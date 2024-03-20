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
   public class reportestadoticketusuariowc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "EstadoTicketId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9EstadoTicketId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV16UsuarioNombre = GetPar( "UsuarioNombre");
                  AV18UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV19UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV21UsuarioHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_From")));
                  AV22UsuarioHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_To")));
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

      public reportestadoticketusuariowc( )
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

      public reportestadoticketusuariowc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EstadoTicketId ,
                           string aP1_UsuarioNombre ,
                           DateTime aP2_UsuarioFecha_From ,
                           DateTime aP3_UsuarioFecha_To ,
                           DateTime aP4_UsuarioHora_From ,
                           DateTime aP5_UsuarioHora_To ,
                           string aP6_K2BToolsGenericSearchField ,
                           short aP7_OrderedBy )
      {
         this.AV9EstadoTicketId = aP0_EstadoTicketId;
         this.AV16UsuarioNombre = aP1_UsuarioNombre;
         this.AV18UsuarioFecha_From = aP2_UsuarioFecha_From;
         this.AV19UsuarioFecha_To = aP3_UsuarioFecha_To;
         this.AV21UsuarioHora_From = aP4_UsuarioHora_From;
         this.AV22UsuarioHora_To = aP5_UsuarioHora_To;
         this.AV10K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         this.AV11OrderedBy = aP7_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_EstadoTicketId ,
                                 string aP1_UsuarioNombre ,
                                 DateTime aP2_UsuarioFecha_From ,
                                 DateTime aP3_UsuarioFecha_To ,
                                 DateTime aP4_UsuarioHora_From ,
                                 DateTime aP5_UsuarioHora_To ,
                                 string aP6_K2BToolsGenericSearchField ,
                                 short aP7_OrderedBy )
      {
         reportestadoticketusuariowc objreportestadoticketusuariowc;
         objreportestadoticketusuariowc = new reportestadoticketusuariowc();
         objreportestadoticketusuariowc.AV9EstadoTicketId = aP0_EstadoTicketId;
         objreportestadoticketusuariowc.AV16UsuarioNombre = aP1_UsuarioNombre;
         objreportestadoticketusuariowc.AV18UsuarioFecha_From = aP2_UsuarioFecha_From;
         objreportestadoticketusuariowc.AV19UsuarioFecha_To = aP3_UsuarioFecha_To;
         objreportestadoticketusuariowc.AV21UsuarioHora_From = aP4_UsuarioHora_From;
         objreportestadoticketusuariowc.AV22UsuarioHora_To = aP5_UsuarioHora_To;
         objreportestadoticketusuariowc.AV10K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         objreportestadoticketusuariowc.AV11OrderedBy = aP7_OrderedBy;
         objreportestadoticketusuariowc.context.SetSubmitInitialConfig(context);
         objreportestadoticketusuariowc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportestadoticketusuariowc);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportestadoticketusuariowc)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Usuario",  "Usuario",  "List",  "",  AV33Pgmname) )
            {
               H3G0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3G0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuarios", 325, Gx_line+0, 501, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
               {
                  H3G0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
               {
                  H3G0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Usuario:", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16UsuarioNombre, "")), 77, Gx_line+7, 516, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV18UsuarioFecha_From) || ! (DateTime.MinValue==AV19UsuarioFecha_To) )
               {
                  AV27UsuarioFecha_ReportDescription = context.localUtil.DToC( AV18UsuarioFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV19UsuarioFecha_To, 2, "/");
                  H3G0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Inicio:", 10, Gx_line+7, 106, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27UsuarioFecha_ReportDescription, "")), 114, Gx_line+7, 636, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV21UsuarioHora_From) || ! (DateTime.MinValue==AV22UsuarioHora_To) )
               {
                  AV28UsuarioHora_ReportDescription = context.localUtil.TToC( AV21UsuarioHora_From, 0, 5, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV22UsuarioHora_To, 0, 5, 0, 3, "/", ":", " ");
                  H3G0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora Inicio:", 10, Gx_line+7, 99, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28UsuarioHora_ReportDescription, "")), 107, Gx_line+7, 629, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3G0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id Usuario:", 18, Gx_line+7, 99, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Usuario:", 107, Gx_line+7, 238, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha Inicio:", 246, Gx_line+7, 342, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora Inicio:", 350, Gx_line+7, 439, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Teléfono:", 479, Gx_line+7, 546, Gx_line+22, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV16UsuarioNombre ,
                                                    AV19UsuarioFecha_To ,
                                                    AV18UsuarioFecha_From ,
                                                    AV22UsuarioHora_To ,
                                                    AV21UsuarioHora_From ,
                                                    AV10K2BToolsGenericSearchField ,
                                                    A93UsuarioNombre ,
                                                    A90UsuarioFecha ,
                                                    A92UsuarioHora ,
                                                    A15UsuarioId ,
                                                    A91UsuarioGerencia ,
                                                    A88UsuarioDepartamento ,
                                                    A94UsuarioRequerimiento ,
                                                    A89UsuarioEmail ,
                                                    A95UsuarioTelefono ,
                                                    AV11OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT
                                                    }
               });
               lV16UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV16UsuarioNombre), "%", "");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003G2 */
               pr_default.execute(0, new Object[] {lV16UsuarioNombre, AV19UsuarioFecha_To, AV18UsuarioFecha_From, AV22UsuarioHora_To, AV21UsuarioHora_From, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A95UsuarioTelefono = P003G2_A95UsuarioTelefono[0];
                  A89UsuarioEmail = P003G2_A89UsuarioEmail[0];
                  A94UsuarioRequerimiento = P003G2_A94UsuarioRequerimiento[0];
                  A88UsuarioDepartamento = P003G2_A88UsuarioDepartamento[0];
                  A91UsuarioGerencia = P003G2_A91UsuarioGerencia[0];
                  A15UsuarioId = P003G2_A15UsuarioId[0];
                  A92UsuarioHora = P003G2_A92UsuarioHora[0];
                  A90UsuarioFecha = P003G2_A90UsuarioFecha[0];
                  A93UsuarioNombre = P003G2_A93UsuarioNombre[0];
                  H3G0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")), 18, Gx_line+7, 99, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), 107, Gx_line+7, 238, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A90UsuarioFecha, "99/99/9999"), 246, Gx_line+7, 342, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A92UsuarioHora, "99:99"), 350, Gx_line+7, 439, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")), 479, Gx_line+7, 546, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3G0( true, 0) ;
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

      protected void H3G0( bool bFoot ,
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
                  getPrinter().GxDrawText("Id Usuario:", 18, Gx_line+7, 99, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Usuario:", 107, Gx_line+7, 238, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha Inicio:", 246, Gx_line+7, 342, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Hora Inicio:", 350, Gx_line+7, 439, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Teléfono:", 479, Gx_line+7, 546, Gx_line+22, 2, 0, 0, 1) ;
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
         AV33Pgmname = "";
         AV27UsuarioFecha_ReportDescription = "";
         AV28UsuarioHora_ReportDescription = "";
         scmdbuf = "";
         lV16UsuarioNombre = "";
         lV10K2BToolsGenericSearchField = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         P003G2_A95UsuarioTelefono = new int[1] ;
         P003G2_A89UsuarioEmail = new string[] {""} ;
         P003G2_A94UsuarioRequerimiento = new string[] {""} ;
         P003G2_A88UsuarioDepartamento = new string[] {""} ;
         P003G2_A91UsuarioGerencia = new string[] {""} ;
         P003G2_A15UsuarioId = new long[1] ;
         P003G2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         P003G2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003G2_A93UsuarioNombre = new string[] {""} ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportestadoticketusuariowc__default(),
            new Object[][] {
                new Object[] {
               P003G2_A95UsuarioTelefono, P003G2_A89UsuarioEmail, P003G2_A94UsuarioRequerimiento, P003G2_A88UsuarioDepartamento, P003G2_A91UsuarioGerencia, P003G2_A15UsuarioId, P003G2_A92UsuarioHora, P003G2_A90UsuarioFecha, P003G2_A93UsuarioNombre
               }
            }
         );
         AV33Pgmname = "ReportEstadoTicketUsuarioWC";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV33Pgmname = "ReportEstadoTicketUsuarioWC";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9EstadoTicketId ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A95UsuarioTelefono ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV10K2BToolsGenericSearchField ;
      private string AV33Pgmname ;
      private string AV27UsuarioFecha_ReportDescription ;
      private string AV28UsuarioHora_ReportDescription ;
      private string scmdbuf ;
      private string lV10K2BToolsGenericSearchField ;
      private DateTime AV21UsuarioHora_From ;
      private DateTime AV22UsuarioHora_To ;
      private DateTime A92UsuarioHora ;
      private DateTime AV18UsuarioFecha_From ;
      private DateTime AV19UsuarioFecha_To ;
      private DateTime A90UsuarioFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private string AV16UsuarioNombre ;
      private string lV16UsuarioNombre ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003G2_A95UsuarioTelefono ;
      private string[] P003G2_A89UsuarioEmail ;
      private string[] P003G2_A94UsuarioRequerimiento ;
      private string[] P003G2_A88UsuarioDepartamento ;
      private string[] P003G2_A91UsuarioGerencia ;
      private long[] P003G2_A15UsuarioId ;
      private DateTime[] P003G2_A92UsuarioHora ;
      private DateTime[] P003G2_A90UsuarioFecha ;
      private string[] P003G2_A93UsuarioNombre ;
      private SdtK2BContext AV8Context ;
   }

   public class reportestadoticketusuariowc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003G2( IGxContext context ,
                                             string AV16UsuarioNombre ,
                                             DateTime AV19UsuarioFecha_To ,
                                             DateTime AV18UsuarioFecha_From ,
                                             DateTime AV22UsuarioHora_To ,
                                             DateTime AV21UsuarioHora_From ,
                                             string AV10K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             long A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV11OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UsuarioTelefono], [UsuarioEmail], [UsuarioRequerimiento], [UsuarioDepartamento], [UsuarioGerencia], [UsuarioId], [UsuarioHora], [UsuarioFecha], [UsuarioNombre] FROM [Usuario]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV16UsuarioNombre)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV19UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV19UsuarioFecha_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV18UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV18UsuarioFecha_From)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV22UsuarioHora_To) )
         {
            AddWhere(sWhereString, "([UsuarioHora] <= @AV22UsuarioHora_To)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV21UsuarioHora_From) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV21UsuarioHora_From)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST([UsuarioId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or [UsuarioNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV10K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV10K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV10K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV10K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [UsuarioId]";
         }
         else if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [UsuarioId] DESC";
         }
         else if ( AV11OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre]";
         }
         else if ( AV11OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre] DESC";
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
                     return conditional_P003G2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP003G2;
          prmP003G2 = new Object[] {
          new ParDef("@lV16UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV19UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV18UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV22UsuarioHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV21UsuarioHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
