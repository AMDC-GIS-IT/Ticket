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
   public class entryuser : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryuser( )
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

      public entryuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV34UserId = aP1_UserId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_UserId=this.AV34UserId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGender = new GXCombobox();
         chkavIsactive = new GXCheckbox();
         chkavIsenabledinrepository = new GXCheckbox();
         chkavDontreciveinformation = new GXCheckbox();
         chkavCanotchangepassword = new GXCheckbox();
         chkavMustchangepassword = new GXCheckbox();
         chkavPasswordneverexpires = new GXCheckbox();
         chkavIsblocked = new GXCheckbox();
         cmbavSecuritypolicyid = new GXCombobox();
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
                  AV34UserId = GetPar( "UserId");
                  AssignAttri("", false, "AV34UserId", AV34UserId);
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
         PA472( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START472( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418818509", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV34UserId))}, new string[] {"Gx_mode","UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "LINESEPARATORCONTENT_LINESEPARATOR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Rolescomponent == null ) )
         {
            WebComp_Rolescomponent.componentjscripts();
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
            WE472( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT472( ) ;
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
         return formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV34UserId))}, new string[] {"Gx_mode","UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario" ;
      }

      protected void WB470( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, lblTitle_Caption, "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecell_attributes_attributes_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_25_472( true) ;
         }
         else
         {
            wb_table1_25_472( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_472e( bool wbgen )
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
            wb_table2_37_472( true) ;
         }
         else
         {
            wb_table2_37_472( false) ;
         }
         return  ;
      }

      protected void wb_table2_37_472e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable_container_userid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUserid_Internalname, StringUtil.RTrim( AV34UserId), StringUtil.RTrim( context.localUtil.Format( AV34UserId, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_usernamespace_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsernamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsernamespace_Internalname, "Namespace", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsernamespace_Internalname, StringUtil.RTrim( AV35UserNameSpace), StringUtil.RTrim( context.localUtil.Format( AV35UserNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsernamespace_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsernamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV36Name, StringUtil.RTrim( context.localUtil.Format( AV36Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_email_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Correo electrónico", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV37Email, StringUtil.RTrim( context.localUtil.Format( AV37Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_firstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, "Primer nombre", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV38FirstName), StringUtil.RTrim( context.localUtil.Format( AV38FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_lastname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, "Apellido", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV39LastName), StringUtil.RTrim( context.localUtil.Format( AV39LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_password_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Contraseña", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV40Password), StringUtil.RTrim( context.localUtil.Format( AV40Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", edtavPassword_Visible, edtavPassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_passwordconf_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPasswordconf_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, "Contraseña (confirmación)", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV41PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV41PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", edtavPasswordconf_Visible, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_urlimage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUrlimage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlimage_Internalname, "URL avatar usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlimage_Internalname, AV55URLImage, StringUtil.RTrim( context.localUtil.Format( AV55URLImage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlimage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUrlimage_Enabled, 1, "text", "", 400, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_birthday_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, "Fecha de nacimiento", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV42Birthday, "99/99/9999"), context.localUtil.Format( AV42Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavBirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gender_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, "Género", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV43Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn Attribute_Required", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "", true, 1, "HLP_K2BFSG\\EntryUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV43Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_isactive_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_isactive_Internalname, "Cuenta activa?", "", "", lblTextblock_var_isactive_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isactivefieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsactive_Internalname, "Cuenta activa?", "gx-form-item CheckBoxAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsactive_Internalname, StringUtil.BoolToStr( AV44IsActive), "", "Cuenta activa?", chkavIsactive.Visible, chkavIsactive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(115, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,115);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavActivationdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavActivationdate_Internalname, context.localUtil.TToC( AV45ActivationDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV45ActivationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActivationdate_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", edtavActivationdate_Visible, edtavActivationdate_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavActivationdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavActivationdate_Visible==0)||(edtavActivationdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTable_container_isenabledinrepository_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_isenabledinrepository_Internalname, "Activo en repositorio", "", "", lblTextblock_var_isenabledinrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isenabledinrepositoryfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenabledinrepository_Internalname, "Activo en repositorio", "gx-form-item CheckBoxAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenabledinrepository_Internalname, StringUtil.BoolToStr( AV46IsEnabledInRepository), "", "Activo en repositorio", chkavIsenabledinrepository.Visible, chkavIsenabledinrepository.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(124, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,124);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEnable_Internalname, "", bttEnable_Caption, bttEnable_Jsonclick, 5, "", "", StyleString, ClassString, bttEnable_Visible, bttEnable_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ENABLE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_lineseparator_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_lineseparator_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lineseparator_Class, "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lineseparator_Internalname, "Avanzado", "", "", lblLineseparatortitle_lineseparator_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11471_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_lineseparator_Internalname, divLineseparatorcontent_lineseparator_Visible, 0, "px", 0, "px", divLineseparatorcontent_lineseparator_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_externalid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavExternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExternalid_Internalname, "Identificador externo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavExternalid_Internalname, AV47ExternalId, StringUtil.RTrim( context.localUtil.Format( AV47ExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavExternalid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavExternalid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_urlprofile_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUrlprofile_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUrlprofile_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlprofile_Internalname, "URL del perfil", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlprofile_Internalname, AV48URLProfile, StringUtil.RTrim( context.localUtil.Format( AV48URLProfile, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlprofile_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUrlprofile_Visible, edtavUrlprofile_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_dontreciveinformation_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavDontreciveinformation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDontreciveinformation_Internalname, "No desea recibir información adicional", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDontreciveinformation_Internalname, StringUtil.BoolToStr( AV49DontReciveInformation), "", "No desea recibir información adicional", 1, chkavDontreciveinformation.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(149, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,149);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_canotchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavCanotchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCanotchangepassword_Internalname, "No puede cambiar la contraseña", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCanotchangepassword_Internalname, StringUtil.BoolToStr( AV50CanotChangePassword), "", "No puede cambiar la contraseña", 1, chkavCanotchangepassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(155, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,155);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_mustchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavMustchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMustchangepassword_Internalname, "Debe cambiar la contraseña", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMustchangepassword_Internalname, StringUtil.BoolToStr( AV51MustChangePassword), "", "Debe cambiar la contraseña", 1, chkavMustchangepassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(161, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,161);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_passwordneverexpires_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavPasswordneverexpires_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavPasswordneverexpires_Internalname, "Contraseña nunca expira", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavPasswordneverexpires_Internalname, StringUtil.BoolToStr( AV52PasswordNeverExpires), "", "Contraseña nunca expira", 1, chkavPasswordneverexpires.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(167, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,167);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_isblocked_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavIsblocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsblocked_Internalname, "Usuario bloqueado", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsblocked_Internalname, StringUtil.BoolToStr( AV53IsBlocked), "", "Usuario bloqueado", 1, chkavIsblocked.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(173, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,173);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_securitypolicyid_Internalname, divTable_container_securitypolicyid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavSecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecuritypolicyid_Internalname, "Id política seguridad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecuritypolicyid, cmbavSecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0)), 1, cmbavSecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecuritypolicyid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "", true, 1, "HLP_K2BFSG\\EntryUser.htm");
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", (string)(cmbavSecuritypolicyid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_185_472( true) ;
         }
         else
         {
            wb_table3_185_472( false) ;
         }
         return  ;
      }

      protected void wb_table3_185_472e( bool wbgen )
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0195"+"", StringUtil.RTrim( WebComp_Rolescomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0195"+""+"\""+((WebComp_Rolescomponent_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRolescomponent), StringUtil.Lower( WebComp_Rolescomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0195"+"");
                  }
                  WebComp_Rolescomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRolescomponent), StringUtil.Lower( WebComp_Rolescomponent_Component)) != 0 )
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

      protected void START472( )
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
            Form.Meta.addItem("description", "Usuario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP470( ) ;
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                              E12472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13472 ();
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
                                    E14472 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ENABLE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Enable' */
                              E15472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16472 ();
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
                        if ( nCmpId == 195 )
                        {
                           OldRolescomponent = cgiGet( "W0195");
                           if ( ( StringUtil.Len( OldRolescomponent) == 0 ) || ( StringUtil.StrCmp(OldRolescomponent, WebComp_Rolescomponent_Component) != 0 ) )
                           {
                              WebComp_Rolescomponent = getWebComponent(GetType(), "GeneXus.Programs", OldRolescomponent, new Object[] {context} );
                              WebComp_Rolescomponent.ComponentInit();
                              WebComp_Rolescomponent.Name = "OldRolescomponent";
                              WebComp_Rolescomponent_Component = OldRolescomponent;
                           }
                           if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
                           {
                              WebComp_Rolescomponent.componentprocess("W0195", "", sEvt);
                           }
                           WebComp_Rolescomponent_Component = OldRolescomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE472( )
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

      protected void PA472( )
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
               GX_FocusControl = edtavUsernamespace_Internalname;
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
         if ( cmbavGender.ItemCount > 0 )
         {
            AV43Gender = cmbavGender.getValidValue(AV43Gender);
            AssignAttri("", false, "AV43Gender", AV43Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV43Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         AV44IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV44IsActive));
         AssignAttri("", false, "AV44IsActive", AV44IsActive);
         AV46IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV46IsEnabledInRepository));
         AssignAttri("", false, "AV46IsEnabledInRepository", AV46IsEnabledInRepository);
         AV49DontReciveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV49DontReciveInformation));
         AssignAttri("", false, "AV49DontReciveInformation", AV49DontReciveInformation);
         AV50CanotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV50CanotChangePassword));
         AssignAttri("", false, "AV50CanotChangePassword", AV50CanotChangePassword);
         AV51MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV51MustChangePassword));
         AssignAttri("", false, "AV51MustChangePassword", AV51MustChangePassword);
         AV52PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV52PasswordNeverExpires));
         AssignAttri("", false, "AV52PasswordNeverExpires", AV52PasswordNeverExpires);
         AV53IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV53IsBlocked));
         AssignAttri("", false, "AV53IsBlocked", AV53IsBlocked);
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV54SecurityPolicyId = (int)(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV54SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV54SecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF472( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
      }

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13472 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Rolescomponent_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
               {
                  WebComp_Rolescomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E16472 ();
            WB470( ) ;
         }
      }

      protected void send_integrity_lvl_hashes472( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12472 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            /* Read variables values. */
            AV34UserId = cgiGet( edtavUserid_Internalname);
            AssignAttri("", false, "AV34UserId", AV34UserId);
            AV35UserNameSpace = cgiGet( edtavUsernamespace_Internalname);
            AssignAttri("", false, "AV35UserNameSpace", AV35UserNameSpace);
            AV36Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV36Name", AV36Name);
            AV37Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV37Email", AV37Email);
            AV38FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV38FirstName", AV38FirstName);
            AV39LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV39LastName", AV39LastName);
            AV40Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV40Password", AV40Password);
            AV41PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV41PasswordConf", AV41PasswordConf);
            AV55URLImage = cgiGet( edtavUrlimage_Internalname);
            AssignAttri("", false, "AV55URLImage", AV55URLImage);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Birthday"}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV42Birthday", context.localUtil.Format(AV42Birthday, "99/99/9999"));
            }
            else
            {
               AV42Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), 2);
               AssignAttri("", false, "AV42Birthday", context.localUtil.Format(AV42Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV43Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV43Gender", AV43Gender);
            AV44IsActive = StringUtil.StrToBool( cgiGet( chkavIsactive_Internalname));
            AssignAttri("", false, "AV44IsActive", AV44IsActive);
            if ( context.localUtil.VCDateTime( cgiGet( edtavActivationdate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Activation Date"}), 1, "vACTIVATIONDATE");
               GX_FocusControl = edtavActivationdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45ActivationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV45ActivationDate", context.localUtil.TToC( AV45ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV45ActivationDate = context.localUtil.CToT( cgiGet( edtavActivationdate_Internalname));
               AssignAttri("", false, "AV45ActivationDate", context.localUtil.TToC( AV45ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            AV46IsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavIsenabledinrepository_Internalname));
            AssignAttri("", false, "AV46IsEnabledInRepository", AV46IsEnabledInRepository);
            AV47ExternalId = cgiGet( edtavExternalid_Internalname);
            AssignAttri("", false, "AV47ExternalId", AV47ExternalId);
            AV48URLProfile = cgiGet( edtavUrlprofile_Internalname);
            AssignAttri("", false, "AV48URLProfile", AV48URLProfile);
            AV49DontReciveInformation = StringUtil.StrToBool( cgiGet( chkavDontreciveinformation_Internalname));
            AssignAttri("", false, "AV49DontReciveInformation", AV49DontReciveInformation);
            AV50CanotChangePassword = StringUtil.StrToBool( cgiGet( chkavCanotchangepassword_Internalname));
            AssignAttri("", false, "AV50CanotChangePassword", AV50CanotChangePassword);
            AV51MustChangePassword = StringUtil.StrToBool( cgiGet( chkavMustchangepassword_Internalname));
            AssignAttri("", false, "AV51MustChangePassword", AV51MustChangePassword);
            AV52PasswordNeverExpires = StringUtil.StrToBool( cgiGet( chkavPasswordneverexpires_Internalname));
            AssignAttri("", false, "AV52PasswordNeverExpires", AV52PasswordNeverExpires);
            AV53IsBlocked = StringUtil.StrToBool( cgiGet( chkavIsblocked_Internalname));
            AssignAttri("", false, "AV53IsBlocked", AV53IsBlocked);
            cmbavSecuritypolicyid.CurrentValue = cgiGet( cmbavSecuritypolicyid_Internalname);
            AV54SecurityPolicyId = (int)(NumberUtil.Val( cgiGet( cmbavSecuritypolicyid_Internalname), "."));
            AssignAttri("", false, "AV54SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV54SecurityPolicyId), 9, 0));
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
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         edtavEmail_Enabled = 1;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
         edtavFirstname_Enabled = 1;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
         edtavLastname_Enabled = 1;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
         edtavUrlimage_Enabled = 1;
         AssignProp("", false, edtavUrlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlimage_Enabled), 5, 0), true);
         edtavUrlprofile_Enabled = 1;
         AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
         edtavExternalid_Enabled = 1;
         AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
         edtavBirthday_Enabled = 1;
         AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
         cmbavGender.Enabled = 1;
         AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
         chkavIsactive.Enabled = 1;
         AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         chkavDontreciveinformation.Enabled = 1;
         AssignProp("", false, chkavDontreciveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreciveinformation.Enabled), 5, 0), true);
         chkavCanotchangepassword.Enabled = 1;
         AssignProp("", false, chkavCanotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCanotchangepassword.Enabled), 5, 0), true);
         chkavMustchangepassword.Enabled = 1;
         AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
         chkavIsblocked.Enabled = 1;
         AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
         chkavPasswordneverexpires.Enabled = 1;
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
         cmbavSecuritypolicyid.Enabled = 1;
         AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
         AV36Name = "";
         AssignAttri("", false, "AV36Name", AV36Name);
         AV37Email = "";
         AssignAttri("", false, "AV37Email", AV37Email);
         AV38FirstName = "";
         AssignAttri("", false, "AV38FirstName", AV38FirstName);
         AV39LastName = "";
         AssignAttri("", false, "AV39LastName", AV39LastName);
         AV55URLImage = "";
         AssignAttri("", false, "AV55URLImage", AV55URLImage);
         AV48URLProfile = "";
         AssignAttri("", false, "AV48URLProfile", AV48URLProfile);
         AV47ExternalId = "";
         AssignAttri("", false, "AV47ExternalId", AV47ExternalId);
         AV42Birthday = DateTime.MinValue;
         AssignAttri("", false, "AV42Birthday", context.localUtil.Format(AV42Birthday, "99/99/9999"));
         AV43Gender = "";
         AssignAttri("", false, "AV43Gender", AV43Gender);
         AV44IsActive = true;
         AssignAttri("", false, "AV44IsActive", AV44IsActive);
         AV49DontReciveInformation = false;
         AssignAttri("", false, "AV49DontReciveInformation", AV49DontReciveInformation);
         AV50CanotChangePassword = false;
         AssignAttri("", false, "AV50CanotChangePassword", AV50CanotChangePassword);
         AV51MustChangePassword = false;
         AssignAttri("", false, "AV51MustChangePassword", AV51MustChangePassword);
         AV53IsBlocked = false;
         AssignAttri("", false, "AV53IsBlocked", AV53IsBlocked);
         AV52PasswordNeverExpires = false;
         AssignAttri("", false, "AV52PasswordNeverExpires", AV52PasswordNeverExpires);
         AV54SecurityPolicyId = 0;
         AssignAttri("", false, "AV54SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV54SecurityPolicyId), 9, 0));
         AV7SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV13FilterSecPol, out  AV12Errors);
         cmbavSecuritypolicyid.addItem("0", "(Ninguno)", 0);
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV7SecurityPolicies.Count )
         {
            AV8SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV7SecurityPolicies.Item(AV59GXV1));
            cmbavSecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8SecurityPolicy.gxTpr_Id), 9, 0)), AV8SecurityPolicy.gxTpr_Name, 0);
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         chkavIsenabledinrepository.Visible = 0;
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
         bttEnable_Visible = 0;
         AssignProp("", false, bttEnable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnable_Visible), 5, 0), true);
         bttEnable_Enabled = 0;
         AssignProp("", false, bttEnable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnable_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtavUrlprofile_Visible = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            edtavPassword_Visible = 1;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            edtavPasswordconf_Visible = 1;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            AV6Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            AV35UserNameSpace = AV6Repository.gxTpr_Namespace;
            AssignAttri("", false, "AV35UserNameSpace", AV35UserNameSpace);
            lblTitle_Caption = "Usuario";
            AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
            chkavIsactive.Visible = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            edtavActivationdate_Visible = 0;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            WebComp_Rolescomponent_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0195"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
         }
         else
         {
            chkavIsactive.Visible = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            edtavActivationdate_Visible = 1;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            edtavUrlprofile_Visible = 1;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            edtavPassword_Visible = 0;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            edtavPasswordconf_Visible = 0;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            AV9User.load( AV34UserId);
            AV10AuthTypeId = AV5AuthenticationType.gettypebyname(AV9User.gxTpr_Authenticationtypename, out  AV12Errors);
            if ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            AV34UserId = AV9User.gxTpr_Guid;
            AssignAttri("", false, "AV34UserId", AV34UserId);
            AV35UserNameSpace = AV9User.gxTpr_Namespace;
            AssignAttri("", false, "AV35UserNameSpace", AV35UserNameSpace);
            AV36Name = StringUtil.Trim( AV9User.gxTpr_Name);
            AssignAttri("", false, "AV36Name", AV36Name);
            AV37Email = StringUtil.Trim( AV9User.gxTpr_Email);
            AssignAttri("", false, "AV37Email", AV37Email);
            AV38FirstName = StringUtil.Trim( AV9User.gxTpr_Firstname);
            AssignAttri("", false, "AV38FirstName", AV38FirstName);
            AV39LastName = StringUtil.Trim( AV9User.gxTpr_Lastname);
            AssignAttri("", false, "AV39LastName", AV39LastName);
            AV48URLProfile = StringUtil.Trim( AV9User.gxTpr_Urlprofile);
            AssignAttri("", false, "AV48URLProfile", AV48URLProfile);
            AV55URLImage = StringUtil.Trim( AV9User.gxTpr_Urlimage);
            AssignAttri("", false, "AV55URLImage", AV55URLImage);
            AV47ExternalId = AV9User.gxTpr_Externalid;
            AssignAttri("", false, "AV47ExternalId", AV47ExternalId);
            AV42Birthday = AV9User.gxTpr_Birthday;
            AssignAttri("", false, "AV42Birthday", context.localUtil.Format(AV42Birthday, "99/99/9999"));
            AV43Gender = AV9User.gxTpr_Gender;
            AssignAttri("", false, "AV43Gender", AV43Gender);
            AV44IsActive = AV9User.gxTpr_Isactive;
            AssignAttri("", false, "AV44IsActive", AV44IsActive);
            AV45ActivationDate = AV9User.gxTpr_Activationdate;
            AssignAttri("", false, "AV45ActivationDate", context.localUtil.TToC( AV45ActivationDate, 10, 5, 0, 3, "/", ":", " "));
            AV49DontReciveInformation = AV9User.gxTpr_Dontreceiveinformation;
            AssignAttri("", false, "AV49DontReciveInformation", AV49DontReciveInformation);
            AV50CanotChangePassword = AV9User.gxTpr_Cannotchangepassword;
            AssignAttri("", false, "AV50CanotChangePassword", AV50CanotChangePassword);
            AV51MustChangePassword = AV9User.gxTpr_Mustchangepassword;
            AssignAttri("", false, "AV51MustChangePassword", AV51MustChangePassword);
            AV52PasswordNeverExpires = AV9User.gxTpr_Passwordneverexpires;
            AssignAttri("", false, "AV52PasswordNeverExpires", AV52PasswordNeverExpires);
            AV53IsBlocked = AV9User.gxTpr_Isblocked;
            AssignAttri("", false, "AV53IsBlocked", AV53IsBlocked);
            AV54SecurityPolicyId = AV9User.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV54SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV54SecurityPolicyId), 9, 0));
            AV46IsEnabledInRepository = AV9User.gxTpr_Isenabledinrepository;
            AssignAttri("", false, "AV46IsEnabledInRepository", AV46IsEnabledInRepository);
            bttEnable_Caption = (AV46IsEnabledInRepository ? "Deshabilitar" : "Habilitar");
            AssignProp("", false, bttEnable_Internalname, "Caption", bttEnable_Caption, true);
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               lblTitle_Caption = "Usuario"+" - "+AV36Name;
               AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
               chkavIsenabledinrepository.Visible = 1;
               AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
               bttEnable_Visible = 1;
               AssignProp("", false, bttEnable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnable_Visible), 5, 0), true);
               bttEnable_Enabled = 1;
               AssignProp("", false, bttEnable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnable_Enabled), 5, 0), true);
               WebComp_Rolescomponent_Visible = 0;
               AssignProp("", false, "gxHTMLWrpW0195"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  lblTitle_Caption = "Usuario"+" - "+AV36Name;
                  AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
                  WebComp_Rolescomponent_Visible = 0;
                  AssignProp("", false, "gxHTMLWrpW0195"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
                  {
                     lblTitle_Caption = "Usuario"+" - "+AV36Name;
                     AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
                     /* Object Property */
                     if ( true )
                     {
                        bDynCreated_Rolescomponent = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Rolescomponent_Component), StringUtil.Lower( "K2BFSG.WWUserRole")) != 0 )
                     {
                        WebComp_Rolescomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wwuserrole", new Object[] {context} );
                        WebComp_Rolescomponent.ComponentInit();
                        WebComp_Rolescomponent.Name = "K2BFSG.WWUserRole";
                        WebComp_Rolescomponent_Component = "K2BFSG.WWUserRole";
                     }
                     if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
                     {
                        WebComp_Rolescomponent.setjustcreated();
                        WebComp_Rolescomponent.componentprepare(new Object[] {(string)"W0195",(string)"",(string)AV34UserId});
                        WebComp_Rolescomponent.componentbind(new Object[] {(string)"vUSERID"});
                     }
                     if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Rolescomponent )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0195"+"");
                        WebComp_Rolescomponent.componentdraw();
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavEmail_Enabled = 0;
            AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
            edtavFirstname_Enabled = 0;
            AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
            edtavLastname_Enabled = 0;
            AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
            edtavUrlprofile_Enabled = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            edtavUrlimage_Enabled = 0;
            AssignProp("", false, edtavUrlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlimage_Enabled), 5, 0), true);
            edtavExternalid_Enabled = 0;
            AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
            edtavBirthday_Enabled = 0;
            AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
            cmbavGender.Enabled = 0;
            AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
            chkavDontreciveinformation.Enabled = 0;
            AssignProp("", false, chkavDontreciveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreciveinformation.Enabled), 5, 0), true);
            chkavCanotchangepassword.Enabled = 0;
            AssignProp("", false, chkavCanotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCanotchangepassword.Enabled), 5, 0), true);
            chkavMustchangepassword.Enabled = 0;
            AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
            chkavIsblocked.Enabled = 0;
            AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
            chkavPasswordneverexpires.Enabled = 0;
            AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
            cmbavSecuritypolicyid.Enabled = 0;
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
         }
         if ( AV44IsActive )
         {
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
         else
         {
            chkavIsactive.Enabled = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12472 ();
         if (returnInSub) return;
      }

      protected void E12472( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         divLineseparatorcontent_lineseparator_Visible = 0;
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0), true);
         divLineseparatorcontent_lineseparator_Class = "Section_LineSeparatorContentClose";
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Class", divLineseparatorcontent_lineseparator_Class, true);
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorClose";
         AssignProp("", false, divLineseparatorheader_lineseparator_Internalname, "Class", divLineseparatorheader_lineseparator_Class, true);
      }

      protected void E13472( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         divTable_container_securitypolicyid_Visible = 0;
         AssignProp("", false, divTable_container_securitypolicyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable_container_securitypolicyid_Visible), 5, 0), true);
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
         cmbavGender.CurrentValue = StringUtil.RTrim( AV43Gender);
         AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0));
         AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9User", AV9User);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
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
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14472 ();
         if (returnInSub) return;
      }

      protected void E14472( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9User", AV9User);
      }

      protected void S152( )
      {
         /* 'U_ENABLE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV9User.load( AV34UserId);
            if ( AV46IsEnabledInRepository )
            {
               AV14isOK = AV9User.repositorydisable(out  AV12Errors);
            }
            else
            {
               AV14isOK = AV9User.repositoryenable(out  AV12Errors);
            }
            if ( ! AV14isOK )
            {
               AV60GXV2 = 1;
               while ( AV60GXV2 <= AV12Errors.Count )
               {
                  AV11Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV60GXV2));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV11Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV11Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV60GXV2 = (int)(AV60GXV2+1);
               }
            }
            else
            {
               context.CommitDataStores("k2bfsg.entryuser",pr_default);
               CallWebObject(formatLink("k2bfsg.wwuser.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
      }

      protected void E15472( )
      {
         /* 'E_Enable' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ENABLE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9User", AV9User);
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            AV9User.gxTpr_Guid = AV34UserId;
            AV17PasswordIsOK = true;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  if ( StringUtil.StrCmp(AV40Password, AV41PasswordConf) != 0 )
                  {
                     AV17PasswordIsOK = false;
                     GX_msglist.addItem("Las contraseñas no coinciden.");
                  }
               }
               else
               {
                  AV9User.load( AV34UserId);
               }
               if ( AV17PasswordIsOK )
               {
                  AV9User.gxTpr_Name = AV36Name;
                  AV9User.gxTpr_Email = AV37Email;
                  AV9User.gxTpr_Firstname = AV38FirstName;
                  AV9User.gxTpr_Lastname = AV39LastName;
                  AV9User.gxTpr_Password = AV40Password;
                  AV9User.gxTpr_Externalid = AV47ExternalId;
                  AV9User.gxTpr_Birthday = AV42Birthday;
                  AV9User.gxTpr_Gender = AV43Gender;
                  AV9User.gxTpr_Isactive = AV44IsActive;
                  AV9User.gxTpr_Urlimage = AV55URLImage;
                  AV9User.gxTpr_Urlprofile = AV48URLProfile;
                  AV9User.gxTpr_Dontreceiveinformation = AV49DontReciveInformation;
                  AV9User.gxTpr_Cannotchangepassword = AV50CanotChangePassword;
                  AV9User.gxTpr_Mustchangepassword = AV51MustChangePassword;
                  AV9User.gxTpr_Isblocked = AV53IsBlocked;
                  AV9User.gxTpr_Passwordneverexpires = AV52PasswordNeverExpires;
                  AV9User.gxTpr_Securitypolicyid = AV54SecurityPolicyId;
                  AV9User.save();
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV9User.delete();
            }
            if ( AV17PasswordIsOK )
            {
               if ( AV9User.success() )
               {
                  AV28Message = new GeneXus.Utils.SdtMessages_Message(context);
                  if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
                  {
                     AV28Message.gxTpr_Description = StringUtil.Format( "Usuario %1 creado", AV9User.gxTpr_Name, "", "", "", "", "", "", "", "");
                  }
                  else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     AV28Message.gxTpr_Description = StringUtil.Format( "Usuario %1 actualizado", AV9User.gxTpr_Name, "", "", "", "", "", "", "", "");
                  }
                  else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                  {
                     AV28Message.gxTpr_Description = StringUtil.Format( "Usuario %1 borrado", AV36Name, "", "", "", "", "", "", "", "");
                  }
                  new k2btoolsmessagequeueadd(context ).execute(  AV28Message) ;
                  context.CommitDataStores("k2bfsg.entryuser",pr_default);
                  CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV9User.gxTpr_Guid))}, new string[] {"Mode","UserId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV12Errors = AV9User.geterrors();
                  AV61GXV3 = 1;
                  while ( AV61GXV3 <= AV12Errors.Count )
                  {
                     AV11Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV61GXV3));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV11Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV11Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV61GXV3 = (int)(AV61GXV3+1);
                  }
               }
            }
         }
      }

      protected void S162( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwuser.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV34UserId))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S182( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV34UserId))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E16472( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_185_472( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions1_Internalname, tblActionscontainertableleft_actions1_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e17471_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_185_472e( true) ;
         }
         else
         {
            wb_table3_185_472e( false) ;
         }
      }

      protected void wb_table2_37_472( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableright_actions2_Internalname, tblActionscontainertableright_actions2_Internalname, "", "K2BTableActionsRightContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e18471_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e19471_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_37_472e( true) ;
         }
         else
         {
            wb_table2_37_472e( false) ;
         }
      }

      protected void wb_table1_25_472( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTitlecontainertable_attributes_Internalname, tblTitlecontainertable_attributes_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_attributes_attributes_Internalname, "General", "", "", lblTextblock_attributes_attributes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_472e( true) ;
         }
         else
         {
            wb_table1_25_472e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV34UserId = (string)getParm(obj,1);
         AssignAttri("", false, "AV34UserId", AV34UserId);
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Rolescomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
            {
               WebComp_Rolescomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188192515", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryuser.js", "?2024188192520", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", "Not Specified", 0);
         cmbavGender.addItem("F", "Female", 0);
         cmbavGender.addItem("M", "Male", 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV43Gender = cmbavGender.getValidValue(AV43Gender);
            AssignAttri("", false, "AV43Gender", AV43Gender);
         }
         chkavIsactive.Name = "vISACTIVE";
         chkavIsactive.WebTags = "";
         chkavIsactive.Caption = "";
         AssignProp("", false, chkavIsactive_Internalname, "TitleCaption", chkavIsactive.Caption, true);
         chkavIsactive.CheckedValue = "false";
         AV44IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV44IsActive));
         AssignAttri("", false, "AV44IsActive", AV44IsActive);
         chkavIsenabledinrepository.Name = "vISENABLEDINREPOSITORY";
         chkavIsenabledinrepository.WebTags = "";
         chkavIsenabledinrepository.Caption = "";
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "TitleCaption", chkavIsenabledinrepository.Caption, true);
         chkavIsenabledinrepository.CheckedValue = "false";
         AV46IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV46IsEnabledInRepository));
         AssignAttri("", false, "AV46IsEnabledInRepository", AV46IsEnabledInRepository);
         chkavDontreciveinformation.Name = "vDONTRECIVEINFORMATION";
         chkavDontreciveinformation.WebTags = "";
         chkavDontreciveinformation.Caption = "";
         AssignProp("", false, chkavDontreciveinformation_Internalname, "TitleCaption", chkavDontreciveinformation.Caption, true);
         chkavDontreciveinformation.CheckedValue = "false";
         AV49DontReciveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV49DontReciveInformation));
         AssignAttri("", false, "AV49DontReciveInformation", AV49DontReciveInformation);
         chkavCanotchangepassword.Name = "vCANOTCHANGEPASSWORD";
         chkavCanotchangepassword.WebTags = "";
         chkavCanotchangepassword.Caption = "";
         AssignProp("", false, chkavCanotchangepassword_Internalname, "TitleCaption", chkavCanotchangepassword.Caption, true);
         chkavCanotchangepassword.CheckedValue = "false";
         AV50CanotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV50CanotChangePassword));
         AssignAttri("", false, "AV50CanotChangePassword", AV50CanotChangePassword);
         chkavMustchangepassword.Name = "vMUSTCHANGEPASSWORD";
         chkavMustchangepassword.WebTags = "";
         chkavMustchangepassword.Caption = "";
         AssignProp("", false, chkavMustchangepassword_Internalname, "TitleCaption", chkavMustchangepassword.Caption, true);
         chkavMustchangepassword.CheckedValue = "false";
         AV51MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV51MustChangePassword));
         AssignAttri("", false, "AV51MustChangePassword", AV51MustChangePassword);
         chkavPasswordneverexpires.Name = "vPASSWORDNEVEREXPIRES";
         chkavPasswordneverexpires.WebTags = "";
         chkavPasswordneverexpires.Caption = "";
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "TitleCaption", chkavPasswordneverexpires.Caption, true);
         chkavPasswordneverexpires.CheckedValue = "false";
         AV52PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV52PasswordNeverExpires));
         AssignAttri("", false, "AV52PasswordNeverExpires", AV52PasswordNeverExpires);
         chkavIsblocked.Name = "vISBLOCKED";
         chkavIsblocked.WebTags = "";
         chkavIsblocked.Caption = "";
         AssignProp("", false, chkavIsblocked_Internalname, "TitleCaption", chkavIsblocked.Caption, true);
         chkavIsblocked.CheckedValue = "false";
         AV53IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV53IsBlocked));
         AssignAttri("", false, "AV53IsBlocked", AV53IsBlocked);
         cmbavSecuritypolicyid.Name = "vSECURITYPOLICYID";
         cmbavSecuritypolicyid.WebTags = "";
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV54SecurityPolicyId = (int)(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV54SecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV54SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV54SecurityPolicyId), 9, 0));
         }
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
         edtavUserid_Internalname = "vUSERID";
         divTable_container_userid_Internalname = "TABLE_CONTAINER_USERID";
         edtavUsernamespace_Internalname = "vUSERNAMESPACE";
         divTable_container_usernamespace_Internalname = "TABLE_CONTAINER_USERNAMESPACE";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavEmail_Internalname = "vEMAIL";
         divTable_container_email_Internalname = "TABLE_CONTAINER_EMAIL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divTable_container_firstname_Internalname = "TABLE_CONTAINER_FIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         divTable_container_lastname_Internalname = "TABLE_CONTAINER_LASTNAME";
         edtavPassword_Internalname = "vPASSWORD";
         divTable_container_password_Internalname = "TABLE_CONTAINER_PASSWORD";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divTable_container_passwordconf_Internalname = "TABLE_CONTAINER_PASSWORDCONF";
         edtavUrlimage_Internalname = "vURLIMAGE";
         divTable_container_urlimage_Internalname = "TABLE_CONTAINER_URLIMAGE";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divTable_container_birthday_Internalname = "TABLE_CONTAINER_BIRTHDAY";
         cmbavGender_Internalname = "vGENDER";
         divTable_container_gender_Internalname = "TABLE_CONTAINER_GENDER";
         lblTextblock_var_isactive_Internalname = "TEXTBLOCK_VAR_ISACTIVE";
         chkavIsactive_Internalname = "vISACTIVE";
         edtavActivationdate_Internalname = "vACTIVATIONDATE";
         divTable_container_isactivefieldcontainer_Internalname = "TABLE_CONTAINER_ISACTIVEFIELDCONTAINER";
         divTable_container_isactive_Internalname = "TABLE_CONTAINER_ISACTIVE";
         lblTextblock_var_isenabledinrepository_Internalname = "TEXTBLOCK_VAR_ISENABLEDINREPOSITORY";
         chkavIsenabledinrepository_Internalname = "vISENABLEDINREPOSITORY";
         bttEnable_Internalname = "ENABLE";
         divTable_container_isenabledinrepositoryfieldcontainer_Internalname = "TABLE_CONTAINER_ISENABLEDINREPOSITORYFIELDCONTAINER";
         divTable_container_isenabledinrepository_Internalname = "TABLE_CONTAINER_ISENABLEDINREPOSITORY";
         lblLineseparatortitle_lineseparator_Internalname = "LINESEPARATORTITLE_LINESEPARATOR";
         divLineseparatorheader_lineseparator_Internalname = "LINESEPARATORHEADER_LINESEPARATOR";
         edtavExternalid_Internalname = "vEXTERNALID";
         divTable_container_externalid_Internalname = "TABLE_CONTAINER_EXTERNALID";
         edtavUrlprofile_Internalname = "vURLPROFILE";
         divTable_container_urlprofile_Internalname = "TABLE_CONTAINER_URLPROFILE";
         chkavDontreciveinformation_Internalname = "vDONTRECIVEINFORMATION";
         divTable_container_dontreciveinformation_Internalname = "TABLE_CONTAINER_DONTRECIVEINFORMATION";
         chkavCanotchangepassword_Internalname = "vCANOTCHANGEPASSWORD";
         divTable_container_canotchangepassword_Internalname = "TABLE_CONTAINER_CANOTCHANGEPASSWORD";
         chkavMustchangepassword_Internalname = "vMUSTCHANGEPASSWORD";
         divTable_container_mustchangepassword_Internalname = "TABLE_CONTAINER_MUSTCHANGEPASSWORD";
         chkavPasswordneverexpires_Internalname = "vPASSWORDNEVEREXPIRES";
         divTable_container_passwordneverexpires_Internalname = "TABLE_CONTAINER_PASSWORDNEVEREXPIRES";
         chkavIsblocked_Internalname = "vISBLOCKED";
         divTable_container_isblocked_Internalname = "TABLE_CONTAINER_ISBLOCKED";
         cmbavSecuritypolicyid_Internalname = "vSECURITYPOLICYID";
         divTable_container_securitypolicyid_Internalname = "TABLE_CONTAINER_SECURITYPOLICYID";
         divLineseparatorcontent_lineseparator_Internalname = "LINESEPARATORCONTENT_LINESEPARATOR";
         divLineseparatorcontainer_lineseparator_Internalname = "LINESEPARATORCONTAINER_LINESEPARATOR";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         tblActionscontainertableleft_actions1_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS1";
         divResponsivetable_containernode_actions1_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS1";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divColumncontainertable_column_Internalname = "COLUMNCONTAINERTABLE_COLUMN";
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
         chkavIsblocked.Caption = "Usuario bloqueado";
         chkavPasswordneverexpires.Caption = "Contraseña nunca expira";
         chkavMustchangepassword.Caption = "Debe cambiar la contraseña";
         chkavCanotchangepassword.Caption = "No puede cambiar la contraseña";
         chkavDontreciveinformation.Caption = "No desea recibir información adicional";
         chkavIsenabledinrepository.Caption = "Activo en repositorio";
         chkavIsactive.Caption = "Cuenta activa?";
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
         bttConfirm_Caption = "Confirmar";
         imgDelete_Tooltiptext = "Eliminar";
         imgUpdate_Tooltiptext = "Actualizar";
         WebComp_Rolescomponent_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0195"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
         cmbavSecuritypolicyid_Jsonclick = "";
         cmbavSecuritypolicyid.Enabled = 1;
         divTable_container_securitypolicyid_Visible = 1;
         chkavIsblocked.Enabled = 1;
         chkavPasswordneverexpires.Enabled = 1;
         chkavMustchangepassword.Enabled = 1;
         chkavCanotchangepassword.Enabled = 1;
         chkavDontreciveinformation.Enabled = 1;
         edtavUrlprofile_Jsonclick = "";
         edtavUrlprofile_Enabled = 1;
         edtavUrlprofile_Visible = 1;
         edtavExternalid_Jsonclick = "";
         edtavExternalid_Enabled = 1;
         divLineseparatorcontent_lineseparator_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lineseparator_Visible = 1;
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorOpen";
         bttEnable_Caption = "Habilitar";
         bttEnable_Enabled = 1;
         bttEnable_Visible = 1;
         chkavIsenabledinrepository.Enabled = 1;
         chkavIsenabledinrepository.Visible = 1;
         edtavActivationdate_Jsonclick = "";
         edtavActivationdate_Enabled = 1;
         edtavActivationdate_Visible = 1;
         chkavIsactive.Enabled = 1;
         chkavIsactive.Visible = 1;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         edtavUrlimage_Jsonclick = "";
         edtavUrlimage_Enabled = 1;
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Visible = 1;
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavUsernamespace_Jsonclick = "";
         edtavUsernamespace_Enabled = 1;
         edtavUserid_Jsonclick = "";
         edtavUserid_Enabled = 0;
         lblTitle_Caption = "Usuario";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuario";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divTable_container_securitypolicyid_Visible',ctrl:'TABLE_CONTAINER_SECURITYPOLICYID',prop:'Visible'},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'edtavEmail_Enabled',ctrl:'vEMAIL',prop:'Enabled'},{av:'edtavFirstname_Enabled',ctrl:'vFIRSTNAME',prop:'Enabled'},{av:'edtavLastname_Enabled',ctrl:'vLASTNAME',prop:'Enabled'},{av:'edtavUrlimage_Enabled',ctrl:'vURLIMAGE',prop:'Enabled'},{av:'edtavUrlprofile_Enabled',ctrl:'vURLPROFILE',prop:'Enabled'},{av:'edtavExternalid_Enabled',ctrl:'vEXTERNALID',prop:'Enabled'},{av:'edtavBirthday_Enabled',ctrl:'vBIRTHDAY',prop:'Enabled'},{av:'cmbavGender'},{av:'chkavIsactive.Enabled',ctrl:'vISACTIVE',prop:'Enabled'},{av:'chkavDontreciveinformation.Enabled',ctrl:'vDONTRECIVEINFORMATION',prop:'Enabled'},{av:'chkavCanotchangepassword.Enabled',ctrl:'vCANOTCHANGEPASSWORD',prop:'Enabled'},{av:'chkavMustchangepassword.Enabled',ctrl:'vMUSTCHANGEPASSWORD',prop:'Enabled'},{av:'chkavIsblocked.Enabled',ctrl:'vISBLOCKED',prop:'Enabled'},{av:'chkavPasswordneverexpires.Enabled',ctrl:'vPASSWORDNEVEREXPIRES',prop:'Enabled'},{av:'cmbavSecuritypolicyid'},{av:'AV36Name',fld:'vNAME',pic:''},{av:'AV37Email',fld:'vEMAIL',pic:''},{av:'AV38FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV39LastName',fld:'vLASTNAME',pic:''},{av:'AV55URLImage',fld:'vURLIMAGE',pic:''},{av:'AV48URLProfile',fld:'vURLPROFILE',pic:''},{av:'AV47ExternalId',fld:'vEXTERNALID',pic:''},{av:'AV42Birthday',fld:'vBIRTHDAY',pic:''},{av:'AV43Gender',fld:'vGENDER',pic:''},{av:'AV54SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'chkavIsenabledinrepository.Visible',ctrl:'vISENABLEDINREPOSITORY',prop:'Visible'},{ctrl:'ENABLE',prop:'Visible'},{ctrl:'ENABLE',prop:'Enabled'},{av:'lblTitle_Caption',ctrl:'TITLE',prop:'Caption'},{ctrl:'ROLESCOMPONENT',prop:'Visible'},{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV45ActivationDate',fld:'vACTIVATIONDATE',pic:'99/99/9999 99:99'},{ctrl:'ENABLE',prop:'Caption'},{ctrl:'ROLESCOMPONENT'},{av:'edtavUrlprofile_Visible',ctrl:'vURLPROFILE',prop:'Visible'},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'},{av:'AV35UserNameSpace',fld:'vUSERNAMESPACE',pic:''},{av:'chkavIsactive.Visible',ctrl:'vISACTIVE',prop:'Visible'},{av:'edtavActivationdate_Visible',ctrl:'vACTIVATIONDATE',prop:'Visible'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E14472',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV40Password',fld:'vPASSWORD',pic:''},{av:'AV41PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV36Name',fld:'vNAME',pic:''},{av:'AV37Email',fld:'vEMAIL',pic:''},{av:'AV38FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV39LastName',fld:'vLASTNAME',pic:''},{av:'AV47ExternalId',fld:'vEXTERNALID',pic:''},{av:'AV42Birthday',fld:'vBIRTHDAY',pic:''},{av:'cmbavGender'},{av:'AV43Gender',fld:'vGENDER',pic:''},{av:'AV55URLImage',fld:'vURLIMAGE',pic:''},{av:'AV48URLProfile',fld:'vURLPROFILE',pic:''},{av:'cmbavSecuritypolicyid'},{av:'AV54SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("'E_ENABLE'","{handler:'E15472',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("'E_ENABLE'",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E17471',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("'E_CANCEL'",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E18471',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E19471',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV34UserId',fld:'vUSERID',pic:''},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK","{handler:'E11471',iparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK",",oparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'},{av:'divLineseparatorcontent_lineseparator_Class',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Class'},{av:'divLineseparatorheader_lineseparator_Class',ctrl:'LINESEPARATORHEADER_LINESEPARATOR',prop:'Class'},{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("VALIDV_BIRTHDAY","{handler:'Validv_Birthday',iparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("VALIDV_BIRTHDAY",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("VALIDV_GENDER","{handler:'Validv_Gender',iparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("VALIDV_GENDER",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
         setEventMetadata("VALIDV_ACTIVATIONDATE","{handler:'Validv_Activationdate',iparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]");
         setEventMetadata("VALIDV_ACTIVATIONDATE",",oparms:[{av:'AV44IsActive',fld:'vISACTIVE',pic:''},{av:'AV46IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV49DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV50CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV51MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV52PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV53IsBlocked',fld:'vISBLOCKED',pic:''}]}");
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
         wcpOAV34UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV35UserNameSpace = "";
         AV36Name = "";
         AV37Email = "";
         AV38FirstName = "";
         AV39LastName = "";
         AV40Password = "";
         AV41PasswordConf = "";
         AV55URLImage = "";
         AV42Birthday = DateTime.MinValue;
         AV43Gender = "";
         lblTextblock_var_isactive_Jsonclick = "";
         AV45ActivationDate = (DateTime)(DateTime.MinValue);
         lblTextblock_var_isenabledinrepository_Jsonclick = "";
         bttEnable_Jsonclick = "";
         lblLineseparatortitle_lineseparator_Jsonclick = "";
         AV47ExternalId = "";
         AV48URLProfile = "";
         WebComp_Rolescomponent_Component = "";
         OldRolescomponent = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV13FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10AuthTypeId = "";
         AV5AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV11Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV28Message = new GeneXus.Utils.SdtMessages_Message(context);
         sStyleString = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_Jsonclick = "";
         lblTextblock_attributes_attributes_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__default(),
            new Object[][] {
            }
         );
         WebComp_Rolescomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUsernamespace_Enabled = 0;
         edtavActivationdate_Enabled = 0;
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
      private int divLineseparatorcontent_lineseparator_Visible ;
      private int edtavUserid_Enabled ;
      private int edtavUsernamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavPassword_Visible ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Visible ;
      private int edtavPasswordconf_Enabled ;
      private int edtavUrlimage_Enabled ;
      private int edtavBirthday_Enabled ;
      private int edtavActivationdate_Visible ;
      private int edtavActivationdate_Enabled ;
      private int bttEnable_Visible ;
      private int bttEnable_Enabled ;
      private int edtavExternalid_Enabled ;
      private int edtavUrlprofile_Visible ;
      private int edtavUrlprofile_Enabled ;
      private int divTable_container_securitypolicyid_Visible ;
      private int AV54SecurityPolicyId ;
      private int WebComp_Rolescomponent_Visible ;
      private int AV59GXV1 ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int AV60GXV2 ;
      private int AV61GXV3 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV34UserId ;
      private string wcpOGx_mode ;
      private string wcpOAV34UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Caption ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divColumns_maincolumnstable_Internalname ;
      private string divColumncontainertable_column_Internalname ;
      private string divResponsivetable_mainattributes_attributes_Internalname ;
      private string divTitlecell_attributes_attributes_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divResponsivetable_containernode_actions2_Internalname ;
      private string divTable_container_userid_Internalname ;
      private string edtavUserid_Internalname ;
      private string edtavUserid_Jsonclick ;
      private string divTable_container_usernamespace_Internalname ;
      private string edtavUsernamespace_Internalname ;
      private string TempTags ;
      private string AV35UserNameSpace ;
      private string edtavUsernamespace_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string divTable_container_email_Internalname ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divTable_container_firstname_Internalname ;
      private string edtavFirstname_Internalname ;
      private string AV38FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divTable_container_lastname_Internalname ;
      private string edtavLastname_Internalname ;
      private string AV39LastName ;
      private string edtavLastname_Jsonclick ;
      private string divTable_container_password_Internalname ;
      private string edtavPassword_Internalname ;
      private string AV40Password ;
      private string edtavPassword_Jsonclick ;
      private string divTable_container_passwordconf_Internalname ;
      private string edtavPasswordconf_Internalname ;
      private string AV41PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divTable_container_urlimage_Internalname ;
      private string edtavUrlimage_Internalname ;
      private string edtavUrlimage_Jsonclick ;
      private string divTable_container_birthday_Internalname ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Jsonclick ;
      private string divTable_container_gender_Internalname ;
      private string cmbavGender_Internalname ;
      private string AV43Gender ;
      private string cmbavGender_Jsonclick ;
      private string divTable_container_isactive_Internalname ;
      private string lblTextblock_var_isactive_Internalname ;
      private string lblTextblock_var_isactive_Jsonclick ;
      private string divTable_container_isactivefieldcontainer_Internalname ;
      private string chkavIsactive_Internalname ;
      private string edtavActivationdate_Internalname ;
      private string edtavActivationdate_Jsonclick ;
      private string divTable_container_isenabledinrepository_Internalname ;
      private string lblTextblock_var_isenabledinrepository_Internalname ;
      private string lblTextblock_var_isenabledinrepository_Jsonclick ;
      private string divTable_container_isenabledinrepositoryfieldcontainer_Internalname ;
      private string chkavIsenabledinrepository_Internalname ;
      private string bttEnable_Internalname ;
      private string bttEnable_Caption ;
      private string bttEnable_Jsonclick ;
      private string divLineseparatorcontainer_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Class ;
      private string lblLineseparatortitle_lineseparator_Internalname ;
      private string lblLineseparatortitle_lineseparator_Jsonclick ;
      private string divLineseparatorcontent_lineseparator_Internalname ;
      private string divLineseparatorcontent_lineseparator_Class ;
      private string divTable_container_externalid_Internalname ;
      private string edtavExternalid_Internalname ;
      private string edtavExternalid_Jsonclick ;
      private string divTable_container_urlprofile_Internalname ;
      private string edtavUrlprofile_Internalname ;
      private string edtavUrlprofile_Jsonclick ;
      private string divTable_container_dontreciveinformation_Internalname ;
      private string chkavDontreciveinformation_Internalname ;
      private string divTable_container_canotchangepassword_Internalname ;
      private string chkavCanotchangepassword_Internalname ;
      private string divTable_container_mustchangepassword_Internalname ;
      private string chkavMustchangepassword_Internalname ;
      private string divTable_container_passwordneverexpires_Internalname ;
      private string chkavPasswordneverexpires_Internalname ;
      private string divTable_container_isblocked_Internalname ;
      private string chkavIsblocked_Internalname ;
      private string divTable_container_securitypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Jsonclick ;
      private string divResponsivetable_containernode_actions1_Internalname ;
      private string divColumncontainertable_column1_Internalname ;
      private string WebComp_Rolescomponent_Component ;
      private string OldRolescomponent ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV10AuthTypeId ;
      private string imgUpdate_Internalname ;
      private string imgUpdate_Tooltiptext ;
      private string imgDelete_Internalname ;
      private string imgDelete_Tooltiptext ;
      private string bttConfirm_Internalname ;
      private string bttCancel_Internalname ;
      private string bttConfirm_Caption ;
      private string sStyleString ;
      private string tblActionscontainertableleft_actions1_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Jsonclick ;
      private string tblActionscontainertableright_actions2_Internalname ;
      private string sImgUrl ;
      private string imgUpdate_Jsonclick ;
      private string imgDelete_Jsonclick ;
      private string tblTitlecontainertable_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Jsonclick ;
      private DateTime AV45ActivationDate ;
      private DateTime AV42Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV44IsActive ;
      private bool AV46IsEnabledInRepository ;
      private bool AV49DontReciveInformation ;
      private bool AV50CanotChangePassword ;
      private bool AV51MustChangePassword ;
      private bool AV52PasswordNeverExpires ;
      private bool AV53IsBlocked ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Rolescomponent ;
      private bool AV14isOK ;
      private bool AV17PasswordIsOK ;
      private string AV36Name ;
      private string AV37Email ;
      private string AV55URLImage ;
      private string AV47ExternalId ;
      private string AV48URLProfile ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXWebComponent WebComp_Rolescomponent ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV5AuthenticationType ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_UserId ;
      private GXCombobox cmbavGender ;
      private GXCheckbox chkavIsactive ;
      private GXCheckbox chkavIsenabledinrepository ;
      private GXCheckbox chkavDontreciveinformation ;
      private GXCheckbox chkavCanotchangepassword ;
      private GXCheckbox chkavMustchangepassword ;
      private GXCheckbox chkavPasswordneverexpires ;
      private GXCheckbox chkavIsblocked ;
      private GXCombobox cmbavSecuritypolicyid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV7SecurityPolicies ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV6Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9User ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV8SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV13FilterSecPol ;
      private GeneXus.Utils.SdtMessages_Message AV28Message ;
   }

   public class entryuser__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class entryuser__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class entryuser__gam : DataStoreHelperBase, IDataStoreHelper
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

public class entryuser__default : DataStoreHelperBase, IDataStoreHelper
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
