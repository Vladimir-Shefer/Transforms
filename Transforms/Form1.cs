using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;



namespace Transforms
{


    public partial class Form1 : Form
    {
      
        private Close_All_Del _del_close_all;
        /// <summary>
        /// ///////////////////////// делегаты ////////////////////////////
        /// </summary>
     
        private UI _ui;
        private List<string> serial_port_names;

        /// <summary>
        /// ////////////////////////////////////////////////////////////
        /// </summary>
        /// 

        public Form1()
        {
            InitializeComponent();





        }

        public delegate void Close_All_Del();

       

    
      

      

      


        internal void Set_UI(UI uI)
        {
            {
                _ui = uI;
            }
        }
        private void Close_Serial_Port_button_Click(object sender, EventArgs e)
        {
            _ui.Close_Serial_Port();
        }


        private void Find_COM_button_Click(object sender, EventArgs e)
        {
            serial_port_names = SerialPort.GetPortNames().ToList();
            comboBox_COM_port.Items.Clear();
            comboBox_COM_port.Items.AddRange(serial_port_names.ToArray());
        }
      
        private void fixate_COM_Name_and_Speed_Click(object sender, EventArgs e)
        {

            string NAME = comboBox_COM_port.Text;
            uint speed;
            serial_port_names = SerialPort.GetPortNames().ToList();
            if (uint.TryParse(comboBox_COM_speed.Text, out speed) && serial_port_names.Contains(NAME))
            {
                _ui.Fixate_Serial_Port(NAME, (int)speed);

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox_COM_port.Items.AddRange(SerialPort.GetPortNames());
            try
            { comboBox_COM_port.Text = SerialPort.GetPortNames().First();
                comboBox_COM_speed.Items.Add("115200");
            }
            catch
            {

            }
        }

        private void Open_Serial_Port_button_Click(object sender, EventArgs e)
        {
            if (!_ui.Serial_Port_Is_Opened())
                _ui.Open_Serial_Port();
        }

        private bool Read_byte_from_textBox(ref int b, TextBox textBox)
        {
            string s = textBox.Text;

            if (!string.IsNullOrEmpty(s))
                try { b = Convert.ToInt32(s); return true; }
                catch { return false; }

            return false;
        }

        public void Update_Rich_Textbox(int i, Data_Carrier_Int_List carrier_Int_List)
        {
            try
            {

                if (this != null)
                    this.Invoke((MethodInvoker)delegate
                    {
                        lock (carrier_Int_List)
                        {
                            if (carrier_Int_List.param == All_Params.sCurrentAnalogData_avg_adc_value)
                                switch (i)

                                {

                                    case 10:
                                        int j = 0;
                                        avg_richTextBox_1.Clear();
                                        foreach (var s in carrier_Int_List.values)
                                        {
                                            if (j < 6)
                                                avg_richTextBox_1.Text += Convert.ToString(s) + "\n";
                                            j++;

                                        }
                                        break;
                                    case 11:
                                        j = 0;
                                        avg_richTextBox_2.Clear();
                                        foreach (var s in carrier_Int_List.values)
                                        {
                                            if (j < 6)
                                                avg_richTextBox_2.Text += Convert.ToString(s) + "\n";
                                            j++;

                                        }
                                        break;
                                    case 12:
                                        j = 0;
                                        avg_richTextBox_3.Clear();
                                        foreach (var s in carrier_Int_List.values)
                                        {
                                            if (j < 6)
                                                avg_richTextBox_3.Text += Convert.ToString(s) + "\n";
                                            j++;


                                        }
                                        break;
                                    case 13:
                                        j = 0;
                                        avg_richTextBox_4.Clear();
                                        foreach (var s in carrier_Int_List.values)
                                        {
                                            if (j < 6)
                                                avg_richTextBox_4.Text += Convert.ToString(s) + "\n";
                                            j++;


                                        }
                                        break;

                                }
                        }
                    });

            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ui.Close_All();
        }

        private void Send_Data_button_Click(object sender, EventArgs e)
        {
            
            _ui.Pass_Data_to_Connection_from_Interface(new Data_Carrier_Int_List { param = All_Params.sCurrentAnalogData_avg_adc_value, values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 } });
        }






        //private void save_to_clipboard_button_Click(object sender, EventArgs e)
        //{
        //    //_del(this);
        //    var data = new DataObject();
        //    data.SetData(DataFormats.UnicodeText, true, $"{avg_adc_value_richTextBox.Text}\n{sCurrentAnalogData_avg_Uline_textBox.Text}\n{sCurrentAnalogData_leak_textBox.Text}\n{sCurrentAnalogData_leak2_textBox.Text}");
        //    var thread = new Thread(() => Clipboard.SetDataObject(data, true));
        //    thread.SetApartmentState(ApartmentState.STA);
        //    thread.Start();
        //    thread.Join();
        //}






    }
}