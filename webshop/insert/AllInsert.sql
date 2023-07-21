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
-- 20000 波士頓派
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'波士頓派', N'1入', N'派', 100, N'蛋糕體比戚風蛋糕更加輕盈綿密，重點在於使用北海道奶霜和法國鮮奶油，入口即能感受到鮮奶油濃濃的奶香和綿細的蛋糕體在嘴裡化開。',
N'一日', N'冷藏',10,NULL,NULL);
-- 20001 天使蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000,N'天使蛋糕', N'1入', N'蛋糕', 200, N'天使蛋糕屬於乳沫類蛋糕，它有一個特色就是不能有一滴油，即使含有油脂的蛋黃也要捨去，同時因為無油脂，色澤呈現蛋糕少有的純白，如同天使般的純潔，故稱為天使。天使蛋糕的口味與一般蛋糕的口味完全不同，喜歡他的人覺得毫不油膩且具彈性，不喜歡的人覺得乾澀又韌，一般蛋糕店比較少販賣，主要因為口感比較特殊。天使蛋糕最適合推薦給怕胖或有心血管疾病的人，因為他不含油脂與膽固醇，可說是一種健康點心喔',
N'一日', N'冷藏',30,NULL,NULL);
-- 20002 千層蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'千層蛋糕', N'1入', N'蛋糕', 100, 
N'英文名稱中的「crêpe」是法文，不少人認為千層蛋糕源自法國：亦有傳說是源自拿破崙御廚 — 享有第一位美食外交官之美譽的馬利．安東尼．卡瑞蒙（Marie-Antonin Carême）。亦有傳說千層形狀的蛋糕最早是源自匈牙利的Szeged城，那裏的人們常吃一種上層鋪有焦糖的千層蛋糕。也有流傳最早的千層蛋糕是以「千層可麗餅蛋糕」型態首度出現於東京，風靡日本後又席捲美國並陸續引進亞洲。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20003 巧克力慕斯
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'巧克力慕斯', N'1入', N'甜點', 300, 
N' 巧克力慕斯起源於法國，可以追溯到18世紀晚期或19世紀早期。它被認為是法國廚師創造的一種甜點，源於法國對巧克力的熱愛和獨特的烹飪傳統。慕斯最初是一種以蛋白和糖製成的輕盈甜點，但隨著時間的推移，人們開始將巧克力作為慕斯的主要成分之一。巧克力慕斯以其絲滑、濃郁的口感和巧克力的香味而受到人們的喜愛。在製作巧克力慕斯時，通常使用優質的巧克力、雞蛋、糖和奶油等原料。這些成分會被精心混合在一起，然後通過冷藏來達到慕斯的質地和口感。隨著時間的推移，巧克力慕斯逐漸成為一道備受歡迎的甜點，並在世界各地的餐廳和糕點店中廣泛供應。人們還會根據個人喜好和創意，加入其他食材和裝飾來製作各種口味和款式的巧克力慕斯。儘管巧克力慕斯的具體起源有些模糊，但它無疑成為了世界上最受歡迎和標誌性的巧克力甜點之一。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20004 咕咕霍夫
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'咕咕霍夫', N'1入', N'甜點', 150, N' 自於奧地利、法國、德國、瑞士等中歐國家的節慶甜點，經典款式是做成「皇冠、僧侶帽」的造型。據說法皇路易十六的皇妃喜歡吃，所以做成「皇冠」造型。另個傳言是神職人員的「僧侶帽」造型，是用來祈求世界和平；也有一說是古代巴勒斯坦國王遺失的皇冠被一位甜點師拾獲，後來他將麵包做成皇冠的造型。不論起源如何，咕咕霍夫這款節慶甜點傳遞的訊息都是「分享與喜悅」',
N'一日', N'冷藏',30,NULL,NULL);
-- 20005 布列塔尼
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'布列塔尼', N'1入', N'甜點', 450, 
N' 布列塔尼圓酥餅 Galette Bretonne 始於19世紀後半，是法國的傳統小點心，發源地是法國西北邊的布列塔尼區，這即是此款甜點名字的由來，屬於地方甜點。我們使用法國頂級手工Échiré艾許奶油，奶油含量豐富，充滿濃郁的奶香；搭配法國頂級法芙娜巧克力，為麵糰帶來酥脆和入口即化的口感，並帶有芳香純美的風味；最後加入少許法國頂級鹽之花點綴，除了有濃郁的巧克力香外，甜中帶點鹹，好吃又不膩口。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20006 穀物麵包
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'穀物麵包', N'1入', N'麵包', 150, 
N'鬆軟香甜的麵包是許多人喜愛的早餐選擇之一，然而，由精緻澱粉製成的麵糰不僅是減重地雷，高糖高油的成分更會導致身體容易感到疲倦及飢餓。近年來不少烘焙師傅開始將「歐式麵包」引進台灣，採用全穀物麥粉製作以及自養酵母菌來進行發酵，不只天然營養還添加手工特色餡料，吃起來美味又滿足！',
N'一日', N'冷藏',30,NULL,NULL);
-- 20007 巧克力吐司
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'巧克力吐司', N'1入', N'麵包', 170, 
N'巧克力吐司是一款美味的早餐選擇。它是將新鮮的吐司麵包均勻地塗上濃郁的巧克力醬，再經過輕輕烘烤，使巧克力融化且表面微焦，帶來絕妙的口感。每一口都散發出迷人的巧克力香氣，讓人垂涎欲滴。這款吐司不僅適合早餐，也是下午茶時光的絕佳伴侶。無論是小朋友還是大人，都能因它的甜蜜滋味而愛不釋手。品嘗一片巧克力吐司，讓您的味蕾在濃情巧克力的魔力下舞動，帶來一份幸福的美好享受。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20008 黑吐司
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'黑吐司', N'1入', N'麵包', 180, 
N'黑吐司，是一款經典的麵包選擇。它的製作過程獨特，以高品質的原材料，如全麥粉和黑糖，製成深沉色澤的麵包。黑吐司的質地綿密鬆軟，並富含營養與纖維。它不僅美味，還有助於維持健康飲食。這款黑吐司可搭配果醬、牛油或其他喜愛的配料，讓您的味蕾享受不同的風味。不論是早餐時光還是下午茶，黑吐司都是您最佳的選擇。讓我們一起來品嘗這頂級的黑吐司，感受其特有的香甜滋味，享受一份營養與美味的双重享受。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20009 磅蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'磅蛋糕', N'1入', N'蛋糕', 200, 
N'磅蛋糕是一款受歡迎的經典甜點。它以簡單純淨的配方製作，包含麵粉、蛋、糖和奶油等基本材料，融合出濃厚的香氣和柔軟的口感。磅蛋糕的特色在於鬆軟細緻，入口即化，不論是原味或加入果醬、巧克力等風味，都能帶來愉悅的享受。它適合各種場合，無論是咖啡時間、生日慶祝或節日聚會，都是完美的甜點選擇。讓您的味蕾在這頂磅蛋糕的滋味中沉醉，感受甜蜜和幸福的時光。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20010 酥皮蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'酥皮蛋糕', N'1入', N'蛋糕', 100, 
N'酥皮蛋糕是一款令人著迷的精緻甜點。它的外觀金黃酥脆，內裡柔軟濕潤，結合了蛋糕和酥皮的完美組合。製作過程中使用高質量奶油、新鮮雞蛋和優質麵粉，使蛋糕帶來豐富的奶香和濃郁的口感。酥皮蛋糕口味多樣，有原味、巧克力、水果等多種選擇，滿足各種喜好。無論是獨自品嘗還是與親朋好友分享，酥皮蛋糕都能為您帶來愉悅的味覺體驗。在下次甜品時光，不妨嘗試這款經典的酥皮蛋糕，讓您的味蕾享受一場獨特的甜蜜盛宴。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20011 戚風蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'戚風蛋糕', N'1入', N'蛋糕', 130, 
N'戚風蛋糕是一款輕盈柔滑的經典甜點。其獨特之處在於使用蛋黃與蛋白分開打發，再輕手混合，使蛋糕體質地蓬鬆綿密。傳統戚風蛋糕口味純正，散發出濃郁的蛋香與香草氣息，入口滑順，帶來無比的愉悅。此外，戚風蛋糕還可加入水果、巧克力等變化，豐富了其口味多樣性。無油脂且低糖份的特點，使它成為健康又美味的選擇。不論是日常點心還是節日慶典，戚風蛋糕都是受歡迎的甜點之一，讓您品嘗到簡單、純粹的甜蜜滋味。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20012 重乳酪蛋糕
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'重乳酪蛋糕', N'1入', N'蛋糕', 700, 
N'重乳酪蛋糕是一款濃郁滑順的美味甜點。其主要成分是優質的乳酪和新鮮奶油，製作過程講究細膩與均勻。重乳酪蛋糕口感豐富，入口柔軟滑順，帶有微微的酸甜香氣，給人無比的舒適享受。此外，它還可添加水果、巧克力等口味，增添多樣風味。重乳酪蛋糕適合各種場合，無論是家庭聚會還是節日慶祝，都是受歡迎的甜點之選。讓我們一同品味這份濃情乳酪的美味，感受它帶來的甜蜜與滿足。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20013 瑪德蓮
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'瑪德蓮', N'1入', N'甜點', 150, 
N'瑪德蓮是一種迷人的法式小甜點。它們外形獨特，像是小小的貝殼，外皮金黃酥脆，內部鬆軟濕潤。瑪德蓮的製作過程包含高質量的麵粉、雞蛋、奶油和香草等成分，使得口感豐富且香氣四溢。這款小甜點適合搭配咖啡或茶，是下午茶的絕佳伴侶。無論是簡單的原味還是添加了柠檬、巧克力等口味，都讓人愛不釋手。享用一口瑪德蓮，彷彿置身於法式浪漫的氛圍中，帶來一份獨特的味覺體驗。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20014 達克瓦茲
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'達克瓦茲', N'1入', N'甜點', 150, 
N'達克瓦茲（Dacquoise）是一款精緻的法式甜點。它由脆杏仁蛋白餅製成，夾著濃郁的奶油餡，每一口都帶來豐富的層次與口感。杏仁蛋白餅帶有輕盈的口感，融合了杏仁的香氣，使得達克瓦茲獨具特色。奶油餡的香甜與杏仁的香濃相輔相成，令人愛不釋手。達克瓦茲是高超烘焙技藝的代表，它的外觀優雅，可作為節日慶典或特別場合的完美甜點。無論是品味純正法式風味或嘗試不同變化，達克瓦茲都是一場美味的味覺之旅，讓您感受法式烘焙的迷人魅力。',
N'一日', N'冷藏',30,NULL,NULL);
-- 20015 可麗露
insert Product_datatable (f_number,p_name,p_spec,p_category,p_price,p_describe,p_savedate,p_saveway,p_Inventory,p_ship,p_payment) 
values 
(60000, N'可麗露', N'1入', N'甜點', 150, 
N'可麗露（Crêpe）是一種來自法國的經典烹飪薄餅。它由簡單的麵粉、蛋、牛奶和鹽混合而成，製作過程中將薄麵糊平均地撒在熱平底鍋上，烹煎至金黃色。可麗露的口感柔軟細緻，可以是甜的或鹹的。甜的可麗露通常配上水果、巧克力、焦糖或冰淇淋，而鹹的則可搭配起司、火腿、蔬菜等。無論是早餐、下午茶，或是特別場合，可麗露都是受歡迎的美食選擇。它簡單美味，給您帶來一份法式的浪漫風味。',
N'一日', N'冷藏',30,NULL,NULL);


-- Product_picturetable
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20000, N'/img/products/波士頓派.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20001, N'/img/products/AngleCake.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20002, N'/img/products/Classic_Mille_Feuille.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20003, N'/img/products/巧克力慕斯.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20004, N'/img/products/咕咕霍夫.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20005, N'/img/products/布列塔尼.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20006, N'/img/products/穀物麵包.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20007, N'/img/products/巧克力吐司.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20008, N'/img/products/黑吐司.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20009, N'/img/products/磅蛋糕.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20010, N'/img/products/酥皮蛋糕.jpeg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20011, N'/img/products/戚風蛋糕.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20012, N'/img/products/重乳酪蛋糕.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20013, N'/img/products/瑪德蓮.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20014, N'/img/products/達克瓦茲.jpg');
insert into Product_picturetable (p_picnumber,　p_number,　p_url) values(1, 20015, N'/img/products/可麗露.jpg');




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
-- 波士頓派 20000
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20000, 1000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- AngleCake 20001
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20001, 2000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- Classic_Mille_Feuille 20002
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20002, 3000, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 巧克力慕斯 20003
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20003, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 咕咕霍夫 20004
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20004, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 布列塔尼 20005
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20005, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 穀物麵包 20006
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20006, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 巧克力吐司 20007
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20007, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 黑吐司 20008
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20008, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 磅蛋糕 20009
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20009, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 酥皮蛋糕 20010
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20010, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 戚風蛋糕 20011
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20011, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 重乳酪蛋糕 20012
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20012, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 瑪德蓮 20013
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20013, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 達克瓦茲 20014
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20014, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)
-- 可麗露 20015
INSERT [dbo].[Order_datatable] ([o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) 
VALUES 
(CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20015, 2500, 750, N'待成團', N'已送出', NULL, NULL, NULL)

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