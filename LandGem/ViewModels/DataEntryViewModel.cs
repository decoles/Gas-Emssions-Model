using LandGEM.Models;
using LandGEM.Services;

namespace LandGEM.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {
        private readonly DataStore _store;

        private DataInsertionModel _insertionModel = new DataInsertionModel();
        public DataInsertionModel DataInsertionModel
        {
            get
            {
                return _insertionModel;
            }
            set
            {
                if (_insertionModel != null)
                {
                    // Unsubscribe from old instance
                    _insertionModel.PropertyChanged -= DataInsertionModel_PropertyChanged;
                }

                SetProperty(ref _insertionModel, value);

                if (_insertionModel != null)
                {
                    // Subscribe to the new instance
                    _insertionModel.PropertyChanged += DataInsertionModel_PropertyChanged;
                }
            }
        }

        public DataEntryViewModel(DataInsertionModel insertionModel, DataStore DataStore)
        {
            _insertionModel = insertionModel;
            _store = DataStore;
            //_store.CreateDataStore(DataInsertionModel);
            if (_insertionModel != null)
            {
                // Subscribe to initial instance
                _insertionModel.PropertyChanged += DataInsertionModel_PropertyChanged;
            }
        }
        private void DataInsertionModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Handle property change (e.g., update the data store or notify other components)
            if (_store != null)
            {
                _store.CreateDataStore(_insertionModel);
            }
        }

    }
}
