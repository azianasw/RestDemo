using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class SubmitTarifAirTangkiCommand : CommandBase
    {
        private TambahTarifAirTangkiViewModel _tambahTarifAirTangkiViewModel;

        public SubmitTarifAirTangkiCommand(TambahTarifAirTangkiViewModel tambahTarifAirTangkiViewModel)
        {
            _tambahTarifAirTangkiViewModel = tambahTarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (_tambahTarifAirTangkiViewModel.IsEdit)
                {
                    TarifAirTangki updateTat = new TarifAirTangki
                    {
                        Id = _tambahTarifAirTangkiViewModel.SelectedTat.Id,
                        BiayaAir = _tambahTarifAirTangkiViewModel.BiayaAir,
                        KategoriId = _tambahTarifAirTangkiViewModel.Selected.Id
                    };

                    HttpResponseMessage response = await WebApi.PutAsync($"tarifAirTangki/{updateTat.Id}", updateTat);
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        _ = MessageBox.Show("Data berhasil diubah!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    TarifAirTangki newTat = new TarifAirTangki { BiayaAir = _tambahTarifAirTangkiViewModel.BiayaAir, KategoriId = _tambahTarifAirTangkiViewModel.Selected.Id };
                    HttpResponseMessage response = await WebApi.PostAsync("tarifAirTangki", newTat);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        _ = MessageBox.Show("Data berhasil ditambahkan!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
