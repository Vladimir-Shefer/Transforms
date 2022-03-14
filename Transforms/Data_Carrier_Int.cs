namespace Transforms
{
    public abstract class Data_Carrier_Base
    {
        public All_Params param;
    }

    public class Data_Carrier_Int : Data_Carrier_Base
    {
        public int value;
    }

    public class Data_Carrier_Int_List : Data_Carrier_Base
    {
        public List<int> values = new List<int>();
    }

    public enum All_Params
    {
        unknown,
        sCurrentAnalogData_avg_adc_value,
        bru_127,
        bru_220,
    }

    public enum Reseiver
    {
        mediator,
        UI,
        model,
        connection
    }
    public class Data_Carrier_Modbus : Data_Carrier_Base
    {
        public int start_value;
    }

    public class Data_Carrier_Modbus_Analog : Data_Carrier_Modbus
    {
        public List<int> values = new List<int>();
    }
    public class Data_Carrier_Modbus_Discret : Data_Carrier_Modbus
    {
        public List<bool> values = new List<bool>();
    }
}