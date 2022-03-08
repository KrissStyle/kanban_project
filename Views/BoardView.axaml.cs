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
        private TextBox textBox;

        public BoardView()
        {
            InitializeComponent();

            scrollViewer = this.Find<ScrollViewer>("ColumnScrollViewer");
            textBox = this.Find<TextBox>("AddColumnTextBox");

            textBox.KeyDown += TextBox_KeyDown;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                }
                else
                {
                    ((BoardViewModel)DataContext).AddColumn(new ColumnModel() { Name = textBox.Text });

                    scrollViewer.Offset = new Vector(double.PositiveInfinity, double.PositiveInfinity);
                }

                textBox.Text = "";
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
