select * from employee

select * from publishers

select * from sales
--joins

select pub_name 'Publisher Name' ,title 'Book Name' from publishers  join titles 
on publishers.pub_id = titles.pub_id 

select p.pub_id 'Publisher Id' , pub_name 'Publisher name', title 'Book' from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher name]

--outer join

select pub_name 'Publisher Name' ,title 'Book Name' from publishers  left outer join titles 
on publishers.pub_id = titles.pub_id 

select t.title Book_name, s.qty Quantity_Sold from
sales s right outer join titles t
on s.title_id = t.title_id

--publisher name and the count of book published

select pub_name 'Publisher Name',count(t.pub_id) 'Number of books published'
from publishers p join titles t
on p.pub_id= t.pub_id
group by pub_name
order by [Publisher Name]

select pub_name 'Publisher Name', fname'Employee Name' from publishers p join employee e
on p.pub_id = e.pub_id

select title 'Book name' , concat(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id

select pub_name'Publisher Name',title 'Book' ,sum(qty) 'Sold quantity'
from publishers p join titles t
on p.pub_id = t.pub_id
join sales s on t.title_id = s.title_id
group by title,pub_name

--cross join - it joins all the column of both the table 

select * from sales cross join employee

--data injection
create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'jjj')

--data integration

select * from tbl1 where f1 =1;delete from tbl1

create Procedure proc_First
as 
begin
select * from authors
end
execute proc_First

create Procedure proc_InsertSample(@f1 int,@f2 varchar(20))
as 
begin
  insert into tbl1 values(@f1,@f2)
end

exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH;delete from tbl1'

alter proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f1=@f2
end

exec proc_Select '1;delete from tbl1'

create proc proc_GetTotalSaleAmount(@authorName varchar(20),@saleamount float out)
as
begin
    declare
	@saleamt float
	set @saleamt = (select sum(qty) * sum(t.price) from sales s join titles t
	               on s.title_id = t.title_id
				   where t.title_id in
				   (select title_id from titleauthor where au_id = 
				   (select au_id from authors where au_fname = @authorName)))
	set @saleamount =@saleamt
end

declare @amt float
begin
exec proc_GetTotalSaleAmount 'Cheryl', @amt out
print @amt
end

create function fn_CalculateTax(@price float)
returns float
as
begin
    declare @totalPrice float
	set @totalPrice = @price +(@price*12.36/100)
	return round(@totalPrice,2)
end

select title,price,dbo.fn_CalculateTax(price) 'Nett. Price'
from titles

create function fn_AuthorName(@au_fname varchar(20), @au_lname varchar(20))
returns varchar(20)
as
begin
	declare @author_name varchar(20)
	set @author_name=concat(@au_fname,' ',@au_lname)
	return @author_name
end

select dbo.fn_AuthorName(au_fname,au_lname) 'Full name 'from authors

create proc proc_GetTotalSale(@PublisherName varchar(20),@totalSale float out)
as
begin
	declare
	@sale float
	set @sale = (select sum(s.qty) from sales s
				join titles t on s.title_id = t.title_id
				where t.pub_id in(select pub_id from publishers 
				where pub_name = @PublisherName))
	set @totalSale = @sale
end

declare @sales int
begin 
	exec proc_GetTotalSale 'New Moon Books',@sales out
	select @sales 'Total sale'
end

--View

Create view vwPublisher
as
select pub_id 'Publisher Id' ,pub_name 'Publisher Name' from Publishers

select * from vwPublisher

create view vwInvoice
as 
	select t.title 'Book Name',sum(s.qty)*sum(t.price) 'Sale Amount' from sales s join titles t
    on s.title_id = t.title_id
	group by t.title

select * from vwInvoice 

--index -  to search faster

create index idxSample on tbl1(f1)

sp_help tbl1

create trigger trg_InsertTbl1
on tbl1
for insert
as 
begin
	print 'Hello'
end

insert into tbl1 values(101,'uuu')

use dbCompany26Oct2023

alter trigger trgInsertEmployeeSkill
on EmployeesSkills
instead of insert
as 
begin
	declare
	@skillName varchar(20),
	@empId int,
	@level int
	set @skillName = (select skill_name from inserted)
	set @empId = (select employee_id from inserted)
	set @level = (select skill_level from inserted)
	if((select count(skill) from Skills where skill = @skillName) = 0)
	begin
		print 'Skill not present in skill table'
	end
	else
	begin
		insert into EmployeesSkills values(@empId,@skillName,@level)
	end
end

insert into EmployeesSkills values (101,'sql',8)


insert into EmployeesSkills values (101,'sq',8)


