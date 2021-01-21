using System.Collections.ObjectModel;

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
    }
}
