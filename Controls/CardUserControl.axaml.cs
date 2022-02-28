using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using kanban_project.Views.Popups;
using kanban_project.ViewModels;
using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;

namespace kanban_project.Controls
{
    public partial class CardUserControl : UserControl
    {
        public CardUserControl()
        {
            InitializeComponent();
        }

        public void ShowDetailedCardDialog(object sender, RoutedEventArgs e)
        {
            DetailedCardPopUpWindow popup = new DetailedCardPopUpWindow(DataContext as CardViewModel);
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                popup.ShowDialog(desktop.MainWindow);
            }
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
