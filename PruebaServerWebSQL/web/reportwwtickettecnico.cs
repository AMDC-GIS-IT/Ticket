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
   public class reportwwtickettecnico : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "TicketTecnicoFecha_From");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16TicketTecnicoFecha_From = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketTecnicoFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketTecnicoFecha_To"));
                  AV19TicketTecnicoHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketTecnicoHora_From")));
                  AV20TicketTecnicoHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketTecnicoHora_To")));
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

      public reportwwtickettecnico( )
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

      public reportwwtickettecnico( IGxContext context )
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

      public void execute( DateTime aP0_TicketTecnicoFecha_From ,
                           DateTime aP1_TicketTecnicoFecha_To ,
                           DateTime aP2_TicketTecnicoHora_From ,
                           DateTime aP3_TicketTecnicoHora_To ,
                           string aP4_K2BToolsGenericSearchField ,
                           short aP5_OrderedBy )
      {
         this.AV16TicketTecnicoFecha_From = aP0_TicketTecnicoFecha_From;
         this.AV17TicketTecnicoFecha_To = aP1_TicketTecnicoFecha_To;
         this.AV19TicketTecnicoHora_From = aP2_TicketTecnicoHora_From;
         this.AV20TicketTecnicoHora_To = aP3_TicketTecnicoHora_To;
         this.AV9K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP5_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_TicketTecnicoFecha_From ,
                                 DateTime aP1_TicketTecnicoFecha_To ,
                                 DateTime aP2_TicketTecnicoHora_From ,
                                 DateTime aP3_TicketTecnicoHora_To ,
                                 string aP4_K2BToolsGenericSearchField ,
                                 short aP5_OrderedBy )
      {
         reportwwtickettecnico objreportwwtickettecnico;
         objreportwwtickettecnico = new reportwwtickettecnico();
         objreportwwtickettecnico.AV16TicketTecnicoFecha_From = aP0_TicketTecnicoFecha_From;
         objreportwwtickettecnico.AV17TicketTecnicoFecha_To = aP1_TicketTecnicoFecha_To;
         objreportwwtickettecnico.AV19TicketTecnicoHora_From = aP2_TicketTecnicoHora_From;
         objreportwwtickettecnico.AV20TicketTecnicoHora_To = aP3_TicketTecnicoHora_To;
         objreportwwtickettecnico.AV9K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         objreportwwtickettecnico.AV10OrderedBy = aP5_OrderedBy;
         objreportwwtickettecnico.context.SetSubmitInitialConfig(context);
         objreportwwtickettecnico.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwtickettecnico);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwtickettecnico)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "TicketTecnico",  "TicketTecnico",  "List",  "",  AV31Pgmname) )
            {
               H3V0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3V0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ticket tecnicos", 249, Gx_line+0, 578, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H3V0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV16TicketTecnicoFecha_From) || ! (DateTime.MinValue==AV17TicketTecnicoFecha_To) )
               {
                  AV25TicketTecnicoFecha_ReportDescription = context.localUtil.DToC( AV16TicketTecnicoFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV17TicketTecnicoFecha_To, 2, "/");
                  H3V0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TicketTecnicoFecha_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV19TicketTecnicoHora_From) || ! (DateTime.MinValue==AV20TicketTecnicoHora_To) )
               {
                  AV26TicketTecnicoHora_ReportDescription = context.localUtil.TToC( AV19TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " ") + " - " + context.localUtil.TToC( AV20TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " ");
                  H3V0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Hora", 10, Gx_line+7, 40, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TicketTecnicoHora_ReportDescription, "")), 48, Gx_line+7, 570, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3V0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ticket Tecnico", 18, Gx_line+7, 121, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha", 129, Gx_line+7, 203, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Hora", 211, Gx_line+7, 248, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Id Ticket", 256, Gx_line+7, 330, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Ticket Responsable Id", 338, Gx_line+7, 492, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Responsable Nombre", 500, Gx_line+7, 631, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Id Usuario", 639, Gx_line+7, 713, Gx_line+22, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV17TicketTecnicoFecha_To ,
                                                    AV16TicketTecnicoFecha_From ,
                                                    AV20TicketTecnicoHora_To ,
                                                    AV19TicketTecnicoHora_From ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A69TicketTecnicoFecha ,
                                                    A71TicketTecnicoHora ,
                                                    A18TicketTecnicoId ,
                                                    A14TicketId ,
                                                    A16TicketResponsableId ,
                                                    A30ResponsableNombre ,
                                                    A15UsuarioId ,
                                                    A93UsuarioNombre ,
                                                    A94UsuarioRequerimiento ,
                                                    A88UsuarioDepartamento ,
                                                    A74TicketTecnicoInventarioSerie ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                                    TypeConstants.SHORT
                                                    }
               });
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003V2 */
               pr_default.execute(0, new Object[] {AV17TicketTecnicoFecha_To, AV16TicketTecnicoFecha_From, AV20TicketTecnicoHora_To, AV19TicketTecnicoHora_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A6ResponsableId = P003V2_A6ResponsableId[0];
                  A74TicketTecnicoInventarioSerie = P003V2_A74TicketTecnicoInventarioSerie[0];
                  A88UsuarioDepartamento = P003V2_A88UsuarioDepartamento[0];
                  A94UsuarioRequerimiento = P003V2_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P003V2_A93UsuarioNombre[0];
                  A15UsuarioId = P003V2_A15UsuarioId[0];
                  A30ResponsableNombre = P003V2_A30ResponsableNombre[0];
                  A16TicketResponsableId = P003V2_A16TicketResponsableId[0];
                  A14TicketId = P003V2_A14TicketId[0];
                  A18TicketTecnicoId = P003V2_A18TicketTecnicoId[0];
                  A71TicketTecnicoHora = P003V2_A71TicketTecnicoHora[0];
                  A69TicketTecnicoFecha = P003V2_A69TicketTecnicoFecha[0];
                  A30ResponsableNombre = P003V2_A30ResponsableNombre[0];
                  A15UsuarioId = P003V2_A15UsuarioId[0];
                  A88UsuarioDepartamento = P003V2_A88UsuarioDepartamento[0];
                  A94UsuarioRequerimiento = P003V2_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P003V2_A93UsuarioNombre[0];
                  H3V0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9")), 18, Gx_line+7, 121, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A69TicketTecnicoFecha, "99/99/9999"), 129, Gx_line+7, 203, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A71TicketTecnicoHora, "99:99"), 211, Gx_line+7, 248, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 256, Gx_line+7, 330, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")), 338, Gx_line+7, 492, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A30ResponsableNombre, "")), 500, Gx_line+7, 631, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), 639, Gx_line+7, 713, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3V0( true, 0) ;
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

      protected void H3V0( bool bFoot ,
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
                  getPrinter().GxDrawText("Ticket Tecnico", 18, Gx_line+7, 121, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha", 129, Gx_line+7, 203, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Hora", 211, Gx_line+7, 248, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Id Ticket", 256, Gx_line+7, 330, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Ticket Responsable Id", 338, Gx_line+7, 492, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Responsable Nombre", 500, Gx_line+7, 631, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Id Usuario", 639, Gx_line+7, 713, Gx_line+22, 2, 0, 0, 1) ;
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
         AV31Pgmname = "";
         AV25TicketTecnicoFecha_ReportDescription = "";
         AV26TicketTecnicoHora_ReportDescription = "";
         scmdbuf = "";
         lV9K2BToolsGenericSearchField = "";
         A69TicketTecnicoFecha = DateTime.MinValue;
         A71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         A30ResponsableNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A88UsuarioDepartamento = "";
         A74TicketTecnicoInventarioSerie = "";
         P003V2_A6ResponsableId = new short[1] ;
         P003V2_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         P003V2_A88UsuarioDepartamento = new string[] {""} ;
         P003V2_A94UsuarioRequerimiento = new string[] {""} ;
         P003V2_A93UsuarioNombre = new string[] {""} ;
         P003V2_A15UsuarioId = new short[1] ;
         P003V2_A30ResponsableNombre = new string[] {""} ;
         P003V2_A16TicketResponsableId = new long[1] ;
         P003V2_A14TicketId = new long[1] ;
         P003V2_A18TicketTecnicoId = new long[1] ;
         P003V2_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         P003V2_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportwwtickettecnico__default(),
            new Object[][] {
                new Object[] {
               P003V2_A6ResponsableId, P003V2_A74TicketTecnicoInventarioSerie, P003V2_A88UsuarioDepartamento, P003V2_A94UsuarioRequerimiento, P003V2_A93UsuarioNombre, P003V2_A15UsuarioId, P003V2_A30ResponsableNombre, P003V2_A16TicketResponsableId, P003V2_A14TicketId, P003V2_A18TicketTecnicoId,
               P003V2_A71TicketTecnicoHora, P003V2_A69TicketTecnicoFecha
               }
            }
         );
         AV31Pgmname = "ReportWWTicketTecnico";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV31Pgmname = "ReportWWTicketTecnico";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private short A15UsuarioId ;
      private short A6ResponsableId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A18TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV31Pgmname ;
      private string AV25TicketTecnicoFecha_ReportDescription ;
      private string AV26TicketTecnicoHora_ReportDescription ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV19TicketTecnicoHora_From ;
      private DateTime AV20TicketTecnicoHora_To ;
      private DateTime A71TicketTecnicoHora ;
      private DateTime AV16TicketTecnicoFecha_From ;
      private DateTime AV17TicketTecnicoFecha_To ;
      private DateTime A69TicketTecnicoFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private string A30ResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A88UsuarioDepartamento ;
      private string A74TicketTecnicoInventarioSerie ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003V2_A6ResponsableId ;
      private string[] P003V2_A74TicketTecnicoInventarioSerie ;
      private string[] P003V2_A88UsuarioDepartamento ;
      private string[] P003V2_A94UsuarioRequerimiento ;
      private string[] P003V2_A93UsuarioNombre ;
      private short[] P003V2_A15UsuarioId ;
      private string[] P003V2_A30ResponsableNombre ;
      private long[] P003V2_A16TicketResponsableId ;
      private long[] P003V2_A14TicketId ;
      private long[] P003V2_A18TicketTecnicoId ;
      private DateTime[] P003V2_A71TicketTecnicoHora ;
      private DateTime[] P003V2_A69TicketTecnicoFecha ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwtickettecnico__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003V2( IGxContext context ,
                                             DateTime AV17TicketTecnicoFecha_To ,
                                             DateTime AV16TicketTecnicoFecha_From ,
                                             DateTime AV20TicketTecnicoHora_To ,
                                             DateTime AV19TicketTecnicoHora_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A30ResponsableNombre ,
                                             short A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ResponsableId], T1.[TicketTecnicoInventarioSerie], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T4.[UsuarioNombre], T3.[UsuarioId], T2.[ResponsableNombre], T1.[TicketResponsableId], T1.[TicketId], T1.[TicketTecnicoId], T1.[TicketTecnicoHora], T1.[TicketTecnicoFecha] FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV17TicketTecnicoFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] <= @AV17TicketTecnicoFecha_To)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV16TicketTecnicoFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] >= @AV16TicketTecnicoFecha_From)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV20TicketTecnicoHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] <= @AV20TicketTecnicoHora_To)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV19TicketTecnicoHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] >= @AV19TicketTecnicoHora_From)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[ResponsableNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T3.[UsuarioId] AS decimal(4,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T4.[UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T4.[UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%' or T4.[UsuarioDepartamento] like '%' + @lV9K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoId]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoId] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoFecha]";
         }
         else if ( AV10OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoFecha] DESC";
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
                     return conditional_P003V2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmP003V2;
          prmP003V2 = new Object[] {
          new ParDef("@AV17TicketTecnicoFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV16TicketTecnicoFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV20TicketTecnicoHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV19TicketTecnicoHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                return;
       }
    }

 }

}
