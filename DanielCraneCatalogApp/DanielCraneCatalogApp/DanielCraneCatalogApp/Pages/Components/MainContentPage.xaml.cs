using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DanielCraneCatalogApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        public MainContentPage(ContentPageModel content)
        {
            InitializeComponent();
            this.BindingContext = content;

            CoverWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
            DataWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
            DataWrapper.Padding = new Thickness(0, (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density), 0, 0);
        }
    }
}