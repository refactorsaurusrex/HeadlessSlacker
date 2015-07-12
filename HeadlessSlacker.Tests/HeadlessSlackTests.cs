using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HeadlessSlacker.Tests
{
    [TestFixture]
    public class HeadlessSlackTests
    {
        [Test]
        public void Blah()
        {
            var blah = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
    }
}
