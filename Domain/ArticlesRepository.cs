using Microsoft.EntityFrameworkCore;

namespace News.Domain
{
    public class ArticlesRepository
    {
        private readonly ArticlesDbContext context;

        public ArticlesRepository(ArticlesDbContext context)
        {
            this .context = context;
        }

        public IQueryable<Article> GetArticles()
        {
            return context.Articles.OrderBy(x => x.Title);
        }//список новостей по новизне

        public Article GetArticleById(Guid id)
        {
            return context.Articles.Single(x => x.Id == id);
        }//выбиаем запись по Id

        public Guid SaveArticle(Article entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }//проверка, новая ли статья(добавляем/обновляем)

        public void DeleteArticle(Article entity)
        {
            context.Articles.Remove(entity);
            context.SaveChanges();
        }//удаляем статью
    }
}
