using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace kanban_project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            #region mock
#if DEBUG
            ColumnModel toDo = new ColumnModel()
            {
                Name = "Сделать",
                Cards = {
                            new CardModel() { Name = "Перетаскивание", Description = "Добавить возможность перетаскивать карточки и столбцы, а еще Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce et tempor nisl. Vivamus nec enim id tortor elementum suscipit. Cras mi libero, tincidunt quis eros id, tincidunt viverra augue. Quisque aliquet dictum massa, non condimentum magna cursus a. Cras ultricies nec lorem vel fermentum. Aenean consequat lacinia risus, ac tempus mauris aliquet nec." },
                            new CardModel() { Name = "Сохранение" },
                            new CardModel() { Name = "Кастомные темы" }
                        }
            };
            ColumnModel doing = new ColumnModel()
            {
                Name = "В процессе",
                Cards = { new CardModel() { Name = "Графический дизайн" } }
            };
            ColumnModel done = new ColumnModel()
            {
                Name = "Сделано",
                Cards = { new CardModel() { Name = "Паника" } }
            };
            ColumnModel overflow = new ColumnModel()
            {
                Name = "Много карточек и длинное название",
                Cards = {
                            new CardModel() { Name = "Lorem ipsum" },
                            new CardModel() { Name = "Lorem ipsum" },
                            new CardModel() { Name = "Lorem ipsum" },
                            new CardModel() { Name = "Lorem ipsum" },
                            new CardModel() { Name = "Lorem ipsum" }
                        }
            };

            BoardViewModel mock = new BoardViewModel(new BoardModel()
            {
                Name = "Канбан",
                Description = "Доска для отслеживания прогресса разработки :)",
                Columns = { toDo, doing, done, overflow }
            });

            AddBoard(mock);
#endif
            #endregion
        }

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
                    // загрузить сохраненные доски
                    boards = new ObservableCollection<BoardViewModel>();
                }
                return boards;
            }
            set => boards = value;
        }

        public void AddBoard()
        {
            BoardViewModel board = new BoardViewModel(new BoardModel()
            {
                Name = "Доска",
                Description = "Канбан доска для отслеживания прогресса разработки :)",
                Columns = {
                    new ColumnModel() { Name = "Сделать" },
                    new ColumnModel() { Name = "В процессе" },
                    new ColumnModel() {
                        Name = "Сделано",
                        Cards = { new CardModel() { Name = "Доска" } }
                    }
                }
            });

            board.Parent = this;
            Boards.Add(board);
            SelectedBoard = board;
        }

        public void AddBoard(BoardViewModel board)
        {
            board.Parent = this;
            Boards.Add(board);
            SelectedBoard = board;
        }

        public void DeleteBoard(BoardViewModel board)
        {
            board.Parent = null;
            Boards.Remove(board);
            if (SelectedBoard != null && SelectedBoard.Equals(board))
                SelectedBoard = Boards.FirstOrDefault();
        }
    }
}
