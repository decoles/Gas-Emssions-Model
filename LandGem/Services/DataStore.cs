using LandGEM.Models;

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
