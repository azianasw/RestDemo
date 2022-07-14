using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Store;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
            await Task.FromResult(true);
        }
    }
}
