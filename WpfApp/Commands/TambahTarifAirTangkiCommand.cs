using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp.Commands
{
    public class TambahTarifAirTangkiCommand : CommandBase
    {
        private readonly TarifAirTangkiViewModel _tarifAirTangkiViewModel;

        public TambahTarifAirTangkiCommand(TarifAirTangkiViewModel tarifAirTangkiViewModel)
        {
            _tarifAirTangkiViewModel = tarifAirTangkiViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _tarifAirTangkiViewModel.Kategori = await _tarifAirTangkiViewModel.RestApi.GetKategoriAsync("kategori");

            _ = bool.TryParse((string)parameter, out bool isEdit)
                ? await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(_tarifAirTangkiViewModel.Kategori, _tarifAirTangkiViewModel.SelectedTat, "Koreksi Tarif Air Tangki", isEdit)), "DialogHost")
                : await DialogHost.Show(new TambahTarifAirTangkiView(new TambahTarifAirTangkiViewModel(_tarifAirTangkiViewModel.Kategori)), "DialogHost");
        }
    }
}
