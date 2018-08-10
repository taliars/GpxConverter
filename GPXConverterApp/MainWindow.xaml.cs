
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GPXConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Waypoint> Waypoints { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Waypoints = new ObservableCollection<Waypoint>();
            dataGrid.ItemsSource = Waypoints;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); 
            dialog.Filters.Add(new CommonFileDialogFilter("gpx файлы", "*.gpx"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                foreach (Waypoint waypoint in GPXLoader.Load(dialog.FileName))
                    Waypoints.Add(waypoint);
        }
    }
}
