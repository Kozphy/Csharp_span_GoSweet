create table Order_assesstable(
	o_number int primary key identity(60000,1) not null,
	p_number int primary key identity(20000,1) not null,
	o_cscore float null,
	o_ccomment nvarchar(50) null,
	o_fscore float null,
	o_fcomment nvarchar(50) null,
)

insert into OrderOrder_assesstable(o_cscore,o_ccomment,o_fscore,o_fcomment) values ();