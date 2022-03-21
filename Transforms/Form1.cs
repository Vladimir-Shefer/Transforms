using System.IO.Ports;

namespace Transforms
{
    public partial class Form1 : Form
    {
       
        private UI _ui;
        private List<string> serial_port_names;

      
        public Form1()
        {
            InitializeComponent();
        }

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
            {
                comboBox_COM_port.Text = SerialPort.GetPortNames().First();
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

        private bool Write_data_to_textBox( Data_Carrier_Base data, TextBox textBox )
        {
            if (data.GetType() == typeof(Data_Carrier_Int))
                textBox.Text = Convert.ToString(((Data_Carrier_Int)data).value);
           else if (data.GetType() == typeof(Data_Carrier_Bool))
                textBox.Text = (((Data_Carrier_Bool)data).value?"true":"false");
            else return false;
            return true;
        }
        public void Update_Rich_textbox1(int i, List<Data_Carrier_Base> carrier)
        {
            try {
                if (this != null)
                    this.Invoke((MethodInvoker)delegate
                { foreach (var data in carrier)
                {


                    if (data.param == All_Params._PT100_0)
                    {

                        Write_data_to_textBox(data, PT100_0_textBox);
                    }
                    else
                if (data.param == All_Params._PT100_1)
                    {

                        Write_data_to_textBox(data, PT100_1_textBox);
                    }
                    else
                if (data.param == All_Params._PT100_2)
                    {

                        Write_data_to_textBox(data, PT100_2_textBox);
                    }
                    else
                if (data.param == All_Params.V4_20_0)
                    {

                        Write_data_to_textBox(data, V4_20_0_textBox);
                    }
                    else
                if (data.param == All_Params.V4_20_1)
                    {

                        Write_data_to_textBox(data, V4_20_1_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_currentA)
                    {

                        Write_data_to_textBox(data, IA_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_currentB)
                    {

                        Write_data_to_textBox(data, IB_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_currentC)
                    {

                        Write_data_to_textBox(data, IC_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_currentD)
                    {

                        Write_data_to_textBox(data, ID_textBox);
                    }
                    else if (data.param == All_Params.time_logic)
                    {

                        Write_data_to_textBox(data, Moto_clock_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_IA_angle)
                    {

                        Write_data_to_textBox(data, angle_IA_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_IB_angle)
                    {

                        Write_data_to_textBox(data, angle_IB_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_IC_angle)
                    {

                        Write_data_to_textBox(data, angle_IC_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_ID_angle)
                    {

                        Write_data_to_textBox(data, angle_ID_textBox);
                    }
                    else if (data.param == All_Params.ADCdata_assymetry)
                    {

                        Write_data_to_textBox(data, assymetry_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL0)
                    {

                        Write_data_to_textBox(data, MUL_0);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL1)
                    {

                        Write_data_to_textBox(data, MUL_1);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL2)
                    {

                        Write_data_to_textBox(data, MUL_2);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL3)
                    {

                        Write_data_to_textBox(data, MUL_3);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL4)
                    {

                        Write_data_to_textBox(data, MUL_4);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL5)
                    {

                        Write_data_to_textBox(data, MUL_5);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL6)
                    {

                        Write_data_to_textBox(data, MUL_6);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL7)
                    {

                        Write_data_to_textBox(data, MUL_7);

                    }
                    else if (data.param == All_Params._FLASH_RATIOS_MUL8)
                    {

                        Write_data_to_textBox(data, MUL_8);
                    }



                    else if (data.param == All_Params._FLASH_RATIOS_GND0)
                    {

                        Write_data_to_textBox(data, GMD_0_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND1)
                    {

                        Write_data_to_textBox(data, GMD_1_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND2)
                    {

                        Write_data_to_textBox(data, GMD_2_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND3)
                    {

                        Write_data_to_textBox(data, GMD_3_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND4)
                    {

                        Write_data_to_textBox(data, GMD_4_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND5)
                    {

                        Write_data_to_textBox(data, GMD_5_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND6)
                    {

                        Write_data_to_textBox(data, GMD_6_textBox);
                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND7)
                    {

                        Write_data_to_textBox(data, GMD_7_textBox);

                    }
                    else if (data.param == All_Params._FLASH_RATIOS_GND8)
                    {

                        Write_data_to_textBox(data, GMD_8_textBox);
                    }
                    else if (data.param == All_Params._FLASH_CURRENT_MUL)
                    {

                        Write_data_to_textBox(data, I_MUL);
                    }
                    else if (data.param == All_Params._FLASH_CT_MUL)
                    {

                        Write_data_to_textBox(data, CT_mul);
                    }
                    else if (data.param == All_Params._FLASH_MIN_CURRENT)
                    {

                        Write_data_to_textBox(data, I_min);
                    }
                    else if (data.param == All_Params._FLASH_NUMBER_BLOK)
                    {

                        Write_data_to_textBox(data, N);
                    }
                    else if (data.param == All_Params._FLASH_RS485_ADDRESS)
                    {

                        Write_data_to_textBox(data, RS_485_addr);
                    }
                    else if (data.param == All_Params._FLASH_RS485_SPEED)
                    {

                        Write_data_to_textBox(data, RS485_speed);
                    }
                        else if (data.param == All_Params._FLASH_PROT_PT100_0_SETPOINT)
                        {

                            if(!PT100_20_0_setpoint_enter) Write_data_to_textBox(data,PT100_20_0_setpoint_textBox);
                        }



                        else if (data.param == All_Params._FLASH_PROT_PT100_1_SETPOINT)
                        {

                            if (!PT100_20_1_setpoint_enter) Write_data_to_textBox(data, PT100_20_1_setpoint_textBox);
                        }
                        else if (data.param == All_Params._FLASH_PROT_PT100_2_SETPOINT)
                        {

                            if (!PT100_20_2_setpoint_enter) Write_data_to_textBox(data, PT100_20_2_setpoint_textBox);
                        }

                        else if (data.param == All_Params._FLASH_WARN_PT100_0_SETPOINT)
                        {

                            if (!PT100_20_0_w_setpoint_enter) Write_data_to_textBox(data, PT100_20_0_warn_setpoint_textBox);
                        }

                        else if (data.param == All_Params._FLASH_WARN_PT100_1_SETPOINT)
                        {

                            if (!PT100_20_1_w_setpoint_enter) Write_data_to_textBox(data, PT100_20_1_warn_setpoint_textBox);
                        }

                        else if (data.param == All_Params._FLASH_WARN_PT100_2_SETPOINT)
                        {

                            if (!PT100_20_2_w_setpoint_enter) Write_data_to_textBox(data, PT100_20_2_warn_setpoint_textBox);
                        }
                    //////////////////////////////

                        else if (data.param == All_Params._LOCK_PT100_0)
                    {
                        if (!locks_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) locks_listBox.Items.Add(data.param);
                        if (locks_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) locks_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._LOCK_PT100_1)
                    {
                        if (!locks_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) locks_listBox.Items.Add(data.param);
                        if (locks_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) locks_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._LOCK_PT100_2)
                    {
                        if (!locks_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) locks_listBox.Items.Add(data.param);
                        if (locks_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) locks_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_0)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_1)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_2)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_V4_20_0)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_V4_20_1)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) 
                                warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) 
                                warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_ERROR_0)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_ERROR_1)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_PT100_ERROR_2)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_V4_20_ERROR_0)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._WARN_V4_20_ERROR_1)
                    {
                        if (!warnings_listBox.Items.Contains(data.param) && ((Data_Carrier_Bool)data).value) 
                                warnings_listBox.Items.Add(data.param);
                        if (warnings_listBox.Items.Contains(data.param) && !((Data_Carrier_Bool)data).value) 
                                warnings_listBox.Items.Remove(data.param);
                    }
                    else if (data.param == All_Params._FLASH_PROT_PT100_0_ENABLE)
                    {
                        PT_100_0_prot_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;
                          
                    }
                        else if (data.param == All_Params._FLASH_PROT_PT100_1_ENABLE)
                        {
                            PT_100_1_prot_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_PROT_PT100_2_ENABLE)
                        {
                            PT_100_2_prot_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_PROT_V4_20_0_ENABLE)
                        {
                           V4_20_0_prot_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_PROT_V4_20_1_ENABLE)
                        {
                            V4_20_1_prot_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }

                        else if (data.param == All_Params._FLASH_WARN_PT100_0_ENABLE)
                        {
                            PT_100_0_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_WARN_PT100_1_ENABLE)
                        {
                            PT_100_1_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_WARN_PT100_2_ENABLE)
                        {
                            PT_100_2_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_WARN_V4_20_0_ENABLE)
                        {
                            V4_20_0_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;


                        }
                        else if (data.param == All_Params._FLASH_WARN_V4_20_1_ENABLE)
                        {
                            V4_20_1_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_ASSYMETRY_ENABLE)
                        {
                            asymmetry_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }
                        else if (data.param == All_Params._FLASH_PROT_WRONG_CON_ENABLE)
                        {
                           wrong_con_warn_enable_checkBox.Checked = ((Data_Carrier_Bool)data).value;

                        }


                    }
            });
        }
        catch{}
        }
        public void Update_Rich_Textbox(int i, List<Data_Carrier_Base> carrier)

        {/*
            try
            {
                if (this != null)
                    this.Invoke((MethodInvoker)delegate
                    {
                        Data_Carrier_Int_List carrier_Int_List;
                        int g;

                        carrier_Int_List = (Data_Carrier_Int_List)carrier.Find(c => c.GetType() == typeof(Data_Carrier_Int_List));
                        g = ((Data_Carrier_Int)carrier.Find(c => c.param == All_Params.id)).value;

                        if (this != null)

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



                        //if (g == 10)
                        //{

                        //    if (!panel_with_fields1.actual)

                        //    {
                        //        Data_Carrier_Container temp_container = new Data_Carrier_Container(carrier_Int_List);
                        //        List<Data_Carrier_Container> booba = new List<Data_Carrier_Container>() { temp_container };
                        //        panel_with_fields1.fields(booba);
                        //    }
                        //    else
                        //    {

                        //        panel_with_fields1.containers.First().field_data = carrier_Int_List;
                        //        panel_with_fields1.containers.First().Display_Current_Data();
                        //    }
                        //}
                    });
            }
            catch { }
           */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ui.Close_All();
        }

        private void Send_Data_button_Click(object sender, EventArgs e)
        {
           
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base>(){ new Data_Carrier_Int { param = All_Params.command, value = 128}, new Data_Carrier_Int_List { param = All_Params.sCurrentAnalogData_avg_adc_value, values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 } } });
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
           /* if (((x + border) * (i + 1) < panel1.Width) && ((y + border) * (j + 1) < panel1.Height))
            {
                panel1.Controls.Add(new Data_Carrier_Container { Location = new Point { X = (x + border) * (i++), Y = (y + border) * j } });
            }
            else if (((x + border) * (i + 1) > panel1.Width) && ((y + border) * (j + 2) < panel1.Height))
            {
                i = 0;

                panel1.Controls.Add(new Data_Carrier_Container { Location = new Point { X = (x + border) * (i++), Y = (y + border) * (++j) } });
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
        bool PT100_20_0_setpoint_enter = false;
        bool PT100_20_1_setpoint_enter = false;
        bool PT100_20_2_setpoint_enter = false;
        bool PT100_20_0_w_setpoint_enter = false;
        bool PT100_20_1_w_setpoint_enter = false;
        bool PT100_20_2_w_setpoint_enter = false;
        bool V4_20_0_setpoint_enter = false;
        bool V4_20_1_setpoint_enter = false;
        bool V4_20_0_w_setpoint_enter = false;
        bool V4_20_1_w_setpoint_enter = false;
        bool as_setpoint_enter = false;
        bool w_setpoint_enter = false;
        private void PT_100_0_enable_checkBox_CheckedChanged(object sender, EventArgs e)
        {
          
           // _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_PT100_0_ENABLE, value = PT_100_0_enable_checkBox.Checked } , new Data_Carrier_Int { param = All_Params.command, value = 103} });
        }

        private void PT_100_0_enable_checkBox_Click(object sender, EventArgs e)
        {
            
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_PT100_0_ENABLE, value = PT_100_0_prot_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void PT_100_1_prot_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_PT100_1_ENABLE, value = PT_100_1_prot_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void PT_100_2_prot_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_PT100_2_ENABLE, value = PT_100_2_prot_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void V4_20_0_prot_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_V4_20_0_ENABLE, value = V4_20_0_prot_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void V4_20_1_prot_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_V4_20_1_ENABLE, value = V4_20_1_prot_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void PT_100_0_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_WARN_PT100_0_ENABLE, value = PT_100_0_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void PT_100_1_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_WARN_PT100_1_ENABLE, value = PT_100_1_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void PT_100_2_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_WARN_PT100_2_ENABLE, value = PT_100_2_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void V4_20_0_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_WARN_V4_20_0_ENABLE, value = V4_20_0_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
        }

        private void V4_20_1_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_WARN_V4_20_1_ENABLE, value = V4_20_1_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });

        }

        private void asymmetry_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_ASSYMETRY_ENABLE, value = asymmetry_warn_enable_checkBox.Checked}, new Data_Carrier_Int { param = All_Params.command, value = 103 } });

        }

        private void wrong_con_warn_enable_checkBox_Click(object sender, EventArgs e)
        {
            _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Bool { param = All_Params._FLASH_PROT_WRONG_CON_ENABLE, value = wrong_con_warn_enable_checkBox.Checked }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });

        }

      
        


        private void PT100_20_0_setpoint_textBox_Enter(object sender, EventArgs e)
        {
            PT100_20_0_setpoint_enter = true;
        
            PT100_20_0_setpoint_button.Visible = true;
        }

        private void PT100_20_0_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_0_setpoint_button.Focused)
            {
               
                PT100_20_0_setpoint_textBox.Text = "";

                PT100_20_0_setpoint_button.Visible = false;
                PT100_20_0_setpoint_enter = false;
            }
        }

        private void PT100_20_1_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_PROT_PT100_1_SETPOINT, value = Convert.ToInt16(PT100_20_1_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
              
                PT100_20_1_setpoint_textBox.Text = "";

                PT100_20_1_setpoint_button.Visible = false;
                PT100_20_1_setpoint_enter = false;
            }
            catch { }
        }

        private void PT100_20_2_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_PROT_PT100_2_SETPOINT, value = Convert.ToInt16(PT100_20_2_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
         
            PT100_20_2_setpoint_textBox.Text = "";

            PT100_20_2_setpoint_button.Visible = false;
                PT100_20_2_setpoint_enter = false;
            }
            catch { }
        }
        private void PT100_20_0_setpoint_button_Click(object sender, EventArgs e)
        {
                try
                {
                    _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_PROT_PT100_0_SETPOINT, value = Convert.ToInt16(PT100_20_0_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
         
            PT100_20_0_setpoint_textBox.Text = "";

            PT100_20_0_setpoint_button.Visible = false;
                PT100_20_0_setpoint_enter = false;
            }
            catch { }
        }

        private void V4_20_0_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_PROT_V4_20_0_SETPOINT, value = Convert.ToInt16(V4_20_0_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
                
                V4_20_0_setpoint_textBox.Text = "";

                V4_20_0_setpoint_button.Visible = false;
                V4_20_0_setpoint_enter = false;
            }
            catch { }
        }

        private void V4_20_1_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_PROT_V4_20_1_SETPOINT, value = Convert.ToInt16(V4_20_1_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
               
                V4_20_1_setpoint_textBox.Text = "";

                V4_20_1_setpoint_button.Visible = false;
                V4_20_1_setpoint_enter = false;
            }
            catch { }
        }

        private void PT100_20_0_warn_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WARN_PT100_0_SETPOINT, value = Convert.ToInt16(PT100_20_0_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
                
                PT100_20_0_warn_setpoint_textBox.Text = "";

                PT100_20_0_warn_setpoint_button.Visible = false;
                PT100_20_0_w_setpoint_enter = false;
            }
            catch { }
        }

        private void PT100_20_1_warn_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WARN_PT100_1_SETPOINT, value = Convert.ToInt16(PT100_20_1_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
                
                PT100_20_1_warn_setpoint_textBox.Text = "";

                PT100_20_1_warn_setpoint_button.Visible = false;
                PT100_20_1_w_setpoint_enter = false;
            }
            catch { }
        }

        private void PT100_20_2_warn_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WARN_PT100_2_SETPOINT, value = Convert.ToInt16(PT100_20_2_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
              
                PT100_20_2_warn_setpoint_textBox.Text = "";

                PT100_20_2_warn_setpoint_button.Visible = false;
                PT100_20_2_w_setpoint_enter = false;
            }
            catch { }
        }

        private void V4_20_0_warn_setpoint_button_Click(object sender, EventArgs e)
        {

            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WARN_V4_20_0_SETPOINT, value = Convert.ToInt16(V4_20_0_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
               
                V4_20_0_warn_setpoint_textBox.Text = "";

                V4_20_0_warn_setpoint_button.Visible = false;
                V4_20_0_w_setpoint_enter = false;
            }
            catch { }
        }

        private void V4_20_1_warn_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WARN_V4_20_1_SETPOINT, value = Convert.ToInt16(V4_20_1_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
              
                V4_20_1_warn_setpoint_textBox.Text = "";

                V4_20_1_warn_setpoint_button.Visible = false;
                V4_20_1_w_setpoint_enter = false;

            }
            catch { }
        }

        private void as_warn_setpoint_button_Click(object sender, EventArgs e)
        {
            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_ASSYMETRY_SETPOINT, value = Convert.ToInt16(assymetry_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
               
                assymetry_textBox.Text = "";

                as_warn_setpoint_button.Visible = false;
                as_setpoint_enter = false;
            }
            catch { }
        }

        private void w_c_warn_setpoint_button_Click(object sender, EventArgs e)
        {

            try
            {
                _ui.Pass_Data_to_Model_from_Interface(new List<Data_Carrier_Base> { new Data_Carrier_Int { param = All_Params._FLASH_WRONG_CON_MAX_CURRENT, value = Convert.ToInt16(w_c_warn_setpoint_textBox.Text) }, new Data_Carrier_Int { param = All_Params.command, value = 103 } });
                
                w_c_warn_setpoint_textBox.Text = "";

                w_c_warn_setpoint_button.Visible = false;
                w_setpoint_enter = false;
            }
            catch { }
        }

        private void PT100_20_1_setpoint_textBox_Enter(object sender, EventArgs e)
        {
          
            PT100_20_1_setpoint_button.Visible = true;
        }

        private void PT100_20_2_setpoint_textBox_Enter(object sender, EventArgs e)
        {
           

            PT100_20_1_setpoint_button.Visible = true;
        }

        private void V4_20_0_setpoint_textBox_Enter(object sender, EventArgs e)
        {
            

            V4_20_0_setpoint_button.Visible = true;
        }

        private void V4_20_1_setpoint_textBox_Enter(object sender, EventArgs e)
        {

          
            V4_20_1_setpoint_button.Visible = true;
        }

        private void PT100_20_0_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
           

            PT100_20_0_warn_setpoint_button.Visible = true;
        }

        private void PT100_20_1_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
           

            PT100_20_1_warn_setpoint_button.Visible = true;
        }

        private void PT100_20_2_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
          

            PT100_20_2_warn_setpoint_button.Visible = true;
        }

        private void V4_20_0_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
            

            V4_20_0_warn_setpoint_button.Visible = true;
        }

        private void V4_20_1_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {

            V4_20_1_warn_setpoint_button.Visible = true;
        }

        private void asymmetry_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
           

            as_warn_setpoint_button.Visible = true;
        }

        private void w_c_warn_setpoint_textBox_Enter(object sender, EventArgs e)
        {
            

            w_c_warn_setpoint_button.Visible = true;
        }

        private void PT100_20_1_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_1_setpoint_button.Focused)
            {
               
                PT100_20_1_setpoint_textBox.Text = "";

                PT100_20_1_setpoint_button.Visible = false;
                PT100_20_1_setpoint_enter = false;
            }
            }

        private void PT100_20_2_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_2_setpoint_button.Focused)
            {
               
                PT100_20_2_setpoint_textBox.Text = "";

                PT100_20_2_setpoint_button.Visible = false;
                PT100_20_2_setpoint_enter = false;
            }
        }

        private void V4_20_0_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!V4_20_0_setpoint_button.Focused)
            {
                  V4_20_0_setpoint_textBox.Text = "";

                V4_20_0_setpoint_button.Visible = false;
                V4_20_0_setpoint_enter = false;
              
            }
            }

        private void V4_20_1_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!V4_20_1_setpoint_button.Focused)
            {
                
                V4_20_1_setpoint_textBox.Text = "";

                V4_20_1_setpoint_button.Visible = false;
                V4_20_1_setpoint_enter = false;

            }
        }

        private void PT100_20_0_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_0_warn_setpoint_button.Focused)
            {
               
                PT100_20_0_warn_setpoint_textBox.Text = "";

                PT100_20_0_warn_setpoint_button.Visible = false;
                PT100_20_0_w_setpoint_enter = false;
            }
        }

        private void PT100_20_1_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_1_warn_setpoint_button.Focused)
            {
               
                PT100_20_1_warn_setpoint_textBox.Text = "";

                PT100_20_1_warn_setpoint_button.Visible = false;
                PT100_20_1_w_setpoint_enter = false;
            }
        }

        private void PT100_20_2_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!PT100_20_2_warn_setpoint_button.Focused)
            {
               
                PT100_20_2_warn_setpoint_textBox.Text = "";

                PT100_20_2_warn_setpoint_button.Visible = false;
                PT100_20_2_w_setpoint_enter = false;
            }
        }

        private void V4_20_0_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!V4_20_0_warn_setpoint_button.Focused)
            {
               
                V4_20_0_warn_setpoint_textBox.Text = "";

                V4_20_0_warn_setpoint_button.Visible = false;
                V4_20_0_w_setpoint_enter = false;
            }
        }

        private void V4_20_1_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!V4_20_1_warn_setpoint_button.Focused)
            {

                V4_20_1_warn_setpoint_textBox.Text = "";

                V4_20_1_warn_setpoint_button.Visible = false;
                V4_20_1_w_setpoint_enter = false;
            }
        }

        private void asymmetry_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {
            if (!as_warn_setpoint_button.Focused)
            {

                asymmetry_warn_setpoint_textBox.Text = "";

                as_warn_setpoint_button.Visible = false;
                as_setpoint_enter = false;
            }
        }

        private void w_c_warn_setpoint_textBox_Leave(object sender, EventArgs e)
        {

            if (!w_c_warn_setpoint_button.Focused)
            {

                w_c_warn_setpoint_textBox.Text = "";

                w_c_warn_setpoint_button.Visible = false;
                w_setpoint_enter = false;
            }
        }

        private void PT100_20_0_setpoint_textBox_TextChanged(object sender, EventArgs e)
        {

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