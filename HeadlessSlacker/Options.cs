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
        [Option('h', longName: "hide")]
        public bool Hide { get; set; }
    }
}
