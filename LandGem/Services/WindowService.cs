using LandGEM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow()
        {
            var window = new PrimaryControlWindow();

            window.ShowDialog();
        }

        public void CloseWindow()
        {
            
        }
    }
}
