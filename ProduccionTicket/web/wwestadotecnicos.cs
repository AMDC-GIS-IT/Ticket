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
   public class wwestadotecnicos : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwestadotecnicos( )
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

      public wwestadotecnicos( IGxContext context )
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
         chkavAtt_estadotecnicosid_visible = new GXCheckbox();
         chkavAtt_estadotecnicosnombre_visible = new GXCheckbox();
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
               nRC_GXsfl_104 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_104"), "."));
               nGXsfl_104_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_104_idx"), "."));
               sGXsfl_104_idx = GetPar( "sGXsfl_104_idx");
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
               AV23K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV22ClassCollection);
               AV24OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               AV42Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV30EstadoTecnicosNombre_IsAuthorized = StringUtil.StrToBool( GetPar( "EstadoTecnicosNombre_IsAuthorized"));
               AV14Att_EstadoTecnicosId_Visible = StringUtil.StrToBool( GetPar( "Att_EstadoTecnicosId_Visible"));
               AV15Att_EstadoTecnicosNombre_Visible = StringUtil.StrToBool( GetPar( "Att_EstadoTecnicosNombre_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV39Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
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
            return "estadotecnicos_Execute" ;
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
         PA5R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188422454", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwestadotecnicos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV23K2BToolsGenericSearchField));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_104", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_104), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV25GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV25GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV22ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV22ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vESTADOTECNICOSNOMBRE_ISAUTHORIZED", AV30EstadoTecnicosNombre_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV39Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
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
            WE5R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5R2( ) ;
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
         return formatLink("wwestadotecnicos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWEstadoTecnicos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Estado técnicos" ;
      }

      protected void WB5R0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Estado técnicos", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV23K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV23K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWEstadoTecnicos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_24_5R2( true) ;
         }
         else
         {
            wb_table1_24_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_5R2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"104\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(38), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtEstadoTecnicosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtEstadoTecnicosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Técnicos") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192EstadoTecnicosId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTecnicosId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A193EstadoTecnicosNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadoTecnicosNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTecnicosNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV31Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV32Delete));
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
         if ( wbEnd == 104 )
         {
            wbEnd = 0;
            nRC_GXsfl_104 = (int)(nGXsfl_104_idx-1);
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
            wb_table2_111_5R2( true) ;
         }
         else
         {
            wb_table2_111_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_111_5R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV25GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV27UC_OrderedBy);
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
         if ( wbEnd == 104 )
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

      protected void START5R2( )
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
            Form.Meta.addItem("description", "Estado técnicos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5R0( ) ;
      }

      protected void WS5R2( )
      {
         START5R2( ) ;
         EVT5R2( ) ;
      }

      protected void EVT5R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E125R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E135R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E145R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E155R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E165R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E175R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E185R2 ();
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
                              nGXsfl_104_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
                              SubsflControlProps_1042( ) ;
                              A192EstadoTecnicosId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTecnicosId_Internalname), ".", ","));
                              A193EstadoTecnicosNombre = cgiGet( edtEstadoTecnicosNombre_Internalname);
                              AV31Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_104_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
                              AV32Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_104_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E205R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E215R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E225R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV23K2BToolsGenericSearchField) != 0 )
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

      protected void WE5R2( )
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

      protected void PA5R2( )
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
         SubsflControlProps_1042( ) ;
         while ( nGXsfl_104_idx <= nRC_GXsfl_104 )
         {
            sendrow_1042( ) ;
            nGXsfl_104_idx = ((subGrid_Islastpage==1)&&(nGXsfl_104_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV23K2BToolsGenericSearchField ,
                                       GxSimpleCollection<string> AV22ClassCollection ,
                                       short AV24OrderedBy ,
                                       int AV8CurrentPage ,
                                       string AV42Pgmname ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV30EstadoTecnicosNombre_IsAuthorized ,
                                       bool AV14Att_EstadoTecnicosId_Visible ,
                                       bool AV15Att_EstadoTecnicosNombre_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV39Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E205R2 ();
         GRID_nCurrentRecord = 0;
         RF5R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOTECNICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A192EstadoTecnicosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESTADOTECNICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192EstadoTecnicosId), 4, 0, ".", "")));
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
         AV14Att_EstadoTecnicosId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_EstadoTecnicosId_Visible));
         AssignAttri("", false, "AV14Att_EstadoTecnicosId_Visible", AV14Att_EstadoTecnicosId_Visible);
         AV15Att_EstadoTecnicosNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_EstadoTecnicosNombre_Visible));
         AssignAttri("", false, "AV15Att_EstadoTecnicosNombre_Visible", AV15Att_EstadoTecnicosNombre_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E205R2 ();
         RF5R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV42Pgmname = "WWEstadoTecnicos";
         context.Gx_err = 0;
      }

      protected void RF5R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 104;
         E215R2 ();
         nGXsfl_104_idx = 1;
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_1042( ) ;
         bGXsfl_104_Refreshing = true;
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
            SubsflControlProps_1042( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV23K2BToolsGenericSearchField ,
                                                 A192EstadoTecnicosId ,
                                                 A193EstadoTecnicosNombre ,
                                                 AV24OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H005R2 */
            pr_default.execute(0, new Object[] {lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_104_idx = 1;
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A193EstadoTecnicosNombre = H005R2_A193EstadoTecnicosNombre[0];
               A192EstadoTecnicosId = H005R2_A192EstadoTecnicosId[0];
               E225R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 104;
            WB5R0( ) ;
         }
         bGXsfl_104_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOTECNICOSID"+"_"+sGXsfl_104_idx, GetSecureSignedToken( sGXsfl_104_idx, context.localUtil.Format( (decimal)(A192EstadoTecnicosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV39Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39Uri, "")), context));
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
                                              AV23K2BToolsGenericSearchField ,
                                              A192EstadoTecnicosId ,
                                              A193EstadoTecnicosNombre ,
                                              AV24OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H005R3 */
         pr_default.execute(1, new Object[] {lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField});
         GRID_nRecordCount = H005R3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV42Pgmname = "WWEstadoTecnicos";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV25GridOrders);
            /* Read saved values. */
            nRC_GXsfl_104 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_104"), ".", ","));
            AV27UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV24OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            /* Read variables values. */
            AV23K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV23K2BToolsGenericSearchField", AV23K2BToolsGenericSearchField);
            AV14Att_EstadoTecnicosId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estadotecnicosid_visible_Internalname));
            AssignAttri("", false, "AV14Att_EstadoTecnicosId_Visible", AV14Att_EstadoTecnicosId_Visible);
            AV15Att_EstadoTecnicosNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estadotecnicosnombre_visible_Internalname));
            AssignAttri("", false, "AV15Att_EstadoTecnicosNombre_Visible", AV15Att_EstadoTecnicosNombre_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV23K2BToolsGenericSearchField) != 0 )
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
         E195R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV42Pgmname,  "Grid", out  AV17RowsPerPageVariable, out  AV18RowsPerPageLoaded) ;
         AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
         if ( ! AV18RowsPerPageLoaded )
         {
            AV17RowsPerPageVariable = 20;
            AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
         }
         AV16GridSettingsRowsPerPageVariable = AV17RowsPerPageVariable;
         AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV17RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Estado técnicos";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, "", false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV25GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV26GridOrder.gxTpr_Ascendingorder = 0;
         AV26GridOrder.gxTpr_Descendingorder = 1;
         AV26GridOrder.gxTpr_Gridcolumnindex = 1;
         AV25GridOrders.Add(AV26GridOrder, 0);
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV26GridOrder.gxTpr_Ascendingorder = 2;
         AV26GridOrder.gxTpr_Descendingorder = 3;
         AV26GridOrder.gxTpr_Gridcolumnindex = 2;
         AV25GridOrders.Add(AV26GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E205R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV28Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV28Messages = GXt_objcol_SdtMessages_Message1;
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV28Messages.Count )
         {
            AV29Message = ((GeneXus.Utils.SdtMessages_Message)AV28Messages.Item(AV43GXV1));
            GX_msglist.addItem(AV29Message.gxTpr_Description);
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV42Pgmname;
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
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
         AV31Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         AV44Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_104_Refreshing);
         AV32Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         AV45Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_104_Refreshing);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV22ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV42Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV24OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         AV27UC_OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
         AV46GXV2 = 1;
         while ( AV46GXV2 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV46GXV2));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV23K2BToolsGenericSearchField = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23K2BToolsGenericSearchField", AV23K2BToolsGenericSearchField);
            }
            AV46GXV2 = (int)(AV46GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV20GridState.gxTpr_Currentpage > 0 ) && ( AV20GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV20GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV42Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV20GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV20GridState.gxTpr_Orderedby = AV24OrderedBy;
         AV20GridState.gxTpr_Filtervalues.Clear();
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV21GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV21GridStateFilterValue.gxTpr_Value = AV23K2BToolsGenericSearchField;
         AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV42Pgmname,  AV19GridStateKey,  AV20GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV33TrnContext = new SdtK2BTrnContext(context);
         AV33TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV33TrnContext.gxTpr_Returnmode = "Stack";
         AV33TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV33TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV33TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "EstadoTecnicos",  AV33TrnContext) ;
      }

      protected void E125R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "EstadoTecnicos",  "EstadoTecnicos",  "Insert",  "",  "EntityManagerEstadoTecnicos") )
         {
            CallWebObject(formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtEstadoTecnicosId_Visible = 1;
         AssignProp("", false, edtEstadoTecnicosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTecnicosId_Visible), 5, 0), !bGXsfl_104_Refreshing);
         AV14Att_EstadoTecnicosId_Visible = true;
         AssignAttri("", false, "AV14Att_EstadoTecnicosId_Visible", AV14Att_EstadoTecnicosId_Visible);
         edtEstadoTecnicosNombre_Visible = 1;
         AssignProp("", false, edtEstadoTecnicosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTecnicosNombre_Visible), 5, 0), !bGXsfl_104_Refreshing);
         AV15Att_EstadoTecnicosNombre_Visible = true;
         AssignAttri("", false, "AV15Att_EstadoTecnicosNombre_Visible", AV15Att_EstadoTecnicosNombre_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV42Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV47GXV3 = 1;
         while ( AV47GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV47GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTecnicosId") == 0 )
               {
                  edtEstadoTecnicosId_Visible = 0;
                  AssignProp("", false, edtEstadoTecnicosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTecnicosId_Visible), 5, 0), !bGXsfl_104_Refreshing);
                  AV14Att_EstadoTecnicosId_Visible = false;
                  AssignAttri("", false, "AV14Att_EstadoTecnicosId_Visible", AV14Att_EstadoTecnicosId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTecnicosNombre") == 0 )
               {
                  edtEstadoTecnicosNombre_Visible = 0;
                  AssignProp("", false, edtEstadoTecnicosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTecnicosNombre_Visible), 5, 0), !bGXsfl_104_Refreshing);
                  AV15Att_EstadoTecnicosNombre_Visible = false;
                  AssignAttri("", false, "AV15Att_EstadoTecnicosNombre_Visible", AV15Att_EstadoTecnicosNombre_Visible);
               }
            }
            AV47GXV3 = (int)(AV47GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "EstadoTecnicosId";
         AV13GridColumn.gxTpr_Columntitle = "Id";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "EstadoTecnicosNombre";
         AV13GridColumn.gxTpr_Columntitle = "Técnicos";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV10GridConfiguration.gxTpr_Gridcolumns = AV12GridColumns;
      }

      protected void S132( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(3)).gxTpr_Isauthorized )
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

      protected void S212( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTecnicos";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         AV30EstadoTecnicosNombre_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV30EstadoTecnicosNombre_IsAuthorized", AV30EstadoTecnicosNombre_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_104_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_104_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_104_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_104_Refreshing);
         }
      }

      protected void S142( )
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

      protected void E215R2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV22ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV31Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         AV44Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_104_Refreshing);
         AV32Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         AV45Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_104_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_104_Refreshing);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV27UC_OrderedBy = AV24OrderedBy;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV22ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E225R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV30EstadoTecnicosNombre_IsAuthorized )
         {
            edtEstadoTecnicosNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A192EstadoTecnicosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
         }
         else
         {
            edtEstadoTecnicosNombre_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A192EstadoTecnicosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A192EstadoTecnicosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 104;
         }
         sendrow_1042( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_104_Refreshing )
         {
            context.DoAjaxLoad(104, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E115R2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV24OrderedBy = AV27UC_OrderedBy;
         AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E135R2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV42Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV48GXV4 = 1;
         while ( AV48GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV48GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTecnicosId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_EstadoTecnicosId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTecnicosNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_EstadoTecnicosNombre_Visible;
            }
            AV48GXV4 = (int)(AV48GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV42Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV27UC_OrderedBy = AV24OrderedBy;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
         if ( AV17RowsPerPageVariable != AV16GridSettingsRowsPerPageVariable )
         {
            AV17RowsPerPageVariable = AV16GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV17RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV42Pgmname,  "Grid",  AV17RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV42Pgmname, AV10GridConfiguration, AV30EstadoTecnicosNombre_IsAuthorized, AV14Att_EstadoTecnicosId_Visible, AV15Att_EstadoTecnicosNombre_Visible, AV11FreezeColumnTitles, AV39Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void S162( )
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

      protected void E145R2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV8CurrentPage = 1;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E155R2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV8CurrentPage > 1 )
         {
            AV8CurrentPage = (int)(AV8CurrentPage-1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E165R2( )
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E175R2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         AV8CurrentPage = AV9K2BMaxPages;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void S152( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV42Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S222( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11FreezeColumnTitles = AV10GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         if ( AV11FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV22ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV22ClassCollection) ;
         }
      }

      protected void E185R2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "EstadoTecnicos",  "EstadoTecnicos",  "List",  "",  "ExportWWEstadoTecnicos") )
         {
            new exportwwestadotecnicos(context ).execute(  AV23K2BToolsGenericSearchField,  AV24OrderedBy, out  AV37OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV37OutFile, out  AV39Uri) )
            {
               CallWebObject(formatLink(AV39Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV38Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV38Guid.ToString(),  AV37OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV38Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table2_111_5R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_111_5R2e( true) ;
         }
         else
         {
            wb_table2_111_5R2e( false) ;
         }
      }

      protected void wb_table1_24_5R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e235r1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWEstadoTecnicos.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWEstadoTecnicos.htm");
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
            GxWebStd.gx_div_start( context, divEstadotecnicosid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estadotecnicosid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estadotecnicosid_visible_Internalname, "Id", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_104_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estadotecnicosid_visible_Internalname, StringUtil.BoolToStr( AV14Att_EstadoTecnicosId_Visible), "", "Id", 1, chkavAtt_estadotecnicosid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
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
            GxWebStd.gx_div_start( context, divEstadotecnicosnombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estadotecnicosnombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estadotecnicosnombre_visible_Internalname, "Técnicos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_104_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estadotecnicosnombre_visible_Internalname, StringUtil.BoolToStr( AV15Att_EstadoTecnicosNombre_Visible), "", "Técnicos", 1, chkavAtt_estadotecnicosnombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_WWEstadoTecnicos.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_104_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(71, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEstadoTecnicos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e245r1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWEstadoTecnicos.htm");
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
            wb_table3_85_5R2( true) ;
         }
         else
         {
            wb_table3_85_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_85_5R2e( bool wbgen )
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
            wb_table4_92_5R2( true) ;
         }
         else
         {
            wb_table4_92_5R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_92_5R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_24_5R2e( true) ;
         }
         else
         {
            wb_table1_24_5R2e( false) ;
         }
      }

      protected void wb_table4_92_5R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEstadoTecnicos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_92_5R2e( true) ;
         }
         else
         {
            wb_table4_92_5R2e( false) ;
         }
      }

      protected void wb_table3_85_5R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e255r1_client"+"'", TempTags, "", 2, "HLP_WWEstadoTecnicos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEstadoTecnicos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_85_5R2e( true) ;
         }
         else
         {
            wb_table3_85_5R2e( false) ;
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
         PA5R2( ) ;
         WS5R2( ) ;
         WE5R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418842286", true, true);
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
         context.AddJavascriptSource("wwestadotecnicos.js", "?202418842287", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1042( )
      {
         edtEstadoTecnicosId_Internalname = "ESTADOTECNICOSID_"+sGXsfl_104_idx;
         edtEstadoTecnicosNombre_Internalname = "ESTADOTECNICOSNOMBRE_"+sGXsfl_104_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_104_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_104_idx;
      }

      protected void SubsflControlProps_fel_1042( )
      {
         edtEstadoTecnicosId_Internalname = "ESTADOTECNICOSID_"+sGXsfl_104_fel_idx;
         edtEstadoTecnicosNombre_Internalname = "ESTADOTECNICOSNOMBRE_"+sGXsfl_104_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_104_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_104_fel_idx;
      }

      protected void sendrow_1042( )
      {
         SubsflControlProps_1042( ) ;
         WB5R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_104_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_104_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_104_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtEstadoTecnicosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTecnicosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A192EstadoTecnicosId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A192EstadoTecnicosId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTecnicosId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtEstadoTecnicosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)38,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtEstadoTecnicosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTecnicosNombre_Internalname,(string)A193EstadoTecnicosNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadoTecnicosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadoTecnicosNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtEstadoTecnicosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV31Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV31Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV44Update_GXI : context.PathToRelativeUrl( AV31Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV31Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV32Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV45Delete_GXI : context.PathToRelativeUrl( AV32Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV32Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes5R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_104_idx = ((subGrid_Islastpage==1)&&(nGXsfl_104_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
         }
         /* End function sendrow_1042 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_estadotecnicosid_visible.Name = "vATT_ESTADOTECNICOSID_VISIBLE";
         chkavAtt_estadotecnicosid_visible.WebTags = "";
         chkavAtt_estadotecnicosid_visible.Caption = "";
         AssignProp("", false, chkavAtt_estadotecnicosid_visible_Internalname, "TitleCaption", chkavAtt_estadotecnicosid_visible.Caption, true);
         chkavAtt_estadotecnicosid_visible.CheckedValue = "false";
         AV14Att_EstadoTecnicosId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_EstadoTecnicosId_Visible));
         AssignAttri("", false, "AV14Att_EstadoTecnicosId_Visible", AV14Att_EstadoTecnicosId_Visible);
         chkavAtt_estadotecnicosnombre_visible.Name = "vATT_ESTADOTECNICOSNOMBRE_VISIBLE";
         chkavAtt_estadotecnicosnombre_visible.WebTags = "";
         chkavAtt_estadotecnicosnombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_estadotecnicosnombre_visible_Internalname, "TitleCaption", chkavAtt_estadotecnicosnombre_visible.Caption, true);
         chkavAtt_estadotecnicosnombre_visible.CheckedValue = "false";
         AV15Att_EstadoTecnicosNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_EstadoTecnicosNombre_Visible));
         AssignAttri("", false, "AV15Att_EstadoTecnicosNombre_Visible", AV15Att_EstadoTecnicosNombre_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
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
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_estadotecnicosid_visible_Internalname = "vATT_ESTADOTECNICOSID_VISIBLE";
         divEstadotecnicosid_gridsettingscontainer_Internalname = "ESTADOTECNICOSID_GRIDSETTINGSCONTAINER";
         chkavAtt_estadotecnicosnombre_visible_Internalname = "vATT_ESTADOTECNICOSNOMBRE_VISIBLE";
         divEstadotecnicosnombre_gridsettingscontainer_Internalname = "ESTADOTECNICOSNOMBRE_GRIDSETTINGSCONTAINER";
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
         edtEstadoTecnicosId_Internalname = "ESTADOTECNICOSID";
         edtEstadoTecnicosNombre_Internalname = "ESTADOTECNICOSNOMBRE";
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
         chkavAtt_estadotecnicosnombre_visible.Caption = "Técnicos";
         chkavAtt_estadotecnicosid_visible.Caption = "Id";
         edtEstadoTecnicosNombre_Jsonclick = "";
         edtEstadoTecnicosId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_estadotecnicosnombre_visible.Enabled = 1;
         chkavAtt_estadotecnicosid_visible.Enabled = 1;
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
         edtEstadoTecnicosNombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtEstadoTecnicosNombre_Visible = -1;
         edtEstadoTecnicosId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Estado técnicos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E125R2',iparms:[{av:'A192EstadoTecnicosId',fld:'ESTADOTECNICOSID',pic:'ZZZ9',hsh:true},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E255R1',iparms:[{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E215R2',iparms:[{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E225R2',iparms:[{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'A192EstadoTecnicosId',fld:'ESTADOTECNICOSID',pic:'ZZZ9',hsh:true},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Link',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E115R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E235R1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E135R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{av:'AV17RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV16GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV17RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E145R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E155R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E165R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E175R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV30EstadoTecnicosNombre_IsAuthorized',fld:'vESTADOTECNICOSNOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtEstadoTecnicosId_Visible',ctrl:'ESTADOTECNICOSID',prop:'Visible'},{av:'edtEstadoTecnicosNombre_Visible',ctrl:'ESTADOTECNICOSNOMBRE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E185R2',iparms:[{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV39Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E245R1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_EstadoTecnicosId_Visible',fld:'vATT_ESTADOTECNICOSID_VISIBLE',pic:''},{av:'AV15Att_EstadoTecnicosNombre_Visible',fld:'vATT_ESTADOTECNICOSNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV23K2BToolsGenericSearchField = "";
         AV22ClassCollection = new GxSimpleCollection<string>();
         AV42Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV39Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV25GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A193EstadoTecnicosNombre = "";
         AV31Update = "";
         AV32Delete = "";
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
         AV44Update_GXI = "";
         AV45Delete_GXI = "";
         scmdbuf = "";
         lV23K2BToolsGenericSearchField = "";
         H005R2_A193EstadoTecnicosNombre = new string[] {""} ;
         H005R2_A192EstadoTecnicosId = new short[1] ;
         H005R3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV28Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV29Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV19GridStateKey = "";
         AV20GridState = new SdtK2BGridState(context);
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV37OutFile = "";
         AV38Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         sImgUrl = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwestadotecnicos__default(),
            new Object[][] {
                new Object[] {
               H005R2_A193EstadoTecnicosNombre, H005R2_A192EstadoTecnicosId
               }
               , new Object[] {
               H005R3_AGRID_nRecordCount
               }
            }
         );
         AV42Pgmname = "WWEstadoTecnicos";
         /* GeneXus formulas. */
         AV42Pgmname = "WWEstadoTecnicos";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV27UC_OrderedBy ;
      private short AV17RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A192EstadoTecnicosId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV16GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_104 ;
      private int nGXsfl_104_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtEstadoTecnicosId_Visible ;
      private int edtEstadoTecnicosNombre_Visible ;
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
      private int AV43GXV1 ;
      private int AV46GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV47GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV48GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_104_idx="0001" ;
      private string AV23K2BToolsGenericSearchField ;
      private string AV42Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtEstadoTecnicosNombre_Link ;
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
      private string edtEstadoTecnicosId_Internalname ;
      private string edtEstadoTecnicosNombre_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV23K2BToolsGenericSearchField ;
      private string chkavAtt_estadotecnicosid_visible_Internalname ;
      private string chkavAtt_estadotecnicosnombre_visible_Internalname ;
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
      private string sImgUrl ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divEstadotecnicosid_gridsettingscontainer_Internalname ;
      private string divEstadotecnicosnombre_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_104_fel_idx="0001" ;
      private string ROClassString ;
      private string edtEstadoTecnicosId_Jsonclick ;
      private string edtEstadoTecnicosNombre_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV30EstadoTecnicosNombre_IsAuthorized ;
      private bool AV14Att_EstadoTecnicosId_Visible ;
      private bool AV15Att_EstadoTecnicosNombre_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_104_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV31Update_IsBlob ;
      private bool AV32Delete_IsBlob ;
      private string AV39Uri ;
      private string A193EstadoTecnicosNombre ;
      private string AV44Update_GXI ;
      private string AV45Delete_GXI ;
      private string AV19GridStateKey ;
      private string AV37OutFile ;
      private string AV31Update ;
      private string AV32Delete ;
      private Guid AV38Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_estadotecnicosid_visible ;
      private GXCheckbox chkavAtt_estadotecnicosnombre_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H005R2_A193EstadoTecnicosNombre ;
      private short[] H005R2_A192EstadoTecnicosId ;
      private long[] H005R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV22ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV25GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV35ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV20GridState ;
      private SdtK2BGridState_FilterValue AV21GridStateFilterValue ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV26GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV29Message ;
      private SdtK2BTrnContext AV33TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV36ActivityListItem ;
   }

   public class wwestadotecnicos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005R2( IGxContext context ,
                                             string AV23K2BToolsGenericSearchField ,
                                             short A192EstadoTecnicosId ,
                                             string A193EstadoTecnicosNombre ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EstadoTecnicosNombre], [EstadoTecnicosId]";
         sFromString = " FROM [EstadoTecnicos]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([EstadoTecnicosId] AS decimal(4,0))) like '%' + @lV23K2BToolsGenericSearchField + '%' or [EstadoTecnicosNombre] like '%' + @lV23K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( AV24OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [EstadoTecnicosId]";
         }
         else if ( AV24OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [EstadoTecnicosId] DESC";
         }
         else if ( AV24OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [EstadoTecnicosNombre]";
         }
         else if ( AV24OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [EstadoTecnicosNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [EstadoTecnicosId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H005R3( IGxContext context ,
                                             string AV23K2BToolsGenericSearchField ,
                                             short A192EstadoTecnicosId ,
                                             string A193EstadoTecnicosNombre ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [EstadoTecnicos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([EstadoTecnicosId] AS decimal(4,0))) like '%' + @lV23K2BToolsGenericSearchField + '%' or [EstadoTecnicosNombre] like '%' + @lV23K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV24OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005R2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] );
               case 1 :
                     return conditional_H005R3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmH005R2;
          prmH005R2 = new Object[] {
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005R3;
          prmH005R3 = new Object[] {
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
