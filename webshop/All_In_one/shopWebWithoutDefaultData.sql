/****** Object:  Table [dbo].[Customer_accounttable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Firm_accounttable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Firm_pagetable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Group_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Member_membertable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Notify_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Order_assesstable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Order_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Payment_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Product_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Product_picturetable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Product_to_Payment]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Product_to_Ship]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Ship_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Talk_datatable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Talk_membertable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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
/****** Object:  Table [dbo].[Talk_persontable]    Script Date: 2023/7/15 下午 11:30:06 ******/
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