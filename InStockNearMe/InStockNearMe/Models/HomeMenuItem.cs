using System;
using System.Collections.Generic;
using System.Text;

namespace InStockNearMe.Models
{
    public enum MenuItemType
    {
        Browse,
        ShoppingCart,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
