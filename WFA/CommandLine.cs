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
        private static string cmdexe => "CMD.exe";
        // For Executing CMD comands

        public static void executeCommand(string command)
        {
            executeCommand(command, cmdexe);
        }
        public static void executeCommand(string command, string filename)
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
        }

        public static string getCommandOutput(string command)
        {
            return getCommandOutput(command, cmdexe);
        }
        public static string getCommandOutput(string command, string filename)
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "wmic.exe";
            p.StartInfo.Arguments = "nic get name, index, NetConnectionID, netenabled";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }
    }
}
