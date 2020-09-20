Create Database CaseArticle
go
use CaseArticle
go

create table Article
(
	ID int identity(1, 1) primary key,
	NameOrTitle nvarchar(100),
	Text nvarchar(max),
	CreatedDate Datetime,
	LastModifiedDate Datetime,
	Deleted bit,
	DeletedDate Datetime
)
go

insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Case Article', 'Makale tipindeki bir nesnenin veri tabanýna kaydedilmesi, güncellenmesi veya silinmesi gibi iþlemlerden sorumlu olan sýnýf ArticleRepository sýnýfýdýr.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Single Responsibility Principle (SRP)', 'Her sýnýfýn veya metodun tek bir sorumluluðu olmalý', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Open / Closed Principle (OCP)', 'Sýnýflar deðiþikliðe kapalý ancak geliþime açýk olmalýdýr. Örnek olarak db log iþlemlerinde enum yerine interface kullanarak sýnýflarý hem deðiþikliðe kapalý hem de geliþime açýk tasarlamýþ oluruz.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Liskov’s Substitution Principle (LSP)', 'Alt sýnýflar miras aldýðý üst sýnýfýn bütün özelliklerini kullanmalý, alt sýnýflarda oluþturulan nesneler üst sýnýflarýn nesneleriyle yer deðiþtirdiklerinde ayný davranýþý göstermeli ve herhangi bir kullanýlmayan özellik olmamalý.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Ýnterface Segregation Principle', 'Ara yüzlerin ayrýlmasý prensibi', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Dependency Inversion Principle', 'Katmanlý mimarilerde üst seviye modüller alt seviyedeki modüllere doðruda baðýmlý olmamalýdýr.', GETDATE(), GETDATE(), 0)
go

create proc AddArticle
(
	@NameOrTitle nvarchar(100),
	@Text nvarchar(max)
)
as
begin
	insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted, DeletedDate)
	values(@NameOrTitle, @Text, GETDATE(), GETDATE(), 0, null)
end
go

create proc UpdateArticle
(
	@ID int,
	@NameOrTitle nvarchar(100),
	@Text nvarchar(Max)
)
as
begin
	Update CaseArticle.dbo.Article
	set
	NameOrTitle = @NameOrTitle,
	Text = @Text,
	LastModifiedDate = GETDATE()
	where
		ID = @ID
end
go

create proc GetArticles
as
begin
	select * from CaseArticle.dbo.Article
end
go

CREATE proc FindArticlesByText
(
    @KeyWord nvarchar(40)
)
AS 
begin
select
	*
from CaseArticle.dbo.Article a
where
	a.NameOrTitle like '%' + @KeyWord + '%' or a.Text like '%' + @KeyWord + '%'
end
go

CREATE proc GetArticle
(
    @ID int
)
AS 
begin
select
	*
from CaseArticle.dbo.Article a
where
	a.ID = @ID
end
go

create proc DeleteArticle
(
	@ID int
)
as
begin
	Update CaseArticle.dbo.Article
	set
	Deleted = 1,
	DeletedDate = GETDATE()
	where
		ID = @ID
end
go

create proc DestroyArticle
(
	@ID int
)
as
begin
	Delete CaseArticle.dbo.Article
	where
		ID = @ID
end
go

create proc IfExist
(
	@ID int
)
as
begin
	select COUNT(*) from CaseArticle.dbo.Article a
	where
		a.ID = @ID
end