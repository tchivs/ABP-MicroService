using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using BasicManagement.DataDictionaries;
using BasicManagement.EntityFrameworkCore;

namespace  BasicManagement.Repository.DataDictionaries
{
    public static class DataDictionaryExtensions
    {
        public static IQueryable<DataDictionary> IncludeDetails(
            this IQueryable<DataDictionary> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable.Include(x => x.Details);
        }
    }

    public class DataDictionaryRepository : EfCoreRepository<IBasicManagementDbContext, DataDictionary, Guid>, IDataDictionaryRepository
    {
        public DataDictionaryRepository(IDbContextProvider<IBasicManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }



        public override async Task<IQueryable<DataDictionary>> WithDetailsAsync()
        {
            //GET的时候获取明细数据
            var queryable = await GetQueryableAsync();
            return queryable.IncludeDetails();
        }
    }
    public class DataDictionaryDetailRepository : EfCoreRepository<IBasicManagementDbContext, DataDictionaryDetail, Guid>, IDataDictionaryDetailRepository
    {
        public DataDictionaryDetailRepository(IDbContextProvider<IBasicManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
