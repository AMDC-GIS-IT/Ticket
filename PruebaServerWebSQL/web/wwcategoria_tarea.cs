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
   public class wwcategoria_tarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwcategoria_tarea( )
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

      public wwcategoria_tarea( IGxContext context )
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
         chkavAtt_categoria_tareaid_tipo_categoria_visible = new GXCheckbox();
         chkavAtt_id_unidad_gis_visible = new GXCheckbox();
         chkavAtt_nombre_categoria_visible = new GXCheckbox();
         chkavAtt_categoria_tareaestado_visible = new GXCheckbox();
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
               nRC_GXsfl_140 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_140"), "."));
               nGXsfl_140_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_140_idx"), "."));
               sGXsfl_140_idx = GetPar( "sGXsfl_140_idx");
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
               AV42K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV31id_unidad_gis = (int)(NumberUtil.Val( GetPar( "id_unidad_gis"), "."));
               AV56flnombre = GetPar( "flnombre");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV30ClassCollection);
               AV43OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV59Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV49id_unidad_gis_IsAuthorized = StringUtil.StrToBool( GetPar( "id_unidad_gis_IsAuthorized"));
               AV14Att_categoria_tareaid_tipo_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_categoria_tareaid_tipo_categoria_Visible"));
               AV15Att_id_unidad_gis_Visible = StringUtil.StrToBool( GetPar( "Att_id_unidad_gis_Visible"));
               AV16Att_nombre_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_categoria_Visible"));
               AV17Att_categoria_tareaestado_Visible = StringUtil.StrToBool( GetPar( "Att_categoria_tareaestado_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
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
            return "categoria_tarea_Execute" ;
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
         PA5A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5A2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20231249564221", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwcategoria_tarea.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV42K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vID_UNIDAD_GIS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31id_unidad_gis), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFLNOMBRE", AV56flnombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_140", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_140), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV40FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV40FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV41DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV44GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV44GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46UC_OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV30ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV30ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43OrderedBy), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vID_UNIDAD_GIS_ISAUTHORIZED", AV49id_unidad_gis_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25RowsPerPageVariable), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
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
            WE5A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5A2( ) ;
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
         return formatLink("wwcategoria_tarea.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWcategoria_tarea" ;
      }

      public override string GetPgmdesc( )
      {
         return "categoria_tareas" ;
      }

      protected void WB5A0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "categoria_tareas", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
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
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavK2btoolsgenericsearchfield_Internalname, "K2 BTools Generic Search Field", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV42K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV42K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWcategoria_tarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWcategoria_tarea.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV40FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV41DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWcategoria_tarea.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_unidad_gis_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavId_unidad_gis_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_unidad_gis_Internalname, "id_unidad_gis", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_140_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavId_unidad_gis_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31id_unidad_gis), 9, 0, ",", "")), ((edtavId_unidad_gis_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31id_unidad_gis), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV31id_unidad_gis), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_unidad_gis_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavId_unidad_gis_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWcategoria_tarea.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerflnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFlnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFlnombre_Internalname, "nombre_categoria", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFlnombre_Internalname, AV56flnombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtavFlnombre_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWcategoria_tarea.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_53_5A2( true) ;
         }
         else
         {
            wb_table1_53_5A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_53_5A2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"140\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(98), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtcategoria_tareaid_tipo_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_tipo_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_unidad_gis_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_unidad_gis") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "nombre_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtcategoria_tareaestado_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "estado") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtcategoria_tareaid_tipo_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A105id_unidad_gis), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtid_unidad_gis_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_unidad_gis_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A106nombre_categoria);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107categoria_tareaestado), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtcategoria_tareaestado_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            nRC_GXsfl_140 = (int)(nGXsfl_140_idx-1);
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
            wb_table2_147_5A2( true) ;
         }
         else
         {
            wb_table2_147_5A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_147_5A2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV44GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV46UC_OrderedBy);
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
         if ( wbEnd == 140 )
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

      protected void START5A2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
            }
            Form.Meta.addItem("description", "categoria_tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5A0( ) ;
      }

      protected void WS5A2( )
      {
         START5A2( ) ;
         EVT5A2( ) ;
      }

      protected void EVT5A2( )
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
                              E115A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E135A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E145A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E155A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E165A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E175A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E185A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E195A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E205A2 ();
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
                              nGXsfl_140_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
                              SubsflControlProps_1402( ) ;
                              A104categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaid_tipo_categoria_Internalname), ",", "."));
                              A105id_unidad_gis = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_gis_Internalname), ",", "."));
                              A106nombre_categoria = cgiGet( edtnombre_categoria_Internalname);
                              n106nombre_categoria = false;
                              A107categoria_tareaestado = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaestado_Internalname), ",", "."));
                              n107categoria_tareaestado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E215A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E225A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E235A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E245A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV42K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Id_unidad_gis Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vID_UNIDAD_GIS"), ",", ".") != Convert.ToDecimal( AV31id_unidad_gis )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Flnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFLNOMBRE"), AV56flnombre) != 0 )
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

      protected void WE5A2( )
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

      protected void PA5A2( )
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
         SubsflControlProps_1402( ) ;
         while ( nGXsfl_140_idx <= nRC_GXsfl_140 )
         {
            sendrow_1402( ) ;
            nGXsfl_140_idx = ((subGrid_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV42K2BToolsGenericSearchField ,
                                       int AV31id_unidad_gis ,
                                       string AV56flnombre ,
                                       GxSimpleCollection<string> AV30ClassCollection ,
                                       short AV43OrderedBy ,
                                       string AV59Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV49id_unidad_gis_IsAuthorized ,
                                       bool AV14Att_categoria_tareaid_tipo_categoria_Visible ,
                                       bool AV15Att_id_unidad_gis_Visible ,
                                       bool AV16Att_nombre_categoria_Visible ,
                                       bool AV17Att_categoria_tareaestado_Visible ,
                                       bool AV11FreezeColumnTitles )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E225A2 ();
         GRID_nCurrentRecord = 0;
         RF5A2( ) ;
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
         AV14Att_categoria_tareaid_tipo_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_categoria_tareaid_tipo_categoria_Visible));
         AssignAttri("", false, "AV14Att_categoria_tareaid_tipo_categoria_Visible", AV14Att_categoria_tareaid_tipo_categoria_Visible);
         AV15Att_id_unidad_gis_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_id_unidad_gis_Visible));
         AssignAttri("", false, "AV15Att_id_unidad_gis_Visible", AV15Att_id_unidad_gis_Visible);
         AV16Att_nombre_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_nombre_categoria_Visible));
         AssignAttri("", false, "AV16Att_nombre_categoria_Visible", AV16Att_nombre_categoria_Visible);
         AV17Att_categoria_tareaestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_categoria_tareaestado_Visible));
         AssignAttri("", false, "AV17Att_categoria_tareaestado_Visible", AV17Att_categoria_tareaestado_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E225A2 ();
         RF5A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV59Pgmname = "WWcategoria_tarea";
         context.Gx_err = 0;
      }

      protected void RF5A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 140;
         E235A2 ();
         nGXsfl_140_idx = 1;
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1402( ) ;
         bGXsfl_140_Refreshing = true;
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
            SubsflControlProps_1402( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV31id_unidad_gis ,
                                                 AV56flnombre ,
                                                 AV42K2BToolsGenericSearchField ,
                                                 A105id_unidad_gis ,
                                                 A106nombre_categoria ,
                                                 A104categoria_tareaid_tipo_categoria ,
                                                 A107categoria_tareaestado ,
                                                 AV43OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV56flnombre = StringUtil.Concat( StringUtil.RTrim( AV56flnombre), "%", "");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H005A2 */
            pr_datastore1.execute(0, new Object[] {AV31id_unidad_gis, lV56flnombre, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_140_idx = 1;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1402( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A107categoria_tareaestado = H005A2_A107categoria_tareaestado[0];
               n107categoria_tareaestado = H005A2_n107categoria_tareaestado[0];
               A106nombre_categoria = H005A2_A106nombre_categoria[0];
               n106nombre_categoria = H005A2_n106nombre_categoria[0];
               A105id_unidad_gis = H005A2_A105id_unidad_gis[0];
               A104categoria_tareaid_tipo_categoria = H005A2_A104categoria_tareaid_tipo_categoria[0];
               E245A2 ();
               pr_datastore1.readNext(0);
            }
            GRID_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 140;
            WB5A0( ) ;
         }
         bGXsfl_140_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
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
                                              AV31id_unidad_gis ,
                                              AV56flnombre ,
                                              AV42K2BToolsGenericSearchField ,
                                              A105id_unidad_gis ,
                                              A106nombre_categoria ,
                                              A104categoria_tareaid_tipo_categoria ,
                                              A107categoria_tareaestado ,
                                              AV43OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV56flnombre = StringUtil.Concat( StringUtil.RTrim( AV56flnombre), "%", "");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H005A3 */
         pr_datastore1.execute(1, new Object[] {AV31id_unidad_gis, lV56flnombre, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField});
         GRID_nRecordCount = H005A3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV59Pgmname = "WWcategoria_tarea";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E215A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV40FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV44GridOrders);
            /* Read saved values. */
            nRC_GXsfl_140 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), ",", "."));
            AV41DeletedTag = cgiGet( "vDELETEDTAG");
            AV46UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ",", "."));
            AV43OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ",", "."));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ",", "."));
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ",", "."));
            /* Read variables values. */
            AV42K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV42K2BToolsGenericSearchField", AV42K2BToolsGenericSearchField);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_unidad_gis_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_unidad_gis_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID_UNIDAD_GIS");
               GX_FocusControl = edtavId_unidad_gis_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31id_unidad_gis = 0;
               AssignAttri("", false, "AV31id_unidad_gis", StringUtil.LTrimStr( (decimal)(AV31id_unidad_gis), 9, 0));
            }
            else
            {
               AV31id_unidad_gis = (int)(context.localUtil.CToN( cgiGet( edtavId_unidad_gis_Internalname), ",", "."));
               AssignAttri("", false, "AV31id_unidad_gis", StringUtil.LTrimStr( (decimal)(AV31id_unidad_gis), 9, 0));
            }
            AV56flnombre = cgiGet( edtavFlnombre_Internalname);
            AssignAttri("", false, "AV56flnombre", AV56flnombre);
            AV14Att_categoria_tareaid_tipo_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname));
            AssignAttri("", false, "AV14Att_categoria_tareaid_tipo_categoria_Visible", AV14Att_categoria_tareaid_tipo_categoria_Visible);
            AV15Att_id_unidad_gis_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_unidad_gis_visible_Internalname));
            AssignAttri("", false, "AV15Att_id_unidad_gis_Visible", AV15Att_id_unidad_gis_Visible);
            AV16Att_nombre_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_categoria_visible_Internalname));
            AssignAttri("", false, "AV16Att_nombre_categoria_Visible", AV16Att_nombre_categoria_Visible);
            AV17Att_categoria_tareaestado_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_categoria_tareaestado_visible_Internalname));
            AssignAttri("", false, "AV17Att_categoria_tareaestado_Visible", AV17Att_categoria_tareaestado_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV42K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vID_UNIDAD_GIS"), ",", ".") != Convert.ToDecimal( AV31id_unidad_gis )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFLNOMBRE"), AV56flnombre) != 0 )
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
         E215A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215A2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV59Pgmname,  "Grid", out  AV25RowsPerPageVariable, out  AV26RowsPerPageLoaded) ;
         AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         if ( ! AV26RowsPerPageLoaded )
         {
            AV25RowsPerPageVariable = 20;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         }
         AV24GridSettingsRowsPerPageVariable = AV25RowsPerPageVariable;
         AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV25RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "categoria_tareas";
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
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45GridOrder.gxTpr_Ascendingorder = 0;
         AV45GridOrder.gxTpr_Descendingorder = 1;
         AV45GridOrder.gxTpr_Gridcolumnindex = 1;
         AV44GridOrders.Add(AV45GridOrder, 0);
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45GridOrder.gxTpr_Ascendingorder = 2;
         AV45GridOrder.gxTpr_Descendingorder = 3;
         AV45GridOrder.gxTpr_Gridcolumnindex = 2;
         AV44GridOrders.Add(AV45GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E225A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV47Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV47Messages = GXt_objcol_SdtMessages_Message1;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV47Messages.Count )
         {
            AV48Message = ((GeneXus.Utils.SdtMessages_Message)AV47Messages.Item(AV60GXV1));
            GX_msglist.addItem(AV48Message.gxTpr_Description);
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV59Pgmname;
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bscjoinstring(context ).execute(  AV30ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV43OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
         AV46UC_OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
         AV61GXV2 = 1;
         while ( AV61GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV61GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "id_unidad_gis") == 0 )
            {
               AV31id_unidad_gis = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31id_unidad_gis", StringUtil.LTrimStr( (decimal)(AV31id_unidad_gis), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "flnombre") == 0 )
            {
               AV56flnombre = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56flnombre", AV56flnombre);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV42K2BToolsGenericSearchField = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42K2BToolsGenericSearchField", AV42K2BToolsGenericSearchField);
            }
            AV61GXV2 = (int)(AV61GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV28GridState.gxTpr_Currentpage > 0 ) && ( AV28GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV28GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV28GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV28GridState.gxTpr_Orderedby = AV43OrderedBy;
         AV28GridState.gxTpr_Filtervalues.Clear();
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "id_unidad_gis";
         AV29GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV31id_unidad_gis), 9, 0);
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "flnombre";
         AV29GridStateFilterValue.gxTpr_Value = AV56flnombre;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV29GridStateFilterValue.gxTpr_Value = AV42K2BToolsGenericSearchField;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV59Pgmname,  AV27GridStateKey,  AV28GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV52TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV52TrnContext.gxTpr_Returnmode = "Stack";
         AV52TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV52TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV52TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "categoria_tarea",  AV52TrnContext) ;
      }

      protected void E135A2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         CallWebObject(formatLink("exportwwcategoria_tarea.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV31id_unidad_gis,9,0)),UrlEncode(StringUtil.RTrim(AV56flnombre)),UrlEncode(StringUtil.RTrim(AV42K2BToolsGenericSearchField)),UrlEncode(StringUtil.LTrimStr(AV43OrderedBy,4,0))}, new string[] {"id_unidad_gis","flnombre","K2BToolsGenericSearchField","OrderedBy"}) );
         context.wjLocDisableFrm = 2;
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtcategoria_tareaid_tipo_categoria_Visible = 1;
         AssignProp("", false, edtcategoria_tareaid_tipo_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaid_tipo_categoria_Visible), 5, 0), !bGXsfl_140_Refreshing);
         AV14Att_categoria_tareaid_tipo_categoria_Visible = true;
         AssignAttri("", false, "AV14Att_categoria_tareaid_tipo_categoria_Visible", AV14Att_categoria_tareaid_tipo_categoria_Visible);
         edtid_unidad_gis_Visible = 1;
         AssignProp("", false, edtid_unidad_gis_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_gis_Visible), 5, 0), !bGXsfl_140_Refreshing);
         AV15Att_id_unidad_gis_Visible = true;
         AssignAttri("", false, "AV15Att_id_unidad_gis_Visible", AV15Att_id_unidad_gis_Visible);
         edtnombre_categoria_Visible = 1;
         AssignProp("", false, edtnombre_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_categoria_Visible), 5, 0), !bGXsfl_140_Refreshing);
         AV16Att_nombre_categoria_Visible = true;
         AssignAttri("", false, "AV16Att_nombre_categoria_Visible", AV16Att_nombre_categoria_Visible);
         edtcategoria_tareaestado_Visible = 1;
         AssignProp("", false, edtcategoria_tareaestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaestado_Visible), 5, 0), !bGXsfl_140_Refreshing);
         AV17Att_categoria_tareaestado_Visible = true;
         AssignAttri("", false, "AV17Att_categoria_tareaestado_Visible", AV17Att_categoria_tareaestado_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV59Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV62GXV3 = 1;
         while ( AV62GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV62GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "categoria_tareaid_tipo_categoria") == 0 )
               {
                  edtcategoria_tareaid_tipo_categoria_Visible = 0;
                  AssignProp("", false, edtcategoria_tareaid_tipo_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaid_tipo_categoria_Visible), 5, 0), !bGXsfl_140_Refreshing);
                  AV14Att_categoria_tareaid_tipo_categoria_Visible = false;
                  AssignAttri("", false, "AV14Att_categoria_tareaid_tipo_categoria_Visible", AV14Att_categoria_tareaid_tipo_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad_gis") == 0 )
               {
                  edtid_unidad_gis_Visible = 0;
                  AssignProp("", false, edtid_unidad_gis_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_gis_Visible), 5, 0), !bGXsfl_140_Refreshing);
                  AV15Att_id_unidad_gis_Visible = false;
                  AssignAttri("", false, "AV15Att_id_unidad_gis_Visible", AV15Att_id_unidad_gis_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_categoria") == 0 )
               {
                  edtnombre_categoria_Visible = 0;
                  AssignProp("", false, edtnombre_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_categoria_Visible), 5, 0), !bGXsfl_140_Refreshing);
                  AV16Att_nombre_categoria_Visible = false;
                  AssignAttri("", false, "AV16Att_nombre_categoria_Visible", AV16Att_nombre_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "categoria_tareaestado") == 0 )
               {
                  edtcategoria_tareaestado_Visible = 0;
                  AssignProp("", false, edtcategoria_tareaestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaestado_Visible), 5, 0), !bGXsfl_140_Refreshing);
                  AV17Att_categoria_tareaestado_Visible = false;
                  AssignAttri("", false, "AV17Att_categoria_tareaestado_Visible", AV17Att_categoria_tareaestado_Visible);
               }
            }
            AV62GXV3 = (int)(AV62GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "categoria_tareaid_tipo_categoria";
         AV13GridColumn.gxTpr_Columntitle = "id_tipo_categoria";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_unidad_gis";
         AV13GridColumn.gxTpr_Columntitle = "id_unidad_gis";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_categoria";
         AV13GridColumn.gxTpr_Columntitle = "nombre_categoria";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "categoria_tareaestado";
         AV13GridColumn.gxTpr_Columntitle = "estado";
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
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWcategoria_tarea";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWcategoria_tarea";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(2)).gxTpr_Isauthorized )
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
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "categoria_tarea";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagercategoria_tarea";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         AV49id_unidad_gis_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV49id_unidad_gis_IsAuthorized", AV49id_unidad_gis_IsAuthorized);
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

      protected void E235A2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV30ClassCollection) ;
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
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV30ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40FilterTags", AV40FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E245A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV49id_unidad_gis_IsAuthorized )
         {
            edtid_unidad_gis_Link = formatLink("entitymanagercategoria_tarea.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","categoria_tareaid_tipo_categoria","TabCode"}) ;
         }
         else
         {
            edtid_unidad_gis_Link = "";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 140;
         }
         sendrow_1402( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_140_Refreshing )
         {
            context.DoAjaxLoad(140, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV38K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (0==AV31id_unidad_gis) )
         {
            AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV39K2BFilterValuesSDTItem.gxTpr_Name = "id_unidad_gis";
            AV39K2BFilterValuesSDTItem.gxTpr_Description = "id_unidad_gis";
            AV39K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV39K2BFilterValuesSDTItem.gxTpr_Value = StringUtil.Str( (decimal)(AV31id_unidad_gis), 9, 0);
            AV39K2BFilterValuesSDTItem.gxTpr_Valuedescription = StringUtil.Str( (decimal)(AV31id_unidad_gis), 9, 0);
            AV38K2BFilterValuesSDT.Add(AV39K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56flnombre)) )
         {
            AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV39K2BFilterValuesSDTItem.gxTpr_Name = "flnombre";
            AV39K2BFilterValuesSDTItem.gxTpr_Description = "nombre_categoria";
            AV39K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV39K2BFilterValuesSDTItem.gxTpr_Value = AV56flnombre;
            AV39K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV56flnombre;
            AV38K2BFilterValuesSDT.Add(AV39K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV38K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV40FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV59Pgmname,  "Grid",  AV38K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV40FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E115A2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41DeletedTag, "id_unidad_gis") == 0 )
         {
            AV31id_unidad_gis = 0;
            AssignAttri("", false, "AV31id_unidad_gis", StringUtil.LTrimStr( (decimal)(AV31id_unidad_gis), 9, 0));
         }
         else if ( StringUtil.StrCmp(AV41DeletedTag, "flnombre") == 0 )
         {
            AV56flnombre = "";
            AssignAttri("", false, "AV56flnombre", AV56flnombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E125A2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV43OrderedBy = AV46UC_OrderedBy;
         AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E145A2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV59Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV63GXV4 = 1;
         while ( AV63GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV63GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "categoria_tareaid_tipo_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_categoria_tareaid_tipo_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad_gis") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_id_unidad_gis_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_nombre_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "categoria_tareaestado") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_categoria_tareaestado_Visible;
            }
            AV63GXV4 = (int)(AV63GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV59Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
         if ( AV25RowsPerPageVariable != AV24GridSettingsRowsPerPageVariable )
         {
            AV25RowsPerPageVariable = AV24GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV25RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV59Pgmname,  "Grid",  AV25RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31id_unidad_gis, AV56flnombre, AV30ClassCollection, AV43OrderedBy, AV59Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49id_unidad_gis_IsAuthorized, AV14Att_categoria_tareaid_tipo_categoria_Visible, AV15Att_id_unidad_gis_Visible, AV16Att_nombre_categoria_Visible, AV17Att_categoria_tareaestado_Visible, AV11FreezeColumnTitles) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
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

      protected void E155A2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E165A2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E175A2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E185A2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV59Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV30ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV30ClassCollection) ;
         }
      }

      protected void E195A2( )
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

      protected void E205A2( )
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

      protected void wb_table2_147_5A2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_147_5A2e( true) ;
         }
         else
         {
            wb_table2_147_5A2e( false) ;
         }
      }

      protected void wb_table1_53_5A2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e255a1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWcategoria_tarea.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWcategoria_tarea.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareaid_tipo_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname, "id_tipo_categoria", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname, StringUtil.BoolToStr( AV14Att_categoria_tareaid_tipo_categoria_Visible), "", "id_tipo_categoria", 1, chkavAtt_categoria_tareaid_tipo_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_div_start( context, divId_unidad_gis_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_unidad_gis_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_unidad_gis_visible_Internalname, "id_unidad_gis", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_unidad_gis_visible_Internalname, StringUtil.BoolToStr( AV15Att_id_unidad_gis_Visible), "", "id_unidad_gis", 1, chkavAtt_id_unidad_gis_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
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
            GxWebStd.gx_div_start( context, divNombre_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_categoria_visible_Internalname, "nombre_categoria", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_categoria_visible_Internalname, StringUtil.BoolToStr( AV16Att_nombre_categoria_Visible), "", "nombre_categoria", 1, chkavAtt_nombre_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
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
            GxWebStd.gx_div_start( context, divCategoria_tareaestado_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_categoria_tareaestado_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_categoria_tareaestado_visible_Internalname, "estado", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_categoria_tareaestado_visible_Internalname, StringUtil.BoolToStr( AV17Att_categoria_tareaestado_Visible), "", "estado", 1, chkavAtt_categoria_tareaestado_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_140_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 1, "HLP_WWcategoria_tarea.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_140_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWcategoria_tarea.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e265a1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWcategoria_tarea.htm");
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
            wb_table3_126_5A2( true) ;
         }
         else
         {
            wb_table3_126_5A2( false) ;
         }
         return  ;
      }

      protected void wb_table3_126_5A2e( bool wbgen )
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
            wb_table1_53_5A2e( true) ;
         }
         else
         {
            wb_table1_53_5A2e( false) ;
         }
      }

      protected void wb_table3_126_5A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e275a1_client"+"'", TempTags, "", 2, "HLP_WWcategoria_tarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(140), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWcategoria_tarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_126_5A2e( true) ;
         }
         else
         {
            wb_table3_126_5A2e( false) ;
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
         PA5A2( ) ;
         WS5A2( ) ;
         WE5A2( ) ;
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
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249564541", true, true);
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
         context.AddJavascriptSource("wwcategoria_tarea.js", "?20231249564541", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1402( )
      {
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA_"+sGXsfl_140_idx;
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS_"+sGXsfl_140_idx;
         edtnombre_categoria_Internalname = "NOMBRE_CATEGORIA_"+sGXsfl_140_idx;
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO_"+sGXsfl_140_idx;
      }

      protected void SubsflControlProps_fel_1402( )
      {
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA_"+sGXsfl_140_fel_idx;
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS_"+sGXsfl_140_fel_idx;
         edtnombre_categoria_Internalname = "NOMBRE_CATEGORIA_"+sGXsfl_140_fel_idx;
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO_"+sGXsfl_140_fel_idx;
      }

      protected void sendrow_1402( )
      {
         SubsflControlProps_1402( ) ;
         WB5A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_140_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_140_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_140_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtcategoria_tareaid_tipo_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareaid_tipo_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareaid_tipo_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtcategoria_tareaid_tipo_categoria_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)98,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_unidad_gis_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_gis_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A105id_unidad_gis), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A105id_unidad_gis), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtid_unidad_gis_Link,(string)"",(string)"",(string)"",(string)edtid_unidad_gis_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtid_unidad_gis_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_categoria_Internalname,(string)A106nombre_categoria,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombre_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombre_categoria_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtcategoria_tareaestado_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareaestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A107categoria_tareaestado), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A107categoria_tareaestado), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareaestado_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtcategoria_tareaestado_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)140,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_140_idx = ((subGrid_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1402( ) ;
         }
         /* End function sendrow_1402 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_categoria_tareaid_tipo_categoria_visible.Name = "vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE";
         chkavAtt_categoria_tareaid_tipo_categoria_visible.WebTags = "";
         chkavAtt_categoria_tareaid_tipo_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname, "TitleCaption", chkavAtt_categoria_tareaid_tipo_categoria_visible.Caption, true);
         chkavAtt_categoria_tareaid_tipo_categoria_visible.CheckedValue = "false";
         AV14Att_categoria_tareaid_tipo_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_categoria_tareaid_tipo_categoria_Visible));
         AssignAttri("", false, "AV14Att_categoria_tareaid_tipo_categoria_Visible", AV14Att_categoria_tareaid_tipo_categoria_Visible);
         chkavAtt_id_unidad_gis_visible.Name = "vATT_ID_UNIDAD_GIS_VISIBLE";
         chkavAtt_id_unidad_gis_visible.WebTags = "";
         chkavAtt_id_unidad_gis_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_unidad_gis_visible_Internalname, "TitleCaption", chkavAtt_id_unidad_gis_visible.Caption, true);
         chkavAtt_id_unidad_gis_visible.CheckedValue = "false";
         AV15Att_id_unidad_gis_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_id_unidad_gis_Visible));
         AssignAttri("", false, "AV15Att_id_unidad_gis_Visible", AV15Att_id_unidad_gis_Visible);
         chkavAtt_nombre_categoria_visible.Name = "vATT_NOMBRE_CATEGORIA_VISIBLE";
         chkavAtt_nombre_categoria_visible.WebTags = "";
         chkavAtt_nombre_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_categoria_visible_Internalname, "TitleCaption", chkavAtt_nombre_categoria_visible.Caption, true);
         chkavAtt_nombre_categoria_visible.CheckedValue = "false";
         AV16Att_nombre_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_nombre_categoria_Visible));
         AssignAttri("", false, "AV16Att_nombre_categoria_Visible", AV16Att_nombre_categoria_Visible);
         chkavAtt_categoria_tareaestado_visible.Name = "vATT_CATEGORIA_TAREAESTADO_VISIBLE";
         chkavAtt_categoria_tareaestado_visible.WebTags = "";
         chkavAtt_categoria_tareaestado_visible.Caption = "";
         AssignProp("", false, chkavAtt_categoria_tareaestado_visible_Internalname, "TitleCaption", chkavAtt_categoria_tareaestado_visible.Caption, true);
         chkavAtt_categoria_tareaestado_visible.CheckedValue = "false";
         AV17Att_categoria_tareaestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_categoria_tareaestado_Visible));
         AssignAttri("", false, "AV17Att_categoria_tareaestado_Visible", AV17Att_categoria_tareaestado_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
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
         edtavId_unidad_gis_Internalname = "vID_UNIDAD_GIS";
         divK2btoolstable_attributecontainerid_unidad_gis_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERID_UNIDAD_GIS";
         edtavFlnombre_Internalname = "vFLNOMBRE";
         divK2btoolstable_attributecontainerflnombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERFLNOMBRE";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname = "vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE";
         divCategoria_tareaid_tipo_categoria_gridsettingscontainer_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_id_unidad_gis_visible_Internalname = "vATT_ID_UNIDAD_GIS_VISIBLE";
         divId_unidad_gis_gridsettingscontainer_Internalname = "ID_UNIDAD_GIS_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_categoria_visible_Internalname = "vATT_NOMBRE_CATEGORIA_VISIBLE";
         divNombre_categoria_gridsettingscontainer_Internalname = "NOMBRE_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_categoria_tareaestado_visible_Internalname = "vATT_CATEGORIA_TAREAESTADO_VISIBLE";
         divCategoria_tareaestado_gridsettingscontainer_Internalname = "CATEGORIA_TAREAESTADO_GRIDSETTINGSCONTAINER";
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
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA";
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS";
         edtnombre_categoria_Internalname = "NOMBRE_CATEGORIA";
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO";
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
         chkavAtt_categoria_tareaestado_visible.Caption = "estado";
         chkavAtt_nombre_categoria_visible.Caption = "nombre_categoria";
         chkavAtt_id_unidad_gis_visible.Caption = "id_unidad_gis";
         chkavAtt_categoria_tareaid_tipo_categoria_visible.Caption = "id_tipo_categoria";
         edtcategoria_tareaestado_Jsonclick = "";
         edtnombre_categoria_Jsonclick = "";
         edtid_unidad_gis_Jsonclick = "";
         edtcategoria_tareaid_tipo_categoria_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_categoria_tareaestado_visible.Enabled = 1;
         chkavAtt_nombre_categoria_visible.Enabled = 1;
         chkavAtt_id_unidad_gis_visible.Enabled = 1;
         chkavAtt_categoria_tareaid_tipo_categoria_visible.Enabled = 1;
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
         edtid_unidad_gis_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtcategoria_tareaestado_Visible = -1;
         edtnombre_categoria_Visible = -1;
         edtid_unidad_gis_Visible = -1;
         edtcategoria_tareaid_tipo_categoria_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavFlnombre_Enabled = 1;
         edtavId_unidad_gis_Jsonclick = "";
         edtavId_unidad_gis_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "categoria_tareas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E135A2',iparms:[{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E275A1',iparms:[{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E235A2',iparms:[{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV40FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E245A2',iparms:[{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'A104categoria_tareaid_tipo_categoria',fld:'CATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtid_unidad_gis_Link',ctrl:'ID_UNIDAD_GIS',prop:'Link'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E115A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV41DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E125A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E255A1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E145A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV24GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E155A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E165A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E175A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E185A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31id_unidad_gis',fld:'vID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV56flnombre',fld:'vFLNOMBRE',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV49id_unidad_gis_IsAuthorized',fld:'vID_UNIDAD_GIS_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtcategoria_tareaid_tipo_categoria_Visible',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtid_unidad_gis_Visible',ctrl:'ID_UNIDAD_GIS',prop:'Visible'},{av:'edtnombre_categoria_Visible',ctrl:'NOMBRE_CATEGORIA',prop:'Visible'},{av:'edtcategoria_tareaestado_Visible',ctrl:'CATEGORIA_TAREAESTADO',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E195A2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E205A2',iparms:[{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E265A1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Categoria_tareaestado',iparms:[{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_categoria_tareaid_tipo_categoria_Visible',fld:'vATT_CATEGORIA_TAREAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_id_unidad_gis_Visible',fld:'vATT_ID_UNIDAD_GIS_VISIBLE',pic:''},{av:'AV16Att_nombre_categoria_Visible',fld:'vATT_NOMBRE_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_categoria_tareaestado_Visible',fld:'vATT_CATEGORIA_TAREAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV42K2BToolsGenericSearchField = "";
         AV56flnombre = "";
         AV30ClassCollection = new GxSimpleCollection<string>();
         AV59Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         Filtersummarytagsuc_Emptystatemessage = "";
         K2borderbyusercontrol_Gridcontrolname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV40FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV41DeletedTag = "";
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A106nombre_categoria = "";
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
         lV56flnombre = "";
         lV42K2BToolsGenericSearchField = "";
         H005A2_A107categoria_tareaestado = new int[1] ;
         H005A2_n107categoria_tareaestado = new bool[] {false} ;
         H005A2_A106nombre_categoria = new string[] {""} ;
         H005A2_n106nombre_categoria = new bool[] {false} ;
         H005A2_A105id_unidad_gis = new int[1] ;
         H005A2_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005A3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV47Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV48Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV27GridStateKey = "";
         AV28GridState = new SdtK2BGridState(context);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV38K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
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
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwcategoria_tarea__datastore1(),
            new Object[][] {
                new Object[] {
               H005A2_A107categoria_tareaestado, H005A2_n107categoria_tareaestado, H005A2_A106nombre_categoria, H005A2_n106nombre_categoria, H005A2_A105id_unidad_gis, H005A2_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H005A3_AGRID_nRecordCount
               }
            }
         );
         AV59Pgmname = "WWcategoria_tarea";
         /* GeneXus formulas. */
         AV59Pgmname = "WWcategoria_tarea";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV46UC_OrderedBy ;
      private short AV25RowsPerPageVariable ;
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
      private short AV24GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_140 ;
      private int nGXsfl_140_idx=1 ;
      private int subGrid_Rows ;
      private int AV31id_unidad_gis ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavId_unidad_gis_Enabled ;
      private int edtavFlnombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtcategoria_tareaid_tipo_categoria_Visible ;
      private int edtid_unidad_gis_Visible ;
      private int edtnombre_categoria_Visible ;
      private int edtcategoria_tareaestado_Visible ;
      private int A104categoria_tareaid_tipo_categoria ;
      private int A105id_unidad_gis ;
      private int A107categoria_tareaestado ;
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
      private int AV60GXV1 ;
      private int AV61GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV62GXV3 ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV63GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_140_idx="0001" ;
      private string AV42K2BToolsGenericSearchField ;
      private string AV59Pgmname ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV41DeletedTag ;
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
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string TempTags ;
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
      private string divK2btoolstable_attributecontainerid_unidad_gis_Internalname ;
      private string edtavId_unidad_gis_Internalname ;
      private string edtavId_unidad_gis_Jsonclick ;
      private string divK2btoolstable_attributecontainerflnombre_Internalname ;
      private string edtavFlnombre_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtid_unidad_gis_Link ;
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
      private string edtcategoria_tareaid_tipo_categoria_Internalname ;
      private string edtid_unidad_gis_Internalname ;
      private string edtnombre_categoria_Internalname ;
      private string edtcategoria_tareaestado_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV42K2BToolsGenericSearchField ;
      private string chkavAtt_categoria_tareaid_tipo_categoria_visible_Internalname ;
      private string chkavAtt_id_unidad_gis_visible_Internalname ;
      private string chkavAtt_nombre_categoria_visible_Internalname ;
      private string chkavAtt_categoria_tareaestado_visible_Internalname ;
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
      private string divCategoria_tareaid_tipo_categoria_gridsettingscontainer_Internalname ;
      private string divId_unidad_gis_gridsettingscontainer_Internalname ;
      private string divNombre_categoria_gridsettingscontainer_Internalname ;
      private string divCategoria_tareaestado_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_140_fel_idx="0001" ;
      private string ROClassString ;
      private string edtcategoria_tareaid_tipo_categoria_Jsonclick ;
      private string edtid_unidad_gis_Jsonclick ;
      private string edtnombre_categoria_Jsonclick ;
      private string edtcategoria_tareaestado_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV49id_unidad_gis_IsAuthorized ;
      private bool AV14Att_categoria_tareaid_tipo_categoria_Visible ;
      private bool AV15Att_id_unidad_gis_Visible ;
      private bool AV16Att_nombre_categoria_Visible ;
      private bool AV17Att_categoria_tareaestado_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n106nombre_categoria ;
      private bool n107categoria_tareaestado ;
      private bool bGXsfl_140_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV26RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV56flnombre ;
      private string A106nombre_categoria ;
      private string lV56flnombre ;
      private string AV27GridStateKey ;
      private string imgFiltertoggle_combined_Bitmap ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_categoria_tareaid_tipo_categoria_visible ;
      private GXCheckbox chkavAtt_id_unidad_gis_visible ;
      private GXCheckbox chkavAtt_nombre_categoria_visible ;
      private GXCheckbox chkavAtt_categoria_tareaestado_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H005A2_A107categoria_tareaestado ;
      private bool[] H005A2_n107categoria_tareaestado ;
      private string[] H005A2_A106nombre_categoria ;
      private bool[] H005A2_n106nombre_categoria ;
      private int[] H005A2_A105id_unidad_gis ;
      private int[] H005A2_A104categoria_tareaid_tipo_categoria ;
      private long[] H005A3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV30ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV38K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV40FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV44GridOrders ;
      private GXBaseCollection<SdtMessages_Message> AV47Messages ;
      private GXBaseCollection<SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV54ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV28GridState ;
      private SdtK2BGridState_FilterValue AV29GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV39K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV45GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV48Message ;
      private SdtK2BTrnContext AV52TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV55ActivityListItem ;
   }

   public class wwcategoria_tarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005A2( IGxContext context ,
                                             int AV31id_unidad_gis ,
                                             string AV56flnombre ,
                                             string AV42K2BToolsGenericSearchField ,
                                             int A105id_unidad_gis ,
                                             string A106nombre_categoria ,
                                             int A104categoria_tareaid_tipo_categoria ,
                                             int A107categoria_tareaestado ,
                                             short AV43OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [estado], [nombre_categoria], [id_unidad_gis], [id_tipo_categoria]";
         sFromString = " FROM dbo.[categoria_tarea]";
         sOrderString = "";
         if ( ! (0==AV31id_unidad_gis) )
         {
            AddWhere(sWhereString, "([id_unidad_gis] = @AV31id_unidad_gis)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56flnombre)) )
         {
            AddWhere(sWhereString, "([nombre_categoria] like @lV56flnombre)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad_gis] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or [nombre_categoria] like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         if ( AV43OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [id_tipo_categoria]";
         }
         else if ( AV43OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [id_tipo_categoria] DESC";
         }
         else if ( AV43OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [id_unidad_gis]";
         }
         else if ( AV43OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [id_unidad_gis] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [id_tipo_categoria]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H005A3( IGxContext context ,
                                             int AV31id_unidad_gis ,
                                             string AV56flnombre ,
                                             string AV42K2BToolsGenericSearchField ,
                                             int A105id_unidad_gis ,
                                             string A106nombre_categoria ,
                                             int A104categoria_tareaid_tipo_categoria ,
                                             int A107categoria_tareaestado ,
                                             short AV43OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[categoria_tarea]";
         if ( ! (0==AV31id_unidad_gis) )
         {
            AddWhere(sWhereString, "([id_unidad_gis] = @AV31id_unidad_gis)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56flnombre)) )
         {
            AddWhere(sWhereString, "([nombre_categoria] like @lV56flnombre)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad_gis] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or [nombre_categoria] like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV43OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005A2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] );
               case 1 :
                     return conditional_H005A3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmH005A2;
          prmH005A2 = new Object[] {
          new ParDef("@AV31id_unidad_gis",GXType.Int32,9,0) ,
          new ParDef("@lV56flnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005A3;
          prmH005A3 = new Object[] {
          new ParDef("@AV31id_unidad_gis",GXType.Int32,9,0) ,
          new ParDef("@lV56flnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
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

}
