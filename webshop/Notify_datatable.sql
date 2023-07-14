create table Notify_datatable(
	n_number int identity(1,1) primary key not null,
	c_number int null,
	f_number int null,
	o_number int not null,
	o_status nvarchar(50) not null,
	n_read bit null
)

insert into Notify_datatable (c_number, f_number, o_number, o_status, n_read) values ();