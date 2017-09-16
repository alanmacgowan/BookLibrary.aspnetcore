using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Features.Home
{
    public class DashboardViewModel
    {
        public DashboardPanelViewModel BooksPanel { get; set; }
        public DashboardPanelViewModel AuthorsPanel { get; set; }
        public DashboardPanelViewModel PublishersPanel { get; set; }

    }
}
