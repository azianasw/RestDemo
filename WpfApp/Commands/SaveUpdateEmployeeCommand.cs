using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                Employee employeeToUpdate = new Employee
                {
                    Id = _updateEmployeeViewModel.Id,
                    Fullname = _updateEmployeeViewModel.Fullname,
                    Address = _updateEmployeeViewModel.Address,
                    Position = _updateEmployeeViewModel.Position
                };

                HttpResponseMessage resp = await WebApi.PutAsync($"employees/{employeeToUpdate.Id}", employeeToUpdate);

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    _ = MessageBox.Show("Data berhasil diupdate!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
