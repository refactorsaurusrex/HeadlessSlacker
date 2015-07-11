using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var options = result.Value;

            var headlessSlack = new HeadlessSlack();
            if (options.Hide)
            {
                headlessSlack.MinimizeSlackToTray();
            }
            else if (options.Show)
            {
                headlessSlack.RestoreSlackWindow();
            }
            else if (options.InjectJumpList)
            {
                headlessSlack.InjectHideJumpListItem();
            }
        }
    }
}
