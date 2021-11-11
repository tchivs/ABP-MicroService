using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BasicManagement.EntityFrameworkCore
{
    public class BasicManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public BasicManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}