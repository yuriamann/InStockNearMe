using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using InStockNearMe.Models; 

namespace InStockNearMe.Services 
{
    class ProductAPIManager
    {
        private static User me = new User("app");
        static HttpClient client = new HttpClient();
        private static string url = "http://a83d595b.ngrok.io/search";

        public async static Task<bool> SendRequest(string product, string brand, float maxDistance, List<string> stores, Models.Location location)
        {
            Models.Location here = new Models.Location("2963 S. Law Ave, Boise ID");
            SearchQuery query = new SearchQuery(product, brand, DateTime.Now.Ticks, maxDistance, stores,
            me,
            location, DeviceInfo.DeviceType.ToString());

            var JSONreq = JsonConvert.SerializeObject(query);
            // Console.WriteLine(JSONreq);

            var response = await client.PostAsync(url, new StringContent(JSONreq, Encoding.UTF8, "application/json"));
            //Console.WriteLine(response); 

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                var retVal = JsonConvert.DeserializeObject<List<Cart>>(responseString);
                DataManager.S.setResults(retVal);
                return true; 
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response);
                return false; 
            }
        }
    }
}