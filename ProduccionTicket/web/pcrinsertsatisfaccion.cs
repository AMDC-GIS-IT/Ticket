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

      public void execute( long aP0_TicketId ,
                           long aP1_TicketResponsableId ,
                           long aP2_UsuarioId ,
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
                                 long aP2_UsuarioId ,
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
         /* Using cursor P005V3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P005V3_A40000GXC1[0];
            n40000GXC1 = P005V3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV55SatisfaccionId = (long)(A40000GXC1+1);
         A7SatisfaccionId = AV55SatisfaccionId;
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
         n34SatisfaccionSugerencia = false;
         A347SatisfaccionCatalogaId = 11;
         A350SatisfaccionRendimientoId = 11;
         A353SatisfaccionProgramadorId = 11;
         A356SatisfaccionCapacitacionId = 11;
         /* Using cursor P005V4 */
         pr_default.execute(1, new Object[] {A7SatisfaccionId, A32SatisfaccionFecha, A8SatisfaccionResueltoId, A9SatisfaccionTecnicoProblemaId, A10SatisfaccionTecnicoCompetenteId, A11SatisfaccionTecnicoProfesionalismoId, A12SatisfaccionTiempoId, A13SatisfaccionAtencionId, n34SatisfaccionSugerencia, A34SatisfaccionSugerencia, A144SatisfaccionHora, A16TicketResponsableId, A14TicketId, A347SatisfaccionCatalogaId, A350SatisfaccionRendimientoId, A353SatisfaccionProgramadorId, A356SatisfaccionCapacitacionId});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("Satisfaccion");
         if ( (pr_default.getStatus(1) == 1) )
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
         /* Using cursor P005V5 */
         pr_default.execute(2, new Object[] {AV35TicketId, AV34UsuarioId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005V6 */
         pr_default.execute(3, new Object[] {AV35TicketId, AV53TicketResponsableId, AV54TicketTecnicoResponsableId});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005V7 */
         pr_default.execute(4, new Object[] {AV34UsuarioId});
         pr_default.close(4);
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
         pr_default.close(0);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P005V3_A40000GXC1 = new long[1] ;
         P005V3_n40000GXC1 = new bool[] {false} ;
         A32SatisfaccionFecha = DateTime.MinValue;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         A34SatisfaccionSugerencia = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrinsertsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               P005V3_A40000GXC1, P005V3_n40000GXC1
               }
               , new Object[] {
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
      private short A347SatisfaccionCatalogaId ;
      private short A350SatisfaccionRendimientoId ;
      private short A353SatisfaccionProgramadorId ;
      private short A356SatisfaccionCapacitacionId ;
      private int GX_INS6 ;
      private long AV35TicketId ;
      private long AV53TicketResponsableId ;
      private long AV34UsuarioId ;
      private long A40000GXC1 ;
      private long AV55SatisfaccionId ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A144SatisfaccionHora ;
      private DateTime A32SatisfaccionFecha ;
      private bool n40000GXC1 ;
      private bool n34SatisfaccionSugerencia ;
      private string AV52SatisfaccionSugerencia ;
      private string A34SatisfaccionSugerencia ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005V3_A40000GXC1 ;
      private bool[] P005V3_n40000GXC1 ;
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
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005V3;
          prmP005V3 = new Object[] {
          };
          Object[] prmP005V4;
          prmP005V4 = new Object[] {
          new ParDef("@SatisfaccionId",GXType.Decimal,10,0) ,
          new ParDef("@SatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionSugerencia",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@SatisfaccionHora",GXType.DateTime,0,5) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0)
          };
          Object[] prmP005V5;
          prmP005V5 = new Object[] {
          new ParDef("@AV35TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV34UsuarioId",GXType.Decimal,10,0)
          };
          Object[] prmP005V6;
          prmP005V6 = new Object[] {
          new ParDef("@AV35TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV53TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV54TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          Object[] prmP005V7;
          prmP005V7 = new Object[] {
          new ParDef("@AV34UsuarioId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([SatisfaccionId]) AS GXC1 FROM [Satisfaccion] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005V4", "INSERT INTO [Satisfaccion]([SatisfaccionId], [SatisfaccionFecha], [SatisfaccionResueltoId], [SatisfaccionTecnicoProblemaId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTiempoId], [SatisfaccionAtencionId], [SatisfaccionSugerencia], [SatisfaccionHora], [TicketResponsableId], [TicketId], [SatisfaccionCatalogaId], [SatisfaccionRendimientoId], [SatisfaccionProgramadorId], [SatisfaccionCapacitacionId], [SatisfaccionMejoraSoftware]) VALUES(@SatisfaccionId, @SatisfaccionFecha, @SatisfaccionResueltoId, @SatisfaccionTecnicoProblemaId, @SatisfaccionTecnicoCompetenteId, @SatisfaccionTecnicoProfesionalismoId, @SatisfaccionTiempoId, @SatisfaccionAtencionId, @SatisfaccionSugerencia, @SatisfaccionHora, @TicketResponsableId, @TicketId, @SatisfaccionCatalogaId, @SatisfaccionRendimientoId, @SatisfaccionProgramadorId, @SatisfaccionCapacitacionId, '')", GxErrorMask.GX_NOMASK,prmP005V4)
             ,new CursorDef("P005V5", "UPDATE [Ticket] SET [EstadoTicketTicketId]=6  WHERE ([TicketId] = @AV35TicketId) AND ([UsuarioId] = @AV34UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V5)
             ,new CursorDef("P005V6", "UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=6  WHERE ([TicketId] = @AV35TicketId and [TicketResponsableId] = @AV53TicketResponsableId) AND ([EstadoTicketTecnicoId] = 5) AND ([TicketTecnicoResponsableId] = @AV54TicketTecnicoResponsableId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V6)
             ,new CursorDef("P005V7", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=6  WHERE [UsuarioId] = @AV34UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005V7)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
