﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class UpdateEmployeeListingCommand : CommandBase
    {
        private EmployeeListingViewModel _employeeListingViewModel;

        public UpdateEmployeeListingCommand(EmployeeListingViewModel employeeListingViewModel)
        {
            _employeeListingViewModel = employeeListingViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var employeeToUpdate = _employeeListingViewModel.Selected;
            var resp = WebApi.PutAsync($"employees/{employeeToUpdate.Id}", employeeToUpdate);
            if (resp.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                _employeeListingViewModel.MessageQueue.Enqueue($"{employeeToUpdate.Fullname}'s details has successfully been updated!");
            }
            await Task.FromResult(true);
        }
    }
}
