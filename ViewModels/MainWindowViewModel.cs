using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace kanban_project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
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

            BoardViewModel mock = new BoardViewModel(new BoardModel()
            {
                Name = "Канбан",
                Description = "Доска для отслеживания прогресса разработки :)",
                Columns = { toDo, doing, done }
            });

            SelectedBoard = mock;
        }

        public BoardViewModel SelectedBoard { get; set; }

        public void AddColumn()
        {
            // добавить НАСТОЯЩЕЕ создание
            ColumnViewModel column = new ColumnViewModel();
            SelectedBoard.Columns.Add(column);
            column.Parent = SelectedBoard;
        }

        internal void AddColumn(ColumnModel columnModel)
        {
            ColumnViewModel column = new ColumnViewModel(columnModel);
            SelectedBoard.Columns.Add(column);
            column.Parent = SelectedBoard;
        }
    }
}
