using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace Basic.DataDictionaries
{
    public class DataDictionaryDetail : FullAuditedEntity<Guid>
    {
        [DisplayName("名称")] public string Name { get; set; }
        [DisplayName("值")] public string Value { get; set; }
        [DisplayName("组名")] public string Group { get; set; }
        [DisplayName("备注")] public string Remark { get; set; }
        [DisplayName("排序")] public int Sort { get; set; }
        public Guid  BasicId { get; set; }
        public Guid? ParentId { get; set; }
     
        public virtual DataDictionary Basic { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public virtual DataDictionaryDetail Parent { get; set; }
        /// <summary>
        /// 子级
        /// </summary>
        public virtual ICollection<DataDictionaryDetail> Children { get; set; }
    }
}