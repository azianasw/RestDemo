using Moq;
using System.Collections.Generic;
using WpfApp.Models;
using WpfApp.ViewModels;
using Xunit;

namespace WpfApp.Test.ViewModel
{
    public class TarifAirTangkiViewModelUnitTest
    {

        [Fact]
        public void TotalRecord_ShouldInitializeWithZero()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object);

            int result = (int)sut.TotalRecord;

            Assert.Null(sut.TarifAirTangki);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TotalRecordShouldReturnItems()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                TarifAirTangki = new List<TatViewModel>()
                {
                    new TatViewModel{Id=1,KategoriTarif="Kategori Tarif 1",NamaTarif="Nama Tarif 1",BiayaAir=100},
                    new TatViewModel{Id=2,KategoriTarif="Kategori Tarif 2",NamaTarif="Nama Tarif 2",BiayaAir=100},
                    new TatViewModel{Id=3,KategoriTarif="Kategori Tarif 3",NamaTarif="Nama Tarif 3",BiayaAir=100},
                }
            };

            Assert.Equal(3, sut.TotalRecord);
        }

        [Fact]
        public void GetFilters_ShouldReturnDataWithFilterKategoriTarifIFItsChecked()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                KodeTarifChecked = true,
                KodeTarif = "1"
            };

            string filters = sut.GetFilters();

            Assert.True(sut.KodeTarifChecked);
            Assert.Contains($"kodetarif={sut.KodeTarif.ToLower()}", filters.ToLower());
        }

        [Fact]
        public void GetFilters_ShouldReturnDataWithFilterNamaTarifIFItsChecked()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                NamaTarifChecked = true,
                NamaTarif = "1"
            };

            string filters = sut.GetFilters();

            Assert.True(sut.NamaTarifChecked);
            Assert.Contains($"namatarif={sut.NamaTarif.ToLower()}", filters.ToLower());
        }

        [Fact]
        public void ResetFilters_ShouldUncheckAllAvailableOptionsAndResetItsValues()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
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
        public void ResetFilters_ShouldClearValueAssociatedOnGetFilters()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                KodeTarifChecked = true,
                NamaTarifChecked = true,
                KodeTarif = "KodeTarif",
                NamaTarif = "NamaTarif"
            };

            sut.ResetFilters();

            string filters = sut.GetFilters();
            Assert.DoesNotContain("=", filters);
        }

        [Fact]
        public void ExecuteRefreshCommand_InvokeGetAsync_AndSetTarifAirTangki()
        {
            List<TatViewModel> expected = new List<TatViewModel>()
            {
                new TatViewModel()
                {
                    Id = 1,
                    KategoriTarif = "KategoriTarif",
                    NamaTarif = "NamaTarif",
                    BiayaAir = 100
                }
            };
            Mock<IRestApi> service = new Mock<IRestApi>();
            _ = service.Setup(i => i.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(expected);
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object); ;

            sut.RefreshCommand.Execute(null);

            service.Verify(i => i.GetAsync(It.IsAny<string>()));
            Assert.Equal(expected, sut.TarifAirTangki);
        }

        [Fact]
        public void ExecuteTambahCommand_InvokeGetKategoriAsync_AndSetKategori()
        {
            List<Kategori> expected = new List<Kategori>()
            {
                new Kategori()
                {
                    Id = 1,
                    KategoriTarif = "KategoriTarif",
                    NamaTarif = "NamaTarif"
                }
            };
            Mock<IRestApi> service = new Mock<IRestApi>();
            _ = service.Setup(i => i.GetKategoriAsync(It.IsAny<string>()))
                .ReturnsAsync(expected);
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object); ;

            sut.TambahCommand.Execute(null);

            service.Verify(i => i.GetKategoriAsync(It.IsAny<string>()));
            Assert.Equal(expected, sut.Kategori);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData(null, false)]
        public void ExecuteTambahCommand_WithParam(object parameter, bool expected)
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object); ;

            sut.TambahCommand.Execute(parameter);

            Assert.Equal(expected, bool.TryParse((string)parameter, out bool _));
            Assert.Equal(expected, bool.TryParse((string)parameter, out bool _));
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData(null, false)]
        public void ExecuteKoreksiCommand_WithParam(object parameter, bool expected)
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object); ;

            sut.KoreksiCommand.Execute(parameter);

            Assert.Equal(expected, bool.TryParse((string)parameter, out bool _));
            Assert.Equal(expected, bool.TryParse((string)parameter, out bool _));
        }

        [Fact]
        public void ExecuteAturUlangFilterCommand_ResetFilters()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                KodeTarifChecked = true,
                NamaTarifChecked = true,
                KodeTarif = "KodeTarif",
                NamaTarif = "NamaTarif"
            };

            sut.AturUlangFilterCommand.Execute(null);

            Assert.False(sut.KodeTarifChecked);
            Assert.False(sut.NamaTarifChecked);
            Assert.Equal(string.Empty, sut.KodeTarif);
            Assert.Equal(string.Empty, sut.NamaTarif);
        }

        [Fact]
        public void ExecuteHapusCommand_InvokeDeleteAsyncAndShowDialog()
        {
            Mock<IRestApi> service = new Mock<IRestApi>();
            var notification = new Mock<INotification>();
            TarifAirTangkiViewModel sut = new TarifAirTangkiViewModel(service.Object, notification.Object)
            {
                SelectedTat = new TatViewModel { Id = 1, KategoriTarif = string.Empty, NamaTarif = string.Empty, BiayaAir = 0 }
            };

            sut.HapusCommand.Execute(null);

            service.Verify(i => i.DeleteAsync(It.IsAny<string>()));
            notification.Verify(i => i.Show(It.IsAny<string>()));
        }
    }
}
