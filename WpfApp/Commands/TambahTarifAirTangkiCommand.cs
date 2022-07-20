using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp.Commands
{
    public class TambahTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _viewModel;
        private readonly IRestApi _restApi;

        public TambahTarifAirTangkiCommand(TarifAirTangkiViewModel viewModel, IRestApi restApi)
        {
            _viewModel = viewModel;
            _restApi = restApi;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.Kategori = await _restApi.GetKategoriAsync("kategori");

            _ = bool.TryParse((string)parameter, out bool isEdit)
                ? await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(_restApi, _viewModel.Kategori, new Notification(), _viewModel.SelectedTat, "Koreksi Tarif Air Tangki", isEdit)), "DialogHost")
                : await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(_restApi, _viewModel.Kategori, new Notification())), "DialogHost");
        }
    }
}
