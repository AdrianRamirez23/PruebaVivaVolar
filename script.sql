USE [VivaVolar]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 9/03/2022 11:27:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[idReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdVuelo] [int] NOT NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 9/03/2022 11:27:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoIdentificacion](
	[idTipoIdentificacion] [int] IDENTITY(1,1) NOT NULL,
	[TipoIdentificacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoIdentificacion] PRIMARY KEY CLUSTERED 
(
	[idTipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 9/03/2022 11:27:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[idTipoUser] [int] IDENTITY(1,1) NOT NULL,
	[TipoUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[idTipoUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/03/2022 11:27:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](150) NOT NULL,
	[NombreUsuario] [varchar](150) NOT NULL,
	[PassUser] [varchar](13) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[idTipoUser] [int] NOT NULL,
	[UsuarioIdentificacion] [varchar](10) NOT NULL,
	[TipoIdentificacion] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelos]    Script Date: 9/03/2022 11:27:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelos](
	[idVuelo] [int] IDENTITY(1,1) NOT NULL,
	[NumeroVuelo] [varchar](10) NOT NULL,
	[FechaDisponibilidad] [date] NOT NULL,
	[CantidadSilla] [int] NOT NULL,
	[CiudadOrigen] [varchar](20) NOT NULL,
	[CiudadDestino] [varchar](20) NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Vuelos] PRIMARY KEY CLUSTERED 
(
	[idVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reservas] ON 

INSERT [dbo].[Reservas] ([idReserva], [IdUsuario], [IdVuelo]) VALUES (1, 1, 3)
INSERT [dbo].[Reservas] ([idReserva], [IdUsuario], [IdVuelo]) VALUES (2, 2, 3)
INSERT [dbo].[Reservas] ([idReserva], [IdUsuario], [IdVuelo]) VALUES (3, 3, 1)
SET IDENTITY_INSERT [dbo].[Reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoIdentificacion] ON 

INSERT [dbo].[TipoIdentificacion] ([idTipoIdentificacion], [TipoIdentificacion]) VALUES (1, N'Cédula Ciudadanía')
INSERT [dbo].[TipoIdentificacion] ([idTipoIdentificacion], [TipoIdentificacion]) VALUES (2, N'Cédula Extrangería')
INSERT [dbo].[TipoIdentificacion] ([idTipoIdentificacion], [TipoIdentificacion]) VALUES (3, N'NIT')
SET IDENTITY_INSERT [dbo].[TipoIdentificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 

INSERT [dbo].[TipoUsuario] ([idTipoUser], [TipoUser]) VALUES (1, N'Administrador')
INSERT [dbo].[TipoUsuario] ([idTipoUser], [TipoUser]) VALUES (2, N'Usuario Persona Natural')
INSERT [dbo].[TipoUsuario] ([idTipoUser], [TipoUser]) VALUES (3, N'Usuario Persona Jurídica')
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [Usuario], [NombreUsuario], [PassUser], [Email], [idTipoUser], [UsuarioIdentificacion], [TipoIdentificacion]) VALUES (1, N'aeramirezji', N'Adrian E Ramirez', N'Nicolas1*', N'adrian.ramirez23@hotmail.com', 1, N'1036598444', 1)
INSERT [dbo].[Usuario] ([idUsuario], [Usuario], [NombreUsuario], [PassUser], [Email], [idTipoUser], [UsuarioIdentificacion], [TipoIdentificacion]) VALUES (2, N'nhiguita', N'Natalia Higuita', N'Maxi123*', N'nataliahig@gmail.com', 2, N'1128433392', 1)
INSERT [dbo].[Usuario] ([idUsuario], [Usuario], [NombreUsuario], [PassUser], [Email], [idTipoUser], [UsuarioIdentificacion], [TipoIdentificacion]) VALUES (3, N'nramirez', N'Nicolas Ramirez Higuita', N'Nico123**', N'nataliahig@gmail.com', 2, N'1036666666', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Vuelos] ON 

INSERT [dbo].[Vuelos] ([idVuelo], [NumeroVuelo], [FechaDisponibilidad], [CantidadSilla], [CiudadOrigen], [CiudadDestino], [Precio]) VALUES (1, N'VUELO1', CAST(N'2022-04-09' AS Date), 24, N'MEDELLIN', N'BOGOTÁ', 58000)
INSERT [dbo].[Vuelos] ([idVuelo], [NumeroVuelo], [FechaDisponibilidad], [CantidadSilla], [CiudadOrigen], [CiudadDestino], [Precio]) VALUES (3, N'VUELO2', CAST(N'2022-04-10' AS Date), 50, N'MEDELLIN', N'SAN ANDRES', 108000)
SET IDENTITY_INSERT [dbo].[Vuelos] OFF
GO
/****** Object:  Index [IX_TipoIdentificacion]    Script Date: 9/03/2022 11:27:16 a. m. ******/
ALTER TABLE [dbo].[TipoIdentificacion] ADD  CONSTRAINT [IX_TipoIdentificacion] UNIQUE NONCLUSTERED 
(
	[idTipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoUsuario]    Script Date: 9/03/2022 11:27:16 a. m. ******/
ALTER TABLE [dbo].[TipoUsuario] ADD  CONSTRAINT [IX_TipoUsuario] UNIQUE NONCLUSTERED 
(
	[idTipoUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario]    Script Date: 9/03/2022 11:27:16 a. m. ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [IX_Usuario] UNIQUE NONCLUSTERED 
(
	[UsuarioIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vuelos]    Script Date: 9/03/2022 11:27:16 a. m. ******/
ALTER TABLE [dbo].[Vuelos] ADD  CONSTRAINT [IX_Vuelos] UNIQUE NONCLUSTERED 
(
	[NumeroVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Usuario]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Vuelos] FOREIGN KEY([IdVuelo])
REFERENCES [dbo].[Vuelos] ([idVuelo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Vuelos]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoIdentificacion] FOREIGN KEY([TipoIdentificacion])
REFERENCES [dbo].[TipoIdentificacion] ([idTipoIdentificacion])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoIdentificacion]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([idTipoUser])
REFERENCES [dbo].[TipoUsuario] ([idTipoUser])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
