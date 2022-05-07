/*select department_id, sum(salary) as summa from employee as e
group by department_id
select d.name, sum(e.salary) as summa from department as d, employee as e
where d.Id = e.department_id
group by d.name
select d.name, sum(e.salary) as summa, e.chief_id
	from department as d, employee as e 
	where d.Id = e.department_id
	group by d.name, e.chief_id

select name, salary from employee where id in (select distinct(chief_id) from employee where chief_id is not null) order by salary desc*/

