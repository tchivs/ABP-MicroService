namespace Basic
{
    public static class BasicErrorCodes
    {
        //Add your business exception error codes here...
        public static string Prefix = "App";
        //Add your business exception error codes here...
        /// <summary>
        /// 明细项不存在
        /// </summary>
        public static string NotExists = $"{Prefix}:{nameof(NotExists)}";
        /// <summary>
        /// 明细项已存在
        /// </summary>
        public static string DetailIsExists = $"{Prefix}:{nameof(DetailIsExists)}";
        public static string IsExists = $"{Prefix}:{nameof(IsExists)}";
        /// <summary>
        /// 父级元素未找到
        /// </summary>
        public static string ParentNotFound = $"{Prefix}:{nameof(ParentNotFound)}";
    }
}
