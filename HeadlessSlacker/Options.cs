using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace HeadlessSlacker
{
    public class Options
    {
        [Option('s', longName: "show")]
        public bool Show { get; set; }

        [Option('h', longName: "hide")]
        public bool Hide { get; set; }

        [Option('i', longName: "inject")]
        public bool InjectJumpList { get; set; }
    }
}
