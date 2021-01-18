using Volo.Abp.Reflection;

namespace Acme.BookStore.BookManagement.Authorization
{
    public class BookManagementPermissions
    {
        public const string GroupName = "BookManagement";

        public static class Books
        {
            public const string Default = GroupName + ".Books";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BookManagementPermissions));
        }
    }
}