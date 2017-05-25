create procedure dbo.spr_ler_empresa_id
	@id_empre INT NOT NULL
as
begin
	
	select
		empresa.id			
		,empresa.name		
		,empresa.cnpj			
		,empresa.logo				
		,empresa.website	
	from 
		dbo.tbl_empresa empresa
	where 
		empresa.id = @id_empre
	
end


	
				
