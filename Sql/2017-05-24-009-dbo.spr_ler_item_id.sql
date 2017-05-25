create procedure dbo.spr_ler_item_id
	@id_item INT NOT NULL
begin
	
	select
		item.id			
		,item.nom_item		
		,item.des_desdo
		,item.des_descr
	from 
		dbo.tbl_item item
	where 
		item.id = @id_item
	
end

