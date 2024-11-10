﻿using LandGEM.Models;
using LandGEM.Services;

namespace LandGEM.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {
        private DataInsertionModel _dataModel;

        public DataInsertionModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; OnPropertyChanged(); }
        }

        public DataEntryViewModel()
        {
            DataModel = new DataInsertionModel();
        }
    }
}
