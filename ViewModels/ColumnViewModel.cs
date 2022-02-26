using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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

        public Guid Id
        {
            get => Model.Id;
        }

        public double ScrollValue
        {
            get;
            set;
        }

        public double MaxScrollValue
        {
            get;
            set;
        }
        // Edit
        // удаление
        public void AddCard()
        {
            // добавить НАСТОЯЩЕЕ создание
            CardViewModel card = new CardViewModel { Parent = this };
            Cards.Add(card);
            Model.Cards.Add(card.Model);
        }

        public void AddCard(CardModel card)
        {
            CardViewModel cardViewModel = new CardViewModel(card) { Parent = this };
            Cards.Add(cardViewModel);
            Model.Cards.Add(card);
        }
        // удаление карточек
    }
}
