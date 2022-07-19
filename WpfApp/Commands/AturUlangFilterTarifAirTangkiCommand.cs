using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class AturUlangFilterTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public AturUlangFilterTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _tarifAirTangkiViewModel.ResetFilters();
            _ = await Task.FromResult(true);
        }
    }
}
