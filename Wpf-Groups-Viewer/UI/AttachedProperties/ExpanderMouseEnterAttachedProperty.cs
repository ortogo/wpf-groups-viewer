using System.Windows;
using System.Windows.Input;

namespace WpfGroupsViewer.UI.AttachedProperties
{
    public static class MouseEnterCommandAttachedProperty
    {
        public static readonly DependencyProperty MouseEnterCommand =
            DependencyProperty.RegisterAttached(nameof(MouseEnterCommand), typeof(ICommand), typeof(MouseEnterCommandAttachedProperty),
                                                                    new PropertyMetadata(null, MouseEnterCommandPropertyChangedCallback));
        public static readonly DependencyProperty MouseEnterCommandParameter =
            DependencyProperty.RegisterAttached(nameof(MouseEnterCommandParameter), typeof(object), typeof(MouseEnterCommandAttachedProperty),
                                                                    new PropertyMetadata(null, MouseEnterCommandParameterPropertyChangedCallback));

        public static readonly DependencyProperty MouseLeaveCommand =
            DependencyProperty.RegisterAttached(nameof(MouseLeaveCommand), typeof(ICommand), typeof(MouseEnterCommandAttachedProperty),
                                                                    new PropertyMetadata(null, MouseLeaveCommandPropertyChangedCallback));
        public static readonly DependencyProperty MouseLeaveCommandParameter =
            DependencyProperty.RegisterAttached(nameof(MouseLeaveCommandParameter), typeof(object), typeof(MouseEnterCommandAttachedProperty),
                                                                    new PropertyMetadata(null, MouseLeaveCommandParameterPropertyChangedCallback));

        private static void MouseEnterCommandParameterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var ui = dependencyObject as UIElement;
            if (ui == null) return;
        }

        private static void MouseLeaveCommandParameterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var ui = dependencyObject as UIElement;
            if (ui == null) return;
        }

        private static void MouseEnterCommandPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is UIElement ui)) return;

            if (args.OldValue != null)
            {
                ui.RemoveHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(MouseEnter));
            }

            if (args.NewValue != null)
            {
                ui.AddHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(MouseEnter));
            }
        }

        private static void MouseLeaveCommandPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is UIElement ui)) return;

            if (args.OldValue != null)
            {
                ui.RemoveHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(MouseLeave));
            }

            if (args.NewValue != null)
            {
                ui.AddHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(MouseLeave));
            }
        }

        private static void ExecuteCommand(object sender, DependencyProperty commandProperty, DependencyProperty commandParameterProperty)
        {
            if (!(sender is DependencyObject dp)) return;

            var parameter = dp.GetValue(commandParameterProperty);

            if (!(dp.GetValue(commandProperty) is ICommand command)) return;

            if (command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }

        private static void MouseEnter(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(sender, MouseEnterCommand, MouseEnterCommandParameter);
        }

        private static void MouseLeave(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(sender, MouseLeaveCommand, MouseLeaveCommandParameter);
        }

        #region Mouse enter properties setters and getters

        public static void SetMouseEnterCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(MouseEnterCommand, value);
        }

        public static ICommand GetMouseEnterCommand(DependencyObject o)
        {
            return o.GetValue(MouseEnterCommand) as ICommand;
        }

        public static void SetMouseEnterCommandParameter(DependencyObject o, object value)
        {
            o.SetValue(MouseEnterCommandParameter, value);
        }

        public static object GetMouseEnterCommandParameter(DependencyObject o)
        {
            return o.GetValue(MouseEnterCommandParameter);
        }
        
        #endregion

        #region Mouse leave properties setters and getters

        public static void SetMouseLeaveCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(MouseLeaveCommand, value);
        }

        public static ICommand GetMouseLeaveCommand(DependencyObject o)
        {
            return o.GetValue(MouseLeaveCommand) as ICommand;
        }

        public static void SetMouseLeaveCommandParameter(DependencyObject o, object value)
        {
            o.SetValue(MouseLeaveCommandParameter, value);
        }

        public static object GetMouseLeaveCommandParameter(DependencyObject o)
        {
            return o.GetValue(MouseLeaveCommandParameter);
        }

        #endregion
    }
}
