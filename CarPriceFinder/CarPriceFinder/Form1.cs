using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarPriceFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'honestRalphsUsedCarsDataSet.tblCars' table. You can move, or remove it, as needed.
            this.tblCarsTableAdapter.Fill(this.honestRalphsUsedCarsDataSet.tblCars);

            var Cars =
                from c in this.honestRalphsUsedCarsDataSet.tblCars
                group c by c.Make;

            foreach (var group in Cars)
            {
                foreach (var c in group)
                {
                    checkedListBox1.Items.Add(c.ModelYear + " - " + c.Make + " - " + c.Color);
                    foreach(var g in group)
                    {
                        label1.Text = "Price is: " + c.Price;
                    }
                    
                }
            }
            
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //can only check one car at time
            if (e.NewValue == CheckState.Checked)
                for (int x = 0; x < checkedListBox1.Items.Count; ++x)
                    if (e.Index != x)
                        checkedListBox1.SetItemChecked(x, false);

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
