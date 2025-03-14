﻿using LandGEM.Services;
using System.Windows.Input;

namespace LandGEM.ViewModels
{
    class StartupWindowViewModel
    {
        private IWindowService _windowService;

        public ICommand OpenWindowCommand { get; set; }

        private void OnOpenWindow()
        {
            _windowService.OpenWindow();
        }

        public StartupWindowViewModel(IWindowService windowService)
        {
            _windowService = windowService;

            OpenWindowCommand = new RelayCommand(param => OnOpenWindow());
        }
    }
}
