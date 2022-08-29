using MultipleDbContextDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MultipleDbContextDemo.Permissions;

public class MultipleDbContextDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MultipleDbContextDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MultipleDbContextDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MultipleDbContextDemoResource>(name);
    }
}
