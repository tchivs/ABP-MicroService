using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SystemManagement.EntityFrameworkCore
{
    public class SystemManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SystemManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}