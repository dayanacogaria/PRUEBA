USE [Negocio]
GO
INSERT [dbo].[Clientes] ([CodCliente], [NomCliente], [Ciudad]) VALUES (N'01', N'Dayana Cogaria', N'Duitama')
INSERT [dbo].[Clientes] ([CodCliente], [NomCliente], [Ciudad]) VALUES (N'02', N'Batman', N'Bogota')
GO
INSERT [dbo].[Productos] ([CodProducto], [NomProducto], [Activo]) VALUES (N'010', N'Teclado', 1)
INSERT [dbo].[Productos] ([CodProducto], [NomProducto], [Activo]) VALUES (N'011', N'Computador', 1)
INSERT [dbo].[Productos] ([CodProducto], [NomProducto], [Activo]) VALUES (N'0123', N'Camara', 1)
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([id], [fecha], [ProductoCodProducto], [ClienteCodCliente], [ValorUnitario], [ValorTotal], [Cantidad]) VALUES (1, CAST(N'2021-03-27T00:00:00.0000000' AS DateTime2), N'010', N'01', CAST(14.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210330143019_Prueba_S.Context.DatabaseContext', N'5.0.4')
GO
