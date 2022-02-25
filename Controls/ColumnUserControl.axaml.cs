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
        public ColumnUserControl()
        {
            InitializeComponent();

            textBox = this.Find<TextBox>("AddCardTextBox");
            //flyout = (Flyout)textBox.Parent;

            //flyout.Closing += Flyout_Closing;
                
            textBox.KeyDown += ColumnUserControl_KeyDown;
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
                    ((ColumnViewModel)DataContext).AddCard(new CardModel() { Name = textBox.Text });
                }

                textBox.Text = "";
                //((Flyout)((FlyoutPresenter)textBox.Parent).Parent)?.Hide();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
