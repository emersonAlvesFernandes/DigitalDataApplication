create procedure dbo.spr_ler_empresa
as
begin
	
	select
		id			
		,name		
		,cnpj			
		,logo				
		,website	
	from dbo.tbl_empresa
	
end


	
				
