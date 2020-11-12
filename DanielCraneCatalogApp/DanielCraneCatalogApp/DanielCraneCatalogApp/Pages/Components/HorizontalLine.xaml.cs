using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanielCraneCatalogApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorizontalLine : StackLayout
    {
        public HorizontalLine()
        {
            InitializeComponent();
        }
    }
}