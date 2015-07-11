using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace HeadlessSlacker
{
    public class HeadlessSlack
    {
        void RunTrayIcon()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new SystemTrayForm();
            form.ShowSlackIcon += form_ShowSlackIcon;

            Application.Run(form);
        }

        void form_ShowSlackIcon(object sender, EventArgs e)
        {
            RestoreSlackWindow();
            Application.Exit();
        }

        public void MinimizeSlackToTray()
        {
            IntPtr? handle = GetSlackWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            var taskbar = (ITaskbarList)new CoTaskbarList();
            taskbar.DeleteTab(handle.Value);
            RunTrayIcon();
        }

        public void RestoreSlackWindow()
        {
            IntPtr? handle = GetSlackWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            var taskbar = (ITaskbarList)new CoTaskbarList();
            taskbar.AddTab(handle.Value);
        }

        public void InjectHideJumpListItem()
        {
            IntPtr? handle = GetSlackWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            var jumpList = JumpList.CreateJumpListForIndividualWindow("headless-slacker", handle.Value);

            var category = new JumpListCustomCategory("Tasks");
            string cmdPath = Assembly.GetEntryAssembly().Location;

            var hideCommand = new JumpListLink(cmdPath, "Hide") { Arguments = Arguments.Hide };
            category.AddJumpListItems(hideCommand);

            jumpList.AddCustomCategories(category);
            jumpList.Refresh();
        }

        IntPtr? GetSlackWindowHandleOrNull()
        {
            var slackProcess = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle.EndsWith("- Slack"));
            if (slackProcess == null)
                return null;

            var processTitle = slackProcess.MainWindowTitle;
            return NativeMethods.FindWindow(null, processTitle);
        }
    }
}
