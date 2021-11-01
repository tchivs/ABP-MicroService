namespace SystemManagement
{
    public static class SystemManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "SystemManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "SystemManagement";
    }
}
