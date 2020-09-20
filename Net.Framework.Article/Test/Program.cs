using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Entities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticleRepository repository = new ArticleRepository();
            int returnValue;

            #region create
            //repository.AddArticle(new Article()
            //{
            //    NameOrTitle = "İlk Test Makale",
            //    Text = "Makale tipindeki bir nesnenin veri tabanına kaydedilmesi, güncellenmesi veya silinmesi gibi işlemlerden sorumlu olan sınıf ArticleRepository sınıfıdır."
            //});

            //repository.AddArticle(new Article()
            //{
            //    NameOrTitle = "1. Single Responsibility Principle (SRP)",
            //    Text = "Her sınıfın veya metodun tek bir sorumluluğu olmalı."
            //});

            //repository.AddArticle(new Article()
            //{
            //    NameOrTitle = "2. Open / Closed Principle (OCP)",
            //    Text = "Sınıflar değişikliğe kapalı ancak gelişime açık olmalıdır. Örnek olarak db log işlemlerinde enum yerine interface kullanarak sınıfları hem değişikliğe kapalı hem de gelişime açık tasarlamış oluruz."
            //});
            #endregion

            #region destroy
            //repository.DestroyArticle(3);
            #endregion

            #region delete
            //repository.DeleteArticle(3);
            #endregion

            #region update
            //returnValue = repository.UpdateArticle(5, "name", "text");
            //Console.WriteLine(returnValue);
            //Console.ReadLine();
            #endregion

            #region Find
            //List<Article> articles = repository.FindArticlesByText("Makale");
            //Console.WriteLine(articles.Count);
            //Console.ReadLine();
            #endregion

            #region List
            //List<Article> articles = repository.GetArticles();
            //Console.WriteLine(articles.Count);
            #endregion

        }
    }
}
