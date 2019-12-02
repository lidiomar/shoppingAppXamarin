using System;

using Foundation;
using UIKit;
using SDWebImage;

namespace Ios.app.catalog
{
    public partial class CatalogTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CatalogTableViewCell");
        public static readonly UINib Nib = UINib.FromName("CatalogTableViewCell", NSBundle.MainBundle);

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
            ProductImage.SetImage(new NSUrl("https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/07b3b1d8-48f8-11e6-aa97-020adee616d7.jpeg"));
        }
    }
}
