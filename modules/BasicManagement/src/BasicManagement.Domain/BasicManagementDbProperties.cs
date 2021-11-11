namespace BasicManagement
{
    public static class BasicManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Basic";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "BasicManagement";
    }
}
