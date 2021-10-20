using Volo.Abp.Reflection;

namespace Basic.Permissions
{
    public class BasicPermissions
    {
        public const string GroupName = "Basic";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasicPermissions));
        }
    }
}