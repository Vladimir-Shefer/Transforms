namespace Transforms
{
    //const Exception invalid_received_data = new Exception("Недопустимый вызов команды на прием");
    public abstract class Command_Handler
    {
        public Command_Handler(List<Data_Carrier_Base> fields)
        { }

        public abstract int id { get; set; }

        public virtual List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            throw new Exception("Недопустимый вызов команды на прием");
        }
        public virtual Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            throw new Exception("Недопустимый вызов команды на отправку");
        }
    }

    public class Command_Handler_102 : Command_Handler
    {
        private List<All_Params> all_Params = new List<All_Params>() {All_Params._FLASH_ID_VERSIYA_H,      // uint16_t id_versiya_h            // Версия ПО
  All_Params._FLASH_ID_VERSIYA_L,      // uint16_t id_versiya_l            // Версия ПО
  All_Params._FLASH_NUMBER_BLOK,        // uint16_t number_blok            // Номер блока
  All_Params._FLASH_DEV_TYPE,         //uint16_t device_config.device_type;      //тип блока //device_type_t device_type;   //тип блока
  All_Params._FLASH_PROT_PT100_0_ENABLE,
  All_Params._FLASH_PROT_PT100_1_ENABLE,
  All_Params._FLASH_PROT_PT100_2_ENABLE,
  All_Params._FLASH_WARN_PT100_0_ENABLE,
  All_Params._FLASH_WARN_PT100_1_ENABLE,
  All_Params._FLASH_WARN_PT100_2_ENABLE,
  All_Params._FLASH_PROT_V4_20_0_ENABLE,
  All_Params._FLASH_PROT_V4_20_1_ENABLE,
  All_Params._FLASH_WARN_V4_20_0_ENABLE,
  All_Params._FLASH_WARN_V4_20_1_ENABLE,
  All_Params._FLASH_PROT_WRONG_CON_ENABLE,
  All_Params._FLASH_MIN_CURRENT,
  All_Params._FLASH_PROT_PT100_0_SETPOINT,
  All_Params._FLASH_PROT_PT100_1_SETPOINT,
  All_Params._FLASH_PROT_PT100_2_SETPOINT,
  All_Params._FLASH_WARN_PT100_0_SETPOINT,
  All_Params._FLASH_WARN_PT100_1_SETPOINT,
  All_Params._FLASH_WARN_PT100_2_SETPOINT,
  All_Params._FLASH_PROT_V4_20_0_SETPOINT,
  All_Params._FLASH_PROT_V4_20_1_SETPOINT,
  All_Params._FLASH_WARN_V4_20_0_SETPOINT,
  All_Params._FLASH_WARN_V4_20_1_SETPOINT,
  All_Params._FLASH_RS485_ADDRESS,
  All_Params._FLASH_RS485_SPEED,
  All_Params._FLASH_RATIOS_MUL0,
  All_Params._FLASH_RATIOS_MUL1,
  All_Params._FLASH_RATIOS_MUL2,
  All_Params._FLASH_RATIOS_MUL3,
  All_Params._FLASH_RATIOS_MUL4,
  All_Params._FLASH_RATIOS_MUL5,
  All_Params._FLASH_RATIOS_MUL6,
  All_Params._FLASH_RATIOS_MUL7,
  All_Params._FLASH_RATIOS_MUL8,
  All_Params._FLASH_RATIOS_GND0,
  All_Params._FLASH_RATIOS_GND1,
  All_Params._FLASH_RATIOS_GND2,
  All_Params._FLASH_RATIOS_GND3,
  All_Params._FLASH_RATIOS_GND4,
  All_Params._FLASH_RATIOS_GND5,
  All_Params._FLASH_RATIOS_GND6,
  All_Params._FLASH_RATIOS_GND7,
  All_Params._FLASH_RATIOS_GND8,
  All_Params._FLASH_CURRENT_MUL,
  All_Params._FLASH_CT_MUL,
  All_Params._FLASH_RATIOS_SHIFT_PT1,
  All_Params._FLASH_RATIOS_SHIFT_PT2,
  All_Params._FLASH_RATIOS_SHIFT_PT3,
  All_Params._FLASH_WRONG_CON_MAX_CURRENT,
  All_Params._FLASH_WRONG_CON_SW_CURRENT,
  All_Params._FLASH_ASSYMETRY_ENABLE,
  All_Params._FLASH_ASSYMETRY_SETPOINT,
  All_Params._FLASH_ASSYMETRY_TIME,};

        private List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>();
        public Command_Handler_102(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var p in all_Params)
            {
                //  fields.Add(new Data_Carrier_Bool { param = p, value = false });
                if (fields.Exists(c => c.param == p))
                    this.fields.Add(fields.FindLast(c => c.param == p));
                else throw new Exception("Ошибка при привязке параметров - не хвататет параметров устройства");
            }
        }

        public override int id { get; set; } = 102;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            int int_param = packet.data[0] + packet.data[1] * 256;
            if (fields.Count >= int_param)
            {
                if(fields[int_param].GetType() == typeof(Data_Carrier_Int))
                ((Data_Carrier_Int)fields[int_param]).value = packet.data[2] + packet.data[3] * 256;
                else if (fields[int_param].GetType() == typeof(Data_Carrier_Bool))
                    ((Data_Carrier_Bool)fields[int_param]).value = packet.data[2]!=0;
                return new List<Data_Carrier_Base>() { fields[int_param] };
            }
            else throw new Exception("Неверно распознан пакет ");
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            int h = 0;
            foreach (var p in all_Params)
            {
                if (list.Exists(c => c.param == p))

                {
                    h = all_Params.IndexOf(p);

                    return new Packet { cmd = (byte)id, data = new byte[] { (byte)(h % 256), (byte)(h / 256) }, frame = 0 };
                }
            }
            throw new Exception("Невозможно отправить такой запрос ");
        }
    }

    public class Command_Handler_103 : Command_Handler
    {
        private List<All_Params> all_Params = new List<All_Params>() {All_Params._FLASH_ID_VERSIYA_H,      // uint16_t id_versiya_h            // Версия ПО
  All_Params._FLASH_ID_VERSIYA_L,      // uint16_t id_versiya_l            // Версия ПО
  All_Params._FLASH_NUMBER_BLOK,        // uint16_t number_blok            // Номер блока
  All_Params._FLASH_DEV_TYPE,         //uint16_t device_config.device_type;      //тип блока //device_type_t device_type;   //тип блока
  All_Params._FLASH_PROT_PT100_0_ENABLE,
  All_Params._FLASH_PROT_PT100_1_ENABLE,
  All_Params._FLASH_PROT_PT100_2_ENABLE,
  All_Params._FLASH_WARN_PT100_0_ENABLE,
  All_Params._FLASH_WARN_PT100_1_ENABLE,
  All_Params._FLASH_WARN_PT100_2_ENABLE,
  All_Params._FLASH_PROT_V4_20_0_ENABLE,
  All_Params._FLASH_PROT_V4_20_1_ENABLE,
  All_Params._FLASH_WARN_V4_20_0_ENABLE,
  All_Params._FLASH_WARN_V4_20_1_ENABLE,
  All_Params._FLASH_PROT_WRONG_CON_ENABLE,
  All_Params._FLASH_MIN_CURRENT,
  All_Params._FLASH_PROT_PT100_0_SETPOINT,
  All_Params._FLASH_PROT_PT100_1_SETPOINT,
  All_Params._FLASH_PROT_PT100_2_SETPOINT,
  All_Params._FLASH_WARN_PT100_0_SETPOINT,
  All_Params._FLASH_WARN_PT100_1_SETPOINT,
  All_Params._FLASH_WARN_PT100_2_SETPOINT,
  All_Params._FLASH_PROT_V4_20_0_SETPOINT,
  All_Params._FLASH_PROT_V4_20_1_SETPOINT,
  All_Params._FLASH_WARN_V4_20_0_SETPOINT,
  All_Params._FLASH_WARN_V4_20_1_SETPOINT,
  All_Params._FLASH_RS485_ADDRESS,
  All_Params._FLASH_RS485_SPEED,
  All_Params._FLASH_RATIOS_MUL0,
  All_Params._FLASH_RATIOS_MUL1,
  All_Params._FLASH_RATIOS_MUL2,
  All_Params._FLASH_RATIOS_MUL3,
  All_Params._FLASH_RATIOS_MUL4,
  All_Params._FLASH_RATIOS_MUL5,
  All_Params._FLASH_RATIOS_MUL6,
  All_Params._FLASH_RATIOS_MUL7,
  All_Params._FLASH_RATIOS_MUL8,
  All_Params._FLASH_RATIOS_GND0,
  All_Params._FLASH_RATIOS_GND1,
  All_Params._FLASH_RATIOS_GND2,
  All_Params._FLASH_RATIOS_GND3,
  All_Params._FLASH_RATIOS_GND4,
  All_Params._FLASH_RATIOS_GND5,
  All_Params._FLASH_RATIOS_GND6,
  All_Params._FLASH_RATIOS_GND7,
  All_Params._FLASH_RATIOS_GND8,
  All_Params._FLASH_CURRENT_MUL,
  All_Params._FLASH_CT_MUL,
  All_Params._FLASH_RATIOS_SHIFT_PT1,
  All_Params._FLASH_RATIOS_SHIFT_PT2,
  All_Params._FLASH_RATIOS_SHIFT_PT3,
  All_Params._FLASH_WRONG_CON_MAX_CURRENT,
  All_Params._FLASH_WRONG_CON_SW_CURRENT,
  All_Params._FLASH_ASSYMETRY_ENABLE,
  All_Params._FLASH_ASSYMETRY_SETPOINT,
  All_Params._FLASH_ASSYMETRY_TIME,};
        private List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>();
        public Command_Handler_103(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var p in all_Params)
            {
                if (fields.Exists(c => c.param == p))
                    this.fields.Add(fields.FindLast(c => c.param == p));
                else throw new Exception("Ошибка при привязке параметров - не хвататет параметров устройства");
            }
        }

        public override int id { get; set; } = 103;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            int int_param = packet.data[0] + packet.data[1] * 256;
            if (fields.Count >= int_param)
            {
                if (fields[int_param].GetType() == typeof(Data_Carrier_Int))
                    ((Data_Carrier_Int)fields[int_param]).value = packet.data[2] + packet.data[3] * 256;
                else if (fields[int_param].GetType() == typeof(Data_Carrier_Bool))
                    ((Data_Carrier_Bool)fields[int_param]).value = packet.data[2] != 0;
                return new List<Data_Carrier_Base>() { fields[int_param] };
            }
            else throw new Exception("Неверно распознан пакет ");
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            int h = 0;
            int i = 0;
            foreach (var p in all_Params)
            {
                if (list.Exists(c => c.param == p))

                {
                    h = all_Params.IndexOf(p);
                    if(fields[h].GetType() == typeof(Data_Carrier_Int))
                        {
                        int b = ((Data_Carrier_Int)(list.FindLast(c=>c.param==p))).value;
                        if (b / 256 < 256 && b >= 0)
                            return new Packet { cmd = (byte)id, data = new byte[] { (byte)(h % 256), (byte)(h / 256), (byte)(b % 256), (byte)(b / 256) }, frame = 0 };
                        else break;
                    }
                    else if(fields[h].GetType() == typeof(Data_Carrier_Bool))
                    {
                        bool bo = ((Data_Carrier_Bool)(list.FindLast(c => c.param == p))).value;
                       
                            return new Packet { cmd = (byte)id, data = new byte[] { (byte)(h % 256), (byte)(h / 256), (byte)(bo?1:0), 0 }, frame = 0 };
                      


                    }
                }
               
            }
            throw new Exception("Невозможно отправить такой запрос ");
        }
    }

    public class Command_Handler_106 : Command_Handler
    {
        private const All_Params eighth_param = All_Params.ADCdata_PT3;
        private const All_Params eleventh_param = All_Params.ADCdata_assymetry;
        private const All_Params fifteenth_param = All_Params.ADCdata_ID_angle;
        private const All_Params fifth_param = All_Params.ADCdata_currentAVG;
        private const All_Params first_param = All_Params.ADCdata_currentA;
        private const All_Params fourteenth_param = All_Params.ADCdata_IC_angle;
        private const All_Params fourth_param = All_Params.ADCdata_currentD;
        private const All_Params ninth_param = All_Params.ADCdata_I4_20_1;
        private const All_Params second_param = All_Params.ADCdata_currentB;
        private const All_Params seventh_param = All_Params.ADCdata_PT2;
        private const All_Params sixth_param = All_Params.ADCdata_PT1;
        private const All_Params tenth_param = All_Params.ADCdata_I4_20_2;
        private const All_Params third_param = All_Params.ADCdata_currentC;
        private const All_Params thirteenth_param = All_Params.ADCdata_IB_angle;
        private const All_Params twelve_param = All_Params.ADCdata_IA_angle;
        private Data_Carrier_Base field_1 = new Data_Carrier_Int();
        private Data_Carrier_Base field_10 = new Data_Carrier_Int();
        private Data_Carrier_Base field_11 = new Data_Carrier_Int();
        private Data_Carrier_Base field_12 = new Data_Carrier_Int();
        private Data_Carrier_Base field_13 = new Data_Carrier_Int();
        private Data_Carrier_Base field_14 = new Data_Carrier_Int();
        private Data_Carrier_Base field_15 = new Data_Carrier_Int();
        private Data_Carrier_Base field_2 = new Data_Carrier_Int();
        private Data_Carrier_Base field_3 = new Data_Carrier_Int();
        private Data_Carrier_Base field_4 = new Data_Carrier_Int();
        private Data_Carrier_Base field_5 = new Data_Carrier_Int();
        private Data_Carrier_Base field_6 = new Data_Carrier_Int();
        private Data_Carrier_Base field_7 = new Data_Carrier_Int();
        private Data_Carrier_Base field_8 = new Data_Carrier_Int();
        private Data_Carrier_Base field_9 = new Data_Carrier_Int();
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

        public override int id { get; set; } = 106;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;

            switch (data[0] + data[1] * 256)
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

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            All_Params param_temp = list.FindLast(c => (c.param == first_param) || (c.param == second_param) || (c.param == third_param) ||
            (c.param == fourth_param) || (c.param == fifth_param) || (c.param == sixth_param) || (c.param == seventh_param)
            || (c.param == eighth_param) || (c.param == ninth_param) || (c.param == tenth_param) || (c.param == eleventh_param) ||
            (c.param == twelve_param) || (c.param == thirteenth_param) || (c.param == fourteenth_param) || (c.param == fifteenth_param)).param;
            if (param_temp != null)
            {
                switch (param_temp)
                {
                    case first_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 0,0 }, frame = 0 };

                    case second_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 1, 0}, frame = 0 };

                    case third_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 2,0 }, frame = 0 };

                    case fourth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 3,0 }, frame = 0 };

                    case fifth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 4,0 }, frame = 0 };

                    case sixth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 5,0 }, frame = 0 };

                    case seventh_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 6,0 }, frame = 0 };

                    case eighth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 7, 0}, frame = 0 };

                    case ninth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 8,0 }, frame = 0 };

                    case tenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 9,0 }, frame = 0 };

                    case eleventh_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 10,0 }, frame = 0 };

                    case twelve_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 11, 0}, frame = 0 };

                    case thirteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 12,0 }, frame = 0 };

                    case fourteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 13,0 }, frame = 0 };

                    case fifteenth_param:
                        return new Packet { cmd = (byte)id, data = new byte[] { 14, 0}, frame = 0 };

                    default:
                        throw new Exception("Недопустимый параметр команды на отправку");
                }
            }
            else throw new Exception("Недопустимый параметр команды на отправку");
        }
    }

    public class Command_Handler_116 : Command_Handler
    {
        private const All_Params w = All_Params.sCurrentAnalogData_avg_adc_value;
        private Data_Carrier_Base field_1 = new Data_Carrier_Int_List { param = w, values = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 } };
        public Command_Handler_116(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {
                if (fields.First().param == w)
                    field_1 = d;
            }
        }

        public override int id { get; set; } = 116;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
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

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)id, CAN = 2, data = new byte[] { 0, 9, 0, 9, 0, 9 }, frame = 0, to = 38, from = 1, };
        }
    }

    public class Command_Handler_128 : Command_Handler
    {
        private const All_Params j = All_Params.bru_220;
        private const All_Params w = All_Params.bru_127;
        private Data_Carrier_Base field_1;
        private Data_Carrier_Base field_2;
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

        public override int id { get; set; } = 128;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            ((Data_Carrier_Int)
            field_1).value = data[1];//null
            ((Data_Carrier_Int)field_2).value = data[2];
            return new List<Data_Carrier_Base> { field_1, field_2 };
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)64, CAN = 2, data = new byte[] { 0, 9, 0, 9, 0, 9 }, frame = 0, to = 10, from = 1, };
        }
    }

    public class Command_Handler_50 : Command_Handler
    {
        private const All_Params j = All_Params.state;

        private Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        public Command_Handler_50(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {
                if (d.param == j)
                    field_1 = d;
            }
        }

        public override int id { get; set; } = 50;
        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = 50, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_51 : Command_Handler
    {
        private const All_Params j = All_Params.state;

        private Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        public Command_Handler_51(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {
                if (d.param == j)
                    field_1 = d;
            }
        }

        public override int id { get; set; } = 51;
        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = 51, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_58 : Command_Handler
    {
        private const All_Params first_param = All_Params._LOCK_PT100_0;
        private const All_Params second_param = All_Params._LOCK_PT100_1;
        private const All_Params third_param = All_Params._LOCK_PT100_2;

        private Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_2 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_3 = new Data_Carrier_Bool();
        public Command_Handler_58(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {
                if (d.param == first_param)
                    field_1 = d;
                if (d.param == second_param)
                    field_2 = d;
                if (d.param == third_param)
                    field_3 = d;
            }
        }

        public override int id { get; set; } = 58;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;

            ((Data_Carrier_Bool)field_1).value = (data[0] >> 5) % 2 == 1;
            ((Data_Carrier_Bool)field_2).value = (data[0] >> 6) % 2 == 1;
            ((Data_Carrier_Bool)field_3).value = (data[0] >> 7) % 2 == 1;

            return new List<Data_Carrier_Base> { field_1, field_2, field_3 };
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)id, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_59 : Command_Handler
    {

        private const All_Params eigth_param = All_Params._WARN_PT100_ERROR_2;
        private const All_Params fifth_param = All_Params._WARN_V4_20_1;
        private const All_Params first_param = All_Params._WARN_PT100_0;
        private const All_Params fourth_param = All_Params._WARN_V4_20_0;
        private const All_Params second_param = All_Params._WARN_PT100_1;
        private const All_Params seventh_param = All_Params._WARN_PT100_ERROR_1;
        private const All_Params sixth_param = All_Params._WARN_PT100_ERROR_0;
        private const All_Params third_param = All_Params._WARN_PT100_2;
        private Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_2 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_3 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_4 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_5 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_6 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_7 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_8 = new Data_Carrier_Bool();
        public Command_Handler_59(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var d in fields)
            {
                if (d.param == first_param)
                    field_1 = d;
                else if (d.param == second_param)
                    field_2 = d;
                else if (d.param == third_param)
                    field_3 = d;
                else if (d.param == fourth_param)
                    field_4 = d;
                else if (d.param == fifth_param)
                    field_5 = d;
                else if (d.param == sixth_param)
                    field_6 = d;
                else if (d.param == seventh_param)
                    field_7 = d;
                else if (d.param == eigth_param)
                    field_8 = d;
            }
        }

        public override int id { get; set; } = 59;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;

            ((Data_Carrier_Bool)field_1).value = (data[0] >> 0) % 2 == 1;
            ((Data_Carrier_Bool)field_2).value = (data[0] >> 1) % 2 == 1;
            ((Data_Carrier_Bool)field_3).value = (data[0] >> 2) % 2 == 1;
            ((Data_Carrier_Bool)field_4).value = (data[0] >> 3) % 2 == 1;
            ((Data_Carrier_Bool)field_5).value = (data[0] >> 4) % 2 == 1;
            ((Data_Carrier_Bool)field_6).value = (data[0] >> 5) % 2 == 1;
            ((Data_Carrier_Bool)field_7).value = (data[0] >> 6) % 2 == 1;
            ((Data_Carrier_Bool)field_8).value = (data[0] >> 7) % 2 == 1;

            return new List<Data_Carrier_Base> { field_1, field_2, field_3, field_4, field_5, field_6, field_7, field_8 };
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)id, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_60 : Command_Handler
    {
        private const All_Params first_param = All_Params._LOCK_PT100_0;
        private const All_Params second_param = All_Params._LOCK_PT100_1;
        private const All_Params third_param = All_Params._LOCK_PT100_2;

        private const All_Params fourth_param = All_Params._WARN_PT100_0;
        private const All_Params fifth_param = All_Params._WARN_PT100_1;
        private const All_Params sixth_param = All_Params._WARN_PT100_2;
        private const All_Params seventh_param = All_Params._WARN_V4_20_0;
        private const All_Params eighth_param = All_Params._WARN_V4_20_1;
        private const All_Params ninth_param = All_Params.V4_20_0;
        private const All_Params tenth_param = All_Params.V4_20_1;
        private const All_Params eleventh_param = All_Params._PT100_0;
        private const All_Params twelve_param = All_Params._PT100_1;
        private const All_Params thirteenth_param = All_Params._PT100_2;

        private const All_Params fourteenth_param = All_Params.time_logic;
        private const All_Params sixteenth_param = All_Params._WARN_PT100_ERROR_0;

        private const All_Params seventeenth_param = All_Params._WARN_PT100_ERROR_1;
        private const All_Params eighteenth_param = All_Params._WARN_PT100_ERROR_2;

        private const All_Params _19_param = All_Params._WARN_V4_20_ERROR_0;
        private const All_Params _20_param = All_Params._WARN_V4_20_ERROR_1;
        private const All_Params state_param = All_Params.state;
        private Data_Carrier_Base field_1 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_2 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_3 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_4 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_5 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_6 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_7 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_8 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_9 = new Data_Carrier_Int();
        private Data_Carrier_Base field_10 = new Data_Carrier_Int();
        private Data_Carrier_Base field_11 = new Data_Carrier_Int();
        private Data_Carrier_Base field_12 = new Data_Carrier_Int();
        private Data_Carrier_Base field_13 = new Data_Carrier_Int();
        private Data_Carrier_Base field_14 = new Data_Carrier_Int();
        private Data_Carrier_Base field_16 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_17 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_18 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_19 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_20 = new Data_Carrier_Bool();
        private Data_Carrier_Base field_state = new Data_Carrier_State();
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
                if (d.param == sixteenth_param)
                    field_16 = d;
                if (d.param == seventeenth_param)
                    field_17 = d;
                if (d.param == eighteenth_param)
                    field_18 = d;
                if (d.param == _19_param)
                    field_19 = d;
                if (d.param == _20_param)
                    field_20 = d;
                if (d.param == state_param)
                    field_state = d;
            }
        }

        public override int id { get; set; } = 60;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            switch (packet.frame)
            {
                case 0:
                    try
                    {
                        ((Data_Carrier_State)field_state).state = (State)(data[0]);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Недопустимый параметр команды на прием");

                    }
                    ((Data_Carrier_Bool)field_1).value = (data[1] >> 3) % 2 == 1;
                    ((Data_Carrier_Bool)field_2).value = (data[1] >> 4) % 2 == 1;
                    ((Data_Carrier_Bool)field_3).value = (data[1] >> 5) % 2 == 1;
                  
                    ((Data_Carrier_Bool)field_4).value = (data[1] >> 6) % 2 == 1;
                    ((Data_Carrier_Bool)field_5).value = (data[1] >> 7) % 2 == 1;
                    ((Data_Carrier_Bool)field_6).value = (data[2] >> 0) % 2 == 1;
                    ((Data_Carrier_Bool)field_7).value = (data[2] >> 1) % 2 == 1;
                    ((Data_Carrier_Bool)field_8).value = (data[2] >> 2) % 2 == 1;
                    ((Data_Carrier_Bool)field_16).value = (data[2] >> 3) % 2 == 1;
                    ((Data_Carrier_Bool)field_17).value = (data[2] >> 4) % 2 == 1;
                    ((Data_Carrier_Bool)field_18).value = (data[2] >> 5) % 2 == 1;
                    ((Data_Carrier_Bool)field_19).value = (data[2] >> 6) % 2 == 1;
                    ((Data_Carrier_Bool)field_20).value = (data[2] >> 7) % 2 == 1;
                    ((Data_Carrier_Int)field_9).value = data[4] + data[5] * 256;
                    ((Data_Carrier_Int)field_10).value = data[6] + data[7] * 256;

                    break;

                case 1:

                    ((Data_Carrier_Int)field_11).value = data[0] + data[1] * 256;
                    ((Data_Carrier_Int)field_12).value = data[2] + data[3] * 256;
                    ((Data_Carrier_Int)field_13).value = data[4] + data[5] * 256;
                    ((Data_Carrier_Int)field_14).value = data[6] + data[7] * 256;
                    break;
            }
            return new List<Data_Carrier_Base> { field_1, field_2, field_3, field_4, field_5, field_6, field_7, field_8, field_9, field_10, field_11, field_12, field_13, field_14, field_16, field_17, field_18, field_19, field_20, field_state };
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)id, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_76 : Command_Handler
    {
        private List<All_Params> all_Params = new List<All_Params>()
        {
        All_Params._FLASH_PROT_PT100_0_ENABLE,
        All_Params._FLASH_PROT_PT100_1_ENABLE,
        All_Params._FLASH_PROT_PT100_2_ENABLE,
        All_Params._FLASH_WARN_PT100_0_ENABLE,
        All_Params._FLASH_WARN_PT100_1_ENABLE,
        All_Params._FLASH_WARN_PT100_2_ENABLE,
        All_Params._FLASH_PROT_V4_20_0_ENABLE,
        All_Params._FLASH_PROT_V4_20_1_ENABLE,
        All_Params._FLASH_WARN_V4_20_0_ENABLE,
        All_Params._FLASH_WARN_V4_20_1_ENABLE,
        All_Params._FLASH_PROT_WRONG_CON_ENABLE,
        All_Params._FLASH_ASSYMETRY_ENABLE,

        All_Params._FLASH_PROT_PT100_0_SETPOINT,
        All_Params._FLASH_PROT_PT100_1_SETPOINT,
        All_Params._FLASH_PROT_PT100_2_SETPOINT,

        All_Params._FLASH_WARN_PT100_0_SETPOINT,
        All_Params._FLASH_WARN_PT100_1_SETPOINT,
       All_Params._FLASH_WARN_PT100_2_SETPOINT,

        All_Params._FLASH_WARN_V4_20_0_SETPOINT,
       All_Params._FLASH_WARN_V4_20_1_SETPOINT,

        All_Params._FLASH_MIN_CURRENT,
         };

        private List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>();
        public Command_Handler_76(List<Data_Carrier_Base> fields) : base(fields)
        {
            foreach (var p in all_Params)
            {
                if (fields.Exists(c => c.param == p))
                    this.fields.Add(fields.FindLast(c => c.param == p));
                else throw new Exception("Ошибка при привязке параметров - не хвататет параметров устройства");
            }
        }

        public override int id { get; set; } = 76;
        public override List<Data_Carrier_Base> Handle_Incoming_Command(Packet packet)
        {
            byte[] data = packet.data;
            switch (packet.frame)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        ((Data_Carrier_Bool)fields[i]).value = (data[i / 8] >> i % 8) % 2 == 1;
                    }
                     ((Data_Carrier_Int)fields[12]).value = data[2] + data[3] * 256;
                    ((Data_Carrier_Int)fields[13]).value = data[4] + data[5] * 256;
                    ((Data_Carrier_Int)fields[14]).value = data[6] + data[7] * 256;
                    return fields.Take(15).ToList();

                    break;

                case 1:
                    for (int i = 15; i < 19; i++)
                    {
                        ((Data_Carrier_Int)fields[i]).value = data[2 * (i - 15)] + data[2 * (i - 15) + 1] * 256;
                    }
                    return fields.Take(new Range(15, 18)).ToList();
                    break;

                case 2:
                    for (int i = 19; i < 22; i++)
                    {
                        ((Data_Carrier_Int)fields[i]).value = data[2 * (i - 15)] + data[2 * (i - 15) + 1] * 256;
                    }
                    return fields.Take(new Range(19, 21)).ToList();
                    break;
            }
            throw new Exception("Неверно распознан пакет ");
        }

        public override Packet Handle_Outgoing_Command(List<Data_Carrier_Base>? list)
        {
            return new Packet { cmd = (byte)id, data = { }, frame = 0 };
        }
    }

    public class Command_Handler_80 : Command_Handler
    {
        private const All_Params first_param = All_Params._FLASH_ID_VERSIYA_H;
        private const All_Params fourth_param = All_Params._FLASH_DEV_TYPE;
        private const All_Params second_param = All_Params._FLASH_ID_VERSIYA_L;
        private const All_Params third_param = All_Params._FLASH_NUMBER_BLOK;
        private Data_Carrier_Base field_1 = new Data_Carrier_Int();
        private Data_Carrier_Base field_2 = new Data_Carrier_Int();
        private Data_Carrier_Base field_3 = new Data_Carrier_Int();
        private Data_Carrier_Base field_4 = new Data_Carrier_Int();
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

        public override int id { get; set; } = 80;
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
}