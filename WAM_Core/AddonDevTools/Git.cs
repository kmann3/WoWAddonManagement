// File: Git.cs - 7/14/2018
// Author: Kennith Mann
// (C) Kennith Mann
using System;
using System.Collections;
using System.Collections.Generic;
using LibGit2Sharp;

namespace WAM_Core.AddonDevTools
{
    public class Git
    {
        public static void CreateRepositoryOnGitHub(string gitUrl, List<string> tags, string username, string password) 
        {
            
        }

        /// <summary>
        /// Updates the repository.
        /// Note: If you enable 2fa then you won't be able to use HTTPS without a personal token.
        /// </summary>
        /// <param name="gitUrl">Git / Repo location.</param>
        /// <param name="comment">Comment for commit message.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password. Could also be the personal token created if 2fa enabled.</param>
        public static void UpdateRepository(string gitUrl, string comment, string username, string password)
        {
            
        }

        /// <summary>
        /// Sends the pull request.
        /// User made a change to a repo and is offering it up to the maintainer.
        /// AKA bug patch.
        /// </summary>
        /// <param name="gitUrl">Git / Repo location.</param>
        /// <param name="comment">Comment.</param>
        public static void SendPullPortRequest(string gitUrl, string comment) 
        {
            //using (var repo = new Repository(addonPath)) 
            var repo = new Repository(null);
            //repo.Network.Push()
        }
    }
}
