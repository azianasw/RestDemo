using WpfApp.Converter;
using Xunit;

namespace WpfApp.Test
{
    public class TidakAdaDataConverterUnitTest
    {
        [Fact]
        public void TidakAdaDataConverter_ReturnTrue_IfTotalDataIs0()
        {
            TidakAdaDataConverter sut = new TidakAdaDataConverter();
            int totalData = 0;

            bool result = (bool)sut.Convert(totalData, null, null, null);

            Assert.True(result);
        }

        [Fact]
        public void TidakAdaDataConverter_ReturnFalse_IfTotalDataIsGt0()
        {
            TidakAdaDataConverter sut = new TidakAdaDataConverter();
            int totalData = 1;

            bool result = (bool)sut.Convert(totalData, null, null, null);

            Assert.False(result);
        }

    }
}
