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
   public class apcrimprimirsoportetecnico : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            return "pcrimprimirsoportetecnico_Execute" ;
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
               AV8TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AV10TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AV11TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AV12TicketTecnicoResponsableNombre = GetPar( "TicketTecnicoResponsableNombre");
                  AV13UsuarioEmail = GetPar( "UsuarioEmail");
                  AV14UsuarioFecha = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha"));
                  AV15UsuarioNombre = GetPar( "UsuarioNombre");
                  AV16UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AV17UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AV19TicketLaptop = StringUtil.StrToBool( GetPar( "TicketLaptop"));
                  AV20TicketDesktop = StringUtil.StrToBool( GetPar( "TicketDesktop"));
                  AV21TicketMonitor = StringUtil.StrToBool( GetPar( "TicketMonitor"));
                  AV22TicketImpresora = StringUtil.StrToBool( GetPar( "TicketImpresora"));
                  AV23TicketEscaner = StringUtil.StrToBool( GetPar( "TicketEscaner"));
                  AV24TicketRouter = StringUtil.StrToBool( GetPar( "TicketRouter"));
                  AV25TicketSistemaOperativo = StringUtil.StrToBool( GetPar( "TicketSistemaOperativo"));
                  AV26TicketOffice = StringUtil.StrToBool( GetPar( "TicketOffice"));
                  AV27TicketAntivirus = StringUtil.StrToBool( GetPar( "TicketAntivirus"));
                  AV28TicketDiscoDuroExterno = StringUtil.StrToBool( GetPar( "TicketDiscoDuroExterno"));
                  AV29TicketPerifericos = StringUtil.StrToBool( GetPar( "TicketPerifericos"));
                  AV30TicketUps = StringUtil.StrToBool( GetPar( "TicketUps"));
                  AV31TicketInstalarDataShow = StringUtil.StrToBool( GetPar( "TicketInstalarDataShow"));
                  AV32TicketOtros = StringUtil.StrToBool( GetPar( "TicketOtros"));
                  AV33UsuarioTelefono = (int)(NumberUtil.Val( GetPar( "UsuarioTelefono"), "."));
                  AV35TicketFechaResponsable = context.localUtil.ParseDateParm( GetPar( "TicketFechaResponsable"));
                  AV34TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHoraResponsable")));
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

      public apcrimprimirsoportetecnico( )
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

      public apcrimprimirsoportetecnico( IGxContext context )
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
                           DateTime aP26_TicketHoraResponsable )
      {
         this.AV8TicketId = aP0_TicketId;
         this.AV9UsuarioId = aP1_UsuarioId;
         this.AV10TicketResponsableId = aP2_TicketResponsableId;
         this.AV11TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV12TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         this.AV13UsuarioEmail = aP5_UsuarioEmail;
         this.AV14UsuarioFecha = aP6_UsuarioFecha;
         this.AV15UsuarioNombre = aP7_UsuarioNombre;
         this.AV16UsuarioDepartamento = aP8_UsuarioDepartamento;
         this.AV17UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         this.AV19TicketLaptop = aP10_TicketLaptop;
         this.AV20TicketDesktop = aP11_TicketDesktop;
         this.AV21TicketMonitor = aP12_TicketMonitor;
         this.AV22TicketImpresora = aP13_TicketImpresora;
         this.AV23TicketEscaner = aP14_TicketEscaner;
         this.AV24TicketRouter = aP15_TicketRouter;
         this.AV25TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         this.AV26TicketOffice = aP17_TicketOffice;
         this.AV27TicketAntivirus = aP18_TicketAntivirus;
         this.AV28TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         this.AV29TicketPerifericos = aP20_TicketPerifericos;
         this.AV30TicketUps = aP21_TicketUps;
         this.AV31TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         this.AV32TicketOtros = aP23_TicketOtros;
         this.AV33UsuarioTelefono = aP24_UsuarioTelefono;
         this.AV35TicketFechaResponsable = aP25_TicketFechaResponsable;
         this.AV34TicketHoraResponsable = aP26_TicketHoraResponsable;
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
                                 DateTime aP26_TicketHoraResponsable )
      {
         apcrimprimirsoportetecnico objapcrimprimirsoportetecnico;
         objapcrimprimirsoportetecnico = new apcrimprimirsoportetecnico();
         objapcrimprimirsoportetecnico.AV8TicketId = aP0_TicketId;
         objapcrimprimirsoportetecnico.AV9UsuarioId = aP1_UsuarioId;
         objapcrimprimirsoportetecnico.AV10TicketResponsableId = aP2_TicketResponsableId;
         objapcrimprimirsoportetecnico.AV11TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objapcrimprimirsoportetecnico.AV12TicketTecnicoResponsableNombre = aP4_TicketTecnicoResponsableNombre;
         objapcrimprimirsoportetecnico.AV13UsuarioEmail = aP5_UsuarioEmail;
         objapcrimprimirsoportetecnico.AV14UsuarioFecha = aP6_UsuarioFecha;
         objapcrimprimirsoportetecnico.AV15UsuarioNombre = aP7_UsuarioNombre;
         objapcrimprimirsoportetecnico.AV16UsuarioDepartamento = aP8_UsuarioDepartamento;
         objapcrimprimirsoportetecnico.AV17UsuarioRequerimiento = aP9_UsuarioRequerimiento;
         objapcrimprimirsoportetecnico.AV19TicketLaptop = aP10_TicketLaptop;
         objapcrimprimirsoportetecnico.AV20TicketDesktop = aP11_TicketDesktop;
         objapcrimprimirsoportetecnico.AV21TicketMonitor = aP12_TicketMonitor;
         objapcrimprimirsoportetecnico.AV22TicketImpresora = aP13_TicketImpresora;
         objapcrimprimirsoportetecnico.AV23TicketEscaner = aP14_TicketEscaner;
         objapcrimprimirsoportetecnico.AV24TicketRouter = aP15_TicketRouter;
         objapcrimprimirsoportetecnico.AV25TicketSistemaOperativo = aP16_TicketSistemaOperativo;
         objapcrimprimirsoportetecnico.AV26TicketOffice = aP17_TicketOffice;
         objapcrimprimirsoportetecnico.AV27TicketAntivirus = aP18_TicketAntivirus;
         objapcrimprimirsoportetecnico.AV28TicketDiscoDuroExterno = aP19_TicketDiscoDuroExterno;
         objapcrimprimirsoportetecnico.AV29TicketPerifericos = aP20_TicketPerifericos;
         objapcrimprimirsoportetecnico.AV30TicketUps = aP21_TicketUps;
         objapcrimprimirsoportetecnico.AV31TicketInstalarDataShow = aP22_TicketInstalarDataShow;
         objapcrimprimirsoportetecnico.AV32TicketOtros = aP23_TicketOtros;
         objapcrimprimirsoportetecnico.AV33UsuarioTelefono = aP24_UsuarioTelefono;
         objapcrimprimirsoportetecnico.AV35TicketFechaResponsable = aP25_TicketFechaResponsable;
         objapcrimprimirsoportetecnico.AV34TicketHoraResponsable = aP26_TicketHoraResponsable;
         objapcrimprimirsoportetecnico.context.SetSubmitInitialConfig(context);
         objapcrimprimirsoportetecnico.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objapcrimprimirsoportetecnico);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apcrimprimirsoportetecnico)stateInfo).executePrivate();
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
            /* Using cursor P007G2 */
            pr_default.execute(0, new Object[] {AV9UsuarioId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15UsuarioId = P007G2_A15UsuarioId[0];
               A92UsuarioHora = P007G2_A92UsuarioHora[0];
               AV18UsuarioHora = A92UsuarioHora;
               if ( AV20TicketDesktop || AV19TicketLaptop )
               {
                  AV37im_pc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV57Im_pc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV37im_pc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV57Im_pc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV28TicketDiscoDuroExterno )
               {
                  AV38im_fs = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV58Im_fs_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV38im_fs = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV58Im_fs_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV25TicketSistemaOperativo )
               {
                  AV39im_so = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV59Im_so_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV39im_so = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV59Im_so_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV29TicketPerifericos )
               {
                  AV40im_per = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV60Im_per_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV40im_per = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV60Im_per_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV27TicketAntivirus )
               {
                  AV41im_av = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV61Im_av_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV41im_av = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV61Im_av_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV23TicketEscaner || AV22TicketImpresora )
               {
                  AV42im_imesc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV62Im_imesc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV42im_imesc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV62Im_imesc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV26TicketOffice )
               {
                  AV43im_office = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV63Im_office_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV43im_office = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV63Im_office_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV32TicketOtros )
               {
                  AV44im_proc = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV64Im_proc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV44im_proc = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV64Im_proc_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV24TicketRouter )
               {
                  AV51im_redes = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV65Im_redes_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV51im_redes = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV65Im_redes_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               if ( AV52TicketIngenieria || AV53TicketAplicacion )
               {
                  AV47im_sistema = context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( ));
                  AV66Im_sistema_GXI = GXDbFile.PathToUrl( context.GetImagePath( "859429df-7e32-40af-aa28-9196f9542d70", "", context.GetTheme( )));
               }
               else
               {
                  AV47im_sistema = context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( ));
                  AV66Im_sistema_GXI = GXDbFile.PathToUrl( context.GetImagePath( "457b2adc-8d9f-4085-9ef5-d4f978256c34", "", context.GetTheme( )));
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            H7G0( false, 1188) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "6c2746e3-8953-4486-b5b0-ab152d2419af", "", context.GetTheme( )), 0, Gx_line+383, 825, Gx_line+1180) ;
            getPrinter().GxDrawRect(17, Gx_line+53, 817, Gx_line+177, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(233, Gx_line+53, 233, Gx_line+177, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(617, Gx_line+53, 617, Gx_line+177, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "58672db5-e41e-4c25-8a7c-9a980bcd6b47", "", context.GetTheme( )), 17, Gx_line+0, 234, Gx_line+213) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "c609efd0-af00-4920-9b0c-7ad03923daad", "", context.GetTheme( )), 667, Gx_line+71, 784, Gx_line+160) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ORDEN DE TRABAJO", 292, Gx_line+83, 542, Gx_line+109, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+177, 817, Gx_line+367, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+217, 817, Gx_line+217, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+250, 817, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+317, 817, Gx_line+317, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+283, 817, Gx_line+283, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(417, Gx_line+177, 417, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nombre del Solicitante:", 25, Gx_line+183, 183, Gx_line+199, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha y hora de solicitud:", 25, Gx_line+283, 197, Gx_line+299, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha de atención:", 25, Gx_line+317, 153, Gx_line+333, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Dependencia:", 425, Gx_line+183, 519, Gx_line+199, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Correo electrónico:", 425, Gx_line+217, 553, Gx_line+233, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Número Memorando/Solicitud:", 25, Gx_line+250, 230, Gx_line+266, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Teléfono:", 25, Gx_line+217, 89, Gx_line+233, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Hora Inicio:", 317, Gx_line+317, 395, Gx_line+333, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Hora Cierre:", 567, Gx_line+317, 649, Gx_line+333, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(308, Gx_line+317, 308, Gx_line+370, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(558, Gx_line+317, 558, Gx_line+370, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+383, 817, Gx_line+1056, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Acción Requerida:", 25, Gx_line+467, 118, Gx_line+481, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Detalle de la solicitud:", 25, Gx_line+367, 133, Gx_line+381, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+367, 817, Gx_line+402, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+467, 817, Gx_line+497, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(33, Gx_line+500, 808, Gx_line+553, 1, 0, 255, 240, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Detalle de la solicitud: ", 25, Gx_line+367, 180, Gx_line+383, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("PROPORCIONE INFORMACIÓN ADICIONAL SI ES NECESARIO", 408, Gx_line+517, 785, Gx_line+531, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("COLOQUE UNA \"X\" EN LA CASILLA CORRESPONDIENTE", 42, Gx_line+517, 391, Gx_line+531, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Acción Requerida:  ", 25, Gx_line+467, 156, Gx_line+483, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+567, 808, Gx_line+597, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+567, 450, Gx_line+597, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("SOLICITUD DE SOPORTE TÉCNICO PARA PC / LAPTOP", 92, Gx_line+567, 387, Gx_line+581, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA ACCESO A FILESERVER ", 108, Gx_line+617, 382, Gx_line+631, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO POR CAMBIOS EN EL SISTEMA OPERATIVO", 42, Gx_line+667, 385, Gx_line+681, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA PERIFÉRICOS", 167, Gx_line+717, 385, Gx_line+731, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA ANTIVIRUS", 183, Gx_line+767, 387, Gx_line+781, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO PARA IMPRESORA Y/O ESCANER", 92, Gx_line+817, 383, Gx_line+831, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("PROBLEMA CON OFFICE O APLICACIONES", 158, Gx_line+867, 384, Gx_line+881, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("ANALISIS / LEVANTAMIENTO DE PROCESOS", 142, Gx_line+917, 383, Gx_line+931, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("SOPORTE TÉCNICO EN REDES O INFRAESTRUCTURA", 92, Gx_line+967, 385, Gx_line+981, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("CAMBIOS EN SISTEMAS Y/O APLICACIONES", 150, Gx_line+1017, 386, Gx_line+1031, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+617, 808, Gx_line+647, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+617, 450, Gx_line+647, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+667, 808, Gx_line+697, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+667, 450, Gx_line+697, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+717, 808, Gx_line+747, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+717, 450, Gx_line+747, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+767, 808, Gx_line+797, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+767, 450, Gx_line+797, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+817, 808, Gx_line+847, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+817, 450, Gx_line+847, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+867, 808, Gx_line+897, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+867, 450, Gx_line+897, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+917, 808, Gx_line+947, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+917, 450, Gx_line+947, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+967, 808, Gx_line+997, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+967, 450, Gx_line+997, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(450, Gx_line+1017, 808, Gx_line+1047, 1, 0, 0, 0, 1, 245, 245, 245, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(408, Gx_line+1017, 450, Gx_line+1047, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "eeaf439c-d9ed-4dae-b56a-a6e959416516", "", context.GetTheme( )), 583, Gx_line+1100, 778, Gx_line+1128) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d3c1f95c-95cc-4ea4-8ad2-fe7171bae301", "", context.GetTheme( )), 50, Gx_line+1100, 153, Gx_line+1130) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15UsuarioNombre, "")), 183, Gx_line+183, 408, Gx_line+216, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16UsuarioDepartamento, "")), 525, Gx_line+183, 808, Gx_line+216, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33UsuarioTelefono), "ZZZZZZZZ9")), 92, Gx_line+217, 184, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13UsuarioEmail, "")), 558, Gx_line+217, 808, Gx_line+250, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV35TicketFechaResponsable, "99/99/9999"), 208, Gx_line+283, 300, Gx_line+298, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV34TicketHoraResponsable, "99:99"), 308, Gx_line+283, 366, Gx_line+298, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17UsuarioRequerimiento, "")), 25, Gx_line+400, 808, Gx_line+467, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37im_pc)) ? AV57Im_pc_GXI : AV37im_pc);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+567, 450, Gx_line+600) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38im_fs)) ? AV58Im_fs_GXI : AV38im_fs);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+617, 450, Gx_line+650) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV39im_so)) ? AV59Im_so_GXI : AV39im_so);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+667, 450, Gx_line+698) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV40im_per)) ? AV60Im_per_GXI : AV40im_per);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+717, 450, Gx_line+750) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41im_av)) ? AV61Im_av_GXI : AV41im_av);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+767, 450, Gx_line+800) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42im_imesc)) ? AV62Im_imesc_GXI : AV42im_imesc);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+817, 450, Gx_line+850) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44im_proc)) ? AV64Im_proc_GXI : AV44im_proc);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+917, 450, Gx_line+950) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47im_sistema)) ? AV66Im_sistema_GXI : AV47im_sistema);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+1017, 450, Gx_line+1050) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43im_office)) ? AV63Im_office_GXI : AV43im_office);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+867, 450, Gx_line+900) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV51im_redes)) ? AV65Im_redes_GXI : AV51im_redes);
            getPrinter().GxDrawBitMap(sImgUrl, 408, Gx_line+967, 450, Gx_line+1000) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+1188);
            H7G0( false, 1169) ;
            getPrinter().GxDrawLine(233, Gx_line+53, 233, Gx_line+177, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ORDEN DE TRABAJO", 292, Gx_line+83, 542, Gx_line+109, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "c609efd0-af00-4920-9b0c-7ad03923daad", "", context.GetTheme( )), 667, Gx_line+71, 784, Gx_line+160) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "58672db5-e41e-4c25-8a7c-9a980bcd6b47", "", context.GetTheme( )), 17, Gx_line+0, 234, Gx_line+213) ;
            getPrinter().GxDrawLine(617, Gx_line+53, 617, Gx_line+177, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+53, 817, Gx_line+177, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+217, 817, Gx_line+465, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+250, 817, Gx_line+285, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+350, 817, Gx_line+385, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajo realizado:", 25, Gx_line+250, 148, Gx_line+266, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TÉCNICO:", 25, Gx_line+217, 86, Gx_line+231, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Observaciones:", 25, Gx_line+350, 128, Gx_line+366, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "6c2746e3-8953-4486-b5b0-ab152d2419af", "", context.GetTheme( )), 0, Gx_line+367, 825, Gx_line+1164) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Firma del solicitante", 342, Gx_line+1033, 489, Gx_line+1050, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "b6288508-259e-4f1e-9d8f-866525664635", "", context.GetTheme( )), 33, Gx_line+683, 808, Gx_line+913) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("USUARIO:", 25, Gx_line+567, 89, Gx_line+581, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+600, 817, Gx_line+653, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+567, 817, Gx_line+656, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(417, Gx_line+500, 600, Gx_line+553, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+500, 200, Gx_line+553, 1, 0, 0, 0, 1, 169, 169, 169, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+500, 817, Gx_line+553, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Basándose en su propia experiencia, por favor valore las siguientes afirmaciones siendo 1 muy pobre y 5 excelente.", 17, Gx_line+617, 702, Gx_line+631, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajo realizado por:", 417, Gx_line+517, 566, Gx_line+533, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Trabajo autorizado por:", 25, Gx_line+517, 182, Gx_line+533, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d3c1f95c-95cc-4ea4-8ad2-fe7171bae301", "", context.GetTheme( )), 58, Gx_line+1100, 161, Gx_line+1130) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "eeaf439c-d9ed-4dae-b56a-a6e959416516", "", context.GetTheme( )), 592, Gx_line+1100, 787, Gx_line+1128) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TicketTecnicoResponsableNombre, "")), 92, Gx_line+217, 809, Gx_line+250, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15UsuarioNombre, "")), 100, Gx_line+567, 808, Gx_line+600, 0+16, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+1169);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7G0( true, 0) ;
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

      protected void H7G0( bool bFoot ,
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
         P007G2_A15UsuarioId = new long[1] ;
         P007G2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         AV18UsuarioHora = (DateTime)(DateTime.MinValue);
         AV37im_pc = "";
         AV57Im_pc_GXI = "";
         AV38im_fs = "";
         AV58Im_fs_GXI = "";
         AV39im_so = "";
         AV59Im_so_GXI = "";
         AV40im_per = "";
         AV60Im_per_GXI = "";
         AV41im_av = "";
         AV61Im_av_GXI = "";
         AV42im_imesc = "";
         AV62Im_imesc_GXI = "";
         AV43im_office = "";
         AV63Im_office_GXI = "";
         AV44im_proc = "";
         AV64Im_proc_GXI = "";
         AV51im_redes = "";
         AV65Im_redes_GXI = "";
         AV47im_sistema = "";
         AV66Im_sistema_GXI = "";
         AV37im_pc = "";
         sImgUrl = "";
         AV38im_fs = "";
         AV39im_so = "";
         AV40im_per = "";
         AV41im_av = "";
         AV42im_imesc = "";
         AV44im_proc = "";
         AV47im_sistema = "";
         AV43im_office = "";
         AV51im_redes = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apcrimprimirsoportetecnico__default(),
            new Object[][] {
                new Object[] {
               P007G2_A15UsuarioId, P007G2_A92UsuarioHora
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV11TicketTecnicoResponsableId ;
      private short GxWebError ;
      private int AV33UsuarioTelefono ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV8TicketId ;
      private long AV9UsuarioId ;
      private long AV10TicketResponsableId ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string sImgUrl ;
      private DateTime AV34TicketHoraResponsable ;
      private DateTime A92UsuarioHora ;
      private DateTime AV18UsuarioHora ;
      private DateTime AV14UsuarioFecha ;
      private DateTime AV35TicketFechaResponsable ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19TicketLaptop ;
      private bool AV20TicketDesktop ;
      private bool AV21TicketMonitor ;
      private bool AV22TicketImpresora ;
      private bool AV23TicketEscaner ;
      private bool AV24TicketRouter ;
      private bool AV25TicketSistemaOperativo ;
      private bool AV26TicketOffice ;
      private bool AV27TicketAntivirus ;
      private bool AV28TicketDiscoDuroExterno ;
      private bool AV29TicketPerifericos ;
      private bool AV30TicketUps ;
      private bool AV31TicketInstalarDataShow ;
      private bool AV32TicketOtros ;
      private bool AV52TicketIngenieria ;
      private bool AV53TicketAplicacion ;
      private string AV12TicketTecnicoResponsableNombre ;
      private string AV13UsuarioEmail ;
      private string AV15UsuarioNombre ;
      private string AV16UsuarioDepartamento ;
      private string AV17UsuarioRequerimiento ;
      private string AV57Im_pc_GXI ;
      private string AV58Im_fs_GXI ;
      private string AV59Im_so_GXI ;
      private string AV60Im_per_GXI ;
      private string AV61Im_av_GXI ;
      private string AV62Im_imesc_GXI ;
      private string AV63Im_office_GXI ;
      private string AV64Im_proc_GXI ;
      private string AV65Im_redes_GXI ;
      private string AV66Im_sistema_GXI ;
      private string AV37im_pc ;
      private string AV38im_fs ;
      private string AV39im_so ;
      private string AV40im_per ;
      private string AV41im_av ;
      private string AV42im_imesc ;
      private string AV43im_office ;
      private string AV44im_proc ;
      private string AV51im_redes ;
      private string AV47im_sistema ;
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
      private long[] P007G2_A15UsuarioId ;
      private DateTime[] P007G2_A92UsuarioHora ;
   }

   public class apcrimprimirsoportetecnico__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007G2;
          prmP007G2 = new Object[] {
          new ParDef("@AV9UsuarioId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007G2", "SELECT [UsuarioId], [UsuarioHora] FROM [Usuario] WHERE [UsuarioId] = @AV9UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007G2,1, GxCacheFrequency.OFF ,false,true )
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
