using System;
using System.Collections.Generic;
using System.Text;
using Git.Data;
using Git.Models;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommitsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public string Create(string description, string userId, string repoId)
        {
            var entity = new Commit()
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repoId,
            };

            this.dbContext.Commits.Add(entity);
            this.dbContext.SaveChanges();

            return entity?.Id;
        }
    }
}
