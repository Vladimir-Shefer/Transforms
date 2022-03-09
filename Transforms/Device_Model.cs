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

        public List<int> avg_adc_value = new List<int>();

        private volatile bool model_interaction_working = true;
        private Thread model_thread;
        private List<Packet_Base> packet_s = new List<Packet_Base>();
        public Device_Model()
        {
            model_thread = new Thread(Model_Interaction);
            model_thread.IsBackground = true;
            model_thread.Start();
            for (int i = 0; i < 8; i++)
            {
                avg_adc_value.Add(0);
            }
        }

        public void Close_Model()
        {
            model_interaction_working = false;
            Ev.Set();
        }

        public void Model_Interaction()
        {
            while (model_interaction_working && Ev.WaitOne())
            {
               
                for (int i = packet_s.Count()-1; i >= 0; i--)
                {
                    Packet packet = ((Packet)packet_s[i]);
                    switch (((Packet)packet_s[i]).frame)
                    {

                        
                        case 0:

                            avg_adc_value[0] = packet.data[0] * 256 + packet.data[1];
                            avg_adc_value[1] = packet.data[2] * 256 + packet.data[3];
                            avg_adc_value[2] = packet.data[4] * 256 + packet.data[5];
                            avg_adc_value[3] = packet.data[6] * 256 + packet.data[7];
                            break;

                        case 1:

                            avg_adc_value[4] = packet.data[0] * 256 + packet.data[1];
                            avg_adc_value[5] = packet.data[2] * 256 + packet.data[3];
                            avg_adc_value[6] = packet.data[4] * 256 + packet.data[5];
                            avg_adc_value[7] = packet.data[6] * 256 + packet.data[7];
                            break;
                    }
                    {
                        List<int> val = new List<int>();
                        for (int h = 0; h < 8; h++)
                        {
                            val.Add(avg_adc_value[h]);
                        }

                        lock (val) _mediator.Notify(this, Reseiver.UI, new Data_Carrier_Int_List { param = All_Params.sCurrentAnalogData_avg_adc_value, values = val });
                    }
                    packet_s.RemoveAt(i);
                }
            }
        }

        public void Receive_Data(byte[] data)
        {
            Ev.Set();
        }

        public void Receive_Data(Packet packet)
        {
            lock (packet_s)
                packet_s.Add(packet);
           
            Ev.Set();
        }
    }
}