using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogicLayer
{
    public interface IBLL
    {
        int AddArticle(string nameOrTitle, string text);
        List<Article> GetArticles();
        List<Article> FindArticlesByText(string keyWord);
        Article GetArticle(int ID);
        int DeleteArticle(int ID);
        int DestroyArticle(int ID);
        int UpdateArticle(int ID, string nameOrTitle, string subject, string text);
    }
}
