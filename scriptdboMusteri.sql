USE [dboMusteri]
GO
/****** Object:  Table [dbo].[tblMusteriler]    Script Date: 2.04.2020 15:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMusteriler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblMusteriler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblMusteriler] ON 

INSERT [dbo].[tblMusteriler] ([ID], [Adi], [Soyadi], [Sifre], [Email]) VALUES (1, N'x', N'x', N'1', N'1')
SET IDENTITY_INSERT [dbo].[tblMusteriler] OFF
/****** Object:  StoredProcedure [dbo].[sp_MusteriGetir]    Script Date: 2.04.2020 15:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_MusteriGetir](
@MusteriID int
)
as
begin
select Adi,Soyadi,Email from tblMusteriler where ID=@MusteriID
end


GO
/****** Object:  StoredProcedure [dbo].[sp_MusteriLogin]    Script Date: 2.04.2020 15:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_MusteriLogin](
@Email nvarchar(50),
@Sifre nvarchar(50)
)as
begin
declare @Sayac int
set @Sayac=(select count(*) from tblMusteriler where Email=@Email and Sifre=@Sifre)
if @Sayac=0
begin
select 0
end
else
begin
select @Sayac
end
end
GO
