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
            else
            {
                if (!Slack.Instance.IsRunning())
                    Slack.Instance.Start();

                Slack.Instance.InjectJumpListMenu();
            }
        }
    }
}
