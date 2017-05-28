create procedure dbo.spr_ler_item_planejamento
	@id_empresa INT NOT NULL,
	@id_item INT NOT NULL,	
begin
	
	select
		planejamento.id								
        ,planejamento.val_fatur					
        ,planejamento.val_plan					
        ,planejamento.val_ini_verde			
        ,planejamento.val_fim_verde			
        ,planejamento.val_ini_verme			
        ,planejamento.val_fim_verme			
        ,planejamento.val_pvsto					
        ,planejamento.id_emp_item_sitem	
        ,planejamento.cod_mes					
	
	from 
		dbo.tbl_planejamento planejamento
			inner join dbo.tbl_empresa_item_subitem relac
				on planejamento.id_emp_item_sitem = relac.id
					
	where 
		relac.id_empresa = @id_empresa
		and relac.id_item = @id_item
							
end

