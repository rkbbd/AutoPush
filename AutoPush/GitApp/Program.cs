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
                projpath = new Uri(Path.Combine(new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\" })).AbsolutePath;
            else
                projpath = System.AppDomain.CurrentDomain.BaseDirectory;

            GitCommand.rootPath = projpath;

            var m = GitCommand.isGit();

        }
    }
}
