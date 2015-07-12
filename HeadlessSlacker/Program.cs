using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;

namespace HeadlessSlacker
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);
            if (result.Errors.Any())
                return; // todo: log errors

            // 1) If Slack isn't started, start it and inject menu
            // 2) If Slack is started, inject jump menu
            // 3) If /h is passed, hide Slack and run the @ tray icon
            // 4) When tray icon is clicked, show Slack and end @ icon

            Options options = result.Value;

            if (options.Hide)
            {
                Slack.Instance.HideWindow();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var form = new SystemTrayForm();
                form.ShowSlackIcon += (s, e) =>
                {
                    Slack.Instance.RestoreWindow();
                    Application.Exit();
                };

                Application.Run(form);
            }
            else if (options.Show)
            {
                Slack.Instance.RestoreWindow();
            }
            else if (options.InjectJumpList)
            {
                if (!Slack.Instance.IsRunning())
                {
                    Process slackProcess = Slack.Instance.Start();
                    slackProcess.WaitForInputIdle(30000);
                }

                Slack.Instance.InjectJumpListMenu();
            }
        }
    }
}
