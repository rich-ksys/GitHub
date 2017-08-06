using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Component", 150);
            listView1.Columns.Add("Price", 80);
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {

            string[] components = new string[5];
            float[] prices = new float[5];
            string[] cells = new string[2];
            int px = 0;
            ListViewItem lvitem;

            components[0] = "capacitor 10mf";
            components[1] = "resistor 100k";
            components[2] = "led yellow";
            components[3] = "led red";
            components[4] = "jump lead";

            prices[0] = 0.5F;
            prices[1] = 0.12F;
            prices[2] = 0.25F;
            prices[3] = 0.25F;
            prices[4] = 0.1F;

            px = 0;
            // populate list view
            foreach (string sc in components)
            {
                cells[0] = sc;
                cells[1] = prices[px].ToString();
                lvitem = new ListViewItem(cells);
                listView1.Items.Add(lvitem);
                px++;
            }  

        }
    }
}
