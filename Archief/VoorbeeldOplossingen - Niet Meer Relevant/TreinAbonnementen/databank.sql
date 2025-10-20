use pg2;

drop table if exists Abonnement;
drop table if exists Station;
drop table if exists Klant;

create table Customer (
  Id         int         auto_increment not null primary key,
  FirstName  varchar(30)                not null            ,
  LastName   varchar(30)                not null            ,
  Email      varchar(60)                not null            
);

alter table Customer add constraint UK_Klant unique(Email);

create table Station (
  Id             int         auto_increment not null primary key  ,
  Name           varchar(30)                not null              ,
  HasWaitingRoom boolean                    not null default false
);

alter table Station add constraint UK_Station unique(Name);

create table Subscription (
  Id           int      auto_increment not null primary key,
  CustomerId   int                     not null            ,
  Station1Id   int                     not null            ,
  Station2Id   int                     not null            ,
  ValidFrom    datetime                not null            ,
  ValidTo      datetime                not null            ,
  ComfortLevel int                     not null default 2
);

alter table Subscription add constraint FK_Abonnement_Klant foreign key (CustomerId) references Customer(Id);
alter table Subscription add constraint FK_Abonnement_StationVan    foreign key (Station1Id) references Station(Id);
alter table Subscription add constraint FK_Abonnement_StationNaar foreign key (Station2Id) references Station(Id);
alter table Subscription add constraint CK_Abonnement_VanTot CHECK (ValidFrom < ValidTo);
alter table Subscription add constraint CK_Abonnement_Klasse CHECK (ComfortLevel in (1,2));




