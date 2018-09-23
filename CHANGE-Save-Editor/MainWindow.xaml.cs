using System.Windows;

namespace CHANGE_Save_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var asd = new GameSaveManager("zd");
            asd.LoadActiveSave();
        }
    }
}
