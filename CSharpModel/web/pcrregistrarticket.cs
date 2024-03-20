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

      public void execute( long aP0_UsuarioId ,
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
                           bool aP19_TicketOtros ,
                           string aP20_TicketMemorando ,
                           DateTime aP21_TicketFechaHora )
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
         this.AV68TicketMemorando = aP20_TicketMemorando;
         this.AV69TicketFechaHora = aP21_TicketFechaHora;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_UsuarioId ,
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
                                 bool aP19_TicketOtros ,
                                 string aP20_TicketMemorando ,
                                 DateTime aP21_TicketFechaHora )
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
         objpcrregistrarticket.AV68TicketMemorando = aP20_TicketMemorando;
         objpcrregistrarticket.AV69TicketFechaHora = aP21_TicketFechaHora;
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
         AV67UserId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AV70TicketResponsableFechaHoraAsigna = DateTimeUtil.Now( context);
         AV71TicketResponsableFechaHoraResuelve = DateTimeUtil.Now( context);
         AV72TicketFechaSistema = DateTimeUtil.Now( context);
         AV73TicketResponsableFechaSistema = DateTimeUtil.Now( context);
         /*
            INSERT RECORD ON TABLE Ticket

         */
         /* Using cursor P005Q3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P005Q3_A40000GXC1[0];
            n40000GXC1 = P005Q3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P005Q5 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P005Q5_A40001GXC2[0];
            n40001GXC2 = P005Q5_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         AV66TicketId = (long)(A40000GXC1+1);
         AV65TicketLastId = (long)(A40001GXC2+1);
         A14TicketId = AV66TicketId;
         A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.YMDHMSMToT( (short)(DateTimeUtil.Year( AV69TicketFechaHora)), (short)(DateTimeUtil.Month( AV69TicketFechaHora)), (short)(DateTimeUtil.Day( AV69TicketFechaHora)), 0, 0, 0, 0));
         A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.YMDHMSMToT( 1900, 1, 1, (short)(DateTimeUtil.Hour( AV69TicketFechaHora)), (short)(DateTimeUtil.Minute( AV69TicketFechaHora)), (short)(DateTimeUtil.Second( AV69TicketFechaHora)), 0));
         A53TicketLaptop = AV46TicketLaptop;
         n53TicketLaptop = false;
         A42TicketDesktop = AV47TicketDesktop;
         n42TicketDesktop = false;
         A55TicketMonitor = AV48TicketMonitor;
         n55TicketMonitor = false;
         A50TicketImpresora = AV49TicketImpresora;
         n50TicketImpresora = false;
         A45TicketEscaner = AV50TicketEscaner;
         n45TicketEscaner = false;
         A59TicketRouter = AV51TicketRouter;
         n59TicketRouter = false;
         A60TicketSistemaOperativo = AV52TicketSistemaOperativo;
         n60TicketSistemaOperativo = false;
         A56TicketOffice = AV53TicketOffice;
         n56TicketOffice = false;
         A39TicketAntivirus = AV54TicketAntivirus;
         n39TicketAntivirus = false;
         A40TicketAplicacion = AV55TicketAplicacion;
         n40TicketAplicacion = false;
         A44TicketDisenio = AV56TicketDisenio;
         n44TicketDisenio = false;
         A51TicketIngenieria = AV57TicketIngenieria;
         n51TicketIngenieria = false;
         A43TicketDiscoDuroExterno = AV58TicketDiscoDuroExterno;
         n43TicketDiscoDuroExterno = false;
         A58TicketPerifericos = AV59TicketPerifericos;
         n58TicketPerifericos = false;
         A87TicketUps = AV60TicketUps;
         n87TicketUps = false;
         A41TicketApoyoUsuario = AV61TicketApoyoUsuario;
         n41TicketApoyoUsuario = false;
         A52TicketInstalarDataShow = AV62TicketInstalarDataShow;
         n52TicketInstalarDataShow = false;
         A57TicketOtros = AV63TicketOtros;
         n57TicketOtros = false;
         A15UsuarioId = AV34UsuarioId;
         A187EstadoTicketTicketId = 3;
         A278TicketUsuarioAsigno = AV67UserId;
         n278TicketUsuarioAsigno = false;
         A285TicketHoraCaracter = context.localUtil.Time( );
         A54TicketLastId = AV65TicketLastId;
         A362TicketMemorando = AV68TicketMemorando;
         n362TicketMemorando = false;
         A289TicketFechaHora = DateTimeUtil.TAdd( AV69TicketFechaHora, 3600*(-6));
         n289TicketFechaHora = false;
         A377TicketFechaSistema = DateTimeUtil.TAdd( AV72TicketFechaSistema, 3600*(-6));
         /* Using cursor P005Q6 */
         pr_default.execute(2, new Object[] {A14TicketId, A46TicketFecha, A48TicketHora, A15UsuarioId, A54TicketLastId, n53TicketLaptop, A53TicketLaptop, n42TicketDesktop, A42TicketDesktop, n55TicketMonitor, A55TicketMonitor, n50TicketImpresora, A50TicketImpresora, n45TicketEscaner, A45TicketEscaner, n59TicketRouter, A59TicketRouter, n60TicketSistemaOperativo, A60TicketSistemaOperativo, n56TicketOffice, A56TicketOffice, n39TicketAntivirus, A39TicketAntivirus, n40TicketAplicacion, A40TicketAplicacion, n44TicketDisenio, A44TicketDisenio, n51TicketIngenieria, A51TicketIngenieria, n43TicketDiscoDuroExterno, A43TicketDiscoDuroExterno, n58TicketPerifericos, A58TicketPerifericos, n87TicketUps, A87TicketUps, n41TicketApoyoUsuario, A41TicketApoyoUsuario, n52TicketInstalarDataShow, A52TicketInstalarDataShow, n57TicketOtros, A57TicketOtros, A187EstadoTicketTicketId, n278TicketUsuarioAsigno, A278TicketUsuarioAsigno, A285TicketHoraCaracter, n289TicketFechaHora, A289TicketFechaHora, n362TicketMemorando, A362TicketMemorando, A377TicketFechaSistema});
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
         /*
            INSERT RECORD ON TABLE TicketResponsable

         */
         /* Using cursor P005Q8 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40002GXC3 = P005Q8_A40002GXC3[0];
            n40002GXC3 = P005Q8_n40002GXC3[0];
         }
         else
         {
            A40002GXC3 = 0;
            n40002GXC3 = false;
         }
         pr_default.close(3);
         AV8TicketResponsableId = (long)(A40002GXC3+1);
         A14TicketId = AV66TicketId;
         A16TicketResponsableId = AV8TicketResponsableId;
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.YMDHMSMToT( 1900, 1, 1, (short)(DateTimeUtil.Hour( AV69TicketFechaHora)), (short)(DateTimeUtil.Minute( AV69TicketFechaHora)), (short)(DateTimeUtil.Second( AV69TicketFechaHora)), 0));
         A47TicketFechaResponsable = DateTimeUtil.ResetTime(context.localUtil.YMDHMSMToT( (short)(DateTimeUtil.Year( AV69TicketFechaHora)), (short)(DateTimeUtil.Month( AV69TicketFechaHora)), (short)(DateTimeUtil.Day( AV69TicketFechaHora)), 0, 0, 0, 0));
         A198TicketTecnicoResponsableId = AV9ResponsableId;
         A17EstadoTicketTecnicoId = 3;
         A290EtapaDesarrolloId = 8;
         n290EtapaDesarrolloId = false;
         A294CategoriaDetalleTareaId = 0;
         A287TicketResponsableFechaHoraAsigna = DateTimeUtil.TAdd( AV69TicketFechaHora, 3600*(-6));
         n287TicketResponsableFechaHoraAsigna = false;
         A288TicketResponsableFechaHoraResuelve = context.localUtil.YMDHMSMToT( 1900, 1, 1, 1, 1, 1, 0);
         n288TicketResponsableFechaHoraResuelve = false;
         A376TicketResponsableFechaSistema = DateTimeUtil.TAdd( AV73TicketResponsableFechaSistema, 3600*(-6));
         /* Using cursor P005Q9 */
         pr_default.execute(4, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n287TicketResponsableFechaHoraAsigna, A287TicketResponsableFechaHoraAsigna, n288TicketResponsableFechaHoraResuelve, A288TicketResponsableFechaHoraResuelve, n290EtapaDesarrolloId, A290EtapaDesarrolloId, A294CategoriaDetalleTareaId, A376TicketResponsableFechaSistema});
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
         /* Optimized UPDATE. */
         /* Using cursor P005Q10 */
         pr_default.execute(5, new Object[] {AV34UsuarioId});
         pr_default.close(5);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         /* End optimized UPDATE. */
         /* Optimized UPDATE. */
         /* Using cursor P005Q11 */
         pr_default.execute(6, new Object[] {AV9ResponsableId});
         pr_default.close(6);
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
         pr_default.close(3);
         pr_default.close(0);
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV67UserId = "";
         AV70TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         AV71TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         AV72TicketFechaSistema = (DateTime)(DateTime.MinValue);
         AV73TicketResponsableFechaSistema = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         P005Q3_A40000GXC1 = new long[1] ;
         P005Q3_n40000GXC1 = new bool[] {false} ;
         P005Q5_A40001GXC2 = new long[1] ;
         P005Q5_n40001GXC2 = new bool[] {false} ;
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A278TicketUsuarioAsigno = "";
         A285TicketHoraCaracter = "";
         A362TicketMemorando = "";
         A289TicketFechaHora = (DateTime)(DateTime.MinValue);
         A377TicketFechaSistema = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         P005Q8_A40002GXC3 = new long[1] ;
         P005Q8_n40002GXC3 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         A287TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         A288TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         A376TicketResponsableFechaSistema = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarticket__default(),
            new Object[][] {
                new Object[] {
               P005Q3_A40000GXC1, P005Q3_n40000GXC1
               }
               , new Object[] {
               P005Q5_A40001GXC2, P005Q5_n40001GXC2
               }
               , new Object[] {
               }
               , new Object[] {
               P005Q8_A40002GXC3, P005Q8_n40002GXC3
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
      private short A294CategoriaDetalleTareaId ;
      private int GX_INS7 ;
      private int GX_INS8 ;
      private long AV34UsuarioId ;
      private long A40000GXC1 ;
      private long A40001GXC2 ;
      private long AV66TicketId ;
      private long AV65TicketLastId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long A54TicketLastId ;
      private long A40002GXC3 ;
      private long AV8TicketResponsableId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private string A285TicketHoraCaracter ;
      private string Gx_emsg ;
      private DateTime AV69TicketFechaHora ;
      private DateTime AV70TicketResponsableFechaHoraAsigna ;
      private DateTime AV71TicketResponsableFechaHoraResuelve ;
      private DateTime AV72TicketFechaSistema ;
      private DateTime AV73TicketResponsableFechaSistema ;
      private DateTime A48TicketHora ;
      private DateTime A289TicketFechaHora ;
      private DateTime A377TicketFechaSistema ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime A287TicketResponsableFechaHoraAsigna ;
      private DateTime A288TicketResponsableFechaHoraResuelve ;
      private DateTime A376TicketResponsableFechaSistema ;
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
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool A53TicketLaptop ;
      private bool n53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool n42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool n55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool n50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool n45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool n59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool n60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool n56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool n39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool n40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool n44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool n51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool n43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool n58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool n87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool n41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool n52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool n57TicketOtros ;
      private bool n278TicketUsuarioAsigno ;
      private bool n362TicketMemorando ;
      private bool n289TicketFechaHora ;
      private bool n40002GXC3 ;
      private bool n290EtapaDesarrolloId ;
      private bool n287TicketResponsableFechaHoraAsigna ;
      private bool n288TicketResponsableFechaHoraResuelve ;
      private string AV68TicketMemorando ;
      private string AV67UserId ;
      private string A278TicketUsuarioAsigno ;
      private string A362TicketMemorando ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005Q3_A40000GXC1 ;
      private bool[] P005Q3_n40000GXC1 ;
      private long[] P005Q5_A40001GXC2 ;
      private bool[] P005Q5_n40001GXC2 ;
      private long[] P005Q8_A40002GXC3 ;
      private bool[] P005Q8_n40002GXC3 ;
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
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005Q3;
          prmP005Q3 = new Object[] {
          };
          Object[] prmP005Q5;
          prmP005Q5 = new Object[] {
          };
          Object[] prmP005Q6;
          prmP005Q6 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFecha",GXType.Date,8,0) ,
          new ParDef("@TicketHora",GXType.DateTime,0,5) ,
          new ParDef("@UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
          new ParDef("@TicketLaptop",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDesktop",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketMonitor",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketImpresora",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketEscaner",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketRouter",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketSistemaOperativo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketOffice",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketAntivirus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketAplicacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDisenio",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketIngenieria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketDiscoDuroExterno",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketPerifericos",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketUps",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketApoyoUsuario",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketInstalarDataShow",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketOtros",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0) ,
          new ParDef("@TicketUsuarioAsigno",GXType.NVarChar,100,60){Nullable=true} ,
          new ParDef("@TicketHoraCaracter",GXType.NChar,8,0) ,
          new ParDef("@TicketFechaHora",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@TicketMemorando",GXType.NVarChar,30,0){Nullable=true} ,
          new ParDef("@TicketFechaSistema",GXType.DateTime,10,8)
          };
          Object[] prmP005Q8;
          prmP005Q8 = new Object[] {
          };
          Object[] prmP005Q9;
          prmP005Q9 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@TicketResponsableFechaHoraAsigna",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@TicketResponsableFechaHoraResuelve",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0) ,
          new ParDef("@TicketResponsableFechaSistema",GXType.DateTime,10,8)
          };
          string cmdBufferP005Q9;
          cmdBufferP005Q9=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [EtapaDesarrolloId], [CategoriaDetalleTareaId], [TicketResponsableFechaSistema], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], "
          + " [TicketResponsableImplementacionUno], [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @TicketResponsableFechaHoraAsigna, @TicketResponsableFechaHoraResuelve, @EtapaDesarrolloId, @CategoriaDetalleTareaId, @TicketResponsableFechaSistema, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
          + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ))" ;
          Object[] prmP005Q10;
          prmP005Q10 = new Object[] {
          new ParDef("@AV34UsuarioId",GXType.Decimal,10,0)
          };
          Object[] prmP005Q11;
          prmP005Q11 = new Object[] {
          new ParDef("@AV9ResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Q3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketId]) AS GXC1 FROM [Ticket] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Q5", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT MAX([TicketLastId]) AS GXC2 FROM [Ticket] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Q6", "INSERT INTO [Ticket]([TicketId], [TicketFecha], [TicketHora], [UsuarioId], [TicketLastId], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [EstadoTicketTicketId], [TicketUsuarioAsigno], [TicketHoraCaracter], [TicketFechaHora], [TicketMemorando], [TicketFechaSistema], [TicketAnalisisDeProceso], [TicketDisenioConceptual], [TicketDesarrolloDeSistema], [TicketDesarrolloyPruebasIniciales], [TicketElaboraciondeDocumentacion], [TicketImplementacion], [TicketMantenimientoSistema], [TicketAdministradorBaseDatos]) VALUES(@TicketId, @TicketFecha, @TicketHora, @UsuarioId, @TicketLastId, @TicketLaptop, @TicketDesktop, @TicketMonitor, @TicketImpresora, @TicketEscaner, @TicketRouter, @TicketSistemaOperativo, @TicketOffice, @TicketAntivirus, @TicketAplicacion, @TicketDisenio, @TicketIngenieria, @TicketDiscoDuroExterno, @TicketPerifericos, @TicketUps, @TicketApoyoUsuario, @TicketInstalarDataShow, @TicketOtros, @EstadoTicketTicketId, @TicketUsuarioAsigno, @TicketHoraCaracter, @TicketFechaHora, @TicketMemorando, @TicketFechaSistema, convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0))", GxErrorMask.GX_NOMASK,prmP005Q6)
             ,new CursorDef("P005Q8", "SELECT COALESCE( T1.[GXC3], 0) AS GXC3 FROM (SELECT MAX([TicketResponsableId]) AS GXC3 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Q9", cmdBufferP005Q9, GxErrorMask.GX_NOMASK,prmP005Q9)
             ,new CursorDef("P005Q10", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=3  WHERE [UsuarioId] = @AV34UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005Q10)
             ,new CursorDef("P005Q11", "UPDATE [Responsable] SET [EstadoResponsableId]=1  WHERE [ResponsableId] = @AV9ResponsableId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP005Q11)
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
       }
    }

 }

}
