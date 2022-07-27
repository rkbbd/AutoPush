using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutoPush
{
    public static class GitCommand
    {
        private static string gitBranch = @"master";
        private static string gitCommand = "git";
        private static string gitCheckoutOptions = "-b";
        private static string gitAddArgument = @"add -A";
        private static string gitCommitArgument = @"commit ""explanations_of_changes""";
        private static string gitPushArgument = @$"push origin {gitBranch}";
        private static string gitPullArgument = @$"pull origin {gitBranch}";
        private static string gitCheckoutArgument = @$"checkout {gitCheckoutOptions} {gitBranch}";
        private static string gitCheckArgument = @"rev-parse";

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
            //startInfo.Arguments = gitCheckArgument;
            var process = Process.Start(startInfo);
            var output = _output(process);
            return output.Trim().ToLower().Contains("true");
        }
        public static KeyValuePair<bool, object> Start()
        {
            try
            {
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
            gitCheckoutOptions = "";
            _checkout();
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = string.IsNullOrWhiteSpace(pushTo) ? gitBranch : pushTo;
            return Start();
        }

        public static KeyValuePair<bool, object> Start(string newBranchName, string pullFrom = "", string format = "")
        {
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = newBranchName;
            _checkout();
            return Start();
        }

        private static string _output(Process process)
        {
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
        private static Process _add()
        {
             startInfo.Arguments  = gitAddArgument;
            return Process.Start(startInfo);
        }
        private static Process _commit()
        {
             startInfo.Arguments  = gitCommitArgument;
            return Process.Start(startInfo);
        }
        private static Process _push()
        {
             startInfo.Arguments  = gitPushArgument;
            return Process.Start(startInfo);
        }
        private static Process _checkout(string b = "")
        {
            gitCheckoutOptions = string.IsNullOrWhiteSpace(b) ? gitCheckoutArgument : b;
             startInfo.Arguments  = gitCheckoutArgument;
            return Process.Start(startInfo);
        }
        private static Process _pull()
        {
             startInfo.Arguments  = gitPullArgument;
            return Process.Start(startInfo);
        }
    }
}
