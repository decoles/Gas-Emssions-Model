using LandGEM.Models;
using LandGEM.Services;
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

        // CanExecute methods for navigation
        private bool CanNavigateForward() => _currentPageNumber < _pageList.Count - 1;
        private bool CanNavigateBackward() => _currentPageNumber > 0;

        public ICommand NavigateForward { get; set; }
        public ICommand NavigateBackward {  get; set; }

        // List of ViewModels for page navigation
        private readonly List<object> _pageList;
        private int _currentPageNumber;


        // Navigation methods
        private void NextPage(object parameter = null)
        {
            if (CanNavigateForward())
            {
                _currentPageNumber++;
                CurrentView = _pageList[_currentPageNumber];
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
            // Initialize page list and add ViewModels
            _pageList = new List<object>
            {
                new DataEntryViewModel (),
                new DataReviewViewModel (),
                //new ResultsViewModel()
            };

            // Set the starting page
            _currentPageNumber = 0;
            CurrentView = _pageList[_currentPageNumber];

            // Initialize commands
            //NavigateForward = new RelayCommand(NextPage, CanNavigateForward);
            //NavigateBackward = new RelayCommand(PreviousPage, CanNavigateBackward);
            NavigateForward = new RelayCommand(NextPage, _ => CanNavigateForward());
            NavigateBackward = new RelayCommand(PreviousPage, _ => CanNavigateBackward());
        }
    }
}
