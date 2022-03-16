using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transforms
{
   //Exception invalid_received_data = new Exception("Недопустимый вызов команды на прием");
    public abstract class Command_Handler
    {
        public abstract int id { get; set; }
        virtual public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            throw new Exception("Недопустимый вызов команды на прием");
        }
        public Command_Handler(List<Data_Carrier_Base> fields) { }

        virtual public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {
            throw new Exception("Недопустимый вызов команды на отправку");
        }
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

                if (d.param == j)
                    field_1 = d;
                if (d.param == w)
                    field_2 = d;
            }
        }

        override public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            ((Data_Carrier_Int)
            field_1).value = data[1];//null
            ((Data_Carrier_Int)field_2).value = data[2];
            return new List<Data_Carrier_Base> { field_1, field_2 };

        }
        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {
            return new Packet { cmd = (byte)64, CAN = 2, data = new byte[] { 0, 9, 0, 9, 0, 9 }, frame = 0, to = 10, from = 1, };
        }
    }

    public class Command_Handler_50 : Command_Handler
    {
        const All_Params j = All_Params.state;

        public override int id { get; set; } = 50;
        Data_Carrier_Base field_1 = new Data_Carrier_Bool();


        public Command_Handler_50(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (d.param == j)
                    field_1 = d;

            }
        }


        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {


            return new Packet { cmd = 50, data = { }, frame = 0 };
        }

    }
    public class Command_Handler_80 : Command_Handler
    {
        const All_Params first_param = All_Params._FLASH_ID_VERSIYA_H;
        const All_Params second_param = All_Params._FLASH_ID_VERSIYA_L;
        const All_Params third_param = All_Params._FLASH_NUMBER_BLOK;
        const All_Params fourth_param = All_Params._FLASH_DEV_TYPE;
        public override int id { get; set; } = 80;
        Data_Carrier_Base field_1 = new Data_Carrier_Int();
        Data_Carrier_Base field_2 = new Data_Carrier_Int();
        Data_Carrier_Base field_3 = new Data_Carrier_Int();
        Data_Carrier_Base field_4 = new Data_Carrier_Int();

        public Command_Handler_80(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (d.param == first_param)
                    field_1 = d;
                if (d.param == second_param)
                    field_1 = d;
                if (d.param == third_param)
                    field_1 = d;
                if (d.param == fourth_param)
                    field_1 = d;
            }
        }


        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            ((Data_Carrier_Int)field_1).value = data[0] * 256 + data[1];
            ((Data_Carrier_Int)field_2).value = data[2] * 256 + data[3];
            ((Data_Carrier_Int)field_3).value = data[4] * 256 + data[5];
            ((Data_Carrier_Int)field_4).value = data[6];
            return new List<Data_Carrier_Base> { field_1, field_2, field_3, field_4 };
        }

    }
    public class Command_Handler_60 : Command_Handler
    {
        const All_Params first_param = All_Params._FLASH_PROT_PT100_0_ENABLE;
        const All_Params second_param = All_Params._FLASH_PROT_PT100_1_ENABLE;
        const All_Params third_param = All_Params._FLASH_PROT_PT100_2_ENABLE;
        const All_Params firth_param = All_Params._FLASH_WARN_PT100_0_ENABLE;
        const All_Params fifth_param = All_Params._FLASH_WARN_PT100_1_ENABLE;
        const All_Params sixth_param = All_Params._FLASH_WARN_PT100_2_ENABLE;
        const All_Params seventh_param = All_Params._FLASH_PROT_V4_20_0_ENABLE;
        const All_Params eighth_param = All_Params._FLASH_PROT_V4_20_1_ENABLE;
        const All_Params ninth_param = All_Params._FLASH_PROT_V4_20_0_SETPOINT;
        const All_Params tenth_param = All_Params._FLASH_PROT_V4_20_1_SETPOINT;
        const All_Params eleventh_param = All_Params._FLASH_PROT_PT100_0_SETPOINT;
        const All_Params twelve_param = All_Params._FLASH_PROT_PT100_1_SETPOINT;
        const All_Params thirteenth_param = All_Params._FLASH_PROT_PT100_2_SETPOINT;
        const All_Params fourteenth_param = All_Params.time_logic;
        public override int id { get; set; } = 60;
        Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        Data_Carrier_Base field_2 = new Data_Carrier_Bool();
        Data_Carrier_Base field_3 = new Data_Carrier_Bool();
        Data_Carrier_Base field_4 = new Data_Carrier_Bool();
        Data_Carrier_Base field_5 = new Data_Carrier_Bool();
        Data_Carrier_Base field_6 = new Data_Carrier_Bool();
        Data_Carrier_Base field_7 = new Data_Carrier_Bool();
        Data_Carrier_Base field_8 = new Data_Carrier_Bool();
        Data_Carrier_Base field_9 = new Data_Carrier_Int();
        Data_Carrier_Base field_10 = new Data_Carrier_Int();
        Data_Carrier_Base field_11 = new Data_Carrier_Int();
        Data_Carrier_Base field_12 = new Data_Carrier_Int();
        Data_Carrier_Base field_13 = new Data_Carrier_Int();
        Data_Carrier_Base field_14 = new Data_Carrier_Int();
        public Command_Handler_60(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (d.param == first_param)
                    field_1 = d;
                if (d.param == second_param)
                    field_2 = d;
                if (d.param == third_param)
                    field_3 = d;
                if (d.param == firth_param)
                    field_4 = d;
                if (d.param == fifth_param)
                    field_5 = d;
                if (d.param == sixth_param)
                    field_6 = d;
                if (d.param == seventh_param)
                    field_7 = d;
                if (d.param == eighth_param)
                    field_8 = d;
                if (d.param == ninth_param)
                    field_9 = d;
                if (d.param == tenth_param)
                    field_10 = d;
                if (d.param == eleventh_param)
                    field_11 = d;
                if (d.param == twelve_param)
                    field_12 = d;
                if (d.param == thirteenth_param)
                    field_13 = d;
                if (d.param == fourteenth_param)
                    field_14 = d;
            }
        }
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            switch (packet.frame)
            {
                case 0:
                    ((Data_Carrier_Bool)field_1).value = (data[0] >> 3) % 2 == 1;
                    ((Data_Carrier_Bool)field_2).value = (data[0] >> 4) % 2 == 1;
                    ((Data_Carrier_Bool)field_3).value = (data[0] >> 5) % 2 == 1;
                    ((Data_Carrier_Bool)field_4).value = (data[0] >> 6) % 2 == 1;
                    ((Data_Carrier_Bool)field_5).value = (data[0] >> 7) % 2 == 1;
                    ((Data_Carrier_Bool)field_6).value = (data[1] >> 0) % 2 == 1;
                    ((Data_Carrier_Bool)field_7).value = (data[1] >> 1) % 2 == 1;
                    ((Data_Carrier_Bool)field_8).value = (data[1] >> 2) % 2 == 1;
                    ((Data_Carrier_Int)field_9).value = data[4] + data[5] * 256;
                    ((Data_Carrier_Int)field_10).value = data[6] + data[7] * 256;
                    

                    break;
                case 1:

                    ((Data_Carrier_Int)field_11).value = data[0] + data[1]*256;
                    ((Data_Carrier_Int)field_12).value = data[2] + data[3] * 256;
                    ((Data_Carrier_Int)field_13).value = data[4] + data[5] * 256;
                    ((Data_Carrier_Int)field_14).value = data[6] + data[7] * 256;
                    break;
            }
            return new List<Data_Carrier_Base> { field_1, field_2, field_3, field_4, field_5, field_6, field_7, field_8, field_9, field_10, field_11, field_12, field_13, field_14 };
        }



        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {


            return new Packet { cmd = (byte)id, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_51 : Command_Handler
    {
        const All_Params j = All_Params.state;

        public override int id { get; set; } = 51;
        Data_Carrier_Base field_1 = new Data_Carrier_Bool();


        public Command_Handler_51(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (d.param == j)
                    field_1 = d;

            }
        }


        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {


            return new Packet { cmd = 51, data = { }, frame = 0 };
        }

    }
    public class Command_Handler_116 : Command_Handler
    {

        const All_Params w = All_Params.sCurrentAnalogData_avg_adc_value;
        public override int id { get; set; } = 116;
        Data_Carrier_Base field_1 = new Data_Carrier_Int_List { param = w, values = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 } };

        public Command_Handler_116(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (fields.First().param == w)
                    field_1 = d;

            }



        }

        override public List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            lock (field_1)
            {
                byte[] data = packet.data;
                for (int i = 0; i < ((Data_Carrier_Int_List)
                 field_1).values.Count / 2; i++)
                    ((Data_Carrier_Int_List)
                field_1).values[i + 4 * packet.frame] = 256 * data[2 * i] + data[2 * i + 1];
            }
            return new List<Data_Carrier_Base> { field_1 };

        }
        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {
            return new Packet { cmd = (byte)id, CAN = 2, data = new byte[] { 0, 9, 0, 9, 0, 9 }, frame = 0, to = 38, from = 1, };
        }

    }


    public class Command_Handler_106 : Command_Handler
    {
        const All_Params first_param = All_Params.ADCdata_currentA;
        const All_Params second_param = All_Params.ADCdata_currentB;
        const All_Params third_param = All_Params.ADCdata_currentC;
        const All_Params fourth_param = All_Params.ADCdata_currentD;
        const All_Params fifth_param = All_Params.ADCdata_currentAVG;
        const All_Params sixth_param = All_Params.ADCdata_PT1;
        const All_Params seventh_param = All_Params.ADCdata_PT2;
        const All_Params eighth_param = All_Params.ADCdata_PT3;
        const All_Params ninth_param = All_Params.ADCdata_I4_20_1;
        const All_Params tenth_param = All_Params.ADCdata_I4_20_2;
        const All_Params eleventh_param = All_Params.ADCdata_assymetry;
        const All_Params twelve_param = All_Params.ADCdata_IA_angle;
        const All_Params thirteenth_param = All_Params.ADCdata_IB_angle;
        const All_Params fourteenth_param = All_Params.ADCdata_IC_angle;
        const All_Params fifteenth_param = All_Params.ADCdata_ID_angle;
        public override int id { get; set; } = 106;
        Data_Carrier_Base field_1 = new Data_Carrier_Int();
        Data_Carrier_Base field_2 = new Data_Carrier_Int();
        Data_Carrier_Base field_3 = new Data_Carrier_Int();
        Data_Carrier_Base field_4 = new Data_Carrier_Int();
        Data_Carrier_Base field_5 = new Data_Carrier_Int();
        Data_Carrier_Base field_6 = new Data_Carrier_Int();
        Data_Carrier_Base field_7 = new Data_Carrier_Int();
        Data_Carrier_Base field_8 = new Data_Carrier_Int();
        Data_Carrier_Base field_9 = new Data_Carrier_Int();
        Data_Carrier_Base field_10 = new Data_Carrier_Int();
        Data_Carrier_Base field_11 = new Data_Carrier_Int();
        Data_Carrier_Base field_12 = new Data_Carrier_Int();
        Data_Carrier_Base field_13 = new Data_Carrier_Int();
        Data_Carrier_Base field_14 = new Data_Carrier_Int();
         Data_Carrier_Base field_15 = new Data_Carrier_Int();
        public Command_Handler_106(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {

                if (d.param == first_param)
                    field_1 = d;
                if (d.param == second_param)
                    field_2 = d;
                if (d.param == third_param)
                    field_3 = d;
                if (d.param == fourth_param)
                    field_4 = d;
                if (d.param == fifth_param)
                    field_5 = d;
                if (d.param == sixth_param)
                    field_6 = d;
                if (d.param == seventh_param)
                    field_7 = d;
                if (d.param == eighth_param)
                    field_8 = d;
                if (d.param == ninth_param)
                    field_9 = d;
                if (d.param == tenth_param)
                    field_10 = d;
                if (d.param == eleventh_param)
                    field_11 = d;
                if (d.param == twelve_param)
                    field_12 = d;
                if (d.param == thirteenth_param)
                    field_13 = d;
                if (d.param == fourteenth_param)
                    field_14 = d;
                if (d.param == fifteenth_param)
                    field_15 = d;
            }
        }
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            

            switch (data[0]+data[1]*256)
                {
                case 0:
                    ((Data_Carrier_Int)field_1).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_1 };
                case 1:
                    ((Data_Carrier_Int)field_2).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_2 };
                case 2:
                    ((Data_Carrier_Int)field_3).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_3 };

                case 3:
                    ((Data_Carrier_Int)field_4).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_4 };
                case 4:
                    ((Data_Carrier_Int)field_5).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_5 };

                case 5:
                    ((Data_Carrier_Int)field_6).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_6 };
                case 6:
                    ((Data_Carrier_Int)field_7).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_7 };
                case 7:
                    ((Data_Carrier_Int)field_8).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_8 };
                case 8:
                    ((Data_Carrier_Int)field_9).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_9 };
                case 9:
                    ((Data_Carrier_Int)field_10).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_10 };
                case 10:
                    ((Data_Carrier_Int)field_11).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_11 };
                case 11:
                    ((Data_Carrier_Int)field_12).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_12 };
                case 12:
                    ((Data_Carrier_Int)field_13).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_13 };
                case 13:
                    ((Data_Carrier_Int)field_14).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_14 };
                case 14:
                    ((Data_Carrier_Int)field_15).value = data[2] + data[3] * 256;
                    return new List<Data_Carrier_Base> { field_15 };
                default:
                    throw new Exception("Недопустимый параметр команды на прием");
            }
            
        }



        override public Packet Handle_Outgoing_Command(List<Data_Carrier_Base> list)
        {

            All_Params param_temp = list.FindLast(c => (c.param == first_param) || (c.param == second_param) || (c.param == third_param) ||
            (c.param == fourth_param) || (c.param == fifth_param) || (c.param == sixth_param) || (c.param == seventh_param)
            || (c.param == eighth_param) || (c.param == ninth_param) || (c.param == tenth_param) || (c.param == eleventh_param) ||
            (c.param == twelve_param) || (c.param == thirteenth_param) || (c.param == fourteenth_param) || (c.param == fifteenth_param)).param;
            if(param_temp!=null)
            {

               switch (param_temp)
                {

                    case first_param:
                        return new Packet { cmd = (byte)id, data = new byte[]{0, }, frame = 0 };
                   
                    case second_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 1, }, frame = 0 };
                    case third_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 2, }, frame = 0 };
                    case fourth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 3, }, frame = 0 };
                    case fifth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 4, }, frame = 0 };
                    case sixth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 5, }, frame = 0 };
                    case seventh_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 6, }, frame = 0 };
                    case eighth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 7, }, frame = 0 };
                    case ninth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 8, }, frame = 0 };
                    case tenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 9, }, frame = 0 };
                    case eleventh_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 10, }, frame = 0 };
                    case twelve_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 11, }, frame = 0 };
                    case thirteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 12, }, frame = 0 };
                    case fourteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 13, }, frame = 0 };
                    case fifteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 14, }, frame = 0 };
                    default:
                        throw new Exception("Недопустимый параметр команды на отправку");


                }
            }
            else throw new Exception("Недопустимый параметр команды на отправку");


        }
    }

}
