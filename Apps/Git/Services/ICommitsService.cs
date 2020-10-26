using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        string Create(string description, string userId, string repoId);
    }
}
