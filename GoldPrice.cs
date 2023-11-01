using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GoldApi
{
    string apiKey = "goldapi-26y0zrlobwcbxq-io";
    string symbol = "XAU";
    string curr = "USD";
    string date = "";
    public string GoldPrice = "0";
    public string GoldPrice24 = "0";
    public string GoldPrice18 = "0";
    public async void Gold()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("x-access-token", apiKey);
            string url = $"https://www.goldapi.io/api/{symbol}/{curr}{date}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            var dJson = JsonConvert.DeserializeObject<Root4>(result);
            GoldPrice = dJson.price.ToString();
            GoldPrice18 = dJson.price_gram_18k.ToString();
            GoldPrice24 = dJson.price_gram_18k.ToString();
        }
    }
}
public class Root4
{
    public double price { get; set; }
    public double price_gram_24k { get; set; }
    public double price_gram_18k { get; set; }
}
