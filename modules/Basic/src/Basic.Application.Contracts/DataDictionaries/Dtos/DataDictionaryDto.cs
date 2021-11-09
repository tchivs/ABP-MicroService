using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using JetBrains.Annotations;
using Micro.Application.Shared;
using Volo.Abp.Application.Dtos;

namespace Basic.DataDictionaries.Dtos
{
    [Serializable]
    public class DataDictionaryDto : FullAuditedEntityDto<Guid>
    {
        [DisplayName("名称")]
        [Required]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxNameLength)]
        public string Name { get; set; }

        [DisplayName("名称")]
        [Required]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxAppNameLength)]
        public string AppName { get; set; }

        [StringLength(BasicConstant.BasicDictionaryConstant.MaxKeyLength)]
        [DisplayName("键")]
        public string Key { get; set; }

        [DisplayName("备注")]
        [StringLength(BasicConstant.MaxRemarkLength)]
        public string Remark { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("顺序")]
        public int Sort { get; set; }

        public ICollection<DataDictionaryDetailDto> Details { get; set; }
    }

    public class GetDataDictionaryInput : PageAndKeyAndIncludeResultRequestDto
    {
        [DisplayName("应用名称")] [CanBeNull] public string AppName { get; set; }
    }

    [Serializable]
    public class CreateDataDictionaryDto
    {
        [DisplayName("名称")]
        [Required]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(BasicConstant.BasicDictionaryConstant.MaxKeyLength)]
        [Required]
        [DisplayName("键")]
        public string Key { get; set; }

        [DisplayName("备注")]
        [StringLength(BasicConstant.MaxRemarkLength)]
        public string Remark { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("顺序")]
        public int Sort { get; set; }
    }

    [Serializable]
    public class UpdateDataDictionaryDto
    {
        [DisplayName("名称")]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(BasicConstant.BasicDictionaryConstant.MaxKeyLength)]
        [DisplayName("键")]
        public string Key { get; set; }

        [DisplayName("备注")]
        [StringLength(BasicConstant.MaxRemarkLength)]
        public string Remark { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("顺序")]
        public int Sort { get; set; }
    }
}