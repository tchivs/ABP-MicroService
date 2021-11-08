using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Basic.DataDictionaries;
using Basic.EntityFrameworkCore;

namespace  Basic.Repository.DataDictionaries
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

    public class DataDictionaryRepository : EfCoreRepository<IBasicDbContext, DataDictionary, Guid>, IDataDictionaryRepository
    {
        public DataDictionaryRepository(IDbContextProvider<IBasicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }



        public override async Task<IQueryable<DataDictionary>> WithDetailsAsync()
        {
            //GET的时候获取明细数据
            var queryable = await GetQueryableAsync();
            return queryable.IncludeDetails();
        }
    }
    public class DataDictionaryDetailRepository : EfCoreRepository<IBasicDbContext, DataDictionaryDetail, Guid>, IDataDictionaryDetailRepository
    {
        public DataDictionaryDetailRepository(IDbContextProvider<IBasicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
