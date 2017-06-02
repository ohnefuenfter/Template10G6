create table class_a (
class_a_pk int not null primary key,
)
go

create table class_b (
class_b_pk int not null primary key,
create_date datetime,
)
go

create table Dict_A_B (
class_a_pk int not null,
class_b_pk int not null,
factor int
)
go

alter table Dict_A_B add constraint FK_class_A foreign key (class_a_pk) references class_a(class_a_pk)
alter table Dict_A_B add constraint FK_class_B foreign key (class_b_pk) references class_b(class_b_pk)
go


insert into class_a values (1)
insert into class_a values (2)

insert into class_b values (1, GETDATE())
insert into class_b values (2, DateADD(dd, 1, GETDATE()))
insert into class_b values (3, DateADD(dd, 2, GETDATE()))
insert into class_b values (4, DateADD(dd, 3, GETDATE()))

insert into Dict_A_B values (1, 1, 20)
insert into Dict_A_B values (1, 2, 1)
insert into Dict_A_B values (1, 3, 1)
insert into Dict_A_B values (1, 4, 1)

insert into Dict_A_B values (2, 1, 20)
insert into Dict_A_B values (2, 2, 2)
insert into Dict_A_B values (2, 3, 4)
insert into Dict_A_B values (2, 4, 1)

