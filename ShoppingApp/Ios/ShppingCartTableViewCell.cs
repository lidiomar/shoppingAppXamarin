using System;

using Foundation;
using UIKit;
using SDWebImage;
namespace Ios
{
    public partial class ShppingCartTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ShppingCartTableViewCell");
        public static readonly UINib Nib;

        static ShppingCartTableViewCell()
        {
            Nib = UINib.FromName("ShppingCartTableViewCell", NSBundle.MainBundle);
        }

        public static ShppingCartTableViewCell Create()
        {
            return (ShppingCartTableViewCell)Nib.Instantiate(null, null)[0];
        }

        protected ShppingCartTableViewCell(IntPtr handle) : base(handle)
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
