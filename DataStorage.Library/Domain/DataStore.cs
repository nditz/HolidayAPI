using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Library.Domain
{
    public class DataStore
    {
        private DataStore(string date, string localName, string countryCode)
        {
            this.Date = date;
            this.LocalName = localName;
            this.CountryCode = countryCode;
        }

        public static DataStore Create(string date, string localName, string countryCode)
        {
            return new DataStore(date, localName, countryCode);
        }
        public string Date { get;  }
        public string LocalName { get; }
        public string CountryCode { get;  }
      
    }
}
