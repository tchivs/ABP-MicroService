using Basic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Basic
{
    public abstract class BasicController : AbpController
    {
        protected BasicController()
        {
            LocalizationResource = typeof(BasicResource);
        }
    }
}
