using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Repository;
using Entities;

namespace ArticleWebApplication.Controllers
{
    public class ArticlesController : ApiController
    {
        ArticleRepository repository = new ArticleRepository();
        List<Article> articles;
        Article article;
        int returnValue;

        public IHttpActionResult Get()
        {
            articles = repository.GetArticles();

            if (articles.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(articles);
            }
        }

        public IHttpActionResult Get(int ID)
        {
            if (repository.IfExist(ID))
            {
                article = repository.GetArticle(ID);
                return Ok(article);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Get (string keyWord)
        {
            if (keyWord == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                articles = repository.FindArticlesByText(keyWord);

                if (articles.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(articles);
                }
            }
        }

        [HttpPost]
        public IHttpActionResult Post(string nameOrTitle, string text)
        {
            if (nameOrTitle != null && text != null)
            {
                article = new Article() 
                { 
                    NameOrTitle = nameOrTitle, 
                    Text = text 
                };

                returnValue = repository.AddArticle(article);
                return CreatedAtRoute("DefaultApi", new { ID = returnValue }, article);
            }
            else
            {
                return BadRequest("Incorrect parameter");
            }
        }

        public IHttpActionResult Put(int ID, string nameOrTitle, string text)
        {
            if (ID == 0 || nameOrTitle == null || text == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (repository.IfExist(ID))
                {
                    repository.UpdateArticle(ID, nameOrTitle, text);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        public IHttpActionResult Delete(int ID, bool willDestroyed = false)
        {
            if (repository.IfExist(ID))
            {
                if (willDestroyed)
                {
                    repository.DestroyArticle(ID);
                    return Ok();
                }
                else
                {
                    repository.DeleteArticle(ID);
                    return Ok();
                }
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
