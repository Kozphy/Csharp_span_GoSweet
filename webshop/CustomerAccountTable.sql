create table Customer_accounttable(
	c_number int identity(10000,1) primary key not null,
	c_nickname nvarchar(30) not null,
	c_account nvarchar(50) not null,
	c_password nvarchar(50) not null,
	c_mailpass bit not null,
)

insert into Customer_accounttable (c_nickname,c_account,c_password,c_mailpass) values ();