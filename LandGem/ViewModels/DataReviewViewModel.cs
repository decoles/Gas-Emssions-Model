using LandGEM.Models;
using LandGEM.Services;
using System.ComponentModel;

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
                if (_dataModel != null)
                {
                    _dataModel.PropertyChanged -= OnDataModelPropertyChanged;
                }

                SetProperty(ref _dataModel, value);

                if (_dataModel != null)
                {
                    _dataModel.PropertyChanged += OnDataModelPropertyChanged;
                }
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

        private void OnDataModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Notify UI of changes to properties of DataModel
            OnPropertyChanged(nameof(DataModel));
        }
    }
}
