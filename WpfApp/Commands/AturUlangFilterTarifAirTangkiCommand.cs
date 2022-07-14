using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class AturUlangFilterTarifAirTangkiCommand : CommandBase
    {
        private TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public AturUlangFilterTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _tarifAirTangkiViewModel.KodeTarifChecked = false;
            _tarifAirTangkiViewModel.KodeTarif = null;
            _tarifAirTangkiViewModel.NamaTarifChecked = false;
            _tarifAirTangkiViewModel.NamaTarif = null;

            _ = await Task.FromResult(false);
        }
    }
}
