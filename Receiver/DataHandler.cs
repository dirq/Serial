using System.IO.Ports;

namespace Receiver
{
    internal class DataHandler
    {
        public static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var port = (SerialPort)sender;
                Console.Write(port.ReadExisting());
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
