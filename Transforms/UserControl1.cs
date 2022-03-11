using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transforms
{
    public partial class Data_Carrier_Container : UserControl
    {

        public Data_Carrier_Base field_data;
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

        }
    }
}
