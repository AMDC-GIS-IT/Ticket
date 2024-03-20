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
namespace GeneXus.Programs.k2bfsg {
   public class entryapplication : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryapplication( )
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

      public entryapplication( IGxContext context )
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

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV33Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV33Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavUseabsoluteurlbyenvironment = new GXCheckbox();
         cmbavMainmenu = new GXCombobox();
         chkavAccessrequirespermission = new GXCheckbox();
         chkavClientallowremoteauth = new GXCheckbox();
         chkavClientallowgetuserroles = new GXCheckbox();
         chkavClientallowgetuseradddata = new GXCheckbox();
         chkavClientallowgetsessioniniprop = new GXCheckbox();
         chkavClientallowremoterestauth = new GXCheckbox();
         chkavClientallowgetuserrolesrest = new GXCheckbox();
         chkavClientallowgetuseradddatarest = new GXCheckbox();
         chkavClientallowgetsessioniniproprest = new GXCheckbox();
         chkavClientaccessuniquebyuser = new GXCheckbox();
         chkavSsorestenable = new GXCheckbox();
         cmbavSsorestmode = new GXCombobox();
         chkavStsprotocolenable = new GXCheckbox();
         cmbavStsmode = new GXCombobox();
         chkavEnvironmentsecurityprotocol = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV33Id = (long)(NumberUtil.Val( GetPar( "Id"), "."));
                  AssignAttri("", false, "AV33Id", StringUtil.LTrimStr( (decimal)(AV33Id), 12, 0));
               }
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
            return "k2bsecurity_Execute" ;
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
         PA3U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3U2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249545431", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryapplication.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV33Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGE", AV36Message);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGE", AV36Message);
         }
         GxWebStd.gx_hidden_field( context, "TABS_TABSCONTROL_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_tabscontrol_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_TABSCONTROL_Class", StringUtil.RTrim( Tabs_tabscontrol_Class));
         GxWebStd.gx_hidden_field( context, "TABS_TABSCONTROL_Historymanagement", StringUtil.BoolToStr( Tabs_tabscontrol_Historymanagement));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTESCONTAINERTABLE_PERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divAttributescontainertable_permissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTESCONTAINERTABLE_MENUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divAttributescontainertable_menus_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTESCONTAINERTABLE_PERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divAttributescontainertable_permissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTESCONTAINERTABLE_MENUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divAttributescontainertable_menus_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Permissionswc == null ) )
         {
            WebComp_Permissionswc.componentjscripts();
         }
         if ( ! ( WebComp_Menuswc == null ) )
         {
            WebComp_Menuswc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3U2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.entryapplication.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV33Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryApplication" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aplicación" ;
      }

      protected void WB3U0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Aplicación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecell_attributes_attributes_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_19_3U2( true) ;
         }
         else
         {
            wb_table1_19_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_19_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_31_3U2( true) ;
         }
         else
         {
            wb_table2_31_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_31_3U2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_id_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Id), 12, 0, ",", "")), ((edtavId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33Id), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV33Id), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavId_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "right", false, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV30GUID), StringUtil.RTrim( context.localUtil.Format( AV30GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV37Name), StringUtil.RTrim( context.localUtil.Format( AV37Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_dsc_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Descripción", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV20Dsc), StringUtil.RTrim( context.localUtil.Format( AV20Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_version_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavVersion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVersion_Internalname, "Versión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVersion_Internalname, StringUtil.RTrim( AV42Version), StringUtil.RTrim( context.localUtil.Format( AV42Version, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVersion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavVersion_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_company_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCompany_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCompany_Internalname, "Empresa", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCompany_Internalname, StringUtil.RTrim( AV18Company), StringUtil.RTrim( context.localUtil.Format( AV18Company, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCompany_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCompany_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_copyright_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCopyright_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCopyright_Internalname, "Copyright", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCopyright_Internalname, StringUtil.RTrim( AV19Copyright), StringUtil.RTrim( context.localUtil.Format( AV19Copyright, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCopyright_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCopyright_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_useabsoluteurlbyenvironment_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavUseabsoluteurlbyenvironment_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUseabsoluteurlbyenvironment_Internalname, "Usar URL absoluta de entorno", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUseabsoluteurlbyenvironment_Internalname, StringUtil.BoolToStr( AV40UseAbsoluteUrlByEnvironment), "", "Usar URL absoluta de entorno", 1, chkavUseabsoluteurlbyenvironment.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(80, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,80);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_homeobject_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavHomeobject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHomeobject_Internalname, "Objecto Inicio", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHomeobject_Internalname, AV31HomeObject, StringUtil.RTrim( context.localUtil.Format( AV31HomeObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHomeobject_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavHomeobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_logoutobject_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_logoutobject_Internalname, "Objeto de Logout", "", "", lblTextblock_var_logoutobject_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_logoutobjectfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogoutobject_Internalname, "Objeto de Logout", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogoutobject_Internalname, AV34LogoutObject, StringUtil.RTrim( context.localUtil.Format( AV34LogoutObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogoutobject_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLogoutobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Static images/pictures */
            ClassString = "K2BImage_ContextHelp";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "afb51b54-e80c-459c-b24b-07b4c9cb5db7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogoutobject_var_contexthelpimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", imgLogoutobject_var_contexthelpimage_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_mainmenu_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavMainmenu_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMainmenu_Internalname, "Menú principal", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMainmenu, cmbavMainmenu_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0)), 1, cmbavMainmenu_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMainmenu.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_K2BFSG\\EntryApplication.htm");
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", (string)(cmbavMainmenu.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_accessrequirespermission_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavAccessrequirespermission_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAccessrequirespermission_Internalname, "Permiso requerido para acceder", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAccessrequirespermission_Internalname, StringUtil.BoolToStr( AV5AccessRequiresPermission), "", "Permiso requerido para acceder", 1, chkavAccessrequirespermission.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientrevoked_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientrevoked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrevoked_Internalname, "ClientRevoked", "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavClientrevoked_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavClientrevoked_Internalname, context.localUtil.TToC( AV52ClientRevoked, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV52ClientRevoked, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrevoked_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtavClientrevoked_Enabled, 1, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_bitmap( context, edtavClientrevoked_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavClientrevoked_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRevoke_Internalname, "", bttRevoke_Caption, bttRevoke_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e113u1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucTabs_tabscontrol.SetProperty("PageCount", Tabs_tabscontrol_Pagecount);
            ucTabs_tabscontrol.SetProperty("Class", Tabs_tabscontrol_Class);
            ucTabs_tabscontrol.SetProperty("HistoryManagement", Tabs_tabscontrol_Historymanagement);
            ucTabs_tabscontrol.Render(context, "tab", Tabs_tabscontrol_Internalname, "TABS_TABSCONTROLContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_tabcontrol_title_Internalname, "Autenticación remota", "", "", lblTab1_tabcontrol_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1_TabControl") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientid_Internalname, "Identificador de cliente", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, StringUtil.RTrim( AV14ClientId), StringUtil.RTrim( context.localUtil.Format( AV14ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationId", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientsecret_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientsecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientsecret_Internalname, "Secreto de cliente", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, StringUtil.RTrim( AV17ClientSecret), StringUtil.RTrim( context.localUtil.Format( AV17ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationSecret", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpRemoteauthentication_Internalname, "Autenticación remota (IDP, SSO)", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_remoteauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowremoteauth_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowremoteauth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowremoteauth_Internalname, "Permitir autenticación remota", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowremoteauth_Internalname, StringUtil.BoolToStr( AV11ClientAllowRemoteAuth), "", "Permitir autenticación remota", 1, chkavClientallowremoteauth.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpRemoteauthenticationcontent_Internalname, "Remote Authentication Content", 1, 0, "px", 0, "px", grpRemoteauthenticationcontent_Class, "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_remoteauthenticationcontent_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetuserroles_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuserroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserroles_Internalname, "Puede obtener roles", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserroles_Internalname, StringUtil.BoolToStr( AV10ClientAllowGetUserRoles), "", "Puede obtener roles", 1, chkavClientallowgetuserroles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(152, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,152);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetuseradddata_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuseradddata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuseradddata_Internalname, "Puede obtener datos adicionales de usuarios", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuseradddata_Internalname, StringUtil.BoolToStr( AV9ClientAllowGetUserAddData), "", "Puede obtener datos adicionales de usuarios", 1, chkavClientallowgetuseradddata.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(157, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,157);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetsessioniniprop_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetsessioniniprop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessioniniprop_Internalname, "Puede obtener datos iniciales de sesión", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessioniniprop_Internalname, StringUtil.BoolToStr( AV51ClientAllowGetSessionIniProp), "", "Puede obtener datos iniciales de sesión", 1, chkavClientallowgetsessioniniprop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(163, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,163);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientlocalloginurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientlocalloginurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientlocalloginurl_Internalname, "URL inicio de sesión local", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientlocalloginurl_Internalname, AV16ClientLocalLoginURL, StringUtil.RTrim( context.localUtil.Format( AV16ClientLocalLoginURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientlocalloginurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientlocalloginurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientcallbackurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientcallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientcallbackurl_Internalname, "URL callback", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientcallbackurl_Internalname, AV12ClientCallbackURL, StringUtil.RTrim( context.localUtil.Format( AV12ClientCallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientcallbackurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientcallbackurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientimageurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientimageurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientimageurl_Internalname, "URL de imágenes", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientimageurl_Internalname, AV15ClientImageURL, StringUtil.RTrim( context.localUtil.Format( AV15ClientImageURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientimageurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientimageurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpRemoteauthenticationrest_Internalname, "Autenticación remota (mobile, GAMRemoteRest)", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_remoteauthenticationrest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowremoterestauth_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowremoterestauth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowremoterestauth_Internalname, "Permitir autenticación remota", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowremoterestauth_Internalname, StringUtil.BoolToStr( AV47ClientAllowRemoteRestAuth), "", "Permitir autenticación remota", 1, chkavClientallowremoterestauth.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,190);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpRemoteauthenticationcontentrest_Internalname, "Remote Authentication Content Rest", 1, 0, "px", 0, "px", grpRemoteauthenticationcontentrest_Class, "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_remoteauthenticationcontentrest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetuserrolesrest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuserrolesrest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserrolesrest_Internalname, "Puede obtener roles", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserrolesrest_Internalname, StringUtil.BoolToStr( AV48ClientAllowGetUserRolesRest), "", "Puede obtener roles", 1, chkavClientallowgetuserrolesrest.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(200, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,200);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetuseradddatarest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuseradddatarest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuseradddatarest_Internalname, "Puede obtener datos adicionales de usuarios", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuseradddatarest_Internalname, StringUtil.BoolToStr( AV49ClientAllowGetUserAddDataRest), "", "Puede obtener datos adicionales de usuarios", 1, chkavClientallowgetuseradddatarest.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(205, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,205);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientallowgetsessioniniproprest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetsessioniniproprest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessioniniproprest_Internalname, "Puede obtener datos iniciales de sesión", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessioniniproprest_Internalname, StringUtil.BoolToStr( AV50ClientAllowGetSessionIniPropRest), "", "Puede obtener datos iniciales de sesión", 1, chkavClientallowgetsessioniniproprest.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(211, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,211);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientaccessuniquebyuser_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavClientaccessuniquebyuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientaccessuniquebyuser_Internalname, "Permitir sólo un acceso por usuario", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientaccessuniquebyuser_Internalname, StringUtil.BoolToStr( AV53ClientAccessUniqueByUser), "", "Permitir sólo un acceso por usuario", 1, chkavClientaccessuniquebyuser.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(217, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,217);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientencryptionkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_clientencryptionkey_Internalname, "Clave de encriptación privada", "", "", lblTextblock_var_clientencryptionkey_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientencryptionkeyfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientencryptionkey_Internalname, "Clave de encriptación privada", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 223,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientencryptionkey_Internalname, StringUtil.RTrim( AV13ClientEncryptionKey), StringUtil.RTrim( context.localUtil.Format( AV13ClientEncryptionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,223);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientencryptionkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientencryptionkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGeneratekey_Internalname, "", "Generar clave", bttGeneratekey_Jsonclick, 5, "", "", StyleString, ClassString, bttGeneratekey_Visible, bttGeneratekey_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_GENERATEKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientrepositoryguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavClientrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrepositoryguid_Internalname, "GUID repositorio cliente", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientrepositoryguid_Internalname, StringUtil.RTrim( AV46ClientRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV46ClientRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrepositoryguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab3_tabcontrol_title_Internalname, "SSO Rest", "", "", lblTab3_tabcontrol_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab3_TabControl") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab3_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_ssorestenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavSsorestenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSsorestenable_Internalname, "Habilitar servicios REST SSO", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSsorestenable_Internalname, StringUtil.BoolToStr( AV59SSORestEnable), "", "Habilitar servicios REST SSO", 1, chkavSsorestenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,241);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroupgamssorest_Internalname, "Group GAMSSORest", 1, 0, "px", 0, "px", grpGroupgamssorest_Class, "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_groupgamssorest_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_ssorestmode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavSsorestmode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSsorestmode_Internalname, "Moso SSO", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSsorestmode, cmbavSsorestmode_Internalname, StringUtil.RTrim( AV60SSORestMode), 1, cmbavSsorestmode_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSsorestmode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "", true, 1, "HLP_K2BFSG\\EntryApplication.htm");
            cmbavSsorestmode.CurrentValue = StringUtil.RTrim( AV60SSORestMode);
            AssignProp("", false, cmbavSsorestmode_Internalname, "Values", (string)(cmbavSsorestmode.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_ssorestuserauthtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSsorestuserauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestuserauthtypename_Internalname, "Nombre de tipo de autenticación en este servidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestuserauthtypename_Internalname, StringUtil.RTrim( AV61SSORestUserAuthTypeName), StringUtil.RTrim( context.localUtil.Format( AV61SSORestUserAuthTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,257);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestuserauthtypename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSsorestuserauthtypename_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_ssorestserverurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSsorestserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestserverurl_Internalname, "URL servidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 263,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestserverurl_Internalname, AV54SSORestServerURL, StringUtil.RTrim( context.localUtil.Format( AV54SSORestServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,263);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestserverurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSsorestserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab4_tabcontrol_title_Internalname, "STS", "", "", lblTab4_tabcontrol_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab4_TabControl") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab4_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_stsprotocolenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavStsprotocolenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavStsprotocolenable_Internalname, "Habilitar protocolo STS", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavStsprotocolenable_Internalname, StringUtil.BoolToStr( AV62STSProtocolEnable), "", "Habilitar protocolo STS", 1, chkavStsprotocolenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,274);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroupsts_Internalname, "Group STS", 1, 0, "px", 0, "px", grpGroupsts_Class, "", "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_groupsts_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_stsmode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavStsmode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavStsmode_Internalname, "Modo STS", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavStsmode, cmbavStsmode_Internalname, StringUtil.RTrim( AV63STSMode), 1, cmbavStsmode_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavStsmode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,284);\"", "", true, 1, "HLP_K2BFSG\\EntryApplication.htm");
            cmbavStsmode.CurrentValue = StringUtil.RTrim( AV63STSMode);
            AssignProp("", false, cmbavStsmode_Internalname, "Values", (string)(cmbavStsmode.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_stsauthorizationusername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavStsauthorizationusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsauthorizationusername_Internalname, "Nombre de usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 290,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsauthorizationusername_Internalname, AV64STSAuthorizationUserName, StringUtil.RTrim( context.localUtil.Format( AV64STSAuthorizationUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,290);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsauthorizationusername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavStsauthorizationusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_stsauthorizationuserguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavStsauthorizationuserguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsauthorizationuserguid_Internalname, "GUID usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 296,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsauthorizationuserguid_Internalname, StringUtil.RTrim( AV58STSAuthorizationUserGUID), StringUtil.RTrim( context.localUtil.Format( AV58STSAuthorizationUserGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,296);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsauthorizationuserguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavStsauthorizationuserguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_stsserverclientpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavStsserverclientpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverclientpassword_Internalname, "Password cliente", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverclientpassword_Internalname, StringUtil.RTrim( AV65STSServerClientPassword), StringUtil.RTrim( context.localUtil.Format( AV65STSServerClientPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,302);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverclientpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavStsserverclientpassword_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_stsserverurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavStsserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverurl_Internalname, "URL servidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 308,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverurl_Internalname, AV56STSServerURL, StringUtil.RTrim( context.localUtil.Format( AV56STSServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,308);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavStsserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_stsserverrepositoryguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavStsserverrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverrepositoryguid_Internalname, "GUID repositorio", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 314,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverrepositoryguid_Internalname, StringUtil.RTrim( AV57STSServerRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV57STSServerRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,314);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverrepositoryguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavStsserverrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_tabcontrol_title_Internalname, "Configuración de entorno", "", "", lblTab2_tabcontrol_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2_TabControl") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABS_TABSCONTROLContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentname_Internalname, "Nombre del ambiente", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 325,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentname_Internalname, StringUtil.RTrim( AV22EnvironmentName), StringUtil.RTrim( context.localUtil.Format( AV22EnvironmentName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,325);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmentname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentsecurityprotocol_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavEnvironmentsecurityprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnvironmentsecurityprotocol_Internalname, "¿Es HTTPS?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 330,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnvironmentsecurityprotocol_Internalname, StringUtil.BoolToStr( AV26EnvironmentSecurityProtocol), "", "¿Es HTTPS?", 1, chkavEnvironmentsecurityprotocol.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(330, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,330);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmenthost_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmenthost_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmenthost_Internalname, "Servidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 336,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmenthost_Internalname, StringUtil.RTrim( AV21EnvironmentHost), StringUtil.RTrim( context.localUtil.Format( AV21EnvironmentHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,336);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmenthost_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmenthost_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentport_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentport_Internalname, "Puerto", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 341,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23EnvironmentPort), 5, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23EnvironmentPort), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,341);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentport_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmentport_Enabled, 1, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "K2BPort", "right", false, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentvirtualdirectory_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentvirtualdirectory_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentvirtualdirectory_Internalname, "Directorio virtual", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 347,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentvirtualdirectory_Internalname, StringUtil.RTrim( AV27EnvironmentVirtualDirectory), StringUtil.RTrim( context.localUtil.Format( AV27EnvironmentVirtualDirectory, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,347);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentvirtualdirectory_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmentvirtualdirectory_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentprogrampackage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentprogrampackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogrampackage_Internalname, "Paquete", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 353,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogrampackage_Internalname, StringUtil.RTrim( AV25EnvironmentProgramPackage), StringUtil.RTrim( context.localUtil.Format( AV25EnvironmentProgramPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,353);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogrampackage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmentprogrampackage_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_environmentprogramextension_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentprogramextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogramextension_Internalname, "Extensión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 358,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogramextension_Internalname, StringUtil.RTrim( AV24EnvironmentProgramExtension), StringUtil.RTrim( context.localUtil.Format( AV24EnvironmentProgramExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,358);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogramextension_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEnvironmentprogramextension_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\EntryApplication.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_364_3U2( true) ;
         }
         else
         {
            wb_table3_364_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_364_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divColumns_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_column_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_permissions_Internalname, divResponsivetable_mainattributes_permissions_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_permissions_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecell_attributes_permissions_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_381_3U2( true) ;
         }
         else
         {
            wb_table4_381_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table4_381_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_permissions_Internalname, divAttributescontainertable_permissions_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0395"+"", StringUtil.RTrim( WebComp_Permissionswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0395"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPermissionswc), StringUtil.Lower( WebComp_Permissionswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0395"+"");
                  }
                  WebComp_Permissionswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPermissionswc), StringUtil.Lower( WebComp_Permissionswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_column1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_menus_Internalname, divResponsivetable_mainattributes_menus_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_menus_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecell_attributes_menus_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_403_3U2( true) ;
         }
         else
         {
            wb_table5_403_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table5_403_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_menus_Internalname, divAttributescontainertable_menus_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0417"+"", StringUtil.RTrim( WebComp_Menuswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0417"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Menuswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMenuswc), StringUtil.Lower( WebComp_Menuswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0417"+"");
                  }
                  WebComp_Menuswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMenuswc), StringUtil.Lower( WebComp_Menuswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
         wbLoad = true;
      }

      protected void START3U2( )
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
            Form.Meta.addItem("description", "Aplicación", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3U0( ) ;
      }

      protected void WS3U2( )
      {
         START3U2( ) ;
         EVT3U2( ) ;
      }

      protected void EVT3U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E123U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E133U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E143U2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_GENERATEKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_GenerateKey' */
                              E153U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TEXTBLOCK_ATTRIBUTES_PERMISSIONS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E163U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COLLAPSIBLEIMAGE_PERMISSIONS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E173U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TEXTBLOCK_ATTRIBUTES_MENUS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E183U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COLLAPSIBLEIMAGE_MENUS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E193U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E203U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCLIENTALLOWREMOTEAUTH.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E213U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCLIENTALLOWREMOTERESTAUTH.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E223U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSSORESTENABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E233U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSTSPROTOCOLENABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243U2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 395 )
                        {
                           OldPermissionswc = cgiGet( "W0395");
                           if ( ( StringUtil.Len( OldPermissionswc) == 0 ) || ( StringUtil.StrCmp(OldPermissionswc, WebComp_Permissionswc_Component) != 0 ) )
                           {
                              WebComp_Permissionswc = getWebComponent(GetType(), "GeneXus.Programs", OldPermissionswc, new Object[] {context} );
                              WebComp_Permissionswc.ComponentInit();
                              WebComp_Permissionswc.Name = "OldPermissionswc";
                              WebComp_Permissionswc_Component = OldPermissionswc;
                           }
                           if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
                           {
                              WebComp_Permissionswc.componentprocess("W0395", "", sEvt);
                           }
                           WebComp_Permissionswc_Component = OldPermissionswc;
                        }
                        else if ( nCmpId == 417 )
                        {
                           OldMenuswc = cgiGet( "W0417");
                           if ( ( StringUtil.Len( OldMenuswc) == 0 ) || ( StringUtil.StrCmp(OldMenuswc, WebComp_Menuswc_Component) != 0 ) )
                           {
                              WebComp_Menuswc = getWebComponent(GetType(), "GeneXus.Programs", OldMenuswc, new Object[] {context} );
                              WebComp_Menuswc.ComponentInit();
                              WebComp_Menuswc.Name = "OldMenuswc";
                              WebComp_Menuswc_Component = OldMenuswc;
                           }
                           if ( StringUtil.Len( WebComp_Menuswc_Component) != 0 )
                           {
                              WebComp_Menuswc.componentprocess("W0417", "", sEvt);
                           }
                           WebComp_Menuswc_Component = OldMenuswc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3U2( )
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

      protected void PA3U2( )
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
               GX_FocusControl = edtavGuid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         AV40UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UseAbsoluteUrlByEnvironment));
         AssignAttri("", false, "AV40UseAbsoluteUrlByEnvironment", AV40UseAbsoluteUrlByEnvironment);
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV35MainMenu = (long)(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0))), "."));
            AssignAttri("", false, "AV35MainMenu", StringUtil.LTrimStr( (decimal)(AV35MainMenu), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", cmbavMainmenu.ToJavascriptSource(), true);
         }
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         AV11ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV11ClientAllowRemoteAuth));
         AssignAttri("", false, "AV11ClientAllowRemoteAuth", AV11ClientAllowRemoteAuth);
         AV10ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ClientAllowGetUserRoles));
         AssignAttri("", false, "AV10ClientAllowGetUserRoles", AV10ClientAllowGetUserRoles);
         AV9ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ClientAllowGetUserAddData));
         AssignAttri("", false, "AV9ClientAllowGetUserAddData", AV9ClientAllowGetUserAddData);
         AV51ClientAllowGetSessionIniProp = StringUtil.StrToBool( StringUtil.BoolToStr( AV51ClientAllowGetSessionIniProp));
         AssignAttri("", false, "AV51ClientAllowGetSessionIniProp", AV51ClientAllowGetSessionIniProp);
         AV47ClientAllowRemoteRestAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV47ClientAllowRemoteRestAuth));
         AssignAttri("", false, "AV47ClientAllowRemoteRestAuth", AV47ClientAllowRemoteRestAuth);
         AV48ClientAllowGetUserRolesRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV48ClientAllowGetUserRolesRest));
         AssignAttri("", false, "AV48ClientAllowGetUserRolesRest", AV48ClientAllowGetUserRolesRest);
         AV49ClientAllowGetUserAddDataRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV49ClientAllowGetUserAddDataRest));
         AssignAttri("", false, "AV49ClientAllowGetUserAddDataRest", AV49ClientAllowGetUserAddDataRest);
         AV50ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV50ClientAllowGetSessionIniPropRest));
         AssignAttri("", false, "AV50ClientAllowGetSessionIniPropRest", AV50ClientAllowGetSessionIniPropRest);
         AV53ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV53ClientAccessUniqueByUser));
         AssignAttri("", false, "AV53ClientAccessUniqueByUser", AV53ClientAccessUniqueByUser);
         AV59SSORestEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV59SSORestEnable));
         AssignAttri("", false, "AV59SSORestEnable", AV59SSORestEnable);
         if ( cmbavSsorestmode.ItemCount > 0 )
         {
            AV60SSORestMode = cmbavSsorestmode.getValidValue(AV60SSORestMode);
            AssignAttri("", false, "AV60SSORestMode", AV60SSORestMode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSsorestmode.CurrentValue = StringUtil.RTrim( AV60SSORestMode);
            AssignProp("", false, cmbavSsorestmode_Internalname, "Values", cmbavSsorestmode.ToJavascriptSource(), true);
         }
         AV62STSProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV62STSProtocolEnable));
         AssignAttri("", false, "AV62STSProtocolEnable", AV62STSProtocolEnable);
         if ( cmbavStsmode.ItemCount > 0 )
         {
            AV63STSMode = cmbavStsmode.getValidValue(AV63STSMode);
            AssignAttri("", false, "AV63STSMode", AV63STSMode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavStsmode.CurrentValue = StringUtil.RTrim( AV63STSMode);
            AssignProp("", false, cmbavStsmode_Internalname, "Values", cmbavStsmode.ToJavascriptSource(), true);
         }
         AV26EnvironmentSecurityProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV26EnvironmentSecurityProtocol));
         AssignAttri("", false, "AV26EnvironmentSecurityProtocol", AV26EnvironmentSecurityProtocol);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
      }

      protected void RF3U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E133U2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
               {
                  WebComp_Permissionswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Menuswc_Component) != 0 )
               {
                  WebComp_Menuswc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E203U2 ();
            WB3U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3U2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            Tabs_tabscontrol_Pagecount = (int)(context.localUtil.CToN( cgiGet( "TABS_TABSCONTROL_Pagecount"), ",", "."));
            Tabs_tabscontrol_Class = cgiGet( "TABS_TABSCONTROL_Class");
            Tabs_tabscontrol_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_TABSCONTROL_Historymanagement"));
            divAttributescontainertable_permissions_Visible = (int)(context.localUtil.CToN( cgiGet( "ATTRIBUTESCONTAINERTABLE_PERMISSIONS_Visible"), ",", "."));
            divAttributescontainertable_menus_Visible = (int)(context.localUtil.CToN( cgiGet( "ATTRIBUTESCONTAINERTABLE_MENUS_Visible"), ",", "."));
            /* Read variables values. */
            AV33Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ",", "."));
            AssignAttri("", false, "AV33Id", StringUtil.LTrimStr( (decimal)(AV33Id), 12, 0));
            AV30GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV30GUID", AV30GUID);
            AV37Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV37Name", AV37Name);
            AV20Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV20Dsc", AV20Dsc);
            AV42Version = cgiGet( edtavVersion_Internalname);
            AssignAttri("", false, "AV42Version", AV42Version);
            AV18Company = cgiGet( edtavCompany_Internalname);
            AssignAttri("", false, "AV18Company", AV18Company);
            AV19Copyright = cgiGet( edtavCopyright_Internalname);
            AssignAttri("", false, "AV19Copyright", AV19Copyright);
            AV40UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( cgiGet( chkavUseabsoluteurlbyenvironment_Internalname));
            AssignAttri("", false, "AV40UseAbsoluteUrlByEnvironment", AV40UseAbsoluteUrlByEnvironment);
            AV31HomeObject = cgiGet( edtavHomeobject_Internalname);
            AssignAttri("", false, "AV31HomeObject", AV31HomeObject);
            AV34LogoutObject = cgiGet( edtavLogoutobject_Internalname);
            AssignAttri("", false, "AV34LogoutObject", AV34LogoutObject);
            cmbavMainmenu.CurrentValue = cgiGet( cmbavMainmenu_Internalname);
            AV35MainMenu = (long)(NumberUtil.Val( cgiGet( cmbavMainmenu_Internalname), "."));
            AssignAttri("", false, "AV35MainMenu", StringUtil.LTrimStr( (decimal)(AV35MainMenu), 12, 0));
            AV5AccessRequiresPermission = StringUtil.StrToBool( cgiGet( chkavAccessrequirespermission_Internalname));
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            if ( context.localUtil.VCDateTime( cgiGet( edtavClientrevoked_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Client Revoked"}), 1, "vCLIENTREVOKED");
               GX_FocusControl = edtavClientrevoked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52ClientRevoked = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV52ClientRevoked", context.localUtil.TToC( AV52ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV52ClientRevoked = context.localUtil.CToT( cgiGet( edtavClientrevoked_Internalname));
               AssignAttri("", false, "AV52ClientRevoked", context.localUtil.TToC( AV52ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            }
            AV14ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri("", false, "AV14ClientId", AV14ClientId);
            AV17ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri("", false, "AV17ClientSecret", AV17ClientSecret);
            AV11ClientAllowRemoteAuth = StringUtil.StrToBool( cgiGet( chkavClientallowremoteauth_Internalname));
            AssignAttri("", false, "AV11ClientAllowRemoteAuth", AV11ClientAllowRemoteAuth);
            AV10ClientAllowGetUserRoles = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserroles_Internalname));
            AssignAttri("", false, "AV10ClientAllowGetUserRoles", AV10ClientAllowGetUserRoles);
            AV9ClientAllowGetUserAddData = StringUtil.StrToBool( cgiGet( chkavClientallowgetuseradddata_Internalname));
            AssignAttri("", false, "AV9ClientAllowGetUserAddData", AV9ClientAllowGetUserAddData);
            AV51ClientAllowGetSessionIniProp = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessioniniprop_Internalname));
            AssignAttri("", false, "AV51ClientAllowGetSessionIniProp", AV51ClientAllowGetSessionIniProp);
            AV16ClientLocalLoginURL = cgiGet( edtavClientlocalloginurl_Internalname);
            AssignAttri("", false, "AV16ClientLocalLoginURL", AV16ClientLocalLoginURL);
            AV12ClientCallbackURL = cgiGet( edtavClientcallbackurl_Internalname);
            AssignAttri("", false, "AV12ClientCallbackURL", AV12ClientCallbackURL);
            AV15ClientImageURL = cgiGet( edtavClientimageurl_Internalname);
            AssignAttri("", false, "AV15ClientImageURL", AV15ClientImageURL);
            AV47ClientAllowRemoteRestAuth = StringUtil.StrToBool( cgiGet( chkavClientallowremoterestauth_Internalname));
            AssignAttri("", false, "AV47ClientAllowRemoteRestAuth", AV47ClientAllowRemoteRestAuth);
            AV48ClientAllowGetUserRolesRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserrolesrest_Internalname));
            AssignAttri("", false, "AV48ClientAllowGetUserRolesRest", AV48ClientAllowGetUserRolesRest);
            AV49ClientAllowGetUserAddDataRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetuseradddatarest_Internalname));
            AssignAttri("", false, "AV49ClientAllowGetUserAddDataRest", AV49ClientAllowGetUserAddDataRest);
            AV50ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessioniniproprest_Internalname));
            AssignAttri("", false, "AV50ClientAllowGetSessionIniPropRest", AV50ClientAllowGetSessionIniPropRest);
            AV53ClientAccessUniqueByUser = StringUtil.StrToBool( cgiGet( chkavClientaccessuniquebyuser_Internalname));
            AssignAttri("", false, "AV53ClientAccessUniqueByUser", AV53ClientAccessUniqueByUser);
            AV13ClientEncryptionKey = cgiGet( edtavClientencryptionkey_Internalname);
            AssignAttri("", false, "AV13ClientEncryptionKey", AV13ClientEncryptionKey);
            AV46ClientRepositoryGUID = cgiGet( edtavClientrepositoryguid_Internalname);
            AssignAttri("", false, "AV46ClientRepositoryGUID", AV46ClientRepositoryGUID);
            AV59SSORestEnable = StringUtil.StrToBool( cgiGet( chkavSsorestenable_Internalname));
            AssignAttri("", false, "AV59SSORestEnable", AV59SSORestEnable);
            cmbavSsorestmode.CurrentValue = cgiGet( cmbavSsorestmode_Internalname);
            AV60SSORestMode = cgiGet( cmbavSsorestmode_Internalname);
            AssignAttri("", false, "AV60SSORestMode", AV60SSORestMode);
            AV61SSORestUserAuthTypeName = cgiGet( edtavSsorestuserauthtypename_Internalname);
            AssignAttri("", false, "AV61SSORestUserAuthTypeName", AV61SSORestUserAuthTypeName);
            AV54SSORestServerURL = cgiGet( edtavSsorestserverurl_Internalname);
            AssignAttri("", false, "AV54SSORestServerURL", AV54SSORestServerURL);
            AV62STSProtocolEnable = StringUtil.StrToBool( cgiGet( chkavStsprotocolenable_Internalname));
            AssignAttri("", false, "AV62STSProtocolEnable", AV62STSProtocolEnable);
            cmbavStsmode.CurrentValue = cgiGet( cmbavStsmode_Internalname);
            AV63STSMode = cgiGet( cmbavStsmode_Internalname);
            AssignAttri("", false, "AV63STSMode", AV63STSMode);
            AV64STSAuthorizationUserName = cgiGet( edtavStsauthorizationusername_Internalname);
            AssignAttri("", false, "AV64STSAuthorizationUserName", AV64STSAuthorizationUserName);
            AV58STSAuthorizationUserGUID = cgiGet( edtavStsauthorizationuserguid_Internalname);
            AssignAttri("", false, "AV58STSAuthorizationUserGUID", AV58STSAuthorizationUserGUID);
            AV65STSServerClientPassword = cgiGet( edtavStsserverclientpassword_Internalname);
            AssignAttri("", false, "AV65STSServerClientPassword", AV65STSServerClientPassword);
            AV56STSServerURL = cgiGet( edtavStsserverurl_Internalname);
            AssignAttri("", false, "AV56STSServerURL", AV56STSServerURL);
            AV57STSServerRepositoryGUID = cgiGet( edtavStsserverrepositoryguid_Internalname);
            AssignAttri("", false, "AV57STSServerRepositoryGUID", AV57STSServerRepositoryGUID);
            AV22EnvironmentName = cgiGet( edtavEnvironmentname_Internalname);
            AssignAttri("", false, "AV22EnvironmentName", AV22EnvironmentName);
            AV26EnvironmentSecurityProtocol = StringUtil.StrToBool( cgiGet( chkavEnvironmentsecurityprotocol_Internalname));
            AssignAttri("", false, "AV26EnvironmentSecurityProtocol", AV26EnvironmentSecurityProtocol);
            AV21EnvironmentHost = cgiGet( edtavEnvironmenthost_Internalname);
            AssignAttri("", false, "AV21EnvironmentHost", AV21EnvironmentHost);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vENVIRONMENTPORT");
               GX_FocusControl = edtavEnvironmentport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23EnvironmentPort = 0;
               AssignAttri("", false, "AV23EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV23EnvironmentPort), 5, 0));
            }
            else
            {
               AV23EnvironmentPort = (int)(context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", "."));
               AssignAttri("", false, "AV23EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV23EnvironmentPort), 5, 0));
            }
            AV27EnvironmentVirtualDirectory = cgiGet( edtavEnvironmentvirtualdirectory_Internalname);
            AssignAttri("", false, "AV27EnvironmentVirtualDirectory", AV27EnvironmentVirtualDirectory);
            AV25EnvironmentProgramPackage = cgiGet( edtavEnvironmentprogrampackage_Internalname);
            AssignAttri("", false, "AV25EnvironmentProgramPackage", AV25EnvironmentProgramPackage);
            AV24EnvironmentProgramExtension = cgiGet( edtavEnvironmentprogramextension_Internalname);
            AssignAttri("", false, "AV24EnvironmentProgramExtension", AV24EnvironmentProgramExtension);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV41User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         edtavDsc_Enabled = 1;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
         edtavVersion_Enabled = 1;
         AssignProp("", false, edtavVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVersion_Enabled), 5, 0), true);
         edtavCopyright_Enabled = 1;
         AssignProp("", false, edtavCopyright_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCopyright_Enabled), 5, 0), true);
         edtavCompany_Enabled = 1;
         AssignProp("", false, edtavCompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCompany_Enabled), 5, 0), true);
         chkavAccessrequirespermission.Enabled = 1;
         AssignProp("", false, chkavAccessrequirespermission_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAccessrequirespermission.Enabled), 5, 0), true);
         edtavClientid_Enabled = 1;
         AssignProp("", false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
         edtavClientsecret_Enabled = 1;
         AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
         chkavClientaccessuniquebyuser.Enabled = 1;
         AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientaccessuniquebyuser.Enabled), 5, 0), true);
         chkavUseabsoluteurlbyenvironment.Enabled = 1;
         AssignProp("", false, chkavUseabsoluteurlbyenvironment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUseabsoluteurlbyenvironment.Enabled), 5, 0), true);
         edtavHomeobject_Enabled = 1;
         AssignProp("", false, edtavHomeobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomeobject_Enabled), 5, 0), true);
         edtavLogoutobject_Enabled = 1;
         AssignProp("", false, edtavLogoutobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLogoutobject_Enabled), 5, 0), true);
         cmbavMainmenu.Enabled = 1;
         AssignProp("", false, cmbavMainmenu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMainmenu.Enabled), 5, 0), true);
         AV30GUID = "";
         AssignAttri("", false, "AV30GUID", AV30GUID);
         AV37Name = "";
         AssignAttri("", false, "AV37Name", AV37Name);
         AV20Dsc = "";
         AssignAttri("", false, "AV20Dsc", AV20Dsc);
         AV42Version = "";
         AssignAttri("", false, "AV42Version", AV42Version);
         AV19Copyright = "";
         AssignAttri("", false, "AV19Copyright", AV19Copyright);
         AV18Company = "";
         AssignAttri("", false, "AV18Company", AV18Company);
         AV5AccessRequiresPermission = true;
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         AV14ClientId = "";
         AssignAttri("", false, "AV14ClientId", AV14ClientId);
         AV17ClientSecret = "";
         AssignAttri("", false, "AV17ClientSecret", AV17ClientSecret);
         AV53ClientAccessUniqueByUser = true;
         AssignAttri("", false, "AV53ClientAccessUniqueByUser", AV53ClientAccessUniqueByUser);
         edtavEnvironmentname_Enabled = 1;
         AssignProp("", false, edtavEnvironmentname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentname_Enabled), 5, 0), true);
         chkavEnvironmentsecurityprotocol.Enabled = 1;
         AssignProp("", false, chkavEnvironmentsecurityprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnvironmentsecurityprotocol.Enabled), 5, 0), true);
         edtavEnvironmenthost_Enabled = 1;
         AssignProp("", false, edtavEnvironmenthost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmenthost_Enabled), 5, 0), true);
         edtavEnvironmentport_Enabled = 1;
         AssignProp("", false, edtavEnvironmentport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentport_Enabled), 5, 0), true);
         edtavEnvironmentvirtualdirectory_Enabled = 1;
         AssignProp("", false, edtavEnvironmentvirtualdirectory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentvirtualdirectory_Enabled), 5, 0), true);
         edtavEnvironmentprogrampackage_Enabled = 1;
         AssignProp("", false, edtavEnvironmentprogrampackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogrampackage_Enabled), 5, 0), true);
         edtavEnvironmentprogramextension_Enabled = 1;
         AssignProp("", false, edtavEnvironmentprogramextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogramextension_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV8Application.load( AV33Id);
            AV33Id = AV8Application.gxTpr_Id;
            AssignAttri("", false, "AV33Id", StringUtil.LTrimStr( (decimal)(AV33Id), 12, 0));
            AV30GUID = StringUtil.Trim( AV8Application.gxTpr_Guid);
            AssignAttri("", false, "AV30GUID", AV30GUID);
            AV37Name = StringUtil.Trim( AV8Application.gxTpr_Name);
            AssignAttri("", false, "AV37Name", AV37Name);
            AV20Dsc = StringUtil.Trim( AV8Application.gxTpr_Description);
            AssignAttri("", false, "AV20Dsc", AV20Dsc);
            AV42Version = StringUtil.Trim( AV8Application.gxTpr_Version);
            AssignAttri("", false, "AV42Version", AV42Version);
            AV19Copyright = StringUtil.Trim( AV8Application.gxTpr_Copyright);
            AssignAttri("", false, "AV19Copyright", AV19Copyright);
            AV18Company = StringUtil.Trim( AV8Application.gxTpr_Companyname);
            AssignAttri("", false, "AV18Company", AV18Company);
            AV5AccessRequiresPermission = AV8Application.gxTpr_Accessrequirespermission;
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            AV14ClientId = StringUtil.Trim( AV8Application.gxTpr_Clientid);
            AssignAttri("", false, "AV14ClientId", AV14ClientId);
            AV17ClientSecret = StringUtil.Trim( AV8Application.gxTpr_Clientsecret);
            AssignAttri("", false, "AV17ClientSecret", AV17ClientSecret);
            AV53ClientAccessUniqueByUser = AV8Application.gxTpr_Clientaccessuniquebyuser;
            AssignAttri("", false, "AV53ClientAccessUniqueByUser", AV53ClientAccessUniqueByUser);
            AV40UseAbsoluteUrlByEnvironment = AV8Application.gxTpr_Useabsoluteurlbyenvironment;
            AssignAttri("", false, "AV40UseAbsoluteUrlByEnvironment", AV40UseAbsoluteUrlByEnvironment);
            AV31HomeObject = AV8Application.gxTpr_Homeobject;
            AssignAttri("", false, "AV31HomeObject", AV31HomeObject);
            AV34LogoutObject = AV8Application.gxTpr_Logoutobject;
            AssignAttri("", false, "AV34LogoutObject", AV34LogoutObject);
            AV70GXV2 = 1;
            AV69GXV1 = AV8Application.getmenus(AV45MenuFilter, out  AV29Errors);
            while ( AV70GXV2 <= AV69GXV1.Count )
            {
               AV44Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV69GXV1.Item(AV70GXV2));
               cmbavMainmenu.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV44Menu.gxTpr_Id), 12, 0)), AV44Menu.gxTpr_Name, 0);
               AV70GXV2 = (int)(AV70GXV2+1);
            }
            AV35MainMenu = AV8Application.gxTpr_Mainmenuid;
            AssignAttri("", false, "AV35MainMenu", StringUtil.LTrimStr( (decimal)(AV35MainMenu), 12, 0));
            AV52ClientRevoked = AV8Application.gxTpr_Clientrevoked;
            AssignAttri("", false, "AV52ClientRevoked", context.localUtil.TToC( AV52ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            AV11ClientAllowRemoteAuth = AV8Application.gxTpr_Clientallowremoteauthentication;
            AssignAttri("", false, "AV11ClientAllowRemoteAuth", AV11ClientAllowRemoteAuth);
            AV10ClientAllowGetUserRoles = AV8Application.gxTpr_Clientallowgetuserroles;
            AssignAttri("", false, "AV10ClientAllowGetUserRoles", AV10ClientAllowGetUserRoles);
            AV9ClientAllowGetUserAddData = AV8Application.gxTpr_Clientallowgetuseradditionaldata;
            AssignAttri("", false, "AV9ClientAllowGetUserAddData", AV9ClientAllowGetUserAddData);
            AV16ClientLocalLoginURL = AV8Application.gxTpr_Clientlocalloginurl;
            AssignAttri("", false, "AV16ClientLocalLoginURL", AV16ClientLocalLoginURL);
            AV12ClientCallbackURL = AV8Application.gxTpr_Clientcallbackurl;
            AssignAttri("", false, "AV12ClientCallbackURL", AV12ClientCallbackURL);
            AV15ClientImageURL = AV8Application.gxTpr_Clientimageurl;
            AssignAttri("", false, "AV15ClientImageURL", AV15ClientImageURL);
            AV13ClientEncryptionKey = AV8Application.gxTpr_Clientencryptionkey;
            AssignAttri("", false, "AV13ClientEncryptionKey", AV13ClientEncryptionKey);
            AV46ClientRepositoryGUID = AV8Application.gxTpr_Clientrepositoryguid;
            AssignAttri("", false, "AV46ClientRepositoryGUID", AV46ClientRepositoryGUID);
            AV51ClientAllowGetSessionIniProp = AV8Application.gxTpr_Clientallowgetsessioninitialproperties;
            AssignAttri("", false, "AV51ClientAllowGetSessionIniProp", AV51ClientAllowGetSessionIniProp);
            AV22EnvironmentName = AV8Application.gxTpr_Environment.gxTpr_Name;
            AssignAttri("", false, "AV22EnvironmentName", AV22EnvironmentName);
            AV26EnvironmentSecurityProtocol = AV8Application.gxTpr_Environment.gxTpr_Secureprotocol;
            AssignAttri("", false, "AV26EnvironmentSecurityProtocol", AV26EnvironmentSecurityProtocol);
            AV21EnvironmentHost = AV8Application.gxTpr_Environment.gxTpr_Host;
            AssignAttri("", false, "AV21EnvironmentHost", AV21EnvironmentHost);
            AV23EnvironmentPort = AV8Application.gxTpr_Environment.gxTpr_Port;
            AssignAttri("", false, "AV23EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV23EnvironmentPort), 5, 0));
            AV27EnvironmentVirtualDirectory = AV8Application.gxTpr_Environment.gxTpr_Virtualdirectory;
            AssignAttri("", false, "AV27EnvironmentVirtualDirectory", AV27EnvironmentVirtualDirectory);
            AV25EnvironmentProgramPackage = AV8Application.gxTpr_Environment.gxTpr_Programpackage;
            AssignAttri("", false, "AV25EnvironmentProgramPackage", AV25EnvironmentProgramPackage);
            AV24EnvironmentProgramExtension = AV8Application.gxTpr_Environment.gxTpr_Programextension;
            AssignAttri("", false, "AV24EnvironmentProgramExtension", AV24EnvironmentProgramExtension);
            AV47ClientAllowRemoteRestAuth = AV8Application.gxTpr_Clientallowremoterestauthentication;
            AssignAttri("", false, "AV47ClientAllowRemoteRestAuth", AV47ClientAllowRemoteRestAuth);
            AV48ClientAllowGetUserRolesRest = AV8Application.gxTpr_Clientallowgetuserrolesrest;
            AssignAttri("", false, "AV48ClientAllowGetUserRolesRest", AV48ClientAllowGetUserRolesRest);
            AV49ClientAllowGetUserAddDataRest = AV8Application.gxTpr_Clientallowgetuseradditionaldatarest;
            AssignAttri("", false, "AV49ClientAllowGetUserAddDataRest", AV49ClientAllowGetUserAddDataRest);
            AV50ClientAllowGetSessionIniPropRest = AV8Application.gxTpr_Clientallowgetsessioninitialpropertiesrest;
            AssignAttri("", false, "AV50ClientAllowGetSessionIniPropRest", AV50ClientAllowGetSessionIniPropRest);
            AV59SSORestEnable = AV8Application.gxTpr_Ssorestenable;
            AssignAttri("", false, "AV59SSORestEnable", AV59SSORestEnable);
            AV60SSORestMode = AV8Application.gxTpr_Ssorestmode;
            AssignAttri("", false, "AV60SSORestMode", AV60SSORestMode);
            AV61SSORestUserAuthTypeName = AV8Application.gxTpr_Ssorestuserauthenticationtypename;
            AssignAttri("", false, "AV61SSORestUserAuthTypeName", AV61SSORestUserAuthTypeName);
            AV54SSORestServerURL = AV8Application.gxTpr_Ssorestserverurl;
            AssignAttri("", false, "AV54SSORestServerURL", AV54SSORestServerURL);
            AV62STSProtocolEnable = AV8Application.gxTpr_Stsprotocolenable;
            AssignAttri("", false, "AV62STSProtocolEnable", AV62STSProtocolEnable);
            AV55GAMUser.load( AV8Application.gxTpr_Stsauthorizationuserguid);
            AV64STSAuthorizationUserName = AV55GAMUser.gxTpr_Name;
            AssignAttri("", false, "AV64STSAuthorizationUserName", AV64STSAuthorizationUserName);
            AV63STSMode = AV8Application.gxTpr_Stsmode;
            AssignAttri("", false, "AV63STSMode", AV63STSMode);
            AV56STSServerURL = AV8Application.gxTpr_Stsserverurl;
            AssignAttri("", false, "AV56STSServerURL", AV56STSServerURL);
            AV65STSServerClientPassword = AV8Application.gxTpr_Stsserverclientpassword;
            AssignAttri("", false, "AV65STSServerClientPassword", AV65STSServerClientPassword);
            AV57STSServerRepositoryGUID = AV8Application.gxTpr_Stsserverrepositoryguid;
            AssignAttri("", false, "AV57STSServerRepositoryGUID", AV57STSServerRepositoryGUID);
            AV22EnvironmentName = AV8Application.gxTpr_Environment.gxTpr_Name;
            AssignAttri("", false, "AV22EnvironmentName", AV22EnvironmentName);
            AV26EnvironmentSecurityProtocol = AV8Application.gxTpr_Environment.gxTpr_Secureprotocol;
            AssignAttri("", false, "AV26EnvironmentSecurityProtocol", AV26EnvironmentSecurityProtocol);
            AV21EnvironmentHost = AV8Application.gxTpr_Environment.gxTpr_Host;
            AssignAttri("", false, "AV21EnvironmentHost", AV21EnvironmentHost);
            AV23EnvironmentPort = AV8Application.gxTpr_Environment.gxTpr_Port;
            AssignAttri("", false, "AV23EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV23EnvironmentPort), 5, 0));
            AV27EnvironmentVirtualDirectory = AV8Application.gxTpr_Environment.gxTpr_Virtualdirectory;
            AssignAttri("", false, "AV27EnvironmentVirtualDirectory", AV27EnvironmentVirtualDirectory);
            AV25EnvironmentProgramPackage = AV8Application.gxTpr_Environment.gxTpr_Programpackage;
            AssignAttri("", false, "AV25EnvironmentProgramPackage", AV25EnvironmentProgramPackage);
            AV24EnvironmentProgramExtension = AV8Application.gxTpr_Environment.gxTpr_Programextension;
            AssignAttri("", false, "AV24EnvironmentProgramExtension", AV24EnvironmentProgramExtension);
            if ( (DateTime.MinValue==AV8Application.gxTpr_Clientrevoked) )
            {
               bttRevoke_Caption = "Revoke";
               AssignProp("", false, bttRevoke_Internalname, "Caption", bttRevoke_Caption, true);
            }
            else
            {
               bttRevoke_Caption = "Authorize";
               AssignProp("", false, bttRevoke_Internalname, "Caption", bttRevoke_Caption, true);
            }
         }
         else
         {
            divResponsivetable_mainattributes_permissions_Visible = 0;
            AssignProp("", false, divResponsivetable_mainattributes_permissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_permissions_Visible), 5, 0), true);
            divResponsivetable_mainattributes_menus_Visible = 0;
            AssignProp("", false, divResponsivetable_mainattributes_menus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_menus_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'REFRESHREMOTEAUTHENTICATION' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'REFRESHREMOTERESTAUTHENTICATION' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'REFRESHSSOREST' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'REFRESHSTS' */
         S212 ();
         if (returnInSub) return;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E123U2 ();
         if (returnInSub) return;
      }

      protected void E123U2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E133U2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         imgLogoutobject_var_contexthelpimage_Tooltiptext = "Especifique un objeto o una url";
         AssignProp("", false, imgLogoutobject_var_contexthelpimage_Internalname, "Tooltiptext", imgLogoutobject_var_contexthelpimage_Tooltiptext, true);
         imgUpdate_Bitmap = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, imgUpdate_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgUpdate_Bitmap)), true);
         AssignProp("", false, imgUpdate_Internalname, "SrcSet", context.GetImageSrcSet( imgUpdate_Bitmap), true);
         imgUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, imgUpdate_Internalname, "Tooltiptext", imgUpdate_Tooltiptext, true);
         imgDelete_Bitmap = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, imgDelete_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgDelete_Bitmap)), true);
         AssignProp("", false, imgDelete_Internalname, "SrcSet", context.GetImageSrcSet( imgDelete_Bitmap), true);
         imgDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, imgDelete_Internalname, "Tooltiptext", imgDelete_Tooltiptext, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Application", AV8Application);
         cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0));
         AssignProp("", false, cmbavMainmenu_Internalname, "Values", cmbavMainmenu.ToJavascriptSource(), true);
         cmbavSsorestmode.CurrentValue = StringUtil.RTrim( AV60SSORestMode);
         AssignProp("", false, cmbavSsorestmode_Internalname, "Values", cmbavSsorestmode.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55GAMUser", AV55GAMUser);
         cmbavStsmode.CurrentValue = StringUtil.RTrim( AV63STSMode);
         AssignProp("", false, cmbavStsmode_Internalname, "Values", cmbavStsmode.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Permissionswc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Permissionswc_Component), StringUtil.Lower( "K2BFSG.WWApplicationPermission")) != 0 )
            {
               WebComp_Permissionswc = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wwapplicationpermission", new Object[] {context} );
               WebComp_Permissionswc.ComponentInit();
               WebComp_Permissionswc.Name = "K2BFSG.WWApplicationPermission";
               WebComp_Permissionswc_Component = "K2BFSG.WWApplicationPermission";
            }
            if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
            {
               WebComp_Permissionswc.setjustcreated();
               WebComp_Permissionswc.componentprepare(new Object[] {(string)"W0395",(string)"",(long)AV33Id});
               WebComp_Permissionswc.componentbind(new Object[] {(string)"vID"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Permissionswc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0395"+"");
               WebComp_Permissionswc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Menuswc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Menuswc_Component), StringUtil.Lower( "K2BFSG.ApplicationMenuWC")) != 0 )
            {
               WebComp_Menuswc = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.applicationmenuwc", new Object[] {context} );
               WebComp_Menuswc.ComponentInit();
               WebComp_Menuswc.Name = "K2BFSG.ApplicationMenuWC";
               WebComp_Menuswc_Component = "K2BFSG.ApplicationMenuWC";
            }
            if ( StringUtil.Len( WebComp_Menuswc_Component) != 0 )
            {
               WebComp_Menuswc.setjustcreated();
               WebComp_Menuswc.componentprepare(new Object[] {(string)"W0417",(string)"",(long)AV33Id});
               WebComp_Menuswc.componentbind(new Object[] {(string)"vID"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Menuswc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0417"+"");
               WebComp_Menuswc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttConfirm_Visible = 0;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttConfirm_Enabled = 0;
            AssignProp("", false, bttConfirm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirm_Enabled), 5, 0), true);
            bttCancel_Visible = 0;
            AssignProp("", false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
            bttCancel_Enabled = 0;
            AssignProp("", false, bttCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttCancel_Enabled), 5, 0), true);
            imgUpdate_Visible = 1;
            AssignProp("", false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgUpdate_Enabled = 1;
            AssignProp("", false, imgUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgUpdate_Enabled), 5, 0), true);
            imgDelete_Visible = 1;
            AssignProp("", false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            imgDelete_Enabled = 1;
            AssignProp("", false, imgDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDelete_Enabled), 5, 0), true);
            bttGeneratekey_Visible = 0;
            AssignProp("", false, bttGeneratekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Visible), 5, 0), true);
            bttGeneratekey_Enabled = 0;
            AssignProp("", false, bttGeneratekey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Enabled), 5, 0), true);
         }
         else
         {
            bttConfirm_Visible = 1;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttConfirm_Enabled = 1;
            AssignProp("", false, bttConfirm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirm_Enabled), 5, 0), true);
            bttCancel_Visible = 1;
            AssignProp("", false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
            bttCancel_Enabled = 1;
            AssignProp("", false, bttCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttCancel_Enabled), 5, 0), true);
            bttGeneratekey_Visible = 1;
            AssignProp("", false, bttGeneratekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Visible), 5, 0), true);
            bttGeneratekey_Enabled = 1;
            AssignProp("", false, bttGeneratekey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Enabled), 5, 0), true);
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               bttConfirm_Caption = "Eliminar";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               bttConfirm_Caption = "Actualizar";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               bttConfirm_Caption = "Agregar";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            imgUpdate_Visible = 0;
            AssignProp("", false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgUpdate_Enabled = 0;
            AssignProp("", false, imgUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgUpdate_Enabled), 5, 0), true);
            imgDelete_Visible = 0;
            AssignProp("", false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            imgDelete_Enabled = 0;
            AssignProp("", false, imgDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDelete_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavGuid_Enabled = 0;
            AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavVersion_Enabled = 0;
            AssignProp("", false, edtavVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVersion_Enabled), 5, 0), true);
            edtavCopyright_Enabled = 0;
            AssignProp("", false, edtavCopyright_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCopyright_Enabled), 5, 0), true);
            edtavCompany_Enabled = 0;
            AssignProp("", false, edtavCompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCompany_Enabled), 5, 0), true);
            chkavAccessrequirespermission.Enabled = 0;
            AssignProp("", false, chkavAccessrequirespermission_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAccessrequirespermission.Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp("", false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            chkavClientaccessuniquebyuser.Enabled = 0;
            AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientaccessuniquebyuser.Enabled), 5, 0), true);
            edtavClientrevoked_Enabled = 0;
            AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
            chkavClientallowremoteauth.Enabled = 0;
            AssignProp("", false, chkavClientallowremoteauth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowremoteauth.Enabled), 5, 0), true);
            chkavClientallowgetuserroles.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserroles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserroles.Enabled), 5, 0), true);
            chkavClientallowgetuseradddata.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddata.Enabled), 5, 0), true);
            edtavClientlocalloginurl_Enabled = 0;
            AssignProp("", false, edtavClientlocalloginurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientlocalloginurl_Enabled), 5, 0), true);
            edtavClientcallbackurl_Enabled = 0;
            AssignProp("", false, edtavClientcallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurl_Enabled), 5, 0), true);
            edtavClientimageurl_Enabled = 0;
            AssignProp("", false, edtavClientimageurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientimageurl_Enabled), 5, 0), true);
            edtavClientencryptionkey_Enabled = 0;
            AssignProp("", false, edtavClientencryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Enabled), 5, 0), true);
            chkavClientallowgetsessioniniprop.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessioniniprop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessioniniprop.Enabled), 5, 0), true);
            edtavClientrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Enabled), 5, 0), true);
            chkavSsorestenable.Enabled = 0;
            AssignProp("", false, chkavSsorestenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSsorestenable.Enabled), 5, 0), true);
            cmbavSsorestmode.Enabled = 0;
            AssignProp("", false, cmbavSsorestmode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSsorestmode.Enabled), 5, 0), true);
            edtavSsorestuserauthtypename_Enabled = 0;
            AssignProp("", false, edtavSsorestuserauthtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestuserauthtypename_Enabled), 5, 0), true);
            edtavSsorestserverurl_Enabled = 0;
            AssignProp("", false, edtavSsorestserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestserverurl_Enabled), 5, 0), true);
            chkavUseabsoluteurlbyenvironment.Enabled = 0;
            AssignProp("", false, chkavUseabsoluteurlbyenvironment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUseabsoluteurlbyenvironment.Enabled), 5, 0), true);
            edtavHomeobject_Enabled = 0;
            AssignProp("", false, edtavHomeobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomeobject_Enabled), 5, 0), true);
            edtavLogoutobject_Enabled = 0;
            AssignProp("", false, edtavLogoutobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLogoutobject_Enabled), 5, 0), true);
            cmbavMainmenu.Enabled = 0;
            AssignProp("", false, cmbavMainmenu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMainmenu.Enabled), 5, 0), true);
            edtavEnvironmentname_Enabled = 0;
            AssignProp("", false, edtavEnvironmentname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentname_Enabled), 5, 0), true);
            chkavEnvironmentsecurityprotocol.Enabled = 0;
            AssignProp("", false, chkavEnvironmentsecurityprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnvironmentsecurityprotocol.Enabled), 5, 0), true);
            edtavEnvironmenthost_Enabled = 0;
            AssignProp("", false, edtavEnvironmenthost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmenthost_Enabled), 5, 0), true);
            edtavEnvironmentport_Enabled = 0;
            AssignProp("", false, edtavEnvironmentport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentport_Enabled), 5, 0), true);
            edtavEnvironmentvirtualdirectory_Enabled = 0;
            AssignProp("", false, edtavEnvironmentvirtualdirectory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentvirtualdirectory_Enabled), 5, 0), true);
            edtavEnvironmentprogrampackage_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogrampackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogrampackage_Enabled), 5, 0), true);
            edtavEnvironmentprogramextension_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogramextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogramextension_Enabled), 5, 0), true);
            chkavClientallowremoterestauth.Enabled = 0;
            AssignProp("", false, chkavClientallowremoterestauth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowremoterestauth.Enabled), 5, 0), true);
            chkavClientallowgetuserrolesrest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserrolesrest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserrolesrest.Enabled), 5, 0), true);
            chkavClientallowgetuseradddatarest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuseradddatarest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddatarest.Enabled), 5, 0), true);
            chkavClientallowgetsessioniniproprest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessioniniproprest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessioniniproprest.Enabled), 5, 0), true);
            chkavStsprotocolenable.Enabled = 0;
            AssignProp("", false, chkavStsprotocolenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavStsprotocolenable.Enabled), 5, 0), true);
            edtavStsauthorizationusername_Enabled = 0;
            AssignProp("", false, edtavStsauthorizationusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsauthorizationusername_Enabled), 5, 0), true);
            cmbavStsmode.Enabled = 0;
            AssignProp("", false, cmbavStsmode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStsmode.Enabled), 5, 0), true);
            edtavStsserverurl_Enabled = 0;
            AssignProp("", false, edtavStsserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverurl_Enabled), 5, 0), true);
            edtavStsserverclientpassword_Enabled = 0;
            AssignProp("", false, edtavStsserverclientpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverclientpassword_Enabled), 5, 0), true);
            edtavStsserverrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavStsserverrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverrepositoryguid_Enabled), 5, 0), true);
            edtavStsauthorizationuserguid_Enabled = 0;
            AssignProp("", false, edtavStsauthorizationuserguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsauthorizationuserguid_Enabled), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV8Application.load( AV33Id);
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               AV8Application.gxTpr_Name = AV37Name;
               AV8Application.gxTpr_Description = AV20Dsc;
               AV8Application.gxTpr_Version = AV42Version;
               AV8Application.gxTpr_Copyright = AV19Copyright;
               AV8Application.gxTpr_Companyname = AV18Company;
               AV8Application.gxTpr_Useabsoluteurlbyenvironment = AV40UseAbsoluteUrlByEnvironment;
               AV8Application.gxTpr_Homeobject = AV31HomeObject;
               AV8Application.gxTpr_Logoutobject = AV34LogoutObject;
               AV8Application.gxTpr_Mainmenuid = AV35MainMenu;
               AV8Application.gxTpr_Accessrequirespermission = AV5AccessRequiresPermission;
               AV8Application.gxTpr_Clientid = AV14ClientId;
               AV8Application.gxTpr_Clientsecret = AV17ClientSecret;
               AV8Application.gxTpr_Clientaccessuniquebyuser = AV53ClientAccessUniqueByUser;
               AV8Application.gxTpr_Clientallowremoteauthentication = AV11ClientAllowRemoteAuth;
               AV8Application.gxTpr_Clientallowgetuserroles = AV10ClientAllowGetUserRoles;
               AV8Application.gxTpr_Clientallowgetuseradditionaldata = AV9ClientAllowGetUserAddData;
               AV8Application.gxTpr_Clientallowgetsessioninitialproperties = AV51ClientAllowGetSessionIniProp;
               AV8Application.gxTpr_Clientlocalloginurl = AV16ClientLocalLoginURL;
               AV8Application.gxTpr_Clientcallbackurl = AV12ClientCallbackURL;
               AV8Application.gxTpr_Clientimageurl = AV15ClientImageURL;
               AV8Application.gxTpr_Clientallowremoterestauthentication = AV47ClientAllowRemoteRestAuth;
               AV8Application.gxTpr_Clientallowgetuserrolesrest = AV48ClientAllowGetUserRolesRest;
               AV8Application.gxTpr_Clientallowgetuseradditionaldatarest = AV49ClientAllowGetUserAddDataRest;
               AV8Application.gxTpr_Clientallowgetsessioninitialpropertiesrest = AV50ClientAllowGetSessionIniPropRest;
               AV8Application.gxTpr_Clientencryptionkey = AV13ClientEncryptionKey;
               AV8Application.gxTpr_Clientrepositoryguid = AV46ClientRepositoryGUID;
               AV8Application.gxTpr_Ssorestenable = AV59SSORestEnable;
               AV8Application.gxTpr_Ssorestmode = AV60SSORestMode;
               AV8Application.gxTpr_Ssorestuserauthenticationtypename = AV61SSORestUserAuthTypeName;
               AV8Application.gxTpr_Ssorestserverurl = AV54SSORestServerURL;
               AV8Application.gxTpr_Stsprotocolenable = AV62STSProtocolEnable;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64STSAuthorizationUserName)) )
               {
                  AV55GAMUser = AV55GAMUser.getbylogin("local", AV64STSAuthorizationUserName, out  AV29Errors);
                  AV58STSAuthorizationUserGUID = AV55GAMUser.gxTpr_Guid;
                  AssignAttri("", false, "AV58STSAuthorizationUserGUID", AV58STSAuthorizationUserGUID);
               }
               AV8Application.gxTpr_Stsauthorizationuserguid = AV58STSAuthorizationUserGUID;
               AV8Application.gxTpr_Stsmode = AV63STSMode;
               AV8Application.gxTpr_Stsserverurl = AV56STSServerURL;
               AV8Application.gxTpr_Stsserverclientpassword = AV65STSServerClientPassword;
               AV8Application.gxTpr_Stsserverrepositoryguid = AV57STSServerRepositoryGUID;
               AV8Application.gxTpr_Environment.gxTpr_Name = AV22EnvironmentName;
               AV8Application.gxTpr_Environment.gxTpr_Secureprotocol = AV26EnvironmentSecurityProtocol;
               AV8Application.gxTpr_Environment.gxTpr_Host = AV21EnvironmentHost;
               AV8Application.gxTpr_Environment.gxTpr_Port = AV23EnvironmentPort;
               AV8Application.gxTpr_Environment.gxTpr_Virtualdirectory = AV27EnvironmentVirtualDirectory;
               AV8Application.gxTpr_Environment.gxTpr_Programpackage = AV25EnvironmentProgramPackage;
               AV8Application.gxTpr_Environment.gxTpr_Programextension = AV24EnvironmentProgramExtension;
               AV8Application.save();
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV8Application.delete();
            }
            if ( AV8Application.success() )
            {
               context.CommitDataStores("k2bfsg.entryapplication",pr_default);
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV36Message.gxTpr_Description = StringUtil.Format( "La aplicación %1 fue creada", AV8Application.gxTpr_Name, "", "", "", "", "", "", "", "");
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     AV36Message.gxTpr_Description = StringUtil.Format( "La aplicación %1 fue actualizada", AV8Application.gxTpr_Name, "", "", "", "", "", "", "", "");
                  }
                  else
                  {
                     AV36Message.gxTpr_Description = StringUtil.Format( "La aplicación %1 fue borrada", AV37Name, "", "", "", "", "", "", "", "");
                  }
               }
               new k2btoolsmessagequeueadd(context ).execute(  AV36Message) ;
               CallWebObject(formatLink("k2bfsg.wwapplication.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV29Errors = AV8Application.geterrors();
               /* Execute user subroutine: 'ERRORES' */
               S262 ();
               if (returnInSub) return;
            }
         }
      }

      protected void S262( )
      {
         /* 'ERRORES' Routine */
         returnInSub = false;
         if ( AV29Errors.Count > 0 )
         {
            AV71GXV3 = 1;
            while ( AV71GXV3 <= AV29Errors.Count )
            {
               AV28Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(AV71GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV28Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV28Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV71GXV3 = (int)(AV71GXV3+1);
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E143U2 ();
         if (returnInSub) return;
      }

      protected void E143U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Application", AV8Application);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55GAMUser", AV55GAMUser);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Message", AV36Message);
      }

      protected void S152( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryapplication.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV33Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S162( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryapplication.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV33Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwapplication.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E213U2( )
      {
         /* Clientallowremoteauth_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'REFRESHREMOTEAUTHENTICATION' */
            S182 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'REFRESHREMOTEAUTHENTICATION' Routine */
         returnInSub = false;
         if ( AV11ClientAllowRemoteAuth )
         {
            grpRemoteauthenticationcontent_Class = "Group_Tabular";
            AssignProp("", false, grpRemoteauthenticationcontent_Internalname, "Class", grpRemoteauthenticationcontent_Class, true);
         }
         else
         {
            grpRemoteauthenticationcontent_Class = "K2BToolsFSGAM_Group_Tabular_Invisible";
            AssignProp("", false, grpRemoteauthenticationcontent_Internalname, "Class", grpRemoteauthenticationcontent_Class, true);
         }
      }

      protected void E223U2( )
      {
         /* Clientallowremoterestauth_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'REFRESHREMOTERESTAUTHENTICATION' */
            S192 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'REFRESHREMOTERESTAUTHENTICATION' Routine */
         returnInSub = false;
         if ( AV47ClientAllowRemoteRestAuth )
         {
            grpRemoteauthenticationcontentrest_Class = "Group_Tabular";
            AssignProp("", false, grpRemoteauthenticationcontentrest_Internalname, "Class", grpRemoteauthenticationcontentrest_Class, true);
         }
         else
         {
            grpRemoteauthenticationcontentrest_Class = "K2BToolsFSGAM_Group_Tabular_Invisible";
            AssignProp("", false, grpRemoteauthenticationcontentrest_Internalname, "Class", grpRemoteauthenticationcontentrest_Class, true);
         }
      }

      protected void E233U2( )
      {
         /* Ssorestenable_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'REFRESHSSOREST' */
            S202 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'REFRESHSSOREST' Routine */
         returnInSub = false;
         if ( AV59SSORestEnable )
         {
            grpGroupgamssorest_Class = "Group_Tabular";
            AssignProp("", false, grpGroupgamssorest_Internalname, "Class", grpGroupgamssorest_Class, true);
         }
         else
         {
            grpGroupgamssorest_Class = "K2BToolsFSGAM_Group_Tabular_Invisible";
            AssignProp("", false, grpGroupgamssorest_Internalname, "Class", grpGroupgamssorest_Class, true);
         }
      }

      protected void E243U2( )
      {
         /* Stsprotocolenable_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'REFRESHSTS' */
            S212 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'REFRESHSTS' Routine */
         returnInSub = false;
         if ( AV62STSProtocolEnable )
         {
            grpGroupsts_Class = "Group_Tabular";
            AssignProp("", false, grpGroupsts_Internalname, "Class", grpGroupsts_Class, true);
         }
         else
         {
            grpGroupsts_Class = "K2BToolsFSGAM_Group_Tabular_Invisible";
            AssignProp("", false, grpGroupsts_Internalname, "Class", grpGroupsts_Class, true);
         }
      }

      protected void E153U2( )
      {
         /* 'E_GenerateKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_GENERATEKEY' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S222( )
      {
         /* 'U_GENERATEKEY' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            AV13ClientEncryptionKey = Crypto.GetEncryptionKey( );
            AssignAttri("", false, "AV13ClientEncryptionKey", AV13ClientEncryptionKey);
         }
      }

      protected void S232( )
      {
         /* 'TOGGLECOLLAPSIBLESECTION(PERMISSIONS)' Routine */
         returnInSub = false;
         if ( divAttributescontainertable_permissions_Visible != 0 )
         {
            divAttributescontainertable_permissions_Visible = 0;
            AssignProp("", false, divAttributescontainertable_permissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAttributescontainertable_permissions_Visible), 5, 0), true);
            imgCollapsibleimage_permissions_Bitmap = context.GetImagePath( "87ba2769-8aab-4613-b833-d06fcae04609", "", context.GetTheme( ));
            AssignProp("", false, imgCollapsibleimage_permissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_permissions_Bitmap)), true);
            AssignProp("", false, imgCollapsibleimage_permissions_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_permissions_Bitmap), true);
            divResponsivetable_mainattributes_permissions_Class = "K2BToolsTable_ComponentContainer"+" "+"K2BToolsTable_CollapsedComponentContainer";
            AssignProp("", false, divResponsivetable_mainattributes_permissions_Internalname, "Class", divResponsivetable_mainattributes_permissions_Class, true);
         }
         else
         {
            divAttributescontainertable_permissions_Visible = 1;
            AssignProp("", false, divAttributescontainertable_permissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAttributescontainertable_permissions_Visible), 5, 0), true);
            imgCollapsibleimage_permissions_Bitmap = context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( ));
            AssignProp("", false, imgCollapsibleimage_permissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_permissions_Bitmap)), true);
            AssignProp("", false, imgCollapsibleimage_permissions_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_permissions_Bitmap), true);
            divResponsivetable_mainattributes_permissions_Class = "K2BToolsTable_ComponentContainer";
            AssignProp("", false, divResponsivetable_mainattributes_permissions_Internalname, "Class", divResponsivetable_mainattributes_permissions_Class, true);
         }
      }

      protected void E163U2( )
      {
         /* Textblock_attributes_permissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(PERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E173U2( )
      {
         /* Collapsibleimage_permissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(PERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S242( )
      {
         /* 'TOGGLECOLLAPSIBLESECTION(MENUS)' Routine */
         returnInSub = false;
         if ( divAttributescontainertable_menus_Visible != 0 )
         {
            divAttributescontainertable_menus_Visible = 0;
            AssignProp("", false, divAttributescontainertable_menus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAttributescontainertable_menus_Visible), 5, 0), true);
            imgCollapsibleimage_menus_Bitmap = context.GetImagePath( "87ba2769-8aab-4613-b833-d06fcae04609", "", context.GetTheme( ));
            AssignProp("", false, imgCollapsibleimage_menus_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_menus_Bitmap)), true);
            AssignProp("", false, imgCollapsibleimage_menus_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_menus_Bitmap), true);
            divResponsivetable_mainattributes_menus_Class = "K2BToolsTable_ComponentContainer"+" "+"K2BToolsTable_CollapsedComponentContainer";
            AssignProp("", false, divResponsivetable_mainattributes_menus_Internalname, "Class", divResponsivetable_mainattributes_menus_Class, true);
         }
         else
         {
            divAttributescontainertable_menus_Visible = 1;
            AssignProp("", false, divAttributescontainertable_menus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAttributescontainertable_menus_Visible), 5, 0), true);
            imgCollapsibleimage_menus_Bitmap = context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( ));
            AssignProp("", false, imgCollapsibleimage_menus_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_menus_Bitmap)), true);
            AssignProp("", false, imgCollapsibleimage_menus_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_menus_Bitmap), true);
            divResponsivetable_mainattributes_menus_Class = "K2BToolsTable_ComponentContainer";
            AssignProp("", false, divResponsivetable_mainattributes_menus_Internalname, "Class", divResponsivetable_mainattributes_menus_Class, true);
         }
      }

      protected void E183U2( )
      {
         /* Textblock_attributes_menus_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(MENUS)' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E193U2( )
      {
         /* Collapsibleimage_menus_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(MENUS)' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S252( )
      {
         /* 'U_REVOKE' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E203U2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table5_403_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTitlecontainertable_menus_Internalname, tblTitlecontainertable_menus_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_attributes_menus_Internalname, "Menús", "", "", lblTextblock_attributes_menus_Jsonclick, "'"+""+"'"+",false,"+"'"+"ETEXTBLOCK_ATTRIBUTES_MENUS.CLICK."+"'", "", "TextBlock_Subtitle", 5, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table6_408_3U2( true) ;
         }
         else
         {
            wb_table6_408_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table6_408_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_403_3U2e( true) ;
         }
         else
         {
            wb_table5_403_3U2e( false) ;
         }
      }

      protected void wb_table6_408_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCollapsibleimagecontainer_menus_Internalname, tblCollapsibleimagecontainer_menus_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 411,'',false,'',0)\"";
            ClassString = "K2BT_CollapseCardImage";
            StyleString = "";
            sImgUrl = imgCollapsibleimage_menus_Bitmap;
            GxWebStd.gx_bitmap( context, imgCollapsibleimage_menus_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgCollapsibleimage_menus_Jsonclick, "'"+""+"'"+",false,"+"'"+"ECOLLAPSIBLEIMAGE_MENUS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_408_3U2e( true) ;
         }
         else
         {
            wb_table6_408_3U2e( false) ;
         }
      }

      protected void wb_table4_381_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTitlecontainertable_permissions_Internalname, tblTitlecontainertable_permissions_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_attributes_permissions_Internalname, "Permisos", "", "", lblTextblock_attributes_permissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"ETEXTBLOCK_ATTRIBUTES_PERMISSIONS.CLICK."+"'", "", "TextBlock_Subtitle", 5, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table7_386_3U2( true) ;
         }
         else
         {
            wb_table7_386_3U2( false) ;
         }
         return  ;
      }

      protected void wb_table7_386_3U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_381_3U2e( true) ;
         }
         else
         {
            wb_table4_381_3U2e( false) ;
         }
      }

      protected void wb_table7_386_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCollapsibleimagecontainer_permissions_Internalname, tblCollapsibleimagecontainer_permissions_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 389,'',false,'',0)\"";
            ClassString = "K2BT_CollapseCardImage";
            StyleString = "";
            sImgUrl = imgCollapsibleimage_permissions_Bitmap;
            GxWebStd.gx_bitmap( context, imgCollapsibleimage_permissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgCollapsibleimage_permissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"ECOLLAPSIBLEIMAGE_PERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_386_3U2e( true) ;
         }
         else
         {
            wb_table7_386_3U2e( false) ;
         }
      }

      protected void wb_table3_364_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 367,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 369,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e253u1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_364_3U2e( true) ;
         }
         else
         {
            wb_table3_364_3U2e( false) ;
         }
      }

      protected void wb_table2_31_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableright_actions2_Internalname, tblActionscontainertableright_actions2_Internalname, "", "K2BTableActionsRightContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e263u1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e273u1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_31_3U2e( true) ;
         }
         else
         {
            wb_table2_31_3U2e( false) ;
         }
      }

      protected void wb_table1_19_3U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTitlecontainertable_attributes_Internalname, tblTitlecontainertable_attributes_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_attributes_attributes_Internalname, "General", "", "", lblTextblock_attributes_attributes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryApplication.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_19_3U2e( true) ;
         }
         else
         {
            wb_table1_19_3U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV33Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV33Id", StringUtil.LTrimStr( (decimal)(AV33Id), 12, 0));
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
         PA3U2( ) ;
         WS3U2( ) ;
         WE3U2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Permissionswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
            {
               WebComp_Permissionswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Menuswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Menuswc_Component) != 0 )
            {
               WebComp_Menuswc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249551410", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryapplication.js", "?20231249551412", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavUseabsoluteurlbyenvironment.Name = "vUSEABSOLUTEURLBYENVIRONMENT";
         chkavUseabsoluteurlbyenvironment.WebTags = "";
         chkavUseabsoluteurlbyenvironment.Caption = "";
         AssignProp("", false, chkavUseabsoluteurlbyenvironment_Internalname, "TitleCaption", chkavUseabsoluteurlbyenvironment.Caption, true);
         chkavUseabsoluteurlbyenvironment.CheckedValue = "false";
         AV40UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UseAbsoluteUrlByEnvironment));
         AssignAttri("", false, "AV40UseAbsoluteUrlByEnvironment", AV40UseAbsoluteUrlByEnvironment);
         cmbavMainmenu.Name = "vMAINMENU";
         cmbavMainmenu.WebTags = "";
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV35MainMenu = (long)(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV35MainMenu), 12, 0))), "."));
            AssignAttri("", false, "AV35MainMenu", StringUtil.LTrimStr( (decimal)(AV35MainMenu), 12, 0));
         }
         chkavAccessrequirespermission.Name = "vACCESSREQUIRESPERMISSION";
         chkavAccessrequirespermission.WebTags = "";
         chkavAccessrequirespermission.Caption = "";
         AssignProp("", false, chkavAccessrequirespermission_Internalname, "TitleCaption", chkavAccessrequirespermission.Caption, true);
         chkavAccessrequirespermission.CheckedValue = "false";
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         chkavClientallowremoteauth.Name = "vCLIENTALLOWREMOTEAUTH";
         chkavClientallowremoteauth.WebTags = "";
         chkavClientallowremoteauth.Caption = "";
         AssignProp("", false, chkavClientallowremoteauth_Internalname, "TitleCaption", chkavClientallowremoteauth.Caption, true);
         chkavClientallowremoteauth.CheckedValue = "false";
         AV11ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV11ClientAllowRemoteAuth));
         AssignAttri("", false, "AV11ClientAllowRemoteAuth", AV11ClientAllowRemoteAuth);
         chkavClientallowgetuserroles.Name = "vCLIENTALLOWGETUSERROLES";
         chkavClientallowgetuserroles.WebTags = "";
         chkavClientallowgetuserroles.Caption = "";
         AssignProp("", false, chkavClientallowgetuserroles_Internalname, "TitleCaption", chkavClientallowgetuserroles.Caption, true);
         chkavClientallowgetuserroles.CheckedValue = "false";
         AV10ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ClientAllowGetUserRoles));
         AssignAttri("", false, "AV10ClientAllowGetUserRoles", AV10ClientAllowGetUserRoles);
         chkavClientallowgetuseradddata.Name = "vCLIENTALLOWGETUSERADDDATA";
         chkavClientallowgetuseradddata.WebTags = "";
         chkavClientallowgetuseradddata.Caption = "";
         AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "TitleCaption", chkavClientallowgetuseradddata.Caption, true);
         chkavClientallowgetuseradddata.CheckedValue = "false";
         AV9ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ClientAllowGetUserAddData));
         AssignAttri("", false, "AV9ClientAllowGetUserAddData", AV9ClientAllowGetUserAddData);
         chkavClientallowgetsessioniniprop.Name = "vCLIENTALLOWGETSESSIONINIPROP";
         chkavClientallowgetsessioniniprop.WebTags = "";
         chkavClientallowgetsessioniniprop.Caption = "";
         AssignProp("", false, chkavClientallowgetsessioniniprop_Internalname, "TitleCaption", chkavClientallowgetsessioniniprop.Caption, true);
         chkavClientallowgetsessioniniprop.CheckedValue = "false";
         AV51ClientAllowGetSessionIniProp = StringUtil.StrToBool( StringUtil.BoolToStr( AV51ClientAllowGetSessionIniProp));
         AssignAttri("", false, "AV51ClientAllowGetSessionIniProp", AV51ClientAllowGetSessionIniProp);
         chkavClientallowremoterestauth.Name = "vCLIENTALLOWREMOTERESTAUTH";
         chkavClientallowremoterestauth.WebTags = "";
         chkavClientallowremoterestauth.Caption = "";
         AssignProp("", false, chkavClientallowremoterestauth_Internalname, "TitleCaption", chkavClientallowremoterestauth.Caption, true);
         chkavClientallowremoterestauth.CheckedValue = "false";
         AV47ClientAllowRemoteRestAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV47ClientAllowRemoteRestAuth));
         AssignAttri("", false, "AV47ClientAllowRemoteRestAuth", AV47ClientAllowRemoteRestAuth);
         chkavClientallowgetuserrolesrest.Name = "vCLIENTALLOWGETUSERROLESREST";
         chkavClientallowgetuserrolesrest.WebTags = "";
         chkavClientallowgetuserrolesrest.Caption = "";
         AssignProp("", false, chkavClientallowgetuserrolesrest_Internalname, "TitleCaption", chkavClientallowgetuserrolesrest.Caption, true);
         chkavClientallowgetuserrolesrest.CheckedValue = "false";
         AV48ClientAllowGetUserRolesRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV48ClientAllowGetUserRolesRest));
         AssignAttri("", false, "AV48ClientAllowGetUserRolesRest", AV48ClientAllowGetUserRolesRest);
         chkavClientallowgetuseradddatarest.Name = "vCLIENTALLOWGETUSERADDDATAREST";
         chkavClientallowgetuseradddatarest.WebTags = "";
         chkavClientallowgetuseradddatarest.Caption = "";
         AssignProp("", false, chkavClientallowgetuseradddatarest_Internalname, "TitleCaption", chkavClientallowgetuseradddatarest.Caption, true);
         chkavClientallowgetuseradddatarest.CheckedValue = "false";
         AV49ClientAllowGetUserAddDataRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV49ClientAllowGetUserAddDataRest));
         AssignAttri("", false, "AV49ClientAllowGetUserAddDataRest", AV49ClientAllowGetUserAddDataRest);
         chkavClientallowgetsessioniniproprest.Name = "vCLIENTALLOWGETSESSIONINIPROPREST";
         chkavClientallowgetsessioniniproprest.WebTags = "";
         chkavClientallowgetsessioniniproprest.Caption = "";
         AssignProp("", false, chkavClientallowgetsessioniniproprest_Internalname, "TitleCaption", chkavClientallowgetsessioniniproprest.Caption, true);
         chkavClientallowgetsessioniniproprest.CheckedValue = "false";
         AV50ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV50ClientAllowGetSessionIniPropRest));
         AssignAttri("", false, "AV50ClientAllowGetSessionIniPropRest", AV50ClientAllowGetSessionIniPropRest);
         chkavClientaccessuniquebyuser.Name = "vCLIENTACCESSUNIQUEBYUSER";
         chkavClientaccessuniquebyuser.WebTags = "";
         chkavClientaccessuniquebyuser.Caption = "";
         AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "TitleCaption", chkavClientaccessuniquebyuser.Caption, true);
         chkavClientaccessuniquebyuser.CheckedValue = "false";
         AV53ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV53ClientAccessUniqueByUser));
         AssignAttri("", false, "AV53ClientAccessUniqueByUser", AV53ClientAccessUniqueByUser);
         chkavSsorestenable.Name = "vSSORESTENABLE";
         chkavSsorestenable.WebTags = "";
         chkavSsorestenable.Caption = "";
         AssignProp("", false, chkavSsorestenable_Internalname, "TitleCaption", chkavSsorestenable.Caption, true);
         chkavSsorestenable.CheckedValue = "false";
         AV59SSORestEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV59SSORestEnable));
         AssignAttri("", false, "AV59SSORestEnable", AV59SSORestEnable);
         cmbavSsorestmode.Name = "vSSORESTMODE";
         cmbavSsorestmode.WebTags = "";
         cmbavSsorestmode.addItem("server", "Server", 0);
         cmbavSsorestmode.addItem("client", "Client", 0);
         if ( cmbavSsorestmode.ItemCount > 0 )
         {
            AV60SSORestMode = cmbavSsorestmode.getValidValue(AV60SSORestMode);
            AssignAttri("", false, "AV60SSORestMode", AV60SSORestMode);
         }
         chkavStsprotocolenable.Name = "vSTSPROTOCOLENABLE";
         chkavStsprotocolenable.WebTags = "";
         chkavStsprotocolenable.Caption = "";
         AssignProp("", false, chkavStsprotocolenable_Internalname, "TitleCaption", chkavStsprotocolenable.Caption, true);
         chkavStsprotocolenable.CheckedValue = "false";
         AV62STSProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV62STSProtocolEnable));
         AssignAttri("", false, "AV62STSProtocolEnable", AV62STSProtocolEnable);
         cmbavStsmode.Name = "vSTSMODE";
         cmbavStsmode.WebTags = "";
         cmbavStsmode.addItem("server", "Server", 0);
         cmbavStsmode.addItem("gettoken", "Get token", 0);
         cmbavStsmode.addItem("checktoken", "Check token", 0);
         cmbavStsmode.addItem("fulltoken", "Get and check token", 0);
         if ( cmbavStsmode.ItemCount > 0 )
         {
            AV63STSMode = cmbavStsmode.getValidValue(AV63STSMode);
            AssignAttri("", false, "AV63STSMode", AV63STSMode);
         }
         chkavEnvironmentsecurityprotocol.Name = "vENVIRONMENTSECURITYPROTOCOL";
         chkavEnvironmentsecurityprotocol.WebTags = "";
         chkavEnvironmentsecurityprotocol.Caption = "";
         AssignProp("", false, chkavEnvironmentsecurityprotocol_Internalname, "TitleCaption", chkavEnvironmentsecurityprotocol.Caption, true);
         chkavEnvironmentsecurityprotocol.CheckedValue = "false";
         AV26EnvironmentSecurityProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV26EnvironmentSecurityProtocol));
         AssignAttri("", false, "AV26EnvironmentSecurityProtocol", AV26EnvironmentSecurityProtocol);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         lblTextblock_attributes_attributes_Internalname = "TEXTBLOCK_ATTRIBUTES_ATTRIBUTES";
         tblTitlecontainertable_attributes_Internalname = "TITLECONTAINERTABLE_ATTRIBUTES";
         divTitlecell_attributes_attributes_Internalname = "TITLECELL_ATTRIBUTES_ATTRIBUTES";
         imgUpdate_Internalname = "UPDATE";
         imgDelete_Internalname = "DELETE";
         tblActionscontainertableright_actions2_Internalname = "ACTIONSCONTAINERTABLERIGHT_ACTIONS2";
         divResponsivetable_containernode_actions2_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS2";
         edtavId_Internalname = "vID";
         divTable_container_id_Internalname = "TABLE_CONTAINER_ID";
         edtavGuid_Internalname = "vGUID";
         divTable_container_guid_Internalname = "TABLE_CONTAINER_GUID";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavDsc_Internalname = "vDSC";
         divTable_container_dsc_Internalname = "TABLE_CONTAINER_DSC";
         edtavVersion_Internalname = "vVERSION";
         divTable_container_version_Internalname = "TABLE_CONTAINER_VERSION";
         edtavCompany_Internalname = "vCOMPANY";
         divTable_container_company_Internalname = "TABLE_CONTAINER_COMPANY";
         edtavCopyright_Internalname = "vCOPYRIGHT";
         divTable_container_copyright_Internalname = "TABLE_CONTAINER_COPYRIGHT";
         chkavUseabsoluteurlbyenvironment_Internalname = "vUSEABSOLUTEURLBYENVIRONMENT";
         divTable_container_useabsoluteurlbyenvironment_Internalname = "TABLE_CONTAINER_USEABSOLUTEURLBYENVIRONMENT";
         edtavHomeobject_Internalname = "vHOMEOBJECT";
         divTable_container_homeobject_Internalname = "TABLE_CONTAINER_HOMEOBJECT";
         lblTextblock_var_logoutobject_Internalname = "TEXTBLOCK_VAR_LOGOUTOBJECT";
         edtavLogoutobject_Internalname = "vLOGOUTOBJECT";
         imgLogoutobject_var_contexthelpimage_Internalname = "LOGOUTOBJECT_VAR_CONTEXTHELPIMAGE";
         divTable_container_logoutobjectfieldcontainer_Internalname = "TABLE_CONTAINER_LOGOUTOBJECTFIELDCONTAINER";
         divTable_container_logoutobject_Internalname = "TABLE_CONTAINER_LOGOUTOBJECT";
         cmbavMainmenu_Internalname = "vMAINMENU";
         divTable_container_mainmenu_Internalname = "TABLE_CONTAINER_MAINMENU";
         chkavAccessrequirespermission_Internalname = "vACCESSREQUIRESPERMISSION";
         divTable_container_accessrequirespermission_Internalname = "TABLE_CONTAINER_ACCESSREQUIRESPERMISSION";
         edtavClientrevoked_Internalname = "vCLIENTREVOKED";
         divTable_container_clientrevoked_Internalname = "TABLE_CONTAINER_CLIENTREVOKED";
         bttRevoke_Internalname = "REVOKE";
         lblTab1_tabcontrol_title_Internalname = "TAB1_TABCONTROL_TITLE";
         edtavClientid_Internalname = "vCLIENTID";
         divTable_container_clientid_Internalname = "TABLE_CONTAINER_CLIENTID";
         edtavClientsecret_Internalname = "vCLIENTSECRET";
         divTable_container_clientsecret_Internalname = "TABLE_CONTAINER_CLIENTSECRET";
         chkavClientallowremoteauth_Internalname = "vCLIENTALLOWREMOTEAUTH";
         divTable_container_clientallowremoteauth_Internalname = "TABLE_CONTAINER_CLIENTALLOWREMOTEAUTH";
         chkavClientallowgetuserroles_Internalname = "vCLIENTALLOWGETUSERROLES";
         divTable_container_clientallowgetuserroles_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETUSERROLES";
         chkavClientallowgetuseradddata_Internalname = "vCLIENTALLOWGETUSERADDDATA";
         divTable_container_clientallowgetuseradddata_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETUSERADDDATA";
         chkavClientallowgetsessioniniprop_Internalname = "vCLIENTALLOWGETSESSIONINIPROP";
         divTable_container_clientallowgetsessioniniprop_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETSESSIONINIPROP";
         edtavClientlocalloginurl_Internalname = "vCLIENTLOCALLOGINURL";
         divTable_container_clientlocalloginurl_Internalname = "TABLE_CONTAINER_CLIENTLOCALLOGINURL";
         edtavClientcallbackurl_Internalname = "vCLIENTCALLBACKURL";
         divTable_container_clientcallbackurl_Internalname = "TABLE_CONTAINER_CLIENTCALLBACKURL";
         edtavClientimageurl_Internalname = "vCLIENTIMAGEURL";
         divTable_container_clientimageurl_Internalname = "TABLE_CONTAINER_CLIENTIMAGEURL";
         divMaingroupresponsivetable_remoteauthenticationcontent_Internalname = "MAINGROUPRESPONSIVETABLE_REMOTEAUTHENTICATIONCONTENT";
         grpRemoteauthenticationcontent_Internalname = "REMOTEAUTHENTICATIONCONTENT";
         divMaingroupresponsivetable_remoteauthentication_Internalname = "MAINGROUPRESPONSIVETABLE_REMOTEAUTHENTICATION";
         grpRemoteauthentication_Internalname = "REMOTEAUTHENTICATION";
         chkavClientallowremoterestauth_Internalname = "vCLIENTALLOWREMOTERESTAUTH";
         divTable_container_clientallowremoterestauth_Internalname = "TABLE_CONTAINER_CLIENTALLOWREMOTERESTAUTH";
         chkavClientallowgetuserrolesrest_Internalname = "vCLIENTALLOWGETUSERROLESREST";
         divTable_container_clientallowgetuserrolesrest_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETUSERROLESREST";
         chkavClientallowgetuseradddatarest_Internalname = "vCLIENTALLOWGETUSERADDDATAREST";
         divTable_container_clientallowgetuseradddatarest_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETUSERADDDATAREST";
         chkavClientallowgetsessioniniproprest_Internalname = "vCLIENTALLOWGETSESSIONINIPROPREST";
         divTable_container_clientallowgetsessioniniproprest_Internalname = "TABLE_CONTAINER_CLIENTALLOWGETSESSIONINIPROPREST";
         divMaingroupresponsivetable_remoteauthenticationcontentrest_Internalname = "MAINGROUPRESPONSIVETABLE_REMOTEAUTHENTICATIONCONTENTREST";
         grpRemoteauthenticationcontentrest_Internalname = "REMOTEAUTHENTICATIONCONTENTREST";
         divMaingroupresponsivetable_remoteauthenticationrest_Internalname = "MAINGROUPRESPONSIVETABLE_REMOTEAUTHENTICATIONREST";
         grpRemoteauthenticationrest_Internalname = "REMOTEAUTHENTICATIONREST";
         chkavClientaccessuniquebyuser_Internalname = "vCLIENTACCESSUNIQUEBYUSER";
         divTable_container_clientaccessuniquebyuser_Internalname = "TABLE_CONTAINER_CLIENTACCESSUNIQUEBYUSER";
         lblTextblock_var_clientencryptionkey_Internalname = "TEXTBLOCK_VAR_CLIENTENCRYPTIONKEY";
         edtavClientencryptionkey_Internalname = "vCLIENTENCRYPTIONKEY";
         bttGeneratekey_Internalname = "GENERATEKEY";
         divTable_container_clientencryptionkeyfieldcontainer_Internalname = "TABLE_CONTAINER_CLIENTENCRYPTIONKEYFIELDCONTAINER";
         divTable_container_clientencryptionkey_Internalname = "TABLE_CONTAINER_CLIENTENCRYPTIONKEY";
         edtavClientrepositoryguid_Internalname = "vCLIENTREPOSITORYGUID";
         divTable_container_clientrepositoryguid_Internalname = "TABLE_CONTAINER_CLIENTREPOSITORYGUID";
         divMaintabresponsivetable_tab1_Internalname = "MAINTABRESPONSIVETABLE_TAB1";
         lblTab3_tabcontrol_title_Internalname = "TAB3_TABCONTROL_TITLE";
         chkavSsorestenable_Internalname = "vSSORESTENABLE";
         divTable_container_ssorestenable_Internalname = "TABLE_CONTAINER_SSORESTENABLE";
         cmbavSsorestmode_Internalname = "vSSORESTMODE";
         divTable_container_ssorestmode_Internalname = "TABLE_CONTAINER_SSORESTMODE";
         edtavSsorestuserauthtypename_Internalname = "vSSORESTUSERAUTHTYPENAME";
         divTable_container_ssorestuserauthtypename_Internalname = "TABLE_CONTAINER_SSORESTUSERAUTHTYPENAME";
         edtavSsorestserverurl_Internalname = "vSSORESTSERVERURL";
         divTable_container_ssorestserverurl_Internalname = "TABLE_CONTAINER_SSORESTSERVERURL";
         divMaingroupresponsivetable_groupgamssorest_Internalname = "MAINGROUPRESPONSIVETABLE_GROUPGAMSSOREST";
         grpGroupgamssorest_Internalname = "GROUPGAMSSOREST";
         divMaintabresponsivetable_tab3_Internalname = "MAINTABRESPONSIVETABLE_TAB3";
         lblTab4_tabcontrol_title_Internalname = "TAB4_TABCONTROL_TITLE";
         chkavStsprotocolenable_Internalname = "vSTSPROTOCOLENABLE";
         divTable_container_stsprotocolenable_Internalname = "TABLE_CONTAINER_STSPROTOCOLENABLE";
         cmbavStsmode_Internalname = "vSTSMODE";
         divTable_container_stsmode_Internalname = "TABLE_CONTAINER_STSMODE";
         edtavStsauthorizationusername_Internalname = "vSTSAUTHORIZATIONUSERNAME";
         divTable_container_stsauthorizationusername_Internalname = "TABLE_CONTAINER_STSAUTHORIZATIONUSERNAME";
         edtavStsauthorizationuserguid_Internalname = "vSTSAUTHORIZATIONUSERGUID";
         divTable_container_stsauthorizationuserguid_Internalname = "TABLE_CONTAINER_STSAUTHORIZATIONUSERGUID";
         edtavStsserverclientpassword_Internalname = "vSTSSERVERCLIENTPASSWORD";
         divTable_container_stsserverclientpassword_Internalname = "TABLE_CONTAINER_STSSERVERCLIENTPASSWORD";
         edtavStsserverurl_Internalname = "vSTSSERVERURL";
         divTable_container_stsserverurl_Internalname = "TABLE_CONTAINER_STSSERVERURL";
         edtavStsserverrepositoryguid_Internalname = "vSTSSERVERREPOSITORYGUID";
         divTable_container_stsserverrepositoryguid_Internalname = "TABLE_CONTAINER_STSSERVERREPOSITORYGUID";
         divMaingroupresponsivetable_groupsts_Internalname = "MAINGROUPRESPONSIVETABLE_GROUPSTS";
         grpGroupsts_Internalname = "GROUPSTS";
         divMaintabresponsivetable_tab4_Internalname = "MAINTABRESPONSIVETABLE_TAB4";
         lblTab2_tabcontrol_title_Internalname = "TAB2_TABCONTROL_TITLE";
         edtavEnvironmentname_Internalname = "vENVIRONMENTNAME";
         divTable_container_environmentname_Internalname = "TABLE_CONTAINER_ENVIRONMENTNAME";
         chkavEnvironmentsecurityprotocol_Internalname = "vENVIRONMENTSECURITYPROTOCOL";
         divTable_container_environmentsecurityprotocol_Internalname = "TABLE_CONTAINER_ENVIRONMENTSECURITYPROTOCOL";
         edtavEnvironmenthost_Internalname = "vENVIRONMENTHOST";
         divTable_container_environmenthost_Internalname = "TABLE_CONTAINER_ENVIRONMENTHOST";
         edtavEnvironmentport_Internalname = "vENVIRONMENTPORT";
         divTable_container_environmentport_Internalname = "TABLE_CONTAINER_ENVIRONMENTPORT";
         edtavEnvironmentvirtualdirectory_Internalname = "vENVIRONMENTVIRTUALDIRECTORY";
         divTable_container_environmentvirtualdirectory_Internalname = "TABLE_CONTAINER_ENVIRONMENTVIRTUALDIRECTORY";
         edtavEnvironmentprogrampackage_Internalname = "vENVIRONMENTPROGRAMPACKAGE";
         divTable_container_environmentprogrampackage_Internalname = "TABLE_CONTAINER_ENVIRONMENTPROGRAMPACKAGE";
         edtavEnvironmentprogramextension_Internalname = "vENVIRONMENTPROGRAMEXTENSION";
         divTable_container_environmentprogramextension_Internalname = "TABLE_CONTAINER_ENVIRONMENTPROGRAMEXTENSION";
         divMaintabresponsivetable_tab2_Internalname = "MAINTABRESPONSIVETABLE_TAB2";
         Tabs_tabscontrol_Internalname = "TABS_TABSCONTROL";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         lblTextblock_attributes_permissions_Internalname = "TEXTBLOCK_ATTRIBUTES_PERMISSIONS";
         imgCollapsibleimage_permissions_Internalname = "COLLAPSIBLEIMAGE_PERMISSIONS";
         tblCollapsibleimagecontainer_permissions_Internalname = "COLLAPSIBLEIMAGECONTAINER_PERMISSIONS";
         tblTitlecontainertable_permissions_Internalname = "TITLECONTAINERTABLE_PERMISSIONS";
         divTitlecell_attributes_permissions_Internalname = "TITLECELL_ATTRIBUTES_PERMISSIONS";
         divAttributescontainertable_permissions_Internalname = "ATTRIBUTESCONTAINERTABLE_PERMISSIONS";
         divResponsivetable_mainattributes_permissions_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_PERMISSIONS";
         divColumncontainertable_column_Internalname = "COLUMNCONTAINERTABLE_COLUMN";
         lblTextblock_attributes_menus_Internalname = "TEXTBLOCK_ATTRIBUTES_MENUS";
         imgCollapsibleimage_menus_Internalname = "COLLAPSIBLEIMAGE_MENUS";
         tblCollapsibleimagecontainer_menus_Internalname = "COLLAPSIBLEIMAGECONTAINER_MENUS";
         tblTitlecontainertable_menus_Internalname = "TITLECONTAINERTABLE_MENUS";
         divTitlecell_attributes_menus_Internalname = "TITLECELL_ATTRIBUTES_MENUS";
         divAttributescontainertable_menus_Internalname = "ATTRIBUTESCONTAINERTABLE_MENUS";
         divResponsivetable_mainattributes_menus_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_MENUS";
         divColumncontainertable_column1_Internalname = "COLUMNCONTAINERTABLE_COLUMN1";
         divColumns_maincolumnstable_Internalname = "COLUMNS_MAINCOLUMNSTABLE";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavEnvironmentsecurityprotocol.Caption = "¿Es HTTPS?";
         chkavStsprotocolenable.Caption = "Habilitar protocolo STS";
         chkavSsorestenable.Caption = "Habilitar servicios REST SSO";
         chkavClientaccessuniquebyuser.Caption = "Permitir sólo un acceso por usuario";
         chkavClientallowgetsessioniniproprest.Caption = "Puede obtener datos iniciales de sesión";
         chkavClientallowgetuseradddatarest.Caption = "Puede obtener datos adicionales de usuarios";
         chkavClientallowgetuserrolesrest.Caption = "Puede obtener roles";
         chkavClientallowremoterestauth.Caption = "Permitir autenticación remota";
         chkavClientallowgetsessioniniprop.Caption = "Puede obtener datos iniciales de sesión";
         chkavClientallowgetuseradddata.Caption = "Puede obtener datos adicionales de usuarios";
         chkavClientallowgetuserroles.Caption = "Puede obtener roles";
         chkavClientallowremoteauth.Caption = "Permitir autenticación remota";
         chkavAccessrequirespermission.Caption = "Permiso requerido para acceder";
         chkavUseabsoluteurlbyenvironment.Caption = "Usar URL absoluta de entorno";
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         imgCollapsibleimage_permissions_Bitmap = (string)(context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( )));
         imgCollapsibleimage_menus_Bitmap = (string)(context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( )));
         bttConfirm_Caption = "Confirmar";
         imgDelete_Tooltiptext = "Eliminar";
         imgUpdate_Tooltiptext = "Actualizar";
         divAttributescontainertable_menus_Visible = 1;
         divResponsivetable_mainattributes_menus_Class = "K2BToolsTable_ComponentContainer";
         divResponsivetable_mainattributes_menus_Visible = 1;
         divAttributescontainertable_permissions_Visible = 1;
         divResponsivetable_mainattributes_permissions_Class = "K2BToolsTable_ComponentContainer";
         divResponsivetable_mainattributes_permissions_Visible = 1;
         edtavEnvironmentprogramextension_Jsonclick = "";
         edtavEnvironmentprogramextension_Enabled = 1;
         edtavEnvironmentprogrampackage_Jsonclick = "";
         edtavEnvironmentprogrampackage_Enabled = 1;
         edtavEnvironmentvirtualdirectory_Jsonclick = "";
         edtavEnvironmentvirtualdirectory_Enabled = 1;
         edtavEnvironmentport_Jsonclick = "";
         edtavEnvironmentport_Enabled = 1;
         edtavEnvironmenthost_Jsonclick = "";
         edtavEnvironmenthost_Enabled = 1;
         chkavEnvironmentsecurityprotocol.Enabled = 1;
         edtavEnvironmentname_Jsonclick = "";
         edtavEnvironmentname_Enabled = 1;
         edtavStsserverrepositoryguid_Jsonclick = "";
         edtavStsserverrepositoryguid_Enabled = 1;
         edtavStsserverurl_Jsonclick = "";
         edtavStsserverurl_Enabled = 1;
         edtavStsserverclientpassword_Jsonclick = "";
         edtavStsserverclientpassword_Enabled = 1;
         edtavStsauthorizationuserguid_Jsonclick = "";
         edtavStsauthorizationuserguid_Enabled = 1;
         edtavStsauthorizationusername_Jsonclick = "";
         edtavStsauthorizationusername_Enabled = 1;
         cmbavStsmode_Jsonclick = "";
         cmbavStsmode.Enabled = 1;
         grpGroupsts_Class = "Group_Tabular";
         chkavStsprotocolenable.Enabled = 1;
         edtavSsorestserverurl_Jsonclick = "";
         edtavSsorestserverurl_Enabled = 1;
         edtavSsorestuserauthtypename_Jsonclick = "";
         edtavSsorestuserauthtypename_Enabled = 1;
         cmbavSsorestmode_Jsonclick = "";
         cmbavSsorestmode.Enabled = 1;
         grpGroupgamssorest_Class = "Group_Tabular";
         chkavSsorestenable.Enabled = 1;
         edtavClientrepositoryguid_Jsonclick = "";
         edtavClientrepositoryguid_Enabled = 1;
         bttGeneratekey_Enabled = 1;
         bttGeneratekey_Visible = 1;
         edtavClientencryptionkey_Jsonclick = "";
         edtavClientencryptionkey_Enabled = 1;
         chkavClientaccessuniquebyuser.Enabled = 1;
         chkavClientallowgetsessioniniproprest.Enabled = 1;
         chkavClientallowgetuseradddatarest.Enabled = 1;
         chkavClientallowgetuserrolesrest.Enabled = 1;
         grpRemoteauthenticationcontentrest_Class = "Group_Tabular";
         chkavClientallowremoterestauth.Enabled = 1;
         edtavClientimageurl_Jsonclick = "";
         edtavClientimageurl_Enabled = 1;
         edtavClientcallbackurl_Jsonclick = "";
         edtavClientcallbackurl_Enabled = 1;
         edtavClientlocalloginurl_Jsonclick = "";
         edtavClientlocalloginurl_Enabled = 1;
         chkavClientallowgetsessioniniprop.Enabled = 1;
         chkavClientallowgetuseradddata.Enabled = 1;
         chkavClientallowgetuserroles.Enabled = 1;
         grpRemoteauthenticationcontent_Class = "Group_Tabular";
         chkavClientallowremoteauth.Enabled = 1;
         edtavClientsecret_Jsonclick = "";
         edtavClientsecret_Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         bttRevoke_Caption = "Revoke";
         edtavClientrevoked_Jsonclick = "";
         edtavClientrevoked_Enabled = 1;
         chkavAccessrequirespermission.Enabled = 1;
         cmbavMainmenu_Jsonclick = "";
         cmbavMainmenu.Enabled = 1;
         imgLogoutobject_var_contexthelpimage_Tooltiptext = "";
         edtavLogoutobject_Jsonclick = "";
         edtavLogoutobject_Enabled = 1;
         edtavHomeobject_Jsonclick = "";
         edtavHomeobject_Enabled = 1;
         chkavUseabsoluteurlbyenvironment.Enabled = 1;
         edtavCopyright_Jsonclick = "";
         edtavCopyright_Enabled = 1;
         edtavCompany_Jsonclick = "";
         edtavCompany_Enabled = 1;
         edtavVersion_Jsonclick = "";
         edtavVersion_Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         Tabs_tabscontrol_Historymanagement = Convert.ToBoolean( 0);
         Tabs_tabscontrol_Class = "Tab";
         Tabs_tabscontrol_Pagecount = 4;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Aplicación";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavMainmenu'},{av:'AV35MainMenu',fld:'vMAINMENU',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgLogoutobject_var_contexthelpimage_Tooltiptext',ctrl:'LOGOUTOBJECT_VAR_CONTEXTHELPIMAGE',prop:'Tooltiptext'},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'edtavDsc_Enabled',ctrl:'vDSC',prop:'Enabled'},{av:'edtavVersion_Enabled',ctrl:'vVERSION',prop:'Enabled'},{av:'edtavCopyright_Enabled',ctrl:'vCOPYRIGHT',prop:'Enabled'},{av:'edtavCompany_Enabled',ctrl:'vCOMPANY',prop:'Enabled'},{av:'chkavAccessrequirespermission.Enabled',ctrl:'vACCESSREQUIRESPERMISSION',prop:'Enabled'},{av:'edtavClientid_Enabled',ctrl:'vCLIENTID',prop:'Enabled'},{av:'edtavClientsecret_Enabled',ctrl:'vCLIENTSECRET',prop:'Enabled'},{av:'chkavClientaccessuniquebyuser.Enabled',ctrl:'vCLIENTACCESSUNIQUEBYUSER',prop:'Enabled'},{av:'chkavUseabsoluteurlbyenvironment.Enabled',ctrl:'vUSEABSOLUTEURLBYENVIRONMENT',prop:'Enabled'},{av:'edtavHomeobject_Enabled',ctrl:'vHOMEOBJECT',prop:'Enabled'},{av:'edtavLogoutobject_Enabled',ctrl:'vLOGOUTOBJECT',prop:'Enabled'},{av:'cmbavMainmenu'},{av:'AV30GUID',fld:'vGUID',pic:''},{av:'AV37Name',fld:'vNAME',pic:''},{av:'AV20Dsc',fld:'vDSC',pic:''},{av:'AV42Version',fld:'vVERSION',pic:''},{av:'AV19Copyright',fld:'vCOPYRIGHT',pic:''},{av:'AV18Company',fld:'vCOMPANY',pic:''},{av:'AV14ClientId',fld:'vCLIENTID',pic:''},{av:'AV17ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'edtavEnvironmentname_Enabled',ctrl:'vENVIRONMENTNAME',prop:'Enabled'},{av:'chkavEnvironmentsecurityprotocol.Enabled',ctrl:'vENVIRONMENTSECURITYPROTOCOL',prop:'Enabled'},{av:'edtavEnvironmenthost_Enabled',ctrl:'vENVIRONMENTHOST',prop:'Enabled'},{av:'edtavEnvironmentport_Enabled',ctrl:'vENVIRONMENTPORT',prop:'Enabled'},{av:'edtavEnvironmentvirtualdirectory_Enabled',ctrl:'vENVIRONMENTVIRTUALDIRECTORY',prop:'Enabled'},{av:'edtavEnvironmentprogrampackage_Enabled',ctrl:'vENVIRONMENTPROGRAMPACKAGE',prop:'Enabled'},{av:'edtavEnvironmentprogramextension_Enabled',ctrl:'vENVIRONMENTPROGRAMEXTENSION',prop:'Enabled'},{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV31HomeObject',fld:'vHOMEOBJECT',pic:''},{av:'AV34LogoutObject',fld:'vLOGOUTOBJECT',pic:''},{av:'AV35MainMenu',fld:'vMAINMENU',pic:'ZZZZZZZZZZZ9'},{av:'AV52ClientRevoked',fld:'vCLIENTREVOKED',pic:'99/99/9999 99:99'},{av:'AV16ClientLocalLoginURL',fld:'vCLIENTLOCALLOGINURL',pic:''},{av:'AV12ClientCallbackURL',fld:'vCLIENTCALLBACKURL',pic:''},{av:'AV15ClientImageURL',fld:'vCLIENTIMAGEURL',pic:''},{av:'AV13ClientEncryptionKey',fld:'vCLIENTENCRYPTIONKEY',pic:''},{av:'AV46ClientRepositoryGUID',fld:'vCLIENTREPOSITORYGUID',pic:''},{av:'AV22EnvironmentName',fld:'vENVIRONMENTNAME',pic:''},{av:'AV21EnvironmentHost',fld:'vENVIRONMENTHOST',pic:''},{av:'AV23EnvironmentPort',fld:'vENVIRONMENTPORT',pic:'ZZZZ9'},{av:'AV27EnvironmentVirtualDirectory',fld:'vENVIRONMENTVIRTUALDIRECTORY',pic:''},{av:'AV25EnvironmentProgramPackage',fld:'vENVIRONMENTPROGRAMPACKAGE',pic:''},{av:'AV24EnvironmentProgramExtension',fld:'vENVIRONMENTPROGRAMEXTENSION',pic:''},{av:'cmbavSsorestmode'},{av:'AV60SSORestMode',fld:'vSSORESTMODE',pic:''},{av:'AV61SSORestUserAuthTypeName',fld:'vSSORESTUSERAUTHTYPENAME',pic:''},{av:'AV54SSORestServerURL',fld:'vSSORESTSERVERURL',pic:''},{av:'AV64STSAuthorizationUserName',fld:'vSTSAUTHORIZATIONUSERNAME',pic:''},{av:'cmbavStsmode'},{av:'AV63STSMode',fld:'vSTSMODE',pic:''},{av:'AV56STSServerURL',fld:'vSTSSERVERURL',pic:''},{av:'AV65STSServerClientPassword',fld:'vSTSSERVERCLIENTPASSWORD',pic:''},{av:'AV57STSServerRepositoryGUID',fld:'vSTSSERVERREPOSITORYGUID',pic:''},{ctrl:'REVOKE',prop:'Caption'},{av:'divResponsivetable_mainattributes_permissions_Visible',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_PERMISSIONS',prop:'Visible'},{av:'divResponsivetable_mainattributes_menus_Visible',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_MENUS',prop:'Visible'},{ctrl:'PERMISSIONSWC'},{ctrl:'MENUSWC'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'},{ctrl:'GENERATEKEY',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Enabled'},{av:'edtavGuid_Enabled',ctrl:'vGUID',prop:'Enabled'},{av:'edtavClientrevoked_Enabled',ctrl:'vCLIENTREVOKED',prop:'Enabled'},{av:'chkavClientallowremoteauth.Enabled',ctrl:'vCLIENTALLOWREMOTEAUTH',prop:'Enabled'},{av:'chkavClientallowgetuserroles.Enabled',ctrl:'vCLIENTALLOWGETUSERROLES',prop:'Enabled'},{av:'chkavClientallowgetuseradddata.Enabled',ctrl:'vCLIENTALLOWGETUSERADDDATA',prop:'Enabled'},{av:'edtavClientlocalloginurl_Enabled',ctrl:'vCLIENTLOCALLOGINURL',prop:'Enabled'},{av:'edtavClientcallbackurl_Enabled',ctrl:'vCLIENTCALLBACKURL',prop:'Enabled'},{av:'edtavClientimageurl_Enabled',ctrl:'vCLIENTIMAGEURL',prop:'Enabled'},{av:'edtavClientencryptionkey_Enabled',ctrl:'vCLIENTENCRYPTIONKEY',prop:'Enabled'},{av:'chkavClientallowgetsessioniniprop.Enabled',ctrl:'vCLIENTALLOWGETSESSIONINIPROP',prop:'Enabled'},{av:'edtavClientrepositoryguid_Enabled',ctrl:'vCLIENTREPOSITORYGUID',prop:'Enabled'},{av:'chkavSsorestenable.Enabled',ctrl:'vSSORESTENABLE',prop:'Enabled'},{av:'edtavSsorestuserauthtypename_Enabled',ctrl:'vSSORESTUSERAUTHTYPENAME',prop:'Enabled'},{av:'edtavSsorestserverurl_Enabled',ctrl:'vSSORESTSERVERURL',prop:'Enabled'},{av:'chkavClientallowremoterestauth.Enabled',ctrl:'vCLIENTALLOWREMOTERESTAUTH',prop:'Enabled'},{av:'chkavClientallowgetuserrolesrest.Enabled',ctrl:'vCLIENTALLOWGETUSERROLESREST',prop:'Enabled'},{av:'chkavClientallowgetuseradddatarest.Enabled',ctrl:'vCLIENTALLOWGETUSERADDDATAREST',prop:'Enabled'},{av:'chkavClientallowgetsessioniniproprest.Enabled',ctrl:'vCLIENTALLOWGETSESSIONINIPROPREST',prop:'Enabled'},{av:'chkavStsprotocolenable.Enabled',ctrl:'vSTSPROTOCOLENABLE',prop:'Enabled'},{av:'edtavStsauthorizationusername_Enabled',ctrl:'vSTSAUTHORIZATIONUSERNAME',prop:'Enabled'},{av:'edtavStsserverurl_Enabled',ctrl:'vSTSSERVERURL',prop:'Enabled'},{av:'edtavStsserverclientpassword_Enabled',ctrl:'vSTSSERVERCLIENTPASSWORD',prop:'Enabled'},{av:'edtavStsserverrepositoryguid_Enabled',ctrl:'vSTSSERVERREPOSITORYGUID',prop:'Enabled'},{av:'edtavStsauthorizationuserguid_Enabled',ctrl:'vSTSAUTHORIZATIONUSERGUID',prop:'Enabled'},{av:'grpRemoteauthenticationcontent_Class',ctrl:'REMOTEAUTHENTICATIONCONTENT',prop:'Class'},{av:'grpRemoteauthenticationcontentrest_Class',ctrl:'REMOTEAUTHENTICATIONCONTENTREST',prop:'Class'},{av:'grpGroupgamssorest_Class',ctrl:'GROUPGAMSSOREST',prop:'Class'},{av:'grpGroupsts_Class',ctrl:'GROUPSTS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E143U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV37Name',fld:'vNAME',pic:''},{av:'AV20Dsc',fld:'vDSC',pic:''},{av:'AV42Version',fld:'vVERSION',pic:''},{av:'AV19Copyright',fld:'vCOPYRIGHT',pic:''},{av:'AV18Company',fld:'vCOMPANY',pic:''},{av:'AV31HomeObject',fld:'vHOMEOBJECT',pic:''},{av:'AV34LogoutObject',fld:'vLOGOUTOBJECT',pic:''},{av:'cmbavMainmenu'},{av:'AV35MainMenu',fld:'vMAINMENU',pic:'ZZZZZZZZZZZ9'},{av:'AV14ClientId',fld:'vCLIENTID',pic:''},{av:'AV17ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'AV16ClientLocalLoginURL',fld:'vCLIENTLOCALLOGINURL',pic:''},{av:'AV12ClientCallbackURL',fld:'vCLIENTCALLBACKURL',pic:''},{av:'AV15ClientImageURL',fld:'vCLIENTIMAGEURL',pic:''},{av:'AV13ClientEncryptionKey',fld:'vCLIENTENCRYPTIONKEY',pic:''},{av:'AV46ClientRepositoryGUID',fld:'vCLIENTREPOSITORYGUID',pic:''},{av:'cmbavSsorestmode'},{av:'AV60SSORestMode',fld:'vSSORESTMODE',pic:''},{av:'AV61SSORestUserAuthTypeName',fld:'vSSORESTUSERAUTHTYPENAME',pic:''},{av:'AV54SSORestServerURL',fld:'vSSORESTSERVERURL',pic:''},{av:'AV64STSAuthorizationUserName',fld:'vSTSAUTHORIZATIONUSERNAME',pic:''},{av:'AV58STSAuthorizationUserGUID',fld:'vSTSAUTHORIZATIONUSERGUID',pic:''},{av:'cmbavStsmode'},{av:'AV63STSMode',fld:'vSTSMODE',pic:''},{av:'AV56STSServerURL',fld:'vSTSSERVERURL',pic:''},{av:'AV65STSServerClientPassword',fld:'vSTSSERVERCLIENTPASSWORD',pic:''},{av:'AV57STSServerRepositoryGUID',fld:'vSTSSERVERREPOSITORYGUID',pic:''},{av:'AV22EnvironmentName',fld:'vENVIRONMENTNAME',pic:''},{av:'AV21EnvironmentHost',fld:'vENVIRONMENTHOST',pic:''},{av:'AV23EnvironmentPort',fld:'vENVIRONMENTPORT',pic:'ZZZZ9'},{av:'AV27EnvironmentVirtualDirectory',fld:'vENVIRONMENTVIRTUALDIRECTORY',pic:''},{av:'AV25EnvironmentProgramPackage',fld:'vENVIRONMENTPROGRAMPACKAGE',pic:''},{av:'AV24EnvironmentProgramExtension',fld:'vENVIRONMENTPROGRAMEXTENSION',pic:''},{av:'AV36Message',fld:'vMESSAGE',pic:''},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV58STSAuthorizationUserGUID',fld:'vSTSAUTHORIZATIONUSERGUID',pic:''},{av:'AV36Message',fld:'vMESSAGE',pic:''},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E263U1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E273U1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV33Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E253U1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("'E_CANCEL'",",oparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VCLIENTALLOWREMOTEAUTH.CLICK","{handler:'E213U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VCLIENTALLOWREMOTEAUTH.CLICK",",oparms:[{av:'grpRemoteauthenticationcontent_Class',ctrl:'REMOTEAUTHENTICATIONCONTENT',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VCLIENTALLOWREMOTERESTAUTH.CLICK","{handler:'E223U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VCLIENTALLOWREMOTERESTAUTH.CLICK",",oparms:[{av:'grpRemoteauthenticationcontentrest_Class',ctrl:'REMOTEAUTHENTICATIONCONTENTREST',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VSSORESTENABLE.CLICK","{handler:'E233U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VSSORESTENABLE.CLICK",",oparms:[{av:'grpGroupgamssorest_Class',ctrl:'GROUPGAMSSOREST',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VSTSPROTOCOLENABLE.CLICK","{handler:'E243U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VSTSPROTOCOLENABLE.CLICK",",oparms:[{av:'grpGroupsts_Class',ctrl:'GROUPSTS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("'E_GENERATEKEY'","{handler:'E153U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("'E_GENERATEKEY'",",oparms:[{av:'AV13ClientEncryptionKey',fld:'vCLIENTENCRYPTIONKEY',pic:''},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("TEXTBLOCK_ATTRIBUTES_PERMISSIONS.CLICK","{handler:'E163U2',iparms:[{av:'divAttributescontainertable_permissions_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_PERMISSIONS',prop:'Visible'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("TEXTBLOCK_ATTRIBUTES_PERMISSIONS.CLICK",",oparms:[{av:'divAttributescontainertable_permissions_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_PERMISSIONS',prop:'Visible'},{av:'divResponsivetable_mainattributes_permissions_Class',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_PERMISSIONS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("COLLAPSIBLEIMAGE_PERMISSIONS.CLICK","{handler:'E173U2',iparms:[{av:'divAttributescontainertable_permissions_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_PERMISSIONS',prop:'Visible'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("COLLAPSIBLEIMAGE_PERMISSIONS.CLICK",",oparms:[{av:'divAttributescontainertable_permissions_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_PERMISSIONS',prop:'Visible'},{av:'divResponsivetable_mainattributes_permissions_Class',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_PERMISSIONS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("TEXTBLOCK_ATTRIBUTES_MENUS.CLICK","{handler:'E183U2',iparms:[{av:'divAttributescontainertable_menus_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_MENUS',prop:'Visible'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("TEXTBLOCK_ATTRIBUTES_MENUS.CLICK",",oparms:[{av:'divAttributescontainertable_menus_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_MENUS',prop:'Visible'},{av:'divResponsivetable_mainattributes_menus_Class',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_MENUS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("COLLAPSIBLEIMAGE_MENUS.CLICK","{handler:'E193U2',iparms:[{av:'divAttributescontainertable_menus_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_MENUS',prop:'Visible'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("COLLAPSIBLEIMAGE_MENUS.CLICK",",oparms:[{av:'divAttributescontainertable_menus_Visible',ctrl:'ATTRIBUTESCONTAINERTABLE_MENUS',prop:'Visible'},{av:'divResponsivetable_mainattributes_menus_Class',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_MENUS',prop:'Class'},{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("'E_REVOKE'","{handler:'E113U1',iparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("'E_REVOKE'",",oparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VALIDV_CLIENTREVOKED","{handler:'Validv_Clientrevoked',iparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VALIDV_CLIENTREVOKED",",oparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VALIDV_SSORESTMODE","{handler:'Validv_Ssorestmode',iparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VALIDV_SSORESTMODE",",oparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
         setEventMetadata("VALIDV_STSMODE","{handler:'Validv_Stsmode',iparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]");
         setEventMetadata("VALIDV_STSMODE",",oparms:[{av:'AV40UseAbsoluteUrlByEnvironment',fld:'vUSEABSOLUTEURLBYENVIRONMENT',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV11ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV10ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV9ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV51ClientAllowGetSessionIniProp',fld:'vCLIENTALLOWGETSESSIONINIPROP',pic:''},{av:'AV47ClientAllowRemoteRestAuth',fld:'vCLIENTALLOWREMOTERESTAUTH',pic:''},{av:'AV48ClientAllowGetUserRolesRest',fld:'vCLIENTALLOWGETUSERROLESREST',pic:''},{av:'AV49ClientAllowGetUserAddDataRest',fld:'vCLIENTALLOWGETUSERADDDATAREST',pic:''},{av:'AV50ClientAllowGetSessionIniPropRest',fld:'vCLIENTALLOWGETSESSIONINIPROPREST',pic:''},{av:'AV53ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV59SSORestEnable',fld:'vSSORESTENABLE',pic:''},{av:'AV62STSProtocolEnable',fld:'vSTSPROTOCOLENABLE',pic:''},{av:'AV26EnvironmentSecurityProtocol',fld:'vENVIRONMENTSECURITYPROTOCOL',pic:''}]}");
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
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV36Message = new GeneXus.Utils.SdtMessages_Message(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV30GUID = "";
         AV37Name = "";
         AV20Dsc = "";
         AV42Version = "";
         AV18Company = "";
         AV19Copyright = "";
         AV31HomeObject = "";
         lblTextblock_var_logoutobject_Jsonclick = "";
         AV34LogoutObject = "";
         sImgUrl = "";
         AV52ClientRevoked = (DateTime)(DateTime.MinValue);
         bttRevoke_Jsonclick = "";
         ucTabs_tabscontrol = new GXUserControl();
         lblTab1_tabcontrol_title_Jsonclick = "";
         AV14ClientId = "";
         AV17ClientSecret = "";
         AV16ClientLocalLoginURL = "";
         AV12ClientCallbackURL = "";
         AV15ClientImageURL = "";
         lblTextblock_var_clientencryptionkey_Jsonclick = "";
         AV13ClientEncryptionKey = "";
         bttGeneratekey_Jsonclick = "";
         AV46ClientRepositoryGUID = "";
         lblTab3_tabcontrol_title_Jsonclick = "";
         AV60SSORestMode = "";
         AV61SSORestUserAuthTypeName = "";
         AV54SSORestServerURL = "";
         lblTab4_tabcontrol_title_Jsonclick = "";
         AV63STSMode = "";
         AV64STSAuthorizationUserName = "";
         AV58STSAuthorizationUserGUID = "";
         AV65STSServerClientPassword = "";
         AV56STSServerURL = "";
         AV57STSServerRepositoryGUID = "";
         lblTab2_tabcontrol_title_Jsonclick = "";
         AV22EnvironmentName = "";
         AV21EnvironmentHost = "";
         AV27EnvironmentVirtualDirectory = "";
         AV25EnvironmentProgramPackage = "";
         AV24EnvironmentProgramExtension = "";
         WebComp_Permissionswc_Component = "";
         OldPermissionswc = "";
         WebComp_Menuswc_Component = "";
         OldMenuswc = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV69GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV45MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV29Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV44Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV55GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV28Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         lblTextblock_attributes_menus_Jsonclick = "";
         imgCollapsibleimage_menus_Jsonclick = "";
         lblTextblock_attributes_permissions_Jsonclick = "";
         imgCollapsibleimage_permissions_Jsonclick = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         imgUpdate_Jsonclick = "";
         imgDelete_Jsonclick = "";
         lblTextblock_attributes_attributes_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryapplication__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryapplication__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryapplication__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryapplication__default(),
            new Object[][] {
            }
         );
         WebComp_Permissionswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Menuswc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavClientrevoked_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divAttributescontainertable_permissions_Visible ;
      private int divAttributescontainertable_menus_Visible ;
      private int Tabs_tabscontrol_Pagecount ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavVersion_Enabled ;
      private int edtavCompany_Enabled ;
      private int edtavCopyright_Enabled ;
      private int edtavHomeobject_Enabled ;
      private int edtavLogoutobject_Enabled ;
      private int edtavClientrevoked_Enabled ;
      private int edtavClientid_Enabled ;
      private int edtavClientsecret_Enabled ;
      private int edtavClientlocalloginurl_Enabled ;
      private int edtavClientcallbackurl_Enabled ;
      private int edtavClientimageurl_Enabled ;
      private int edtavClientencryptionkey_Enabled ;
      private int bttGeneratekey_Visible ;
      private int bttGeneratekey_Enabled ;
      private int edtavClientrepositoryguid_Enabled ;
      private int edtavSsorestuserauthtypename_Enabled ;
      private int edtavSsorestserverurl_Enabled ;
      private int edtavStsauthorizationusername_Enabled ;
      private int edtavStsauthorizationuserguid_Enabled ;
      private int edtavStsserverclientpassword_Enabled ;
      private int edtavStsserverurl_Enabled ;
      private int edtavStsserverrepositoryguid_Enabled ;
      private int edtavEnvironmentname_Enabled ;
      private int edtavEnvironmenthost_Enabled ;
      private int AV23EnvironmentPort ;
      private int edtavEnvironmentport_Enabled ;
      private int edtavEnvironmentvirtualdirectory_Enabled ;
      private int edtavEnvironmentprogrampackage_Enabled ;
      private int edtavEnvironmentprogramextension_Enabled ;
      private int divResponsivetable_mainattributes_permissions_Visible ;
      private int divResponsivetable_mainattributes_menus_Visible ;
      private int AV70GXV2 ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int AV71GXV3 ;
      private int idxLst ;
      private long AV33Id ;
      private long wcpOAV33Id ;
      private long AV35MainMenu ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tabs_tabscontrol_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divResponsivetable_mainattributes_attributes_Internalname ;
      private string divTitlecell_attributes_attributes_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divResponsivetable_containernode_actions2_Internalname ;
      private string divTable_container_id_Internalname ;
      private string edtavId_Internalname ;
      private string edtavId_Jsonclick ;
      private string divTable_container_guid_Internalname ;
      private string edtavGuid_Internalname ;
      private string TempTags ;
      private string AV30GUID ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV37Name ;
      private string edtavName_Jsonclick ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV20Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_version_Internalname ;
      private string edtavVersion_Internalname ;
      private string AV42Version ;
      private string edtavVersion_Jsonclick ;
      private string divTable_container_company_Internalname ;
      private string edtavCompany_Internalname ;
      private string AV18Company ;
      private string edtavCompany_Jsonclick ;
      private string divTable_container_copyright_Internalname ;
      private string edtavCopyright_Internalname ;
      private string AV19Copyright ;
      private string edtavCopyright_Jsonclick ;
      private string divTable_container_useabsoluteurlbyenvironment_Internalname ;
      private string chkavUseabsoluteurlbyenvironment_Internalname ;
      private string divTable_container_homeobject_Internalname ;
      private string edtavHomeobject_Internalname ;
      private string edtavHomeobject_Jsonclick ;
      private string divTable_container_logoutobject_Internalname ;
      private string lblTextblock_var_logoutobject_Internalname ;
      private string lblTextblock_var_logoutobject_Jsonclick ;
      private string divTable_container_logoutobjectfieldcontainer_Internalname ;
      private string edtavLogoutobject_Internalname ;
      private string edtavLogoutobject_Jsonclick ;
      private string sImgUrl ;
      private string imgLogoutobject_var_contexthelpimage_Internalname ;
      private string imgLogoutobject_var_contexthelpimage_Tooltiptext ;
      private string divTable_container_mainmenu_Internalname ;
      private string cmbavMainmenu_Internalname ;
      private string cmbavMainmenu_Jsonclick ;
      private string divTable_container_accessrequirespermission_Internalname ;
      private string chkavAccessrequirespermission_Internalname ;
      private string divTable_container_clientrevoked_Internalname ;
      private string edtavClientrevoked_Internalname ;
      private string edtavClientrevoked_Jsonclick ;
      private string bttRevoke_Internalname ;
      private string bttRevoke_Caption ;
      private string bttRevoke_Jsonclick ;
      private string Tabs_tabscontrol_Internalname ;
      private string lblTab1_tabcontrol_title_Internalname ;
      private string lblTab1_tabcontrol_title_Jsonclick ;
      private string divMaintabresponsivetable_tab1_Internalname ;
      private string divTable_container_clientid_Internalname ;
      private string edtavClientid_Internalname ;
      private string AV14ClientId ;
      private string edtavClientid_Jsonclick ;
      private string divTable_container_clientsecret_Internalname ;
      private string edtavClientsecret_Internalname ;
      private string AV17ClientSecret ;
      private string edtavClientsecret_Jsonclick ;
      private string grpRemoteauthentication_Internalname ;
      private string divMaingroupresponsivetable_remoteauthentication_Internalname ;
      private string divTable_container_clientallowremoteauth_Internalname ;
      private string chkavClientallowremoteauth_Internalname ;
      private string grpRemoteauthenticationcontent_Internalname ;
      private string grpRemoteauthenticationcontent_Class ;
      private string divMaingroupresponsivetable_remoteauthenticationcontent_Internalname ;
      private string divTable_container_clientallowgetuserroles_Internalname ;
      private string chkavClientallowgetuserroles_Internalname ;
      private string divTable_container_clientallowgetuseradddata_Internalname ;
      private string chkavClientallowgetuseradddata_Internalname ;
      private string divTable_container_clientallowgetsessioniniprop_Internalname ;
      private string chkavClientallowgetsessioniniprop_Internalname ;
      private string divTable_container_clientlocalloginurl_Internalname ;
      private string edtavClientlocalloginurl_Internalname ;
      private string edtavClientlocalloginurl_Jsonclick ;
      private string divTable_container_clientcallbackurl_Internalname ;
      private string edtavClientcallbackurl_Internalname ;
      private string edtavClientcallbackurl_Jsonclick ;
      private string divTable_container_clientimageurl_Internalname ;
      private string edtavClientimageurl_Internalname ;
      private string edtavClientimageurl_Jsonclick ;
      private string grpRemoteauthenticationrest_Internalname ;
      private string divMaingroupresponsivetable_remoteauthenticationrest_Internalname ;
      private string divTable_container_clientallowremoterestauth_Internalname ;
      private string chkavClientallowremoterestauth_Internalname ;
      private string grpRemoteauthenticationcontentrest_Internalname ;
      private string grpRemoteauthenticationcontentrest_Class ;
      private string divMaingroupresponsivetable_remoteauthenticationcontentrest_Internalname ;
      private string divTable_container_clientallowgetuserrolesrest_Internalname ;
      private string chkavClientallowgetuserrolesrest_Internalname ;
      private string divTable_container_clientallowgetuseradddatarest_Internalname ;
      private string chkavClientallowgetuseradddatarest_Internalname ;
      private string divTable_container_clientallowgetsessioniniproprest_Internalname ;
      private string chkavClientallowgetsessioniniproprest_Internalname ;
      private string divTable_container_clientaccessuniquebyuser_Internalname ;
      private string chkavClientaccessuniquebyuser_Internalname ;
      private string divTable_container_clientencryptionkey_Internalname ;
      private string lblTextblock_var_clientencryptionkey_Internalname ;
      private string lblTextblock_var_clientencryptionkey_Jsonclick ;
      private string divTable_container_clientencryptionkeyfieldcontainer_Internalname ;
      private string edtavClientencryptionkey_Internalname ;
      private string AV13ClientEncryptionKey ;
      private string edtavClientencryptionkey_Jsonclick ;
      private string bttGeneratekey_Internalname ;
      private string bttGeneratekey_Jsonclick ;
      private string divTable_container_clientrepositoryguid_Internalname ;
      private string edtavClientrepositoryguid_Internalname ;
      private string AV46ClientRepositoryGUID ;
      private string edtavClientrepositoryguid_Jsonclick ;
      private string lblTab3_tabcontrol_title_Internalname ;
      private string lblTab3_tabcontrol_title_Jsonclick ;
      private string divMaintabresponsivetable_tab3_Internalname ;
      private string divTable_container_ssorestenable_Internalname ;
      private string chkavSsorestenable_Internalname ;
      private string grpGroupgamssorest_Internalname ;
      private string grpGroupgamssorest_Class ;
      private string divMaingroupresponsivetable_groupgamssorest_Internalname ;
      private string divTable_container_ssorestmode_Internalname ;
      private string cmbavSsorestmode_Internalname ;
      private string AV60SSORestMode ;
      private string cmbavSsorestmode_Jsonclick ;
      private string divTable_container_ssorestuserauthtypename_Internalname ;
      private string edtavSsorestuserauthtypename_Internalname ;
      private string AV61SSORestUserAuthTypeName ;
      private string edtavSsorestuserauthtypename_Jsonclick ;
      private string divTable_container_ssorestserverurl_Internalname ;
      private string edtavSsorestserverurl_Internalname ;
      private string edtavSsorestserverurl_Jsonclick ;
      private string lblTab4_tabcontrol_title_Internalname ;
      private string lblTab4_tabcontrol_title_Jsonclick ;
      private string divMaintabresponsivetable_tab4_Internalname ;
      private string divTable_container_stsprotocolenable_Internalname ;
      private string chkavStsprotocolenable_Internalname ;
      private string grpGroupsts_Internalname ;
      private string grpGroupsts_Class ;
      private string divMaingroupresponsivetable_groupsts_Internalname ;
      private string divTable_container_stsmode_Internalname ;
      private string cmbavStsmode_Internalname ;
      private string AV63STSMode ;
      private string cmbavStsmode_Jsonclick ;
      private string divTable_container_stsauthorizationusername_Internalname ;
      private string edtavStsauthorizationusername_Internalname ;
      private string edtavStsauthorizationusername_Jsonclick ;
      private string divTable_container_stsauthorizationuserguid_Internalname ;
      private string edtavStsauthorizationuserguid_Internalname ;
      private string AV58STSAuthorizationUserGUID ;
      private string edtavStsauthorizationuserguid_Jsonclick ;
      private string divTable_container_stsserverclientpassword_Internalname ;
      private string edtavStsserverclientpassword_Internalname ;
      private string AV65STSServerClientPassword ;
      private string edtavStsserverclientpassword_Jsonclick ;
      private string divTable_container_stsserverurl_Internalname ;
      private string edtavStsserverurl_Internalname ;
      private string edtavStsserverurl_Jsonclick ;
      private string divTable_container_stsserverrepositoryguid_Internalname ;
      private string edtavStsserverrepositoryguid_Internalname ;
      private string AV57STSServerRepositoryGUID ;
      private string edtavStsserverrepositoryguid_Jsonclick ;
      private string lblTab2_tabcontrol_title_Internalname ;
      private string lblTab2_tabcontrol_title_Jsonclick ;
      private string divMaintabresponsivetable_tab2_Internalname ;
      private string divTable_container_environmentname_Internalname ;
      private string edtavEnvironmentname_Internalname ;
      private string AV22EnvironmentName ;
      private string edtavEnvironmentname_Jsonclick ;
      private string divTable_container_environmentsecurityprotocol_Internalname ;
      private string chkavEnvironmentsecurityprotocol_Internalname ;
      private string divTable_container_environmenthost_Internalname ;
      private string edtavEnvironmenthost_Internalname ;
      private string AV21EnvironmentHost ;
      private string edtavEnvironmenthost_Jsonclick ;
      private string divTable_container_environmentport_Internalname ;
      private string edtavEnvironmentport_Internalname ;
      private string edtavEnvironmentport_Jsonclick ;
      private string divTable_container_environmentvirtualdirectory_Internalname ;
      private string edtavEnvironmentvirtualdirectory_Internalname ;
      private string AV27EnvironmentVirtualDirectory ;
      private string edtavEnvironmentvirtualdirectory_Jsonclick ;
      private string divTable_container_environmentprogrampackage_Internalname ;
      private string edtavEnvironmentprogrampackage_Internalname ;
      private string AV25EnvironmentProgramPackage ;
      private string edtavEnvironmentprogrampackage_Jsonclick ;
      private string divTable_container_environmentprogramextension_Internalname ;
      private string edtavEnvironmentprogramextension_Internalname ;
      private string AV24EnvironmentProgramExtension ;
      private string edtavEnvironmentprogramextension_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divColumns_maincolumnstable_Internalname ;
      private string divColumncontainertable_column_Internalname ;
      private string divResponsivetable_mainattributes_permissions_Internalname ;
      private string divResponsivetable_mainattributes_permissions_Class ;
      private string divTitlecell_attributes_permissions_Internalname ;
      private string divAttributescontainertable_permissions_Internalname ;
      private string WebComp_Permissionswc_Component ;
      private string OldPermissionswc ;
      private string divColumncontainertable_column1_Internalname ;
      private string divResponsivetable_mainattributes_menus_Internalname ;
      private string divResponsivetable_mainattributes_menus_Class ;
      private string divTitlecell_attributes_menus_Internalname ;
      private string divAttributescontainertable_menus_Internalname ;
      private string WebComp_Menuswc_Component ;
      private string OldMenuswc ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string imgUpdate_Internalname ;
      private string imgUpdate_Tooltiptext ;
      private string imgDelete_Internalname ;
      private string imgDelete_Tooltiptext ;
      private string bttConfirm_Internalname ;
      private string bttCancel_Internalname ;
      private string bttConfirm_Caption ;
      private string imgCollapsibleimage_permissions_Internalname ;
      private string imgCollapsibleimage_menus_Internalname ;
      private string sStyleString ;
      private string tblTitlecontainertable_menus_Internalname ;
      private string lblTextblock_attributes_menus_Internalname ;
      private string lblTextblock_attributes_menus_Jsonclick ;
      private string tblCollapsibleimagecontainer_menus_Internalname ;
      private string imgCollapsibleimage_menus_Jsonclick ;
      private string tblTitlecontainertable_permissions_Internalname ;
      private string lblTextblock_attributes_permissions_Internalname ;
      private string lblTextblock_attributes_permissions_Jsonclick ;
      private string tblCollapsibleimagecontainer_permissions_Internalname ;
      private string imgCollapsibleimage_permissions_Jsonclick ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Jsonclick ;
      private string tblActionscontainertableright_actions2_Internalname ;
      private string imgUpdate_Jsonclick ;
      private string imgDelete_Jsonclick ;
      private string tblTitlecontainertable_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Jsonclick ;
      private DateTime AV52ClientRevoked ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Tabs_tabscontrol_Historymanagement ;
      private bool wbLoad ;
      private bool AV40UseAbsoluteUrlByEnvironment ;
      private bool AV5AccessRequiresPermission ;
      private bool AV11ClientAllowRemoteAuth ;
      private bool AV10ClientAllowGetUserRoles ;
      private bool AV9ClientAllowGetUserAddData ;
      private bool AV51ClientAllowGetSessionIniProp ;
      private bool AV47ClientAllowRemoteRestAuth ;
      private bool AV48ClientAllowGetUserRolesRest ;
      private bool AV49ClientAllowGetUserAddDataRest ;
      private bool AV50ClientAllowGetSessionIniPropRest ;
      private bool AV53ClientAccessUniqueByUser ;
      private bool AV59SSORestEnable ;
      private bool AV62STSProtocolEnable ;
      private bool AV26EnvironmentSecurityProtocol ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Permissionswc ;
      private bool bDynCreated_Menuswc ;
      private string AV31HomeObject ;
      private string AV34LogoutObject ;
      private string AV16ClientLocalLoginURL ;
      private string AV12ClientCallbackURL ;
      private string AV15ClientImageURL ;
      private string AV54SSORestServerURL ;
      private string AV64STSAuthorizationUserName ;
      private string AV56STSServerURL ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private string imgCollapsibleimage_permissions_Bitmap ;
      private string imgCollapsibleimage_menus_Bitmap ;
      private GXWebComponent WebComp_Permissionswc ;
      private GXWebComponent WebComp_Menuswc ;
      private GXUserControl ucTabs_tabscontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCheckbox chkavUseabsoluteurlbyenvironment ;
      private GXCombobox cmbavMainmenu ;
      private GXCheckbox chkavAccessrequirespermission ;
      private GXCheckbox chkavClientallowremoteauth ;
      private GXCheckbox chkavClientallowgetuserroles ;
      private GXCheckbox chkavClientallowgetuseradddata ;
      private GXCheckbox chkavClientallowgetsessioniniprop ;
      private GXCheckbox chkavClientallowremoterestauth ;
      private GXCheckbox chkavClientallowgetuserrolesrest ;
      private GXCheckbox chkavClientallowgetuseradddatarest ;
      private GXCheckbox chkavClientallowgetsessioniniproprest ;
      private GXCheckbox chkavClientaccessuniquebyuser ;
      private GXCheckbox chkavSsorestenable ;
      private GXCombobox cmbavSsorestmode ;
      private GXCheckbox chkavStsprotocolenable ;
      private GXCombobox cmbavStsmode ;
      private GXCheckbox chkavEnvironmentsecurityprotocol ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV29Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV69GXV1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV28Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV44Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV45MenuFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV41User ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV55GAMUser ;
      private GeneXus.Utils.SdtMessages_Message AV36Message ;
   }

   public class entryapplication__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class entryapplication__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class entryapplication__gam : DataStoreHelperBase, IDataStoreHelper
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

 public override string getDataStoreName( )
 {
    return "GAM";
 }

}

public class entryapplication__default : DataStoreHelperBase, IDataStoreHelper
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
