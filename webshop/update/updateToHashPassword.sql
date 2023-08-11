update Firm_accounttable
set f_password = CONVERT(NVARCHAR(MAX), HASHBYTES('SHA2_256', '12345678'), 2)
where f_number < 60013

update Customer_accounttable
set c_password = CONVERT(NVARCHAR(MAX), HASHBYTES('SHA2_256', '12345678'), 2)
where c_number < 10005