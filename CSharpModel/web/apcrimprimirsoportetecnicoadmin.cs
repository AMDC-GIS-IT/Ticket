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
using GeneXus.Printer;
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
   public class apcrimprimirsoportetecnicoadmin : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "pcrimprimirsoportetecnicoadmin_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TicketId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV27TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV45UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AV35TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AV38TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AV39TicketTecnicoResponsableNombre = GetPar( "TicketTecnicoResponsableNombre");
                  AV42UsuarioEmail = GetPar( "UsuarioEmail");
                  AV43UsuarioFecha = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha"));
                  AV46UsuarioNombre = GetPar( "UsuarioNombre");
                  AV41UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AV47UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AV30TicketLaptop = StringUtil.StrToBool( GetPar( "TicketLaptop"));
                  AV22TicketDesktop = StringUtil.StrToBool( GetPar( "TicketDesktop"));
                  AV31TicketMonitor = StringUtil.StrToBool( GetPar( "TicketMonitor"));
                  AV28TicketImpresora = StringUtil.StrToBool( GetPar( "TicketImpresora"));
                  AV24TicketEscaner = StringUtil.StrToBool( GetPar( "TicketEscaner"));
                  AV36TicketRouter = StringUtil.StrToBool( GetPar( "TicketRouter"));
                  AV37TicketSistemaOperativo = StringUtil.StrToBool( GetPar( "TicketSistemaOperativo"));
                  AV32TicketOffice = StringUtil.StrToBool( GetPar( "TicketOffice"));
                  AV21TicketAntivirus = StringUtil.StrToBool( GetPar( "TicketAntivirus"));
                  AV23TicketDiscoDuroExterno = StringUtil.StrToBool( GetPar( "TicketDiscoDuroExterno"));
                  AV34TicketPerifericos = StringUtil.StrToBool( GetPar( "TicketPerifericos"));
                  AV40TicketUps = StringUtil.StrToBool( GetPar( "TicketUps"));
                  AV29TicketInstalarDataShow = StringUtil.StrToBool( GetPar( "TicketInstalarDataShow"));
                  AV33TicketOtros = StringUtil.StrToBool( GetPar( "TicketOtros"));
                  AV48UsuarioTelefono = (int)(NumberUtil.Val( GetPar( "UsuarioTelefono"), "."));
                  AV25TicketFechaResponsable = context.localUtil.ParseDateParm( GetPar( "TicketFechaResponsable"));
                  AV26TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHoraResponsable")));
                  AV51TicketMemorando = GetPar( "TicketMemorando");
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public apcrimprimirsoportetecnicoadmin( )
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

      public apcrimprimirsoportetecnicoadmin( IGxContext context )
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
         this.AV27TicketId = aP0_TicketId;
         this.AV45UsuarioId = aP1_UsuarioId;
         this.AV35TicketResponsableId = aP2_TicketResponsableId;
         this.AV38TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV39TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         this.AV42UsuarioEmail = aP5_UsuarioEmail;
         this.AV43UsuarioFecha = aP6_UsuarioFecha;
         this.AV46UsuarioNombre = aP7_UsuarioNombre;
         this.AV41UsuarioDepartamento = aP8_UsuarioDepartamento;
         this.AV47UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         this.AV30TicketLaptop = aP10_TicketLaptop;
         this.AV22TicketDesktop = aP11_TicketDesktop;
         this.AV31TicketMonitor = aP12_TicketMonitor;
         this.AV28TicketImpresora = aP13_TicketImpresora;
         this.AV24TicketEscaner = aP14_TicketEscaner;
         this.AV36TicketRouter = aP15_TicketRouter;
         this.AV37TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         this.AV32TicketOffice = aP17_TicketOffice;
         this.AV21TicketAntivirus = aP18_TicketAntivirus;
         this.AV23TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         this.AV34TicketPerifericos = aP20_TicketPerifericos;
         this.AV40TicketUps = aP21_TicketUps;
         this.AV29TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         this.AV33TicketOtros = aP23_TicketOtros;
         this.AV48UsuarioTelefono = aP24_UsuarioTelefono;
         this.AV25TicketFechaResponsable = aP25_TicketFechaResponsable;
         this.AV26TicketHoraResponsable = aP26_TicketHoraResponsable;
         this.AV51TicketMemorando = aP27_TicketMemorando;
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
         apcrimprimirsoportetecnicoadmin objapcrimprimirsoportetecnicoadmin;
         objapcrimprimirsoportetecnicoadmin = new apcrimprimirsoportetecnicoadmin();
         objapcrimprimirsoportetecnicoadmin.AV27TicketId = aP0_TicketId;
         objapcrimprimirsoportetecnicoadmin.AV45UsuarioId = aP1_UsuarioId;
         objapcrimprimirsoportetecnicoadmin.AV35TicketResponsableId = aP2_TicketResponsableId;
         objapcrimprimirsoportetecnicoadmin.AV38TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objapcrimprimirsoportetecnicoadmin.AV39TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         objapcrimprimirsoportetecnicoadmin.AV42UsuarioEmail = aP5_UsuarioEmail;
         objapcrimprimirsoportetecnicoadmin.AV43UsuarioFecha = aP6_UsuarioFecha;
         objapcrimprimirsoportetecnicoadmin.AV46UsuarioNombre = aP7_UsuarioNombre;
         objapcrimprimirsoportetecnicoadmin.AV41UsuarioDepartamento = aP8_UsuarioDepartamento;
         objapcrimprimirsoportetecnicoadmin.AV47UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         objapcrimprimirsoportetecnicoadmin.AV30TicketLaptop = aP10_TicketLaptop;
         objapcrimprimirsoportetecnicoadmin.AV22TicketDesktop = aP11_TicketDesktop;
         objapcrimprimirsoportetecnicoadmin.AV31TicketMonitor = aP12_TicketMonitor;
         objapcrimprimirsoportetecnicoadmin.AV28TicketImpresora = aP13_TicketImpresora;
         objapcrimprimirsoportetecnicoadmin.AV24TicketEscaner = aP14_TicketEscaner;
         objapcrimprimirsoportetecnicoadmin.AV36TicketRouter = aP15_TicketRouter;
         objapcrimprimirsoportetecnicoadmin.AV37TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         objapcrimprimirsoportetecnicoadmin.AV32TicketOffice = aP17_TicketOffice;
         objapcrimprimirsoportetecnicoadmin.AV21TicketAntivirus = aP18_TicketAntivirus;
         objapcrimprimirsoportetecnicoadmin.AV23TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         objapcrimprimirsoportetecnicoadmin.AV34TicketPerifericos = aP20_TicketPerifericos;
         objapcrimprimirsoportetecnicoadmin.AV40TicketUps = aP21_TicketUps;
         objapcrimprimirsoportetecnicoadmin.AV29TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         objapcrimprimirsoportetecnicoadmin.AV33TicketOtros = aP23_TicketOtros;
         objapcrimprimirsoportetecnicoadmin.AV48UsuarioTelefono = aP24_UsuarioTelefono;
         objapcrimprimirsoportetecnicoadmin.AV25TicketFechaResponsable = aP25_TicketFechaResponsable;
         objapcrimprimirsoportetecnicoadmin.AV26TicketHoraResponsable = aP26_TicketHoraResponsable;
         objapcrimprimirsoportetecnicoadmin.AV51TicketMemorando = aP27_TicketMemorando;
         objapcrimprimirsoportetecnicoadmin.context.SetSubmitInitialConfig(context);
         objapcrimprimirsoportetecnicoadmin.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objapcrimprimirsoportetecnicoadmin);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apcrimprimirsoportetecnicoadmin)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11923, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Using cursor P007I2 */
            pr_default.execute(0, new Object[] {AV45UsuarioId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15UsuarioId = P007I2_A15UsuarioId[0];
               A92UsuarioHora = P007I2_A92UsuarioHora[0];
               AV44UsuarioHora = A92UsuarioHora;
               if ( AV22TicketDesktop || AV30TicketLaptop )
               {
                  AV14im_pc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV55Im_pc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV14im_pc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV55Im_pc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV23TicketDiscoDuroExterno )
               {
                  AV10im_fs = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV56Im_fs_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV10im_fs = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV56Im_fs_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV37TicketSistemaOperativo )
               {
                  AV19im_so = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV57Im_so_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV19im_so = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV57Im_so_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV34TicketPerifericos )
               {
                  AV15im_per = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV58Im_per_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV15im_per = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV58Im_per_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV21TicketAntivirus )
               {
                  AV9im_av = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV59Im_av_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV9im_av = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV59Im_av_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV24TicketEscaner || AV28TicketImpresora )
               {
                  AV11im_imesc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV60Im_imesc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV11im_imesc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV60Im_imesc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV32TicketOffice )
               {
                  AV12im_office = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV61Im_office_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV12im_office = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV61Im_office_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV33TicketOtros )
               {
                  AV16im_proc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV62Im_proc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV16im_proc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV62Im_proc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV36TicketRouter )
               {
                  AV17im_redes = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV63Im_redes_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV17im_redes = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV63Im_redes_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV49TicketIngenieria || AV50TicketAplicacion )
               {
                  AV18im_sistema = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV64Im_sistema_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV18im_sistema = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV64Im_sistema_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            H7I0( false, 1055) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "6c2746e3-8953-4486-b5b0-ab152d2419af", "", context.GetTheme( )), 0, Gx_line+283, 808, Gx_line+1050) ;
            getPrinter().GxDrawRect(0, Gx_line+17, 792, Gx_line+141, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(225, Gx_line+17, 225, Gx_line+141, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(608, Gx_line+17, 608, Gx_line+141, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "58672db5-e41e-4c25-8a7c-9a980bcd6b47", "", context.GetTheme( )), 0, Gx_line+0, 217, Gx_line+167) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "c609efd0-af00-4920-9b0c-7ad03923daad", "", context.GetTheme( )), 650, Gx_line+33, 750, Gx_line+105) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ORDEN DE TRABAJO", 283, Gx_line+50, 533, Gx_line+76, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+150, 792, Gx_line+317, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+183, 792, Gx_line+183, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+217, 792, Gx_line+217, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+283, 792, Gx_line+283, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+250, 792, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(400, Gx_line+150, 400, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nombre del Solicitante:", 8, Gx_line+150, 166, Gx_line+166, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha y hora de solicitud:", 8, Gx_line+250, 180, Gx_line+266, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha de atención:", 8, Gx_line+283, 136, Gx_line+299, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Dependencia:", 408, Gx_line+150, 502, Gx_line+166, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Correo electrónico:", 408, Gx_line+183, 536, Gx_line+199, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Número Memorando:", 8, Gx_line+217, 151, Gx_line+233, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Teléfono:", 8, Gx_line+183, 72, Gx_line+199, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Hora Inicio:", 300, Gx_line+283, 378, Gx_line+299, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Hora Cierre:", 550, Gx_line+283, 632, Gx_line+299, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(292, Gx_line+283, 292, Gx_line+316, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(542, Gx_line+283, 542, Gx_line+316, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+350, 792, Gx_line+967, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+317, 792, Gx_line+352, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+383, 792, Gx_line+413, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(8, Gx_line+417, 775, Gx_line+467, 1, 0, 255, 240, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Detalle de la solicitud: ", 8, Gx_line+317, 163, Gx_line+333, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("PROPORCIONE INFORMACIÓN ADICIONAL SI ES NECESARIO", 392, Gx_line+433, 769, Gx_line+447, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("COLOQUE UNA \"X\" EN LA CASILLA CORRESPONDIENTE", 25, Gx_line+433, 374, Gx_line+447, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Acción Requerida:  ", 8, Gx_line+383, 139, Gx_line+399, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+483, 783, Gx_line+513, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+483, 434, Gx_line+513, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("SOLICITUD DE SOPORTE TÉCNICO PARA PC / LAPTOP", 75, Gx_line+483, 370, Gx_line+497, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA ACCESO A FILESERVER ", 92, Gx_line+533, 366, Gx_line+547, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO POR CAMBIOS EN EL SISTEMA OPERATIVO", 25, Gx_line+583, 368, Gx_line+597, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA PERIFÉRICOS", 150, Gx_line+633, 368, Gx_line+647, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA ANTIVIRUS", 167, Gx_line+683, 371, Gx_line+697, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA IMPRESORA Y/O ESCANER", 75, Gx_line+733, 366, Gx_line+747, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("PROBLEMA CON OFFICE O APLICACIONES", 142, Gx_line+783, 368, Gx_line+797, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("ANALISIS / LEVANTAMIENTO DE PROCESOS", 125, Gx_line+833, 366, Gx_line+847, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO EN REDES O INFRAESTRUCTURA", 67, Gx_line+883, 360, Gx_line+897, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("CAMBIOS EN SISTEMAS Y/O APLICACIONES", 125, Gx_line+933, 361, Gx_line+947, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+533, 783, Gx_line+563, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+533, 434, Gx_line+563, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+583, 783, Gx_line+613, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+583, 434, Gx_line+613, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+633, 783, Gx_line+663, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+633, 434, Gx_line+663, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+683, 783, Gx_line+713, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+683, 434, Gx_line+713, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+733, 783, Gx_line+763, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+733, 434, Gx_line+763, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+783, 783, Gx_line+813, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+783, 434, Gx_line+813, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+833, 783, Gx_line+863, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+833, 434, Gx_line+863, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+883, 783, Gx_line+913, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+883, 434, Gx_line+913, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+933, 783, Gx_line+963, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+933, 434, Gx_line+963, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "eeaf439c-d9ed-4dae-b56a-a6e959416516", "", context.GetTheme( )), 575, Gx_line+983, 770, Gx_line+1011) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d3c1f95c-95cc-4ea4-8ad2-fe7171bae301", "", context.GetTheme( )), 42, Gx_line+983, 145, Gx_line+1013) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46UsuarioNombre, "")), 167, Gx_line+150, 384, Gx_line+183, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41UsuarioDepartamento, "")), 508, Gx_line+150, 791, Gx_line+183, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48UsuarioTelefono), "ZZZZZZZZ9")), 75, Gx_line+183, 167, Gx_line+198, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42UsuarioEmail, "")), 542, Gx_line+183, 792, Gx_line+216, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25TicketFechaResponsable, "99/99/9999"), 192, Gx_line+250, 284, Gx_line+265, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26TicketHoraResponsable, "99:99"), 292, Gx_line+250, 350, Gx_line+265, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47UsuarioRequerimiento, "")), 8, Gx_line+350, 791, Gx_line+383, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV14im_pc)) ? AV55Im_pc_GXI : AV14im_pc);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+483, 434, Gx_line+516) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV10im_fs)) ? AV56Im_fs_GXI : AV10im_fs);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+533, 434, Gx_line+566) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19im_so)) ? AV57Im_so_GXI : AV19im_so);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+583, 434, Gx_line+614) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV15im_per)) ? AV58Im_per_GXI : AV15im_per);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+633, 434, Gx_line+666) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9im_av)) ? AV59Im_av_GXI : AV9im_av);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+683, 434, Gx_line+716) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV11im_imesc)) ? AV60Im_imesc_GXI : AV11im_imesc);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+733, 434, Gx_line+766) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16im_proc)) ? AV62Im_proc_GXI : AV16im_proc);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+833, 434, Gx_line+866) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV18im_sistema)) ? AV64Im_sistema_GXI : AV18im_sistema);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+933, 434, Gx_line+966) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12im_office)) ? AV61Im_office_GXI : AV12im_office);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+783, 434, Gx_line+816) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17im_redes)) ? AV63Im_redes_GXI : AV17im_redes);
            getPrinter().GxDrawBitMap(sImgUrl, 392, Gx_line+883, 434, Gx_line+916) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Solicitud:", 408, Gx_line+217, 472, Gx_line+233, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45UsuarioId), "ZZZZZZZZZ9")), 483, Gx_line+217, 558, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TicketMemorando, "")), 158, Gx_line+217, 350, Gx_line+232, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+1055);
            H7I0( false, 998) ;
            getPrinter().GxDrawLine(217, Gx_line+17, 217, Gx_line+141, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ORDEN DE TRABAJO", 275, Gx_line+50, 525, Gx_line+76, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "c609efd0-af00-4920-9b0c-7ad03923daad", "", context.GetTheme( )), 650, Gx_line+33, 750, Gx_line+105) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "58672db5-e41e-4c25-8a7c-9a980bcd6b47", "", context.GetTheme( )), 8, Gx_line+0, 208, Gx_line+167) ;
            getPrinter().GxDrawLine(600, Gx_line+17, 600, Gx_line+141, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+17, 800, Gx_line+141, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+167, 800, Gx_line+384, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+200, 800, Gx_line+235, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+283, 800, Gx_line+318, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajo realizado:", 8, Gx_line+200, 131, Gx_line+216, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TÉCNICO:", 8, Gx_line+167, 69, Gx_line+181, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Observaciones:", 8, Gx_line+283, 111, Gx_line+299, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "6c2746e3-8953-4486-b5b0-ab152d2419af", "", context.GetTheme( )), 0, Gx_line+400, 808, Gx_line+980) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Firma del solicitante", 342, Gx_line+883, 489, Gx_line+900, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "b6288508-259e-4f1e-9d8f-866525664635", "", context.GetTheme( )), 17, Gx_line+583, 792, Gx_line+813) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("USUARIO:", 8, Gx_line+467, 72, Gx_line+481, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+517, 800, Gx_line+570, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+467, 800, Gx_line+517, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(400, Gx_line+400, 583, Gx_line+453, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+400, 183, Gx_line+453, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+400, 800, Gx_line+453, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Basándose en su propia experiencia, por favor valore las siguientes afirmaciones siendo 1 muy pobre y 5 excelente.", 8, Gx_line+533, 693, Gx_line+547, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajo realizado por:", 408, Gx_line+417, 557, Gx_line+433, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Trabajo autorizado por:", 8, Gx_line+417, 165, Gx_line+433, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d3c1f95c-95cc-4ea4-8ad2-fe7171bae301", "", context.GetTheme( )), 42, Gx_line+900, 145, Gx_line+930) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "eeaf439c-d9ed-4dae-b56a-a6e959416516", "", context.GetTheme( )), 583, Gx_line+900, 778, Gx_line+928) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TicketTecnicoResponsableNombre, "")), 75, Gx_line+167, 792, Gx_line+200, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46UsuarioNombre, "")), 83, Gx_line+467, 791, Gx_line+500, 0+16, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+998);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7I0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H7I0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P007I2_A15UsuarioId = new long[1] ;
         P007I2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         AV44UsuarioHora = (DateTime)(DateTime.MinValue);
         AV14im_pc = "";
         AV55Im_pc_GXI = "";
         AV10im_fs = "";
         AV56Im_fs_GXI = "";
         AV19im_so = "";
         AV57Im_so_GXI = "";
         AV15im_per = "";
         AV58Im_per_GXI = "";
         AV9im_av = "";
         AV59Im_av_GXI = "";
         AV11im_imesc = "";
         AV60Im_imesc_GXI = "";
         AV12im_office = "";
         AV61Im_office_GXI = "";
         AV16im_proc = "";
         AV62Im_proc_GXI = "";
         AV17im_redes = "";
         AV63Im_redes_GXI = "";
         AV18im_sistema = "";
         AV64Im_sistema_GXI = "";
         AV14im_pc = "";
         sImgUrl = "";
         AV10im_fs = "";
         AV19im_so = "";
         AV15im_per = "";
         AV9im_av = "";
         AV11im_imesc = "";
         AV16im_proc = "";
         AV18im_sistema = "";
         AV12im_office = "";
         AV17im_redes = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apcrimprimirsoportetecnicoadmin__default(),
            new Object[][] {
                new Object[] {
               P007I2_A15UsuarioId, P007I2_A92UsuarioHora
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV38TicketTecnicoResponsableId ;
      private short GxWebError ;
      private int AV48UsuarioTelefono ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV27TicketId ;
      private long AV45UsuarioId ;
      private long AV35TicketResponsableId ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string sImgUrl ;
      private DateTime AV26TicketHoraResponsable ;
      private DateTime A92UsuarioHora ;
      private DateTime AV44UsuarioHora ;
      private DateTime AV43UsuarioFecha ;
      private DateTime AV25TicketFechaResponsable ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV30TicketLaptop ;
      private bool AV22TicketDesktop ;
      private bool AV31TicketMonitor ;
      private bool AV28TicketImpresora ;
      private bool AV24TicketEscaner ;
      private bool AV36TicketRouter ;
      private bool AV37TicketSistemaOperativo ;
      private bool AV32TicketOffice ;
      private bool AV21TicketAntivirus ;
      private bool AV23TicketDiscoDuroExterno ;
      private bool AV34TicketPerifericos ;
      private bool AV40TicketUps ;
      private bool AV29TicketInstalarDataShow ;
      private bool AV33TicketOtros ;
      private bool AV49TicketIngenieria ;
      private bool AV50TicketAplicacion ;
      private string AV39TicketTecnicoResponsableNombre ;
      private string AV42UsuarioEmail ;
      private string AV46UsuarioNombre ;
      private string AV41UsuarioDepartamento ;
      private string AV47UsuarioRequerimiento ;
      private string AV51TicketMemorando ;
      private string AV55Im_pc_GXI ;
      private string AV56Im_fs_GXI ;
      private string AV57Im_so_GXI ;
      private string AV58Im_per_GXI ;
      private string AV59Im_av_GXI ;
      private string AV60Im_imesc_GXI ;
      private string AV61Im_office_GXI ;
      private string AV62Im_proc_GXI ;
      private string AV63Im_redes_GXI ;
      private string AV64Im_sistema_GXI ;
      private string AV14im_pc ;
      private string AV10im_fs ;
      private string AV19im_so ;
      private string AV15im_per ;
      private string AV9im_av ;
      private string AV11im_imesc ;
      private string AV12im_office ;
      private string AV16im_proc ;
      private string AV17im_redes ;
      private string AV18im_sistema ;
      private string Im_pc ;
      private string Im_fs ;
      private string Im_so ;
      private string Im_per ;
      private string Im_av ;
      private string Im_imesc ;
      private string Im_proc ;
      private string Im_sistema ;
      private string Im_office ;
      private string Im_redes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P007I2_A15UsuarioId ;
      private DateTime[] P007I2_A92UsuarioHora ;
   }

   public class apcrimprimirsoportetecnicoadmin__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          new ParDef("@AV45UsuarioId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "SELECT [UsuarioId], [UsuarioHora] FROM [Usuario] WHERE [UsuarioId] = @AV45UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                return;
       }
    }

 }

}
