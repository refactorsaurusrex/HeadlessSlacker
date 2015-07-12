using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace HeadlessSlacker
{
    public class Slack
    {
        static readonly Lazy<Slack> instance = new Lazy<Slack>(() => new Slack());

        public static Slack Instance
        {
            get { return instance.Value; }
        }

        Slack() { }

        public bool IsRunning()
        {
            return !GetWindowHandleOrNull().HasValue;
        }

        public Process Start()
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var slackDirectory = Directory.GetDirectories(localAppData, "*", SearchOption.TopDirectoryOnly).FirstOrDefault(x => x.Equals("slack", StringComparison.OrdinalIgnoreCase));
            // todo: handle null reference

            var slackExecutables = Directory.GetFiles(slackDirectory, "slack.exe", SearchOption.AllDirectories);
            var currentSlackExe = slackExecutables.OrderByDescending(FileVersionInfo.GetVersionInfo).FirstOrDefault();
            // todo: handle null reference

            return Process.Start(currentSlackExe);
        }

        public void HideWindow()
        {
            IntPtr? handle = GetWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            var taskbar = (ITaskbarList)new CoTaskbarList();
            taskbar.DeleteTab(handle.Value);
        }

        public void RestoreWindow()
        {
            IntPtr? handle = GetWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            var taskbar = (ITaskbarList)new CoTaskbarList();
            taskbar.AddTab(handle.Value);
        }

        public void InjectJumpListMenu()
        {
            IntPtr? handle = GetWindowHandleOrNull();
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

        IntPtr? GetWindowHandleOrNull()
        {
            var slackProcess = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle.EndsWith("- Slack"));
            if (slackProcess == null)
                return null;

            var processTitle = slackProcess.MainWindowTitle;
            return NativeMethods.FindWindow(null, processTitle);
        }
    }
}
