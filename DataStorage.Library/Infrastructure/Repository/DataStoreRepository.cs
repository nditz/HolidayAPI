using DataStorage.Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Library.Infrastructure.Repository
{
    public class DataStoreRepository : IDataStoreRepository
    {
        private readonly HashSet<DataStore> dataStoreAggregates;
        public DataStoreRepository()
        {
            dataStoreAggregates = new HashSet<DataStore>();
        }
        public DataStore Add(DataStore dataStore)
        {
            dataStoreAggregates.Add(dataStore);
            return dataStore;
        }

        public IEnumerable<DataStore> Get()
        {
            return dataStoreAggregates;
        }
    }
}
