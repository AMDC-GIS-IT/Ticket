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

      public void release( )
      {
      }

      public void execute( short aP0_UsuarioId ,
                           short aP1_ResponsableId ,
                           bool aP2_TicketLaptop ,
                           bool aP3_TicketDesktop ,
                           bool aP4_TicketMonitor ,
                           bool aP5_TicketImpresora ,
                           bool aP6_TicketEscaner ,
                           bool aP7_TicketRouter ,
                           bool aP8_TicketSistemaOperativo ,
                           bool aP9_TicketOffice ,
                           bool aP10_TicketAntivirus ,
                           bool aP11_TicketAplicacion ,
                           bool aP12_TicketDisenio ,
                           bool aP13_TicketIngenieria ,
                           bool aP14_TicketDiscoDuroExterno ,
                           bool aP15_TicketPerifericos ,
                           bool aP16_TicketUps ,
                           bool aP17_TicketApoyoUsuario ,
                           bool aP18_TicketInstalarDataShow ,
                           bool aP19_TicketOtros )
      {
         this.AV10UsuarioId = aP0_UsuarioId;
         this.AV9ResponsableId = aP1_ResponsableId;
         this.AV11TicketLaptop = aP2_TicketLaptop;
         this.AV12TicketDesktop = aP3_TicketDesktop;
         this.AV13TicketMonitor = aP4_TicketMonitor;
         this.AV14TicketImpresora = aP5_TicketImpresora;
         this.AV15TicketEscaner = aP6_TicketEscaner;
         this.AV16TicketRouter = aP7_TicketRouter;
         this.AV17TicketSistemaOperativo = aP8_TicketSistemaOperativo;
         this.AV18TicketOffice = aP9_TicketOffice;
         this.AV19TicketAntivirus = aP10_TicketAntivirus;
         this.AV20TicketAplicacion = aP11_TicketAplicacion;
         this.AV21TicketDisenio = aP12_TicketDisenio;
         this.AV22TicketIngenieria = aP13_TicketIngenieria;
         this.AV23TicketDiscoDuroExterno = aP14_TicketDiscoDuroExterno;
         this.AV24TicketPerifericos = aP15_TicketPerifericos;
         this.AV25TicketUps = aP16_TicketUps;
         this.AV26TicketApoyoUsuario = aP17_TicketApoyoUsuario;
         this.AV27TicketInstalarDataShow = aP18_TicketInstalarDataShow;
         this.AV28TicketOtros = aP19_TicketOtros;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_UsuarioId ,
                                 short aP1_ResponsableId ,
                                 bool aP2_TicketLaptop ,
                                 bool aP3_TicketDesktop ,
                                 bool aP4_TicketMonitor ,
                                 bool aP5_TicketImpresora ,
                                 bool aP6_TicketEscaner ,
                                 bool aP7_TicketRouter ,
                                 bool aP8_TicketSistemaOperativo ,
                                 bool aP9_TicketOffice ,
                                 bool aP10_TicketAntivirus ,
                                 bool aP11_TicketAplicacion ,
                                 bool aP12_TicketDisenio ,
                                 bool aP13_TicketIngenieria ,
                                 bool aP14_TicketDiscoDuroExterno ,
                                 bool aP15_TicketPerifericos ,
                                 bool aP16_TicketUps ,
                                 bool aP17_TicketApoyoUsuario ,
                                 bool aP18_TicketInstalarDataShow ,
                                 bool aP19_TicketOtros )
      {
         pcrregistrarticketdesarrollo objpcrregistrarticketdesarrollo;
         objpcrregistrarticketdesarrollo = new pcrregistrarticketdesarrollo();
         objpcrregistrarticketdesarrollo.AV10UsuarioId = aP0_UsuarioId;
         objpcrregistrarticketdesarrollo.AV9ResponsableId = aP1_ResponsableId;
         objpcrregistrarticketdesarrollo.AV11TicketLaptop = aP2_TicketLaptop;
         objpcrregistrarticketdesarrollo.AV12TicketDesktop = aP3_TicketDesktop;
         objpcrregistrarticketdesarrollo.AV13TicketMonitor = aP4_TicketMonitor;
         objpcrregistrarticketdesarrollo.AV14TicketImpresora = aP5_TicketImpresora;
         objpcrregistrarticketdesarrollo.AV15TicketEscaner = aP6_TicketEscaner;
         objpcrregistrarticketdesarrollo.AV16TicketRouter = aP7_TicketRouter;
         objpcrregistrarticketdesarrollo.AV17TicketSistemaOperativo = aP8_TicketSistemaOperativo;
         objpcrregistrarticketdesarrollo.AV18TicketOffice = aP9_TicketOffice;
         objpcrregistrarticketdesarrollo.AV19TicketAntivirus = aP10_TicketAntivirus;
         objpcrregistrarticketdesarrollo.AV20TicketAplicacion = aP11_TicketAplicacion;
         objpcrregistrarticketdesarrollo.AV21TicketDisenio = aP12_TicketDisenio;
         objpcrregistrarticketdesarrollo.AV22TicketIngenieria = aP13_TicketIngenieria;
         objpcrregistrarticketdesarrollo.AV23TicketDiscoDuroExterno = aP14_TicketDiscoDuroExterno;
         objpcrregistrarticketdesarrollo.AV24TicketPerifericos = aP15_TicketPerifericos;
         objpcrregistrarticketdesarrollo.AV25TicketUps = aP16_TicketUps;
         objpcrregistrarticketdesarrollo.AV26TicketApoyoUsuario = aP17_TicketApoyoUsuario;
         objpcrregistrarticketdesarrollo.AV27TicketInstalarDataShow = aP18_TicketInstalarDataShow;
         objpcrregistrarticketdesarrollo.AV28TicketOtros = aP19_TicketOtros;
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
         /*
            INSERT RECORD ON TABLE Ticket

         */
         A46TicketFecha = DateTimeUtil.Today( context);
         A48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A53TicketLaptop = AV11TicketLaptop;
         A42TicketDesktop = AV12TicketDesktop;
         A55TicketMonitor = AV13TicketMonitor;
         A50TicketImpresora = AV14TicketImpresora;
         A45TicketEscaner = AV15TicketEscaner;
         A59TicketRouter = AV16TicketRouter;
         A60TicketSistemaOperativo = AV17TicketSistemaOperativo;
         A56TicketOffice = AV18TicketOffice;
         A39TicketAntivirus = AV19TicketAntivirus;
         A40TicketAplicacion = AV20TicketAplicacion;
         A44TicketDisenio = AV21TicketDisenio;
         A51TicketIngenieria = AV22TicketIngenieria;
         A43TicketDiscoDuroExterno = AV23TicketDiscoDuroExterno;
         A58TicketPerifericos = AV24TicketPerifericos;
         A87TicketUps = AV25TicketUps;
         A41TicketApoyoUsuario = AV26TicketApoyoUsuario;
         A52TicketInstalarDataShow = AV27TicketInstalarDataShow;
         A57TicketOtros = AV28TicketOtros;
         A15UsuarioId = AV10UsuarioId;
         A187EstadoTicketTicketId = 3;
         A278TicketUsuarioAsigno = AV29WebSession.Get("UsuarioSistema");
         A285TicketHoraCaracter = context.localUtil.Time( );
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {A46TicketFecha, A48TicketHora, A15UsuarioId, A53TicketLaptop, A42TicketDesktop, A55TicketMonitor, A50TicketImpresora, A45TicketEscaner, A59TicketRouter, A60TicketSistemaOperativo, A56TicketOffice, A39TicketAntivirus, A40TicketAplicacion, A44TicketDisenio, A51TicketIngenieria, A43TicketDiscoDuroExterno, A58TicketPerifericos, A87TicketUps, A41TicketApoyoUsuario, A52TicketInstalarDataShow, A57TicketOtros, A187EstadoTicketTicketId, A278TicketUsuarioAsigno, A285TicketHoraCaracter});
         A14TicketId = P00742_A14TicketId[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
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
         /*
            INSERT RECORD ON TABLE TicketResponsable

         */
         /* Using cursor P00744 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P00744_A40000GXC1[0];
            n40000GXC1 = P00744_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         AV8TicketResponsableId = (long)(A40000GXC1+1);
         A16TicketResponsableId = AV8TicketResponsableId;
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A47TicketFechaResponsable = DateTimeUtil.Today( context);
         A198TicketTecnicoResponsableId = AV9ResponsableId;
         A17EstadoTicketTecnicoId = 3;
         A290EtapaDesarrolloId = 1;
         n290EtapaDesarrolloId = false;
         /* Using cursor P00745 */
         pr_default.execute(2, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
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
         /* Optimized UPDATE. */
         /* Using cursor P00746 */
         pr_default.execute(3, new Object[] {AV10UsuarioId});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P00747 */
         pr_default.execute(4, new Object[] {AV9ResponsableId});
         pr_default.close(4);
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A278TicketUsuarioAsigno = "";
         AV29WebSession = context.GetSession();
         A285TicketHoraCaracter = "";
         P00742_A14TicketId = new long[1] ;
         Gx_emsg = "";
         scmdbuf = "";
         P00744_A40000GXC1 = new long[1] ;
         P00744_n40000GXC1 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarticketdesarrollo__default(),
            new Object[][] {
                new Object[] {
               P00742_A14TicketId
               }
               , new Object[] {
               P00744_A40000GXC1, P00744_n40000GXC1
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

      private short AV10UsuarioId ;
      private short AV9ResponsableId ;
      private short A15UsuarioId ;
      private short A187EstadoTicketTicketId ;
      private short A198TicketTecnicoResponsableId ;
      private short A17EstadoTicketTecnicoId ;
      private short A290EtapaDesarrolloId ;
      private int GX_INS7 ;
      private int GX_INS8 ;
      private long A14TicketId ;
      private long A40000GXC1 ;
      private long AV8TicketResponsableId ;
      private long A16TicketResponsableId ;
      private string A285TicketHoraCaracter ;
      private string Gx_emsg ;
      private string scmdbuf ;
      private DateTime A48TicketHora ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime A46TicketFecha ;
      private DateTime A47TicketFechaResponsable ;
      private bool AV11TicketLaptop ;
      private bool AV12TicketDesktop ;
      private bool AV13TicketMonitor ;
      private bool AV14TicketImpresora ;
      private bool AV15TicketEscaner ;
      private bool AV16TicketRouter ;
      private bool AV17TicketSistemaOperativo ;
      private bool AV18TicketOffice ;
      private bool AV19TicketAntivirus ;
      private bool AV20TicketAplicacion ;
      private bool AV21TicketDisenio ;
      private bool AV22TicketIngenieria ;
      private bool AV23TicketDiscoDuroExterno ;
      private bool AV24TicketPerifericos ;
      private bool AV25TicketUps ;
      private bool AV26TicketApoyoUsuario ;
      private bool AV27TicketInstalarDataShow ;
      private bool AV28TicketOtros ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool n40000GXC1 ;
      private bool n290EtapaDesarrolloId ;
      private string A278TicketUsuarioAsigno ;
      private IGxSession AV29WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00742_A14TicketId ;
      private long[] P00744_A40000GXC1 ;
      private bool[] P00744_n40000GXC1 ;
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
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("@TicketFecha",GXType.Date,8,0) ,
          new ParDef("@TicketHora",GXType.DateTime,0,5) ,
          new ParDef("@UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@TicketLaptop",GXType.Boolean,4,0) ,
          new ParDef("@TicketDesktop",GXType.Boolean,4,0) ,
          new ParDef("@TicketMonitor",GXType.Boolean,4,0) ,
          new ParDef("@TicketImpresora",GXType.Boolean,4,0) ,
          new ParDef("@TicketEscaner",GXType.Boolean,4,0) ,
          new ParDef("@TicketRouter",GXType.Boolean,4,0) ,
          new ParDef("@TicketSistemaOperativo",GXType.Boolean,4,0) ,
          new ParDef("@TicketOffice",GXType.Boolean,4,0) ,
          new ParDef("@TicketAntivirus",GXType.Boolean,4,0) ,
          new ParDef("@TicketAplicacion",GXType.Boolean,4,0) ,
          new ParDef("@TicketDisenio",GXType.Boolean,4,0) ,
          new ParDef("@TicketIngenieria",GXType.Boolean,4,0) ,
          new ParDef("@TicketDiscoDuroExterno",GXType.Boolean,4,0) ,
          new ParDef("@TicketPerifericos",GXType.Boolean,4,0) ,
          new ParDef("@TicketUps",GXType.Boolean,4,0) ,
          new ParDef("@TicketApoyoUsuario",GXType.Boolean,4,0) ,
          new ParDef("@TicketInstalarDataShow",GXType.Boolean,4,0) ,
          new ParDef("@TicketOtros",GXType.Boolean,4,0) ,
          new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0) ,
          new ParDef("@TicketUsuarioAsigno",GXType.NVarChar,100,60) ,
          new ParDef("@TicketHoraCaracter",GXType.NChar,8,0)
          };
          Object[] prmP00744;
          prmP00744 = new Object[] {
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmP00746;
          prmP00746 = new Object[] {
          new ParDef("@AV10UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmP00747;
          prmP00747 = new Object[] {
          new ParDef("@AV9ResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "INSERT INTO [Ticket]([TicketFecha], [TicketHora], [UsuarioId], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [EstadoTicketTicketId], [TicketUsuarioAsigno], [TicketHoraCaracter], [TicketLastId], [TicketFechaHora]) VALUES(@TicketFecha, @TicketHora, @UsuarioId, @TicketLaptop, @TicketDesktop, @TicketMonitor, @TicketImpresora, @TicketEscaner, @TicketRouter, @TicketSistemaOperativo, @TicketOffice, @TicketAntivirus, @TicketAplicacion, @TicketDisenio, @TicketIngenieria, @TicketDiscoDuroExterno, @TicketPerifericos, @TicketUps, @TicketApoyoUsuario, @TicketInstalarDataShow, @TicketOtros, @EstadoTicketTicketId, @TicketUsuarioAsigno, @TicketHoraCaracter, convert(int, 0), convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP00742)
             ,new CursorDef("P00744", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00744,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00745", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00745)
             ,new CursorDef("P00746", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=3  WHERE [UsuarioId] = @AV10UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00746)
             ,new CursorDef("P00747", "UPDATE [Responsable] SET [EstadoResponsableId]=1  WHERE [ResponsableId] = @AV9ResponsableId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00747)
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
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
