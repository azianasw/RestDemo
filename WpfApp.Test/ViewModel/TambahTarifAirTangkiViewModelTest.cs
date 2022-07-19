using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp.Models;
using WpfApp.ViewModels;
using Xunit;

namespace WpfApp.Test.ViewModel
{
    public class TambahTarifAirTangkiViewModelTest
    {
        [Fact]
        public void Execute_SubmitCommand_InvokePutAsync()
        {
            var service = new Mock<IRestApi>();
            var kategori = new List<Kategori> { new Kategori { Id = 1, KategoriTarif = string.Empty, NamaTarif = string.Empty } };
            var selected = new TatViewModel { Id = 1, KategoriTarif = string.Empty, NamaTarif = string.Empty, BiayaAir = 0 };
            var isEdit = true;
            var sut = new TambahTarifAirTangkiViewModel(service.Object, kategori, selected, null, isEdit);

            sut.SubmitCommand.Execute(null);

            service.Verify(i => i.PutAsync(It.IsAny<string>(), It.IsAny<TarifAirTangki>()));
        }

        [Fact]
        public void Execute_SubmitCommand_InvokePostAsync()
        {
            var service = new Mock<IRestApi>();
            var kategori = new List<Kategori> { new Kategori { Id = 1, KategoriTarif = string.Empty, NamaTarif = string.Empty } };
            var selected = new TatViewModel { Id = 1, KategoriTarif = string.Empty, NamaTarif = string.Empty, BiayaAir = 0 };
            var isEdit = false;
            var sut = new TambahTarifAirTangkiViewModel(service.Object, kategori, selected, null, isEdit);

            sut.SubmitCommand.Execute(null);

            service.Verify(i => i.PostAsync(It.IsAny<string>(), It.IsAny<TarifAirTangki>()));
        }

    }
}
