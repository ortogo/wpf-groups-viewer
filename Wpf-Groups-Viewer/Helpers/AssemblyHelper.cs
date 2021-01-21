using System.IO;

namespace WpfGroupsViewer.Helpers
{
    public class AssemblyHelper
    {
        #region Methods

        /// <summary>
        /// Returns the path to directory that contains current application.
        /// </summary>
        /// <returns>The path to directory that contains current application.</returns>
        public static string GetAssemblyDirectoryPath()
        {
            return Path.GetDirectoryName(typeof(App).Assembly.Location);
        }

        #endregion
    }
}
