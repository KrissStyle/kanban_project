using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kanban_project.ViewModels;
using ReactiveUI;

namespace kanban_project.Views
{
    public partial class DetailedCardPopup : ReactiveWindow<DetailedCardViewModel>
    {
        public DetailedCardPopup()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            //this.WhenActivated(d => d());
        }

        public DetailedCardPopup(CardViewModel cardViewModel) : this()
        {
            this.DataContext = cardViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
