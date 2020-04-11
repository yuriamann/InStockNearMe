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

            Quantity.Items.Add("1");
            Quantity.Items.Add("2");
            Quantity.Items.Add("3");
            Quantity.Items.Add("4");
            Quantity.Items.Add("5");
            Quantity.Items.Add("6");
            Quantity.Items.Add("7");
            Quantity.Items.Add("8");
            Quantity.Items.Add("9");
            Quantity.Items.Add("10");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        private void Distance_SelectedIndexChanged(object sender, EventArgs e)
        {
            var distancehehe = Distance.Items[Distance.SelectedIndex];

        }

        private void Quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var quantityhehe = Quantity.Items[Quantity.SelectedIndex];
        }
    }
}