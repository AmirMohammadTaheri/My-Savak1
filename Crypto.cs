using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Crypto
{
    public string crypto = "";
    public string cryptoName = "there is no data about this crypto currencies";
    public string cryptoPrice = "0";
    public async void Api()
    {
        HttpClient httpclient = new HttpClient();
        string stringAPI = "https://api.wallex.ir/v1/currencies/stats";
        HttpResponseMessage response = await httpclient.GetAsync(stringAPI);

        if (response.IsSuccessStatusCode)
        {
            string apiresponse = await response.Content.ReadAsStringAsync();
            ApiResponseWrapper apiWrapper = JsonConvert.DeserializeObject<ApiResponseWrapper>(apiresponse);
            List<DataItem> dataItems = apiWrapper.result;
            string C = crypto.Remove(0, 3);
            foreach (var item in dataItems)
            {
                if (C == item.key)
                {
                    cryptoName = item.name_en;
                    cryptoPrice = item.price;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
   
}
public class ApiResponseWrapper
{
    public List<DataItem> result { get; set; }

}
public class DataItem
{
    public string key { get; set; }
    public string name_en { get; set; }
    public string rank { get; set; }
    public string price { get; set; }
    public string daily_high_price { get; set; }
    public string daily_low_price { get; set; }
    public string weekly_high_price { get; set; }
    public string weekly_low_price { get; set; }
    public string price_change_24h { get; set; }
    public string price_change_7d { get; set; }
    public DateTime updated_at { get; set; }
}
