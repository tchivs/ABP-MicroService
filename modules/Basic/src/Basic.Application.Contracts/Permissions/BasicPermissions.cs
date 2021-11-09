using Volo.Abp.Reflection;

namespace Basic.Permissions
{
    public class BasicPermissions
    {
        public const string GroupName = "Basic";
        public class DataDictionary
        {
            public const string Default = GroupName + ".DataDictionary";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            //public const string DetailUpdate = Default + ".DetailUpdate";
            //public const string DetailCreate = Default + ".DetailCreate";
            //public const string DetailDelete = Default + ".DetailDelete";
        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasicPermissions));
        }
    }
}