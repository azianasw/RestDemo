using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class TambahTarifAirTangkiViewModel : ViewModelBase
    {
        public List<Kategori> Kategori { get; }
        public TATViewmModel SelectedTat { get; }

        private long _biayaAir;
        public long BiayaAir
        {
            get => _biayaAir;
            set
            {
                _biayaAir = value;
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

        public ICommand SubmitCommand { get; }

        public TambahTarifAirTangkiViewModel(List<Kategori> kategori, TATViewmModel selectedTat = null, string title = "Tambah Tarif Air Tangki", bool isEdit = false)
        {
            Kategori = kategori;
            SelectedTat = selectedTat;
            Title = title;
            IsEdit = isEdit;

            PrepareEditForm();

            SubmitCommand = new SubmitTarifAirTangkiCommand(this);
        }

        private void PrepareEditForm()
        {
            if (SelectedTat != null)
            {
                BiayaAir = SelectedTat.BiayaAir;
                Selected = Kategori.FirstOrDefault(_ => SelectedTat.KategoriTarif.Contains(_.KategoriTarif));
            }
        }
    }
}
