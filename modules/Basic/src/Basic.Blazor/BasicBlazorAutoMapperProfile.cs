using AutoMapper;
using Basic.DataDictionaries.Dtos;

namespace Basic.Blazor
{
    public class BasicBlazorAutoMapperProfile : Profile
    {
        public BasicBlazorAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<DataDictionaryDto, CreateDataDictionaryDto>();
        }
    }
}