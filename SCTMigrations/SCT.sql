GO
USE [SistemaDeControlDeTutorias];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasPeriodoEscolar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TutoriasAcademicas] DROP CONSTRAINT [FK_TutoriasAcademicasPeriodoEscolar];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblematicaAcademicaComentariosProblematicas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComentariosProblematicas] DROP CONSTRAINT [FK_ProblematicaAcademicaComentariosProblematicas];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblematicaAcademicaExperienciaEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblematicaAcademica] DROP CONSTRAINT [FK_ProblematicaAcademicaExperienciaEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoEstudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estudiante] DROP CONSTRAINT [FK_ProgramaEducativoEstudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasProblematicaAcademica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblematicaAcademica] DROP CONSTRAINT [FK_TutoriasAcademicasProblematicaAcademica];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodoEscolarProgramaEducativo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativo] DROP CONSTRAINT [FK_PeriodoEscolarProgramaEducativo];
GO
IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasAsistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Asistencia] DROP CONSTRAINT [FK_TutoriasAcademicasAsistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesorEstudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estudiante] DROP CONSTRAINT [FK_ProfesorEstudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoExperienciaEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExperienciaEducativa] DROP CONSTRAINT [FK_ProgramaEducativoExperienciaEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenciaEstudiante_Asistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaEstudiante] DROP CONSTRAINT [FK_AsistenciaEstudiante_Asistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenciaEstudiante_Estudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaEstudiante] DROP CONSTRAINT [FK_AsistenciaEstudiante_Estudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_ExperienciaEducativaProfesor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profesor] DROP CONSTRAINT [FK_ExperienciaEducativaProfesor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoProfesor_ProgramaEducativo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativoProfesor] DROP CONSTRAINT [FK_ProgramaEducativoProfesor_ProgramaEducativo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoProfesor_Profesor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativoProfesor] DROP CONSTRAINT [FK_ProgramaEducativoProfesor_Profesor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Estudiante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estudiante];
GO
IF OBJECT_ID(N'[dbo].[Profesor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profesor];
GO
IF OBJECT_ID(N'[dbo].[ExperienciaEducativa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExperienciaEducativa];
GO
IF OBJECT_ID(N'[dbo].[ProblematicaAcademica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProblematicaAcademica];
GO
IF OBJECT_ID(N'[dbo].[ComentariosProblematicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComentariosProblematicas];
GO
IF OBJECT_ID(N'[dbo].[TutoriasAcademicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TutoriasAcademicas];
GO
IF OBJECT_ID(N'[dbo].[PeriodoEscolar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoEscolar];
GO
IF OBJECT_ID(N'[dbo].[Asistencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asistencia];
GO
IF OBJECT_ID(N'[dbo].[ProgramaEducativo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramaEducativo];
GO
IF OBJECT_ID(N'[dbo].[Administrador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Administrador];
GO
IF OBJECT_ID(N'[dbo].[AsistenciaEstudiante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistenciaEstudiante];
GO
IF OBJECT_ID(N'[dbo].[ProgramaEducativoProfesor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramaEducativoProfesor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Estudiante'
CREATE TABLE [dbo].[Estudiante] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Matricula] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [ApellidoPaterno] nvarchar(max)  NOT NULL,
    [ApellidoMaterno] nvarchar(max)  NOT NULL,
    [CorreoPersonal] nvarchar(max)  NOT NULL,
    [CorreoInstitucional] nvarchar(max)  NOT NULL,
    [ProgramaEducativo_Id] int  NOT NULL,
    [Tutor_Id] int  NOT NULL
);
GO

-- Creating table 'Profesor'
CREATE TABLE [dbo].[Profesor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroDePersonal] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [ApellidoPaterno] nvarchar(max)  NOT NULL,
    [ApellidoMaterno] nvarchar(max)  NOT NULL,
    [CorreoPersonal] nvarchar(max)  NOT NULL,
    [CorreoInstitucional] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [EsTutor] nvarchar(max)  NOT NULL,
    [EsCoordinador] nvarchar(max)  NOT NULL,
    [EsJefeCarrera] bit  NULL,
    [ExperienciaEducativa_Id] int  NULL
);
GO

-- Creating table 'ExperienciaEducativa'
CREATE TABLE [dbo].[ExperienciaEducativa] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nrc] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [ProgramaEducativo_Id] int  NOT NULL
);
GO

-- Creating table 'ProblematicaAcademica'
CREATE TABLE [dbo].[ProblematicaAcademica] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [NumeroIncidencias] smallint  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [ExperienciaEducativa_Id] int  NOT NULL,
    [TutoriasAcademicas_Id] int  NOT NULL
);
GO

-- Creating table 'ComentariosProblematicas'
CREATE TABLE [dbo].[ComentariosProblematicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ProblematicaAcademica_Id] int  NOT NULL
);
GO

-- Creating table 'TutoriasAcademicas'
CREATE TABLE [dbo].[TutoriasAcademicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroDeSesion] smallint  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaTermino] datetime  NOT NULL,
    [FechaEntrega] datetime  NOT NULL,
    [PeriodoEscolar_Id] int  NOT NULL
);
GO

-- Creating table 'PeriodoEscolar'
CREATE TABLE [dbo].[PeriodoEscolar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaTermino] datetime  NOT NULL
);
GO

-- Creating table 'Asistencia'
CREATE TABLE [dbo].[Asistencia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Presente] bit  NOT NULL,
    [TutoriasAcademicas_Id] int  NOT NULL
);
GO

-- Creating table 'ProgramaEducativo'
CREATE TABLE [dbo].[ProgramaEducativo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [PeriodoEscolar_Id] int  NOT NULL
);
GO

-- Creating table 'Administrador'
CREATE TABLE [dbo].[Administrador] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AsistenciaEstudiante'
CREATE TABLE [dbo].[AsistenciaEstudiante] (
    [Asistencia_Id] int  NOT NULL,
    [Estudiante_Id] int  NOT NULL
);
GO

-- Creating table 'ProgramaEducativoProfesor'
CREATE TABLE [dbo].[ProgramaEducativoProfesor] (
    [ProgramaEducativo_Id] int  NOT NULL,
    [Profesor_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Estudiante'
ALTER TABLE [dbo].[Estudiante]
ADD CONSTRAINT [PK_Estudiante]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Profesor'
ALTER TABLE [dbo].[Profesor]
ADD CONSTRAINT [PK_Profesor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExperienciaEducativa'
ALTER TABLE [dbo].[ExperienciaEducativa]
ADD CONSTRAINT [PK_ExperienciaEducativa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProblematicaAcademica'
ALTER TABLE [dbo].[ProblematicaAcademica]
ADD CONSTRAINT [PK_ProblematicaAcademica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentariosProblematicas'
ALTER TABLE [dbo].[ComentariosProblematicas]
ADD CONSTRAINT [PK_ComentariosProblematicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TutoriasAcademicas'
ALTER TABLE [dbo].[TutoriasAcademicas]
ADD CONSTRAINT [PK_TutoriasAcademicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodoEscolar'
ALTER TABLE [dbo].[PeriodoEscolar]
ADD CONSTRAINT [PK_PeriodoEscolar]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Asistencia'
ALTER TABLE [dbo].[Asistencia]
ADD CONSTRAINT [PK_Asistencia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgramaEducativo'
ALTER TABLE [dbo].[ProgramaEducativo]
ADD CONSTRAINT [PK_ProgramaEducativo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Administrador'
ALTER TABLE [dbo].[Administrador]
ADD CONSTRAINT [PK_Administrador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Asistencia_Id], [Estudiante_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [PK_AsistenciaEstudiante]
    PRIMARY KEY CLUSTERED ([Asistencia_Id], [Estudiante_Id] ASC);
GO

-- Creating primary key on [ProgramaEducativo_Id], [Profesor_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [PK_ProgramaEducativoProfesor]
    PRIMARY KEY CLUSTERED ([ProgramaEducativo_Id], [Profesor_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PeriodoEscolar_Id] in table 'TutoriasAcademicas'
ALTER TABLE [dbo].[TutoriasAcademicas]
ADD CONSTRAINT [FK_TutoriasAcademicasPeriodoEscolar]
    FOREIGN KEY ([PeriodoEscolar_Id])
    REFERENCES [dbo].[PeriodoEscolar]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasPeriodoEscolar'
CREATE INDEX [IX_FK_TutoriasAcademicasPeriodoEscolar]
ON [dbo].[TutoriasAcademicas]
    ([PeriodoEscolar_Id]);
GO

-- Creating foreign key on [ProblematicaAcademica_Id] in table 'ComentariosProblematicas'
ALTER TABLE [dbo].[ComentariosProblematicas]
ADD CONSTRAINT [FK_ProblematicaAcademicaComentariosProblematicas]
    FOREIGN KEY ([ProblematicaAcademica_Id])
    REFERENCES [dbo].[ProblematicaAcademica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblematicaAcademicaComentariosProblematicas'
CREATE INDEX [IX_FK_ProblematicaAcademicaComentariosProblematicas]
ON [dbo].[ComentariosProblematicas]
    ([ProblematicaAcademica_Id]);
GO

-- Creating foreign key on [ExperienciaEducativa_Id] in table 'ProblematicaAcademica'
ALTER TABLE [dbo].[ProblematicaAcademica]
ADD CONSTRAINT [FK_ProblematicaAcademicaExperienciaEducativa]
    FOREIGN KEY ([ExperienciaEducativa_Id])
    REFERENCES [dbo].[ExperienciaEducativa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblematicaAcademicaExperienciaEducativa'
CREATE INDEX [IX_FK_ProblematicaAcademicaExperienciaEducativa]
ON [dbo].[ProblematicaAcademica]
    ([ExperienciaEducativa_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'Estudiante'
ALTER TABLE [dbo].[Estudiante]
ADD CONSTRAINT [FK_ProgramaEducativoEstudiante]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoEstudiante'
CREATE INDEX [IX_FK_ProgramaEducativoEstudiante]
ON [dbo].[Estudiante]
    ([ProgramaEducativo_Id]);
GO

-- Creating foreign key on [TutoriasAcademicas_Id] in table 'ProblematicaAcademica'
ALTER TABLE [dbo].[ProblematicaAcademica]
ADD CONSTRAINT [FK_TutoriasAcademicasProblematicaAcademica]
    FOREIGN KEY ([TutoriasAcademicas_Id])
    REFERENCES [dbo].[TutoriasAcademicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasProblematicaAcademica'
CREATE INDEX [IX_FK_TutoriasAcademicasProblematicaAcademica]
ON [dbo].[ProblematicaAcademica]
    ([TutoriasAcademicas_Id]);
GO

-- Creating foreign key on [PeriodoEscolar_Id] in table 'ProgramaEducativo'
ALTER TABLE [dbo].[ProgramaEducativo]
ADD CONSTRAINT [FK_PeriodoEscolarProgramaEducativo]
    FOREIGN KEY ([PeriodoEscolar_Id])
    REFERENCES [dbo].[PeriodoEscolar]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoEscolarProgramaEducativo'
CREATE INDEX [IX_FK_PeriodoEscolarProgramaEducativo]
ON [dbo].[ProgramaEducativo]
    ([PeriodoEscolar_Id]);
GO

-- Creating foreign key on [TutoriasAcademicas_Id] in table 'Asistencia'
ALTER TABLE [dbo].[Asistencia]
ADD CONSTRAINT [FK_TutoriasAcademicasAsistencia]
    FOREIGN KEY ([TutoriasAcademicas_Id])
    REFERENCES [dbo].[TutoriasAcademicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasAsistencia'
CREATE INDEX [IX_FK_TutoriasAcademicasAsistencia]
ON [dbo].[Asistencia]
    ([TutoriasAcademicas_Id]);
GO

-- Creating foreign key on [Tutor_Id] in table 'Estudiante'
ALTER TABLE [dbo].[Estudiante]
ADD CONSTRAINT [FK_ProfesorEstudiante]
    FOREIGN KEY ([Tutor_Id])
    REFERENCES [dbo].[Profesor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesorEstudiante'
CREATE INDEX [IX_FK_ProfesorEstudiante]
ON [dbo].[Estudiante]
    ([Tutor_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'ExperienciaEducativa'
ALTER TABLE [dbo].[ExperienciaEducativa]
ADD CONSTRAINT [FK_ProgramaEducativoExperienciaEducativa]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoExperienciaEducativa'
CREATE INDEX [IX_FK_ProgramaEducativoExperienciaEducativa]
ON [dbo].[ExperienciaEducativa]
    ([ProgramaEducativo_Id]);
GO

-- Creating foreign key on [Asistencia_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [FK_AsistenciaEstudiante_Asistencia]
    FOREIGN KEY ([Asistencia_Id])
    REFERENCES [dbo].[Asistencia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Estudiante_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [FK_AsistenciaEstudiante_Estudiante]
    FOREIGN KEY ([Estudiante_Id])
    REFERENCES [dbo].[Estudiante]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistenciaEstudiante_Estudiante'
CREATE INDEX [IX_FK_AsistenciaEstudiante_Estudiante]
ON [dbo].[AsistenciaEstudiante]
    ([Estudiante_Id]);
GO

-- Creating foreign key on [ExperienciaEducativa_Id] in table 'Profesor'
ALTER TABLE [dbo].[Profesor]
ADD CONSTRAINT [FK_ExperienciaEducativaProfesor]
    FOREIGN KEY ([ExperienciaEducativa_Id])
    REFERENCES [dbo].[ExperienciaEducativa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienciaEducativaProfesor'
CREATE INDEX [IX_FK_ExperienciaEducativaProfesor]
ON [dbo].[Profesor]
    ([ExperienciaEducativa_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [FK_ProgramaEducativoProfesor_ProgramaEducativo]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Profesor_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [FK_ProgramaEducativoProfesor_Profesor]
    FOREIGN KEY ([Profesor_Id])
    REFERENCES [dbo].[Profesor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoProfesor_Profesor'
CREATE INDEX [IX_FK_ProgramaEducativoProfesor_Profesor]
ON [dbo].[ProgramaEducativoProfesor]
    ([Profesor_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------