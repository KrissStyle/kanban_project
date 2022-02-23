using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kanban_project.Models
{
	public class BaseModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
	}
}
