using ReactiveUI;
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
            set
            {
                if (card.Name == value)
                    return;
                card.Name = value;
                this.RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => card.Description;
            set
            {
                if (card.Description == value)
                    return;
                card.Description = value;
                this.RaisePropertyChanged();
            }
        }

        public Guid Id { get => card.Id; }
    }
}
