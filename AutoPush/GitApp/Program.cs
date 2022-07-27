using AutoPush;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace GitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var projpath = "";
            if (System.Diagnostics.Debugger.IsAttached)
                projpath = new Uri(Path.Combine(new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "..\\.." })).AbsolutePath;
            else
                projpath = System.AppDomain.CurrentDomain.BaseDirectory;

            GitCommand.rootPath = "D:/project/";

            var m = GitCommand.isGit();

           
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var path2 = System.AppDomain.CurrentDomain.BaseDirectory;
            //var path3 = System.Environment.CurrentDirectory;

            //var projpath = "";
            //if (System.Diagnostics.Debugger.IsAttached)
            //    projpath = new Uri(Path.Combine(new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "..\\.." })).AbsolutePath;
            //else
            //    projpath = System.AppDomain.CurrentDomain.BaseDirectory;


            //var startInfo = new System.Diagnostics.ProcessStartInfo
            //{
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true,
            //    FileName = "git.exe",
            //    Arguments = "status",
            //    WorkingDirectory = projpath
            //};
            //var process = System.Diagnostics.Process.Start(startInfo);

            //string output = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            //process.WaitForExit();
        }
    }
}
