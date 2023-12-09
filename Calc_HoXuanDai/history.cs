using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_HoXuanDai
{
    
    public partial class history : Form
    {
        public List<string> lichsuList { get; set; }

        public history()
        {
            InitializeComponent();
            tt_BackToCal.SetToolTip(btnBackCal, "Trở lại tính toán");
        }

        private void history_Load(object sender, EventArgs e)
        {
            foreach(string item in lichsuList)
            {
                lHistory.Items.Add(item);
            }
            textBox1.Enabled = false;
        }
        private void onClick_BacktoCal(object sender, EventArgs e)
        {
            this.Close();
        }
        private void onClick_delHis(object sender, EventArgs e)
        {
            lHistory.Items.Clear();
            lichsuList.Clear();
        }
        private void tt_BackCal_Popup(object sender, PopupEventArgs e)
        {
            
        }
    }
}
