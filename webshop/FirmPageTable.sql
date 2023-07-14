create table Firm_pagetable(
	f_number int identity(60000,1) primary key not null,
	f_pagename nvarchar(50) not null,
	f_message nvarchar(500) not null,
	f_picurl nvarchar(50) not null
);

insert into Firm_pagetable (f_pagename, f_message, f_picurl) values();