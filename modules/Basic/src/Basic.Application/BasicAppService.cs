using Basic.Localization;
using Volo.Abp.Application.Services;

namespace Basic
{
    public abstract class BasicAppService : ApplicationService
    {
        protected BasicAppService()
        {
            LocalizationResource = typeof(BasicResource);
            ObjectMapperContext = typeof(BasicApplicationModule);
        }
    }
}
