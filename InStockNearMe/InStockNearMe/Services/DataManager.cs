using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using InStockNearMe.Models; 

namespace InStockNearMe.Services
{
    class DataManager
    {
        private static readonly object sLock = new object();
        private static DataManager s = null;
        public static ObservableCollection<Cart> searchResults = new ObservableCollection<Cart>();

        public DataManager()
        {

        }

        public void resetResults()
        {
            searchResults = new ObservableCollection<Cart>();
        }

        public void setResults(List<Cart> newList)
        {
            searchResults = new ObservableCollection<Cart>(newList);
            printResults(); 
        }

        public void addToResults(List<Cart> newList)
        {
            foreach (Cart newChain in newList)
            {
                string store = newChain.StoreChain;
                var chainMatches = searchResults.Where(p => p.StoreChain.Equals(store));
                if (chainMatches.Any()) // store chain exists in list already 
                {
                    // search within chain for matching branches 

                    // search within branch for matching items 

                }
                else // store chain does not exist in list already 
                {
                    searchResults.Add(newChain);
                }
            }
        }

        public void printResults()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < searchResults.Count; i++)
            {
                Console.WriteLine("Chain: " + searchResults[i].StoreChain);
                Console.WriteLine("Num Stores: " + searchResults[i].Stores.Length); 
                //Console.WriteLine("Num Stores: " + searchResults[i].Stores.Length);
                for (int j = 0; j < searchResults[i].Stores.Length; j++)
                {                   
                    Console.WriteLine(searchResults[i].Stores[j].Address);
                    //Console.WriteLine(searchResults[i].Stores[j].ItemsByQuery.Keys.Count);
                    //Console.WriteLine(searchResults[i].Stores[j].Metadata.Keys.Count);
                    //Console.WriteLine("Num items: " + searchResults[i].Stores[j].Items.Count);
                    //foreach (var item in searchResults[i].Stores[j].Items)
                    //{
                    //    Console.Write("Name: " + item.ItemName);
                    //    Console.Write("Quantity: " + item.ItemAvailabilities[0].Quantity);
                    //    Console.Write("Price: " + item.ItemAvailabilities[0].PriceLower);
                    //}
                }
                Console.WriteLine("\n");
            }
        }

        public static DataManager S
        {
            get
            {
                lock (sLock)
                {
                    if (s == null)
                    {
                        s = new DataManager();
                    }
                    return s;
                }
            }
        }
    }
}
