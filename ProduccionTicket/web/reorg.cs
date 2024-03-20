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

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeTicket( )
      {
         string cmdBuffer = "";
         /* Indices for table Ticket */
         cmdBuffer=" ALTER TABLE [Ticket] ADD [TicketFechaSistema] datetime NOT NULL CONSTRAINT TicketFechaSistemaTicket_DEFAULT DEFAULT convert( DATETIME, '17530101', 112 ) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [Ticket] DROP CONSTRAINT TicketFechaSistemaTicket_DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTicketResponsable( )
      {
         string cmdBuffer = "";
         /* Indices for table TicketResponsable */
         cmdBuffer=" ALTER TABLE [TicketResponsable] ADD [TicketResponsableFechaSistema] datetime NOT NULL CONSTRAINT TicketResponsableFechaSistemaTicketResponsable_DEFAULT DEFAULT convert( DATETIME, '17530101', 112 ) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [TicketResponsable] DROP CONSTRAINT TicketResponsableFechaSistemaTicketResponsable_DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeUsuario( )
      {
         string cmdBuffer = "";
         /* Indices for table Usuario */
         cmdBuffer=" ALTER TABLE [Usuario] ADD [UsuarioFechaSistema] datetime NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            TicketCount = P00012_ATicketCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Ticket" ,  TicketCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            TicketResponsableCount = P00023_ATicketResponsableCount[0];
            pr_default.close(1);
            PrintRecordCount ( "TicketResponsable" ,  TicketResponsableCount );
            /* Using cursor P00034 */
            pr_default.execute(2);
            UsuarioCount = P00034_AUsuarioCount[0];
            pr_default.close(2);
            PrintRecordCount ( "Usuario" ,  UsuarioCount );
         }
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
            /* Using cursor P00045 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               sSchemaVar = P00045_AsSchemaVar[0];
               nsSchemaVar = P00045_nsSchemaVar[0];
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else
         {
            /* Using cursor P00056 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               sSchemaVar = P00056_AsSchemaVar[0];
               nsSchemaVar = P00056_nsSchemaVar[0];
               pr_default.readNext(4);
            }
            pr_default.close(4);
         }
         if ( ColumnExist("Ticket",sSchemaVar,"TicketFechaSistema") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"TicketFechaSistema", "Ticket"}) ) ;
            return false ;
         }
         if ( ColumnExist("TicketResponsable",sSchemaVar,"TicketResponsableFechaSistema") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"TicketResponsableFechaSistema", "TicketResponsable"}) ) ;
            return false ;
         }
         if ( ColumnExist("Usuario",sSchemaVar,"UsuarioFechaSistema") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"UsuarioFechaSistema", "Usuario"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P00067 */
         pr_default.execute(5, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(5) != 101) )
         {
            tablename = P00067_Atablename[0];
            ntablename = P00067_ntablename[0];
            schemaname = P00067_Aschemaname[0];
            nschemaname = P00067_nschemaname[0];
            columnname = P00067_Acolumnname[0];
            ncolumnname = P00067_ncolumnname[0];
            result = true;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTicket" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeTicketResponsable" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "ReorganizeUsuario" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
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
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Ticket", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"TicketResponsable", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Usuario", ""}) );
      }

      private void SetPrecedenceris( )
      {
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
         scmdbuf = "";
         P00012_ATicketCount = new int[1] ;
         P00023_ATicketResponsableCount = new int[1] ;
         P00034_AUsuarioCount = new int[1] ;
         sSchemaVar = "";
         nsSchemaVar = false;
         P00045_AsSchemaVar = new string[] {""} ;
         P00045_nsSchemaVar = new bool[] {false} ;
         P00056_AsSchemaVar = new string[] {""} ;
         P00056_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         sMyColumnName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         columnname = "";
         ncolumnname = false;
         P00067_Atablename = new string[] {""} ;
         P00067_ntablename = new bool[] {false} ;
         P00067_Aschemaname = new string[] {""} ;
         P00067_nschemaname = new bool[] {false} ;
         P00067_Acolumnname = new string[] {""} ;
         P00067_ncolumnname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATicketCount
               }
               , new Object[] {
               P00023_ATicketResponsableCount
               }
               , new Object[] {
               P00034_AUsuarioCount
               }
               , new Object[] {
               P00045_AsSchemaVar
               }
               , new Object[] {
               P00056_AsSchemaVar
               }
               , new Object[] {
               P00067_Atablename, P00067_Aschemaname, P00067_Acolumnname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int TicketCount ;
      protected int TicketResponsableCount ;
      protected int UsuarioCount ;
      protected string scmdbuf ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected string sMyColumnName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected string tablename ;
      protected string schemaname ;
      protected string columnname ;
      protected IGxDataStore dsDataStore2 ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATicketCount ;
      protected int[] P00023_ATicketResponsableCount ;
      protected int[] P00034_AUsuarioCount ;
      protected string[] P00045_AsSchemaVar ;
      protected bool[] P00045_nsSchemaVar ;
      protected string[] P00056_AsSchemaVar ;
      protected bool[] P00056_nsSchemaVar ;
      protected string[] P00067_Atablename ;
      protected bool[] P00067_ntablename ;
      protected string[] P00067_Aschemaname ;
      protected bool[] P00067_nschemaname ;
      protected string[] P00067_Acolumnname ;
      protected bool[] P00067_ncolumnname ;
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
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
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
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          };
          Object[] prmP00067;
          prmP00067 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0) ,
          new ParDef("@sMySchemaName",GXType.Char,255,0) ,
          new ParDef("@sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM [Ticket] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM [TicketResponsable] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT COUNT(*) FROM [Usuario] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00067", "SELECT TABLE_NAME, TABLE_SCHEMA, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) AND (COLUMN_NAME = @sMyColumnName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00067,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
