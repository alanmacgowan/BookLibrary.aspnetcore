using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Features.Home
{
    public class DashboardPanelViewModel
    {
        public string Title { get; set; }
        public int Value { get; set; }
        public string Url { get; set; }
        public string IconCssClass { get; set; }
        public string ColorCssClass { get; set; }
    }
}
