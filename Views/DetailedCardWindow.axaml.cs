using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
