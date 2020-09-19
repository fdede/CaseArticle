using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using Entities;
using DataAccessLayer.DataBase;

namespace DataAccessLayer.Repository
{
    class ArticleRepository : GlobalTransactions, IArticleRepository
    {
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValue;
        DataBase.DataAccessLayer DAL;

        public ArticleRepository()
        {
            DAL = new DataBase.DataAccessLayer();
        }

        public int AddArticle(Article article)
        {
            TryIt(() => 
            {
                cmd = new SqlCommand("AddArticle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NameOrTitle", SqlDbType.NVarChar).Value = article.NameOrTitle;
                cmd.Parameters.Add("@Text", SqlDbType.NVarChar).Value = article.Text;
                ReturnValue = DAL.Run(cmd);
            });

            return ReturnValue;
        }

        public void DeleteArticle(int ID)
        {
            TryIt(() =>
            {
                cmd = new SqlCommand("DeleteArticle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                DAL.Run(cmd);
            });
        }

        public void DestroyArticle(int ID)
        {
            TryIt(() =>
            {
                cmd = new SqlCommand("DestroyArticle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                DAL.Run(cmd);
            });
        }

        public List<Article> FindArticlesByText(string keyWord)
        {
            List<Article> articles = new List<Article>();
            TryIt(() =>
            {
                cmd = new SqlCommand("FindArticlesByText");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@KeyWord", SqlDbType.NVarChar).Value = keyWord;
                reader = DAL.GetData(cmd);
                while (reader.Read())
                {
                    articles.Add(new Article()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        NameOrTitle = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        CreatedDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                        LastModifiedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        Deleted = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        DeletedDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6)
                    });
                }
                reader.Close();
                DAL.con.Close();
            });

            return articles;
        }

        public Article GetArticle(int ID)
        {
            Article article = new Article();
            TryIt(() =>
            {
                cmd = new SqlCommand("GetArticle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                reader = DAL.GetData(cmd);
                while (reader.Read())
                {
                    article = new Article()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        NameOrTitle = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        CreatedDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                        LastModifiedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        Deleted = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        DeletedDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6)
                    };
                }
                reader.Close();
                DAL.con.Close();
            });

            return article;
        }

        public List<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();
            TryIt(() => 
            {
                cmd = new SqlCommand("GetArticles");
                cmd.CommandType = CommandType.StoredProcedure;
                reader = DAL.GetData(cmd);
                while (reader.Read())
                {
                    articles.Add(new Article() 
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        NameOrTitle = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        CreatedDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                        LastModifiedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        Deleted = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        DeletedDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6)
                    });
                }
                reader.Close();
                DAL.con.Close();
            });

            return articles;
        }

        public void UpdateArticle(int ID, string nameOrTitle, string subject, string text)
        {
            TryIt(() =>
            {
                cmd = new SqlCommand("UpdateArticle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@NameOrTitle", SqlDbType.NVarChar).Value = nameOrTitle;
                cmd.Parameters.Add("@Text", SqlDbType.NVarChar).Value = text;
                DAL.Run(cmd);
            });
        }
    }
}
