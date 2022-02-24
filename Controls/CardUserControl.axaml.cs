using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace kanban_project.Controls
{
    public partial class CardUserControl : UserControl
    {
        public CardUserControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
