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
   public class reportwwsatisfaccion : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "SatisfaccionFecha_From");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16SatisfaccionFecha_From = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
                  AV19UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV20UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV21SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
                  AV22SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
                  AV23SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
                  AV24SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
                  AV25SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
                  AV26SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
                  AV33UsuarioNombre = GetPar( "UsuarioNombre");
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

      public reportwwsatisfaccion( )
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

      public reportwwsatisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_SatisfaccionFecha_From ,
                           DateTime aP1_SatisfaccionFecha_To ,
                           DateTime aP2_UsuarioFecha_From ,
                           DateTime aP3_UsuarioFecha_To ,
                           string aP4_SatisfaccionResueltoNombre ,
                           string aP5_SatisfaccionTecnicoProblemaNombre ,
                           string aP6_SatisfaccionTecnicoCompetenteNombre ,
                           string aP7_SatisfaccionTecnicoProfesionalismoNombre ,
                           string aP8_SatisfaccionTiempoNombre ,
                           string aP9_SatisfaccionAtencionNombre ,
                           string aP10_UsuarioNombre ,
                           string aP11_K2BToolsGenericSearchField ,
                           short aP12_OrderedBy )
      {
         this.AV16SatisfaccionFecha_From = aP0_SatisfaccionFecha_From;
         this.AV17SatisfaccionFecha_To = aP1_SatisfaccionFecha_To;
         this.AV19UsuarioFecha_From = aP2_UsuarioFecha_From;
         this.AV20UsuarioFecha_To = aP3_UsuarioFecha_To;
         this.AV21SatisfaccionResueltoNombre = aP4_SatisfaccionResueltoNombre;
         this.AV22SatisfaccionTecnicoProblemaNombre = aP5_SatisfaccionTecnicoProblemaNombre;
         this.AV23SatisfaccionTecnicoCompetenteNombre = aP6_SatisfaccionTecnicoCompetenteNombre;
         this.AV24SatisfaccionTecnicoProfesionalismoNombre = aP7_SatisfaccionTecnicoProfesionalismoNombre;
         this.AV25SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         this.AV26SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         this.AV33UsuarioNombre = aP10_UsuarioNombre;
         this.AV9K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP12_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_SatisfaccionFecha_From ,
                                 DateTime aP1_SatisfaccionFecha_To ,
                                 DateTime aP2_UsuarioFecha_From ,
                                 DateTime aP3_UsuarioFecha_To ,
                                 string aP4_SatisfaccionResueltoNombre ,
                                 string aP5_SatisfaccionTecnicoProblemaNombre ,
                                 string aP6_SatisfaccionTecnicoCompetenteNombre ,
                                 string aP7_SatisfaccionTecnicoProfesionalismoNombre ,
                                 string aP8_SatisfaccionTiempoNombre ,
                                 string aP9_SatisfaccionAtencionNombre ,
                                 string aP10_UsuarioNombre ,
                                 string aP11_K2BToolsGenericSearchField ,
                                 short aP12_OrderedBy )
      {
         reportwwsatisfaccion objreportwwsatisfaccion;
         objreportwwsatisfaccion = new reportwwsatisfaccion();
         objreportwwsatisfaccion.AV16SatisfaccionFecha_From = aP0_SatisfaccionFecha_From;
         objreportwwsatisfaccion.AV17SatisfaccionFecha_To = aP1_SatisfaccionFecha_To;
         objreportwwsatisfaccion.AV19UsuarioFecha_From = aP2_UsuarioFecha_From;
         objreportwwsatisfaccion.AV20UsuarioFecha_To = aP3_UsuarioFecha_To;
         objreportwwsatisfaccion.AV21SatisfaccionResueltoNombre = aP4_SatisfaccionResueltoNombre;
         objreportwwsatisfaccion.AV22SatisfaccionTecnicoProblemaNombre = aP5_SatisfaccionTecnicoProblemaNombre;
         objreportwwsatisfaccion.AV23SatisfaccionTecnicoCompetenteNombre = aP6_SatisfaccionTecnicoCompetenteNombre;
         objreportwwsatisfaccion.AV24SatisfaccionTecnicoProfesionalismoNombre = aP7_SatisfaccionTecnicoProfesionalismoNombre;
         objreportwwsatisfaccion.AV25SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         objreportwwsatisfaccion.AV26SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         objreportwwsatisfaccion.AV33UsuarioNombre = aP10_UsuarioNombre;
         objreportwwsatisfaccion.AV9K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         objreportwwsatisfaccion.AV10OrderedBy = aP12_OrderedBy;
         objreportwwsatisfaccion.context.SetSubmitInitialConfig(context);
         objreportwwsatisfaccion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwsatisfaccion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwsatisfaccion)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  AV38Pgmname) )
            {
               H3X0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no est� autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3X0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Satisfacciones", 260, Gx_line+0, 567, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H3X0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("B�squeda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV16SatisfaccionFecha_From) || ! (DateTime.MinValue==AV17SatisfaccionFecha_To) )
               {
                  AV31SatisfaccionFecha_ReportDescription = context.localUtil.DToC( AV16SatisfaccionFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV17SatisfaccionFecha_To, 2, "/");
                  H3X0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Encuesta:", 10, Gx_line+7, 120, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31SatisfaccionFecha_ReportDescription, "")), 128, Gx_line+7, 650, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV19UsuarioFecha_From) || ! (DateTime.MinValue==AV20UsuarioFecha_To) )
               {
                  AV32UsuarioFecha_ReportDescription = context.localUtil.DToC( AV19UsuarioFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV20UsuarioFecha_To, 2, "/");
                  H3X0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32UsuarioFecha_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33UsuarioNombre)) )
               {
                  H3X0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Usuario", 10, Gx_line+7, 62, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33UsuarioNombre, "")), 70, Gx_line+7, 509, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3X0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RST No.", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Id TR:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("T�cnico", 182, Gx_line+7, 313, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Usuario", 321, Gx_line+7, 456, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha Inicio:", 464, Gx_line+7, 560, Gx_line+22, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV17SatisfaccionFecha_To ,
                                                    AV16SatisfaccionFecha_From ,
                                                    AV20UsuarioFecha_To ,
                                                    AV19UsuarioFecha_From ,
                                                    AV21SatisfaccionResueltoNombre ,
                                                    AV22SatisfaccionTecnicoProblemaNombre ,
                                                    AV23SatisfaccionTecnicoCompetenteNombre ,
                                                    AV24SatisfaccionTecnicoProfesionalismoNombre ,
                                                    AV25SatisfaccionTiempoNombre ,
                                                    AV26SatisfaccionAtencionNombre ,
                                                    AV33UsuarioNombre ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A32SatisfaccionFecha ,
                                                    A90UsuarioFecha ,
                                                    A33SatisfaccionResueltoNombre ,
                                                    A36SatisfaccionTecnicoProblemaNombre ,
                                                    A35SatisfaccionTecnicoCompetenteNombre ,
                                                    A37SatisfaccionTecnicoProfesionalismoNombre ,
                                                    A38SatisfaccionTiempoNombre ,
                                                    A31SatisfaccionAtencionNombre ,
                                                    A93UsuarioNombre ,
                                                    A14TicketId ,
                                                    A16TicketResponsableId ,
                                                    A199TicketTecnicoResponsableNombre ,
                                                    A94UsuarioRequerimiento ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                                    }
               });
               lV21SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV21SatisfaccionResueltoNombre), "%", "");
               lV22SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV22SatisfaccionTecnicoProblemaNombre), "%", "");
               lV23SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV23SatisfaccionTecnicoCompetenteNombre), "%", "");
               lV24SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV24SatisfaccionTecnicoProfesionalismoNombre), "%", "");
               lV25SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV25SatisfaccionTiempoNombre), "%", "");
               lV26SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV26SatisfaccionAtencionNombre), "%", "");
               lV33UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV33UsuarioNombre), "%", "");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003X2 */
               pr_default.execute(0, new Object[] {AV17SatisfaccionFecha_To, AV16SatisfaccionFecha_From, AV20UsuarioFecha_To, AV19UsuarioFecha_From, lV21SatisfaccionResueltoNombre, lV22SatisfaccionTecnicoProblemaNombre, lV23SatisfaccionTecnicoCompetenteNombre, lV24SatisfaccionTecnicoProfesionalismoNombre, lV25SatisfaccionTiempoNombre, lV26SatisfaccionAtencionNombre, lV33UsuarioNombre, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A198TicketTecnicoResponsableId = P003X2_A198TicketTecnicoResponsableId[0];
                  A15UsuarioId = P003X2_A15UsuarioId[0];
                  A8SatisfaccionResueltoId = P003X2_A8SatisfaccionResueltoId[0];
                  A9SatisfaccionTecnicoProblemaId = P003X2_A9SatisfaccionTecnicoProblemaId[0];
                  A10SatisfaccionTecnicoCompetenteId = P003X2_A10SatisfaccionTecnicoCompetenteId[0];
                  A11SatisfaccionTecnicoProfesionalismoId = P003X2_A11SatisfaccionTecnicoProfesionalismoId[0];
                  A12SatisfaccionTiempoId = P003X2_A12SatisfaccionTiempoId[0];
                  A13SatisfaccionAtencionId = P003X2_A13SatisfaccionAtencionId[0];
                  A94UsuarioRequerimiento = P003X2_A94UsuarioRequerimiento[0];
                  A199TicketTecnicoResponsableNombre = P003X2_A199TicketTecnicoResponsableNombre[0];
                  A16TicketResponsableId = P003X2_A16TicketResponsableId[0];
                  A14TicketId = P003X2_A14TicketId[0];
                  A93UsuarioNombre = P003X2_A93UsuarioNombre[0];
                  A31SatisfaccionAtencionNombre = P003X2_A31SatisfaccionAtencionNombre[0];
                  A38SatisfaccionTiempoNombre = P003X2_A38SatisfaccionTiempoNombre[0];
                  A37SatisfaccionTecnicoProfesionalismoNombre = P003X2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
                  A35SatisfaccionTecnicoCompetenteNombre = P003X2_A35SatisfaccionTecnicoCompetenteNombre[0];
                  A36SatisfaccionTecnicoProblemaNombre = P003X2_A36SatisfaccionTecnicoProblemaNombre[0];
                  A33SatisfaccionResueltoNombre = P003X2_A33SatisfaccionResueltoNombre[0];
                  A90UsuarioFecha = P003X2_A90UsuarioFecha[0];
                  A32SatisfaccionFecha = P003X2_A32SatisfaccionFecha[0];
                  A7SatisfaccionId = P003X2_A7SatisfaccionId[0];
                  A33SatisfaccionResueltoNombre = P003X2_A33SatisfaccionResueltoNombre[0];
                  A36SatisfaccionTecnicoProblemaNombre = P003X2_A36SatisfaccionTecnicoProblemaNombre[0];
                  A35SatisfaccionTecnicoCompetenteNombre = P003X2_A35SatisfaccionTecnicoCompetenteNombre[0];
                  A37SatisfaccionTecnicoProfesionalismoNombre = P003X2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
                  A38SatisfaccionTiempoNombre = P003X2_A38SatisfaccionTiempoNombre[0];
                  A31SatisfaccionAtencionNombre = P003X2_A31SatisfaccionAtencionNombre[0];
                  A15UsuarioId = P003X2_A15UsuarioId[0];
                  A94UsuarioRequerimiento = P003X2_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P003X2_A93UsuarioNombre[0];
                  A90UsuarioFecha = P003X2_A90UsuarioFecha[0];
                  A198TicketTecnicoResponsableId = P003X2_A198TicketTecnicoResponsableId[0];
                  A199TicketTecnicoResponsableNombre = P003X2_A199TicketTecnicoResponsableNombre[0];
                  H3X0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 18, Gx_line+7, 92, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")), 100, Gx_line+7, 174, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A199TicketTecnicoResponsableNombre, "")), 182, Gx_line+7, 313, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), 321, Gx_line+7, 456, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A90UsuarioFecha, "99/99/9999"), 464, Gx_line+7, 560, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3X0( true, 0) ;
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

      protected void H3X0( bool bFoot ,
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
                  getPrinter().GxDrawText("Id TR:", 100, Gx_line+7, 174, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("T�cnico", 182, Gx_line+7, 313, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Usuario", 321, Gx_line+7, 456, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha Inicio:", 464, Gx_line+7, 560, Gx_line+22, 2, 0, 0, 1) ;
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
         AV31SatisfaccionFecha_ReportDescription = "";
         AV32UsuarioFecha_ReportDescription = "";
         scmdbuf = "";
         lV21SatisfaccionResueltoNombre = "";
         lV22SatisfaccionTecnicoProblemaNombre = "";
         lV23SatisfaccionTecnicoCompetenteNombre = "";
         lV24SatisfaccionTecnicoProfesionalismoNombre = "";
         lV25SatisfaccionTiempoNombre = "";
         lV26SatisfaccionAtencionNombre = "";
         lV33UsuarioNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A93UsuarioNombre = "";
         A199TicketTecnicoResponsableNombre = "";
         A94UsuarioRequerimiento = "";
         P003X2_A198TicketTecnicoResponsableId = new short[1] ;
         P003X2_A15UsuarioId = new long[1] ;
         P003X2_A8SatisfaccionResueltoId = new short[1] ;
         P003X2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         P003X2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         P003X2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         P003X2_A12SatisfaccionTiempoId = new short[1] ;
         P003X2_A13SatisfaccionAtencionId = new short[1] ;
         P003X2_A94UsuarioRequerimiento = new string[] {""} ;
         P003X2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         P003X2_A16TicketResponsableId = new long[1] ;
         P003X2_A14TicketId = new long[1] ;
         P003X2_A93UsuarioNombre = new string[] {""} ;
         P003X2_A31SatisfaccionAtencionNombre = new string[] {""} ;
         P003X2_A38SatisfaccionTiempoNombre = new string[] {""} ;
         P003X2_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         P003X2_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         P003X2_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         P003X2_A33SatisfaccionResueltoNombre = new string[] {""} ;
         P003X2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003X2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         P003X2_A7SatisfaccionId = new long[1] ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportwwsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               P003X2_A198TicketTecnicoResponsableId, P003X2_A15UsuarioId, P003X2_A8SatisfaccionResueltoId, P003X2_A9SatisfaccionTecnicoProblemaId, P003X2_A10SatisfaccionTecnicoCompetenteId, P003X2_A11SatisfaccionTecnicoProfesionalismoId, P003X2_A12SatisfaccionTiempoId, P003X2_A13SatisfaccionAtencionId, P003X2_A94UsuarioRequerimiento, P003X2_A199TicketTecnicoResponsableNombre,
               P003X2_A16TicketResponsableId, P003X2_A14TicketId, P003X2_A93UsuarioNombre, P003X2_A31SatisfaccionAtencionNombre, P003X2_A38SatisfaccionTiempoNombre, P003X2_A37SatisfaccionTecnicoProfesionalismoNombre, P003X2_A35SatisfaccionTecnicoCompetenteNombre, P003X2_A36SatisfaccionTecnicoProblemaNombre, P003X2_A33SatisfaccionResueltoNombre, P003X2_A90UsuarioFecha,
               P003X2_A32SatisfaccionFecha, P003X2_A7SatisfaccionId
               }
            }
         );
         AV38Pgmname = "ReportWWSatisfaccion";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV38Pgmname = "ReportWWSatisfaccion";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private short A198TicketTecnicoResponsableId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long A7SatisfaccionId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV38Pgmname ;
      private string AV31SatisfaccionFecha_ReportDescription ;
      private string AV32UsuarioFecha_ReportDescription ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV16SatisfaccionFecha_From ;
      private DateTime AV17SatisfaccionFecha_To ;
      private DateTime AV19UsuarioFecha_From ;
      private DateTime AV20UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private string AV21SatisfaccionResueltoNombre ;
      private string AV22SatisfaccionTecnicoProblemaNombre ;
      private string AV23SatisfaccionTecnicoCompetenteNombre ;
      private string AV24SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV25SatisfaccionTiempoNombre ;
      private string AV26SatisfaccionAtencionNombre ;
      private string AV33UsuarioNombre ;
      private string lV21SatisfaccionResueltoNombre ;
      private string lV22SatisfaccionTecnicoProblemaNombre ;
      private string lV23SatisfaccionTecnicoCompetenteNombre ;
      private string lV24SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV25SatisfaccionTiempoNombre ;
      private string lV26SatisfaccionAtencionNombre ;
      private string lV33UsuarioNombre ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A93UsuarioNombre ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A94UsuarioRequerimiento ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003X2_A198TicketTecnicoResponsableId ;
      private long[] P003X2_A15UsuarioId ;
      private short[] P003X2_A8SatisfaccionResueltoId ;
      private short[] P003X2_A9SatisfaccionTecnicoProblemaId ;
      private short[] P003X2_A10SatisfaccionTecnicoCompetenteId ;
      private short[] P003X2_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] P003X2_A12SatisfaccionTiempoId ;
      private short[] P003X2_A13SatisfaccionAtencionId ;
      private string[] P003X2_A94UsuarioRequerimiento ;
      private string[] P003X2_A199TicketTecnicoResponsableNombre ;
      private long[] P003X2_A16TicketResponsableId ;
      private long[] P003X2_A14TicketId ;
      private string[] P003X2_A93UsuarioNombre ;
      private string[] P003X2_A31SatisfaccionAtencionNombre ;
      private string[] P003X2_A38SatisfaccionTiempoNombre ;
      private string[] P003X2_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string[] P003X2_A35SatisfaccionTecnicoCompetenteNombre ;
      private string[] P003X2_A36SatisfaccionTecnicoProblemaNombre ;
      private string[] P003X2_A33SatisfaccionResueltoNombre ;
      private DateTime[] P003X2_A90UsuarioFecha ;
      private DateTime[] P003X2_A32SatisfaccionFecha ;
      private long[] P003X2_A7SatisfaccionId ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003X2( IGxContext context ,
                                             DateTime AV17SatisfaccionFecha_To ,
                                             DateTime AV16SatisfaccionFecha_From ,
                                             DateTime AV20UsuarioFecha_To ,
                                             DateTime AV19UsuarioFecha_From ,
                                             string AV21SatisfaccionResueltoNombre ,
                                             string AV22SatisfaccionTecnicoProblemaNombre ,
                                             string AV23SatisfaccionTecnicoCompetenteNombre ,
                                             string AV24SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV25SatisfaccionTiempoNombre ,
                                             string AV26SatisfaccionAtencionNombre ,
                                             string AV33UsuarioNombre ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T10.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T8.[UsuarioId], T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T9.[UsuarioRequerimiento], T11.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketResponsableId], T1.[TicketId], T9.[UsuarioNombre], T7.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T2.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T9.[UsuarioFecha], T1.[SatisfaccionFecha], T1.[SatisfaccionId] FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [Ticket] T8 ON T8.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T9 ON T9.[UsuarioId]";
         scmdbuf += " = T8.[UsuarioId]) INNER JOIN [TicketResponsable] T10 ON T10.[TicketId] = T1.[TicketId] AND T10.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T11 ON T11.[ResponsableId] = T10.[TicketTecnicoResponsableId])";
         if ( ! (DateTime.MinValue==AV17SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV17SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV16SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV16SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV20UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] <= @AV20UsuarioFecha_To)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV19UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] >= @AV19UsuarioFecha_From)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV21SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV22SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV23SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV24SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV25SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV26SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioNombre] like @lV33UsuarioNombre)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T11.[ResponsableNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T9.[UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T9.[UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
            GXv_int1[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV10OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha] DESC";
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
                     return conditional_P003X2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP003X2;
          prmP003X2 = new Object[] {
          new ParDef("@AV17SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV16SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV20UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV19UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV21SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV22SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV23SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV24SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV25SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV26SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV33UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003X2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(20);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(21);
                ((long[]) buf[21])[0] = rslt.getLong(22);
                return;
       }
    }

 }

}
