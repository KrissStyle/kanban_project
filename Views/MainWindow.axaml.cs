using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
    public partial class MainWindow : Window
    {
        private TextBox textBox;
        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            this.WindowState = WindowState.Normal;
            this.AttachDevTools();
#endif
            textBox = this.Find<TextBox>("AddColumnTextBox");

            textBox.KeyDown += TextBox_KeyDown;
        }


        private void TextBox_KeyDown(object sender, Avalonia.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                }
                else
                {
                    ((MainWindowViewModel)DataContext).AddColumn(new ColumnModel() { Name = textBox.Text });
                }

                textBox.Text = "";
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            MainWindowViewModel viewModel = new MainWindowViewModel();

            this.DataContext = viewModel;

            //viewModel.OpenAddBoardDialog += () =>
            //{
            //    AddBoardWindow addBoard = new AddBoardWindow(new AddBoardViewModel());
            //    BoardViewModel result = addBoard.ShowDialogSync<BoardViewModel>(this);
            //    return result;
            //};

            //viewModel.OpenEditBoardDialog += (board) =>
            //{
            //    AddBoardWindow addBoard = new AddBoardWindow(new AddBoardViewModel(board));
            //    BoardViewModel result = addBoard.ShowDialogSync<BoardViewModel>(this);
            //    return result;
            //};

            //viewModel.ShowMessageDialog += (title, message) =>
            //{
            //    MessageBoxWindow messageBox = new MessageBoxWindow(new MessageBoxViewModel(title, message));
            //    return messageBox.ShowDialogSync<string>(this);
            //};

            //viewModel.OpenAddColumnDialog += () =>
            //{
            //    AddColumnWindow addColumn = new AddColumnWindow(new AddColumnViewModel());
            //    ColumnViewModel result = addColumn.ShowDialogSync<ColumnViewModel>(this);
            //    return result;
            //};
        }
    }
}
