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
   public class entrymenuoption : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entrymenuoption( )
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

      public entrymenuoption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_ApplicationId ,
                           ref long aP2_MenuId ,
                           ref long aP3_MenuOptionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8ApplicationId = aP1_ApplicationId;
         this.AV22MenuId = aP2_MenuId;
         this.AV24MenuOptionId = aP3_MenuOptionId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_ApplicationId=this.AV8ApplicationId;
         aP2_MenuId=this.AV22MenuId;
         aP3_MenuOptionId=this.AV24MenuOptionId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavOptiontype = new GXCombobox();
         cmbavMenusid = new GXCombobox();
         cmbavRelresid = new GXCombobox();
         chkavShowinextrasmall = new GXCheckbox();
         chkavShowinsmall = new GXCheckbox();
         chkavShowinmedium = new GXCheckbox();
         chkavShowinlarge = new GXCheckbox();
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
                  AV8ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
                  AssignAttri("", false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ApplicationId), "ZZZZZZZZZZZ9"), context));
                  AV22MenuId = (long)(NumberUtil.Val( GetPar( "MenuId"), "."));
                  AssignAttri("", false, "AV22MenuId", StringUtil.LTrimStr( (decimal)(AV22MenuId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22MenuId), "ZZZZZZZZZZZ9"), context));
                  AV24MenuOptionId = (long)(NumberUtil.Val( GetPar( "MenuOptionId"), "."));
                  AssignAttri("", false, "AV24MenuOptionId", StringUtil.LTrimStr( (decimal)(AV24MenuOptionId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
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
         PA4O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4O2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188404956", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entrymenuoption.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV22MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV24MenuOptionId,12,0))}, new string[] {"Gx_mode","ApplicationId","MenuId","MenuOptionId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADPERMISSIONS", AV19LoadPermissions);
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMENUOPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24MenuOptionId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV18IsOk);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGE", AV27Message);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGE", AV27Message);
         }
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
            WE4O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4O2( ) ;
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
         return formatLink("k2bfsg.entrymenuoption.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV22MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV24MenuOptionId,12,0))}, new string[] {"Gx_mode","ApplicationId","MenuId","MenuOptionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryMenuOption" ;
      }

      public override string GetPgmdesc( )
      {
         return "Opci�n de men�" ;
      }

      protected void WB4O0( )
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_applicationname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavApplicationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavApplicationname_Internalname, "Aplicaci�n", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavApplicationname_Internalname, StringUtil.RTrim( AV11ApplicationName), StringUtil.RTrim( context.localUtil.Format( AV11ApplicationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavApplicationname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavApplicationname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_menuname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavMenuname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMenuname_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMenuname_Internalname, StringUtil.RTrim( AV23MenuName), StringUtil.RTrim( context.localUtil.Format( AV23MenuName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMenuname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMenuname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
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
            GxWebStd.gx_group_start( context, grpOptions_Internalname, "Opciones", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntryMenuOption.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_options_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_optionname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavOptionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOptionname_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOptionname_Internalname, StringUtil.RTrim( AV30OptionName), StringUtil.RTrim( context.localUtil.Format( AV30OptionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOptionname_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavOptionname_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_optiondescription_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavOptiondescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOptiondescription_Internalname, "Descripci�n", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOptiondescription_Internalname, StringUtil.RTrim( AV28OptionDescription), StringUtil.RTrim( context.localUtil.Format( AV28OptionDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOptiondescription_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOptiondescription_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_optiontype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavOptiontype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOptiontype_Internalname, "Tipo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOptiontype, cmbavOptiontype_Internalname, StringUtil.RTrim( AV31OptionType), 1, cmbavOptiontype_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVOPTIONTYPE.CLICK."+"'", "char", "", 1, cmbavOptiontype.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 1, "HLP_K2BFSG\\EntryMenuOption.htm");
            cmbavOptiontype.CurrentValue = StringUtil.RTrim( AV31OptionType);
            AssignProp("", false, cmbavOptiontype_Internalname, "Values", (string)(cmbavOptiontype.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_optionguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_optionguid_Internalname, "GUID", "", "", lblTextblock_var_optionguid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryMenuOption.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_optionguidfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOptionguid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOptionguid_Internalname, StringUtil.RTrim( AV29OptionGUID), StringUtil.RTrim( context.localUtil.Format( AV29OptionGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOptionguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOptionguid_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "K2BDescription", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Static images/pictures */
            ClassString = "K2BImage_ContextHelp";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "afb51b54-e80c-459c-b24b-07b4c9cb5db7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgOptionguid_var_contexthelpimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", imgOptionguid_var_contexthelpimage_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_menusid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavMenusid.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavMenusid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMenusid_Internalname, "Sub-men�", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMenusid, cmbavMenusid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0)), 1, cmbavMenusid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavMenusid.Visible, cmbavMenusid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 1, "HLP_K2BFSG\\EntryMenuOption.htm");
            cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0));
            AssignProp("", false, cmbavMenusid_Internalname, "Values", (string)(cmbavMenusid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_relresid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavRelresid.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavRelresid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRelresid_Internalname, "Permiso", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRelresid, cmbavRelresid_Internalname, StringUtil.RTrim( AV34RelResId), 1, cmbavRelresid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavRelresid.Visible, cmbavRelresid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 1, "HLP_K2BFSG\\EntryMenuOption.htm");
            cmbavRelresid.CurrentValue = StringUtil.RTrim( AV34RelResId);
            AssignProp("", false, cmbavRelresid_Internalname, "Values", (string)(cmbavRelresid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_resource_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavResource_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavResource_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResource_Internalname, "Recurso", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResource_Internalname, AV35Resource, StringUtil.RTrim( context.localUtil.Format( AV35Resource, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResource_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavResource_Visible, edtavResource_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_resourceparameters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavResourceparameters_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavResourceparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResourceparameters_Internalname, "Par�metros", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResourceparameters_Internalname, AV36ResourceParameters, StringUtil.RTrim( context.localUtil.Format( AV36ResourceParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResourceparameters_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavResourceparameters_Visible, edtavResourceparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_imageurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavImageurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImageurl_Internalname, "URL de im�genes", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImageurl_Internalname, AV17ImageUrl, StringUtil.RTrim( context.localUtil.Format( AV17ImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", AV17ImageUrl, "_blank", "", "", edtavImageurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavImageurl_Enabled, 1, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_imageclass_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavImageclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImageclass_Internalname, "Clase de la imagen", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImageclass_Internalname, StringUtil.RTrim( AV16ImageClass), StringUtil.RTrim( context.localUtil.Format( AV16ImageClass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImageclass_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavImageclass_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "K2BDescription", "left", true, "", "HLP_K2BFSG\\EntryMenuOption.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_group_start( context, grpResponsive_Internalname, "Configuraci�n Responsive Web Design", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntryMenuOption.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_responsive_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_showinextrasmall_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavShowinextrasmall_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowinextrasmall_Internalname, "Mostrar en Extra Small", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowinextrasmall_Internalname, StringUtil.BoolToStr( AV37ShowInExtraSmall), "", "Mostrar en Extra Small", 1, chkavShowinextrasmall.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_showinsmall_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavShowinsmall_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowinsmall_Internalname, "Mostrar en Small", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowinsmall_Internalname, StringUtil.BoolToStr( AV40ShowInSmall), "", "Mostrar en Small", 1, chkavShowinsmall.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_showinmedium_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavShowinmedium_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowinmedium_Internalname, "Mostrar en Medium", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowinmedium_Internalname, StringUtil.BoolToStr( AV39ShowInMedium), "", "Mostrar en Medium", 1, chkavShowinmedium.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_showinlarge_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavShowinlarge_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowinlarge_Internalname, "Mostrar en Large", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowinlarge_Internalname, StringUtil.BoolToStr( AV38ShowInLarge), "", "Mostrar en Large", 1, chkavShowinlarge.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_122_4O2( true) ;
         }
         else
         {
            wb_table1_122_4O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_122_4O2e( bool wbgen )
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

      protected void START4O2( )
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
            Form.Meta.addItem("description", "Opci�n de men�", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4O0( ) ;
      }

      protected void WS4O2( )
      {
         START4O2( ) ;
         EVT4O2( ) ;
      }

      protected void EVT4O2( )
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
                              E114O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E124O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VOPTIONTYPE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134O2 ();
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
                                    E144O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Cancel' */
                              E154O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRELRESID.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E174O2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4O2( )
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

      protected void PA4O2( )
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
               GX_FocusControl = edtavApplicationname_Internalname;
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
         if ( cmbavOptiontype.ItemCount > 0 )
         {
            AV31OptionType = cmbavOptiontype.getValidValue(AV31OptionType);
            AssignAttri("", false, "AV31OptionType", AV31OptionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOptiontype.CurrentValue = StringUtil.RTrim( AV31OptionType);
            AssignProp("", false, cmbavOptiontype_Internalname, "Values", cmbavOptiontype.ToJavascriptSource(), true);
         }
         if ( cmbavMenusid.ItemCount > 0 )
         {
            AV26MenusId = (long)(NumberUtil.Val( cmbavMenusid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0))), "."));
            AssignAttri("", false, "AV26MenusId", StringUtil.LTrimStr( (decimal)(AV26MenusId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0));
            AssignProp("", false, cmbavMenusid_Internalname, "Values", cmbavMenusid.ToJavascriptSource(), true);
         }
         if ( cmbavRelresid.ItemCount > 0 )
         {
            AV34RelResId = cmbavRelresid.getValidValue(AV34RelResId);
            AssignAttri("", false, "AV34RelResId", AV34RelResId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRelresid.CurrentValue = StringUtil.RTrim( AV34RelResId);
            AssignProp("", false, cmbavRelresid_Internalname, "Values", cmbavRelresid.ToJavascriptSource(), true);
         }
         AV37ShowInExtraSmall = StringUtil.StrToBool( StringUtil.BoolToStr( AV37ShowInExtraSmall));
         AssignAttri("", false, "AV37ShowInExtraSmall", AV37ShowInExtraSmall);
         AV40ShowInSmall = StringUtil.StrToBool( StringUtil.BoolToStr( AV40ShowInSmall));
         AssignAttri("", false, "AV40ShowInSmall", AV40ShowInSmall);
         AV39ShowInMedium = StringUtil.StrToBool( StringUtil.BoolToStr( AV39ShowInMedium));
         AssignAttri("", false, "AV39ShowInMedium", AV39ShowInMedium);
         AV38ShowInLarge = StringUtil.StrToBool( StringUtil.BoolToStr( AV38ShowInLarge));
         AssignAttri("", false, "AV38ShowInLarge", AV38ShowInLarge);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), true);
      }

      protected void RF4O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E124O2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E174O2 ();
            WB4O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4O2( )
      {
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMENUOPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24MenuOptionId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV11ApplicationName = cgiGet( edtavApplicationname_Internalname);
            AssignAttri("", false, "AV11ApplicationName", AV11ApplicationName);
            AV23MenuName = cgiGet( edtavMenuname_Internalname);
            AssignAttri("", false, "AV23MenuName", AV23MenuName);
            AV30OptionName = cgiGet( edtavOptionname_Internalname);
            AssignAttri("", false, "AV30OptionName", AV30OptionName);
            AV28OptionDescription = cgiGet( edtavOptiondescription_Internalname);
            AssignAttri("", false, "AV28OptionDescription", AV28OptionDescription);
            cmbavOptiontype.CurrentValue = cgiGet( cmbavOptiontype_Internalname);
            AV31OptionType = cgiGet( cmbavOptiontype_Internalname);
            AssignAttri("", false, "AV31OptionType", AV31OptionType);
            AV29OptionGUID = cgiGet( edtavOptionguid_Internalname);
            AssignAttri("", false, "AV29OptionGUID", AV29OptionGUID);
            cmbavMenusid.CurrentValue = cgiGet( cmbavMenusid_Internalname);
            AV26MenusId = (long)(NumberUtil.Val( cgiGet( cmbavMenusid_Internalname), "."));
            AssignAttri("", false, "AV26MenusId", StringUtil.LTrimStr( (decimal)(AV26MenusId), 12, 0));
            cmbavRelresid.CurrentValue = cgiGet( cmbavRelresid_Internalname);
            AV34RelResId = cgiGet( cmbavRelresid_Internalname);
            AssignAttri("", false, "AV34RelResId", AV34RelResId);
            AV35Resource = cgiGet( edtavResource_Internalname);
            AssignAttri("", false, "AV35Resource", AV35Resource);
            AV36ResourceParameters = cgiGet( edtavResourceparameters_Internalname);
            AssignAttri("", false, "AV36ResourceParameters", AV36ResourceParameters);
            AV17ImageUrl = cgiGet( edtavImageurl_Internalname);
            AssignAttri("", false, "AV17ImageUrl", AV17ImageUrl);
            AV16ImageClass = cgiGet( edtavImageclass_Internalname);
            AssignAttri("", false, "AV16ImageClass", AV16ImageClass);
            AV37ShowInExtraSmall = StringUtil.StrToBool( cgiGet( chkavShowinextrasmall_Internalname));
            AssignAttri("", false, "AV37ShowInExtraSmall", AV37ShowInExtraSmall);
            AV40ShowInSmall = StringUtil.StrToBool( cgiGet( chkavShowinsmall_Internalname));
            AssignAttri("", false, "AV40ShowInSmall", AV40ShowInSmall);
            AV39ShowInMedium = StringUtil.StrToBool( cgiGet( chkavShowinmedium_Internalname));
            AssignAttri("", false, "AV39ShowInMedium", AV39ShowInMedium);
            AV38ShowInLarge = StringUtil.StrToBool( cgiGet( chkavShowinlarge_Internalname));
            AssignAttri("", false, "AV38ShowInLarge", AV38ShowInLarge);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114O2 ();
         if (returnInSub) return;
      }

      protected void E114O2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E124O2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         imgOptionguid_var_contexthelpimage_Tooltiptext = "Si se deja vac�o, ser� generado autom�ticamente.";
         AssignProp("", false, imgOptionguid_var_contexthelpimage_Internalname, "Tooltiptext", imgOptionguid_var_contexthelpimage_Tooltiptext, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E134O2( )
      {
         /* Optiontype_Click Routine */
         returnInSub = false;
         AV19LoadPermissions = String.IsNullOrEmpty(StringUtil.RTrim( AV34RelResId));
         AssignAttri("", false, "AV19LoadPermissions", AV19LoadPermissions);
         AV7Application.load( AV8ApplicationId);
         /* Execute user subroutine: 'HIDESHOWRESOURCES' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Application", AV7Application);
         cmbavRelresid.CurrentValue = StringUtil.RTrim( AV34RelResId);
         AssignProp("", false, cmbavRelresid_Internalname, "Values", cmbavRelresid.ToJavascriptSource(), true);
         cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0));
         AssignProp("", false, cmbavMenusid_Internalname, "Values", cmbavMenusid.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV7Application.load( AV8ApplicationId);
         AV11ApplicationName = AV7Application.gxTpr_Name;
         AssignAttri("", false, "AV11ApplicationName", AV11ApplicationName);
         AV9ApplicationMenu = AV7Application.getmenu(AV22MenuId, out  AV13Errors);
         AV23MenuName = AV9ApplicationMenu.gxTpr_Name;
         AssignAttri("", false, "AV23MenuName", AV23MenuName);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV10ApplicationMenuOption = AV9ApplicationMenu.getmenuoptionbyid(AV8ApplicationId, AV24MenuOptionId, out  AV13Errors);
            AV24MenuOptionId = AV10ApplicationMenuOption.gxTpr_Id;
            AssignAttri("", false, "AV24MenuOptionId", StringUtil.LTrimStr( (decimal)(AV24MenuOptionId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
            AV30OptionName = AV10ApplicationMenuOption.gxTpr_Name;
            AssignAttri("", false, "AV30OptionName", AV30OptionName);
            AV28OptionDescription = AV10ApplicationMenuOption.gxTpr_Description;
            AssignAttri("", false, "AV28OptionDescription", AV28OptionDescription);
            AV29OptionGUID = AV10ApplicationMenuOption.gxTpr_Guid;
            AssignAttri("", false, "AV29OptionGUID", AV29OptionGUID);
            AV31OptionType = AV10ApplicationMenuOption.gxTpr_Type;
            AssignAttri("", false, "AV31OptionType", AV31OptionType);
            AV26MenusId = AV10ApplicationMenuOption.gxTpr_Submenuid;
            AssignAttri("", false, "AV26MenusId", StringUtil.LTrimStr( (decimal)(AV26MenusId), 12, 0));
            AV34RelResId = AV10ApplicationMenuOption.gxTpr_Permissionresourceguid;
            AssignAttri("", false, "AV34RelResId", AV34RelResId);
            AV35Resource = AV10ApplicationMenuOption.gxTpr_Resource;
            AssignAttri("", false, "AV35Resource", AV35Resource);
            AV36ResourceParameters = AV10ApplicationMenuOption.gxTpr_Resourceparameters;
            AssignAttri("", false, "AV36ResourceParameters", AV36ResourceParameters);
            edtavOptionguid_Enabled = 0;
            AssignProp("", false, edtavOptionguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionguid_Enabled), 5, 0), true);
            new GeneXus.Programs.k2bfsg.getextendedmenuoptionsvalues(context ).execute(  AV10ApplicationMenuOption.gxTpr_Properties, out  AV17ImageUrl, out  AV16ImageClass, out  AV37ShowInExtraSmall, out  AV40ShowInSmall, out  AV39ShowInMedium, out  AV38ShowInLarge) ;
            AssignAttri("", false, "AV17ImageUrl", AV17ImageUrl);
            AssignAttri("", false, "AV16ImageClass", AV16ImageClass);
            AssignAttri("", false, "AV37ShowInExtraSmall", AV37ShowInExtraSmall);
            AssignAttri("", false, "AV40ShowInSmall", AV40ShowInSmall);
            AssignAttri("", false, "AV39ShowInMedium", AV39ShowInMedium);
            AssignAttri("", false, "AV38ShowInLarge", AV38ShowInLarge);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
               {
                  bttConfirm_Visible = 0;
                  AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
                  bttCancel_Visible = 0;
                  AssignProp("", false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
               }
               edtavOptionname_Enabled = 0;
               AssignProp("", false, edtavOptionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionname_Enabled), 5, 0), true);
               edtavOptiondescription_Enabled = 0;
               AssignProp("", false, edtavOptiondescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiondescription_Enabled), 5, 0), true);
               cmbavOptiontype.Enabled = 0;
               AssignProp("", false, cmbavOptiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOptiontype.Enabled), 5, 0), true);
               cmbavRelresid.Enabled = 0;
               AssignProp("", false, cmbavRelresid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Enabled), 5, 0), true);
               edtavResource_Enabled = 0;
               AssignProp("", false, edtavResource_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResource_Enabled), 5, 0), true);
               edtavResourceparameters_Enabled = 0;
               AssignProp("", false, edtavResourceparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResourceparameters_Enabled), 5, 0), true);
               edtavImageclass_Enabled = 0;
               AssignProp("", false, edtavImageclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImageclass_Enabled), 5, 0), true);
               edtavImageurl_Enabled = 0;
               AssignProp("", false, edtavImageurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImageurl_Enabled), 5, 0), true);
               chkavShowinextrasmall.Enabled = 0;
               AssignProp("", false, chkavShowinextrasmall_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavShowinextrasmall.Enabled), 5, 0), true);
               chkavShowinsmall.Enabled = 0;
               AssignProp("", false, chkavShowinsmall_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavShowinsmall.Enabled), 5, 0), true);
               chkavShowinmedium.Enabled = 0;
               AssignProp("", false, chkavShowinmedium_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavShowinmedium.Enabled), 5, 0), true);
               chkavShowinlarge.Enabled = 0;
               AssignProp("", false, chkavShowinlarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavShowinlarge.Enabled), 5, 0), true);
               cmbavMenusid.Enabled = 0;
               AssignProp("", false, cmbavMenusid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Enabled), 5, 0), true);
               bttConfirm_Caption = "Eliminar";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
         }
         else
         {
            AV37ShowInExtraSmall = true;
            AssignAttri("", false, "AV37ShowInExtraSmall", AV37ShowInExtraSmall);
            AV40ShowInSmall = true;
            AssignAttri("", false, "AV40ShowInSmall", AV40ShowInSmall);
            AV39ShowInMedium = true;
            AssignAttri("", false, "AV39ShowInMedium", AV39ShowInMedium);
            AV38ShowInLarge = true;
            AssignAttri("", false, "AV38ShowInLarge", AV38ShowInLarge);
         }
         AV19LoadPermissions = true;
         AssignAttri("", false, "AV19LoadPermissions", AV19LoadPermissions);
         /* Execute user subroutine: 'HIDESHOWRESOURCES' */
         S142 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            Form.Caption = "Agregar opci�n de men�";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            Form.Caption = "Actualizar opci�n de men�";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            Form.Caption = "Borrar opci�n de men�";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            Form.Caption = "Opci�n de men�";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         }
      }

      protected void S142( )
      {
         /* 'HIDESHOWRESOURCES' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31OptionType, "S") == 0 )
         {
            if ( AV19LoadPermissions )
            {
               AV48GXV2 = 1;
               AV47GXV1 = AV7Application.getpermissions(AV33PermissionFilter, out  AV13Errors);
               while ( AV48GXV2 <= AV47GXV1.Count )
               {
                  AV32Permission = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV47GXV1.Item(AV48GXV2));
                  cmbavRelresid.addItem(AV32Permission.gxTpr_Guid, AV32Permission.gxTpr_Name, 0);
                  AV48GXV2 = (int)(AV48GXV2+1);
               }
            }
            cmbavMenusid.Visible = 0;
            AssignProp("", false, cmbavMenusid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Visible), 5, 0), true);
            cmbavRelresid.Visible = 1;
            AssignProp("", false, cmbavRelresid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Visible), 5, 0), true);
            edtavResource_Visible = 1;
            AssignProp("", false, edtavResource_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResource_Visible), 5, 0), true);
            edtavResourceparameters_Visible = 1;
            AssignProp("", false, edtavResourceparameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResourceparameters_Visible), 5, 0), true);
         }
         else
         {
            AV50GXV4 = 1;
            AV49GXV3 = AV7Application.getsubmenus(AV22MenuId, out  AV13Errors);
            while ( AV50GXV4 <= AV49GXV3.Count )
            {
               AV20Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV49GXV3.Item(AV50GXV4));
               cmbavMenusid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV20Menu.gxTpr_Id), 12, 0)), AV20Menu.gxTpr_Name, 0);
               AV50GXV4 = (int)(AV50GXV4+1);
            }
            cmbavMenusid.Visible = 1;
            AssignProp("", false, cmbavMenusid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Visible), 5, 0), true);
            cmbavRelresid.Visible = 0;
            AssignProp("", false, cmbavRelresid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Visible), 5, 0), true);
            edtavResource_Visible = 0;
            AssignProp("", false, edtavResource_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResource_Visible), 5, 0), true);
            edtavResourceparameters_Visible = 0;
            AssignProp("", false, edtavResourceparameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResourceparameters_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144O2 ();
         if (returnInSub) return;
      }

      protected void E144O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Application", AV7Application);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10ApplicationMenuOption", AV10ApplicationMenuOption);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27Message", AV27Message);
      }

      protected void S152( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV7Application.load( AV8ApplicationId);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30OptionName)) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
               S172 ();
               if (returnInSub) return;
               AV18IsOk = AV7Application.addmenuoption(AV22MenuId, AV10ApplicationMenuOption, out  AV13Errors);
               AssignAttri("", false, "AV18IsOk", AV18IsOk);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               AV10ApplicationMenuOption = AV7Application.getmenuoption(AV22MenuId, AV24MenuOptionId, out  AV13Errors);
               /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
               S172 ();
               if (returnInSub) return;
               AV18IsOk = AV7Application.updatemenuoption(AV22MenuId, AV10ApplicationMenuOption, out  AV13Errors);
               AssignAttri("", false, "AV18IsOk", AV18IsOk);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV10ApplicationMenuOption = AV7Application.getmenuoption(AV22MenuId, AV24MenuOptionId, out  AV13Errors);
               AV18IsOk = AV7Application.deletemenuoption(AV22MenuId, AV10ApplicationMenuOption, out  AV13Errors);
               AssignAttri("", false, "AV18IsOk", AV18IsOk);
            }
         }
         else
         {
            AV18IsOk = false;
            AssignAttri("", false, "AV18IsOk", AV18IsOk);
            AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
            AV12Error.gxTpr_Code = 239;
            AV12Error.gxTpr_Message = GeneXus.Programs.genexussecuritycommon.gxdomaingamerrormessages.getDescription(context,AV12Error.gxTpr_Code);
            AV13Errors.Add(AV12Error, 0);
         }
         if ( AV18IsOk )
         {
            context.CommitDataStores("k2bfsg.entrymenuoption",pr_default);
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV27Message.gxTpr_Description = StringUtil.Format( "La opci�n de men� %1 fue creada", AV30OptionName, "", "", "", "", "", "", "", "");
            }
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               AV27Message.gxTpr_Description = StringUtil.Format( "La opci�n de men� %1 fue actualizada", AV30OptionName, "", "", "", "", "", "", "", "");
            }
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV27Message.gxTpr_Description = StringUtil.Format( "La opci�n de men� %1 fue borrada", AV30OptionName, "", "", "", "", "", "", "", "");
            }
            new k2btoolsmessagequeueadd(context ).execute(  AV27Message) ;
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(long)AV8ApplicationId,(long)AV22MenuId,(long)AV24MenuOptionId});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV8ApplicationId","AV22MenuId","AV24MenuOptionId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV51GXV5 = 1;
            while ( AV51GXV5 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV51GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV51GXV5 = (int)(AV51GXV5+1);
            }
         }
      }

      protected void S172( )
      {
         /* 'LOAD_APPLICATIONMENUOPTION' Routine */
         returnInSub = false;
         AV10ApplicationMenuOption.gxTpr_Guid = AV29OptionGUID;
         AV10ApplicationMenuOption.gxTpr_Name = AV30OptionName;
         AV10ApplicationMenuOption.gxTpr_Description = AV28OptionDescription;
         AV10ApplicationMenuOption.gxTpr_Type = AV31OptionType;
         AV10ApplicationMenuOption.gxTpr_Submenuid = AV26MenusId;
         AV10ApplicationMenuOption.gxTpr_Permissionresourceguid = AV34RelResId;
         AV10ApplicationMenuOption.gxTpr_Resource = AV35Resource;
         AV10ApplicationMenuOption.gxTpr_Resourceparameters = AV36ResourceParameters;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            new GeneXus.Programs.k2bfsg.setextendedmenuoptionsvalues(context ).execute( ref  AV10ApplicationMenuOption,  AV17ImageUrl,  AV16ImageClass,  AV37ShowInExtraSmall,  AV40ShowInSmall,  AV39ShowInMedium,  AV38ShowInLarge) ;
         }
      }

      protected void E154O2( )
      {
         /* 'E_Cancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CANCEL' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(string)Gx_mode,(long)AV8ApplicationId,(long)AV22MenuId,(long)AV24MenuOptionId});
         context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV8ApplicationId","AV22MenuId","AV24MenuOptionId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E164O2( )
      {
         /* Relresid_Isvalid Routine */
         returnInSub = false;
         AV7Application.load( AV8ApplicationId);
         AV32Permission = AV7Application.getpermissionbyguid(AV34RelResId, out  AV13Errors);
         AV35Resource = AV32Permission.gxTpr_Resource;
         AssignAttri("", false, "AV35Resource", AV35Resource);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Application", AV7Application);
      }

      protected void nextLoad( )
      {
      }

      protected void E174O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_122_4O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryMenuOption.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryMenuOption.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_122_4O2e( true) ;
         }
         else
         {
            wb_table1_122_4O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV8ApplicationId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ApplicationId), "ZZZZZZZZZZZ9"), context));
         AV22MenuId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV22MenuId", StringUtil.LTrimStr( (decimal)(AV22MenuId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22MenuId), "ZZZZZZZZZZZ9"), context));
         AV24MenuOptionId = Convert.ToInt64(getParm(obj,3));
         AssignAttri("", false, "AV24MenuOptionId", StringUtil.LTrimStr( (decimal)(AV24MenuOptionId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24MenuOptionId), "ZZZZZZZZZZZ9"), context));
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
         PA4O2( ) ;
         WS4O2( ) ;
         WE4O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418841332", true, true);
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
         context.AddJavascriptSource("k2bfsg/entrymenuoption.js", "?202418841335", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavOptiontype.Name = "vOPTIONTYPE";
         cmbavOptiontype.WebTags = "";
         cmbavOptiontype.addItem("S", "Simple", 0);
         cmbavOptiontype.addItem("M", "Menu", 0);
         if ( cmbavOptiontype.ItemCount > 0 )
         {
            AV31OptionType = cmbavOptiontype.getValidValue(AV31OptionType);
            AssignAttri("", false, "AV31OptionType", AV31OptionType);
         }
         cmbavMenusid.Name = "vMENUSID";
         cmbavMenusid.WebTags = "";
         if ( cmbavMenusid.ItemCount > 0 )
         {
            AV26MenusId = (long)(NumberUtil.Val( cmbavMenusid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26MenusId), 12, 0))), "."));
            AssignAttri("", false, "AV26MenusId", StringUtil.LTrimStr( (decimal)(AV26MenusId), 12, 0));
         }
         cmbavRelresid.Name = "vRELRESID";
         cmbavRelresid.WebTags = "";
         if ( cmbavRelresid.ItemCount > 0 )
         {
            AV34RelResId = cmbavRelresid.getValidValue(AV34RelResId);
            AssignAttri("", false, "AV34RelResId", AV34RelResId);
         }
         chkavShowinextrasmall.Name = "vSHOWINEXTRASMALL";
         chkavShowinextrasmall.WebTags = "";
         chkavShowinextrasmall.Caption = "";
         AssignProp("", false, chkavShowinextrasmall_Internalname, "TitleCaption", chkavShowinextrasmall.Caption, true);
         chkavShowinextrasmall.CheckedValue = "false";
         AV37ShowInExtraSmall = StringUtil.StrToBool( StringUtil.BoolToStr( AV37ShowInExtraSmall));
         AssignAttri("", false, "AV37ShowInExtraSmall", AV37ShowInExtraSmall);
         chkavShowinsmall.Name = "vSHOWINSMALL";
         chkavShowinsmall.WebTags = "";
         chkavShowinsmall.Caption = "";
         AssignProp("", false, chkavShowinsmall_Internalname, "TitleCaption", chkavShowinsmall.Caption, true);
         chkavShowinsmall.CheckedValue = "false";
         AV40ShowInSmall = StringUtil.StrToBool( StringUtil.BoolToStr( AV40ShowInSmall));
         AssignAttri("", false, "AV40ShowInSmall", AV40ShowInSmall);
         chkavShowinmedium.Name = "vSHOWINMEDIUM";
         chkavShowinmedium.WebTags = "";
         chkavShowinmedium.Caption = "";
         AssignProp("", false, chkavShowinmedium_Internalname, "TitleCaption", chkavShowinmedium.Caption, true);
         chkavShowinmedium.CheckedValue = "false";
         AV39ShowInMedium = StringUtil.StrToBool( StringUtil.BoolToStr( AV39ShowInMedium));
         AssignAttri("", false, "AV39ShowInMedium", AV39ShowInMedium);
         chkavShowinlarge.Name = "vSHOWINLARGE";
         chkavShowinlarge.WebTags = "";
         chkavShowinlarge.Caption = "";
         AssignProp("", false, chkavShowinlarge_Internalname, "TitleCaption", chkavShowinlarge.Caption, true);
         chkavShowinlarge.CheckedValue = "false";
         AV38ShowInLarge = StringUtil.StrToBool( StringUtil.BoolToStr( AV38ShowInLarge));
         AssignAttri("", false, "AV38ShowInLarge", AV38ShowInLarge);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavApplicationname_Internalname = "vAPPLICATIONNAME";
         divTable_container_applicationname_Internalname = "TABLE_CONTAINER_APPLICATIONNAME";
         edtavMenuname_Internalname = "vMENUNAME";
         divTable_container_menuname_Internalname = "TABLE_CONTAINER_MENUNAME";
         edtavOptionname_Internalname = "vOPTIONNAME";
         divTable_container_optionname_Internalname = "TABLE_CONTAINER_OPTIONNAME";
         edtavOptiondescription_Internalname = "vOPTIONDESCRIPTION";
         divTable_container_optiondescription_Internalname = "TABLE_CONTAINER_OPTIONDESCRIPTION";
         cmbavOptiontype_Internalname = "vOPTIONTYPE";
         divTable_container_optiontype_Internalname = "TABLE_CONTAINER_OPTIONTYPE";
         lblTextblock_var_optionguid_Internalname = "TEXTBLOCK_VAR_OPTIONGUID";
         edtavOptionguid_Internalname = "vOPTIONGUID";
         imgOptionguid_var_contexthelpimage_Internalname = "OPTIONGUID_VAR_CONTEXTHELPIMAGE";
         divTable_container_optionguidfieldcontainer_Internalname = "TABLE_CONTAINER_OPTIONGUIDFIELDCONTAINER";
         divTable_container_optionguid_Internalname = "TABLE_CONTAINER_OPTIONGUID";
         cmbavMenusid_Internalname = "vMENUSID";
         divTable_container_menusid_Internalname = "TABLE_CONTAINER_MENUSID";
         cmbavRelresid_Internalname = "vRELRESID";
         divTable_container_relresid_Internalname = "TABLE_CONTAINER_RELRESID";
         edtavResource_Internalname = "vRESOURCE";
         divTable_container_resource_Internalname = "TABLE_CONTAINER_RESOURCE";
         edtavResourceparameters_Internalname = "vRESOURCEPARAMETERS";
         divTable_container_resourceparameters_Internalname = "TABLE_CONTAINER_RESOURCEPARAMETERS";
         edtavImageurl_Internalname = "vIMAGEURL";
         divTable_container_imageurl_Internalname = "TABLE_CONTAINER_IMAGEURL";
         edtavImageclass_Internalname = "vIMAGECLASS";
         divTable_container_imageclass_Internalname = "TABLE_CONTAINER_IMAGECLASS";
         divMaingroupresponsivetable_options_Internalname = "MAINGROUPRESPONSIVETABLE_OPTIONS";
         grpOptions_Internalname = "OPTIONS";
         chkavShowinextrasmall_Internalname = "vSHOWINEXTRASMALL";
         divTable_container_showinextrasmall_Internalname = "TABLE_CONTAINER_SHOWINEXTRASMALL";
         chkavShowinsmall_Internalname = "vSHOWINSMALL";
         divTable_container_showinsmall_Internalname = "TABLE_CONTAINER_SHOWINSMALL";
         chkavShowinmedium_Internalname = "vSHOWINMEDIUM";
         divTable_container_showinmedium_Internalname = "TABLE_CONTAINER_SHOWINMEDIUM";
         chkavShowinlarge_Internalname = "vSHOWINLARGE";
         divTable_container_showinlarge_Internalname = "TABLE_CONTAINER_SHOWINLARGE";
         divMaingroupresponsivetable_responsive_Internalname = "MAINGROUPRESPONSIVETABLE_RESPONSIVE";
         grpResponsive_Internalname = "RESPONSIVE";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
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
         chkavShowinlarge.Caption = "Mostrar en Large";
         chkavShowinmedium.Caption = "Mostrar en Medium";
         chkavShowinsmall.Caption = "Mostrar en Small";
         chkavShowinextrasmall.Caption = "Mostrar en Extra Small";
         bttCancel_Visible = 1;
         bttConfirm_Visible = 1;
         bttConfirm_Caption = "Confirmar";
         chkavShowinlarge.Enabled = 1;
         chkavShowinmedium.Enabled = 1;
         chkavShowinsmall.Enabled = 1;
         chkavShowinextrasmall.Enabled = 1;
         edtavImageclass_Jsonclick = "";
         edtavImageclass_Enabled = 1;
         edtavImageurl_Jsonclick = "";
         edtavImageurl_Enabled = 1;
         edtavResourceparameters_Jsonclick = "";
         edtavResourceparameters_Enabled = 1;
         edtavResourceparameters_Visible = 1;
         edtavResource_Jsonclick = "";
         edtavResource_Enabled = 1;
         edtavResource_Visible = 1;
         cmbavRelresid_Jsonclick = "";
         cmbavRelresid.Enabled = 1;
         cmbavRelresid.Visible = 1;
         cmbavMenusid_Jsonclick = "";
         cmbavMenusid.Enabled = 1;
         cmbavMenusid.Visible = 1;
         imgOptionguid_var_contexthelpimage_Tooltiptext = "";
         edtavOptionguid_Jsonclick = "";
         edtavOptionguid_Enabled = 1;
         cmbavOptiontype_Jsonclick = "";
         cmbavOptiontype.Enabled = 1;
         edtavOptiondescription_Jsonclick = "";
         edtavOptiondescription_Enabled = 1;
         edtavOptionname_Jsonclick = "";
         edtavOptionname_Enabled = 1;
         edtavMenuname_Jsonclick = "";
         edtavMenuname_Enabled = 1;
         edtavApplicationname_Jsonclick = "";
         edtavApplicationname_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Opci�n de men�";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV22MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV24MenuOptionId',fld:'vMENUOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgOptionguid_var_contexthelpimage_Tooltiptext',ctrl:'OPTIONGUID_VAR_CONTEXTHELPIMAGE',prop:'Tooltiptext'},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("VOPTIONTYPE.CLICK","{handler:'E134O2',iparms:[{av:'cmbavRelresid'},{av:'AV34RelResId',fld:'vRELRESID',pic:''},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavOptiontype'},{av:'AV31OptionType',fld:'vOPTIONTYPE',pic:''},{av:'AV19LoadPermissions',fld:'vLOADPERMISSIONS',pic:''},{av:'AV22MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavMenusid'},{av:'AV26MenusId',fld:'vMENUSID',pic:'ZZZZZZZZZZZ9'},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("VOPTIONTYPE.CLICK",",oparms:[{av:'AV19LoadPermissions',fld:'vLOADPERMISSIONS',pic:''},{av:'cmbavRelresid'},{av:'AV34RelResId',fld:'vRELRESID',pic:''},{av:'cmbavMenusid'},{av:'AV26MenusId',fld:'vMENUSID',pic:'ZZZZZZZZZZZ9'},{av:'edtavResource_Visible',ctrl:'vRESOURCE',prop:'Visible'},{av:'edtavResourceparameters_Visible',ctrl:'vRESOURCEPARAMETERS',prop:'Visible'},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E144O2',iparms:[{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV30OptionName',fld:'vOPTIONNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV22MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24MenuOptionId',fld:'vMENUOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV18IsOk',fld:'vISOK',pic:''},{av:'AV27Message',fld:'vMESSAGE',pic:''},{av:'AV29OptionGUID',fld:'vOPTIONGUID',pic:''},{av:'AV28OptionDescription',fld:'vOPTIONDESCRIPTION',pic:''},{av:'cmbavOptiontype'},{av:'AV31OptionType',fld:'vOPTIONTYPE',pic:''},{av:'cmbavMenusid'},{av:'AV26MenusId',fld:'vMENUSID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavRelresid'},{av:'AV34RelResId',fld:'vRELRESID',pic:''},{av:'AV35Resource',fld:'vRESOURCE',pic:''},{av:'AV36ResourceParameters',fld:'vRESOURCEPARAMETERS',pic:''},{av:'AV17ImageUrl',fld:'vIMAGEURL',pic:''},{av:'AV16ImageClass',fld:'vIMAGECLASS',pic:''},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV18IsOk',fld:'vISOK',pic:''},{av:'AV27Message',fld:'vMESSAGE',pic:''},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E154O2',iparms:[{av:'AV24MenuOptionId',fld:'vMENUOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV22MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("'E_CANCEL'",",oparms:[{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("VRELRESID.ISVALID","{handler:'E164O2',iparms:[{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavRelresid'},{av:'AV34RelResId',fld:'vRELRESID',pic:''},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("VRELRESID.ISVALID",",oparms:[{av:'AV35Resource',fld:'vRESOURCE',pic:''},{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("VALIDV_OPTIONTYPE","{handler:'Validv_Optiontype',iparms:[{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("VALIDV_OPTIONTYPE",",oparms:[{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
         setEventMetadata("VALIDV_IMAGEURL","{handler:'Validv_Imageurl',iparms:[{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]");
         setEventMetadata("VALIDV_IMAGEURL",",oparms:[{av:'AV37ShowInExtraSmall',fld:'vSHOWINEXTRASMALL',pic:''},{av:'AV40ShowInSmall',fld:'vSHOWINSMALL',pic:''},{av:'AV39ShowInMedium',fld:'vSHOWINMEDIUM',pic:''},{av:'AV38ShowInLarge',fld:'vSHOWINLARGE',pic:''}]}");
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
         AV27Message = new GeneXus.Utils.SdtMessages_Message(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV11ApplicationName = "";
         AV23MenuName = "";
         AV30OptionName = "";
         AV28OptionDescription = "";
         AV31OptionType = "";
         lblTextblock_var_optionguid_Jsonclick = "";
         AV29OptionGUID = "";
         sImgUrl = "";
         AV34RelResId = "";
         AV35Resource = "";
         AV36ResourceParameters = "";
         AV17ImageUrl = "";
         AV16ImageClass = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV9ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV47GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV33PermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV32Permission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV49GXV3 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV20Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrymenuoption__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrymenuoption__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrymenuoption__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrymenuoption__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavApplicationname_Enabled = 0;
         edtavMenuname_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavApplicationname_Enabled ;
      private int edtavMenuname_Enabled ;
      private int edtavOptionname_Enabled ;
      private int edtavOptiondescription_Enabled ;
      private int edtavOptionguid_Enabled ;
      private int edtavResource_Visible ;
      private int edtavResource_Enabled ;
      private int edtavResourceparameters_Visible ;
      private int edtavResourceparameters_Enabled ;
      private int edtavImageurl_Enabled ;
      private int edtavImageclass_Enabled ;
      private int bttConfirm_Visible ;
      private int bttCancel_Visible ;
      private int AV48GXV2 ;
      private int AV50GXV4 ;
      private int AV51GXV5 ;
      private int idxLst ;
      private long AV8ApplicationId ;
      private long AV22MenuId ;
      private long AV24MenuOptionId ;
      private long wcpOAV8ApplicationId ;
      private long wcpOAV22MenuId ;
      private long wcpOAV24MenuOptionId ;
      private long AV26MenusId ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divResponsivetable_mainattributes_attributes_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_applicationname_Internalname ;
      private string edtavApplicationname_Internalname ;
      private string TempTags ;
      private string AV11ApplicationName ;
      private string edtavApplicationname_Jsonclick ;
      private string divTable_container_menuname_Internalname ;
      private string edtavMenuname_Internalname ;
      private string AV23MenuName ;
      private string edtavMenuname_Jsonclick ;
      private string grpOptions_Internalname ;
      private string divMaingroupresponsivetable_options_Internalname ;
      private string divTable_container_optionname_Internalname ;
      private string edtavOptionname_Internalname ;
      private string AV30OptionName ;
      private string edtavOptionname_Jsonclick ;
      private string divTable_container_optiondescription_Internalname ;
      private string edtavOptiondescription_Internalname ;
      private string AV28OptionDescription ;
      private string edtavOptiondescription_Jsonclick ;
      private string divTable_container_optiontype_Internalname ;
      private string cmbavOptiontype_Internalname ;
      private string AV31OptionType ;
      private string cmbavOptiontype_Jsonclick ;
      private string divTable_container_optionguid_Internalname ;
      private string lblTextblock_var_optionguid_Internalname ;
      private string lblTextblock_var_optionguid_Jsonclick ;
      private string divTable_container_optionguidfieldcontainer_Internalname ;
      private string edtavOptionguid_Internalname ;
      private string AV29OptionGUID ;
      private string edtavOptionguid_Jsonclick ;
      private string sImgUrl ;
      private string imgOptionguid_var_contexthelpimage_Internalname ;
      private string imgOptionguid_var_contexthelpimage_Tooltiptext ;
      private string divTable_container_menusid_Internalname ;
      private string cmbavMenusid_Internalname ;
      private string cmbavMenusid_Jsonclick ;
      private string divTable_container_relresid_Internalname ;
      private string cmbavRelresid_Internalname ;
      private string AV34RelResId ;
      private string cmbavRelresid_Jsonclick ;
      private string divTable_container_resource_Internalname ;
      private string edtavResource_Internalname ;
      private string edtavResource_Jsonclick ;
      private string divTable_container_resourceparameters_Internalname ;
      private string edtavResourceparameters_Internalname ;
      private string edtavResourceparameters_Jsonclick ;
      private string divTable_container_imageurl_Internalname ;
      private string edtavImageurl_Internalname ;
      private string edtavImageurl_Jsonclick ;
      private string divTable_container_imageclass_Internalname ;
      private string edtavImageclass_Internalname ;
      private string AV16ImageClass ;
      private string edtavImageclass_Jsonclick ;
      private string grpResponsive_Internalname ;
      private string divMaingroupresponsivetable_responsive_Internalname ;
      private string divTable_container_showinextrasmall_Internalname ;
      private string chkavShowinextrasmall_Internalname ;
      private string divTable_container_showinsmall_Internalname ;
      private string chkavShowinsmall_Internalname ;
      private string divTable_container_showinmedium_Internalname ;
      private string chkavShowinmedium_Internalname ;
      private string divTable_container_showinlarge_Internalname ;
      private string chkavShowinlarge_Internalname ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string bttConfirm_Internalname ;
      private string bttCancel_Internalname ;
      private string bttConfirm_Caption ;
      private string sStyleString ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19LoadPermissions ;
      private bool AV18IsOk ;
      private bool wbLoad ;
      private bool AV37ShowInExtraSmall ;
      private bool AV40ShowInSmall ;
      private bool AV39ShowInMedium ;
      private bool AV38ShowInLarge ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV35Resource ;
      private string AV36ResourceParameters ;
      private string AV17ImageUrl ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_ApplicationId ;
      private long aP2_MenuId ;
      private long aP3_MenuOptionId ;
      private GXCombobox cmbavOptiontype ;
      private GXCombobox cmbavMenusid ;
      private GXCombobox cmbavRelresid ;
      private GXCheckbox chkavShowinextrasmall ;
      private GXCheckbox chkavShowinsmall ;
      private GXCheckbox chkavShowinmedium ;
      private GXCheckbox chkavShowinlarge ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV47GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV49GXV3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV7Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV32Permission ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV33PermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV9ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV20Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV10ApplicationMenuOption ;
      private GeneXus.Utils.SdtMessages_Message AV27Message ;
   }

   public class entrymenuoption__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class entrymenuoption__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class entrymenuoption__gam : DataStoreHelperBase, IDataStoreHelper
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

public class entrymenuoption__default : DataStoreHelperBase, IDataStoreHelper
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
