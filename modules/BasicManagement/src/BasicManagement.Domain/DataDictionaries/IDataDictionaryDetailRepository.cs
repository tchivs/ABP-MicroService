using System;
using Volo.Abp.Domain.Repositories;

namespace BasicManagement.DataDictionaries {     public interface IDataDictionaryDetailRepository : IRepository<DataDictionaryDetail, Guid>
    {
    }
}