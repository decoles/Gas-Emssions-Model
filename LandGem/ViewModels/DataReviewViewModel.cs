using LandGEM.Models;
using LandGEM.Services;

namespace LandGEM.ViewModels
{
    public class DataReviewViewModel : ViewModelBase
    {

        private readonly DataStore _dataStore;
        private DataInsertionModel _dataModel;
        public DataInsertionModel DataModel
        {
            get
            {
                return _dataModel;
            }
            set
            {
                SetProperty(ref _dataModel, value);
            }
        }

        public DataReviewViewModel(DataInsertionModel InsertionModel, DataStore DataStore)
        {
            _dataModel = InsertionModel;

            //If Data Entry Page updated then recieve data
            _dataStore = DataStore;
            _dataStore.DataModelCreated += OnProductCreated;
        }

        public void OnProductCreated(DataInsertionModel dataInsertionModel)
        {
            DataModel = dataInsertionModel;
        }

    }
}
