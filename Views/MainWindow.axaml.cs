using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private ScrollViewer scrollViewer;
        private TextBox textBox;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            WindowState = WindowState.Normal;
            this.AttachDevTools();
#endif
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
                    ((MainWindowViewModel)DataContext).AddColumn(new ColumnModel() { Name = textBox.Text });

                    scrollViewer.Offset = new Vector(double.PositiveInfinity, double.PositiveInfinity);
                }

                textBox.Text = "";
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            MainWindowViewModel viewModel = new MainWindowViewModel();

            DataContext = viewModel;
        }
    }
}
