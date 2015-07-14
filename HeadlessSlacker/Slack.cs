using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;
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
            return GetWindowHandleOrNull().HasValue;
        }

        public void Start()
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var slackDirectory = Directory.GetDirectories(localAppData, "*", SearchOption.TopDirectoryOnly).FirstOrDefault(x => x.EndsWith("slack", StringComparison.OrdinalIgnoreCase));
            // todo: handle null reference

            var slackExecutables = Directory.GetFiles(slackDirectory, "slack.exe", SearchOption.AllDirectories);
            var currentSlackExe = slackExecutables.OrderByDescending(x => FileVersionInfo.GetVersionInfo(x).FileVersion).FirstOrDefault();
            // todo: handle null reference

            Process.Start(currentSlackExe);

            while (!IsRunning())
            {
                Task.Delay(3000).Wait();
            }
        }

        public void HideWindow()
        {
            IntPtr? handle = GetWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            WindowsTaskBar.Instance.DeleteTab(handle.Value);
            NativeMethods.ShowWindow(handle.Value, ShowWindowCommands.Minimize);
        }

        public void RestoreWindow()
        {
            IntPtr? handle = GetWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            WindowsTaskBar.Instance.AddTab(handle.Value);
            NativeMethods.ShowWindow(handle.Value, ShowWindowCommands.Restore);
        }

        public void InjectJumpListMenu()
        {
            IntPtr? handle = GetWindowHandleOrNull();
            if (!handle.HasValue)
                return;

            string cmdPath = Assembly.GetEntryAssembly().Location;

            var jumpList = JumpList.CreateJumpListForIndividualWindow("headless-slacker", handle.Value);
            var category = new JumpListCustomCategory("Headless Slack");

            var hideCommand = new JumpListLink(cmdPath, "Hide Taskbar Icon")
            {
                Arguments = "/h",
                IconReference = new IconReference(cmdPath, 0)
            };
            
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
