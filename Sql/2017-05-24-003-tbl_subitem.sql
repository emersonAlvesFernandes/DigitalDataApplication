CREATE TABLE [dbo].[tbl_subitem]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nom_sitem] VARCHAR(50) NULL, 
	[des_descr] VARCHAR(200) NULL,
    [id_item] INT NULL,

	CONSTRAINT fk_subitem_item
		FOREIGN KEY (id_item)
		REFERENCES dbo.tbl_item (id)
		ON DELETE CASCADE
)



