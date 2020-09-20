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

insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Case Article', 'Makale tipindeki bir nesnenin veri taban�na kaydedilmesi, g�ncellenmesi veya silinmesi gibi i�lemlerden sorumlu olan s�n�f ArticleRepository s�n�f�d�r.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Single Responsibility Principle (SRP)', 'Her s�n�f�n veya metodun tek bir sorumlulu�u olmal�', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Open / Closed Principle (OCP)', 'S�n�flar de�i�ikli�e kapal� ancak geli�ime a��k olmal�d�r. �rnek olarak db log i�lemlerinde enum yerine interface kullanarak s�n�flar� hem de�i�ikli�e kapal� hem de geli�ime a��k tasarlam�� oluruz.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Liskov�s Substitution Principle (LSP)', 'Alt s�n�flar miras ald��� �st s�n�f�n b�t�n �zelliklerini kullanmal�, alt s�n�flarda olu�turulan nesneler �st s�n�flar�n nesneleriyle yer de�i�tirdiklerinde ayn� davran��� g�stermeli ve herhangi bir kullan�lmayan �zellik olmamal�.', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('�nterface Segregation Principle', 'Ara y�zlerin ayr�lmas� prensibi', GETDATE(), GETDATE(), 0)
insert into CaseArticle.dbo.Article(NameOrTitle, Text, CreatedDate, LastModifiedDate, Deleted) Values('Dependency Inversion Principle', 'Katmanl� mimarilerde �st seviye mod�ller alt seviyedeki mod�llere do�ruda ba��ml� olmamal�d�r.', GETDATE(), GETDATE(), 0)
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