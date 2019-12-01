using System;

using Foundation;
using UIKit;
using SDWebImage;
namespace Ios
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
            ProductImage.SetImage(new NSUrl("https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/fda44b12-48f7-11e6-996c-0aad52ea90db.jpeg"));
        }
    }
}
