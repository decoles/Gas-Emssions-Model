using LandGEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.Services
{
    public class DataStore
    {
        public event Action<DataInsertionModel> DataModelCreated;

        public void CreateDataStore(DataInsertionModel dataInsertionModel)
        {
            DataModelCreated?.Invoke(dataInsertionModel);
        }
    }
}
