using kanban_project.Models;
using System;

namespace kanban_project.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        public CardViewModel()
        {
            Model = new CardModel();
        }

        public CardViewModel(CardModel card)
        {
            Model = card;
        }

        public CardModel Model { get; set; }
        public ColumnViewModel Parent { get; set; }

        public string Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }

        public string Description
        {
            get => Model.Description;
            set => Model.Description = value;
        }

        public Guid Id { get => Model.Id; }

        public void Delete()
        {
            Parent.RemoveCard(this);
        }
    }
}
