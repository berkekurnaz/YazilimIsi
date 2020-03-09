using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class BlogManager : IBlogService
    {

        private IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAllBlogArticles()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAllBlogArticlesByCategory(string category)
        {
            if (category == "Yazilim")
            {
                return _blogDal.GetAll(x => x.Category == "Yazilim");
            }
            else if(category == "Isveren")
            {
                return _blogDal.GetAll(x => x.Category == "Isveren");
            }
            else
            {
                return _blogDal.GetAll();
            }
        }

        public Blog GetBlogById(int Id)
        {
            return _blogDal.Get(x => x.Id == Id);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
