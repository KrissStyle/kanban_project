using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using kanban_project.Views;
using kanban_project.ViewModels;
using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using ReactiveUI;
using System.Threading.Tasks;
using Avalonia.ReactiveUI;

namespace kanban_project.Controls
{
    public partial class CardUserControl : ReactiveUserControl<CardViewModel>
    {
        public CardUserControl()
        {
            InitializeComponent();

            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }

        private async Task DoShowDialogAsync(InteractionContext<DetailedCardViewModel, CardViewModel?> interaction)
        {
            var dialog = new DetailedCardPopup();
            dialog.DataContext = interaction.Input;

            var result = await dialog.ShowDialog<CardViewModel?>(VisualRoot as MainWindow);
            interaction.SetOutput(result);
        }

        public void OnTapped(object sender, RoutedEventArgs e)
        {
            ViewModel!.EditCardCommand.Execute(null);
        }
        //public async void ShowDetailedCardDialog(object sender, RoutedEventArgs e)
        //{
        //    DetailedCardPopup popup = new DetailedCardPopup(DataContext as CardViewModel);
        //    if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //    {
        //        var a = await popup.ShowDialog(desktop.MainWindow);
        //    }
        //}

        PointerPoint initialPoint;
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            initialPoint = e.GetCurrentPoint(this);
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);

            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed && PassedThreshold(e))
            {
                initialPoint = e.GetCurrentPoint(this);
                DataObject data = new DataObject();
                data.Set("card", DataContext as CardViewModel);
                DragDrop.DoDragDrop(e, data, DragDropEffects.Move);
            }
        }

        private bool PassedThreshold(PointerEventArgs e)
        {
            PointerPoint currentPoint = e.GetCurrentPoint(this);

            return initialPoint != null
                && Math.Abs(currentPoint.Position.X - initialPoint.Position.X) >= 3
                && Math.Abs(currentPoint.Position.Y - initialPoint.Position.Y) >= 3;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
