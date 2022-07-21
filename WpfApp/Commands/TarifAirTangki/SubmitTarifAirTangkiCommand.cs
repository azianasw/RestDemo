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
        private readonly TambahTarifAirTangkiViewModel _viewModel;
        private readonly IRestApi _restApi;
        private readonly INotification _notification;

        public SubmitTarifAirTangkiCommand(TambahTarifAirTangkiViewModel viewModel, IRestApi restApi, INotification notification)
        {
            _viewModel = viewModel;
            _restApi = restApi;
            _notification = notification;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.IsEdit)
            {
                TarifAirTangki updateTat = new TarifAirTangki
                {
                    Id = _viewModel.Id,
                    BiayaAir = _viewModel.BiayaAir,
                    KategoriId = _viewModel.SelectedKategori.Id
                };

                await _restApi.PutAsync($"tarifAirTangki/{updateTat.Id}", updateTat);

                _notification.Show("Data berhasil dikoreksi.");
            }
            else
            {
                TarifAirTangki newTat = new TarifAirTangki
                {
                    BiayaAir = _viewModel.BiayaAir,
                    KategoriId = _viewModel.SelectedKategori.Id
                };

                await _restApi.PostAsync("tarifAirTangki", newTat);

                _notification.Show("Data berhasil ditambah.");
            }
        }
    }
}
