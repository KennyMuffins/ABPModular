using System.Threading.Tasks;
using Acme.IssueManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace Acme.IssueManagement.Blazor.Host
{
    public class IssueManagementHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<IssueManagementResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "IssueManagement.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
