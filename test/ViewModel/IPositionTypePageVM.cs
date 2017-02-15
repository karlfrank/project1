using System.Collections.ObjectModel;
using System.ComponentModel;
using Elibrium.BO;

namespace ElibriumWPF.ViewModel
{
    interface IPositionTypePageVM
    {
        ObservableCollection<PositionTypeBO> PositionTypes
        {
            get;
        }

        event PropertyChangedEventHandler PropertyChanged;

        void GetPositionTypes();
    }
}