using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp
{
    public interface IRestApi
    {
        Task<List<TatViewModel>> GetAsync(string uri);
        Task<List<Kategori>> GetKategoriAsync(string uri);
    }
}
