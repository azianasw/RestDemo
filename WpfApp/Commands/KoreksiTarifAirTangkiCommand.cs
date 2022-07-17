using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp.Commands
{
    public class KoreksiTarifAirTangkiCommand : CommandBase
    {
        private TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public KoreksiTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //Employee employeeToUpdate = new Employee
            //{
            //    Id = _tarifAirTangkiViewModel.Selected.Id,
            //    Fullname = _tarifAirTangkiViewModel.Selected.Fullname,
            //    Address = _tarifAirTangkiViewModel.Selected.Address,
            //    Position = _tarifAirTangkiViewModel.Selected.Position
            //};

            //_ = await DialogHost.Show(new UpdateEmployeeView(new UpdateEmployeeViewModel(employeeToUpdate)), "DialogHost");
        }
    }
}
