using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutoPush
{
    public static class GitCommand
    {
        private static string gitBranch = @"master";
        private static string gitCheckoutOptions = "-b";
        private static string gitAddArgument = @"add .";
        private static string gitMessage = string.Concat(DateTime.Now.ToLongDateString(), "-", DateTime.Now.ToLongTimeString(), "_via_AutoPush");
        private static string gitCommitArgument = @$"commit -m ""{gitMessage}""";
        private static string gitPushArgument = @$"push origin {gitBranch}";
        private static string gitPullArgument = @$"pull origin {gitBranch}";
        private static string gitCheckoutArgument = @$"checkout {gitCheckoutOptions} {gitBranch}";
        private static string gitCheckArgument = @"git ls-remote https://github.com/rkbbd/AutoPush";

        static int interval = 1000;
        static string gitBranchPrefix = string.Empty;

        public static string rootPath = string.Empty;
        private static ProcessStartInfo startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            FileName = "git.exe",
            Arguments = "status",
            WorkingDirectory = rootPath
        };

        public static bool isGit()
        {
            startInfo.Arguments = gitCheckArgument;
            var process = Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd();
            return output.Trim().ToLower().Contains("true");
        }
        public static KeyValuePair<bool, object> Start()
        {
            try
            {
                startInfo.WorkingDirectory = rootPath;
                _add();
                _commit();
                _push();
                return new KeyValuePair<bool, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, object>(true, ex); ;
            }
        }

        public static KeyValuePair<bool, object> Start(string pullFrom, string pushTo)
        {
            startInfo.WorkingDirectory = rootPath;
            gitCheckoutOptions = "";
            _checkout();
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = string.IsNullOrWhiteSpace(pushTo) ? gitBranch : pushTo;
            return Start();
        }

        public static KeyValuePair<bool, object> Start(string newBranchName, string pullFrom = "", string format = "")
        {
            startInfo.WorkingDirectory = rootPath;
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = newBranchName;
            _checkout();
            return Start();
        }

        private static string _execute()
        {
            var process = Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
        private static string _add()
        {
            startInfo.Arguments = gitAddArgument;
            return _execute();
        }
        private static string _commit()
        {
            startInfo.Arguments = gitCommitArgument;
            return _execute();
        }
        private static string _push()
        {
            startInfo.Arguments = gitPushArgument;
            return _execute();
        }
        private static string _checkout(string b = "")
        {
            gitCheckoutOptions = string.IsNullOrWhiteSpace(b) ? gitCheckoutArgument : b;
            startInfo.Arguments = gitCheckoutArgument;
            return _execute();
        }
        private static string _pull()
        {
            startInfo.Arguments = gitPullArgument;
            return _execute();
        }
    }
}
