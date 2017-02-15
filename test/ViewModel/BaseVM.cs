using System.Collections.ObjectModel;
using Elibrium;
using Elibrium.BO;
using Elibrium.Service;
using System.ComponentModel;

namespace ElibriumWPF.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
