using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InStockNearMe.Models;
using InStockNearMe.Views;
using InStockNearMe.ViewModels;
using InStockNearMe.Services; 

namespace InStockNearMe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public static int count = 0; 

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (CartItem)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("We Clicked Finalize " + ++count);
            
            var listItems = await viewModel.DataStore.GetItemsAsync();
            List<string> itemNames = new List<string>(); 
            foreach (var item in listItems)
            {
                itemNames.Add(item.Text); 
            }

            await ProductAPIManager.SendRequest(itemNames, null, 20, null, new Location("2963 S. Law Ave. Boise, ID", "83706"));
       
            await Navigation.PushModalAsync(new NavigationPage(new FinalizedListPage()));
        }
    }
}