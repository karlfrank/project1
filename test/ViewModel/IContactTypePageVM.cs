using System.Collections.ObjectModel;
using System.ComponentModel;
using Elibrium.BO;

namespace ElibriumWPF.ViewModel
{
	interface IContactTypePageVM
	{
		ObservableCollection<ContactTypeBO> ContactTypes
		{
			get;
		}

		event PropertyChangedEventHandler PropertyChanged;

		bool ContactTypeInUse(ContactTypeBO a);
		void GetContactTypes();
	}
}