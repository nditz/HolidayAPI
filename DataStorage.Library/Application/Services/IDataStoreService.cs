using DataStorage.Library.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Library.Application.Services
{
    public interface IDataStoreService
    {
        Task AddDataAsync();
        DataStoreDto AddData(DataStoreDto dataStoreDtos);
        CountryHolidayDto GetMostHolidayCntPerCountry();
        MonthDataDto GetMostHolidayCntPerMonth();
        DistinctDataDto GetMostDistinct();
        IEnumerable<CountryHolidayDto> GetCountryHolidayData();
        IEnumerable<MonthDataDto> GetMonthHolidayData();
    }
}
