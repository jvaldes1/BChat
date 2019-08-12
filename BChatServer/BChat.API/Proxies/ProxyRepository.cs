using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BChat.Data.Model;
using Newtonsoft.Json;

namespace BChat.API.Proxies
{
    class ProxyRepository : IRepository
    {
        private string URL = ConfigurationManager.AppSettings["URL"];

        public string GetCsvMessages()
        {
            var list = new List<Message>();

            var client = new HttpClient {BaseAddress = new Uri(URL)};

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var data = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                data = data.Replace("\\", string.Empty);
                data = data.TrimStart('\"');
                data = data.TrimEnd('\"');
                list = JsonConvert.DeserializeObject<List<Message>>(data);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            if (list.Any())
            {
                var sb = new StringBuilder();
                foreach (var message in list)
                {
                    sb.AppendLine(message.Id + "," + message.User + "," + message.Timestamp + "," + message.Content);
                }

                return sb.ToString();
            }
            else
            {
                return "";
            }
        }


        public Result AddMessage(Message message)
        {
            var client = new HttpClient( );
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var contentStr = JsonConvert.SerializeObject(message);
            StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
            // List data response.
            var response = client.PostAsync(new Uri(URL), content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                return new Result(){Status = true};
            }
            else
            {
                return new Result() { Status = false, OutputMessage = response.ReasonPhrase};
            }
        }

        public Result AddMessage(string command)
        {
            var builder = new CommandBuilder(command);

            if (builder.IsValid())
            {
                return AddMessage(builder.GetMessage());
            }
            else
            {
                return new Result(){ Status = false, OutputMessage = "Invalid Command"};
            }
        }
    }
}
