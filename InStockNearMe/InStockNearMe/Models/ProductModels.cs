using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace InStockNearMe.Models
{
    public class Item
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("categoryName")] public string CategoryName { get; set; }
        [JsonProperty("price")] public float? Price { get; set; }
        [JsonProperty("size")] public float? Size { get; set; }
        [JsonProperty("unit")] public string Unit { get; set; }
        [JsonProperty("itemName")] public string ItemName { get; set; }

        [JsonProperty("brand")] public string Brand { get; set; }
        [JsonProperty("priority")] public int Priority { get; set; }
        [JsonProperty("hotness")] public int Hotness { get; set; }
        [JsonProperty("itemUrl")] public string ItemUrl { get; set; }
        [JsonProperty("itemAvailabilities")] public List<ItemAvailability> ItemAvailabilities { get; set; }
        [JsonProperty("averageRating")] public string AverageRating { get; set; }
        [JsonProperty("availableOnline")] public bool AvailableOnline { get; set; }
        [JsonProperty("imageUrl")] public string ImageUrl { get; set; }
    }

    public class ItemAvailability
    {
        [JsonProperty("quantity")] public int? Quantity { get; set; }
        [JsonProperty("priceLower")] public string PriceLower { get; set; }
        [JsonProperty("priceUpper")] public string PriceUpper { get; set; }
    }

    public class Location
    {
        [JsonProperty("address")] public string Address { set; get; }
        [JsonProperty("latitude")] public decimal? Latitude { set; get; }
        [JsonProperty("longitude")] public decimal? Longitude { set; get; }
        [JsonProperty("zip")] public string Zip { set; get; }

        public Location()
        {
        }

        public Location(string address = null, string zip = null, decimal ? latitude = null, decimal? longitude = null)
        {
            Address = address;
            Zip = zip;
            Latitude = latitude;
            Longitude = longitude;
            
        }
    }

    public class Cart
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("storeChain")] public string StoreChain { get; set; }
        [JsonProperty("stores")] public Store[] Stores { get; set; }
        [JsonProperty("location")] public Location Location { get; set; }
    }

    public class Store
    {
        [JsonProperty("address")] public string Address { set; get; }
        [JsonProperty("name")] public string Name { set; get; }
        [JsonProperty("brand")] public string Brand { set; get; }
        [JsonProperty("isOpen")] public bool? IsOpen { set; get; }
        [JsonProperty("openTime")] public string OpenTime { set; get; }
        [JsonProperty("closeTime")] public string CloseTime { set; get; }
        [JsonProperty("metadata")] public Dictionary<string, object> Metadata { set; get; }
        [JsonProperty("services")] public List<string> Services { set; get; }
        [JsonProperty("phone")] public string Phone { set; get; }
        [JsonProperty("items")] public List<Tuple<string, List<Item>>> Items { get; set; }

        public List<Item> ItemsList{ get; set; } 

        public Store()
        {
            ItemsList = new List<Item>(); 
        }

    }

    public class SearchQuery
    {
        [JsonProperty("time")] public long Time { set; get; }
        [JsonProperty("maxDistance")] public float MaxDistance { set; get; }
        [JsonProperty("includedStores")] public List<string> IncludedStores { set; get; } // kroger, walgreens 
        [JsonProperty("user")] public User User { set; get; }
        [JsonProperty("location")] public Location Location { set; get; }
        [JsonProperty("device")] public string Device { set; get; }

        [JsonProperty("queries")] public List<string> Queries { set; get; }

        [JsonProperty("options")] public Dictionary<string, object> Options { get; set; }

        [JsonProperty("brand")] public string Brand { get; set; }

        public SearchQuery()
        {
        }

        public SearchQuery(List<string> queries, string brand, long time, float maxDistance, List<string> includedStores,
            User user,
            Location location, string device, Dictionary<string, object> options = null)
        {
            Queries = queries;
            Brand = brand;
            Time = time;
            MaxDistance = maxDistance;
            IncludedStores = includedStores;
            User = user;
            Location = location;
            Device = device;
            Options = options;
        }
    }

    public class User
    {
        [JsonProperty("id")] public string Id { set; get; }
        public User()
        {
        }

        public User(string id)
        {
            Id = id;
        }
    }
}
