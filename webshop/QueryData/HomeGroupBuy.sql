select TOP 4 Member_membertable.m_number,Product_datatable.p_name, Product_picturetable.p_url, 
Product_datatable.p_describe, Group_datatable.g_maxpeople, SUM(Member_membertable.m_nowpeople) as totalBuyNow, Group_datatable.g_end,
(SUM(Member_membertable.m_nowpeople) * 100 / Group_datatable.g_maxpeople)
from Product_datatable
join Product_picturetable on Product_datatable.p_number = Product_picturetable.p_number
join Group_datatable on Group_datatable.p_number = Product_datatable.p_number 
join Member_membertable on Member_membertable.g_number = Group_datatable.g_number
where Product_picturetable.p_picnumber = 1
group by Member_membertable.m_number,Product_datatable.p_name, Product_picturetable.p_url,Product_datatable.p_describe, Group_datatable.g_maxpeople, Member_membertable.g_maxpeople, Group_datatable.g_end
order by totalBuyNow

select  * 
from Product_datatable
join Product_picturetable on Product_datatable.p_number = Product_picturetable.p_number
join Group_datatable on Group_datatable.p_number = Product_datatable.p_number 
join Member_membertable on Member_membertable.g_number = Group_datatable.g_number
where Product_picturetable.p_picnumber = 1
