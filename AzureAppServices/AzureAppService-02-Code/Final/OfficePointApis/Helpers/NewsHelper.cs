using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace OfficePointApis.Helpers
{
    public class NewsHelper
    {
        public async static Task<List<NewsInformation>> GetTrendingNewsAsync()
        {
            List<NewsInformation> newsResults = new List<NewsInformation>();

            
            string queryUri = "https://bingapis.azure-api.net/api/v5/news/search";

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.SecureConstants.BingApiKey);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            string bingRawResponse;

            TrendingNewsInformation bingJsonResponse = null;

            try
            {
                bingRawResponse = await httpClient.GetStringAsync(queryUri);
                bingJsonResponse = JsonConvert.DeserializeObject<TrendingNewsInformation>(bingRawResponse);
            }
            catch (Exception ex)
            {
            }

            newsResults = bingJsonResponse.value.ToList();
            
            return newsResults;
        }
    }
}