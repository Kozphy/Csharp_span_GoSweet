create table Firm_accounttable(
	f_number int identity(60000,1) primary key not null,
	f_nickname nvarchar(50) not null,
	f_account nvarchar(50) not null,
	f_password nvarchar(50) not null,
	f_mailpass bit not null
)

insert into Firm_accounttable(f_nickname, f_account, f_password, f_mailpass) values ();

INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'李銘翔', 10000, N'test@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'黃瀞儀', 10001, N'test1@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'廖胤翔', 10002, N'test2@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'趙晟佑', 10003, N'test3@gmail.com', N'test', 0)