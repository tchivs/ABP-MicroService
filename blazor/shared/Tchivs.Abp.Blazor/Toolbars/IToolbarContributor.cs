using System.Threading.Tasks;

namespace Tchivs.Abp.Blazor
{
    public interface IToolbarContributor
    {
        Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
    }
}