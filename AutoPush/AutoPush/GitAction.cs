using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AutoPush
{
    public static class GitAction
    {
        private static string gitBranch = @"master";
        private static string gitCommand = "git";
        private static string gitCheckoutOptions = "-b";
        private static string gitAddArgument = @"add -A";
        private static string gitCommitArgument = @"commit ""explanations_of_changes""";
        private static string gitPushArgument = @$"push origin {gitBranch}";
        private static string gitPullArgument = @$"pull origin {gitBranch}";
        private static string gitCheckoutArgument = @$"checkout {gitCheckoutOptions} {gitBranch}";

        static int interval = 1000;
        static string gitBranchPrefix = "";


       public static bool isGit()
        {
             Process.Start("git", @"rev-parse");
           return true;
        }
        public static KeyValuePair<bool,object> AutoPush()
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

        public static KeyValuePair<bool, object> AutoPush(string pullFrom, string pushTo)
        {
            gitCheckoutOptions = "";
            _checkout();
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = string.IsNullOrWhiteSpace(pushTo) ? gitBranch :pushTo;
            return AutoPush();
        }

        public static KeyValuePair<bool, object> AutoPush(string newBranchName, string pullFrom = "", string format = "")
        {
            gitBranch = string.IsNullOrWhiteSpace(pullFrom) ? gitBranch : pullFrom;
            _pull();
            gitBranch = newBranchName;
            _checkout();
            return AutoPush();
        }

        private static void _add()
        {
            Process.Start(gitCommand, gitAddArgument);
        }
        private static void _commit()
        {
            Process.Start(gitCommand, gitCommitArgument);
        }
        private static void _push()
        {
            Process.Start(gitCommand, gitPushArgument);
        }
        private static void _checkout(string b= "")
        {
            gitCheckoutOptions = string.IsNullOrWhiteSpace(b) ? gitCheckoutArgument : b;
            Process.Start(gitCommand, gitCheckoutArgument);
        }
        private static void _pull()
        {
            Process.Start(gitCommand, gitPullArgument);
        }

    }
}
