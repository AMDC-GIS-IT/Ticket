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
   public class pcrregistrarticket : GXProcedure
   {
      public pcrregistrarticket( )
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

      public pcrregistrarticket( IGxContext context )
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
         this.AV34UsuarioId = aP0_UsuarioId;
         this.AV9ResponsableId = aP1_ResponsableId;
         this.AV46TicketLaptop = aP2_TicketLaptop;
         this.AV47TicketDesktop = aP3_TicketDesktop;
         this.AV48TicketMonitor = aP4_TicketMonitor;
         this.AV49TicketImpresora = aP5_TicketImpresora;
         this.AV50TicketEscaner = aP6_TicketEscaner;
         this.AV51TicketRouter = aP7_TicketRouter;
         this.AV52TicketSistemaOperativo = aP8_TicketSistemaOperativo;
         this.AV53TicketOffice = aP9_TicketOffice;
         this.AV54TicketAntivirus = aP10_TicketAntivirus;
         this.AV55TicketAplicacion = aP11_TicketAplicacion;
         this.AV56TicketDisenio = aP12_TicketDisenio;
         this.AV57TicketIngenieria = aP13_TicketIngenieria;
         this.AV58TicketDiscoDuroExterno = aP14_TicketDiscoDuroExterno;
         this.AV59TicketPerifericos = aP15_TicketPerifericos;
         this.AV60TicketUps = aP16_TicketUps;
         this.AV61TicketApoyoUsuario = aP17_TicketApoyoUsuario;
         this.AV62TicketInstalarDataShow = aP18_TicketInstalarDataShow;
         this.AV63TicketOtros = aP19_TicketOtros;
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
         pcrregistrarticket objpcrregistrarticket;
         objpcrregistrarticket = new pcrregistrarticket();
         objpcrregistrarticket.AV34UsuarioId = aP0_UsuarioId;
         objpcrregistrarticket.AV9ResponsableId = aP1_ResponsableId;
         objpcrregistrarticket.AV46TicketLaptop = aP2_TicketLaptop;
         objpcrregistrarticket.AV47TicketDesktop = aP3_TicketDesktop;
         objpcrregistrarticket.AV48TicketMonitor = aP4_TicketMonitor;
         objpcrregistrarticket.AV49TicketImpresora = aP5_TicketImpresora;
         objpcrregistrarticket.AV50TicketEscaner = aP6_TicketEscaner;
         objpcrregistrarticket.AV51TicketRouter = aP7_TicketRouter;
         objpcrregistrarticket.AV52TicketSistemaOperativo = aP8_TicketSistemaOperativo;
         objpcrregistrarticket.AV53TicketOffice = aP9_TicketOffice;
         objpcrregistrarticket.AV54TicketAntivirus = aP10_TicketAntivirus;
         objpcrregistrarticket.AV55TicketAplicacion = aP11_TicketAplicacion;
         objpcrregistrarticket.AV56TicketDisenio = aP12_TicketDisenio;
         objpcrregistrarticket.AV57TicketIngenieria = aP13_TicketIngenieria;
         objpcrregistrarticket.AV58TicketDiscoDuroExterno = aP14_TicketDiscoDuroExterno;
         objpcrregistrarticket.AV59TicketPerifericos = aP15_TicketPerifericos;
         objpcrregistrarticket.AV60TicketUps = aP16_TicketUps;
         objpcrregistrarticket.AV61TicketApoyoUsuario = aP17_TicketApoyoUsuario;
         objpcrregistrarticket.AV62TicketInstalarDataShow = aP18_TicketInstalarDataShow;
         objpcrregistrarticket.AV63TicketOtros = aP19_TicketOtros;
         objpcrregistrarticket.context.SetSubmitInitialConfig(context);
         objpcrregistrarticket.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrregistrarticket);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrregistrarticket)stateInfo).executePrivate();
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
         A53TicketLaptop = AV46TicketLaptop;
         A42TicketDesktop = AV47TicketDesktop;
         A55TicketMonitor = AV48TicketMonitor;
         A50TicketImpresora = AV49TicketImpresora;
         A45TicketEscaner = AV50TicketEscaner;
         A59TicketRouter = AV51TicketRouter;
         A60TicketSistemaOperativo = AV52TicketSistemaOperativo;
         A56TicketOffice = AV53TicketOffice;
         A39TicketAntivirus = AV54TicketAntivirus;
         A40TicketAplicacion = AV55TicketAplicacion;
         A44TicketDisenio = AV56TicketDisenio;
         A51TicketIngenieria = AV57TicketIngenieria;
         A43TicketDiscoDuroExterno = AV58TicketDiscoDuroExterno;
         A58TicketPerifericos = AV59TicketPerifericos;
         A87TicketUps = AV60TicketUps;
         A41TicketApoyoUsuario = AV61TicketApoyoUsuario;
         A52TicketInstalarDataShow = AV62TicketInstalarDataShow;
         A57TicketOtros = AV63TicketOtros;
         A15UsuarioId = AV34UsuarioId;
         A187EstadoTicketTicketId = 3;
         A278TicketUsuarioAsigno = AV64WebSession.Get("UsuarioSistema");
         A285TicketHoraCaracter = context.localUtil.Time( );
         /* Using cursor P005Q2 */
         pr_default.execute(0, new Object[] {A46TicketFecha, A48TicketHora, A15UsuarioId, A53TicketLaptop, A42TicketDesktop, A55TicketMonitor, A50TicketImpresora, A45TicketEscaner, A59TicketRouter, A60TicketSistemaOperativo, A56TicketOffice, A39TicketAntivirus, A40TicketAplicacion, A44TicketDisenio, A51TicketIngenieria, A43TicketDiscoDuroExterno, A58TicketPerifericos, A87TicketUps, A41TicketApoyoUsuario, A52TicketInstalarDataShow, A57TicketOtros, A187EstadoTicketTicketId, A278TicketUsuarioAsigno, A285TicketHoraCaracter});
         A14TicketId = P005Q2_A14TicketId[0];
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
         /* Using cursor P005Q4 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P005Q4_A40000GXC1[0];
            n40000GXC1 = P005Q4_n40000GXC1[0];
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
         A290EtapaDesarrolloId = 8;
         n290EtapaDesarrolloId = false;
         /* Using cursor P005Q5 */
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
         /* Using cursor P005Q6 */
         pr_default.execute(3, new Object[] {AV34UsuarioId});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005Q7 */
         pr_default.execute(4, new Object[] {AV9ResponsableId});
         pr_default.close(4);
         dsDefault.SmartCacheProvider.SetUpdated("Responsable");
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrregistrarticket",pr_default);
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
         AV64WebSession = context.GetSession();
         A285TicketHoraCaracter = "";
         P005Q2_A14TicketId = new long[1] ;
         Gx_emsg = "";
         scmdbuf = "";
         P005Q4_A40000GXC1 = new long[1] ;
         P005Q4_n40000GXC1 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarticket__default(),
            new Object[][] {
                new Object[] {
               P005Q2_A14TicketId
               }
               , new Object[] {
               P005Q4_A40000GXC1, P005Q4_n40000GXC1
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
      private bool AV46TicketLaptop ;
      private bool AV47TicketDesktop ;
      private bool AV48TicketMonitor ;
      private bool AV49TicketImpresora ;
      private bool AV50TicketEscaner ;
      private bool AV51TicketRouter ;
      private bool AV52TicketSistemaOperativo ;
      private bool AV53TicketOffice ;
      private bool AV54TicketAntivirus ;
      private bool AV55TicketAplicacion ;
      private bool AV56TicketDisenio ;
      private bool AV57TicketIngenieria ;
      private bool AV58TicketDiscoDuroExterno ;
      private bool AV59TicketPerifericos ;
      private bool AV60TicketUps ;
      private bool AV61TicketApoyoUsuario ;
      private bool AV62TicketInstalarDataShow ;
      private bool AV63TicketOtros ;
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
      private IGxSession AV64WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005Q2_A14TicketId ;
      private long[] P005Q4_A40000GXC1 ;
      private bool[] P005Q4_n40000GXC1 ;
   }

   public class pcrregistrarticket__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005Q2;
          prmP005Q2 = new Object[] {
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
          Object[] prmP005Q4;
          prmP005Q4 = new Object[] {
          };
          Object[] prmP005Q5;
          prmP005Q5 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmP005Q6;
          prmP005Q6 = new Object[] {
          new ParDef("@AV34UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmP005Q7;
          prmP005Q7 = new Object[] {
          new ParDef("@AV9ResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Q2", "INSERT INTO [Ticket]([TicketFecha], [TicketHora], [UsuarioId], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [EstadoTicketTicketId], [TicketUsuarioAsigno], [TicketHoraCaracter], [TicketLastId], [TicketFechaHora]) VALUES(@TicketFecha, @TicketHora, @UsuarioId, @TicketLaptop, @TicketDesktop, @TicketMonitor, @TicketImpresora, @TicketEscaner, @TicketRouter, @TicketSistemaOperativo, @TicketOffice, @TicketAntivirus, @TicketAplicacion, @TicketDisenio, @TicketIngenieria, @TicketDiscoDuroExterno, @TicketPerifericos, @TicketUps, @TicketApoyoUsuario, @TicketInstalarDataShow, @TicketOtros, @EstadoTicketTicketId, @TicketUsuarioAsigno, @TicketHoraCaracter, convert(int, 0), convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP005Q2)
             ,new CursorDef("P005Q4", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Q5", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP005Q5)
             ,new CursorDef("P005Q6", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=3  WHERE [UsuarioId] = @AV34UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005Q6)
             ,new CursorDef("P005Q7", "UPDATE [Responsable] SET [EstadoResponsableId]=1  WHERE [ResponsableId] = @AV9ResponsableId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005Q7)
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
