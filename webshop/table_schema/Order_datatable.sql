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



INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES 
(50000, CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20000, 3, 750, N'待成團', N'已送出', NULL, NULL, NULL)