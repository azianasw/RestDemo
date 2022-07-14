using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp
{
    public class WebApi
    {
        private static readonly string _baseUri = "https://localhost:44380/api/";

        public static async Task<HttpResponseMessage> GetAsync(string url)
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

                    return await client.GetAsync(apiUrl);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                return await client.PostAsync(apiUrl, content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PutAsync<T>(string url, T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                return await client.PutAsync(apiUrl, content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = _baseUri + url;

                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                return await client.DeleteAsync(apiUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
