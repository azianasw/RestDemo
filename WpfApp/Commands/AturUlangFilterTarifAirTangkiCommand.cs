using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class AturUlangFilterTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _viewModel;

        public AturUlangFilterTarifAirTangkiCommand(TarifAirTangkiViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ResetFilters();
            _ = await Task.FromResult(true);
        }
    }
}
