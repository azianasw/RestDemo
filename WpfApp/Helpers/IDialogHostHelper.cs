using System.Threading.Tasks;

namespace WpfApp.Helpers
{
    public interface IDialogHostHelper
    {
        public Task<object> Show(object content, object dialogIdentifier);
    }
}