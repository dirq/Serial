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
                Console.Write("From " + port.PortName + ": " + port.ReadExisting());
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