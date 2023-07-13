create table Product_picturetable(
	p_picnumber int identity(1,1) primary key  not null,
	p_number int identity(20000,1) primary key not null,
	p_url nvarchar(50) not null
);

insert into Product_picturetable (p_url) values()