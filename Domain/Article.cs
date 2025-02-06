using System.ComponentModel.DataAnnotations;

namespace News.Domain
{
    public class Article
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Title { get; set; } //Название статьи
        
        public string Text { get; set; } //Содержание статьи

    }
}
