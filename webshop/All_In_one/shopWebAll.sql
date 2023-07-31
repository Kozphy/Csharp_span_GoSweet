CREATE DATABASE [shopweb]
USE [shopweb]
GO
/****** Object:  Table [dbo].[Customer_accounttable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_accounttable](
	[c_nickname] [nvarchar](50) NOT NULL,
	[c_number] [int] IDENTITY(10000,1) NOT NULL,
	[c_account] [nvarchar](100) NOT NULL,
	[c_password] [nvarchar](500) NOT NULL,
	[c_mailpass] [bit] NOT NULL,
 CONSTRAINT [PK_c_accounttable] PRIMARY KEY CLUSTERED 
(
	[c_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firm_accounttable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firm_accounttable](
	[f_number] [int] IDENTITY(60000,1) NOT NULL,
	[f_nickname] [nvarchar](50) NOT NULL,
	[f_account] [nvarchar](100) NOT NULL,
	[f_password] [nvarchar](500) NOT NULL,
	[f_mailpass] [bit] NOT NULL,
 CONSTRAINT [PK_f_accounttable] PRIMARY KEY CLUSTERED 
(
	[f_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firm_pagetable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firm_pagetable](
	[f_number] [int] NOT NULL,
	[f_pagename] [nvarchar](50) NOT NULL,
	[f_message] [nvarchar](500) NULL,
	[f_picurl] [nvarchar](500) NULL,
 CONSTRAINT [PK_f_pagetable] PRIMARY KEY CLUSTERED 
(
	[f_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Member_membertable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Notify_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Order_assesstable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_assesstable](
	[o_number] [int] NOT NULL,
	[o_cscore] [float] NULL,
	[o_ccomment] [nvarchar](500) NULL,
	[o_fscore] [float] NULL,
	[o_fcomment] [nvarchar](500) NULL,
	[p_number] [int] NULL,
 CONSTRAINT [PK_Order_assesstable] PRIMARY KEY CLUSTERED 
(
	[o_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
	[o_place] [nvarchar](500) NULL,
	[o_payment] [int] NULL,
 CONSTRAINT [PK_o_datatable] PRIMARY KEY CLUSTERED 
(
	[o_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Product_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
	[p_describe] [nvarchar](500) NULL,
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
/****** Object:  Table [dbo].[Product_picturetable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_picturetable](
	[p_sort] [int] IDENTITY(1,1) NOT NULL,
	[p_picnumber] [int] NOT NULL,
	[p_number] [int] NOT NULL,
	[p_url] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Product_picturetable] PRIMARY KEY CLUSTERED 
(
	[p_sort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_to_Payment]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Product_to_Ship]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Ship_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Talk_datatable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk_datatable](
	[t_number] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NOT NULL,
	[f_number] [int] NOT NULL,
	[t_time] [datetime] NOT NULL,
	[t_message] [nvarchar](500) NOT NULL,
	[t_read] [int] NOT NULL,
	[t_post] [int] NOT NULL,
 CONSTRAINT [PK_t_datatable] PRIMARY KEY CLUSTERED 
(
	[t_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talk_membertable]    Script Date: 2023/7/25 上午 11:03:30 ******/
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
/****** Object:  Table [dbo].[Talk_persontable]    Script Date: 2023/7/25 上午 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk_persontable](
	[t_forPK] [int] IDENTITY(1,1) NOT NULL,
	[c_number] [int] NULL,
	[f_number] [int] NULL,
	[t_id] [nvarchar](500) NOT NULL,
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
INSERT [dbo].[Customer_accounttable] ([c_nickname], [c_number], [c_account], [c_password], [c_mailpass]) VALUES (N'王曉明', 10004, N'test4@gmail.com', N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Customer_accounttable] OFF
GO
SET IDENTITY_INSERT [dbo].[Firm_accounttable] ON 
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60000, N'祈麟手作', N'test@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60001, N'澎湖黑妞', N'test1@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60002, N'超品起司烘焙工坊', N'test2@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60003, N'超比食品', N'test3@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60004, N'MENIPPE媚力泊', N'test4@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60005, N'雅＋達藤原', N'test5@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60006, N'麥之鄉', N'test6@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60007, N'穀王烘焙', N'test7@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60008, N'亞尼克', N'test8@gmail.com', N'test', 1)
GO
INSERT [dbo].[Firm_accounttable] ([f_number], [f_nickname], [f_account], [f_password], [f_mailpass]) VALUES (60009, N'巴特里', N'test9@gmail.com', N'test', 1)
GO
SET IDENTITY_INSERT [dbo].[Firm_accounttable] OFF
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60000, N'祈麟手作', N'無', N'/img/firmpage/60000.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60001, N'澎湖黑妞', N'無', N'/img/firmpage/60001.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60002, N'超品起司烘焙工坊', N'無', N'/img/firmpage/60002.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60003, N'超比食品', N'無', N'/img/firmpage/60003.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60004, N'MENIPPE媚力泊', N'無', N'/img/firmpage/60004.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60005, N'雅＋達藤原', N'無', N'/img/firmpage/60005.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60006, N'麥之鄉', N'無', N'/img/firmpage/60006.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60007, N'穀王烘焙', N'無', N'/img/firmpage/60007.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60008, N'亞尼克', N'無', N'/img/firmpage/60008.jpg')
GO
INSERT [dbo].[Firm_pagetable] ([f_number], [f_pagename], [f_message], [f_picurl]) VALUES (60009, N'巴特里', N'無', N'/img/firmpage/60009.jpg')
GO
SET IDENTITY_INSERT [dbo].[Group_datatable] ON 
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30000, 60000, 20000, CAST(N'2023-07-01' AS Date), CAST(N'2023-08-30' AS Date), 10, 370)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30001, 60001, 20001, CAST(N'2023-07-07' AS Date), CAST(N'2023-09-20' AS Date), 10, 130)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30002, 60002, 20002, CAST(N'2023-07-11' AS Date), CAST(N'2023-09-10' AS Date), 15, 370)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30003, 60003, 20003, CAST(N'2023-07-12' AS Date), CAST(N'2023-09-10' AS Date), 15, 420)
GO
INSERT [dbo].[Group_datatable] ([g_number], [f_number], [p_number], [g_start], [g_end], [g_maxpeople], [g_price]) VALUES (30004, 60004, 20004, CAST(N'2023-07-13' AS Date), CAST(N'2023-09-10' AS Date), 15, 530)
GO
SET IDENTITY_INSERT [dbo].[Group_datatable] OFF
GO
SET IDENTITY_INSERT [dbo].[Member_membertable] ON 
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40000, 30000, 10, 9, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40001, 30001, 10, 9, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40002, 30002, 15, 13, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40003, 30003, 15, 13, 0)
GO
INSERT [dbo].[Member_membertable] ([m_number], [g_number], [g_maxpeople], [m_nowpeople], [m_status]) VALUES (40004, 30004, 15, 13, 0)
GO
SET IDENTITY_INSERT [dbo].[Member_membertable] OFF
GO
SET IDENTITY_INSERT [dbo].[Notify_datatable] ON 
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (1, NULL, 60000, 50000, N'已下單', 0)
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (2, 10000, NULL, 50000, N'已成團', 0)
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (3, 10001, NULL, 50001, N'已成團', 0)
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (4, 10000, NULL, 50000, N'已寄出', 0)
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (5, 10001, NULL, 50001, N'已寄出', 0)
GO
INSERT [dbo].[Notify_datatable] ([n_number], [c_number], [f_number], [o_number], [o_status], [n_read]) VALUES (6, NULL, 60000, 50001, N'已取貨', 0)
GO
SET IDENTITY_INSERT [dbo].[Notify_datatable] OFF
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment], [p_number]) VALUES (50000, 3.5, N'好吃', 5, N'謝謝光臨', 20000)
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment], [p_number]) VALUES (50001, 4, N'好吃', 5, N'謝謝光臨', 20001)
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment], [p_number]) VALUES (50002, 3.5, N'好吃', 5, N'謝謝光臨', 20002)
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment], [p_number]) VALUES (50006, 4.5, N'好吃', 5, N'謝謝光臨', 20003)
GO
INSERT [dbo].[Order_assesstable] ([o_number], [o_cscore], [o_ccomment], [o_fscore], [o_fcomment], [p_number]) VALUES (50007, 3.5, N'好吃', 5, N'謝謝光臨', 20004)
GO
SET IDENTITY_INSERT [dbo].[Order_datatable] ON 
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50000, CAST(N'2023-07-01' AS Date), CAST(N'2023-07-20' AS Date), 10000, 60000, 0, NULL, 20000, 1, 420, N'已結單', N'已寄出', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50001, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-20' AS Date), 10000, 60001, 0, NULL, 20001, 1, 150, N'已結單', N'已寄出', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50002, CAST(N'2023-07-04' AS Date), CAST(N'2023-07-20' AS Date), 10000, 60002, 0, NULL, 20002, 2, 800, N'已結單', N'已寄出', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50006, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-20' AS Date), 10000, 60003, 0, NULL, 20003, 1, 450, N'已結單', N'已寄出', 1, N'408台中市南屯區公益路二段51號', 1)
GO
INSERT [dbo].[Order_datatable] ([o_number], [o_start], [o_end], [c_number], [f_number], [o_type], [m_number], [p_number], [o_buynumber], [o_price], [o_status], [o_shipstatus], [o_ship], [o_place], [o_payment]) VALUES (50007, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-20' AS Date), 10000, 60004, 0, NULL, 20004, 1, 560, N'已結單', N'已寄出', 1, N'408台中市南屯區公益路二段51號', 1)
GO
SET IDENTITY_INSERT [dbo].[Order_datatable] OFF
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (1, N'超商取貨付款')
GO
INSERT [dbo].[Payment_datatable] ([Payment_number], [Payment_name]) VALUES (2, N'VISA')
GO
SET IDENTITY_INSERT [dbo].[Product_datatable] ON 
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60000, 20000, N'法式生乳雪藏綿', N'/入', N'蛋糕', 420, N'『初心祈 平安麟，用最真的心祈求手作，讓食品吃得安心健康』-是祈麟手作的初發心

嚴選天然食材、高級原料，依循法式手作烘焙技法，製程無加任何一滴水

♥️ 好蛋、好油、好麵粉的原料有那些呢?

奧莉塔橄欖油，可使糕體香氣十足

麵粉選用白菊花麵粉系列，與鼎泰豐同等級麵粉，讓糕體口感紮實有彈性

麗園牧場特選蛋，讓出爐後的蛋糕色澤有著金黃的外表，濃度也比市面上較為濃厚

健康減糖秘訣就是選用赤藻糖醇', N'5天', N'冷藏', 300, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60001, 20001, N'黑妞微晶冷凍堅果糕', N'12塊/包', N'傳統糕點', 150, N'澎湖黑妞堅果糕以Q、軟可口為特色，
淡淡的黑糖香氣與堅果的搭配綿密的口感完美結合，每一口都充滿著堅果香 Q 鬆 軟!

來自外婆澎湖灣的招牌人氣王，包您一口接著一口!', N'2個月', N'冷凍', 50, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60002, 20002, N'糕點界的馬卡龍-綜合冰糕', N'8個/盒', N'傳統糕點', 400, N'台北伴手禮大賽得獎商品，網購人氣冰糕！依循傳統作法以上等純綠豆仁拌入進口橄欖油製作，選用海藻糖降低糖分，口感不同於傳統綠豆糕，冰心綿密爽口，適合闔家享用。', N'180天', N'冷凍', 70, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60003, 20003, N'棗泥冰心綠豆皇', N'12入/盒', N'傳統糕點', 450, N'以新鮮綠豆仁與大豆油搭配海藻糖製成，
口感清涼爽口、微甜不膩，遵循精湛手藝製作，口感細緻入口即化的原始滋味，更是中國御用名點。
內餡經典綿密棗泥，在清爽中透出濃郁回甘，無論休閒茶點或伴手禮皆適宜。
冰心綠豆皇油分含量低，色澤白、厚度薄，很容易碎成粉狀。由於是以新鮮綠豆仁做成的，完全不含防腐劑，
必須低溫保存，外皮因為綠豆仁豆沙細膩，使冰心綠豆皇入口即化，內餡包覆香醇棗泥，
讓口感更加有層次感，除可以吃出綠豆的香氣之外，還多了香醇棗泥的口感。', N'180天', N'冷凍', 90, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60004, 20004, N'純手工土鳳梨酥', N'10入/盒', N'傳統糕點', 560, N'純手工精心製作
獨家酥皮比例濃酥不膩口，外皮酥薄奶香不具油耗味!
香甜內餡是用金鑽鳳梨與土鳳梨以最佳比例調配而成
融合了土鳳梨的微酸及金鑽鳳梨微甜，香氣足而且有鳳梨的纖維口感
比傳統冬瓜酥來得不易膩且低熱量!!
與有著紅寶石之稱的蔓越莓果乾做搭配，酥香帶著酸酸甜甜的好滋味，一口咬下香甜氣味鮮明不黏牙。', N'30天', N'常溫', 120, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60005, 20005, N'豆腐酪', N'12杯/盒', N'布丁', 570, N'使用來自紐西蘭放牧母牛100%純鮮乳，與100％法國AOC認證奶油，日式古法手工製作，軟嫩滑順，奶香濃郁，融合多種頂級食材製作而成，給你入口即化的甜蜜滋味！', N'10天', N'冷藏', 150, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60006, 20006, N'法式楓糖布丁', N'/入', N'蛋糕', 180, N'使用天然食材代替人工香料，低糖低脂無負擔
以海藻糖代替砂糖，海藻糖比一般砂糖貴6倍、甜度為砂糖45％的天然海藻糖，
能有效降低糖分及油脂~降低甜膩感,整體用糖量也減少了20%~~
安定性也比較高~容易消化~低糖低卡路里~', N'7天', N'冷凍', 40, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60007, 20007, N'焦糖布丁蛋糕', N'/盒', N'蛋糕', 190, N'‧ 手工大甲芋頭泥，吃得到顆粒！
‧ 手工相思紅豆泥，吃得到顆粒！
‧ 獨創完美伯爵茶蛋糕，茶香縈繞，鬆軟香綿！
‧ 台灣經典奶茶內餡，輕爽不膩，輕甜迷人！', N'4天', N'冷藏', 100, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60008, 20008, N'生乳捲', N'/入', N'蛋糕', 300, N'香味獨特的阿薩姆紅茶入味捲蛋糕裡,茶香分明不苦澀,再融入北海道奶霜,開啟捲心裡的爽口滋味.茶奶香滿滿地,搭著滑嫩布丁,就是要佔領你的味蕾。', N'3天', N'冷藏', 60, NULL, NULL)
GO
INSERT [dbo].[Product_datatable] ([f_number], [p_number], [p_name], [p_spec], [p_category], [p_price], [p_describe], [p_savedate], [p_saveway], [p_Inventory], [p_ship], [p_payment]) VALUES (60009, 20009, N'人氣爆漿餐包', N'10入/盒', N'麵包', 120, N'．手工搓揉麵糰製成，真材實料
．濃郁內餡，滑順不油膩
．爆漿餡料，吃起來超滿足', N'30天', N'冷凍', 220, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Product_datatable] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_picturetable] ON 
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (1, 1, 20000, N'/img/ProductUrl/20000-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (2, 5, 20000, N'/img/ProductUrl/20000-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (3, 2, 20000, N'/img/ProductUrl/20000-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (5, 1, 20001, N'/img/ProductUrl/20001-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (6, 2, 20001, N'/img/ProductUrl/20001-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (7, 5, 20001, N'/img/ProductUrl/20001-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (8, 1, 20002, N'/img/ProductUrl/20002-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (9, 2, 20002, N'/img/ProductUrl/20002-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (10, 5, 20002, N'/img/ProductUrl/20002-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (11, 1, 20003, N'/img/ProductUrl/20003-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (12, 2, 20003, N'/img/ProductUrl/20003-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (13, 5, 20003, N'/img/ProductUrl/20003-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (14, 1, 20004, N'/img/ProductUrl/20004-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (15, 2, 20004, N'/img/ProductUrl/20004-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (16, 5, 20004, N'/img/ProductUrl/20004-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (17, 1, 20005, N'/img/ProductUrl/20005-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (18, 2, 20005, N'/img/ProductUrl/20005-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (19, 5, 20005, N'/img/ProductUrl/20005-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (20, 1, 20006, N'/img/ProductUrl/20006-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (21, 2, 20006, N'/img/ProductUrl/20006-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (22, 5, 20006, N'/img/ProductUrl/20006-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (23, 1, 20007, N'/img/ProductUrl/20007-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (24, 2, 20007, N'/img/ProductUrl/20007-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (25, 5, 20007, N'/img/ProductUrl/20007-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (26, 1, 20008, N'/img/ProductUrl/20008-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (27, 2, 20008, N'/img/ProductUrl/20008-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (28, 5, 20008, N'/img/ProductUrl/20008-5.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (29, 1, 20009, N'/img/ProductUrl/20009-1.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (30, 2, 20009, N'/img/ProductUrl/20009-2.jpg')
GO
INSERT [dbo].[Product_picturetable] ([p_sort], [p_picnumber], [p_number], [p_url]) VALUES (31, 5, 20009, N'/img/ProductUrl/20009-5.jpg')
GO
SET IDENTITY_INSERT [dbo].[Product_picturetable] OFF
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
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (3, N'OK')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (4, N'萊爾富')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (5, N'宅配 --黑貓')
GO
INSERT [dbo].[Ship_datatable] ([ship_number], [ship_name]) VALUES (6, N'宅配 --郵局')
GO
SET IDENTITY_INSERT [dbo].[Talk_datatable] ON 
GO
INSERT [dbo].[Talk_datatable] ([t_number], [c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (47, 10000, 60000, CAST(N'2023-07-25T10:10:52.000' AS DateTime), N'我是客戶', 0, 0)
GO
INSERT [dbo].[Talk_datatable] ([t_number], [c_number], [f_number], [t_time], [t_message], [t_read], [t_post]) VALUES (48, 10000, 60000, CAST(N'2023-07-25T10:11:03.000' AS DateTime), N'我是廠商', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Talk_datatable] OFF
GO
SET IDENTITY_INSERT [dbo].[Talk_membertable] ON 
GO
INSERT [dbo].[Talk_membertable] ([Talk_member_id], [c_number], [f_number]) VALUES (12, 10000, 60000)
GO
SET IDENTITY_INSERT [dbo].[Talk_membertable] OFF
GO
SET IDENTITY_INSERT [dbo].[Talk_persontable] ON 
GO
INSERT [dbo].[Talk_persontable] ([t_forPK], [c_number], [f_number], [t_id]) VALUES (1, NULL, 60000, N'3fX9bL7AZxNVmpEbWJCNxQ')
GO
INSERT [dbo].[Talk_persontable] ([t_forPK], [c_number], [f_number], [t_id]) VALUES (2, 10000, NULL, N'eiO5HJk1GkRYeqrqxA7qyw')
GO
SET IDENTITY_INSERT [dbo].[Talk_persontable] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer_accounttable]    Script Date: 2023/7/25 上午 11:03:30 ******/
ALTER TABLE [dbo].[Customer_accounttable] ADD  CONSTRAINT [IX_Customer_accounttable] UNIQUE NONCLUSTERED 
(
	[c_account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Firm_accounttable]    Script Date: 2023/7/25 上午 11:03:30 ******/
ALTER TABLE [dbo].[Firm_accounttable] ADD  CONSTRAINT [IX_Firm_accounttable] UNIQUE NONCLUSTERED 
(
	[f_account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[Order_assesstable]  WITH CHECK ADD  CONSTRAINT [FK_Order_assesstable_Product_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Order_assesstable] CHECK CONSTRAINT [FK_Order_assesstable_Product_datatable]
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
ALTER TABLE [dbo].[Talk_membertable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_membertable_Customer_accounttable] FOREIGN KEY([c_number])
REFERENCES [dbo].[Customer_accounttable] ([c_number])
GO
ALTER TABLE [dbo].[Talk_membertable] CHECK CONSTRAINT [FK_Talk_membertable_Customer_accounttable]
GO
ALTER TABLE [dbo].[Talk_membertable]  WITH CHECK ADD  CONSTRAINT [FK_Talk_membertable_Firm_accounttable] FOREIGN KEY([f_number])
REFERENCES [dbo].[Firm_accounttable] ([f_number])
GO
ALTER TABLE [dbo].[Talk_membertable] CHECK CONSTRAINT [FK_Talk_membertable_Firm_accounttable]
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



