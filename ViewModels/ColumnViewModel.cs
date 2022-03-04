using System;
using System.Linq;
using System.Collections.ObjectModel;
using kanban_project.Models;
using Avalonia.Media;

namespace kanban_project.ViewModels
{
    public class ColumnViewModel : ViewModelBase
    {
        public ColumnViewModel()
        {
            Model = new ColumnModel();
        }

        public ColumnViewModel(ColumnModel column)
        {
            Model = column;
        }

        public ColumnModel Model { get; set; }
        public BoardViewModel Parent { get; set; }

        private ObservableCollection<CardViewModel> cards;
        public ObservableCollection<CardViewModel> Cards
        {
            get
            {
                if (cards == null)
                {
                    cards = new ObservableCollection<CardViewModel>(Model.Cards.Select(c => new CardViewModel(c) {
                        Parent = this
                    }));
                }
                return cards;
            }
            set => cards = value;
        }

        public string Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }

        private SolidColorBrush color;
        public SolidColorBrush Color
        {
            get => color ?? new SolidColorBrush(Model.Color);
            set {
                color = value;
                Model.Color = value.Color;
            }
        }

        public Guid Id
        {
            get => Model.Id;
        }

        public void AddCard()
        {
            AddCard(new CardModel());
        }

        public void AddCard(CardModel card)
        {
            CardViewModel cardViewModel = new CardViewModel(card) { Parent = this };
            Cards.Add(cardViewModel);
            Model.Cards.Add(card);
        }

        public void RemoveCard(CardViewModel card)
        {
            Cards.Remove(card);
        }
    }
}
