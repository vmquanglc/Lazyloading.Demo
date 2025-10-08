using Lazyloading.Demo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Lazyloading.Demo.Permissions;

public class DemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DemoPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(DemoPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(DemoPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(DemoPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(DemoPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DemoResource>(name);
    }
}
