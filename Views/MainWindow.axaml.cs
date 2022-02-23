using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			#if DEBUG
			this.WindowState = WindowState.Normal;
			this.AttachDevTools();
			#endif
		}

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            MainWindowViewModel viewModel = new();

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
