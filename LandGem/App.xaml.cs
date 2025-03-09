using LandGEM.Content;
using System.Windows;

namespace LandGEM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            LandfillGasData.LoadData();
        }
    }
}
