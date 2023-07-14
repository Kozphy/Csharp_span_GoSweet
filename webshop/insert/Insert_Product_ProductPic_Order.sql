select ProductData.p_number, p_name, p_category,p_url, p_price, p_describe, 
OrderData.o_buynumber, ProductPic.p_picnumber from Product_datatable AS productData join Product_picturetable  AS ProductPic
on productData.p_number = ProductPic.p_number join Order_datatable AS OrderData
on OrderData.p_number = productData.p_number

-- product datatable
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'波士頓派', N'1入', N'派', 100, N'布列塔尼圓酥餅 Galette Bretonne 始於19世紀後半，是法國的傳統小點心，發源地是法國西北邊的布列塔尼區，這即是此款甜點名字的由來，屬於地方甜點。我們使用法國頂級手工Échiré艾許奶油，奶油含量豐富，充滿濃郁的奶香；搭配法國頂級法芙娜巧克力，為麵糰帶來酥脆和入口即化的口感，並帶有芳香純美的風味；最後加入少許法國頂級鹽之花點綴，除了有濃郁的巧克力香外，甜中帶點鹹，好吃又不膩口',
N'一日', N'冷藏',10,NULL,NULL);

-- product picturetable
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(3, 20003, '~/img/ProductPopularRank/波士頓派.jpg');

-- order_datatable
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20003, 1000, 750, N'待成團', N'已送出', NULL, NULL, NULL)