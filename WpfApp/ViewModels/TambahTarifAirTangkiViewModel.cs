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
        public IRestApi RestApi { get; set; }
        public List<Kategori> Kategori { get; }
        public TatViewModel SelectedTat { get; }

        private long _biayaAir;
        public long BiayaAir
        {
            get => _biayaAir;
            set
            {
                _biayaAir = value;

                _errorViewModel.ClearErrors(nameof(BiayaAir));
                if (_biayaAir < 0)
                {
                    _errorViewModel.AddError(nameof(BiayaAir), "Tidak boleh minus");
                }

                OnPropertyChanged(nameof(BiayaAir));
            }
        }
        private Kategori _selected;
        public Kategori Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
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

        public bool IsValid => !HasErrors;

        public ICommand SubmitCommand { get; }

        public TambahTarifAirTangkiViewModel(IRestApi restApi, List<Kategori> kategori, TatViewModel selectedTat = null, string title = "Tambah Tarif Air Tangki", bool isEdit = false)
        {
            RestApi = restApi;
            Kategori = kategori;
            SelectedTat = selectedTat;
            Title = title;
            IsEdit = isEdit;
            _errorViewModel = new ErrorsViewModel();
            _errorViewModel.ErrorsChanged += ErrorViewModel_ErrorsChanged;

            PrepareEditForm();

            SubmitCommand = new SubmitTarifAirTangkiCommand(this);
        }

        private void ErrorViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(IsValid));
        }

        private void PrepareEditForm()
        {
            if (SelectedTat != null)
            {
                BiayaAir = SelectedTat.BiayaAir;
                Selected = Kategori.FirstOrDefault(_ => SelectedTat.KategoriTarif.Contains(_.KategoriTarif));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }
    }
}
