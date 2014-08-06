using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiTextMaker
{
    public partial class WinMidiTextMaker : Form
    {
        DAndDSizeChanger sizeChanger;

        public WinMidiTextMaker()
        {
            InitializeComponent();
        }

        private void WinMidiTextMaker_Load(object sender, EventArgs e)
        {
            sizeChanger = new DAndDSizeChanger(this.dAndDMoveTextBox1, this, DAndDArea.All, 8);
        }

        private void textBox1_DAndDMoving(object sender, DAndDMovingEventArgs e)
        {
            e.Cancel = sizeChanger.ContainsSizeChangeArea(e.Location);
        }

        private void dAndDMoveTextBox1_DAndDMoving(object sender, DAndDMovingEventArgs e)
        {
            e.Cancel = sizeChanger.ContainsSizeChangeArea(e.Location);
        }
    }
}
