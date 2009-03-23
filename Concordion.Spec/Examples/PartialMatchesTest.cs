﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concordion.Integration;

namespace Concordion.Spec.Examples
{
    public class PartialMatchesTest
    {
        private List<string> usernamesInSystem = new List<string>();

        public void SetUpUser(string username)
        {
            usernamesInSystem.Add(username);
        }

        public List<string> GetSearchResultsFor(string searchString) 
        {
            var matchSet = new List<string>();

            var matches = from username in usernamesInSystem
                          where username.Contains(searchString)
                          select username;

            foreach (string match in matches)
            {
                matchSet.Add(match);
            }

            return matchSet;
        }
    }
}
