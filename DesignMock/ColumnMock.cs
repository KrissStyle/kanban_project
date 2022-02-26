using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.DesignMock
{
    public class ColumnMock : ColumnViewModel
    {
        public ColumnMock()
        {
            Model = new ColumnModel() { Name = "Тест" };
            this.Cards.Add(new CardMock());
            this.Cards.Add(new CardMock());
            this.Cards.Add(new CardMock());
            this.Cards.Add(new CardMock());
            this.Cards.Add(new CardMock());
        }
    }
}
