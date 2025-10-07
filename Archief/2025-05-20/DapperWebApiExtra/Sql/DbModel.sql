USE pg2;

CREATE TABLE DemoTypes (
    Id int auto_increment not null primary key,
    Blabla varchar(256)
);

INSERT INTO DemoTypes (Blabla) VALUES ('First');