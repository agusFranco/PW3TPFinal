-- RESETEO
DELETE FROM Calificaciones;
DELETE FROM EventosRecetas;
DELETE FROM Eventos;
DELETE FROM Usuarios;
DELETE FROM Recetas;
DELETE FROM TipoRecetas;
DELETE FROM Reservas;
DBCC CHECKIDENT (Calificaciones,RESEED, 0)
DBCC CHECKIDENT (EventosRecetas,RESEED, 0)
DBCC CHECKIDENT (Eventos,RESEED, 0)
DBCC CHECKIDENT (Usuarios,RESEED, 0)
DBCC CHECKIDENT (Recetas,RESEED, 0)
DBCC CHECKIDENT (TipoRecetas,RESEED, 0)
DBCC CHECKIDENT (Reservas,RESEED, 0)
GO
-- FIN RESETEO

-- INICIO USUARIOS
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Email], [Password], [Perfil], [FechaRegistracion]) VALUES
(1, N'Comensal 1', N'comensal@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(2, N'Comensal 2', N'comensal2@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(3, N'Comensal 3', N'comensal3@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(4, N'Comensal 4', N'comensal4@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(5, N'Comensal 5', N'comensal5@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(6, N'Comensal 6', N'comensal6@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(7, N'Comensal 7', N'comensal7@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(8, N'Comensal 8', N'comensal8@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(9, N'Comensal 9', N'comensal9@test.com', N'$2a$11$QC0dGyGRsp1NEGtwYURT8OrtTqu7c.tArI60IztjwjgDLU6NLGO6S', 2, CAST(N'2021-11-16T02:07:41.760' AS DateTime)),
(10, N'Cocinero 1', N'cocinero@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(11, N'Cocinero 2', N'cocinero2@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(12, N'Cocinero 3', N'cocinero3@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(13, N'Cocinero 4', N'cocinero4@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(14, N'Cocinero 5', N'cocinero5@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(15, N'Cocinero 6', N'cocinero6@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(16, N'Cocinero 7', N'cocinero7@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(17, N'Cocinero 8', N'cocinero8@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime)),
(18, N'Cocinero 9', N'cocinero9@test.com', N'$2a$11$eE2pDJfqr9ul27a8NYAIZeU9hx9l8mjvWHsbk49wdZqskpZpZNZ2m', 1, CAST(N'2021-11-16T02:07:52.453' AS DateTime));
GO

SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO

-- FIN USUARIOS

-- INICIO TIPO RECETAS
SET IDENTITY_INSERT [dbo].[TipoRecetas] ON 
GO

INSERT INTO [TipoRecetas] (IdTipoReceta, Nombre)
VALUES
  (1, 'Postre'),
  (2, 'Rapida'),
  (3, 'Coccion Lenta');  
GO

SET IDENTITY_INSERT [dbo].[TipoRecetas] OFF 
GO
-- FIN TIPO RECETAS

-- RECETAS
SET IDENTITY_INSERT [dbo].[Recetas] ON 
GO

INSERT [dbo].[Recetas] ([IdReceta], [IdCocinero], [Nombre], [TiempoCoccion], [Descripcion], [Ingredientes], [IdTipoReceta]) VALUES 
(1, 10, N'Receta 1', 10, N'Otras cosas', N'Muchas cosas', 1),
(2, 10, N'Receta 2', 20, N'Otras ', N'Cosas', 2),
(3, 11, N'Receta 4', 30, N'Otras', N'Cosas', 3),
(4, 11, N'Receta 5', 10, N'Otras', N'Cosas', 1),
(5, 12, N'Receta 6', 20, N'Otras', N'Cosas', 2),
(6, 12, N'Receta 7', 30, N'Otras', N'Cosas', 3),
(7, 13, N'Receta 8', 10, N'Otras', N'Cosas', 1),
(8, 13, N'Receta 9', 20, N'Otras', N'Cosas', 2),
(9, 14, N'Receta 10', 30, N'Otras', N'Cosas', 3)
GO

SET IDENTITY_INSERT [dbo].[Recetas] OFF
GO

-- FIN RECETAS

-- EVENTOS
SET IDENTITY_INSERT [dbo].[Eventos] ON 
GO

INSERT [dbo].[Eventos] ([IdEvento], [IdCocinero], [Nombre], [Fecha], [CantidadComensales], [Ubicacion], [Foto], [Precio], [Estado]) VALUES 
(1, 10, N'Evento 1',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 10, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(2, 10, N'Evento 2',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(3, 10, N'Evento 3',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(4, 11, N'Evento 4',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(5, 11, N'Evento 5',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(6, 11, N'Evento 6',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 1),
(7, 12, N'Evento 7',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(8, 12, N'Evento 8',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(9, 12, N'Evento 9',   CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(10, 13, N'Evento 10', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(11, 13, N'Evento 11', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(12, 13, N'Evento 12', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(13, 14, N'Evento 13', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(14, 14, N'Evento 14', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(15, 14, N'Evento 15', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0),
(16, 14, N'Evento 16', CAST(N'2021-12-05T00:00:00.000' AS DateTime), 20, N'Ubicacion', N'17749e39-c2a0-4877-a393-f8d49d4a8ae9.jpg', CAST(1000.00 AS Decimal(18, 2)), 0)
GO

SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
-- FIN EVENTOS

-- EVENTOS RECETAS
SET IDENTITY_INSERT [dbo].[EventosRecetas] ON 
GO

INSERT [dbo].[EventosRecetas] ([IdEventoReceta], [IdEvento], [IdReceta]) VALUES 
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 2, 4),
(5, 2, 5),
(6, 2, 6),
(7, 3, 7),
(8, 3, 8),
(9, 3, 9),
(10, 4, 1),
(11, 4, 2),
(12, 4, 3),
(13, 5, 4),
(14, 5, 5),
(15, 5, 6),
(16, 6, 7),
(17, 6, 8),
(18, 6, 9)
GO

SET IDENTITY_INSERT [dbo].[EventosRecetas] OFF
GO

-- FIN EVENTOS RECETAS

--COMENTARIOS

INSERT INTO [dbo].[Calificaciones] ([IdEvento],[IdComensal],[Calificacion],[Comentarios])    
VALUES
--(<IdEvento, int,>,<IdComensal, int,>,<Calificacion, int,>,<Comentarios, nvarchar(max),>)
(1,1,10,'Muy rico!'),
(1,2,10,'Muy rico!'),
(1,3,10,'Muy rico!'),
(1,4,10,'Muy rico!'),
(1,1,10,'Muy rico!'),
(1,2,10,'Muy rico!'),
(1,3,10,'Muy rico!'),
(2,1,10,'Muy rico!'),
(2,2,10,'Muy rico!'),
(2,3,10,'Muy rico!'),
(2,4,10,'Muy rico!'),
(2,1,10,'Muy rico!'),
(2,2,10,'Muy rico!'),
(2,3,10,'Muy rico!'),
(3,1,10,'Muy rico!'),
(3,2,10,'Muy rico!'),
(3,3,10,'Muy rico!'),
(3,4,10,'Muy rico!'),
(3,1,10,'Muy rico!'),
(3,2,10,'Muy rico!'),
(3,3,10,'Muy rico!'),
(4,1,10,'Muy rico!'),
(4,2,10,'Muy rico!'),
(4,3,10,'Muy rico!'),
(4,4,10,'Muy rico!'),
(4,1,10,'Muy rico!'),
(4,2,10,'Muy rico!'),
(4,3,10,'Muy rico!'),
(5,1,10,'Muy rico!'),
(5,2,10,'Muy rico!'),
(5,3,10,'Muy rico!'),
(5,4,10,'Muy rico!'),
(5,1,10,'Muy rico!'),
(5,2,10,'Muy rico!'),
(5,3,10,'Muy rico!'),
(6,1,10,'Muy rico!'),
(6,2,10,'Muy rico!'),
(6,3,10,'Muy rico!'),
(6,4,10,'Muy rico!'),
(6,1,10,'Muy rico!'),
(6,2,10,'Muy rico!'),
(6,3,10,'Muy rico!')
GO

