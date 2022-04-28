using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AutoPush
{
    public static class GitAction
    {
        static string gitBranch = @"master";
        static string gitCommand = "git";
        static string gitCheckoutOptions = "-b";
        static string gitAddArgument = @"add -A";
        static string gitCommitArgument = @"commit ""explanations_of_changes""";
        static string gitPushArgument = @$"push origin {gitBranch}";
        static string gitPullArgument = @$"pull origin {gitBranch}";
        static string gitCheckoutArgument = @$"checkout {gitCheckoutOptions} {gitBranch}";

        static int interval = 1000;
        static string gitBranchPrefix = "";

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
