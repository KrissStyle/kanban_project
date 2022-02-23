using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace kanban_project.Controls
{
    public partial class ColumnUserControl : UserControl
{
    public ColumnUserControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
}
