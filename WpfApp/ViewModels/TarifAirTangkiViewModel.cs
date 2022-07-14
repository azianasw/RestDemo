using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public class TarifAirTangkiViewModel : ViewModelBase
    {
        private List<EmployeeViewModel> _employees;
        public List<EmployeeViewModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private EmployeeViewModel _selected;
        public EmployeeViewModel Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
        private List<TATViewmModel> _tats;
        public List<TATViewmModel> Tats
        {
            get => _tats;
            set
            {
                _tats = value;
                OnPropertyChanged(nameof(Tats));
            }
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
        private bool _noRecord = true;
        public bool NoRecord
        {
            get => _noRecord;
            set
            {
                _noRecord = value;
                OnPropertyChanged(nameof(NoRecord));
            }
        }
        private long _totalRecord = 0;
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
