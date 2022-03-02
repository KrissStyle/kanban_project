using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using kanban_project.ViewModels;
using kanban_project.Models;

namespace kanban_project.Controls
{
    public partial class ColumnUserControl : UserControl
    {
        //private Flyout flyout;
        private TextBox textBox;
        private ScrollViewer scrollViewer;
        public ColumnUserControl()
        {
            InitializeComponent();

            scrollViewer = this.Find<ScrollViewer>("CardScrollViewer");
            textBox = this.Find<TextBox>("AddCardTextBox");
            //flyout = (Flyout)textBox.Parent;

            //flyout.Closing += Flyout_Closing;
                
            textBox.KeyDown += ColumnUserControl_KeyDown;
            AddHandler(DragDrop.DropEvent, OnDrop);
        }

        //private void Flyout_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(textBox.Text))
        //    {
        //    }
        //    else
        //    {
        //        ((ColumnViewModel)DataContext).AddCard(new CardModel() { Name = textBox.Text });
        //    }

        //    textBox.Text = "";
        //}

        private void ColumnUserControl_KeyDown(object sender, Avalonia.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                } else
                {
                    (DataContext as ColumnViewModel).AddCard(new CardModel() { Name = textBox.Text });
                    scrollViewer.ScrollToEnd();
                }

                textBox.Text = "";
                //((Flyout)((FlyoutPresenter)textBox.Parent).Parent)?.Hide();
            }
        }

        private async void OnDrop(object sender, DragEventArgs e)
        {
            CardViewModel card = e.Data.Get("card") as CardViewModel;

            if (card.Parent == this.DataContext) return;

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
