using LandGEM.Services;
using LandGEM.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace LandGEM.ViewModels
{
    /// <summary>
    /// Handles the window itself and allows for page navigation.
    /// </summary>
    public class PrimaryContorolViewModel : ObservableObject
    {
        //re-write to follow https://github.com/CSharpDesignPro/Page-Navigation-using-MVVM/blob/main/ViewModel/NavigationVM.cs
        private Page _currentPage;
        private Page _FirstPage = new DataInsertionPage();
        private Page _ReviewPage = new DataReviewPage();
        private Page _ResultsPage = new DataReviewPage();
        private int currentPageNumber = 0;

        private List<Page> _PageList = new List<Page>();

        public Page CurrentPage
        {
            get
            { return _currentPage; }
            set
            {
                SetProperty(ref _currentPage, value);
            }
        }

        public ICommand NavigateForward => new RelayCommand(param => NextPage());
        public ICommand NavigateBackward => new RelayCommand(param => PreviousPage());


        public void NextPage()
        {
            if (currentPageNumber < _PageList.Count())
            {
                currentPageNumber++;
                CurrentPage = _PageList[currentPageNumber];
            }
        }

        public void PreviousPage()
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber--;
                CurrentPage = _PageList[currentPageNumber];
            }
        }

        public PrimaryContorolViewModel() 
        {
            _PageList.Add(_FirstPage);
            _PageList.Add(_ReviewPage);
            _PageList.Add(_ResultsPage);
            CurrentPage = _PageList[0];
        }
    }
}
