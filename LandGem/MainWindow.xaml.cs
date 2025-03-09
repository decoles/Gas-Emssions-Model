using LandGEM.Services;
using LandGEM.ViewModels;
using System.Windows;

namespace LandGEM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var windowService = new WindowService();

            this.DataContext = windowService;
            DataContext = new StartupWindowViewModel(windowService);
        }
    }
}