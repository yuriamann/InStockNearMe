using System;
using System.Collections.Generic;
using System.Text;

using InStockNearMe.Models;
using System.Collections.ObjectModel;
using InStockNearMe.Services; 

namespace InStockNearMe.ViewModels
{
    class FinalizedListViewModel
    {
        public ObservableCollection<Cart> SearchResults { get; set; }

        public FinalizedListViewModel()
        {
            SearchResults = DataManager.searchResults;    
        }
    }
}
