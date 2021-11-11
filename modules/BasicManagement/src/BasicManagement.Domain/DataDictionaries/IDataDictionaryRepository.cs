using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BasicManagement.DataDictionaries
{
    public interface IDataDictionaryRepository : IRepository<DataDictionary, Guid>
    {
    }
  
}