using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace WpfApp.Helpers
{
    public class DialogHostHelper : IDialogHostHelper
    {
        public async Task<object> Show(object content, object dialogIdentifier)
        {
            return await DialogHost.Show(content, dialogIdentifier);
        }
    }
}
