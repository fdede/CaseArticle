using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Entities;

namespace BusinessLogicLayer
{
    public class BLL : IBLL
    {
        int returnValue;
        ArticleRepository repository;

        public BLL()
        {
            repository = new ArticleRepository();
        }

        public int AddArticle(string nameOrTitle, string text)
        {
            return repository.AddArticle(new Article()
            {
                NameOrTitle = nameOrTitle,
                Text = text
            });
        }

        public int DeleteArticle(int ID)
        {
            throw new NotImplementedException();
        }

        public int DestroyArticle(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Article> FindArticlesByText(string keyWord)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticles()
        {
            throw new NotImplementedException();
        }

        public int UpdateArticle(int ID, string nameOrTitle, string subject, string text)
        {
            throw new NotImplementedException();
        }
    }
}
