using LandGEM.Content;
using LandGEM.Models;
using LandGEM.Services;
using LandGEM.Views;
using System.Collections.ObjectModel;

namespace LandGEM.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {
        #region Private Variables
        private readonly DataStore _store;

        private DataInsertionModel _insertionModel = new DataInsertionModel();
        private string _selectedGas1;
        private string _selectedGas2;
        private string _selectedGas3;
        private string _selectedGas4;

        //For 2. Determine Model Parameters
        private string _parameter1;
        private string _parameter2;
        private string _parameter3;
        private string _parameter4;

        private string _inputUnit;
        private string _wasteDesignOption;

        private bool _isLandfillClosureYearVisible;

        private string _radioButtonState;
        #endregion

        #region Public Variables
        public string selectedGas1
        {
            get { return _selectedGas1; }
            set
            {
                SetProperty(ref _selectedGas1, value);
                DataInsertionModel.Pollutant1 = value;
            }
        }

        public string selectedGas2
        {
            get { return _selectedGas2; }
            set
            {
                SetProperty(ref _selectedGas2, value);
                DataInsertionModel.Pollutant2 = value;
            }
        }

        public string selectedGas3
        {
            get { return _selectedGas3; }
            set
            {
                SetProperty(ref _selectedGas3, value);
                DataInsertionModel.Pollutant3 = value;
            }
        }

        public string selectedGas4
        {
            get { return _selectedGas4; }
            set
            {
                SetProperty(ref _selectedGas4, value);
                DataInsertionModel.Pollutant4 = value;
            }
        }

        public string parameter1
        {
            get { return _parameter1; }
            set
            {
                SetProperty(ref _parameter1, value);
                DataInsertionModel.MethaneGenerationRate = value;
            }
        }

        public string parameter2
        {
            get { return _parameter2; }
            set
            {
                SetProperty(ref _parameter2, value);
                DataInsertionModel.PotentialMethaneGenerationCapacity = value;
            }
        }

        public string parameter3
        {
            get { return _parameter3; }
            set
            {
                SetProperty(ref _parameter3, value);
                DataInsertionModel.NMOCConcentration = value;
            }
        }

        public string parameter4
        {
            get { return _parameter4; }
            set
            {
                SetProperty(ref _parameter4, value);
                DataInsertionModel.MethaneContent = value;
            }
        }

        public string inputUnit
        {
            get { return _inputUnit; }
            set
            {
                SetProperty(ref _inputUnit, value);
                DataInsertionModel.InputUnit = value;
            }
        }

        public bool IsLandfillClosureYearVisible
        {
            get { return _isLandfillClosureYearVisible; }
            set { SetProperty(ref _isLandfillClosureYearVisible, value); }
        }

        public string wasteDesignOption
        {
            get { return _wasteDesignOption; }
            set
            {
                SetProperty(ref _wasteDesignOption, value);
                DataInsertionModel.WasteDesignCapacity = value;
            }
        }

        public string radioButtonState
        {
            get { return _radioButtonState; }
            set
            {
                SetProperty(ref _radioButtonState, value);
                //DataInsertionModel.CalculateClosureYear = value;
                //IsLandfillClosureYearVisible = value;
            }
        }

        public ObservableCollection<string> GasNames { get; }
        public ObservableCollection<string> Parameter1Names { get; }
        public ObservableCollection<string> Parameter2Names { get; }
        public ObservableCollection<string> Parameter3Names { get; }
        public ObservableCollection<string> Parameter4Names { get; }
        public ObservableCollection<string> InputUnits { get; }
        public ObservableCollection<string> WasteDesignOptions { get; }

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
        #endregion

        #region Consturctor
        public DataEntryViewModel(DataInsertionModel insertionModel, DataStore DataStore)
        {
            _insertionModel = insertionModel;
            _store = DataStore;
            GasNames = new ObservableCollection<string>(LandfillGasData.GasData.Keys);
            Parameter1Names = new ObservableCollection<string>(LandfillGasData.parameter1.Keys);
            Parameter2Names = new ObservableCollection<string>(LandfillGasData.parameter2.Keys);
            Parameter3Names = new ObservableCollection<string>(LandfillGasData.parameter3.Keys);
            Parameter4Names = new ObservableCollection<string>(LandfillGasData.parameter4.Keys);
            InputUnits = new ObservableCollection<string> { "Mg/year", "short-tons/year" };
            WasteDesignOptions = new ObservableCollection<string> { "megagrams", "short-tons" };
            inputUnit = InputUnits[0];
            wasteDesignOption = WasteDesignOptions[0];
            radioButtonState = "Yes";

            if (_insertionModel != null)
            {
                // Subscribe to initial instance
                _insertionModel.PropertyChanged += DataInsertionModel_PropertyChanged;
            }
        }
        #endregion

        #region Private Methods
        private void DataInsertionModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Handle property change (e.g., update the data store or notify other components)
            if (_store != null)
            {
                _store.CreateDataStore(_insertionModel);
            }
        }
        #endregion
    }
}
