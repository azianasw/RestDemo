using System.Collections.Generic;
using WpfApp.ViewModels;
using Xunit;

namespace WpfApp.Test.ViewModel
{
    public class TarifAirTangkiViewModelUnitTest
    {
        [Fact]
        public void TarifAirTangkiViewModel_TotalRecord_ShouldReturnZeroOnInitialize()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel();
            long result = sut.TotalRecord;
            Assert.Equal(0, result);
        }

        [Fact]
        public void TarifAirTangkiViewModel_TotalRecord_ShouldReturn_3()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel
            {
                TarifAirTangki = new List<TATViewmModel>()
                {
                    new TATViewmModel{Id=1,KategoriTarif="Kategori Tarif 1",NamaTarif="Nama Tarif 1",BiayaAir=100},
                    new TATViewmModel{Id=2,KategoriTarif="Kategori Tarif 2",NamaTarif="Nama Tarif 2",BiayaAir=100},
                    new TATViewmModel{Id=3,KategoriTarif="Kategori Tarif 3",NamaTarif="Nama Tarif 3",BiayaAir=100},
                }
            };

            Assert.Equal(3, sut.TotalRecord);
        }

        [Fact]
        public void TarifAirTangkiViewModel_GetFilters_ShouldReturnDataWithFilterKategoriTarifIFItsChecked()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel
            {
                KodeTarifChecked = true,
                KodeTarif = "1"
            };

            string filters = sut.GetFilters();

            Assert.True(sut.KodeTarifChecked);
            Assert.Contains($"kodetarif={sut.KodeTarif.ToLower()}", filters.ToLower());
        }

        [Fact]
        public void TarifAirTangkiViewModel_GetFilters_ShouldReturnDataWithFilterNamaTarifIFItsChecked()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel
            {
                NamaTarifChecked = true,
                NamaTarif = "1"
            };

            string filters = sut.GetFilters();

            Assert.True(sut.NamaTarifChecked);
            Assert.Contains($"namatarif={sut.NamaTarif.ToLower()}", filters.ToLower());
        }

        [Fact]
        public void TarifAirTangkiViewModel_ResetFilters_ShouldUncheckAllAvailableOptionsAndResetItsValues()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel
            {
                KodeTarifChecked = true,
                NamaTarifChecked = true,
                KodeTarif = "1",
                NamaTarif = "1"
            };

            sut.ResetFilters();

            Assert.False(sut.KodeTarifChecked);
            Assert.False(sut.NamaTarifChecked);

            Assert.Equal(string.Empty, sut.KodeTarif);
            Assert.Equal(string.Empty, sut.NamaTarif);
        }

        [Fact]
        public void TarifAirTangkiViewModel_ResetFilters_ShouldClearValueAssiciatedOnGetFilters()
        {
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel
            {
                KodeTarifChecked = true,
                NamaTarifChecked = true,
                KodeTarif = "1",
                NamaTarif = "1"
            };

            sut.ResetFilters();

            string filters = sut.GetFilters();
            Assert.DoesNotContain("=", filters);
        }

    }
}
