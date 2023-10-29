select title 'Title' from titles

select title 'Title' from titles where pub_id = 1389

select title 'Books' from titles where price between 10 and 15

select title 'Books' from titles where price is NULL

select title 'Books' from titles where title like 'The%'

select title 'Books' from titles where title not like '%v%'

select title 'Books' from titles order by royalty

select title 'Books' from titles order by pub_id desc,type,price desc

select type 'Type', avg(price) 'Price' from titles group by type

select distinct(type) 'Type Name' from titles

select top 2 title 'Book' from titles order by price desc

select title 'Books' from titles where type = 'business' and price < 20 or price >7000

select pub_id 'Publisher_id' ,count(title) from titles
where price between 15 and 25 and title like '%it%'
group by pub_id
having count(pub_id) > 2
order by count(pub_id)

select au_fname 'First_Name', au_lname 'Last_Name' from authors where state ='CA'

select state, count(state) from authors group by state

--set 2
select stor_id 'store Id' ,count(ord_num) 'orders' from sales group by stor_id

select title_id,count(ord_num) 'orders' from sales where title_id in(select title_id from titles)
group by title_id

select Titles.title , publishers.pub_name from titles
inner join publishers on titles.pub_id = titles.pub_id

select CONCAT(au_fname,' ',au_lname) 'Author Name' from authors

select title 'Book' , (price+price*12.36/100) 'Tax' from titles

select concat(authors.au_fname,' ',authors.au_lname) 'Author Name',titles.title 'Title'
from authors 
inner join titleauthor on authors.au_id = titleauthor.au_id
inner join titles on titleauthor.title_id = titles.title_id

select concat(authors.au_fname,' ',authors.au_lname) 'Author Name',titles.title 'Title',publishers.pub_name
from authors 
inner join titleauthor on authors.au_id = titleauthor.au_id
inner join titles on titleauthor.title_id = titles.title_id
inner join publishers on titles.pub_id = publishers.pub_id

select publishers.pub_name,avg(titles.price) 'Average price' from publishers
inner join titles on publishers.pub_id = titles.pub_id
group by pub_name

select titles.title 'Book' from titles
inner join titleauthor on titles.title_id = titleauthor.title_id
inner join authors on titleauthor.au_id = authors.au_id
where authors.au_fname = 'Marjorie'

select sales.ord_num 'Order number' from sales
inner join titles on sales.title_id = titles.title_id
inner join publishers on titles.pub_id = titles.pub_id
where publishers.pub_name = 'New Moon Books'

select publishers.pub_name 'Publishers name',count(sales.ord_num) 'Order number' from sales
inner join titles on sales.title_id = titles.title_id
inner join publishers on titles.pub_id = titles.pub_id
group by publishers.pub_name

select sales.ord_num'Order number',titles.title 'Book name', sales.qty'quantity',titles.price,(titles.price*sales.qty)'Total price' from titles
inner join sales on titles.title_id = sales.title_id

select titles.title 'Book',sum(sales.qty)'Total quantity' from sales
inner join titles on sales.title_id = titles.title_id
group by titles.title

select titles.title ,sum(titles.price*sales.qty)'Total order value' from sales 
inner join titles on sales.title_id = titles.title_id
group by titles.title

select sales.ord_num from sales
join titles on sales.title_id = titles.title_id
join employee on titles.pub_id = employee.pub_id
where employee.fname = 'Paolo'