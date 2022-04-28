using System;
using System.Diagnostics;

namespace AutoPush
{
    public static class GitAction
    {
        static string gitBranch = @"master";
        static string gitCommand = "git";
        static string gitAddArgument = @"add -A";
        static string gitCommitArgument = @"commit ""explanations_of_changes""";
        static string gitPushArgument = @$"push {gitBranch}";
        static string gitPullArgument = @$"pull {gitBranch}";

        public static bool AutoPush()
        {
            try
            {
                _add();
                _commit();
                _push();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
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

        private static void _pull()
        {
            Process.Start(gitCommand, gitPullArgument);
        }

    }
}
