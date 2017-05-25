create procedure dbo.spr_ler_subitem
	@id_item INT NOT NULL
begin
	
	select
		id			
		,nom_sitem		
		,des_descr							
	from 
		dbo.tbl_subitem subitem
	where 
		subitem.id_item = @id_item 
	
	
end

