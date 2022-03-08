using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            WindowState = WindowState.Normal;
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            MainWindowViewModel viewModel = new MainWindowViewModel();

            DataContext = viewModel;
        }
    }
}
