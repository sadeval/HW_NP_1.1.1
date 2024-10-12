using System;
using System.Net.Sockets;
using System.Text;

namespace SqrtClientApp
{
    class Program
    {
        static void Main()
        {
            string serverAddress = "127.0.0.1";
            int port = 13000;

            try
            {
                using (TcpClient client = new TcpClient(serverAddress, port))
                {
                    Console.WriteLine("Подключено к серверу.");
                    NetworkStream stream = client.GetStream();

                    Console.Write("Введите число для вычисления квадратного корня: ");
                    string? input = Console.ReadLine();

                    byte[] data = Encoding.UTF8.GetBytes(input);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[256];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Результат от сервера: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
