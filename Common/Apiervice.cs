using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Apiervice
    {

        public static bool TestCreditCard(string cvv, string cardNumber, int month, int year)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            HttpClient client = new HttpClient(handler);
            //this url was copied from swagger of my project
            string url =
            $@"https://localhost:7133/api/Credit?cardNumberStr={cardNumber}&cvvStr={cvv}&ExpDate={month}%2F{year}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                return response.Content.ReadAsAsync<bool>().Result;
            }
            else
            {
                return false;
            }
        }

        public static string NumberToName(int number , bool isWeb)
        {
            if (isWeb)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://numbers-to-words1.p.rapidapi.com/api/converter/"),
                    Headers =
                    {
                        { "x-rapidapi-key", "94e8ba8c84msh3af07c4e7b2b2c8p144c89jsnaabb9ad56e31" },
                        { "x-rapidapi-host", "numbers-to-words1.p.rapidapi.com" },
                    },
                    Content = new StringContent("{\"number\":"+number+",\"delete_from_sentence\":null,\"currency\":null,\"decimal_currency\":\"millimes\",\"separator\":\"et\",\"decimal\":3,\"language\":\"en\"}")
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }
                };
                using (var response = client.SendAsync(request).Result)
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch
                    {
                        return "NAN";
                    }
                    var body = response.Content.ReadAsAsync<NumberResult>().Result;
                    return body.Message;
                }
            }
            else
            {
                switch(number)
                {
                    //todo;
                    case 0:
                        return "zero";
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    case 4:
                        return "four";
                    case 5:
                        return "five";
                    default:
                        return "NAN";
                }
            }

        }

      
    }

    public class NumberResult
    {
        public string Message { get; set; }
    }

}
