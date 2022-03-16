namespace Transforms
{
    public partial class Data_Carrier_Container : UserControl
    {
        public bool Lock = false;
        public Data_Carrier_Base field_data = new Data_Carrier_Int { param = All_Params.unknown, value = 0 };

        public Data_Carrier_Container()
        {
            InitializeComponent();
        }

        public Data_Carrier_Container(Data_Carrier_Base data)
        {
            InitializeComponent();
            field_data = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display_Current_Data();
        }

        public void Display_Current_Data()
        {
            textBox1.Text = String.Empty;
            if (field_data.GetType() == typeof(Data_Carrier_Int_List))
                lock (field_data)
                {
                    foreach (var data in ((Data_Carrier_Int_List)(field_data)).values)
                        textBox1.Text += Convert.ToString(data) + " ";
                }
            else if (field_data.GetType() == typeof(Data_Carrier_Int))
            {
                textBox1.Text = Convert.ToString(((Data_Carrier_Int)field_data).value);
            }
        }

        private void Data_Carrier_Container_Load(object sender, EventArgs e)
        {
            int f = label1.Width;
            Display_Current_Data();
            label1.Text = field_data.param.ToString();
           float maxSize = 14f;
           
            label1.Font = new Font(label1.Font.FontFamily, maxSize, label1.Font.Style);
            while (label1.Width > textBox1.Location.X- label1.Location.X)
            {
                label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 0.5f, label1.Font.Style);
            }
        }
    }
}