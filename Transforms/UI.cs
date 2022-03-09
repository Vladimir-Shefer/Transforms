using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transforms
{
    internal class UI:Base_Component
    {


        public static Form1 form;
        public List<string> avg_adc_value = new List<string>();
        public UI() : base()
        {


        }

        public void Close_All()
        {


            _mediator.Close_All();
        }

        public void doS()
        {
            form.DialogResult = MessageBox.Show(
        "Отключено",
        "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
       );
        }

        public void Fixate_Serial_Port(string PortName, int speed)
        {
            _mediator.Fixate_Serial_Port(PortName, speed);
        }

        public Form1 Get_UI_Form()
        {

            return form;
        }
        public void Open_Serial_Port()
        {

            _mediator.Open_Serial_Port();
        }

        public void Put_UI_Form(Form1 fff)
        {
            form = fff;
            form.Set_UI(this);
        }
        public bool Serial_Port_Is_Opened()
        {

            return _mediator.Serial_Port_Is_Opened();
        }

      
        public void Update_Model_Info(int id, Data_Carrier_Int_List int_List)
        {
            form.Update_Rich_Textbox(id, int_List);

        }
      
        internal void Close_Serial_Port()
        {
            _mediator.Close_Serial_Port();
        }

        internal void Pass_Data_to_Connection_from_Interface(byte[] data)
        {
            
          
                _mediator.Notify(this, Reseiver.connection, data);
           
        }
    }
}
