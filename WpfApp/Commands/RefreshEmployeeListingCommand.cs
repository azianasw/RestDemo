using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class RefreshEmployeeListingCommand : CommandBase
    {
        private EmployeeListingViewModel _employeeListingViewModel;

        public RefreshEmployeeListingCommand(EmployeeListingViewModel employeeListingViewModel)
        {
            _employeeListingViewModel = employeeListingViewModel;
        }

        public override void Execute(object parameter)
        {
            var employees = WebApi.Get("employees");
            if (employees.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _employeeListingViewModel.Employees = JsonConvert.DeserializeObject<List<Employee>>(
                    employees.Result.Content.ReadAsStringAsync().Result)
                    .Select(e => new EmployeeViewModel(e)).ToList();
            }
        }
    }
}
