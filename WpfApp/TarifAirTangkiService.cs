using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp
{
    public class TarifAirTangkiService : IRestApi
    {
        private readonly HttpClient _client;

        public TarifAirTangkiService()
        {

            if (Environment.GetEnvironmentVariable("ApiUrl") == null)
            {
                Environment.SetEnvironmentVariable("ApiUrl", "https://localhost:44380/api/");
            }

            _client = new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("ApiUrl"))
            };
        }

        public async Task<List<TatViewModel>> GetAsync(string uri)
        {
            string json = await GetJsonResponse(uri);
            return JsonConvert.DeserializeObject<List<TarifAirTangki>>(json)
                .Select(_ => new TatViewModel
                {
                    Id = _.Id,
                    KategoriTarif = _.Kategori.KategoriTarif,
                    NamaTarif = _.Kategori.NamaTarif,
                    BiayaAir = _.BiayaAir
                })
                .ToList();
        }

        public async Task<List<Kategori>> GetKategoriAsync(string uri)
        {
            string json = await GetJsonResponse(uri);
            return JsonConvert.DeserializeObject<List<Kategori>>(json);
        }

        public async Task PostAsync(string uri, TarifAirTangki newTat)
        {
            StringContent content = BuildStringContentFrom(newTat);
            _ = await _client.PostAsync(uri, content);
        }

        public async Task PutAsync(string uri, TarifAirTangki updateTat)
        {
            StringContent content = BuildStringContentFrom(updateTat);
            _ = await _client.PutAsync(uri, content);
        }

        public async Task DeleteAsync(string uri)
        {
            await _client.DeleteAsync(uri);
        }

        private async Task<string> GetJsonResponse(string uri)
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        private StringContent BuildStringContentFrom(TarifAirTangki model)
        {
            return new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
        }
    }
}
