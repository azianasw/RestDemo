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
    class SaveUpdateEmployeeCommand : CommandBase
    {
        private UpdateEmployeeViewModel _updateEmployeeViewModel;

        public SaveUpdateEmployeeCommand(UpdateEmployeeViewModel updateEmployeeViewModel)
        {
            _updateEmployeeViewModel = updateEmployeeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _ = await Task.FromResult(false);
        }
    }
}
