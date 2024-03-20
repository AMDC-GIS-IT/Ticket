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
   public class pcrinsertencuestadesarrollo : GXProcedure
   {
      public pcrinsertencuestadesarrollo( )
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

      public pcrinsertencuestadesarrollo( IGxContext context )
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
                           short aP3_SatisfaccionCatalogaId ,
                           short aP4_SatisfaccionRendimientoId ,
                           short aP5_SatisfaccionProgramadorId ,
                           short aP6_SatisfaccionCapacitacionId ,
                           string aP7_SatisfaccionMejoraSoftware ,
                           short aP8_TicketTecnicoResponsableId )
      {
         this.AV9TicketId = aP0_TicketId;
         this.AV17TicketResponsableId = aP1_TicketResponsableId;
         this.AV8UsuarioId = aP2_UsuarioId;
         this.AV24SatisfaccionCatalogaId = aP3_SatisfaccionCatalogaId;
         this.AV23SatisfaccionRendimientoId = aP4_SatisfaccionRendimientoId;
         this.AV22SatisfaccionProgramadorId = aP5_SatisfaccionProgramadorId;
         this.AV21SatisfaccionCapacitacionId = aP6_SatisfaccionCapacitacionId;
         this.AV20SatisfaccionMejoraSoftware = aP7_SatisfaccionMejoraSoftware;
         this.AV18TicketTecnicoResponsableId = aP8_TicketTecnicoResponsableId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 long aP1_TicketResponsableId ,
                                 long aP2_UsuarioId ,
                                 short aP3_SatisfaccionCatalogaId ,
                                 short aP4_SatisfaccionRendimientoId ,
                                 short aP5_SatisfaccionProgramadorId ,
                                 short aP6_SatisfaccionCapacitacionId ,
                                 string aP7_SatisfaccionMejoraSoftware ,
                                 short aP8_TicketTecnicoResponsableId )
      {
         pcrinsertencuestadesarrollo objpcrinsertencuestadesarrollo;
         objpcrinsertencuestadesarrollo = new pcrinsertencuestadesarrollo();
         objpcrinsertencuestadesarrollo.AV9TicketId = aP0_TicketId;
         objpcrinsertencuestadesarrollo.AV17TicketResponsableId = aP1_TicketResponsableId;
         objpcrinsertencuestadesarrollo.AV8UsuarioId = aP2_UsuarioId;
         objpcrinsertencuestadesarrollo.AV24SatisfaccionCatalogaId = aP3_SatisfaccionCatalogaId;
         objpcrinsertencuestadesarrollo.AV23SatisfaccionRendimientoId = aP4_SatisfaccionRendimientoId;
         objpcrinsertencuestadesarrollo.AV22SatisfaccionProgramadorId = aP5_SatisfaccionProgramadorId;
         objpcrinsertencuestadesarrollo.AV21SatisfaccionCapacitacionId = aP6_SatisfaccionCapacitacionId;
         objpcrinsertencuestadesarrollo.AV20SatisfaccionMejoraSoftware = aP7_SatisfaccionMejoraSoftware;
         objpcrinsertencuestadesarrollo.AV18TicketTecnicoResponsableId = aP8_TicketTecnicoResponsableId;
         objpcrinsertencuestadesarrollo.context.SetSubmitInitialConfig(context);
         objpcrinsertencuestadesarrollo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrinsertencuestadesarrollo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrinsertencuestadesarrollo)stateInfo).executePrivate();
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
         /* Using cursor P00783 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00783_A40000GXC1[0];
            n40000GXC1 = P00783_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV19SatisfaccionId = (long)(A40000GXC1+1);
         A7SatisfaccionId = AV19SatisfaccionId;
         A32SatisfaccionFecha = DateTimeUtil.Today( context);
         A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A14TicketId = AV9TicketId;
         A16TicketResponsableId = AV17TicketResponsableId;
         A8SatisfaccionResueltoId = 11;
         A9SatisfaccionTecnicoProblemaId = 11;
         A10SatisfaccionTecnicoCompetenteId = 11;
         A11SatisfaccionTecnicoProfesionalismoId = 11;
         A12SatisfaccionTiempoId = 11;
         A13SatisfaccionAtencionId = 11;
         A347SatisfaccionCatalogaId = AV24SatisfaccionCatalogaId;
         A350SatisfaccionRendimientoId = AV23SatisfaccionRendimientoId;
         A353SatisfaccionProgramadorId = AV22SatisfaccionProgramadorId;
         A356SatisfaccionCapacitacionId = AV21SatisfaccionCapacitacionId;
         A359SatisfaccionMejoraSoftware = AV20SatisfaccionMejoraSoftware;
         n359SatisfaccionMejoraSoftware = false;
         /* Using cursor P00784 */
         pr_default.execute(1, new Object[] {A7SatisfaccionId, A32SatisfaccionFecha, A8SatisfaccionResueltoId, A9SatisfaccionTecnicoProblemaId, A10SatisfaccionTecnicoCompetenteId, A11SatisfaccionTecnicoProfesionalismoId, A12SatisfaccionTiempoId, A13SatisfaccionAtencionId, A144SatisfaccionHora, A16TicketResponsableId, A14TicketId, A347SatisfaccionCatalogaId, A350SatisfaccionRendimientoId, A353SatisfaccionProgramadorId, A356SatisfaccionCapacitacionId, n359SatisfaccionMejoraSoftware, A359SatisfaccionMejoraSoftware});
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
         /* Using cursor P00785 */
         pr_default.execute(2, new Object[] {AV9TicketId, AV8UsuarioId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P00786 */
         pr_default.execute(3, new Object[] {AV9TicketId, AV17TicketResponsableId, AV18TicketTecnicoResponsableId});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P00787 */
         pr_default.execute(4, new Object[] {AV8UsuarioId});
         pr_default.close(4);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrinsertencuestadesarrollo",pr_default);
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
         P00783_A40000GXC1 = new long[1] ;
         P00783_n40000GXC1 = new bool[] {false} ;
         A32SatisfaccionFecha = DateTime.MinValue;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         A359SatisfaccionMejoraSoftware = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrinsertencuestadesarrollo__default(),
            new Object[][] {
                new Object[] {
               P00783_A40000GXC1, P00783_n40000GXC1
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

      private short AV24SatisfaccionCatalogaId ;
      private short AV23SatisfaccionRendimientoId ;
      private short AV22SatisfaccionProgramadorId ;
      private short AV21SatisfaccionCapacitacionId ;
      private short AV18TicketTecnicoResponsableId ;
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
      private long AV9TicketId ;
      private long AV17TicketResponsableId ;
      private long AV8UsuarioId ;
      private long A40000GXC1 ;
      private long AV19SatisfaccionId ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A144SatisfaccionHora ;
      private DateTime A32SatisfaccionFecha ;
      private bool n40000GXC1 ;
      private bool n359SatisfaccionMejoraSoftware ;
      private string AV20SatisfaccionMejoraSoftware ;
      private string A359SatisfaccionMejoraSoftware ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00783_A40000GXC1 ;
      private bool[] P00783_n40000GXC1 ;
   }

   public class pcrinsertencuestadesarrollo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00783;
          prmP00783 = new Object[] {
          };
          Object[] prmP00784;
          prmP00784 = new Object[] {
          new ParDef("@SatisfaccionId",GXType.Decimal,10,0) ,
          new ParDef("@SatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionHora",GXType.DateTime,0,5) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0) ,
          new ParDef("@SatisfaccionMejoraSoftware",GXType.NVarChar,300,0){Nullable=true}
          };
          Object[] prmP00785;
          prmP00785 = new Object[] {
          new ParDef("@AV9TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV8UsuarioId",GXType.Decimal,10,0)
          };
          Object[] prmP00786;
          prmP00786 = new Object[] {
          new ParDef("@AV9TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV17TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV18TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          Object[] prmP00787;
          prmP00787 = new Object[] {
          new ParDef("@AV8UsuarioId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00783", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([SatisfaccionId]) AS GXC1 FROM [Satisfaccion] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00783,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00784", "INSERT INTO [Satisfaccion]([SatisfaccionId], [SatisfaccionFecha], [SatisfaccionResueltoId], [SatisfaccionTecnicoProblemaId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTiempoId], [SatisfaccionAtencionId], [SatisfaccionHora], [TicketResponsableId], [TicketId], [SatisfaccionCatalogaId], [SatisfaccionRendimientoId], [SatisfaccionProgramadorId], [SatisfaccionCapacitacionId], [SatisfaccionMejoraSoftware], [SatisfaccionSugerencia]) VALUES(@SatisfaccionId, @SatisfaccionFecha, @SatisfaccionResueltoId, @SatisfaccionTecnicoProblemaId, @SatisfaccionTecnicoCompetenteId, @SatisfaccionTecnicoProfesionalismoId, @SatisfaccionTiempoId, @SatisfaccionAtencionId, @SatisfaccionHora, @TicketResponsableId, @TicketId, @SatisfaccionCatalogaId, @SatisfaccionRendimientoId, @SatisfaccionProgramadorId, @SatisfaccionCapacitacionId, @SatisfaccionMejoraSoftware, '')", GxErrorMask.GX_NOMASK,prmP00784)
             ,new CursorDef("P00785", "UPDATE [Ticket] SET [EstadoTicketTicketId]=6  WHERE ([TicketId] = @AV9TicketId) AND ([UsuarioId] = @AV8UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00785)
             ,new CursorDef("P00786", "UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=6  WHERE ([TicketId] = @AV9TicketId and [TicketResponsableId] = @AV17TicketResponsableId) AND ([EstadoTicketTecnicoId] = 5) AND ([TicketTecnicoResponsableId] = @AV18TicketTecnicoResponsableId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00786)
             ,new CursorDef("P00787", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=6  WHERE [UsuarioId] = @AV8UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00787)
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
