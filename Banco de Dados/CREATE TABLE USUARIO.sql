USE [PreventCataclysmSystems];
GO

CREATE TABLE [dbo].[USUARIO]
    (
      [IDUSUARIO] [INT] IDENTITY(1, 1)
                        NOT NULL ,
      [NOME] [NVARCHAR](255) NOT NULL ,
      [CPF] [NVARCHAR](11) NOT NULL ,
      [EMAIL] [NVARCHAR](255) NOT NULL ,
      [TELEFONE] [NVARCHAR](255) NOT NULL ,
      [DESCONTO] [FLOAT] NULL ,
      [JUROS] [FLOAT] NULL ,
      [SITUACAO] [BIT] NOT NULL ,
      [ULTIMO_ALUGUEL] [FLOAT] NULL ,
      [IDPERFIL] [INT] NULL
    )
	GO


