using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Library.Domain
{
    public interface IDataStoreRepository
    {
        DataStore Add(DataStore dataStore);

        IEnumerable<DataStore> Get();
    }
}
