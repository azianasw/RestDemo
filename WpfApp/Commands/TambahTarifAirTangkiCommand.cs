using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp.Commands
{
    public class TambahTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public TambahTarifAirTangkiCommand()
        {
        }

        public TambahTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                HttpResponseMessage responseKategori = await WebApi.GetAsync("kategori");

                if (responseKategori.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Kategori> kategori = JsonConvert.DeserializeObject<List<Kategori>>(
                            responseKategori.Content.ReadAsStringAsync().Result).ToList();

                    _ = bool.TryParse((string)parameter, out bool isEdit)
                        ? await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(kategori, _tarifAirTangkiViewModel.SelectedTat, "Koreksi Tarif Air Tangki", isEdit)), "DialogHost")
                        : await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(kategori)), "DialogHost");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
