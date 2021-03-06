using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Transforms
{
    internal class Mediator : IMediator
    {
        private List<Connection> connections = new List<Connection>();

        //private Transfer_Data_to_Interface_from_Model _del_update;
        private List<Device_Model> models = new List<Device_Model>();
        private UI ui = new UI();
        Data_Parser parser;
        public Mediator(Device_Model d, Connection c, UI u, Data_Parser parser)
        {
            Set_Parser(parser);
            Set_New_Connection(c);
            Set_New_DeviceModel(d);
            Set_New_UI(u);
            models.First().SetMediator(this);
            connections.First().SetMediator(this);
            ui.SetMediator(this);

            //IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();

            //usbEventWatcher.UsbDeviceRemoved += (_, device) => ui.doS();
            
        }

        public Mediator(List<Device_Model> d, Connection c, UI u)
        {
            Set_New_Connection(c);
            foreach (var j in d) Set_New_DeviceModel(j);
            Set_New_UI(u);
            foreach (var j in d) j.SetMediator(this);
            connections.First().SetMediator(this);
            ui.SetMediator(this);

            //IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();

            //usbEventWatcher.UsbDeviceRemoved += (_, device) => ui.doS();
            //connection.Register_Data_Receive_Handler(new Connection.Serial_Port_Data(Pass_Data_to_Model_from_Connection));
            //BRUS.Register_Model_Update_Handler(new DeviceModel.Model_Update_Del(Pass_Data_to_Interface_from_Model));
        }

        public interface IScopedPostmanService
        {
            void DeliverLetter(string postmanType);

            void GetSignature(string postmanType);

            void HandOverLetter(string postmanType);

            void PickUpLetter(string postmanType);
        }

        public interface ISingletonPostmanService
        {
            void DeliverLetter(string postmanType);

            void GetSignature(string postmanType);

            void HandOverLetter(string postmanType);

            void PickUpLetter(string postmanType);
        }

        public interface ITransientPostmanService
        {
            void DeliverLetter(string postmanType);

            void GetSignature(string postmanType);

            void HandOverLetter(string postmanType);

            void PickUpLetter(string postmanType);
        }

        public void Close_All()
        {
            models.First().Close_Model();
            connections.First().Close_Connection();
        }

        public void Close_Serial_Port()
        {
            connections.First().Close_Serial_Port();
        }

        public void DoDI()
        {
            PostmanHandler postman;

            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            var scopeFactory = serviceProvider.GetService<IServiceScopeFactory>();

            postman = serviceProvider.GetService<PostmanHandler>();

            postman.PickUpLetter();
            postman = serviceProvider.GetService<PostmanHandler>();
            postman.DeliverLetter();
            postman = serviceProvider.GetService<PostmanHandler>();
            postman.GetSignature();
            postman = serviceProvider.GetService<PostmanHandler>();
            postman.HandOverLetter();

            Console.WriteLine("-----------------Scope changed!---------------------");

            using (var scope = scopeFactory.CreateScope())
            {
                postman = scope.ServiceProvider.GetService<PostmanHandler>();

                postman.PickUpLetter();
                postman = serviceProvider.GetService<PostmanHandler>();
                postman.DeliverLetter();
                postman = serviceProvider.GetService<PostmanHandler>();
                postman.GetSignature();
                postman = serviceProvider.GetService<PostmanHandler>();
                postman.HandOverLetter();
            }

            Console.ReadKey();
        }

        public void Fixate_Serial_Port(string PortName, int speed)
        {
            connections.First().Fixate_Serial_Port(PortName, speed);
        }

        public void Notify(object sender, Reseiver reseiver, Data_Carrier_Int_List d)
        {
            if (reseiver == Reseiver.UI)
            {
                ui.Update_Model_Info(((Device_Model)sender).id, d);
            }
        }

        public void Notify(object sender, Reseiver reseiver, byte[] bytes)
        {
            if (reseiver == Reseiver.model)

            {

                byte[] hh = new byte[8];

                for (int i = 0; i < 8; i++)
                {
                    hh[i] = bytes[i + 6];
                }
                Packet packet = new Packet { from = bytes[1], to = bytes[2], frame = bytes[3], cmd = bytes[4], len = bytes[5], data = hh };


                try { models.Where(c => c.id == packet.from).First().Receive_Data(parser.Parse_from_bytes_to_Packet(bytes)); }
                catch { }
                // models.First().Receive_Data(packet);
            }
            if (reseiver == Reseiver.connection)
            {



                connections.First().Pass_Data_to_Connection(bytes);
            }


        }

        public void Open_Serial_Port()
        {
            connections.First().Open_Serial_Port();
        }

      

       

      


        public bool Serial_Port_Is_Opened()
        {
            return connections.First().Serial_Port_Is_Opened();
        }

        public void Set_New_Connection(Connection connection)
        {
            connections.Add(connection);
        }
        public void Set_Parser(Data_Parser dp)
        {
            parser = dp;
        }
        public void Set_New_DeviceModel(Device_Model device)
        {
            models.Add(device);
        }
        public void Set_New_UI(UI ui)
        {
            this.ui = ui;
        }
        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITransientPostmanService, PostmanService>();
            services.AddScoped<IScopedPostmanService, PostmanService>();
            services.AddSingleton<ISingletonPostmanService, PostmanService>();

            services.AddTransient<PostmanHandler>();

            services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
            });

            return services;
        }
        public class PostmanHandler
        {
            private readonly IScopedPostmanService _scopedPostman;
            private readonly ISingletonPostmanService _singletonPostman;
            private readonly ITransientPostmanService _transientPostman;
            public PostmanHandler(ITransientPostmanService transientPostman, IScopedPostmanService scopedPostman, ISingletonPostmanService singletonPostman)
            {
                _transientPostman = transientPostman;
                _scopedPostman = scopedPostman;
                _singletonPostman = singletonPostman;
            }

            public void DeliverLetter()
            {
                _transientPostman.DeliverLetter(nameof(_transientPostman));
                _scopedPostman.DeliverLetter(nameof(_scopedPostman));
                _singletonPostman.DeliverLetter(nameof(_singletonPostman));
            }

            public void GetSignature()
            {
                _transientPostman.GetSignature(nameof(_transientPostman));
                _scopedPostman.GetSignature(nameof(_scopedPostman));
                _singletonPostman.GetSignature(nameof(_singletonPostman));
            }

            public void HandOverLetter()
            {
                _transientPostman.HandOverLetter(nameof(_transientPostman));
                _scopedPostman.HandOverLetter(nameof(_scopedPostman));
                _singletonPostman.HandOverLetter(nameof(_singletonPostman));
            }

            public void PickUpLetter()
            {
                _transientPostman.PickUpLetter(nameof(_transientPostman));
                _scopedPostman.PickUpLetter(nameof(_scopedPostman));
                _singletonPostman.PickUpLetter(nameof(_singletonPostman));
            }
        }
        public class PostmanService :
            ITransientPostmanService,
            IScopedPostmanService,
            ISingletonPostmanService
        {
            private readonly ILogger<PostmanService> _logger;
            private readonly string _name;
            private readonly string[] _possibleLastNames = new string[] { "Brown", "Jackson", "Gibson", "Williams" };
            private readonly string[] _possibleNames = new string[] { "Peter", "Jack", "Bob", "Alex" };
            public PostmanService(ILogger<PostmanService> logger)
            {
                _logger = logger;

                var rnd = new Random();
                _name = $"{_possibleNames[rnd.Next(0, _possibleNames.Length - 1)]} {_possibleLastNames[rnd.Next(0, _possibleLastNames.Length - 1)]}";

                _logger.LogInformation($"Hi! My name is {_name}.");
            }

            public void DeliverLetter(string postmanType)
            {
                _logger.LogInformation($"Postman {_name} delivered the letter. [{postmanType}]");
            }

            public void GetSignature(string postmanType)
            {
                _logger.LogInformation($"Postman {_name} got a signature. [{postmanType}]");
            }

            public void HandOverLetter(string postmanType)
            {
                _logger.LogInformation($"Postman {_name} handed the letter. [{postmanType}]");
            }

            public void PickUpLetter(string postmanType)
            {
                _logger.LogInformation($"Postman {_name} took the letter. [{postmanType}]");
            }
        }
    }
}