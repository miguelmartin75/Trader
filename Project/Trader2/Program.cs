using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trader
{
    static class Program
    {
        public static string Comment = "#";


        public static bool IsComment(string line)
        {
            return (line.Length < Comment.Length || line.Substring(0, Program.Comment.Length) == Program.Comment);
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
