using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Basic.DataDictionaries.Dtos
{
    [Serializable]
    public class DataDictionaryDetailDto : FullAuditedEntityDto<Guid>
    {
        [Display(Name = "名称")]
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }

        [Display(Name = "值")]
        [Required]
        [DisplayName("值")]
        public string Value { get; set; }

        [Display(Name = "组名")]
        [DisplayName("组名")]
        public string Group { get; set; }

        [Display(Name = "备注")]
        [DisplayName("备注")]
        public string Remark { get; set; }

        [Display(Name = "排序")]
        [DisplayName("排序")]
        public int Sort { get; set; }
        // public ICollection<DataDictionaryDetailDto> Children { get; set; }
    }

    [Serializable]
    public class CreateDataDictionaryDetailDto
    {
        [Required] [DisplayName("名称")] public string Name { get; set; }
        [Required] [DisplayName("值")] public string Value { get; set; }
        [DisplayName("组名")] public string Group { get; set; }
        [DisplayName("备注")] public string Remark { get; set; }
        [DisplayName("排序")] public int Sort { get; set; }
    }

    [Serializable]
    public class UpdateDataDictionaryDetailDto
    {
        [Required] [DisplayName("名称")] public string Name { get; set; }
        [Required] [DisplayName("值")] public string Value { get; set; }
        [DisplayName("组名")] public string Group { get; set; }
        [DisplayName("备注")] public string Remark { get; set; }
        [DisplayName("排序")] public int Sort { get; set; }
    }
}