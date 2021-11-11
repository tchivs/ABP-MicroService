using System;
using BasicManagement.DataDictionaries;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BasicManagement.EntityFrameworkCore
{
    public static class BasicManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureBasicManagement(
            this ModelBuilder builder,
            Action<BasicManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BasicManagementModelBuilderConfigurationOptions(
                BasicManagementDbProperties.DbTablePrefix,
                BasicManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            builder.Entity<DataDictionary>(b =>
            {
                b.ToTable(options.TablePrefix + "DataDictionaries", options.Schema);
                b.ConfigureByConvention();
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(BasicConstant.BasicDictionaryConstant.MaxNameLength);
                b.Property(x => x.AppName).IsRequired().HasMaxLength(BasicConstant.BasicDictionaryConstant.MaxAppNameLength);
                b.Property(x => x.Key).IsRequired().HasMaxLength(BasicConstant.BasicDictionaryConstant.MaxKeyLength);
                b.Property(x => x.Remark).HasMaxLength(BasicConstant.MaxRemarkLength);
                b.HasIndex(x => x.Key);
                b.HasMany(x => x.Details)
                    .WithOne().HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Cascade);
                /* Configure more properties here */
            });
            builder.Entity<DataDictionaryDetail>(b =>
            {
                b.ToTable(options.TablePrefix + "DataDictionaryDetails", options.Schema);
                b.ConfigureByConvention();
                b.ConfigureFullAudited();
                b.Property(x => x.Name).IsRequired().HasMaxLength(BasicConstant.BasicDictionaryConstant.MaxNameLength);
                b.Property(x => x.Value).IsRequired().HasMaxLength(BasicConstant.BasicDictionaryConstant.MaxValueLength);
                b.Property(x => x.Remark).HasMaxLength(BasicConstant.MaxRemarkLength);
                b.Property(x => x.Group).HasMaxLength(32);
            });
        }
    }
}