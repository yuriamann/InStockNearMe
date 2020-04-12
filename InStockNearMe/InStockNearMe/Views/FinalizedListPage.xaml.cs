using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InStockNearMe.ViewModels;


namespace InStockNearMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalizedListPage : ContentPage
    {
        FinalizedListViewModel viewModel;

        public FinalizedListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FinalizedListViewModel();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EmailAddressInfo()));
        }
    }
}