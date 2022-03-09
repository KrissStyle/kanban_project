using kanban_project.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace kanban_project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private BoardViewModel selectedBoard;
        public BoardViewModel SelectedBoard
        {
            get => selectedBoard;
            set => selectedBoard = value;
        }

        private ObservableCollection<BoardViewModel> boards { get; set; }
        public ObservableCollection<BoardViewModel> Boards
        {
            get
            {
                if (boards == null)
                {
                    Serializer.DeserializeBoards();
                    boards = new ObservableCollection<BoardViewModel>(Serializer.Boards.Select(b => new BoardViewModel(b) { Parent = this }));
                    if (boards.Count == 0)
                        AddBoard();
                    else
                        SelectedBoard = boards.FirstOrDefault();
                }
                return boards;
            }
            set => boards = value;
        }

        public void AddBoard()
        {
            AddBoard(new BoardViewModel(new BoardModel()
            {
                Name = "Доска",
                Description = "Канбан доска для отслеживания прогресса разработки :)",
                Columns = {
                    new ColumnModel() { Name = "Сделать" },
                    new ColumnModel() { Name = "В процессе" },
                    new ColumnModel() { Name = "Сделано" }
                }
            }));
        }

        public void AddBoard(BoardViewModel board)
        {
            board.Parent = this;
            Boards.Add(board);
            Serializer.Boards.Add(board.Model);
            SelectedBoard = board;
            Serializer.SerializeBoards();
        }

        public void DeleteBoard(BoardViewModel board)
        {
            Serializer.Boards.Remove(board.Model);
            board.Parent = null;
            Boards.Remove(board);
            if (SelectedBoard != null && SelectedBoard.Equals(board))
                SelectedBoard = Boards.FirstOrDefault();
            Serializer.SerializeBoards();
        }
    }
}
