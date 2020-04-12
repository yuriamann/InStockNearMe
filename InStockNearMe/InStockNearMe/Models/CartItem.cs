using System;

namespace InStockNearMe.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}