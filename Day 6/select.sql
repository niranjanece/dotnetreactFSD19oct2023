use pubs

select * from authors

select *from titles

select * from sales

select * from publishers

--projectiion it will not change in the table only to display with that name

select au_id, phone from authors
-- to display 
select au_fname 'First Name' from authors
--if no space in the name 
select au_fname Author_name ,phone Contact_Number from authors

--selection

select * from authors where contract=0

select * from titles where royalty > 10 and price>15

select title 'Book Name', price 'cost' ,royalty 'Royality Paid' , advance 'Advance Received' from titles
where royalty > 10 and price>15

select title from titles where price between 10 and 25

select * from titles where title like 'the%'

select title from titles where title like '%data%'

select title from titles where pubdate > '1991-06-18 00:00:00.000'

select title 'Book Name' , price from titles where pub_id = 0877

select title 'Book Name' , price, notes  from titles where price between 15 and 100

--identifying null
select * from titles where advance is null
select * from titles where advance is not null

--to select multiple

select * from titles where price in (10,20,30)

--Aggrigate data

select avg(price) 'Average Price' from titles
select count(title) 'Total Book' from titles
select max(price) 'Maximim Price' from titles
select min(price) 'Minimum Price' from titles
select sum(price) 'Total Price' from titles

select avg(price) 'Average Price' from titles
where type = 'business'

--subtotal and grouping

select type 'Type Name' , avg(price) 'Average Price' from titles group by type 

select state 'State' ,count(au_id) from authors group by state

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id 
having count(ord_num) > 1

select type 'Type Name', avg(price) 'Average Price' 
from titles
where price>10
group by type 
having avg(price) > 10

-- sorting

select * from authors order by state

select * from authors order by state,city,au_fname

select type 'Type Name' , avg(price) 'average price' from titles
where price > 10
group by type
having avg(price)>18
order by Type desc

--subquerry

select * from titles
select * from sales
select title_id from titles where title = 'Straight Talk About Computers'
select * from sales where title_id = 'BU7832'

select * from sales where title_id = (select title_id from titles where title = 'Straight Talk About Computers')

select * from titles where title_id in(
select title_id from titleauthor where au_id=
(select au_id from authors where au_lname = 'White'))

select title 'Book' from titles where title_id in (select title_id from sales)

select title 'Title' ,avg(price) 'Average Price' from titles where pub_id in
(select pub_id from publishers where country = 'USA' )
group by title
having avg(price)>(select avg(price) from titles)

