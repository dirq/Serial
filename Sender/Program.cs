using System.IO.Ports;
using Common;

Console.WriteLine("SENDER");

//Console.WriteLine("Available Ports:");
//foreach (string s in SerialPort.GetPortNames())
//{
//    Console.WriteLine("   {0}", s);
//}

//wait for the listener to start
Thread.Sleep(500);

var serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
serialPort.DataReceived += DataHandler.DataReceived;
serialPort.ErrorReceived += Common.DataHandler.ErrorReceived;
serialPort.PinChanged += Common.DataHandler.PinChanged;
//load 894 file and pass it through the receiver


try
{
    if (!serialPort.IsOpen)
        serialPort.Open();

    Console.WriteLine("I'm on " + serialPort.PortName);

    serialPort.WriteLine("did you see this?");

    Thread.Sleep(500);
    serialPort.WriteLine("how about this?");

    Thread.Sleep(500);
    serialPort.WriteLine("and this?");

    Thread.Sleep(500);
    serialPort.WriteLine("that's all I have to say.");
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