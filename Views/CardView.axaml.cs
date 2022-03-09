using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kanban_project.ViewModels;
using System;

namespace kanban_project.Views
{
    public partial class CardView : UserControl
    {
        public CardView()
        {
            InitializeComponent();
        }

        public async void ShowDetailedCardDialog(object sender, RoutedEventArgs e)
        {
            var card = DataContext as CardViewModel;
            var details = new DetailedCardViewModel(DataContext as CardViewModel);
            DetailedCardWindow popup = new DetailedCardWindow() { DataContext = details };

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await popup.ShowDialog(desktop.MainWindow);

                card.Parent.EditCard(card, details.card);
            }
        }

        public void DeleteCard(object? sender, RoutedEventArgs e)
        {
            var card = DataContext as CardViewModel;
            card.Parent.RemoveCard(card);
        }

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
