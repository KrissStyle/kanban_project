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
    }
}
