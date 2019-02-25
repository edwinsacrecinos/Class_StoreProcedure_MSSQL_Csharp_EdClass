
-- STORE PROCEDURE READ
/*
Create Procedure read_sp_students
as begin 
select id, name, lastname, section, course, note, state
from information
end
*/

-- STORE PROCEDURE CREATE
/*
Create Procedure Insert_Students 
(@name nvarchar(50), @lastname nvarchar(50), @section nvarchar(50),
 @course nvarchar(50), @note int, @state nvarchar(50),@results nvarchar(100) output)
as begin 
insert into information values (@name,@lastname, @section, @course, @note, @state, 1)
set @results = 'inserted successfully'
end

*/

-- STORE PROCEDURE UPDATE
/*
create Procedure Update_Students 
(@id int,@name nvarchar(50), @lastname nvarchar(50), @section nvarchar(50),
 @course nvarchar(50), @note int, @state nvarchar(50),@results nvarchar(100) output)
as begin 
update information
set name = @name, lastname = @lastname, section = @section, course = @course,
	note = @note, state = @state
where id = @id
set @results = 'Update successfully'
end 
*/

-- STORE PROCEDURE DELETE 
/*
Create Procedure Delete_Students
(@id int, @results nvarchar(100) output)
as begin 
delete from information where id = @id
set @results = 'Delete successfully'
end
*/