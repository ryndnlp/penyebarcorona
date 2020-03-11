using Microsoft.Msagl.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace penyebarcorona
{
    public partial class MainWindow : Window
    {
        Simulator simulator;
        Graph graph;
        public MainWindow()
        {
            simulator = new Simulator();
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public void MainWindow_Loaded(object s, RoutedEventArgs e) {

            graph = new Graph();

            simulator.output(day, graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }

        private void NextDay(object sender, RoutedEventArgs e)
        {
            simulator.next();

            graph = new Graph();

            simulator.output(day, graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }

        private void AddDays(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < int.Parse(dayCount.Text); i++)
            {
                simulator.next();
            }

            graph = new Graph();

            simulator.output(day, graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }

        private void IsNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text) && e.Text.Length < 10;
        }
    }
}
