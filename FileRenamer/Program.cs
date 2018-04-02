using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <2 )
            {
                Console.WriteLine("Usage: FileRenamer.exe {suffix} {dir} ");
                return;
            }
            var suffix = args[0];
            var dir = args[1];

            var dirInfo = new DirectoryInfo(dir);
            foreach (var file in dirInfo.GetFiles("*"+suffix+".*")) {
                var newName = file.DirectoryName+Path.DirectorySeparatorChar;
                newName += suffix + file.Name.Replace(suffix, "");
                Console.WriteLine(String.Format("Rename: {0} to {1}", file.FullName, newName));
                File.Move(file.FullName, newName);
            }

        }
    }
}
