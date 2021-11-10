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
}