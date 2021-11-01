using System.Threading.Tasks;

namespace Tchivs.Abp.Blazor
{
    public interface IToolbarManager
    {
        Task<Toolbar> GetAsync(string name);
    }
}
