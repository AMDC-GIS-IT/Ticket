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
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class tickettecnicoconversion : GXProcedure
   {
      public tickettecnicoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public tickettecnicoconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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

      public void executeSubmit( )
      {
         tickettecnicoconversion objtickettecnicoconversion;
         objtickettecnicoconversion = new tickettecnicoconversion();
         objtickettecnicoconversion.context.SetSubmitInitialConfig(context);
         objtickettecnicoconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtickettecnicoconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tickettecnicoconversion)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized copy (Insert w/Subselect). */
         cmdBuffer=" SET IDENTITY_INSERT [GXA0009] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TICKETTECN2 */
         pr_default.execute(0);
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("TicketTecnico");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         cmdBuffer=" SET IDENTITY_INSERT [GXA0009] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* End optimized group. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         cmdBuffer = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tickettecnicoconversion__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string cmdBuffer ;
      private string Gx_emsg ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
   }

   public class tickettecnicoconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTICKETTECN2;
          prmTICKETTECN2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("TICKETTECN2", "INSERT INTO [GXA0009]([TicketTecnicoId], [TicketTecnicoFecha], [TicketTecnicoHora], [TicketId], [TicketResponsableId], [TicketTecnicoInventarioSerie], [TicketTecnicoInstalacion], [TicketTecnicoConfiguracion], [TicketTecnicoInternetRouter], [TicketTecnicoFormateo], [TicketTecnicoReparacion], [TicketTecnicoLimpieza], [TicketTecnicoPuntoRed], [TicketTecnicoCambiosHardware], [TicketTecnicoCopiasRespaldo], [TicketTecnicoRam], [TicketTecnicoDiscoDuro], [TicketTecnicoProcesador], [TicketTecnicoMaletin], [TicketTecnicoTonerCinta], [TicketTecnicoTarjetaVideoExtra], [TicketTecnicoCargadorLaptop], [TicketTecnicoCDsDVDs], [TicketTecnicoCableEspecial], [TicketTecnicoOtrosTaller], [TicketTecnicoCerrado], [TicketTecnicoPendiente], [TicketTecnicoPasaTaller], [TicketTecnicoObservacion]) SELECT [TicketTecnicoId], [TicketTecnicoFecha], [TicketTecnicoHora], [TicketId], [TicketResponsableId], [TicketTecnicoInventarioSerie], [TicketTecnicoInstalacion], [TicketTecnicoConfiguracion], [TicketTecnicoInternetRouter], [TicketTecnicoFormateo], [TicketTecnicoReparacion], [TicketTecnicoLimpieza], [TicketTecnicoPuntoRed], [TicketTecnicoCambiosHardware], [TicketTecnicoCopiasRespaldo], [TicketTecnicoRam], [TicketTecnicoDiscoDuro], [TicketTecnicoProcesador], [TicketTecnicoMaletin], [TicketTecnicoTonerCinta], [TicketTecnicoTarjetaVideoExtra], [TicketTecnicoCargadorLaptop], [TicketTecnicoCDsDVDs], [TicketTecnicoCableEspecial], [TicketTecnicoOtrosTaller], [TicketTecnicoCerrado], [TicketTecnicoPendiente], [TicketTecnicoPasaTaller], ' ' AS TicketTecnicoObservacion  FROM [TicketTecnico]", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTICKETTECN2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
