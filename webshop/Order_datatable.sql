create table Order_datatable(
	o_number int identity(50000,1) primary key not null,
	o_start date not null,
	o_end date null,
	c_number int not null,
	f_number int not null,
	o_type bit not null,
	m_number int null,
	p_number int not null,
	o_buynumber int not null,
	o_price int not null,
	o_status nvarchar(50) not null,
	o_shipstatus nvarchar(50) not null,
	o_ship int null
	o_place nvarchar(50) not null,
	o_payment int null
)

insert into Order_datatable(o_start,o_end,c_number,f_number,o_type,m_number,p_number,o_buynumber,o_price,o_status, o_shipstatus,o_ship,o_place,o_payment) 
values();