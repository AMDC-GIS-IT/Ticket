using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
               setupDB = 0;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateEtapasDesarrollo( )
      {
         string cmdBuffer = "";
         /* Indices for table EtapasDesarrollo */
         try
         {
            cmdBuffer=" CREATE TABLE [EtapasDesarrollo] ([EtapaDesarrolloId] smallint NOT NULL IDENTITY(1,1), [EtapaDesarrolloNombre] nvarchar(30) NOT NULL , [EtapaDesarrolloUsuarioRegistro] nvarchar(100) NOT NULL , PRIMARY KEY([EtapaDesarrolloId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EtapasDesarrollo]") ;
               cmdBuffer=" DROP TABLE [EtapasDesarrollo] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EtapasDesarrollo]") ;
                  cmdBuffer=" DROP VIEW [EtapasDesarrollo] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EtapasDesarrollo]") ;
                     cmdBuffer=" DROP FUNCTION [EtapasDesarrollo] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EtapasDesarrollo] ([EtapaDesarrolloId] smallint NOT NULL IDENTITY(1,1), [EtapaDesarrolloNombre] nvarchar(30) NOT NULL , [EtapaDesarrolloUsuarioRegistro] nvarchar(100) NOT NULL , PRIMARY KEY([EtapaDesarrolloId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateGXChatUser( )
      {
         string cmdBuffer = "";
         /* Indices for table GXChatUser */
         try
         {
            cmdBuffer=" CREATE TABLE [GXChatUser] ([GXChatUserId] uniqueidentifier NOT NULL CONSTRAINT GXChatUserIdGXChatUser_DEFAULT DEFAULT NEWID(), [GXChatUserDevice] nvarchar(256) NOT NULL , PRIMARY KEY([GXChatUserId], [GXChatUserDevice]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[GXChatUser]") ;
               cmdBuffer=" DROP TABLE [GXChatUser] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[GXChatUser]") ;
                  cmdBuffer=" DROP VIEW [GXChatUser] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[GXChatUser]") ;
                     cmdBuffer=" DROP FUNCTION [GXChatUser] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [GXChatUser] ([GXChatUserId] uniqueidentifier NOT NULL CONSTRAINT GXChatUserIdGXChatUser_DEFAULT DEFAULT NEWID(), [GXChatUserDevice] nvarchar(256) NOT NULL , PRIMARY KEY([GXChatUserId], [GXChatUserDevice]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateGXChatMessage( )
      {
         string cmdBuffer = "";
         /* Indices for table GXChatMessage */
         try
         {
            cmdBuffer=" CREATE TABLE [GXChatMessage] ([GXChatMessageId] uniqueidentifier NOT NULL ROWGUIDCOL CONSTRAINT GXChatMessageIdGXChatMessage_DEFAULT DEFAULT NEWID(), [GXChatUserId] uniqueidentifier NOT NULL , [GXChatMessageMessage] NVARCHAR(MAX) NOT NULL , [GXChatMessageType] nchar(2) NOT NULL , [GXChatMessageImage] VARBINARY(MAX) NULL , [GXChatMessageImage_GXI] varchar(2048) NULL , [GXChatMessageDate] datetime2(3) NOT NULL , [GXChatMessageMeta] NVARCHAR(MAX) NOT NULL , [GXChatUserDevice] nvarchar(256) NOT NULL , [GXChatMessageRepeat] nvarchar(256) NOT NULL , [GXChatMessageInstance] nvarchar(256) NOT NULL , PRIMARY KEY([GXChatMessageId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[GXChatMessage]") ;
               cmdBuffer=" DROP TABLE [GXChatMessage] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[GXChatMessage]") ;
                  cmdBuffer=" DROP VIEW [GXChatMessage] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[GXChatMessage]") ;
                     cmdBuffer=" DROP FUNCTION [GXChatMessage] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [GXChatMessage] ([GXChatMessageId] uniqueidentifier NOT NULL ROWGUIDCOL CONSTRAINT GXChatMessageIdGXChatMessage_DEFAULT DEFAULT NEWID(), [GXChatUserId] uniqueidentifier NOT NULL , [GXChatMessageMessage] NVARCHAR(MAX) NOT NULL , [GXChatMessageType] nchar(2) NOT NULL , [GXChatMessageImage] VARBINARY(MAX) NULL , [GXChatMessageImage_GXI] varchar(2048) NULL , [GXChatMessageDate] datetime2(3) NOT NULL , [GXChatMessageMeta] NVARCHAR(MAX) NOT NULL , [GXChatUserDevice] nvarchar(256) NOT NULL , [GXChatMessageRepeat] nvarchar(256) NOT NULL , [GXChatMessageInstance] nvarchar(256) NOT NULL , PRIMARY KEY([GXChatMessageId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IGXCHATMESSAGE1] ON [GXChatMessage] ([GXChatUserId] ,[GXChatUserDevice] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IGXCHATMESSAGE1] ON [GXChatMessage] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IGXCHATMESSAGE1] ON [GXChatMessage] ([GXChatUserId] ,[GXChatUserDevice] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UGXCHATMESSAGE] ON [GXChatMessage] ([GXChatMessageDate] DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UGXCHATMESSAGE] ON [GXChatMessage] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UGXCHATMESSAGE] ON [GXChatMessage] ([GXChatMessageDate] DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAtencionSoporteTecnico( )
      {
         string cmdBuffer = "";
         /* Indices for table AtencionSoporteTecnico */
         try
         {
            cmdBuffer=" CREATE TABLE [AtencionSoporteTecnico] ([SoporteTecnicoId] decimal( 10) NOT NULL IDENTITY(1,1), [SoporteTecnicoFecha] datetime NOT NULL , [SoporteTecnicoHora] datetime NOT NULL , [TicketId] decimal( 10) NOT NULL , [SoporteTecnicoInventarioSerie] nvarchar(300) NULL , [SoporteTecnicoInstalacion] BIT NULL , [SoporteTecnicoConfiguracion] BIT NULL , [SoporteTecnicoInternetRouter] BIT NULL , [SoporteTecnicoFormateo] BIT NULL , [SoporteTecnicoReparacion] BIT NULL , [SoporteTecnicoFechaResuelve] datetime NULL , [SoporteTecnicoHoraResuelve] datetime NULL , [SoporteTecnicoLimpieza] BIT NULL , [SoporteTecnicoPuntoRed] BIT NULL , [SoporteTecnicoCambiosHardware] BIT NULL , [SoporteTecnicoCopiasRespaldo] BIT NULL , [SoporteTecnicoRam] nvarchar(60) NULL , [SoporteTecnicoDiscoDuro] nvarchar(60) NULL , [SoporteTecnicoProcesador] nvarchar(60) NULL , [SoporteTecnicoMaletin] nvarchar(60) NULL , [SoporteTecnicoTonerCinta] nvarchar(60) NULL , [SoporteTecnicoTarjetaVideoExtra] nvarchar(60) NULL , [SoporteTecnicoCargadorLaptop] nvarchar(60) NULL , [SoporteTecnicoCDsDVDs] nvarchar(60) NULL , [SoporteTecnicoCableEspecial] nvarchar(60) NULL , [SoporteTecnicoOtrosTaller] nvarchar(60) NULL , [SoporteTecnicoObservacion] nvarchar(300) NULL , [SoporteTecnicoCerrado] BIT NOT NULL , [SoporteTecnicoPendiente] BIT NOT NULL , [SoporteTecnicoPasaTaller] BIT NOT NULL , PRIMARY KEY([SoporteTecnicoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[AtencionSoporteTecnico]") ;
               cmdBuffer=" DROP TABLE [AtencionSoporteTecnico] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[AtencionSoporteTecnico]") ;
                  cmdBuffer=" DROP VIEW [AtencionSoporteTecnico] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[AtencionSoporteTecnico]") ;
                     cmdBuffer=" DROP FUNCTION [AtencionSoporteTecnico] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [AtencionSoporteTecnico] ([SoporteTecnicoId] decimal( 10) NOT NULL IDENTITY(1,1), [SoporteTecnicoFecha] datetime NOT NULL , [SoporteTecnicoHora] datetime NOT NULL , [TicketId] decimal( 10) NOT NULL , [SoporteTecnicoInventarioSerie] nvarchar(300) NULL , [SoporteTecnicoInstalacion] BIT NULL , [SoporteTecnicoConfiguracion] BIT NULL , [SoporteTecnicoInternetRouter] BIT NULL , [SoporteTecnicoFormateo] BIT NULL , [SoporteTecnicoReparacion] BIT NULL , [SoporteTecnicoFechaResuelve] datetime NULL , [SoporteTecnicoHoraResuelve] datetime NULL , [SoporteTecnicoLimpieza] BIT NULL , [SoporteTecnicoPuntoRed] BIT NULL , [SoporteTecnicoCambiosHardware] BIT NULL , [SoporteTecnicoCopiasRespaldo] BIT NULL , [SoporteTecnicoRam] nvarchar(60) NULL , [SoporteTecnicoDiscoDuro] nvarchar(60) NULL , [SoporteTecnicoProcesador] nvarchar(60) NULL , [SoporteTecnicoMaletin] nvarchar(60) NULL , [SoporteTecnicoTonerCinta] nvarchar(60) NULL , [SoporteTecnicoTarjetaVideoExtra] nvarchar(60) NULL , [SoporteTecnicoCargadorLaptop] nvarchar(60) NULL , [SoporteTecnicoCDsDVDs] nvarchar(60) NULL , [SoporteTecnicoCableEspecial] nvarchar(60) NULL , [SoporteTecnicoOtrosTaller] nvarchar(60) NULL , [SoporteTecnicoObservacion] nvarchar(300) NULL , [SoporteTecnicoCerrado] BIT NOT NULL , [SoporteTecnicoPendiente] BIT NOT NULL , [SoporteTecnicoPasaTaller] BIT NOT NULL , PRIMARY KEY([SoporteTecnicoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISOPORTETECNICO1] ON [AtencionSoporteTecnico] ([TicketId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISOPORTETECNICO1] ON [AtencionSoporteTecnico] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISOPORTETECNICO1] ON [AtencionSoporteTecnico] ([TicketId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstadoTecnicos( )
      {
         string cmdBuffer = "";
         /* Indices for table EstadoTecnicos */
         try
         {
            cmdBuffer=" CREATE TABLE [EstadoTecnicos] ([EstadoTecnicosId] smallint NOT NULL IDENTITY(1,1), [EstadoTecnicosNombre] nvarchar(30) NOT NULL , PRIMARY KEY([EstadoTecnicosId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EstadoTecnicos]") ;
               cmdBuffer=" DROP TABLE [EstadoTecnicos] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EstadoTecnicos]") ;
                  cmdBuffer=" DROP VIEW [EstadoTecnicos] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EstadoTecnicos]") ;
                     cmdBuffer=" DROP FUNCTION [EstadoTecnicos] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EstadoTecnicos] ([EstadoTecnicosId] smallint NOT NULL IDENTITY(1,1), [EstadoTecnicosNombre] nvarchar(30) NOT NULL , PRIMARY KEY([EstadoTecnicosId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUsuarioSistema( )
      {
         string cmdBuffer = "";
         /* Indices for table UsuarioSistema */
         try
         {
            cmdBuffer=" CREATE TABLE [UsuarioSistema] ([UsuarioSistemaId] nvarchar(100) NOT NULL , [UsuarioSistemaNombre] nvarchar(60) NOT NULL , [UsuarioSistemaIdentidad] nvarchar(30) NOT NULL , [UsuarioSistemaDepartamento] nvarchar(300) NULL , [UsuarioSistemaGerencia] nvarchar(300) NULL , [DireccionId] smallint NOT NULL , [CentrodecostoId] nvarchar(5) NOT NULL , [DepartamentoId] smallint NOT NULL , [UsuarioSistemaTelefono] int NOT NULL , [UsuarioSistemaEmail] nvarchar(100) NOT NULL , [UsuarioSistemaFecha] datetime NOT NULL , PRIMARY KEY([UsuarioSistemaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[UsuarioSistema]") ;
               cmdBuffer=" DROP TABLE [UsuarioSistema] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[UsuarioSistema]") ;
                  cmdBuffer=" DROP VIEW [UsuarioSistema] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[UsuarioSistema]") ;
                     cmdBuffer=" DROP FUNCTION [UsuarioSistema] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [UsuarioSistema] ([UsuarioSistemaId] nvarchar(100) NOT NULL , [UsuarioSistemaNombre] nvarchar(60) NOT NULL , [UsuarioSistemaIdentidad] nvarchar(30) NOT NULL , [UsuarioSistemaDepartamento] nvarchar(300) NULL , [UsuarioSistemaGerencia] nvarchar(300) NULL , [DireccionId] smallint NOT NULL , [CentrodecostoId] nvarchar(5) NOT NULL , [DepartamentoId] smallint NOT NULL , [UsuarioSistemaTelefono] int NOT NULL , [UsuarioSistemaEmail] nvarchar(100) NOT NULL , [UsuarioSistemaFecha] datetime NOT NULL , PRIMARY KEY([UsuarioSistemaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOSISTEMA1] ON [UsuarioSistema] ([CentrodecostoId] ,[DepartamentoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IUSUARIOSISTEMA1] ON [UsuarioSistema] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOSISTEMA1] ON [UsuarioSistema] ([CentrodecostoId] ,[DepartamentoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOSISTEMA2] ON [UsuarioSistema] ([DireccionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IUSUARIOSISTEMA2] ON [UsuarioSistema] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOSISTEMA2] ON [UsuarioSistema] ([DireccionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUsuario( )
      {
         string cmdBuffer = "";
         /* Indices for table Usuario */
         try
         {
            cmdBuffer=" CREATE TABLE [Usuario] ([UsuarioId] smallint NOT NULL IDENTITY(1,1), [UsuarioNombre] nvarchar(60) NOT NULL , [UsuarioFecha] datetime NOT NULL , [UsuarioHora] datetime NOT NULL , [UsuarioGerencia] nvarchar(300) NOT NULL , [UsuarioDepartamento] nvarchar(300) NOT NULL , [UsuarioRequerimiento] nvarchar(300) NOT NULL , [UsuarioEmail] nvarchar(100) NOT NULL , [UsuarioTelefono] int NOT NULL , [EstadoTicketUsuarioId] smallint NOT NULL , [UsuarioSistema] nvarchar(100) NOT NULL , [UsuarioFechaHora] datetime NULL , PRIMARY KEY([UsuarioId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Usuario]") ;
               cmdBuffer=" DROP TABLE [Usuario] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Usuario]") ;
                  cmdBuffer=" DROP VIEW [Usuario] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Usuario]") ;
                     cmdBuffer=" DROP FUNCTION [Usuario] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Usuario] ([UsuarioId] smallint NOT NULL IDENTITY(1,1), [UsuarioNombre] nvarchar(60) NOT NULL , [UsuarioFecha] datetime NOT NULL , [UsuarioHora] datetime NOT NULL , [UsuarioGerencia] nvarchar(300) NOT NULL , [UsuarioDepartamento] nvarchar(300) NOT NULL , [UsuarioRequerimiento] nvarchar(300) NOT NULL , [UsuarioEmail] nvarchar(100) NOT NULL , [UsuarioTelefono] int NOT NULL , [EstadoTicketUsuarioId] smallint NOT NULL , [UsuarioSistema] nvarchar(100) NOT NULL , [UsuarioFechaHora] datetime NULL , PRIMARY KEY([UsuarioId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIO2] ON [Usuario] ([EstadoTicketUsuarioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IUSUARIO2] ON [Usuario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIO2] ON [Usuario] ([EstadoTicketUsuarioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTicketTecnico( )
      {
         string cmdBuffer = "";
         /* Indices for table TicketTecnico */
         try
         {
            cmdBuffer=" CREATE TABLE [TicketTecnico] ([TicketTecnicoId] decimal( 10) NOT NULL IDENTITY(1,1), [TicketTecnicoFecha] datetime NOT NULL , [TicketTecnicoHora] datetime NOT NULL , [TicketId] decimal( 10) NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketTecnicoInventarioSerie] nvarchar(300) NOT NULL , [TicketTecnicoInstalacion] BIT NOT NULL , [TicketTecnicoConfiguracion] BIT NOT NULL , [TicketTecnicoInternetRouter] BIT NOT NULL , [TicketTecnicoFormateo] BIT NOT NULL , [TicketTecnicoReparacion] BIT NOT NULL , [TicketTecnicoLimpieza] BIT NOT NULL , [TicketTecnicoPuntoRed] BIT NOT NULL , [TicketTecnicoCambiosHardware] BIT NOT NULL , [TicketTecnicoCopiasRespaldo] BIT NOT NULL , [TicketTecnicoRam] BIT NOT NULL , [TicketTecnicoDiscoDuro] BIT NOT NULL , [TicketTecnicoProcesador] BIT NOT NULL , [TicketTecnicoMaletin] BIT NOT NULL , [TicketTecnicoTonerCinta] BIT NOT NULL , [TicketTecnicoTarjetaVideoExtra] BIT NOT NULL , [TicketTecnicoCargadorLaptop] BIT NOT NULL , [TicketTecnicoCDsDVDs] BIT NOT NULL , [TicketTecnicoCableEspecial] BIT NOT NULL , [TicketTecnicoOtrosTaller] BIT NOT NULL , [TicketTecnicoCerrado] BIT NOT NULL , [TicketTecnicoPendiente] BIT NOT NULL , [TicketTecnicoPasaTaller] BIT NOT NULL , [TicketTecnicoObservacion] BIT NULL , [TicketTecnicoDetalle] nvarchar(300) NOT NULL , [SgActividadId] int NOT NULL , [SgActividadIdCategoria] int NOT NULL , [ResponsableId] smallint NOT NULL , PRIMARY KEY([TicketTecnicoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TicketTecnico]") ;
               cmdBuffer=" DROP TABLE [TicketTecnico] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TicketTecnico]") ;
                  cmdBuffer=" DROP VIEW [TicketTecnico] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TicketTecnico]") ;
                     cmdBuffer=" DROP FUNCTION [TicketTecnico] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [TicketTecnico] ([TicketTecnicoId] decimal( 10) NOT NULL IDENTITY(1,1), [TicketTecnicoFecha] datetime NOT NULL , [TicketTecnicoHora] datetime NOT NULL , [TicketId] decimal( 10) NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketTecnicoInventarioSerie] nvarchar(300) NOT NULL , [TicketTecnicoInstalacion] BIT NOT NULL , [TicketTecnicoConfiguracion] BIT NOT NULL , [TicketTecnicoInternetRouter] BIT NOT NULL , [TicketTecnicoFormateo] BIT NOT NULL , [TicketTecnicoReparacion] BIT NOT NULL , [TicketTecnicoLimpieza] BIT NOT NULL , [TicketTecnicoPuntoRed] BIT NOT NULL , [TicketTecnicoCambiosHardware] BIT NOT NULL , [TicketTecnicoCopiasRespaldo] BIT NOT NULL , [TicketTecnicoRam] BIT NOT NULL , [TicketTecnicoDiscoDuro] BIT NOT NULL , [TicketTecnicoProcesador] BIT NOT NULL , [TicketTecnicoMaletin] BIT NOT NULL , [TicketTecnicoTonerCinta] BIT NOT NULL , [TicketTecnicoTarjetaVideoExtra] BIT NOT NULL , [TicketTecnicoCargadorLaptop] BIT NOT NULL , [TicketTecnicoCDsDVDs] BIT NOT NULL , [TicketTecnicoCableEspecial] BIT NOT NULL , [TicketTecnicoOtrosTaller] BIT NOT NULL , [TicketTecnicoCerrado] BIT NOT NULL , [TicketTecnicoPendiente] BIT NOT NULL , [TicketTecnicoPasaTaller] BIT NOT NULL , [TicketTecnicoObservacion] BIT NULL , [TicketTecnicoDetalle] nvarchar(300) NOT NULL , [SgActividadId] int NOT NULL , [SgActividadIdCategoria] int NOT NULL , [ResponsableId] smallint NOT NULL , PRIMARY KEY([TicketTecnicoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO1] ON [TicketTecnico] ([TicketId] ,[TicketResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETTECNICO1] ON [TicketTecnico] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO1] ON [TicketTecnico] ([TicketId] ,[TicketResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO2] ON [TicketTecnico] ([SgActividadIdCategoria] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETTECNICO2] ON [TicketTecnico] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO2] ON [TicketTecnico] ([SgActividadIdCategoria] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO3] ON [TicketTecnico] ([SgActividadId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETTECNICO3] ON [TicketTecnico] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO3] ON [TicketTecnico] ([SgActividadId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO4] ON [TicketTecnico] ([ResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETTECNICO4] ON [TicketTecnico] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETTECNICO4] ON [TicketTecnico] ([ResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTicketResponsable( )
      {
         string cmdBuffer = "";
         /* Indices for table TicketResponsable */
         try
         {
            cmdBuffer=" CREATE TABLE [TicketResponsable] ([TicketId] decimal( 10) NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketFechaResponsable] datetime NOT NULL , [TicketHoraResponsable] datetime NOT NULL , [EstadoTicketTecnicoId] smallint NOT NULL , [TicketResponsableInventarioSerie] nvarchar(300) NULL , [TicketResponsableInstalacion] BIT NULL , [TicketResponsableConfiguracion] BIT NULL , [TicketResponsableInternetRouter] BIT NULL , [TicketResponsableFormateo] BIT NULL , [TicketResponsableReparacion] BIT NULL , [TicketResponsableLimpieza] BIT NULL , [TicketResponsablePuntoRed] BIT NULL , [TicketResponsableCambiosHardware] BIT NULL , [TicketResponsableCopiasRespaldo] BIT NULL , [TicketResponsableCerrado] BIT NULL , [TicketResponsablePendiente] BIT NULL , [TicketResponsablePasaTaller] BIT NULL , [TicketResponsableObservacion] nvarchar(300) NULL , [TicketResponsableFechaResuelve] datetime NULL , [TicketResponsableHoraResuelve] datetime NULL , [TicketResponsableRamTxt] nvarchar(60) NULL , [TicketResponsableDiscoDuroTxt] nvarchar(60) NULL , [TicketResponsableProcesadorTxt] nvarchar(60) NULL , [TicketResponsableMaletinTxt] nvarchar(60) NULL , [TicketResponsableTonerCintaTxt] nvarchar(60) NULL , [TicketResponsableTarjetaVideoExtraTxt] nvarchar(60) NULL , [TicketResponsableCargadorLaptopTxt] nvarchar(60) NULL , [TicketResponsableCDsDVDsTxt] nvarchar(60) NULL , [TicketResponsableCableEspecialTxt] nvarchar(60) NULL , [TicketResponsableOtrosTallerTxt] nvarchar(60) NULL , [TicketTecnicoResponsableId] smallint NOT NULL , [TicketResponsableFechaHoraAsigna] datetime NULL , [TicketResponsableFechaHoraResuelve] datetime NULL , [EtapaDesarrolloId] smallint NULL , PRIMARY KEY([TicketId], [TicketResponsableId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TicketResponsable]") ;
               cmdBuffer=" DROP TABLE [TicketResponsable] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TicketResponsable]") ;
                  cmdBuffer=" DROP VIEW [TicketResponsable] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TicketResponsable]") ;
                     cmdBuffer=" DROP FUNCTION [TicketResponsable] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [TicketResponsable] ([TicketId] decimal( 10) NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketFechaResponsable] datetime NOT NULL , [TicketHoraResponsable] datetime NOT NULL , [EstadoTicketTecnicoId] smallint NOT NULL , [TicketResponsableInventarioSerie] nvarchar(300) NULL , [TicketResponsableInstalacion] BIT NULL , [TicketResponsableConfiguracion] BIT NULL , [TicketResponsableInternetRouter] BIT NULL , [TicketResponsableFormateo] BIT NULL , [TicketResponsableReparacion] BIT NULL , [TicketResponsableLimpieza] BIT NULL , [TicketResponsablePuntoRed] BIT NULL , [TicketResponsableCambiosHardware] BIT NULL , [TicketResponsableCopiasRespaldo] BIT NULL , [TicketResponsableCerrado] BIT NULL , [TicketResponsablePendiente] BIT NULL , [TicketResponsablePasaTaller] BIT NULL , [TicketResponsableObservacion] nvarchar(300) NULL , [TicketResponsableFechaResuelve] datetime NULL , [TicketResponsableHoraResuelve] datetime NULL , [TicketResponsableRamTxt] nvarchar(60) NULL , [TicketResponsableDiscoDuroTxt] nvarchar(60) NULL , [TicketResponsableProcesadorTxt] nvarchar(60) NULL , [TicketResponsableMaletinTxt] nvarchar(60) NULL , [TicketResponsableTonerCintaTxt] nvarchar(60) NULL , [TicketResponsableTarjetaVideoExtraTxt] nvarchar(60) NULL , [TicketResponsableCargadorLaptopTxt] nvarchar(60) NULL , [TicketResponsableCDsDVDsTxt] nvarchar(60) NULL , [TicketResponsableCableEspecialTxt] nvarchar(60) NULL , [TicketResponsableOtrosTallerTxt] nvarchar(60) NULL , [TicketTecnicoResponsableId] smallint NOT NULL , [TicketResponsableFechaHoraAsigna] datetime NULL , [TicketResponsableFechaHoraResuelve] datetime NULL , [EtapaDesarrolloId] smallint NULL , PRIMARY KEY([TicketId], [TicketResponsableId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE3] ON [TicketResponsable] ([EstadoTicketTecnicoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETRESPONSABLE3] ON [TicketResponsable] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE3] ON [TicketResponsable] ([EstadoTicketTecnicoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE4] ON [TicketResponsable] ([TicketTecnicoResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETRESPONSABLE4] ON [TicketResponsable] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE4] ON [TicketResponsable] ([TicketTecnicoResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE1] ON [TicketResponsable] ([EtapaDesarrolloId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKETRESPONSABLE1] ON [TicketResponsable] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKETRESPONSABLE1] ON [TicketResponsable] ([EtapaDesarrolloId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTicket( )
      {
         string cmdBuffer = "";
         /* Indices for table Ticket */
         try
         {
            cmdBuffer=" CREATE TABLE [Ticket] ([TicketId] decimal( 10) NOT NULL IDENTITY(1,1), [TicketFecha] datetime NOT NULL , [TicketHora] datetime NOT NULL , [UsuarioId] smallint NOT NULL , [TicketLastId] decimal( 10) NOT NULL , [TicketLaptop] BIT NOT NULL , [TicketDesktop] BIT NOT NULL , [TicketMonitor] BIT NOT NULL , [TicketImpresora] BIT NOT NULL , [TicketEscaner] BIT NOT NULL , [TicketRouter] BIT NOT NULL , [TicketSistemaOperativo] BIT NOT NULL , [TicketOffice] BIT NOT NULL , [TicketAntivirus] BIT NOT NULL , [TicketAplicacion] BIT NOT NULL , [TicketDisenio] BIT NOT NULL , [TicketIngenieria] BIT NOT NULL , [TicketDiscoDuroExterno] BIT NOT NULL , [TicketPerifericos] BIT NOT NULL , [TicketUps] BIT NOT NULL , [TicketApoyoUsuario] BIT NOT NULL , [TicketInstalarDataShow] BIT NOT NULL , [TicketOtros] BIT NOT NULL , [EstadoTicketTicketId] smallint NOT NULL , [TicketUsuarioAsigno] nvarchar(100) NOT NULL , [TicketHoraCaracter] nchar(8) NOT NULL , [TicketFechaHora] datetime NULL , PRIMARY KEY([TicketId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Ticket]") ;
               cmdBuffer=" DROP TABLE [Ticket] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Ticket]") ;
                  cmdBuffer=" DROP VIEW [Ticket] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Ticket]") ;
                     cmdBuffer=" DROP FUNCTION [Ticket] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Ticket] ([TicketId] decimal( 10) NOT NULL IDENTITY(1,1), [TicketFecha] datetime NOT NULL , [TicketHora] datetime NOT NULL , [UsuarioId] smallint NOT NULL , [TicketLastId] decimal( 10) NOT NULL , [TicketLaptop] BIT NOT NULL , [TicketDesktop] BIT NOT NULL , [TicketMonitor] BIT NOT NULL , [TicketImpresora] BIT NOT NULL , [TicketEscaner] BIT NOT NULL , [TicketRouter] BIT NOT NULL , [TicketSistemaOperativo] BIT NOT NULL , [TicketOffice] BIT NOT NULL , [TicketAntivirus] BIT NOT NULL , [TicketAplicacion] BIT NOT NULL , [TicketDisenio] BIT NOT NULL , [TicketIngenieria] BIT NOT NULL , [TicketDiscoDuroExterno] BIT NOT NULL , [TicketPerifericos] BIT NOT NULL , [TicketUps] BIT NOT NULL , [TicketApoyoUsuario] BIT NOT NULL , [TicketInstalarDataShow] BIT NOT NULL , [TicketOtros] BIT NOT NULL , [EstadoTicketTicketId] smallint NOT NULL , [TicketUsuarioAsigno] nvarchar(100) NOT NULL , [TicketHoraCaracter] nchar(8) NOT NULL , [TicketFechaHora] datetime NULL , PRIMARY KEY([TicketId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKET1] ON [Ticket] ([UsuarioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKET1] ON [Ticket] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKET1] ON [Ticket] ([UsuarioId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKET2] ON [Ticket] ([EstadoTicketTicketId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITICKET2] ON [Ticket] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITICKET2] ON [Ticket] ([EstadoTicketTicketId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSatisfaccion( )
      {
         string cmdBuffer = "";
         /* Indices for table Satisfaccion */
         try
         {
            cmdBuffer=" CREATE TABLE [Satisfaccion] ([SatisfaccionId] decimal( 10) NOT NULL IDENTITY(1,1), [SatisfaccionFecha] datetime NOT NULL , [SatisfaccionResueltoId] smallint NOT NULL , [SatisfaccionTecnicoProblemaId] smallint NOT NULL , [SatisfaccionTecnicoCompetenteId] smallint NOT NULL , [SatisfaccionTecnicoProfesionalismoId] smallint NOT NULL , [SatisfaccionTiempoId] smallint NOT NULL , [SatisfaccionAtencionId] smallint NOT NULL , [SatisfaccionSugerencia] nvarchar(300) NOT NULL , [SatisfaccionHora] datetime NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketId] decimal( 10) NOT NULL , PRIMARY KEY([SatisfaccionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Satisfaccion]") ;
               cmdBuffer=" DROP TABLE [Satisfaccion] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Satisfaccion]") ;
                  cmdBuffer=" DROP VIEW [Satisfaccion] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Satisfaccion]") ;
                     cmdBuffer=" DROP FUNCTION [Satisfaccion] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Satisfaccion] ([SatisfaccionId] decimal( 10) NOT NULL IDENTITY(1,1), [SatisfaccionFecha] datetime NOT NULL , [SatisfaccionResueltoId] smallint NOT NULL , [SatisfaccionTecnicoProblemaId] smallint NOT NULL , [SatisfaccionTecnicoCompetenteId] smallint NOT NULL , [SatisfaccionTecnicoProfesionalismoId] smallint NOT NULL , [SatisfaccionTiempoId] smallint NOT NULL , [SatisfaccionAtencionId] smallint NOT NULL , [SatisfaccionSugerencia] nvarchar(300) NOT NULL , [SatisfaccionHora] datetime NOT NULL , [TicketResponsableId] decimal( 10) NOT NULL , [TicketId] decimal( 10) NOT NULL , PRIMARY KEY([SatisfaccionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION6] ON [Satisfaccion] ([SatisfaccionAtencionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION6] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION6] ON [Satisfaccion] ([SatisfaccionAtencionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION1] ON [Satisfaccion] ([SatisfaccionResueltoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION1] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION1] ON [Satisfaccion] ([SatisfaccionResueltoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION3] ON [Satisfaccion] ([SatisfaccionTecnicoCompetenteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION3] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION3] ON [Satisfaccion] ([SatisfaccionTecnicoCompetenteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION2] ON [Satisfaccion] ([SatisfaccionTecnicoProblemaId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION2] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION2] ON [Satisfaccion] ([SatisfaccionTecnicoProblemaId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION4] ON [Satisfaccion] ([SatisfaccionTecnicoProfesionalismoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION4] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION4] ON [Satisfaccion] ([SatisfaccionTecnicoProfesionalismoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION5] ON [Satisfaccion] ([SatisfaccionTiempoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION5] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION5] ON [Satisfaccion] ([SatisfaccionTiempoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION7] ON [Satisfaccion] ([TicketId] ,[TicketResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ISATISFACCION7] ON [Satisfaccion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ISATISFACCION7] ON [Satisfaccion] ([TicketId] ,[TicketResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResponsable( )
      {
         string cmdBuffer = "";
         /* Indices for table Responsable */
         try
         {
            cmdBuffer=" CREATE TABLE [Responsable] ([ResponsableId] smallint NOT NULL IDENTITY(1,1), [ResponsableIdentidad] nvarchar(30) NOT NULL , [ResponsableNombre] nvarchar(60) NOT NULL , [ResponsableCargo] nvarchar(300) NOT NULL , [ResponsableEmail] nvarchar(100) NOT NULL , [ResponsableActivo] BIT NOT NULL , [ResponsableUsuario] nvarchar(100) NOT NULL , [EstadoResponsableId] smallint NOT NULL , [id_unidad] int NOT NULL , PRIMARY KEY([ResponsableId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Responsable]") ;
               cmdBuffer=" DROP TABLE [Responsable] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Responsable]") ;
                  cmdBuffer=" DROP VIEW [Responsable] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Responsable]") ;
                     cmdBuffer=" DROP FUNCTION [Responsable] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Responsable] ([ResponsableId] smallint NOT NULL IDENTITY(1,1), [ResponsableIdentidad] nvarchar(30) NOT NULL , [ResponsableNombre] nvarchar(60) NOT NULL , [ResponsableCargo] nvarchar(300) NOT NULL , [ResponsableEmail] nvarchar(100) NOT NULL , [ResponsableActivo] BIT NOT NULL , [ResponsableUsuario] nvarchar(100) NOT NULL , [EstadoResponsableId] smallint NOT NULL , [id_unidad] int NOT NULL , PRIMARY KEY([ResponsableId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRESPONSABLE1] ON [Responsable] ([EstadoResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IRESPONSABLE1] ON [Responsable] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRESPONSABLE1] ON [Responsable] ([EstadoResponsableId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRESPONSABLE2] ON [Responsable] ([id_unidad] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IRESPONSABLE2] ON [Responsable] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRESPONSABLE2] ON [Responsable] ([id_unidad] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstadoTicket( )
      {
         string cmdBuffer = "";
         /* Indices for table EstadoTicket */
         try
         {
            cmdBuffer=" CREATE TABLE [EstadoTicket] ([EstadoTicketId] smallint NOT NULL IDENTITY(1,1), [EstadoTicketNombre] nvarchar(30) NOT NULL , [EstadoTicketEstado] BIT NOT NULL , PRIMARY KEY([EstadoTicketId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EstadoTicket]") ;
               cmdBuffer=" DROP TABLE [EstadoTicket] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EstadoTicket]") ;
                  cmdBuffer=" DROP VIEW [EstadoTicket] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EstadoTicket]") ;
                     cmdBuffer=" DROP FUNCTION [EstadoTicket] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EstadoTicket] ([EstadoTicketId] smallint NOT NULL IDENTITY(1,1), [EstadoTicketNombre] nvarchar(30) NOT NULL , [EstadoTicketEstado] BIT NOT NULL , PRIMARY KEY([EstadoTicketId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstadoSatisfaccion( )
      {
         string cmdBuffer = "";
         /* Indices for table EstadoSatisfaccion */
         try
         {
            cmdBuffer=" CREATE TABLE [EstadoSatisfaccion] ([EstadoSatisfaccionId] smallint NOT NULL IDENTITY(1,1), [EstadoSatisfaccionNombre] nvarchar(30) NOT NULL , [EstadoSatisfaccionEstado] BIT NOT NULL , [EstadoSatisfaccionCalificacion] smallint NOT NULL , PRIMARY KEY([EstadoSatisfaccionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EstadoSatisfaccion]") ;
               cmdBuffer=" DROP TABLE [EstadoSatisfaccion] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EstadoSatisfaccion]") ;
                  cmdBuffer=" DROP VIEW [EstadoSatisfaccion] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EstadoSatisfaccion]") ;
                     cmdBuffer=" DROP FUNCTION [EstadoSatisfaccion] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EstadoSatisfaccion] ([EstadoSatisfaccionId] smallint NOT NULL IDENTITY(1,1), [EstadoSatisfaccionNombre] nvarchar(30) NOT NULL , [EstadoSatisfaccionEstado] BIT NOT NULL , [EstadoSatisfaccionCalificacion] smallint NOT NULL , PRIMARY KEY([EstadoSatisfaccionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstado( )
      {
         string cmdBuffer = "";
         /* Indices for table Estado */
         try
         {
            cmdBuffer=" CREATE TABLE [Estado] ([EstadoId] smallint NOT NULL IDENTITY(1,1), [EstadoNombre] nvarchar(30) NOT NULL , [EstadoActivo] BIT NOT NULL , [SgCategoriaId] int NOT NULL , [SgActividadId] int NOT NULL , PRIMARY KEY([EstadoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Estado]") ;
               cmdBuffer=" DROP TABLE [Estado] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Estado]") ;
                  cmdBuffer=" DROP VIEW [Estado] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Estado]") ;
                     cmdBuffer=" DROP FUNCTION [Estado] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Estado] ([EstadoId] smallint NOT NULL IDENTITY(1,1), [EstadoNombre] nvarchar(30) NOT NULL , [EstadoActivo] BIT NOT NULL , [SgCategoriaId] int NOT NULL , [SgActividadId] int NOT NULL , PRIMARY KEY([EstadoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESTADO1] ON [Estado] ([SgActividadId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IESTADO1] ON [Estado] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESTADO1] ON [Estado] ([SgActividadId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESTADO2] ON [Estado] ([SgCategoriaId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IESTADO2] ON [Estado] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESTADO2] ON [Estado] ([SgCategoriaId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResponsableEstadoTecnicos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Responsable] ADD CONSTRAINT [IRESPONSABLE1] FOREIGN KEY ([EstadoResponsableId]) REFERENCES [EstadoTecnicos] ([EstadoTecnicosId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Responsable] DROP CONSTRAINT [IRESPONSABLE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Responsable] ADD CONSTRAINT [IRESPONSABLE1] FOREIGN KEY ([EstadoResponsableId]) REFERENCES [EstadoTecnicos] ([EstadoTecnicosId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionTicketResponsable( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION7] FOREIGN KEY ([TicketId], [TicketResponsableId]) REFERENCES [TicketResponsable] ([TicketId], [TicketResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION7] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION7] FOREIGN KEY ([TicketId], [TicketResponsableId]) REFERENCES [TicketResponsable] ([TicketId], [TicketResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION6] FOREIGN KEY ([SatisfaccionAtencionId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION6] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION6] FOREIGN KEY ([SatisfaccionAtencionId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION5] FOREIGN KEY ([SatisfaccionTiempoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION5] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION5] FOREIGN KEY ([SatisfaccionTiempoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion2( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION4] FOREIGN KEY ([SatisfaccionTecnicoProfesionalismoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION4] FOREIGN KEY ([SatisfaccionTecnicoProfesionalismoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion3( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION3] FOREIGN KEY ([SatisfaccionTecnicoCompetenteId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION3] FOREIGN KEY ([SatisfaccionTecnicoCompetenteId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion4( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION2] FOREIGN KEY ([SatisfaccionTecnicoProblemaId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION2] FOREIGN KEY ([SatisfaccionTecnicoProblemaId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISatisfaccionEstadoSatisfaccion5( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION1] FOREIGN KEY ([SatisfaccionResueltoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Satisfaccion] DROP CONSTRAINT [ISATISFACCION1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Satisfaccion] ADD CONSTRAINT [ISATISFACCION1] FOREIGN KEY ([SatisfaccionResueltoId]) REFERENCES [EstadoSatisfaccion] ([EstadoSatisfaccionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketUsuario( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ticket] ADD CONSTRAINT [ITICKET1] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([UsuarioId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ticket] DROP CONSTRAINT [ITICKET1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ticket] ADD CONSTRAINT [ITICKET1] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([UsuarioId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketEstadoTicket( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ticket] ADD CONSTRAINT [ITICKET2] FOREIGN KEY ([EstadoTicketTicketId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ticket] DROP CONSTRAINT [ITICKET2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ticket] ADD CONSTRAINT [ITICKET2] FOREIGN KEY ([EstadoTicketTicketId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketResponsableTicket( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE2] FOREIGN KEY ([TicketId]) REFERENCES [Ticket] ([TicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketResponsable] DROP CONSTRAINT [ITICKETRESPONSABLE2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE2] FOREIGN KEY ([TicketId]) REFERENCES [Ticket] ([TicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketResponsableEtapasDesarrollo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE1] FOREIGN KEY ([EtapaDesarrolloId]) REFERENCES [EtapasDesarrollo] ([EtapaDesarrolloId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketResponsable] DROP CONSTRAINT [ITICKETRESPONSABLE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE1] FOREIGN KEY ([EtapaDesarrolloId]) REFERENCES [EtapasDesarrollo] ([EtapaDesarrolloId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketResponsableEstadoTicket( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE3] FOREIGN KEY ([EstadoTicketTecnicoId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketResponsable] DROP CONSTRAINT [ITICKETRESPONSABLE3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE3] FOREIGN KEY ([EstadoTicketTecnicoId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketResponsableResponsable( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE4] FOREIGN KEY ([TicketTecnicoResponsableId]) REFERENCES [Responsable] ([ResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketResponsable] DROP CONSTRAINT [ITICKETRESPONSABLE4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketResponsable] ADD CONSTRAINT [ITICKETRESPONSABLE4] FOREIGN KEY ([TicketTecnicoResponsableId]) REFERENCES [Responsable] ([ResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketTecnicoTicketResponsable( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketTecnico] ADD CONSTRAINT [ITICKETTECNICO1] FOREIGN KEY ([TicketId], [TicketResponsableId]) REFERENCES [TicketResponsable] ([TicketId], [TicketResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketTecnico] DROP CONSTRAINT [ITICKETTECNICO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketTecnico] ADD CONSTRAINT [ITICKETTECNICO1] FOREIGN KEY ([TicketId], [TicketResponsableId]) REFERENCES [TicketResponsable] ([TicketId], [TicketResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITicketTecnicoResponsable( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TicketTecnico] ADD CONSTRAINT [ITICKETTECNICO4] FOREIGN KEY ([ResponsableId]) REFERENCES [Responsable] ([ResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TicketTecnico] DROP CONSTRAINT [ITICKETTECNICO4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TicketTecnico] ADD CONSTRAINT [ITICKETTECNICO4] FOREIGN KEY ([ResponsableId]) REFERENCES [Responsable] ([ResponsableId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIUsuarioEstadoTicket( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Usuario] ADD CONSTRAINT [IUSUARIO2] FOREIGN KEY ([EstadoTicketUsuarioId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Usuario] DROP CONSTRAINT [IUSUARIO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Usuario] ADD CONSTRAINT [IUSUARIO2] FOREIGN KEY ([EstadoTicketUsuarioId]) REFERENCES [EstadoTicket] ([EstadoTicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAtencionSoporteTecnicoTicket( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [AtencionSoporteTecnico] ADD CONSTRAINT [ISOPORTETECNICO1] FOREIGN KEY ([TicketId]) REFERENCES [Ticket] ([TicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [AtencionSoporteTecnico] DROP CONSTRAINT [ISOPORTETECNICO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [AtencionSoporteTecnico] ADD CONSTRAINT [ISOPORTETECNICO1] FOREIGN KEY ([TicketId]) REFERENCES [Ticket] ([TicketId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIGXChatMessageGXChatUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [GXChatMessage] ADD CONSTRAINT [IGXCHATMESSAGE1] FOREIGN KEY ([GXChatUserId], [GXChatUserDevice]) REFERENCES [GXChatUser] ([GXChatUserId], [GXChatUserDevice]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [GXChatMessage] DROP CONSTRAINT [IGXCHATMESSAGE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [GXChatMessage] ADD CONSTRAINT [IGXCHATMESSAGE1] FOREIGN KEY ([GXChatUserId], [GXChatUserDevice]) REFERENCES [GXChatUser] ([GXChatUserId], [GXChatUserDevice]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( tableexist("EtapasDesarrollo",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EtapasDesarrollo"}) ) ;
            return false ;
         }
         if ( tableexist("GXChatUser",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"GXChatUser"}) ) ;
            return false ;
         }
         if ( tableexist("GXChatMessage",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"GXChatMessage"}) ) ;
            return false ;
         }
         if ( tableexist("AtencionSoporteTecnico",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AtencionSoporteTecnico"}) ) ;
            return false ;
         }
         if ( tableexist("EstadoTecnicos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EstadoTecnicos"}) ) ;
            return false ;
         }
         if ( tableexist("UsuarioSistema",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"UsuarioSistema"}) ) ;
            return false ;
         }
         if ( tableexist("Usuario",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Usuario"}) ) ;
            return false ;
         }
         if ( tableexist("TicketTecnico",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TicketTecnico"}) ) ;
            return false ;
         }
         if ( tableexist("TicketResponsable",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TicketResponsable"}) ) ;
            return false ;
         }
         if ( tableexist("Ticket",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Ticket"}) ) ;
            return false ;
         }
         if ( tableexist("Satisfaccion",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Satisfaccion"}) ) ;
            return false ;
         }
         if ( tableexist("Responsable",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Responsable"}) ) ;
            return false ;
         }
         if ( tableexist("EstadoTicket",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EstadoTicket"}) ) ;
            return false ;
         }
         if ( tableexist("EstadoSatisfaccion",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EstadoSatisfaccion"}) ) ;
            return false ;
         }
         if ( tableexist("Estado",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Estado"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateEtapasDesarrollo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateGXChatUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateGXChatMessage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateAtencionSoporteTecnico" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateEstadoTecnicos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateUsuarioSistema" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateUsuario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateTicketTecnico" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateTicketResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateSatisfaccion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateEstadoTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateEstadoSatisfaccion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateEstado" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RIResponsableEstadoTecnicos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RISatisfaccionTicketResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RISatisfaccionEstadoSatisfaccion1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "RISatisfaccionEstadoSatisfaccion2" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "RISatisfaccionEstadoSatisfaccion3" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "RISatisfaccionEstadoSatisfaccion4" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "RISatisfaccionEstadoSatisfaccion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "RISatisfaccionEstadoSatisfaccion5" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "RITicketUsuario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "RITicketEstadoTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "RITicketResponsableTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "RITicketResponsableEtapasDesarrollo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "RITicketResponsableEstadoTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "RITicketResponsableResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "RITicketTecnicoTicketResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "RITicketTecnicoResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "RIUsuarioEstadoTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "RIAtencionSoporteTecnicoTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "RIGXChatMessageGXChatUser" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EtapasDesarrollo", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"GXChatUser", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"GXChatMessage", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateGXChatMessage" ,  "CreateGXChatUser" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AtencionSoporteTecnico", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAtencionSoporteTecnico" ,  "CreateTicket" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EstadoTecnicos", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"UsuarioSistema", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Usuario", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateUsuario" ,  "CreateEstadoTicket" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TicketTecnico", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTicketTecnico" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "CreateTicketTecnico" ,  "CreateResponsable" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TicketResponsable", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTicketResponsable" ,  "CreateTicket" );
         ReorgExecute.RegisterPrecedence( "CreateTicketResponsable" ,  "CreateEtapasDesarrollo" );
         ReorgExecute.RegisterPrecedence( "CreateTicketResponsable" ,  "CreateEstadoTicket" );
         ReorgExecute.RegisterPrecedence( "CreateTicketResponsable" ,  "CreateResponsable" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Ticket", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTicket" ,  "CreateUsuario" );
         ReorgExecute.RegisterPrecedence( "CreateTicket" ,  "CreateEstadoTicket" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Satisfaccion", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "CreateSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Responsable", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateResponsable" ,  "CreateEstadoTecnicos" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EstadoTicket", ""}) );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EstadoSatisfaccion", ""}) );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Estado", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IRESPONSABLE1]"}) );
         ReorgExecute.RegisterPrecedence( "RIResponsableEstadoTecnicos" ,  "CreateResponsable" );
         ReorgExecute.RegisterPrecedence( "RIResponsableEstadoTecnicos" ,  "CreateEstadoTecnicos" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION7]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionTicketResponsable" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionTicketResponsable" ,  "CreateTicketResponsable" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION5]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion1" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion1" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION4]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion2" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion2" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION3]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion3" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion3" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION2]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion4" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion4" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION6]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISATISFACCION1]"}) );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion5" ,  "CreateSatisfaccion" );
         ReorgExecute.RegisterPrecedence( "RISatisfaccionEstadoSatisfaccion5" ,  "CreateEstadoSatisfaccion" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKET1]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketUsuario" ,  "CreateTicket" );
         ReorgExecute.RegisterPrecedence( "RITicketUsuario" ,  "CreateUsuario" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKET2]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketEstadoTicket" ,  "CreateTicket" );
         ReorgExecute.RegisterPrecedence( "RITicketEstadoTicket" ,  "CreateEstadoTicket" );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETRESPONSABLE2]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableTicket" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableTicket" ,  "CreateTicket" );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETRESPONSABLE1]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableEtapasDesarrollo" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableEtapasDesarrollo" ,  "CreateEtapasDesarrollo" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETRESPONSABLE3]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableEstadoTicket" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableEstadoTicket" ,  "CreateEstadoTicket" );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETRESPONSABLE4]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableResponsable" ,  "CreateTicketResponsable" );
         ReorgExecute.RegisterPrecedence( "RITicketResponsableResponsable" ,  "CreateResponsable" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETTECNICO1]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketTecnicoTicketResponsable" ,  "CreateTicketTecnico" );
         ReorgExecute.RegisterPrecedence( "RITicketTecnicoTicketResponsable" ,  "CreateTicketResponsable" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITICKETTECNICO4]"}) );
         ReorgExecute.RegisterPrecedence( "RITicketTecnicoResponsable" ,  "CreateTicketTecnico" );
         ReorgExecute.RegisterPrecedence( "RITicketTecnicoResponsable" ,  "CreateResponsable" );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IUSUARIO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIUsuarioEstadoTicket" ,  "CreateUsuario" );
         ReorgExecute.RegisterPrecedence( "RIUsuarioEstadoTicket" ,  "CreateEstadoTicket" );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ISOPORTETECNICO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIAtencionSoporteTecnicoTicket" ,  "CreateAtencionSoporteTecnico" );
         ReorgExecute.RegisterPrecedence( "RIAtencionSoporteTecnicoTicket" ,  "CreateTicket" );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IGXCHATMESSAGE1]"}) );
         ReorgExecute.RegisterPrecedence( "RIGXChatMessageGXChatUser" ,  "CreateGXChatMessage" );
         ReorgExecute.RegisterPrecedence( "RIGXChatMessageGXChatUser" ,  "CreateGXChatUser" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            constid = P00045_Aconstid[0];
            nconstid = P00045_nconstid[0];
            fkeyid = P00045_Afkeyid[0];
            nfkeyid = P00045_nfkeyid[0];
            rkeyid = P00045_Arkeyid[0];
            nrkeyid = P00045_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00045_Aconstid = new string[] {""} ;
         P00045_nconstid = new bool[] {false} ;
         P00045_Afkeyid = new string[] {""} ;
         P00045_nfkeyid = new bool[] {false} ;
         P00045_Arkeyid = new int[1] ;
         P00045_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Aconstid, P00045_Afkeyid, P00045_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string tablename ;
      protected string schemaname ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDataStore2 ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Aconstid ;
      protected bool[] P00045_nconstid ;
      protected string[] P00045_Afkeyid ;
      protected bool[] P00045_nfkeyid ;
      protected int[] P00045_Arkeyid ;
      protected bool[] P00045_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0) ,
          new ParDef("@sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
