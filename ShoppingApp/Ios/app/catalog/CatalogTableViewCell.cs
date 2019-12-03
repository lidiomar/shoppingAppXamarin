using System;

using Foundation;
using UIKit;
using SDWebImage;
using ShoppingApp.app.model.catalog;
using Shared;
using ShoppingApp.app.catalog.viewmodel;
using System.Collections.Generic;

namespace Ios.app.catalog
{
    public partial class CatalogTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CatalogTableViewCell");
        public static readonly UINib Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);
        public static readonly int plus = 1;
        public static readonly int less = 2;
        public TableSource tableSource;
        public int position;

        static CatalogTableViewCell()
        {
            Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);
        }

        public static CatalogTableViewCell Create()
        {
            return (CatalogTableViewCell)Nib.Instantiate(null, null)[0];
        }

        protected CatalogTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Bind((Product)tableSource.preparedList[position]);

            //Image
            string photoUrl = ((Product)tableSource.preparedList[position]).Photo;
            ProductImage.SetImage(new NSUrl(photoUrl));

            //Favorite
            if (((Product)tableSource.preparedList[position]).Favorite)
            {
                ButtonFavorite.SetBackgroundImage(UIImage.GetSystemImage("star.fill"), UIControlState.Normal);
            }
            else
            {
                ButtonFavorite.SetBackgroundImage(UIImage.GetSystemImage("star"), UIControlState.Normal);
            }

            ButtonFavorite.TouchUpInside -= (sender, args) => { HandlerFavorite(sender, args, position, tableSource.catalogElementViewModel); };
            ButtonFavorite.TouchUpInside += (sender, args) => { HandlerFavorite(sender, args, position, tableSource.catalogElementViewModel); };

            ButtonPlus.TouchUpInside -= (sender, args) => { HandlerChangeItemCount(sender, args, plus, position, tableSource.catalogElementViewModel); };
            ButtonPlus.TouchUpInside += (sender, args) => { HandlerChangeItemCount(sender, args, plus, position, tableSource.catalogElementViewModel); };

            ButtonLess.TouchUpInside -= (sender, args) => { HandlerChangeItemCount(sender, args, less, position, tableSource.catalogElementViewModel); };
            ButtonLess.TouchUpInside += (sender, args) => { HandlerChangeItemCount(sender, args, less, position, tableSource.catalogElementViewModel); };

        }

        void Bind(Product product)
        {
            //Name
            ProductDescription.Text = product.Name;

            //Price
            if (product.SumPrice > 0)
            {
                float displayValue = product.SumPrice - product.DiscountValue;
                ProductPrice.Text = Utils.GetPrice(NSBundle.MainBundle.GetLocalizedString("price", " "), displayValue);
            }
            else
            {
                ProductPrice.Text = Utils.GetPrice(NSBundle.MainBundle.GetLocalizedString("price", " "), product.Price);
            }

            //Quantity
            if (product.Quantity > 0)
            {
                ProductQuantity.Text = Utils.GetUN(NSBundle.MainBundle.GetLocalizedString("un", " "), product.Quantity.ToString());
                ProductQuantity.Hidden = false;
            }
            else
            {
                ProductQuantity.Hidden = true;
            }

            //Discount
            if (product.DiscountPercent > 0)
            {
                ProductDiscount.Text = Utils.GetDiscount(NSBundle.MainBundle.GetLocalizedString("discount", " "), ((int)product.DiscountPercent).ToString());
                ProductDiscount.Hidden = false;
            }
            else
            {
                ProductDiscount.Hidden = true;
            }
        }

        void HandlerChangeItemCount(object sender, EventArgs args, int action, int positionHandler, ICatalogElementViewModel catalogElementViewModel)
        {
            Product product = (Product)tableSource.preparedList[positionHandler];

            if (action == plus)
            {
                product.SumPrice += product.Price;
            }
            else
            {
                if (product.SumPrice <= 0)
                {
                    return;
                }
                product.SumPrice -= product.Price;
            }

            product.DiscountPercent = 0;
            product.Quantity = catalogElementViewModel.GetNumberOfProductsSelected(product);

            if (product.Quantity == 0)
            {
                product.SumPrice = 0;
            }

            if (product.Category != null && tableSource.salesDict.ContainsKey(product.Category))
            {
                Sale sale = tableSource.salesDict[product.Category];
                List<Policie> policies = sale.Policies;
                product.DiscountPercent = catalogElementViewModel.GetPercentDiscount(policies, product.Quantity);
            }

            product.DiscountValue = catalogElementViewModel.GetDiscountValue(product.SumPrice, product.DiscountPercent);

            Bind(product);

            catalogElementViewModel.AddProductToCart(product, product.SumPrice - product.DiscountValue);
            float totalValue = catalogElementViewModel.GetTotalValue();
            tableSource.owner.UpdateButtonBuyValue(totalValue);
        }

        void HandlerFavorite(object sender, EventArgs args, int positionHandler, ICatalogElementViewModel catalogElementViewModel)
        {
            Product product = (Product)tableSource.preparedList[positionHandler];
            if (product.Favorite)
            {
                (sender as UIButton).SetBackgroundImage(UIImage.GetSystemImage("star"), UIControlState.Normal);
                product.Favorite = false;
            }
            else
            {
                (sender as UIButton).SetBackgroundImage(UIImage.GetSystemImage("star.fill"), UIControlState.Normal);
                product.Favorite = true;
            }

            catalogElementViewModel.UpdateProductAsync(product).ContinueWith(i =>
            {
                if (i.IsFaulted || i.IsCanceled)
                {
                    string markAsfavoriteError = NSBundle.MainBundle.GetLocalizedString("favorite_error", " ");
                    string markAsfavoriteErrorFormated = String.Format(markAsfavoriteError, product?.Name);

                    UIAlertController alertController = UIAlertController.Create(null, markAsfavoriteErrorFormated, preferredStyle: UIAlertControllerStyle.Alert);
                    alertController.AddAction(UIAlertAction.Create(NSBundle.MainBundle.GetLocalizedString("cancel", " "), UIAlertActionStyle.Default, (a)=> { }));
                    //TODO
                }
            });
        }
    }



}
