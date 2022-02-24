using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace kanban_project.ViewModels
{
    public class ColumnViewModel
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
                if (cards == null) cards = new ObservableCollection<CardViewModel>();
                return cards;
            }
            set => cards = value;
        }

        public string Name {
            get => Model.Name;
            set => Model.Name = value;
        }

        public Guid Id
        {
            get => Model.Id;
        }

        // Edit
        // удаление
        // AddCard
        // удаление карточек
    }
}
