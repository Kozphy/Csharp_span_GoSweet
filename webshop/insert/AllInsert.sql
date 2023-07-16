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

-- Notify_datatable, n_number identity: 1
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (NULL, 60000, 50000, N'已下單', 0)

-- Order_assesstable
INSERT [dbo].[Order_assesstable] ([o_number], [p_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment]) VALUES (50000, 20000, 3, N'普通', 5, N'歡迎下次購買其他品項')
GO


-- Order_datatable, o_number identity: 50000
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (CAST(N'2023-07-01' AS Date), NULL, 10000, 60000, 1, 40000, 20000, 3, 750, N'待成團', N'已送出', NULL, NULL, NULL)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (CAST(N'2023-07-03' AS Date), NULL, 10000, 60001, 0, NULL, 20001, 2, 1000, N'已下單', N'未送出', NULL, NULL, NULL)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (CAST(N'2023-07-04' AS Date), NULL, 10002, 60002, 1, 40002, 20002, 3, 1110, N'待成團', N'未出貨', NULL, NULL, NULL)
GO

-- Payment_datatable 
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (1, N'超商取貨付款')
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (2, N'VISA')
GO

-- Product_datatable, p_number identity: 20000
INSERT [dbo].[Product_datatable] ([f_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60000, N'奶油爆漿餐包', N'6入/包', N'餐包', 300, N'好吃奶油餐包', N'一週', N'冷藏', 300, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60001, N'法式楓糖布丁', N'/入', N'布丁', 500, N'好吃法式布丁', N'五天', N'冷藏', 50, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60002, N'焦糖布丁蛋糕', N'/盒', N'布丁', 400, N'好吃焦糖蛋糕', N'四天', N'冷藏', 70, NULL, NULL)
GO

-- Product_picturetable
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (1, 20000, N'/img/order/蛋糕.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (1, 20001, N'/img/order/蛋糕2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (2, 20000, N'/img2')
GO

-- Product_to_Payment
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 2)
GO

-- Product_to_Ship
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 2)
GO

-- Ship_datatable
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (1, N'全家')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (2, N'7-11')
GO