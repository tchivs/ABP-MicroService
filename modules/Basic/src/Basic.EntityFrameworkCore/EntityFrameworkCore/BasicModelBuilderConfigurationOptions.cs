using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Basic.EntityFrameworkCore
{
    public class BasicModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public BasicModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}