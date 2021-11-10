using System;

namespace Micro.Application.Shared
{
    [Serializable]
    public class PageAndKeyAndIncludeResultRequestDto : PageAndKeyResultRequestDto
    {
        /// <summary>
        /// 是否加载明细数据
        /// </summary>
        public bool Include { get; set; }
    }
}