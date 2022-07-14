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
        private TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public RefreshTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                string endpoint = "tarifAirTangki?";

                endpoint += !string.IsNullOrEmpty(_tarifAirTangkiViewModel.KodeTarif) ? $"kodeTarif={_tarifAirTangkiViewModel.KodeTarif}" : "kodeTarif";
                endpoint += !string.IsNullOrEmpty(_tarifAirTangkiViewModel.NamaTarif) ? $"&namaTarif={_tarifAirTangkiViewModel.NamaTarif}" : "&namaTarif";

                HttpResponseMessage resp = await WebApi.GetAsync(endpoint);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _tarifAirTangkiViewModel.Tats = JsonConvert.DeserializeObject<List<TarifAirTangki>>(
                            resp.Content.ReadAsStringAsync().Result)
                            .Select(_ => new TATViewmModel(_.Id, _.Kategori.KategoriTarif, _.Kategori.NamaTarif, _.BiayaAir)).ToList();

                    _tarifAirTangkiViewModel.NoRecord = false;
                    _tarifAirTangkiViewModel.TotalRecord = _tarifAirTangkiViewModel.Tats.Count;
                }

            }
            catch (Exception)
            {
            }

        }
    }
}
