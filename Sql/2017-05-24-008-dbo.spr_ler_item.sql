create procedure dbo.spr_ler_item
begin
	
	select
		id			
		,nom_item		
		,des_desdo
		,des_descr
	from dbo.tbl_item
	
end

