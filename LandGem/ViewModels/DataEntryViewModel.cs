using LandGEM.Models;
using LandGEM.Services;
using System.Runtime.Serialization.DataContracts;

namespace LandGEM.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {

        //private DataInsertionModel _insertionModel;
        //public DataInsertionModel DataInsertionModel
        //{
        //    get
        //    {
        //        return _insertionModel;
        //    }
        //    set
        //    {
        //        SetProperty(ref _insertionModel, value);
        //    }
        //}
        public DataInsertionModel insertionModel;

        public DataEntryViewModel(DataInsertionModel insertionModel)
        {
            
        }
    }
}
