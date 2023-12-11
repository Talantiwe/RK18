using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpListener tcpListener;
        private List<TcpClient> clients = new List<TcpClient>();
        private readonly object clientsLock = new object();
        private Thread listenerThread;

        public MainWindow()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            // Вставьте строку для установки IP-адреса и порта
            tcpListener = new TcpListener(IPAddress.Any, 1111);
            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
            Console.WriteLine("Server started");
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                lock (clientsLock)
                {
                    clients.Add(client);
                }

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                    break;

                string clientMessage = Encoding.UTF8.GetString(message, 0, bytesRead);
                BroadcastMessage(clientMessage);
            }

            lock (clientsLock)
            {
                clients.Remove(tcpClient);
            }

            tcpClient.Close();
        }

        private void BroadcastMessage(string message)
        {
            byte[] broadcastBytes = Encoding.UTF8.GetBytes(message);

            lock (clientsLock)
            {
                foreach (TcpClient client in clients)
                {
                    NetworkStream clientStream = client.GetStream();
                    clientStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    clientStream.Flush();
                }
            }
        }
    }
}
