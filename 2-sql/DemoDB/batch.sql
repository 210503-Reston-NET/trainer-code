--for sql server--
drop table batch;
drop table trainers;
drop table associates;
--note that SQL is not case sensitive, it is case insensitive for keywords 
-- doesn't really care if I create a table via CREATE TABLE, create table, cReAte TaBlE
create table associates
(
	id int identity primary key,
	associateName nvarchar(100) not null,
	associateLocale varchar(2) not null,
	revaPoints int not null
);
create table trainers
(
	id int identity primary key,
	trainerName varchar(20) not null,
	campus varchar(3) not null,
	caffeineLevel int not null
);
create table batch
(
	id int identity primary key,
	associateID int references associates(id),
	trainerID int references trainers (id)
);

insert into associates (associateName, associateLocale, revaPoints) values 
('Robbie', 'GA', 50), ('Alex', 'MN', 50), ('Jacob', 'FL', 0), ('Juniper', 'WA', 197), ('Janel', 'AZ', 50), ('James', 'PA', 18), ('Phoebe', 'WA', 199);
insert into trainers (trainerName, campus, caffeineLevel) values
('Marielle', 'USF', 60), ('Pushpinder', 'UTA', 50), ('Nick', 'UTA', 75), ('Mark', 'WVU', 16), ('Fred', 'UTA', 25);
insert into batch (associateID, trainerID) values
(3,3), (1,4), (2,2), (4,1), (6,3), (7,1);

select * from associates;