CREATE TABLE [dbo].[tbl_empresa]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [nom_empre] VARCHAR(60) NOT NULL, 
    [des_cnpj] VARCHAR(14) NOT NULL, 
    [val_logo] VARBINARY(MAX) NULL, 
    [des_site] VARCHAR(50) NULL
)
