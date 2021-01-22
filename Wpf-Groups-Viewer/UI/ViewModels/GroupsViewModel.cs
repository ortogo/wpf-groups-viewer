using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

using WpfGroupsViewer.UI.Commands;
using WpfGroupsViewer.UI.Models;

namespace WpfGroupsViewer.UI.ViewModels
{
    public class GroupsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the groups list.
        /// </summary>
        public ObservableCollection<GroupModel> GroupsItems { get; set; }

        public ICommand OpenGroupDetailsCommand => new SimpleCommand<GroupModel>(OpenGroupDetailsCommandHandler);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsViewModel"/> class. 
        /// Populates the list of groups with default values.
        /// </summary>
        public GroupsViewModel()
        {
            GroupsItems = new ObservableCollection<GroupModel>()
            {
                new GroupModel { Name = "Local", Number=10 },
                new GroupModel { Name = "Global", Number=20 },
                new GroupModel { Name = "Regional", Number=30 },
                new GroupModel { Name = "International", Number=40 }
            };
        }

        #endregion

        #region Methods

        private void OpenGroupDetailsCommandHandler(GroupModel groupModel)
        {
            if (!File.Exists(groupModel.DetailsFilePath))
            {
                MessageBox.Show(string.Format((string)Application.Current.FindResource("DetailsFileDoesNotExistsTemplateString"), groupModel.DetailsFilePath));

                return;
            }

            Process.Start(groupModel.DetailsFilePath);
        }

        #endregion
    }
}
