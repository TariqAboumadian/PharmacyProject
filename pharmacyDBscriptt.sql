USE [Yousef Pharmacy96]
GO
/****** Object:  UserDefinedFunction [dbo].[totalprice]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[totalprice](@medicinId INT)
RETURNS INT
AS
  BEGIN
      RETURN
        (SELECT price
         FROM   Medicine
         WHERE  Id = @medicinId )
  END
GO
/****** Object:  UserDefinedFunction [dbo].[totalpricee]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[totalpricee](@medicinId INT)
RETURNS INT
AS
  BEGIN
      RETURN
        (SELECT price
         FROM   Medicine
         WHERE  Id = @medicinId )
  END
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Price] [decimal](10, 5) NULL,
	[unitInStock] [int] NULL,
	[Type] [nvarchar](100) NULL,
	[companyId] [int] NULL,
	[Prod_Date] [date] NULL,
	[Expire_Date] [date] NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[medicineReport]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[medicineReport] 
as 
	select * from [dbo].[Medicine]
GO
/****** Object:  Table [dbo].[medicineCompany]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicineCompany](
	[Name] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
	[Address] [varchar](150) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_medicineCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[companyReport]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create view [dbo].[companyReport]
as 
	select * from [dbo].[medicineCompany]
	
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[adminID] [int] NULL,
	[medicineID] [int] NULL,
	[MedicineName] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[price] [decimal](18, 3) NULL,
	[Totalcost] [decimal](18, 3) NULL,
	[salesDate] [datetime] NULL,
	[salesID] [int] IDENTITY(1,1) NOT NULL,
	[billnumber] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[salesID] ASC,
	[billnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[salesReport]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[salesReport]
as 
	select * from Sales
GO
/****** Object:  UserDefinedFunction [dbo].[medcineCompanyDetials]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[medcineCompanyDetials](@companyID int)
returns table
as
return(
select m.* from Medicine m  where m.companyId=@companyID
)
GO
/****** Object:  View [dbo].[medicinecompanies]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[medicinecompanies]
as
	select C.Name as companyName,M.* from medicineCompany C inner join Medicine M
	on C.ID=M.companyId
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[userName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[UserRule] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (6, N'Tariq Aboumadian', N'tariq@gmail.com', N'123', 1)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (12, N'Nora Mahmoud', N'nora@gmail.com', N'123', 0)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (17, N'amro Slama', N'amro@gmail.com', N'123', 1)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (18, N'Youssef Mahfouz', N'youssef@gmail.com', N'098', 0)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (19, N'Hossam Gmal', N'hosam@gmail.com', N'123', 0)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (21, N'Ahmed Mahmoud', N'ahmed@gmail.com', N'456', 1)
INSERT [dbo].[Admin] ([ID], [Name], [userName], [Password], [UserRule]) VALUES (22, N'Ahmed Gmal', N'ahmed@gmail.com', N'123', 0)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (10, N'Aspirin                                                                                             ', CAST(5.99000 AS Decimal(10, 5)), 59, N'antibiotic                                                                                          ', 11, CAST(N'2023-04-24' AS Date), CAST(N'2023-09-30' AS Date))
INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (11, N'Ibuprofen                                                                                           ', CAST(7.99000 AS Decimal(10, 5)), 50, N'Pain antibiotic                                                                                     ', 4, CAST(N'2023-04-24' AS Date), CAST(N'2023-07-30' AS Date))
INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (12, N'oplex                                                                                               ', CAST(25.00000 AS Decimal(10, 5)), 70, N'antibiotic                                                                                          ', 4, CAST(N'2023-04-21' AS Date), CAST(N'2023-04-24' AS Date))
INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (25, N'Flix                                                                                                ', CAST(50.00000 AS Decimal(10, 5)), 65, N'Spray                                                                                               ', 5, CAST(N'2023-04-27' AS Date), CAST(N'2025-01-01' AS Date))
INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (27, N'Exdreen                                                                                             ', CAST(20.00000 AS Decimal(10, 5)), 90, N'tblets                                                                                              ', 11, CAST(N'2023-04-27' AS Date), CAST(N'2024-06-21' AS Date))
INSERT [dbo].[Medicine] ([Id], [Name], [Price], [unitInStock], [Type], [companyId], [Prod_Date], [Expire_Date]) VALUES (28, N'Panadol Extra                                                                                       ', CAST(20.00000 AS Decimal(10, 5)), 100, N'tablets                                                                                             ', 6, CAST(N'2023-04-27' AS Date), CAST(N'2024-09-26' AS Date))
SET IDENTITY_INSERT [dbo].[Medicine] OFF
GO
SET IDENTITY_INSERT [dbo].[medicineCompany] ON 

INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'GlaxoSmithKline', 4, N'GlaxoSmithKline@gmail.com', N'cairo', N'10113926779')
INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'Amgen', 5, N'Amgen@gmail.com', N'alex', N'1013532296')
INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'AbbVie', 6, N'AbbVie@gmail.com', N'cairo', N'1011130296')
INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'Novartis', 7, N'Novartis@gmail.com', N'mansoura', N'1039058992')
INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'Pharma                                            ', 11, N'pharma@gmail.com                                                                                    ', N'sharkia                                                                                             ', N'222698746')
INSERT [dbo].[medicineCompany] ([Name], [ID], [Email], [Address], [Phone]) VALUES (N'Sedco', 12, N'sed@gmail.com', N'Assuit', N'+8825185786')
SET IDENTITY_INSERT [dbo].[medicineCompany] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 2, CAST(6.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(N'2023-04-28T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 2, CAST(6.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(N'2023-04-28T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 11, N'Ibuprofen                                         ', 3, CAST(8.000 AS Decimal(18, 3)), CAST(24.000 AS Decimal(18, 3)), CAST(N'2023-04-28T00:00:00.000' AS DateTime), 3, 1)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 2, CAST(6.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(N'2023-04-28T00:00:00.000' AS DateTime), 4, 2)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 2, CAST(6.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(N'2023-04-28T00:00:00.000' AS DateTime), 10, 3)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 25, N'Flix                                              ', 2, CAST(45.000 AS Decimal(18, 3)), CAST(90.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 11, 4)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 1, CAST(6.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 12, 5)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 2, CAST(6.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 13, 6)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 25, N'Flix                                              ', 1, CAST(45.000 AS Decimal(18, 3)), CAST(45.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 14, 7)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 11, N'Ibuprofen                                         ', 2, CAST(8.000 AS Decimal(18, 3)), CAST(16.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 15, 8)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 11, N'Ibuprofen                                         ', 2, CAST(8.000 AS Decimal(18, 3)), CAST(16.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 18, 9)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 25, N'Flix                                              ', 1, CAST(45.000 AS Decimal(18, 3)), CAST(45.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 19, 9)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 5, CAST(6.000 AS Decimal(18, 3)), CAST(30.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 20, 9)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 1, CAST(6.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 21, 10)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 25, N'Flix                                              ', 1, CAST(45.000 AS Decimal(18, 3)), CAST(45.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 23, 11)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 5, CAST(6.000 AS Decimal(18, 3)), CAST(30.000 AS Decimal(18, 3)), CAST(N'2023-04-29T00:00:00.000' AS DateTime), 25, 11)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 1, CAST(6.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)), CAST(N'2023-04-30T00:00:00.000' AS DateTime), 27, 12)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 25, N'Flix                                              ', 3, CAST(50.000 AS Decimal(18, 3)), CAST(150.000 AS Decimal(18, 3)), CAST(N'2023-04-30T00:00:00.000' AS DateTime), 31, 12)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 27, N'Exdreen                                           ', 2, CAST(20.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)), CAST(N'2023-04-30T00:00:00.000' AS DateTime), 32, 13)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (12, 10, N'Aspirin                                           ', 3, CAST(6.000 AS Decimal(18, 3)), CAST(18.000 AS Decimal(18, 3)), CAST(N'2023-04-30T00:00:00.000' AS DateTime), 35, 14)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 10, N'Aspirin                                           ', 1, CAST(6.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)), CAST(N'2023-04-30T00:00:00.000' AS DateTime), 36, 14)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 27, N'Exdreen                                           ', 3, CAST(20.000 AS Decimal(18, 3)), CAST(60.000 AS Decimal(18, 3)), CAST(N'2023-05-16T00:00:00.000' AS DateTime), 37, 15)
INSERT [dbo].[Sales] ([adminID], [medicineID], [MedicineName], [Quantity], [price], [Totalcost], [salesDate], [salesID], [billnumber]) VALUES (6, 27, N'Exdreen                                           ', 5, CAST(20.000 AS Decimal(18, 3)), CAST(100.000 AS Decimal(18, 3)), CAST(N'2023-05-16T00:00:00.000' AS DateTime), 42, 17)
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
ALTER TABLE [dbo].[Medicine] ADD  CONSTRAINT [DF_Medicine_Prod_Date]  DEFAULT (getdate()) FOR [Prod_Date]
GO
ALTER TABLE [dbo].[Medicine] ADD  CONSTRAINT [DF_Medicine_Expire_Date]  DEFAULT (getdate()+(60)) FOR [Expire_Date]
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_medicineCompany] FOREIGN KEY([companyId])
REFERENCES [dbo].[medicineCompany] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_medicineCompany]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Admin] FOREIGN KEY([adminID])
REFERENCES [dbo].[Admin] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Admin]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Medicine] FOREIGN KEY([medicineID])
REFERENCES [dbo].[Medicine] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Medicine]
GO
/****** Object:  StoredProcedure [dbo].[AddAdmin]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[AddAdmin]  @name nvarchar(100),@username nvarchar(100),@Password nvarchar(100),
@role bit
as
begin 
	
		insert into [dbo].[Admin] values
		   (@name,@username,@Password,@role)
end
GO
/****** Object:  StoredProcedure [dbo].[Addcompany]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[Addcompany]  @name varchar(100),@email varchar(100),@address varchar(100),@phone varchar(50)
as
begin 
	
		insert into [dbo].[medicineCompany] values
		(@name,@email,@address,@phone)
	
end
GO
/****** Object:  StoredProcedure [dbo].[Addmedicine]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[Addmedicine]  @name nchar(100),@price decimal(10,5),@unitInStock int,@type  nchar(100),@companyId int,
@prod_Date date,@expire_date date
as
begin 
	
		insert into [dbo].[Medicine] values
		(@name,@price,@unitInStock ,@type,@companyId,@prod_Date,@expire_date)
	
end
GO
/****** Object:  StoredProcedure [dbo].[Addsales]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[Addsales]  @adminID int,@medicineID int ,@quantity int,  @date datetime ,
@billnum int,@totalcost decimal,@name varchar(50),@price decimal
as
begin 
		insert into [dbo].[Sales] values
		(@adminID,@medicineID,@name,@quantity,@price,@totalcost,@date,@billnum)
		end
GO
/****** Object:  StoredProcedure [dbo].[DeleteAdmin]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteAdmin] @id int
as
begin
delete from admin where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deletecompany]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[deletecompany] @id int 
as
begin 
	
		delete from  [dbo].[medicineCompany] 
		where ID=@id
		
	
end
GO
/****** Object:  StoredProcedure [dbo].[deleteesales]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[deleteesales] @salesid int
as
begin 
	
		delete from  [dbo].[Sales]
		where salesID=@salesid
end
GO
/****** Object:  StoredProcedure [dbo].[deletemedicine]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[deletemedicine] @id int 
as
begin 
	
		delete from  [dbo].[Medicine]
		where ID=@id
		
	
end
GO
/****** Object:  StoredProcedure [dbo].[editadmin]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editadmin] @id int,@name varchar(50),@usrname varchar(50),@pass varchar(50)
as
begin
	update Admin set Name=@name,userName=@usrname,Password=@pass where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[editcompany]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[editcompany] @id int, @name nchar(100),@email nchar(100),@address nchar(100),@phone bigint
as
begin 
	
		update  [dbo].[medicineCompany] 
		set Name=@name ,Email=@email, Address=@address, Phone =@phone
		where ID=@id
		
	
end
GO
/****** Object:  StoredProcedure [dbo].[editmedicine]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[editmedicine] @id int,  @name nchar(100),@price decimal(10,5),@unitInStock int
                           ,@type  nchar(100),@companyId int,@prodDate date,@expireDate date
as
begin 
	
		update  [dbo].[Medicine]
		set Name=@name ,Price=@price, unitInStock=@unitInStock, Type =@type, companyId=@companyId,Prod_Date=@prodDate,Expire_Date=@expireDate
		where Id=@id
		
	
end
GO
/****** Object:  StoredProcedure [dbo].[editsales]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[editsales] @SalesId int, @adminID int,@medicineID int ,@quantity int,  @date datetime,
@medicinename varchar(50),@price decimal,@totalcost decimal,@billnumber int
as
begin 
	
		update [dbo].[Sales]
		set  Quantity=@quantity, salesDate=@date,adminID=@adminID,medicineID=@medicineID,
		MedicineName=@medicinename,price=@price,Totalcost=@totalcost,billnumber=@billnumber
		where salesID =@SalesId
	
end
GO
/****** Object:  StoredProcedure [dbo].[getExpiredMedicine]    Script Date: 7/10/2023 10:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getExpiredMedicine]
as
 begin
DECLARE c1 CURSOR
  for
	 select Expire_Date,Id from Medicine
  OPEN c1
  declare @expriedDate date,@id int
  FETCH c1 into @expriedDate, @id
  WHILE @@fetch_status =0
  BEGIN
       if getdate()>= @expriedDate
	    begin
	    insert into [dbo].[ExpiredMedicine]
		       select * from Medicine where Id=@id
		delete from Medicine where Id=@id
		end
    FETCH c1 INTO @expriedDate , @id
  END
  CLOSE c1
  DEALLOCATE c1
  end
GO
