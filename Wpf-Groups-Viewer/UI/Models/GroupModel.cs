using System.IO;
using WpfGroupsViewer.Helpers;

namespace WpfGroupsViewer.UI.Models
{
    public class GroupModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets a group name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a group number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets a path to directory that contains group details file.
        /// </summary>
        public string DetailsFilePath =>
            Path.Combine(
                AssemblyHelper.GetAssemblyDirectoryPath(),
                Constants.RESOURCES_DIRECTORY_NAME,
                $"{Name}{Constants.TXT_EXTENSION}");

        #endregion
    }
}
