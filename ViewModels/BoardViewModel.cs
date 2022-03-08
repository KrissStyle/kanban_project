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
        public MainWindowViewModel Parent { get; set; }

        private ObservableCollection<ColumnViewModel> columns;
        public ObservableCollection<ColumnViewModel> Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new ObservableCollection<ColumnViewModel>(
                        Model.Columns.Select(c => new ColumnViewModel(c) { Parent = this })
                    );
                }
                return columns;
            }
            set => columns = value;
        }

        public string Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }

        public string Description
        {
            get => Model.Description;
            set => Model.Description = value;
        }
        
        public Guid Id
        {
            get => Model.Id;
        }

        public void AddColumn()
        {
            // добавить НАСТОЯЩЕЕ создание
            ColumnViewModel column = new ColumnViewModel();
            Columns.Add(column);
            column.Parent = this;
        }

        public void AddColumn(ColumnModel columnModel)
        {
            ColumnViewModel column = new ColumnViewModel(columnModel);
            Columns.Add(column);
            column.Parent = this;
        }

        public void DeleteColumn(ColumnViewModel column) {
            column.Parent = null;
            Columns.Remove(column);
        }

        public void Delete()
        {
            Parent.DeleteBoard(this);
        }
    }
}
