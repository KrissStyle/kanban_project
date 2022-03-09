using System;

namespace kanban_project.ViewModels
{
    public class DetailedCardViewModel : ViewModelBase
    {
        public DetailedCardViewModel(CardViewModel card)
        {
            this.card = card;
        }

        public CardViewModel card;

        public string Name
        {
            get => card.Name;
            set => card.Name = value;
        }

        public string Description
        {
            get => card.Description;
            set => card.Description = value;
        }

        public Guid Id { get => card.Id; }
    }
}
