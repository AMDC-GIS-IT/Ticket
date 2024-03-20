using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pcrimprimirsoportetecnicoadmin : GXProcedure
   {
      public pcrimprimirsoportetecnicoadmin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public pcrimprimirsoportetecnicoadmin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TicketId ,
                           long aP1_UsuarioId ,
                           long aP2_TicketResponsableId ,
                           short aP3_TicketTecnicoResponsableId ,
                           string aP4_TicketTecnicoResponsableNombre ,
                           string aP5_UsuarioEmail ,
                           DateTime aP6_UsuarioFecha ,
                           string aP7_UsuarioNombre ,
                           string aP8_UsuarioDepartamento ,
                           string aP9_UsuarioRequerimiento ,
                           bool aP10_TicketLaptop ,
                           bool aP11_TicketDesktop ,
                           bool aP12_TicketMonitor ,
                           bool aP13_TicketImpresora ,
                           bool aP14_TicketEscaner ,
                           bool aP15_TicketRouter ,
                           bool aP16_TicketSistemaOperativo ,
                           bool aP17_TicketOffice ,
                           bool aP18_TicketAntivirus ,
                           bool aP19_TicketDiscoDuroExterno ,
                           bool aP20_TicketPerifericos ,
                           bool aP21_TicketUps ,
                           bool aP22_TicketInstalarDataShow ,
                           bool aP23_TicketOtros ,
                           int aP24_UsuarioTelefono ,
                           DateTime aP25_TicketFechaResponsable ,
                           DateTime aP26_TicketHoraResponsable ,
                           string aP27_TicketMemorando )
      {
         this.AV2TicketId = aP0_TicketId;
         this.AV3UsuarioId = aP1_UsuarioId;
         this.AV4TicketResponsableId = aP2_TicketResponsableId;
         this.AV5TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV6TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         this.AV7UsuarioEmail = aP5_UsuarioEmail;
         this.AV8UsuarioFecha = aP6_UsuarioFecha;
         this.AV9UsuarioNombre = aP7_UsuarioNombre;
         this.AV10UsuarioDepartamento = aP8_UsuarioDepartamento;
         this.AV11UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         this.AV12TicketLaptop = aP10_TicketLaptop;
         this.AV13TicketDesktop = aP11_TicketDesktop;
         this.AV14TicketMonitor = aP12_TicketMonitor;
         this.AV15TicketImpresora = aP13_TicketImpresora;
         this.AV16TicketEscaner = aP14_TicketEscaner;
         this.AV17TicketRouter = aP15_TicketRouter;
         this.AV18TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         this.AV19TicketOffice = aP17_TicketOffice;
         this.AV20TicketAntivirus = aP18_TicketAntivirus;
         this.AV21TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         this.AV22TicketPerifericos = aP20_TicketPerifericos;
         this.AV23TicketUps = aP21_TicketUps;
         this.AV24TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         this.AV25TicketOtros = aP23_TicketOtros;
         this.AV26UsuarioTelefono = aP24_UsuarioTelefono;
         this.AV27TicketFechaResponsable = aP25_TicketFechaResponsable;
         this.AV28TicketHoraResponsable = aP26_TicketHoraResponsable;
         this.AV29TicketMemorando = aP27_TicketMemorando;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 long aP1_UsuarioId ,
                                 long aP2_TicketResponsableId ,
                                 short aP3_TicketTecnicoResponsableId ,
                                 string aP4_TicketTecnicoResponsableNombre ,
                                 string aP5_UsuarioEmail ,
                                 DateTime aP6_UsuarioFecha ,
                                 string aP7_UsuarioNombre ,
                                 string aP8_UsuarioDepartamento ,
                                 string aP9_UsuarioRequerimiento ,
                                 bool aP10_TicketLaptop ,
                                 bool aP11_TicketDesktop ,
                                 bool aP12_TicketMonitor ,
                                 bool aP13_TicketImpresora ,
                                 bool aP14_TicketEscaner ,
                                 bool aP15_TicketRouter ,
                                 bool aP16_TicketSistemaOperativo ,
                                 bool aP17_TicketOffice ,
                                 bool aP18_TicketAntivirus ,
                                 bool aP19_TicketDiscoDuroExterno ,
                                 bool aP20_TicketPerifericos ,
                                 bool aP21_TicketUps ,
                                 bool aP22_TicketInstalarDataShow ,
                                 bool aP23_TicketOtros ,
                                 int aP24_UsuarioTelefono ,
                                 DateTime aP25_TicketFechaResponsable ,
                                 DateTime aP26_TicketHoraResponsable ,
                                 string aP27_TicketMemorando )
      {
         pcrimprimirsoportetecnicoadmin objpcrimprimirsoportetecnicoadmin;
         objpcrimprimirsoportetecnicoadmin = new pcrimprimirsoportetecnicoadmin();
         objpcrimprimirsoportetecnicoadmin.AV2TicketId = aP0_TicketId;
         objpcrimprimirsoportetecnicoadmin.AV3UsuarioId = aP1_UsuarioId;
         objpcrimprimirsoportetecnicoadmin.AV4TicketResponsableId = aP2_TicketResponsableId;
         objpcrimprimirsoportetecnicoadmin.AV5TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objpcrimprimirsoportetecnicoadmin.AV6TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         objpcrimprimirsoportetecnicoadmin.AV7UsuarioEmail = aP5_UsuarioEmail;
         objpcrimprimirsoportetecnicoadmin.AV8UsuarioFecha = aP6_UsuarioFecha;
         objpcrimprimirsoportetecnicoadmin.AV9UsuarioNombre = aP7_UsuarioNombre;
         objpcrimprimirsoportetecnicoadmin.AV10UsuarioDepartamento = aP8_UsuarioDepartamento;
         objpcrimprimirsoportetecnicoadmin.AV11UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         objpcrimprimirsoportetecnicoadmin.AV12TicketLaptop = aP10_TicketLaptop;
         objpcrimprimirsoportetecnicoadmin.AV13TicketDesktop = aP11_TicketDesktop;
         objpcrimprimirsoportetecnicoadmin.AV14TicketMonitor = aP12_TicketMonitor;
         objpcrimprimirsoportetecnicoadmin.AV15TicketImpresora = aP13_TicketImpresora;
         objpcrimprimirsoportetecnicoadmin.AV16TicketEscaner = aP14_TicketEscaner;
         objpcrimprimirsoportetecnicoadmin.AV17TicketRouter = aP15_TicketRouter;
         objpcrimprimirsoportetecnicoadmin.AV18TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         objpcrimprimirsoportetecnicoadmin.AV19TicketOffice = aP17_TicketOffice;
         objpcrimprimirsoportetecnicoadmin.AV20TicketAntivirus = aP18_TicketAntivirus;
         objpcrimprimirsoportetecnicoadmin.AV21TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         objpcrimprimirsoportetecnicoadmin.AV22TicketPerifericos = aP20_TicketPerifericos;
         objpcrimprimirsoportetecnicoadmin.AV23TicketUps = aP21_TicketUps;
         objpcrimprimirsoportetecnicoadmin.AV24TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         objpcrimprimirsoportetecnicoadmin.AV25TicketOtros = aP23_TicketOtros;
         objpcrimprimirsoportetecnicoadmin.AV26UsuarioTelefono = aP24_UsuarioTelefono;
         objpcrimprimirsoportetecnicoadmin.AV27TicketFechaResponsable = aP25_TicketFechaResponsable;
         objpcrimprimirsoportetecnicoadmin.AV28TicketHoraResponsable = aP26_TicketHoraResponsable;
         objpcrimprimirsoportetecnicoadmin.AV29TicketMemorando = aP27_TicketMemorando;
         objpcrimprimirsoportetecnicoadmin.context.SetSubmitInitialConfig(context);
         objpcrimprimirsoportetecnicoadmin.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrimprimirsoportetecnicoadmin);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrimprimirsoportetecnicoadmin)stateInfo).executePrivate();
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
         args = new Object[] {(long)AV2TicketId,(long)AV3UsuarioId,(long)AV4TicketResponsableId,(short)AV5TicketTecnicoResponsableId,(string)AV6TicketTecnicoResponsableNombre,(string)AV7UsuarioEmail,(DateTime)AV8UsuarioFecha,(string)AV9UsuarioNombre,(string)AV10UsuarioDepartamento,(string)AV11UsuarioRequerimiento,(bool)AV12TicketLaptop,(bool)AV13TicketDesktop,(bool)AV14TicketMonitor,(bool)AV15TicketImpresora,(bool)AV16TicketEscaner,(bool)AV17TicketRouter,(bool)AV18TicketSistemaOperativo,(bool)AV19TicketOffice,(bool)AV20TicketAntivirus,(bool)AV21TicketDiscoDuroExterno,(bool)AV22TicketPerifericos,(bool)AV23TicketUps,(bool)AV24TicketInstalarDataShow,(bool)AV25TicketOtros,(int)AV26UsuarioTelefono,(DateTime)AV27TicketFechaResponsable,(DateTime)AV28TicketHoraResponsable,(string)AV29TicketMemorando} ;
         ClassLoader.Execute("apcrimprimirsoportetecnicoadmin","GeneXus.Programs","apcrimprimirsoportetecnicoadmin", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 28 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5TicketTecnicoResponsableId ;
      private int AV26UsuarioTelefono ;
      private long AV2TicketId ;
      private long AV3UsuarioId ;
      private long AV4TicketResponsableId ;
      private DateTime AV28TicketHoraResponsable ;
      private DateTime AV8UsuarioFecha ;
      private DateTime AV27TicketFechaResponsable ;
      private bool AV12TicketLaptop ;
      private bool AV13TicketDesktop ;
      private bool AV14TicketMonitor ;
      private bool AV15TicketImpresora ;
      private bool AV16TicketEscaner ;
      private bool AV17TicketRouter ;
      private bool AV18TicketSistemaOperativo ;
      private bool AV19TicketOffice ;
      private bool AV20TicketAntivirus ;
      private bool AV21TicketDiscoDuroExterno ;
      private bool AV22TicketPerifericos ;
      private bool AV23TicketUps ;
      private bool AV24TicketInstalarDataShow ;
      private bool AV25TicketOtros ;
      private string AV6TicketTecnicoResponsableNombre ;
      private string AV7UsuarioEmail ;
      private string AV9UsuarioNombre ;
      private string AV10UsuarioDepartamento ;
      private string AV11UsuarioRequerimiento ;
      private string AV29TicketMemorando ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
