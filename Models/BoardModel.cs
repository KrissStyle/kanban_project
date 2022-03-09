using System.Collections.Generic;

namespace kanban_project.Models
{
    public class BoardModel : BaseModel
    {
        public string Description { get; set; }
        public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
    }
}
