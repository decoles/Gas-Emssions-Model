using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGem.models.usercontrolmodel
{
    internal class textboxModel : INotifyPropertyChanged
    {
        private string _label;
        private string _value;

        public string label
        {
            get { return _label; }
            set
            {

                _label = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
