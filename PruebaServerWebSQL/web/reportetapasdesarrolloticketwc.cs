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
   public class reportetapasdesarrolloticketwc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
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
            gxfirstwebparm = GetFirstPar( "EtapaDesarrolloId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9EtapaDesarrolloId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
                  AV18TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV20TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV21TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
                  AV22UsuarioNombre = GetPar( "UsuarioNombre");
                  AV23EstadoTicketTicketNombre = GetPar( "EstadoTicketTicketNombre");
                  AV25TicketFechaHora_From = context.localUtil.ParseDTimeParm( GetPar( "TicketFechaHora_From"));
                  AV26TicketFechaHora_To = context.localUtil.ParseDTimeParm( GetPar( "TicketFechaHora_To"));
                  AV10K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV11OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public reportetapasdesarrolloticketwc( )
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

      public reportetapasdesarrolloticketwc( IGxContext context )
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

      public void execute( short aP0_EtapaDesarrolloId ,
                           DateTime aP1_TicketFecha_From ,
                           DateTime aP2_TicketFecha_To ,
                           DateTime aP3_TicketHora_From ,
                           DateTime aP4_TicketHora_To ,
                           string aP5_UsuarioNombre ,
                           string aP6_EstadoTicketTicketNombre ,
                           DateTime aP7_TicketFechaHora_From ,
                           DateTime aP8_TicketFechaHora_To ,
                           string aP9_K2BToolsGenericSearchField ,
                           short aP10_OrderedBy )
      {
         this.AV9EtapaDesarrolloId = aP0_EtapaDesarrolloId;
         this.AV17TicketFecha_From = aP1_TicketFecha_From;
         this.AV18TicketFecha_To = aP2_TicketFecha_To;
         this.AV20TicketHora_From = aP3_TicketHora_From;
         this.AV21TicketHora_To = aP4_TicketHora_To;
         this.AV22UsuarioNombre = aP5_UsuarioNombre;
         this.AV23EstadoTicketTicketNombre = aP6_EstadoTicketTicketNombre;
         this.AV25TicketFechaHora_From = aP7_TicketFechaHora_From;
         this.AV26TicketFechaHora_To = aP8_TicketFechaHora_To;
         this.AV10K2BToolsGenericSearchField = aP9_K2BToolsGenericSearchField;
         this.AV11OrderedBy = aP10_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_EtapaDesarrolloId ,
                                 DateTime aP1_TicketFecha_From ,
                                 DateTime aP2_TicketFecha_To ,
                                 DateTime aP3_TicketHora_From ,
                                 DateTime aP4_TicketHora_To ,
                                 string aP5_UsuarioNombre ,
                                 string aP6_EstadoTicketTicketNombre ,
                                 DateTime aP7_TicketFechaHora_From ,
                                 DateTime aP8_TicketFechaHora_To ,
                                 string aP9_K2BToolsGenericSearchField ,
                                 short aP10_OrderedBy )
      {
         reportetapasdesarrolloticketwc objreportetapasdesarrolloticketwc;
         objreportetapasdesarrolloticketwc = new reportetapasdesarrolloticketwc();
         objreportetapasdesarrolloticketwc.AV9EtapaDesarrolloId = aP0_EtapaDesarrolloId;
         objreportetapasdesarrolloticketwc.AV17TicketFecha_From = aP1_TicketFecha_From;
         objreportetapasdesarrolloticketwc.AV18TicketFecha_To = aP2_TicketFecha_To;
         objreportetapasdesarrolloticketwc.AV20TicketHora_From = aP3_TicketHora_From;
         objreportetapasdesarrolloticketwc.AV21TicketHora_To = aP4_TicketHora_To;
         objreportetapasdesarrolloticketwc.AV22UsuarioNombre = aP5_UsuarioNombre;
         objreportetapasdesarrolloticketwc.AV23EstadoTicketTicketNombre = aP6_EstadoTicketTicketNombre;
         objreportetapasdesarrolloticketwc.AV25TicketFechaHora_From = aP7_TicketFechaHora_From;
         objreportetapasdesarrolloticketwc.AV26TicketFechaHora_To = aP8_TicketFechaHora_To;
         objreportetapasdesarrolloticketwc.AV10K2BToolsGenericSearchField = aP9_K2BToolsGenericSearchField;
         objreportetapasdesarrolloticketwc.AV11OrderedBy = aP10_OrderedBy;
         objreportetapasdesarrolloticketwc.context.SetSubmitInitialConfig(context);
         objreportetapasdesarrolloticketwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportetapasdesarrolloticketwc);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportetapasdesarrolloticketwc)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            new k2bgetcontext(context ).execute( out  AV8Context) ;
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  AV38Pgmname) )
            {
               H730( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H730( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ticketes", 325, Gx_line+0, 501, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
               {
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV17TicketFecha_From) || ! (DateTime.MinValue==AV18TicketFecha_To) )
               {
                  AV31TicketFecha_ReportDescription = context.localUtil.DToC( AV17TicketFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV18TicketFecha_To, 2, "/");
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha:", 10, Gx_line+7, 55, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TicketFecha_ReportDescription, "")), 63, Gx_line+7, 585, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV20TicketHora_From) || ! (DateTime.MinValue==AV21TicketHora_To) )
               {
                  AV32TicketHora_ReportDescription = context.localUtil.TToC( AV20TicketHora_From, 0, 5, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV21TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora:", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TicketHora_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22UsuarioNombre)) )
               {
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Usuario", 10, Gx_line+7, 62, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22UsuarioNombre, "")), 70, Gx_line+7, 509, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23EstadoTicketTicketNombre)) )
               {
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Estado Ticket", 10, Gx_line+7, 106, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23EstadoTicketTicketNombre, "")), 114, Gx_line+7, 334, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV25TicketFechaHora_From) || ! (DateTime.MinValue==AV26TicketFechaHora_To) )
               {
                  AV33TicketFechaHora_ReportDescription = context.localUtil.TToC( AV25TicketFechaHora_From, 10, 8, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV26TicketFechaHora_To, 10, 8, 0, 3, "/", ":", " ");
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ticket ", 10, Gx_line+7, 62, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TicketFechaHora_ReportDescription, "")), 70, Gx_line+7, 592, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H730( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RST No.", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora:", 182, Gx_line+7, 219, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Id Usuario", 227, Gx_line+7, 301, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Usuario", 309, Gx_line+7, 440, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Estado Id", 472, Gx_line+7, 539, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Estado Ticket", 547, Gx_line+7, 676, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Last Id", 684, Gx_line+7, 758, Gx_line+22, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV18TicketFecha_To ,
                                                    AV17TicketFecha_From ,
                                                    AV21TicketHora_To ,
                                                    AV20TicketHora_From ,
                                                    AV22UsuarioNombre ,
                                                    AV23EstadoTicketTicketNombre ,
                                                    AV26TicketFechaHora_To ,
                                                    AV25TicketFechaHora_From ,
                                                    AV10K2BToolsGenericSearchField ,
                                                    A46TicketFecha ,
                                                    A48TicketHora ,
                                                    A93UsuarioNombre ,
                                                    A188EstadoTicketTicketNombre ,
                                                    A289TicketFechaHora ,
                                                    A14TicketId ,
                                                    A15UsuarioId ,
                                                    A94UsuarioRequerimiento ,
                                                    A91UsuarioGerencia ,
                                                    A88UsuarioDepartamento ,
                                                    A187EstadoTicketTicketId ,
                                                    A54TicketLastId ,
                                                    A285TicketHoraCaracter ,
                                                    A278TicketUsuarioAsigno ,
                                                    AV11OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                    TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                                    }
               });
               lV22UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV22UsuarioNombre), "%", "");
               lV23EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV23EstadoTicketTicketNombre), "%", "");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P00732 */
               pr_default.execute(0, new Object[] {AV18TicketFecha_To, AV17TicketFecha_From, AV21TicketHora_To, AV20TicketHora_From, lV22UsuarioNombre, lV23EstadoTicketTicketNombre, AV26TicketFechaHora_To, AV25TicketFechaHora_From, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A278TicketUsuarioAsigno = P00732_A278TicketUsuarioAsigno[0];
                  A285TicketHoraCaracter = P00732_A285TicketHoraCaracter[0];
                  A54TicketLastId = P00732_A54TicketLastId[0];
                  A187EstadoTicketTicketId = P00732_A187EstadoTicketTicketId[0];
                  A88UsuarioDepartamento = P00732_A88UsuarioDepartamento[0];
                  A91UsuarioGerencia = P00732_A91UsuarioGerencia[0];
                  A94UsuarioRequerimiento = P00732_A94UsuarioRequerimiento[0];
                  A15UsuarioId = P00732_A15UsuarioId[0];
                  A14TicketId = P00732_A14TicketId[0];
                  A289TicketFechaHora = P00732_A289TicketFechaHora[0];
                  n289TicketFechaHora = P00732_n289TicketFechaHora[0];
                  A188EstadoTicketTicketNombre = P00732_A188EstadoTicketTicketNombre[0];
                  A93UsuarioNombre = P00732_A93UsuarioNombre[0];
                  A48TicketHora = P00732_A48TicketHora[0];
                  A46TicketFecha = P00732_A46TicketFecha[0];
                  A188EstadoTicketTicketNombre = P00732_A188EstadoTicketTicketNombre[0];
                  A88UsuarioDepartamento = P00732_A88UsuarioDepartamento[0];
                  A91UsuarioGerencia = P00732_A91UsuarioGerencia[0];
                  A94UsuarioRequerimiento = P00732_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P00732_A93UsuarioNombre[0];
                  H730( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 18, Gx_line+7, 92, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A46TicketFecha, "99/99/9999"), 100, Gx_line+7, 174, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A48TicketHora, "99:99"), 182, Gx_line+7, 219, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), 227, Gx_line+7, 301, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), 309, Gx_line+7, 440, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A187EstadoTicketTicketId), "ZZZ9")), 472, Gx_line+7, 539, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A188EstadoTicketTicketNombre, "")), 547, Gx_line+7, 676, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")), 684, Gx_line+7, 758, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H730( true, 0) ;
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

      protected void H730( bool bFoot ,
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
                  getPrinter().GxDrawLine(50, Gx_line+0, 775, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 383, Gx_line+33, 398, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("{{Pages}}", 417, Gx_line+33, 432, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Page", 353, Gx_line+33, 383, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("of", 400, Gx_line+33, 415, Gx_line+47, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
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
               getPrinter().GxDrawBitMap(context.GetImagePath( "b7ea4f08-f7a5-4fad-b32e-2c1b1255fdbb", "", context.GetTheme( )), 0, Gx_line+0, 75, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 608, Gx_line+0, 653, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date", 575, Gx_line+0, 608, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Page", 720, Gx_line+0, 750, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("of", 767, Gx_line+0, 782, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("{{Pages}}", 783, Gx_line+0, 798, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 750, Gx_line+0, 765, Gx_line+14, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+71);
               if ( GxHdr3 )
               {
                  getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("RST No.", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Hora:", 182, Gx_line+7, 219, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Id Usuario", 227, Gx_line+7, 301, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Usuario", 309, Gx_line+7, 440, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Estado Id", 472, Gx_line+7, 539, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Estado Ticket", 547, Gx_line+7, 676, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Last Id", 684, Gx_line+7, 758, Gx_line+22, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
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
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Courier New", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Courier New", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV8Context = new SdtK2BContext(context);
         AV38Pgmname = "";
         AV31TicketFecha_ReportDescription = "";
         AV32TicketHora_ReportDescription = "";
         AV33TicketFechaHora_ReportDescription = "";
         scmdbuf = "";
         lV22UsuarioNombre = "";
         lV23EstadoTicketTicketNombre = "";
         lV10K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A188EstadoTicketTicketNombre = "";
         A289TicketFechaHora = (DateTime)(DateTime.MinValue);
         A94UsuarioRequerimiento = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A285TicketHoraCaracter = "";
         A278TicketUsuarioAsigno = "";
         P00732_A278TicketUsuarioAsigno = new string[] {""} ;
         P00732_A285TicketHoraCaracter = new string[] {""} ;
         P00732_A54TicketLastId = new long[1] ;
         P00732_A187EstadoTicketTicketId = new short[1] ;
         P00732_A88UsuarioDepartamento = new string[] {""} ;
         P00732_A91UsuarioGerencia = new string[] {""} ;
         P00732_A94UsuarioRequerimiento = new string[] {""} ;
         P00732_A15UsuarioId = new short[1] ;
         P00732_A14TicketId = new long[1] ;
         P00732_A289TicketFechaHora = new DateTime[] {DateTime.MinValue} ;
         P00732_n289TicketFechaHora = new bool[] {false} ;
         P00732_A188EstadoTicketTicketNombre = new string[] {""} ;
         P00732_A93UsuarioNombre = new string[] {""} ;
         P00732_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P00732_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportetapasdesarrolloticketwc__default(),
            new Object[][] {
                new Object[] {
               P00732_A278TicketUsuarioAsigno, P00732_A285TicketHoraCaracter, P00732_A54TicketLastId, P00732_A187EstadoTicketTicketId, P00732_A88UsuarioDepartamento, P00732_A91UsuarioGerencia, P00732_A94UsuarioRequerimiento, P00732_A15UsuarioId, P00732_A14TicketId, P00732_A289TicketFechaHora,
               P00732_n289TicketFechaHora, P00732_A188EstadoTicketTicketNombre, P00732_A93UsuarioNombre, P00732_A48TicketHora, P00732_A46TicketFecha
               }
            }
         );
         AV38Pgmname = "ReportEtapasDesarrolloTicketWC";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV38Pgmname = "ReportEtapasDesarrolloTicketWC";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9EtapaDesarrolloId ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private short A15UsuarioId ;
      private short A187EstadoTicketTicketId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A14TicketId ;
      private long A54TicketLastId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV10K2BToolsGenericSearchField ;
      private string AV38Pgmname ;
      private string AV31TicketFecha_ReportDescription ;
      private string AV32TicketHora_ReportDescription ;
      private string AV33TicketFechaHora_ReportDescription ;
      private string scmdbuf ;
      private string lV10K2BToolsGenericSearchField ;
      private string A285TicketHoraCaracter ;
      private DateTime AV20TicketHora_From ;
      private DateTime AV21TicketHora_To ;
      private DateTime AV25TicketFechaHora_From ;
      private DateTime AV26TicketFechaHora_To ;
      private DateTime A48TicketHora ;
      private DateTime A289TicketFechaHora ;
      private DateTime AV17TicketFecha_From ;
      private DateTime AV18TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private bool n289TicketFechaHora ;
      private string AV22UsuarioNombre ;
      private string AV23EstadoTicketTicketNombre ;
      private string lV22UsuarioNombre ;
      private string lV23EstadoTicketTicketNombre ;
      private string A93UsuarioNombre ;
      private string A188EstadoTicketTicketNombre ;
      private string A94UsuarioRequerimiento ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A278TicketUsuarioAsigno ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00732_A278TicketUsuarioAsigno ;
      private string[] P00732_A285TicketHoraCaracter ;
      private long[] P00732_A54TicketLastId ;
      private short[] P00732_A187EstadoTicketTicketId ;
      private string[] P00732_A88UsuarioDepartamento ;
      private string[] P00732_A91UsuarioGerencia ;
      private string[] P00732_A94UsuarioRequerimiento ;
      private short[] P00732_A15UsuarioId ;
      private long[] P00732_A14TicketId ;
      private DateTime[] P00732_A289TicketFechaHora ;
      private bool[] P00732_n289TicketFechaHora ;
      private string[] P00732_A188EstadoTicketTicketNombre ;
      private string[] P00732_A93UsuarioNombre ;
      private DateTime[] P00732_A48TicketHora ;
      private DateTime[] P00732_A46TicketFecha ;
      private SdtK2BContext AV8Context ;
   }

   public class reportetapasdesarrolloticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00732( IGxContext context ,
                                             DateTime AV18TicketFecha_To ,
                                             DateTime AV17TicketFecha_From ,
                                             DateTime AV21TicketHora_To ,
                                             DateTime AV20TicketHora_From ,
                                             string AV22UsuarioNombre ,
                                             string AV23EstadoTicketTicketNombre ,
                                             DateTime AV26TicketFechaHora_To ,
                                             DateTime AV25TicketFechaHora_From ,
                                             string AV10K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             DateTime A289TicketFechaHora ,
                                             long A14TicketId ,
                                             short A15UsuarioId ,
                                             string A94UsuarioRequerimiento ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             short A187EstadoTicketTicketId ,
                                             long A54TicketLastId ,
                                             string A285TicketHoraCaracter ,
                                             string A278TicketUsuarioAsigno ,
                                             short AV11OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[19];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TicketUsuarioAsigno], T1.[TicketHoraCaracter], T1.[TicketLastId], T1.[EstadoTicketTicketId] AS EstadoTicketTicketId, T3.[UsuarioDepartamento], T3.[UsuarioGerencia], T3.[UsuarioRequerimiento], T1.[UsuarioId], T1.[TicketId], T1.[TicketFechaHora], T2.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T3.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha] FROM (([Ticket] T1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = T1.[EstadoTicketTicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T1.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV18TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV18TicketFecha_To)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV17TicketFecha_From)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV21TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV21TicketHora_To)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV20TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV20TicketHora_From)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioNombre] like @lV22UsuarioNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoTicketNombre] like @lV23EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TicketFechaHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFechaHora] <= @AV26TicketFechaHora_To)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TicketFechaHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFechaHora] >= @AV25TicketFechaHora_From)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[UsuarioId] AS decimal(4,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV10K2BToolsGenericSearchField + '%' or T3.[UsuarioGerencia] like '%' + @lV10K2BToolsGenericSearchField + '%' or T3.[UsuarioDepartamento] like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[EstadoTicketTicketId] AS decimal(4,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or T2.[EstadoTicketNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketLastId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or T1.[TicketHoraCaracter] like '%' + @lV10K2BToolsGenericSearchField + '%' or T1.[TicketUsuarioAsigno] like '%' + @lV10K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
            GXv_int1[15] = 1;
            GXv_int1[16] = 1;
            GXv_int1[17] = 1;
            GXv_int1[18] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV11OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV11OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00732(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00732;
          prmP00732 = new Object[] {
          new ParDef("@AV18TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV17TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV21TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV20TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV22UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV23EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@AV26TicketFechaHora_To",GXType.DateTime,10,8) ,
          new ParDef("@AV25TicketFechaHora_From",GXType.DateTime,10,8) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00732", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00732,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 8);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                return;
       }
    }

 }

}
