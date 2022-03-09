namespace Transforms
{
    public abstract class Data_Currier_Base
    {
        public All_Params param;
    }

    public class Data_Carrier_Int : Data_Currier_Base
    {
        public int value;
    }

    public class Data_Carrier_Int_List : Data_Currier_Base
    {
        public List<int> values;
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
}