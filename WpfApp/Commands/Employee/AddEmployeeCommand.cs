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
    public class AddEmployeeCommand : CommandBase
    {
        private readonly AddEmployeeViewModel _addEmployeeViewModel;

        public AddEmployeeCommand(AddEmployeeViewModel addEmployeeViewModel)
        {
            _addEmployeeViewModel = addEmployeeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _ = await Task.FromResult(false);
        }
    }
}
