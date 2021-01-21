using System.Windows;

using WpfGroupsViewer.UI.ViewModels;

namespace WpfGroupsViewer.UI.Views
{
    /// <summary>
    /// Interaction logic for GroupsView.xaml
    /// </summary>
    public partial class GroupsView : Window
    {
        public GroupsView()
        {
            InitializeComponent();
            DataContext = new GroupsViewModel();
        }
    }
}
