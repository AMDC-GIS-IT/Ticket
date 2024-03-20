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
   public class reportusuarioticketwc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "UsuarioId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9UsuarioId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
                  AV18TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV20TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV21TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
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

      public reportusuarioticketwc( )
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

      public reportusuarioticketwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           DateTime aP1_TicketFecha_From ,
                           DateTime aP2_TicketFecha_To ,
                           DateTime aP3_TicketHora_From ,
                           DateTime aP4_TicketHora_To ,
                           string aP5_K2BToolsGenericSearchField ,
                           short aP6_OrderedBy )
      {
         this.AV9UsuarioId = aP0_UsuarioId;
         this.AV17TicketFecha_From = aP1_TicketFecha_From;
         this.AV18TicketFecha_To = aP2_TicketFecha_To;
         this.AV20TicketHora_From = aP3_TicketHora_From;
         this.AV21TicketHora_To = aP4_TicketHora_To;
         this.AV10K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         this.AV11OrderedBy = aP6_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 DateTime aP1_TicketFecha_From ,
                                 DateTime aP2_TicketFecha_To ,
                                 DateTime aP3_TicketHora_From ,
                                 DateTime aP4_TicketHora_To ,
                                 string aP5_K2BToolsGenericSearchField ,
                                 short aP6_OrderedBy )
      {
         reportusuarioticketwc objreportusuarioticketwc;
         objreportusuarioticketwc = new reportusuarioticketwc();
         objreportusuarioticketwc.AV9UsuarioId = aP0_UsuarioId;
         objreportusuarioticketwc.AV17TicketFecha_From = aP1_TicketFecha_From;
         objreportusuarioticketwc.AV18TicketFecha_To = aP2_TicketFecha_To;
         objreportusuarioticketwc.AV20TicketHora_From = aP3_TicketHora_From;
         objreportusuarioticketwc.AV21TicketHora_To = aP4_TicketHora_To;
         objreportusuarioticketwc.AV10K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         objreportusuarioticketwc.AV11OrderedBy = aP6_OrderedBy;
         objreportusuarioticketwc.context.SetSubmitInitialConfig(context);
         objreportusuarioticketwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportusuarioticketwc);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportusuarioticketwc)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  AV42Pgmname) )
            {
               H3L0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3L0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ticketes", 325, Gx_line+0, 501, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
               {
                  H3L0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV17TicketFecha_From) || ! (DateTime.MinValue==AV18TicketFecha_To) )
               {
                  AV33TicketFecha_ReportDescription = context.localUtil.DToC( AV17TicketFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV18TicketFecha_To, 2, "/");
                  H3L0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha:", 10, Gx_line+7, 55, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TicketFecha_ReportDescription, "")), 63, Gx_line+7, 585, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV20TicketHora_From) || ! (DateTime.MinValue==AV21TicketHora_To) )
               {
                  AV34TicketHora_ReportDescription = context.localUtil.TToC( AV20TicketHora_From, 0, 5, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV21TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
                  H3L0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora:", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TicketHora_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3L0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RST No.", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora:", 182, Gx_line+7, 219, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Last Id", 227, Gx_line+7, 301, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("aptop", 309, Gx_line+7, 346, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Desktop", 354, Gx_line+7, 406, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Monitor", 414, Gx_line+7, 466, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Impresora", 474, Gx_line+7, 541, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Escaner", 549, Gx_line+7, 601, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Operativo", 617, Gx_line+7, 684, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Office", 692, Gx_line+7, 737, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Diseño", 761, Gx_line+7, 806, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV18TicketFecha_To ,
                                                    AV17TicketFecha_From ,
                                                    AV21TicketHora_To ,
                                                    AV20TicketHora_From ,
                                                    AV10K2BToolsGenericSearchField ,
                                                    A46TicketFecha ,
                                                    A48TicketHora ,
                                                    A14TicketId ,
                                                    A54TicketLastId ,
                                                    AV11OrderedBy ,
                                                    AV9UsuarioId ,
                                                    A15UsuarioId } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                                    TypeConstants.LONG
                                                    }
               });
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               lV10K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV10K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003L2 */
               pr_default.execute(0, new Object[] {AV9UsuarioId, AV18TicketFecha_To, AV17TicketFecha_From, AV21TicketHora_To, AV20TicketHora_From, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A15UsuarioId = P003L2_A15UsuarioId[0];
                  A54TicketLastId = P003L2_A54TicketLastId[0];
                  A14TicketId = P003L2_A14TicketId[0];
                  A48TicketHora = P003L2_A48TicketHora[0];
                  A46TicketFecha = P003L2_A46TicketFecha[0];
                  A53TicketLaptop = P003L2_A53TicketLaptop[0];
                  n53TicketLaptop = P003L2_n53TicketLaptop[0];
                  A42TicketDesktop = P003L2_A42TicketDesktop[0];
                  n42TicketDesktop = P003L2_n42TicketDesktop[0];
                  A55TicketMonitor = P003L2_A55TicketMonitor[0];
                  n55TicketMonitor = P003L2_n55TicketMonitor[0];
                  A50TicketImpresora = P003L2_A50TicketImpresora[0];
                  n50TicketImpresora = P003L2_n50TicketImpresora[0];
                  A45TicketEscaner = P003L2_A45TicketEscaner[0];
                  n45TicketEscaner = P003L2_n45TicketEscaner[0];
                  A60TicketSistemaOperativo = P003L2_A60TicketSistemaOperativo[0];
                  n60TicketSistemaOperativo = P003L2_n60TicketSistemaOperativo[0];
                  A56TicketOffice = P003L2_A56TicketOffice[0];
                  n56TicketOffice = P003L2_n56TicketOffice[0];
                  A44TicketDisenio = P003L2_A44TicketDisenio[0];
                  n44TicketDisenio = P003L2_n44TicketDisenio[0];
                  AV26Grid_TicketLaptop = (A53TicketLaptop ? "Si" : "No");
                  AV27Grid_TicketDesktop = (A42TicketDesktop ? "Si" : "No");
                  AV28Grid_TicketMonitor = (A55TicketMonitor ? "Si" : "No");
                  AV29Grid_TicketImpresora = (A50TicketImpresora ? "Si" : "No");
                  AV30Grid_TicketEscaner = (A45TicketEscaner ? "Si" : "No");
                  AV35Grid_TicketSistemaOperativo = (A60TicketSistemaOperativo ? "Si" : "No");
                  AV36Grid_TicketOffice = (A56TicketOffice ? "Si" : "No");
                  AV37Grid_TicketDisenio = (A44TicketDisenio ? "Si" : "No");
                  H3L0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 18, Gx_line+7, 92, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A46TicketFecha, "99/99/9999"), 100, Gx_line+7, 174, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A48TicketHora, "99:99"), 182, Gx_line+7, 219, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")), 227, Gx_line+7, 301, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Grid_TicketLaptop, "")), 309, Gx_line+7, 346, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Grid_TicketDesktop, "")), 354, Gx_line+7, 406, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Grid_TicketMonitor, "")), 414, Gx_line+7, 466, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Grid_TicketImpresora, "")), 474, Gx_line+7, 541, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Grid_TicketEscaner, "")), 549, Gx_line+7, 601, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Grid_TicketSistemaOperativo, "")), 617, Gx_line+7, 684, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Grid_TicketOffice, "")), 692, Gx_line+7, 737, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Grid_TicketDisenio, "")), 761, Gx_line+7, 806, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3L0( true, 0) ;
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

      protected void H3L0( bool bFoot ,
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
                  getPrinter().GxDrawText("Last Id", 227, Gx_line+7, 301, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("aptop", 309, Gx_line+7, 346, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Desktop", 354, Gx_line+7, 406, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Monitor", 414, Gx_line+7, 466, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Impresora", 474, Gx_line+7, 541, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Escaner", 549, Gx_line+7, 601, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Operativo", 617, Gx_line+7, 684, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Office", 692, Gx_line+7, 737, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Diseño", 761, Gx_line+7, 806, Gx_line+22, 0, 0, 0, 1) ;
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
         AV42Pgmname = "";
         AV33TicketFecha_ReportDescription = "";
         AV34TicketHora_ReportDescription = "";
         scmdbuf = "";
         lV10K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         P003L2_A15UsuarioId = new long[1] ;
         P003L2_A54TicketLastId = new long[1] ;
         P003L2_A14TicketId = new long[1] ;
         P003L2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P003L2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         P003L2_A53TicketLaptop = new bool[] {false} ;
         P003L2_n53TicketLaptop = new bool[] {false} ;
         P003L2_A42TicketDesktop = new bool[] {false} ;
         P003L2_n42TicketDesktop = new bool[] {false} ;
         P003L2_A55TicketMonitor = new bool[] {false} ;
         P003L2_n55TicketMonitor = new bool[] {false} ;
         P003L2_A50TicketImpresora = new bool[] {false} ;
         P003L2_n50TicketImpresora = new bool[] {false} ;
         P003L2_A45TicketEscaner = new bool[] {false} ;
         P003L2_n45TicketEscaner = new bool[] {false} ;
         P003L2_A60TicketSistemaOperativo = new bool[] {false} ;
         P003L2_n60TicketSistemaOperativo = new bool[] {false} ;
         P003L2_A56TicketOffice = new bool[] {false} ;
         P003L2_n56TicketOffice = new bool[] {false} ;
         P003L2_A44TicketDisenio = new bool[] {false} ;
         P003L2_n44TicketDisenio = new bool[] {false} ;
         AV26Grid_TicketLaptop = "";
         AV27Grid_TicketDesktop = "";
         AV28Grid_TicketMonitor = "";
         AV29Grid_TicketImpresora = "";
         AV30Grid_TicketEscaner = "";
         AV35Grid_TicketSistemaOperativo = "";
         AV36Grid_TicketOffice = "";
         AV37Grid_TicketDisenio = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportusuarioticketwc__default(),
            new Object[][] {
                new Object[] {
               P003L2_A15UsuarioId, P003L2_A54TicketLastId, P003L2_A14TicketId, P003L2_A48TicketHora, P003L2_A46TicketFecha, P003L2_A53TicketLaptop, P003L2_n53TicketLaptop, P003L2_A42TicketDesktop, P003L2_n42TicketDesktop, P003L2_A55TicketMonitor,
               P003L2_n55TicketMonitor, P003L2_A50TicketImpresora, P003L2_n50TicketImpresora, P003L2_A45TicketEscaner, P003L2_n45TicketEscaner, P003L2_A60TicketSistemaOperativo, P003L2_n60TicketSistemaOperativo, P003L2_A56TicketOffice, P003L2_n56TicketOffice, P003L2_A44TicketDisenio,
               P003L2_n44TicketDisenio
               }
            }
         );
         AV42Pgmname = "ReportUsuarioTicketWC";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV42Pgmname = "ReportUsuarioTicketWC";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV9UsuarioId ;
      private long A14TicketId ;
      private long A54TicketLastId ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV10K2BToolsGenericSearchField ;
      private string AV42Pgmname ;
      private string AV33TicketFecha_ReportDescription ;
      private string AV34TicketHora_ReportDescription ;
      private string scmdbuf ;
      private string lV10K2BToolsGenericSearchField ;
      private string AV26Grid_TicketLaptop ;
      private string AV27Grid_TicketDesktop ;
      private string AV28Grid_TicketMonitor ;
      private string AV29Grid_TicketImpresora ;
      private string AV30Grid_TicketEscaner ;
      private string AV35Grid_TicketSistemaOperativo ;
      private string AV36Grid_TicketOffice ;
      private string AV37Grid_TicketDisenio ;
      private DateTime AV20TicketHora_From ;
      private DateTime AV21TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime AV17TicketFecha_From ;
      private DateTime AV18TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
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
      private bool A60TicketSistemaOperativo ;
      private bool n60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool n56TicketOffice ;
      private bool A44TicketDisenio ;
      private bool n44TicketDisenio ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003L2_A15UsuarioId ;
      private long[] P003L2_A54TicketLastId ;
      private long[] P003L2_A14TicketId ;
      private DateTime[] P003L2_A48TicketHora ;
      private DateTime[] P003L2_A46TicketFecha ;
      private bool[] P003L2_A53TicketLaptop ;
      private bool[] P003L2_n53TicketLaptop ;
      private bool[] P003L2_A42TicketDesktop ;
      private bool[] P003L2_n42TicketDesktop ;
      private bool[] P003L2_A55TicketMonitor ;
      private bool[] P003L2_n55TicketMonitor ;
      private bool[] P003L2_A50TicketImpresora ;
      private bool[] P003L2_n50TicketImpresora ;
      private bool[] P003L2_A45TicketEscaner ;
      private bool[] P003L2_n45TicketEscaner ;
      private bool[] P003L2_A60TicketSistemaOperativo ;
      private bool[] P003L2_n60TicketSistemaOperativo ;
      private bool[] P003L2_A56TicketOffice ;
      private bool[] P003L2_n56TicketOffice ;
      private bool[] P003L2_A44TicketDisenio ;
      private bool[] P003L2_n44TicketDisenio ;
      private SdtK2BContext AV8Context ;
   }

   public class reportusuarioticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003L2( IGxContext context ,
                                             DateTime AV18TicketFecha_To ,
                                             DateTime AV17TicketFecha_From ,
                                             DateTime AV21TicketHora_To ,
                                             DateTime AV20TicketHora_From ,
                                             string AV10K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             long A14TicketId ,
                                             long A54TicketLastId ,
                                             short AV11OrderedBy ,
                                             long AV9UsuarioId ,
                                             long A15UsuarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UsuarioId], [TicketLastId], [TicketId], [TicketHora], [TicketFecha], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketSistemaOperativo], [TicketOffice], [TicketDisenio] FROM [Ticket]";
         AddWhere(sWhereString, "([UsuarioId] = @AV9UsuarioId)");
         if ( ! (DateTime.MinValue==AV18TicketFecha_To) )
         {
            AddWhere(sWhereString, "([TicketFecha] <= @AV18TicketFecha_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TicketFecha_From) )
         {
            AddWhere(sWhereString, "([TicketFecha] >= @AV17TicketFecha_From)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV21TicketHora_To) )
         {
            AddWhere(sWhereString, "([TicketHora] <= @AV21TicketHora_To)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV20TicketHora_From) )
         {
            AddWhere(sWhereString, "([TicketHora] >= @AV20TicketHora_From)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST([TicketId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST([TicketLastId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [TicketId]";
         }
         else if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TicketId] DESC";
         }
         else if ( AV11OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [TicketFecha]";
         }
         else if ( AV11OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [TicketFecha] DESC";
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
                     return conditional_P003L2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
          Object[] prmP003L2;
          prmP003L2 = new Object[] {
          new ParDef("@AV9UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@AV18TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV17TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV21TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV20TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((bool[]) buf[9])[0] = rslt.getBool(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((bool[]) buf[11])[0] = rslt.getBool(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((bool[]) buf[13])[0] = rslt.getBool(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((bool[]) buf[17])[0] = rslt.getBool(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((bool[]) buf[19])[0] = rslt.getBool(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
