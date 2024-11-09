using LandGEM.Models;
using LandGEM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.ViewModels
{
    public class DataEntryReview : ObservableObject
    {
        private DataInsertionModel _dataModel;

        public DataInsertionModel DataModel
        {
            get => _dataModel;
            set => SetProperty(ref _dataModel, value);
        }

        public DataEntryReview()
        {
            DataModel = new DataInsertionModel();
        }
    }
}
