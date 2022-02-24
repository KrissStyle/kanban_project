using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace kanban_project.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public BoardViewModel SelectedBoard { get; set; } = new BoardViewModel();

		public void AddColumn()
        {
			// добавить НАСТОЯЩЕЕ создание
			ColumnViewModel column = new();
			SelectedBoard.Columns.Add(column);
			column.Parent = SelectedBoard;
        }
	}
}
