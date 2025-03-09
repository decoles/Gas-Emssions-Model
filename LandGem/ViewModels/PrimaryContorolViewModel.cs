using LandGEM.Models;
using LandGEM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LandGEM.ViewModels
{
    /// <summary>
    /// Handles the window itself and allows for page navigation.
    /// </summary>
    public class PrimaryContorolViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private DataInsertionModel _insertionModel = new DataInsertionModel();
        
        // CanExecute methods for navigation
        private bool CanNavigateForward() => _currentPageNumber < _pageList.Count - 1;
        private bool CanNavigateBackward() => _currentPageNumber > 0;

        public ICommand NavigateForward { get; set; }
        public ICommand NavigateBackward {  get; set; }

        // List of ViewModels for page navigation
        private readonly ObservableCollection<object> _pageList;
        private int _currentPageNumber;

        DataStore dataStore = new DataStore();
        // Navigation methods
        private void NextPage(object parameter = null)
        {
            if (CanNavigateForward())
            {
                _currentPageNumber++;
                CurrentView = _pageList[_currentPageNumber];
                //_dataStore.CreateProduct(InsertionModel)
            }
        }

        private void PreviousPage(object parameter = null)
        {
            if (CanNavigateBackward())
            {
                _currentPageNumber--;
                CurrentView = _pageList[_currentPageNumber];
            }
        }

        public PrimaryContorolViewModel() 
        {
            DataEntryViewModel dataEntryVM = new DataEntryViewModel(_insertionModel, dataStore);
            DataReviewViewModel dataReviewVM = new DataReviewViewModel(_insertionModel, dataStore);

            // Initialize page list and add ViewModels
            _pageList = new ObservableCollection<object> { dataEntryVM, dataReviewVM };

            // Set the starting page
            _currentPageNumber = 0;
            CurrentView = _pageList[_currentPageNumber];

            // Initialize commands
            NavigateForward = new RelayCommand(NextPage, _ => CanNavigateForward());
            NavigateBackward = new RelayCommand(PreviousPage, _ => CanNavigateBackward());
        }
    }
}
