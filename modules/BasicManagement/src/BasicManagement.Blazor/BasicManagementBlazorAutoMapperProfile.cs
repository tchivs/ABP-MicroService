using AutoMapper;
using BasicManagement.DataDictionaries.Dtos;

namespace BasicManagement.Blazor
{
    public class BasicManagementBlazorAutoMapperProfile : Profile
    {
        public BasicManagementBlazorAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<DataDictionaryDto, CreateDataDictionaryDto>();
            CreateMap<DataDictionaryDto, UpdateDataDictionaryDto>();
        }
    }
}