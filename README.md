# CaseArticle

•	Projede kullanıldığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?

Veri tabanı erişimi için Repository Pattern kullanıldı. Günün ihtiyaçlarına göre MS SQL veri tabanı ile geliştirilen API’nin gelecekte farklı bir veri tabanını kullanabilmesi ve api katmanının bundan etkilenmemesi için proje bileşenlere ayrıldı.

Yazılım geliştirme süreçlerinde ekip çalışmasının çok faydalı hatta gereklidir. Ekip içindeki üyelerin bir proje üzerinde çalışırken zorlanmadan yapılan işlemleri yorumlayabilmesi hatta ileride geliştiricinin bizzat koda bakarken neler yaptığımı vakit kaybetmeden anlayabilmesi için SOLID prensiplere uygun tasarım yapıldı.

Sıradan CRUD fonksiyonlarına ek fonksiyonlar tanımlandı. Her sınıf ve metodun sadece bir görevi olması amaçlanarak geliştirildi. Örnek verecek olursak API’daki DELETE metodu incelenebilir. Bu metodun “willDestroyed” adında optional bir parametresi vardır. Parametre makaleyi tamamen yok etmek veya her ihtimale karşı veri tabanında saklayarak silinmiş olarak işaretlemenize izin verir. ArticleRepository sınıfında bu iki özellik ayrı şekilde tasarlanmıştır. Tasarlanan ara yüz veya API’larda kullanılabilir.

Open / Closed Principle (OCP) göz önünde bulundurularak geliştirme yapılmıştır. ArticleRepository sınıfı örnek verilebilir. Projeyi incelediğinizde “Undelete” metodu bulunmamaktadır. Gelecekte oluşabilecek ihtiyaçlar için katman içindeki metotlar değişime kapalıdır fakat sınıf gelişime açıktır.
Dependency Inversion Principle uygulanmaya çalışılarak katmanlar arasındaki doğrudan bağımlılık azaltılmaya çalışılmıştır.



•	Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?

İlk kez Web API yazdım. Doğal olarak geliştirme süresinin epey bir kısmını araştırmaya ayırdım. NLog, System.Collections, System.Data.SqlClient ve System.Linq gibi kütüphaneleri hemen hemen her projede kullanıyorum. Aynı şekilde T-SQL tarafında function, view, stored procedur ve karmaşık rapor sorguları konusunda oldukça tecrübeliyim. Çalıştığım pozisyonda tecrübe edindiğim test araçlarından Postman’i de projenin test sürecinde oldukça kullandım.



•	Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?

Daha geniş bir vaktim olsaydı veri modelimi daha karmaşık bir yapıda tasarlardım. API metotlarını authentication ve secret keyler kullanarak güvenliği artırmaya çalışırdım.



•	Eklemek istediğiniz bir yorumunuz var mı?

İlk kez bir API projesi geliştirdiğim için karmaşık veri modellerine ve tasarımdan uzak durup design patternlere önem verip temiz bir kod yazmaya çalıştım.



API Metotları ve Kullanımı


Get() Bir hata oluşmaz ise içerideki tüm makaleleri döner.

Get(int ID) Özel olarak bir makale çağırmanızı sağlar.

Get (string keyWord) Makaleler içinde geçen bir kelime arama yapmanıza olanak verir. Liste döner.

Post(string nameOrTitle, string text) Yeni bir makale oluşturmanızı sağar, tüm parametreler zorunludur.

Put(int ID, string nameOrTitle, string text) Var olan bir makaleyi gencellemenize olanak veirir, tüm parametreler zorunludur.

Delete(int ID, bool willDestroyed = false) Makale silebilirsiniz. Optional olarak yok edebilir veya sadece silinmiş olarak işaretleyebilirsiniz.
