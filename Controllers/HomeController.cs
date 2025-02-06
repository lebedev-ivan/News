using Microsoft.AspNetCore.Mvc;
using News.Domain;
using News.Models;
using System.Diagnostics;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticlesRepository articlesRepository;
        public HomeController(ArticlesRepository articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        public IActionResult Index()
        {
            var model = articlesRepository.GetArticles();
            return View(model);
        }

        public IActionResult ArticlesEdit(Guid Id)
        {
            Article model = Id == default ? new Article() : articlesRepository.GetArticleById(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult ArticlesEdit(Article model)
        {
            if (ModelState.IsValid)
            {
                articlesRepository.SaveArticle(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ArticlesDelete(Guid id)
        {
            articlesRepository.DeleteArticle(new Article {Id = id});
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
