using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override async Task ExecuteAsync(object parameter)
        {
            var employees = WebApi.GetAsync("employees");
            if (employees.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _employeeListingViewModel.Employees = JsonConvert.DeserializeObject<List<Employee>>(
                    employees.Result.Content.ReadAsStringAsync().Result)
                    .Select(e => new EmployeeViewModel(e)).ToList();
            }
            await Task.FromResult(true);
        }
    }
}
