using Acme.BookStore.BookManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.BookManagement.Authorization
{
    public class BookManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(BookManagementPermissions.GroupName, L("Permission:BookManagement"));
            var bookStoreGroup = context.AddGroup(BookManagementPermissions.GroupName, L("Permission:BookStore"));

            var booksPermission = bookStoreGroup.AddPermission(BookManagementPermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(BookManagementPermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(BookManagementPermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(BookManagementPermissions.Books.Delete, L("Permission:Books.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookManagementResource>(name);
        }
    }
}