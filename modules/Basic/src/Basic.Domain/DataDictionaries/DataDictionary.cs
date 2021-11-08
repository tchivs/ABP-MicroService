using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Basic.DataDictionaries
{
    public class DataDictionary : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        [DisplayName("名称")]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxKeyLength)]
        [DisplayName("键")]
        [Required] public string Key { get; set; }
        [DisplayName("备注")]
        [StringLength(BasicConstant.MaxRemarkLength)] 
        public string Remark { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("顺序")] public int Sort { get; set; }
        /// <summary>
        /// 明细
        /// </summary>
        public virtual ICollection<DataDictionaryDetail> Details { get; set; }
        private DataDictionary()
        {
        }

        public DataDictionary([NotNull] string name, [NotNull] string key, string remark = null,  int sort = 0)
        {
            this.Key = key;
            this.Sort = sort;
            Name = name;
            Remark = remark;
        }
    }
}
