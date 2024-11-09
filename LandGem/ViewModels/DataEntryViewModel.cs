﻿using LandGEM.Models;
using LandGEM.Services;

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
