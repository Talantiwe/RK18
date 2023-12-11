using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ChatClient
{
    public partial class MainWindow : Window
    {
        private TcpClient tcpClient;
        private Thread clientThread;

        public MainWindow()
        {
            InitializeComponent();
            StartClient();
        }

        private void StartClient()
        {
            // Вставьте строки для установки IP-адреса и порта
            tcpClient = new TcpClient();
            tcpClient.Connect("192.168.0.11", 1111);

            clientThread = new Thread(new ThreadStart(ListenForMessages));
            clientThread.Start();
        }

        private void ListenForMessages()
        {
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

                string serverMessage = Encoding.UTF8.GetString(message, 0, bytesRead);
                DisplayMessage(serverMessage);
            }
        }

        private void DisplayMessage(string message)
        {
            chatTextBox.Dispatcher.Invoke(() =>
            {
                // Отображение сообщения в вашем элементе управления WPF
                chatTextBox.Text += message + Environment.NewLine;
            });
        }

        private void SendMessage(string message)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            clientStream.Write(messageBytes, 0, messageBytes.Length);
            clientStream.Flush();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = $"{userNameTextBox.Text}: {messageTextBox.Text}";
            SendMessage(message);
            messageTextBox.Text = string.Empty;
        }
    }
}
