use pubs

select * from titles

select * from stores

select * from sales

select * from publishers

select * from authors

select * from titleauthor

select stor_name 'Store Name', title 'Books', qty 'Quantity of book' , (qty*price) 'Sale amount',pub_name 'Publisher Name',au_fname 'AuthorName' 
from stores st right join sales sa
on st.stor_id =sa.stor_id
right join titles t on t.title_id = sa.title_id
right join publishers p on p.pub_id = t.pub_id
right join titleauthor ta on t.title_id = ta.title_id
right join authors a on ta.au_id = a.au_id

alter proc proc_GetTotalSalesAmount(@PublisherName varchar(20),@totalSale float out)
as
begin
	declare
	@sale float
	set @sale = (select sum(qty*price) from sales s join titles t
			on s.title_id = t.title_id
			join titleauthor ta on t.title_id = ta.title_id
			join authors a on ta.au_id = a.au_id
			where au_fname = @PublisherName)
	set @totalSale = @sale
end

declare @sales int
begin 
	exec proc_GetTotalSalesAmount 'Marjorie',@sales out
	select @sales 'Total Sales'
end

select * from sales s where qty in (select max(qty) from sales
group by stor_id)

select concat(au_fname,' ',au_lname)'Author name' ,title 'Book' , avg(price) 'Average price' from titles t 
join titleauthor ta
on t.title_id = ta.title_id
join authors a on a.au_id = ta.au_id 
group by title,au_fname,au_lname

sp_help titles

create proc proc_CountOfBooks(@price_of_book int,@count_of_book int out)
as
begin
	declare @total int
	set @total = (select count(title) 'Total Book' from titles
	  where price < @price_of_book)
	set @count_of_book = @total
end

declare @total int
begin
  exec proc_CountOfBooks 20,@total out
  select @total 'Total Book Count'
end

create trigger trgUpdatePrice on titles
instead of update
as begin
	declare
	@price int,
	@titleId varchar(20)
	set @price = (select price from inserted)
	set @titleId = (select title_Id from inserted)
	if(@price < 7)
	begin
	  print 'Not updated'
	end
	else
	begin
		update titles set price = @price where title_id =@titleId
	end
end

update titles set price = 10 where title_id ='BU1111'


select title 'Book' from titles 
where title like '%e%' and title like '%a%'
