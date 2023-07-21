-- Customer_accounttable, c_number identity: 10000
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_account], [c_password], [c_mailpass]) VALUES (N'李銘翔', N'test@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_account], [c_password], [c_mailpass]) VALUES (N'黃瀞儀', N'test1@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_account], [c_password], [c_mailpass]) VALUES (N'廖胤翔', N'test2@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_account], [c_password], [c_mailpass]) VALUES (N'趙晟佑', N'test3@gmail.com', N'test', 0)
GO

-- Firm_accounttable, f_number identity: 60000
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'巴特里', N'test@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'麥之鄉', N'test2@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (N'穀王烘焙', N'test3@gmail.com', N'test', 1)
GO

-- Firm_pagetable, f_number 60000
INSERT [dbo].[Firm_pagetable] (f_number, [f_pagename], [f_message], [f_picurl]) VALUES (60000, N'巴特里', N'販賣各式糕點店', '')
GO
INSERT [dbo].[Firm_pagetable] (f_number,[f_pagename], [f_message], [f_picurl]) VALUES (60001, N'麥之鄉', N'販賣各種口味的法式布丁', '')
GO
INSERT [dbo].[Firm_pagetable] (f_number,[f_pagename], [f_message], [f_picurl]) VALUES (60002, N'穀王烘焙', N'販賣各式黑糖糕點店', '')
GO

-- Ship_datatable
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (1, N'全家')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (2, N'7-11')
GO

-- Payment_datatable
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (1, N'超商取貨付款')
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (2, N'VISA')
GO

-- Product_datatable, p_number identity: 20000
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'波士頓派', N'1入', N'派', 100, N'蛋糕體比戚風蛋糕更加輕盈綿密，重點在於使用北海道奶霜和法國鮮奶油，入口即能感受到鮮奶油濃濃的奶香和綿細的蛋糕體在嘴裡化開。',
N'一日', N'冷藏',10,NULL,NULL);
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'天使蛋糕', N'1入', N'蛋糕', 200, N'天使蛋糕屬於乳沫類蛋糕，它有一個特色就是不能有一滴油，即使含有油脂的蛋黃也要捨去，同時因為無油脂，色澤呈現蛋糕少有的純白，如同天使般的純潔，故稱為天使。天使蛋糕的口味與一般蛋糕的口味完全不同，喜歡他的人覺得毫不油膩且具彈性，不喜歡的人覺得乾澀又韌，一般蛋糕店比較少販賣，主要因為口感比較特殊。天使蛋糕最適合推薦給怕胖或有心血管疾病的人，因為他不含油脂與膽固醇，可說是一種健康點心喔',
N'一日', N'冷藏',30,NULL,NULL);
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'千層蛋糕', N'1入', N'蛋糕', 100, 
N'英文名稱中的「crêpe」是法文，不少人認為千層蛋糕源自法國：亦有傳說是源自拿破崙御廚 — 享有第一位美食外交官之美譽的馬利．安東尼．卡瑞蒙（Marie-Antonin Carême）。亦有傳說千層形狀的蛋糕最早是源自匈牙利的Szeged城，那裏的人們常吃一種上層鋪有焦糖的千層蛋糕。也有流傳最早的千層蛋糕是以「千層可麗餅蛋糕」型態首度出現於東京，風靡日本後又席捲美國並陸續引進亞洲。',
N'一日', N'冷藏',30,NULL,NULL);
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'巧克力慕斯', N'1入', N'甜點', 300, 
N' 巧克力慕斯起源於法國，可以追溯到18世紀晚期或19世紀早期。它被認為是法國廚師創造的一種甜點，源於法國對巧克力的熱愛和獨特的烹飪傳統。慕斯最初是一種以蛋白和糖製成的輕盈甜點，但隨著時間的推移，人們開始將巧克力作為慕斯的主要成分之一。巧克力慕斯以其絲滑、濃郁的口感和巧克力的香味而受到人們的喜愛。在製作巧克力慕斯時，通常使用優質的巧克力、雞蛋、糖和奶油等原料。這些成分會被精心混合在一起，然後通過冷藏來達到慕斯的質地和口感。隨著時間的推移，巧克力慕斯逐漸成為一道備受歡迎的甜點，並在世界各地的餐廳和糕點店中廣泛供應。人們還會根據個人喜好和創意，加入其他食材和裝飾來製作各種口味和款式的巧克力慕斯。儘管巧克力慕斯的具體起源有些模糊，但它無疑成為了世界上最受歡迎和標誌性的巧克力甜點之一。',
N'一日', N'冷藏',30,NULL,NULL);
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'咕咕霍夫', N'1入', N'甜點', 150, N' 自於奧地利、法國、德國、瑞士等中歐國家的節慶甜點，經典款式是做成「皇冠、僧侶帽」的造型。據說法皇路易十六的皇妃喜歡吃，所以做成「皇冠」造型。另個傳言是神職人員的「僧侶帽」造型，是用來祈求世界和平；也有一說是古代巴勒斯坦國王遺失的皇冠被一位甜點師拾獲，後來他將麵包做成皇冠的造型。不論起源如何，咕咕霍夫這款節慶甜點傳遞的訊息都是「分享與喜悅」',
N'一日', N'冷藏',30,NULL,NULL);
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'布列塔尼', N'1入', N'甜點', 450, 
N' 布列塔尼圓酥餅 Galette Bretonne 始於19世紀後半，是法國的傳統小點心，發源地是法國西北邊的布列塔尼區，這即是此款甜點名字的由來，屬於地方甜點。我們使用法國頂級手工Échiré艾許奶油，奶油含量豐富，充滿濃郁的奶香；搭配法國頂級法芙娜巧克力，為麵糰帶來酥脆和入口即化的口感，並帶有芳香純美的風味；最後加入少許法國頂級鹽之花點綴，除了有濃郁的巧克力香外，甜中帶點鹹，好吃又不膩口。',
N'一日', N'冷藏',30,NULL,NULL);



-- Product_picturetable
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20000, N'/img/Home/ProductPopularRank/波士頓派.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20001, N'/img/Home/ProductPopularRank/AngleCake.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20002, N'/img/Home/ProductPopularRank/Classic_Mille_Feuille.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20003, N'/img/Home/ProductPopularRank/巧克力慕斯.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20004, N'/img/Home/ProductPopularRank/咕咕霍夫.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20005, N'/img/Home/ProductPopularRank/布列塔尼.jpg');

-- Product_to_Ship
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 2)
GO

-- Product_to_Payment
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 2)
GO

-- Group_datatable, g_number identity: 30000
INSERT [dbo].[Group_datatable] ([f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (60000, 20000, CAST(N'2023-07-01' AS Date), CAST(N'2023-08-30' AS Date), 20, 250)
GO
INSERT [dbo].[Group_datatable] ([f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (60001, 20001, CAST(N'2023-07-07' AS Date), CAST(N'2023-09-20' AS Date), 17, 450)
GO
INSERT [dbo].[Group_datatable] ([f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (60002, 20002, CAST(N'2023-07-11' AS Date), CAST(N'2023-09-10' AS Date), 15, 370)
GO

-- Member_membertable, m_number identity: 40000
INSERT [dbo].[Member_membertable] ([g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (30000, 20, 10, 0)
GO
INSERT [dbo].[Member_membertable] ([g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (30001, 17, 11, 0)
GO
INSERT [dbo].[Member_membertable] ([g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (30002, 15, 13, 0)
GO

-- Order_datatable, o_number identity: 50000
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20000, 1000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20001, 2000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20002, 3000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20003, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20005, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)


-- Order_assesstable
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment]) VALUES (50000, 3, N'普通', 5, N'歡迎下次購買其他品項')
GO

-- Notify_datatable, n_number identity: 1
INSERT [dbo].[Notify_datatable] ([c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (NULL, 60000, 50000, N'已下單', 0)

-- Talk_membertable, Talk_member_id identiy(1,1)
INSERT [dbo].[Talk_membertable] ([c_number], [f_number]) VALUES (10000, 60000)
GO
INSERT [dbo].[Talk_membertable] ([c_number], [f_number]) VALUES (10000, 60001)
GO

-- Talk_persontable, t_forPK identity(1,1)
INSERT [dbo].[Talk_persontable] ([c_number], [f_number], [t_id]) VALUES (NULL, 60000, N'1--XnJQElaTboh2OC2_iAA')

-- Talk_datatable, t_number identity(1,1)
INSERT [dbo].[Talk_datatable] ([c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (10000, 60000, CAST(N'2007-06-11T13:50:30.000' AS DateTime), N'我收到的不是餐包', 0, 0)
GO
INSERT [dbo].[Talk_datatable] ([c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (10000, 60000, CAST(N'2023-06-11T15:30:33.000' AS DateTime), N'呼叫廠商', 0, 0)