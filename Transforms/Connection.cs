using Modbus.Device;
using System.Diagnostics;
using System.IO.Ports;

namespace Transforms
{
    internal class Connection : Base_Component
    {
        private const byte data_length = 16;

        private byte[] buffer = new byte[data_length*1000];
        private int buffer_position = 0;
        private List<byte[]> data_to_send_list = new List<byte[]>();
        private AutoResetEvent Ev_reading = new AutoResetEvent(false);
        private AutoResetEvent Ev_writing = new AutoResetEvent(false);
        private Thread reading_thread;
        private volatile bool reading_thread_working = true;
        private SerialPort serialPort;
        private Thread writing_thread;
        private volatile bool writing_thread_working = true;
        Data_Parser parser;
        ModbusSerialMaster master;
        public Connection()
        {
            //  master = ModbusSerialMaster.CreateRtu(serialPort);
            
            for (int i=0; i<buffer.Length; i++)
            {

                buffer[i] = 0;
            }
            serialPort = new SerialPort();
            serialPort.DataReceived += (a, e) => { Ev_reading.Set(); };

            reading_thread = new Thread(Reading_Data_Experimental);
            reading_thread.IsBackground = true;

            writing_thread = new Thread(Writing_Data);
            writing_thread.IsBackground = true;

            reading_thread.Start();
            writing_thread.Start();
        }

        public void Close_Connection()
        {
            writing_thread_working = false;
            reading_thread_working = false;

        }

        public void Close_Serial_Port()
        {
            try
            {
                serialPort.Close();
            }
            catch
            {
            }
        }

        public void Fixate_Serial_Port(string PortName, int speed)
        {
            try
            {
                writing_thread_working = false;
                reading_thread_working = false;

                lock (serialPort)
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();

                        serialPort.PortName = PortName;
                        serialPort.BaudRate = speed;
                        serialPort.Open();
                    }
                    else
                    {
                        serialPort.PortName = PortName;
                        serialPort.BaudRate = speed;
                    }
                }
                writing_thread_working = true;
                reading_thread_working = true;

                reading_thread.Start();
                writing_thread.Start();
            }
            catch
            {
            }
        }

        public void Open_Serial_Port()
        {
            bool g = false;
            string[] s = SerialPort.GetPortNames();
            foreach (var v in s)
            {
                if (v == serialPort.PortName)
                {
                    g = true;
                    break;
                }
            }
            if (serialPort.PortName != null && g)
            {
                serialPort.Open();

                serialPort.Write(new byte[] { 0x14, 0x14, 0x14, 0x14, 0x14 }, 0, 5);
            }
        }

        public void Pass_Data_to_Connection(byte[] data_to_connection)
        {
            lock (data_to_send_list)
            {
                data_to_send_list.Add(data_to_connection);
            }
            Ev_writing.Set();

        }

        public void Pass_Data_to_Connection(Packet packet)
        {
            lock (data_to_send_list)
            {
                data_to_send_list.Add(parser.Parse_from_packet_to_bytes(packet));
            }
            Ev_writing.Set();

        }

        public void Reading_Data_Modbus()
        {
            byte slaveID = 1;
            ushort startAddress = 0;
            ushort numOfPoints = 1;

            ushort[] holding_register = master.ReadHoldingRegisters(slaveID, startAddress,
            numOfPoints);


        }
        public void Reading_Data_Experimental()
        {
            
            while (reading_thread_working)
            {
               
                Ev_reading.WaitOne();
                while (serialPort.IsOpen && serialPort.BytesToRead >= 0)
                {
                    if(serialPort.BytesToRead>= buffer.Length)
                    {

                        serialPort.ReadExisting();
                        break;
                    }
                    if (buffer_position + serialPort.BytesToRead > buffer.Length)
                    {
                        
                        for (int g = 0; g < buffer_position; g++)
                            buffer[g] = 0;
                        buffer_position = 0;
                    }
                    int tempI = 0;
            byte[] data = new byte[data_length];
            byte[] temp = new byte[data_length];
                    tempI = serialPort.BytesToRead;
                    serialPort.Read(buffer, buffer_position, tempI);
                    buffer_position += tempI;
                    

                    while (Conformity(ref buffer, data_length, ref temp))
                    {

                        Packet ggg = parser.Parse_from_bytes_to_Packet(temp);
                        if(ggg.cmd == 106 && ggg.data[0]==14)
                        { }    
                        _mediator.Notify(this, Reseiver.model,ggg);
                        buffer_position -= data_length;
                    }

                    for (int g = 0; g < temp.Length; g++)
                        temp[g] = 0;
                }
            }
        }

        public void Set_Parser(Data_Parser dp)
        {
            parser = dp;
        }
        public bool Conformity(ref byte[] data, int data_length, ref byte[] temp)
        {
            int tempLe = data.Length;
            //byte[] temp = new byte[data_length];
            List<byte> tempL = new List<byte>();
            lock(data)
            for (int i = 0; i < data.Length; i++)
            {


                if (data[i] == 15 && data[i + data_length - 1] == 10)
                {

                    for (int g = i; g < i + data_length; g++)
                    {

                        temp[g - i] = data[g];

                    }

                    tempL = data.ToList();
                    tempL.RemoveRange(i, data_length);
                        for(int h = 0; h<data.Length; h++)
                        {

                            data[h] = 0;
                        }
                       for(int h = 0; h<tempL.Count; h++)
                        {

                            data[h] = tempL[h];
                        }


                    return true;

                }
            }
            return false;
        }
      
/*public void Reading_Data()
        {
            try
            {
                byte[] data = new byte[data_length];

                while (reading_thread_working)
                {
                    Ev_reading.WaitOne();
                    while (serialPort.IsOpen && serialPort.BytesToRead >= data_length)
                    {

                        serialPort.Read(buffer, buffer_position, data_length);

                        if (buffer[buffer_position] == (byte)15 && buffer[buffer_position + data_length - 1] == (byte)10)

                        {
                            for (int i = buffer_position; i < buffer_position + data_length; i++)
                            {
                                data[i - buffer_position] = buffer[i];
                            }

                            _mediator.Notify(this, Reseiver.model, data);
                        }

                        buffer_position += data_length;
                        if (buffer_position > 3 * data_length)
                        {
                            for (int i = 0; i < buffer.Length; i++)
                            {
                                buffer[i] = 0;
                            }
                            buffer_position = 0;
                        }

                    }
                }
            }
            catch
            {
            }
        }
*/
        public bool Serial_Port_Is_Opened()
        {
            return serialPort.IsOpen;
        }

        public void Writing_Data()
        {
            while (writing_thread_working && Ev_writing.WaitOne())
            {
                if (serialPort != null && serialPort.IsOpen)
                    lock (data_to_send_list)
                    {
                        for (int i = data_to_send_list.Count - 1; i >= 0; i--)
                        {
                            serialPort.Write(data_to_send_list[i], 0, data_to_send_list[i].Length);
                            data_to_send_list.RemoveAt(i);
                        }

                    }
            }
        }
    }
}