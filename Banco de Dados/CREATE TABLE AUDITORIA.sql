USE [PreventCataclysmSystems]
GO

CREATE TABLE [dbo].[AUDITORIA](
	[IDAUDITORIA] [INT] IDENTITY(1,1) NOT NULL,
	[DATAALTERACAO] [DATETIME] NULL,
	[IDLIVRO] [INT] NOT NULL,
	[NOME] [NVARCHAR](255) NOT NULL,
	[AUTOR] [NVARCHAR](255) NOT NULL,
	[SITUACAO] [BIT] NULL,
	[ESTADO] [NVARCHAR](50) NOT NULL,
	[ISBN] [VARCHAR](20) NOT NULL,
	[IDGENERO] [INT] NOT NULL,
	[INSTRUCAO] [VARCHAR](50) NULL)
GO

//Commit teste
