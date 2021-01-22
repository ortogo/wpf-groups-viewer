using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace WpfGroupsViewer.UI.Behaviours
{
    public class ExpanderDoubleClickBehaviour : Behavior<ListBox>
    {
        #region Methods

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewMouseDoubleClick += MouseDoubleClickHandler;
        }

        private void MouseDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;

            if (!(e.OriginalSource is DependencyObject originalSouce))
                return;

            var expander = originalSouce is ListBoxItem expanderSource ? expanderSource : FindParent(originalSouce);

            AssociatedObject.InputBindings.OfType<MouseBinding>()
                .Where(b => b.MouseAction == MouseAction.LeftDoubleClick && b.Command != null && b.Command.CanExecute(expander?.DataContext))
                .ToList()
                .ForEach(b => b.Command.Execute(expander?.DataContext));
        }

        private ListBoxItem FindParent(DependencyObject dependencyObject)
        {
            var parentObject = VisualTreeHelper.GetParent(dependencyObject);

            if (parentObject == null)
                return null;

            if (parentObject is ListBoxItem)
                return (ListBoxItem)parentObject;
            else
                return FindParent(parentObject);
        }

        #endregion
    }
}
