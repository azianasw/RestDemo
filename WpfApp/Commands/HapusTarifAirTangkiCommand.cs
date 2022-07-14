using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class HapusTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public HapusTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            HttpResponseMessage resp = await WebApi.DeleteAsync($"tarifAirTangki/{_tarifAirTangkiViewModel.SelectedTat.Id}");

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _ = MessageBox.Show("Data berhasil dihapus!", "Hapus", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
