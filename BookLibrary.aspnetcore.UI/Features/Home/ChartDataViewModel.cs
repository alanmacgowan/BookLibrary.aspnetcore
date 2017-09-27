using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Features.Home
{
    public class ChartDataViewModel
    {
        public ChartDataViewModel(int year, int value)
        {
            Year = year;
            Value = value;
        }
        public int Year { get; set; }
        public int Value { get; set; }
    }
}
