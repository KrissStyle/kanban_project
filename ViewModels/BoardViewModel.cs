using kanban_project.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
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
            set
            {
                if (Model.Name == value)
                    return;
                Model.Name = value;
                this.RaisePropertyChanged();
            }
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
            Serializer.SerializeBoards();
        }

        public void AddColumn(ColumnModel columnModel)
        {
            ColumnViewModel column = new ColumnViewModel(columnModel);
            Columns.Add(column);
            column.Parent = this;
            Serializer.SerializeBoards();
        }

        public void DeleteColumn(ColumnViewModel column)
        {
            column.Parent = null;
            Columns.Remove(column);
            Serializer.SerializeBoards();
        }

        public void Delete()
        {
            Parent.DeleteBoard(this);
        }
    }
}
