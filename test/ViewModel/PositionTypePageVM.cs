using System.Collections.ObjectModel;
using Elibrium.BO;
using Elibrium.Service;

namespace ElibriumWPF.ViewModel
{
    class PositionTypePageVM : BaseVM, IPositionTypePageVM
    {
        public PositionTypePageVM()
        {

        }
        private ObservableCollection<PositionTypeBO> _positionTypes
        {
            get
            {
                return PositionTypeService.GetAllPositionTypes();
            }
            set
            {
                OnPropertyChanged("_positionTypes");
            }
        }

        public ObservableCollection<PositionTypeBO> PositionTypes
        {
            get
            {
                return _positionTypes;
            }
        }

        public void GetPositionTypes()
        {
            _positionTypes = PositionTypeService.GetAllPositionTypes();
        }

    }
}
