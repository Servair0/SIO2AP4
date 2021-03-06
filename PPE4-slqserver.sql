Create database SIO2AP4_Dauvergne
/****** Object:  Table [administrateur]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [administrateur](
	[id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [badge]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [badge](
	[id] [int]  NOT NULL,
	[uid] [nvarchar](25) NOT NULL,
	[actif] [smallint] NOT NULL,
 CONSTRAINT [PK_badge_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [categ_soins]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [categ_soins](
	[id] [int]  NOT NULL,
	[libel] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_categ_soins_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [categorie_indisponibilite]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [categorie_indisponibilite](
	[id] [int]  NOT NULL,
	[libelle] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_categorie_indisponibilite_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [chambre_forte]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chambre_forte](
	[badge] [nvarchar](25) NOT NULL,
	[date] [datetime] NOT NULL DEFAULT (getdate()),
	[acces_ok] [smallint] NOT NULL,
 CONSTRAINT [PK_chambre_forte_badge] PRIMARY KEY CLUSTERED 
(
	[badge] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [convalescence]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [convalescence](
	[id_patient] [int] NOT NULL,
	[id_lieux] [int] NOT NULL,
	[date_deb] [date] NOT NULL,
	[date_fin] [date] NULL,
	[chambre] [nvarchar](50) NULL,
	[tel_directe] [nchar](10) NULL,
 CONSTRAINT [PK_convalescence_id_patient] PRIMARY KEY CLUSTERED 
(
	[id_patient] ASC,
	[id_lieux] ASC,
	[date_deb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [indisponibilite]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [indisponibilite](
	[infirmiere] [int] NOT NULL,
	[date_debut] [date] NOT NULL,
	[date_fin] [date] NOT NULL,
	[heure_deb] [time](7) NULL,
	[heure_fin] [time](7) NULL,
	[categorie] [int] NOT NULL,
 CONSTRAINT [PK_indisponibilite_infirmiere] PRIMARY KEY CLUSTERED 
(
	[infirmiere] ASC,
	[date_debut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [infirmiere]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infirmiere](
	[id] [int] NOT NULL,
	[fichier_photo] [nvarchar](250) NULL DEFAULT (NULL),
 CONSTRAINT [PK_infirmiere_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [infirmiere_badge]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [infirmiere_badge](
	[id_infirmiere] [int] NOT NULL,
	[id_badge] [int] NOT NULL,
	[date_deb] [date] NOT NULL,
	[date_fin] [date] NULL DEFAULT (NULL),
 CONSTRAINT [PK_infirmiere_badge_id_infirmiere] PRIMARY KEY CLUSTERED 
(
	[id_infirmiere] ASC,
	[id_badge] ASC,
	[date_deb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lieu_convalescence]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lieu_convalescence](
	[id] [int] NOT NULL,
	[titre] [nvarchar](max) NOT NULL,
	[ad1] [nvarchar](255) NOT NULL,
	[ad2] [nvarchar](255) NOT NULL,
	[cp] [nchar](5) NOT NULL,
	[ville] [nvarchar](255) NOT NULL,
	[tel_fixe] [nchar](10) NOT NULL,
	[contact] [int] NULL,
 CONSTRAINT [PK_lieu_convalescence_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [patient]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [patient](
	[id] [int] NOT NULL,
	[informations_medicales] [nvarchar](max) NOT NULL,
	[personne_de_confiance] [int] NULL DEFAULT (NULL),
	[infirmiere_souhait] [int] NULL DEFAULT (NULL),
 CONSTRAINT [PK_patient_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [personne]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [personne](
	[id] [int]  NOT NULL,
	[nom] [nvarchar](100) NOT NULL,
	[prenom] [nvarchar](100) NOT NULL,
	[sexe] [nchar](1) NOT NULL,
	[date_naiss] [date] NULL DEFAULT (NULL),
	[date_deces] [date] NULL DEFAULT (NULL),
	[ad1] [nvarchar](100) NULL DEFAULT (NULL),
	[ad2] [nvarchar](100) NULL DEFAULT (NULL),
	[cp] [int] NULL DEFAULT (NULL),
	[ville] [nvarchar](100) NULL DEFAULT (NULL),
	[tel_fixe] [nvarchar](15) NULL DEFAULT (NULL),
	[tel_port] [nvarchar](15) NULL DEFAULT (NULL),
	[mail] [nvarchar](30) NULL DEFAULT (NULL),
 CONSTRAINT [PK_personne_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [personne_login]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [personne_login](
	[id] [int] NOT NULL,
	[login] [nvarchar](25) NOT NULL,
	[mp] [nchar](32) NOT NULL,
	[derniere_connexion] [date] NULL DEFAULT (NULL),
	[nb_tentative_erreur] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_personne_login_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [soins]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [soins](
	[id_categ_soins] [int] NOT NULL,
	[id_type_soins] [int] NOT NULL,
	[id] [int] NOT NULL,
	[libel] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
	[coefficient] [real] NOT NULL,
	[date] [datetime] NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_soins_id_categ_soins] PRIMARY KEY CLUSTERED 
(
	[id_categ_soins] ASC,
	[id_type_soins] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [soins_visite]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [soins_visite](
	[visite] [int] NOT NULL,
	[id_categ_soins] [int] NOT NULL,
	[id_type_soins] [int] NOT NULL,
	[id_soins] [int] NOT NULL,
	[prevu] [smallint] NOT NULL,
	[realise] [smallint] NOT NULL,
 CONSTRAINT [PK_soins_visite_visite] PRIMARY KEY CLUSTERED 
(
	[visite] ASC,
	[id_categ_soins] ASC,
	[id_type_soins] ASC,
	[id_soins] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [specialisation]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [specialisation](
	[id_infirmiere] [int] NOT NULL,
	[id_categ_soins] [int] NOT NULL,
	[id_type_soins] [int] NOT NULL,
 CONSTRAINT [PK_specialisation_id_infirmiere] PRIMARY KEY CLUSTERED 
(
	[id_infirmiere] ASC,
	[id_categ_soins] ASC,
	[id_type_soins] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [temoignage]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [temoignage](
	[id] [int] NOT NULL,
	[personne_login] [int] NOT NULL,
	[contenu] [nvarchar](max) NOT NULL,
	[date] [datetime2](0) NOT NULL,
	[valide] [smallint] NOT NULL,
 CONSTRAINT [PK_temoignage_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [token]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [token](
	[id] [int] NOT NULL,
	[id_login] [int] NOT NULL,
	[date] [datetime2](0) NOT NULL,
	[jeton] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_token_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [type_soins]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [type_soins](
	[id_categ_soins] [int] NOT NULL,
	[id_type_soins] [int] NOT NULL,
	[libel] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_type_soins_id_categ_soins] PRIMARY KEY CLUSTERED 
(
	[id_categ_soins] ASC,
	[id_type_soins] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [visite]    Script Date: 26/02/2019 18:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [visite](
	[id] [int] NOT NULL,
	[patient] [int] NOT NULL,
	[infirmiere] [int] NOT NULL,
	[date_prevue] [datetime2](0) NOT NULL,
	[date_reelle] [datetime2](0) NULL DEFAULT (NULL),
	[duree] [int] NOT NULL,
	[compte_rendu_infirmiere] [nvarchar](max) NULL,
	[compte_rendu_patient] [nvarchar](max) NULL,
 CONSTRAINT [PK_visite_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [convalescence] ADD  DEFAULT (NULL) FOR [date_fin]
GO
ALTER TABLE [convalescence] ADD  DEFAULT (NULL) FOR [chambre]
GO
ALTER TABLE [convalescence] ADD  DEFAULT (NULL) FOR [tel_directe]
GO
ALTER TABLE [indisponibilite] ADD  DEFAULT (NULL) FOR [heure_deb]
GO
ALTER TABLE [indisponibilite] ADD  DEFAULT (NULL) FOR [heure_fin]
GO
ALTER TABLE [lieu_convalescence] ADD  DEFAULT (NULL) FOR [contact]
GO
ALTER TABLE [convalescence]  WITH NOCHECK ADD  CONSTRAINT [convalescence$convalescence_ibfk_1] FOREIGN KEY([id_patient])
REFERENCES [patient] ([id])
GO
ALTER TABLE [convalescence] CHECK CONSTRAINT [convalescence$convalescence_ibfk_1]
GO
ALTER TABLE [convalescence]  WITH NOCHECK ADD  CONSTRAINT [convalescence$convalescence_ibfk_2] FOREIGN KEY([id_lieux])
REFERENCES [lieu_convalescence] ([id])
GO
ALTER TABLE [convalescence] CHECK CONSTRAINT [convalescence$convalescence_ibfk_2]
GO
ALTER TABLE [indisponibilite]  WITH NOCHECK ADD  CONSTRAINT [indisponibilite$indisponibilite_ibfk_1] FOREIGN KEY([infirmiere])
REFERENCES [infirmiere] ([id])
GO
ALTER TABLE [indisponibilite] CHECK CONSTRAINT [indisponibilite$indisponibilite_ibfk_1]
GO
ALTER TABLE [indisponibilite]  WITH NOCHECK ADD  CONSTRAINT [indisponibilite$indisponibilite_ibfk_2] FOREIGN KEY([categorie])
REFERENCES [categorie_indisponibilite] ([id])
GO
ALTER TABLE [indisponibilite] CHECK CONSTRAINT [indisponibilite$indisponibilite_ibfk_2]
GO
ALTER TABLE [infirmiere]  WITH NOCHECK ADD  CONSTRAINT [infirmiere$infirmiere_ibfk_1] FOREIGN KEY([id])
REFERENCES [personne] ([id])
GO
ALTER TABLE [infirmiere] CHECK CONSTRAINT [infirmiere$infirmiere_ibfk_1]
GO
ALTER TABLE [infirmiere_badge]  WITH NOCHECK ADD  CONSTRAINT [infirmiere_badge$infirmiere_badge_ibfk_1] FOREIGN KEY([id_infirmiere])
REFERENCES [infirmiere] ([id])
GO
ALTER TABLE [infirmiere_badge] CHECK CONSTRAINT [infirmiere_badge$infirmiere_badge_ibfk_1]
GO
ALTER TABLE [infirmiere_badge]  WITH NOCHECK ADD  CONSTRAINT [infirmiere_badge$infirmiere_badge_ibfk_2] FOREIGN KEY([id_badge])
REFERENCES [badge] ([id])
GO
ALTER TABLE [infirmiere_badge] CHECK CONSTRAINT [infirmiere_badge$infirmiere_badge_ibfk_2]
GO
ALTER TABLE [lieu_convalescence]  WITH NOCHECK ADD  CONSTRAINT [lieu_convalescence$lieu_convalescence_ibfk_1] FOREIGN KEY([contact])
REFERENCES [personne] ([id])
GO
ALTER TABLE [lieu_convalescence] CHECK CONSTRAINT [lieu_convalescence$lieu_convalescence_ibfk_1]
GO
ALTER TABLE [patient]  WITH NOCHECK ADD  CONSTRAINT [patient$patient_ibfk_1] FOREIGN KEY([id])
REFERENCES [personne] ([id])
GO
ALTER TABLE [patient] CHECK CONSTRAINT [patient$patient_ibfk_1]
GO
ALTER TABLE [patient]  WITH NOCHECK ADD  CONSTRAINT [patient$patient_ibfk_2] FOREIGN KEY([personne_de_confiance])
REFERENCES [personne] ([id])
GO
ALTER TABLE [patient] CHECK CONSTRAINT [patient$patient_ibfk_2]
GO
ALTER TABLE [patient]  WITH NOCHECK ADD  CONSTRAINT [patient$patient_ibfk_3] FOREIGN KEY([infirmiere_souhait])
REFERENCES [infirmiere] ([id])
GO
ALTER TABLE [patient] CHECK CONSTRAINT [patient$patient_ibfk_3]
GO
ALTER TABLE [personne_login]  WITH NOCHECK ADD  CONSTRAINT [personne_login$personne_login_ibfk_1] FOREIGN KEY([id])
REFERENCES [personne] ([id])
GO
ALTER TABLE [personne_login] CHECK CONSTRAINT [personne_login$personne_login_ibfk_1]
GO
ALTER TABLE [soins]  WITH NOCHECK ADD  CONSTRAINT [soins$FK_soins] FOREIGN KEY([id_categ_soins], [id_type_soins])
REFERENCES [type_soins] ([id_categ_soins], [id_type_soins])
GO
ALTER TABLE [soins] CHECK CONSTRAINT [soins$FK_soins]
GO
ALTER TABLE [soins_visite]  WITH NOCHECK ADD  CONSTRAINT [soins_visite$soins_visite_ibfk_1] FOREIGN KEY([visite])
REFERENCES [visite] ([id])
GO
ALTER TABLE [soins_visite] CHECK CONSTRAINT [soins_visite$soins_visite_ibfk_1]
GO
ALTER TABLE [soins_visite]  WITH NOCHECK ADD  CONSTRAINT [soins_visite$soins_visite_ibfk_2] FOREIGN KEY([id_categ_soins], [id_type_soins], [id_soins])
REFERENCES [soins] ([id_categ_soins], [id_type_soins], [id])
GO
ALTER TABLE [soins_visite] CHECK CONSTRAINT [soins_visite$soins_visite_ibfk_2]
GO
ALTER TABLE [specialisation]  WITH NOCHECK ADD  CONSTRAINT [specialisation$specialisation_ibfk_1] FOREIGN KEY([id_infirmiere])
REFERENCES [infirmiere] ([id])
GO
ALTER TABLE [specialisation] CHECK CONSTRAINT [specialisation$specialisation_ibfk_1]
GO
ALTER TABLE [specialisation]  WITH NOCHECK ADD  CONSTRAINT [specialisation$specialisation_ibfk_2] FOREIGN KEY([id_categ_soins], [id_type_soins])
REFERENCES [type_soins] ([id_categ_soins], [id_type_soins])
GO
ALTER TABLE [specialisation] CHECK CONSTRAINT [specialisation$specialisation_ibfk_2]
GO
ALTER TABLE [temoignage]  WITH NOCHECK ADD  CONSTRAINT [temoignage$temoignage_ibfk_1] FOREIGN KEY([personne_login])
REFERENCES [personne_login] ([id])
GO
ALTER TABLE [temoignage] CHECK CONSTRAINT [temoignage$temoignage_ibfk_1]
GO
ALTER TABLE [token]  WITH NOCHECK ADD  CONSTRAINT [token$token_ibfk_1] FOREIGN KEY([id_login])
REFERENCES [personne_login] ([id])
GO
ALTER TABLE [token] CHECK CONSTRAINT [token$token_ibfk_1]
GO
ALTER TABLE [type_soins]  WITH NOCHECK ADD  CONSTRAINT [type_soins$type_soins_ibfk_1] FOREIGN KEY([id_categ_soins])
REFERENCES [categ_soins] ([id])
GO
ALTER TABLE [type_soins] CHECK CONSTRAINT [type_soins$type_soins_ibfk_1]
GO
ALTER TABLE [visite]  WITH NOCHECK ADD  CONSTRAINT [visite$visite_ibfk_1] FOREIGN KEY([patient])
REFERENCES [patient] ([id])
GO
ALTER TABLE [visite] CHECK CONSTRAINT [visite$visite_ibfk_1]
GO
ALTER TABLE [visite]  WITH NOCHECK ADD  CONSTRAINT [visite$visite_ibfk_2] FOREIGN KEY([infirmiere])
REFERENCES [infirmiere] ([id])
GO
ALTER TABLE [visite] CHECK CONSTRAINT [visite$visite_ibfk_2]
GO
