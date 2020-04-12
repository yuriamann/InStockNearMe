using System;

using InStockNearMe.Models;

namespace InStockNearMe.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public CartItem Item { get; set; }
        public ItemDetailViewModel(CartItem item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
