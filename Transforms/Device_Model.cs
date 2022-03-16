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
        private AutoResetEvent Ev = new AutoResetEvent(false);
        public int id;
        public  List<Data_Carrier_Base> fields = new List<Data_Carrier_Base>() { 
          
            new Data_Carrier_Int_List {param = All_Params.sCurrentAnalogData_avg_adc_value, values = new List<int>{ 0,0,0,0,0,0,0,0} }    
        };
        public List<Command_Handler> commands ;
        public List<int> avg_adc_value = new List<int>();

        private volatile bool model_interaction_working = true;
        private Thread model_thread;
        private List<Packet_Base> packet_s = new List<Packet_Base>();
        public Device_Model()
        {
            model_thread = new Thread(Model_Interaction);
            model_thread.IsBackground = true;
            model_thread.Start();
            commands = new List<Command_Handler>() { new Command_Handler_128(fields), new Command_Handler_116(fields) };
        }

        public void Close_Model()
        {
            model_interaction_working = false;
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
              
               
                for (int i = packet_s.Count()-1; i >= 0; i--)
                {
                    List<Data_Carrier_Base> datas = new List<Data_Carrier_Base>();
                    Packet packet = ((Packet)packet_s[i]);
                    
                   

                          
                            if (packet.cmd != 115)
                            {
                                datas.Clear();
                     int gff =    this.id;
                                datas = commands.Find(c => c.id == packet.cmd).Handle_Incoming_Command(packet);
                               if(((Data_Carrier_Int_List)datas[0]).values.Exists(c=>c>3000) && id!=10)
                                {



                                }
                                datas.Add(new Data_Carrier_Int { param = All_Params.id, value = id, });
                                
                                
                               _mediator.Notify(this, Reseiver.UI, datas);
                            }
                     
                    
                    packet_s.RemoveAt(i);
                }
            }
        }

        internal void Send_Data_to_Connection(List<Data_Carrier_Base> d)
        {
            Packet packet = commands.First(c => c.id == ((Data_Carrier_Int)d.Find(f => f.param == All_Params.command)).value).Handle_Outgoing_Command(d);
            packet.len = (byte)packet.data.Length;
            packet.to = (byte)id;
            
            _mediator.Notify(this, Reseiver.connection,packet );    
        }

        public void Receive_Data(Packet packet)
        {
            Packet gg;
            lock (packet_s)
            {
               gg = new Packet { CAN = packet.CAN, cmd = packet.cmd, frame = packet.frame, from = packet.from, len = packet.len, to = packet.to };
                gg.data = new byte[gg.len];
                for(int i = 0; i< gg.len; i++)
                { 

                    gg.data[i] = packet.data[i];    
}
            }
            if(gg.data[0] * 256 + gg.data[1] > 2000)
            {



            }
            if (gg.from != 10 && gg.data[0] * 256 + gg.data[1] > 2000)
            { }
            packet_s.Add(gg);
           //////////////////////////////////////////////
            Ev.Set();
        }
    }
}