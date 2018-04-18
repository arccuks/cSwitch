using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    public static class CommandLine
    {
        // For Executing CMD comands
        public static void executeCommand(string command, string filename = "CMD.exe")
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = command;
            p.Start();

            //Process.Start("CMD.exe", command);
        }
    }
}
