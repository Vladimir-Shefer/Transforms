namespace Transforms
{
    internal class Device_Command_Logic
    {
        private List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>();
    }

    internal enum Devices
    {
        ddd,
        fff,
        fdsf,
    }

    internal enum Commmands
    {
        get_ggg = 109
    }

    public class Device_Command
    {
        public int id;
        public string name;

        public int number_of_frames = 1;

        public Device_Command(List<Data_Carrier_Base> data_fields)
        {
        }

        public void Input(Packet packet)
        {
        }

        public Packet Output()
        {
            return new Packet();
        }
    }
}