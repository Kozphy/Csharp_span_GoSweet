create table Product_datatable(
	p_number int identity(20000,1) primary key not null,
	f_number int not null,
	p_name nvarchar(50) not null,
	p_spec nvarchar(50) null,
	p_category nvarchar(50) not null,
	p_price int not null,
	p_describe nvarchar(500) null,
	p_savedate nvarchar(50) null
	p_saveway nvarchar(50) null,
	p_Inventory int not null
	p_ship int null,
	p_payment int null
);

insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'波士頓派', N'1入', N'派', 100, N'布列塔尼圓酥餅 Galette Bretonne 始於19世紀後半，是法國的傳統小點心，發源地是法國西北邊的布列塔尼區，這即是此款甜點名字的由來，屬於地方甜點。我們使用法國頂級手工Échiré艾許奶油，奶油含量豐富，充滿濃郁的奶香；搭配法國頂級法芙娜巧克力，為麵糰帶來酥脆和入口即化的口感，並帶有芳香純美的風味；最後加入少許法國頂級鹽之花點綴，除了有濃郁的巧克力香外，甜中帶點鹹，好吃又不膩口',
'一日', N'冷藏',10,NULL,NULL);