using AutoMapper;
using Basic.DataDictionaries.Dtos;

namespace Basic
{
    public class BasicApplicationAutoMapperProfile : Profile
    {
        public BasicApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<DataDictionaryDto, CreateDataDictionaryDto>();
            CreateMap<DataDictionaryDto, UpdateDataDictionaryDto>();
        }
    }
}