using MarvelRockSample;
using MarvelRockSample.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ImageCircle), typeof(ImageCircleRenderer))]
namespace MarvelRockSample.UWP.Renderers
{
    public class ImageCircleRenderer : ViewRenderer<Image, Ellipse>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
        {
            var temp = DateTime.Now;
        }

        /// <summary>
        /// Register circle
        /// </summary>
        /// <param name="e"></param>
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            var ellipse = new Ellipse();
            SetNativeControl(ellipse);

        }

        Xamarin.Forms.ImageSource file = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;



            var min = Math.Min(Element.WidthRequest, Element.HeightRequest) / 2.0f;
            if (min <= 0)
                return;

            try
            {

                Control.Width = Element.WidthRequest;
                Control.Height = Element.HeightRequest;

                var force = e.PropertyName == VisualElement.XProperty.PropertyName ||
                    e.PropertyName == VisualElement.YProperty.PropertyName ||
                    e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                    e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                    e.PropertyName == VisualElement.ScaleProperty.PropertyName ||
                    e.PropertyName == VisualElement.TranslationXProperty.PropertyName ||
                    e.PropertyName == VisualElement.TranslationYProperty.PropertyName ||
                    e.PropertyName == VisualElement.RotationYProperty.PropertyName ||
                    e.PropertyName == VisualElement.RotationXProperty.PropertyName ||
                    e.PropertyName == VisualElement.RotationProperty.PropertyName ||
                    e.PropertyName == VisualElement.AnchorXProperty.PropertyName ||
                    e.PropertyName == VisualElement.AnchorYProperty.PropertyName;


                //already set
                if (file == Element.Source && !force)
                    return;

                file = Element.Source;

                var handler = GetHandler(file);
                if (file == null)
                    return;
                var imageSource = await handler.LoadImageAsync(file);

                if (imageSource != null)
                {
                    Control.Fill = new ImageBrush
                    {
                        ImageSource = imageSource,
                        Stretch = Stretch.UniformToFill,
                    };
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image, falling back to background color.");
            }
        }

        private static IImageSourceHandler GetHandler(Xamarin.Forms.ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }

    }
}
