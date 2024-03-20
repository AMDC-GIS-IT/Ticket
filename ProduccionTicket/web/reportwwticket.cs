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
   public class reportwwticket : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "TicketFecha_From");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16TicketFecha_From = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV19TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV20TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
                  AV21UsuarioNombre = GetPar( "UsuarioNombre");
                  AV29EstadoTicketTicketNombre = GetPar( "EstadoTicketTicketNombre");
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV10OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public reportwwticket( )
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

      public reportwwticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_TicketFecha_From ,
                           DateTime aP1_TicketFecha_To ,
                           DateTime aP2_TicketHora_From ,
                           DateTime aP3_TicketHora_To ,
                           string aP4_UsuarioNombre ,
                           string aP5_EstadoTicketTicketNombre ,
                           string aP6_K2BToolsGenericSearchField ,
                           short aP7_OrderedBy )
      {
         this.AV16TicketFecha_From = aP0_TicketFecha_From;
         this.AV17TicketFecha_To = aP1_TicketFecha_To;
         this.AV19TicketHora_From = aP2_TicketHora_From;
         this.AV20TicketHora_To = aP3_TicketHora_To;
         this.AV21UsuarioNombre = aP4_UsuarioNombre;
         this.AV29EstadoTicketTicketNombre = aP5_EstadoTicketTicketNombre;
         this.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP7_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_TicketFecha_From ,
                                 DateTime aP1_TicketFecha_To ,
                                 DateTime aP2_TicketHora_From ,
                                 DateTime aP3_TicketHora_To ,
                                 string aP4_UsuarioNombre ,
                                 string aP5_EstadoTicketTicketNombre ,
                                 string aP6_K2BToolsGenericSearchField ,
                                 short aP7_OrderedBy )
      {
         reportwwticket objreportwwticket;
         objreportwwticket = new reportwwticket();
         objreportwwticket.AV16TicketFecha_From = aP0_TicketFecha_From;
         objreportwwticket.AV17TicketFecha_To = aP1_TicketFecha_To;
         objreportwwticket.AV19TicketHora_From = aP2_TicketHora_From;
         objreportwwticket.AV20TicketHora_To = aP3_TicketHora_To;
         objreportwwticket.AV21UsuarioNombre = aP4_UsuarioNombre;
         objreportwwticket.AV29EstadoTicketTicketNombre = aP5_EstadoTicketTicketNombre;
         objreportwwticket.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         objreportwwticket.AV10OrderedBy = aP7_OrderedBy;
         objreportwwticket.context.SetSubmitInitialConfig(context);
         objreportwwticket.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwticket);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwticket)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  AV34Pgmname) )
            {
               H3S0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3S0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ticketes", 325, Gx_line+0, 501, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV16TicketFecha_From) || ! (DateTime.MinValue==AV17TicketFecha_To) )
               {
                  AV27TicketFecha_ReportDescription = context.localUtil.DToC( AV16TicketFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV17TicketFecha_To, 2, "/");
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha:", 10, Gx_line+7, 55, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TicketFecha_ReportDescription, "")), 63, Gx_line+7, 585, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV19TicketHora_From) || ! (DateTime.MinValue==AV20TicketHora_To) )
               {
                  AV28TicketHora_ReportDescription = context.localUtil.TToC( AV19TicketHora_From, 0, 5, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV20TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora:", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TicketHora_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21UsuarioNombre)) )
               {
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Usuario", 10, Gx_line+7, 62, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21UsuarioNombre, "")), 70, Gx_line+7, 509, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EstadoTicketTicketNombre)) )
               {
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ticket", 10, Gx_line+7, 55, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29EstadoTicketTicketNombre, "")), 63, Gx_line+7, 283, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3S0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RST No.", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora:", 182, Gx_line+7, 219, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Usuario", 227, Gx_line+7, 358, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Ticket", 374, Gx_line+7, 503, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV17TicketFecha_To ,
                                                    AV16TicketFecha_From ,
                                                    AV20TicketHora_To ,
                                                    AV19TicketHora_From ,
                                                    AV21UsuarioNombre ,
                                                    AV29EstadoTicketTicketNombre ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A46TicketFecha ,
                                                    A48TicketHora ,
                                                    A93UsuarioNombre ,
                                                    A188EstadoTicketTicketNombre ,
                                                    A14TicketId ,
                                                    A94UsuarioRequerimiento ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                                    }
               });
               lV21UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV21UsuarioNombre), "%", "");
               lV29EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV29EstadoTicketTicketNombre), "%", "");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003S2 */
               pr_default.execute(0, new Object[] {AV17TicketFecha_To, AV16TicketFecha_From, AV20TicketHora_To, AV19TicketHora_From, lV21UsuarioNombre, lV29EstadoTicketTicketNombre, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A15UsuarioId = P003S2_A15UsuarioId[0];
                  A187EstadoTicketTicketId = P003S2_A187EstadoTicketTicketId[0];
                  A94UsuarioRequerimiento = P003S2_A94UsuarioRequerimiento[0];
                  A14TicketId = P003S2_A14TicketId[0];
                  A188EstadoTicketTicketNombre = P003S2_A188EstadoTicketTicketNombre[0];
                  A93UsuarioNombre = P003S2_A93UsuarioNombre[0];
                  A48TicketHora = P003S2_A48TicketHora[0];
                  A46TicketFecha = P003S2_A46TicketFecha[0];
                  A94UsuarioRequerimiento = P003S2_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P003S2_A93UsuarioNombre[0];
                  A188EstadoTicketTicketNombre = P003S2_A188EstadoTicketTicketNombre[0];
                  H3S0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 18, Gx_line+7, 92, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A46TicketFecha, "99/99/9999"), 100, Gx_line+7, 174, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A48TicketHora, "99:99"), 182, Gx_line+7, 219, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), 227, Gx_line+7, 358, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A188EstadoTicketTicketNombre, "")), 374, Gx_line+7, 503, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3S0( true, 0) ;
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

      protected void H3S0( bool bFoot ,
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
                  getPrinter().GxDrawText("Usuario", 227, Gx_line+7, 358, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Ticket", 374, Gx_line+7, 503, Gx_line+22, 0, 0, 0, 1) ;
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
         AV34Pgmname = "";
         AV27TicketFecha_ReportDescription = "";
         AV28TicketHora_ReportDescription = "";
         scmdbuf = "";
         lV21UsuarioNombre = "";
         lV29EstadoTicketTicketNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A188EstadoTicketTicketNombre = "";
         A94UsuarioRequerimiento = "";
         P003S2_A15UsuarioId = new long[1] ;
         P003S2_A187EstadoTicketTicketId = new short[1] ;
         P003S2_A94UsuarioRequerimiento = new string[] {""} ;
         P003S2_A14TicketId = new long[1] ;
         P003S2_A188EstadoTicketTicketNombre = new string[] {""} ;
         P003S2_A93UsuarioNombre = new string[] {""} ;
         P003S2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P003S2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportwwticket__default(),
            new Object[][] {
                new Object[] {
               P003S2_A15UsuarioId, P003S2_A187EstadoTicketTicketId, P003S2_A94UsuarioRequerimiento, P003S2_A14TicketId, P003S2_A188EstadoTicketTicketNombre, P003S2_A93UsuarioNombre, P003S2_A48TicketHora, P003S2_A46TicketFecha
               }
            }
         );
         AV34Pgmname = "ReportWWTicket";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV34Pgmname = "ReportWWTicket";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private short A187EstadoTicketTicketId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV34Pgmname ;
      private string AV27TicketFecha_ReportDescription ;
      private string AV28TicketHora_ReportDescription ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV19TicketHora_From ;
      private DateTime AV20TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime AV16TicketFecha_From ;
      private DateTime AV17TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private string AV21UsuarioNombre ;
      private string AV29EstadoTicketTicketNombre ;
      private string lV21UsuarioNombre ;
      private string lV29EstadoTicketTicketNombre ;
      private string A93UsuarioNombre ;
      private string A188EstadoTicketTicketNombre ;
      private string A94UsuarioRequerimiento ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003S2_A15UsuarioId ;
      private short[] P003S2_A187EstadoTicketTicketId ;
      private string[] P003S2_A94UsuarioRequerimiento ;
      private long[] P003S2_A14TicketId ;
      private string[] P003S2_A188EstadoTicketTicketNombre ;
      private string[] P003S2_A93UsuarioNombre ;
      private DateTime[] P003S2_A48TicketHora ;
      private DateTime[] P003S2_A46TicketFecha ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwticket__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003S2( IGxContext context ,
                                             DateTime AV17TicketFecha_To ,
                                             DateTime AV16TicketFecha_From ,
                                             DateTime AV20TicketHora_To ,
                                             DateTime AV19TicketHora_From ,
                                             string AV21UsuarioNombre ,
                                             string AV29EstadoTicketTicketNombre ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[UsuarioId], T1.[EstadoTicketTicketId] AS EstadoTicketTicketId, T2.[UsuarioRequerimiento], T1.[TicketId], T3.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T2.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha] FROM (([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId]) INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = T1.[EstadoTicketTicketId])";
         if ( ! (DateTime.MinValue==AV17TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV17TicketFecha_To)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV16TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV16TicketFecha_From)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV20TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV20TicketHora_To)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV19TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV19TicketHora_From)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV21UsuarioNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoTicketNombre] like @lV29EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[EstadoTicketNombre] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV10OrderedBy == 3 )
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
                     return conditional_P003S2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP003S2;
          prmP003S2 = new Object[] {
          new ParDef("@AV17TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV16TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV20TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV19TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV21UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV29EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003S2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                return;
       }
    }

 }

}
