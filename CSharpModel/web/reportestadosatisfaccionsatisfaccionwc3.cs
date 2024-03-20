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
   public class reportestadosatisfaccionsatisfaccionwc3 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "SatisfaccionTecnicoProfesionalismoId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
                  AV18SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
                  AV20UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV21UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV22SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
                  AV23SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
                  AV24SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
                  AV25SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
                  AV26SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
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

      public reportestadosatisfaccionsatisfaccionwc3( )
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

      public reportestadosatisfaccionsatisfaccionwc3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SatisfaccionTecnicoProfesionalismoId ,
                           DateTime aP1_SatisfaccionFecha_From ,
                           DateTime aP2_SatisfaccionFecha_To ,
                           DateTime aP3_UsuarioFecha_From ,
                           DateTime aP4_UsuarioFecha_To ,
                           string aP5_SatisfaccionResueltoNombre ,
                           string aP6_SatisfaccionTecnicoProblemaNombre ,
                           string aP7_SatisfaccionTecnicoCompetenteNombre ,
                           string aP8_SatisfaccionTiempoNombre ,
                           string aP9_SatisfaccionAtencionNombre ,
                           string aP10_K2BToolsGenericSearchField ,
                           short aP11_OrderedBy )
      {
         this.AV9SatisfaccionTecnicoProfesionalismoId = aP0_SatisfaccionTecnicoProfesionalismoId;
         this.AV17SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         this.AV18SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         this.AV20UsuarioFecha_From = aP3_UsuarioFecha_From;
         this.AV21UsuarioFecha_To = aP4_UsuarioFecha_To;
         this.AV22SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         this.AV23SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         this.AV24SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         this.AV25SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         this.AV26SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         this.AV10K2BToolsGenericSearchField = aP10_K2BToolsGenericSearchField;
         this.AV11OrderedBy = aP11_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_SatisfaccionTecnicoProfesionalismoId ,
                                 DateTime aP1_SatisfaccionFecha_From ,
                                 DateTime aP2_SatisfaccionFecha_To ,
                                 DateTime aP3_UsuarioFecha_From ,
                                 DateTime aP4_UsuarioFecha_To ,
                                 string aP5_SatisfaccionResueltoNombre ,
                                 string aP6_SatisfaccionTecnicoProblemaNombre ,
                                 string aP7_SatisfaccionTecnicoCompetenteNombre ,
                                 string aP8_SatisfaccionTiempoNombre ,
                                 string aP9_SatisfaccionAtencionNombre ,
                                 string aP10_K2BToolsGenericSearchField ,
                                 short aP11_OrderedBy )
      {
         reportestadosatisfaccionsatisfaccionwc3 objreportestadosatisfaccionsatisfaccionwc3;
         objreportestadosatisfaccionsatisfaccionwc3 = new reportestadosatisfaccionsatisfaccionwc3();
         objreportestadosatisfaccionsatisfaccionwc3.AV9SatisfaccionTecnicoProfesionalismoId = aP0_SatisfaccionTecnicoProfesionalismoId;
         objreportestadosatisfaccionsatisfaccionwc3.AV17SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         objreportestadosatisfaccionsatisfaccionwc3.AV18SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         objreportestadosatisfaccionsatisfaccionwc3.AV20UsuarioFecha_From = aP3_UsuarioFecha_From;
         objreportestadosatisfaccionsatisfaccionwc3.AV21UsuarioFecha_To = aP4_UsuarioFecha_To;
         objreportestadosatisfaccionsatisfaccionwc3.AV22SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         objreportestadosatisfaccionsatisfaccionwc3.AV23SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         objreportestadosatisfaccionsatisfaccionwc3.AV24SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         objreportestadosatisfaccionsatisfaccionwc3.AV25SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         objreportestadosatisfaccionsatisfaccionwc3.AV26SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         objreportestadosatisfaccionsatisfaccionwc3.AV10K2BToolsGenericSearchField = aP10_K2BToolsGenericSearchField;
         objreportestadosatisfaccionsatisfaccionwc3.AV11OrderedBy = aP11_OrderedBy;
         objreportestadosatisfaccionsatisfaccionwc3.context.SetSubmitInitialConfig(context);
         objreportestadosatisfaccionsatisfaccionwc3.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportestadosatisfaccionsatisfaccionwc3);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportestadosatisfaccionsatisfaccionwc3)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  AV37Pgmname) )
            {
               H390( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H390( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Satisfacciones", 260, Gx_line+0, 567, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV17SatisfaccionFecha_From) || ! (DateTime.MinValue==AV18SatisfaccionFecha_To) )
               {
                  AV31SatisfaccionFecha_ReportDescription = context.localUtil.DToC( AV17SatisfaccionFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV18SatisfaccionFecha_To, 2, "/");
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha Encuesta:", 10, Gx_line+7, 120, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31SatisfaccionFecha_ReportDescription, "")), 128, Gx_line+7, 650, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV20UsuarioFecha_From) || ! (DateTime.MinValue==AV21UsuarioFecha_To) )
               {
                  AV32UsuarioFecha_ReportDescription = context.localUtil.DToC( AV20UsuarioFecha_From, 2, "/") + " - " + context.localUtil.DToC( AV21UsuarioFecha_To, 2, "/");
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Fecha", 10, Gx_line+7, 47, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32UsuarioFecha_ReportDescription, "")), 55, Gx_line+7, 577, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SatisfaccionResueltoNombre)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Respuesta:", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22SatisfaccionResueltoNombre, "")), 92, Gx_line+7, 312, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SatisfaccionTecnicoProblemaNombre)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Respuesta:", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23SatisfaccionTecnicoProblemaNombre, "")), 92, Gx_line+7, 312, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionTecnicoCompetenteNombre)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Respuesta:", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24SatisfaccionTecnicoCompetenteNombre, "")), 92, Gx_line+7, 312, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTiempoNombre)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Respuesta:", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25SatisfaccionTiempoNombre, "")), 92, Gx_line+7, 312, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionAtencionNombre)) )
               {
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Respuesta:", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26SatisfaccionAtencionNombre, "")), 92, Gx_line+7, 312, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H390( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha Encuesta:", 100, Gx_line+7, 210, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("RST No.", 218, Gx_line+7, 292, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Id Usuario", 300, Gx_line+7, 374, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Usuario", 382, Gx_line+7, 513, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Fecha Inicio:", 521, Gx_line+7, 617, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Respuesta:", 633, Gx_line+7, 762, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV18SatisfaccionFecha_To ,
                                                    AV17SatisfaccionFecha_From ,
                                                    AV21UsuarioFecha_To ,
                                                    AV20UsuarioFecha_From ,
                                                    AV22SatisfaccionResueltoNombre ,
                                                    AV23SatisfaccionTecnicoProblemaNombre ,
                                                    AV24SatisfaccionTecnicoCompetenteNombre ,
                                                    AV25SatisfaccionTiempoNombre ,
                                                    AV26SatisfaccionAtencionNombre ,
                                                    AV10K2BToolsGenericSearchField ,
                                                    A32SatisfaccionFecha ,
                                                    A90UsuarioFecha ,
                                                    A33SatisfaccionResueltoNombre ,
                                                    A36SatisfaccionTecnicoProblemaNombre ,
                                                    A35SatisfaccionTecnicoCompetenteNombre ,
                                                    A38SatisfaccionTiempoNombre ,
                                                    A31SatisfaccionAtencionNombre ,
                                                    A7SatisfaccionId ,
                                                    A14TicketId ,
                                                    A15UsuarioId ,
                                                    A93UsuarioNombre ,
                                                    A94UsuarioRequerimiento ,
                                                    A34SatisfaccionSugerencia ,
                                                    AV11OrderedBy ,
                                                    AV9SatisfaccionTecnicoProfesionalismoId ,
                                                    A11SatisfaccionTecnicoProfesionalismoId } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                    TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                    }
               });
               lV22SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV22SatisfaccionResueltoNombre), "%", "");
               lV23SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV23SatisfaccionTecnicoProblemaNombre), "%", "");
               lV24SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV24SatisfaccionTecnicoCompetenteNombre), "%", "");
               lV25SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV25SatisfaccionTiempoNombre), "%", "");
               lV26SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV26SatisfaccionAtencionNombre), "%", "");
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
               /* Using cursor P00392 */
               pr_default.execute(0, new Object[] {AV9SatisfaccionTecnicoProfesionalismoId, AV18SatisfaccionFecha_To, AV17SatisfaccionFecha_From, AV21UsuarioFecha_To, AV20UsuarioFecha_From, lV22SatisfaccionResueltoNombre, lV23SatisfaccionTecnicoProblemaNombre, lV24SatisfaccionTecnicoCompetenteNombre, lV25SatisfaccionTiempoNombre, lV26SatisfaccionAtencionNombre, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField, lV10K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A8SatisfaccionResueltoId = P00392_A8SatisfaccionResueltoId[0];
                  A9SatisfaccionTecnicoProblemaId = P00392_A9SatisfaccionTecnicoProblemaId[0];
                  A10SatisfaccionTecnicoCompetenteId = P00392_A10SatisfaccionTecnicoCompetenteId[0];
                  A12SatisfaccionTiempoId = P00392_A12SatisfaccionTiempoId[0];
                  A13SatisfaccionAtencionId = P00392_A13SatisfaccionAtencionId[0];
                  A11SatisfaccionTecnicoProfesionalismoId = P00392_A11SatisfaccionTecnicoProfesionalismoId[0];
                  A34SatisfaccionSugerencia = P00392_A34SatisfaccionSugerencia[0];
                  n34SatisfaccionSugerencia = P00392_n34SatisfaccionSugerencia[0];
                  A94UsuarioRequerimiento = P00392_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P00392_A93UsuarioNombre[0];
                  A15UsuarioId = P00392_A15UsuarioId[0];
                  A14TicketId = P00392_A14TicketId[0];
                  A7SatisfaccionId = P00392_A7SatisfaccionId[0];
                  A31SatisfaccionAtencionNombre = P00392_A31SatisfaccionAtencionNombre[0];
                  A38SatisfaccionTiempoNombre = P00392_A38SatisfaccionTiempoNombre[0];
                  A35SatisfaccionTecnicoCompetenteNombre = P00392_A35SatisfaccionTecnicoCompetenteNombre[0];
                  A36SatisfaccionTecnicoProblemaNombre = P00392_A36SatisfaccionTecnicoProblemaNombre[0];
                  A33SatisfaccionResueltoNombre = P00392_A33SatisfaccionResueltoNombre[0];
                  A90UsuarioFecha = P00392_A90UsuarioFecha[0];
                  A32SatisfaccionFecha = P00392_A32SatisfaccionFecha[0];
                  A33SatisfaccionResueltoNombre = P00392_A33SatisfaccionResueltoNombre[0];
                  A36SatisfaccionTecnicoProblemaNombre = P00392_A36SatisfaccionTecnicoProblemaNombre[0];
                  A35SatisfaccionTecnicoCompetenteNombre = P00392_A35SatisfaccionTecnicoCompetenteNombre[0];
                  A38SatisfaccionTiempoNombre = P00392_A38SatisfaccionTiempoNombre[0];
                  A31SatisfaccionAtencionNombre = P00392_A31SatisfaccionAtencionNombre[0];
                  A15UsuarioId = P00392_A15UsuarioId[0];
                  A94UsuarioRequerimiento = P00392_A94UsuarioRequerimiento[0];
                  A93UsuarioNombre = P00392_A93UsuarioNombre[0];
                  A90UsuarioFecha = P00392_A90UsuarioFecha[0];
                  H390( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")), 18, Gx_line+7, 92, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"), 100, Gx_line+7, 210, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), 218, Gx_line+7, 292, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")), 300, Gx_line+7, 374, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), 382, Gx_line+7, 513, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A90UsuarioFecha, "99/99/9999"), 521, Gx_line+7, 617, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A33SatisfaccionResueltoNombre, "")), 633, Gx_line+7, 762, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H390( true, 0) ;
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

      protected void H390( bool bFoot ,
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
                  getPrinter().GxDrawText("Id", 18, Gx_line+7, 92, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha Encuesta:", 100, Gx_line+7, 210, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("RST No.", 218, Gx_line+7, 292, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Id Usuario", 300, Gx_line+7, 374, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Usuario", 382, Gx_line+7, 513, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Fecha Inicio:", 521, Gx_line+7, 617, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Respuesta:", 633, Gx_line+7, 762, Gx_line+22, 0, 0, 0, 1) ;
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
         AV37Pgmname = "";
         AV31SatisfaccionFecha_ReportDescription = "";
         AV32UsuarioFecha_ReportDescription = "";
         scmdbuf = "";
         lV22SatisfaccionResueltoNombre = "";
         lV23SatisfaccionTecnicoProblemaNombre = "";
         lV24SatisfaccionTecnicoCompetenteNombre = "";
         lV25SatisfaccionTiempoNombre = "";
         lV26SatisfaccionAtencionNombre = "";
         lV10K2BToolsGenericSearchField = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A34SatisfaccionSugerencia = "";
         P00392_A8SatisfaccionResueltoId = new short[1] ;
         P00392_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         P00392_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         P00392_A12SatisfaccionTiempoId = new short[1] ;
         P00392_A13SatisfaccionAtencionId = new short[1] ;
         P00392_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         P00392_A34SatisfaccionSugerencia = new string[] {""} ;
         P00392_n34SatisfaccionSugerencia = new bool[] {false} ;
         P00392_A94UsuarioRequerimiento = new string[] {""} ;
         P00392_A93UsuarioNombre = new string[] {""} ;
         P00392_A15UsuarioId = new long[1] ;
         P00392_A14TicketId = new long[1] ;
         P00392_A7SatisfaccionId = new long[1] ;
         P00392_A31SatisfaccionAtencionNombre = new string[] {""} ;
         P00392_A38SatisfaccionTiempoNombre = new string[] {""} ;
         P00392_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         P00392_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         P00392_A33SatisfaccionResueltoNombre = new string[] {""} ;
         P00392_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P00392_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportestadosatisfaccionsatisfaccionwc3__default(),
            new Object[][] {
                new Object[] {
               P00392_A8SatisfaccionResueltoId, P00392_A9SatisfaccionTecnicoProblemaId, P00392_A10SatisfaccionTecnicoCompetenteId, P00392_A12SatisfaccionTiempoId, P00392_A13SatisfaccionAtencionId, P00392_A11SatisfaccionTecnicoProfesionalismoId, P00392_A34SatisfaccionSugerencia, P00392_n34SatisfaccionSugerencia, P00392_A94UsuarioRequerimiento, P00392_A93UsuarioNombre,
               P00392_A15UsuarioId, P00392_A14TicketId, P00392_A7SatisfaccionId, P00392_A31SatisfaccionAtencionNombre, P00392_A38SatisfaccionTiempoNombre, P00392_A35SatisfaccionTecnicoCompetenteNombre, P00392_A36SatisfaccionTecnicoProblemaNombre, P00392_A33SatisfaccionResueltoNombre, P00392_A90UsuarioFecha, P00392_A32SatisfaccionFecha
               }
            }
         );
         AV37Pgmname = "ReportEstadoSatisfaccionSatisfaccionWC3";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV37Pgmname = "ReportEstadoSatisfaccionSatisfaccionWC3";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9SatisfaccionTecnicoProfesionalismoId ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV10K2BToolsGenericSearchField ;
      private string AV37Pgmname ;
      private string AV31SatisfaccionFecha_ReportDescription ;
      private string AV32UsuarioFecha_ReportDescription ;
      private string scmdbuf ;
      private string lV10K2BToolsGenericSearchField ;
      private DateTime AV17SatisfaccionFecha_From ;
      private DateTime AV18SatisfaccionFecha_To ;
      private DateTime AV20UsuarioFecha_From ;
      private DateTime AV21UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private bool n34SatisfaccionSugerencia ;
      private string AV22SatisfaccionResueltoNombre ;
      private string AV23SatisfaccionTecnicoProblemaNombre ;
      private string AV24SatisfaccionTecnicoCompetenteNombre ;
      private string AV25SatisfaccionTiempoNombre ;
      private string AV26SatisfaccionAtencionNombre ;
      private string lV22SatisfaccionResueltoNombre ;
      private string lV23SatisfaccionTecnicoProblemaNombre ;
      private string lV24SatisfaccionTecnicoCompetenteNombre ;
      private string lV25SatisfaccionTiempoNombre ;
      private string lV26SatisfaccionAtencionNombre ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A34SatisfaccionSugerencia ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00392_A8SatisfaccionResueltoId ;
      private short[] P00392_A9SatisfaccionTecnicoProblemaId ;
      private short[] P00392_A10SatisfaccionTecnicoCompetenteId ;
      private short[] P00392_A12SatisfaccionTiempoId ;
      private short[] P00392_A13SatisfaccionAtencionId ;
      private short[] P00392_A11SatisfaccionTecnicoProfesionalismoId ;
      private string[] P00392_A34SatisfaccionSugerencia ;
      private bool[] P00392_n34SatisfaccionSugerencia ;
      private string[] P00392_A94UsuarioRequerimiento ;
      private string[] P00392_A93UsuarioNombre ;
      private long[] P00392_A15UsuarioId ;
      private long[] P00392_A14TicketId ;
      private long[] P00392_A7SatisfaccionId ;
      private string[] P00392_A31SatisfaccionAtencionNombre ;
      private string[] P00392_A38SatisfaccionTiempoNombre ;
      private string[] P00392_A35SatisfaccionTecnicoCompetenteNombre ;
      private string[] P00392_A36SatisfaccionTecnicoProblemaNombre ;
      private string[] P00392_A33SatisfaccionResueltoNombre ;
      private DateTime[] P00392_A90UsuarioFecha ;
      private DateTime[] P00392_A32SatisfaccionFecha ;
      private SdtK2BContext AV8Context ;
   }

   public class reportestadosatisfaccionsatisfaccionwc3__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00392( IGxContext context ,
                                             DateTime AV18SatisfaccionFecha_To ,
                                             DateTime AV17SatisfaccionFecha_From ,
                                             DateTime AV21UsuarioFecha_To ,
                                             DateTime AV20UsuarioFecha_From ,
                                             string AV22SatisfaccionResueltoNombre ,
                                             string AV23SatisfaccionTecnicoProblemaNombre ,
                                             string AV24SatisfaccionTecnicoCompetenteNombre ,
                                             string AV25SatisfaccionTiempoNombre ,
                                             string AV26SatisfaccionAtencionNombre ,
                                             string AV10K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV11OrderedBy ,
                                             short AV9SatisfaccionTecnicoProfesionalismoId ,
                                             short A11SatisfaccionTecnicoProfesionalismoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[21];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T1.[SatisfaccionTecnicoProfesionalismoId], T1.[SatisfaccionSugerencia], T8.[UsuarioRequerimiento], T8.[UsuarioNombre], T7.[UsuarioId], T1.[TicketId], T1.[SatisfaccionId], T6.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T2.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T8.[UsuarioFecha], T1.[SatisfaccionFecha] FROM ((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [Ticket] T7 ON T7.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T8 ON T8.[UsuarioId] = T7.[UsuarioId])";
         AddWhere(sWhereString, "(T1.[SatisfaccionTecnicoProfesionalismoId] = @AV9SatisfaccionTecnicoProfesionalismoId)");
         if ( ! (DateTime.MinValue==AV18SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV18SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV17SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV17SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV21UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] <= @AV21UsuarioFecha_To)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV20UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] >= @AV20UsuarioFecha_From)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV22SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV23SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV24SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV25SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV26SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T7.[UsuarioId] AS decimal(10,0))) like '%' + @lV10K2BToolsGenericSearchField + '%' or T8.[UsuarioNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T8.[UsuarioRequerimiento] like '%' + @lV10K2BToolsGenericSearchField + '%' or T2.[EstadoSatisfaccionNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T3.[EstadoSatisfaccionNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV10K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV10K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
            GXv_int1[15] = 1;
            GXv_int1[16] = 1;
            GXv_int1[17] = 1;
            GXv_int1[18] = 1;
            GXv_int1[19] = 1;
            GXv_int1[20] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV11OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV11OrderedBy == 3 )
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
                     return conditional_P00392(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("@AV9SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@AV18SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV17SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV21UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV20UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV22SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV23SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV24SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV25SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV26SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV10K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(19);
                return;
       }
    }

 }

}
