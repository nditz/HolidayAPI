using DataStorage.Library.ApiWrapper;
using DataStorage.Library.Application.Dtos;
using DataStorage.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Library.Application.Services
{
    public class DataStoreService : IDataStoreService
    {
        private readonly IDataStoreRepository dataStoreRepository;
        public DataStoreService(IDataStoreRepository dataStoreRepository)
        {
            this.dataStoreRepository = dataStoreRepository;
        }

        public DataStoreDto AddData(DataStoreDto item)
        {
            if (item != null)
                this.dataStoreRepository.Add(DataStore.Create(item.Date, item.LocalName, item.CountryCode));
            return item;
        }

        public async Task AddDataAsync()
        {
            IReadOnlyList<string> countryCodes = Enum.GetNames(typeof(CountryCodes)).ToList();
            HTTPClientWrapper wrapper = new HTTPClientWrapper();
            var data = await wrapper.Execute(countryCodes);
            foreach (var item in data)
            {
                this.dataStoreRepository.Add(DataStore.Create(item.Date, item.LocalName, item.CountryCode));
            }
        }

        public IEnumerable<CountryHolidayDto> GetCountryHolidayData()
        {
            return this.dataStoreRepository.Get().GroupBy(p => p.CountryCode)
                .OrderByDescending(k => k.Key)
                .Select(g => new CountryHolidayDto { CountryCode = g.Key, HolidayCount = g.Count() });

        }

        public IEnumerable<MonthDataDto> GetMonthHolidayData()
        {
            var data = this.dataStoreRepository.Get()
                .Select(p => new MonthHolidayDto { Month = p.Date.Split('-')[1], CountryCode = p.CountryCode, LocalName = p.LocalName });
            return data.GroupBy(p => p.Month)
                .OrderByDescending(k => k.Key)
                .Select(s => new MonthDataDto { MonthHolidayCnt = s.Count(), Month = s.Key });
            
        }

        public DistinctDataDto GetMostDistinct()
        {
            return this.dataStoreRepository.Get()
                .GroupBy(p => new { p.CountryCode, p.Date })
                .Select(s => new DistinctDataDto { CountryCode = s.Key.CountryCode, DistinctCount = s.Count()})
                .OrderByDescending(o => o.DistinctCount).FirstOrDefault();
        }

        public CountryHolidayDto GetMostHolidayCntPerCountry()
        {
            return this.dataStoreRepository.Get().GroupBy(p => p.CountryCode)
                .Select(g => new CountryHolidayDto { CountryCode = g.Key, HolidayCount = g.Count() })
                .OrderByDescending(o => o.HolidayCount).FirstOrDefault();
        }

        public MonthDataDto GetMostHolidayCntPerMonth()
        {
            var data = this.dataStoreRepository.Get()
                .Select(p => new MonthHolidayDto { Month = p.Date.Split('-')[1], CountryCode = p.CountryCode, LocalName = p.LocalName });
            return data.GroupBy(p => p.Month)
                .Select(s => new MonthDataDto { MonthHolidayCnt = s.Count(), Month = s.Key })
                .OrderByDescending(o => o.MonthHolidayCnt).FirstOrDefault();
        }
    }
}
