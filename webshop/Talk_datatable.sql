create table Talk_datatable(
	t_number int identity(1,1) primary key not null,
	c_number int not null,
	f_number int not null,
	t_time datetime not null,
	t_message nvarchar(500) not null,
	t_read bit not null,
	t_post int not null
)

insert into Talk_datatable (c_number, f_number, t_time, t_message, t_read, t_post) values()