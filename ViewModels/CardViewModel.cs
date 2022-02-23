﻿using kanban_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kanban_project.ViewModels {
    public class CardViewModel : ViewModelBase
    {
        public CardViewModel()
        {
            this.Model = new CardModel();
        }

        public CardViewModel(CardModel card)
        {
            this.Model = card;
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

        // редактирование
        // удаление
    }

}
