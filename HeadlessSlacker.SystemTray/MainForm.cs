using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadlessSlacker.SystemTray
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }   
    }
}
