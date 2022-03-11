namespace Transforms
{
    public abstract class Data_Carrier_Base
    {
        public All_Params param;
       // public abstract string ToString();
    }

    public class Data_Carrier_Int : Data_Carrier_Base
    {
        public int value;
    }

    public class Data_Carrier_Int_List : Data_Carrier_Base
    {
        public List<int> values;
    }

    public enum All_Params
    {
        unknown,
        command_number,
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
}