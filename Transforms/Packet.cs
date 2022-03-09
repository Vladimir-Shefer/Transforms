using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Timers;

namespace Transforms
{



    public class Packet : Packet_Base
    {
        public byte CAN;
        public bool displayed;
        public byte frame;
        public byte from;
        public byte len;
        public byte to;
        const int full_length = 16;
        public bool forThis(Packet packet)
        {
            if ((this.cmd == 129 || packet.cmd == 129))
            {
                if (this.data.Length == 0)
                    return false;
                if (((packet.from == this.from) || (this.from == 0)) && packet.to == this.to && packet.frame == this.frame && packet.cmd == this.cmd && this.data[0] == packet.data[0])
                    return true;
                return false;
            }
            else
            if (((packet.from == this.from) || (this.from == 0)) && packet.to == this.to && packet.frame == this.frame && packet.cmd == this.cmd)
                return true;

            return false;
        }

        public bool isThis(Packet packet)
        {

            int l = this.data.Length;

            for (int i = 0; i < l; i++)
            {

                if (this.data[i] != packet.data[i])
                    return false;
            }
            if (((packet.from == this.from) || (this.from == 0)) && packet.to == this.to && packet.frame == this.frame && packet.cmd == this.cmd && packet.displayed == this.displayed)
                return true;

            return false;
        }

        public string ToString(int code)
        {
            //TimeSpan g = DateTime.Now - time;
            var list = data?.Select(s => s.ToString()) ?? new List<string>();
            switch (code)
            {
                case 0: return $"Получен ожидаемый пакет, от: {from}, кому: {to}, фрейм: {frame}, команда: {cmd}, данные: {string.Join(" ", list)}";
                case 1: return $"Получен неожидаемый пакет, от: {from}, кому: {to}, фрейм: {frame}, команда: {cmd}, данные: {string.Join(" ", list)}";
                case 2: return $"Прошло время ожидания пакета от: {from}, кому: {to}, фрейм: {frame}, команда: {cmd}";
                default: return $"Пакет, от: {from}, кому: {to}, фрейм: {frame}, команда: {cmd}, данные: {string.Join(" ", list)}";
            }



        }
    }

    public class Packet_Base
    {

        public byte cmd;
        public byte[] data;
        public DateTime time;
        public int timeout;
    }
}
