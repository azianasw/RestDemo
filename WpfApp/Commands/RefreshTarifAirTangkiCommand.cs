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
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public RefreshTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            string uri = $"tarifAirTangki?{_tarifAirTangkiViewModel.GetFilters()}";

            _tarifAirTangkiViewModel.TarifAirTangki = await _tarifAirTangkiViewModel.RestApi.GetAsync(uri);
        }
    }
}