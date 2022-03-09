using kanban_project.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace kanban_project
{
    public class Serializer
    {
        public static List<BoardModel> Boards;

        public static void DeserializeBoards()
        {
            if (File.Exists("boards.json"))
            {
                Boards = JsonConvert.DeserializeObject<List<BoardModel>>(File.ReadAllText("boards.json"));
            }
            else
            {
                Boards = new List<BoardModel>();
            }
        }

        public static void SerializeBoards()
        {
            File.WriteAllText("boards.json", JsonConvert.SerializeObject(Boards));
        }

        public static void SerializeBoards(List<BoardModel> boards)
        {
            File.WriteAllText("boards.json", JsonConvert.SerializeObject(boards));
        }

        private static BoardModel CreateLandingBoardModel()
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

            return new BoardModel()
            {
                Name = "Канбан",
                Description = "Доска для отслеживания прогресса разработки :)",
                Columns = { toDo, doing, done }
            };
        }
    }
}
