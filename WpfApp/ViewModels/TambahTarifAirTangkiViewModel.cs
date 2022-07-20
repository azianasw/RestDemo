using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class TambahTarifAirTangkiViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public List<Kategori> Kategori { get; }

        public long Id { get; set; }

        private long _biayaAir;
        public long BiayaAir
        {
            get => _biayaAir;
            set
            {
                _biayaAir = value;
                OnPropertyChanged(nameof(BiayaAir));
                OnPropertyChanged(nameof(IsValid));

                _errorViewModel.ClearErrors(nameof(BiayaAir));
                if (_biayaAir < 0)
                {
                    _errorViewModel.AddError(nameof(BiayaAir), "Biaya air must gt 0.");
                }
            }
        }

        private Kategori _selectedKategori;
        public Kategori SelectedKategori
        {
            get => _selectedKategori;
            set
            {
                _selectedKategori = value;
                OnPropertyChanged(nameof(SelectedKategori));
                OnPropertyChanged(nameof(IsValid));

                _errorViewModel.ClearErrors(nameof(SelectedKategori));
                if (_selectedKategori == null)
                {
                    _errorViewModel.AddError(nameof(SelectedKategori), "Kategori is required.");
                }
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public bool IsEdit { get; }

        private readonly ErrorsViewModel _errorViewModel;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => _errorViewModel.HasErrors;
        public bool IsValid => !HasErrors && BiayaAir > 0 && SelectedKategori != null;

        public ICommand SubmitCommand { get; }

        public TambahTarifAirTangkiViewModel(IRestApi restApi, List<Kategori> kategori, INotification notification, TatViewModel selectedTat = null, string title = "Tambah Tarif Air Tangki", bool isEdit = false)
        {
            Kategori = kategori;
            Title = title;
            IsEdit = isEdit;

            _errorViewModel = new ErrorsViewModel();
            _errorViewModel.ErrorsChanged += ErrorViewModel_ErrorsChanged;

            PrepareEditForm(selectedTat);

            SubmitCommand = new SubmitTarifAirTangkiCommand(this, restApi, notification);
        }

        private void PrepareEditForm(TatViewModel selectedTat)
        {
            if (selectedTat != null)
            {
                Id = selectedTat.Id;
                BiayaAir = selectedTat.BiayaAir;
                SelectedKategori = Kategori.FirstOrDefault(_ => selectedTat.KategoriTarif.Contains(_.KategoriTarif));
            }
        }

        private void ErrorViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(IsValid));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }
    }
}
