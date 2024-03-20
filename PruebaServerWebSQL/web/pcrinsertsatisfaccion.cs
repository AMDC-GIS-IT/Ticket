using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pcrinsertsatisfaccion : GXProcedure
   {
      public pcrinsertsatisfaccion( )
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

      public pcrinsertsatisfaccion( IGxContext context )
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

      public void execute( long aP0_TicketId ,
                           long aP1_TicketResponsableId ,
                           short aP2_UsuarioId ,
                           short aP3_SatisfaccionResueltoId ,
                           short aP4_SatisfaccionTecnicoProblemaId ,
                           short aP5_SatisfaccionTecnicoCompetenteId ,
                           short aP6_SatisfaccionTecnicoProfesionalismoId ,
                           short aP7_SatisfaccionTiempoId ,
                           short aP8_SatisfaccionAtencionId ,
                           string aP9_SatisfaccionSugerencia ,
                           short aP10_TicketTecnicoResponsableId )
      {
         this.AV35TicketId = aP0_TicketId;
         this.AV53TicketResponsableId = aP1_TicketResponsableId;
         this.AV34UsuarioId = aP2_UsuarioId;
         this.AV46SatisfaccionResueltoId = aP3_SatisfaccionResueltoId;
         this.AV47SatisfaccionTecnicoProblemaId = aP4_SatisfaccionTecnicoProblemaId;
         this.AV48SatisfaccionTecnicoCompetenteId = aP5_SatisfaccionTecnicoCompetenteId;
         this.AV49SatisfaccionTecnicoProfesionalismoId = aP6_SatisfaccionTecnicoProfesionalismoId;
         this.AV50SatisfaccionTiempoId = aP7_SatisfaccionTiempoId;
         this.AV51SatisfaccionAtencionId = aP8_SatisfaccionAtencionId;
         this.AV52SatisfaccionSugerencia = aP9_SatisfaccionSugerencia;
         this.AV54TicketTecnicoResponsableId = aP10_TicketTecnicoResponsableId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 long aP1_TicketResponsableId ,
                                 short aP2_UsuarioId ,
                                 short aP3_SatisfaccionResueltoId ,
                                 short aP4_SatisfaccionTecnicoProblemaId ,
                                 short aP5_SatisfaccionTecnicoCompetenteId ,
                                 short aP6_SatisfaccionTecnicoProfesionalismoId ,
                                 short aP7_SatisfaccionTiempoId ,
                                 short aP8_SatisfaccionAtencionId ,
                                 string aP9_SatisfaccionSugerencia ,
                                 short aP10_TicketTecnicoResponsableId )
      {
         pcrinsertsatisfaccion objpcrinsertsatisfaccion;
         objpcrinsertsatisfaccion = new pcrinsertsatisfaccion();
         objpcrinsertsatisfaccion.AV35TicketId = aP0_TicketId;
         objpcrinsertsatisfaccion.AV53TicketResponsableId = aP1_TicketResponsableId;
         objpcrinsertsatisfaccion.AV34UsuarioId = aP2_UsuarioId;
         objpcrinsertsatisfaccion.AV46SatisfaccionResueltoId = aP3_SatisfaccionResueltoId;
         objpcrinsertsatisfaccion.AV47SatisfaccionTecnicoProblemaId = aP4_SatisfaccionTecnicoProblemaId;
         objpcrinsertsatisfaccion.AV48SatisfaccionTecnicoCompetenteId = aP5_SatisfaccionTecnicoCompetenteId;
         objpcrinsertsatisfaccion.AV49SatisfaccionTecnicoProfesionalismoId = aP6_SatisfaccionTecnicoProfesionalismoId;
         objpcrinsertsatisfaccion.AV50SatisfaccionTiempoId = aP7_SatisfaccionTiempoId;
         objpcrinsertsatisfaccion.AV51SatisfaccionAtencionId = aP8_SatisfaccionAtencionId;
         objpcrinsertsatisfaccion.AV52SatisfaccionSugerencia = aP9_SatisfaccionSugerencia;
         objpcrinsertsatisfaccion.AV54TicketTecnicoResponsableId = aP10_TicketTecnicoResponsableId;
         objpcrinsertsatisfaccion.context.SetSubmitInitialConfig(context);
         objpcrinsertsatisfaccion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrinsertsatisfaccion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrinsertsatisfaccion)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE Satisfaccion

         */
         A32SatisfaccionFecha = DateTimeUtil.Today( context);
         A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A14TicketId = AV35TicketId;
         A16TicketResponsableId = AV53TicketResponsableId;
         A8SatisfaccionResueltoId = AV46SatisfaccionResueltoId;
         A9SatisfaccionTecnicoProblemaId = AV47SatisfaccionTecnicoProblemaId;
         A10SatisfaccionTecnicoCompetenteId = AV48SatisfaccionTecnicoCompetenteId;
         A11SatisfaccionTecnicoProfesionalismoId = AV49SatisfaccionTecnicoProfesionalismoId;
         A12SatisfaccionTiempoId = AV50SatisfaccionTiempoId;
         A13SatisfaccionAtencionId = AV51SatisfaccionAtencionId;
         A34SatisfaccionSugerencia = AV52SatisfaccionSugerencia;
         A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         /* Using cursor P005V2 */
         pr_default.execute(0, new Object[] {A32SatisfaccionFecha, A8SatisfaccionResueltoId, A9SatisfaccionTecnicoProblemaId, A10SatisfaccionTecnicoCompetenteId, A11SatisfaccionTecnicoProfesionalismoId, A12SatisfaccionTiempoId, A13SatisfaccionAtencionId, A34SatisfaccionSugerencia, A144SatisfaccionHora, A16TicketResponsableId, A14TicketId});
         A7SatisfaccionId = P005V2_A7SatisfaccionId[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Satisfaccion");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /* Optimized UPDATE. */
         /* Using cursor P005V3 */
         pr_default.execute(1, new Object[] {AV35TicketId, AV34UsuarioId});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005V4 */
         pr_default.execute(2, new Object[] {AV35TicketId, AV53TicketResponsableId, AV54TicketTecnicoResponsableId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005V5 */
         pr_default.execute(3, new Object[] {AV34UsuarioId});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrinsertsatisfaccion",pr_default);
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
         A32SatisfaccionFecha = DateTime.MinValue;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         A34SatisfaccionSugerencia = "";
         P005V2_A7SatisfaccionId = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrinsertsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               P005V2_A7SatisfaccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV34UsuarioId ;
      private short AV46SatisfaccionResueltoId ;
      private short AV47SatisfaccionTecnicoProblemaId ;
      private short AV48SatisfaccionTecnicoCompetenteId ;
      private short AV49SatisfaccionTecnicoProfesionalismoId ;
      private short AV50SatisfaccionTiempoId ;
      private short AV51SatisfaccionAtencionId ;
      private short AV54TicketTecnicoResponsableId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private int GX_INS6 ;
      private long AV35TicketId ;
      private long AV53TicketResponsableId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A7SatisfaccionId ;
      private string Gx_emsg ;
      private DateTime A144SatisfaccionHora ;
      private DateTime A32SatisfaccionFecha ;
      private string AV52SatisfaccionSugerencia ;
      private string A34SatisfaccionSugerencia ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005V2_A7SatisfaccionId ;
   }

   public class pcrinsertsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005V2;
          prmP005V2 = new Object[] {
          new ParDef("@SatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionSugerencia",GXType.NVarChar,300,0) ,
          new ParDef("@SatisfaccionHora",GXType.DateTime,0,5) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketId",GXType.Decimal,10,0)
          };
          Object[] prmP005V3;
          prmP005V3 = new Object[] {
          new ParDef("@AV35TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV34UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmP005V4;
          prmP005V4 = new Object[] {
          new ParDef("@AV35TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV53TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV54TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          Object[] prmP005V5;
          prmP005V5 = new Object[] {
          new ParDef("@AV34UsuarioId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V2", "INSERT INTO [Satisfaccion]([SatisfaccionFecha], [SatisfaccionResueltoId], [SatisfaccionTecnicoProblemaId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTiempoId], [SatisfaccionAtencionId], [SatisfaccionSugerencia], [SatisfaccionHora], [TicketResponsableId], [TicketId]) VALUES(@SatisfaccionFecha, @SatisfaccionResueltoId, @SatisfaccionTecnicoProblemaId, @SatisfaccionTecnicoCompetenteId, @SatisfaccionTecnicoProfesionalismoId, @SatisfaccionTiempoId, @SatisfaccionAtencionId, @SatisfaccionSugerencia, @SatisfaccionHora, @TicketResponsableId, @TicketId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP005V2)
             ,new CursorDef("P005V3", "UPDATE [Ticket] SET [EstadoTicketTicketId]=6  WHERE ([TicketId] = @AV35TicketId) AND ([UsuarioId] = @AV34UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V3)
             ,new CursorDef("P005V4", "UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=6  WHERE ([TicketId] = @AV35TicketId and [TicketResponsableId] = @AV53TicketResponsableId) AND ([EstadoTicketTecnicoId] = 5) AND ([TicketTecnicoResponsableId] = @AV54TicketTecnicoResponsableId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V4)
             ,new CursorDef("P005V5", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=6  WHERE [UsuarioId] = @AV34UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V5)
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
                return;
       }
    }

 }

}
