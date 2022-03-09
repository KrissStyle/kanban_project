using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
    public partial class BoardView : UserControl
    {
        private ScrollViewer scrollViewer;
        private TextBox addColumnTextBox;

        public BoardView()
        {
            InitializeComponent();

            scrollViewer = this.Find<ScrollViewer>("ColumnScrollViewer");
            addColumnTextBox = this.Find<TextBox>("AddColumnTextBox");

            addColumnTextBox.KeyDown += AddColumnKeyDown;
        }

        private void AddColumnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (string.IsNullOrEmpty(addColumnTextBox.Text))
                {
                }
                else
                {
                    ((BoardViewModel)DataContext).AddColumn(new ColumnModel() { Name = addColumnTextBox.Text });

                    scrollViewer.Offset = new Vector(double.PositiveInfinity, double.PositiveInfinity);
                }

                addColumnTextBox.Text = "";
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
