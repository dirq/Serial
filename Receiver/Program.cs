using Receiver;
using System.IO.Ports;

Console.WriteLine("RECEIVER");


Console.WriteLine("Available Ports:");
foreach (string s in SerialPort.GetPortNames())
{
    Console.WriteLine("   {0}", s);
}

var serialPort = new SerialPort("COM2", 9600);
serialPort.DataReceived += DataHandler.DataReceived;


try
{
    if (!serialPort.IsOpen)
        serialPort.Open();

}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine("Error: Port {0} is in use", serialPort.PortName);
}
catch (IOException ex)
{
    Console.WriteLine(ex);
}


Console.ReadLine();