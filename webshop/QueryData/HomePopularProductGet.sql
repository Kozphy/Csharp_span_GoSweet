select Product_datatable.p_number ,Product_datatable.p_name, Product_datatable.p_category, Product_picturetable.p_url, AVG(Product_datatable.p_price) AS UnitPrice, Product_datatable.p_describe, SUM(Order_datatable.o_buynumber) AS totalBuyNum  from Product_datatable 
join Product_picturetable on Product_datatable.p_number = Product_picturetable.p_number
join Order_datatable on Order_datatable.p_number = Product_datatable.p_number
where Product_picturetable.p_picnumber = 1
group by Product_datatable.p_number, Product_datatable.p_name, Product_datatable.p_category, Product_picturetable.p_url, Product_datatable.p_describe
order by totalBuyNum desc