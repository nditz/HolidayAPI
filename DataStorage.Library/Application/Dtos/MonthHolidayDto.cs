using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Library.Application.Dtos
{
    public class MonthHolidayDto
    {
        public string Month { get; set; }
        public string CountryCode { get; set; }
        public string LocalName { get; set; }
    }

    public class MonthDataDto
    {
        public int MonthHolidayCnt { get; set; }
        public string Month { get; set; }
    }
}
