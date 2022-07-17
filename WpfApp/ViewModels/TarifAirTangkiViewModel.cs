using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class TarifAirTangkiViewModel : ViewModelBase
    {
        private List<TATViewmModel> _tarifAirTangki;
        public List<TATViewmModel> TarifAirTangki
        {
            get => _tarifAirTangki;
            set
            {
                _tarifAirTangki = value;
                OnPropertyChanged(nameof(TarifAirTangki));
                UpdateTotalRecord();
            }
        }

        private void UpdateTotalRecord()
        {
            TotalRecord = TarifAirTangki.Count;
        }

        public void ResetFilters()
        {
            KodeTarifChecked = false;
            NamaTarifChecked = false;
            KodeTarif = string.Empty;
            NamaTarif = string.Empty;
        }

        public string GetFilters()
        {
            string filters = string.Empty;

            filters += !string.IsNullOrEmpty(KodeTarif) && KodeTarifChecked ? $"kodeTarif={KodeTarif}" : "kodeTarif";
            filters += !string.IsNullOrEmpty(NamaTarif) && NamaTarifChecked ? $"&namaTarif={NamaTarif}" : "&namaTarif";

            return filters;
        }

        private TATViewmModel _selectedTat;
        public TATViewmModel SelectedTat
        {
            get => _selectedTat;
            set
            {
                _selectedTat = value;
                OnPropertyChanged(nameof(SelectedTat));
            }
        }
        private long _totalRecord;
        public long TotalRecord
        {
            get => _totalRecord;
            set
            {
                _totalRecord = value;
                OnPropertyChanged(nameof(TotalRecord));
            }
        }
        private bool _kodeTarifChecked;
        public bool KodeTarifChecked
        {
            get => _kodeTarifChecked;
            set
            {
                _kodeTarifChecked = value;
                OnPropertyChanged(nameof(KodeTarifChecked));
            }
        }
        private string _kodeTarif;
        public string KodeTarif
        {
            get => _kodeTarif;
            set
            {
                _kodeTarif = value;
                OnPropertyChanged(nameof(KodeTarif));
            }
        }
        private bool _namaTarifChecked;
        public bool NamaTarifChecked
        {
            get => _namaTarifChecked;
            set
            {
                _namaTarifChecked = value;
                OnPropertyChanged(nameof(NamaTarifChecked));
            }
        }
        private string _namaTarif;
        public string NamaTarif
        {
            get => _namaTarif;
            set
            {
                _namaTarif = value;
                OnPropertyChanged(nameof(NamaTarif));
            }
        }

        public ICommand RefreshCommand { get; }
        public ICommand TambahCommand { get; }
        public ICommand HapusCommand { get; }
        public ICommand KoreksiCommand { get; }
        public ICommand AturUlangFilterCommand { get; }

        public TarifAirTangkiViewModel()
        {
            RefreshCommand = new RefreshTarifAirTangkiCommand(this);
            TambahCommand = new TambahTarifAirTangkiCommand();
            HapusCommand = new HapusTarifAirTangkiCommand(this);
            KoreksiCommand = new TambahTarifAirTangkiCommand(this);
            AturUlangFilterCommand = new AturUlangFilterTarifAirTangkiCommand(this);
        }
    }
}
