CREATE TABLE [dbo].[tbl_empresa] (
    [id]        INT             IDENTITY (1, 1) NOT NULL,
    [nom_empre] VARCHAR (60)    NOT NULL,
    [des_cnpj]  VARCHAR (14)    NOT NULL,
    [val_logo]  VARBINARY (MAX) NULL,
    [des_site]  VARCHAR (50)    NULL,
    [des_email] VARCHAR (50)    NULL,
    [cod_ende]  INT             NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

