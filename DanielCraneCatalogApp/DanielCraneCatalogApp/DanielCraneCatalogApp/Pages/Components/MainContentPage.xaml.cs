﻿using System;
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

            CoverWrapper.HeightRequest = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            CoverWrapper.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

            protected async void ResizeImage()
            {
                var assembly = typeof(HomePage).GetTypeInfo().Assembly;
                byte[] imageData;

                Stream stream = assembly.GetManifestResourceStream(ResourcePrefix + "OriginalImage.JPG");
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    imageData = ms.ToArray();
                }

                byte[] resizedImage = await ImageResizer.ResizeImage(imageData, 400, 400);


                this._photo.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage));
            }

            //DataWrapper.HeightRequest = i;
            // this is what you would call, a last ditch effort
            // adds padding under the background image in the code behind
            //DataWrapper.Padding = new Thickness(0, (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density) + 50, 0, 0);
        }
    }
}