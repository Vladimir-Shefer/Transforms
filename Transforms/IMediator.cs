namespace Transforms
{
    internal interface IMediator
    {
        void Close_All();

        void Close_Serial_Port();

        void Fixate_Serial_Port(string PortName, int speed);

        void Notify(object sender, Reseiver reseiver, List<Data_Carrier_Base> data_List);

        void Notify(object sender, Reseiver reseiver, Packet packet);
        void Notify(object sender, Reseiver reseiver, List<Command_Handler> commands);

        void Open_Serial_Port();

        bool Serial_Port_Is_Opened();
    }
}