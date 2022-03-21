namespace Transforms
{
    //брус конфигуратор
    public struct sCurrentAnalogData
    {
        public int[] avg_adc_value;
        public int avg_Uline;
        public int leak;
        public int leak2;
    }

    internal class Device_Model : Base_Component
    {
        private static System.Timers.Timer timer_for_observation;
        private AutoResetEvent Ev = new AutoResetEvent(false);
        public int id;
        public List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>() {
              new Data_Carrier_Bool {param = All_Params. state, value = false},
               new Data_Carrier_Int{param = All_Params.time_logic, value = 0},
            new Data_Carrier_Int_List {param = All_Params.sCurrentAnalogData_avg_adc_value, values = new List<int>{ 0,0,0,0,0,0,0,0} },
             new Data_Carrier_Int {param = All_Params._FLASH_ID_VERSIYA_H, value = 0},
             new Data_Carrier_Int {param = All_Params._FLASH_ID_VERSIYA_L, value = 0},
             new Data_Carrier_Int{param = All_Params._FLASH_NUMBER_BLOK, value = 0},
              new Data_Carrier_Int{param = All_Params._FLASH_DEV_TYPE, value = 0},
              new Data_Carrier_Bool {param = All_Params._FLASH_PROT_PT100_0_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params._FLASH_PROT_PT100_1_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params._FLASH_PROT_PT100_2_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params. _FLASH_WARN_PT100_0_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params. _FLASH_WARN_PT100_1_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params. _FLASH_WARN_PT100_2_ENABLE, value = false},
              new Data_Carrier_Bool {param = All_Params. _FLASH_PROT_V4_20_0_ENABLE, value = false},
                    new Data_Carrier_Bool {param = All_Params. _FLASH_PROT_V4_20_1_ENABLE, value = false},
                          new Data_Carrier_Bool {param = All_Params. _FLASH_WARN_V4_20_0_ENABLE, value = false},
                             new Data_Carrier_Bool {param = All_Params. _FLASH_WARN_V4_20_1_ENABLE, value = false},
                                new Data_Carrier_Bool {param = All_Params. _FLASH_PROT_WRONG_CON_ENABLE, value = false},
                                 new Data_Carrier_Int {param = All_Params. _FLASH_MIN_CURRENT, value = 0},
                                new Data_Carrier_Int {param = All_Params. _FLASH_PROT_PT100_0_SETPOINT, value = 0},
                                new Data_Carrier_Int {param = All_Params. _FLASH_PROT_PT100_1_SETPOINT, value = 0},
                                new Data_Carrier_Int {param = All_Params. _FLASH_PROT_PT100_2_SETPOINT, value = 0},
                                new Data_Carrier_Int {param = All_Params. _FLASH_WARN_PT100_0_SETPOINT, value = 0},
                                 new Data_Carrier_Int {param = All_Params. _FLASH_WARN_PT100_1_SETPOINT, value = 0},
                                 new Data_Carrier_Int {param = All_Params. _FLASH_WARN_PT100_2_SETPOINT, value = 0},
                                  new Data_Carrier_Int {param = All_Params.  _FLASH_PROT_V4_20_0_SETPOINT, value = 0},
                                   new Data_Carrier_Int {param = All_Params.  _FLASH_PROT_V4_20_1_SETPOINT, value = 0},
                                    new Data_Carrier_Int {param = All_Params.  _FLASH_WARN_V4_20_0_SETPOINT, value = 0},
                                     new Data_Carrier_Int {param = All_Params.  _FLASH_WARN_V4_20_1_SETPOINT, value = 0},
                                        new Data_Carrier_Int {param = All_Params.  _FLASH_RS485_ADDRESS, value = 0},
                                        new Data_Carrier_Int {param = All_Params.  _FLASH_RS485_SPEED, value = 0},
                                         new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL0, value = 0},
                                          new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL1, value = 0},
                                           new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL2, value = 0},
                                            new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL3, value = 0},
                                             new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL4, value = 0},
                                              new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL5, value = 0},
                                               new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL6, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL7, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_MUL8, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND0, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND1, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND2, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND3, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND4, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND5, value = 0},
                                                new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND6, value = 0},
                                                 new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND7, value = 0},
                                                  new Data_Carrier_Int {param = All_Params.  _FLASH_RATIOS_GND8, value = 0},
                                                   new Data_Carrier_Int {param = All_Params.  _FLASH_CURRENT_MUL, value = 0},
                                                    new Data_Carrier_Int {param = All_Params.  _FLASH_CT_MUL, value = 0},
                                                     new Data_Carrier_Int {param = All_Params.  _FLASH_WRONG_CON_MAX_CURRENT, value = 0},
                                                      new Data_Carrier_Int {param = All_Params.  _FLASH_WRONG_CON_SW_CURRENT, value = 0},
                                                           new Data_Carrier_Bool {param = All_Params. _FLASH_ASSYMETRY_ENABLE, value = false},
                                                             new Data_Carrier_Int {param = All_Params.  _FLASH_ASSYMETRY_SETPOINT, value = 0},
                                                               new Data_Carrier_Int {param = All_Params.  _FLASH_ASSYMETRY_TIME, value = 0},
                                                                 new Data_Carrier_Int {param = All_Params.  ADCdata_currentA, value = 0},
                                                                  new Data_Carrier_Int {param = All_Params.  ADCdata_currentB, value = 0},
                                                                   new Data_Carrier_Int {param = All_Params.  ADCdata_currentC, value = 0},
                                                                    new Data_Carrier_Int {param = All_Params.  ADCdata_currentD, value = 0},
                                                                     new Data_Carrier_Int {param = All_Params.  ADCdata_currentAVG, value = 0},
                                                                      new Data_Carrier_Int {param = All_Params.  ADCdata_PT1, value = 0},
                                                                       new Data_Carrier_Int {param = All_Params.  ADCdata_PT2, value = 0},
                                                                        new Data_Carrier_Int {param = All_Params.  ADCdata_PT3, value = 0},
                                                                         new Data_Carrier_Int {param = All_Params.  ADCdata_I4_20_1, value = 0},
                                                                       new Data_Carrier_Int {param = All_Params.  ADCdata_I4_20_2, value = 0},
                                                                       new Data_Carrier_Int {param = All_Params.  ADCdata_assymetry, value = 0},
                                                                               new Data_Carrier_Int {param = All_Params.  ADCdata_IA_angle, value = 0},
                                                                                       new Data_Carrier_Int {param = All_Params.  ADCdata_IB_angle, value = 0},
                                                                                               new Data_Carrier_Int {param = All_Params.  ADCdata_IC_angle, value = 0},
                                                                                                       new Data_Carrier_Int {param = All_Params.  ADCdata_ID_angle, value = 0},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_0, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_1, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_2, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_V4_20_0, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_V4_20_1, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_ERROR_0, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_ERROR_1, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_PT100_ERROR_2, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_V4_20_ERROR_0, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._WARN_V4_20_ERROR_1, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._LOCK_PT100_0, value = false},
                                                                                                       new Data_Carrier_Bool {param = All_Params._LOCK_PT100_1, value = false},
                                                                                                          new Data_Carrier_Bool {param = All_Params._LOCK_PT100_2, value = false},
                                                                                                      new Data_Carrier_Int {param = All_Params.  V4_20_0, value = 0},
                                                                                                         new Data_Carrier_Int {param = All_Params.  V4_20_1, value = 0},
                                                                                                            new Data_Carrier_Int {param = All_Params.  _PT100_0, value = 0},
                                                                                                               new Data_Carrier_Int {param = All_Params.  _PT100_1, value = 0},
                                                                                                                  new Data_Carrier_Int {param = All_Params.  _PT100_2, value = 0},
                                                                                                                    new Data_Carrier_Int {param =   All_Params._FLASH_RATIOS_SHIFT_PT1, value = 0},
                                                                      new Data_Carrier_Int {param = All_Params._FLASH_RATIOS_SHIFT_PT2, value = 0},
                                                                        new Data_Carrier_Int {param = All_Params._FLASH_RATIOS_SHIFT_PT3, value = 0},

        };
        public List<Command_Handler> commands;
        public List<int> avg_adc_value = new List<int>();

        private volatile bool model_interaction_working = true;
        private Thread model_thread;
        private List<Packet_Base> packet_s = new List<Packet_Base>();
        public Device_Model()
        {
            timer_for_observation = new System.Timers.Timer(500);
            timer_for_observation.Elapsed += Timer_for_observation_Elapsed;
            timer_for_observation.Start();
            model_thread = new Thread(Model_Interaction);
            model_thread.IsBackground = true;
            model_thread.Start();
           

            commands = new List<Command_Handler>() {  new Command_Handler_102(fields), new Command_Handler_80(fields), new Command_Handler_76(fields),
                new Command_Handler_60(fields), new Command_Handler_59(fields), new Command_Handler_58(fields), new Command_Handler_51(fields), new Command_Handler_50(fields), new Command_Handler_106(fields), new Command_Handler_103(fields)
            };

            
        }
        List<All_Params> all_ = new List<All_Params>()
            {
             All_Params.ADCdata_currentA,
        All_Params.ADCdata_currentB,
        All_Params.ADCdata_currentC,
        All_Params.ADCdata_currentD,
        All_Params.ADCdata_currentAVG,
        All_Params.ADCdata_PT1,
        All_Params.ADCdata_PT2,
        All_Params.ADCdata_PT3,
        All_Params.ADCdata_I4_20_1,
        All_Params.ADCdata_I4_20_2,
        All_Params.ADCdata_assymetry,
        All_Params.ADCdata_IA_angle,
        All_Params.ADCdata_IB_angle,
        All_Params.ADCdata_IC_angle,
        All_Params.ADCdata_ID_angle,
            };
      
        private void Timer_for_observation_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            //Packet packet = commands.First(c => c.id == 59).Handle_Outgoing_Command(null);
            //packet.len = (packet.data == null ? (byte)0 : (byte)(packet.data.Length));
            //packet.to = (byte)id;
            //_mediator.Notify(this, Reseiver.connection, packet);
            Packet packet1 = commands.First(c => c.id == 58).Handle_Outgoing_Command(null);
            packet1.len = (packet1.data == null ? (byte)0 : (byte)(packet1.data.Length));
            packet1.to = (byte)id;
            _mediator.Notify(this, Reseiver.connection, packet1);
            Packet packet2 = commands.First(c => c.id == 60).Handle_Outgoing_Command(null);
            packet2.len = (packet2.data == null ? (byte)0 : (byte)(packet2.data.Length));
            packet2.to = (byte)id;
            _mediator.Notify(this, Reseiver.connection, packet2);

            for (int i = 0; i < all_.Count; i++)
            {
                Packet packet3 = commands.First(c => c.id == 106).Handle_Outgoing_Command(new List<Data_Carrier_Base>() { new Data_Carrier_Bool() { param = all_[i] } });
                packet3.len = (packet3.data == null ? (byte)0 : (byte)(packet3.data.Length));
                packet3.to = (byte)id;
                _mediator.Notify(this, Reseiver.connection, packet3);
            }


           

                Send_Command_Static_Data();
           

        }

        public void Send_Command_Static_Data()
        {
            foreach(var par in fields)
            {


                if(par.param.ToString().Contains("_FLASH_"))
                { Send_Data_to_Connection(new List<Data_Carrier_Base>() { new Data_Carrier_Int() { param = All_Params.command, value = 102 }, par });
                }
                
            }



        }
        public void Close_Model()
        {
            model_interaction_working = false;
            timer_for_observation.Stop();
            Ev.Set();
        }
        public void Notify_about_Model()
        {

            _mediator.Notify(this, Reseiver.UI, fields);
            _mediator.Notify(this, Reseiver.UI, commands);

        }
       
        public void Model_Interaction()
        {

            while (model_interaction_working && Ev.WaitOne())
            {


                lock (packet_s)

                {
                    for (int i = packet_s.Count() - 1; i >= 0; i--)
                    {
                        List<Data_Carrier_Base> datas = new List<Data_Carrier_Base>();
                        Packet packet = ((Packet)packet_s[i]);


                        if(packet.frame == 0 &&  packet.cmd==60 && (packet.data[1] >> 2) % 2 == 1)
                        { }


                        if (packet.frame == 0 && packet.cmd == 60 && (packet.data[1] >> 2) % 2 == 0)
                        { }


                        if (packet.cmd != 203 && packet.cmd != 0)
                        {
                            {
                                datas = commands.Find(c => c.id == packet.cmd).Handle_Incoming_Command(packet);

                                datas.Add(new Data_Carrier_Int { param = All_Params.id, value = id, });

                                if(datas.First().param == All_Params._FLASH_WARN_PT100_1_ENABLE)
                                {

                                  
                                }
                                _mediator.Notify(this, Reseiver.UI, datas);

                            }
                        }


                        packet_s.RemoveAt(i);
                    }
                }
            }
        }

        internal void Send_Data_to_Connection(List<Data_Carrier_Base> d)
        {
            Packet packet = commands.First(c => c.id == ((Data_Carrier_Int)d.Find(f => f.param == All_Params.command)).value).Handle_Outgoing_Command(d);
            packet.len = (byte)packet.data.Length;
            packet.to = (byte)id;

            _mediator.Notify(this, Reseiver.connection, packet);
            if(packet.cmd==103)
            {

                packet = commands.First(c => c.id == 102).Handle_Outgoing_Command(d);
                packet.len = (byte)packet.data.Length;
                packet.to = (byte)id;
                _mediator.Notify(this, Reseiver.connection, packet);
            }
        }

        public void Receive_Data(Packet packet)
        {
            Packet gg;
            lock (packet_s)
            {
                gg = new Packet { CAN = packet.CAN, cmd = packet.cmd, frame = packet.frame, from = packet.from, len = packet.len, to = packet.to };
                gg.data = new byte[gg.len];
                for (int i = 0; i < gg.len; i++)
                {

                    gg.data[i] = packet.data[i];
                }
            }

            packet_s.Add(gg);
            //////////////////////////////////////////////
            Ev.Set();
        }
    }
}