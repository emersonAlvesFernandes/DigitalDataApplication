USE [master]
GO
/****** Object:  Database [DigitalDataDB]    Script Date: 04/09/2017 23:54:02 ******/
CREATE DATABASE [DigitalDataDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DigitalDataDB', FILENAME = N'C:\Users\Pichau\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\DigitalDataDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DigitalDataDB_log', FILENAME = N'C:\Users\Pichau\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\DigitalDataDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DigitalDataDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DigitalDataDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DigitalDataDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [DigitalDataDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [DigitalDataDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [DigitalDataDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [DigitalDataDB] SET ARITHABORT ON 
GO
ALTER DATABASE [DigitalDataDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DigitalDataDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DigitalDataDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DigitalDataDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DigitalDataDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [DigitalDataDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [DigitalDataDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DigitalDataDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [DigitalDataDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DigitalDataDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DigitalDataDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DigitalDataDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DigitalDataDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DigitalDataDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DigitalDataDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DigitalDataDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DigitalDataDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DigitalDataDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DigitalDataDB] SET  MULTI_USER 
GO
ALTER DATABASE [DigitalDataDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DigitalDataDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DigitalDataDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DigitalDataDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DigitalDataDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DigitalDataDB] SET QUERY_STORE = OFF
GO
USE [DigitalDataDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DigitalDataDB]
GO
/****** Object:  Table [dbo].[tbl_empresa]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empresa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom_empre] [varchar](60) NOT NULL,
	[des_cnpj] [varchar](14) NOT NULL,
	[val_logo] [varbinary](max) NULL,
	[des_site] [varchar](50) NULL,
	[des_email] [varchar](50) NULL,
	[ind_ativa] [bit] NULL,
	[dat_criac] [nchar](10) NULL,
	[dat_atual] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empresa_endereco]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empresa_endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_empre] [int] NULL,
	[id_ender] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empresa_item_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empresa_item_subitem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_empresa] [int] NOT NULL,
	[id_item] [int] NOT NULL,
	[id_subitem] [int] NULL,
	[dat_criac] [datetime] NULL,
	[cod_usu] [int] NULL,
	[ind_ativ] [bit] NULL,
	[dat_inat] [nchar](10) NULL,
	[cod_usu_inat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empresa_usuario]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empresa_usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_endereco]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[des_logra] [varchar](100) NULL,
	[num_logra] [int] NULL,
	[num_cep] [int] NULL,
	[val_compl] [varchar](10) NULL,
	[nom_cidad] [varchar](50) NULL,
	[nom_estad] [varchar](50) NULL,
	[nom_bairr] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_funcionalidade]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_funcionalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[des_funcionalidade] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom_item] [varchar](25) NOT NULL,
	[ind_desdo] [bit] NULL,
	[des_descr] [varchar](200) NOT NULL,
	[dat_criac] [datetime] NOT NULL,
	[dat_atual] [datetime] NOT NULL,
	[ind_ativa] [bit] NOT NULL,
	[cod_usu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_item_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_item_subitem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_item] [int] NOT NULL,
	[id_subitem] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_perfil]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[des_perfil] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_perfil_funcionalidade]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_perfil_funcionalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_perfil] [int] NULL,
	[id_funcionalidade] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_planejamento]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_planejamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[val_fatur] [decimal](18, 2) NULL,
	[val_plan] [decimal](18, 2) NULL,
	[val_ini_verde] [decimal](18, 2) NULL,
	[val_fim_verde] [decimal](18, 2) NULL,
	[val_ini_verme] [decimal](18, 2) NULL,
	[val_fim_verme] [decimal](18, 2) NULL,
	[val_pvsto] [decimal](18, 2) NULL,
	[id_emp_item_sitem] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_planejamento_anual]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_planejamento_anual](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_empre_item_subitem] [int] NOT NULL,
	[num_ano] [int] NOT NULL,
	[val_reali] [decimal](18, 2) NOT NULL,
	[val_previ] [decimal](18, 2) NULL,
	[val_verde_ini] [decimal](18, 2) NULL,
	[val_verde_fim] [decimal](18, 2) NULL,
	[val_verme_ini] [decimal](18, 2) NULL,
	[val_verme_fim] [decimal](18, 2) NULL,
	[val_orcad] [decimal](18, 2) NOT NULL,
	[dat_criac] [datetime] NOT NULL,
	[cod_usu_adm] [int] NOT NULL,
	[cod_usu_clien] [int] NULL,
	[des_cor_status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_planejamento_mensal]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_planejamento_mensal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_empre_item_subitem] [int] NOT NULL,
	[cod_mes] [int] NOT NULL,
	[num_ano] [int] NOT NULL,
	[val_reali] [decimal](18, 2) NOT NULL,
	[val_previ] [decimal](18, 2) NULL,
	[val_verde_ini] [decimal](18, 2) NULL,
	[val_verde_fim] [decimal](18, 2) NULL,
	[val_verme_ini] [decimal](18, 2) NULL,
	[val_verme_fim] [decimal](18, 2) NULL,
	[val_orcad] [decimal](18, 2) NOT NULL,
	[dat_criac] [datetime] NOT NULL,
	[cod_usu_adm] [int] NOT NULL,
	[cod_usu_clien] [int] NULL,
	[des_cor_status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subitem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom_subitem] [varchar](50) NOT NULL,
	[des_descr] [varchar](200) NULL,
	[dat_criac] [datetime] NOT NULL,
	[dat_atual] [datetime] NOT NULL,
	[ind_ativa] [bit] NOT NULL,
	[cod_usu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[des_nome] [varchar](50) NOT NULL,
	[des_sobrenome] [varchar](100) NOT NULL,
	[des_email] [varchar](50) NULL,
	[des_cpf] [varchar](20) NOT NULL,
	[des_username] [varchar](50) NOT NULL,
	[des_psw] [varchar](50) NOT NULL,
	[dat_criac] [nchar](10) NULL,
	[des_phone1] [varchar](15) NULL,
	[des_phone2] [varchar](15) NULL,
	[ind_ativo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario_perfil]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario_perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_perfil] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_empresa_endereco]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_tbl_endereco] FOREIGN KEY([id_empre])
REFERENCES [dbo].[tbl_empresa] ([id])
GO
ALTER TABLE [dbo].[tbl_empresa_endereco] CHECK CONSTRAINT [fk_tbl_empresa_tbl_endereco]
GO
ALTER TABLE [dbo].[tbl_empresa_endereco]  WITH CHECK ADD  CONSTRAINT [fk_tbl_endereco_tbl_empresa] FOREIGN KEY([id_ender])
REFERENCES [dbo].[tbl_endereco] ([Id])
GO
ALTER TABLE [dbo].[tbl_empresa_endereco] CHECK CONSTRAINT [fk_tbl_endereco_tbl_empresa]
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_empresa] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[tbl_empresa] ([id])
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem] CHECK CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_empresa]
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_item] FOREIGN KEY([id_item])
REFERENCES [dbo].[tbl_item] ([id])
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem] CHECK CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_item]
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_subitem] FOREIGN KEY([id_subitem])
REFERENCES [dbo].[tbl_subitem] ([id])
GO
ALTER TABLE [dbo].[tbl_empresa_item_subitem] CHECK CONSTRAINT [fk_tbl_empresa_item_subitem_tbl_subitem]
GO
ALTER TABLE [dbo].[tbl_empresa_usuario]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_usuario_tbl_empresa] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[tbl_empresa] ([id])
GO
ALTER TABLE [dbo].[tbl_empresa_usuario] CHECK CONSTRAINT [fk_tbl_empresa_usuario_tbl_empresa]
GO
ALTER TABLE [dbo].[tbl_empresa_usuario]  WITH CHECK ADD  CONSTRAINT [fk_tbl_empresa_usuario_tbl_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([Id])
GO
ALTER TABLE [dbo].[tbl_empresa_usuario] CHECK CONSTRAINT [fk_tbl_empresa_usuario_tbl_usuario]
GO
ALTER TABLE [dbo].[tbl_item_subitem]  WITH CHECK ADD  CONSTRAINT [fk_tbl_item_subitem_item] FOREIGN KEY([id_item])
REFERENCES [dbo].[tbl_item] ([id])
GO
ALTER TABLE [dbo].[tbl_item_subitem] CHECK CONSTRAINT [fk_tbl_item_subitem_item]
GO
ALTER TABLE [dbo].[tbl_item_subitem]  WITH CHECK ADD  CONSTRAINT [fk_tbl_item_subitem_subitem] FOREIGN KEY([id_subitem])
REFERENCES [dbo].[tbl_subitem] ([id])
GO
ALTER TABLE [dbo].[tbl_item_subitem] CHECK CONSTRAINT [fk_tbl_item_subitem_subitem]
GO
ALTER TABLE [dbo].[tbl_perfil_funcionalidade]  WITH CHECK ADD  CONSTRAINT [fk_tbl_perfil_funcionalidade_funcioalidade] FOREIGN KEY([id_funcionalidade])
REFERENCES [dbo].[tbl_funcionalidade] ([Id])
GO
ALTER TABLE [dbo].[tbl_perfil_funcionalidade] CHECK CONSTRAINT [fk_tbl_perfil_funcionalidade_funcioalidade]
GO
ALTER TABLE [dbo].[tbl_perfil_funcionalidade]  WITH CHECK ADD  CONSTRAINT [fk_tbl_perfil_funcionalidade_perfil] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[tbl_perfil] ([Id])
GO
ALTER TABLE [dbo].[tbl_perfil_funcionalidade] CHECK CONSTRAINT [fk_tbl_perfil_funcionalidade_perfil]
GO
ALTER TABLE [dbo].[tbl_planejamento]  WITH CHECK ADD  CONSTRAINT [fk_planejamento_tbl_empresa_item_subitem] FOREIGN KEY([id_emp_item_sitem])
REFERENCES [dbo].[tbl_empresa_item_subitem] ([Id])
GO
ALTER TABLE [dbo].[tbl_planejamento] CHECK CONSTRAINT [fk_planejamento_tbl_empresa_item_subitem]
GO
ALTER TABLE [dbo].[tbl_planejamento_anual]  WITH CHECK ADD  CONSTRAINT [fk_tbl_planejamento_anual_tbl_empresa_item_subitem] FOREIGN KEY([id_empre_item_subitem])
REFERENCES [dbo].[tbl_empresa_item_subitem] ([Id])
GO
ALTER TABLE [dbo].[tbl_planejamento_anual] CHECK CONSTRAINT [fk_tbl_planejamento_anual_tbl_empresa_item_subitem]
GO
ALTER TABLE [dbo].[tbl_planejamento_mensal]  WITH CHECK ADD  CONSTRAINT [fk_tbl_planejamento_tbl_empresa_item_subitem] FOREIGN KEY([id_empre_item_subitem])
REFERENCES [dbo].[tbl_empresa_item_subitem] ([Id])
GO
ALTER TABLE [dbo].[tbl_planejamento_mensal] CHECK CONSTRAINT [fk_tbl_planejamento_tbl_empresa_item_subitem]
GO
ALTER TABLE [dbo].[tbl_usuario_perfil]  WITH CHECK ADD  CONSTRAINT [fk_tbl_usuario_perfil_tbl_perfil] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[tbl_perfil] ([Id])
GO
ALTER TABLE [dbo].[tbl_usuario_perfil] CHECK CONSTRAINT [fk_tbl_usuario_perfil_tbl_perfil]
GO
ALTER TABLE [dbo].[tbl_usuario_perfil]  WITH CHECK ADD  CONSTRAINT [fk_tbl_usuario_perfil_tbl_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tbl_usuario] ([Id])
GO
ALTER TABLE [dbo].[tbl_usuario_perfil] CHECK CONSTRAINT [fk_tbl_usuario_perfil_tbl_usuario]
GO
/****** Object:  StoredProcedure [dbo].[spr_del_empre]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_del_empre]
	@id int
AS
BEGIN	
	UPDATE 
		dbo.tbl_empresa 
	SET
		ind_ativa = 0
		, dat_atual = GETDATE()
	WHERE 
		id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spr_del_empre_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_del_empre_item]
	@id_empresa INT
	,@id_item INT
	,@id_subitem INT = null
	,@cod_usu INT
AS
BEGIN
	
	UPDATE 
		dbo.tbl_empresa_item_subitem
	SET
		ind_ativ = 0,
		dat_inat = GETDATE()
		,cod_usu_inat = @cod_usu
	WHERE			
		id_empresa = @id_empresa
		and id_item = @id_item
		and (@id_subitem is null or id_subitem = @id_subitem)	
END
GO
/****** Object:  StoredProcedure [dbo].[spr_del_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_del_item]
	@id_item INT
AS
BEGIN
	
	UPDATE 
		dbo.tbl_item
	SET
		ind_ativa = 0,
		dat_atual = GETDATE()
	WHERE			
		id = @id_item
END
GO
/****** Object:  StoredProcedure [dbo].[spr_del_limpa_db]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_del_limpa_db]
	
AS
BEGIN

delete tbl_empresa_item_subitem;
delete tbl_planejamento_mensal
delete tbl_planejamento_anual
delete tbl_empresa_endereco;
delete tbl_item_subitem;

delete tbl_endereco
delete tbl_empresa
delete tbl_item;
delete tbl_subitem;

END
GO
/****** Object:  StoredProcedure [dbo].[spr_del_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_del_subitem]
	@id_subitem INT
AS
BEGIN
	
	UPDATE 
		dbo.tbl_subitem
	SET
		ind_ativa = 0,
		dat_atual = GETDATE()
	WHERE			
		id = @id_subitem
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_empre]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ins_empre]
(
	@nom_empre	VARCHAR(50)
	,@des_cnpj	VARCHAR (14)
	,@val_logo	VARBINARY (MAX) = NULL
    ,@des_site	VARCHAR (50) 
    ,@des_email	VARCHAR (50)
	,@dat_criac datetime
	,@dat_atual datetime
	,@ind_ativa bit
)
AS
BEGIN

	INSERT INTO dbo.tbl_empresa(
		nom_empre,
		des_cnpj,
		val_logo,	
		des_site,	
		des_email,
		dat_criac,
		dat_atual,
		ind_ativa
	) VALUES (
		@nom_empre,
		@des_cnpj,
		@val_logo,	
		@des_site,	
		@des_email,
		@dat_criac,
		@dat_atual,
		@ind_ativa
	)

	SELECT CONVERT(int, SCOPE_IDENTITY())
	
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_empre_ender]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spr_ins_empre_ender]
	@id_empre	INT
	,@des_logra	VARCHAR (100)
    ,@num_logra INT           
    ,@num_cep	INT           
    ,@val_compl VARCHAR (10)  
    ,@nom_cidad VARCHAR (50)  
    ,@nom_estad VARCHAR (50)  
    ,@nom_bairr VARCHAR (50)      
AS
BEGIN
	INSERT INTO dbo.tbl_endereco(
		des_logra	
		,num_logra 
		,num_cep	
		,val_compl 
		,nom_cidad 
		,nom_estad 
		,nom_bairr  			
	) VALUES (
		@des_logra	
		,@num_logra 
		,@num_cep	
		,@val_compl 
		,@nom_cidad 
		,@nom_estad 
		,@nom_bairr				
	)
	
	DECLARE @id_ender INT;
	SET @id_ender = (SELECT max(id) FROM dbo.tbl_endereco WITH(NOLOCK))	
		

	INSERT INTO dbo.[tbl_empresa_endereco] (id_empre, id_ender) VALUES (@id_empre, @id_ender)
	

	SELECT CONVERT(int, SCOPE_IDENTITY())

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_empre_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_empre_item]
	@id_empresa INT
	,@id_item INT
	,@id_subitem INT = null
	,@cod_usu INT
AS
BEGIN
	
	INSERT INTO dbo.tbl_empresa_item_subitem
		(id_empresa, id_item, id_subitem, dat_criac, cod_usu, ind_ativ)
	VALUES
		(@id_empresa, @id_item, @id_subitem, GETDATE(), @cod_usu, 1)
	
	SELECT CONVERT(int, SCOPE_IDENTITY())

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_empre_usuar]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_empre_usuar]
	@id_usuario int
	,@id_empresa int 
	
AS
BEGIN
	insert into tbl_empresa_usuario (id_usuario, id_empresa) VALUES (@id_usuario, @id_empresa)
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ins_item]
	@nom_item VARCHAR(25)
	,@ind_desdo bit
	,@des_descr VARCHAR(200) = NULL
	,@ind_ativa bit
	,@cod_usu INT
AS
BEGIN

--BEGIN TRANSACTION [Tran1]

--BEGIN TRY

	INSERT INTO dbo.tbl_item
		(nom_item, ind_desdo, des_descr, dat_criac, dat_atual, ind_ativa, cod_usu)
	VALUES
		(@nom_item, @ind_desdo, @des_descr, GETDATE(), GETDATE(), @ind_ativa, @cod_usu)
								
	--DECLARE @id_item_criado INTEGER			
	--SELECT  @id_item_criado = max(id)+1 FROM dbo.tbl_item WITH(NOLOCK)

	--BEGIN
	--	EXEC spr_ins_item_subitem
	--		@id_item	=	@id_item_criado
	--END

			
	--COMMIT TRANSACTION [Tran1]

	SELECT CONVERT(int, SCOPE_IDENTITY()) 	

--END TRY
--BEGIN CATCH
  --ROLLBACK TRANSACTION [Tran1]
--END CATCH 

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_item_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_item_subitem]
	@id_item INT
	,@id_subitem INT = NULL
AS
BEGIN
	
	IF @id_subitem is null
		BEGIN
			INSERT INTO dbo.tbl_item_subitem
				(id_item)
			VALUES
				(@id_item)
		END
	ELSE
	BEGIN
		INSERT INTO dbo.tbl_item_subitem
			(id_item, id_subitem)
		VALUES
			(@id_item, @id_subitem)
	END

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_planejamento_anual]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_planejamento_anual]
	@id_empre_item_subitem INT
	,@num_ano			int        
	,@val_reali			decimal(18,2) = NULL
	,@val_previ			decimal(18,2)           
	,@val_verde_ini		decimal(18,2)
	,@val_verde_fim		decimal(18,2)        
	,@val_verme_ini		decimal(18,2)         
	,@val_verme_fim		decimal(18,2)         
	,@val_orcad			decimal(18,2)        
	,@dat_criac			datetime        
	,@cod_usu_adm			int        
	,@cod_usu_clien			int  = null      
	,@des_cor_status	varchar(20)
AS
BEGIN	

	insert into tbl_planejamento_anual (
		id_empre_item_subitem
		,num_ano
		,val_reali  
		,val_previ             
		,val_verde_ini
		,val_verde_fim         
		,val_verme_ini
		,val_verme_fim         
		,val_orcad             
		,dat_criac             
		,cod_usu_adm               
		,cod_usu_clien
		,des_cor_status)
	values (
		@id_empre_item_subitem
		,@num_ano
		,@val_reali  
		,@val_previ             
		,@val_verde_ini
		,@val_verde_fim
		,@val_verme_ini
		,@val_verme_fim         
		,@val_orcad             
		,@dat_criac             
		,@cod_usu_adm               
		,@cod_usu_clien
		,@des_cor_status
	)

	SELECT CONVERT(int, SCOPE_IDENTITY()) 	

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_planejamento_mensal]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_planejamento_mensal]
	 @id_empre_item_subitem	INT
	,@cod_mes				INT
	,@num_ano				INT        
	,@val_reali				decimal(18,2) = NULL
	,@val_previ				decimal(18,2)           
	,@val_verde_ini			decimal(18,2)
	,@val_verde_fim			decimal(18,2)        
	,@val_verme_ini			decimal(18,2)        
	,@val_verme_fim			decimal(18,2)         
	,@val_orcad				decimal(18,2)        
	,@dat_criac				datetime        
	,@cod_usu_adm			int        
	,@cod_usu_clien			int = NULL        
	,@des_cor_status		varchar(20)
AS
BEGIN	

	insert into tbl_planejamento_mensal (
		id_empre_item_subitem
		,cod_mes
		,num_ano
		,val_reali  
		,val_previ             
		,val_verde_ini
		,val_verde_fim    
		,val_verme_ini
		,val_verme_fim         
		,val_orcad             
		,dat_criac             
		,cod_usu_adm               
		,cod_usu_clien
		,des_cor_status)
	values (
		@id_empre_item_subitem
		,@cod_mes
		,@num_ano
		,@val_reali  
		,@val_previ             
		,@val_verde_ini
		,@val_verde_fim         
		,@val_verme_ini         
		,@val_verme_fim         
		,@val_orcad             
		,@dat_criac             
		,@cod_usu_adm               
		,@cod_usu_clien
		,@des_cor_status
	)

	SELECT CONVERT(int, SCOPE_IDENTITY()) 	

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_subitem]
	@id_item		INT	 	
	,@nom_subitem	VARCHAR(50)
	,@des_descr		VARCHAR(200)	 	
	,@dat_criac		DATETIME
	,@dat_atual		DATETIME
	,@ind_ativa		BIT
	,@cod_usu		INT
AS
BEGIN

--BEGIN TRANSACTION [Tran1]
--BEGIN TRY

	INSERT INTO	dbo.tbl_subitem
		(nom_subitem 
		,des_descr		 
		,dat_criac 
		,dat_atual 
		,ind_ativa
		,cod_usu)
	VALUES (
		@nom_subitem 
		,@des_descr		 
		,@dat_criac
		,@dat_atual
		,@ind_ativa
		,@cod_usu)

	
	SELECT CONVERT(int, SCOPE_IDENTITY()) 

--	DECLARE @id_subitem_criado INTEGER		
--	SELECT @id_subitem_criado = max(id)+1 FROM dbo.tbl_subitem WITH(NOLOCK)

--	EXEC spr_ins_item_subitem
--		@id_item		=	@id_item
--		,@id_subitem	=	@id_subitem_criado

--COMMIT TRANSACTION [Tran1]

--END TRY
--BEGIN CATCH
  --ROLLBACK TRANSACTION [Tran1]
--END CATCH 

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_usuar]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_usuar]
@des_nome			VARCHAR(50)
,@des_sobrenome		VARCHAR(100)
,@des_email			VARCHAR(50)
,@des_cpf			VARCHAR(20)
,@des_username		VARCHAR(50)
,@des_psw			VARCHAR(50)
,@dat_criac			datetime
,@des_phone1		VARCHAR(50)
,@des_phone2		VARCHAR(50)
,@ind_ativo			BIT


AS
BEGIN
	INSERT INTO tbl_usuario (
		des_nome 
		,des_sobrenome		
		,des_email			
		,des_cpf			
		,des_username		
		,des_psw			
		,dat_criac			
		,des_phone1		
		,des_phone2		
		,ind_ativo)
		VALUES (@des_nome 
		,@des_sobrenome		
		,@des_email			
		,@des_cpf			
		,@des_username		
		,@des_psw			
		,@dat_criac			
		,@des_phone1		
		,@des_phone2		
		,@ind_ativo)

		SELECT CONVERT(int, SCOPE_IDENTITY())

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ins_usuario_perfil]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ins_usuario_perfil]
	@id_usuario int 
	,@id_perfil int
AS
	insert into tbl_usuario_perfil (id_usuario, id_perfil) VALUES (@id_usuario, @id_perfil)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empre]
	@id int = null
AS
BEGIN
	SELECT 
		id
		,nom_empre
		,des_cnpj
		,val_logo	
		,des_site	
		,des_email
		,dat_criac
		,dat_atual
		,ind_ativa
	FROM 
		dbo.tbl_empresa	
	WHERE 
		(@id is null or id = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre_ender]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empre_ender]
	@id_empre int	
AS
BEGIN
	SELECT		
		endereco.Id
		,endereco.des_logra
		,endereco.num_logra
		,endereco.num_cep
		,endereco.val_compl
		,endereco.nom_cidad
		,endereco.nom_estad
		,endereco.nom_bairr    
	FROM
		dbo.tbl_endereco endereco
			INNER JOIN dbo.tbl_empresa_endereco rel
				on rel.id_ender = endereco.Id
	WHERE 
		rel.id_empre = @id_empre
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spr_ler_empre_item]
	@id_empresa INT
AS
BEGIN

		--select 
		--	item.id
		--	,item.nom_item
		--	,item.ind_desdo
		--	,item.des_descr
		--	,rel.dat_criac		
		--	,item.dat_atual 
		--	,item.ind_ativa
		--from 
		--	tbl_item item 
		--		inner join tbl_empresa_item_subitem rel 
		--			on rel.id_item = item.id
		--where
		--	rel.id_empresa = @id_empresa
		--	AND rel.ind_ativ = 1
		
		SELECT	
	item.id
	,item.nom_item
	,item.ind_desdo
	,item.des_descr	
	, REL.dat_criac
	,item.dat_atual 
	,item.ind_ativa 
FROM
	(select 
		distinct 
		relac.id_item
		,relac.dat_criac 
	from 
		tbl_empresa_item_subitem relac
	where 
		relac.id_empresa = @id_empresa 
		and relac.id_subitem is null 
		and relac.ind_ativ = 1
	) REL
		INNER JOIN tbl_item item 
			on item.id = REL.id_item
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre_item_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empre_item_subitem]
	@id_empre INT,
	@id_item INT
AS
BEGIN

	SELECT 	
		subitem.id
		,subitem.nom_subitem
		,subitem.des_descr 		
	FROM
		dbo.tbl_subitem subitem
			INNER JOIN tbl_empresa_item_subitem rel 
				on rel.id_subitem = subitem.id
	WHERE 
		rel.id_empresa = @id_empre
		AND rel.id_item =  @id_item
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre_item_subitem_id]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empre_item_subitem_id]
	@id_empresa int
	,@id_item int
	,@id_subitem int = null
AS
BEGIN
	if @id_subitem is not null
		begin
			SELECT 
				rel.id 
			FROM 
				tbl_empresa_item_subitem rel
			WHERE 
				rel.id_empresa = @id_empresa
				and rel.id_item = @id_item
				and rel.id_subitem = @id_subitem
		end
	else
		begin
			SELECT 
				rel.id 
			FROM 
				tbl_empresa_item_subitem rel
			WHERE 
				rel.id_empresa = @id_empresa
				and rel.id_item = @id_item
		end
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empre_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empre_subitem]
	@id_item int 
	,@id_empresa int
AS
BEGIN
	SELECT 		
		distinct
		subitem.id 
		,subitem.nom_subitem
		,subitem.des_descr   
		,subitem.dat_criac   
		,subitem.dat_atual   
		,relmaster.ind_ativ as ind_ativa
	FROM
		dbo.tbl_subitem subitem
			inner join dbo.tbl_item_subitem rel 
				on rel.id_subitem = subitem.id
			inner join tbl_empresa_item_subitem relmaster
				on relmaster.id_subitem = subitem.id
	WHERE 
		relmaster.id_empresa = @id_empresa
		and relmaster.id_item = @id_item

END

	--SELECT 		
	--	distinct
	--	subitem.id 
	--	,subitem.nom_subitem
	--	,subitem.des_descr   
	--	,subitem.dat_criac   
	--	,subitem.dat_atual   
	--	,relmaster.ind_ativ as ind_ativsa
	--FROM
	--	dbo.tbl_subitem subitem
	--		inner join dbo.tbl_item_subitem rel 
	--			on rel.id_subitem = subitem.id
	--		inner join tbl_empresa_item_subitem relmaster
	--			on relmaster.id_subitem = subitem.id
	--WHERE 
	--	relmaster.id_empresa = 1019
	--	and relmaster.id_item = 3058
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_empresa_por_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_empresa_por_item]
	@id_item int	
AS
BEGIN
	
	SELECT 
		empre.id
		,empre.nom_empre
		,empre.des_cnpj
		,empre.val_logo	
		,empre.des_site	
		,empre.des_email
		,empre.dat_criac
		,empre.dat_atual
		,empre.ind_ativa
	FROM
		tbl_empresa empre
			inner join tbl_empresa_item_subitem rel on rel.id_empresa = empre.id
	WHERE 
		rel.id_item = @id_item
	
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_endereco]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_endereco]
	@id INT	
AS
BEGIN
	SELECT 
		endereco.Id
		,endereco.des_logra
		,endereco.num_logra
		,endereco.num_cep
		,endereco.val_compl
		,endereco.nom_cidad
		,endereco.nom_estad
		,endereco.nom_bairr
	FROM
		tbl_endereco endereco
	WHERE 
		endereco.Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ler_item]
	--@id_item int = null
AS
BEGIN
	SELECT 
		distinct
		item.id
		,item.nom_item
		,item.ind_desdo
		,item.des_descr
		,item.dat_criac
		,item.dat_atual
		,item.ind_ativa
	FROM
		dbo.tbl_item item
			inner join tbl_item_subitem rel on rel.id_item = item.id
	--WHERE 
	--	(@id_item is null or item.id = @id_item)		
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_item_por_id]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_item_por_id]
	@id_item int 
AS
BEGIN
	SELECT 
		distinct
		item.id
		,item.nom_item
		,item.ind_desdo
		,item.des_descr
		,item.dat_criac
		,item.dat_atual
		,item.ind_ativa
	FROM
		dbo.tbl_item item
			inner join tbl_item_subitem rel on rel.id_item = item.id
	WHERE 
		item.id = @id_item
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_item_relac_empre_subitem_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ler_item_relac_empre_subitem_item]
	@id_empresa	INT
	,@id_item INT
	,@id_subitem INT
AS
BEGIN
	SELECT 		
		subitem.id 
		,subitem.nom_subitem
		,subitem.des_descr   
		,subitem.dat_criac   
		,subitem.dat_atual   
		,rel.ind_ativ as ind_ativa
	FROM
		tbl_subitem subitem
		inner join tbl_empresa_item_subitem rel on subitem.id = rel.id_subitem
	WHERE
		rel.id_empresa = @id_empresa
		and rel.id_item = @id_item
		and subitem.id = @id_subitem 
		and subitem.ind_ativa = 1 
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_item_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_item_subitem]
	@id_item int 
AS
BEGIN
	SELECT 		
		distinct
		subitem.id 
		,subitem.nom_subitem
		,subitem.des_descr   
		,subitem.dat_criac   
		,subitem.dat_atual   
		,subitem.ind_ativa   		
	FROM
		dbo.tbl_subitem subitem
			inner join dbo.tbl_item_subitem rel 
				on rel.id_subitem = subitem.id
	WHERE 
		rel.id_item = @id_item	

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_perfil]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_perfil]
AS
BEGIN
	select Id, des_perfil from tbl_perfil
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_perfil_usuario]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_perfil_usuario]
	@id_usuario int 	
AS
BEGIN
	SELECT 
		perfil.Id
		,perfil.des_perfil
	FROM
		tbl_perfil perfil
			inner join tbl_usuario_perfil rel 
				on rel.id_perfil = perfil.Id
	WHERE 
		rel.id_usuario = @id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_plan_agrup_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ler_plan_agrup_item]
	@id_item int,
	@id_empresa int
AS
BEGIN
	select	
		cod_mes
		,num_ano
		,SUM(val_reali) as val_reali
		,SUM(VAL_PREVI) as val_previ
		,SUM(val_verde_ini) as val_verde_ini
		,SUM(val_verde_fim) as val_verde_fim
		,SUM(val_verme_ini) as val_verme_ini
		,SUM(val_verme_fim) as val_verme_fim
		,SUM(val_orcad) as val_orcad
	from 
		tbl_planejamento_mensal mensal
			inner join tbl_empresa_item_subitem rel 
				on mensal.id_empre_item_subitem = rel.Id 

	where 
		 rel.id_item = @id_item --3058
		 and rel.id_empresa = @id_empresa --1019
	group by 	
		cod_mes
		,num_ano	

	order by 
		num_ano,
		cod_mes
END

GO
/****** Object:  StoredProcedure [dbo].[spr_ler_plan_anual]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spr_ler_plan_anual]
	@id_item int 	
	,@id_empresa int
	,@id_subitem int = null
AS
BEGIN
	SELECT 	
		anual.id
		,anual.num_ano		
		,anual.val_reali  
		,anual.val_previ             
		,anual.val_verde_ini		
		,anual.val_verde_fim         
		,anual.val_verme_ini
		,anual.val_verme_fim         
		,anual.val_orcad             
		,anual.dat_criac             
		,anual.cod_usu_adm               
		,anual.cod_usu_clien
		,anual.des_cor_status		
	FROM 
		tbl_planejamento_anual anual
		inner join tbl_empresa_item_subitem rel
			on anual.id_empre_item_subitem = rel.Id
	WHERE 
		rel.id_item = @id_item
		and rel.id_empresa = @id_empresa
		and (rel.id_subitem = @id_subitem OR @id_subitem is null)
		
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_plan_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_plan_item]
	@id_item int 	
	,@id_empresa int
AS
BEGIN
	SELECT 	
		mensal.id
		,mensal.num_ano
		,mensal.cod_mes
		,mensal.val_reali  
		,mensal.val_previ             
		,mensal.val_verde_ini		
		,mensal.val_verde_fim         
		,mensal.val_verme_ini
		,mensal.val_verme_fim         
		,mensal.val_orcad             
		,mensal.dat_criac             
		,mensal.cod_usu_adm               
		,mensal.cod_usu_clien
		,mensal.des_cor_status
		,mensal.id_empre_item_subitem
	FROM 
		tbl_planejamento_mensal mensal
		inner join tbl_empresa_item_subitem rel
			on mensal.id_empre_item_subitem = rel.Id
	WHERE 
		rel.id_item = @id_item
		and rel.id_empresa = @id_empresa
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_plan_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_plan_subitem]
	@id_empresa int
	,@id_item int
	,@id_subitem int 	
AS
BEGIN
	SELECT 	
		mensal.id
		,mensal.num_ano
		,mensal.cod_mes
		,mensal.val_reali  
		,mensal.val_previ             
		,mensal.val_verde_ini
		,mensal.val_verde_fim         
		,mensal.val_verme_ini
		,mensal.val_verme_fim         
		,mensal.val_orcad             
		,mensal.dat_criac             		
		,mensal.des_cor_status
	FROM 
		tbl_planejamento_mensal mensal
		inner join tbl_empresa_item_subitem rel
			on rel.Id = mensal.id_empre_item_subitem
	WHERE
		rel.id_empresa = @id_empresa
		and rel.id_item = @id_item
		and rel.id_subitem = @id_subitem
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_subitem]
	@id_subitem int = null
AS
BEGIN
	SELECT 		
		distinct
		subitem.id 
		,subitem.nom_subitem
		,subitem.des_descr   
		,subitem.dat_criac   
		,subitem.dat_atual   
		,subitem.ind_ativa   		
	FROM
		dbo.tbl_subitem subitem
			inner join dbo.tbl_item_subitem rel 
				on rel.id_subitem = subitem.id
	WHERE 
		(@id_subitem is null or rel.id_subitem = @id_subitem)	

END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_usuario_empresa]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_usuario_empresa]
	@id_empresa INT
AS
BEGIN
	select 
		usuario.Id
		,usuario.des_nome 
		,usuario.des_sobrenome		
		,usuario.des_email			
		,usuario.des_cpf			
		,usuario.des_username		
		,usuario.des_psw			
		,usuario.dat_criac			
		,usuario.des_phone1		
		,usuario.des_phone2		
		,usuario.ind_ativo
	from 
		tbl_usuario usuario
		inner join tbl_empresa_usuario empresa_usuario
			on usuario.id = empresa_usuario.id_usuario
	where 
		empresa_usuario.id_empresa = @id_empresa
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_usuario_por_email]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_usuario_por_email]
	@des_email VARCHAR(20)
AS
BEGIN
	select 
		usuario.Id
		,usuario.des_nome 
		,usuario.des_sobrenome		
		,usuario.des_email			
		,usuario.des_cpf			
		,usuario.des_username		
		,usuario.des_psw			
		,usuario.dat_criac			
		,usuario.des_phone1		
		,usuario.des_phone2		
		,usuario.ind_ativo
		,rel.id_empresa
	from 
		tbl_usuario usuario		
			inner join tbl_empresa_usuario rel on usuario.Id = rel.id_usuario
	where 
		usuario.des_username = @des_email
END
GO
/****** Object:  StoredProcedure [dbo].[spr_ler_usuario_por_username]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_ler_usuario_por_username]
	@des_username VARCHAR(20)
AS
BEGIN
	select 
		usuario.Id
		,usuario.des_nome 
		,usuario.des_sobrenome		
		,usuario.des_email			
		,usuario.des_cpf			
		,usuario.des_username		
		,usuario.des_psw			
		,usuario.dat_criac			
		,usuario.des_phone1		
		,usuario.des_phone2		
		,usuario.ind_ativo
		,rel.id_empresa
	from 
		tbl_usuario usuario		
			inner join tbl_empresa_usuario rel on usuario.Id = rel.id_usuario
	where 
		usuario.des_username = @des_username
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_empre]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_empre]
(
	@id INT
	,@nom_empre	VARCHAR(50)
	,@des_cnpj	VARCHAR (14)
	,@val_logo	VARBINARY (MAX) = NULL
    ,@des_site	VARCHAR (50) 
    ,@des_email	VARCHAR (50)
)
AS
BEGIN

	UPDATE 
		dbo.tbl_empresa
	SET
		nom_empre = @nom_empre
		, des_cnpj = @des_cnpj
		, val_logo = @val_logo
		, des_site = @des_site
		, des_email	= @des_email	
		, dat_atual = GETDATE()
	WHERE 
		id = @id
			
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_empre_ender]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_empre_ender]
	@id INT
	,@des_logra VARCHAR(100)
	,@num_logra INT
	,@num_cep	INT
	,@val_compl VARCHAR(10)
	,@nom_cidad VARCHAR(50)
	,@nom_estad	VARCHAR(50)
	,@nom_bairr	VARCHAR(50)
AS
BEGIN
	UPDATE 
		dbo.tbl_endereco
	SET		
		des_logra = @des_logra
		,num_logra = @num_logra
		,num_cep = @num_cep
		,val_compl = @val_compl
		,nom_cidad = @nom_cidad
		,nom_estad = @nom_estad
		,nom_bairr = @nom_bairr
	WHERE
		Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_item]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_item]
	@id INT
	,@nom_item VARCHAR(25)
	,@ind_desdo bit
	,@des_descr VARCHAR(200)
	,@cod_usu INT
AS
BEGIN
	
	UPDATE 
		dbo.tbl_item
	SET
		nom_item  = @nom_item 
		,ind_desdo  = @ind_desdo 
		,des_descr = @des_descr 
		,dat_atual = GETDATE()
		,cod_usu = @cod_usu
	WHERE			
		id = @id		
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_planejamento_mensal]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_planejamento_mensal]
	@id						INT
	,@cod_mes				INT 
	,@num_ano				INT 
	,@val_reali				decimal(18,2) 
	,@val_previ				decimal(18,2) 
	,@val_verde_ini			decimal(18,2) 
	,@val_verde_fim			decimal(18,2)        
	,@val_verme_ini			decimal(18,2)        
	,@val_verme_fim			decimal(18,2)         
	,@val_orcad				decimal(18,2)        
	,@dat_criac				datetime        
	,@cod_usu_adm			int        	
	,@des_cor_status		varchar(20)
AS
BEGIN
	UPDATE 
		tbl_planejamento_mensal
	SET		
		cod_mes				=	@cod_mes		
		,num_ano			=	@num_ano		
		,val_reali			=	@val_reali		
		,val_previ			=	@val_previ		
		,val_verde_ini		=	@val_verde_ini
		,val_verde_fim		=	@val_verde_fim
		,val_verme_ini		=	@val_verme_ini
		,val_verme_fim		=	@val_verme_fim
		,val_orcad			=	@val_orcad		
		,dat_criac			=	@dat_criac		
		,cod_usu_adm		=	@cod_usu_adm			
		,des_cor_status		=	@des_cor_status
	where 
		id = @id
		
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_preenchimento_clien_planejamento_mensal]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_preenchimento_clien_planejamento_mensal]
	@id						INT	
	,@val_reali				decimal(18,2) 	
	,@cod_usu_clien			int = NULL        	
	,@des_cor_status		varchar(20)
AS
BEGIN
	UPDATE 
		tbl_planejamento_mensal
	SET				
		val_reali			=	@val_reali				
		,cod_usu_clien		=	@cod_usu_clien
		,des_cor_status		=	@des_cor_status
	where 
		id = @id
		
END
GO
/****** Object:  StoredProcedure [dbo].[spr_upd_subitem]    Script Date: 04/09/2017 23:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spr_upd_subitem]
	@id_subitem		INT	 	
	,@nom_subitem	VARCHAR(50)
	,@des_descr		VARCHAR(200)	 		
	,@dat_atual		DATETIME	
	,@cod_usu		INT
AS
BEGIN
	UPDATE 
		tbl_subitem
	SET	
		nom_subitem	= @nom_subitem	
		,des_descr		= @des_descr			 		
		,dat_atual		= @dat_atual		
		,cod_usu		= @cod_usu	
	WHERE 
		id =  @id_subitem
		
END
GO
USE [master]
GO
ALTER DATABASE [DigitalDataDB] SET  READ_WRITE 
GO
