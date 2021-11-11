using AutoMapper;
using BasicManagement.DataDictionaries;
using BasicManagement.DataDictionaries.Dtos;

namespace BasicManagement
{
    public class BasicManagementApplicationAutoMapperProfile : Profile
    {
        public BasicManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<DataDictionary, DataDictionaryDto>() ;
            CreateMap<DataDictionaryDetail, DataDictionaryDetailDto>() ;
            // CreateMap<CreateDataDictionaryDto, DataDictionaryDto>();
            // CreateMap<UpdateDataDictionaryDto, DataDictionaryDto>();
            //
            CreateMap<DataDictionaryDetailDto, CreateDataDictionaryDetailDto>();
            CreateMap<DataDictionaryDetailDto, UpdateDataDictionaryDetailDto>();
        }
    }
}