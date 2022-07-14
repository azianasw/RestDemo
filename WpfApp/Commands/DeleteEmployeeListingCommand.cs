using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public override async Task ExecuteAsync(object parameter)
        {
            await WebApi.DeleteAsync($"employees/{_employeeListingViewModel.Selected.Id}");
            //if (resp.Result.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    _employeeListingViewModel.MessageQueue.Enqueue($"{_employeeListingViewModel.Selected.Fullname}'s details has successfully been deleted!");
            //}
        }
    }
}
