using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Library.Application.Dtos
{
    public class CountryHolidayDto
    {
        public int HolidayCount { get; set; }
        public string CountryCode { get; set; }
    }

    public class DistinctDataDto
    {
        public string CountryCode { get; set; }
        public int DistinctCount { get; set; }

    }
}
