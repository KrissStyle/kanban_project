using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
    public partial class ColumnView : UserControl
    {
        private TextBox textBox;
        private ScrollViewer scrollViewer;
        public ColumnView()
        {
            InitializeComponent();

            scrollViewer = this.Find<ScrollViewer>("CardScrollViewer");
            textBox = this.Find<TextBox>("AddCardTextBox");

            textBox.KeyDown += ColumnUserControl_KeyDown;

            AddHandler(DragDrop.DropEvent, OnDrop);
        }

        private void DeleteColumn(object? sender, RoutedEventArgs e)
        {
            var column = DataContext as ColumnViewModel;
            column.Parent.DeleteColumn(column);
        }

        private void ColumnUserControl_KeyDown(object sender, Avalonia.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                }
                else
                {
                    (DataContext as ColumnViewModel).AddCard(new CardModel() { Name = textBox.Text });
                    scrollViewer.ScrollToEnd();
                }

                textBox.Text = "";
            }
        }

        private async void OnDrop(object sender, DragEventArgs e)
        {
            CardViewModel card = e.Data.Get("card") as CardViewModel;

            if (card.Parent == this.DataContext)
                return;

            card.Parent.RemoveCard(card);
            (DataContext as ColumnViewModel).AddCard(card.Model);
            scrollViewer.ScrollToEnd();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
