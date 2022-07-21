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

namespace WpfApp.Commands
{
    public class RefreshTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _viewModel;
        private readonly IRestApi _restApi;

        public RefreshTarifAirTangkiCommand(TarifAirTangkiViewModel viewModel, IRestApi restApi)
        {
            _viewModel = viewModel;
            _restApi = restApi;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            string uri = $"tarifAirTangki?{_viewModel.GetFilters()}";

            _viewModel.TarifAirTangki = await _restApi.GetAsync(uri);
        }
    }
}