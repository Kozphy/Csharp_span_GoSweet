-- �U��
select n_number,c_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number and Notify_datatable.o_status = N'�w�H�X'
join Customer_accounttable on Notify_datatable.c_number = Customer_accounttable.c_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number

-- �U��
select n_number, c_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number and Notify_datatable.o_status = N'�w����'
join Customer_accounttable on Notify_datatable.c_number = Customer_accounttable.c_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number

-- without account, �U��
select  Notify_datatable.c_number,Order_datatable.o_number,n_number, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
where  Notify_datatable.o_status = N'�w�H�X' and Notify_datatable.n_read = 0
go

-- have account
-- order, �U��
select  Notify_datatable.c_number, Order_datatable.o_number,n_number, c_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join Customer_accounttable on Notify_datatable.c_number = Customer_accounttable.c_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
where  Notify_datatable.o_status = N'�w�H�X' and Customer_accounttable.c_account = N'test@gmail.com'

-- group, �U��
select   Group_datatable.g_number, Order_datatable.o_number,n_number, c_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join Customer_accounttable on Notify_datatable.c_number = Customer_accounttable.c_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
join Group_datatable on Product_datatable.p_number = Group_datatable.p_number
where  Notify_datatable.o_status = N'�w����' and Customer_accounttable.c_account = N'test@gmail.com'

-- gropu + order, �U��
select  Customer_accounttable.c_number, Order_datatable.o_number, Group_datatable.g_number, n_number, c_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join Customer_accounttable on Notify_datatable.c_number = Customer_accounttable.c_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
join Group_datatable on Product_datatable.p_number = Group_datatable.p_number
where  (Notify_datatable.o_status = N'�w����' or Notify_datatable.o_status = N'�w�H�X')  and Customer_accounttable.c_account = N'test@gmail.com'

-- gropu + order, �U��
SELECT        Notify_datatable.o_status, Notify_datatable.o_number, Product_datatable.p_name
FROM            Customer_accounttable INNER JOIN
                         Notify_datatable ON Customer_accounttable.c_number = Notify_datatable.c_number INNER JOIN
                         Order_datatable ON Customer_accounttable.c_number = Order_datatable.c_number AND Notify_datatable.o_number = Order_datatable.o_number INNER JOIN
                         Product_datatable ON Order_datatable.p_number = Product_datatable.p_number where  Notify_datatable.o_status = N'�w����' and Customer_accounttable.c_account = N'test@gmail.com'

-- �t��
select Firm_accounttable.f_number, Order_datatable.o_number, n_number, f_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join [dbo].[Firm_accounttable] on Notify_datatable.f_number = Firm_accounttable.f_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
where  (Notify_datatable.o_status = N'�w�U��')  and Firm_accounttable.f_account = N'test@gmail.com'

select  Firm_accounttable.f_number, Order_datatable.o_number, n_number, f_account, Product_datatable.p_name, Notify_datatable.o_status
from Notify_datatable
join Order_datatable on Notify_datatable.o_number = Order_datatable.o_number
join [dbo].[Firm_accounttable] on Notify_datatable.f_number = Firm_accounttable.f_number
join Product_datatable on Product_datatable.p_number = Order_datatable.p_number
where  (Notify_datatable.o_status = N'�w���f')  and Firm_accounttable.f_account = N'test@gmail.com'