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
   public class wwdetalle_infotec : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwdetalle_infotec( )
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

      public wwdetalle_infotec( IGxContext context )
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
         chkavAtt_correlativo_visible = new GXCheckbox();
         chkavAtt_nombre_emp_visible = new GXCheckbox();
         chkavAtt_cargo_emp_visible = new GXCheckbox();
         chkavAtt_fecha_registro_visible = new GXCheckbox();
         chkavAtt_estatus_visible = new GXCheckbox();
         chkavAtt_trabajo_visible = new GXCheckbox();
         chkavAtt_nombre_usuario_visible = new GXCheckbox();
         chkavAtt_depto_usuario_visible = new GXCheckbox();
         chkavAtt_correo_usuario_visible = new GXCheckbox();
         chkavAtt_detalle_infotecid_unidad_visible = new GXCheckbox();
         chkavAtt_id_categoria_visible = new GXCheckbox();
         chkavAtt_id_actividad_visible = new GXCheckbox();
         chkavAtt_detalle_tarea_visible = new GXCheckbox();
         chkavAtt_prioridad_visible = new GXCheckbox();
         chkavAtt_observaciones_visible = new GXCheckbox();
         chkavAtt_fecha_solicitud_visible = new GXCheckbox();
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
               nRC_GXsfl_216 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_216"), "."));
               nGXsfl_216_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_216_idx"), "."));
               sGXsfl_216_idx = GetPar( "sGXsfl_216_idx");
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
               AV57K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV40nombre_emp = GetPar( "nombre_emp");
               AV72fecha_registro_From = context.localUtil.ParseDateParm( GetPar( "fecha_registro_From"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV39ClassCollection);
               AV58OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV73fecha_registro_To = context.localUtil.ParseDateParm( GetPar( "fecha_registro_To"));
               AV79Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV64nombre_emp_IsAuthorized = StringUtil.StrToBool( GetPar( "nombre_emp_IsAuthorized"));
               AV14Att_correlativo_Visible = StringUtil.StrToBool( GetPar( "Att_correlativo_Visible"));
               AV15Att_nombre_emp_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_emp_Visible"));
               AV16Att_cargo_emp_Visible = StringUtil.StrToBool( GetPar( "Att_cargo_emp_Visible"));
               AV17Att_fecha_registro_Visible = StringUtil.StrToBool( GetPar( "Att_fecha_registro_Visible"));
               AV19Att_estatus_Visible = StringUtil.StrToBool( GetPar( "Att_estatus_Visible"));
               AV20Att_trabajo_Visible = StringUtil.StrToBool( GetPar( "Att_trabajo_Visible"));
               AV21Att_nombre_usuario_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_usuario_Visible"));
               AV22Att_depto_usuario_Visible = StringUtil.StrToBool( GetPar( "Att_depto_usuario_Visible"));
               AV23Att_correo_usuario_Visible = StringUtil.StrToBool( GetPar( "Att_correo_usuario_Visible"));
               AV24Att_detalle_infotecid_unidad_Visible = StringUtil.StrToBool( GetPar( "Att_detalle_infotecid_unidad_Visible"));
               AV25Att_id_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_id_categoria_Visible"));
               AV26Att_id_actividad_Visible = StringUtil.StrToBool( GetPar( "Att_id_actividad_Visible"));
               AV27Att_detalle_tarea_Visible = StringUtil.StrToBool( GetPar( "Att_detalle_tarea_Visible"));
               AV28Att_prioridad_Visible = StringUtil.StrToBool( GetPar( "Att_prioridad_Visible"));
               AV29Att_observaciones_Visible = StringUtil.StrToBool( GetPar( "Att_observaciones_Visible"));
               AV30Att_fecha_solicitud_Visible = StringUtil.StrToBool( GetPar( "Att_fecha_solicitud_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV76Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
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
            return "detalle_infotec_Execute" ;
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
         PA7V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418822269", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwdetalle_infotec.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV57K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vNOMBRE_EMP", AV40nombre_emp);
         GxWebStd.gx_hidden_field( context, "GXH_vFECHA_REGISTRO_FROM", context.localUtil.Format(AV72fecha_registro_From, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_216", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_216), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV55FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV55FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV56DeletedTag));
         GxWebStd.gx_hidden_field( context, "vFECHA_REGISTRO_TO", context.localUtil.DToC( AV73fecha_registro_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV59GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV59GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV79Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV39ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV39ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vNOMBRE_EMP_ISAUTHORIZED", AV64nombre_emp_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV76Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vFECHA_REGISTRO_FROM", context.localUtil.DToC( AV72fecha_registro_From, 0, "/"));
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
            WE7V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7V2( ) ;
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
         return formatLink("wwdetalle_infotec.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWdetalle_infotec" ;
      }

      public override string GetPgmdesc( )
      {
         return "detalle_infoteces" ;
      }

      protected void WB7V0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "detalle_infoteces", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_216_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV57K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV57K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWdetalle_infotec.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWdetalle_infotec.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV55FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV56DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWdetalle_infotec.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_emp_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavNombre_emp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNombre_emp_Internalname, "nombre_emp", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavNombre_emp_Internalname, AV40nombre_emp, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtavNombre_emp_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWdetalle_infotec.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerfecha_registro_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfecha_registro_Internalname, "fecha_registro", "", "", lblTextblockfecha_registro_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* User Defined Control */
            ucFecha_registro_daterangepicker.SetProperty("ValueFrom", AV72fecha_registro_From);
            ucFecha_registro_daterangepicker.SetProperty("ValueTo", AV73fecha_registro_To);
            ucFecha_registro_daterangepicker.Render(context, "k2bdaterangepicker", Fecha_registro_daterangepicker_Internalname, "FECHA_REGISTRO_DATERANGEPICKERContainer");
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
            wb_table1_52_7V2( true) ;
         }
         else
         {
            wb_table1_52_7V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_52_7V2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"216\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(73), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtcorrelativo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "correlativo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_emp_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "nombre_emp") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtcargo_emp_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "cargo_emp") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtfecha_registro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "fecha_registro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtestatus_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "estatus") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edttrabajo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "trabajo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_usuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "nombre_usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtdepto_usuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "depto_usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtcorreo_usuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "correo_usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtdetalle_infotecid_unidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_unidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_actividad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_actividad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtdetalle_tarea_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "detalle_tarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtprioridad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "prioridad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtobservaciones_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "observaciones") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtfecha_solicitud_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "fecha_solicitud") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtcorrelativo_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A239nombre_emp);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtnombre_emp_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_emp_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A240cargo_emp);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtcargo_emp_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A241fecha_registro, "99/99/99"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtfecha_registro_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A243estatus);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtestatus_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A244trabajo);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edttrabajo_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A245nombre_usuario);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_usuario_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A246depto_usuario);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtdepto_usuario_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A247correo_usuario);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtcorreo_usuario_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtdetalle_infotecid_unidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A249id_categoria), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A250id_actividad), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_actividad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A251detalle_tarea);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtdetalle_tarea_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A252prioridad);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtprioridad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A253observaciones);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtobservaciones_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A254fecha_solicitud);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtfecha_solicitud_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV65Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV66Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 216 )
         {
            wbEnd = 0;
            nRC_GXsfl_216 = (int)(nGXsfl_216_idx-1);
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
            wb_table2_237_7V2( true) ;
         }
         else
         {
            wb_table2_237_7V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_237_7V2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV59GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV61UC_OrderedBy);
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
         if ( wbEnd == 216 )
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

      protected void START7V2( )
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
            Form.Meta.addItem("description", "detalle_infoteces", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7V0( ) ;
      }

      protected void WS7V2( )
      {
         START7V2( ) ;
         EVT7V2( ) ;
      }

      protected void EVT7V2( )
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
                              E117V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E127V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E137V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E147V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E157V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E167V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E177V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E187V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E197V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E217V2 ();
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
                              nGXsfl_216_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_216_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_216_idx), 4, 0), 4, "0");
                              SubsflControlProps_2162( ) ;
                              A238correlativo = (int)(context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ".", ","));
                              A239nombre_emp = cgiGet( edtnombre_emp_Internalname);
                              n239nombre_emp = false;
                              A240cargo_emp = cgiGet( edtcargo_emp_Internalname);
                              n240cargo_emp = false;
                              A241fecha_registro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtfecha_registro_Internalname), 0));
                              n241fecha_registro = false;
                              A243estatus = cgiGet( edtestatus_Internalname);
                              n243estatus = false;
                              A244trabajo = cgiGet( edttrabajo_Internalname);
                              n244trabajo = false;
                              A245nombre_usuario = cgiGet( edtnombre_usuario_Internalname);
                              n245nombre_usuario = false;
                              A246depto_usuario = cgiGet( edtdepto_usuario_Internalname);
                              n246depto_usuario = false;
                              A247correo_usuario = cgiGet( edtcorreo_usuario_Internalname);
                              n247correo_usuario = false;
                              A248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ".", ","));
                              n248detalle_infotecid_unidad = false;
                              A249id_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ".", ","));
                              n249id_categoria = false;
                              A250id_actividad = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ".", ","));
                              n250id_actividad = false;
                              A251detalle_tarea = cgiGet( edtdetalle_tarea_Internalname);
                              n251detalle_tarea = false;
                              A252prioridad = cgiGet( edtprioridad_Internalname);
                              n252prioridad = false;
                              A253observaciones = cgiGet( edtobservaciones_Internalname);
                              n253observaciones = false;
                              A254fecha_solicitud = cgiGet( edtfecha_solicitud_Internalname);
                              n254fecha_solicitud = false;
                              AV65Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.convertURL( context.PathToRelativeUrl( AV65Update))), !bGXsfl_216_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV65Update), true);
                              AV66Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV66Delete))), !bGXsfl_216_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV66Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E227V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E237V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E247V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E257V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV57K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Nombre_emp Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE_EMP"), AV40nombre_emp) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fecha_registro_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHA_REGISTRO_FROM"), 0) != AV72fecha_registro_From )
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

      protected void WE7V2( )
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

      protected void PA7V2( )
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
         SubsflControlProps_2162( ) ;
         while ( nGXsfl_216_idx <= nRC_GXsfl_216 )
         {
            sendrow_2162( ) ;
            nGXsfl_216_idx = ((subGrid_Islastpage==1)&&(nGXsfl_216_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_216_idx+1);
            sGXsfl_216_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_216_idx), 4, 0), 4, "0");
            SubsflControlProps_2162( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV57K2BToolsGenericSearchField ,
                                       string AV40nombre_emp ,
                                       DateTime AV72fecha_registro_From ,
                                       GxSimpleCollection<string> AV39ClassCollection ,
                                       short AV58OrderedBy ,
                                       DateTime AV73fecha_registro_To ,
                                       string AV79Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV64nombre_emp_IsAuthorized ,
                                       bool AV14Att_correlativo_Visible ,
                                       bool AV15Att_nombre_emp_Visible ,
                                       bool AV16Att_cargo_emp_Visible ,
                                       bool AV17Att_fecha_registro_Visible ,
                                       bool AV19Att_estatus_Visible ,
                                       bool AV20Att_trabajo_Visible ,
                                       bool AV21Att_nombre_usuario_Visible ,
                                       bool AV22Att_depto_usuario_Visible ,
                                       bool AV23Att_correo_usuario_Visible ,
                                       bool AV24Att_detalle_infotecid_unidad_Visible ,
                                       bool AV25Att_id_categoria_Visible ,
                                       bool AV26Att_id_actividad_Visible ,
                                       bool AV27Att_detalle_tarea_Visible ,
                                       bool AV28Att_prioridad_Visible ,
                                       bool AV29Att_observaciones_Visible ,
                                       bool AV30Att_fecha_solicitud_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV76Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E237V2 ();
         GRID_nCurrentRecord = 0;
         RF7V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORRELATIVO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CORRELATIVO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")));
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
         AV14Att_correlativo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_correlativo_Visible));
         AssignAttri("", false, "AV14Att_correlativo_Visible", AV14Att_correlativo_Visible);
         AV15Att_nombre_emp_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_nombre_emp_Visible));
         AssignAttri("", false, "AV15Att_nombre_emp_Visible", AV15Att_nombre_emp_Visible);
         AV16Att_cargo_emp_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_cargo_emp_Visible));
         AssignAttri("", false, "AV16Att_cargo_emp_Visible", AV16Att_cargo_emp_Visible);
         AV17Att_fecha_registro_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_fecha_registro_Visible));
         AssignAttri("", false, "AV17Att_fecha_registro_Visible", AV17Att_fecha_registro_Visible);
         AV19Att_estatus_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_estatus_Visible));
         AssignAttri("", false, "AV19Att_estatus_Visible", AV19Att_estatus_Visible);
         AV20Att_trabajo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_trabajo_Visible));
         AssignAttri("", false, "AV20Att_trabajo_Visible", AV20Att_trabajo_Visible);
         AV21Att_nombre_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_nombre_usuario_Visible));
         AssignAttri("", false, "AV21Att_nombre_usuario_Visible", AV21Att_nombre_usuario_Visible);
         AV22Att_depto_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_depto_usuario_Visible));
         AssignAttri("", false, "AV22Att_depto_usuario_Visible", AV22Att_depto_usuario_Visible);
         AV23Att_correo_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_correo_usuario_Visible));
         AssignAttri("", false, "AV23Att_correo_usuario_Visible", AV23Att_correo_usuario_Visible);
         AV24Att_detalle_infotecid_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_detalle_infotecid_unidad_Visible));
         AssignAttri("", false, "AV24Att_detalle_infotecid_unidad_Visible", AV24Att_detalle_infotecid_unidad_Visible);
         AV25Att_id_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_id_categoria_Visible));
         AssignAttri("", false, "AV25Att_id_categoria_Visible", AV25Att_id_categoria_Visible);
         AV26Att_id_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV26Att_id_actividad_Visible));
         AssignAttri("", false, "AV26Att_id_actividad_Visible", AV26Att_id_actividad_Visible);
         AV27Att_detalle_tarea_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV27Att_detalle_tarea_Visible));
         AssignAttri("", false, "AV27Att_detalle_tarea_Visible", AV27Att_detalle_tarea_Visible);
         AV28Att_prioridad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV28Att_prioridad_Visible));
         AssignAttri("", false, "AV28Att_prioridad_Visible", AV28Att_prioridad_Visible);
         AV29Att_observaciones_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV29Att_observaciones_Visible));
         AssignAttri("", false, "AV29Att_observaciones_Visible", AV29Att_observaciones_Visible);
         AV30Att_fecha_solicitud_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV30Att_fecha_solicitud_Visible));
         AssignAttri("", false, "AV30Att_fecha_solicitud_Visible", AV30Att_fecha_solicitud_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV33GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV33GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E237V2 ();
         RF7V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV79Pgmname = "WWdetalle_infotec";
         context.Gx_err = 0;
      }

      protected void RF7V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 216;
         E247V2 ();
         nGXsfl_216_idx = 1;
         sGXsfl_216_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_216_idx), 4, 0), 4, "0");
         SubsflControlProps_2162( ) ;
         bGXsfl_216_Refreshing = true;
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
            SubsflControlProps_2162( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 1 : GRID_nFirstRecordOnPage+1));
            GXPagingTo2 = (int)(((subGrid_Rows==0) ? 10000 : GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )+1));
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV40nombre_emp ,
                                                 AV73fecha_registro_To ,
                                                 AV72fecha_registro_From ,
                                                 AV57K2BToolsGenericSearchField ,
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
                                                 AV58OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV40nombre_emp = StringUtil.Concat( StringUtil.RTrim( AV40nombre_emp), "%", "");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H007V2 */
            pr_datastore1.execute(0, new Object[] {lV40nombre_emp, AV73fecha_registro_To, AV72fecha_registro_From, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingFrom2, GXPagingTo2});
            nGXsfl_216_idx = 1;
            sGXsfl_216_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_216_idx), 4, 0), 4, "0");
            SubsflControlProps_2162( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A254fecha_solicitud = H007V2_A254fecha_solicitud[0];
               n254fecha_solicitud = H007V2_n254fecha_solicitud[0];
               A253observaciones = H007V2_A253observaciones[0];
               n253observaciones = H007V2_n253observaciones[0];
               A252prioridad = H007V2_A252prioridad[0];
               n252prioridad = H007V2_n252prioridad[0];
               A251detalle_tarea = H007V2_A251detalle_tarea[0];
               n251detalle_tarea = H007V2_n251detalle_tarea[0];
               A250id_actividad = H007V2_A250id_actividad[0];
               n250id_actividad = H007V2_n250id_actividad[0];
               A249id_categoria = H007V2_A249id_categoria[0];
               n249id_categoria = H007V2_n249id_categoria[0];
               A248detalle_infotecid_unidad = H007V2_A248detalle_infotecid_unidad[0];
               n248detalle_infotecid_unidad = H007V2_n248detalle_infotecid_unidad[0];
               A247correo_usuario = H007V2_A247correo_usuario[0];
               n247correo_usuario = H007V2_n247correo_usuario[0];
               A246depto_usuario = H007V2_A246depto_usuario[0];
               n246depto_usuario = H007V2_n246depto_usuario[0];
               A245nombre_usuario = H007V2_A245nombre_usuario[0];
               n245nombre_usuario = H007V2_n245nombre_usuario[0];
               A244trabajo = H007V2_A244trabajo[0];
               n244trabajo = H007V2_n244trabajo[0];
               A243estatus = H007V2_A243estatus[0];
               n243estatus = H007V2_n243estatus[0];
               A241fecha_registro = H007V2_A241fecha_registro[0];
               n241fecha_registro = H007V2_n241fecha_registro[0];
               A240cargo_emp = H007V2_A240cargo_emp[0];
               n240cargo_emp = H007V2_n240cargo_emp[0];
               A239nombre_emp = H007V2_A239nombre_emp[0];
               n239nombre_emp = H007V2_n239nombre_emp[0];
               A238correlativo = H007V2_A238correlativo[0];
               E257V2 ();
               pr_datastore1.readNext(0);
            }
            GRID_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 216;
            WB7V0( ) ;
         }
         bGXsfl_216_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV79Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CORRELATIVO"+"_"+sGXsfl_216_idx, GetSecureSignedToken( sGXsfl_216_idx, context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV76Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76Uri, "")), context));
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
                                              AV40nombre_emp ,
                                              AV73fecha_registro_To ,
                                              AV72fecha_registro_From ,
                                              AV57K2BToolsGenericSearchField ,
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
                                              AV58OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV40nombre_emp = StringUtil.Concat( StringUtil.RTrim( AV40nombre_emp), "%", "");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         lV57K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV57K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H007V3 */
         pr_datastore1.execute(1, new Object[] {lV40nombre_emp, AV73fecha_registro_To, AV72fecha_registro_From, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField, lV57K2BToolsGenericSearchField});
         GRID_nRecordCount = H007V3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV79Pgmname = "WWdetalle_infotec";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E227V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV55FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV59GridOrders);
            /* Read saved values. */
            nRC_GXsfl_216 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_216"), ".", ","));
            AV56DeletedTag = cgiGet( "vDELETEDTAG");
            AV72fecha_registro_From = context.localUtil.CToD( cgiGet( "vFECHA_REGISTRO_FROM"), 0);
            AV73fecha_registro_To = context.localUtil.CToD( cgiGet( "vFECHA_REGISTRO_TO"), 0);
            AV61UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV58OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV57K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV57K2BToolsGenericSearchField", AV57K2BToolsGenericSearchField);
            AV40nombre_emp = cgiGet( edtavNombre_emp_Internalname);
            AssignAttri("", false, "AV40nombre_emp", AV40nombre_emp);
            AV14Att_correlativo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_correlativo_visible_Internalname));
            AssignAttri("", false, "AV14Att_correlativo_Visible", AV14Att_correlativo_Visible);
            AV15Att_nombre_emp_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_emp_visible_Internalname));
            AssignAttri("", false, "AV15Att_nombre_emp_Visible", AV15Att_nombre_emp_Visible);
            AV16Att_cargo_emp_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_cargo_emp_visible_Internalname));
            AssignAttri("", false, "AV16Att_cargo_emp_Visible", AV16Att_cargo_emp_Visible);
            AV17Att_fecha_registro_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_fecha_registro_visible_Internalname));
            AssignAttri("", false, "AV17Att_fecha_registro_Visible", AV17Att_fecha_registro_Visible);
            AV19Att_estatus_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estatus_visible_Internalname));
            AssignAttri("", false, "AV19Att_estatus_Visible", AV19Att_estatus_Visible);
            AV20Att_trabajo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_trabajo_visible_Internalname));
            AssignAttri("", false, "AV20Att_trabajo_Visible", AV20Att_trabajo_Visible);
            AV21Att_nombre_usuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_usuario_visible_Internalname));
            AssignAttri("", false, "AV21Att_nombre_usuario_Visible", AV21Att_nombre_usuario_Visible);
            AV22Att_depto_usuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_depto_usuario_visible_Internalname));
            AssignAttri("", false, "AV22Att_depto_usuario_Visible", AV22Att_depto_usuario_Visible);
            AV23Att_correo_usuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_correo_usuario_visible_Internalname));
            AssignAttri("", false, "AV23Att_correo_usuario_Visible", AV23Att_correo_usuario_Visible);
            AV24Att_detalle_infotecid_unidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_detalle_infotecid_unidad_visible_Internalname));
            AssignAttri("", false, "AV24Att_detalle_infotecid_unidad_Visible", AV24Att_detalle_infotecid_unidad_Visible);
            AV25Att_id_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_categoria_visible_Internalname));
            AssignAttri("", false, "AV25Att_id_categoria_Visible", AV25Att_id_categoria_Visible);
            AV26Att_id_actividad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_actividad_visible_Internalname));
            AssignAttri("", false, "AV26Att_id_actividad_Visible", AV26Att_id_actividad_Visible);
            AV27Att_detalle_tarea_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_detalle_tarea_visible_Internalname));
            AssignAttri("", false, "AV27Att_detalle_tarea_Visible", AV27Att_detalle_tarea_Visible);
            AV28Att_prioridad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_prioridad_visible_Internalname));
            AssignAttri("", false, "AV28Att_prioridad_Visible", AV28Att_prioridad_Visible);
            AV29Att_observaciones_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_observaciones_visible_Internalname));
            AssignAttri("", false, "AV29Att_observaciones_Visible", AV29Att_observaciones_Visible);
            AV30Att_fecha_solicitud_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_fecha_solicitud_visible_Internalname));
            AssignAttri("", false, "AV30Att_fecha_solicitud_Visible", AV30Att_fecha_solicitud_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV33GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV33GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV57K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE_EMP"), AV40nombre_emp) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHA_REGISTRO_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV72fecha_registro_From ) )
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
         E227V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E227V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV40nombre_emp = "";
         AssignAttri("", false, "AV40nombre_emp", AV40nombre_emp);
         AV71fecha_registro = DateTime.MinValue;
         AV72fecha_registro_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV72fecha_registro_From", context.localUtil.Format(AV72fecha_registro_From, "99/99/99"));
         AV73fecha_registro_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV73fecha_registro_To", context.localUtil.Format(AV73fecha_registro_To, "99/99/99"));
         new k2bloadrowsperpage(context ).execute(  AV79Pgmname,  "Grid", out  AV34RowsPerPageVariable, out  AV35RowsPerPageLoaded) ;
         AssignAttri("", false, "AV34RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV34RowsPerPageVariable), 4, 0));
         if ( ! AV35RowsPerPageLoaded )
         {
            AV34RowsPerPageVariable = 20;
            AssignAttri("", false, "AV34RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV34RowsPerPageVariable), 4, 0));
         }
         AV33GridSettingsRowsPerPageVariable = AV34RowsPerPageVariable;
         AssignAttri("", false, "AV33GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV34RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "detalle_infoteces";
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
         AV59GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV60GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV60GridOrder.gxTpr_Ascendingorder = 0;
         AV60GridOrder.gxTpr_Descendingorder = 1;
         AV60GridOrder.gxTpr_Gridcolumnindex = 1;
         AV59GridOrders.Add(AV60GridOrder, 0);
         AV60GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV60GridOrder.gxTpr_Ascendingorder = 2;
         AV60GridOrder.gxTpr_Descendingorder = 3;
         AV60GridOrder.gxTpr_Gridcolumnindex = 2;
         AV59GridOrders.Add(AV60GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E237V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV62Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV62Messages = GXt_objcol_SdtMessages_Message1;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV62Messages.Count )
         {
            AV63Message = ((GeneXus.Utils.SdtMessages_Message)AV62Messages.Item(AV80GXV1));
            GX_msglist.addItem(AV63Message.gxTpr_Description);
            AV80GXV1 = (int)(AV80GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV79Pgmname;
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV65Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.convertURL( context.PathToRelativeUrl( AV65Update))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV65Update), true);
         AV81Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.convertURL( context.PathToRelativeUrl( AV65Update))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV65Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_216_Refreshing);
         AV66Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV66Delete))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV66Delete), true);
         AV82Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV66Delete))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV66Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_216_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV39ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV36GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV79Pgmname,  AV36GridStateKey, out  AV37GridState) ;
         AV58OrderedBy = AV37GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV58OrderedBy", StringUtil.LTrimStr( (decimal)(AV58OrderedBy), 4, 0));
         AV61UC_OrderedBy = AV37GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV61UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV61UC_OrderedBy), 4, 0));
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Filtername, "nombre_emp") == 0 )
            {
               AV40nombre_emp = AV38GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40nombre_emp", AV40nombre_emp);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Filtername, "fecha_registro:From") == 0 )
            {
               AV72fecha_registro_From = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV72fecha_registro_From", context.localUtil.Format(AV72fecha_registro_From, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Filtername, "fecha_registro:To") == 0 )
            {
               AV73fecha_registro_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV73fecha_registro_To", context.localUtil.Format(AV73fecha_registro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV57K2BToolsGenericSearchField = AV38GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57K2BToolsGenericSearchField", AV57K2BToolsGenericSearchField);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV37GridState.gxTpr_Currentpage > 0 ) && ( AV37GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV37GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV36GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV79Pgmname,  AV36GridStateKey, out  AV37GridState) ;
         AV37GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV37GridState.gxTpr_Orderedby = AV58OrderedBy;
         AV37GridState.gxTpr_Filtervalues.Clear();
         AV38GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV38GridStateFilterValue.gxTpr_Filtername = "nombre_emp";
         AV38GridStateFilterValue.gxTpr_Value = AV40nombre_emp;
         AV37GridState.gxTpr_Filtervalues.Add(AV38GridStateFilterValue, 0);
         AV38GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV38GridStateFilterValue.gxTpr_Filtername = "fecha_registro:From";
         AV38GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV72fecha_registro_From, "99/99/99");
         AV37GridState.gxTpr_Filtervalues.Add(AV38GridStateFilterValue, 0);
         AV38GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV38GridStateFilterValue.gxTpr_Filtername = "fecha_registro:To";
         AV38GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV73fecha_registro_To, "99/99/99");
         AV37GridState.gxTpr_Filtervalues.Add(AV38GridStateFilterValue, 0);
         AV38GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV38GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV38GridStateFilterValue.gxTpr_Value = AV57K2BToolsGenericSearchField;
         AV37GridState.gxTpr_Filtervalues.Add(AV38GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV79Pgmname,  AV36GridStateKey,  AV37GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV67TrnContext = new SdtK2BTrnContext(context);
         AV67TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV67TrnContext.gxTpr_Returnmode = "Stack";
         AV67TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV67TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV67TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "detalle_infotec",  AV67TrnContext) ;
      }

      protected void E137V2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "detalle_infotec",  "detalle_infotec",  "Insert",  "",  "EntityManagerdetalle_infotec") )
         {
            CallWebObject(formatLink("entitymanagerdetalle_infotec.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","correlativo","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtcorrelativo_Visible = 1;
         AssignProp("", false, edtcorrelativo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV14Att_correlativo_Visible = true;
         AssignAttri("", false, "AV14Att_correlativo_Visible", AV14Att_correlativo_Visible);
         edtnombre_emp_Visible = 1;
         AssignProp("", false, edtnombre_emp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_emp_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV15Att_nombre_emp_Visible = true;
         AssignAttri("", false, "AV15Att_nombre_emp_Visible", AV15Att_nombre_emp_Visible);
         edtcargo_emp_Visible = 1;
         AssignProp("", false, edtcargo_emp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcargo_emp_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV16Att_cargo_emp_Visible = true;
         AssignAttri("", false, "AV16Att_cargo_emp_Visible", AV16Att_cargo_emp_Visible);
         edtfecha_registro_Visible = 1;
         AssignProp("", false, edtfecha_registro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtfecha_registro_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV17Att_fecha_registro_Visible = true;
         AssignAttri("", false, "AV17Att_fecha_registro_Visible", AV17Att_fecha_registro_Visible);
         edtestatus_Visible = 1;
         AssignProp("", false, edtestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtestatus_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV19Att_estatus_Visible = true;
         AssignAttri("", false, "AV19Att_estatus_Visible", AV19Att_estatus_Visible);
         edttrabajo_Visible = 1;
         AssignProp("", false, edttrabajo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edttrabajo_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV20Att_trabajo_Visible = true;
         AssignAttri("", false, "AV20Att_trabajo_Visible", AV20Att_trabajo_Visible);
         edtnombre_usuario_Visible = 1;
         AssignProp("", false, edtnombre_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV21Att_nombre_usuario_Visible = true;
         AssignAttri("", false, "AV21Att_nombre_usuario_Visible", AV21Att_nombre_usuario_Visible);
         edtdepto_usuario_Visible = 1;
         AssignProp("", false, edtdepto_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdepto_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV22Att_depto_usuario_Visible = true;
         AssignAttri("", false, "AV22Att_depto_usuario_Visible", AV22Att_depto_usuario_Visible);
         edtcorreo_usuario_Visible = 1;
         AssignProp("", false, edtcorreo_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcorreo_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV23Att_correo_usuario_Visible = true;
         AssignAttri("", false, "AV23Att_correo_usuario_Visible", AV23Att_correo_usuario_Visible);
         edtdetalle_infotecid_unidad_Visible = 1;
         AssignProp("", false, edtdetalle_infotecid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdetalle_infotecid_unidad_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV24Att_detalle_infotecid_unidad_Visible = true;
         AssignAttri("", false, "AV24Att_detalle_infotecid_unidad_Visible", AV24Att_detalle_infotecid_unidad_Visible);
         edtid_categoria_Visible = 1;
         AssignProp("", false, edtid_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_categoria_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV25Att_id_categoria_Visible = true;
         AssignAttri("", false, "AV25Att_id_categoria_Visible", AV25Att_id_categoria_Visible);
         edtid_actividad_Visible = 1;
         AssignProp("", false, edtid_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV26Att_id_actividad_Visible = true;
         AssignAttri("", false, "AV26Att_id_actividad_Visible", AV26Att_id_actividad_Visible);
         edtdetalle_tarea_Visible = 1;
         AssignProp("", false, edtdetalle_tarea_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdetalle_tarea_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV27Att_detalle_tarea_Visible = true;
         AssignAttri("", false, "AV27Att_detalle_tarea_Visible", AV27Att_detalle_tarea_Visible);
         edtprioridad_Visible = 1;
         AssignProp("", false, edtprioridad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtprioridad_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV28Att_prioridad_Visible = true;
         AssignAttri("", false, "AV28Att_prioridad_Visible", AV28Att_prioridad_Visible);
         edtobservaciones_Visible = 1;
         AssignProp("", false, edtobservaciones_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtobservaciones_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV29Att_observaciones_Visible = true;
         AssignAttri("", false, "AV29Att_observaciones_Visible", AV29Att_observaciones_Visible);
         edtfecha_solicitud_Visible = 1;
         AssignProp("", false, edtfecha_solicitud_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtfecha_solicitud_Visible), 5, 0), !bGXsfl_216_Refreshing);
         AV30Att_fecha_solicitud_Visible = true;
         AssignAttri("", false, "AV30Att_fecha_solicitud_Visible", AV30Att_fecha_solicitud_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV79Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV84GXV3 = 1;
         while ( AV84GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV84GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "correlativo") == 0 )
               {
                  edtcorrelativo_Visible = 0;
                  AssignProp("", false, edtcorrelativo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV14Att_correlativo_Visible = false;
                  AssignAttri("", false, "AV14Att_correlativo_Visible", AV14Att_correlativo_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_emp") == 0 )
               {
                  edtnombre_emp_Visible = 0;
                  AssignProp("", false, edtnombre_emp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_emp_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV15Att_nombre_emp_Visible = false;
                  AssignAttri("", false, "AV15Att_nombre_emp_Visible", AV15Att_nombre_emp_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "cargo_emp") == 0 )
               {
                  edtcargo_emp_Visible = 0;
                  AssignProp("", false, edtcargo_emp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcargo_emp_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV16Att_cargo_emp_Visible = false;
                  AssignAttri("", false, "AV16Att_cargo_emp_Visible", AV16Att_cargo_emp_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "fecha_registro") == 0 )
               {
                  edtfecha_registro_Visible = 0;
                  AssignProp("", false, edtfecha_registro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtfecha_registro_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV17Att_fecha_registro_Visible = false;
                  AssignAttri("", false, "AV17Att_fecha_registro_Visible", AV17Att_fecha_registro_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "estatus") == 0 )
               {
                  edtestatus_Visible = 0;
                  AssignProp("", false, edtestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtestatus_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV19Att_estatus_Visible = false;
                  AssignAttri("", false, "AV19Att_estatus_Visible", AV19Att_estatus_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "trabajo") == 0 )
               {
                  edttrabajo_Visible = 0;
                  AssignProp("", false, edttrabajo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edttrabajo_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV20Att_trabajo_Visible = false;
                  AssignAttri("", false, "AV20Att_trabajo_Visible", AV20Att_trabajo_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_usuario") == 0 )
               {
                  edtnombre_usuario_Visible = 0;
                  AssignProp("", false, edtnombre_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV21Att_nombre_usuario_Visible = false;
                  AssignAttri("", false, "AV21Att_nombre_usuario_Visible", AV21Att_nombre_usuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "depto_usuario") == 0 )
               {
                  edtdepto_usuario_Visible = 0;
                  AssignProp("", false, edtdepto_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdepto_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV22Att_depto_usuario_Visible = false;
                  AssignAttri("", false, "AV22Att_depto_usuario_Visible", AV22Att_depto_usuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "correo_usuario") == 0 )
               {
                  edtcorreo_usuario_Visible = 0;
                  AssignProp("", false, edtcorreo_usuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcorreo_usuario_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV23Att_correo_usuario_Visible = false;
                  AssignAttri("", false, "AV23Att_correo_usuario_Visible", AV23Att_correo_usuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "detalle_infotecid_unidad") == 0 )
               {
                  edtdetalle_infotecid_unidad_Visible = 0;
                  AssignProp("", false, edtdetalle_infotecid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdetalle_infotecid_unidad_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV24Att_detalle_infotecid_unidad_Visible = false;
                  AssignAttri("", false, "AV24Att_detalle_infotecid_unidad_Visible", AV24Att_detalle_infotecid_unidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_categoria") == 0 )
               {
                  edtid_categoria_Visible = 0;
                  AssignProp("", false, edtid_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_categoria_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV25Att_id_categoria_Visible = false;
                  AssignAttri("", false, "AV25Att_id_categoria_Visible", AV25Att_id_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad") == 0 )
               {
                  edtid_actividad_Visible = 0;
                  AssignProp("", false, edtid_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV26Att_id_actividad_Visible = false;
                  AssignAttri("", false, "AV26Att_id_actividad_Visible", AV26Att_id_actividad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "detalle_tarea") == 0 )
               {
                  edtdetalle_tarea_Visible = 0;
                  AssignProp("", false, edtdetalle_tarea_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtdetalle_tarea_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV27Att_detalle_tarea_Visible = false;
                  AssignAttri("", false, "AV27Att_detalle_tarea_Visible", AV27Att_detalle_tarea_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "prioridad") == 0 )
               {
                  edtprioridad_Visible = 0;
                  AssignProp("", false, edtprioridad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtprioridad_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV28Att_prioridad_Visible = false;
                  AssignAttri("", false, "AV28Att_prioridad_Visible", AV28Att_prioridad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "observaciones") == 0 )
               {
                  edtobservaciones_Visible = 0;
                  AssignProp("", false, edtobservaciones_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtobservaciones_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV29Att_observaciones_Visible = false;
                  AssignAttri("", false, "AV29Att_observaciones_Visible", AV29Att_observaciones_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "fecha_solicitud") == 0 )
               {
                  edtfecha_solicitud_Visible = 0;
                  AssignProp("", false, edtfecha_solicitud_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtfecha_solicitud_Visible), 5, 0), !bGXsfl_216_Refreshing);
                  AV30Att_fecha_solicitud_Visible = false;
                  AssignAttri("", false, "AV30Att_fecha_solicitud_Visible", AV30Att_fecha_solicitud_Visible);
               }
            }
            AV84GXV3 = (int)(AV84GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "correlativo";
         AV13GridColumn.gxTpr_Columntitle = "correlativo";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_emp";
         AV13GridColumn.gxTpr_Columntitle = "nombre_emp";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "cargo_emp";
         AV13GridColumn.gxTpr_Columntitle = "cargo_emp";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "fecha_registro";
         AV13GridColumn.gxTpr_Columntitle = "fecha_registro";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "estatus";
         AV13GridColumn.gxTpr_Columntitle = "estatus";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "trabajo";
         AV13GridColumn.gxTpr_Columntitle = "trabajo";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_usuario";
         AV13GridColumn.gxTpr_Columntitle = "nombre_usuario";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "depto_usuario";
         AV13GridColumn.gxTpr_Columntitle = "depto_usuario";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "correo_usuario";
         AV13GridColumn.gxTpr_Columntitle = "correo_usuario";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "detalle_infotecid_unidad";
         AV13GridColumn.gxTpr_Columntitle = "id_unidad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_categoria";
         AV13GridColumn.gxTpr_Columntitle = "id_categoria";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_actividad";
         AV13GridColumn.gxTpr_Columntitle = "id_actividad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "detalle_tarea";
         AV13GridColumn.gxTpr_Columntitle = "detalle_tarea";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "prioridad";
         AV13GridColumn.gxTpr_Columntitle = "prioridad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "observaciones";
         AV13GridColumn.gxTpr_Columntitle = "observaciones";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "fecha_solicitud";
         AV13GridColumn.gxTpr_Columntitle = "fecha_solicitud";
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
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttInsert_Visible = 1;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
         else
         {
            bttInsert_Visible = 0;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV70ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerdetalle_infotec";
         AV69ActivityList.Add(AV70ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         AV64nombre_emp_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV64nombre_emp_IsAuthorized", AV64nombre_emp_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_216_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_216_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_216_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_216_Refreshing);
         }
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

      protected void E247V2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV39ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV65Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.convertURL( context.PathToRelativeUrl( AV65Update))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV65Update), true);
         AV81Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.convertURL( context.PathToRelativeUrl( AV65Update))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV65Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_216_Refreshing);
         AV66Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV66Delete))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV66Delete), true);
         AV82Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV66Delete))), !bGXsfl_216_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV66Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_216_Refreshing);
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
         AV61UC_OrderedBy = AV58OrderedBy;
         AssignAttri("", false, "AV61UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV61UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV39ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55FilterTags", AV55FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E257V2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV64nombre_emp_IsAuthorized )
         {
            edtnombre_emp_Link = formatLink("entitymanagerdetalle_infotec.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","correlativo","TabCode"}) ;
         }
         else
         {
            edtnombre_emp_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerdetalle_infotec.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","correlativo","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerdetalle_infotec.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","correlativo","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 216;
         }
         sendrow_2162( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_216_Refreshing )
         {
            context.DoAjaxLoad(216, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV53K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40nombre_emp)) )
         {
            AV54K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV54K2BFilterValuesSDTItem.gxTpr_Name = "nombre_emp";
            AV54K2BFilterValuesSDTItem.gxTpr_Description = "nombre_emp";
            AV54K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV54K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV54K2BFilterValuesSDTItem.gxTpr_Value = AV40nombre_emp;
            AV54K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV40nombre_emp;
            AV53K2BFilterValuesSDT.Add(AV54K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV72fecha_registro_From) || ! (DateTime.MinValue==AV73fecha_registro_To) )
         {
            AV54K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV54K2BFilterValuesSDTItem.gxTpr_Name = "fecha_registro";
            AV54K2BFilterValuesSDTItem.gxTpr_Description = "fecha_registro";
            AV54K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV54K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV54K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV72fecha_registro_From ) ;
            AV54K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV73fecha_registro_To ) ;
            AV54K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV53K2BFilterValuesSDT.Add(AV54K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV53K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV55FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV79Pgmname,  "Grid",  AV53K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV55FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E117V2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV56DeletedTag, "nombre_emp") == 0 )
         {
            AV40nombre_emp = "";
            AssignAttri("", false, "AV40nombre_emp", AV40nombre_emp);
         }
         else if ( StringUtil.StrCmp(AV56DeletedTag, "fecha_registro") == 0 )
         {
            AV72fecha_registro_From = DateTime.MinValue;
            AssignAttri("", false, "AV72fecha_registro_From", context.localUtil.Format(AV72fecha_registro_From, "99/99/99"));
            AV73fecha_registro_To = DateTime.MinValue;
            AssignAttri("", false, "AV73fecha_registro_To", context.localUtil.Format(AV73fecha_registro_To, "99/99/99"));
         }
         gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void E127V2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV58OrderedBy = AV61UC_OrderedBy;
         AssignAttri("", false, "AV58OrderedBy", StringUtil.LTrimStr( (decimal)(AV58OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void E147V2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV79Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV85GXV4 = 1;
         while ( AV85GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV85GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "correlativo") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_correlativo_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_emp") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_nombre_emp_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "cargo_emp") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_cargo_emp_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "fecha_registro") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_fecha_registro_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "estatus") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV19Att_estatus_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "trabajo") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_trabajo_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_usuario") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV21Att_nombre_usuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "depto_usuario") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV22Att_depto_usuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "correo_usuario") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV23Att_correo_usuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "detalle_infotecid_unidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV24Att_detalle_infotecid_unidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV25Att_id_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV26Att_id_actividad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "detalle_tarea") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV27Att_detalle_tarea_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "prioridad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV28Att_prioridad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "observaciones") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV29Att_observaciones_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "fecha_solicitud") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV30Att_fecha_solicitud_Visible;
            }
            AV85GXV4 = (int)(AV85GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV79Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV61UC_OrderedBy = AV58OrderedBy;
         AssignAttri("", false, "AV61UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV61UC_OrderedBy), 4, 0));
         if ( AV34RowsPerPageVariable != AV33GridSettingsRowsPerPageVariable )
         {
            AV34RowsPerPageVariable = AV33GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV34RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV34RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV34RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV79Pgmname,  "Grid",  AV34RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV57K2BToolsGenericSearchField, AV40nombre_emp, AV72fecha_registro_From, AV39ClassCollection, AV58OrderedBy, AV73fecha_registro_To, AV79Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64nombre_emp_IsAuthorized, AV14Att_correlativo_Visible, AV15Att_nombre_emp_Visible, AV16Att_cargo_emp_Visible, AV17Att_fecha_registro_Visible, AV19Att_estatus_Visible, AV20Att_trabajo_Visible, AV21Att_nombre_usuario_Visible, AV22Att_depto_usuario_Visible, AV23Att_correo_usuario_Visible, AV24Att_detalle_infotecid_unidad_Visible, AV25Att_id_categoria_Visible, AV26Att_id_actividad_Visible, AV27Att_detalle_tarea_Visible, AV28Att_prioridad_Visible, AV29Att_observaciones_Visible, AV30Att_fecha_solicitud_Visible, AV11FreezeColumnTitles, AV76Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
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

      protected void E157V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void E167V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void E177V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
      }

      protected void E187V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ClassCollection", AV39ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV79Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV39ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV39ClassCollection) ;
         }
      }

      protected void E197V2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "detalle_infotec",  "detalle_infotec",  "List",  "",  "ExportWWdetalle_infotec") )
         {
            new exportwwdetalle_infotec(context ).execute(  AV40nombre_emp,  AV72fecha_registro_From,  AV73fecha_registro_To,  AV57K2BToolsGenericSearchField,  AV58OrderedBy, out  AV74OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV74OutFile, out  AV76Uri) )
            {
               CallWebObject(formatLink(AV76Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV75Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV75Guid.ToString(),  AV74OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV75Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E207V2( )
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

      protected void E217V2( )
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

      protected void wb_table2_237_7V2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_237_7V2e( true) ;
         }
         else
         {
            wb_table2_237_7V2e( false) ;
         }
      }

      protected void wb_table1_52_7V2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e267v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWdetalle_infotec.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWdetalle_infotec.htm");
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
            GxWebStd.gx_div_start( context, divCorrelativo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_correlativo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_correlativo_visible_Internalname, "correlativo", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_correlativo_visible_Internalname, StringUtil.BoolToStr( AV14Att_correlativo_Visible), "", "correlativo", 1, chkavAtt_correlativo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(81, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,81);\"");
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
            GxWebStd.gx_div_start( context, divNombre_emp_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_emp_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_emp_visible_Internalname, "nombre_emp", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_emp_visible_Internalname, StringUtil.BoolToStr( AV15Att_nombre_emp_Visible), "", "nombre_emp", 1, chkavAtt_nombre_emp_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(87, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,87);\"");
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
            GxWebStd.gx_div_start( context, divCargo_emp_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_cargo_emp_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_cargo_emp_visible_Internalname, "cargo_emp", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_cargo_emp_visible_Internalname, StringUtil.BoolToStr( AV16Att_cargo_emp_Visible), "", "cargo_emp", 1, chkavAtt_cargo_emp_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
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
            GxWebStd.gx_div_start( context, divFecha_registro_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_fecha_registro_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_fecha_registro_visible_Internalname, "fecha_registro", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_fecha_registro_visible_Internalname, StringUtil.BoolToStr( AV17Att_fecha_registro_Visible), "", "fecha_registro", 1, chkavAtt_fecha_registro_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
            GxWebStd.gx_div_start( context, divEstatus_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estatus_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estatus_visible_Internalname, "estatus", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estatus_visible_Internalname, StringUtil.BoolToStr( AV19Att_estatus_Visible), "", "estatus", 1, chkavAtt_estatus_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
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
            GxWebStd.gx_div_start( context, divTrabajo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_trabajo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_trabajo_visible_Internalname, "trabajo", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_trabajo_visible_Internalname, StringUtil.BoolToStr( AV20Att_trabajo_Visible), "", "trabajo", 1, chkavAtt_trabajo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
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
            GxWebStd.gx_div_start( context, divNombre_usuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_usuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_usuario_visible_Internalname, "nombre_usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_usuario_visible_Internalname, StringUtil.BoolToStr( AV21Att_nombre_usuario_Visible), "", "nombre_usuario", 1, chkavAtt_nombre_usuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(117, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,117);\"");
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
            GxWebStd.gx_div_start( context, divDepto_usuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_depto_usuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_depto_usuario_visible_Internalname, "depto_usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_depto_usuario_visible_Internalname, StringUtil.BoolToStr( AV22Att_depto_usuario_Visible), "", "depto_usuario", 1, chkavAtt_depto_usuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,123);\"");
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
            GxWebStd.gx_div_start( context, divCorreo_usuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_correo_usuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_correo_usuario_visible_Internalname, "correo_usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_correo_usuario_visible_Internalname, StringUtil.BoolToStr( AV23Att_correo_usuario_Visible), "", "correo_usuario", 1, chkavAtt_correo_usuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(129, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,129);\"");
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
            GxWebStd.gx_div_start( context, divDetalle_infotecid_unidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_detalle_infotecid_unidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_detalle_infotecid_unidad_visible_Internalname, "id_unidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_detalle_infotecid_unidad_visible_Internalname, StringUtil.BoolToStr( AV24Att_detalle_infotecid_unidad_Visible), "", "id_unidad", 1, chkavAtt_detalle_infotecid_unidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
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
            GxWebStd.gx_div_start( context, divId_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_categoria_visible_Internalname, "id_categoria", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_categoria_visible_Internalname, StringUtil.BoolToStr( AV25Att_id_categoria_Visible), "", "id_categoria", 1, chkavAtt_id_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(141, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,141);\"");
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
            GxWebStd.gx_div_start( context, divId_actividad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_actividad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_actividad_visible_Internalname, "id_actividad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_actividad_visible_Internalname, StringUtil.BoolToStr( AV26Att_id_actividad_Visible), "", "id_actividad", 1, chkavAtt_id_actividad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(147, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,147);\"");
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
            GxWebStd.gx_div_start( context, divDetalle_tarea_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_detalle_tarea_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_detalle_tarea_visible_Internalname, "detalle_tarea", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_detalle_tarea_visible_Internalname, StringUtil.BoolToStr( AV27Att_detalle_tarea_Visible), "", "detalle_tarea", 1, chkavAtt_detalle_tarea_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(153, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,153);\"");
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
            GxWebStd.gx_div_start( context, divPrioridad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_prioridad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_prioridad_visible_Internalname, "prioridad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_prioridad_visible_Internalname, StringUtil.BoolToStr( AV28Att_prioridad_Visible), "", "prioridad", 1, chkavAtt_prioridad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(159, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,159);\"");
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
            GxWebStd.gx_div_start( context, divObservaciones_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_observaciones_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_observaciones_visible_Internalname, "observaciones", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_observaciones_visible_Internalname, StringUtil.BoolToStr( AV29Att_observaciones_Visible), "", "observaciones", 1, chkavAtt_observaciones_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(165, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,165);\"");
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
            GxWebStd.gx_div_start( context, divFecha_solicitud_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_fecha_solicitud_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_fecha_solicitud_visible_Internalname, "fecha_solicitud", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_fecha_solicitud_visible_Internalname, StringUtil.BoolToStr( AV30Att_fecha_solicitud_Visible), "", "fecha_solicitud", 1, chkavAtt_fecha_solicitud_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(171, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,171);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_216_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "", true, 1, "HLP_WWdetalle_infotec.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'" + sGXsfl_216_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(216), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWdetalle_infotec.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e277v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWdetalle_infotec.htm");
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
            wb_table3_197_7V2( true) ;
         }
         else
         {
            wb_table3_197_7V2( false) ;
         }
         return  ;
      }

      protected void wb_table3_197_7V2e( bool wbgen )
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
            context.WriteHtmlText( "<td>") ;
            wb_table4_204_7V2( true) ;
         }
         else
         {
            wb_table4_204_7V2( false) ;
         }
         return  ;
      }

      protected void wb_table4_204_7V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_52_7V2e( true) ;
         }
         else
         {
            wb_table1_52_7V2e( false) ;
         }
      }

      protected void wb_table4_204_7V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(216), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWdetalle_infotec.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_204_7V2e( true) ;
         }
         else
         {
            wb_table4_204_7V2e( false) ;
         }
      }

      protected void wb_table3_197_7V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(216), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e287v1_client"+"'", TempTags, "", 2, "HLP_WWdetalle_infotec.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(216), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWdetalle_infotec.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_197_7V2e( true) ;
         }
         else
         {
            wb_table3_197_7V2e( false) ;
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
         PA7V2( ) ;
         WS7V2( ) ;
         WE7V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188223591", true, true);
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
         context.AddJavascriptSource("wwdetalle_infotec.js", "?2024188223592", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_2162( )
      {
         edtcorrelativo_Internalname = "CORRELATIVO_"+sGXsfl_216_idx;
         edtnombre_emp_Internalname = "NOMBRE_EMP_"+sGXsfl_216_idx;
         edtcargo_emp_Internalname = "CARGO_EMP_"+sGXsfl_216_idx;
         edtfecha_registro_Internalname = "FECHA_REGISTRO_"+sGXsfl_216_idx;
         edtestatus_Internalname = "ESTATUS_"+sGXsfl_216_idx;
         edttrabajo_Internalname = "TRABAJO_"+sGXsfl_216_idx;
         edtnombre_usuario_Internalname = "NOMBRE_USUARIO_"+sGXsfl_216_idx;
         edtdepto_usuario_Internalname = "DEPTO_USUARIO_"+sGXsfl_216_idx;
         edtcorreo_usuario_Internalname = "CORREO_USUARIO_"+sGXsfl_216_idx;
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD_"+sGXsfl_216_idx;
         edtid_categoria_Internalname = "ID_CATEGORIA_"+sGXsfl_216_idx;
         edtid_actividad_Internalname = "ID_ACTIVIDAD_"+sGXsfl_216_idx;
         edtdetalle_tarea_Internalname = "DETALLE_TAREA_"+sGXsfl_216_idx;
         edtprioridad_Internalname = "PRIORIDAD_"+sGXsfl_216_idx;
         edtobservaciones_Internalname = "OBSERVACIONES_"+sGXsfl_216_idx;
         edtfecha_solicitud_Internalname = "FECHA_SOLICITUD_"+sGXsfl_216_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_216_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_216_idx;
      }

      protected void SubsflControlProps_fel_2162( )
      {
         edtcorrelativo_Internalname = "CORRELATIVO_"+sGXsfl_216_fel_idx;
         edtnombre_emp_Internalname = "NOMBRE_EMP_"+sGXsfl_216_fel_idx;
         edtcargo_emp_Internalname = "CARGO_EMP_"+sGXsfl_216_fel_idx;
         edtfecha_registro_Internalname = "FECHA_REGISTRO_"+sGXsfl_216_fel_idx;
         edtestatus_Internalname = "ESTATUS_"+sGXsfl_216_fel_idx;
         edttrabajo_Internalname = "TRABAJO_"+sGXsfl_216_fel_idx;
         edtnombre_usuario_Internalname = "NOMBRE_USUARIO_"+sGXsfl_216_fel_idx;
         edtdepto_usuario_Internalname = "DEPTO_USUARIO_"+sGXsfl_216_fel_idx;
         edtcorreo_usuario_Internalname = "CORREO_USUARIO_"+sGXsfl_216_fel_idx;
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD_"+sGXsfl_216_fel_idx;
         edtid_categoria_Internalname = "ID_CATEGORIA_"+sGXsfl_216_fel_idx;
         edtid_actividad_Internalname = "ID_ACTIVIDAD_"+sGXsfl_216_fel_idx;
         edtdetalle_tarea_Internalname = "DETALLE_TAREA_"+sGXsfl_216_fel_idx;
         edtprioridad_Internalname = "PRIORIDAD_"+sGXsfl_216_fel_idx;
         edtobservaciones_Internalname = "OBSERVACIONES_"+sGXsfl_216_fel_idx;
         edtfecha_solicitud_Internalname = "FECHA_SOLICITUD_"+sGXsfl_216_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_216_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_216_fel_idx;
      }

      protected void sendrow_2162( )
      {
         SubsflControlProps_2162( ) ;
         WB7V0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_216_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_216_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_216_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtcorrelativo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcorrelativo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcorrelativo_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtcorrelativo_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)73,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_emp_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_emp_Internalname,(string)A239nombre_emp,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtnombre_emp_Link,(string)"",(string)"",(string)"",(string)edtnombre_emp_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtnombre_emp_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtcargo_emp_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcargo_emp_Internalname,(string)A240cargo_emp,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcargo_emp_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtcargo_emp_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtfecha_registro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtfecha_registro_Internalname,context.localUtil.Format(A241fecha_registro, "99/99/99"),context.localUtil.Format( A241fecha_registro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtfecha_registro_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtfecha_registro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtestatus_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtestatus_Internalname,(string)A243estatus,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtestatus_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtestatus_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edttrabajo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edttrabajo_Internalname,(string)A244trabajo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edttrabajo_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edttrabajo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_usuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_usuario_Internalname,(string)A245nombre_usuario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombre_usuario_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombre_usuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtdepto_usuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtdepto_usuario_Internalname,(string)A246depto_usuario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtdepto_usuario_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtdepto_usuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtcorreo_usuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcorreo_usuario_Internalname,(string)A247correo_usuario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcorreo_usuario_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtcorreo_usuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtdetalle_infotecid_unidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtdetalle_infotecid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtdetalle_infotecid_unidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtdetalle_infotecid_unidad_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A249id_categoria), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_categoria_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_actividad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_actividad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A250id_actividad), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_actividad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_actividad_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtdetalle_tarea_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtdetalle_tarea_Internalname,(string)A251detalle_tarea,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtdetalle_tarea_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtdetalle_tarea_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtprioridad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtprioridad_Internalname,(string)A252prioridad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtprioridad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtprioridad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtobservaciones_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtobservaciones_Internalname,(string)A253observaciones,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtobservaciones_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtobservaciones_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtfecha_solicitud_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtfecha_solicitud_Internalname,(string)A254fecha_solicitud,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtfecha_solicitud_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtfecha_solicitud_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)216,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV65Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV65Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV81Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV65Update)) ? AV81Update_GXI : context.PathToRelativeUrl( AV65Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV65Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV66Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV82Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV66Delete)) ? AV82Delete_GXI : context.PathToRelativeUrl( AV66Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV66Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes7V2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_216_idx = ((subGrid_Islastpage==1)&&(nGXsfl_216_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_216_idx+1);
            sGXsfl_216_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_216_idx), 4, 0), 4, "0");
            SubsflControlProps_2162( ) ;
         }
         /* End function sendrow_2162 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_correlativo_visible.Name = "vATT_CORRELATIVO_VISIBLE";
         chkavAtt_correlativo_visible.WebTags = "";
         chkavAtt_correlativo_visible.Caption = "";
         AssignProp("", false, chkavAtt_correlativo_visible_Internalname, "TitleCaption", chkavAtt_correlativo_visible.Caption, true);
         chkavAtt_correlativo_visible.CheckedValue = "false";
         AV14Att_correlativo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_correlativo_Visible));
         AssignAttri("", false, "AV14Att_correlativo_Visible", AV14Att_correlativo_Visible);
         chkavAtt_nombre_emp_visible.Name = "vATT_NOMBRE_EMP_VISIBLE";
         chkavAtt_nombre_emp_visible.WebTags = "";
         chkavAtt_nombre_emp_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_emp_visible_Internalname, "TitleCaption", chkavAtt_nombre_emp_visible.Caption, true);
         chkavAtt_nombre_emp_visible.CheckedValue = "false";
         AV15Att_nombre_emp_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_nombre_emp_Visible));
         AssignAttri("", false, "AV15Att_nombre_emp_Visible", AV15Att_nombre_emp_Visible);
         chkavAtt_cargo_emp_visible.Name = "vATT_CARGO_EMP_VISIBLE";
         chkavAtt_cargo_emp_visible.WebTags = "";
         chkavAtt_cargo_emp_visible.Caption = "";
         AssignProp("", false, chkavAtt_cargo_emp_visible_Internalname, "TitleCaption", chkavAtt_cargo_emp_visible.Caption, true);
         chkavAtt_cargo_emp_visible.CheckedValue = "false";
         AV16Att_cargo_emp_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_cargo_emp_Visible));
         AssignAttri("", false, "AV16Att_cargo_emp_Visible", AV16Att_cargo_emp_Visible);
         chkavAtt_fecha_registro_visible.Name = "vATT_FECHA_REGISTRO_VISIBLE";
         chkavAtt_fecha_registro_visible.WebTags = "";
         chkavAtt_fecha_registro_visible.Caption = "";
         AssignProp("", false, chkavAtt_fecha_registro_visible_Internalname, "TitleCaption", chkavAtt_fecha_registro_visible.Caption, true);
         chkavAtt_fecha_registro_visible.CheckedValue = "false";
         AV17Att_fecha_registro_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_fecha_registro_Visible));
         AssignAttri("", false, "AV17Att_fecha_registro_Visible", AV17Att_fecha_registro_Visible);
         chkavAtt_estatus_visible.Name = "vATT_ESTATUS_VISIBLE";
         chkavAtt_estatus_visible.WebTags = "";
         chkavAtt_estatus_visible.Caption = "";
         AssignProp("", false, chkavAtt_estatus_visible_Internalname, "TitleCaption", chkavAtt_estatus_visible.Caption, true);
         chkavAtt_estatus_visible.CheckedValue = "false";
         AV19Att_estatus_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_estatus_Visible));
         AssignAttri("", false, "AV19Att_estatus_Visible", AV19Att_estatus_Visible);
         chkavAtt_trabajo_visible.Name = "vATT_TRABAJO_VISIBLE";
         chkavAtt_trabajo_visible.WebTags = "";
         chkavAtt_trabajo_visible.Caption = "";
         AssignProp("", false, chkavAtt_trabajo_visible_Internalname, "TitleCaption", chkavAtt_trabajo_visible.Caption, true);
         chkavAtt_trabajo_visible.CheckedValue = "false";
         AV20Att_trabajo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_trabajo_Visible));
         AssignAttri("", false, "AV20Att_trabajo_Visible", AV20Att_trabajo_Visible);
         chkavAtt_nombre_usuario_visible.Name = "vATT_NOMBRE_USUARIO_VISIBLE";
         chkavAtt_nombre_usuario_visible.WebTags = "";
         chkavAtt_nombre_usuario_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_usuario_visible_Internalname, "TitleCaption", chkavAtt_nombre_usuario_visible.Caption, true);
         chkavAtt_nombre_usuario_visible.CheckedValue = "false";
         AV21Att_nombre_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_nombre_usuario_Visible));
         AssignAttri("", false, "AV21Att_nombre_usuario_Visible", AV21Att_nombre_usuario_Visible);
         chkavAtt_depto_usuario_visible.Name = "vATT_DEPTO_USUARIO_VISIBLE";
         chkavAtt_depto_usuario_visible.WebTags = "";
         chkavAtt_depto_usuario_visible.Caption = "";
         AssignProp("", false, chkavAtt_depto_usuario_visible_Internalname, "TitleCaption", chkavAtt_depto_usuario_visible.Caption, true);
         chkavAtt_depto_usuario_visible.CheckedValue = "false";
         AV22Att_depto_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_depto_usuario_Visible));
         AssignAttri("", false, "AV22Att_depto_usuario_Visible", AV22Att_depto_usuario_Visible);
         chkavAtt_correo_usuario_visible.Name = "vATT_CORREO_USUARIO_VISIBLE";
         chkavAtt_correo_usuario_visible.WebTags = "";
         chkavAtt_correo_usuario_visible.Caption = "";
         AssignProp("", false, chkavAtt_correo_usuario_visible_Internalname, "TitleCaption", chkavAtt_correo_usuario_visible.Caption, true);
         chkavAtt_correo_usuario_visible.CheckedValue = "false";
         AV23Att_correo_usuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_correo_usuario_Visible));
         AssignAttri("", false, "AV23Att_correo_usuario_Visible", AV23Att_correo_usuario_Visible);
         chkavAtt_detalle_infotecid_unidad_visible.Name = "vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE";
         chkavAtt_detalle_infotecid_unidad_visible.WebTags = "";
         chkavAtt_detalle_infotecid_unidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_detalle_infotecid_unidad_visible_Internalname, "TitleCaption", chkavAtt_detalle_infotecid_unidad_visible.Caption, true);
         chkavAtt_detalle_infotecid_unidad_visible.CheckedValue = "false";
         AV24Att_detalle_infotecid_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_detalle_infotecid_unidad_Visible));
         AssignAttri("", false, "AV24Att_detalle_infotecid_unidad_Visible", AV24Att_detalle_infotecid_unidad_Visible);
         chkavAtt_id_categoria_visible.Name = "vATT_ID_CATEGORIA_VISIBLE";
         chkavAtt_id_categoria_visible.WebTags = "";
         chkavAtt_id_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_categoria_visible_Internalname, "TitleCaption", chkavAtt_id_categoria_visible.Caption, true);
         chkavAtt_id_categoria_visible.CheckedValue = "false";
         AV25Att_id_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_id_categoria_Visible));
         AssignAttri("", false, "AV25Att_id_categoria_Visible", AV25Att_id_categoria_Visible);
         chkavAtt_id_actividad_visible.Name = "vATT_ID_ACTIVIDAD_VISIBLE";
         chkavAtt_id_actividad_visible.WebTags = "";
         chkavAtt_id_actividad_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_actividad_visible_Internalname, "TitleCaption", chkavAtt_id_actividad_visible.Caption, true);
         chkavAtt_id_actividad_visible.CheckedValue = "false";
         AV26Att_id_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV26Att_id_actividad_Visible));
         AssignAttri("", false, "AV26Att_id_actividad_Visible", AV26Att_id_actividad_Visible);
         chkavAtt_detalle_tarea_visible.Name = "vATT_DETALLE_TAREA_VISIBLE";
         chkavAtt_detalle_tarea_visible.WebTags = "";
         chkavAtt_detalle_tarea_visible.Caption = "";
         AssignProp("", false, chkavAtt_detalle_tarea_visible_Internalname, "TitleCaption", chkavAtt_detalle_tarea_visible.Caption, true);
         chkavAtt_detalle_tarea_visible.CheckedValue = "false";
         AV27Att_detalle_tarea_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV27Att_detalle_tarea_Visible));
         AssignAttri("", false, "AV27Att_detalle_tarea_Visible", AV27Att_detalle_tarea_Visible);
         chkavAtt_prioridad_visible.Name = "vATT_PRIORIDAD_VISIBLE";
         chkavAtt_prioridad_visible.WebTags = "";
         chkavAtt_prioridad_visible.Caption = "";
         AssignProp("", false, chkavAtt_prioridad_visible_Internalname, "TitleCaption", chkavAtt_prioridad_visible.Caption, true);
         chkavAtt_prioridad_visible.CheckedValue = "false";
         AV28Att_prioridad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV28Att_prioridad_Visible));
         AssignAttri("", false, "AV28Att_prioridad_Visible", AV28Att_prioridad_Visible);
         chkavAtt_observaciones_visible.Name = "vATT_OBSERVACIONES_VISIBLE";
         chkavAtt_observaciones_visible.WebTags = "";
         chkavAtt_observaciones_visible.Caption = "";
         AssignProp("", false, chkavAtt_observaciones_visible_Internalname, "TitleCaption", chkavAtt_observaciones_visible.Caption, true);
         chkavAtt_observaciones_visible.CheckedValue = "false";
         AV29Att_observaciones_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV29Att_observaciones_Visible));
         AssignAttri("", false, "AV29Att_observaciones_Visible", AV29Att_observaciones_Visible);
         chkavAtt_fecha_solicitud_visible.Name = "vATT_FECHA_SOLICITUD_VISIBLE";
         chkavAtt_fecha_solicitud_visible.WebTags = "";
         chkavAtt_fecha_solicitud_visible.Caption = "";
         AssignProp("", false, chkavAtt_fecha_solicitud_visible_Internalname, "TitleCaption", chkavAtt_fecha_solicitud_visible.Caption, true);
         chkavAtt_fecha_solicitud_visible.CheckedValue = "false";
         AV30Att_fecha_solicitud_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV30Att_fecha_solicitud_Visible));
         AssignAttri("", false, "AV30Att_fecha_solicitud_Visible", AV30Att_fecha_solicitud_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV33GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV33GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV33GridSettingsRowsPerPageVariable), 4, 0));
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
         edtavNombre_emp_Internalname = "vNOMBRE_EMP";
         divK2btoolstable_attributecontainernombre_emp_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_EMP";
         lblTextblockfecha_registro_Internalname = "TEXTBLOCKFECHA_REGISTRO";
         Fecha_registro_daterangepicker_Internalname = "FECHA_REGISTRO_DATERANGEPICKER";
         divK2btoolstable_attributecontainerfecha_registro_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERFECHA_REGISTRO";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_correlativo_visible_Internalname = "vATT_CORRELATIVO_VISIBLE";
         divCorrelativo_gridsettingscontainer_Internalname = "CORRELATIVO_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_emp_visible_Internalname = "vATT_NOMBRE_EMP_VISIBLE";
         divNombre_emp_gridsettingscontainer_Internalname = "NOMBRE_EMP_GRIDSETTINGSCONTAINER";
         chkavAtt_cargo_emp_visible_Internalname = "vATT_CARGO_EMP_VISIBLE";
         divCargo_emp_gridsettingscontainer_Internalname = "CARGO_EMP_GRIDSETTINGSCONTAINER";
         chkavAtt_fecha_registro_visible_Internalname = "vATT_FECHA_REGISTRO_VISIBLE";
         divFecha_registro_gridsettingscontainer_Internalname = "FECHA_REGISTRO_GRIDSETTINGSCONTAINER";
         chkavAtt_estatus_visible_Internalname = "vATT_ESTATUS_VISIBLE";
         divEstatus_gridsettingscontainer_Internalname = "ESTATUS_GRIDSETTINGSCONTAINER";
         chkavAtt_trabajo_visible_Internalname = "vATT_TRABAJO_VISIBLE";
         divTrabajo_gridsettingscontainer_Internalname = "TRABAJO_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_usuario_visible_Internalname = "vATT_NOMBRE_USUARIO_VISIBLE";
         divNombre_usuario_gridsettingscontainer_Internalname = "NOMBRE_USUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_depto_usuario_visible_Internalname = "vATT_DEPTO_USUARIO_VISIBLE";
         divDepto_usuario_gridsettingscontainer_Internalname = "DEPTO_USUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_correo_usuario_visible_Internalname = "vATT_CORREO_USUARIO_VISIBLE";
         divCorreo_usuario_gridsettingscontainer_Internalname = "CORREO_USUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_detalle_infotecid_unidad_visible_Internalname = "vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE";
         divDetalle_infotecid_unidad_gridsettingscontainer_Internalname = "DETALLE_INFOTECID_UNIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_id_categoria_visible_Internalname = "vATT_ID_CATEGORIA_VISIBLE";
         divId_categoria_gridsettingscontainer_Internalname = "ID_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_id_actividad_visible_Internalname = "vATT_ID_ACTIVIDAD_VISIBLE";
         divId_actividad_gridsettingscontainer_Internalname = "ID_ACTIVIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_detalle_tarea_visible_Internalname = "vATT_DETALLE_TAREA_VISIBLE";
         divDetalle_tarea_gridsettingscontainer_Internalname = "DETALLE_TAREA_GRIDSETTINGSCONTAINER";
         chkavAtt_prioridad_visible_Internalname = "vATT_PRIORIDAD_VISIBLE";
         divPrioridad_gridsettingscontainer_Internalname = "PRIORIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_observaciones_visible_Internalname = "vATT_OBSERVACIONES_VISIBLE";
         divObservaciones_gridsettingscontainer_Internalname = "OBSERVACIONES_GRIDSETTINGSCONTAINER";
         chkavAtt_fecha_solicitud_visible_Internalname = "vATT_FECHA_SOLICITUD_VISIBLE";
         divFecha_solicitud_gridsettingscontainer_Internalname = "FECHA_SOLICITUD_GRIDSETTINGSCONTAINER";
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
         bttInsert_Internalname = "INSERT";
         tblK2btableactionsrightcontainer_Internalname = "K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtcorrelativo_Internalname = "CORRELATIVO";
         edtnombre_emp_Internalname = "NOMBRE_EMP";
         edtcargo_emp_Internalname = "CARGO_EMP";
         edtfecha_registro_Internalname = "FECHA_REGISTRO";
         edtestatus_Internalname = "ESTATUS";
         edttrabajo_Internalname = "TRABAJO";
         edtnombre_usuario_Internalname = "NOMBRE_USUARIO";
         edtdepto_usuario_Internalname = "DEPTO_USUARIO";
         edtcorreo_usuario_Internalname = "CORREO_USUARIO";
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD";
         edtid_categoria_Internalname = "ID_CATEGORIA";
         edtid_actividad_Internalname = "ID_ACTIVIDAD";
         edtdetalle_tarea_Internalname = "DETALLE_TAREA";
         edtprioridad_Internalname = "PRIORIDAD";
         edtobservaciones_Internalname = "OBSERVACIONES";
         edtfecha_solicitud_Internalname = "FECHA_SOLICITUD";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
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
         chkavAtt_fecha_solicitud_visible.Caption = "fecha_solicitud";
         chkavAtt_observaciones_visible.Caption = "observaciones";
         chkavAtt_prioridad_visible.Caption = "prioridad";
         chkavAtt_detalle_tarea_visible.Caption = "detalle_tarea";
         chkavAtt_id_actividad_visible.Caption = "id_actividad";
         chkavAtt_id_categoria_visible.Caption = "id_categoria";
         chkavAtt_detalle_infotecid_unidad_visible.Caption = "id_unidad";
         chkavAtt_correo_usuario_visible.Caption = "correo_usuario";
         chkavAtt_depto_usuario_visible.Caption = "depto_usuario";
         chkavAtt_nombre_usuario_visible.Caption = "nombre_usuario";
         chkavAtt_trabajo_visible.Caption = "trabajo";
         chkavAtt_estatus_visible.Caption = "estatus";
         chkavAtt_fecha_registro_visible.Caption = "fecha_registro";
         chkavAtt_cargo_emp_visible.Caption = "cargo_emp";
         chkavAtt_nombre_emp_visible.Caption = "nombre_emp";
         chkavAtt_correlativo_visible.Caption = "correlativo";
         edtfecha_solicitud_Jsonclick = "";
         edtobservaciones_Jsonclick = "";
         edtprioridad_Jsonclick = "";
         edtdetalle_tarea_Jsonclick = "";
         edtid_actividad_Jsonclick = "";
         edtid_categoria_Jsonclick = "";
         edtdetalle_infotecid_unidad_Jsonclick = "";
         edtcorreo_usuario_Jsonclick = "";
         edtdepto_usuario_Jsonclick = "";
         edtnombre_usuario_Jsonclick = "";
         edttrabajo_Jsonclick = "";
         edtestatus_Jsonclick = "";
         edtfecha_registro_Jsonclick = "";
         edtcargo_emp_Jsonclick = "";
         edtnombre_emp_Jsonclick = "";
         edtcorrelativo_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_fecha_solicitud_visible.Enabled = 1;
         chkavAtt_observaciones_visible.Enabled = 1;
         chkavAtt_prioridad_visible.Enabled = 1;
         chkavAtt_detalle_tarea_visible.Enabled = 1;
         chkavAtt_id_actividad_visible.Enabled = 1;
         chkavAtt_id_categoria_visible.Enabled = 1;
         chkavAtt_detalle_infotecid_unidad_visible.Enabled = 1;
         chkavAtt_correo_usuario_visible.Enabled = 1;
         chkavAtt_depto_usuario_visible.Enabled = 1;
         chkavAtt_nombre_usuario_visible.Enabled = 1;
         chkavAtt_trabajo_visible.Enabled = 1;
         chkavAtt_estatus_visible.Enabled = 1;
         chkavAtt_fecha_registro_visible.Enabled = 1;
         chkavAtt_cargo_emp_visible.Enabled = 1;
         chkavAtt_nombre_emp_visible.Enabled = 1;
         chkavAtt_correlativo_visible.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         tblNoresultsfoundtable_Visible = 1;
         bttInsert_Tooltiptext = "Agregar";
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
         edtavDelete_Tooltiptext = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Tooltiptext = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtnombre_emp_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtfecha_solicitud_Visible = -1;
         edtobservaciones_Visible = -1;
         edtprioridad_Visible = -1;
         edtdetalle_tarea_Visible = -1;
         edtid_actividad_Visible = -1;
         edtid_categoria_Visible = -1;
         edtdetalle_infotecid_unidad_Visible = -1;
         edtcorreo_usuario_Visible = -1;
         edtdepto_usuario_Visible = -1;
         edtnombre_usuario_Visible = -1;
         edttrabajo_Visible = -1;
         edtestatus_Visible = -1;
         edtfecha_registro_Visible = -1;
         edtcargo_emp_Visible = -1;
         edtnombre_emp_Visible = -1;
         edtcorrelativo_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavNombre_emp_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "detalle_infoteces";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E137V2',iparms:[{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9',hsh:true},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E287V1',iparms:[{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E247V2',iparms:[{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV61UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV55FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E257V2',iparms:[{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9',hsh:true},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtnombre_emp_Link',ctrl:'NOMBRE_EMP',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E117V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV56DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E127V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV61UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E267V1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E147V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV34RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV33GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV61UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV34RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E157V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E167V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E177V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E187V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV65Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV66Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV64nombre_emp_IsAuthorized',fld:'vNOMBRE_EMP_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV39ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcorrelativo_Visible',ctrl:'CORRELATIVO',prop:'Visible'},{av:'edtnombre_emp_Visible',ctrl:'NOMBRE_EMP',prop:'Visible'},{av:'edtcargo_emp_Visible',ctrl:'CARGO_EMP',prop:'Visible'},{av:'edtfecha_registro_Visible',ctrl:'FECHA_REGISTRO',prop:'Visible'},{av:'edtestatus_Visible',ctrl:'ESTATUS',prop:'Visible'},{av:'edttrabajo_Visible',ctrl:'TRABAJO',prop:'Visible'},{av:'edtnombre_usuario_Visible',ctrl:'NOMBRE_USUARIO',prop:'Visible'},{av:'edtdepto_usuario_Visible',ctrl:'DEPTO_USUARIO',prop:'Visible'},{av:'edtcorreo_usuario_Visible',ctrl:'CORREO_USUARIO',prop:'Visible'},{av:'edtdetalle_infotecid_unidad_Visible',ctrl:'DETALLE_INFOTECID_UNIDAD',prop:'Visible'},{av:'edtid_categoria_Visible',ctrl:'ID_CATEGORIA',prop:'Visible'},{av:'edtid_actividad_Visible',ctrl:'ID_ACTIVIDAD',prop:'Visible'},{av:'edtdetalle_tarea_Visible',ctrl:'DETALLE_TAREA',prop:'Visible'},{av:'edtprioridad_Visible',ctrl:'PRIORIDAD',prop:'Visible'},{av:'edtobservaciones_Visible',ctrl:'OBSERVACIONES',prop:'Visible'},{av:'edtfecha_solicitud_Visible',ctrl:'FECHA_SOLICITUD',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E197V2',iparms:[{av:'AV40nombre_emp',fld:'vNOMBRE_EMP',pic:''},{av:'AV72fecha_registro_From',fld:'vFECHA_REGISTRO_FROM',pic:''},{av:'AV73fecha_registro_To',fld:'vFECHA_REGISTRO_TO',pic:''},{av:'AV57K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV58OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV76Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E207V2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E217V2',iparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E277V1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_correlativo_Visible',fld:'vATT_CORRELATIVO_VISIBLE',pic:''},{av:'AV15Att_nombre_emp_Visible',fld:'vATT_NOMBRE_EMP_VISIBLE',pic:''},{av:'AV16Att_cargo_emp_Visible',fld:'vATT_CARGO_EMP_VISIBLE',pic:''},{av:'AV17Att_fecha_registro_Visible',fld:'vATT_FECHA_REGISTRO_VISIBLE',pic:''},{av:'AV19Att_estatus_Visible',fld:'vATT_ESTATUS_VISIBLE',pic:''},{av:'AV20Att_trabajo_Visible',fld:'vATT_TRABAJO_VISIBLE',pic:''},{av:'AV21Att_nombre_usuario_Visible',fld:'vATT_NOMBRE_USUARIO_VISIBLE',pic:''},{av:'AV22Att_depto_usuario_Visible',fld:'vATT_DEPTO_USUARIO_VISIBLE',pic:''},{av:'AV23Att_correo_usuario_Visible',fld:'vATT_CORREO_USUARIO_VISIBLE',pic:''},{av:'AV24Att_detalle_infotecid_unidad_Visible',fld:'vATT_DETALLE_INFOTECID_UNIDAD_VISIBLE',pic:''},{av:'AV25Att_id_categoria_Visible',fld:'vATT_ID_CATEGORIA_VISIBLE',pic:''},{av:'AV26Att_id_actividad_Visible',fld:'vATT_ID_ACTIVIDAD_VISIBLE',pic:''},{av:'AV27Att_detalle_tarea_Visible',fld:'vATT_DETALLE_TAREA_VISIBLE',pic:''},{av:'AV28Att_prioridad_Visible',fld:'vATT_PRIORIDAD_VISIBLE',pic:''},{av:'AV29Att_observaciones_Visible',fld:'vATT_OBSERVACIONES_VISIBLE',pic:''},{av:'AV30Att_fecha_solicitud_Visible',fld:'vATT_FECHA_SOLICITUD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV57K2BToolsGenericSearchField = "";
         AV40nombre_emp = "";
         AV72fecha_registro_From = DateTime.MinValue;
         AV39ClassCollection = new GxSimpleCollection<string>();
         AV73fecha_registro_To = DateTime.MinValue;
         AV79Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV76Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV55FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV56DeletedTag = "";
         AV59GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblockfecha_registro_Jsonclick = "";
         ucFecha_registro_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A239nombre_emp = "";
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         AV65Update = "";
         AV66Delete = "";
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
         AV81Update_GXI = "";
         AV82Delete_GXI = "";
         scmdbuf = "";
         lV40nombre_emp = "";
         lV57K2BToolsGenericSearchField = "";
         H007V2_A254fecha_solicitud = new string[] {""} ;
         H007V2_n254fecha_solicitud = new bool[] {false} ;
         H007V2_A253observaciones = new string[] {""} ;
         H007V2_n253observaciones = new bool[] {false} ;
         H007V2_A252prioridad = new string[] {""} ;
         H007V2_n252prioridad = new bool[] {false} ;
         H007V2_A251detalle_tarea = new string[] {""} ;
         H007V2_n251detalle_tarea = new bool[] {false} ;
         H007V2_A250id_actividad = new int[1] ;
         H007V2_n250id_actividad = new bool[] {false} ;
         H007V2_A249id_categoria = new int[1] ;
         H007V2_n249id_categoria = new bool[] {false} ;
         H007V2_A248detalle_infotecid_unidad = new int[1] ;
         H007V2_n248detalle_infotecid_unidad = new bool[] {false} ;
         H007V2_A247correo_usuario = new string[] {""} ;
         H007V2_n247correo_usuario = new bool[] {false} ;
         H007V2_A246depto_usuario = new string[] {""} ;
         H007V2_n246depto_usuario = new bool[] {false} ;
         H007V2_A245nombre_usuario = new string[] {""} ;
         H007V2_n245nombre_usuario = new bool[] {false} ;
         H007V2_A244trabajo = new string[] {""} ;
         H007V2_n244trabajo = new bool[] {false} ;
         H007V2_A243estatus = new string[] {""} ;
         H007V2_n243estatus = new bool[] {false} ;
         H007V2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         H007V2_n241fecha_registro = new bool[] {false} ;
         H007V2_A240cargo_emp = new string[] {""} ;
         H007V2_n240cargo_emp = new bool[] {false} ;
         H007V2_A239nombre_emp = new string[] {""} ;
         H007V2_n239nombre_emp = new bool[] {false} ;
         H007V2_A238correlativo = new int[1] ;
         H007V3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV71fecha_registro = DateTime.MinValue;
         AV60GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV62Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV63Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV70ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV36GridStateKey = "";
         AV37GridState = new SdtK2BGridState(context);
         AV38GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV67TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV53K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV54K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV74OutFile = "";
         AV75Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_Jsonclick = "";
         bttInsert_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwdetalle_infotec__datastore1(),
            new Object[][] {
                new Object[] {
               H007V2_A254fecha_solicitud, H007V2_n254fecha_solicitud, H007V2_A253observaciones, H007V2_n253observaciones, H007V2_A252prioridad, H007V2_n252prioridad, H007V2_A251detalle_tarea, H007V2_n251detalle_tarea, H007V2_A250id_actividad, H007V2_n250id_actividad,
               H007V2_A249id_categoria, H007V2_n249id_categoria, H007V2_A248detalle_infotecid_unidad, H007V2_n248detalle_infotecid_unidad, H007V2_A247correo_usuario, H007V2_n247correo_usuario, H007V2_A246depto_usuario, H007V2_n246depto_usuario, H007V2_A245nombre_usuario, H007V2_n245nombre_usuario,
               H007V2_A244trabajo, H007V2_n244trabajo, H007V2_A243estatus, H007V2_n243estatus, H007V2_A241fecha_registro, H007V2_n241fecha_registro, H007V2_A240cargo_emp, H007V2_n240cargo_emp, H007V2_A239nombre_emp, H007V2_n239nombre_emp,
               H007V2_A238correlativo
               }
               , new Object[] {
               H007V3_AGRID_nRecordCount
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwdetalle_infotec__default(),
            new Object[][] {
            }
         );
         AV79Pgmname = "WWdetalle_infotec";
         /* GeneXus formulas. */
         AV79Pgmname = "WWdetalle_infotec";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV58OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV61UC_OrderedBy ;
      private short AV34RowsPerPageVariable ;
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
      private short AV33GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_216 ;
      private int nGXsfl_216_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavNombre_emp_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtcorrelativo_Visible ;
      private int edtnombre_emp_Visible ;
      private int edtcargo_emp_Visible ;
      private int edtfecha_registro_Visible ;
      private int edtestatus_Visible ;
      private int edttrabajo_Visible ;
      private int edtnombre_usuario_Visible ;
      private int edtdepto_usuario_Visible ;
      private int edtcorreo_usuario_Visible ;
      private int edtdetalle_infotecid_unidad_Visible ;
      private int edtid_categoria_Visible ;
      private int edtid_actividad_Visible ;
      private int edtdetalle_tarea_Visible ;
      private int edtprioridad_Visible ;
      private int edtobservaciones_Visible ;
      private int edtfecha_solicitud_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int A238correlativo ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
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
      private int AV80GXV1 ;
      private int AV83GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV84GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV85GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_216_idx="0001" ;
      private string AV57K2BToolsGenericSearchField ;
      private string AV79Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV56DeletedTag ;
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
      private string divK2btoolstable_attributecontainernombre_emp_Internalname ;
      private string edtavNombre_emp_Internalname ;
      private string divK2btoolstable_attributecontainerfecha_registro_Internalname ;
      private string lblTextblockfecha_registro_Internalname ;
      private string lblTextblockfecha_registro_Jsonclick ;
      private string Fecha_registro_daterangepicker_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtnombre_emp_Link ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Tooltiptext ;
      private string edtavDelete_Link ;
      private string edtavDelete_Tooltiptext ;
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
      private string edtcorrelativo_Internalname ;
      private string edtnombre_emp_Internalname ;
      private string edtcargo_emp_Internalname ;
      private string edtfecha_registro_Internalname ;
      private string edtestatus_Internalname ;
      private string edttrabajo_Internalname ;
      private string edtnombre_usuario_Internalname ;
      private string edtdepto_usuario_Internalname ;
      private string edtcorreo_usuario_Internalname ;
      private string edtdetalle_infotecid_unidad_Internalname ;
      private string edtid_categoria_Internalname ;
      private string edtid_actividad_Internalname ;
      private string edtdetalle_tarea_Internalname ;
      private string edtprioridad_Internalname ;
      private string edtobservaciones_Internalname ;
      private string edtfecha_solicitud_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV57K2BToolsGenericSearchField ;
      private string chkavAtt_correlativo_visible_Internalname ;
      private string chkavAtt_nombre_emp_visible_Internalname ;
      private string chkavAtt_cargo_emp_visible_Internalname ;
      private string chkavAtt_fecha_registro_visible_Internalname ;
      private string chkavAtt_estatus_visible_Internalname ;
      private string chkavAtt_trabajo_visible_Internalname ;
      private string chkavAtt_nombre_usuario_visible_Internalname ;
      private string chkavAtt_depto_usuario_visible_Internalname ;
      private string chkavAtt_correo_usuario_visible_Internalname ;
      private string chkavAtt_detalle_infotecid_unidad_visible_Internalname ;
      private string chkavAtt_id_categoria_visible_Internalname ;
      private string chkavAtt_id_actividad_visible_Internalname ;
      private string chkavAtt_detalle_tarea_visible_Internalname ;
      private string chkavAtt_prioridad_visible_Internalname ;
      private string chkavAtt_observaciones_visible_Internalname ;
      private string chkavAtt_fecha_solicitud_visible_Internalname ;
      private string chkavFreezecolumntitles_Internalname ;
      private string divDownloadactionstable_Internalname ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string bttReport_Tooltiptext ;
      private string bttReport_Internalname ;
      private string bttExport_Tooltiptext ;
      private string bttExport_Internalname ;
      private string bttInsert_Tooltiptext ;
      private string bttInsert_Internalname ;
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
      private string divCorrelativo_gridsettingscontainer_Internalname ;
      private string divNombre_emp_gridsettingscontainer_Internalname ;
      private string divCargo_emp_gridsettingscontainer_Internalname ;
      private string divFecha_registro_gridsettingscontainer_Internalname ;
      private string divEstatus_gridsettingscontainer_Internalname ;
      private string divTrabajo_gridsettingscontainer_Internalname ;
      private string divNombre_usuario_gridsettingscontainer_Internalname ;
      private string divDepto_usuario_gridsettingscontainer_Internalname ;
      private string divCorreo_usuario_gridsettingscontainer_Internalname ;
      private string divDetalle_infotecid_unidad_gridsettingscontainer_Internalname ;
      private string divId_categoria_gridsettingscontainer_Internalname ;
      private string divId_actividad_gridsettingscontainer_Internalname ;
      private string divDetalle_tarea_gridsettingscontainer_Internalname ;
      private string divPrioridad_gridsettingscontainer_Internalname ;
      private string divObservaciones_gridsettingscontainer_Internalname ;
      private string divFecha_solicitud_gridsettingscontainer_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string tblK2btableactionsrightcontainer_Internalname ;
      private string bttInsert_Jsonclick ;
      private string tblK2btabledownloadssectioncontainer_Internalname ;
      private string bttReport_Jsonclick ;
      private string bttExport_Jsonclick ;
      private string sGXsfl_216_fel_idx="0001" ;
      private string ROClassString ;
      private string edtcorrelativo_Jsonclick ;
      private string edtnombre_emp_Jsonclick ;
      private string edtcargo_emp_Jsonclick ;
      private string edtfecha_registro_Jsonclick ;
      private string edtestatus_Jsonclick ;
      private string edttrabajo_Jsonclick ;
      private string edtnombre_usuario_Jsonclick ;
      private string edtdepto_usuario_Jsonclick ;
      private string edtcorreo_usuario_Jsonclick ;
      private string edtdetalle_infotecid_unidad_Jsonclick ;
      private string edtid_categoria_Jsonclick ;
      private string edtid_actividad_Jsonclick ;
      private string edtdetalle_tarea_Jsonclick ;
      private string edtprioridad_Jsonclick ;
      private string edtobservaciones_Jsonclick ;
      private string edtfecha_solicitud_Jsonclick ;
      private DateTime GXt_dtime3 ;
      private DateTime AV72fecha_registro_From ;
      private DateTime AV73fecha_registro_To ;
      private DateTime A241fecha_registro ;
      private DateTime AV71fecha_registro ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV64nombre_emp_IsAuthorized ;
      private bool AV14Att_correlativo_Visible ;
      private bool AV15Att_nombre_emp_Visible ;
      private bool AV16Att_cargo_emp_Visible ;
      private bool AV17Att_fecha_registro_Visible ;
      private bool AV19Att_estatus_Visible ;
      private bool AV20Att_trabajo_Visible ;
      private bool AV21Att_nombre_usuario_Visible ;
      private bool AV22Att_depto_usuario_Visible ;
      private bool AV23Att_correo_usuario_Visible ;
      private bool AV24Att_detalle_infotecid_unidad_Visible ;
      private bool AV25Att_id_categoria_Visible ;
      private bool AV26Att_id_actividad_Visible ;
      private bool AV27Att_detalle_tarea_Visible ;
      private bool AV28Att_prioridad_Visible ;
      private bool AV29Att_observaciones_Visible ;
      private bool AV30Att_fecha_solicitud_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n239nombre_emp ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n243estatus ;
      private bool n244trabajo ;
      private bool n245nombre_usuario ;
      private bool n246depto_usuario ;
      private bool n247correo_usuario ;
      private bool n248detalle_infotecid_unidad ;
      private bool n249id_categoria ;
      private bool n250id_actividad ;
      private bool n251detalle_tarea ;
      private bool n252prioridad ;
      private bool n253observaciones ;
      private bool n254fecha_solicitud ;
      private bool bGXsfl_216_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV35RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV65Update_IsBlob ;
      private bool AV66Delete_IsBlob ;
      private string AV40nombre_emp ;
      private string AV76Uri ;
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
      private string AV81Update_GXI ;
      private string AV82Delete_GXI ;
      private string lV40nombre_emp ;
      private string AV36GridStateKey ;
      private string AV74OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV65Update ;
      private string AV66Delete ;
      private Guid AV75Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucFecha_registro_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_correlativo_visible ;
      private GXCheckbox chkavAtt_nombre_emp_visible ;
      private GXCheckbox chkavAtt_cargo_emp_visible ;
      private GXCheckbox chkavAtt_fecha_registro_visible ;
      private GXCheckbox chkavAtt_estatus_visible ;
      private GXCheckbox chkavAtt_trabajo_visible ;
      private GXCheckbox chkavAtt_nombre_usuario_visible ;
      private GXCheckbox chkavAtt_depto_usuario_visible ;
      private GXCheckbox chkavAtt_correo_usuario_visible ;
      private GXCheckbox chkavAtt_detalle_infotecid_unidad_visible ;
      private GXCheckbox chkavAtt_id_categoria_visible ;
      private GXCheckbox chkavAtt_id_actividad_visible ;
      private GXCheckbox chkavAtt_detalle_tarea_visible ;
      private GXCheckbox chkavAtt_prioridad_visible ;
      private GXCheckbox chkavAtt_observaciones_visible ;
      private GXCheckbox chkavAtt_fecha_solicitud_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] H007V2_A254fecha_solicitud ;
      private bool[] H007V2_n254fecha_solicitud ;
      private string[] H007V2_A253observaciones ;
      private bool[] H007V2_n253observaciones ;
      private string[] H007V2_A252prioridad ;
      private bool[] H007V2_n252prioridad ;
      private string[] H007V2_A251detalle_tarea ;
      private bool[] H007V2_n251detalle_tarea ;
      private int[] H007V2_A250id_actividad ;
      private bool[] H007V2_n250id_actividad ;
      private int[] H007V2_A249id_categoria ;
      private bool[] H007V2_n249id_categoria ;
      private int[] H007V2_A248detalle_infotecid_unidad ;
      private bool[] H007V2_n248detalle_infotecid_unidad ;
      private string[] H007V2_A247correo_usuario ;
      private bool[] H007V2_n247correo_usuario ;
      private string[] H007V2_A246depto_usuario ;
      private bool[] H007V2_n246depto_usuario ;
      private string[] H007V2_A245nombre_usuario ;
      private bool[] H007V2_n245nombre_usuario ;
      private string[] H007V2_A244trabajo ;
      private bool[] H007V2_n244trabajo ;
      private string[] H007V2_A243estatus ;
      private bool[] H007V2_n243estatus ;
      private DateTime[] H007V2_A241fecha_registro ;
      private bool[] H007V2_n241fecha_registro ;
      private string[] H007V2_A240cargo_emp ;
      private bool[] H007V2_n240cargo_emp ;
      private string[] H007V2_A239nombre_emp ;
      private bool[] H007V2_n239nombre_emp ;
      private int[] H007V2_A238correlativo ;
      private long[] H007V3_AGRID_nRecordCount ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV39ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV53K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV55FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV59GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV62Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV69ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV37GridState ;
      private SdtK2BGridState_FilterValue AV38GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV54K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV60GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV63Message ;
      private SdtK2BTrnContext AV67TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV70ActivityListItem ;
   }

   public class wwdetalle_infotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007V2( IGxContext context ,
                                             string AV40nombre_emp ,
                                             DateTime AV73fecha_registro_To ,
                                             DateTime AV72fecha_registro_From ,
                                             string AV57K2BToolsGenericSearchField ,
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
                                             short AV58OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[22];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [fecha_solicitud], [observaciones], [prioridad], [detalle_tarea], [id_actividad], [id_categoria], [id_unidad], [correo_usuario], [depto_usuario], [nombre_usuario], [trabajo], [estatus], [fecha_registro], [cargo_emp], [nombre_emp], [correlativo]";
         sFromString = " FROM dbo.[detalle_infotec]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40nombre_emp)) )
         {
            AddWhere(sWhereString, "([nombre_emp] like @lV40nombre_emp)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV73fecha_registro_To) )
         {
            AddWhere(sWhereString, "([fecha_registro] <= @AV73fecha_registro_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV72fecha_registro_From) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV72fecha_registro_From)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([correlativo] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or [nombre_emp] like '%' + @lV57K2BToolsGenericSearchField + '%' or [cargo_emp] like '%' + @lV57K2BToolsGenericSearchField + '%' or [estatus] like '%' + @lV57K2BToolsGenericSearchField + '%' or [trabajo] like '%' + @lV57K2BToolsGenericSearchField + '%' or [nombre_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or [depto_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or [correo_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_categoria] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_actividad] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or [detalle_tarea] like '%' + @lV57K2BToolsGenericSearchField + '%' or [prioridad] like '%' + @lV57K2BToolsGenericSearchField + '%' or [observaciones] like '%' + @lV57K2BToolsGenericSearchField + '%' or [fecha_solicitud] like '%' + @lV57K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
         }
         if ( AV58OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [correlativo]";
         }
         else if ( AV58OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [correlativo] DESC";
         }
         else if ( AV58OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [nombre_emp]";
         }
         else if ( AV58OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [nombre_emp] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [correlativo]";
         }
         scmdbuf = "SELECT * FROM (SELECT " + sSelectString + ", ROW_NUMBER() OVER (" + sOrderString + " ) AS GX_ROW_NUMBER" + sFromString + sWhereString + "" + ") AS GX_CTE WHERE GX_ROW_NUMBER" + " >= " + "@GXPagingFrom2" + " AND GX_ROW_NUMBER <= (CASE WHEN (" + "@GXPagingTo2" + " < " + "@GXPagingFrom2" + ") THEN CAST(0x7FFFFFFFFFFFFFFF AS bigint) ELSE " + "@GXPagingTo2" + " END)";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H007V3( IGxContext context ,
                                             string AV40nombre_emp ,
                                             DateTime AV73fecha_registro_To ,
                                             DateTime AV72fecha_registro_From ,
                                             string AV57K2BToolsGenericSearchField ,
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
                                             short AV58OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[detalle_infotec]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40nombre_emp)) )
         {
            AddWhere(sWhereString, "([nombre_emp] like @lV40nombre_emp)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV73fecha_registro_To) )
         {
            AddWhere(sWhereString, "([fecha_registro] <= @AV73fecha_registro_To)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV72fecha_registro_From) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV72fecha_registro_From)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([correlativo] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or [nombre_emp] like '%' + @lV57K2BToolsGenericSearchField + '%' or [cargo_emp] like '%' + @lV57K2BToolsGenericSearchField + '%' or [estatus] like '%' + @lV57K2BToolsGenericSearchField + '%' or [trabajo] like '%' + @lV57K2BToolsGenericSearchField + '%' or [nombre_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or [depto_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or [correo_usuario] like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_categoria] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_actividad] AS decimal(9,0))) like '%' + @lV57K2BToolsGenericSearchField + '%' or [detalle_tarea] like '%' + @lV57K2BToolsGenericSearchField + '%' or [prioridad] like '%' + @lV57K2BToolsGenericSearchField + '%' or [observaciones] like '%' + @lV57K2BToolsGenericSearchField + '%' or [fecha_solicitud] like '%' + @lV57K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
            GXv_int7[16] = 1;
            GXv_int7[17] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV58OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV58OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV58OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV58OrderedBy == 3 )
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
                     return conditional_H007V2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] );
               case 1 :
                     return conditional_H007V3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] );
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
          Object[] prmH007V2;
          prmH007V2 = new Object[] {
          new ParDef("@lV40nombre_emp",GXType.NVarChar,300,0) ,
          new ParDef("@AV73fecha_registro_To",GXType.Date,8,0) ,
          new ParDef("@AV72fecha_registro_From",GXType.Date,8,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007V3;
          prmH007V3 = new Object[] {
          new ParDef("@lV40nombre_emp",GXType.NVarChar,300,0) ,
          new ParDef("@AV73fecha_registro_To",GXType.Date,8,0) ,
          new ParDef("@AV72fecha_registro_From",GXType.Date,8,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV57K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007V3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
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

 public class wwdetalle_infotec__default : DataStoreHelperBase, IDataStoreHelper
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
