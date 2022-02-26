using kanban_project.Models;
using kanban_project.ViewModels;
using System.Collections.ObjectModel;

namespace kanban_project.DesignMock
{
    public class MainWindowMock : MainWindowViewModel
    {
        public MainWindowMock()
        {
            Boards = new ObservableCollection<BoardViewModel>();
            #region Selected Board
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

            SelectedBoard = mock;
            Boards.Add(mock);
            #endregion
        }
    }
}
