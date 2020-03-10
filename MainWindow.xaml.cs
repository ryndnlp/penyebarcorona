using Microsoft.Msagl.Drawing;
using System.Windows;

namespace penyebarcorona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

            simulator.output(graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }

        private void NextDay(object sender, RoutedEventArgs e)
        {
            simulator.next();

            graph = new Graph();

            simulator.output(graph);

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

            simulator.output(graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }
    }
}
