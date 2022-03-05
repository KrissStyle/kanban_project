using System;
using System.Reactive.Linq;
using System.Windows.Input;
using kanban_project.Models;
using ReactiveUI;

namespace kanban_project.ViewModels {
    public class CardViewModel : ViewModelBase
    {
        //public CardViewModel() : this(new CardModel()) { }

        public CardViewModel(CardModel card)
        {
            Model = card;

            ShowDialog = new Interaction<DetailedCardViewModel, CardViewModel?>();

            EditCardCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var details = new DetailedCardViewModel();

                var result = await ShowDialog.Handle(details);

                if (result != null)
                    Parent!.EditCard(this, result);
            });
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

        public ICommand EditCardCommand { get; }
        public Interaction<DetailedCardViewModel, CardViewModel?> ShowDialog { get; }

        // редактирование
        // удаление
    }

}
