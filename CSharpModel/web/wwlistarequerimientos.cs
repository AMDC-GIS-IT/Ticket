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
   public class wwlistarequerimientos : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwlistarequerimientos( )
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

      public wwlistarequerimientos( IGxContext context )
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
         chkavAtt_listarequerimientosid_visible = new GXCheckbox();
         chkavAtt_listarequerimientosdescripcion_visible = new GXCheckbox();
         chkavAtt_areasatenciondescripcion_visible = new GXCheckbox();
         chkavAtt_listarequerimientosusuariosistema_visible = new GXCheckbox();
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
               nRC_GXsfl_145 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_145"), "."));
               nGXsfl_145_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_145_idx"), "."));
               sGXsfl_145_idx = GetPar( "sGXsfl_145_idx");
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
               AV31K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV25ListaRequerimientosDescripcion = GetPar( "ListaRequerimientosDescripcion");
               AV26AreasAtencionDescripcion = GetPar( "AreasAtencionDescripcion");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV24ClassCollection);
               AV32OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV51Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV47AutoLinksActivityList);
               AV41ListaRequerimientosDescripcion_IsAuthorized = StringUtil.StrToBool( GetPar( "ListaRequerimientosDescripcion_IsAuthorized"));
               AV14Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosId_Visible"));
               AV15Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosDescripcion_Visible"));
               AV16Att_AreasAtencionDescripcion_Visible = StringUtil.StrToBool( GetPar( "Att_AreasAtencionDescripcion_Visible"));
               AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosUsuarioSistema_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV38Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
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
            return "listarequerimientos_Execute" ;
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
         PA8D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188223683", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwlistarequerimientos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV31K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vLISTAREQUERIMIENTOSDESCRIPCION", AV25ListaRequerimientosDescripcion);
         GxWebStd.gx_hidden_field( context, "GXH_vAREASATENCIONDESCRIPCION", AV26AreasAtencionDescripcion);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_145", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_145), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV29FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV29FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV30DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV33GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV33GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV24ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV24ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUTOLINKSACTIVITYLIST", AV47AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUTOLINKSACTIVITYLIST", AV47AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED", AV41ListaRequerimientosDescripcion_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV38Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
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
            WE8D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8D2( ) ;
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
         return formatLink("wwlistarequerimientos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWListaRequerimientos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista requerimientoses" ;
      }

      protected void WB8D0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Lista requerimientoses", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_145_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV31K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV31K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWListaRequerimientos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWListaRequerimientos.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV29FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV30DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWListaRequerimientos.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavListarequerimientosdescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavListarequerimientosdescripcion_Internalname, "Descripción:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_145_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavListarequerimientosdescripcion_Internalname, AV25ListaRequerimientosDescripcion, StringUtil.RTrim( context.localUtil.Format( AV25ListaRequerimientosDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavListarequerimientosdescripcion_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavListarequerimientosdescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWListaRequerimientos.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavAreasatenciondescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAreasatenciondescripcion_Internalname, "Descripción: ", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_145_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAreasatenciondescripcion_Internalname, AV26AreasAtencionDescripcion, StringUtil.RTrim( context.localUtil.Format( AV26AreasAtencionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAreasatenciondescripcion_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavAreasatenciondescripcion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWListaRequerimientos.htm");
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
            wb_table1_53_8D2( true) ;
         }
         else
         {
            wb_table1_53_8D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_53_8D2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"145\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(38), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Descripción:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id: ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtAreasAtencionDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Descripción: ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosUsuarioSistema_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Registro:") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A370ListaRequerimientosDescripcion);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtListaRequerimientosDescripcion_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A366AreasAtencionId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A367AreasAtencionDescripcion);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAreasAtencionDescripcion_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAreasAtencionDescripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A371ListaRequerimientosUsuarioSistema);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV42Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV43Delete));
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
         if ( wbEnd == 145 )
         {
            wbEnd = 0;
            nRC_GXsfl_145 = (int)(nGXsfl_145_idx-1);
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
            wb_table2_155_8D2( true) ;
         }
         else
         {
            wb_table2_155_8D2( false) ;
         }
         return  ;
      }

      protected void wb_table2_155_8D2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV33GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV35UC_OrderedBy);
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
         if ( wbEnd == 145 )
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

      protected void START8D2( )
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
            Form.Meta.addItem("description", "Lista requerimientoses", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8D0( ) ;
      }

      protected void WS8D2( )
      {
         START8D2( ) ;
         EVT8D2( ) ;
      }

      protected void EVT8D2( )
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
                              E118D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E128D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E138D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E148D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E158D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E168D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E178D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E188D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E198D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E208D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E218D2 ();
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
                              nGXsfl_145_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_145_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_145_idx), 4, 0), 4, "0");
                              SubsflControlProps_1452( ) ;
                              A369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ","));
                              A370ListaRequerimientosDescripcion = cgiGet( edtListaRequerimientosDescripcion_Internalname);
                              A366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( edtAreasAtencionId_Internalname), ".", ","));
                              A367AreasAtencionDescripcion = cgiGet( edtAreasAtencionDescripcion_Internalname);
                              A371ListaRequerimientosUsuarioSistema = cgiGet( edtListaRequerimientosUsuarioSistema_Internalname);
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_145_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
                              AV43Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_145_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E228D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E238D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E248D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E258D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV31K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Listarequerimientosdescripcion Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTAREQUERIMIENTOSDESCRIPCION"), AV25ListaRequerimientosDescripcion) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Areasatenciondescripcion Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vAREASATENCIONDESCRIPCION"), AV26AreasAtencionDescripcion) != 0 )
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

      protected void WE8D2( )
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

      protected void PA8D2( )
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
         SubsflControlProps_1452( ) ;
         while ( nGXsfl_145_idx <= nRC_GXsfl_145 )
         {
            sendrow_1452( ) ;
            nGXsfl_145_idx = ((subGrid_Islastpage==1)&&(nGXsfl_145_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_145_idx+1);
            sGXsfl_145_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_145_idx), 4, 0), 4, "0");
            SubsflControlProps_1452( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV31K2BToolsGenericSearchField ,
                                       string AV25ListaRequerimientosDescripcion ,
                                       string AV26AreasAtencionDescripcion ,
                                       GxSimpleCollection<string> AV24ClassCollection ,
                                       short AV32OrderedBy ,
                                       string AV51Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV47AutoLinksActivityList ,
                                       bool AV41ListaRequerimientosDescripcion_IsAuthorized ,
                                       bool AV14Att_ListaRequerimientosId_Visible ,
                                       bool AV15Att_ListaRequerimientosDescripcion_Visible ,
                                       bool AV16Att_AreasAtencionDescripcion_Visible ,
                                       bool AV17Att_ListaRequerimientosUsuarioSistema_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV38Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E238D2 ();
         GRID_nCurrentRecord = 0;
         RF8D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_LISTAREQUERIMIENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LISTAREQUERIMIENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")));
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
         AV14Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_ListaRequerimientosId_Visible));
         AssignAttri("", false, "AV14Att_ListaRequerimientosId_Visible", AV14Att_ListaRequerimientosId_Visible);
         AV15Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_ListaRequerimientosDescripcion_Visible));
         AssignAttri("", false, "AV15Att_ListaRequerimientosDescripcion_Visible", AV15Att_ListaRequerimientosDescripcion_Visible);
         AV16Att_AreasAtencionDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_AreasAtencionDescripcion_Visible));
         AssignAttri("", false, "AV16Att_AreasAtencionDescripcion_Visible", AV16Att_AreasAtencionDescripcion_Visible);
         AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_ListaRequerimientosUsuarioSistema_Visible));
         AssignAttri("", false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV18GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E238D2 ();
         RF8D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV51Pgmname = "WWListaRequerimientos";
         context.Gx_err = 0;
      }

      protected void RF8D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 145;
         E248D2 ();
         nGXsfl_145_idx = 1;
         sGXsfl_145_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_145_idx), 4, 0), 4, "0");
         SubsflControlProps_1452( ) ;
         bGXsfl_145_Refreshing = true;
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
            SubsflControlProps_1452( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV25ListaRequerimientosDescripcion ,
                                                 AV26AreasAtencionDescripcion ,
                                                 AV31K2BToolsGenericSearchField ,
                                                 A370ListaRequerimientosDescripcion ,
                                                 A367AreasAtencionDescripcion ,
                                                 A369ListaRequerimientosId ,
                                                 A371ListaRequerimientosUsuarioSistema ,
                                                 AV32OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV25ListaRequerimientosDescripcion = StringUtil.Concat( StringUtil.RTrim( AV25ListaRequerimientosDescripcion), "%", "");
            lV26AreasAtencionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV26AreasAtencionDescripcion), "%", "");
            lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
            lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
            lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
            lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H008D2 */
            pr_default.execute(0, new Object[] {lV25ListaRequerimientosDescripcion, lV26AreasAtencionDescripcion, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_145_idx = 1;
            sGXsfl_145_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_145_idx), 4, 0), 4, "0");
            SubsflControlProps_1452( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A371ListaRequerimientosUsuarioSistema = H008D2_A371ListaRequerimientosUsuarioSistema[0];
               A367AreasAtencionDescripcion = H008D2_A367AreasAtencionDescripcion[0];
               A366AreasAtencionId = H008D2_A366AreasAtencionId[0];
               A370ListaRequerimientosDescripcion = H008D2_A370ListaRequerimientosDescripcion[0];
               A369ListaRequerimientosId = H008D2_A369ListaRequerimientosId[0];
               A367AreasAtencionDescripcion = H008D2_A367AreasAtencionDescripcion[0];
               E258D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 145;
            WB8D0( ) ;
         }
         bGXsfl_145_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_LISTAREQUERIMIENTOSID"+"_"+sGXsfl_145_idx, GetSecureSignedToken( sGXsfl_145_idx, context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV38Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38Uri, "")), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV25ListaRequerimientosDescripcion ,
                                              AV26AreasAtencionDescripcion ,
                                              AV31K2BToolsGenericSearchField ,
                                              A370ListaRequerimientosDescripcion ,
                                              A367AreasAtencionDescripcion ,
                                              A369ListaRequerimientosId ,
                                              A371ListaRequerimientosUsuarioSistema ,
                                              AV32OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV25ListaRequerimientosDescripcion = StringUtil.Concat( StringUtil.RTrim( AV25ListaRequerimientosDescripcion), "%", "");
         lV26AreasAtencionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV26AreasAtencionDescripcion), "%", "");
         lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
         lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
         lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
         lV31K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV31K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H008D3 */
         pr_default.execute(1, new Object[] {lV25ListaRequerimientosDescripcion, lV26AreasAtencionDescripcion, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField, lV31K2BToolsGenericSearchField});
         GRID_nRecordCount = H008D3_AGRID_nRecordCount[0];
         pr_default.close(1);
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
            gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV51Pgmname = "WWListaRequerimientos";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E228D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV29FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV33GridOrders);
            /* Read saved values. */
            nRC_GXsfl_145 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_145"), ".", ","));
            AV30DeletedTag = cgiGet( "vDELETEDTAG");
            AV35UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV32OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV31K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV31K2BToolsGenericSearchField", AV31K2BToolsGenericSearchField);
            AV25ListaRequerimientosDescripcion = cgiGet( edtavListarequerimientosdescripcion_Internalname);
            AssignAttri("", false, "AV25ListaRequerimientosDescripcion", AV25ListaRequerimientosDescripcion);
            AV26AreasAtencionDescripcion = cgiGet( edtavAreasatenciondescripcion_Internalname);
            AssignAttri("", false, "AV26AreasAtencionDescripcion", AV26AreasAtencionDescripcion);
            AV14Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosid_visible_Internalname));
            AssignAttri("", false, "AV14Att_ListaRequerimientosId_Visible", AV14Att_ListaRequerimientosId_Visible);
            AV15Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosdescripcion_visible_Internalname));
            AssignAttri("", false, "AV15Att_ListaRequerimientosDescripcion_Visible", AV15Att_ListaRequerimientosDescripcion_Visible);
            AV16Att_AreasAtencionDescripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_areasatenciondescripcion_visible_Internalname));
            AssignAttri("", false, "AV16Att_AreasAtencionDescripcion_Visible", AV16Att_AreasAtencionDescripcion_Visible);
            AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosusuariosistema_visible_Internalname));
            AssignAttri("", false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV18GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV31K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTAREQUERIMIENTOSDESCRIPCION"), AV25ListaRequerimientosDescripcion) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vAREASATENCIONDESCRIPCION"), AV26AreasAtencionDescripcion) != 0 )
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
         E228D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E228D2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV25ListaRequerimientosDescripcion = "";
         AssignAttri("", false, "AV25ListaRequerimientosDescripcion", AV25ListaRequerimientosDescripcion);
         AV26AreasAtencionDescripcion = "";
         AssignAttri("", false, "AV26AreasAtencionDescripcion", AV26AreasAtencionDescripcion);
         new k2bloadrowsperpage(context ).execute(  AV51Pgmname,  "Grid", out  AV19RowsPerPageVariable, out  AV20RowsPerPageLoaded) ;
         AssignAttri("", false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
         if ( ! AV20RowsPerPageLoaded )
         {
            AV19RowsPerPageVariable = 20;
            AssignAttri("", false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
         }
         AV18GridSettingsRowsPerPageVariable = AV19RowsPerPageVariable;
         AssignAttri("", false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV19RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Lista requerimientoses";
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
         AV33GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV34GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV34GridOrder.gxTpr_Ascendingorder = 0;
         AV34GridOrder.gxTpr_Descendingorder = 1;
         AV34GridOrder.gxTpr_Gridcolumnindex = 1;
         AV33GridOrders.Add(AV34GridOrder, 0);
         AV34GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV34GridOrder.gxTpr_Ascendingorder = 2;
         AV34GridOrder.gxTpr_Descendingorder = 3;
         AV34GridOrder.gxTpr_Gridcolumnindex = 2;
         AV33GridOrders.Add(AV34GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E238D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV39Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV39Messages = GXt_objcol_SdtMessages_Message1;
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV39Messages.Count )
         {
            AV40Message = ((GeneXus.Utils.SdtMessages_Message)AV39Messages.Item(AV52GXV1));
            GX_msglist.addItem(AV40Message.gxTpr_Description);
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV51Pgmname;
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV42Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         AV53Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_145_Refreshing);
         AV43Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         AV54Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_145_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV24ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV21GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV51Pgmname,  AV21GridStateKey, out  AV22GridState) ;
         AV32OrderedBy = AV22GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV32OrderedBy", StringUtil.LTrimStr( (decimal)(AV32OrderedBy), 4, 0));
         AV35UC_OrderedBy = AV22GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV35UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV35UC_OrderedBy), 4, 0));
         AV55GXV2 = 1;
         while ( AV55GXV2 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV55GXV2));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Filtername, "ListaRequerimientosDescripcion") == 0 )
            {
               AV25ListaRequerimientosDescripcion = AV23GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25ListaRequerimientosDescripcion", AV25ListaRequerimientosDescripcion);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Filtername, "AreasAtencionDescripcion") == 0 )
            {
               AV26AreasAtencionDescripcion = AV23GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26AreasAtencionDescripcion", AV26AreasAtencionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV31K2BToolsGenericSearchField = AV23GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31K2BToolsGenericSearchField", AV31K2BToolsGenericSearchField);
            }
            AV55GXV2 = (int)(AV55GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV22GridState.gxTpr_Currentpage > 0 ) && ( AV22GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV22GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV21GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV51Pgmname,  AV21GridStateKey, out  AV22GridState) ;
         AV22GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV22GridState.gxTpr_Orderedby = AV32OrderedBy;
         AV22GridState.gxTpr_Filtervalues.Clear();
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV23GridStateFilterValue.gxTpr_Filtername = "ListaRequerimientosDescripcion";
         AV23GridStateFilterValue.gxTpr_Value = AV25ListaRequerimientosDescripcion;
         AV22GridState.gxTpr_Filtervalues.Add(AV23GridStateFilterValue, 0);
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV23GridStateFilterValue.gxTpr_Filtername = "AreasAtencionDescripcion";
         AV23GridStateFilterValue.gxTpr_Value = AV26AreasAtencionDescripcion;
         AV22GridState.gxTpr_Filtervalues.Add(AV23GridStateFilterValue, 0);
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV23GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV23GridStateFilterValue.gxTpr_Value = AV31K2BToolsGenericSearchField;
         AV22GridState.gxTpr_Filtervalues.Add(AV23GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV51Pgmname,  AV21GridStateKey,  AV22GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV44TrnContext = new SdtK2BTrnContext(context);
         AV44TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV44TrnContext.gxTpr_Returnmode = "Stack";
         AV44TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV44TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV44TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "ListaRequerimientos",  AV44TrnContext) ;
      }

      protected void E138D2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "ListaRequerimientos",  "ListaRequerimientos",  "Insert",  "",  "EntityManagerListaRequerimientos") )
         {
            CallWebObject(formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtListaRequerimientosId_Visible = 1;
         AssignProp("", false, edtListaRequerimientosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Visible), 5, 0), !bGXsfl_145_Refreshing);
         AV14Att_ListaRequerimientosId_Visible = true;
         AssignAttri("", false, "AV14Att_ListaRequerimientosId_Visible", AV14Att_ListaRequerimientosId_Visible);
         edtListaRequerimientosDescripcion_Visible = 1;
         AssignProp("", false, edtListaRequerimientosDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0), !bGXsfl_145_Refreshing);
         AV15Att_ListaRequerimientosDescripcion_Visible = true;
         AssignAttri("", false, "AV15Att_ListaRequerimientosDescripcion_Visible", AV15Att_ListaRequerimientosDescripcion_Visible);
         edtAreasAtencionDescripcion_Visible = 1;
         AssignProp("", false, edtAreasAtencionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Visible), 5, 0), !bGXsfl_145_Refreshing);
         AV16Att_AreasAtencionDescripcion_Visible = true;
         AssignAttri("", false, "AV16Att_AreasAtencionDescripcion_Visible", AV16Att_AreasAtencionDescripcion_Visible);
         edtListaRequerimientosUsuarioSistema_Visible = 1;
         AssignProp("", false, edtListaRequerimientosUsuarioSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0), !bGXsfl_145_Refreshing);
         AV17Att_ListaRequerimientosUsuarioSistema_Visible = true;
         AssignAttri("", false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV51Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV56GXV3 = 1;
         while ( AV56GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV56GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
               {
                  edtListaRequerimientosId_Visible = 0;
                  AssignProp("", false, edtListaRequerimientosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Visible), 5, 0), !bGXsfl_145_Refreshing);
                  AV14Att_ListaRequerimientosId_Visible = false;
                  AssignAttri("", false, "AV14Att_ListaRequerimientosId_Visible", AV14Att_ListaRequerimientosId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
               {
                  edtListaRequerimientosDescripcion_Visible = 0;
                  AssignProp("", false, edtListaRequerimientosDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0), !bGXsfl_145_Refreshing);
                  AV15Att_ListaRequerimientosDescripcion_Visible = false;
                  AssignAttri("", false, "AV15Att_ListaRequerimientosDescripcion_Visible", AV15Att_ListaRequerimientosDescripcion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "AreasAtencionDescripcion") == 0 )
               {
                  edtAreasAtencionDescripcion_Visible = 0;
                  AssignProp("", false, edtAreasAtencionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Visible), 5, 0), !bGXsfl_145_Refreshing);
                  AV16Att_AreasAtencionDescripcion_Visible = false;
                  AssignAttri("", false, "AV16Att_AreasAtencionDescripcion_Visible", AV16Att_AreasAtencionDescripcion_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
               {
                  edtListaRequerimientosUsuarioSistema_Visible = 0;
                  AssignProp("", false, edtListaRequerimientosUsuarioSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0), !bGXsfl_145_Refreshing);
                  AV17Att_ListaRequerimientosUsuarioSistema_Visible = false;
                  AssignAttri("", false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
               }
            }
            AV56GXV3 = (int)(AV56GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ListaRequerimientosId";
         AV13GridColumn.gxTpr_Columntitle = "";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ListaRequerimientosDescripcion";
         AV13GridColumn.gxTpr_Columntitle = "Descripción:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "AreasAtencionDescripcion";
         AV13GridColumn.gxTpr_Columntitle = "Descripción: ";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ListaRequerimientosUsuarioSistema";
         AV13GridColumn.gxTpr_Columntitle = "Registro:";
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
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         AV41ListaRequerimientosDescripcion_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV41ListaRequerimientosDescripcion_IsAuthorized", AV41ListaRequerimientosDescripcion_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_145_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_145_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_145_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_145_Refreshing);
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

      protected void E248D2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV24ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV42Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         AV53Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_145_Refreshing);
         AV43Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         AV54Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_145_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_145_Refreshing);
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
         AV47AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "AreasAtencion";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "AreasAtencion";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerAreasAtencion";
         AV47AutoLinksActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV47AutoLinksActivityList) ;
         AV35UC_OrderedBy = AV32OrderedBy;
         AssignAttri("", false, "AV35UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV35UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV24ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47AutoLinksActivityList", AV47AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29FilterTags", AV29FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E258D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV47AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
         }
         if ( AV41ListaRequerimientosDescripcion_IsAuthorized )
         {
            edtListaRequerimientosDescripcion_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         }
         else
         {
            edtListaRequerimientosDescripcion_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 145;
         }
         sendrow_1452( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_145_Refreshing )
         {
            context.DoAjaxLoad(145, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV27K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ListaRequerimientosDescripcion)) )
         {
            AV28K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV28K2BFilterValuesSDTItem.gxTpr_Name = "ListaRequerimientosDescripcion";
            AV28K2BFilterValuesSDTItem.gxTpr_Description = "Descripción:";
            AV28K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV28K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV28K2BFilterValuesSDTItem.gxTpr_Value = AV25ListaRequerimientosDescripcion;
            AV28K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV25ListaRequerimientosDescripcion;
            AV27K2BFilterValuesSDT.Add(AV28K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AreasAtencionDescripcion)) )
         {
            AV28K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV28K2BFilterValuesSDTItem.gxTpr_Name = "AreasAtencionDescripcion";
            AV28K2BFilterValuesSDTItem.gxTpr_Description = "Descripción: ";
            AV28K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV28K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV28K2BFilterValuesSDTItem.gxTpr_Value = AV26AreasAtencionDescripcion;
            AV28K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV26AreasAtencionDescripcion;
            AV27K2BFilterValuesSDT.Add(AV28K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV27K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV29FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV51Pgmname,  "Grid",  AV27K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV29FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E118D2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30DeletedTag, "ListaRequerimientosDescripcion") == 0 )
         {
            AV25ListaRequerimientosDescripcion = "";
            AssignAttri("", false, "AV25ListaRequerimientosDescripcion", AV25ListaRequerimientosDescripcion);
         }
         else if ( StringUtil.StrCmp(AV30DeletedTag, "AreasAtencionDescripcion") == 0 )
         {
            AV26AreasAtencionDescripcion = "";
            AssignAttri("", false, "AV26AreasAtencionDescripcion", AV26AreasAtencionDescripcion);
         }
         gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E128D2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV32OrderedBy = AV35UC_OrderedBy;
         AssignAttri("", false, "AV32OrderedBy", StringUtil.LTrimStr( (decimal)(AV32OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E148D2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV51Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV57GXV4 = 1;
         while ( AV57GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV57GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_ListaRequerimientosId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_ListaRequerimientosDescripcion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "AreasAtencionDescripcion") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_AreasAtencionDescripcion_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_ListaRequerimientosUsuarioSistema_Visible;
            }
            AV57GXV4 = (int)(AV57GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV51Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV35UC_OrderedBy = AV32OrderedBy;
         AssignAttri("", false, "AV35UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV35UC_OrderedBy), 4, 0));
         if ( AV19RowsPerPageVariable != AV18GridSettingsRowsPerPageVariable )
         {
            AV19RowsPerPageVariable = AV18GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV19RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV51Pgmname,  "Grid",  AV19RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV31K2BToolsGenericSearchField, AV25ListaRequerimientosDescripcion, AV26AreasAtencionDescripcion, AV24ClassCollection, AV32OrderedBy, AV51Pgmname, AV8CurrentPage, AV10GridConfiguration, AV47AutoLinksActivityList, AV41ListaRequerimientosDescripcion_IsAuthorized, AV14Att_ListaRequerimientosId_Visible, AV15Att_ListaRequerimientosDescripcion_Visible, AV16Att_AreasAtencionDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV11FreezeColumnTitles, AV38Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
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

      protected void E158D2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E168D2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E178D2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E188D2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ClassCollection", AV24ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV51Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV24ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV24ClassCollection) ;
         }
      }

      protected void E198D2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "ListaRequerimientos",  "ListaRequerimientos",  "List",  "",  "ExportWWListaRequerimientos") )
         {
            new exportwwlistarequerimientos(context ).execute(  AV25ListaRequerimientosDescripcion,  AV26AreasAtencionDescripcion,  AV31K2BToolsGenericSearchField,  AV32OrderedBy, out  AV36OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV36OutFile, out  AV38Uri) )
            {
               CallWebObject(formatLink(AV38Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV37Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV37Guid.ToString(),  AV36OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV37Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E208D2( )
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

      protected void E218D2( )
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

      protected void wb_table2_155_8D2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_155_8D2e( true) ;
         }
         else
         {
            wb_table2_155_8D2e( false) ;
         }
      }

      protected void wb_table1_53_8D2( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e268d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWListaRequerimientos.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWListaRequerimientos.htm");
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
            GxWebStd.gx_div_start( context, divListarequerimientosid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosid_visible_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_145_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosid_visible_Internalname, StringUtil.BoolToStr( AV14Att_ListaRequerimientosId_Visible), "", "", 1, chkavAtt_listarequerimientosid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_div_start( context, divListarequerimientosdescripcion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosdescripcion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_listarequerimientosdescripcion_visible_Internalname, "Descripción:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_145_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosdescripcion_visible_Internalname, StringUtil.BoolToStr( AV15Att_ListaRequerimientosDescripcion_Visible), "", "Descripción:", 1, chkavAtt_listarequerimientosdescripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
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
            GxWebStd.gx_div_start( context, divAreasatenciondescripcion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_areasatenciondescripcion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_areasatenciondescripcion_visible_Internalname, "Descripción: ", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_145_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_areasatenciondescripcion_visible_Internalname, StringUtil.BoolToStr( AV16Att_AreasAtencionDescripcion_Visible), "", "Descripción: ", 1, chkavAtt_areasatenciondescripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
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
            GxWebStd.gx_div_start( context, divListarequerimientosusuariosistema_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosusuariosistema_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, "Registro:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_145_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, StringUtil.BoolToStr( AV17Att_ListaRequerimientosUsuarioSistema_Visible), "", "Registro:", 1, chkavAtt_listarequerimientosusuariosistema_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_145_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 1, "HLP_WWListaRequerimientos.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_145_idx + "',0)\"";
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
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(145), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWListaRequerimientos.htm");
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
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e278d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWListaRequerimientos.htm");
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
            wb_table3_126_8D2( true) ;
         }
         else
         {
            wb_table3_126_8D2( false) ;
         }
         return  ;
      }

      protected void wb_table3_126_8D2e( bool wbgen )
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
            wb_table4_133_8D2( true) ;
         }
         else
         {
            wb_table4_133_8D2( false) ;
         }
         return  ;
      }

      protected void wb_table4_133_8D2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_53_8D2e( true) ;
         }
         else
         {
            wb_table1_53_8D2e( false) ;
         }
      }

      protected void wb_table4_133_8D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(145), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWListaRequerimientos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_133_8D2e( true) ;
         }
         else
         {
            wb_table4_133_8D2e( false) ;
         }
      }

      protected void wb_table3_126_8D2( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(145), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e288d1_client"+"'", TempTags, "", 2, "HLP_WWListaRequerimientos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(145), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWListaRequerimientos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_126_8D2e( true) ;
         }
         else
         {
            wb_table3_126_8D2e( false) ;
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
         PA8D2( ) ;
         WS8D2( ) ;
         WE8D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418822429", true, true);
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
         context.AddJavascriptSource("wwlistarequerimientos.js", "?202418822429", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1452( )
      {
         edtListaRequerimientosId_Internalname = "LISTAREQUERIMIENTOSID_"+sGXsfl_145_idx;
         edtListaRequerimientosDescripcion_Internalname = "LISTAREQUERIMIENTOSDESCRIPCION_"+sGXsfl_145_idx;
         edtAreasAtencionId_Internalname = "AREASATENCIONID_"+sGXsfl_145_idx;
         edtAreasAtencionDescripcion_Internalname = "AREASATENCIONDESCRIPCION_"+sGXsfl_145_idx;
         edtListaRequerimientosUsuarioSistema_Internalname = "LISTAREQUERIMIENTOSUSUARIOSISTEMA_"+sGXsfl_145_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_145_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_145_idx;
      }

      protected void SubsflControlProps_fel_1452( )
      {
         edtListaRequerimientosId_Internalname = "LISTAREQUERIMIENTOSID_"+sGXsfl_145_fel_idx;
         edtListaRequerimientosDescripcion_Internalname = "LISTAREQUERIMIENTOSDESCRIPCION_"+sGXsfl_145_fel_idx;
         edtAreasAtencionId_Internalname = "AREASATENCIONID_"+sGXsfl_145_fel_idx;
         edtAreasAtencionDescripcion_Internalname = "AREASATENCIONDESCRIPCION_"+sGXsfl_145_fel_idx;
         edtListaRequerimientosUsuarioSistema_Internalname = "LISTAREQUERIMIENTOSUSUARIOSISTEMA_"+sGXsfl_145_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_145_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_145_fel_idx;
      }

      protected void sendrow_1452( )
      {
         SubsflControlProps_1452( ) ;
         WB8D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_145_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_145_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_145_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtListaRequerimientosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaRequerimientosId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtListaRequerimientosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)38,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)145,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtListaRequerimientosDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosDescripcion_Internalname,(string)A370ListaRequerimientosDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtListaRequerimientosDescripcion_Link,(string)"",(string)"",(string)"",(string)edtListaRequerimientosDescripcion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtListaRequerimientosDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)145,(short)1,(short)-1,(short)-1,(bool)true,(string)"TextoCorto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAreasAtencionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A366AreasAtencionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A366AreasAtencionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAreasAtencionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)145,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtAreasAtencionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAreasAtencionDescripcion_Internalname,(string)A367AreasAtencionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAreasAtencionDescripcion_Link,(string)"",(string)"",(string)"",(string)edtAreasAtencionDescripcion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtAreasAtencionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)145,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtListaRequerimientosUsuarioSistema_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosUsuarioSistema_Internalname,(string)A371ListaRequerimientosUsuarioSistema,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaRequerimientosUsuarioSistema_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtListaRequerimientosUsuarioSistema_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)145,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV42Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV42Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV53Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV53Update_GXI : context.PathToRelativeUrl( AV42Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV42Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV43Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV54Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV54Delete_GXI : context.PathToRelativeUrl( AV43Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV43Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes8D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_145_idx = ((subGrid_Islastpage==1)&&(nGXsfl_145_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_145_idx+1);
            sGXsfl_145_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_145_idx), 4, 0), 4, "0");
            SubsflControlProps_1452( ) ;
         }
         /* End function sendrow_1452 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_listarequerimientosid_visible.Name = "vATT_LISTAREQUERIMIENTOSID_VISIBLE";
         chkavAtt_listarequerimientosid_visible.WebTags = "";
         chkavAtt_listarequerimientosid_visible.Caption = "";
         AssignProp("", false, chkavAtt_listarequerimientosid_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosid_visible.Caption, true);
         chkavAtt_listarequerimientosid_visible.CheckedValue = "false";
         AV14Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_ListaRequerimientosId_Visible));
         AssignAttri("", false, "AV14Att_ListaRequerimientosId_Visible", AV14Att_ListaRequerimientosId_Visible);
         chkavAtt_listarequerimientosdescripcion_visible.Name = "vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE";
         chkavAtt_listarequerimientosdescripcion_visible.WebTags = "";
         chkavAtt_listarequerimientosdescripcion_visible.Caption = "";
         AssignProp("", false, chkavAtt_listarequerimientosdescripcion_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosdescripcion_visible.Caption, true);
         chkavAtt_listarequerimientosdescripcion_visible.CheckedValue = "false";
         AV15Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_ListaRequerimientosDescripcion_Visible));
         AssignAttri("", false, "AV15Att_ListaRequerimientosDescripcion_Visible", AV15Att_ListaRequerimientosDescripcion_Visible);
         chkavAtt_areasatenciondescripcion_visible.Name = "vATT_AREASATENCIONDESCRIPCION_VISIBLE";
         chkavAtt_areasatenciondescripcion_visible.WebTags = "";
         chkavAtt_areasatenciondescripcion_visible.Caption = "";
         AssignProp("", false, chkavAtt_areasatenciondescripcion_visible_Internalname, "TitleCaption", chkavAtt_areasatenciondescripcion_visible.Caption, true);
         chkavAtt_areasatenciondescripcion_visible.CheckedValue = "false";
         AV16Att_AreasAtencionDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_AreasAtencionDescripcion_Visible));
         AssignAttri("", false, "AV16Att_AreasAtencionDescripcion_Visible", AV16Att_AreasAtencionDescripcion_Visible);
         chkavAtt_listarequerimientosusuariosistema_visible.Name = "vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE";
         chkavAtt_listarequerimientosusuariosistema_visible.WebTags = "";
         chkavAtt_listarequerimientosusuariosistema_visible.Caption = "";
         AssignProp("", false, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosusuariosistema_visible.Caption, true);
         chkavAtt_listarequerimientosusuariosistema_visible.CheckedValue = "false";
         AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_ListaRequerimientosUsuarioSistema_Visible));
         AssignAttri("", false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV18GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
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
         edtavListarequerimientosdescripcion_Internalname = "vLISTAREQUERIMIENTOSDESCRIPCION";
         divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERLISTAREQUERIMIENTOSDESCRIPCION";
         edtavAreasatenciondescripcion_Internalname = "vAREASATENCIONDESCRIPCION";
         divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONDESCRIPCION";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_listarequerimientosid_visible_Internalname = "vATT_LISTAREQUERIMIENTOSID_VISIBLE";
         divListarequerimientosid_gridsettingscontainer_Internalname = "LISTAREQUERIMIENTOSID_GRIDSETTINGSCONTAINER";
         chkavAtt_listarequerimientosdescripcion_visible_Internalname = "vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE";
         divListarequerimientosdescripcion_gridsettingscontainer_Internalname = "LISTAREQUERIMIENTOSDESCRIPCION_GRIDSETTINGSCONTAINER";
         chkavAtt_areasatenciondescripcion_visible_Internalname = "vATT_AREASATENCIONDESCRIPCION_VISIBLE";
         divAreasatenciondescripcion_gridsettingscontainer_Internalname = "AREASATENCIONDESCRIPCION_GRIDSETTINGSCONTAINER";
         chkavAtt_listarequerimientosusuariosistema_visible_Internalname = "vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE";
         divListarequerimientosusuariosistema_gridsettingscontainer_Internalname = "LISTAREQUERIMIENTOSUSUARIOSISTEMA_GRIDSETTINGSCONTAINER";
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
         edtListaRequerimientosId_Internalname = "LISTAREQUERIMIENTOSID";
         edtListaRequerimientosDescripcion_Internalname = "LISTAREQUERIMIENTOSDESCRIPCION";
         edtAreasAtencionId_Internalname = "AREASATENCIONID";
         edtAreasAtencionDescripcion_Internalname = "AREASATENCIONDESCRIPCION";
         edtListaRequerimientosUsuarioSistema_Internalname = "LISTAREQUERIMIENTOSUSUARIOSISTEMA";
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
         chkavAtt_listarequerimientosusuariosistema_visible.Caption = "Registro:";
         chkavAtt_areasatenciondescripcion_visible.Caption = "Descripción: ";
         chkavAtt_listarequerimientosdescripcion_visible.Caption = "Descripción:";
         chkavAtt_listarequerimientosid_visible.Caption = "";
         edtListaRequerimientosUsuarioSistema_Jsonclick = "";
         edtAreasAtencionDescripcion_Jsonclick = "";
         edtAreasAtencionId_Jsonclick = "";
         edtListaRequerimientosDescripcion_Jsonclick = "";
         edtListaRequerimientosId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_listarequerimientosusuariosistema_visible.Enabled = 1;
         chkavAtt_areasatenciondescripcion_visible.Enabled = 1;
         chkavAtt_listarequerimientosdescripcion_visible.Enabled = 1;
         chkavAtt_listarequerimientosid_visible.Enabled = 1;
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
         edtAreasAtencionDescripcion_Link = "";
         edtListaRequerimientosDescripcion_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtListaRequerimientosUsuarioSistema_Visible = -1;
         edtAreasAtencionDescripcion_Visible = -1;
         edtListaRequerimientosDescripcion_Visible = -1;
         edtListaRequerimientosId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavAreasatenciondescripcion_Jsonclick = "";
         edtavAreasatenciondescripcion_Enabled = 1;
         edtavListarequerimientosdescripcion_Jsonclick = "";
         edtavListarequerimientosdescripcion_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Lista requerimientoses";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E138D2',iparms:[{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9',hsh:true},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E288D1',iparms:[{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E248D2',iparms:[{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV29FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E258D2',iparms:[{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A366AreasAtencionId',fld:'AREASATENCIONID',pic:'ZZZ9'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9',hsh:true},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Link',ctrl:'AREASATENCIONDESCRIPCION',prop:'Link'},{av:'edtListaRequerimientosDescripcion_Link',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E118D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV30DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E128D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV35UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E268D1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E148D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV19RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV18GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV35UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV19RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E158D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E168D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E178D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E188D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtAreasAtencionDescripcion_Visible',ctrl:'AREASATENCIONDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E198D2',iparms:[{av:'AV25ListaRequerimientosDescripcion',fld:'vLISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV26AreasAtencionDescripcion',fld:'vAREASATENCIONDESCRIPCION',pic:''},{av:'AV31K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV32OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV38Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E208D2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E218D2',iparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E278D1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_AREASATENCIONID","{handler:'Valid_Areasatencionid',iparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_AREASATENCIONID",",oparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV15Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV16Att_AreasAtencionDescripcion_Visible',fld:'vATT_AREASATENCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV31K2BToolsGenericSearchField = "";
         AV25ListaRequerimientosDescripcion = "";
         AV26AreasAtencionDescripcion = "";
         AV24ClassCollection = new GxSimpleCollection<string>();
         AV51Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV47AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV38Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV29FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV30DeletedTag = "";
         AV33GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A370ListaRequerimientosDescripcion = "";
         A367AreasAtencionDescripcion = "";
         A371ListaRequerimientosUsuarioSistema = "";
         AV42Update = "";
         AV43Delete = "";
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
         AV53Update_GXI = "";
         AV54Delete_GXI = "";
         scmdbuf = "";
         lV25ListaRequerimientosDescripcion = "";
         lV26AreasAtencionDescripcion = "";
         lV31K2BToolsGenericSearchField = "";
         H008D2_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         H008D2_A367AreasAtencionDescripcion = new string[] {""} ;
         H008D2_A366AreasAtencionId = new short[1] ;
         H008D2_A370ListaRequerimientosDescripcion = new string[] {""} ;
         H008D2_A369ListaRequerimientosId = new short[1] ;
         H008D3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV34GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV39Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV40Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV21GridStateKey = "";
         AV22GridState = new SdtK2BGridState(context);
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV44TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV27K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV28K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV36OutFile = "";
         AV37Guid = (Guid)(Guid.Empty);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwlistarequerimientos__default(),
            new Object[][] {
                new Object[] {
               H008D2_A371ListaRequerimientosUsuarioSistema, H008D2_A367AreasAtencionDescripcion, H008D2_A366AreasAtencionId, H008D2_A370ListaRequerimientosDescripcion, H008D2_A369ListaRequerimientosId
               }
               , new Object[] {
               H008D3_AGRID_nRecordCount
               }
            }
         );
         AV51Pgmname = "WWListaRequerimientos";
         /* GeneXus formulas. */
         AV51Pgmname = "WWListaRequerimientos";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV32OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV35UC_OrderedBy ;
      private short AV19RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A369ListaRequerimientosId ;
      private short A366AreasAtencionId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV18GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_145 ;
      private int nGXsfl_145_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavListarequerimientosdescripcion_Enabled ;
      private int edtavAreasatenciondescripcion_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtListaRequerimientosId_Visible ;
      private int edtListaRequerimientosDescripcion_Visible ;
      private int edtAreasAtencionDescripcion_Visible ;
      private int edtListaRequerimientosUsuarioSistema_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
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
      private int AV52GXV1 ;
      private int AV55GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV56GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV57GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_145_idx="0001" ;
      private string AV31K2BToolsGenericSearchField ;
      private string AV51Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV30DeletedTag ;
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
      private string divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname ;
      private string edtavListarequerimientosdescripcion_Internalname ;
      private string edtavListarequerimientosdescripcion_Jsonclick ;
      private string divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname ;
      private string edtavAreasatenciondescripcion_Internalname ;
      private string edtavAreasatenciondescripcion_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtListaRequerimientosDescripcion_Link ;
      private string edtAreasAtencionDescripcion_Link ;
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
      private string edtListaRequerimientosId_Internalname ;
      private string edtListaRequerimientosDescripcion_Internalname ;
      private string edtAreasAtencionId_Internalname ;
      private string edtAreasAtencionDescripcion_Internalname ;
      private string edtListaRequerimientosUsuarioSistema_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV31K2BToolsGenericSearchField ;
      private string chkavAtt_listarequerimientosid_visible_Internalname ;
      private string chkavAtt_listarequerimientosdescripcion_visible_Internalname ;
      private string chkavAtt_areasatenciondescripcion_visible_Internalname ;
      private string chkavAtt_listarequerimientosusuariosistema_visible_Internalname ;
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
      private string divListarequerimientosid_gridsettingscontainer_Internalname ;
      private string divListarequerimientosdescripcion_gridsettingscontainer_Internalname ;
      private string divAreasatenciondescripcion_gridsettingscontainer_Internalname ;
      private string divListarequerimientosusuariosistema_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_145_fel_idx="0001" ;
      private string ROClassString ;
      private string edtListaRequerimientosId_Jsonclick ;
      private string edtListaRequerimientosDescripcion_Jsonclick ;
      private string edtAreasAtencionId_Jsonclick ;
      private string edtAreasAtencionDescripcion_Jsonclick ;
      private string edtListaRequerimientosUsuarioSistema_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV41ListaRequerimientosDescripcion_IsAuthorized ;
      private bool AV14Att_ListaRequerimientosId_Visible ;
      private bool AV15Att_ListaRequerimientosDescripcion_Visible ;
      private bool AV16Att_AreasAtencionDescripcion_Visible ;
      private bool AV17Att_ListaRequerimientosUsuarioSistema_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_145_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV20RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV42Update_IsBlob ;
      private bool AV43Delete_IsBlob ;
      private string AV25ListaRequerimientosDescripcion ;
      private string AV26AreasAtencionDescripcion ;
      private string AV38Uri ;
      private string A370ListaRequerimientosDescripcion ;
      private string A367AreasAtencionDescripcion ;
      private string A371ListaRequerimientosUsuarioSistema ;
      private string AV53Update_GXI ;
      private string AV54Delete_GXI ;
      private string lV25ListaRequerimientosDescripcion ;
      private string lV26AreasAtencionDescripcion ;
      private string AV21GridStateKey ;
      private string AV36OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV42Update ;
      private string AV43Delete ;
      private Guid AV37Guid ;
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
      private GXCheckbox chkavAtt_listarequerimientosid_visible ;
      private GXCheckbox chkavAtt_listarequerimientosdescripcion_visible ;
      private GXCheckbox chkavAtt_areasatenciondescripcion_visible ;
      private GXCheckbox chkavAtt_listarequerimientosusuariosistema_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H008D2_A371ListaRequerimientosUsuarioSistema ;
      private string[] H008D2_A367AreasAtencionDescripcion ;
      private short[] H008D2_A366AreasAtencionId ;
      private string[] H008D2_A370ListaRequerimientosDescripcion ;
      private short[] H008D2_A369ListaRequerimientosId ;
      private long[] H008D3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV24ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV27K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV29FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV33GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV39Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV47AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV46ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV22GridState ;
      private SdtK2BGridState_FilterValue AV23GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV28K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV34GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV40Message ;
      private SdtK2BTrnContext AV44TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV48ActivityListItem ;
   }

   public class wwlistarequerimientos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008D2( IGxContext context ,
                                             string AV25ListaRequerimientosDescripcion ,
                                             string AV26AreasAtencionDescripcion ,
                                             string AV31K2BToolsGenericSearchField ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A367AreasAtencionDescripcion ,
                                             short A369ListaRequerimientosId ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV32OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ListaRequerimientosUsuarioSistema], T2.[AreasAtencionDescripcion], T1.[AreasAtencionId], T1.[ListaRequerimientosDescripcion], T1.[ListaRequerimientosId]";
         sFromString = " FROM ([ListaRequerimientos] T1 INNER JOIN [AreasAtencion] T2 ON T2.[AreasAtencionId] = T1.[AreasAtencionId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ListaRequerimientosDescripcion)) )
         {
            AddWhere(sWhereString, "(T1.[ListaRequerimientosDescripcion] like @lV25ListaRequerimientosDescripcion)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AreasAtencionDescripcion)) )
         {
            AddWhere(sWhereString, "(T2.[AreasAtencionDescripcion] like @lV26AreasAtencionDescripcion)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST(T1.[ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV31K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosDescripcion] like '%' + @lV31K2BToolsGenericSearchField + '%' or T2.[AreasAtencionDescripcion] like '%' + @lV31K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosUsuarioSistema] like '%' + @lV31K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         if ( AV32OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[ListaRequerimientosId]";
         }
         else if ( AV32OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[ListaRequerimientosId] DESC";
         }
         else if ( AV32OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[ListaRequerimientosDescripcion]";
         }
         else if ( AV32OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[ListaRequerimientosDescripcion] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ListaRequerimientosId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H008D3( IGxContext context ,
                                             string AV25ListaRequerimientosDescripcion ,
                                             string AV26AreasAtencionDescripcion ,
                                             string AV31K2BToolsGenericSearchField ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A367AreasAtencionDescripcion ,
                                             short A369ListaRequerimientosId ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV32OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([ListaRequerimientos] T1 INNER JOIN [AreasAtencion] T2 ON T2.[AreasAtencionId] = T1.[AreasAtencionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ListaRequerimientosDescripcion)) )
         {
            AddWhere(sWhereString, "(T1.[ListaRequerimientosDescripcion] like @lV25ListaRequerimientosDescripcion)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AreasAtencionDescripcion)) )
         {
            AddWhere(sWhereString, "(T2.[AreasAtencionDescripcion] like @lV26AreasAtencionDescripcion)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST(T1.[ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV31K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosDescripcion] like '%' + @lV31K2BToolsGenericSearchField + '%' or T2.[AreasAtencionDescripcion] like '%' + @lV31K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosUsuarioSistema] like '%' + @lV31K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV32OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV32OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV32OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV32OrderedBy == 3 )
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
                     return conditional_H008D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] );
               case 1 :
                     return conditional_H008D3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmH008D2;
          prmH008D2 = new Object[] {
          new ParDef("@lV25ListaRequerimientosDescripcion",GXType.NVarChar,100,0) ,
          new ParDef("@lV26AreasAtencionDescripcion",GXType.NVarChar,30,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008D3;
          prmH008D3 = new Object[] {
          new ParDef("@lV25ListaRequerimientosDescripcion",GXType.NVarChar,100,0) ,
          new ParDef("@lV26AreasAtencionDescripcion",GXType.NVarChar,30,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV31K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
