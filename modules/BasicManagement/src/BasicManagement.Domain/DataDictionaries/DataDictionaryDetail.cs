using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace BasicManagement.DataDictionaries
{
    public class DataDictionaryDetail : FullAuditedEntity<Guid>
    {
        [DisplayName("名称")] public string Name { get; set; }
        [DisplayName("值")] public string Value { get; set; }
        [DisplayName("组名")] public string Group { get; set; }
        [DisplayName("备注")] public string Remark { get; set; }
        [DisplayName("排序")] public int Sort { get; set; }

        public Guid ParentId { get; set; }

        //public virtual DataDictionary Parent { get; set; }
        private DataDictionaryDetail()
        {
        }
        public DataDictionaryDetail(Guid parentId, string name, string value, string group, string remark, int sort)
        {
            this.ParentId = parentId;
            this.Name = name;
            this.Value = value;
            this.Group = group;
            this.Remark = remark;
            this.Sort = sort;
        }
    }
}