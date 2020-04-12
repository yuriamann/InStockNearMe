using InStockNearMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InStockNearMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            Distance.Items.Add("1 Mile");
            Distance.Items.Add("5 Miles");
            Distance.Items.Add("10 Miles");
            Distance.Items.Add("15 Miles");
            Distance.Items.Add("20 Miles");

            Stores.Items.Add("Walmart");
            Stores.Items.Add("Walgreens");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FinalizedListPage());
        }

        private void Distance_SelectedIndexChanged(object sender, EventArgs e)
        {
            var distancehehe = Distance.Items[Distance.SelectedIndex];

        }

        private void Stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var storeshehe = Stores.Items[Stores.SelectedIndex];
        }
    }
}