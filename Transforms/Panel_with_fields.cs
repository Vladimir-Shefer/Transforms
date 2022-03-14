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
    public partial class Panel_with_fields : UserControl
    {
        public Panel_with_fields()
        {
            InitializeComponent();

        }
        public bool actual = false;
        public List<Data_Carrier_Container> containers = new List<Data_Carrier_Container>();
        public void fields(List<Data_Carrier_Container> carrier_Containers)
        {
            
            containers = carrier_Containers;
            foreach(var f in containers)
                panel1.Controls.Add(f);
            actual = true;

        }

        private void Panel_with_fields_Load(object sender, EventArgs e)
        {
           
        }
    }
}
