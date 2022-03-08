using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kanban_project.ViewModels;
using ReactiveUI;
using System.ComponentModel;

namespace kanban_project.Views
{
    public partial class DetailedCardWindow : Window
    {
        public DetailedCardWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
