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
