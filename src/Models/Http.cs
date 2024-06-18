using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
    public class MyAnimeHTTP
    {
        public string Url { get; set; }
        public bool ResponseExists {  get; set; }
        public dynamic JsonData { get; set; }

        public void Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            int retryCount = 0;
            int maxRetries = 5;
            TimeSpan backoffPeriod = TimeSpan.FromSeconds(0.5);
            JsonData = null;

            do
            {
                if (retryCount > 0)
                {
                    Thread.Sleep(500);
                }
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync(Url).Result;
                    ResponseExists = response.IsSuccessStatusCode;
                    if (ResponseExists)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JsonData = JsonConvert.DeserializeObject(responseBody);
                    }
                }

                if ((int)response.StatusCode == 429)
                {
                    retryCount++;
                }
                else
                {
                    break;
                }
            } while (retryCount <= maxRetries);
        } 
    }
