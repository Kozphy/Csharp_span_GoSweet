create table Member_membertable(
	m_number int identity(40000,1) primary key not null,
	g_number int not null,
	g_maxpeople int not null,
	m_nowpeople int not null,
	m_status bit not null,
)

insert into Member_membertable (g_number, g_maxpeople, m_notpeople, m_status) values();