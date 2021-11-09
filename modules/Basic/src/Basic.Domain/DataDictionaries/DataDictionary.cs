using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Basic.DataDictionaries
{
    public class DataDictionary : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        [DisplayName("名称")]
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(BasicConstant.BasicDictionaryConstant.MaxAppNameLength)]
        [Required]
        [DisplayName("应用名称")]
        public string AppName { get; set; }
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
            this.Details=new List<DataDictionaryDetail>();
        }

        public DataDictionary([NotNull] string name, [NotNull] string key, string remark = null, int sort = 0)
        {
            this.Key = key;
            this.Sort = sort;
            Name = name;
            Remark = remark;
        }
        public void AddDetail(string name, string value, string group, string remark, int sort = 0)
        {
            if (this.Details.Any(x=>x.Name==name))
            {
                throw new BusinessException(BasicErrorCodes.DetailIsExists).WithData("Footer", $",{name}已存在");
            }

            var detail = new DataDictionaryDetail(this.Id, name, value, group, remark, sort);
            Details.Add(detail);
        }
    }
}
