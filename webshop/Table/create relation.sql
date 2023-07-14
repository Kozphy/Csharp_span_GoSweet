ALTER TABLE [dbo].[Firm_pagetable]  WITH CHECK ADD  CONSTRAINT [FK_Firm_pagetable_Firm_accounttable] FOREIGN KEY([f_numberr])
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
ALTER TABLE [dbo].[Order_assesstable]  WITH CHECK ADD  CONSTRAINT [FK_o_assesstable_p_datatable] FOREIGN KEY([p_number])
REFERENCES [dbo].[Product_datatable] ([p_number])
GO
ALTER TABLE [dbo].[Order_assesstable] CHECK CONSTRAINT [FK_o_assesstable_p_datatable]
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
