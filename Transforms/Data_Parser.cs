namespace Transforms
{
    internal class Data_Parser
    {
        public Packet Parse_from_bytes_to_Packet(byte[] bytes_data)
        {
            byte[] hh = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                hh[i] = bytes_data[i + 6];
            }
            Packet packet = new Packet { from = bytes_data[1], to = bytes_data[2], frame = bytes_data[3], cmd = bytes_data[4], len = bytes_data[5], data = hh };

            return packet;
        }

        public byte[] Parse_from_packet_to_bytes(Packet_Base packet_data)
        {
            if (packet_data.GetType() == typeof(Packet))
            {
                byte[] buffer = new byte[15];
                byte AMOUNT_DATA = 0;
                if (((Packet)packet_data).data != null) AMOUNT_DATA = (byte)((Packet)packet_data).data.Length;
                buffer[0] = ((Packet)packet_data).CAN; //2; //0 - интерфейс кан(в нашем случае 2)
                buffer[1] = ((Packet)packet_data).from; // 1; //1 - sender(наш адрес на кане) пусть будет 1 - номер устройства отправителя в шине
                buffer[2] = ((Packet)packet_data).to == null ? (byte)0 : (byte)((Packet)packet_data).to; // 38; //2 - receiver = 38 - номер устройства получателя в шине
                buffer[3] = ((Packet)packet_data).frame; // 0; //3 - номер фрейма при отправке 0, при получении - смещение
                buffer[4] = ((Packet)packet_data).cmd; // 64; //4 - номер команды
                buffer[5] = AMOUNT_DATA; // 0; //5 - количество данных
                buffer[6] = AMOUNT_DATA > 0 ? ((Packet)packet_data).data[0] : (byte)0; // 1;//6 - packet_data.data[0]
                buffer[7] = AMOUNT_DATA > 1 ? ((Packet)packet_data).data[1] : (byte)0; //7 - packet_data.data[1]
                buffer[8] = AMOUNT_DATA > 2 ? ((Packet)packet_data).data[2] : (byte)0; //8 - packet_data.data[2]
                buffer[9] = AMOUNT_DATA > 3 ? ((Packet)packet_data).data[3] : (byte)0; //9 - packet_data.data[3]
                buffer[10] = AMOUNT_DATA > 4 ? ((Packet)packet_data).data[4] : (byte)0; //10 - packet_data.data[4]
                buffer[11] = AMOUNT_DATA > 5 ? ((Packet)packet_data).data[5] : (byte)0; //11 - packet_data.data[5]
                buffer[12] = AMOUNT_DATA > 6 ? ((Packet)packet_data).data[6] : (byte)0; //12 - packet_data.data[6]
                buffer[13] = AMOUNT_DATA > 7 ? ((Packet)packet_data).data[7] : (byte)0; //13 - data[7]
                buffer[14] = 0;//14 - crc8
                return buffer;
            }
            else return new byte[0];
        }
    }
}