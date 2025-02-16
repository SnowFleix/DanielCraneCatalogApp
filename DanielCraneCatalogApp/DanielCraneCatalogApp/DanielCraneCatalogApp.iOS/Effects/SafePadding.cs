﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DanielCraneCatalogApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using Foundation;
using UIKit;

[assembly: ResolutionGroupName("DanielCraneCatalogApp")]
[assembly: ExportEffect(typeof(SafePadding), nameof(SafePadding))]
namespace DanielCraneCatalogApp.iOS
{
    class SafePadding : PlatformEffect
    {
        Thickness _padding;
        protected override void OnAttached()
        {
            if (Element is Layout element)
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                {
                    _padding = element.Padding;
                    var insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets;

                    if (insets.Top > 0)
                    {
                        element.Padding = new Thickness(_padding.Left + insets.Left, _padding.Top + insets.Top, _padding.Right + insets.Right, _padding.Bottom + insets.Bottom);
                        return;
                    }
                }

                element.Padding = new Thickness(_padding.Left, _padding.Top + 20, _padding.Right, _padding.Bottom + 20);
            }
        }

        protected override void OnDetached()
        {
            if (Element is Layout element)
            {
                element.Padding = _padding;
            }
        }
    }
}