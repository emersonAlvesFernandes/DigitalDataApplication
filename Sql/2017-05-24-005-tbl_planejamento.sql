CREATE TABLE [dbo].[tbl_planejamento]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [val_fatur] DECIMAL(18, 2) NULL, 
    [val_plan] DECIMAL(18, 2) NULL, 
    [val_ini_verde] DECIMAL(18, 2) NULL, 
    [val_fim_verde] DECIMAL(18, 2) NULL, 
    [val_ini_verme] DECIMAL(18, 2) NULL, 
    [val_fim_verme] DECIMAL(18, 2) NULL, 
    [val_pvsto] DECIMAL(18, 2) NULL, 
    [id_emp_item_sitem] INT NULL,
	[cod_mes] NCHAR(10) NULL, 

    CONSTRAINT fk_planejamento_tbl_empresa_item_subitem
	FOREIGN KEY (id_emp_item_sitem)
	REFERENCES dbo.tbl_empresa_item_subitem (Id)
)
