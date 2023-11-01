using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IMDB
{
    public string Id = "تا 10 فیلم قابل پشتیبانی است";
    public string MId = "";
    public string MTitel = "";
    public string MPoster = "";
    public string MYear = "";
    public string MCountry = "";
    public string MIMDB = "";

    public async void Movie()
    {
        HttpClient httpclient = new HttpClient();
        string stringAPI = "http://moviesapi.ir/api/v1/movies?page=1";
        HttpResponseMessage response = await httpclient.GetAsync(stringAPI);

        if (response.IsSuccessStatusCode)
        {
            string apiresponse = await response.Content.ReadAsStringAsync();
            Root5 apiWrapper = JsonConvert.DeserializeObject<Root5>(apiresponse);
            List<Datum> dataItems = apiWrapper.data;
            string c = Id.Remove(0, 3);
            int C = int.Parse(c);
            foreach (var item in dataItems)
            {
                if (C == item.id)
                {
                    MId = c;
                    MTitel = item.title;
                    MPoster = item.poster;
                    MYear = item.year;
                    MCountry = item.country;
                    MIMDB = item.imdb_rating;
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
public class Datum
{
    public int id { get; set; }
    public string title { get; set; }
    public string poster { get; set; }
    public string year { get; set; }
    public string country { get; set; }
    public string imdb_rating { get; set; }
}
public class Root5
{
    public List<Datum> data { get; set; }
}
