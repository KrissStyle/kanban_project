using kanban_project.Models;
using ReactiveUI;
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
            set
            {
                if (Model.Name == value)
                    return;
                Model.Name = value;
                this.RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description == value)
                    return;
                Model.Description = value;
                this.RaisePropertyChanged();
            }
        }

        public Guid Id { get => Model.Id; }

        public void Delete()
        {
            Parent.RemoveCard(this);
        }
    }
}
