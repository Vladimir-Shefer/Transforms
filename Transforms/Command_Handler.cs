using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforms
{
    public abstract class Command_Handler
    {
        public abstract int id { get; set; }
        abstract public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet);
        public Command_Handler(List<Data_Carrier_Base> fields) { }
       
    }

    

    public class Command_Handler_128 : Command_Handler
    {
        const All_Params j = All_Params.bru_220;
        const All_Params w = All_Params.bru_127;
        public override int id { get; set; } = 128;
        Data_Carrier_Base field_1;
        Data_Carrier_Base field_2;  
        
        public Command_Handler_128(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if(d.param==j)
                    field_1 = d;
                if (d.param == w)
                    field_2 = d;
            }
        }

        override public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            ((Data_Carrier_Int)
            field_1).value= data[1];
            ((Data_Carrier_Int)field_2).value = data[2];
            return new List<Data_Carrier_Base>{ field_1, field_2 }; 

        }
    }



    public class Command_Handler_124 : Command_Handler
    {

        const All_Params w = All_Params.sCurrentAnalogData_avg_adc_value;
        public override int id { get; set; } = 128;
        Data_Carrier_Base field_1;
      
        public Command_Handler_124(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

              
                if (d.param == w)
                    field_1 = d;
            }
        }

        override public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            for (int i = 0; i < ((Data_Carrier_Int_List)
             field_1).values.Count/2; i++)
                ((Data_Carrier_Int_List)
            field_1).values[i+4*packet.frame] = 256*data[2*i] + data[2*i+1];
          
            return new List<Data_Carrier_Base> { field_1 };

        }
    }
}
