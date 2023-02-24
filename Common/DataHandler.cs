using System.IO.Ports;

namespace Common
{
    public class DataHandler
    {
        public static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var port = (SerialPort)sender;
                var data = port.ReadExisting();
                Console.WriteLine($"Data received on {port.PortName}:");
                Console.Write(data);
                Console.WriteLine();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            var port = (SerialPort)sender;
            Console.WriteLine("Pin changed on " + port.PortName);
        }

        public static void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            var port = (SerialPort)sender;
            Console.WriteLine("Error on " + port.PortName);
        }


    }
}