use events;

create table Locaties (
	Id int auto_increment primary key,
    Naam varchar(200),
    blabla varchar(30)
);

insert into Locaties (Naam) 
values ("Gent"), ("Aalst");

create table Events (
	Id int auto_increment primary key,
    Naam varchar(200),
    LocatieId int,
    LastUpdate datetime default current_timestamp
);

insert into Events (Naam, LocatieId)
values 
("Het eerste event", 1),
("Het tweede event", 2)
;

create table Tasks (
	Id int auto_increment primary key,
    Naam varchar(200),
    Prio varchar(30),
    Status varchar(30),
    EventId int,
    LastUpdate datetime default current_timestamp    
)
;

insert into Tasks (Naam, Prio, Status, EventId)
values
("Taak 1 van event 1", "Must", "ToDo", 1),
("Taak 2 van event 1", "Could", "ToDo", 1),
("Taak 3 van event 1", "Must", "Done", 1),
("Taak 1 van event 2", "Must", "ToDo", 2),
("Taak 2 van event 2", "Could", "ToDo", 2),
("Taak 3 van event 2", "Should", "Doing", 2)
;

update Tasks
set LastUpdate = current_timestamp 
where Id = 6;


alter table Events add constraint fk_event_locatie 
foreign key (LocatieId) references Locaties (Id)
;

alter table Tasks add constraint fk_taak_event
foreign key (EventId) references Events (Id)
;


select 	e.Id 	as EventId, 
		e.Naam 	as EventName, 
        l.Id 	as LocatieId, 
        l.Naam 	as LocatieNaam,
        (
			CONCAT(
				(select count(1) from Tasks where EventId = e.Id and status = "Done") /
				(select count(1) from Tasks where EventId = e.Id) * 100
                , "%"
			)
        ) as PercentageTakenVoltooid,
        (
			select 	count(1) 
            from 	Tasks 
            where 	EventId = e.Id 
            and 	prio 	= "Must" 
            and 	status 	= "ToDo"
		) as AantalMustTakenToDo,
        (
			select MAX(u.upd)
            from (
				select e.LastUpdate as upd
				union all
				select t.LastUpdate as upd from Tasks t where t.EventId = e.Id
            ) u
        ) as LastUpdateEventOfTask
from 		Events e
inner join 	Locaties l on l.Id = e.LocatieId

