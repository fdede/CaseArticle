using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IArticleRepository
    {
        int AddArticle(Article article);
        List<Article> GetArticles();
        List<Article> FindArticlesByText(string keyWord);
        Article GetArticle(int ID);
        void DeleteArticle(int ID);
        void DestroyArticle(int ID);
        void UpdateArticle(int ID, string nameOrTitle, string subject, string text);
    }
}
