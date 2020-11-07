using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanielCraneCatalogApp
{
    public partial class App : Application
    {
        public App()
        {
            List<ContentPage> pages = new List<ContentPage>(0);
            // implement a feature to add new pages from the database to here

            ContentPageModel content = new ContentPageModel();

            content.Title = "Example title";
            content.BackgroundImage = "TestImage.png";
            content.ShortDescription = "Description of the image";
            content.DataTitle = "This is a title";
            content.DataDescription = "This is an example of a description";
            content.DataLongDescription = "This is a very long description about the image to the left which is kind of important";
            content.DataImageSource = "TestImage.jpg";
            content.DataPrice = "£100.00";
            
            for (int i = 0; i < 5; i++) {
                pages.Add(new MainContentPage(content));
            }

            InitializeComponent();

            CarouselPage MainContent = new CarouselPage();

            // TODO : check if the pages are empty and crash with dignity
            foreach (ContentPage cp in pages)
                MainContent.Children.Add(cp);

            MainPage = MainContent;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
