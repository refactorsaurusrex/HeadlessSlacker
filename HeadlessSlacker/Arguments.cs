using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadlessSlacker
{
    public static class Arguments
    {
        public static string Hide
        {
            get { return "/h"; }
        }

        public static string Show
        {
            get { return "/s"; }
        }

        //public static Argument Hide
        //{
        //    get { return new Argument("Hide", "/h"); }
        //}
    }

    //public class Argument
    //{
    //    public Argument(string displayText, string command)
    //    {
    //        DisplayText = displayText;
    //        Command = command;
    //    }

    //    public string DisplayText { get; private set; }

    //    public string Command { get; private set; }
    //}
}
