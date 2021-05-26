using AutoMapper;
using DataStorage.Library.Application.Dtos;
using DataStorage.Library.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IDataStoreService dataStoreService;

        public HolidayController(IDataStoreService dataStoreService)
        {
            this.dataStoreService = dataStoreService;
        }
        //GET api/holiday
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Load data 
            await this.dataStoreService.AddDataAsync();
            // get country holidays count list 
            var result = this.dataStoreService.GetCountryHolidayData();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //Post api/holiday
        [HttpPost]
        [Route("AddHoliday")]
        public IActionResult CreateData(DataStoreDto dataStoreDto)
        {
            //DataStoreDto dto = new DataStoreDto
            //{
            //    Date = date,
            //    LocalName = localName,
            //    Name = name,
            //    CountryCode = countryCode
            //};
            // Load data 
            var result = this.dataStoreService.AddData(dataStoreDto);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //GET api/holiday/GetCntCountry
        [HttpGet]
        [Route("GetCntCountry")]
        public IActionResult GetTopCountryHolidaysCnt()
        {
            var result = this.dataStoreService.GetMostHolidayCntPerCountry();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //GET api/holiday/GetCntMonth
        [HttpGet]
        [Route("GetCntMonth")]
        public IActionResult GetTopMonthHolidaysCnt()
        {
            var result = this.dataStoreService.GetMostHolidayCntPerMonth();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //GET api/holiday/GetCntDistinct
        [HttpGet]
        [Route("GetCntDistinct")]
        public IActionResult GetTopDistinctHolidaysCnt()
        {
            var result = this.dataStoreService.GetMostDistinct();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
