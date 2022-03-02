using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kanban_project.ViewModels;
using ReactiveUI;

namespace kanban_project.Views.Popups
{
    public partial class DetailedCardPopUpWindow : ReactiveWindow<DetailedCardViewModel>
    {
        public DetailedCardPopUpWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated();
        }

        public DetailedCardPopUpWindow(CardViewModel cardViewModel) : this()
        {
            this.DataContext = cardViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
