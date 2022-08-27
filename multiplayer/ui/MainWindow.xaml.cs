using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace multiplayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpListener myList;
        Socket s;
        string field;
        public MainWindow()
        {
            InitializeComponent();
        }        
        public void start()
        {
            IPAddress ipAd = IPAddress.Parse(ipXAML.Text);
            int port = Convert.ToInt32(portXAML.Text);
            myList = new TcpListener(ipAd, port);
            myList.Start();
        }
        public void receive()
        {
            s = myList.AcceptSocket();
            byte[] b = new byte[100];
            int k = s.Receive(b);
            for (int i = 0; i < k; i++)
                field += Convert.ToChar(b[i]);
            s.Close();            
        }
        public void disconnect()
        {
            myList.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            disconnect();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void SinglePlayerButton_click(object sender, RoutedEventArgs e)
        {

        }
        private void MultiPlayerButton_click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Collapsed;
            MultiSeverSetup.Visibility = Visibility.Collapsed;
            Choose.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Visible;
            MultiSeverSetup.Visibility = Visibility.Collapsed;
            Choose.Visibility = Visibility.Collapsed;
        }
    }
}
