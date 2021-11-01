using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace SystemService
{
    public class SystemServiceDataSeeder : IDataSeedContributor, ITransientDependency
    {
        public Task SeedAsync(DataSeedContext context)
        {
            return Task.CompletedTask;
        }
    }
}
