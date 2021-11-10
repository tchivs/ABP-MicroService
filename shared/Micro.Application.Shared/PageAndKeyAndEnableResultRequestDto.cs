using System;

namespace Micro.Application.Shared
{
    [Serializable]
    public class PageAndKeyAndEnableResultRequestDto : PageAndKeyResultRequestDto
    {
        public bool Enable { get; set; } = true;
    }
}