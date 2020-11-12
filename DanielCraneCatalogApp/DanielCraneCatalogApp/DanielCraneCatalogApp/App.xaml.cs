using System;
using System.IO;
using System.Reflection;
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
            string[] pictures = { "BeachRidersTestImage.png", "FoxTestImage.png", "GateJumpTestImage.png", "HoundPackTestImage.png", "HoundTestImage.png", "HouseHoldCavalryTestImage.png", "HuntTestImage.png", "RiderTestImage.png", "StablesTestImage.png", "WhatAChanceTestImage.png" };

            content.Title = "Example title";
            content.BackgroundImage = "SampleImage.png";
            content.ShortDescription = "Description of the image";
            content.DataTitle = "This is a title";
            content.DataDescription = "This is an example of a description, Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sodales nisl at condimentum volutpat.";
            content.DataLongDescription = "This is a very long description about the image to the left which is kind of important, Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sodales nisl at condimentum volutpat.";
            content.DataImageSource = "ProfilePictureTestImage.png";
            content.PortfolioDescription = "This is a description of the portfolio, Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sodales nisl at condimentum volutpat.";
            content.DataPictureType = "Original";
            content.DataPrice = "£0.00";
            
            for (int i = 0; i < pictures.Length; i++) {
                content.BackgroundImage = pictures[i];
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
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
