using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public enum enBt { eBtYes , eBtNo};

        public enBt Bt;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtYes_Click(object sender, EventArgs e)
        {
            
            Bt = enBt.eBtYes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bt = enBt.eBtNo;
            this.Close();
        }
    }
}
