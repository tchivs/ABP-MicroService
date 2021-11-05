using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Basic.MongoDB
{
    public static class BasicMongoDbContextExtensions
    {
        public static void ConfigureBasic(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BasicMongoModelBuilderConfigurationOptions(
                BasicDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}