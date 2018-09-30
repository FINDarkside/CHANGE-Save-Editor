using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CHANGE_Save_Editor.Views.Tabs
{

    public partial class AboutTab : UserControl
    {
        public AboutTab()
        {
            InitializeComponent();
        }

        private void ViewOnGitHubClicked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/FINDarkside/CHANGE-Save-Editor");
        }
    }
}
