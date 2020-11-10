using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using DanielCraneCatalogApp.Interfaces;

namespace DanielCraneCatalogApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        public static string ResourcePrefix = "";

#if __IOS__
		public static string ResourcePrefix = "XamFormsImageResize.iOS.";
#endif
#if __ANDROID__
		public static string ResourcePrefix = "XamFormsImageResize.Android.";
#endif

        async void ResizeImage(double height, double width)
        {
            var assembly = typeof(MainContentPage).GetTypeInfo().Assembly;
            byte[] imageData;

            Stream stream = assembly.GetManifestResourceStream(ResourcePrefix + "OriginalImage.JPG");
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                imageData = ms.ToArray();
            }

            // c-style casting is usually bad, change later
            byte[] resizedImage = await ImageResizer.ResizeImage(imageData, (float)width, (float)height);


            BackgroundImage.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage));
        }

        public MainContentPage(ContentPageModel content)
        {
            InitializeComponent();
            this.BindingContext = content;

            double deviceWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double deviceHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            CoverWrapper.HeightRequest = deviceHeight;
            CoverWrapper.WidthRequest = deviceWidth;

            //ResizeImage()

            //DataWrapper.HeightRequest = i;
            // this is what you would call, a last ditch effort
            // adds padding under the background image in the code behind
            //DataWrapper.Padding = new Thickness(0, (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density) + 50, 0, 0);
        }
    }
}