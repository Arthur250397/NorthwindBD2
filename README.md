# NorthwindBD2

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

O projeto foi desenvolvido todo no visual studio 2022. 
Para utilizar componentes do SQL server no projeto foi preciso adicionar o pacote Systen.Data.SqlClient(4.8.4)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


Integrantes: 

ARTHUR MENEZES ALVES DE ARAÚJO,
VICTOR SILVA VALERIANO
JOÃO THALIS RAMOS DA SILVA

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

*SP usada para o relatorio de vendas

USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[sp_vendas_funcionario]    Script Date: 21/11/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_vendas_funcionario] 
					@DataIni Date, 
					@DataFim Date,
					@EmployeeID Int
AS
BEGIN 

	SELECT  
	OD.OrderID AS Pedido,
	P.ProductName AS Produto,
	P.UnitPrice AS [Preço Unitário],
	OD.Quantity,  
	STR(OD.Discount * 100) + '%' AS Desconto,
	(OD.Quantity * OD.UnitPrice * (1-OD.Discount)) AS [Venda Total]
	FROM Orders O join [Order Details] OD on OD.OrderID = O.OrderID
				  join Employees E on E.EmployeeID = O.EmployeeID 
				  join Products P on P.ProductID = OD.ProductID
	WHERE O.OrderDate between @DataIni and @DataFim and E.EmployeeID = @EmployeeID

END
