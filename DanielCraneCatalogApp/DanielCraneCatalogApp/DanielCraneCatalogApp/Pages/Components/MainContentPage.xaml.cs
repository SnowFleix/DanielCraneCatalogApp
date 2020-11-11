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
        public MainContentPage(ContentPageModel content)
        {
            InitializeComponent();
            this.BindingContext = content;

            // Doesn't seem to work without using a double
            double deviceWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            double deviceHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            CoverWrapper.HeightRequest = deviceHeight;
            CoverWrapper.WidthRequest = deviceWidth;
        }
    }
}