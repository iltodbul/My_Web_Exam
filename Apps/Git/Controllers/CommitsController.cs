using System;
using System.Collections.Generic;
using System.Text;
using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create(string repoId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repoName = repositoriesService.GetNameById(repoId);
            var model = new CreateCommitViewModel(){Id = repoId, Name = repoName};
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 3)
            {
                return this.Error("Description should be more then 3 characters");
            }

            this.commitsService.Create(description, this.GetUserId(), id);
            return this.Redirect("/Repositories/All");
        }
    }
}
