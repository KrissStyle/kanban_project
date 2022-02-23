using System.Collections.Generic;

namespace kanban_project.Models
{
	public class ColumnModel : BaseModel
	{
		public List<CardModel> Cards { get; set; } = new List<CardModel>();
	}
}
