using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Services;

namespace BasicManagement.DataDictionaries
{
    public class DictionaryManager: IDomainService
    {
        private readonly IDataDictionaryRepository _dataDictionaryRepository;
        private readonly IDataDictionaryDetailRepository _dataDictionaryDetailRepository;

        public DictionaryManager(IDataDictionaryRepository dataDictionaryRepository,IDataDictionaryDetailRepository dataDictionaryDetailRepository, ILogger<DictionaryManager> logger)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
            _dataDictionaryDetailRepository = dataDictionaryDetailRepository;
        }
    }
}
