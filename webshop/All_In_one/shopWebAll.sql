/****** Object:  Table [dbo].[Customer_accounttable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_accounttable](
	[c_nickname] [nvarchar](10) NOT NULL,
	[c_number] [int] IDENTITY(10000,1) NOT NULL,
	[c_account] [nvarchar](50) NOT NULL,
	[c_password] [nvarchar](50) NOT NULL,
	[c_mailpass] [bit] NOT NULL,
 CONSTRAINT [PK_c_accounttable] PRIMARY KEY CLUSTERED 
(
	[c_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firm_accounttable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firm_accounttable](
	[f_number] [int] IDENTITY(60000,1) NOT NULL,
	[f_nickname] [nvarchar](50) NOT NULL,
	[f_account] [nvarchar](50) NOT NULL,
	[f_password] [nvarchar](50) NOT NULL,
	[f_mailpass] [bit] NOT NULL,
 CONSTRAINT [PK_f_accounttable] PRIMARY KEY CLUSTERED 
(
	[f_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firm_pagetable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firm_pagetable](
	[f_number] [int] NOT NULL,
	[f_pagename] [nvarchar](50) NOT NULL,
	[f_message] [nvarchar](50) NULL,
	[f_picurl] [nvarchar](50) NULL,
 CONSTRAINT [PK_f_pagetable] PRIMARY KEY CLUSTERED 
(
	[f_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group_datatable](
	[g_number] [int] IDENTITY(30000,1) NOT NULL,
	[f_number] [int] NOT NULL,
	[p_number] [int] NOT NULL,
	[g_start] [date] NOT NULL,
	[g_end] [date] NOT NULL,
	[g_maxpeople] [int] NOT NULL,
	[g_price] [int] NOT NULL,
 CONSTRAINT [PK_g_datatable] PRIMARY KEY CLUSTERED 
(
	[g_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member_membertable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member_membertable](
	[m_number] [int] IDENTITY(40000,1) NOT NULL,
	[g_number] [int] NOT NULL,
	[g_maxpeople] [int] NOT NULL,
	[m_nowpeople] [int] NOT NULL,
	[m_status] [bit] NOT NULL,
 CONSTRAINT [PK_m_membertable] PRIMARY KEY CLUSTERED 
(
	[m_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notify_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notify_datatable](
	[n_number] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NULL,
	[f_number] [int] NULL,
	[o_number] [int] NOT NULL,
	[o_status] [nvarchar](50) NOT NULL,
	[n_read] [bit] NULL,
 CONSTRAINT [PK_Notify_datatable] PRIMARY KEY CLUSTERED 
(
	[n_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_assesstable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_assesstable](
	[o_number] [int] NOT NULL,
	[o_cscore] [float] NULL,
	[o_ccomment] [nvarchar](50) NULL,
	[o_fscore] [float] NULL,
	[o_fcomment] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order_assesstable] PRIMARY KEY CLUSTERED 
(
	[o_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_datatable](
	[o_number] [int] IDENTITY(50000,1) NOT NULL,
	[o_start] [date] NOT NULL,
	[o_end] [date] NULL,
	[c_number] [int] NOT NULL,
	[f_number] [int] NOT NULL,
	[o_type] [bit] NOT NULL,
	[m_number] [int] NULL,
	[p_number] [int] NOT NULL,
	[o_buynumber] [int] NOT NULL,
	[o_price] [int] NOT NULL,
	[o_status] [nvarchar](50) NOT NULL,
	[o_shipstatus] [nvarchar](50) NOT NULL,
	[o_ship] [int] NULL,
	[o_place] [nvarchar](50) NULL,
	[o_payment] [int] NULL,
 CONSTRAINT [PK_o_datatable] PRIMARY KEY CLUSTERED 
(
	[o_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_datatable](
	[Payment_number] [int] NOT NULL,
	[Payment_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_datatable] PRIMARY KEY CLUSTERED 
(
	[Payment_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_datatable](
	[f_number] [int] NOT NULL,
	[p_number] [int] IDENTITY(20000,1) NOT NULL,
	[p_name] [nvarchar](50) NOT NULL,
	[p_spec] [nvarchar](50) NULL,
	[p_category] [nvarchar](50) NOT NULL,
	[p_price] [int] NOT NULL,
	[p_describe] [nvarchar](50) NULL,
	[p_savedate] [nvarchar](500) NULL,
	[p_saveway] [nvarchar](50) NULL,
	[p_Inventory] [int] NOT NULL,
	[p_ship] [int] NULL,
	[p_payment] [int] NULL,
 CONSTRAINT [PK_p_datatable] PRIMARY KEY CLUSTERED 
(
	[p_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_picturetable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_picturetable](
	[p_picnumber] [int] NOT NULL,
	[p_number] [int] NOT NULL,
	[p_url] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_p_picturetable] PRIMARY KEY CLUSTERED 
(
	[p_picnumber] ASC,
	[p_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_to_Payment]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_to_Payment](
	[p_number] [int] NOT NULL,
	[Payment_number] [int] NOT NULL,
 CONSTRAINT [PK_Product_to_Payment] PRIMARY KEY CLUSTERED 
(
	[p_number] ASC,
	[Payment_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_to_Ship]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_to_Ship](
	[p_number] [int] NOT NULL,
	[ship_number] [int] NOT NULL,
 CONSTRAINT [PK_Product_to_Ship] PRIMARY KEY CLUSTERED 
(
	[p_number] ASC,
	[ship_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ship_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ship_datatable](
	[ship_number] [int] NOT NULL,
	[ship_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ship_datatable] PRIMARY KEY CLUSTERED 
(
	[ship_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talk_datatable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk_datatable](
	[t_number] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NOT NULL,
	[f_number] [int] NOT NULL,
	[t_time] [datetime] NOT NULL,
	[t_message] [nvarchar](50) NOT NULL,
	[t_read] [bit] NOT NULL,
	[t_post] [int] NOT NULL,
 CONSTRAINT [PK_t_datatable] PRIMARY KEY CLUSTERED 
(
	[t_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talk_membertable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk_membertable](
	[Talk_member_id] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NOT NULL,
	[f_number] [int] NOT NULL,
 CONSTRAINT [PK_Talk_membertable] PRIMARY KEY CLUSTERED 
(
	[Talk_member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talk_persontable]    Script Date: 2023/7/15 下午 08:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk_persontable](
	[t_forPK] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NULL,
	[f_number] [int] NULL,
	[t_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Talk_persontable] PRIMARY KEY CLUSTERED 
(
	[t_forPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer_accounttable] ON 
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'李銘翔', 10000, N'test@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'黃瀞儀', 10001, N'test1@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'廖胤翔', 10002, N'test2@gmail.com', N'test', 0)
GO
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'趙晟佑', 10003, N'test3@gmail.com', N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Customer_accounttable] OFF
GO
SET IDENTITY_INSERT [dbo].[Firm_accounttable] ON 
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60000, N'巴特里', N'test@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60001, N'麥之鄉', N'test2@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60002, N'穀王烘焙', N'test3@gmail.com', N'test', 1)
GO
SET IDENTITY_INSERT [dbo].[Firm_accounttable] OFF
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60000, N'巴特里', N'販賣各式糕點店', N'/img/order/廠商.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60001, N'麥之鄉', N'販賣各種口味的法式布丁', N'/img/order/廠商2.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60002, N'穀王烘焙', N'販賣各式黑糖糕點店', NULL)
GO
SET IDENTITY_INSERT [dbo].[Group_datatable] ON 
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30000, 60000, 20000, CAST(N'2023-07-01' AS Date), CAST(N'2023-08-30' AS Date), 20, 250)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30001, 60001, 20001, CAST(N'2023-07-07' AS Date), CAST(N'2023-09-20' AS Date), 17, 450)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30002, 60002, 20002, CAST(N'2023-07-11' AS Date), CAST(N'2023-09-10' AS Date), 15, 370)
GO
SET IDENTITY_INSERT [dbo].[Group_datatable] OFF
GO
SET IDENTITY_INSERT [dbo].[Member_membertable] ON 
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40000, 30000, 20, 10, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40001, 30001, 17, 11, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40002, 30002, 15, 13, 0)
GO
SET IDENTITY_INSERT [dbo].[Member_membertable] OFF
GO
SET IDENTITY_INSERT [dbo].[Notify_datatable] ON 
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (1, NULL, 60000, 50000, N'已下單', 0)
GO
SET IDENTITY_INSERT [dbo].[Notify_datatable] OFF
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment]) VALUES (50000, 4.5, N'普通gg 555fff
jiji
好吃', 5, N'歡迎下次購買其他品項')
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment]) VALUES (50001, 4.5, N'gggg', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Order_datatable] ON 
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50000, CAST(N'2023-07-01' AS Date), CAST(N'2023-07-15' AS Date), 10000, 60000, 1, 40000, 20000, 3, 750, N'已結單', N'已取貨', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50001, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-13' AS Date), 10000, 60001, 0, NULL, 20001, 2, 1000, N'已結單', N'已取貨', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50002, CAST(N'2023-07-04' AS Date), NULL, 10002, 60002, 1, 40002, 20002, 3, 1110, N'待成團', N'未出貨', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Order_datatable] OFF
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (1, N'超商取貨付款')
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (2, N'VISA')
GO
SET IDENTITY_INSERT [dbo].[Product_datatable] ON 
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60000, 20000, N'奶油爆漿餐包', N'6入/包', N'餐包', 300, N'好吃奶油餐包', N'一週', N'冷藏', 300, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60001, 20001, N'法式楓糖布丁', N'/入', N'布丁', 500, N'好吃法式布丁', N'五天', N'冷藏', 50, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60002, 20002, N'焦糖布丁蛋糕', N'/盒', N'布丁', 400, N'好吃焦糖蛋糕', N'四天', N'冷藏', 70, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Product_datatable] OFF
GO
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (1, 20000, N'/img/order/蛋糕.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (1, 20001, N'/img/order/蛋糕2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_picnumber], [p_number], [p_url]) VALUES (2, 20000, N'/img2')
GO
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Payment] ([p_number], [Payment_number]) VALUES (20000, 2)
GO
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 1)
GO
INSERT [dbo].[Product_to_Ship] ([p_number], [ship_number]) VALUES (20000, 2)
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (1, N'全家')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (2, N'7-11')
GO
SET IDENTITY_INSERT [dbo].[Talk_datatable] ON 
GO
INSERT [dbo].[Talk_datatable] ([t_number], [c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (1, 10000, 60000, CAST(N'2007-06-11T13:50:30.000' AS DateTime), N'我收到的不是餐包', 0, 0)
GO
INSERT [dbo].[Talk_datatable] ([t_number], [c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (3, 10000, 60000, CAST(N'2023-06-11T15:30:33.000' AS DateTime), N'呼叫廠商', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Talk_datatable] OFF
GO
SET IDENTITY_INSERT [dbo].[Talk_membertable] ON 
GO
INSERT [dbo].[Talk_membertable] ([Talk_member_id], [c_number], [f_number]) VALUES (5, 10000, 60000)
GO
INSERT [dbo].[Talk_membertable] ([Talk_member_id], [c_number], [f_number]) VALUES (7, 10000, 60001)
GO
SET IDENTITY_INSERT [dbo].[Talk_membertable] OFF
GO
SET IDENTITY_INSERT [dbo].[Talk_persontable] ON 
GO
INSERT [dbo].[Talk_persontable] ([t_forPK], [c_number], [f_number], [t_id]) VALUES (1, NULL, 60000, N'1--XnJQElaTboh2OC2_iAA')
GO
SET IDENTITY_INSERT [dbo].[Talk_persontable] OFF
GO
ALTER TABLE [dbo].[Firm_pagetable]  WITH CHECK ADD  CONSTRAINT [FK_Firm_pagetable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Firm_pagetable] CHECK CONSTRAINT [FK_Firm_pagetable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Group_datatable]  WITH CHECK ADD  CONSTRAINT [FK_g_datatable_p_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Group_datatable] CHECK CONSTRAINT [FK_g_datatable_p_datatable]
GO
ALTER TABLE [dbo].[Group_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Group_datatable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Group_datatable] CHECK CONSTRAINT [FK_Group_datatable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Member_membertable]  WITH CHECK ADD  CONSTRAINT [FK_m_membertable_g_datatable] FOREIGN KEY([g_number])
REFERENCES [dbo].[Group_datatable] ([g_number])
GO
ALTER TABLE [dbo].[Member_membertable] CHECK CONSTRAINT [FK_m_membertable_g_datatable]
GO
ALTER TABLE [dbo].[Notify_datatable]  WITH CHECK ADD  CONSTRAINT [FK_n_datatable_o_datatable] FOREIGN KEY([o_number])
REFERENCES [dbo].[Order_datatable] ([o_number])
GO
ALTER TABLE [dbo].[Notify_datatable] CHECK CONSTRAINT [FK_n_datatable_o_datatable]
GO
ALTER TABLE [dbo].[Notify_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Notify_datatable_Customer_accounttable] FOREIGN KEY([c_number])
REFERENCES [dbo].[Customer_accounttable] ([c_number])
GO
ALTER TABLE [dbo].[Notify_datatable] CHECK CONSTRAINT [FK_Notify_datatable_Customer_accounttable]
GO
ALTER TABLE [dbo].[Notify_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Notify_datatable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Notify_datatable] CHECK CONSTRAINT [FK_Notify_datatable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Order_assesstable]  WITH CHECK ADD  CONSTRAINT [FK_o_assesstable_o_datatable] FOREIGN KEY([o_number])
REFERENCES [dbo].[Order_datatable] ([o_number])
GO
ALTER TABLE [dbo].[Order_assesstable] CHECK CONSTRAINT [FK_o_assesstable_o_datatable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_o_datatable_m_membertable] FOREIGN KEY([m_number])
REFERENCES [dbo].[Member_membertable] ([m_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_o_datatable_m_membertable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_o_datatable_p_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_o_datatable_p_datatable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Order_datatable_Customer_accounttable] FOREIGN KEY([c_number])
REFERENCES [dbo].[Customer_accounttable] ([c_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_Order_datatable_Customer_accounttable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Order_datatable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_Order_datatable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Order_datatable_Payment_datatable] FOREIGN KEY([o_payment])
REFERENCES [dbo].[Payment_datatable] ([Payment_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_Order_datatable_Payment_datatable]
GO
ALTER TABLE [dbo].[Order_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Order_datatable_Ship_datatable] FOREIGN KEY([o_ship])
REFERENCES [dbo].[Ship_datatable] ([ship_number])
GO
ALTER TABLE [dbo].[Order_datatable] CHECK CONSTRAINT [FK_Order_datatable_Ship_datatable]
GO
ALTER TABLE [dbo].[Product_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Product_datatable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Product_datatable] CHECK CONSTRAINT [FK_Product_datatable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Product_picturetable]  WITH CHECK ADD  CONSTRAINT [FK_p_picturetable_p_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Product_picturetable] CHECK CONSTRAINT [FK_p_picturetable_p_datatable]
GO
ALTER TABLE [dbo].[Product_to_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Product_to_Payment_Payment_datatable] FOREIGN KEY([Payment_number])
REFERENCES [dbo].[Payment_datatable] ([Payment_number])
GO
ALTER TABLE [dbo].[Product_to_Payment] CHECK CONSTRAINT [FK_Product_to_Payment_Payment_datatable]
GO
ALTER TABLE [dbo].[Product_to_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Product_to_Payment_Product_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Product_to_Payment] CHECK CONSTRAINT [FK_Product_to_Payment_Product_datatable]
GO
ALTER TABLE [dbo].[Product_to_Ship]  WITH CHECK ADD  CONSTRAINT [FK_Product_to_Ship_Product_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Product_to_Ship] CHECK CONSTRAINT [FK_Product_to_Ship_Product_datatable]
GO
ALTER TABLE [dbo].[Product_to_Ship]  WITH CHECK ADD  CONSTRAINT [FK_Product_to_Ship_Ship_datatable] FOREIGN KEY([ship_number])
REFERENCES [dbo].[Ship_datatable] ([ship_number])
GO
ALTER TABLE [dbo].[Product_to_Ship] CHECK CONSTRAINT [FK_Product_to_Ship_Ship_datatable]
GO
ALTER TABLE [dbo].[Talk_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_datatable_Customer_accounttable] FOREIGN KEY([c_number])
REFERENCES [dbo].[Customer_accounttable] ([c_number])
GO
ALTER TABLE [dbo].[Talk_datatable] CHECK CONSTRAINT [FK_Talk_datatable_Customer_accounttable]
GO
ALTER TABLE [dbo].[Talk_datatable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_datatable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Talk_datatable] CHECK CONSTRAINT [FK_Talk_datatable_Firm_accounttable]
GO
ALTER TABLE [dbo].[Talk_persontable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_persontable_Customer_accounttable] FOREIGN KEY([c_number])
REFERENCES [dbo].[Customer_accounttable] ([c_number])
GO
ALTER TABLE [dbo].[Talk_persontable] CHECK CONSTRAINT [FK_Talk_persontable_Customer_accounttable]
GO
ALTER TABLE [dbo].[Talk_persontable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_persontable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Talk_persontable] CHECK CONSTRAINT [FK_Talk_persontable_Firm_accounttable]
GO