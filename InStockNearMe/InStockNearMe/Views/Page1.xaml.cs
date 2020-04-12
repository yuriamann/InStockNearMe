using InStockNearMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InStockNearMe.Services; 

namespace InStockNearMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        List<string> itemNames;
        float distancehehe;
        List<string> storeshehe = new List<string>(); 
        public Page1(List<string> newItemNames)
        {
            InitializeComponent();
            Distance.Items.Add("1");
            Distance.Items.Add("5");
            Distance.Items.Add("10");
            Distance.Items.Add("15");
            Distance.Items.Add("20");

            Stores.Items.Add("Walmart");
            Stores.Items.Add("Walgreens");

            itemNames = newItemNames; 

        }

        private async void Button_Clicked(object sender, EventArgs e)
        { 
            await ProductAPIManager.SendRequest(itemNames, null, distancehehe, storeshehe, new Location(addy.Text, zipcode.Text));

            await Navigation.PushAsync(new FinalizedListPage());
        }

        private void Distance_SelectedIndexChanged(object sender, EventArgs e)
        {
            string distance = Distance.Items[Distance.SelectedIndex];
            float.TryParse(distance, out float result);
            distancehehe = result; 

        }

        private void Stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            storeshehe = new List<String>() { Stores.Items[Stores.SelectedIndex].ToLower() };
        }
    }
}