declare @encrypt varbinary(200) 
select @encrypt = EncryptByPassPhrase('key', '1234' )
select @encrypt 
 
select convert(varchar(100),DecryptByPassPhrase('key', @encrypt ))