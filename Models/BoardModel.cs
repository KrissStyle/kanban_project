using System.Collections.Generic;

namespace kanban_project.Models
{
	public class BoardModel : BaseModel
	{
		public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
	}
}
