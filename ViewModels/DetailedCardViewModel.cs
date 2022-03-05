using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kanban_project.ViewModels
{
    public class DetailedCardViewModel : ViewModelBase
    {
        private CardViewModel card;

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
