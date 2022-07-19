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
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44380/api/")
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

        private async Task<string> GetJsonResponse(string uri)
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
