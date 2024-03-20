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
   public class pcrregistrarticketdesarrollo : GXProcedure
   {
      public pcrregistrarticketdesarrollo( )
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

      public pcrregistrarticketdesarrollo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           short aP1_ResponsableId ,
                           bool aP2_TicketAnalisisDeProceso ,
                           bool aP3_TicketDisenioConceptual ,
                           bool aP4_TicketDesarrolloDeSistema ,
                           bool aP5_TicketDesarrolloyPruebasIniciales ,
                           bool aP6_TicketElaboraciondeDocumentacion ,
                           bool aP7_TicketImplementacion ,
                           bool aP8_TicketMantenimientoSistema ,
                           bool aP9_TicketAdministradorBaseDatos )
      {
         this.AV10UsuarioId = aP0_UsuarioId;
         this.AV9ResponsableId = aP1_ResponsableId;
         this.AV33TicketAnalisisDeProceso = aP2_TicketAnalisisDeProceso;
         this.AV32TicketDisenioConceptual = aP3_TicketDisenioConceptual;
         this.AV34TicketDesarrolloDeSistema = aP4_TicketDesarrolloDeSistema;
         this.AV35TicketDesarrolloyPruebasIniciales = aP5_TicketDesarrolloyPruebasIniciales;
         this.AV36TicketElaboraciondeDocumentacion = aP6_TicketElaboraciondeDocumentacion;
         this.AV37TicketImplementacion = aP7_TicketImplementacion;
         this.AV38TicketMantenimientoSistema = aP8_TicketMantenimientoSistema;
         this.AV39TicketAdministradorBaseDatos = aP9_TicketAdministradorBaseDatos;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 short aP1_ResponsableId ,
                                 bool aP2_TicketAnalisisDeProceso ,
                                 bool aP3_TicketDisenioConceptual ,
                                 bool aP4_TicketDesarrolloDeSistema ,
                                 bool aP5_TicketDesarrolloyPruebasIniciales ,
                                 bool aP6_TicketElaboraciondeDocumentacion ,
                                 bool aP7_TicketImplementacion ,
                                 bool aP8_TicketMantenimientoSistema ,
                                 bool aP9_TicketAdministradorBaseDatos )
      {
         pcrregistrarticketdesarrollo objpcrregistrarticketdesarrollo;
         objpcrregistrarticketdesarrollo = new pcrregistrarticketdesarrollo();
         objpcrregistrarticketdesarrollo.AV10UsuarioId = aP0_UsuarioId;
         objpcrregistrarticketdesarrollo.AV9ResponsableId = aP1_ResponsableId;
         objpcrregistrarticketdesarrollo.AV33TicketAnalisisDeProceso = aP2_TicketAnalisisDeProceso;
         objpcrregistrarticketdesarrollo.AV32TicketDisenioConceptual = aP3_TicketDisenioConceptual;
         objpcrregistrarticketdesarrollo.AV34TicketDesarrolloDeSistema = aP4_TicketDesarrolloDeSistema;
         objpcrregistrarticketdesarrollo.AV35TicketDesarrolloyPruebasIniciales = aP5_TicketDesarrolloyPruebasIniciales;
         objpcrregistrarticketdesarrollo.AV36TicketElaboraciondeDocumentacion = aP6_TicketElaboraciondeDocumentacion;
         objpcrregistrarticketdesarrollo.AV37TicketImplementacion = aP7_TicketImplementacion;
         objpcrregistrarticketdesarrollo.AV38TicketMantenimientoSistema = aP8_TicketMantenimientoSistema;
         objpcrregistrarticketdesarrollo.AV39TicketAdministradorBaseDatos = aP9_TicketAdministradorBaseDatos;
         objpcrregistrarticketdesarrollo.context.SetSubmitInitialConfig(context);
         objpcrregistrarticketdesarrollo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrregistrarticketdesarrollo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrregistrarticketdesarrollo)stateInfo).executePrivate();
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
         AV40UserId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         /*
            INSERT RECORD ON TABLE Ticket

         */
         /* Using cursor P00743 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00743_A40000GXC1[0];
            n40000GXC1 = P00743_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P00745 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P00745_A40001GXC2[0];
            n40001GXC2 = P00745_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         AV31TicketId = (long)(A40000GXC1+1);
         AV30TicketLastId = (long)(A40001GXC2+1);
         A14TicketId = AV31TicketId;
         A46TicketFecha = DateTimeUtil.Today( context);
         A48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A297TicketAnalisisDeProceso = AV33TicketAnalisisDeProceso;
         n297TicketAnalisisDeProceso = false;
         A298TicketDisenioConceptual = AV32TicketDisenioConceptual;
         n298TicketDisenioConceptual = false;
         A299TicketDesarrolloDeSistema = AV34TicketDesarrolloDeSistema;
         n299TicketDesarrolloDeSistema = false;
         A300TicketDesarrolloyPruebasIniciales = AV35TicketDesarrolloyPruebasIniciales;
         n300TicketDesarrolloyPruebasIniciales = false;
         A301TicketElaboraciondeDocumentacion = AV36TicketElaboraciondeDocumentacion;
         n301TicketElaboraciondeDocumentacion = false;
         A302TicketImplementacion = AV37TicketImplementacion;
         n302TicketImplementacion = false;
         A303TicketMantenimientoSistema = AV38TicketMantenimientoSistema;
         n303TicketMantenimientoSistema = false;
         A304TicketAdministradorBaseDatos = AV39TicketAdministradorBaseDatos;
         n304TicketAdministradorBaseDatos = false;
         A15UsuarioId = AV10UsuarioId;
         A187EstadoTicketTicketId = 3;
         A278TicketUsuarioAsigno = AV40UserId;
         n278TicketUsuarioAsigno = false;
         A285TicketHoraCaracter = context.localUtil.Time( );
         A54TicketLastId = AV30TicketLastId;
         /* Using cursor P00746 */
         pr_default.execute(2, new Object[] {A14TicketId, A46TicketFecha, A48TicketHora, A15UsuarioId, A54TicketLastId, A187EstadoTicketTicketId, n278TicketUsuarioAsigno, A278TicketUsuarioAsigno, A285TicketHoraCaracter, n297TicketAnalisisDeProceso, A297TicketAnalisisDeProceso, n298TicketDisenioConceptual, A298TicketDisenioConceptual, n299TicketDesarrolloDeSistema, A299TicketDesarrolloDeSistema, n300TicketDesarrolloyPruebasIniciales, A300TicketDesarrolloyPruebasIniciales, n301TicketElaboraciondeDocumentacion, A301TicketElaboraciondeDocumentacion, n302TicketImplementacion, A302TicketImplementacion, n303TicketMantenimientoSistema, A303TicketMantenimientoSistema, n304TicketAdministradorBaseDatos, A304TicketAdministradorBaseDatos});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
         if ( (pr_default.getStatus(2) == 1) )
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
         if ( AV39TicketAdministradorBaseDatos )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P00748 */
            pr_default.execute(3);
            if ( (pr_default.getStatus(3) != 101) )
            {
               A40002GXC3 = P00748_A40002GXC3[0];
               n40002GXC3 = P00748_n40002GXC3[0];
            }
            else
            {
               A40002GXC3 = 0;
               n40002GXC3 = false;
            }
            pr_default.close(3);
            AV8TicketResponsableId = (long)(A40002GXC3+1);
            A16TicketResponsableId = AV8TicketResponsableId;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV9ResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 9;
            n290EtapaDesarrolloId = false;
            /* Using cursor P00749 */
            pr_default.execute(4, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(4);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(4) == 1) )
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
         }
         if ( ( AV33TicketAnalisisDeProceso ) || ( AV32TicketDisenioConceptual ) || ( AV34TicketDesarrolloDeSistema ) || ( AV35TicketDesarrolloyPruebasIniciales ) || ( AV36TicketElaboraciondeDocumentacion ) || ( AV37TicketImplementacion ) || ( AV38TicketMantenimientoSistema ) )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007411 */
            pr_default.execute(5);
            if ( (pr_default.getStatus(5) != 101) )
            {
               A40002GXC3 = P007411_A40002GXC3[0];
               n40002GXC3 = P007411_n40002GXC3[0];
            }
            else
            {
               A40002GXC3 = 0;
               n40002GXC3 = false;
            }
            pr_default.close(5);
            AV8TicketResponsableId = (long)(A40002GXC3+1);
            A16TicketResponsableId = AV8TicketResponsableId;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV9ResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 1;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007412 */
            pr_default.execute(6, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(6) == 1) )
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
         }
         /* Optimized UPDATE. */
         /* Using cursor P007413 */
         pr_default.execute(7, new Object[] {AV10UsuarioId});
         pr_default.close(7);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P007414 */
         pr_default.execute(8, new Object[] {AV9ResponsableId});
         pr_default.close(8);
         dsDefault.SmartCacheProvider.SetUpdated("Responsable");
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrregistrarticketdesarrollo",pr_default);
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(0);
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV40UserId = "";
         scmdbuf = "";
         P00743_A40000GXC1 = new long[1] ;
         P00743_n40000GXC1 = new bool[] {false} ;
         P00745_A40001GXC2 = new long[1] ;
         P00745_n40001GXC2 = new bool[] {false} ;
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A278TicketUsuarioAsigno = "";
         A285TicketHoraCaracter = "";
         Gx_emsg = "";
         P00748_A40002GXC3 = new long[1] ;
         P00748_n40002GXC3 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         P007411_A40002GXC3 = new long[1] ;
         P007411_n40002GXC3 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarticketdesarrollo__default(),
            new Object[][] {
                new Object[] {
               P00743_A40000GXC1, P00743_n40000GXC1
               }
               , new Object[] {
               P00745_A40001GXC2, P00745_n40001GXC2
               }
               , new Object[] {
               }
               , new Object[] {
               P00748_A40002GXC3, P00748_n40002GXC3
               }
               , new Object[] {
               }
               , new Object[] {
               P007411_A40002GXC3, P007411_n40002GXC3
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

      private short AV9ResponsableId ;
      private short A187EstadoTicketTicketId ;
      private short A198TicketTecnicoResponsableId ;
      private short A17EstadoTicketTecnicoId ;
      private short A290EtapaDesarrolloId ;
      private int GX_INS7 ;
      private int GX_INS8 ;
      private long AV10UsuarioId ;
      private long A40000GXC1 ;
      private long A40001GXC2 ;
      private long AV31TicketId ;
      private long AV30TicketLastId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long A54TicketLastId ;
      private long A40002GXC3 ;
      private long AV8TicketResponsableId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private string A285TicketHoraCaracter ;
      private string Gx_emsg ;
      private DateTime A48TicketHora ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime A46TicketFecha ;
      private DateTime A47TicketFechaResponsable ;
      private bool AV33TicketAnalisisDeProceso ;
      private bool AV32TicketDisenioConceptual ;
      private bool AV34TicketDesarrolloDeSistema ;
      private bool AV35TicketDesarrolloyPruebasIniciales ;
      private bool AV36TicketElaboraciondeDocumentacion ;
      private bool AV37TicketImplementacion ;
      private bool AV38TicketMantenimientoSistema ;
      private bool AV39TicketAdministradorBaseDatos ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool A297TicketAnalisisDeProceso ;
      private bool n297TicketAnalisisDeProceso ;
      private bool A298TicketDisenioConceptual ;
      private bool n298TicketDisenioConceptual ;
      private bool A299TicketDesarrolloDeSistema ;
      private bool n299TicketDesarrolloDeSistema ;
      private bool A300TicketDesarrolloyPruebasIniciales ;
      private bool n300TicketDesarrolloyPruebasIniciales ;
      private bool A301TicketElaboraciondeDocumentacion ;
      private bool n301TicketElaboraciondeDocumentacion ;
      private bool A302TicketImplementacion ;
      private bool n302TicketImplementacion ;
      private bool A303TicketMantenimientoSistema ;
      private bool n303TicketMantenimientoSistema ;
      private bool A304TicketAdministradorBaseDatos ;
      private bool n304TicketAdministradorBaseDatos ;
      private bool n278TicketUsuarioAsigno ;
      private bool n40002GXC3 ;
      private bool n290EtapaDesarrolloId ;
      private string AV40UserId ;
      private string A278TicketUsuarioAsigno ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00743_A40000GXC1 ;
      private bool[] P00743_n40000GXC1 ;
      private long[] P00745_A40001GXC2 ;
      private bool[] P00745_n40001GXC2 ;
      private long[] P00748_A40002GXC3 ;
      private bool[] P00748_n40002GXC3 ;
      private long[] P007411_A40002GXC3 ;
      private bool[] P007411_n40002GXC3 ;
   }

   public class pcrregistrarticketdesarrollo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00743;
          prmP00743 = new Object[] {
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          };
          Object[] prmP00746;
          prmP00746 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFecha",GXType.Date,8,0) ,
          new ParDef("@TicketHora",GXType.DateTime,0,5) ,
          new ParDef("@UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
          new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0) ,
          new ParDef("@TicketUsuarioAsigno",GXType.NVarChar,100,60){Nullable=true} ,
          new ParDef("@TicketHoraCaracter",GXType.NChar,8,0) ,
          new ParDef("@TicketAnalisisDeProceso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDisenioConceptual",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDesarrolloDeSistema",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDesarrolloyPruebasIniciales",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketElaboraciondeDocumentacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketImplementacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketMantenimientoSistema",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketAdministradorBaseDatos",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmP00748;
          prmP00748 = new Object[] {
          };
          Object[] prmP00749;
          prmP00749 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
          };
          string cmdBufferP00749;
          cmdBufferP00749=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
          + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
          + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
          Object[] prmP007411;
          prmP007411 = new Object[] {
          };
          Object[] prmP007412;
          prmP007412 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
          };
          string cmdBufferP007412;
          cmdBufferP007412=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
          + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
          + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
          Object[] prmP007413;
          prmP007413 = new Object[] {
          new ParDef("@AV10UsuarioId",GXType.Decimal,10,0)
          };
          Object[] prmP007414;
          prmP007414 = new Object[] {
          new ParDef("@AV9ResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00743", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketId]) AS GXC1 FROM [Ticket] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00745", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT MAX([TicketLastId]) AS GXC2 FROM [Ticket] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00746", "INSERT INTO [Ticket]([TicketId], [TicketFecha], [TicketHora], [UsuarioId], [TicketLastId], [EstadoTicketTicketId], [TicketUsuarioAsigno], [TicketHoraCaracter], [TicketAnalisisDeProceso], [TicketDisenioConceptual], [TicketDesarrolloDeSistema], [TicketDesarrolloyPruebasIniciales], [TicketElaboraciondeDocumentacion], [TicketImplementacion], [TicketMantenimientoSistema], [TicketAdministradorBaseDatos], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [TicketFechaHora], [TicketMemorando], [TicketFechaSistema]) VALUES(@TicketId, @TicketFecha, @TicketHora, @UsuarioId, @TicketLastId, @EstadoTicketTicketId, @TicketUsuarioAsigno, @TicketHoraCaracter, @TicketAnalisisDeProceso, @TicketDisenioConceptual, @TicketDesarrolloDeSistema, @TicketDesarrolloyPruebasIniciales, @TicketElaboraciondeDocumentacion, @TicketImplementacion, @TicketMantenimientoSistema, @TicketAdministradorBaseDatos, convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00746)
             ,new CursorDef("P00748", "SELECT COALESCE( T1.[GXC3], 0) AS GXC3 FROM (SELECT MAX([TicketResponsableId]) AS GXC3 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00748,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00749", cmdBufferP00749, GxErrorMask.GX_NOMASK,prmP00749)
             ,new CursorDef("P007411", "SELECT COALESCE( T1.[GXC3], 0) AS GXC3 FROM (SELECT MAX([TicketResponsableId]) AS GXC3 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007412", cmdBufferP007412, GxErrorMask.GX_NOMASK,prmP007412)
             ,new CursorDef("P007413", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=3  WHERE [UsuarioId] = @AV10UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007413)
             ,new CursorDef("P007414", "UPDATE [Responsable] SET [EstadoResponsableId]=1  WHERE [ResponsableId] = @AV9ResponsableId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007414)
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
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
