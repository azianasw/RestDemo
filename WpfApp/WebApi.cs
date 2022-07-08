using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp
{
    class WebApi
    {
        private static readonly string _baseUri = "https://localhost:44380/api/";

        public static Task<HttpResponseMessage> Get(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(apiUrl);
                    response.Wait();

                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Task<HttpResponseMessage> Post<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                    var response = client.PostAsync(apiUrl, content);
                    response.Wait();

                    return response;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static Task<HttpResponseMessage> Put<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                    var response = client.PutAsync(apiUrl, content);
                    response.Wait();

                    return response;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static Task<HttpResponseMessage> Delete(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var response = client.DeleteAsync(apiUrl);
                    response.Wait();

                    return response;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
