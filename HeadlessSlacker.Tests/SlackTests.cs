using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HeadlessSlacker.Tests
{
    [TestFixture]
    public class SlackTests
    {
        [Test, Category("SideEffects")]
        public void HideWindow()
        {
            Slack.Instance.HideWindow();
        }

        [Test, Category("SideEffects")]
        public void InjectHideWindowJumpListIntoSlackTaskbarMenu()
        {
            Slack.Instance.InjectJumpListMenu();
        }
    }
}
