create table Group_datatable(
	g_number int identity(30000,1) primary key not null,
	f_number int not null,
	p_number int not null,
	g_start date not null,
	g_end date not null,
	g_maxpeople int not null,
	g_price int not null,
);

insert into (f_number, p_number,g_start, g_end, g_maxpeople, g_price) values();