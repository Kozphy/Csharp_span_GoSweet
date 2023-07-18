create table Firm_accounttable(
	f_number int identity(60000,1) primary key not null,
	f_nickname nvarchar(50) not null,
	f_account nvarchar(50) not null,
	f_password nvarchar(50) not null,
	f_mailpass bit not null
)

insert into Firm_accounttable(f_nickname, f_account, f_password, f_mailpass) values ();

-- 60000
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'巴特里', N'test@gmail.com', N'test', 1)
GO

-- 60001
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'麥之鄉', N'test2@gmail.com', N'test', 1)
GO

-- 60002
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'穀王烘焙', N'test3@gmail.com', N'test', 1)
GO