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
   public class reportwwdetalle_infotec : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "nombre_emp");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV15nombre_emp = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV33fecha_registro_From = context.localUtil.ParseDateParm( GetPar( "fecha_registro_From"));
                  AV34fecha_registro_To = context.localUtil.ParseDateParm( GetPar( "fecha_registro_To"));
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

      public reportwwdetalle_infotec( )
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

      public reportwwdetalle_infotec( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_nombre_emp ,
                           DateTime aP1_fecha_registro_From ,
                           DateTime aP2_fecha_registro_To ,
                           string aP3_K2BToolsGenericSearchField ,
                           short aP4_OrderedBy )
      {
         this.AV15nombre_emp = aP0_nombre_emp;
         this.AV33fecha_registro_From = aP1_fecha_registro_From;
         this.AV34fecha_registro_To = aP2_fecha_registro_To;
         this.AV9K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP4_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_nombre_emp ,
                                 DateTime aP1_fecha_registro_From ,
                                 DateTime aP2_fecha_registro_To ,
                                 string aP3_K2BToolsGenericSearchField ,
                                 short aP4_OrderedBy )
      {
         reportwwdetalle_infotec objreportwwdetalle_infotec;
         objreportwwdetalle_infotec = new reportwwdetalle_infotec();
         objreportwwdetalle_infotec.AV15nombre_emp = aP0_nombre_emp;
         objreportwwdetalle_infotec.AV33fecha_registro_From = aP1_fecha_registro_From;
         objreportwwdetalle_infotec.AV34fecha_registro_To = aP2_fecha_registro_To;
         objreportwwdetalle_infotec.AV9K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         objreportwwdetalle_infotec.AV10OrderedBy = aP4_OrderedBy;
         objreportwwdetalle_infotec.context.SetSubmitInitialConfig(context);
         objreportwwdetalle_infotec.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwdetalle_infotec);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwdetalle_infotec)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "detalle_infotec",  "detalle_infotec",  "List",  "",  AV40Pgmname) )
            {
               H7B0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H7B0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("detalle_infoteces", 227, Gx_line+0, 600, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H7B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15nombre_emp)) )
               {
                  H7B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("nombre_emp", 10, Gx_line+7, 84, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15nombre_emp, "")), 92, Gx_line+7, 1952, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV33fecha_registro_From) || ! (DateTime.MinValue==AV34fecha_registro_To) )
               {
                  AV35fecha_registro_ReportDescription = context.localUtil.DToC( AV33fecha_registro_From, 2, "/") + " - " + context.localUtil.DToC( AV34fecha_registro_To, 2, "/");
                  H7B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("fecha_registro", 10, Gx_line+7, 113, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35fecha_registro_ReportDescription, "")), 121, Gx_line+7, 643, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H7B0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("correlativo", 18, Gx_line+7, 99, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("cargo_emp", 115, Gx_line+7, 246, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("fecha_registro", 254, Gx_line+7, 357, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("estatus", 365, Gx_line+7, 494, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("id_unidad", 534, Gx_line+7, 601, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("id_categoria", 609, Gx_line+7, 698, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("id_actividad", 706, Gx_line+7, 795, Gx_line+22, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                    AV15nombre_emp ,
                                                    AV34fecha_registro_To ,
                                                    AV33fecha_registro_From ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A239nombre_emp ,
                                                    A241fecha_registro ,
                                                    A238correlativo ,
                                                    A240cargo_emp ,
                                                    A243estatus ,
                                                    A244trabajo ,
                                                    A245nombre_usuario ,
                                                    A246depto_usuario ,
                                                    A247correo_usuario ,
                                                    A248detalle_infotecid_unidad ,
                                                    A249id_categoria ,
                                                    A250id_actividad ,
                                                    A251detalle_tarea ,
                                                    A252prioridad ,
                                                    A253observaciones ,
                                                    A254fecha_solicitud ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                    TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                    TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                    }
               });
               lV15nombre_emp = StringUtil.Concat( StringUtil.RTrim( AV15nombre_emp), "%", "");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P007B2 */
               pr_datastore1.execute(0, new Object[] {lV15nombre_emp, AV34fecha_registro_To, AV33fecha_registro_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_datastore1.getStatus(0) != 101) )
               {
                  A254fecha_solicitud = P007B2_A254fecha_solicitud[0];
                  n254fecha_solicitud = P007B2_n254fecha_solicitud[0];
                  A253observaciones = P007B2_A253observaciones[0];
                  n253observaciones = P007B2_n253observaciones[0];
                  A252prioridad = P007B2_A252prioridad[0];
                  n252prioridad = P007B2_n252prioridad[0];
                  A251detalle_tarea = P007B2_A251detalle_tarea[0];
                  n251detalle_tarea = P007B2_n251detalle_tarea[0];
                  A250id_actividad = P007B2_A250id_actividad[0];
                  n250id_actividad = P007B2_n250id_actividad[0];
                  A249id_categoria = P007B2_A249id_categoria[0];
                  n249id_categoria = P007B2_n249id_categoria[0];
                  A248detalle_infotecid_unidad = P007B2_A248detalle_infotecid_unidad[0];
                  n248detalle_infotecid_unidad = P007B2_n248detalle_infotecid_unidad[0];
                  A247correo_usuario = P007B2_A247correo_usuario[0];
                  n247correo_usuario = P007B2_n247correo_usuario[0];
                  A246depto_usuario = P007B2_A246depto_usuario[0];
                  n246depto_usuario = P007B2_n246depto_usuario[0];
                  A245nombre_usuario = P007B2_A245nombre_usuario[0];
                  n245nombre_usuario = P007B2_n245nombre_usuario[0];
                  A244trabajo = P007B2_A244trabajo[0];
                  n244trabajo = P007B2_n244trabajo[0];
                  A243estatus = P007B2_A243estatus[0];
                  n243estatus = P007B2_n243estatus[0];
                  A240cargo_emp = P007B2_A240cargo_emp[0];
                  n240cargo_emp = P007B2_n240cargo_emp[0];
                  A238correlativo = P007B2_A238correlativo[0];
                  A241fecha_registro = P007B2_A241fecha_registro[0];
                  n241fecha_registro = P007B2_n241fecha_registro[0];
                  A239nombre_emp = P007B2_A239nombre_emp[0];
                  n239nombre_emp = P007B2_n239nombre_emp[0];
                  H7B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9")), 18, Gx_line+7, 99, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A240cargo_emp, "")), 115, Gx_line+7, 246, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A241fecha_registro, "99/99/99"), 254, Gx_line+7, 357, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A243estatus, "")), 365, Gx_line+7, 494, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9")), 534, Gx_line+7, 601, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9")), 609, Gx_line+7, 698, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9")), 706, Gx_line+7, 795, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_datastore1.readNext(0);
               }
               pr_datastore1.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7B0( true, 0) ;
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

      protected void H7B0( bool bFoot ,
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
                  getPrinter().GxDrawText("correlativo", 18, Gx_line+7, 99, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("cargo_emp", 115, Gx_line+7, 246, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("fecha_registro", 254, Gx_line+7, 357, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("estatus", 365, Gx_line+7, 494, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("id_unidad", 534, Gx_line+7, 601, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("id_categoria", 609, Gx_line+7, 698, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("id_actividad", 706, Gx_line+7, 795, Gx_line+22, 2, 0, 0, 1) ;
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
         AV40Pgmname = "";
         AV35fecha_registro_ReportDescription = "";
         scmdbuf = "";
         lV15nombre_emp = "";
         lV9K2BToolsGenericSearchField = "";
         A239nombre_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A240cargo_emp = "";
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         P007B2_A254fecha_solicitud = new string[] {""} ;
         P007B2_n254fecha_solicitud = new bool[] {false} ;
         P007B2_A253observaciones = new string[] {""} ;
         P007B2_n253observaciones = new bool[] {false} ;
         P007B2_A252prioridad = new string[] {""} ;
         P007B2_n252prioridad = new bool[] {false} ;
         P007B2_A251detalle_tarea = new string[] {""} ;
         P007B2_n251detalle_tarea = new bool[] {false} ;
         P007B2_A250id_actividad = new int[1] ;
         P007B2_n250id_actividad = new bool[] {false} ;
         P007B2_A249id_categoria = new int[1] ;
         P007B2_n249id_categoria = new bool[] {false} ;
         P007B2_A248detalle_infotecid_unidad = new int[1] ;
         P007B2_n248detalle_infotecid_unidad = new bool[] {false} ;
         P007B2_A247correo_usuario = new string[] {""} ;
         P007B2_n247correo_usuario = new bool[] {false} ;
         P007B2_A246depto_usuario = new string[] {""} ;
         P007B2_n246depto_usuario = new bool[] {false} ;
         P007B2_A245nombre_usuario = new string[] {""} ;
         P007B2_n245nombre_usuario = new bool[] {false} ;
         P007B2_A244trabajo = new string[] {""} ;
         P007B2_n244trabajo = new bool[] {false} ;
         P007B2_A243estatus = new string[] {""} ;
         P007B2_n243estatus = new bool[] {false} ;
         P007B2_A240cargo_emp = new string[] {""} ;
         P007B2_n240cargo_emp = new bool[] {false} ;
         P007B2_A238correlativo = new int[1] ;
         P007B2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         P007B2_n241fecha_registro = new bool[] {false} ;
         P007B2_A239nombre_emp = new string[] {""} ;
         P007B2_n239nombre_emp = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.reportwwdetalle_infotec__datastore1(),
            new Object[][] {
                new Object[] {
               P007B2_A254fecha_solicitud, P007B2_n254fecha_solicitud, P007B2_A253observaciones, P007B2_n253observaciones, P007B2_A252prioridad, P007B2_n252prioridad, P007B2_A251detalle_tarea, P007B2_n251detalle_tarea, P007B2_A250id_actividad, P007B2_n250id_actividad,
               P007B2_A249id_categoria, P007B2_n249id_categoria, P007B2_A248detalle_infotecid_unidad, P007B2_n248detalle_infotecid_unidad, P007B2_A247correo_usuario, P007B2_n247correo_usuario, P007B2_A246depto_usuario, P007B2_n246depto_usuario, P007B2_A245nombre_usuario, P007B2_n245nombre_usuario,
               P007B2_A244trabajo, P007B2_n244trabajo, P007B2_A243estatus, P007B2_n243estatus, P007B2_A240cargo_emp, P007B2_n240cargo_emp, P007B2_A238correlativo, P007B2_A241fecha_registro, P007B2_n241fecha_registro, P007B2_A239nombre_emp,
               P007B2_n239nombre_emp
               }
            }
         );
         AV40Pgmname = "ReportWWdetalle_infotec";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV40Pgmname = "ReportWWdetalle_infotec";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A238correlativo ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV40Pgmname ;
      private string AV35fecha_registro_ReportDescription ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV33fecha_registro_From ;
      private DateTime AV34fecha_registro_To ;
      private DateTime A241fecha_registro ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private bool n254fecha_solicitud ;
      private bool n253observaciones ;
      private bool n252prioridad ;
      private bool n251detalle_tarea ;
      private bool n250id_actividad ;
      private bool n249id_categoria ;
      private bool n248detalle_infotecid_unidad ;
      private bool n247correo_usuario ;
      private bool n246depto_usuario ;
      private bool n245nombre_usuario ;
      private bool n244trabajo ;
      private bool n243estatus ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n239nombre_emp ;
      private string AV15nombre_emp ;
      private string lV15nombre_emp ;
      private string A239nombre_emp ;
      private string A240cargo_emp ;
      private string A243estatus ;
      private string A244trabajo ;
      private string A245nombre_usuario ;
      private string A246depto_usuario ;
      private string A247correo_usuario ;
      private string A251detalle_tarea ;
      private string A252prioridad ;
      private string A253observaciones ;
      private string A254fecha_solicitud ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P007B2_A254fecha_solicitud ;
      private bool[] P007B2_n254fecha_solicitud ;
      private string[] P007B2_A253observaciones ;
      private bool[] P007B2_n253observaciones ;
      private string[] P007B2_A252prioridad ;
      private bool[] P007B2_n252prioridad ;
      private string[] P007B2_A251detalle_tarea ;
      private bool[] P007B2_n251detalle_tarea ;
      private int[] P007B2_A250id_actividad ;
      private bool[] P007B2_n250id_actividad ;
      private int[] P007B2_A249id_categoria ;
      private bool[] P007B2_n249id_categoria ;
      private int[] P007B2_A248detalle_infotecid_unidad ;
      private bool[] P007B2_n248detalle_infotecid_unidad ;
      private string[] P007B2_A247correo_usuario ;
      private bool[] P007B2_n247correo_usuario ;
      private string[] P007B2_A246depto_usuario ;
      private bool[] P007B2_n246depto_usuario ;
      private string[] P007B2_A245nombre_usuario ;
      private bool[] P007B2_n245nombre_usuario ;
      private string[] P007B2_A244trabajo ;
      private bool[] P007B2_n244trabajo ;
      private string[] P007B2_A243estatus ;
      private bool[] P007B2_n243estatus ;
      private string[] P007B2_A240cargo_emp ;
      private bool[] P007B2_n240cargo_emp ;
      private int[] P007B2_A238correlativo ;
      private DateTime[] P007B2_A241fecha_registro ;
      private bool[] P007B2_n241fecha_registro ;
      private string[] P007B2_A239nombre_emp ;
      private bool[] P007B2_n239nombre_emp ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwdetalle_infotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007B2( IGxContext context ,
                                             string AV15nombre_emp ,
                                             DateTime AV34fecha_registro_To ,
                                             DateTime AV33fecha_registro_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             string A239nombre_emp ,
                                             DateTime A241fecha_registro ,
                                             int A238correlativo ,
                                             string A240cargo_emp ,
                                             string A243estatus ,
                                             string A244trabajo ,
                                             string A245nombre_usuario ,
                                             string A246depto_usuario ,
                                             string A247correo_usuario ,
                                             int A248detalle_infotecid_unidad ,
                                             int A249id_categoria ,
                                             int A250id_actividad ,
                                             string A251detalle_tarea ,
                                             string A252prioridad ,
                                             string A253observaciones ,
                                             string A254fecha_solicitud ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [fecha_solicitud], [observaciones], [prioridad], [detalle_tarea], [id_actividad], [id_categoria], [id_unidad], [correo_usuario], [depto_usuario], [nombre_usuario], [trabajo], [estatus], [cargo_emp], [correlativo], [fecha_registro], [nombre_emp] FROM dbo.[detalle_infotec]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15nombre_emp)) )
         {
            AddWhere(sWhereString, "([nombre_emp] like @lV15nombre_emp)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV34fecha_registro_To) )
         {
            AddWhere(sWhereString, "([fecha_registro] <= @AV34fecha_registro_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV33fecha_registro_From) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV33fecha_registro_From)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([correlativo] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [nombre_emp] like '%' + @lV9K2BToolsGenericSearchField + '%' or [cargo_emp] like '%' + @lV9K2BToolsGenericSearchField + '%' or [estatus] like '%' + @lV9K2BToolsGenericSearchField + '%' or [trabajo] like '%' + @lV9K2BToolsGenericSearchField + '%' or [nombre_usuario] like '%' + @lV9K2BToolsGenericSearchField + '%' or [depto_usuario] like '%' + @lV9K2BToolsGenericSearchField + '%' or [correo_usuario] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_categoria] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_actividad] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [detalle_tarea] like '%' + @lV9K2BToolsGenericSearchField + '%' or [prioridad] like '%' + @lV9K2BToolsGenericSearchField + '%' or [observaciones] like '%' + @lV9K2BToolsGenericSearchField + '%' or [fecha_solicitud] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
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
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [correlativo]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [correlativo] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [nombre_emp]";
         }
         else if ( AV10OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [nombre_emp] DESC";
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
                     return conditional_P007B2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] );
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
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("@lV15nombre_emp",GXType.NVarChar,300,0) ,
          new ParDef("@AV34fecha_registro_To",GXType.Date,8,0) ,
          new ParDef("@AV33fecha_registro_From",GXType.Date,8,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
