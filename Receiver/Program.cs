using System.IO.Ports;

Console.WriteLine("RECEIVER");


Console.WriteLine("Available Ports:");
foreach (var s in SerialPort.GetPortNames()) Console.WriteLine("   {0}", s);

var serialPort = new SerialPort("COM2", 9600);
serialPort.DataReceived += Common.DataHandler.DataReceived;
serialPort.ErrorReceived += Common.DataHandler.ErrorReceived;
serialPort.PinChanged += Common.DataHandler.PinChanged;


//serialPort.PinChanged

//need to watch for plugging/unplugging

//test for disconnection during transfer

//how to get back a comm port when it is locked by an improper disconnect

//how to verify bitstream / packet loss
//if it's bad, throw it away and start over
//do we send a message back to the handheld?

//may need to kill processes on the host machine

//could use a file watcher to send a message to close 
//or check on MMQ

//save 894 and iterations of 895
//can we test with a file on disk?
//

//check ascii format

//check DEX version  / parameter

//need ~10 of DEX 894 and 895 files in a directory for unit tests

//convert publix certification test suite to unit tests


try
{
    if (!serialPort.IsOpen)
        serialPort.Open();

    Console.WriteLine("I'm on " + serialPort.PortName);

    Thread.Sleep(500);
    serialPort.WriteLine("Yo brosif.");


    Thread.Sleep(500);
    serialPort.Write("hello");
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