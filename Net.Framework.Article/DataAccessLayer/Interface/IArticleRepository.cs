﻿using Entities;
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
        int DeleteArticle(int ID);
        int DestroyArticle(int ID);
        int UpdateArticle(int ID, string nameOrTitle, string text);
        bool IfExist(int ID);
    }
}
