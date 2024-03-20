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
   public class satisfaccionconversion : GXProcedure
   {
      public satisfaccionconversion( )
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

      public satisfaccionconversion( IGxContext context )
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

      public void executeSubmit( )
      {
         satisfaccionconversion objsatisfaccionconversion;
         objsatisfaccionconversion = new satisfaccionconversion();
         objsatisfaccionconversion.context.SetSubmitInitialConfig(context);
         objsatisfaccionconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsatisfaccionconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((satisfaccionconversion)stateInfo).executePrivate();
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
         /* Using cursor SATISFACCI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14TicketId = SATISFACCI2_A14TicketId[0];
            A16TicketResponsableId = SATISFACCI2_A16TicketResponsableId[0];
            A144SatisfaccionHora = SATISFACCI2_A144SatisfaccionHora[0];
            A34SatisfaccionSugerencia = SATISFACCI2_A34SatisfaccionSugerencia[0];
            A13SatisfaccionAtencionId = SATISFACCI2_A13SatisfaccionAtencionId[0];
            A12SatisfaccionTiempoId = SATISFACCI2_A12SatisfaccionTiempoId[0];
            A11SatisfaccionTecnicoProfesionalismoId = SATISFACCI2_A11SatisfaccionTecnicoProfesionalismoId[0];
            A10SatisfaccionTecnicoCompetenteId = SATISFACCI2_A10SatisfaccionTecnicoCompetenteId[0];
            A9SatisfaccionTecnicoProblemaId = SATISFACCI2_A9SatisfaccionTecnicoProblemaId[0];
            A8SatisfaccionResueltoId = SATISFACCI2_A8SatisfaccionResueltoId[0];
            A32SatisfaccionFecha = SATISFACCI2_A32SatisfaccionFecha[0];
            A7SatisfaccionId = SATISFACCI2_A7SatisfaccionId[0];
            /*
               INSERT RECORD ON TABLE GXA0006

            */
            AV2SatisfaccionId = A7SatisfaccionId;
            AV3SatisfaccionFecha = A32SatisfaccionFecha;
            AV4SatisfaccionResueltoId = A8SatisfaccionResueltoId;
            AV5SatisfaccionTecnicoProblemaId = A9SatisfaccionTecnicoProblemaId;
            AV6SatisfaccionTecnicoCompetenteId = A10SatisfaccionTecnicoCompetenteId;
            AV7SatisfaccionTecnicoProfesionalismoId = A11SatisfaccionTecnicoProfesionalismoId;
            AV8SatisfaccionTiempoId = A12SatisfaccionTiempoId;
            AV9SatisfaccionAtencionId = A13SatisfaccionAtencionId;
            AV10SatisfaccionSugerencia = A34SatisfaccionSugerencia;
            nV10SatisfaccionSugerencia = false;
            AV11SatisfaccionHora = A144SatisfaccionHora;
            AV12TicketResponsableId = A16TicketResponsableId;
            AV13TicketId = A14TicketId;
            if ( (0==A4EstadoSatisfaccionId) )
            {
               AV14SatisfaccionCatalogaId = 0;
            }
            else
            {
               AV14SatisfaccionCatalogaId = A4EstadoSatisfaccionId;
            }
            if ( (0==A4EstadoSatisfaccionId) )
            {
               AV15SatisfaccionRendimientoId = 0;
            }
            else
            {
               AV15SatisfaccionRendimientoId = A4EstadoSatisfaccionId;
            }
            if ( (0==A4EstadoSatisfaccionId) )
            {
               AV16SatisfaccionProgramadorId = 0;
            }
            else
            {
               AV16SatisfaccionProgramadorId = A4EstadoSatisfaccionId;
            }
            if ( (0==A4EstadoSatisfaccionId) )
            {
               AV17SatisfaccionCapacitacionId = 0;
            }
            else
            {
               AV17SatisfaccionCapacitacionId = A4EstadoSatisfaccionId;
            }
            AV18SatisfaccionMejoraSoftware = "";
            nV18SatisfaccionMejoraSoftware = false;
            nV18SatisfaccionMejoraSoftware = true;
            /* Using cursor SATISFACCI3 */
            pr_default.execute(1, new Object[] {AV2SatisfaccionId, AV3SatisfaccionFecha, AV4SatisfaccionResueltoId, AV5SatisfaccionTecnicoProblemaId, AV6SatisfaccionTecnicoCompetenteId, AV7SatisfaccionTecnicoProfesionalismoId, AV8SatisfaccionTiempoId, AV9SatisfaccionAtencionId, nV10SatisfaccionSugerencia, AV10SatisfaccionSugerencia, AV11SatisfaccionHora, AV12TicketResponsableId, AV13TicketId, AV14SatisfaccionCatalogaId, AV15SatisfaccionRendimientoId, AV16SatisfaccionProgramadorId, AV17SatisfaccionCapacitacionId, nV18SatisfaccionMejoraSoftware, AV18SatisfaccionMejoraSoftware});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0006");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         SATISFACCI2_A14TicketId = new long[1] ;
         SATISFACCI2_A16TicketResponsableId = new long[1] ;
         SATISFACCI2_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         SATISFACCI2_A34SatisfaccionSugerencia = new string[] {""} ;
         SATISFACCI2_A13SatisfaccionAtencionId = new short[1] ;
         SATISFACCI2_A12SatisfaccionTiempoId = new short[1] ;
         SATISFACCI2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         SATISFACCI2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         SATISFACCI2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         SATISFACCI2_A8SatisfaccionResueltoId = new short[1] ;
         SATISFACCI2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         SATISFACCI2_A7SatisfaccionId = new long[1] ;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         A34SatisfaccionSugerencia = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         AV3SatisfaccionFecha = DateTime.MinValue;
         AV10SatisfaccionSugerencia = "";
         AV11SatisfaccionHora = (DateTime)(DateTime.MinValue);
         AV18SatisfaccionMejoraSoftware = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.satisfaccionconversion__default(),
            new Object[][] {
                new Object[] {
               SATISFACCI2_A14TicketId, SATISFACCI2_A16TicketResponsableId, SATISFACCI2_A144SatisfaccionHora, SATISFACCI2_A34SatisfaccionSugerencia, SATISFACCI2_A13SatisfaccionAtencionId, SATISFACCI2_A12SatisfaccionTiempoId, SATISFACCI2_A11SatisfaccionTecnicoProfesionalismoId, SATISFACCI2_A10SatisfaccionTecnicoCompetenteId, SATISFACCI2_A9SatisfaccionTecnicoProblemaId, SATISFACCI2_A8SatisfaccionResueltoId,
               SATISFACCI2_A32SatisfaccionFecha, SATISFACCI2_A7SatisfaccionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A13SatisfaccionAtencionId ;
      private short A12SatisfaccionTiempoId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A8SatisfaccionResueltoId ;
      private short AV4SatisfaccionResueltoId ;
      private short AV5SatisfaccionTecnicoProblemaId ;
      private short AV6SatisfaccionTecnicoCompetenteId ;
      private short AV7SatisfaccionTecnicoProfesionalismoId ;
      private short AV8SatisfaccionTiempoId ;
      private short AV9SatisfaccionAtencionId ;
      private short A4EstadoSatisfaccionId ;
      private short AV14SatisfaccionCatalogaId ;
      private short AV15SatisfaccionRendimientoId ;
      private short AV16SatisfaccionProgramadorId ;
      private short AV17SatisfaccionCapacitacionId ;
      private int GIGXA0006 ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A7SatisfaccionId ;
      private long AV2SatisfaccionId ;
      private long AV12TicketResponsableId ;
      private long AV13TicketId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A144SatisfaccionHora ;
      private DateTime AV11SatisfaccionHora ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime AV3SatisfaccionFecha ;
      private bool nV10SatisfaccionSugerencia ;
      private bool nV18SatisfaccionMejoraSoftware ;
      private string A34SatisfaccionSugerencia ;
      private string AV10SatisfaccionSugerencia ;
      private string AV18SatisfaccionMejoraSoftware ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] SATISFACCI2_A14TicketId ;
      private long[] SATISFACCI2_A16TicketResponsableId ;
      private DateTime[] SATISFACCI2_A144SatisfaccionHora ;
      private string[] SATISFACCI2_A34SatisfaccionSugerencia ;
      private short[] SATISFACCI2_A13SatisfaccionAtencionId ;
      private short[] SATISFACCI2_A12SatisfaccionTiempoId ;
      private short[] SATISFACCI2_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] SATISFACCI2_A10SatisfaccionTecnicoCompetenteId ;
      private short[] SATISFACCI2_A9SatisfaccionTecnicoProblemaId ;
      private short[] SATISFACCI2_A8SatisfaccionResueltoId ;
      private DateTime[] SATISFACCI2_A32SatisfaccionFecha ;
      private long[] SATISFACCI2_A7SatisfaccionId ;
   }

   public class satisfaccionconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmSATISFACCI2;
          prmSATISFACCI2 = new Object[] {
          };
          Object[] prmSATISFACCI3;
          prmSATISFACCI3 = new Object[] {
          new ParDef("@AV2SatisfaccionId",GXType.Decimal,10,0) ,
          new ParDef("@AV3SatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@AV4SatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@AV5SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@AV6SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@AV7SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@AV8SatisfaccionTiempoId",GXType.Int16,4,0) ,
          new ParDef("@AV9SatisfaccionAtencionId",GXType.Int16,4,0) ,
          new ParDef("@AV10SatisfaccionSugerencia",GXType.VarChar,300,0){Nullable=true} ,
          new ParDef("@AV11SatisfaccionHora",GXType.DateTime,0,5) ,
          new ParDef("@AV12TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV13TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV14SatisfaccionCatalogaId",GXType.Int16,4,0) ,
          new ParDef("@AV15SatisfaccionRendimientoId",GXType.Int16,4,0) ,
          new ParDef("@AV16SatisfaccionProgramadorId",GXType.Int16,4,0) ,
          new ParDef("@AV17SatisfaccionCapacitacionId",GXType.Int16,4,0) ,
          new ParDef("@AV18SatisfaccionMejoraSoftware",GXType.VarChar,300,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("SATISFACCI2", "SELECT [TicketId], [TicketResponsableId], [SatisfaccionHora], [SatisfaccionSugerencia], [SatisfaccionAtencionId], [SatisfaccionTiempoId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProblemaId], [SatisfaccionResueltoId], [SatisfaccionFecha], [SatisfaccionId] FROM [Satisfaccion] ORDER BY [SatisfaccionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmSATISFACCI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("SATISFACCI3", "INSERT INTO [GXA0006]([SatisfaccionId], [SatisfaccionFecha], [SatisfaccionResueltoId], [SatisfaccionTecnicoProblemaId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTiempoId], [SatisfaccionAtencionId], [SatisfaccionSugerencia], [SatisfaccionHora], [TicketResponsableId], [TicketId], [SatisfaccionCatalogaId], [SatisfaccionRendimientoId], [SatisfaccionProgramadorId], [SatisfaccionCapacitacionId], [SatisfaccionMejoraSoftware]) VALUES(@AV2SatisfaccionId, @AV3SatisfaccionFecha, @AV4SatisfaccionResueltoId, @AV5SatisfaccionTecnicoProblemaId, @AV6SatisfaccionTecnicoCompetenteId, @AV7SatisfaccionTecnicoProfesionalismoId, @AV8SatisfaccionTiempoId, @AV9SatisfaccionAtencionId, @AV10SatisfaccionSugerencia, @AV11SatisfaccionHora, @AV12TicketResponsableId, @AV13TicketId, @AV14SatisfaccionCatalogaId, @AV15SatisfaccionRendimientoId, @AV16SatisfaccionProgramadorId, @AV17SatisfaccionCapacitacionId, @AV18SatisfaccionMejoraSoftware)", GxErrorMask.GX_NOMASK,prmSATISFACCI3)
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
