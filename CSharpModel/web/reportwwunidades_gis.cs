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
   public class reportwwunidades_gis : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "nombre_unidad");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV15nombre_unidad = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17unidades_gisfecha_creacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_From"));
                  AV18unidades_gisfecha_creacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_To"));
                  AV20unidades_gisfecha_modificacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_From"));
                  AV21unidades_gisfecha_modificacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_To"));
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

      public reportwwunidades_gis( )
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

      public reportwwunidades_gis( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_nombre_unidad ,
                           DateTime aP1_unidades_gisfecha_creacion_From ,
                           DateTime aP2_unidades_gisfecha_creacion_To ,
                           DateTime aP3_unidades_gisfecha_modificacion_From ,
                           DateTime aP4_unidades_gisfecha_modificacion_To ,
                           string aP5_K2BToolsGenericSearchField ,
                           short aP6_OrderedBy )
      {
         this.AV15nombre_unidad = aP0_nombre_unidad;
         this.AV17unidades_gisfecha_creacion_From = aP1_unidades_gisfecha_creacion_From;
         this.AV18unidades_gisfecha_creacion_To = aP2_unidades_gisfecha_creacion_To;
         this.AV20unidades_gisfecha_modificacion_From = aP3_unidades_gisfecha_modificacion_From;
         this.AV21unidades_gisfecha_modificacion_To = aP4_unidades_gisfecha_modificacion_To;
         this.AV9K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP6_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_nombre_unidad ,
                                 DateTime aP1_unidades_gisfecha_creacion_From ,
                                 DateTime aP2_unidades_gisfecha_creacion_To ,
                                 DateTime aP3_unidades_gisfecha_modificacion_From ,
                                 DateTime aP4_unidades_gisfecha_modificacion_To ,
                                 string aP5_K2BToolsGenericSearchField ,
                                 short aP6_OrderedBy )
      {
         reportwwunidades_gis objreportwwunidades_gis;
         objreportwwunidades_gis = new reportwwunidades_gis();
         objreportwwunidades_gis.AV15nombre_unidad = aP0_nombre_unidad;
         objreportwwunidades_gis.AV17unidades_gisfecha_creacion_From = aP1_unidades_gisfecha_creacion_From;
         objreportwwunidades_gis.AV18unidades_gisfecha_creacion_To = aP2_unidades_gisfecha_creacion_To;
         objreportwwunidades_gis.AV20unidades_gisfecha_modificacion_From = aP3_unidades_gisfecha_modificacion_From;
         objreportwwunidades_gis.AV21unidades_gisfecha_modificacion_To = aP4_unidades_gisfecha_modificacion_To;
         objreportwwunidades_gis.AV9K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         objreportwwunidades_gis.AV10OrderedBy = aP6_OrderedBy;
         objreportwwunidades_gis.context.SetSubmitInitialConfig(context);
         objreportwwunidades_gis.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwunidades_gis);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwunidades_gis)stateInfo).executePrivate();
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
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "unidades_gis",  "unidades_gis",  "List",  "",  AV32Pgmname) )
            {
               H5N0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H5N0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("unidades_gises", 260, Gx_line+0, 567, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H5N0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15nombre_unidad)) )
               {
                  H5N0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("nombre_unidad", 10, Gx_line+7, 106, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15nombre_unidad, "")), 114, Gx_line+7, 1573, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV17unidades_gisfecha_creacion_From) || ! (DateTime.MinValue==AV18unidades_gisfecha_creacion_To) )
               {
                  AV26unidades_gisfecha_creacion_ReportDescription = context.localUtil.DToC( AV17unidades_gisfecha_creacion_From, 2, "/") + " - " + context.localUtil.DToC( AV18unidades_gisfecha_creacion_To, 2, "/");
                  H5N0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("fecha_creacion", 10, Gx_line+7, 113, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26unidades_gisfecha_creacion_ReportDescription, "")), 121, Gx_line+7, 643, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! (DateTime.MinValue==AV20unidades_gisfecha_modificacion_From) || ! (DateTime.MinValue==AV21unidades_gisfecha_modificacion_To) )
               {
                  AV27unidades_gisfecha_modificacion_ReportDescription = context.localUtil.DToC( AV20unidades_gisfecha_modificacion_From, 2, "/") + " - " + context.localUtil.DToC( AV21unidades_gisfecha_modificacion_To, 2, "/");
                  H5N0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("fecha_modificacion", 10, Gx_line+7, 142, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27unidades_gisfecha_modificacion_ReportDescription, "")), 150, Gx_line+7, 672, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H5N0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("id_unidad", 18, Gx_line+7, 85, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("estado", 101, Gx_line+7, 168, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("fecha_creacion", 176, Gx_line+7, 279, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("hora_creacion", 287, Gx_line+7, 383, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("creado_por", 391, Gx_line+7, 457, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("fecha_modificacion", 465, Gx_line+7, 597, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("hora_modificacion", 605, Gx_line+7, 730, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("modificado_por", 738, Gx_line+7, 804, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                    AV15nombre_unidad ,
                                                    AV18unidades_gisfecha_creacion_To ,
                                                    AV17unidades_gisfecha_creacion_From ,
                                                    AV21unidades_gisfecha_modificacion_To ,
                                                    AV20unidades_gisfecha_modificacion_From ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A114nombre_unidad ,
                                                    A116unidades_gisfecha_creacion ,
                                                    A119unidades_gisfecha_modificacion ,
                                                    A103id_unidad ,
                                                    A115unidades_gisestado ,
                                                    A117unidades_gishora_creacion ,
                                                    A118unidades_giscreado_por ,
                                                    A120unidades_gishora_modificacion ,
                                                    A121unidades_gismodificado_por ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                    TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                    }
               });
               lV15nombre_unidad = StringUtil.Concat( StringUtil.RTrim( AV15nombre_unidad), "%", "");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P005N2 */
               pr_datastore1.execute(0, new Object[] {lV15nombre_unidad, AV18unidades_gisfecha_creacion_To, AV17unidades_gisfecha_creacion_From, AV21unidades_gisfecha_modificacion_To, AV20unidades_gisfecha_modificacion_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_datastore1.getStatus(0) != 101) )
               {
                  A121unidades_gismodificado_por = P005N2_A121unidades_gismodificado_por[0];
                  n121unidades_gismodificado_por = P005N2_n121unidades_gismodificado_por[0];
                  A120unidades_gishora_modificacion = P005N2_A120unidades_gishora_modificacion[0];
                  n120unidades_gishora_modificacion = P005N2_n120unidades_gishora_modificacion[0];
                  A118unidades_giscreado_por = P005N2_A118unidades_giscreado_por[0];
                  n118unidades_giscreado_por = P005N2_n118unidades_giscreado_por[0];
                  A117unidades_gishora_creacion = P005N2_A117unidades_gishora_creacion[0];
                  n117unidades_gishora_creacion = P005N2_n117unidades_gishora_creacion[0];
                  A115unidades_gisestado = P005N2_A115unidades_gisestado[0];
                  n115unidades_gisestado = P005N2_n115unidades_gisestado[0];
                  A103id_unidad = P005N2_A103id_unidad[0];
                  A119unidades_gisfecha_modificacion = P005N2_A119unidades_gisfecha_modificacion[0];
                  n119unidades_gisfecha_modificacion = P005N2_n119unidades_gisfecha_modificacion[0];
                  A116unidades_gisfecha_creacion = P005N2_A116unidades_gisfecha_creacion[0];
                  n116unidades_gisfecha_creacion = P005N2_n116unidades_gisfecha_creacion[0];
                  A114nombre_unidad = P005N2_A114nombre_unidad[0];
                  n114nombre_unidad = P005N2_n114nombre_unidad[0];
                  H5N0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9")), 18, Gx_line+7, 85, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A115unidades_gisestado), "ZZZZZZZZ9")), 101, Gx_line+7, 168, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A116unidades_gisfecha_creacion, "99/99/99"), 176, Gx_line+7, 279, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A117unidades_gishora_creacion), "ZZZZ9")), 287, Gx_line+7, 383, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A118unidades_giscreado_por, "")), 391, Gx_line+7, 457, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A119unidades_gisfecha_modificacion, "99/99/99"), 465, Gx_line+7, 597, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A120unidades_gishora_modificacion), "ZZZZ9")), 605, Gx_line+7, 730, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A121unidades_gismodificado_por, "")), 738, Gx_line+7, 804, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_datastore1.readNext(0);
               }
               pr_datastore1.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H5N0( true, 0) ;
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

      protected void H5N0( bool bFoot ,
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
                  getPrinter().GxDrawText("id_unidad", 18, Gx_line+7, 85, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("estado", 101, Gx_line+7, 168, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("fecha_creacion", 176, Gx_line+7, 279, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("hora_creacion", 287, Gx_line+7, 383, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("creado_por", 391, Gx_line+7, 457, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("fecha_modificacion", 465, Gx_line+7, 597, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("hora_modificacion", 605, Gx_line+7, 730, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("modificado_por", 738, Gx_line+7, 804, Gx_line+22, 0, 0, 0, 1) ;
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
         AV32Pgmname = "";
         AV26unidades_gisfecha_creacion_ReportDescription = "";
         AV27unidades_gisfecha_modificacion_ReportDescription = "";
         scmdbuf = "";
         lV15nombre_unidad = "";
         lV9K2BToolsGenericSearchField = "";
         A114nombre_unidad = "";
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         A118unidades_giscreado_por = "";
         A121unidades_gismodificado_por = "";
         P005N2_A121unidades_gismodificado_por = new string[] {""} ;
         P005N2_n121unidades_gismodificado_por = new bool[] {false} ;
         P005N2_A120unidades_gishora_modificacion = new int[1] ;
         P005N2_n120unidades_gishora_modificacion = new bool[] {false} ;
         P005N2_A118unidades_giscreado_por = new string[] {""} ;
         P005N2_n118unidades_giscreado_por = new bool[] {false} ;
         P005N2_A117unidades_gishora_creacion = new int[1] ;
         P005N2_n117unidades_gishora_creacion = new bool[] {false} ;
         P005N2_A115unidades_gisestado = new int[1] ;
         P005N2_n115unidades_gisestado = new bool[] {false} ;
         P005N2_A103id_unidad = new int[1] ;
         P005N2_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         P005N2_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         P005N2_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         P005N2_n116unidades_gisfecha_creacion = new bool[] {false} ;
         P005N2_A114nombre_unidad = new string[] {""} ;
         P005N2_n114nombre_unidad = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.reportwwunidades_gis__datastore1(),
            new Object[][] {
                new Object[] {
               P005N2_A121unidades_gismodificado_por, P005N2_n121unidades_gismodificado_por, P005N2_A120unidades_gishora_modificacion, P005N2_n120unidades_gishora_modificacion, P005N2_A118unidades_giscreado_por, P005N2_n118unidades_giscreado_por, P005N2_A117unidades_gishora_creacion, P005N2_n117unidades_gishora_creacion, P005N2_A115unidades_gisestado, P005N2_n115unidades_gisestado,
               P005N2_A103id_unidad, P005N2_A119unidades_gisfecha_modificacion, P005N2_n119unidades_gisfecha_modificacion, P005N2_A116unidades_gisfecha_creacion, P005N2_n116unidades_gisfecha_creacion, P005N2_A114nombre_unidad, P005N2_n114nombre_unidad
               }
            }
         );
         AV32Pgmname = "ReportWWunidades_gis";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV32Pgmname = "ReportWWunidades_gis";
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
      private int A103id_unidad ;
      private int A115unidades_gisestado ;
      private int A117unidades_gishora_creacion ;
      private int A120unidades_gishora_modificacion ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV32Pgmname ;
      private string AV26unidades_gisfecha_creacion_ReportDescription ;
      private string AV27unidades_gisfecha_modificacion_ReportDescription ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV17unidades_gisfecha_creacion_From ;
      private DateTime AV18unidades_gisfecha_creacion_To ;
      private DateTime AV20unidades_gisfecha_modificacion_From ;
      private DateTime AV21unidades_gisfecha_modificacion_To ;
      private DateTime A116unidades_gisfecha_creacion ;
      private DateTime A119unidades_gisfecha_modificacion ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private bool n121unidades_gismodificado_por ;
      private bool n120unidades_gishora_modificacion ;
      private bool n118unidades_giscreado_por ;
      private bool n117unidades_gishora_creacion ;
      private bool n115unidades_gisestado ;
      private bool n119unidades_gisfecha_modificacion ;
      private bool n116unidades_gisfecha_creacion ;
      private bool n114nombre_unidad ;
      private string AV15nombre_unidad ;
      private string lV15nombre_unidad ;
      private string A114nombre_unidad ;
      private string A118unidades_giscreado_por ;
      private string A121unidades_gismodificado_por ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P005N2_A121unidades_gismodificado_por ;
      private bool[] P005N2_n121unidades_gismodificado_por ;
      private int[] P005N2_A120unidades_gishora_modificacion ;
      private bool[] P005N2_n120unidades_gishora_modificacion ;
      private string[] P005N2_A118unidades_giscreado_por ;
      private bool[] P005N2_n118unidades_giscreado_por ;
      private int[] P005N2_A117unidades_gishora_creacion ;
      private bool[] P005N2_n117unidades_gishora_creacion ;
      private int[] P005N2_A115unidades_gisestado ;
      private bool[] P005N2_n115unidades_gisestado ;
      private int[] P005N2_A103id_unidad ;
      private DateTime[] P005N2_A119unidades_gisfecha_modificacion ;
      private bool[] P005N2_n119unidades_gisfecha_modificacion ;
      private DateTime[] P005N2_A116unidades_gisfecha_creacion ;
      private bool[] P005N2_n116unidades_gisfecha_creacion ;
      private string[] P005N2_A114nombre_unidad ;
      private bool[] P005N2_n114nombre_unidad ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwunidades_gis__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005N2( IGxContext context ,
                                             string AV15nombre_unidad ,
                                             DateTime AV18unidades_gisfecha_creacion_To ,
                                             DateTime AV17unidades_gisfecha_creacion_From ,
                                             DateTime AV21unidades_gisfecha_modificacion_To ,
                                             DateTime AV20unidades_gisfecha_modificacion_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             string A114nombre_unidad ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A103id_unidad ,
                                             int A115unidades_gisestado ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             int A120unidades_gishora_modificacion ,
                                             string A121unidades_gismodificado_por ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [modificado_por], [hora_modificacion], [creado_por], [hora_creacion], [estado], [id_unidad], [fecha_modificacion], [fecha_creacion], [nombre_unidad] FROM dbo.[unidades_gis]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15nombre_unidad)) )
         {
            AddWhere(sWhereString, "([nombre_unidad] like @lV15nombre_unidad)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV18unidades_gisfecha_creacion_To) )
         {
            AddWhere(sWhereString, "([fecha_creacion] <= @AV18unidades_gisfecha_creacion_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV17unidades_gisfecha_creacion_From) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV17unidades_gisfecha_creacion_From)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV21unidades_gisfecha_modificacion_To) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] <= @AV21unidades_gisfecha_modificacion_To)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV20unidades_gisfecha_modificacion_From) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV20unidades_gisfecha_modificacion_From)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [nombre_unidad] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_creacion] AS decimal(5,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [creado_por] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_modificacion] AS decimal(5,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [modificado_por] like '%' + @lV9K2BToolsGenericSearchField + '%')");
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
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [id_unidad]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [id_unidad] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [nombre_unidad]";
         }
         else if ( AV10OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [nombre_unidad] DESC";
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
                     return conditional_P005N2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP005N2;
          prmP005N2 = new Object[] {
          new ParDef("@lV15nombre_unidad",GXType.NVarChar,200,0) ,
          new ParDef("@AV18unidades_gisfecha_creacion_To",GXType.Date,8,0) ,
          new ParDef("@AV17unidades_gisfecha_creacion_From",GXType.Date,8,0) ,
          new ParDef("@AV21unidades_gisfecha_modificacion_To",GXType.Date,8,0) ,
          new ParDef("@AV20unidades_gisfecha_modificacion_From",GXType.Date,8,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005N2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
