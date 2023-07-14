create table Firm_accounttable(
	f_number int identity(60000,1) primary key not null,
	f_nickname nvarchar(50) not null,
	f_account nvarchar(50) not null,
	f_password nvarchar(50) not null,
	f_mailpass bit not null
)

insert into Firm_accounttable(f_nickname, f_account, f_password, f_mailpass) values ();