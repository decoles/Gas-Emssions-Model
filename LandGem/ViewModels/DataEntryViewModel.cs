using LandGEM.Models;
using LandGEM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.ViewModels
{
    public class DataEntryViewModel : ObservableObject
    {
        private DataInsertionModel _dataModel;

        public DataInsertionModel DataModel
        {
            get => _dataModel;
            set => SetProperty(ref _dataModel, value);
        }

        public DataEntryViewModel()
        {
            DataModel = new DataInsertionModel();
        }
    }
}
