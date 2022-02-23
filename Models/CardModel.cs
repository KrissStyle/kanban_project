using Avalonia.Media;

namespace kanban_project.Models
{
	public class CardModel : BaseModel
	{
		public string Description { get; set; }
		public Color Color { get; set; }
	}
}
