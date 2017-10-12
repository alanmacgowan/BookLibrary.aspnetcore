using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Features.Home.ViewComponents
{
    public class DashboardPanelViewComponent : ViewComponent
    {

        public DashboardPanelViewComponent()
        {
        }

        public Task<IViewComponentResult> InvokeAsync(DashboardPanelViewModel panel)
        {
            return Task.FromResult<IViewComponentResult>(View("Default", panel));
        }
    }
}
