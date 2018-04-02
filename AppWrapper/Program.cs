using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("test.bat");
            p.StartInfo.Arguments = "src/";
            //p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            Log(output);
            string err = p.StandardError.ReadToEnd();
            Log(err);
            p.WaitForExit();

            
        }
        static void Log(string s)
        {
            Console.WriteLine(s);

        }

    }
}
