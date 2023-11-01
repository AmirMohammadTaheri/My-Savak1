using System;
using System.Data;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;
using Newtonsoft.Json;
int OFFSET = 0;
string url = $"https://api.telegram.org/bot6591911267:AAFuEWRnHUEvyRFD_LPY6fMCA_Gfs_jxgQM/";
WebClient client = new WebClient();
decimal offset = 0;
while (true)
{
    string DataBot = client.DownloadString($"{url}getupdates?offset={offset}");
    var dJson = JsonConvert.DeserializeObject<Root>(DataBot);
    foreach (var item in dJson.result)
    {

        string url2 = $"{url}sendmessage?chat_id={item.message.chat.id}&text=";
        if (item.message.text == "/start")
        {
            client.DownloadString(url2 + $"Hello. How can I help you");
       
        }
        else if (item.message.text == "/imdb")
        {
            client.DownloadString(url2 + "Here I can show you the Top 10 Imdb movies \n Please Enter your movie number in /F-(Movie number)");
        }
        else if (item.message.text == "/crypto")
        {
            client.DownloadString(url2 + ":Please enter your Crypto currency \n /C-BTC ");
        }
        else if (item.message.text == "/gold")
        {
            GoldApi gold = new GoldApi();
            gold.Gold();
            System.Threading.Thread.Sleep(3000);
            client.DownloadString(url2 +$"Ons price {gold.GoldPrice}\n {gold.GoldPrice18}\n {gold.GoldPrice24}");
        }
        else if (item.message.text.StartsWith("/C-"))
        {
            Crypto crypto = new Crypto();
            crypto.crypto = item.message.text;
            crypto.Api();
            System.Threading.Thread.Sleep(3000);
            client.DownloadString(url2 + $"Currenc Name ={crypto.cryptoName}\n Currency in Ir Toman ={crypto.cryptoPrice}");
        }
        else if (item.message.text.StartsWith("/F-"))
        {
            IMDB imdb = new IMDB();
            imdb.Id = item.message.text;
            imdb.Movie();
            System.Threading.Thread.Sleep(3000);
            client.DownloadString(url2 + $"لینک پوستر = {imdb.MPoster}");
            client.DownloadString(url2 + $"رتبه فیلم = {imdb.MId}\n اسم فیلم = {imdb.MTitel}\n سال ساخت = {imdb.MYear}\n کشور سازنده = {imdb.MCountry}\n امتیاز = {imdb.MIMDB}");
        }
        else
        {
            client.DownloadString(url2 + $"My Services:\n /imdb \n /crypto \n /gold");
        }
        Console.WriteLine($"@{item.message.from.username} Send New Message \n ...........................");
        offset = item.update_id + 1;
    }
}


