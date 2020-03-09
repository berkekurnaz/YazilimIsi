using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogArticles();
        List<Blog> GetAllBlogArticlesByCategory(string category);
        Blog GetBlogById(int Id);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
    }
}
