using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class RefreshTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public RefreshTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                string endpoint = $"tarifAirTangki?{_tarifAirTangkiViewModel.GetFilters()}";

                HttpResponseMessage resp = await WebApi.GetAsync(endpoint);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _tarifAirTangkiViewModel.TarifAirTangki = JsonConvert.DeserializeObject<List<TarifAirTangki>>(
                            resp.Content.ReadAsStringAsync().Result)
                            .Select(_ => new TATViewmModel { Id = _.Id, KategoriTarif = _.Kategori.KategoriTarif, NamaTarif = _.Kategori.NamaTarif, BiayaAir = _.BiayaAir }).ToList();
                }

            }
            catch (Exception)
            {
            }

        }
    }
}
