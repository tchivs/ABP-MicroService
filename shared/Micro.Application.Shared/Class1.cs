using System;
using Volo.Abp.Application.Dtos;

namespace Micro.Application.Shared
{
    [Serializable]
    public class PageAndKeyResultRequestDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
    }

    [Serializable]
    public class PageAndKeyAndEnableResultRequestDto : PageAndKeyResultRequestDto
    {
        public bool Enable { get; set; } = true;
    }

    [Serializable]
    public class PageAndKeyAndIncludeResultRequestDto : PageAndKeyResultRequestDto
    {
        /// <summary>
        /// 是否加载明细数据
        /// </summary>
        public bool Include { get; set; }
    }
}