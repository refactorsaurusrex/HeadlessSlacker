using System;
using System.Collections.Generic;
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

            Options options = result.Value;

            if (options.Hide)
            {
                if (!Slack.Instance.IsRunning())
                    return;

                Slack.Instance.HideWindow();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var form = new SystemTrayForm();
                form.ShowSlackIcon += form_ShowSlackIcon;
                Application.Run(form);
            }
            else
            {
                if (!Slack.Instance.IsRunning())
                    Slack.Instance.Start();

                Slack.Instance.InjectJumpListMenu();
            }
        }

        static void form_ShowSlackIcon(object sender, EventArgs e)
        {
            if (Slack.Instance.IsRunning())
            {
                Slack.Instance.RestoreWindow();
            }
            else
            {
                Slack.Instance.Start();
                Slack.Instance.InjectJumpListMenu();
            }

            Application.Exit();
        }
    }
}
