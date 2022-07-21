using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class HapusTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _viewModel;
        private readonly IRestApi _restApi;
        private readonly INotification _notification;

        public HapusTarifAirTangkiCommand(TarifAirTangkiViewModel viewModel, IRestApi restApi, INotification notification)
        {
            _viewModel = viewModel;
            _restApi = restApi;
            _notification = notification;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _restApi.DeleteAsync($"tarifAirTangki/{_viewModel.SelectedTat.Id}");

            _notification.Show("Data berhasil dihapus.");
        }
    }
}
