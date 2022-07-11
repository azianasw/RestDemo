using System;
using System.Collections.Generic;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class DeleteEmployeeListingCommand : CommandBase
    {
        private EmployeeListingViewModel _employeeListingViewModel;

        public DeleteEmployeeListingCommand(EmployeeListingViewModel employeeListingViewModel)
        {
            _employeeListingViewModel = employeeListingViewModel;
        }

        public override void Execute(object parameter)
        {
            var resp = WebApi.Delete($"employees/{_employeeListingViewModel.Selected.Id}");
            if (resp.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _employeeListingViewModel.MessageQueue.Enqueue($"{_employeeListingViewModel.Selected.Fullname}'s details has successfully been deleted!");
            }
        }
    }
}
