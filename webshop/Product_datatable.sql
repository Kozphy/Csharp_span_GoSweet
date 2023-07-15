create table Product_datatable(
	p_number int identity(20000,1) primary key not null,
	f_number int not null,
	p_name nvarchar(50) not null,
	p_spec nvarchar(50) null,
	p_category nvarchar(50) not null,
	p_price int not null,
	p_describe nvarchar(500) null,
	p_savedate nvarchar(50) null,
	p_saveway nvarchar(50) null,
	p_Inventory int not null
	p_ship int null,
	p_payment int null
);

insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) values();