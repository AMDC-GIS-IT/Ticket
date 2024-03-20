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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwunidades_gis : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwunidades_gis( )
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

      public wwunidades_gis( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavAtt_id_unidad_visible = new GXCheckbox();
         chkavAtt_nombre_unidad_visible = new GXCheckbox();
         chkavAtt_unidades_gisestado_visible = new GXCheckbox();
         chkavAtt_unidades_gisfecha_creacion_visible = new GXCheckbox();
         chkavAtt_unidades_gishora_creacion_visible = new GXCheckbox();
         chkavAtt_unidades_giscreado_por_visible = new GXCheckbox();
         chkavAtt_unidades_gisfecha_modificacion_visible = new GXCheckbox();
         chkavAtt_unidades_gishora_modificacion_visible = new GXCheckbox();
         chkavAtt_unidades_gismodificado_por_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_174 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_174"), "."));
               nGXsfl_174_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_174_idx"), "."));
               sGXsfl_174_idx = GetPar( "sGXsfl_174_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
               AV41K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV30nombre_unidad = GetPar( "nombre_unidad");
               AV32unidades_gisfecha_creacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_From"));
               AV35unidades_gisfecha_modificacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_From"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV29ClassCollection);
               AV42OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV33unidades_gisfecha_creacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_To"));
               AV36unidades_gisfecha_modificacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_To"));
               AV60Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV48nombre_unidad_IsAuthorized = StringUtil.StrToBool( GetPar( "nombre_unidad_IsAuthorized"));
               AV14Att_id_unidad_Visible = StringUtil.StrToBool( GetPar( "Att_id_unidad_Visible"));
               AV15Att_nombre_unidad_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_unidad_Visible"));
               AV16Att_unidades_gisestado_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gisestado_Visible"));
               AV17Att_unidades_gisfecha_creacion_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gisfecha_creacion_Visible"));
               AV18Att_unidades_gishora_creacion_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gishora_creacion_Visible"));
               AV19Att_unidades_giscreado_por_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_giscreado_por_Visible"));
               AV20Att_unidades_gisfecha_modificacion_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gisfecha_modificacion_Visible"));
               AV21Att_unidades_gishora_modificacion_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gishora_modificacion_Visible"));
               AV22Att_unidades_gismodificado_por_Visible = StringUtil.StrToBool( GetPar( "Att_unidades_gismodificado_por_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV57Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

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
            return "unidades_gis_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bt_masterpage", "GeneXus.Programs.k2bt_masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA5E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5E2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2024188212599", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwunidades_gis.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV41K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vNOMBRE_UNIDAD", AV30nombre_unidad);
         GxWebStd.gx_hidden_field( context, "GXH_vUNIDADES_GISFECHA_CREACION_FROM", context.localUtil.Format(AV32unidades_gisfecha_creacion_From, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vUNIDADES_GISFECHA_MODIFICACION_FROM", context.localUtil.Format(AV35unidades_gisfecha_modificacion_From, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_174", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_174), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV39FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV39FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV40DeletedTag));
         GxWebStd.gx_hidden_field( context, "vUNIDADES_GISFECHA_CREACION_TO", context.localUtil.DToC( AV33unidades_gisfecha_creacion_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUNIDADES_GISFECHA_MODIFICACION_TO", context.localUtil.DToC( AV36unidades_gisfecha_modificacion_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV43GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV43GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV29ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV29ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vNOMBRE_UNIDAD_ISAUTHORIZED", AV48nombre_unidad_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV57Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUNIDADES_GISFECHA_CREACION_FROM", context.localUtil.DToC( AV32unidades_gisfecha_creacion_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUNIDADES_GISFECHA_MODIFICACION_FROM", context.localUtil.DToC( AV35unidades_gisfecha_modificacion_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSUMMARYTAGSUC_Emptystatemessage", StringUtil.RTrim( Filtersummarytagsuc_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwunidades_gis.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWunidades_gis" ;
      }

      public override string GetPgmdesc( )
      {
         return "unidades_gises" ;
      }

      protected void WB5E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "unidades_gises", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "h1");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterglobalcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombinedfilterlayout_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection4_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_174_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV41K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV41K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWunidades_gis.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV39FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV40DeletedTag);
            ucFiltersummarytagsuc.Render(context, "k2btagsviewer", Filtersummarytagsuc_Internalname, "FILTERSUMMARYTAGSUCContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercollapsiblesection_combined_Internalname, divFiltercollapsiblesection_combined_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWunidades_gis.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsfilterscontainer_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterattributestable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_unidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavNombre_unidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNombre_unidad_Internalname, "nombre_unidad", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavNombre_unidad_Internalname, AV30nombre_unidad, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtavNombre_unidad_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockunidades_gisfecha_creacion_Internalname, "fecha_creacion", "", "", lblTextblockunidades_gisfecha_creacion_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* User Defined Control */
            ucUnidades_gisfecha_creacion_daterangepicker.SetProperty("ValueFrom", AV32unidades_gisfecha_creacion_From);
            ucUnidades_gisfecha_creacion_daterangepicker.SetProperty("ValueTo", AV33unidades_gisfecha_creacion_To);
            ucUnidades_gisfecha_creacion_daterangepicker.Render(context, "k2bdaterangepicker", Unidades_gisfecha_creacion_daterangepicker_Internalname, "UNIDADES_GISFECHA_CREACION_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockunidades_gisfecha_modificacion_Internalname, "fecha_modificacion", "", "", lblTextblockunidades_gisfecha_modificacion_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* User Defined Control */
            ucUnidades_gisfecha_modificacion_daterangepicker.SetProperty("ValueFrom", AV35unidades_gisfecha_modificacion_From);
            ucUnidades_gisfecha_modificacion_daterangepicker.SetProperty("ValueTo", AV36unidades_gisfecha_modificacion_To);
            ucUnidades_gisfecha_modificacion_daterangepicker.Render(context, "k2bdaterangepicker", Unidades_gisfecha_modificacion_daterangepicker_Internalname, "UNIDADES_GISFECHA_MODIFICACION_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_57_5E2( true) ;
         }
         else
         {
            wb_table1_57_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_57_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_grid_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"174\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(73), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_unidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_unidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_unidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "nombre_unidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gisestado_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gisfecha_creacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "fecha_creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gishora_creacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "hora_creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_giscreado_por_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "creado_por") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gisfecha_modificacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "fecha_modificacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gishora_modificacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "hora_modificacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidades_gismodificado_por_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "modificado_por") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_unidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A114nombre_unidad);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtnombre_unidad_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_unidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115unidades_gisestado), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gisestado_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gisfecha_creacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A117unidades_gishora_creacion), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gishora_creacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A118unidades_giscreado_por);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_giscreado_por_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gisfecha_modificacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120unidades_gishora_modificacion), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gishora_modificacion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A121unidades_gismodificado_por);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidades_gismodificado_por_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 174 )
         {
            wbEnd = 0;
            nRC_GXsfl_174 = (int)(nGXsfl_174_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_186_5E2( true) ;
         }
         else
         {
            wb_table2_186_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_186_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection8_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolspagingcontainertable_Internalname, divK2btoolspagingcontainertable_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWunidades_gis.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsabstracthiddenitemsgrid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV43GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV45UC_OrderedBy);
            ucK2borderbyusercontrol.Render(context, "k2borderby", K2borderbyusercontrol_Internalname, "K2BORDERBYUSERCONTROLContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 174 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5E2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "unidades_gises", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5E0( ) ;
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERSUMMARYTAGSUC.TAGDELETED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E135E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E145E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E155E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E165E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E175E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E185E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E195E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E205E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_174_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_174_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_174_idx), 4, 0), 4, "0");
                              SubsflControlProps_1742( ) ;
                              A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ","));
                              A114nombre_unidad = cgiGet( edtnombre_unidad_Internalname);
                              n114nombre_unidad = false;
                              A115unidades_gisestado = (int)(context.localUtil.CToN( cgiGet( edtunidades_gisestado_Internalname), ".", ","));
                              n115unidades_gisestado = false;
                              A116unidades_gisfecha_creacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtunidades_gisfecha_creacion_Internalname), 0));
                              n116unidades_gisfecha_creacion = false;
                              A117unidades_gishora_creacion = (int)(context.localUtil.CToN( cgiGet( edtunidades_gishora_creacion_Internalname), ".", ","));
                              n117unidades_gishora_creacion = false;
                              A118unidades_giscreado_por = cgiGet( edtunidades_giscreado_por_Internalname);
                              n118unidades_giscreado_por = false;
                              A119unidades_gisfecha_modificacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtunidades_gisfecha_modificacion_Internalname), 0));
                              n119unidades_gisfecha_modificacion = false;
                              A120unidades_gishora_modificacion = (int)(context.localUtil.CToN( cgiGet( edtunidades_gishora_modificacion_Internalname), ".", ","));
                              n120unidades_gishora_modificacion = false;
                              A121unidades_gismodificado_por = cgiGet( edtunidades_gismodificado_por_Internalname);
                              n121unidades_gismodificado_por = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E215E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E225E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E235E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E245E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV41K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Nombre_unidad Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE_UNIDAD"), AV30nombre_unidad) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Unidades_gisfecha_creacion_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUNIDADES_GISFECHA_CREACION_FROM"), 0) != AV32unidades_gisfecha_creacion_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Unidades_gisfecha_modificacion_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUNIDADES_GISFECHA_MODIFICACION_FROM"), 0) != AV35unidades_gisfecha_modificacion_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA5E2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1742( ) ;
         while ( nGXsfl_174_idx <= nRC_GXsfl_174 )
         {
            sendrow_1742( ) ;
            nGXsfl_174_idx = ((subGrid_Islastpage==1)&&(nGXsfl_174_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_174_idx+1);
            sGXsfl_174_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_174_idx), 4, 0), 4, "0");
            SubsflControlProps_1742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV41K2BToolsGenericSearchField ,
                                       string AV30nombre_unidad ,
                                       DateTime AV32unidades_gisfecha_creacion_From ,
                                       DateTime AV35unidades_gisfecha_modificacion_From ,
                                       GxSimpleCollection<string> AV29ClassCollection ,
                                       short AV42OrderedBy ,
                                       DateTime AV33unidades_gisfecha_creacion_To ,
                                       DateTime AV36unidades_gisfecha_modificacion_To ,
                                       string AV60Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV48nombre_unidad_IsAuthorized ,
                                       bool AV14Att_id_unidad_Visible ,
                                       bool AV15Att_nombre_unidad_Visible ,
                                       bool AV16Att_unidades_gisestado_Visible ,
                                       bool AV17Att_unidades_gisfecha_creacion_Visible ,
                                       bool AV18Att_unidades_gishora_creacion_Visible ,
                                       bool AV19Att_unidades_giscreado_por_Visible ,
                                       bool AV20Att_unidades_gisfecha_modificacion_Visible ,
                                       bool AV21Att_unidades_gishora_modificacion_Visible ,
                                       bool AV22Att_unidades_gismodificado_por_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV57Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E225E2 ();
         GRID_nCurrentRecord = 0;
         RF5E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV14Att_id_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_id_unidad_Visible));
         AssignAttri("", false, "AV14Att_id_unidad_Visible", AV14Att_id_unidad_Visible);
         AV15Att_nombre_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_nombre_unidad_Visible));
         AssignAttri("", false, "AV15Att_nombre_unidad_Visible", AV15Att_nombre_unidad_Visible);
         AV16Att_unidades_gisestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_unidades_gisestado_Visible));
         AssignAttri("", false, "AV16Att_unidades_gisestado_Visible", AV16Att_unidades_gisestado_Visible);
         AV17Att_unidades_gisfecha_creacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_unidades_gisfecha_creacion_Visible));
         AssignAttri("", false, "AV17Att_unidades_gisfecha_creacion_Visible", AV17Att_unidades_gisfecha_creacion_Visible);
         AV18Att_unidades_gishora_creacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_unidades_gishora_creacion_Visible));
         AssignAttri("", false, "AV18Att_unidades_gishora_creacion_Visible", AV18Att_unidades_gishora_creacion_Visible);
         AV19Att_unidades_giscreado_por_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_unidades_giscreado_por_Visible));
         AssignAttri("", false, "AV19Att_unidades_giscreado_por_Visible", AV19Att_unidades_giscreado_por_Visible);
         AV20Att_unidades_gisfecha_modificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_unidades_gisfecha_modificacion_Visible));
         AssignAttri("", false, "AV20Att_unidades_gisfecha_modificacion_Visible", AV20Att_unidades_gisfecha_modificacion_Visible);
         AV21Att_unidades_gishora_modificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_unidades_gishora_modificacion_Visible));
         AssignAttri("", false, "AV21Att_unidades_gishora_modificacion_Visible", AV21Att_unidades_gishora_modificacion_Visible);
         AV22Att_unidades_gismodificado_por_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_unidades_gismodificado_por_Visible));
         AssignAttri("", false, "AV22Att_unidades_gismodificado_por_Visible", AV22Att_unidades_gismodificado_por_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV23GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV23GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E225E2 ();
         RF5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "WWunidades_gis";
         context.Gx_err = 0;
      }

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 174;
         E235E2 ();
         nGXsfl_174_idx = 1;
         sGXsfl_174_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_174_idx), 4, 0), 4, "0");
         SubsflControlProps_1742( ) ;
         bGXsfl_174_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1742( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 1 : GRID_nFirstRecordOnPage+1));
            GXPagingTo2 = (int)(((subGrid_Rows==0) ? 10000 : GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )+1));
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV30nombre_unidad ,
                                                 AV33unidades_gisfecha_creacion_To ,
                                                 AV32unidades_gisfecha_creacion_From ,
                                                 AV36unidades_gisfecha_modificacion_To ,
                                                 AV35unidades_gisfecha_modificacion_From ,
                                                 AV41K2BToolsGenericSearchField ,
                                                 A114nombre_unidad ,
                                                 A116unidades_gisfecha_creacion ,
                                                 A119unidades_gisfecha_modificacion ,
                                                 A103id_unidad ,
                                                 A115unidades_gisestado ,
                                                 A117unidades_gishora_creacion ,
                                                 A118unidades_giscreado_por ,
                                                 A120unidades_gishora_modificacion ,
                                                 A121unidades_gismodificado_por ,
                                                 AV42OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV30nombre_unidad = StringUtil.Concat( StringUtil.RTrim( AV30nombre_unidad), "%", "");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H005E2 */
            pr_datastore1.execute(0, new Object[] {lV30nombre_unidad, AV33unidades_gisfecha_creacion_To, AV32unidades_gisfecha_creacion_From, AV36unidades_gisfecha_modificacion_To, AV35unidades_gisfecha_modificacion_From, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingFrom2, GXPagingTo2});
            nGXsfl_174_idx = 1;
            sGXsfl_174_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_174_idx), 4, 0), 4, "0");
            SubsflControlProps_1742( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A121unidades_gismodificado_por = H005E2_A121unidades_gismodificado_por[0];
               n121unidades_gismodificado_por = H005E2_n121unidades_gismodificado_por[0];
               A120unidades_gishora_modificacion = H005E2_A120unidades_gishora_modificacion[0];
               n120unidades_gishora_modificacion = H005E2_n120unidades_gishora_modificacion[0];
               A119unidades_gisfecha_modificacion = H005E2_A119unidades_gisfecha_modificacion[0];
               n119unidades_gisfecha_modificacion = H005E2_n119unidades_gisfecha_modificacion[0];
               A118unidades_giscreado_por = H005E2_A118unidades_giscreado_por[0];
               n118unidades_giscreado_por = H005E2_n118unidades_giscreado_por[0];
               A117unidades_gishora_creacion = H005E2_A117unidades_gishora_creacion[0];
               n117unidades_gishora_creacion = H005E2_n117unidades_gishora_creacion[0];
               A116unidades_gisfecha_creacion = H005E2_A116unidades_gisfecha_creacion[0];
               n116unidades_gisfecha_creacion = H005E2_n116unidades_gisfecha_creacion[0];
               A115unidades_gisestado = H005E2_A115unidades_gisestado[0];
               n115unidades_gisestado = H005E2_n115unidades_gisestado[0];
               A114nombre_unidad = H005E2_A114nombre_unidad[0];
               n114nombre_unidad = H005E2_n114nombre_unidad[0];
               A103id_unidad = H005E2_A103id_unidad[0];
               E245E2 ();
               pr_datastore1.readNext(0);
            }
            GRID_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 174;
            WB5E0( ) ;
         }
         bGXsfl_174_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV57Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Uri, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_datastore1.dynParam(1, new Object[]{ new Object[]{
                                              AV30nombre_unidad ,
                                              AV33unidades_gisfecha_creacion_To ,
                                              AV32unidades_gisfecha_creacion_From ,
                                              AV36unidades_gisfecha_modificacion_To ,
                                              AV35unidades_gisfecha_modificacion_From ,
                                              AV41K2BToolsGenericSearchField ,
                                              A114nombre_unidad ,
                                              A116unidades_gisfecha_creacion ,
                                              A119unidades_gisfecha_modificacion ,
                                              A103id_unidad ,
                                              A115unidades_gisestado ,
                                              A117unidades_gishora_creacion ,
                                              A118unidades_giscreado_por ,
                                              A120unidades_gishora_modificacion ,
                                              A121unidades_gismodificado_por ,
                                              AV42OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV30nombre_unidad = StringUtil.Concat( StringUtil.RTrim( AV30nombre_unidad), "%", "");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         lV41K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV41K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H005E3 */
         pr_datastore1.execute(1, new Object[] {lV30nombre_unidad, AV33unidades_gisfecha_creacion_To, AV32unidades_gisfecha_creacion_From, AV36unidades_gisfecha_modificacion_To, AV35unidades_gisfecha_modificacion_From, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField, lV41K2BToolsGenericSearchField});
         GRID_nRecordCount = H005E3_AGRID_nRecordCount[0];
         pr_datastore1.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "WWunidades_gis";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E215E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV39FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV43GridOrders);
            /* Read saved values. */
            nRC_GXsfl_174 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_174"), ".", ","));
            AV40DeletedTag = cgiGet( "vDELETEDTAG");
            AV32unidades_gisfecha_creacion_From = context.localUtil.CToD( cgiGet( "vUNIDADES_GISFECHA_CREACION_FROM"), 0);
            AV33unidades_gisfecha_creacion_To = context.localUtil.CToD( cgiGet( "vUNIDADES_GISFECHA_CREACION_TO"), 0);
            AV35unidades_gisfecha_modificacion_From = context.localUtil.CToD( cgiGet( "vUNIDADES_GISFECHA_MODIFICACION_FROM"), 0);
            AV36unidades_gisfecha_modificacion_To = context.localUtil.CToD( cgiGet( "vUNIDADES_GISFECHA_MODIFICACION_TO"), 0);
            AV45UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV42OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV41K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV41K2BToolsGenericSearchField", AV41K2BToolsGenericSearchField);
            AV30nombre_unidad = cgiGet( edtavNombre_unidad_Internalname);
            AssignAttri("", false, "AV30nombre_unidad", AV30nombre_unidad);
            AV14Att_id_unidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_unidad_visible_Internalname));
            AssignAttri("", false, "AV14Att_id_unidad_Visible", AV14Att_id_unidad_Visible);
            AV15Att_nombre_unidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_unidad_visible_Internalname));
            AssignAttri("", false, "AV15Att_nombre_unidad_Visible", AV15Att_nombre_unidad_Visible);
            AV16Att_unidades_gisestado_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gisestado_visible_Internalname));
            AssignAttri("", false, "AV16Att_unidades_gisestado_Visible", AV16Att_unidades_gisestado_Visible);
            AV17Att_unidades_gisfecha_creacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gisfecha_creacion_visible_Internalname));
            AssignAttri("", false, "AV17Att_unidades_gisfecha_creacion_Visible", AV17Att_unidades_gisfecha_creacion_Visible);
            AV18Att_unidades_gishora_creacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gishora_creacion_visible_Internalname));
            AssignAttri("", false, "AV18Att_unidades_gishora_creacion_Visible", AV18Att_unidades_gishora_creacion_Visible);
            AV19Att_unidades_giscreado_por_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_giscreado_por_visible_Internalname));
            AssignAttri("", false, "AV19Att_unidades_giscreado_por_Visible", AV19Att_unidades_giscreado_por_Visible);
            AV20Att_unidades_gisfecha_modificacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gisfecha_modificacion_visible_Internalname));
            AssignAttri("", false, "AV20Att_unidades_gisfecha_modificacion_Visible", AV20Att_unidades_gisfecha_modificacion_Visible);
            AV21Att_unidades_gishora_modificacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gishora_modificacion_visible_Internalname));
            AssignAttri("", false, "AV21Att_unidades_gishora_modificacion_Visible", AV21Att_unidades_gishora_modificacion_Visible);
            AV22Att_unidades_gismodificado_por_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidades_gismodificado_por_visible_Internalname));
            AssignAttri("", false, "AV22Att_unidades_gismodificado_por_Visible", AV22Att_unidades_gismodificado_por_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV23GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV23GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV41K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE_UNIDAD"), AV30nombre_unidad) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUNIDADES_GISFECHA_CREACION_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV32unidades_gisfecha_creacion_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUNIDADES_GISFECHA_MODIFICACION_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV35unidades_gisfecha_modificacion_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E215E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV30nombre_unidad = "";
         AssignAttri("", false, "AV30nombre_unidad", AV30nombre_unidad);
         AV31unidades_gisfecha_creacion = DateTime.MinValue;
         AV32unidades_gisfecha_creacion_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV32unidades_gisfecha_creacion_From", context.localUtil.Format(AV32unidades_gisfecha_creacion_From, "99/99/99"));
         AV33unidades_gisfecha_creacion_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV33unidades_gisfecha_creacion_To", context.localUtil.Format(AV33unidades_gisfecha_creacion_To, "99/99/99"));
         AV34unidades_gisfecha_modificacion = DateTime.MinValue;
         AV35unidades_gisfecha_modificacion_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV35unidades_gisfecha_modificacion_From", context.localUtil.Format(AV35unidades_gisfecha_modificacion_From, "99/99/99"));
         AV36unidades_gisfecha_modificacion_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV36unidades_gisfecha_modificacion_To", context.localUtil.Format(AV36unidades_gisfecha_modificacion_To, "99/99/99"));
         new k2bloadrowsperpage(context ).execute(  AV60Pgmname,  "Grid", out  AV24RowsPerPageVariable, out  AV25RowsPerPageLoaded) ;
         AssignAttri("", false, "AV24RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24RowsPerPageVariable), 4, 0));
         if ( ! AV25RowsPerPageLoaded )
         {
            AV24RowsPerPageVariable = 20;
            AssignAttri("", false, "AV24RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24RowsPerPageVariable), 4, 0));
         }
         AV23GridSettingsRowsPerPageVariable = AV24RowsPerPageVariable;
         AssignAttri("", false, "AV23GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV24RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "unidades_gises";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, "", false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV43GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV44GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV44GridOrder.gxTpr_Ascendingorder = 0;
         AV44GridOrder.gxTpr_Descendingorder = 1;
         AV44GridOrder.gxTpr_Gridcolumnindex = 1;
         AV43GridOrders.Add(AV44GridOrder, 0);
         AV44GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV44GridOrder.gxTpr_Ascendingorder = 2;
         AV44GridOrder.gxTpr_Descendingorder = 3;
         AV44GridOrder.gxTpr_Gridcolumnindex = 2;
         AV43GridOrders.Add(AV44GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E225E2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV46Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV46Messages = GXt_objcol_SdtMessages_Message1;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV46Messages.Count )
         {
            AV47Message = ((GeneXus.Utils.SdtMessages_Message)AV46Messages.Item(AV61GXV1));
            GX_msglist.addItem(AV47Message.gxTpr_Description);
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV53ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV54ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV60Pgmname;
         AV53ActivityList.Add(AV54ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV53ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV29ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV26GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV60Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV42OrderedBy = AV27GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV42OrderedBy", StringUtil.LTrimStr( (decimal)(AV42OrderedBy), 4, 0));
         AV45UC_OrderedBy = AV27GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV45UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV45UC_OrderedBy), 4, 0));
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "nombre_unidad") == 0 )
            {
               AV30nombre_unidad = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30nombre_unidad", AV30nombre_unidad);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "unidades_gisfecha_creacion:From") == 0 )
            {
               AV32unidades_gisfecha_creacion_From = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV32unidades_gisfecha_creacion_From", context.localUtil.Format(AV32unidades_gisfecha_creacion_From, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "unidades_gisfecha_creacion:To") == 0 )
            {
               AV33unidades_gisfecha_creacion_To = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV33unidades_gisfecha_creacion_To", context.localUtil.Format(AV33unidades_gisfecha_creacion_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "unidades_gisfecha_modificacion:From") == 0 )
            {
               AV35unidades_gisfecha_modificacion_From = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV35unidades_gisfecha_modificacion_From", context.localUtil.Format(AV35unidades_gisfecha_modificacion_From, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "unidades_gisfecha_modificacion:To") == 0 )
            {
               AV36unidades_gisfecha_modificacion_To = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV36unidades_gisfecha_modificacion_To", context.localUtil.Format(AV36unidades_gisfecha_modificacion_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV41K2BToolsGenericSearchField = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41K2BToolsGenericSearchField", AV41K2BToolsGenericSearchField);
            }
            AV62GXV2 = (int)(AV62GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV27GridState.gxTpr_Currentpage > 0 ) && ( AV27GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV27GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV26GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV60Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV27GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV27GridState.gxTpr_Orderedby = AV42OrderedBy;
         AV27GridState.gxTpr_Filtervalues.Clear();
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "nombre_unidad";
         AV28GridStateFilterValue.gxTpr_Value = AV30nombre_unidad;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "unidades_gisfecha_creacion:From";
         AV28GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV32unidades_gisfecha_creacion_From, "99/99/99");
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "unidades_gisfecha_creacion:To";
         AV28GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV33unidades_gisfecha_creacion_To, "99/99/99");
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "unidades_gisfecha_modificacion:From";
         AV28GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV35unidades_gisfecha_modificacion_From, "99/99/99");
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "unidades_gisfecha_modificacion:To";
         AV28GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV36unidades_gisfecha_modificacion_To, "99/99/99");
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV28GridStateFilterValue.gxTpr_Value = AV41K2BToolsGenericSearchField;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV60Pgmname,  AV26GridStateKey,  AV27GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV51TrnContext = new SdtK2BTrnContext(context);
         AV51TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV51TrnContext.gxTpr_Returnmode = "Stack";
         AV51TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV51TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV51TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV51TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV51TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV51TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "unidades_gis",  AV51TrnContext) ;
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtid_unidad_Visible = 1;
         AssignProp("", false, edtid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV14Att_id_unidad_Visible = true;
         AssignAttri("", false, "AV14Att_id_unidad_Visible", AV14Att_id_unidad_Visible);
         edtnombre_unidad_Visible = 1;
         AssignProp("", false, edtnombre_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV15Att_nombre_unidad_Visible = true;
         AssignAttri("", false, "AV15Att_nombre_unidad_Visible", AV15Att_nombre_unidad_Visible);
         edtunidades_gisestado_Visible = 1;
         AssignProp("", false, edtunidades_gisestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisestado_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV16Att_unidades_gisestado_Visible = true;
         AssignAttri("", false, "AV16Att_unidades_gisestado_Visible", AV16Att_unidades_gisestado_Visible);
         edtunidades_gisfecha_creacion_Visible = 1;
         AssignProp("", false, edtunidades_gisfecha_creacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_creacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV17Att_unidades_gisfecha_creacion_Visible = true;
         AssignAttri("", false, "AV17Att_unidades_gisfecha_creacion_Visible", AV17Att_unidades_gisfecha_creacion_Visible);
         edtunidades_gishora_creacion_Visible = 1;
         AssignProp("", false, edtunidades_gishora_creacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_creacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV18Att_unidades_gishora_creacion_Visible = true;
         AssignAttri("", false, "AV18Att_unidades_gishora_creacion_Visible", AV18Att_unidades_gishora_creacion_Visible);
         edtunidades_giscreado_por_Visible = 1;
         AssignProp("", false, edtunidades_giscreado_por_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_giscreado_por_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV19Att_unidades_giscreado_por_Visible = true;
         AssignAttri("", false, "AV19Att_unidades_giscreado_por_Visible", AV19Att_unidades_giscreado_por_Visible);
         edtunidades_gisfecha_modificacion_Visible = 1;
         AssignProp("", false, edtunidades_gisfecha_modificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_modificacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV20Att_unidades_gisfecha_modificacion_Visible = true;
         AssignAttri("", false, "AV20Att_unidades_gisfecha_modificacion_Visible", AV20Att_unidades_gisfecha_modificacion_Visible);
         edtunidades_gishora_modificacion_Visible = 1;
         AssignProp("", false, edtunidades_gishora_modificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_modificacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV21Att_unidades_gishora_modificacion_Visible = true;
         AssignAttri("", false, "AV21Att_unidades_gishora_modificacion_Visible", AV21Att_unidades_gishora_modificacion_Visible);
         edtunidades_gismodificado_por_Visible = 1;
         AssignProp("", false, edtunidades_gismodificado_por_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gismodificado_por_Visible), 5, 0), !bGXsfl_174_Refreshing);
         AV22Att_unidades_gismodificado_por_Visible = true;
         AssignAttri("", false, "AV22Att_unidades_gismodificado_por_Visible", AV22Att_unidades_gismodificado_por_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV60Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV63GXV3 = 1;
         while ( AV63GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV63GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
               {
                  edtid_unidad_Visible = 0;
                  AssignProp("", false, edtid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV14Att_id_unidad_Visible = false;
                  AssignAttri("", false, "AV14Att_id_unidad_Visible", AV14Att_id_unidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
               {
                  edtnombre_unidad_Visible = 0;
                  AssignProp("", false, edtnombre_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV15Att_nombre_unidad_Visible = false;
                  AssignAttri("", false, "AV15Att_nombre_unidad_Visible", AV15Att_nombre_unidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisestado") == 0 )
               {
                  edtunidades_gisestado_Visible = 0;
                  AssignProp("", false, edtunidades_gisestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisestado_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV16Att_unidades_gisestado_Visible = false;
                  AssignAttri("", false, "AV16Att_unidades_gisestado_Visible", AV16Att_unidades_gisestado_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisfecha_creacion") == 0 )
               {
                  edtunidades_gisfecha_creacion_Visible = 0;
                  AssignProp("", false, edtunidades_gisfecha_creacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_creacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV17Att_unidades_gisfecha_creacion_Visible = false;
                  AssignAttri("", false, "AV17Att_unidades_gisfecha_creacion_Visible", AV17Att_unidades_gisfecha_creacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gishora_creacion") == 0 )
               {
                  edtunidades_gishora_creacion_Visible = 0;
                  AssignProp("", false, edtunidades_gishora_creacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_creacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV18Att_unidades_gishora_creacion_Visible = false;
                  AssignAttri("", false, "AV18Att_unidades_gishora_creacion_Visible", AV18Att_unidades_gishora_creacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_giscreado_por") == 0 )
               {
                  edtunidades_giscreado_por_Visible = 0;
                  AssignProp("", false, edtunidades_giscreado_por_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_giscreado_por_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV19Att_unidades_giscreado_por_Visible = false;
                  AssignAttri("", false, "AV19Att_unidades_giscreado_por_Visible", AV19Att_unidades_giscreado_por_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisfecha_modificacion") == 0 )
               {
                  edtunidades_gisfecha_modificacion_Visible = 0;
                  AssignProp("", false, edtunidades_gisfecha_modificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_modificacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV20Att_unidades_gisfecha_modificacion_Visible = false;
                  AssignAttri("", false, "AV20Att_unidades_gisfecha_modificacion_Visible", AV20Att_unidades_gisfecha_modificacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gishora_modificacion") == 0 )
               {
                  edtunidades_gishora_modificacion_Visible = 0;
                  AssignProp("", false, edtunidades_gishora_modificacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_modificacion_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV21Att_unidades_gishora_modificacion_Visible = false;
                  AssignAttri("", false, "AV21Att_unidades_gishora_modificacion_Visible", AV21Att_unidades_gishora_modificacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gismodificado_por") == 0 )
               {
                  edtunidades_gismodificado_por_Visible = 0;
                  AssignProp("", false, edtunidades_gismodificado_por_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidades_gismodificado_por_Visible), 5, 0), !bGXsfl_174_Refreshing);
                  AV22Att_unidades_gismodificado_por_Visible = false;
                  AssignAttri("", false, "AV22Att_unidades_gismodificado_por_Visible", AV22Att_unidades_gismodificado_por_Visible);
               }
            }
            AV63GXV3 = (int)(AV63GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_unidad";
         AV13GridColumn.gxTpr_Columntitle = "id_unidad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_unidad";
         AV13GridColumn.gxTpr_Columntitle = "nombre_unidad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gisestado";
         AV13GridColumn.gxTpr_Columntitle = "estado";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gisfecha_creacion";
         AV13GridColumn.gxTpr_Columntitle = "fecha_creacion";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gishora_creacion";
         AV13GridColumn.gxTpr_Columntitle = "hora_creacion";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_giscreado_por";
         AV13GridColumn.gxTpr_Columntitle = "creado_por";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gisfecha_modificacion";
         AV13GridColumn.gxTpr_Columntitle = "fecha_modificacion";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gishora_modificacion";
         AV13GridColumn.gxTpr_Columntitle = "hora_modificacion";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidades_gismodificado_por";
         AV13GridColumn.gxTpr_Columntitle = "modificado_por";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV10GridConfiguration.gxTpr_Gridcolumns = AV12GridColumns;
      }

      protected void S142( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV53ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV54ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWunidades_gis";
         AV53ActivityList.Add(AV54ActivityListItem, 0);
         AV54ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWunidades_gis";
         AV53ActivityList.Add(AV54ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV53ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV53ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV54ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "unidades_gis";
         AV54ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerunidades_gis";
         AV53ActivityList.Add(AV54ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV53ActivityList) ;
         AV48nombre_unidad_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV53ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV48nombre_unidad_IsAuthorized", AV48nombre_unidad_IsAuthorized);
      }

      protected void S152( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         returnInSub = false;
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E235E2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV29ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV45UC_OrderedBy = AV42OrderedBy;
         AssignAttri("", false, "AV45UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV45UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV29ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39FilterTags", AV39FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E245E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV48nombre_unidad_IsAuthorized )
         {
            edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
         }
         else
         {
            edtnombre_unidad_Link = "";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 174;
         }
         sendrow_1742( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_174_Refreshing )
         {
            context.DoAjaxLoad(174, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV37K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30nombre_unidad)) )
         {
            AV38K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV38K2BFilterValuesSDTItem.gxTpr_Name = "nombre_unidad";
            AV38K2BFilterValuesSDTItem.gxTpr_Description = "nombre_unidad";
            AV38K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV38K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV38K2BFilterValuesSDTItem.gxTpr_Value = AV30nombre_unidad;
            AV38K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV30nombre_unidad;
            AV37K2BFilterValuesSDT.Add(AV38K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV32unidades_gisfecha_creacion_From) || ! (DateTime.MinValue==AV33unidades_gisfecha_creacion_To) )
         {
            AV38K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV38K2BFilterValuesSDTItem.gxTpr_Name = "unidades_gisfecha_creacion";
            AV38K2BFilterValuesSDTItem.gxTpr_Description = "fecha_creacion";
            AV38K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV38K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV38K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV32unidades_gisfecha_creacion_From ) ;
            AV38K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV33unidades_gisfecha_creacion_To ) ;
            AV38K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV37K2BFilterValuesSDT.Add(AV38K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV35unidades_gisfecha_modificacion_From) || ! (DateTime.MinValue==AV36unidades_gisfecha_modificacion_To) )
         {
            AV38K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV38K2BFilterValuesSDTItem.gxTpr_Name = "unidades_gisfecha_modificacion";
            AV38K2BFilterValuesSDTItem.gxTpr_Description = "fecha_modificacion";
            AV38K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV38K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV38K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV35unidades_gisfecha_modificacion_From ) ;
            AV38K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36unidades_gisfecha_modificacion_To ) ;
            AV38K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV37K2BFilterValuesSDT.Add(AV38K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV37K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV39FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV60Pgmname,  "Grid",  AV37K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV39FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E115E2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40DeletedTag, "nombre_unidad") == 0 )
         {
            AV30nombre_unidad = "";
            AssignAttri("", false, "AV30nombre_unidad", AV30nombre_unidad);
         }
         else if ( StringUtil.StrCmp(AV40DeletedTag, "unidades_gisfecha_creacion") == 0 )
         {
            AV32unidades_gisfecha_creacion_From = DateTime.MinValue;
            AssignAttri("", false, "AV32unidades_gisfecha_creacion_From", context.localUtil.Format(AV32unidades_gisfecha_creacion_From, "99/99/99"));
            AV33unidades_gisfecha_creacion_To = DateTime.MinValue;
            AssignAttri("", false, "AV33unidades_gisfecha_creacion_To", context.localUtil.Format(AV33unidades_gisfecha_creacion_To, "99/99/99"));
         }
         else if ( StringUtil.StrCmp(AV40DeletedTag, "unidades_gisfecha_modificacion") == 0 )
         {
            AV35unidades_gisfecha_modificacion_From = DateTime.MinValue;
            AssignAttri("", false, "AV35unidades_gisfecha_modificacion_From", context.localUtil.Format(AV35unidades_gisfecha_modificacion_From, "99/99/99"));
            AV36unidades_gisfecha_modificacion_To = DateTime.MinValue;
            AssignAttri("", false, "AV36unidades_gisfecha_modificacion_To", context.localUtil.Format(AV36unidades_gisfecha_modificacion_To, "99/99/99"));
         }
         gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void E125E2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV42OrderedBy = AV45UC_OrderedBy;
         AssignAttri("", false, "AV42OrderedBy", StringUtil.LTrimStr( (decimal)(AV42OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void E135E2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV60Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV64GXV4 = 1;
         while ( AV64GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV64GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_id_unidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_nombre_unidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisestado") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_unidades_gisestado_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisfecha_creacion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_unidades_gisfecha_creacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gishora_creacion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_unidades_gishora_creacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_giscreado_por") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV19Att_unidades_giscreado_por_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gisfecha_modificacion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_unidades_gisfecha_modificacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gishora_modificacion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV21Att_unidades_gishora_modificacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidades_gismodificado_por") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV22Att_unidades_gismodificado_por_Visible;
            }
            AV64GXV4 = (int)(AV64GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV60Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV45UC_OrderedBy = AV42OrderedBy;
         AssignAttri("", false, "AV45UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV45UC_OrderedBy), 4, 0));
         if ( AV24RowsPerPageVariable != AV23GridSettingsRowsPerPageVariable )
         {
            AV24RowsPerPageVariable = AV23GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV24RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV24RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV60Pgmname,  "Grid",  AV24RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV41K2BToolsGenericSearchField, AV30nombre_unidad, AV32unidades_gisfecha_creacion_From, AV35unidades_gisfecha_modificacion_From, AV29ClassCollection, AV42OrderedBy, AV33unidades_gisfecha_creacion_To, AV36unidades_gisfecha_modificacion_To, AV60Pgmname, AV8CurrentPage, AV10GridConfiguration, AV48nombre_unidad_IsAuthorized, AV14Att_id_unidad_Visible, AV15Att_nombre_unidad_Visible, AV16Att_unidades_gisestado_Visible, AV17Att_unidades_gisfecha_creacion_Visible, AV18Att_unidades_gishora_creacion_Visible, AV19Att_unidades_giscreado_por_Visible, AV20Att_unidades_gisfecha_modificacion_Visible, AV21Att_unidades_gishora_modificacion_Visible, AV22Att_unidades_gismodificado_por_Visible, AV11FreezeColumnTitles, AV57Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void S172( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV8CurrentPage > AV9K2BMaxPages ) && ( AV9K2BMaxPages > 0 ) )
         {
            AV8CurrentPage = AV9K2BMaxPages;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefresh();
         }
         if ( AV9K2BMaxPages == 0 )
         {
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         else
         {
            AV8CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp("", false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage-1), 10, 0);
         AssignProp("", false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage), 5, 0);
         AssignProp("", false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage+1), 10, 0);
         AssignProp("", false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV9K2BMaxPages), 6, 0);
         AssignProp("", false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV8CurrentPage) || ( AV8CurrentPage <= 1 ) )
         {
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblPreviouspagetextblock_Visible = 1;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == 2 )
            {
               lblFirstpagetextblock_Visible = 0;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblFirstpagetextblock_Visible = 1;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == 3 )
               {
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV8CurrentPage == AV9K2BMaxPages )
         {
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            lblNextpagetextblock_Visible = 0;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblNextpagetextblock_Visible = 1;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == AV9K2BMaxPages - 1 )
            {
               lblLastpagetextblock_Visible = 0;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblLastpagetextblock_Visible = 1;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == AV9K2BMaxPages - 2 )
               {
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV8CurrentPage <= 1 ) && ( AV9K2BMaxPages <= 1 ) )
         {
            divK2btoolspagingcontainertable_Visible = 0;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            divK2btoolspagingcontainertable_Visible = 1;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E145E2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV8CurrentPage = 1;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void E155E2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV8CurrentPage > 1 )
         {
            AV8CurrentPage = (int)(AV8CurrentPage-1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void E165E2( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV8CurrentPage != AV9K2BMaxPages )
         {
            AV8CurrentPage = (int)(AV8CurrentPage+1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_nextpage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void E175E2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         AV8CurrentPage = AV9K2BMaxPages;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ClassCollection", AV29ClassCollection);
      }

      protected void S162( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV60Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S232( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11FreezeColumnTitles = AV10GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         if ( AV11FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV29ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV29ClassCollection) ;
         }
      }

      protected void E185E2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "unidades_gis",  "unidades_gis",  "List",  "",  "ExportWWunidades_gis") )
         {
            new exportwwunidades_gis(context ).execute(  AV30nombre_unidad,  AV32unidades_gisfecha_creacion_From,  AV33unidades_gisfecha_creacion_To,  AV35unidades_gisfecha_modificacion_From,  AV36unidades_gisfecha_modificacion_To,  AV41K2BToolsGenericSearchField,  AV42OrderedBy, out  AV55OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV55OutFile, out  AV57Uri) )
            {
               CallWebObject(formatLink(AV57Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV56Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV56Guid.ToString(),  AV55OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV56Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E195E2( )
      {
         /* Filtertoggle_combined_Click Routine */
         returnInSub = false;
         if ( divFiltercollapsiblesection_combined_Visible != 0 )
         {
            divFiltercollapsiblesection_combined_Visible = 0;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         else
         {
            divFiltercollapsiblesection_combined_Visible = 1;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E205E2( )
      {
         /* Filterclose_combined_Click Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void wb_table2_186_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblNoresultsfoundtable_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblNoresultsfoundtable_Internalname, tblNoresultsfoundtable_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_186_5E2e( true) ;
         }
         else
         {
            wb_table2_186_5E2e( false) ;
         }
      }

      protected void wb_table1_57_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e255e1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingscontentoutertable_Internalname, divK2bgridsettingscontentoutertable_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettingstable_content_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divId_unidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_unidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_unidad_visible_Internalname, "id_unidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_unidad_visible_Internalname, StringUtil.BoolToStr( AV14Att_id_unidad_Visible), "", "id_unidad", 1, chkavAtt_id_unidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(86, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,86);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNombre_unidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_unidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_unidad_visible_Internalname, "nombre_unidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_unidad_visible_Internalname, StringUtil.BoolToStr( AV15Att_nombre_unidad_Visible), "", "nombre_unidad", 1, chkavAtt_nombre_unidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(92, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,92);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gisestado_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gisestado_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gisestado_visible_Internalname, "estado", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gisestado_visible_Internalname, StringUtil.BoolToStr( AV16Att_unidades_gisestado_Visible), "", "estado", 1, chkavAtt_unidades_gisestado_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(98, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,98);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gisfecha_creacion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gisfecha_creacion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gisfecha_creacion_visible_Internalname, "fecha_creacion", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gisfecha_creacion_visible_Internalname, StringUtil.BoolToStr( AV17Att_unidades_gisfecha_creacion_Visible), "", "fecha_creacion", 1, chkavAtt_unidades_gisfecha_creacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gishora_creacion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gishora_creacion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gishora_creacion_visible_Internalname, "hora_creacion", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gishora_creacion_visible_Internalname, StringUtil.BoolToStr( AV18Att_unidades_gishora_creacion_Visible), "", "hora_creacion", 1, chkavAtt_unidades_gishora_creacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(110, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,110);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_giscreado_por_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_giscreado_por_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_giscreado_por_visible_Internalname, "creado_por", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_giscreado_por_visible_Internalname, StringUtil.BoolToStr( AV19Att_unidades_giscreado_por_Visible), "", "creado_por", 1, chkavAtt_unidades_giscreado_por_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gisfecha_modificacion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gisfecha_modificacion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gisfecha_modificacion_visible_Internalname, "fecha_modificacion", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gisfecha_modificacion_visible_Internalname, StringUtil.BoolToStr( AV20Att_unidades_gisfecha_modificacion_Visible), "", "fecha_modificacion", 1, chkavAtt_unidades_gisfecha_modificacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(122, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,122);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gishora_modificacion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gishora_modificacion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gishora_modificacion_visible_Internalname, "hora_modificacion", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gishora_modificacion_visible_Internalname, StringUtil.BoolToStr( AV21Att_unidades_gishora_modificacion_Visible), "", "hora_modificacion", 1, chkavAtt_unidades_gishora_modificacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(128, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnidades_gismodificado_por_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidades_gismodificado_por_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidades_gismodificado_por_visible_Internalname, "modificado_por", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidades_gismodificado_por_visible_Internalname, StringUtil.BoolToStr( AV22Att_unidades_gismodificado_por_Visible), "", "modificado_por", 1, chkavAtt_unidades_gismodificado_por_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpagevariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_174_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "", true, 1, "HLP_WWunidades_gis.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (string)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFreezegridcolumntitlescontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_Internalname, "Inmovilizar títulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_174_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(146, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,146);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(174), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, divDownloadsactionssectioncontainer_Visible, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e265e1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWunidades_gis.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadactionstable_Internalname, divDownloadactionstable_Visible, 0, "px", 0, "px", "K2BToolsDownloadActionsTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_160_5E2( true) ;
         }
         else
         {
            wb_table3_160_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_160_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_57_5E2e( true) ;
         }
         else
         {
            wb_table1_57_5E2e( false) ;
         }
      }

      protected void wb_table3_160_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(174), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e275e1_client"+"'", TempTags, "", 2, "HLP_WWunidades_gis.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(174), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWunidades_gis.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_160_5E2e( true) ;
         }
         else
         {
            wb_table3_160_5E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188213316", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wwunidades_gis.js", "?2024188213318", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1742( )
      {
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_174_idx;
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD_"+sGXsfl_174_idx;
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO_"+sGXsfl_174_idx;
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION_"+sGXsfl_174_idx;
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION_"+sGXsfl_174_idx;
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR_"+sGXsfl_174_idx;
         edtunidades_gisfecha_modificacion_Internalname = "UNIDADES_GISFECHA_MODIFICACION_"+sGXsfl_174_idx;
         edtunidades_gishora_modificacion_Internalname = "UNIDADES_GISHORA_MODIFICACION_"+sGXsfl_174_idx;
         edtunidades_gismodificado_por_Internalname = "UNIDADES_GISMODIFICADO_POR_"+sGXsfl_174_idx;
      }

      protected void SubsflControlProps_fel_1742( )
      {
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_174_fel_idx;
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD_"+sGXsfl_174_fel_idx;
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO_"+sGXsfl_174_fel_idx;
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION_"+sGXsfl_174_fel_idx;
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION_"+sGXsfl_174_fel_idx;
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR_"+sGXsfl_174_fel_idx;
         edtunidades_gisfecha_modificacion_Internalname = "UNIDADES_GISFECHA_MODIFICACION_"+sGXsfl_174_fel_idx;
         edtunidades_gishora_modificacion_Internalname = "UNIDADES_GISHORA_MODIFICACION_"+sGXsfl_174_fel_idx;
         edtunidades_gismodificado_por_Internalname = "UNIDADES_GISMODIFICADO_POR_"+sGXsfl_174_fel_idx;
      }

      protected void sendrow_1742( )
      {
         SubsflControlProps_1742( ) ;
         WB5E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_174_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_174_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_174_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_unidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_unidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_unidad_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)73,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_unidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_unidad_Internalname,(string)A114nombre_unidad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtnombre_unidad_Link,(string)"",(string)"",(string)"",(string)edtnombre_unidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtnombre_unidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtunidades_gisestado_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gisestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115unidades_gisestado), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A115unidades_gisestado), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gisestado_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gisestado_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtunidades_gisfecha_creacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gisfecha_creacion_Internalname,context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"),context.localUtil.Format( A116unidades_gisfecha_creacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gisfecha_creacion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gisfecha_creacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtunidades_gishora_creacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gishora_creacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A117unidades_gishora_creacion), 5, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A117unidades_gishora_creacion), "ZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gishora_creacion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gishora_creacion_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtunidades_giscreado_por_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_giscreado_por_Internalname,(string)A118unidades_giscreado_por,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_giscreado_por_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_giscreado_por_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtunidades_gisfecha_modificacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gisfecha_modificacion_Internalname,context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"),context.localUtil.Format( A119unidades_gisfecha_modificacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gisfecha_modificacion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gisfecha_modificacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtunidades_gishora_modificacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gishora_modificacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A120unidades_gishora_modificacion), 5, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A120unidades_gishora_modificacion), "ZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gishora_modificacion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gishora_modificacion_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtunidades_gismodificado_por_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gismodificado_por_Internalname,(string)A121unidades_gismodificado_por,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gismodificado_por_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidades_gismodificado_por_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)174,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes5E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_174_idx = ((subGrid_Islastpage==1)&&(nGXsfl_174_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_174_idx+1);
            sGXsfl_174_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_174_idx), 4, 0), 4, "0");
            SubsflControlProps_1742( ) ;
         }
         /* End function sendrow_1742 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_id_unidad_visible.Name = "vATT_ID_UNIDAD_VISIBLE";
         chkavAtt_id_unidad_visible.WebTags = "";
         chkavAtt_id_unidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_unidad_visible_Internalname, "TitleCaption", chkavAtt_id_unidad_visible.Caption, true);
         chkavAtt_id_unidad_visible.CheckedValue = "false";
         AV14Att_id_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_id_unidad_Visible));
         AssignAttri("", false, "AV14Att_id_unidad_Visible", AV14Att_id_unidad_Visible);
         chkavAtt_nombre_unidad_visible.Name = "vATT_NOMBRE_UNIDAD_VISIBLE";
         chkavAtt_nombre_unidad_visible.WebTags = "";
         chkavAtt_nombre_unidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_unidad_visible_Internalname, "TitleCaption", chkavAtt_nombre_unidad_visible.Caption, true);
         chkavAtt_nombre_unidad_visible.CheckedValue = "false";
         AV15Att_nombre_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_nombre_unidad_Visible));
         AssignAttri("", false, "AV15Att_nombre_unidad_Visible", AV15Att_nombre_unidad_Visible);
         chkavAtt_unidades_gisestado_visible.Name = "vATT_UNIDADES_GISESTADO_VISIBLE";
         chkavAtt_unidades_gisestado_visible.WebTags = "";
         chkavAtt_unidades_gisestado_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gisestado_visible_Internalname, "TitleCaption", chkavAtt_unidades_gisestado_visible.Caption, true);
         chkavAtt_unidades_gisestado_visible.CheckedValue = "false";
         AV16Att_unidades_gisestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_unidades_gisestado_Visible));
         AssignAttri("", false, "AV16Att_unidades_gisestado_Visible", AV16Att_unidades_gisestado_Visible);
         chkavAtt_unidades_gisfecha_creacion_visible.Name = "vATT_UNIDADES_GISFECHA_CREACION_VISIBLE";
         chkavAtt_unidades_gisfecha_creacion_visible.WebTags = "";
         chkavAtt_unidades_gisfecha_creacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gisfecha_creacion_visible_Internalname, "TitleCaption", chkavAtt_unidades_gisfecha_creacion_visible.Caption, true);
         chkavAtt_unidades_gisfecha_creacion_visible.CheckedValue = "false";
         AV17Att_unidades_gisfecha_creacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_unidades_gisfecha_creacion_Visible));
         AssignAttri("", false, "AV17Att_unidades_gisfecha_creacion_Visible", AV17Att_unidades_gisfecha_creacion_Visible);
         chkavAtt_unidades_gishora_creacion_visible.Name = "vATT_UNIDADES_GISHORA_CREACION_VISIBLE";
         chkavAtt_unidades_gishora_creacion_visible.WebTags = "";
         chkavAtt_unidades_gishora_creacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gishora_creacion_visible_Internalname, "TitleCaption", chkavAtt_unidades_gishora_creacion_visible.Caption, true);
         chkavAtt_unidades_gishora_creacion_visible.CheckedValue = "false";
         AV18Att_unidades_gishora_creacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_unidades_gishora_creacion_Visible));
         AssignAttri("", false, "AV18Att_unidades_gishora_creacion_Visible", AV18Att_unidades_gishora_creacion_Visible);
         chkavAtt_unidades_giscreado_por_visible.Name = "vATT_UNIDADES_GISCREADO_POR_VISIBLE";
         chkavAtt_unidades_giscreado_por_visible.WebTags = "";
         chkavAtt_unidades_giscreado_por_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_giscreado_por_visible_Internalname, "TitleCaption", chkavAtt_unidades_giscreado_por_visible.Caption, true);
         chkavAtt_unidades_giscreado_por_visible.CheckedValue = "false";
         AV19Att_unidades_giscreado_por_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_unidades_giscreado_por_Visible));
         AssignAttri("", false, "AV19Att_unidades_giscreado_por_Visible", AV19Att_unidades_giscreado_por_Visible);
         chkavAtt_unidades_gisfecha_modificacion_visible.Name = "vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE";
         chkavAtt_unidades_gisfecha_modificacion_visible.WebTags = "";
         chkavAtt_unidades_gisfecha_modificacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gisfecha_modificacion_visible_Internalname, "TitleCaption", chkavAtt_unidades_gisfecha_modificacion_visible.Caption, true);
         chkavAtt_unidades_gisfecha_modificacion_visible.CheckedValue = "false";
         AV20Att_unidades_gisfecha_modificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_unidades_gisfecha_modificacion_Visible));
         AssignAttri("", false, "AV20Att_unidades_gisfecha_modificacion_Visible", AV20Att_unidades_gisfecha_modificacion_Visible);
         chkavAtt_unidades_gishora_modificacion_visible.Name = "vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE";
         chkavAtt_unidades_gishora_modificacion_visible.WebTags = "";
         chkavAtt_unidades_gishora_modificacion_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gishora_modificacion_visible_Internalname, "TitleCaption", chkavAtt_unidades_gishora_modificacion_visible.Caption, true);
         chkavAtt_unidades_gishora_modificacion_visible.CheckedValue = "false";
         AV21Att_unidades_gishora_modificacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_unidades_gishora_modificacion_Visible));
         AssignAttri("", false, "AV21Att_unidades_gishora_modificacion_Visible", AV21Att_unidades_gishora_modificacion_Visible);
         chkavAtt_unidades_gismodificado_por_visible.Name = "vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE";
         chkavAtt_unidades_gismodificado_por_visible.WebTags = "";
         chkavAtt_unidades_gismodificado_por_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidades_gismodificado_por_visible_Internalname, "TitleCaption", chkavAtt_unidades_gismodificado_por_visible.Caption, true);
         chkavAtt_unidades_gismodificado_por_visible.CheckedValue = "false";
         AV22Att_unidades_gismodificado_por_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_unidades_gismodificado_por_Visible));
         AssignAttri("", false, "AV22Att_unidades_gismodificado_por_Visible", AV22Att_unidades_gismodificado_por_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV23GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV23GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblPgmdescriptortextblock_Internalname = "PGMDESCRIPTORTEXTBLOCK";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = "FILTERTOGGLE_COMBINED";
         Filtersummarytagsuc_Internalname = "FILTERSUMMARYTAGSUC";
         divSection4_Internalname = "SECTION4";
         imgFilterclose_combined_Internalname = "FILTERCLOSE_COMBINED";
         edtavNombre_unidad_Internalname = "vNOMBRE_UNIDAD";
         divK2btoolstable_attributecontainernombre_unidad_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_UNIDAD";
         lblTextblockunidades_gisfecha_creacion_Internalname = "TEXTBLOCKUNIDADES_GISFECHA_CREACION";
         Unidades_gisfecha_creacion_daterangepicker_Internalname = "UNIDADES_GISFECHA_CREACION_DATERANGEPICKER";
         divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISFECHA_CREACION";
         lblTextblockunidades_gisfecha_modificacion_Internalname = "TEXTBLOCKUNIDADES_GISFECHA_MODIFICACION";
         Unidades_gisfecha_modificacion_daterangepicker_Internalname = "UNIDADES_GISFECHA_MODIFICACION_DATERANGEPICKER";
         divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISFECHA_MODIFICACION";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_id_unidad_visible_Internalname = "vATT_ID_UNIDAD_VISIBLE";
         divId_unidad_gridsettingscontainer_Internalname = "ID_UNIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_unidad_visible_Internalname = "vATT_NOMBRE_UNIDAD_VISIBLE";
         divNombre_unidad_gridsettingscontainer_Internalname = "NOMBRE_UNIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gisestado_visible_Internalname = "vATT_UNIDADES_GISESTADO_VISIBLE";
         divUnidades_gisestado_gridsettingscontainer_Internalname = "UNIDADES_GISESTADO_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gisfecha_creacion_visible_Internalname = "vATT_UNIDADES_GISFECHA_CREACION_VISIBLE";
         divUnidades_gisfecha_creacion_gridsettingscontainer_Internalname = "UNIDADES_GISFECHA_CREACION_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gishora_creacion_visible_Internalname = "vATT_UNIDADES_GISHORA_CREACION_VISIBLE";
         divUnidades_gishora_creacion_gridsettingscontainer_Internalname = "UNIDADES_GISHORA_CREACION_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_giscreado_por_visible_Internalname = "vATT_UNIDADES_GISCREADO_POR_VISIBLE";
         divUnidades_giscreado_por_gridsettingscontainer_Internalname = "UNIDADES_GISCREADO_POR_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gisfecha_modificacion_visible_Internalname = "vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE";
         divUnidades_gisfecha_modificacion_gridsettingscontainer_Internalname = "UNIDADES_GISFECHA_MODIFICACION_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gishora_modificacion_visible_Internalname = "vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE";
         divUnidades_gishora_modificacion_gridsettingscontainer_Internalname = "UNIDADES_GISHORA_MODIFICACION_GRIDSETTINGSCONTAINER";
         chkavAtt_unidades_gismodificado_por_visible_Internalname = "vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE";
         divUnidades_gismodificado_por_gridsettingscontainer_Internalname = "UNIDADES_GISMODIFICADO_POR_GRIDSETTINGSCONTAINER";
         divGridsettingstable_content_Internalname = "GRIDSETTINGSTABLE_CONTENT";
         cmbavGridsettingsrowsperpagevariable_Internalname = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         divRowsperpagecontainer_Internalname = "ROWSPERPAGECONTAINER";
         chkavFreezecolumntitles_Internalname = "vFREEZECOLUMNTITLES";
         divFreezegridcolumntitlescontainer_Internalname = "FREEZEGRIDCOLUMNTITLESCONTAINER";
         bttK2bgridsettingssave_Internalname = "K2BGRIDSETTINGSSAVE";
         divCustomizationcollapsiblesection_Internalname = "CUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_Internalname = "GRIDCUSTOMIZATIONCONTAINER";
         divContentinnertable_Internalname = "CONTENTINNERTABLE";
         divK2bgridsettingscontentoutertable_Internalname = "K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = "K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = "IMAGE1";
         bttReport_Internalname = "REPORT";
         bttExport_Internalname = "EXPORT";
         tblK2btabledownloadssectioncontainer_Internalname = "K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = "DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = "DOWNLOADSACTIONSSECTIONCONTAINER";
         tblTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtid_unidad_Internalname = "ID_UNIDAD";
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD";
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO";
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION";
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION";
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR";
         edtunidades_gisfecha_modificacion_Internalname = "UNIDADES_GISFECHA_MODIFICACION";
         edtunidades_gishora_modificacion_Internalname = "UNIDADES_GISHORA_MODIFICACION";
         edtunidades_gismodificado_por_Internalname = "UNIDADES_GISMODIFICADO_POR";
         lblNoresultsfoundtextblock_Internalname = "NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = "NORESULTSFOUNDTABLE";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPreviouspagebuttontextblock_Internalname = "PREVIOUSPAGEBUTTONTEXTBLOCK";
         lblFirstpagetextblock_Internalname = "FIRSTPAGETEXTBLOCK";
         lblSpacinglefttextblock_Internalname = "SPACINGLEFTTEXTBLOCK";
         lblPreviouspagetextblock_Internalname = "PREVIOUSPAGETEXTBLOCK";
         lblCurrentpagetextblock_Internalname = "CURRENTPAGETEXTBLOCK";
         lblNextpagetextblock_Internalname = "NEXTPAGETEXTBLOCK";
         lblSpacingrighttextblock_Internalname = "SPACINGRIGHTTEXTBLOCK";
         lblLastpagetextblock_Internalname = "LASTPAGETEXTBLOCK";
         lblNextpagebuttontextblock_Internalname = "NEXTPAGEBUTTONTEXTBLOCK";
         divK2btoolspagingcontainertable_Internalname = "K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = "SECTION8";
         divTable4_Internalname = "TABLE4";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         K2borderbyusercontrol_Internalname = "K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsgrid_Internalname = "K2BTOOLSABSTRACTHIDDENITEMSGRID";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavFreezecolumntitles.Caption = "Inmovilizar títulos";
         chkavAtt_unidades_gismodificado_por_visible.Caption = "modificado_por";
         chkavAtt_unidades_gishora_modificacion_visible.Caption = "hora_modificacion";
         chkavAtt_unidades_gisfecha_modificacion_visible.Caption = "fecha_modificacion";
         chkavAtt_unidades_giscreado_por_visible.Caption = "creado_por";
         chkavAtt_unidades_gishora_creacion_visible.Caption = "hora_creacion";
         chkavAtt_unidades_gisfecha_creacion_visible.Caption = "fecha_creacion";
         chkavAtt_unidades_gisestado_visible.Caption = "estado";
         chkavAtt_nombre_unidad_visible.Caption = "nombre_unidad";
         chkavAtt_id_unidad_visible.Caption = "id_unidad";
         edtunidades_gismodificado_por_Jsonclick = "";
         edtunidades_gishora_modificacion_Jsonclick = "";
         edtunidades_gisfecha_modificacion_Jsonclick = "";
         edtunidades_giscreado_por_Jsonclick = "";
         edtunidades_gishora_creacion_Jsonclick = "";
         edtunidades_gisfecha_creacion_Jsonclick = "";
         edtunidades_gisestado_Jsonclick = "";
         edtnombre_unidad_Jsonclick = "";
         edtid_unidad_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_unidades_gismodificado_por_visible.Enabled = 1;
         chkavAtt_unidades_gishora_modificacion_visible.Enabled = 1;
         chkavAtt_unidades_gisfecha_modificacion_visible.Enabled = 1;
         chkavAtt_unidades_giscreado_por_visible.Enabled = 1;
         chkavAtt_unidades_gishora_creacion_visible.Enabled = 1;
         chkavAtt_unidades_gisfecha_creacion_visible.Enabled = 1;
         chkavAtt_unidades_gisestado_visible.Enabled = 1;
         chkavAtt_nombre_unidad_visible.Enabled = 1;
         chkavAtt_id_unidad_visible.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         tblNoresultsfoundtable_Visible = 1;
         bttExport_Tooltiptext = "";
         bttReport_Tooltiptext = "";
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         lblLastpagetextblock_Caption = "1";
         lblLastpagetextblock_Visible = 1;
         lblSpacingrighttextblock_Visible = 1;
         lblNextpagetextblock_Caption = "#";
         lblNextpagetextblock_Visible = 1;
         lblCurrentpagetextblock_Caption = "#";
         lblPreviouspagetextblock_Caption = "#";
         lblPreviouspagetextblock_Visible = 1;
         lblSpacinglefttextblock_Visible = 1;
         lblFirstpagetextblock_Caption = "1";
         lblFirstpagetextblock_Visible = 1;
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         divK2btoolspagingcontainertable_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtnombre_unidad_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtunidades_gismodificado_por_Visible = -1;
         edtunidades_gishora_modificacion_Visible = -1;
         edtunidades_gisfecha_modificacion_Visible = -1;
         edtunidades_giscreado_por_Visible = -1;
         edtunidades_gishora_creacion_Visible = -1;
         edtunidades_gisfecha_creacion_Visible = -1;
         edtunidades_gisestado_Visible = -1;
         edtnombre_unidad_Visible = -1;
         edtid_unidad_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavNombre_unidad_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "unidades_gises";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E275E1',iparms:[{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E235E2',iparms:[{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV45UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV39FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E245E2',iparms:[{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtnombre_unidad_Link',ctrl:'NOMBRE_UNIDAD',prop:'Link'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E115E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV40DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E125E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV45UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E255E1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E135E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV24RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV23GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV45UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV24RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E145E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E155E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E165E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E175E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48nombre_unidad_IsAuthorized',fld:'vNOMBRE_UNIDAD_ISAUTHORIZED',pic:''},{av:'AV29ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'edtunidades_gisestado_Visible',ctrl:'UNIDADES_GISESTADO',prop:'Visible'},{av:'edtunidades_gisfecha_creacion_Visible',ctrl:'UNIDADES_GISFECHA_CREACION',prop:'Visible'},{av:'edtunidades_gishora_creacion_Visible',ctrl:'UNIDADES_GISHORA_CREACION',prop:'Visible'},{av:'edtunidades_giscreado_por_Visible',ctrl:'UNIDADES_GISCREADO_POR',prop:'Visible'},{av:'edtunidades_gisfecha_modificacion_Visible',ctrl:'UNIDADES_GISFECHA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gishora_modificacion_Visible',ctrl:'UNIDADES_GISHORA_MODIFICACION',prop:'Visible'},{av:'edtunidades_gismodificado_por_Visible',ctrl:'UNIDADES_GISMODIFICADO_POR',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E185E2',iparms:[{av:'AV30nombre_unidad',fld:'vNOMBRE_UNIDAD',pic:''},{av:'AV32unidades_gisfecha_creacion_From',fld:'vUNIDADES_GISFECHA_CREACION_FROM',pic:''},{av:'AV33unidades_gisfecha_creacion_To',fld:'vUNIDADES_GISFECHA_CREACION_TO',pic:''},{av:'AV35unidades_gisfecha_modificacion_From',fld:'vUNIDADES_GISFECHA_MODIFICACION_FROM',pic:''},{av:'AV36unidades_gisfecha_modificacion_To',fld:'vUNIDADES_GISFECHA_MODIFICACION_TO',pic:''},{av:'AV41K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV42OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV57Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E195E2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E205E2',iparms:[{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E265E1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Unidades_gismodificado_por',iparms:[{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV15Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV16Att_unidades_gisestado_Visible',fld:'vATT_UNIDADES_GISESTADO_VISIBLE',pic:''},{av:'AV17Att_unidades_gisfecha_creacion_Visible',fld:'vATT_UNIDADES_GISFECHA_CREACION_VISIBLE',pic:''},{av:'AV18Att_unidades_gishora_creacion_Visible',fld:'vATT_UNIDADES_GISHORA_CREACION_VISIBLE',pic:''},{av:'AV19Att_unidades_giscreado_por_Visible',fld:'vATT_UNIDADES_GISCREADO_POR_VISIBLE',pic:''},{av:'AV20Att_unidades_gisfecha_modificacion_Visible',fld:'vATT_UNIDADES_GISFECHA_MODIFICACION_VISIBLE',pic:''},{av:'AV21Att_unidades_gishora_modificacion_Visible',fld:'vATT_UNIDADES_GISHORA_MODIFICACION_VISIBLE',pic:''},{av:'AV22Att_unidades_gismodificado_por_Visible',fld:'vATT_UNIDADES_GISMODIFICADO_POR_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV41K2BToolsGenericSearchField = "";
         AV30nombre_unidad = "";
         AV32unidades_gisfecha_creacion_From = DateTime.MinValue;
         AV35unidades_gisfecha_modificacion_From = DateTime.MinValue;
         AV29ClassCollection = new GxSimpleCollection<string>();
         AV33unidades_gisfecha_creacion_To = DateTime.MinValue;
         AV36unidades_gisfecha_modificacion_To = DateTime.MinValue;
         AV60Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV57Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV39FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV40DeletedTag = "";
         AV43GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         Filtersummarytagsuc_Emptystatemessage = "";
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgFiltertoggle_combined_Jsonclick = "";
         ucFiltersummarytagsuc = new GXUserControl();
         imgFilterclose_combined_Jsonclick = "";
         lblTextblockunidades_gisfecha_creacion_Jsonclick = "";
         ucUnidades_gisfecha_creacion_daterangepicker = new GXUserControl();
         lblTextblockunidades_gisfecha_modificacion_Jsonclick = "";
         ucUnidades_gisfecha_modificacion_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A114nombre_unidad = "";
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         A118unidades_giscreado_por = "";
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         A121unidades_gismodificado_por = "";
         lblPreviouspagebuttontextblock_Jsonclick = "";
         lblFirstpagetextblock_Jsonclick = "";
         lblSpacinglefttextblock_Jsonclick = "";
         lblPreviouspagetextblock_Jsonclick = "";
         lblCurrentpagetextblock_Jsonclick = "";
         lblNextpagetextblock_Jsonclick = "";
         lblSpacingrighttextblock_Jsonclick = "";
         lblLastpagetextblock_Jsonclick = "";
         lblNextpagebuttontextblock_Jsonclick = "";
         ucK2borderbyusercontrol = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV30nombre_unidad = "";
         lV41K2BToolsGenericSearchField = "";
         H005E2_A121unidades_gismodificado_por = new string[] {""} ;
         H005E2_n121unidades_gismodificado_por = new bool[] {false} ;
         H005E2_A120unidades_gishora_modificacion = new int[1] ;
         H005E2_n120unidades_gishora_modificacion = new bool[] {false} ;
         H005E2_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         H005E2_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         H005E2_A118unidades_giscreado_por = new string[] {""} ;
         H005E2_n118unidades_giscreado_por = new bool[] {false} ;
         H005E2_A117unidades_gishora_creacion = new int[1] ;
         H005E2_n117unidades_gishora_creacion = new bool[] {false} ;
         H005E2_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         H005E2_n116unidades_gisfecha_creacion = new bool[] {false} ;
         H005E2_A115unidades_gisestado = new int[1] ;
         H005E2_n115unidades_gisestado = new bool[] {false} ;
         H005E2_A114nombre_unidad = new string[] {""} ;
         H005E2_n114nombre_unidad = new bool[] {false} ;
         H005E2_A103id_unidad = new int[1] ;
         H005E3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV31unidades_gisfecha_creacion = DateTime.MinValue;
         AV34unidades_gisfecha_modificacion = DateTime.MinValue;
         AV44GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV46Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV47Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV53ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV54ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV26GridStateKey = "";
         AV27GridState = new SdtK2BGridState(context);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV51TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV37K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV38K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV55OutFile = "";
         AV56Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwunidades_gis__datastore1(),
            new Object[][] {
                new Object[] {
               H005E2_A121unidades_gismodificado_por, H005E2_n121unidades_gismodificado_por, H005E2_A120unidades_gishora_modificacion, H005E2_n120unidades_gishora_modificacion, H005E2_A119unidades_gisfecha_modificacion, H005E2_n119unidades_gisfecha_modificacion, H005E2_A118unidades_giscreado_por, H005E2_n118unidades_giscreado_por, H005E2_A117unidades_gishora_creacion, H005E2_n117unidades_gishora_creacion,
               H005E2_A116unidades_gisfecha_creacion, H005E2_n116unidades_gisfecha_creacion, H005E2_A115unidades_gisestado, H005E2_n115unidades_gisestado, H005E2_A114nombre_unidad, H005E2_n114nombre_unidad, H005E2_A103id_unidad
               }
               , new Object[] {
               H005E3_AGRID_nRecordCount
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwunidades_gis__default(),
            new Object[][] {
            }
         );
         AV60Pgmname = "WWunidades_gis";
         /* GeneXus formulas. */
         AV60Pgmname = "WWunidades_gis";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV42OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV45UC_OrderedBy ;
      private short AV24RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV23GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_174 ;
      private int nGXsfl_174_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavNombre_unidad_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtid_unidad_Visible ;
      private int edtnombre_unidad_Visible ;
      private int edtunidades_gisestado_Visible ;
      private int edtunidades_gisfecha_creacion_Visible ;
      private int edtunidades_gishora_creacion_Visible ;
      private int edtunidades_giscreado_por_Visible ;
      private int edtunidades_gisfecha_modificacion_Visible ;
      private int edtunidades_gishora_modificacion_Visible ;
      private int edtunidades_gismodificado_por_Visible ;
      private int A103id_unidad ;
      private int A115unidades_gisestado ;
      private int A117unidades_gishora_creacion ;
      private int A120unidades_gishora_modificacion ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int divK2btoolspagingcontainertable_Visible ;
      private int lblFirstpagetextblock_Visible ;
      private int lblSpacinglefttextblock_Visible ;
      private int lblPreviouspagetextblock_Visible ;
      private int lblNextpagetextblock_Visible ;
      private int lblSpacingrighttextblock_Visible ;
      private int lblLastpagetextblock_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV61GXV1 ;
      private int AV62GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV63GXV3 ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV64GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_174_idx="0001" ;
      private string AV41K2BToolsGenericSearchField ;
      private string AV60Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV40DeletedTag ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblPgmdescriptortextblock_Internalname ;
      private string lblPgmdescriptortextblock_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable7_Internalname ;
      private string divTable10_Internalname ;
      private string divFilterglobalcontainer_Internalname ;
      private string divCombinedfilterlayout_Internalname ;
      private string divSection4_Internalname ;
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string sImgUrl ;
      private string imgFiltertoggle_combined_Internalname ;
      private string imgFiltertoggle_combined_Jsonclick ;
      private string Filtersummarytagsuc_Internalname ;
      private string divFiltercollapsiblesection_combined_Internalname ;
      private string imgFilterclose_combined_Internalname ;
      private string imgFilterclose_combined_Jsonclick ;
      private string divK2btoolsfilterscontainer_Internalname ;
      private string divFilterattributestable_Internalname ;
      private string divK2btoolstable_attributecontainernombre_unidad_Internalname ;
      private string edtavNombre_unidad_Internalname ;
      private string divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname ;
      private string lblTextblockunidades_gisfecha_creacion_Internalname ;
      private string lblTextblockunidades_gisfecha_creacion_Jsonclick ;
      private string Unidades_gisfecha_creacion_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname ;
      private string lblTextblockunidades_gisfecha_modificacion_Internalname ;
      private string lblTextblockunidades_gisfecha_modificacion_Jsonclick ;
      private string Unidades_gisfecha_modificacion_daterangepicker_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtnombre_unidad_Link ;
      private string divTable4_Internalname ;
      private string divSection8_Internalname ;
      private string divK2btoolspagingcontainertable_Internalname ;
      private string lblPreviouspagebuttontextblock_Internalname ;
      private string lblPreviouspagebuttontextblock_Jsonclick ;
      private string lblPreviouspagebuttontextblock_Class ;
      private string lblFirstpagetextblock_Internalname ;
      private string lblFirstpagetextblock_Caption ;
      private string lblFirstpagetextblock_Jsonclick ;
      private string lblSpacinglefttextblock_Internalname ;
      private string lblSpacinglefttextblock_Jsonclick ;
      private string lblPreviouspagetextblock_Internalname ;
      private string lblPreviouspagetextblock_Caption ;
      private string lblPreviouspagetextblock_Jsonclick ;
      private string lblCurrentpagetextblock_Internalname ;
      private string lblCurrentpagetextblock_Caption ;
      private string lblCurrentpagetextblock_Jsonclick ;
      private string lblNextpagetextblock_Internalname ;
      private string lblNextpagetextblock_Caption ;
      private string lblNextpagetextblock_Jsonclick ;
      private string lblSpacingrighttextblock_Internalname ;
      private string lblSpacingrighttextblock_Jsonclick ;
      private string lblLastpagetextblock_Internalname ;
      private string lblLastpagetextblock_Caption ;
      private string lblLastpagetextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Internalname ;
      private string lblNextpagebuttontextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Class ;
      private string divK2btoolsabstracthiddenitemsgrid_Internalname ;
      private string K2borderbyusercontrol_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtid_unidad_Internalname ;
      private string edtnombre_unidad_Internalname ;
      private string edtunidades_gisestado_Internalname ;
      private string edtunidades_gisfecha_creacion_Internalname ;
      private string edtunidades_gishora_creacion_Internalname ;
      private string edtunidades_giscreado_por_Internalname ;
      private string edtunidades_gisfecha_modificacion_Internalname ;
      private string edtunidades_gishora_modificacion_Internalname ;
      private string edtunidades_gismodificado_por_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV41K2BToolsGenericSearchField ;
      private string chkavAtt_id_unidad_visible_Internalname ;
      private string chkavAtt_nombre_unidad_visible_Internalname ;
      private string chkavAtt_unidades_gisestado_visible_Internalname ;
      private string chkavAtt_unidades_gisfecha_creacion_visible_Internalname ;
      private string chkavAtt_unidades_gishora_creacion_visible_Internalname ;
      private string chkavAtt_unidades_giscreado_por_visible_Internalname ;
      private string chkavAtt_unidades_gisfecha_modificacion_visible_Internalname ;
      private string chkavAtt_unidades_gishora_modificacion_visible_Internalname ;
      private string chkavAtt_unidades_gismodificado_por_visible_Internalname ;
      private string chkavFreezecolumntitles_Internalname ;
      private string divDownloadactionstable_Internalname ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string bttReport_Tooltiptext ;
      private string bttReport_Internalname ;
      private string bttExport_Tooltiptext ;
      private string bttExport_Internalname ;
      private string divDownloadsactionssectioncontainer_Internalname ;
      private string tblNoresultsfoundtable_Internalname ;
      private string GXt_char2 ;
      private string lblNoresultsfoundtextblock_Internalname ;
      private string lblNoresultsfoundtextblock_Jsonclick ;
      private string tblTable6_Internalname ;
      private string divK2bgridsettingstable_Internalname ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divId_unidad_gridsettingscontainer_Internalname ;
      private string divNombre_unidad_gridsettingscontainer_Internalname ;
      private string divUnidades_gisestado_gridsettingscontainer_Internalname ;
      private string divUnidades_gisfecha_creacion_gridsettingscontainer_Internalname ;
      private string divUnidades_gishora_creacion_gridsettingscontainer_Internalname ;
      private string divUnidades_giscreado_por_gridsettingscontainer_Internalname ;
      private string divUnidades_gisfecha_modificacion_gridsettingscontainer_Internalname ;
      private string divUnidades_gishora_modificacion_gridsettingscontainer_Internalname ;
      private string divUnidades_gismodificado_por_gridsettingscontainer_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string tblK2btabledownloadssectioncontainer_Internalname ;
      private string bttReport_Jsonclick ;
      private string bttExport_Jsonclick ;
      private string sGXsfl_174_fel_idx="0001" ;
      private string ROClassString ;
      private string edtid_unidad_Jsonclick ;
      private string edtnombre_unidad_Jsonclick ;
      private string edtunidades_gisestado_Jsonclick ;
      private string edtunidades_gisfecha_creacion_Jsonclick ;
      private string edtunidades_gishora_creacion_Jsonclick ;
      private string edtunidades_giscreado_por_Jsonclick ;
      private string edtunidades_gisfecha_modificacion_Jsonclick ;
      private string edtunidades_gishora_modificacion_Jsonclick ;
      private string edtunidades_gismodificado_por_Jsonclick ;
      private DateTime GXt_dtime3 ;
      private DateTime AV32unidades_gisfecha_creacion_From ;
      private DateTime AV35unidades_gisfecha_modificacion_From ;
      private DateTime AV33unidades_gisfecha_creacion_To ;
      private DateTime AV36unidades_gisfecha_modificacion_To ;
      private DateTime A116unidades_gisfecha_creacion ;
      private DateTime A119unidades_gisfecha_modificacion ;
      private DateTime AV31unidades_gisfecha_creacion ;
      private DateTime AV34unidades_gisfecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV48nombre_unidad_IsAuthorized ;
      private bool AV14Att_id_unidad_Visible ;
      private bool AV15Att_nombre_unidad_Visible ;
      private bool AV16Att_unidades_gisestado_Visible ;
      private bool AV17Att_unidades_gisfecha_creacion_Visible ;
      private bool AV18Att_unidades_gishora_creacion_Visible ;
      private bool AV19Att_unidades_giscreado_por_Visible ;
      private bool AV20Att_unidades_gisfecha_modificacion_Visible ;
      private bool AV21Att_unidades_gishora_modificacion_Visible ;
      private bool AV22Att_unidades_gismodificado_por_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n114nombre_unidad ;
      private bool n115unidades_gisestado ;
      private bool n116unidades_gisfecha_creacion ;
      private bool n117unidades_gishora_creacion ;
      private bool n118unidades_giscreado_por ;
      private bool n119unidades_gisfecha_modificacion ;
      private bool n120unidades_gishora_modificacion ;
      private bool n121unidades_gismodificado_por ;
      private bool bGXsfl_174_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV25RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV30nombre_unidad ;
      private string AV57Uri ;
      private string A114nombre_unidad ;
      private string A118unidades_giscreado_por ;
      private string A121unidades_gismodificado_por ;
      private string lV30nombre_unidad ;
      private string AV26GridStateKey ;
      private string AV55OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private Guid AV56Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucUnidades_gisfecha_creacion_daterangepicker ;
      private GXUserControl ucUnidades_gisfecha_modificacion_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_id_unidad_visible ;
      private GXCheckbox chkavAtt_nombre_unidad_visible ;
      private GXCheckbox chkavAtt_unidades_gisestado_visible ;
      private GXCheckbox chkavAtt_unidades_gisfecha_creacion_visible ;
      private GXCheckbox chkavAtt_unidades_gishora_creacion_visible ;
      private GXCheckbox chkavAtt_unidades_giscreado_por_visible ;
      private GXCheckbox chkavAtt_unidades_gisfecha_modificacion_visible ;
      private GXCheckbox chkavAtt_unidades_gishora_modificacion_visible ;
      private GXCheckbox chkavAtt_unidades_gismodificado_por_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] H005E2_A121unidades_gismodificado_por ;
      private bool[] H005E2_n121unidades_gismodificado_por ;
      private int[] H005E2_A120unidades_gishora_modificacion ;
      private bool[] H005E2_n120unidades_gishora_modificacion ;
      private DateTime[] H005E2_A119unidades_gisfecha_modificacion ;
      private bool[] H005E2_n119unidades_gisfecha_modificacion ;
      private string[] H005E2_A118unidades_giscreado_por ;
      private bool[] H005E2_n118unidades_giscreado_por ;
      private int[] H005E2_A117unidades_gishora_creacion ;
      private bool[] H005E2_n117unidades_gishora_creacion ;
      private DateTime[] H005E2_A116unidades_gisfecha_creacion ;
      private bool[] H005E2_n116unidades_gisfecha_creacion ;
      private int[] H005E2_A115unidades_gisestado ;
      private bool[] H005E2_n115unidades_gisestado ;
      private string[] H005E2_A114nombre_unidad ;
      private bool[] H005E2_n114nombre_unidad ;
      private int[] H005E2_A103id_unidad ;
      private long[] H005E3_AGRID_nRecordCount ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV29ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV37K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV39FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV43GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV46Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV53ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV27GridState ;
      private SdtK2BGridState_FilterValue AV28GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV38K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV44GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV47Message ;
      private SdtK2BTrnContext AV51TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV54ActivityListItem ;
   }

   public class wwunidades_gis__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005E2( IGxContext context ,
                                             string AV30nombre_unidad ,
                                             DateTime AV33unidades_gisfecha_creacion_To ,
                                             DateTime AV32unidades_gisfecha_creacion_From ,
                                             DateTime AV36unidades_gisfecha_modificacion_To ,
                                             DateTime AV35unidades_gisfecha_modificacion_From ,
                                             string AV41K2BToolsGenericSearchField ,
                                             string A114nombre_unidad ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A103id_unidad ,
                                             int A115unidades_gisestado ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             int A120unidades_gishora_modificacion ,
                                             string A121unidades_gismodificado_por ,
                                             short AV42OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [modificado_por], [hora_modificacion], [fecha_modificacion], [creado_por], [hora_creacion], [fecha_creacion], [estado], [nombre_unidad], [id_unidad]";
         sFromString = " FROM dbo.[unidades_gis]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30nombre_unidad)) )
         {
            AddWhere(sWhereString, "([nombre_unidad] like @lV30nombre_unidad)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV33unidades_gisfecha_creacion_To) )
         {
            AddWhere(sWhereString, "([fecha_creacion] <= @AV33unidades_gisfecha_creacion_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV32unidades_gisfecha_creacion_From) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV32unidades_gisfecha_creacion_From)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV36unidades_gisfecha_modificacion_To) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] <= @AV36unidades_gisfecha_modificacion_To)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV35unidades_gisfecha_modificacion_From) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV35unidades_gisfecha_modificacion_From)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [nombre_unidad] like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_creacion] AS decimal(5,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [creado_por] like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_modificacion] AS decimal(5,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [modificado_por] like '%' + @lV41K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
         }
         if ( AV42OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [id_unidad]";
         }
         else if ( AV42OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [id_unidad] DESC";
         }
         else if ( AV42OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [nombre_unidad]";
         }
         else if ( AV42OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [nombre_unidad] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [id_unidad]";
         }
         scmdbuf = "SELECT * FROM (SELECT " + sSelectString + ", ROW_NUMBER() OVER (" + sOrderString + " ) AS GX_ROW_NUMBER" + sFromString + sWhereString + "" + ") AS GX_CTE WHERE GX_ROW_NUMBER" + " >= " + "@GXPagingFrom2" + " AND GX_ROW_NUMBER <= (CASE WHEN (" + "@GXPagingTo2" + " < " + "@GXPagingFrom2" + ") THEN CAST(0x7FFFFFFFFFFFFFFF AS bigint) ELSE " + "@GXPagingTo2" + " END)";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H005E3( IGxContext context ,
                                             string AV30nombre_unidad ,
                                             DateTime AV33unidades_gisfecha_creacion_To ,
                                             DateTime AV32unidades_gisfecha_creacion_From ,
                                             DateTime AV36unidades_gisfecha_modificacion_To ,
                                             DateTime AV35unidades_gisfecha_modificacion_From ,
                                             string AV41K2BToolsGenericSearchField ,
                                             string A114nombre_unidad ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A103id_unidad ,
                                             int A115unidades_gisestado ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             int A120unidades_gishora_modificacion ,
                                             string A121unidades_gismodificado_por ,
                                             short AV42OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[unidades_gis]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30nombre_unidad)) )
         {
            AddWhere(sWhereString, "([nombre_unidad] like @lV30nombre_unidad)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV33unidades_gisfecha_creacion_To) )
         {
            AddWhere(sWhereString, "([fecha_creacion] <= @AV33unidades_gisfecha_creacion_To)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV32unidades_gisfecha_creacion_From) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV32unidades_gisfecha_creacion_From)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV36unidades_gisfecha_modificacion_To) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] <= @AV36unidades_gisfecha_modificacion_To)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV35unidades_gisfecha_modificacion_From) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV35unidades_gisfecha_modificacion_From)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [nombre_unidad] like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_creacion] AS decimal(5,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [creado_por] like '%' + @lV41K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_modificacion] AS decimal(5,0))) like '%' + @lV41K2BToolsGenericSearchField + '%' or [modificado_por] like '%' + @lV41K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV42OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV42OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV42OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV42OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005E2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] );
               case 1 :
                     return conditional_H005E3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005E2;
          prmH005E2 = new Object[] {
          new ParDef("@lV30nombre_unidad",GXType.NVarChar,200,0) ,
          new ParDef("@AV33unidades_gisfecha_creacion_To",GXType.Date,8,0) ,
          new ParDef("@AV32unidades_gisfecha_creacion_From",GXType.Date,8,0) ,
          new ParDef("@AV36unidades_gisfecha_modificacion_To",GXType.Date,8,0) ,
          new ParDef("@AV35unidades_gisfecha_modificacion_From",GXType.Date,8,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005E3;
          prmH005E3 = new Object[] {
          new ParDef("@lV30nombre_unidad",GXType.NVarChar,200,0) ,
          new ParDef("@AV33unidades_gisfecha_creacion_To",GXType.Date,8,0) ,
          new ParDef("@AV32unidades_gisfecha_creacion_From",GXType.Date,8,0) ,
          new ParDef("@AV36unidades_gisfecha_modificacion_To",GXType.Date,8,0) ,
          new ParDef("@AV35unidades_gisfecha_modificacion_From",GXType.Date,8,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV41K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wwunidades_gis__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
