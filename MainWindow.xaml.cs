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
        public MainWindow()
        {
            simulator = new Simulator();
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public void MainWindow_Loaded(object s, RoutedEventArgs e) {

            Graph graph = new Graph();

            simulator.output(graph);

            graph.Attr.LayerDirection = LayerDirection.LR;

            graphViewer.Graph = graph;
        }
    }
}
