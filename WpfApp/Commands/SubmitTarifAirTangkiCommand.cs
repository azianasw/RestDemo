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
        private readonly TambahTarifAirTangkiViewModel _tambahTarifAirTangkiViewModel;

        public SubmitTarifAirTangkiCommand(TambahTarifAirTangkiViewModel tambahTarifAirTangkiViewModel)
        {
            _tambahTarifAirTangkiViewModel = tambahTarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_tambahTarifAirTangkiViewModel.IsEdit)
            {
                TarifAirTangki updateTat = new TarifAirTangki
                {
                    Id = _tambahTarifAirTangkiViewModel.SelectedTat.Id,
                    BiayaAir = _tambahTarifAirTangkiViewModel.BiayaAir,
                    KategoriId = _tambahTarifAirTangkiViewModel.Selected.Id
                };

                await _tambahTarifAirTangkiViewModel.RestApi.PutAsync($"tarifAirTangki/{updateTat.Id}", updateTat);

                _ = MessageBox.Show("Data berhasil diubah!.");
            }
            else
            {
                TarifAirTangki newTat = new TarifAirTangki
                {
                    BiayaAir = _tambahTarifAirTangkiViewModel.BiayaAir,
                    KategoriId = _tambahTarifAirTangkiViewModel.Selected.Id
                };

                await _tambahTarifAirTangkiViewModel.RestApi.PostAsync("tarifAirTangki", newTat);

                _ = MessageBox.Show("Data berhasil ditambah!.");
            }
        }
    }
}
