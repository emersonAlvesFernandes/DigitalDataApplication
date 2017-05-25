CREATE TABLE [dbo].[tbl_empresa_item_subitem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_empresa] INT NULL, 
    [id_item] INT NULL, 
    [id_subitem] INT NOT NULL

	CONSTRAINT fk_tbl_empresa_item_subitem_tbl_empresa
	FOREIGN KEY (id_empresa)
	REFERENCES dbo.tbl_empresa (id)

	CONSTRAINT fk_tbl_empresa_item_subitem_tbl_item
	FOREIGN KEY (id_item)
	REFERENCES dbo.tbl_item (id)

	CONSTRAINT fk_tbl_empresa_item_subitem_tbl_subitem
	FOREIGN KEY (id_subitem)
	REFERENCES dbo.tbl_subitem (id)
		
)
