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
   public class wcauthenticationtypeentrygeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcauthenticationtypeentrygeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
      }

      public wcauthenticationtypeentrygeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_Name ,
                           ref string aP2_TypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV30Name = aP1_Name;
         this.AV54TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV30Name;
         aP2_TypeId=this.AV54TypeId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavFunctionid = new GXCombobox();
         chkavIsenable = new GXCheckbox();
         chkavAdduseradditionaldatascope = new GXCheckbox();
         chkavAddinitialpropertiesscope = new GXCheckbox();
         chkavAutovalidateexternaltokenandrefresh = new GXCheckbox();
         cmbavWsversion = new GXCombobox();
         cmbavWsserversecureprotocol = new GXCombobox();
         cmbavCusversion = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  AV30Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV30Name", AV30Name);
                  AV54TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV54TypeId", AV54TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV30Name,(string)AV54TypeId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA402( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS402( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "K2BT_GAM_WCAuthenticationTypeEntryGeneral") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202418810358", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wcauthenticationtypeentrygeneral.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV30Name)),UrlEncode(StringUtil.RTrim(AV54TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV30Name", StringUtil.RTrim( wcpOAV30Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV54TypeId", StringUtil.RTrim( wcpOAV54TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV54TypeId));
      }

      protected void RenderHtmlCloseForm402( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.WCAuthenticationTypeEntryGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2BT_GAM_WCAuthenticationTypeEntryGeneral" ;
      }

      protected void WB400( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wcauthenticationtypeentrygeneral.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", divContenttable_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tbldata_Internalname, 1, 0, "px", 0, "px", divResponsivetable_mainattributes_tbldata_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbldata_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tbldata_Class, "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV30Name), StringUtil.RTrim( context.localUtil.Format( AV30Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_functionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavFunctionid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFunctionid_Internalname, "Función", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV22FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 1, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV22FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", (string)(cmbavFunctionid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_dsc_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Descripción", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV21Dsc), StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavIsenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, "¿Habilitado?", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV28IsEnable), "", "¿Habilitado?", 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_smallimagename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSmallimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSmallimagename_Internalname, "Nombre imagen pequeña", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV32SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV32SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_bigimagename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavBigimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBigimagename_Internalname, "Nombre imagen grande", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV10BigImageName), StringUtil.RTrim( context.localUtil.Format( AV10BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblimpersonate_Internalname, divResponsivetable_mainattributes_tblimpersonate_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblimpersonate_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblimpersonate_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblimpersonate_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_impersonate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImpersonate_Internalname, "Impersonar", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpersonate_Internalname, StringUtil.RTrim( AV27Impersonate), StringUtil.RTrim( context.localUtil.Format( AV27Impersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpersonate_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavImpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblclientidsecret_Internalname, divResponsivetable_mainattributes_tblclientidsecret_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblclientidsecret_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblclientidsecret_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblclientidsecret_Class, "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, AV12ClientId, StringUtil.RTrim( context.localUtil.Format( AV12ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, AV13ClientSecret, StringUtil.RTrim( context.localUtil.Format( AV13ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_versionpath_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavVersionpath_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavVersionpath_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVersionpath_Internalname, "Path de versión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVersionpath_Internalname, StringUtil.RTrim( AV56VersionPath), StringUtil.RTrim( context.localUtil.Format( AV56VersionPath, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVersionpath_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavVersionpath_Visible, edtavVersionpath_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblclientlocalserver_Internalname, divResponsivetable_mainattributes_tblclientlocalserver_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblclientlocalserver_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblclientlocalserver_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblclientlocalserver_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_siteurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavSiteurl_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSiteurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSiteurl_Internalname, "URL sitio local", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSiteurl_Internalname, AV31SiteURL, StringUtil.RTrim( context.localUtil.Format( AV31SiteURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSiteurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavSiteurl_Visible, edtavSiteurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tbltwitter_Internalname, divResponsivetable_mainattributes_tbltwitter_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tbltwitter_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbltwitter_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tbltwitter_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_consumerkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavConsumerkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumerkey_Internalname, "Clave consumidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumerkey_Internalname, StringUtil.RTrim( AV14ConsumerKey), StringUtil.RTrim( context.localUtil.Format( AV14ConsumerKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumerkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConsumerkey_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_consumersecret_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavConsumersecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumersecret_Internalname, "Secreto consumidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumersecret_Internalname, StringUtil.RTrim( AV15ConsumerSecret), StringUtil.RTrim( context.localUtil.Format( AV15ConsumerSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumersecret_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConsumersecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_callbackurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCallbackurl_Internalname, "URL callback", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCallbackurl_Internalname, AV11CallbackURL, StringUtil.RTrim( context.localUtil.Format( AV11CallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCallbackurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCallbackurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblscopes_Internalname, divResponsivetable_mainattributes_tblscopes_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblscopes_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblscopes_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblscopes_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_adduseradditionaldatascope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavAdduseradditionaldatascope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAdduseradditionaldatascope_Internalname, "Agregar alcance gam_user_additional__data", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAdduseradditionaldatascope_Internalname, StringUtil.BoolToStr( AV57AddUserAdditionalDataScope), "", "Agregar alcance gam_user_additional__data", 1, chkavAdduseradditionaldatascope.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(129, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,129);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_addinitialpropertiesscope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavAddinitialpropertiesscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAddinitialpropertiesscope_Internalname, "Agregar alcance gam_session_initial_prop", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAddinitialpropertiesscope_Internalname, StringUtil.BoolToStr( AV58AddInitialPropertiesScope), "", "Agregar alcance gam_session_initial_prop", 1, chkavAddinitialpropertiesscope.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblcommonadditional_Internalname, divResponsivetable_mainattributes_tblcommonadditional_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblcommonadditional_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblcommonadditional_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblcommonadditional_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_additionalscope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavAdditionalscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdditionalscope_Internalname, "Scope adicional", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdditionalscope_Internalname, AV9AdditionalScope, StringUtil.RTrim( context.localUtil.Format( AV9AdditionalScope, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdditionalscope_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAdditionalscope_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblauthtypename_Internalname, divResponsivetable_mainattributes_tblauthtypename_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblauthtypename_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblauthtypename_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblauthtypename_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrauthenticationtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGamrauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrauthenticationtypename_Internalname, "Tipo de autenticación en servidor remoto", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrauthenticationtypename_Internalname, StringUtil.RTrim( AV59GAMRAuthenticationTypeName), StringUtil.RTrim( context.localUtil.Format( AV59GAMRAuthenticationTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrauthenticationtypename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrauthenticationtypename_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblserverhost_Internalname, divResponsivetable_mainattributes_tblserverhost_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblserverhost_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblserverhost_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblserverhost_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrserverurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGamrserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrserverurl_Internalname, "URL servidor remoto", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrserverurl_Internalname, AV25GAMRServerURL, StringUtil.RTrim( context.localUtil.Format( AV25GAMRServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrserverurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGamrprivateencryptkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrprivateencryptkey_Internalname, "K2BT_GAM_PrivateEncryptionKey", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrprivateencryptkey_Internalname, StringUtil.RTrim( AV23GAMRPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV23GAMRPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrrepositoryguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGamrrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrrepositoryguid_Internalname, "GUID repositorio", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrrepositoryguid_Internalname, StringUtil.RTrim( AV24GAMRRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV24GAMRRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrrepositoryguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_autovalidateexternaltokenandrefresh_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavAutovalidateexternaltokenandrefresh_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAutovalidateexternaltokenandrefresh_Internalname, "Validar token externo", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutovalidateexternaltokenandrefresh_Internalname, StringUtil.BoolToStr( AV60AutovalidateExternalTokenAndRefresh), "", "Validar token externo", 1, chkavAutovalidateexternaltokenandrefresh.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(186, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,186);\"");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblwebservice_Internalname, divResponsivetable_mainattributes_tblwebservice_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblwebservice_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblwebservice_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblwebservice_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavWsversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsversion_Internalname, "Versión Web Service", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsversion, cmbavWsversion_Internalname, StringUtil.RTrim( AV45WSVersion), 1, cmbavWsversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavWsversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"", "", true, 1, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV45WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", (string)(cmbavWsversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_wsprivateencryptkey_Internalname, " Private Encryption Key", "", "", lblTextblock_var_wsprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsprivateencryptkeyfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsprivateencryptkey_Internalname, " Private Encryption Key", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsprivateencryptkey_Internalname, StringUtil.RTrim( AV39WSPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV39WSPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGeneratekey_Internalname, "", "Generar clave", bttGeneratekey_Jsonclick, 5, "", "", StyleString, ClassString, bttGeneratekey_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_GENERATEKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsservername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWsservername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsservername_Internalname, "Nombre servidor", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsservername_Internalname, StringUtil.RTrim( AV41WSServerName), StringUtil.RTrim( context.localUtil.Format( AV41WSServerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavWsservername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsservername_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsserverport_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWsserverport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverport_Internalname, " Port", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WSServerPort), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42WSServerPort), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,216);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Server Port", edtavWsserverport_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsserverport_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsserverbaseurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWsserverbaseurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverbaseurl_Internalname, "URL Base", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverbaseurl_Internalname, StringUtil.RTrim( AV40WSServerBaseURL), StringUtil.RTrim( context.localUtil.Format( AV40WSServerBaseURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,221);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsserverbaseurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsserverbaseurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsserversecureprotocol_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavWsserversecureprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsserversecureprotocol_Internalname, "Protocolo seguro", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 227,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsserversecureprotocol, cmbavWsserversecureprotocol_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV43WSServerSecureProtocol), 4, 0)), 1, cmbavWsserversecureprotocol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavWsserversecureprotocol.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,227);\"", "", true, 1, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43WSServerSecureProtocol), 4, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", (string)(cmbavWsserversecureprotocol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wstimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWstimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWstimeout_Internalname, "Timeout (segundos)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 232,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWstimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WSTimeout), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44WSTimeout), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,232);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWstimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWstimeout_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wspackage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWspackage_Internalname, "Paquete", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 238,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWspackage_Internalname, StringUtil.RTrim( AV38WSPackage), StringUtil.RTrim( context.localUtil.Format( AV38WSPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,238);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWspackage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWsname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsname_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 243,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsname_Internalname, StringUtil.RTrim( AV37WSName), StringUtil.RTrim( context.localUtil.Format( AV37WSName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,243);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsextension_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavWsextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsextension_Internalname, "Extensión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsextension_Internalname, StringUtil.RTrim( AV36WSExtension), StringUtil.RTrim( context.localUtil.Format( AV36WSExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,248);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsextension_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsextension_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tblexternal_Internalname, divResponsivetable_mainattributes_tblexternal_Visible, 0, "px", 0, "px", divResponsivetable_mainattributes_tblexternal_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblexternal_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblexternal_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavCusversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCusversion_Internalname, "Versión JSON", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 260,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCusversion, cmbavCusversion_Internalname, StringUtil.RTrim( AV20CusVersion), 1, cmbavCusversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavCusversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,260);\"", "", true, 1, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV20CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", (string)(cmbavCusversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_cusprivateencryptkey_Internalname, "Clave de encriptación privada", "", "", lblTextblock_var_cusprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusprivateencryptkeyfieldcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusprivateencryptkey_Internalname, "Clave de encriptación privada", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusprivateencryptkey_Internalname, StringUtil.RTrim( AV19CusPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV19CusPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Private encryption key", edtavCusprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 267,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGenerate_Internalname, "", "Generar clave", bttGenerate_Jsonclick, 5, "", "", StyleString, ClassString, bttGenerate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_GENERATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusfilename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCusfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusfilename_Internalname, "Nombre archivo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 273,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusfilename_Internalname, StringUtil.RTrim( AV17CusFileName), StringUtil.RTrim( context.localUtil.Format( AV17CusFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,273);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusfilename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusfilename_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cuspackage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCuspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuspackage_Internalname, "Paquete", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 278,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuspackage_Internalname, StringUtil.RTrim( AV18CusPackage), StringUtil.RTrim( context.localUtil.Format( AV18CusPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,278);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuspackage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCuspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusclassname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavCusclassname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusclassname_Internalname, "Nombre de clase", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 283,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusclassname_Internalname, StringUtil.RTrim( AV16CusClassName), StringUtil.RTrim( context.localUtil.Format( AV16CusClassName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,283);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusclassname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusclassname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_289_402( true) ;
         }
         else
         {
            wb_table1_289_402( false) ;
         }
         return  ;
      }

      protected void wb_table1_289_402e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START402( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "K2BT_GAM_WCAuthenticationTypeEntryGeneral", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP400( ) ;
            }
         }
      }

      protected void WS402( )
      {
         START402( ) ;
         EVT402( ) ;
      }

      protected void EVT402( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_GENERATEKEY'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_GenerateKey' */
                                    E13402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_GENERATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Generate' */
                                    E14402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Confirm' */
                                    E15402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E16402 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP400( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavFunctionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE402( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm402( ) ;
            }
         }
      }

      protected void PA402( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavFunctionid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavFunctionid.ItemCount > 0 )
         {
            AV22FunctionId = cmbavFunctionid.getValidValue(AV22FunctionId);
            AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV22FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV28IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnable));
         AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
         AV57AddUserAdditionalDataScope = StringUtil.StrToBool( StringUtil.BoolToStr( AV57AddUserAdditionalDataScope));
         AssignAttri(sPrefix, false, "AV57AddUserAdditionalDataScope", AV57AddUserAdditionalDataScope);
         AV58AddInitialPropertiesScope = StringUtil.StrToBool( StringUtil.BoolToStr( AV58AddInitialPropertiesScope));
         AssignAttri(sPrefix, false, "AV58AddInitialPropertiesScope", AV58AddInitialPropertiesScope);
         AV60AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( StringUtil.BoolToStr( AV60AutovalidateExternalTokenAndRefresh));
         AssignAttri(sPrefix, false, "AV60AutovalidateExternalTokenAndRefresh", AV60AutovalidateExternalTokenAndRefresh);
         if ( cmbavWsversion.ItemCount > 0 )
         {
            AV45WSVersion = cmbavWsversion.getValidValue(AV45WSVersion);
            AssignAttri(sPrefix, false, "AV45WSVersion", AV45WSVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV45WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", cmbavWsversion.ToJavascriptSource(), true);
         }
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
            AV43WSServerSecureProtocol = (short)(NumberUtil.Val( cmbavWsserversecureprotocol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43WSServerSecureProtocol), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV43WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV43WSServerSecureProtocol), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43WSServerSecureProtocol), 4, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", cmbavWsserversecureprotocol.ToJavascriptSource(), true);
         }
         if ( cmbavCusversion.ItemCount > 0 )
         {
            AV20CusVersion = cmbavCusversion.getValidValue(AV20CusVersion);
            AssignAttri(sPrefix, false, "AV20CusVersion", AV20CusVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV20CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", cmbavCusversion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF402( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF402( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12402 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E16402 ();
            WB400( ) ;
         }
      }

      protected void send_integrity_lvl_hashes402( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP400( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11402 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV30Name = cgiGet( sPrefix+"wcpOAV30Name");
            wcpOAV54TypeId = cgiGet( sPrefix+"wcpOAV54TypeId");
            Gx_mode = cgiGet( sPrefix+"vMODE");
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV30Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
            }
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV22FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
            AV21Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
            AV28IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
            AV32SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
            AV10BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
            AV27Impersonate = cgiGet( edtavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
            AV12ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri(sPrefix, false, "AV12ClientId", AV12ClientId);
            AV13ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri(sPrefix, false, "AV13ClientSecret", AV13ClientSecret);
            AV56VersionPath = cgiGet( edtavVersionpath_Internalname);
            AssignAttri(sPrefix, false, "AV56VersionPath", AV56VersionPath);
            AV31SiteURL = cgiGet( edtavSiteurl_Internalname);
            AssignAttri(sPrefix, false, "AV31SiteURL", AV31SiteURL);
            AV14ConsumerKey = cgiGet( edtavConsumerkey_Internalname);
            AssignAttri(sPrefix, false, "AV14ConsumerKey", AV14ConsumerKey);
            AV15ConsumerSecret = cgiGet( edtavConsumersecret_Internalname);
            AssignAttri(sPrefix, false, "AV15ConsumerSecret", AV15ConsumerSecret);
            AV11CallbackURL = cgiGet( edtavCallbackurl_Internalname);
            AssignAttri(sPrefix, false, "AV11CallbackURL", AV11CallbackURL);
            AV57AddUserAdditionalDataScope = StringUtil.StrToBool( cgiGet( chkavAdduseradditionaldatascope_Internalname));
            AssignAttri(sPrefix, false, "AV57AddUserAdditionalDataScope", AV57AddUserAdditionalDataScope);
            AV58AddInitialPropertiesScope = StringUtil.StrToBool( cgiGet( chkavAddinitialpropertiesscope_Internalname));
            AssignAttri(sPrefix, false, "AV58AddInitialPropertiesScope", AV58AddInitialPropertiesScope);
            AV9AdditionalScope = cgiGet( edtavAdditionalscope_Internalname);
            AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
            AV59GAMRAuthenticationTypeName = cgiGet( edtavGamrauthenticationtypename_Internalname);
            AssignAttri(sPrefix, false, "AV59GAMRAuthenticationTypeName", AV59GAMRAuthenticationTypeName);
            AV25GAMRServerURL = cgiGet( edtavGamrserverurl_Internalname);
            AssignAttri(sPrefix, false, "AV25GAMRServerURL", AV25GAMRServerURL);
            AV23GAMRPrivateEncryptKey = cgiGet( edtavGamrprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV23GAMRPrivateEncryptKey", AV23GAMRPrivateEncryptKey);
            AV24GAMRRepositoryGUID = cgiGet( edtavGamrrepositoryguid_Internalname);
            AssignAttri(sPrefix, false, "AV24GAMRRepositoryGUID", AV24GAMRRepositoryGUID);
            AV60AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( cgiGet( chkavAutovalidateexternaltokenandrefresh_Internalname));
            AssignAttri(sPrefix, false, "AV60AutovalidateExternalTokenAndRefresh", AV60AutovalidateExternalTokenAndRefresh);
            cmbavWsversion.CurrentValue = cgiGet( cmbavWsversion_Internalname);
            AV45WSVersion = cgiGet( cmbavWsversion_Internalname);
            AssignAttri(sPrefix, false, "AV45WSVersion", AV45WSVersion);
            AV39WSPrivateEncryptKey = cgiGet( edtavWsprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV39WSPrivateEncryptKey", AV39WSPrivateEncryptKey);
            AV41WSServerName = cgiGet( edtavWsservername_Internalname);
            AssignAttri(sPrefix, false, "AV41WSServerName", AV41WSServerName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSSERVERPORT");
               GX_FocusControl = edtavWsserverport_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42WSServerPort = 0;
               AssignAttri(sPrefix, false, "AV42WSServerPort", StringUtil.LTrimStr( (decimal)(AV42WSServerPort), 4, 0));
            }
            else
            {
               AV42WSServerPort = (short)(context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "AV42WSServerPort", StringUtil.LTrimStr( (decimal)(AV42WSServerPort), 4, 0));
            }
            AV40WSServerBaseURL = cgiGet( edtavWsserverbaseurl_Internalname);
            AssignAttri(sPrefix, false, "AV40WSServerBaseURL", AV40WSServerBaseURL);
            cmbavWsserversecureprotocol.CurrentValue = cgiGet( cmbavWsserversecureprotocol_Internalname);
            AV43WSServerSecureProtocol = (short)(NumberUtil.Val( cgiGet( cmbavWsserversecureprotocol_Internalname), "."));
            AssignAttri(sPrefix, false, "AV43WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV43WSServerSecureProtocol), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSTIMEOUT");
               GX_FocusControl = edtavWstimeout_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44WSTimeout = 0;
               AssignAttri(sPrefix, false, "AV44WSTimeout", StringUtil.LTrimStr( (decimal)(AV44WSTimeout), 4, 0));
            }
            else
            {
               AV44WSTimeout = (short)(context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "AV44WSTimeout", StringUtil.LTrimStr( (decimal)(AV44WSTimeout), 4, 0));
            }
            AV38WSPackage = cgiGet( edtavWspackage_Internalname);
            AssignAttri(sPrefix, false, "AV38WSPackage", AV38WSPackage);
            AV37WSName = cgiGet( edtavWsname_Internalname);
            AssignAttri(sPrefix, false, "AV37WSName", AV37WSName);
            AV36WSExtension = cgiGet( edtavWsextension_Internalname);
            AssignAttri(sPrefix, false, "AV36WSExtension", AV36WSExtension);
            cmbavCusversion.CurrentValue = cgiGet( cmbavCusversion_Internalname);
            AV20CusVersion = cgiGet( cmbavCusversion_Internalname);
            AssignAttri(sPrefix, false, "AV20CusVersion", AV20CusVersion);
            AV19CusPrivateEncryptKey = cgiGet( edtavCusprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV19CusPrivateEncryptKey", AV19CusPrivateEncryptKey);
            AV17CusFileName = cgiGet( edtavCusfilename_Internalname);
            AssignAttri(sPrefix, false, "AV17CusFileName", AV17CusFileName);
            AV18CusPackage = cgiGet( edtavCuspackage_Internalname);
            AssignAttri(sPrefix, false, "AV18CusPackage", AV18CusPackage);
            AV16CusClassName = cgiGet( edtavCusclassname_Internalname);
            AssignAttri(sPrefix, false, "AV16CusClassName", AV16CusClassName);
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
         E11402 ();
         if (returnInSub) return;
      }

      protected void E11402( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12402( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         divResponsivetable_mainattributes_tbldata_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tbldata_Internalname, "Class", divResponsivetable_mainattributes_tbldata_Class, true);
         divResponsivetable_mainattributes_tblimpersonate_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblimpersonate_Internalname, "Class", divResponsivetable_mainattributes_tblimpersonate_Class, true);
         divResponsivetable_mainattributes_tblclientidsecret_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientidsecret_Internalname, "Class", divResponsivetable_mainattributes_tblclientidsecret_Class, true);
         divResponsivetable_mainattributes_tbltwitter_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tbltwitter_Internalname, "Class", divResponsivetable_mainattributes_tbltwitter_Class, true);
         divResponsivetable_mainattributes_tblcommonadditional_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblcommonadditional_Internalname, "Class", divResponsivetable_mainattributes_tblcommonadditional_Class, true);
         divResponsivetable_mainattributes_tblserverhost_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblserverhost_Internalname, "Class", divResponsivetable_mainattributes_tblserverhost_Class, true);
         divResponsivetable_mainattributes_tblwebservice_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblwebservice_Internalname, "Class", divResponsivetable_mainattributes_tblwebservice_Class, true);
         divResponsivetable_mainattributes_tblexternal_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblexternal_Internalname, "Class", divResponsivetable_mainattributes_tblexternal_Class, true);
         divResponsivetable_mainattributes_tblclientlocalserver_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientlocalserver_Internalname, "Class", divResponsivetable_mainattributes_tblclientlocalserver_Class, true);
         divResponsivetable_mainattributes_tblscopes_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblscopes_Internalname, "Class", divResponsivetable_mainattributes_tblscopes_Class, true);
         divResponsivetable_mainattributes_tblauthtypename_Class = "Section";
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblauthtypename_Internalname, "Class", divResponsivetable_mainattributes_tblauthtypename_Class, true);
         divAttributescontainertable_tbldata_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tbldata_Internalname, "Class", divAttributescontainertable_tbldata_Class, true);
         divAttributescontainertable_tblimpersonate_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblimpersonate_Internalname, "Class", divAttributescontainertable_tblimpersonate_Class, true);
         divAttributescontainertable_tblclientidsecret_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblclientidsecret_Internalname, "Class", divAttributescontainertable_tblclientidsecret_Class, true);
         divAttributescontainertable_tbltwitter_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tbltwitter_Internalname, "Class", divAttributescontainertable_tbltwitter_Class, true);
         divAttributescontainertable_tblcommonadditional_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblcommonadditional_Internalname, "Class", divAttributescontainertable_tblcommonadditional_Class, true);
         divAttributescontainertable_tblserverhost_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblserverhost_Internalname, "Class", divAttributescontainertable_tblserverhost_Class, true);
         divAttributescontainertable_tblwebservice_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblwebservice_Internalname, "Class", divAttributescontainertable_tblwebservice_Class, true);
         divAttributescontainertable_tblexternal_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblexternal_Internalname, "Class", divAttributescontainertable_tblexternal_Class, true);
         divAttributescontainertable_tblclientlocalserver_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblclientlocalserver_Internalname, "Class", divAttributescontainertable_tblclientlocalserver_Class, true);
         divAttributescontainertable_tblscopes_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblscopes_Internalname, "Class", divAttributescontainertable_tblscopes_Class, true);
         divAttributescontainertable_tblauthtypename_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblauthtypename_Internalname, "Class", divAttributescontainertable_tblauthtypename_Class, true);
         divContenttable_Class = "Section";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtavName_Enabled = 1;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
            {
               AV32SmallImageName = "GAMButtonTwitterSmall";
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 )
            {
               AV32SmallImageName = "GAMButtonFacebookSmall";
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 )
            {
               AV32SmallImageName = "GAMButtonGoogleSmall";
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
            }
         }
         else
         {
            edtavName_Enabled = 0;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            AV22FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
            if ( StringUtil.StrCmp(AV54TypeId, "GAMLocal") == 0 )
            {
               AV49AuthenticationTypeLocal.load( AV30Name);
               AV30Name = AV49AuthenticationTypeLocal.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV22FunctionId = AV49AuthenticationTypeLocal.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
               AV28IsEnable = AV49AuthenticationTypeLocal.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV49AuthenticationTypeLocal.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV49AuthenticationTypeLocal.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV49AuthenticationTypeLocal.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV5AuthenticationTypeFacebook.load( AV30Name);
               AV30Name = AV5AuthenticationTypeFacebook.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV28IsEnable = AV5AuthenticationTypeFacebook.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV5AuthenticationTypeFacebook.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV5AuthenticationTypeFacebook.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV5AuthenticationTypeFacebook.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV5AuthenticationTypeFacebook.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV12ClientId = AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV12ClientId", AV12ClientId);
               AV13ClientSecret = AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV13ClientSecret", AV13ClientSecret);
               AV31SiteURL = AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV31SiteURL", AV31SiteURL);
               AV9AdditionalScope = AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV48AuthenticationTypeGoogle.load( AV30Name);
               AV30Name = AV48AuthenticationTypeGoogle.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV28IsEnable = AV48AuthenticationTypeGoogle.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV48AuthenticationTypeGoogle.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV48AuthenticationTypeGoogle.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV48AuthenticationTypeGoogle.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV48AuthenticationTypeGoogle.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV12ClientId = AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV12ClientId", AV12ClientId);
               AV13ClientSecret = AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV13ClientSecret", AV13ClientSecret);
               AV31SiteURL = AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV31SiteURL", AV31SiteURL);
               AV9AdditionalScope = AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV47AuthenticationTypeGAMRemote.load( AV30Name);
               AV30Name = AV47AuthenticationTypeGAMRemote.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV22FunctionId = AV47AuthenticationTypeGAMRemote.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
               AV28IsEnable = AV47AuthenticationTypeGAMRemote.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV47AuthenticationTypeGAMRemote.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV47AuthenticationTypeGAMRemote.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV47AuthenticationTypeGAMRemote.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV47AuthenticationTypeGAMRemote.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV12ClientId = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV12ClientId", AV12ClientId);
               AV13ClientSecret = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV13ClientSecret", AV13ClientSecret);
               AV31SiteURL = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV31SiteURL", AV31SiteURL);
               AV9AdditionalScope = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
               AV25GAMRServerURL = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl;
               AssignAttri(sPrefix, false, "AV25GAMRServerURL", AV25GAMRServerURL);
               AV23GAMRPrivateEncryptKey = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey;
               AssignAttri(sPrefix, false, "AV23GAMRPrivateEncryptKey", AV23GAMRPrivateEncryptKey);
               AV24GAMRRepositoryGUID = AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid;
               AssignAttri(sPrefix, false, "AV24GAMRRepositoryGUID", AV24GAMRRepositoryGUID);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemoteRest") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV55AuthenticationTypeGAMRemoteRest.load( AV30Name);
               AV30Name = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV22FunctionId = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
               AV28IsEnable = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV12ClientId = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV12ClientId", AV12ClientId);
               AV13ClientSecret = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV13ClientSecret", AV13ClientSecret);
               AV56VersionPath = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Versionpath;
               AssignAttri(sPrefix, false, "AV56VersionPath", AV56VersionPath);
               AV58AddInitialPropertiesScope = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Addsessioninitialpropertiesscope;
               AssignAttri(sPrefix, false, "AV58AddInitialPropertiesScope", AV58AddInitialPropertiesScope);
               AV57AddUserAdditionalDataScope = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Adduseradditionaldatascope;
               AssignAttri(sPrefix, false, "AV57AddUserAdditionalDataScope", AV57AddUserAdditionalDataScope);
               AV9AdditionalScope = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
               AV59GAMRAuthenticationTypeName = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteauthenticationtypename;
               AssignAttri(sPrefix, false, "AV59GAMRAuthenticationTypeName", AV59GAMRAuthenticationTypeName);
               AV25GAMRServerURL = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverurl;
               AssignAttri(sPrefix, false, "AV25GAMRServerURL", AV25GAMRServerURL);
               AV23GAMRPrivateEncryptKey = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverkey;
               AssignAttri(sPrefix, false, "AV23GAMRPrivateEncryptKey", AV23GAMRPrivateEncryptKey);
               AV24GAMRRepositoryGUID = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoterepositoryguid;
               AssignAttri(sPrefix, false, "AV24GAMRRepositoryGUID", AV24GAMRRepositoryGUID);
               AV60AutovalidateExternalTokenAndRefresh = AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Autovalidateexternaltokenandrefresh;
               AssignAttri(sPrefix, false, "AV60AutovalidateExternalTokenAndRefresh", AV60AutovalidateExternalTokenAndRefresh);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV6AuthenticationTypeTwitter.load( AV30Name);
               AV30Name = AV6AuthenticationTypeTwitter.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV28IsEnable = AV6AuthenticationTypeTwitter.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV6AuthenticationTypeTwitter.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV6AuthenticationTypeTwitter.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV6AuthenticationTypeTwitter.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV6AuthenticationTypeTwitter.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV14ConsumerKey = AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey;
               AssignAttri(sPrefix, false, "AV14ConsumerKey", AV14ConsumerKey);
               AV15ConsumerSecret = AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret;
               AssignAttri(sPrefix, false, "AV15ConsumerSecret", AV15ConsumerSecret);
               AV11CallbackURL = AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl;
               AssignAttri(sPrefix, false, "AV11CallbackURL", AV11CallbackURL);
               AV9AdditionalScope = AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV9AdditionalScope", AV9AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "ExternalWebService") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV51AuthenticationTypeWebService.load( AV30Name);
               AV30Name = AV51AuthenticationTypeWebService.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV22FunctionId = AV51AuthenticationTypeWebService.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
               AV28IsEnable = AV51AuthenticationTypeWebService.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV51AuthenticationTypeWebService.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV51AuthenticationTypeWebService.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV51AuthenticationTypeWebService.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV51AuthenticationTypeWebService.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV45WSVersion = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version;
               AssignAttri(sPrefix, false, "AV45WSVersion", AV45WSVersion);
               AV39WSPrivateEncryptKey = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey;
               AssignAttri(sPrefix, false, "AV39WSPrivateEncryptKey", AV39WSPrivateEncryptKey);
               AV41WSServerName = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV41WSServerName", AV41WSServerName);
               AV42WSServerPort = (short)(AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port);
               AssignAttri(sPrefix, false, "AV42WSServerPort", StringUtil.LTrimStr( (decimal)(AV42WSServerPort), 4, 0));
               AV40WSServerBaseURL = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl;
               AssignAttri(sPrefix, false, "AV40WSServerBaseURL", AV40WSServerBaseURL);
               AV43WSServerSecureProtocol = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol;
               AssignAttri(sPrefix, false, "AV43WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV43WSServerSecureProtocol), 4, 0));
               AV44WSTimeout = (short)(AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout);
               AssignAttri(sPrefix, false, "AV44WSTimeout", StringUtil.LTrimStr( (decimal)(AV44WSTimeout), 4, 0));
               AV38WSPackage = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package;
               AssignAttri(sPrefix, false, "AV38WSPackage", AV38WSPackage);
               AV37WSName = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV37WSName", AV37WSName);
               AV36WSExtension = AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension;
               AssignAttri(sPrefix, false, "AV36WSExtension", AV36WSExtension);
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Custom") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV46AuthenticationTypeCustom.load( AV30Name);
               AV30Name = AV46AuthenticationTypeCustom.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV30Name", AV30Name);
               AV22FunctionId = AV46AuthenticationTypeCustom.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
               AV28IsEnable = AV46AuthenticationTypeCustom.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
               AV21Dsc = AV46AuthenticationTypeCustom.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV21Dsc", AV21Dsc);
               AV32SmallImageName = AV46AuthenticationTypeCustom.gxTpr_Smallimagename;
               AssignAttri(sPrefix, false, "AV32SmallImageName", AV32SmallImageName);
               AV10BigImageName = AV46AuthenticationTypeCustom.gxTpr_Bigimagename;
               AssignAttri(sPrefix, false, "AV10BigImageName", AV10BigImageName);
               AV27Impersonate = AV46AuthenticationTypeCustom.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
               AV20CusVersion = AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version;
               AssignAttri(sPrefix, false, "AV20CusVersion", AV20CusVersion);
               AV19CusPrivateEncryptKey = AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey;
               AssignAttri(sPrefix, false, "AV19CusPrivateEncryptKey", AV19CusPrivateEncryptKey);
               AV17CusFileName = AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename;
               AssignAttri(sPrefix, false, "AV17CusFileName", AV17CusFileName);
               AV18CusPackage = AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package;
               AssignAttri(sPrefix, false, "AV18CusPackage", AV18CusPackage);
               AV16CusClassName = AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname;
               AssignAttri(sPrefix, false, "AV16CusClassName", AV16CusClassName);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttConfirm_Visible = 0;
            AssignProp(sPrefix, false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttCancel_Visible = 0;
            AssignProp(sPrefix, false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
            cmbavFunctionid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            bttGeneratekey_Visible = 0;
            AssignProp(sPrefix, false, bttGeneratekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Visible), 5, 0), true);
            bttGenerate_Visible = 0;
            AssignProp(sPrefix, false, bttGenerate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGenerate_Visible), 5, 0), true);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavSmallimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavSmallimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSmallimagename_Enabled), 5, 0), true);
            edtavBigimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavBigimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBigimagename_Enabled), 5, 0), true);
            edtavImpersonate_Enabled = 0;
            AssignProp(sPrefix, false, edtavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImpersonate_Enabled), 5, 0), true);
            cmbavWsversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsversion.Enabled), 5, 0), true);
            edtavWsprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsprivateencryptkey_Enabled), 5, 0), true);
            edtavWsservername_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsservername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsservername_Enabled), 5, 0), true);
            edtavWsserverport_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverport_Enabled), 5, 0), true);
            edtavWsserverbaseurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverbaseurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverbaseurl_Enabled), 5, 0), true);
            cmbavWsserversecureprotocol.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsserversecureprotocol.Enabled), 5, 0), true);
            edtavWstimeout_Enabled = 0;
            AssignProp(sPrefix, false, edtavWstimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWstimeout_Enabled), 5, 0), true);
            edtavWspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavWspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWspackage_Enabled), 5, 0), true);
            edtavWsname_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsname_Enabled), 5, 0), true);
            edtavWsextension_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsextension_Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            edtavSiteurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavSiteurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSiteurl_Enabled), 5, 0), true);
            edtavAdditionalscope_Enabled = 0;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Enabled), 5, 0), true);
            edtavConsumerkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumerkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumerkey_Enabled), 5, 0), true);
            edtavConsumersecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumersecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumersecret_Enabled), 5, 0), true);
            edtavCallbackurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavCallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCallbackurl_Enabled), 5, 0), true);
            cmbavCusversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCusversion.Enabled), 5, 0), true);
            edtavCusprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusprivateencryptkey_Enabled), 5, 0), true);
            edtavCusfilename_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusfilename_Enabled), 5, 0), true);
            edtavCuspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavCuspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCuspackage_Enabled), 5, 0), true);
            edtavCusclassname_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusclassname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusclassname_Enabled), 5, 0), true);
            edtavGamrserverurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Enabled), 5, 0), true);
            edtavGamrprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Enabled), 5, 0), true);
            edtavGamrrepositoryguid_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrrepositoryguid_Enabled), 5, 0), true);
            bttConfirm_Caption = "Eliminar";
            AssignProp(sPrefix, false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
         }
         /* Execute user subroutine: 'REFRESHAUTHENTICATIONTYPE' */
         S182 ();
         if (returnInSub) return;
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

      protected void E13402( )
      {
         /* 'E_GenerateKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_GENERATEKEY' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'U_GENERATEKEY' Routine */
         returnInSub = false;
         AV39WSPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV39WSPrivateEncryptKey", AV39WSPrivateEncryptKey);
      }

      protected void E14402( )
      {
         /* 'E_Generate' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_GENERATE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_GENERATE' Routine */
         returnInSub = false;
         AV19CusPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV19CusPrivateEncryptKey", AV19CusPrivateEncryptKey);
      }

      protected void E15402( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46AuthenticationTypeCustom", AV46AuthenticationTypeCustom);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV51AuthenticationTypeWebService", AV51AuthenticationTypeWebService);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6AuthenticationTypeTwitter", AV6AuthenticationTypeTwitter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55AuthenticationTypeGAMRemoteRest", AV55AuthenticationTypeGAMRemoteRest);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47AuthenticationTypeGAMRemote", AV47AuthenticationTypeGAMRemote);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48AuthenticationTypeGoogle", AV48AuthenticationTypeGoogle);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeFacebook", AV5AuthenticationTypeFacebook);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49AuthenticationTypeLocal", AV49AuthenticationTypeLocal);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50AuthenticationTypeOauth20", AV50AuthenticationTypeOauth20);
      }

      protected void S162( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( StringUtil.StrCmp(AV54TypeId, "GAMLocal") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV49AuthenticationTypeLocal.load( AV30Name);
               }
               AV49AuthenticationTypeLocal.gxTpr_Name = AV30Name;
               AV49AuthenticationTypeLocal.gxTpr_Functionid = AV22FunctionId;
               AV49AuthenticationTypeLocal.gxTpr_Isenable = AV28IsEnable;
               AV49AuthenticationTypeLocal.gxTpr_Description = AV21Dsc;
               AV49AuthenticationTypeLocal.gxTpr_Smallimagename = AV32SmallImageName;
               AV49AuthenticationTypeLocal.gxTpr_Bigimagename = AV10BigImageName;
               AV49AuthenticationTypeLocal.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV5AuthenticationTypeFacebook.load( AV30Name);
               }
               AV5AuthenticationTypeFacebook.gxTpr_Name = AV30Name;
               AV5AuthenticationTypeFacebook.gxTpr_Isenable = AV28IsEnable;
               AV5AuthenticationTypeFacebook.gxTpr_Description = AV21Dsc;
               AV5AuthenticationTypeFacebook.gxTpr_Smallimagename = AV32SmallImageName;
               AV5AuthenticationTypeFacebook.gxTpr_Bigimagename = AV10BigImageName;
               AV5AuthenticationTypeFacebook.gxTpr_Impersonate = AV27Impersonate;
               AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid = AV12ClientId;
               AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret = AV13ClientSecret;
               AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl = AV31SiteURL;
               AV5AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope = AV9AdditionalScope;
               AV5AuthenticationTypeFacebook.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV48AuthenticationTypeGoogle.load( AV30Name);
               }
               AV48AuthenticationTypeGoogle.gxTpr_Name = AV30Name;
               AV48AuthenticationTypeGoogle.gxTpr_Isenable = AV28IsEnable;
               AV48AuthenticationTypeGoogle.gxTpr_Description = AV21Dsc;
               AV48AuthenticationTypeGoogle.gxTpr_Smallimagename = AV32SmallImageName;
               AV48AuthenticationTypeGoogle.gxTpr_Bigimagename = AV10BigImageName;
               AV48AuthenticationTypeGoogle.gxTpr_Impersonate = AV27Impersonate;
               AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid = AV12ClientId;
               AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret = AV13ClientSecret;
               AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl = AV31SiteURL;
               AV48AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope = AV9AdditionalScope;
               AV48AuthenticationTypeGoogle.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV47AuthenticationTypeGAMRemote.load( AV30Name);
               }
               AV47AuthenticationTypeGAMRemote.gxTpr_Name = AV30Name;
               AV47AuthenticationTypeGAMRemote.gxTpr_Functionid = AV22FunctionId;
               AV47AuthenticationTypeGAMRemote.gxTpr_Isenable = AV28IsEnable;
               AV47AuthenticationTypeGAMRemote.gxTpr_Description = AV21Dsc;
               AV47AuthenticationTypeGAMRemote.gxTpr_Smallimagename = AV32SmallImageName;
               AV47AuthenticationTypeGAMRemote.gxTpr_Bigimagename = AV10BigImageName;
               AV47AuthenticationTypeGAMRemote.gxTpr_Impersonate = AV27Impersonate;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid = AV12ClientId;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret = AV13ClientSecret;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl = AV31SiteURL;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope = AV9AdditionalScope;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl = AV25GAMRServerURL;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey = AV23GAMRPrivateEncryptKey;
               AV47AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid = AV24GAMRRepositoryGUID;
               AV47AuthenticationTypeGAMRemote.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemoteRest") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV55AuthenticationTypeGAMRemoteRest.load( AV30Name);
               }
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Name = AV30Name;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Functionid = AV22FunctionId;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Isenable = AV28IsEnable;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Description = AV21Dsc;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Smallimagename = AV32SmallImageName;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Bigimagename = AV10BigImageName;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Impersonate = AV27Impersonate;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientid = AV12ClientId;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientsecret = AV13ClientSecret;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Versionpath = AV56VersionPath;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Addsessioninitialpropertiesscope = AV58AddInitialPropertiesScope;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Adduseradditionaldatascope = AV57AddUserAdditionalDataScope;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Additionalscope = AV9AdditionalScope;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteauthenticationtypename = AV59GAMRAuthenticationTypeName;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverurl = AV25GAMRServerURL;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverkey = AV23GAMRPrivateEncryptKey;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoterepositoryguid = AV24GAMRRepositoryGUID;
               AV55AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Autovalidateexternaltokenandrefresh = AV60AutovalidateExternalTokenAndRefresh;
               AV55AuthenticationTypeGAMRemoteRest.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV6AuthenticationTypeTwitter.load( AV30Name);
               }
               AV6AuthenticationTypeTwitter.gxTpr_Name = AV30Name;
               AV6AuthenticationTypeTwitter.gxTpr_Isenable = AV28IsEnable;
               AV6AuthenticationTypeTwitter.gxTpr_Description = AV21Dsc;
               AV6AuthenticationTypeTwitter.gxTpr_Smallimagename = AV32SmallImageName;
               AV6AuthenticationTypeTwitter.gxTpr_Bigimagename = AV10BigImageName;
               AV6AuthenticationTypeTwitter.gxTpr_Impersonate = AV27Impersonate;
               AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey = AV14ConsumerKey;
               AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret = AV15ConsumerSecret;
               AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl = AV11CallbackURL;
               AV6AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope = AV9AdditionalScope;
               AV6AuthenticationTypeTwitter.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "ExternalWebService") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV51AuthenticationTypeWebService.load( AV30Name);
               }
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV51AuthenticationTypeWebService.gxTpr_Name = AV30Name;
               AV51AuthenticationTypeWebService.gxTpr_Functionid = AV22FunctionId;
               AV51AuthenticationTypeWebService.gxTpr_Isenable = AV28IsEnable;
               AV51AuthenticationTypeWebService.gxTpr_Description = AV21Dsc;
               AV51AuthenticationTypeWebService.gxTpr_Smallimagename = AV32SmallImageName;
               AV51AuthenticationTypeWebService.gxTpr_Bigimagename = AV10BigImageName;
               AV51AuthenticationTypeWebService.gxTpr_Impersonate = AV27Impersonate;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version = AV45WSVersion;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey = AV39WSPrivateEncryptKey;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout = AV44WSTimeout;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package = AV38WSPackage;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name = AV37WSName;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension = AV36WSExtension;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name = AV41WSServerName;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port = AV42WSServerPort;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl = AV40WSServerBaseURL;
               AV51AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol = AV43WSServerSecureProtocol;
               AV51AuthenticationTypeWebService.save();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Custom") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV46AuthenticationTypeCustom.load( AV30Name);
               }
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV46AuthenticationTypeCustom.gxTpr_Name = AV30Name;
               AV46AuthenticationTypeCustom.gxTpr_Functionid = AV22FunctionId;
               AV46AuthenticationTypeCustom.gxTpr_Isenable = AV28IsEnable;
               AV46AuthenticationTypeCustom.gxTpr_Description = AV21Dsc;
               AV46AuthenticationTypeCustom.gxTpr_Smallimagename = AV32SmallImageName;
               AV46AuthenticationTypeCustom.gxTpr_Bigimagename = AV10BigImageName;
               AV46AuthenticationTypeCustom.gxTpr_Impersonate = AV27Impersonate;
               AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version = AV20CusVersion;
               AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey = AV19CusPrivateEncryptKey;
               AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename = AV17CusFileName;
               AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package = AV18CusPackage;
               AV46AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname = AV16CusClassName;
               AV46AuthenticationTypeCustom.save();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( StringUtil.StrCmp(AV54TypeId, "GAMLocal") == 0 )
            {
               AV49AuthenticationTypeLocal.load( AV30Name);
               AV49AuthenticationTypeLocal.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 )
            {
               AV5AuthenticationTypeFacebook.load( AV30Name);
               AV5AuthenticationTypeFacebook.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 )
            {
               AV48AuthenticationTypeGoogle.load( AV30Name);
               AV48AuthenticationTypeGoogle.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 )
            {
               AV47AuthenticationTypeGAMRemote.load( AV30Name);
               AV47AuthenticationTypeGAMRemote.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemoteRest") == 0 )
            {
               AV55AuthenticationTypeGAMRemoteRest.load( AV30Name);
               AV55AuthenticationTypeGAMRemoteRest.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Oauth20") == 0 )
            {
               AV50AuthenticationTypeOauth20.load( AV30Name);
               AV50AuthenticationTypeOauth20.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
            {
               AV6AuthenticationTypeTwitter.load( AV30Name);
               AV6AuthenticationTypeTwitter.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "ExternalWebService") == 0 )
            {
               AV51AuthenticationTypeWebService.load( AV30Name);
               AV51AuthenticationTypeWebService.delete();
            }
            else if ( StringUtil.StrCmp(AV54TypeId, "Custom") == 0 )
            {
               AV46AuthenticationTypeCustom.load( AV30Name);
               AV46AuthenticationTypeCustom.delete();
            }
         }
         if ( StringUtil.StrCmp(AV54TypeId, "GAMLocal") == 0 )
         {
            if ( AV49AuthenticationTypeLocal.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 )
         {
            if ( AV5AuthenticationTypeFacebook.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 )
         {
            if ( AV48AuthenticationTypeGoogle.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 )
         {
            if ( AV47AuthenticationTypeGAMRemote.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemoteRest") == 0 )
         {
            if ( AV55AuthenticationTypeGAMRemoteRest.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Oauth20") == 0 )
         {
            if ( AV50AuthenticationTypeOauth20.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
         {
            if ( AV6AuthenticationTypeTwitter.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "ExternalWebService") == 0 )
         {
            if ( AV51AuthenticationTypeWebService.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Custom") == 0 )
         {
            if ( AV46AuthenticationTypeCustom.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
               CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         AV53Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV53Errors.Count )
         {
            AV52Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV53Errors.Item(AV64GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV52Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV52Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV64GXV1 = (int)(AV64GXV1+1);
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S182( )
      {
         /* 'REFRESHAUTHENTICATIONTYPE' Routine */
         returnInSub = false;
         edtavSiteurl_Visible = 1;
         AssignProp(sPrefix, false, edtavSiteurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSiteurl_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblimpersonate_Visible = 1;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblimpersonate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblimpersonate_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblclientidsecret_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientidsecret_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblclientidsecret_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblclientlocalserver_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientlocalserver_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblclientlocalserver_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblscopes_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblscopes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblscopes_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblauthtypename_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblauthtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblauthtypename_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblcommonadditional_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblcommonadditional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblcommonadditional_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblserverhost_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblserverhost_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblserverhost_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tbltwitter_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tbltwitter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tbltwitter_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblwebservice_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblwebservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblwebservice_Visible), 5, 0), true);
         divResponsivetable_mainattributes_tblexternal_Visible = 0;
         AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblexternal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblexternal_Visible), 5, 0), true);
         if ( ( StringUtil.StrCmp(AV54TypeId, "AppleID") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "WeChat") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 ) )
         {
            AV22FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         else
         {
            cmbavFunctionid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(AV54TypeId, "GAMLocal") == 0 )
         {
            divResponsivetable_mainattributes_tblimpersonate_Visible = 0;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblimpersonate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblimpersonate_Visible), 5, 0), true);
         }
         else if ( ( StringUtil.StrCmp(AV54TypeId, "AppleID") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "Facebook") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "Google") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "WeChat") == 0 ) || ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 ) )
         {
            divResponsivetable_mainattributes_tblclientidsecret_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientidsecret_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblclientidsecret_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblclientlocalserver_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientlocalserver_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblclientlocalserver_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblcommonadditional_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblcommonadditional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblcommonadditional_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(AV54TypeId, "WeChat") == 0 )
            {
               edtavVersionpath_Visible = 0;
               AssignProp(sPrefix, false, edtavVersionpath_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVersionpath_Visible), 5, 0), true);
            }
            if ( StringUtil.StrCmp(AV54TypeId, "GAMRemote") == 0 )
            {
               edtavVersionpath_Visible = 0;
               AssignProp(sPrefix, false, edtavVersionpath_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVersionpath_Visible), 5, 0), true);
               divResponsivetable_mainattributes_tblscopes_Visible = 1;
               AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblscopes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblscopes_Visible), 5, 0), true);
               divResponsivetable_mainattributes_tblserverhost_Visible = 1;
               AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblserverhost_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblserverhost_Visible), 5, 0), true);
            }
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "GAMRemoteRest") == 0 )
         {
            divResponsivetable_mainattributes_tblclientidsecret_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblclientidsecret_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblclientidsecret_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblscopes_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblscopes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblscopes_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblcommonadditional_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblcommonadditional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblcommonadditional_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblauthtypename_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblauthtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblauthtypename_Visible), 5, 0), true);
            divResponsivetable_mainattributes_tblserverhost_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblserverhost_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblserverhost_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Twitter") == 0 )
         {
            AV22FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV22FunctionId", AV22FunctionId);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            divResponsivetable_mainattributes_tbltwitter_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tbltwitter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tbltwitter_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "ExternalWebService") == 0 )
         {
            divResponsivetable_mainattributes_tblwebservice_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblwebservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblwebservice_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV54TypeId, "Custom") == 0 )
         {
            divResponsivetable_mainattributes_tblexternal_Visible = 1;
            AssignProp(sPrefix, false, divResponsivetable_mainattributes_tblexternal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divResponsivetable_mainattributes_tblexternal_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E16402( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_289_402( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 292,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 294,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e17401_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_289_402e( true) ;
         }
         else
         {
            wb_table1_289_402e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV30Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV30Name", AV30Name);
         AV54TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV54TypeId", AV54TypeId);
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
         PA402( ) ;
         WS402( ) ;
         WE402( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV30Name = (string)((string)getParm(obj,1));
         sCtrlAV54TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA402( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wcauthenticationtypeentrygeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA402( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV30Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV30Name", AV30Name);
            AV54TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV54TypeId", AV54TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV30Name = cgiGet( sPrefix+"wcpOAV30Name");
         wcpOAV54TypeId = cgiGet( sPrefix+"wcpOAV54TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV30Name, wcpOAV30Name) != 0 ) || ( StringUtil.StrCmp(AV54TypeId, wcpOAV54TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV30Name = AV30Name;
         wcpOAV54TypeId = AV54TypeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV30Name = cgiGet( sPrefix+"AV30Name_CTRL");
         if ( StringUtil.Len( sCtrlAV30Name) > 0 )
         {
            AV30Name = cgiGet( sCtrlAV30Name);
            AssignAttri(sPrefix, false, "AV30Name", AV30Name);
         }
         else
         {
            AV30Name = cgiGet( sPrefix+"AV30Name_PARM");
         }
         sCtrlAV54TypeId = cgiGet( sPrefix+"AV54TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV54TypeId) > 0 )
         {
            AV54TypeId = cgiGet( sCtrlAV54TypeId);
            AssignAttri(sPrefix, false, "AV54TypeId", AV54TypeId);
         }
         else
         {
            AV54TypeId = cgiGet( sPrefix+"AV54TypeId_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA402( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS402( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS402( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV30Name_PARM", StringUtil.RTrim( AV30Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30Name_CTRL", StringUtil.RTrim( sCtrlAV30Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV54TypeId_PARM", StringUtil.RTrim( AV54TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV54TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV54TypeId_CTRL", StringUtil.RTrim( sCtrlAV54TypeId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE402( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188141016", true, true);
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
         context.AddJavascriptSource("k2bfsg/wcauthenticationtypeentrygeneral.js", "?2024188141024", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavFunctionid.Name = "vFUNCTIONID";
         cmbavFunctionid.WebTags = "";
         cmbavFunctionid.addItem("AuthenticationAndRoles", "Authentication and Roles", 0);
         cmbavFunctionid.addItem("OnlyAuthentication", "Only Authentication", 0);
         if ( cmbavFunctionid.ItemCount > 0 )
         {
         }
         chkavIsenable.Name = "vISENABLE";
         chkavIsenable.WebTags = "";
         chkavIsenable.Caption = "";
         AssignProp(sPrefix, false, chkavIsenable_Internalname, "TitleCaption", chkavIsenable.Caption, true);
         chkavIsenable.CheckedValue = "false";
         chkavAdduseradditionaldatascope.Name = "vADDUSERADDITIONALDATASCOPE";
         chkavAdduseradditionaldatascope.WebTags = "";
         chkavAdduseradditionaldatascope.Caption = "";
         AssignProp(sPrefix, false, chkavAdduseradditionaldatascope_Internalname, "TitleCaption", chkavAdduseradditionaldatascope.Caption, true);
         chkavAdduseradditionaldatascope.CheckedValue = "false";
         chkavAddinitialpropertiesscope.Name = "vADDINITIALPROPERTIESSCOPE";
         chkavAddinitialpropertiesscope.WebTags = "";
         chkavAddinitialpropertiesscope.Caption = "";
         AssignProp(sPrefix, false, chkavAddinitialpropertiesscope_Internalname, "TitleCaption", chkavAddinitialpropertiesscope.Caption, true);
         chkavAddinitialpropertiesscope.CheckedValue = "false";
         chkavAutovalidateexternaltokenandrefresh.Name = "vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         chkavAutovalidateexternaltokenandrefresh.WebTags = "";
         chkavAutovalidateexternaltokenandrefresh.Caption = "";
         AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "TitleCaption", chkavAutovalidateexternaltokenandrefresh.Caption, true);
         chkavAutovalidateexternaltokenandrefresh.CheckedValue = "false";
         cmbavWsversion.Name = "vWSVERSION";
         cmbavWsversion.WebTags = "";
         cmbavWsversion.addItem("GAM10", "Version 1.0", 0);
         cmbavWsversion.addItem("GAM20", "Version 2.0", 0);
         if ( cmbavWsversion.ItemCount > 0 )
         {
         }
         cmbavWsserversecureprotocol.Name = "vWSSERVERSECUREPROTOCOL";
         cmbavWsserversecureprotocol.WebTags = "";
         cmbavWsserversecureprotocol.addItem("0", "No", 0);
         cmbavWsserversecureprotocol.addItem("1", "Yes", 0);
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
         }
         cmbavCusversion.Name = "vCUSVERSION";
         cmbavCusversion.WebTags = "";
         cmbavCusversion.addItem("GAM10", "Version 1.0", 0);
         cmbavCusversion.addItem("GAM20", "Version 2.0", 0);
         if ( cmbavCusversion.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavName_Internalname = sPrefix+"vNAME";
         divTable_container_name_Internalname = sPrefix+"TABLE_CONTAINER_NAME";
         cmbavFunctionid_Internalname = sPrefix+"vFUNCTIONID";
         divTable_container_functionid_Internalname = sPrefix+"TABLE_CONTAINER_FUNCTIONID";
         edtavDsc_Internalname = sPrefix+"vDSC";
         divTable_container_dsc_Internalname = sPrefix+"TABLE_CONTAINER_DSC";
         chkavIsenable_Internalname = sPrefix+"vISENABLE";
         divTable_container_isenable_Internalname = sPrefix+"TABLE_CONTAINER_ISENABLE";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         divTable_container_smallimagename_Internalname = sPrefix+"TABLE_CONTAINER_SMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTable_container_bigimagename_Internalname = sPrefix+"TABLE_CONTAINER_BIGIMAGENAME";
         divAttributescontainertable_tbldata_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLDATA";
         divResponsivetable_mainattributes_tbldata_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA";
         edtavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         divTable_container_impersonate_Internalname = sPrefix+"TABLE_CONTAINER_IMPERSONATE";
         divAttributescontainertable_tblimpersonate_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLIMPERSONATE";
         divResponsivetable_mainattributes_tblimpersonate_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLIMPERSONATE";
         edtavClientid_Internalname = sPrefix+"vCLIENTID";
         divTable_container_clientid_Internalname = sPrefix+"TABLE_CONTAINER_CLIENTID";
         edtavClientsecret_Internalname = sPrefix+"vCLIENTSECRET";
         divTable_container_clientsecret_Internalname = sPrefix+"TABLE_CONTAINER_CLIENTSECRET";
         edtavVersionpath_Internalname = sPrefix+"vVERSIONPATH";
         divTable_container_versionpath_Internalname = sPrefix+"TABLE_CONTAINER_VERSIONPATH";
         divAttributescontainertable_tblclientidsecret_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCLIENTIDSECRET";
         divResponsivetable_mainattributes_tblclientidsecret_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLCLIENTIDSECRET";
         edtavSiteurl_Internalname = sPrefix+"vSITEURL";
         divTable_container_siteurl_Internalname = sPrefix+"TABLE_CONTAINER_SITEURL";
         divAttributescontainertable_tblclientlocalserver_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCLIENTLOCALSERVER";
         divResponsivetable_mainattributes_tblclientlocalserver_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLCLIENTLOCALSERVER";
         edtavConsumerkey_Internalname = sPrefix+"vCONSUMERKEY";
         divTable_container_consumerkey_Internalname = sPrefix+"TABLE_CONTAINER_CONSUMERKEY";
         edtavConsumersecret_Internalname = sPrefix+"vCONSUMERSECRET";
         divTable_container_consumersecret_Internalname = sPrefix+"TABLE_CONTAINER_CONSUMERSECRET";
         edtavCallbackurl_Internalname = sPrefix+"vCALLBACKURL";
         divTable_container_callbackurl_Internalname = sPrefix+"TABLE_CONTAINER_CALLBACKURL";
         divAttributescontainertable_tbltwitter_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLTWITTER";
         divResponsivetable_mainattributes_tbltwitter_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLTWITTER";
         chkavAdduseradditionaldatascope_Internalname = sPrefix+"vADDUSERADDITIONALDATASCOPE";
         divTable_container_adduseradditionaldatascope_Internalname = sPrefix+"TABLE_CONTAINER_ADDUSERADDITIONALDATASCOPE";
         chkavAddinitialpropertiesscope_Internalname = sPrefix+"vADDINITIALPROPERTIESSCOPE";
         divTable_container_addinitialpropertiesscope_Internalname = sPrefix+"TABLE_CONTAINER_ADDINITIALPROPERTIESSCOPE";
         divAttributescontainertable_tblscopes_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLSCOPES";
         divResponsivetable_mainattributes_tblscopes_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLSCOPES";
         edtavAdditionalscope_Internalname = sPrefix+"vADDITIONALSCOPE";
         divTable_container_additionalscope_Internalname = sPrefix+"TABLE_CONTAINER_ADDITIONALSCOPE";
         divAttributescontainertable_tblcommonadditional_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCOMMONADDITIONAL";
         divResponsivetable_mainattributes_tblcommonadditional_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLCOMMONADDITIONAL";
         edtavGamrauthenticationtypename_Internalname = sPrefix+"vGAMRAUTHENTICATIONTYPENAME";
         divTable_container_gamrauthenticationtypename_Internalname = sPrefix+"TABLE_CONTAINER_GAMRAUTHENTICATIONTYPENAME";
         divAttributescontainertable_tblauthtypename_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLAUTHTYPENAME";
         divResponsivetable_mainattributes_tblauthtypename_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLAUTHTYPENAME";
         edtavGamrserverurl_Internalname = sPrefix+"vGAMRSERVERURL";
         divTable_container_gamrserverurl_Internalname = sPrefix+"TABLE_CONTAINER_GAMRSERVERURL";
         edtavGamrprivateencryptkey_Internalname = sPrefix+"vGAMRPRIVATEENCRYPTKEY";
         divTable_container_gamrprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_GAMRPRIVATEENCRYPTKEY";
         edtavGamrrepositoryguid_Internalname = sPrefix+"vGAMRREPOSITORYGUID";
         divTable_container_gamrrepositoryguid_Internalname = sPrefix+"TABLE_CONTAINER_GAMRREPOSITORYGUID";
         chkavAutovalidateexternaltokenandrefresh_Internalname = sPrefix+"vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         divTable_container_autovalidateexternaltokenandrefresh_Internalname = sPrefix+"TABLE_CONTAINER_AUTOVALIDATEEXTERNALTOKENANDREFRESH";
         divAttributescontainertable_tblserverhost_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLSERVERHOST";
         divResponsivetable_mainattributes_tblserverhost_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLSERVERHOST";
         cmbavWsversion_Internalname = sPrefix+"vWSVERSION";
         divTable_container_wsversion_Internalname = sPrefix+"TABLE_CONTAINER_WSVERSION";
         lblTextblock_var_wsprivateencryptkey_Internalname = sPrefix+"TEXTBLOCK_VAR_WSPRIVATEENCRYPTKEY";
         edtavWsprivateencryptkey_Internalname = sPrefix+"vWSPRIVATEENCRYPTKEY";
         bttGeneratekey_Internalname = sPrefix+"GENERATEKEY";
         divTable_container_wsprivateencryptkeyfieldcontainer_Internalname = sPrefix+"TABLE_CONTAINER_WSPRIVATEENCRYPTKEYFIELDCONTAINER";
         divTable_container_wsprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_WSPRIVATEENCRYPTKEY";
         edtavWsservername_Internalname = sPrefix+"vWSSERVERNAME";
         divTable_container_wsservername_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERNAME";
         edtavWsserverport_Internalname = sPrefix+"vWSSERVERPORT";
         divTable_container_wsserverport_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERPORT";
         edtavWsserverbaseurl_Internalname = sPrefix+"vWSSERVERBASEURL";
         divTable_container_wsserverbaseurl_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERBASEURL";
         cmbavWsserversecureprotocol_Internalname = sPrefix+"vWSSERVERSECUREPROTOCOL";
         divTable_container_wsserversecureprotocol_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERSECUREPROTOCOL";
         edtavWstimeout_Internalname = sPrefix+"vWSTIMEOUT";
         divTable_container_wstimeout_Internalname = sPrefix+"TABLE_CONTAINER_WSTIMEOUT";
         edtavWspackage_Internalname = sPrefix+"vWSPACKAGE";
         divTable_container_wspackage_Internalname = sPrefix+"TABLE_CONTAINER_WSPACKAGE";
         edtavWsname_Internalname = sPrefix+"vWSNAME";
         divTable_container_wsname_Internalname = sPrefix+"TABLE_CONTAINER_WSNAME";
         edtavWsextension_Internalname = sPrefix+"vWSEXTENSION";
         divTable_container_wsextension_Internalname = sPrefix+"TABLE_CONTAINER_WSEXTENSION";
         divAttributescontainertable_tblwebservice_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLWEBSERVICE";
         divResponsivetable_mainattributes_tblwebservice_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLWEBSERVICE";
         cmbavCusversion_Internalname = sPrefix+"vCUSVERSION";
         divTable_container_cusversion_Internalname = sPrefix+"TABLE_CONTAINER_CUSVERSION";
         lblTextblock_var_cusprivateencryptkey_Internalname = sPrefix+"TEXTBLOCK_VAR_CUSPRIVATEENCRYPTKEY";
         edtavCusprivateencryptkey_Internalname = sPrefix+"vCUSPRIVATEENCRYPTKEY";
         bttGenerate_Internalname = sPrefix+"GENERATE";
         divTable_container_cusprivateencryptkeyfieldcontainer_Internalname = sPrefix+"TABLE_CONTAINER_CUSPRIVATEENCRYPTKEYFIELDCONTAINER";
         divTable_container_cusprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_CUSPRIVATEENCRYPTKEY";
         edtavCusfilename_Internalname = sPrefix+"vCUSFILENAME";
         divTable_container_cusfilename_Internalname = sPrefix+"TABLE_CONTAINER_CUSFILENAME";
         edtavCuspackage_Internalname = sPrefix+"vCUSPACKAGE";
         divTable_container_cuspackage_Internalname = sPrefix+"TABLE_CONTAINER_CUSPACKAGE";
         edtavCusclassname_Internalname = sPrefix+"vCUSCLASSNAME";
         divTable_container_cusclassname_Internalname = sPrefix+"TABLE_CONTAINER_CUSCLASSNAME";
         divAttributescontainertable_tblexternal_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLEXTERNAL";
         divResponsivetable_mainattributes_tblexternal_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLEXTERNAL";
         bttConfirm_Internalname = sPrefix+"CONFIRM";
         bttCancel_Internalname = sPrefix+"CANCEL";
         tblActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkavAutovalidateexternaltokenandrefresh.Caption = "Validar token externo";
         chkavAddinitialpropertiesscope.Caption = "Agregar alcance gam_session_initial_prop";
         chkavAdduseradditionaldatascope.Caption = "Agregar alcance gam_user_additional__data";
         chkavIsenable.Caption = "¿Habilitado?";
         bttCancel_Visible = 1;
         bttConfirm_Visible = 1;
         bttConfirm_Caption = "Confirmar";
         edtavCusclassname_Jsonclick = "";
         edtavCusclassname_Enabled = 1;
         edtavCuspackage_Jsonclick = "";
         edtavCuspackage_Enabled = 1;
         edtavCusfilename_Jsonclick = "";
         edtavCusfilename_Enabled = 1;
         bttGenerate_Visible = 1;
         edtavCusprivateencryptkey_Jsonclick = "";
         edtavCusprivateencryptkey_Enabled = 1;
         cmbavCusversion_Jsonclick = "";
         cmbavCusversion.Enabled = 1;
         divAttributescontainertable_tblexternal_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblexternal_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblexternal_Visible = 1;
         edtavWsextension_Jsonclick = "";
         edtavWsextension_Enabled = 1;
         edtavWsname_Jsonclick = "";
         edtavWsname_Enabled = 1;
         edtavWspackage_Jsonclick = "";
         edtavWspackage_Enabled = 1;
         edtavWstimeout_Jsonclick = "";
         edtavWstimeout_Enabled = 1;
         cmbavWsserversecureprotocol_Jsonclick = "";
         cmbavWsserversecureprotocol.Enabled = 1;
         edtavWsserverbaseurl_Jsonclick = "";
         edtavWsserverbaseurl_Enabled = 1;
         edtavWsserverport_Jsonclick = "";
         edtavWsserverport_Enabled = 1;
         edtavWsservername_Jsonclick = "";
         edtavWsservername_Enabled = 1;
         bttGeneratekey_Visible = 1;
         edtavWsprivateencryptkey_Jsonclick = "";
         edtavWsprivateencryptkey_Enabled = 1;
         cmbavWsversion_Jsonclick = "";
         cmbavWsversion.Enabled = 1;
         divAttributescontainertable_tblwebservice_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblwebservice_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblwebservice_Visible = 1;
         chkavAutovalidateexternaltokenandrefresh.Enabled = 1;
         edtavGamrrepositoryguid_Jsonclick = "";
         edtavGamrrepositoryguid_Enabled = 1;
         edtavGamrprivateencryptkey_Jsonclick = "";
         edtavGamrprivateencryptkey_Enabled = 1;
         edtavGamrserverurl_Jsonclick = "";
         edtavGamrserverurl_Enabled = 1;
         divAttributescontainertable_tblserverhost_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblserverhost_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblserverhost_Visible = 1;
         edtavGamrauthenticationtypename_Jsonclick = "";
         edtavGamrauthenticationtypename_Enabled = 1;
         divAttributescontainertable_tblauthtypename_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblauthtypename_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblauthtypename_Visible = 1;
         edtavAdditionalscope_Jsonclick = "";
         edtavAdditionalscope_Enabled = 1;
         divAttributescontainertable_tblcommonadditional_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblcommonadditional_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblcommonadditional_Visible = 1;
         chkavAddinitialpropertiesscope.Enabled = 1;
         chkavAdduseradditionaldatascope.Enabled = 1;
         divAttributescontainertable_tblscopes_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblscopes_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblscopes_Visible = 1;
         edtavCallbackurl_Jsonclick = "";
         edtavCallbackurl_Enabled = 1;
         edtavConsumersecret_Jsonclick = "";
         edtavConsumersecret_Enabled = 1;
         edtavConsumerkey_Jsonclick = "";
         edtavConsumerkey_Enabled = 1;
         divAttributescontainertable_tbltwitter_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tbltwitter_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tbltwitter_Visible = 1;
         edtavSiteurl_Jsonclick = "";
         edtavSiteurl_Enabled = 1;
         edtavSiteurl_Visible = 1;
         divAttributescontainertable_tblclientlocalserver_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblclientlocalserver_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblclientlocalserver_Visible = 1;
         edtavVersionpath_Jsonclick = "";
         edtavVersionpath_Enabled = 1;
         edtavVersionpath_Visible = 1;
         edtavClientsecret_Jsonclick = "";
         edtavClientsecret_Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         divAttributescontainertable_tblclientidsecret_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblclientidsecret_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblclientidsecret_Visible = 1;
         edtavImpersonate_Jsonclick = "";
         edtavImpersonate_Enabled = 1;
         divAttributescontainertable_tblimpersonate_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tblimpersonate_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divResponsivetable_mainattributes_tblimpersonate_Visible = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         chkavIsenable.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         divAttributescontainertable_tbldata_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divResponsivetable_mainattributes_tbldata_Class = "K2BToolsTable_ComponentWithoutTitleContainer";
         divContenttable_Class = "K2BToolsTable_WebPanelDesignerContent";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("'E_GENERATEKEY'","{handler:'E13402',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("'E_GENERATEKEY'",",oparms:[{av:'AV39WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("'E_GENERATE'","{handler:'E14402',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("'E_GENERATE'",",oparms:[{av:'AV19CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E15402',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV31SiteURL',fld:'vSITEURL',pic:''},{av:'AV24GAMRRepositoryGUID',fld:'vGAMRREPOSITORYGUID',pic:''},{av:'AV23GAMRPrivateEncryptKey',fld:'vGAMRPRIVATEENCRYPTKEY',pic:''},{av:'AV25GAMRServerURL',fld:'vGAMRSERVERURL',pic:''},{av:'AV59GAMRAuthenticationTypeName',fld:'vGAMRAUTHENTICATIONTYPENAME',pic:''},{av:'AV56VersionPath',fld:'vVERSIONPATH',pic:''},{av:'AV13ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'AV12ClientId',fld:'vCLIENTID',pic:''},{av:'AV9AdditionalScope',fld:'vADDITIONALSCOPE',pic:''},{av:'AV11CallbackURL',fld:'vCALLBACKURL',pic:''},{av:'AV15ConsumerSecret',fld:'vCONSUMERSECRET',pic:''},{av:'AV14ConsumerKey',fld:'vCONSUMERKEY',pic:''},{av:'cmbavWsserversecureprotocol'},{av:'AV43WSServerSecureProtocol',fld:'vWSSERVERSECUREPROTOCOL',pic:'ZZZ9'},{av:'AV40WSServerBaseURL',fld:'vWSSERVERBASEURL',pic:''},{av:'AV42WSServerPort',fld:'vWSSERVERPORT',pic:'ZZZ9'},{av:'AV41WSServerName',fld:'vWSSERVERNAME',pic:''},{av:'AV36WSExtension',fld:'vWSEXTENSION',pic:''},{av:'AV37WSName',fld:'vWSNAME',pic:''},{av:'AV38WSPackage',fld:'vWSPACKAGE',pic:''},{av:'AV44WSTimeout',fld:'vWSTIMEOUT',pic:'ZZZ9'},{av:'AV39WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavWsversion'},{av:'AV45WSVersion',fld:'vWSVERSION',pic:''},{av:'AV16CusClassName',fld:'vCUSCLASSNAME',pic:''},{av:'AV18CusPackage',fld:'vCUSPACKAGE',pic:''},{av:'AV17CusFileName',fld:'vCUSFILENAME',pic:''},{av:'AV19CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavCusversion'},{av:'AV20CusVersion',fld:'vCUSVERSION',pic:''},{av:'AV27Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV10BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'AV32SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV21Dsc',fld:'vDSC',pic:''},{av:'cmbavFunctionid'},{av:'AV22FunctionId',fld:'vFUNCTIONID',pic:''},{av:'AV30Name',fld:'vNAME',pic:''},{av:'AV54TypeId',fld:'vTYPEID',pic:''},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[{av:'cmbavFunctionid'},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E17401',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("'E_CANCEL'",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("VALIDV_WSVERSION","{handler:'Validv_Wsversion',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("VALIDV_WSVERSION",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
         setEventMetadata("VALIDV_CUSVERSION","{handler:'Validv_Cusversion',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("VALIDV_CUSVERSION",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV57AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV58AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV60AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]}");
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
         wcpOAV30Name = "";
         wcpOAV54TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV22FunctionId = "";
         AV21Dsc = "";
         AV32SmallImageName = "";
         AV10BigImageName = "";
         AV27Impersonate = "";
         AV12ClientId = "";
         AV13ClientSecret = "";
         AV56VersionPath = "";
         AV31SiteURL = "";
         AV14ConsumerKey = "";
         AV15ConsumerSecret = "";
         AV11CallbackURL = "";
         AV9AdditionalScope = "";
         AV59GAMRAuthenticationTypeName = "";
         AV25GAMRServerURL = "";
         AV23GAMRPrivateEncryptKey = "";
         AV24GAMRRepositoryGUID = "";
         AV45WSVersion = "";
         lblTextblock_var_wsprivateencryptkey_Jsonclick = "";
         AV39WSPrivateEncryptKey = "";
         bttGeneratekey_Jsonclick = "";
         AV41WSServerName = "";
         AV40WSServerBaseURL = "";
         AV38WSPackage = "";
         AV37WSName = "";
         AV36WSExtension = "";
         AV20CusVersion = "";
         lblTextblock_var_cusprivateencryptkey_Jsonclick = "";
         AV19CusPrivateEncryptKey = "";
         bttGenerate_Jsonclick = "";
         AV17CusFileName = "";
         AV18CusPackage = "";
         AV16CusClassName = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV49AuthenticationTypeLocal = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal(context);
         AV5AuthenticationTypeFacebook = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook(context);
         AV48AuthenticationTypeGoogle = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle(context);
         AV47AuthenticationTypeGAMRemote = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote(context);
         AV55AuthenticationTypeGAMRemoteRest = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemoteRest(context);
         AV6AuthenticationTypeTwitter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter(context);
         AV51AuthenticationTypeWebService = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService(context);
         AV46AuthenticationTypeCustom = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom(context);
         AV50AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         AV53Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV52Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV30Name = "";
         sCtrlAV54TypeId = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV42WSServerPort ;
      private short AV43WSServerSecureProtocol ;
      private short AV44WSTimeout ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int divResponsivetable_mainattributes_tblimpersonate_Visible ;
      private int edtavImpersonate_Enabled ;
      private int divResponsivetable_mainattributes_tblclientidsecret_Visible ;
      private int edtavClientid_Enabled ;
      private int edtavClientsecret_Enabled ;
      private int edtavVersionpath_Visible ;
      private int edtavVersionpath_Enabled ;
      private int divResponsivetable_mainattributes_tblclientlocalserver_Visible ;
      private int edtavSiteurl_Visible ;
      private int edtavSiteurl_Enabled ;
      private int divResponsivetable_mainattributes_tbltwitter_Visible ;
      private int edtavConsumerkey_Enabled ;
      private int edtavConsumersecret_Enabled ;
      private int edtavCallbackurl_Enabled ;
      private int divResponsivetable_mainattributes_tblscopes_Visible ;
      private int divResponsivetable_mainattributes_tblcommonadditional_Visible ;
      private int edtavAdditionalscope_Enabled ;
      private int divResponsivetable_mainattributes_tblauthtypename_Visible ;
      private int edtavGamrauthenticationtypename_Enabled ;
      private int divResponsivetable_mainattributes_tblserverhost_Visible ;
      private int edtavGamrserverurl_Enabled ;
      private int edtavGamrprivateencryptkey_Enabled ;
      private int edtavGamrrepositoryguid_Enabled ;
      private int divResponsivetable_mainattributes_tblwebservice_Visible ;
      private int edtavWsprivateencryptkey_Enabled ;
      private int bttGeneratekey_Visible ;
      private int edtavWsservername_Enabled ;
      private int edtavWsserverport_Enabled ;
      private int edtavWsserverbaseurl_Enabled ;
      private int edtavWstimeout_Enabled ;
      private int edtavWspackage_Enabled ;
      private int edtavWsname_Enabled ;
      private int edtavWsextension_Enabled ;
      private int divResponsivetable_mainattributes_tblexternal_Visible ;
      private int edtavCusprivateencryptkey_Enabled ;
      private int bttGenerate_Visible ;
      private int edtavCusfilename_Enabled ;
      private int edtavCuspackage_Enabled ;
      private int edtavCusclassname_Enabled ;
      private int bttConfirm_Visible ;
      private int bttCancel_Visible ;
      private int AV64GXV1 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV30Name ;
      private string AV54TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV30Name ;
      private string wcpOAV54TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divContenttable_Class ;
      private string divResponsivetable_mainattributes_tbldata_Internalname ;
      private string divResponsivetable_mainattributes_tbldata_Class ;
      private string divAttributescontainertable_tbldata_Internalname ;
      private string divAttributescontainertable_tbldata_Class ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divTable_container_functionid_Internalname ;
      private string cmbavFunctionid_Internalname ;
      private string AV22FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV21Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_isenable_Internalname ;
      private string chkavIsenable_Internalname ;
      private string divTable_container_smallimagename_Internalname ;
      private string edtavSmallimagename_Internalname ;
      private string AV32SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string divTable_container_bigimagename_Internalname ;
      private string edtavBigimagename_Internalname ;
      private string AV10BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string divResponsivetable_mainattributes_tblimpersonate_Internalname ;
      private string divResponsivetable_mainattributes_tblimpersonate_Class ;
      private string divAttributescontainertable_tblimpersonate_Internalname ;
      private string divAttributescontainertable_tblimpersonate_Class ;
      private string divTable_container_impersonate_Internalname ;
      private string edtavImpersonate_Internalname ;
      private string AV27Impersonate ;
      private string edtavImpersonate_Jsonclick ;
      private string divResponsivetable_mainattributes_tblclientidsecret_Internalname ;
      private string divResponsivetable_mainattributes_tblclientidsecret_Class ;
      private string divAttributescontainertable_tblclientidsecret_Internalname ;
      private string divAttributescontainertable_tblclientidsecret_Class ;
      private string divTable_container_clientid_Internalname ;
      private string edtavClientid_Internalname ;
      private string edtavClientid_Jsonclick ;
      private string divTable_container_clientsecret_Internalname ;
      private string edtavClientsecret_Internalname ;
      private string edtavClientsecret_Jsonclick ;
      private string divTable_container_versionpath_Internalname ;
      private string edtavVersionpath_Internalname ;
      private string AV56VersionPath ;
      private string edtavVersionpath_Jsonclick ;
      private string divResponsivetable_mainattributes_tblclientlocalserver_Internalname ;
      private string divResponsivetable_mainattributes_tblclientlocalserver_Class ;
      private string divAttributescontainertable_tblclientlocalserver_Internalname ;
      private string divAttributescontainertable_tblclientlocalserver_Class ;
      private string divTable_container_siteurl_Internalname ;
      private string edtavSiteurl_Internalname ;
      private string edtavSiteurl_Jsonclick ;
      private string divResponsivetable_mainattributes_tbltwitter_Internalname ;
      private string divResponsivetable_mainattributes_tbltwitter_Class ;
      private string divAttributescontainertable_tbltwitter_Internalname ;
      private string divAttributescontainertable_tbltwitter_Class ;
      private string divTable_container_consumerkey_Internalname ;
      private string edtavConsumerkey_Internalname ;
      private string AV14ConsumerKey ;
      private string edtavConsumerkey_Jsonclick ;
      private string divTable_container_consumersecret_Internalname ;
      private string edtavConsumersecret_Internalname ;
      private string AV15ConsumerSecret ;
      private string edtavConsumersecret_Jsonclick ;
      private string divTable_container_callbackurl_Internalname ;
      private string edtavCallbackurl_Internalname ;
      private string edtavCallbackurl_Jsonclick ;
      private string divResponsivetable_mainattributes_tblscopes_Internalname ;
      private string divResponsivetable_mainattributes_tblscopes_Class ;
      private string divAttributescontainertable_tblscopes_Internalname ;
      private string divAttributescontainertable_tblscopes_Class ;
      private string divTable_container_adduseradditionaldatascope_Internalname ;
      private string chkavAdduseradditionaldatascope_Internalname ;
      private string divTable_container_addinitialpropertiesscope_Internalname ;
      private string chkavAddinitialpropertiesscope_Internalname ;
      private string divResponsivetable_mainattributes_tblcommonadditional_Internalname ;
      private string divResponsivetable_mainattributes_tblcommonadditional_Class ;
      private string divAttributescontainertable_tblcommonadditional_Internalname ;
      private string divAttributescontainertable_tblcommonadditional_Class ;
      private string divTable_container_additionalscope_Internalname ;
      private string edtavAdditionalscope_Internalname ;
      private string edtavAdditionalscope_Jsonclick ;
      private string divResponsivetable_mainattributes_tblauthtypename_Internalname ;
      private string divResponsivetable_mainattributes_tblauthtypename_Class ;
      private string divAttributescontainertable_tblauthtypename_Internalname ;
      private string divAttributescontainertable_tblauthtypename_Class ;
      private string divTable_container_gamrauthenticationtypename_Internalname ;
      private string edtavGamrauthenticationtypename_Internalname ;
      private string AV59GAMRAuthenticationTypeName ;
      private string edtavGamrauthenticationtypename_Jsonclick ;
      private string divResponsivetable_mainattributes_tblserverhost_Internalname ;
      private string divResponsivetable_mainattributes_tblserverhost_Class ;
      private string divAttributescontainertable_tblserverhost_Internalname ;
      private string divAttributescontainertable_tblserverhost_Class ;
      private string divTable_container_gamrserverurl_Internalname ;
      private string edtavGamrserverurl_Internalname ;
      private string edtavGamrserverurl_Jsonclick ;
      private string divTable_container_gamrprivateencryptkey_Internalname ;
      private string edtavGamrprivateencryptkey_Internalname ;
      private string AV23GAMRPrivateEncryptKey ;
      private string edtavGamrprivateencryptkey_Jsonclick ;
      private string divTable_container_gamrrepositoryguid_Internalname ;
      private string edtavGamrrepositoryguid_Internalname ;
      private string AV24GAMRRepositoryGUID ;
      private string edtavGamrrepositoryguid_Jsonclick ;
      private string divTable_container_autovalidateexternaltokenandrefresh_Internalname ;
      private string chkavAutovalidateexternaltokenandrefresh_Internalname ;
      private string divResponsivetable_mainattributes_tblwebservice_Internalname ;
      private string divResponsivetable_mainattributes_tblwebservice_Class ;
      private string divAttributescontainertable_tblwebservice_Internalname ;
      private string divAttributescontainertable_tblwebservice_Class ;
      private string divTable_container_wsversion_Internalname ;
      private string cmbavWsversion_Internalname ;
      private string AV45WSVersion ;
      private string cmbavWsversion_Jsonclick ;
      private string divTable_container_wsprivateencryptkey_Internalname ;
      private string lblTextblock_var_wsprivateencryptkey_Internalname ;
      private string lblTextblock_var_wsprivateencryptkey_Jsonclick ;
      private string divTable_container_wsprivateencryptkeyfieldcontainer_Internalname ;
      private string edtavWsprivateencryptkey_Internalname ;
      private string AV39WSPrivateEncryptKey ;
      private string edtavWsprivateencryptkey_Jsonclick ;
      private string bttGeneratekey_Internalname ;
      private string bttGeneratekey_Jsonclick ;
      private string divTable_container_wsservername_Internalname ;
      private string edtavWsservername_Internalname ;
      private string AV41WSServerName ;
      private string edtavWsservername_Jsonclick ;
      private string divTable_container_wsserverport_Internalname ;
      private string edtavWsserverport_Internalname ;
      private string edtavWsserverport_Jsonclick ;
      private string divTable_container_wsserverbaseurl_Internalname ;
      private string edtavWsserverbaseurl_Internalname ;
      private string AV40WSServerBaseURL ;
      private string edtavWsserverbaseurl_Jsonclick ;
      private string divTable_container_wsserversecureprotocol_Internalname ;
      private string cmbavWsserversecureprotocol_Internalname ;
      private string cmbavWsserversecureprotocol_Jsonclick ;
      private string divTable_container_wstimeout_Internalname ;
      private string edtavWstimeout_Internalname ;
      private string edtavWstimeout_Jsonclick ;
      private string divTable_container_wspackage_Internalname ;
      private string edtavWspackage_Internalname ;
      private string AV38WSPackage ;
      private string edtavWspackage_Jsonclick ;
      private string divTable_container_wsname_Internalname ;
      private string edtavWsname_Internalname ;
      private string AV37WSName ;
      private string edtavWsname_Jsonclick ;
      private string divTable_container_wsextension_Internalname ;
      private string edtavWsextension_Internalname ;
      private string AV36WSExtension ;
      private string edtavWsextension_Jsonclick ;
      private string divResponsivetable_mainattributes_tblexternal_Internalname ;
      private string divResponsivetable_mainattributes_tblexternal_Class ;
      private string divAttributescontainertable_tblexternal_Internalname ;
      private string divAttributescontainertable_tblexternal_Class ;
      private string divTable_container_cusversion_Internalname ;
      private string cmbavCusversion_Internalname ;
      private string AV20CusVersion ;
      private string cmbavCusversion_Jsonclick ;
      private string divTable_container_cusprivateencryptkey_Internalname ;
      private string lblTextblock_var_cusprivateencryptkey_Internalname ;
      private string lblTextblock_var_cusprivateencryptkey_Jsonclick ;
      private string divTable_container_cusprivateencryptkeyfieldcontainer_Internalname ;
      private string edtavCusprivateencryptkey_Internalname ;
      private string AV19CusPrivateEncryptKey ;
      private string edtavCusprivateencryptkey_Jsonclick ;
      private string bttGenerate_Internalname ;
      private string bttGenerate_Jsonclick ;
      private string divTable_container_cusfilename_Internalname ;
      private string edtavCusfilename_Internalname ;
      private string AV17CusFileName ;
      private string edtavCusfilename_Jsonclick ;
      private string divTable_container_cuspackage_Internalname ;
      private string edtavCuspackage_Internalname ;
      private string AV18CusPackage ;
      private string edtavCuspackage_Jsonclick ;
      private string divTable_container_cusclassname_Internalname ;
      private string edtavCusclassname_Internalname ;
      private string AV16CusClassName ;
      private string edtavCusclassname_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
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
      private string sCtrlGx_mode ;
      private string sCtrlAV30Name ;
      private string sCtrlAV54TypeId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV28IsEnable ;
      private bool AV57AddUserAdditionalDataScope ;
      private bool AV58AddInitialPropertiesScope ;
      private bool AV60AutovalidateExternalTokenAndRefresh ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV12ClientId ;
      private string AV13ClientSecret ;
      private string AV31SiteURL ;
      private string AV11CallbackURL ;
      private string AV9AdditionalScope ;
      private string AV25GAMRServerURL ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCheckbox chkavAdduseradditionaldatascope ;
      private GXCheckbox chkavAddinitialpropertiesscope ;
      private GXCheckbox chkavAutovalidateexternaltokenandrefresh ;
      private GXCombobox cmbavWsversion ;
      private GXCombobox cmbavWsserversecureprotocol ;
      private GXCombobox cmbavCusversion ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV53Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook AV5AuthenticationTypeFacebook ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV52Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter AV6AuthenticationTypeTwitter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom AV46AuthenticationTypeCustom ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote AV47AuthenticationTypeGAMRemote ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle AV48AuthenticationTypeGoogle ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal AV49AuthenticationTypeLocal ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20 AV50AuthenticationTypeOauth20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService AV51AuthenticationTypeWebService ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemoteRest AV55AuthenticationTypeGAMRemoteRest ;
   }

   public class wcauthenticationtypeentrygeneral__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class wcauthenticationtypeentrygeneral__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class wcauthenticationtypeentrygeneral__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wcauthenticationtypeentrygeneral__default : DataStoreHelperBase, IDataStoreHelper
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
