using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace kanban_project.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        public BoardViewModel()
        {
            Model = new BoardModel();
        }

        public BoardViewModel(BoardModel board)
        {
            Model = board;
        }

        public BoardModel Model { get; set; }

        private ObservableCollection<ColumnViewModel> columns;
        public ObservableCollection<ColumnViewModel> Columns
        {
            get
            {
                if (columns == null) columns = new ObservableCollection<ColumnViewModel>();
                return columns;
            }
            set => columns = value;
        }

        public string Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }

        public Guid Id
        {
            get => Model.Id;
        }

        // удаление столбца
    }
}
