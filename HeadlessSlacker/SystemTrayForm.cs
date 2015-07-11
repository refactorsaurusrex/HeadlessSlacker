using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadlessSlacker
{
    public partial class SystemTrayForm : Form, ISystemTrayForm
    {
        public event EventHandler ShowSlackIcon = delegate { };

        public SystemTrayForm()
        {
            InitializeComponent();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            ShowSlackIcon(this, EventArgs.Empty);
        }
    }
}
