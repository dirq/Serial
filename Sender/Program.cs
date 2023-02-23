using Sender;
using System.IO.Ports;

Console.WriteLine("SENDER");

//Console.WriteLine("Available Ports:");
//foreach (string s in SerialPort.GetPortNames())
//{
//    Console.WriteLine("   {0}", s);
//}

//wait for the listener to start
Thread.Sleep(500);

var serialPort = new SerialPort("COM1", 9600);
serialPort.DataReceived += DataHandler.DataReceived;

//load 894 file and pass it through the reciever



try
{
    if (!serialPort.IsOpen)
        serialPort.Open();

    Console.WriteLine("I'm sending a message!");

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