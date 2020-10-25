using System;
using System.Collections.Generic;
using System.Text;
using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryCreateInputModel inputModel)
        {
            //TODO check
            var userId = this.GetUserId();
            this.repositoriesService.Create(inputModel.Name, inputModel.RepositoryType, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var repositories = repositoriesService.GetAll();

            return this.View();
        }
    }
}
