using System;
using System.Collections.Generic;
using System.Text;

namespace kanban_project.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public BoardViewModel SelectedBoard { get; set; }
	}
}
