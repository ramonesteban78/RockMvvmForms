using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MarvelRockSample;
using MarvelRockSample.iOS;
using System.ComponentModel;
using UIKit;
using System.Drawing;

[assembly: ExportRenderer(typeof(ImageCircle), typeof(ImageCircleRenderer))]
namespace MarvelRockSample.iOS
{
	public class ImageCircleRenderer : ImageRenderer
	{
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null) return;


			if (e.PropertyName == Image.IsLoadingProperty.PropertyName
				&& !this.Element.IsLoading && this.Control.Image != null)
			{
				DrawOther();
			}

		}


		private void DrawOther()
		{
			int height = 0;
			int width = 0;
			int top = 0;
			int left = 0;

			switch (this.Element.Aspect)
			{
			case Aspect.AspectFill:
				height = (int)this.Control.Image.Size.Height;
				width = (int)this.Control.Image.Size.Width;
				height = width;
				left = (((int)this.Control.Image.Size.Width - width) / 2);
				top = (((int)this.Control.Image.Size.Height - height) / 2);
				break;
			case Aspect.AspectFit:
				height = (int)this.Control.Image.Size.Height;
				width = (int)this.Control.Image.Size.Width;
				height = width;
				left = (((int)this.Control.Image.Size.Width - width) / 2);
				top = (((int)this.Control.Image.Size.Height - height) / 2);
				break;
			default:
				throw new NotImplementedException();
			}

			UIImage image = this.Control.Image;
			var clipRect = new RectangleF(0, 0, width, height);
			var scaled = image.Scale(new SizeF(width, height));
			UIGraphics.BeginImageContextWithOptions(new SizeF(width, height), false, 0f);
			UIBezierPath.FromRoundedRect(clipRect, Math.Max(width, height) / 2).AddClip();

			scaled.Draw(new RectangleF(0, 0, (float)scaled.Size.Width, (float)scaled.Size.Height));
			UIImage final = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			this.Control.Image = final;
		}
	}
}

