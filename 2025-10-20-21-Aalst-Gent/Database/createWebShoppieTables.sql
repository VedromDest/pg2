-- Voer uit als shopgent in ShopGent schema
use ShopGent;

drop table if exists OrderProducts;
drop table if exists Orders;
drop table if exists Customers;
drop table if exists Products;

create table Customers (
                           Id		   int         auto_increment not null primary key,
                           FirstName	   varchar(30)                not null            ,
                           LastName	   varchar(30)                not null            ,
                           DateOfBirth  datetime	                  not null            ,
                           Email        varchar(60)                not null            ,
                           TIN          varchar(20)                    null            ,
                           AddressLine1 varchar(30)                    null            ,
                           AddressLine2 varchar(30)                    null            ,
                           AddressLine3 varchar(30)                    null            ,
                           Country      varchar(30)                    null
);

create table Products (
                          Id		  int		   auto_increment not null primary key,
                          Name		  varchar(50)                 not null            ,
                          Description varchar(200)                not null            ,
                          Price		  decimal(6,2)                not null            ,
                          StockCount  int                         not null default 0  ,
                          AgeRating   int                             null
);

alter table Products
    add constraint UK_Products
        unique (Name);

alter table Products
    add constraint CK_Products_Price_Positive
        check (Price >= 0);

create table Orders (
                        Id           int		 auto_increment	not null primary key              ,
                        CustomerId   int		                not null                          ,
                        CreatedOnUtc timestamp                not null default current_timestamp
);

alter table Orders
    add constraint FK_Orders_Customers
        foreign key (CustomerId)
            references Customers(Id);

create table OrderProducts (
                               Id		int          auto_increment not null primary key,
                               OrderId	int			                not null            ,
                               ProductId	int			                not null            ,
                               Quantity	int			                not null            ,
                               Price		decimal(6,2)                not null            ,
                               Name		varchar(50)	                not null
);

alter table OrderProducts
    add constraint FK_OrderProducts_Order
        foreign key (OrderId)
            references Orders(Id);

alter table OrderProducts
    add constraint FK_OrderProducts_Product
        foreign key (ProductId)
            references Products(Id);

alter table OrderProducts
    add constraint CK_OrderProducts_Quantity_Positive
        check (Quantity > 0);

alter table OrderProducts
    add constraint CK_OrderProducts_Price_Positive
        check (Price >= 0);