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
   public class repositoryconfiguration : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public repositoryconfiguration( )
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

      public repositoryconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_pId )
      {
         this.AV10pId = aP0_pId;
         executePrivate();
         aP0_pId=this.AV10pId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDefaultauthtypename = new GXCombobox();
         chkavSessionexpiresonipchange = new GXCheckbox();
         chkavAllowoauthaccess = new GXCheckbox();
         cmbavUseridentification = new GXCombobox();
         cmbavUseractivationmethod = new GXCombobox();
         chkavUseremailisunique = new GXCheckbox();
         chkavRequiredemail = new GXCheckbox();
         chkavRequiredpassword = new GXCheckbox();
         chkavRequiredfirstname = new GXCheckbox();
         chkavRequiredlastname = new GXCheckbox();
         cmbavGeneratesessionstatistics = new GXCombobox();
         cmbavUserremembermetype = new GXCombobox();
         chkavGiveanonymoussession = new GXCheckbox();
         cmbavDefaultsecuritypolicyid = new GXCombobox();
         cmbavDefaultroleid = new GXCombobox();
         cmbavLogoutbehaviour = new GXCombobox();
         cmbavEnabletracing = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pId");
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
               gxfirstwebparm = GetFirstPar( "pId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pId");
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
               AV10pId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV10pId", StringUtil.LTrimStr( (decimal)(AV10pId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10pId), "ZZZ9"), context));
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
         PA3J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3J2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188372962", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pId,4,0))}, new string[] {"pId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10pId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"RepositoryConfiguration");
         forbiddenHiddens.Add("Id", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("k2bfsg\\repositoryconfiguration:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV14Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10pId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECURITYADMINISTRATOREMAIL", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCANREGISTERUSERS", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
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
            WE3J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3J2( ) ;
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
         return formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pId,4,0))}, new string[] {"pId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RepositoryConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return "Configuración de repositorio" ;
      }

      protected void WB3J0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Configuración de repositorio", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_id_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Id), 12, 0, ".", "")), StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV28GUID), StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGuid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_namespace_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavNamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNamespace_Internalname, "Namespace", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNamespace_Internalname, StringUtil.RTrim( AV29NameSpace), StringUtil.RTrim( context.localUtil.Format( AV29NameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNamespace_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavNamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV30Name), StringUtil.RTrim( context.localUtil.Format( AV30Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_dsc_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Descripción", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV31Dsc), StringUtil.RTrim( context.localUtil.Format( AV31Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_defaultauthtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavDefaultauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultauthtypename_Internalname, "Tipo de autenticación predeterminado", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultauthtypename, cmbavDefaultauthtypename_Internalname, StringUtil.RTrim( AV32DefaultAuthTypeName), 1, cmbavDefaultauthtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavDefaultauthtypename.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
            AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", (string)(cmbavDefaultauthtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_sessionexpiresonipchange_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavSessionexpiresonipchange_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSessionexpiresonipchange_Internalname, "Expirar sesión de GAM cuando hay cambios de IP", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSessionexpiresonipchange_Internalname, StringUtil.BoolToStr( AV33SessionExpiresOnIPChange), "", "Expirar sesión de GAM cuando hay cambios de IP", 1, chkavSessionexpiresonipchange.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,57);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_allowoauthaccess_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavAllowoauthaccess_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAllowoauthaccess_Internalname, "Permitir acceso OAuth", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAllowoauthaccess_Internalname, StringUtil.BoolToStr( AV34AllowOauthAccess), "", "Permitir acceso OAuth", 1, chkavAllowoauthaccess.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,62);\"");
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
            GxWebStd.gx_group_start( context, grpUserinformation_Internalname, "Información de usuario", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_userinformation_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_useridentification_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavUseridentification_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUseridentification_Internalname, "Identificación de usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUseridentification, cmbavUseridentification_Internalname, StringUtil.RTrim( AV35UserIdentification), 1, cmbavUseridentification_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUseridentification.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
            AssignProp("", false, cmbavUseridentification_Internalname, "Values", (string)(cmbavUseridentification.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_useractivationmethod_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavUseractivationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUseractivationmethod_Internalname, "Método de activación de usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUseractivationmethod, cmbavUseractivationmethod_Internalname, StringUtil.RTrim( AV36UserActivationMethod), 1, cmbavUseractivationmethod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUseractivationmethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
            AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", (string)(cmbavUseractivationmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userautomaticactivationtimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserautomaticactivationtimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserautomaticactivationtimeout_Internalname, "Tiempo límite de activación automática de usuario (horas)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserautomaticactivationtimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserautomaticactivationtimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV37UserAutomaticActivationTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV37UserAutomaticActivationTimeout), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserautomaticactivationtimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserautomaticactivationtimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_useremailisunique_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavUseremailisunique_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUseremailisunique_Internalname, "E-mail de usuario es único", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUseremailisunique_Internalname, StringUtil.BoolToStr( AV38UserEmailisUnique), "", "E-mail de usuario es único", 1, chkavUseremailisunique.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavRequiredemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredemail_Internalname, "Requerir correo electrónico", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredemail_Internalname, StringUtil.BoolToStr( AV39RequiredEmail), "", "Requerir correo electrónico", 1, chkavRequiredemail.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavRequiredpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredpassword_Internalname, "Requerir contraseña", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredpassword_Internalname, StringUtil.BoolToStr( AV40RequiredPassword), "", "Requerir contraseña", 1, chkavRequiredpassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_requiredfirstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavRequiredfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredfirstname_Internalname, "Nombre requerido", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredfirstname_Internalname, StringUtil.BoolToStr( AV53RequiredFirstName), "", "Nombre requerido", 1, chkavRequiredfirstname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredlastname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavRequiredlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredlastname_Internalname, "Apellido requerido", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredlastname_Internalname, StringUtil.BoolToStr( AV54RequiredLastName), "", "Apellido requerido", 1, chkavRequiredlastname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(110, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,110);\"");
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
            GxWebStd.gx_group_start( context, grpSession_Internalname, "Sesión", 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_session_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_generatesessionstatistics_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavGeneratesessionstatistics_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGeneratesessionstatistics_Internalname, "Generar estadísticas de sesión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGeneratesessionstatistics, cmbavGeneratesessionstatistics_Internalname, StringUtil.RTrim( AV41GenerateSessionStatistics), 1, cmbavGeneratesessionstatistics_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGeneratesessionstatistics.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", (string)(cmbavGeneratesessionstatistics.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_usersessioncachetimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsersessioncachetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsersessioncachetimeout_Internalname, "Tiempo de expiración de cache de sesiones (segundos)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsersessioncachetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50UserSessionCacheTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUsersessioncachetimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV50UserSessionCacheTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV50UserSessionCacheTimeout), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsersessioncachetimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsersessioncachetimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userremembermetype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavUserremembermetype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserremembermetype_Internalname, "Tipo de \"Mantenerme conectado\"", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserremembermetype, cmbavUserremembermetype_Internalname, StringUtil.RTrim( AV42UserRememberMeType), 1, cmbavUserremembermetype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUserremembermetype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
            AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", (string)(cmbavUserremembermetype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userremembermetimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserremembermetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserremembermetimeout_Internalname, "Tiempo de expiración de \"Mantenerme conectado\" (días)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserremembermetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43UserRememberMeTimeOut), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserremembermetimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV43UserRememberMeTimeOut), "ZZZ9") : context.localUtil.Format( (decimal)(AV43UserRememberMeTimeOut), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserremembermetimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserremembermetimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userrecoverypasswordkeytimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserrecoverypasswordkeytimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserrecoverypasswordkeytimeout_Internalname, "Tiempo de expiración para recuperación de contraseña (minutos)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserrecoverypasswordkeytimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserrecoverypasswordkeytimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), "ZZZ9") : context.localUtil.Format( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserrecoverypasswordkeytimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserrecoverypasswordkeytimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_minimumamountcharactersinlogin_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavMinimumamountcharactersinlogin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumamountcharactersinlogin_Internalname, "Cantidad mínima de caracteres en login", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumamountcharactersinlogin_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0, ".", "")), StringUtil.LTrim( ((edtavMinimumamountcharactersinlogin_Enabled!=0) ? context.localUtil.Format( (decimal)(AV45MinimumAmountCharactersInLogin), "ZZZ9") : context.localUtil.Format( (decimal)(AV45MinimumAmountCharactersInLogin), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumamountcharactersinlogin_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumamountcharactersinlogin_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_loginattemptstolockuser_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavLoginattemptstolockuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLoginattemptstolockuser_Internalname, "Intentos fallidos de login antes de bloquear usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLoginattemptstolockuser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46LoginAttemptsToLockUser), 4, 0, ".", "")), StringUtil.LTrim( ((edtavLoginattemptstolockuser_Enabled!=0) ? context.localUtil.Format( (decimal)(AV46LoginAttemptsToLockUser), "ZZZ9") : context.localUtil.Format( (decimal)(AV46LoginAttemptsToLockUser), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLoginattemptstolockuser_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLoginattemptstolockuser_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_gamunblockusertimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavGamunblockusertimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamunblockusertimeout_Internalname, "Tiempo para desbloqueo automático de usuario (minutos)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamunblockusertimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GAMUnblockUserTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavGamunblockusertimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV47GAMUnblockUserTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV47GAMUnblockUserTimeout), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamunblockusertimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamunblockusertimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_loginattemptstolocksession_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavLoginattemptstolocksession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLoginattemptstolocksession_Internalname, "Intentos de inicio de sesión antes de bloquear sesión", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLoginattemptstolocksession_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48LoginAttemptsToLockSession), 4, 0, ".", "")), StringUtil.LTrim( ((edtavLoginattemptstolocksession_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48LoginAttemptsToLockSession), "ZZZ9") : context.localUtil.Format( (decimal)(AV48LoginAttemptsToLockSession), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLoginattemptstolocksession_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLoginattemptstolocksession_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "K2BNumber", "right", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_giveanonymoussession_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkavGiveanonymoussession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavGiveanonymoussession_Internalname, "Otorgar sesiones web anónimas", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavGiveanonymoussession_Internalname, StringUtil.BoolToStr( AV49GiveAnonymousSession), "", "Otorgar sesiones web anónimas", 1, chkavGiveanonymoussession.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(169, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,169);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_defaultsecuritypolicyid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavDefaultsecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultsecuritypolicyid_Internalname, "Política de seguridad predeterminada", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultsecuritypolicyid, cmbavDefaultsecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0)), 1, cmbavDefaultsecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDefaultsecuritypolicyid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", (string)(cmbavDefaultsecuritypolicyid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_defaultroleid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavDefaultroleid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultroleid_Internalname, "Rol predeterminado", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultroleid, cmbavDefaultroleid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0)), 1, cmbavDefaultroleid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDefaultroleid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
            AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", (string)(cmbavDefaultroleid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_logoutbehaviour_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavLogoutbehaviour_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogoutbehaviour_Internalname, "Comportamiento de logout remoto", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogoutbehaviour, cmbavLogoutbehaviour_Internalname, StringUtil.RTrim( AV55LogoutBehaviour), 1, cmbavLogoutbehaviour_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavLogoutbehaviour.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavLogoutbehaviour.CurrentValue = StringUtil.RTrim( AV55LogoutBehaviour);
            AssignProp("", false, cmbavLogoutbehaviour_Internalname, "Values", (string)(cmbavLogoutbehaviour.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_enabletracing_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavEnabletracing_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEnabletracing_Internalname, "Habilitar Traza", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEnabletracing, cmbavEnabletracing_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0)), 1, cmbavEnabletracing_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEnabletracing.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "", true, 1, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", (string)(cmbavEnabletracing.ToJavascriptSource()), true);
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
            wb_table1_197_3J2( true) ;
         }
         else
         {
            wb_table1_197_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_197_3J2e( bool wbgen )
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

      protected void START3J2( )
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
            Form.Meta.addItem("description", "Configuración de repositorio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3J0( ) ;
      }

      protected void WS3J2( )
      {
         START3J2( ) ;
         EVT3J2( ) ;
      }

      protected void EVT3J2( )
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
                              E113J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E123J2 ();
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
                                    E133J2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E143J2 ();
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

      protected void WE3J2( )
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

      protected void PA3J2( )
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
               GX_FocusControl = edtavId_Internalname;
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
         if ( cmbavDefaultauthtypename.ItemCount > 0 )
         {
            AV32DefaultAuthTypeName = cmbavDefaultauthtypename.getValidValue(AV32DefaultAuthTypeName);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
            AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", cmbavDefaultauthtypename.ToJavascriptSource(), true);
         }
         AV33SessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV33SessionExpiresOnIPChange));
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         AV34AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV34AllowOauthAccess));
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         if ( cmbavUseridentification.ItemCount > 0 )
         {
            AV35UserIdentification = cmbavUseridentification.getValidValue(AV35UserIdentification);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
            AssignProp("", false, cmbavUseridentification_Internalname, "Values", cmbavUseridentification.ToJavascriptSource(), true);
         }
         if ( cmbavUseractivationmethod.ItemCount > 0 )
         {
            AV36UserActivationMethod = cmbavUseractivationmethod.getValidValue(AV36UserActivationMethod);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
            AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", cmbavUseractivationmethod.ToJavascriptSource(), true);
         }
         AV38UserEmailisUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV38UserEmailisUnique));
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         AV39RequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV39RequiredEmail));
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         AV40RequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV40RequiredPassword));
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         AV53RequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV53RequiredFirstName));
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         AV54RequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV54RequiredLastName));
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV41GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV41GenerateSessionStatistics);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         }
         if ( cmbavUserremembermetype.ItemCount > 0 )
         {
            AV42UserRememberMeType = cmbavUserremembermetype.getValidValue(AV42UserRememberMeType);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
            AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", cmbavUserremembermetype.ToJavascriptSource(), true);
         }
         AV49GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV49GiveAnonymousSession));
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         if ( cmbavDefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV51DefaultSecurityPolicyId = (long)(NumberUtil.Val( cmbavDefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0))), "."));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", cmbavDefaultsecuritypolicyid.ToJavascriptSource(), true);
         }
         if ( cmbavDefaultroleid.ItemCount > 0 )
         {
            AV52DefaultRoleId = (int)(NumberUtil.Val( cmbavDefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0))), "."));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
            AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", cmbavDefaultroleid.ToJavascriptSource(), true);
         }
         if ( cmbavLogoutbehaviour.ItemCount > 0 )
         {
            AV55LogoutBehaviour = cmbavLogoutbehaviour.getValidValue(AV55LogoutBehaviour);
            AssignAttri("", false, "AV55LogoutBehaviour", AV55LogoutBehaviour);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogoutbehaviour.CurrentValue = StringUtil.RTrim( AV55LogoutBehaviour);
            AssignProp("", false, cmbavLogoutbehaviour_Internalname, "Values", cmbavLogoutbehaviour.ToJavascriptSource(), true);
         }
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV56EnableTracing = (short)(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0))), "."));
            AssignAttri("", false, "AV56EnableTracing", StringUtil.LTrimStr( (decimal)(AV56EnableTracing), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3J2( ) ;
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
         edtavNamespace_Enabled = 0;
         AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
      }

      protected void RF3J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E123J2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E143J2 ();
            WB3J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3J2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV14Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10pId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECURITYADMINISTRATOREMAIL", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCANREGISTERUSERS", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavNamespace_Enabled = 0;
         AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27Id = 0;
               AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
            }
            else
            {
               AV27Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
               AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
            }
            AV28GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV28GUID", AV28GUID);
            AV29NameSpace = cgiGet( edtavNamespace_Internalname);
            AssignAttri("", false, "AV29NameSpace", AV29NameSpace);
            AV30Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV30Name", AV30Name);
            AV31Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV31Dsc", AV31Dsc);
            cmbavDefaultauthtypename.CurrentValue = cgiGet( cmbavDefaultauthtypename_Internalname);
            AV32DefaultAuthTypeName = cgiGet( cmbavDefaultauthtypename_Internalname);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
            AV33SessionExpiresOnIPChange = StringUtil.StrToBool( cgiGet( chkavSessionexpiresonipchange_Internalname));
            AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
            AV34AllowOauthAccess = StringUtil.StrToBool( cgiGet( chkavAllowoauthaccess_Internalname));
            AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
            cmbavUseridentification.CurrentValue = cgiGet( cmbavUseridentification_Internalname);
            AV35UserIdentification = cgiGet( cmbavUseridentification_Internalname);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
            cmbavUseractivationmethod.CurrentValue = cgiGet( cmbavUseractivationmethod_Internalname);
            AV36UserActivationMethod = cgiGet( cmbavUseractivationmethod_Internalname);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERAUTOMATICACTIVATIONTIMEOUT");
               GX_FocusControl = edtavUserautomaticactivationtimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37UserAutomaticActivationTimeout = 0;
               AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
            }
            else
            {
               AV37UserAutomaticActivationTimeout = (short)(context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ","));
               AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
            }
            AV38UserEmailisUnique = StringUtil.StrToBool( cgiGet( chkavUseremailisunique_Internalname));
            AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
            AV39RequiredEmail = StringUtil.StrToBool( cgiGet( chkavRequiredemail_Internalname));
            AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
            AV40RequiredPassword = StringUtil.StrToBool( cgiGet( chkavRequiredpassword_Internalname));
            AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
            AV53RequiredFirstName = StringUtil.StrToBool( cgiGet( chkavRequiredfirstname_Internalname));
            AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
            AV54RequiredLastName = StringUtil.StrToBool( cgiGet( chkavRequiredlastname_Internalname));
            AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
            cmbavGeneratesessionstatistics.CurrentValue = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AV41GenerateSessionStatistics = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERSESSIONCACHETIMEOUT");
               GX_FocusControl = edtavUsersessioncachetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50UserSessionCacheTimeout = 0;
               AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
            }
            else
            {
               AV50UserSessionCacheTimeout = (short)(context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ","));
               AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
            }
            cmbavUserremembermetype.CurrentValue = cgiGet( cmbavUserremembermetype_Internalname);
            AV42UserRememberMeType = cgiGet( cmbavUserremembermetype_Internalname);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERREMEMBERMETIMEOUT");
               GX_FocusControl = edtavUserremembermetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43UserRememberMeTimeOut = 0;
               AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
            }
            else
            {
               AV43UserRememberMeTimeOut = (short)(context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ","));
               AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERRECOVERYPASSWORDKEYTIMEOUT");
               GX_FocusControl = edtavUserrecoverypasswordkeytimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44UserRecoveryPasswordKeyTimeOut = 0;
               AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
            }
            else
            {
               AV44UserRecoveryPasswordKeyTimeOut = (short)(context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ","));
               AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMAMOUNTCHARACTERSINLOGIN");
               GX_FocusControl = edtavMinimumamountcharactersinlogin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45MinimumAmountCharactersInLogin = 0;
               AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
            }
            else
            {
               AV45MinimumAmountCharactersInLogin = (short)(context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ","));
               AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLOGINATTEMPTSTOLOCKUSER");
               GX_FocusControl = edtavLoginattemptstolockuser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV46LoginAttemptsToLockUser = 0;
               AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
            }
            else
            {
               AV46LoginAttemptsToLockUser = (short)(context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ","));
               AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGAMUNBLOCKUSERTIMEOUT");
               GX_FocusControl = edtavGamunblockusertimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47GAMUnblockUserTimeout = 0;
               AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
            }
            else
            {
               AV47GAMUnblockUserTimeout = (short)(context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ","));
               AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLOGINATTEMPTSTOLOCKSESSION");
               GX_FocusControl = edtavLoginattemptstolocksession_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV48LoginAttemptsToLockSession = 0;
               AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
            }
            else
            {
               AV48LoginAttemptsToLockSession = (short)(context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ","));
               AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
            }
            AV49GiveAnonymousSession = StringUtil.StrToBool( cgiGet( chkavGiveanonymoussession_Internalname));
            AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
            cmbavDefaultsecuritypolicyid.CurrentValue = cgiGet( cmbavDefaultsecuritypolicyid_Internalname);
            AV51DefaultSecurityPolicyId = (long)(NumberUtil.Val( cgiGet( cmbavDefaultsecuritypolicyid_Internalname), "."));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            cmbavDefaultroleid.CurrentValue = cgiGet( cmbavDefaultroleid_Internalname);
            AV52DefaultRoleId = (int)(NumberUtil.Val( cgiGet( cmbavDefaultroleid_Internalname), "."));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
            cmbavLogoutbehaviour.CurrentValue = cgiGet( cmbavLogoutbehaviour_Internalname);
            AV55LogoutBehaviour = cgiGet( cmbavLogoutbehaviour_Internalname);
            AssignAttri("", false, "AV55LogoutBehaviour", AV55LogoutBehaviour);
            cmbavEnabletracing.CurrentValue = cgiGet( cmbavEnabletracing_Internalname);
            AV56EnableTracing = (short)(NumberUtil.Val( cgiGet( cmbavEnabletracing_Internalname), "."));
            AssignAttri("", false, "AV56EnableTracing", StringUtil.LTrimStr( (decimal)(AV56EnableTracing), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"RepositoryConfiguration");
            AV27Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
            AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
            forbiddenHiddens.Add("Id", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("k2bfsg\\repositoryconfiguration:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
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
         AV15AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV14Language, out  AV13Errors);
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV15AuthenticationTypes.Count )
         {
            AV5AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV15AuthenticationTypes.Item(AV59GXV1));
            cmbavDefaultauthtypename.addItem(AV5AuthenticationType.gxTpr_Name, AV5AuthenticationType.gxTpr_Description, 0);
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         AV7SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV16FilterSecPol, out  AV13Errors);
         AV60GXV2 = 1;
         while ( AV60GXV2 <= AV7SecurityPolicies.Count )
         {
            AV8SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV7SecurityPolicies.Item(AV60GXV2));
            cmbavDefaultsecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8SecurityPolicy.gxTpr_Id), 12, 0)), AV8SecurityPolicy.gxTpr_Name, 0);
            AV60GXV2 = (int)(AV60GXV2+1);
         }
         AV6Roles = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV17FilterRole, out  AV13Errors);
         AV61GXV3 = 1;
         while ( AV61GXV3 <= AV6Roles.Count )
         {
            AV9Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV6Roles.Item(AV61GXV3));
            cmbavDefaultroleid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Role.gxTpr_Id), 9, 0)), AV9Role.gxTpr_Name, 0);
            AV61GXV3 = (int)(AV61GXV3+1);
         }
         if ( (0==AV10pId) )
         {
            AV27Id = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getid();
            AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
         }
         else
         {
            AV27Id = AV10pId;
            AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
         }
         AV11Repository.load( (int)(AV27Id));
         AV28GUID = AV11Repository.gxTpr_Guid;
         AssignAttri("", false, "AV28GUID", AV28GUID);
         AV29NameSpace = AV11Repository.gxTpr_Namespace;
         AssignAttri("", false, "AV29NameSpace", AV29NameSpace);
         AV30Name = AV11Repository.gxTpr_Name;
         AssignAttri("", false, "AV30Name", AV30Name);
         AV31Dsc = AV11Repository.gxTpr_Description;
         AssignAttri("", false, "AV31Dsc", AV31Dsc);
         AV32DefaultAuthTypeName = AV11Repository.gxTpr_Defaultauthenticationtypename;
         AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         AV35UserIdentification = AV11Repository.gxTpr_Useridentification;
         AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         AV41GenerateSessionStatistics = AV11Repository.gxTpr_Generatesessionstatistics;
         AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         AV36UserActivationMethod = AV11Repository.gxTpr_Useractivationmethod;
         AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         AV37UserAutomaticActivationTimeout = (short)(AV11Repository.gxTpr_Userautomaticactivationtimeout);
         AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
         AV42UserRememberMeType = AV11Repository.gxTpr_Userremembermetype;
         AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         AV43UserRememberMeTimeOut = AV11Repository.gxTpr_Userremembermetimeout;
         AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
         AV44UserRecoveryPasswordKeyTimeOut = (short)(AV11Repository.gxTpr_Userrecoverypasswordkeytimeout);
         AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
         AV45MinimumAmountCharactersInLogin = AV11Repository.gxTpr_Minimumamountcharactersinlogin;
         AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
         AV46LoginAttemptsToLockUser = AV11Repository.gxTpr_Loginattemptstolockuser;
         AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
         AV47GAMUnblockUserTimeout = (short)(AV11Repository.gxTpr_Gamunblockusertimeout);
         AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
         AV48LoginAttemptsToLockSession = AV11Repository.gxTpr_Loginattemptstolocksession;
         AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
         AV50UserSessionCacheTimeout = (short)(AV11Repository.gxTpr_Usersessioncachetimeout);
         AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
         AV18SecurityAdministratorEmail = AV11Repository.gxTpr_Securityadministratoremail;
         AssignAttri("", false, "AV18SecurityAdministratorEmail", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         AV49GiveAnonymousSession = AV11Repository.gxTpr_Giveanonymoussession;
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         AV19CanRegisterUsers = AV11Repository.gxTpr_Canregisterusers;
         AssignAttri("", false, "AV19CanRegisterUsers", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
         AV38UserEmailisUnique = AV11Repository.gxTpr_Useremailisunique;
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         AV51DefaultSecurityPolicyId = AV11Repository.gxTpr_Defaultsecuritypolicyid;
         AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         AV52DefaultRoleId = (int)(AV11Repository.gxTpr_Defaultroleid);
         AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         AV34AllowOauthAccess = AV11Repository.gxTpr_Allowoauthaccess;
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         AV33SessionExpiresOnIPChange = AV11Repository.gxTpr_Sessionexpiresonipchange;
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         AV40RequiredPassword = AV11Repository.gxTpr_Requiredpassword;
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         AV39RequiredEmail = AV11Repository.gxTpr_Requiredemail;
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         AV53RequiredFirstName = AV11Repository.gxTpr_Requiredfirstname;
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         AV54RequiredLastName = AV11Repository.gxTpr_Requiredlastname;
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         AV56EnableTracing = AV11Repository.gxTpr_Enabletracing;
         AssignAttri("", false, "AV56EnableTracing", StringUtil.LTrimStr( (decimal)(AV56EnableTracing), 4, 0));
         AV55LogoutBehaviour = AV11Repository.gxTpr_Gamremotelogoutbehavior;
         AssignAttri("", false, "AV55LogoutBehaviour", AV55LogoutBehaviour);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E113J2 ();
         if (returnInSub) return;
      }

      protected void E113J2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E123J2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
         AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", cmbavDefaultauthtypename.ToJavascriptSource(), true);
         cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", cmbavDefaultsecuritypolicyid.ToJavascriptSource(), true);
         cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
         AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", cmbavDefaultroleid.ToJavascriptSource(), true);
         cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
         AssignProp("", false, cmbavUseridentification_Internalname, "Values", cmbavUseridentification.ToJavascriptSource(), true);
         cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
         AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
         AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", cmbavUseractivationmethod.ToJavascriptSource(), true);
         cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
         AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", cmbavUserremembermetype.ToJavascriptSource(), true);
         cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0));
         AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
         cmbavLogoutbehaviour.CurrentValue = StringUtil.RTrim( AV55LogoutBehaviour);
         AssignProp("", false, cmbavLogoutbehaviour_Internalname, "Values", cmbavLogoutbehaviour.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV11Repository.load( (int)(AV27Id));
         AV11Repository.gxTpr_Name = AV30Name;
         AV11Repository.gxTpr_Description = AV31Dsc;
         AV11Repository.gxTpr_Defaultauthenticationtypename = AV32DefaultAuthTypeName;
         AV11Repository.gxTpr_Useridentification = AV35UserIdentification;
         AV11Repository.gxTpr_Generatesessionstatistics = AV41GenerateSessionStatistics;
         AV11Repository.gxTpr_Useractivationmethod = AV36UserActivationMethod;
         AV11Repository.gxTpr_Userautomaticactivationtimeout = AV37UserAutomaticActivationTimeout;
         AV11Repository.gxTpr_Gamunblockusertimeout = AV47GAMUnblockUserTimeout;
         AV11Repository.gxTpr_Userremembermetype = AV42UserRememberMeType;
         AV11Repository.gxTpr_Userremembermetimeout = AV43UserRememberMeTimeOut;
         AV11Repository.gxTpr_Userrecoverypasswordkeytimeout = AV44UserRecoveryPasswordKeyTimeOut;
         AV11Repository.gxTpr_Minimumamountcharactersinlogin = AV45MinimumAmountCharactersInLogin;
         AV11Repository.gxTpr_Loginattemptstolockuser = AV46LoginAttemptsToLockUser;
         AV11Repository.gxTpr_Loginattemptstolocksession = AV48LoginAttemptsToLockSession;
         AV11Repository.gxTpr_Usersessioncachetimeout = AV50UserSessionCacheTimeout;
         AV11Repository.gxTpr_Securityadministratoremail = AV18SecurityAdministratorEmail;
         AV11Repository.gxTpr_Giveanonymoussession = AV49GiveAnonymousSession;
         AV11Repository.gxTpr_Canregisterusers = AV19CanRegisterUsers;
         AV11Repository.gxTpr_Useremailisunique = AV38UserEmailisUnique;
         AV11Repository.gxTpr_Defaultsecuritypolicyid = (int)(AV51DefaultSecurityPolicyId);
         AV11Repository.gxTpr_Defaultroleid = AV52DefaultRoleId;
         AV11Repository.gxTpr_Allowoauthaccess = AV34AllowOauthAccess;
         AV11Repository.gxTpr_Sessionexpiresonipchange = AV33SessionExpiresOnIPChange;
         AV11Repository.gxTpr_Requiredpassword = AV40RequiredPassword;
         AV11Repository.gxTpr_Requiredemail = AV39RequiredEmail;
         AV11Repository.gxTpr_Requiredfirstname = AV53RequiredFirstName;
         AV11Repository.gxTpr_Requiredlastname = AV54RequiredLastName;
         AV11Repository.gxTpr_Enabletracing = AV56EnableTracing;
         AV11Repository.gxTpr_Gamremotelogoutbehavior = AV55LogoutBehaviour;
         AV11Repository.save();
         if ( AV11Repository.success() )
         {
            context.CommitDataStores("k2bfsg.repositoryconfiguration",pr_default);
            GX_msglist.addItem("Configuración de repositorio actualizada correctamente");
         }
         else
         {
            AV13Errors = AV11Repository.geterrors();
            AV62GXV4 = 1;
            while ( AV62GXV4 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV62GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV62GXV4 = (int)(AV62GXV4+1);
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E133J2 ();
         if (returnInSub) return;
      }

      protected void E133J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.secbackendhome.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E143J2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_197_3J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", "Confirmar", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RepositoryConfiguration.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e153j1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_197_3J2e( true) ;
         }
         else
         {
            wb_table1_197_3J2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10pId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10pId", StringUtil.LTrimStr( (decimal)(AV10pId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10pId), "ZZZ9"), context));
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
         PA3J2( ) ;
         WS3J2( ) ;
         WE3J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188381327", true, true);
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
         context.AddJavascriptSource("k2bfsg/repositoryconfiguration.js", "?2024188381330", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDefaultauthtypename.Name = "vDEFAULTAUTHTYPENAME";
         cmbavDefaultauthtypename.WebTags = "";
         if ( cmbavDefaultauthtypename.ItemCount > 0 )
         {
            AV32DefaultAuthTypeName = cmbavDefaultauthtypename.getValidValue(AV32DefaultAuthTypeName);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         }
         chkavSessionexpiresonipchange.Name = "vSESSIONEXPIRESONIPCHANGE";
         chkavSessionexpiresonipchange.WebTags = "";
         chkavSessionexpiresonipchange.Caption = "";
         AssignProp("", false, chkavSessionexpiresonipchange_Internalname, "TitleCaption", chkavSessionexpiresonipchange.Caption, true);
         chkavSessionexpiresonipchange.CheckedValue = "false";
         AV33SessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV33SessionExpiresOnIPChange));
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         chkavAllowoauthaccess.Name = "vALLOWOAUTHACCESS";
         chkavAllowoauthaccess.WebTags = "";
         chkavAllowoauthaccess.Caption = "";
         AssignProp("", false, chkavAllowoauthaccess_Internalname, "TitleCaption", chkavAllowoauthaccess.Caption, true);
         chkavAllowoauthaccess.CheckedValue = "false";
         AV34AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV34AllowOauthAccess));
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         cmbavUseridentification.Name = "vUSERIDENTIFICATION";
         cmbavUseridentification.WebTags = "";
         cmbavUseridentification.addItem("name", "Name", 0);
         cmbavUseridentification.addItem("email", "EMail", 0);
         cmbavUseridentification.addItem("namema", "Name and Email", 0);
         if ( cmbavUseridentification.ItemCount > 0 )
         {
            AV35UserIdentification = cmbavUseridentification.getValidValue(AV35UserIdentification);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         }
         cmbavUseractivationmethod.Name = "vUSERACTIVATIONMETHOD";
         cmbavUseractivationmethod.WebTags = "";
         cmbavUseractivationmethod.addItem("A", "Automatic", 0);
         cmbavUseractivationmethod.addItem("U", "User", 0);
         cmbavUseractivationmethod.addItem("D", "Administrator", 0);
         if ( cmbavUseractivationmethod.ItemCount > 0 )
         {
            AV36UserActivationMethod = cmbavUseractivationmethod.getValidValue(AV36UserActivationMethod);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         }
         chkavUseremailisunique.Name = "vUSEREMAILISUNIQUE";
         chkavUseremailisunique.WebTags = "";
         chkavUseremailisunique.Caption = "";
         AssignProp("", false, chkavUseremailisunique_Internalname, "TitleCaption", chkavUseremailisunique.Caption, true);
         chkavUseremailisunique.CheckedValue = "false";
         AV38UserEmailisUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV38UserEmailisUnique));
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         chkavRequiredemail.Name = "vREQUIREDEMAIL";
         chkavRequiredemail.WebTags = "";
         chkavRequiredemail.Caption = "";
         AssignProp("", false, chkavRequiredemail_Internalname, "TitleCaption", chkavRequiredemail.Caption, true);
         chkavRequiredemail.CheckedValue = "false";
         AV39RequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV39RequiredEmail));
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         chkavRequiredpassword.Name = "vREQUIREDPASSWORD";
         chkavRequiredpassword.WebTags = "";
         chkavRequiredpassword.Caption = "";
         AssignProp("", false, chkavRequiredpassword_Internalname, "TitleCaption", chkavRequiredpassword.Caption, true);
         chkavRequiredpassword.CheckedValue = "false";
         AV40RequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV40RequiredPassword));
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         chkavRequiredfirstname.Name = "vREQUIREDFIRSTNAME";
         chkavRequiredfirstname.WebTags = "";
         chkavRequiredfirstname.Caption = "";
         AssignProp("", false, chkavRequiredfirstname_Internalname, "TitleCaption", chkavRequiredfirstname.Caption, true);
         chkavRequiredfirstname.CheckedValue = "false";
         AV53RequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV53RequiredFirstName));
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         chkavRequiredlastname.Name = "vREQUIREDLASTNAME";
         chkavRequiredlastname.WebTags = "";
         chkavRequiredlastname.Caption = "";
         AssignProp("", false, chkavRequiredlastname_Internalname, "TitleCaption", chkavRequiredlastname.Caption, true);
         chkavRequiredlastname.CheckedValue = "false";
         AV54RequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV54RequiredLastName));
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         cmbavGeneratesessionstatistics.Name = "vGENERATESESSIONSTATISTICS";
         cmbavGeneratesessionstatistics.WebTags = "";
         cmbavGeneratesessionstatistics.addItem("None", "None", 0);
         cmbavGeneratesessionstatistics.addItem("Minimum", "Minimum (Only authenticated users)", 0);
         cmbavGeneratesessionstatistics.addItem("Detail", "Detail (Authenticated and anonymous users)", 0);
         cmbavGeneratesessionstatistics.addItem("Full", "Full log (Authenticated and anonymous users)", 0);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV41GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV41GenerateSessionStatistics);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         }
         cmbavUserremembermetype.Name = "vUSERREMEMBERMETYPE";
         cmbavUserremembermetype.WebTags = "";
         cmbavUserremembermetype.addItem("None", "None", 0);
         cmbavUserremembermetype.addItem("Login", "Login", 0);
         cmbavUserremembermetype.addItem("Auth", "Authentication", 0);
         cmbavUserremembermetype.addItem("Both", "Both", 0);
         if ( cmbavUserremembermetype.ItemCount > 0 )
         {
            AV42UserRememberMeType = cmbavUserremembermetype.getValidValue(AV42UserRememberMeType);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         }
         chkavGiveanonymoussession.Name = "vGIVEANONYMOUSSESSION";
         chkavGiveanonymoussession.WebTags = "";
         chkavGiveanonymoussession.Caption = "";
         AssignProp("", false, chkavGiveanonymoussession_Internalname, "TitleCaption", chkavGiveanonymoussession.Caption, true);
         chkavGiveanonymoussession.CheckedValue = "false";
         AV49GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV49GiveAnonymousSession));
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         cmbavDefaultsecuritypolicyid.Name = "vDEFAULTSECURITYPOLICYID";
         cmbavDefaultsecuritypolicyid.WebTags = "";
         if ( cmbavDefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV51DefaultSecurityPolicyId = (long)(NumberUtil.Val( cmbavDefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0))), "."));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         }
         cmbavDefaultroleid.Name = "vDEFAULTROLEID";
         cmbavDefaultroleid.WebTags = "";
         if ( cmbavDefaultroleid.ItemCount > 0 )
         {
            AV52DefaultRoleId = (int)(NumberUtil.Val( cmbavDefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0))), "."));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         }
         cmbavLogoutbehaviour.Name = "vLOGOUTBEHAVIOUR";
         cmbavLogoutbehaviour.WebTags = "";
         cmbavLogoutbehaviour.addItem("clionl", "Client only", 0);
         cmbavLogoutbehaviour.addItem("cliip", "Identity Provider and Client", 0);
         cmbavLogoutbehaviour.addItem("all", "Identity Provider and all Clients", 0);
         if ( cmbavLogoutbehaviour.ItemCount > 0 )
         {
            AV55LogoutBehaviour = cmbavLogoutbehaviour.getValidValue(AV55LogoutBehaviour);
            AssignAttri("", false, "AV55LogoutBehaviour", AV55LogoutBehaviour);
         }
         cmbavEnabletracing.Name = "vENABLETRACING";
         cmbavEnabletracing.WebTags = "";
         cmbavEnabletracing.addItem("0", "0 - Off", 0);
         cmbavEnabletracing.addItem("1", "1 - Debug", 0);
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV56EnableTracing = (short)(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV56EnableTracing), 4, 0))), "."));
            AssignAttri("", false, "AV56EnableTracing", StringUtil.LTrimStr( (decimal)(AV56EnableTracing), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavId_Internalname = "vID";
         divTable_container_id_Internalname = "TABLE_CONTAINER_ID";
         edtavGuid_Internalname = "vGUID";
         divTable_container_guid_Internalname = "TABLE_CONTAINER_GUID";
         edtavNamespace_Internalname = "vNAMESPACE";
         divTable_container_namespace_Internalname = "TABLE_CONTAINER_NAMESPACE";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavDsc_Internalname = "vDSC";
         divTable_container_dsc_Internalname = "TABLE_CONTAINER_DSC";
         cmbavDefaultauthtypename_Internalname = "vDEFAULTAUTHTYPENAME";
         divTable_container_defaultauthtypename_Internalname = "TABLE_CONTAINER_DEFAULTAUTHTYPENAME";
         chkavSessionexpiresonipchange_Internalname = "vSESSIONEXPIRESONIPCHANGE";
         divTable_container_sessionexpiresonipchange_Internalname = "TABLE_CONTAINER_SESSIONEXPIRESONIPCHANGE";
         chkavAllowoauthaccess_Internalname = "vALLOWOAUTHACCESS";
         divTable_container_allowoauthaccess_Internalname = "TABLE_CONTAINER_ALLOWOAUTHACCESS";
         cmbavUseridentification_Internalname = "vUSERIDENTIFICATION";
         divTable_container_useridentification_Internalname = "TABLE_CONTAINER_USERIDENTIFICATION";
         cmbavUseractivationmethod_Internalname = "vUSERACTIVATIONMETHOD";
         divTable_container_useractivationmethod_Internalname = "TABLE_CONTAINER_USERACTIVATIONMETHOD";
         edtavUserautomaticactivationtimeout_Internalname = "vUSERAUTOMATICACTIVATIONTIMEOUT";
         divTable_container_userautomaticactivationtimeout_Internalname = "TABLE_CONTAINER_USERAUTOMATICACTIVATIONTIMEOUT";
         chkavUseremailisunique_Internalname = "vUSEREMAILISUNIQUE";
         divTable_container_useremailisunique_Internalname = "TABLE_CONTAINER_USEREMAILISUNIQUE";
         chkavRequiredemail_Internalname = "vREQUIREDEMAIL";
         divTable_container_requiredemail_Internalname = "TABLE_CONTAINER_REQUIREDEMAIL";
         chkavRequiredpassword_Internalname = "vREQUIREDPASSWORD";
         divTable_container_requiredpassword_Internalname = "TABLE_CONTAINER_REQUIREDPASSWORD";
         chkavRequiredfirstname_Internalname = "vREQUIREDFIRSTNAME";
         divTable_container_requiredfirstname_Internalname = "TABLE_CONTAINER_REQUIREDFIRSTNAME";
         chkavRequiredlastname_Internalname = "vREQUIREDLASTNAME";
         divTable_container_requiredlastname_Internalname = "TABLE_CONTAINER_REQUIREDLASTNAME";
         divMaingroupresponsivetable_userinformation_Internalname = "MAINGROUPRESPONSIVETABLE_USERINFORMATION";
         grpUserinformation_Internalname = "USERINFORMATION";
         cmbavGeneratesessionstatistics_Internalname = "vGENERATESESSIONSTATISTICS";
         divTable_container_generatesessionstatistics_Internalname = "TABLE_CONTAINER_GENERATESESSIONSTATISTICS";
         edtavUsersessioncachetimeout_Internalname = "vUSERSESSIONCACHETIMEOUT";
         divTable_container_usersessioncachetimeout_Internalname = "TABLE_CONTAINER_USERSESSIONCACHETIMEOUT";
         cmbavUserremembermetype_Internalname = "vUSERREMEMBERMETYPE";
         divTable_container_userremembermetype_Internalname = "TABLE_CONTAINER_USERREMEMBERMETYPE";
         edtavUserremembermetimeout_Internalname = "vUSERREMEMBERMETIMEOUT";
         divTable_container_userremembermetimeout_Internalname = "TABLE_CONTAINER_USERREMEMBERMETIMEOUT";
         edtavUserrecoverypasswordkeytimeout_Internalname = "vUSERRECOVERYPASSWORDKEYTIMEOUT";
         divTable_container_userrecoverypasswordkeytimeout_Internalname = "TABLE_CONTAINER_USERRECOVERYPASSWORDKEYTIMEOUT";
         edtavMinimumamountcharactersinlogin_Internalname = "vMINIMUMAMOUNTCHARACTERSINLOGIN";
         divTable_container_minimumamountcharactersinlogin_Internalname = "TABLE_CONTAINER_MINIMUMAMOUNTCHARACTERSINLOGIN";
         edtavLoginattemptstolockuser_Internalname = "vLOGINATTEMPTSTOLOCKUSER";
         divTable_container_loginattemptstolockuser_Internalname = "TABLE_CONTAINER_LOGINATTEMPTSTOLOCKUSER";
         edtavGamunblockusertimeout_Internalname = "vGAMUNBLOCKUSERTIMEOUT";
         divTable_container_gamunblockusertimeout_Internalname = "TABLE_CONTAINER_GAMUNBLOCKUSERTIMEOUT";
         edtavLoginattemptstolocksession_Internalname = "vLOGINATTEMPTSTOLOCKSESSION";
         divTable_container_loginattemptstolocksession_Internalname = "TABLE_CONTAINER_LOGINATTEMPTSTOLOCKSESSION";
         chkavGiveanonymoussession_Internalname = "vGIVEANONYMOUSSESSION";
         divTable_container_giveanonymoussession_Internalname = "TABLE_CONTAINER_GIVEANONYMOUSSESSION";
         divMaingroupresponsivetable_session_Internalname = "MAINGROUPRESPONSIVETABLE_SESSION";
         grpSession_Internalname = "SESSION";
         cmbavDefaultsecuritypolicyid_Internalname = "vDEFAULTSECURITYPOLICYID";
         divTable_container_defaultsecuritypolicyid_Internalname = "TABLE_CONTAINER_DEFAULTSECURITYPOLICYID";
         cmbavDefaultroleid_Internalname = "vDEFAULTROLEID";
         divTable_container_defaultroleid_Internalname = "TABLE_CONTAINER_DEFAULTROLEID";
         cmbavLogoutbehaviour_Internalname = "vLOGOUTBEHAVIOUR";
         divTable_container_logoutbehaviour_Internalname = "TABLE_CONTAINER_LOGOUTBEHAVIOUR";
         cmbavEnabletracing_Internalname = "vENABLETRACING";
         divTable_container_enabletracing_Internalname = "TABLE_CONTAINER_ENABLETRACING";
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
         chkavGiveanonymoussession.Caption = "Otorgar sesiones web anónimas";
         chkavRequiredlastname.Caption = "Apellido requerido";
         chkavRequiredfirstname.Caption = "Nombre requerido";
         chkavRequiredpassword.Caption = "Requerir contraseña";
         chkavRequiredemail.Caption = "Requerir correo electrónico";
         chkavUseremailisunique.Caption = "E-mail de usuario es único";
         chkavAllowoauthaccess.Caption = "Permitir acceso OAuth";
         chkavSessionexpiresonipchange.Caption = "Expirar sesión de GAM cuando hay cambios de IP";
         cmbavEnabletracing_Jsonclick = "";
         cmbavEnabletracing.Enabled = 1;
         cmbavLogoutbehaviour_Jsonclick = "";
         cmbavLogoutbehaviour.Enabled = 1;
         cmbavDefaultroleid_Jsonclick = "";
         cmbavDefaultroleid.Enabled = 1;
         cmbavDefaultsecuritypolicyid_Jsonclick = "";
         cmbavDefaultsecuritypolicyid.Enabled = 1;
         chkavGiveanonymoussession.Enabled = 1;
         edtavLoginattemptstolocksession_Jsonclick = "";
         edtavLoginattemptstolocksession_Enabled = 1;
         edtavGamunblockusertimeout_Jsonclick = "";
         edtavGamunblockusertimeout_Enabled = 1;
         edtavLoginattemptstolockuser_Jsonclick = "";
         edtavLoginattemptstolockuser_Enabled = 1;
         edtavMinimumamountcharactersinlogin_Jsonclick = "";
         edtavMinimumamountcharactersinlogin_Enabled = 1;
         edtavUserrecoverypasswordkeytimeout_Jsonclick = "";
         edtavUserrecoverypasswordkeytimeout_Enabled = 1;
         edtavUserremembermetimeout_Jsonclick = "";
         edtavUserremembermetimeout_Enabled = 1;
         cmbavUserremembermetype_Jsonclick = "";
         cmbavUserremembermetype.Enabled = 1;
         edtavUsersessioncachetimeout_Jsonclick = "";
         edtavUsersessioncachetimeout_Enabled = 1;
         cmbavGeneratesessionstatistics_Jsonclick = "";
         cmbavGeneratesessionstatistics.Enabled = 1;
         chkavRequiredlastname.Enabled = 1;
         chkavRequiredfirstname.Enabled = 1;
         chkavRequiredpassword.Enabled = 1;
         chkavRequiredemail.Enabled = 1;
         chkavUseremailisunique.Enabled = 1;
         edtavUserautomaticactivationtimeout_Jsonclick = "";
         edtavUserautomaticactivationtimeout_Enabled = 1;
         cmbavUseractivationmethod_Jsonclick = "";
         cmbavUseractivationmethod.Enabled = 1;
         cmbavUseridentification_Jsonclick = "";
         cmbavUseridentification.Enabled = 1;
         chkavAllowoauthaccess.Enabled = 1;
         chkavSessionexpiresonipchange.Enabled = 1;
         cmbavDefaultauthtypename_Jsonclick = "";
         cmbavDefaultauthtypename.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavNamespace_Jsonclick = "";
         edtavNamespace_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Configuración de repositorio";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'cmbavDefaultauthtypename'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'cmbavDefaultsecuritypolicyid'},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavDefaultroleid'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'AV14Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'AV10pId',fld:'vPID',pic:'ZZZ9',hsh:true},{av:'AV27Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDefaultauthtypename'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'cmbavDefaultsecuritypolicyid'},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavDefaultroleid'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'AV27Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV28GUID',fld:'vGUID',pic:''},{av:'AV29NameSpace',fld:'vNAMESPACE',pic:''},{av:'AV30Name',fld:'vNAME',pic:''},{av:'AV31Dsc',fld:'vDSC',pic:''},{av:'cmbavUseridentification'},{av:'AV35UserIdentification',fld:'vUSERIDENTIFICATION',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV41GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'cmbavUseractivationmethod'},{av:'AV36UserActivationMethod',fld:'vUSERACTIVATIONMETHOD',pic:''},{av:'AV37UserAutomaticActivationTimeout',fld:'vUSERAUTOMATICACTIVATIONTIMEOUT',pic:'ZZZ9'},{av:'cmbavUserremembermetype'},{av:'AV42UserRememberMeType',fld:'vUSERREMEMBERMETYPE',pic:''},{av:'AV43UserRememberMeTimeOut',fld:'vUSERREMEMBERMETIMEOUT',pic:'ZZZ9'},{av:'AV44UserRecoveryPasswordKeyTimeOut',fld:'vUSERRECOVERYPASSWORDKEYTIMEOUT',pic:'ZZZ9'},{av:'AV45MinimumAmountCharactersInLogin',fld:'vMINIMUMAMOUNTCHARACTERSINLOGIN',pic:'ZZZ9'},{av:'AV46LoginAttemptsToLockUser',fld:'vLOGINATTEMPTSTOLOCKUSER',pic:'ZZZ9'},{av:'AV47GAMUnblockUserTimeout',fld:'vGAMUNBLOCKUSERTIMEOUT',pic:'ZZZ9'},{av:'AV48LoginAttemptsToLockSession',fld:'vLOGINATTEMPTSTOLOCKSESSION',pic:'ZZZ9'},{av:'AV50UserSessionCacheTimeout',fld:'vUSERSESSIONCACHETIMEOUT',pic:'ZZZ9'},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'cmbavEnabletracing'},{av:'AV56EnableTracing',fld:'vENABLETRACING',pic:'ZZZ9'},{av:'cmbavLogoutbehaviour'},{av:'AV55LogoutBehaviour',fld:'vLOGOUTBEHAVIOUR',pic:''},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E133J2',iparms:[{av:'AV27Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV30Name',fld:'vNAME',pic:''},{av:'AV31Dsc',fld:'vDSC',pic:''},{av:'cmbavDefaultauthtypename'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'cmbavUseridentification'},{av:'AV35UserIdentification',fld:'vUSERIDENTIFICATION',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV41GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'cmbavUseractivationmethod'},{av:'AV36UserActivationMethod',fld:'vUSERACTIVATIONMETHOD',pic:''},{av:'AV37UserAutomaticActivationTimeout',fld:'vUSERAUTOMATICACTIVATIONTIMEOUT',pic:'ZZZ9'},{av:'AV47GAMUnblockUserTimeout',fld:'vGAMUNBLOCKUSERTIMEOUT',pic:'ZZZ9'},{av:'cmbavUserremembermetype'},{av:'AV42UserRememberMeType',fld:'vUSERREMEMBERMETYPE',pic:''},{av:'AV43UserRememberMeTimeOut',fld:'vUSERREMEMBERMETIMEOUT',pic:'ZZZ9'},{av:'AV44UserRecoveryPasswordKeyTimeOut',fld:'vUSERRECOVERYPASSWORDKEYTIMEOUT',pic:'ZZZ9'},{av:'AV45MinimumAmountCharactersInLogin',fld:'vMINIMUMAMOUNTCHARACTERSINLOGIN',pic:'ZZZ9'},{av:'AV46LoginAttemptsToLockUser',fld:'vLOGINATTEMPTSTOLOCKUSER',pic:'ZZZ9'},{av:'AV48LoginAttemptsToLockSession',fld:'vLOGINATTEMPTSTOLOCKSESSION',pic:'ZZZ9'},{av:'AV50UserSessionCacheTimeout',fld:'vUSERSESSIONCACHETIMEOUT',pic:'ZZZ9'},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'cmbavDefaultsecuritypolicyid'},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavDefaultroleid'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'cmbavEnabletracing'},{av:'AV56EnableTracing',fld:'vENABLETRACING',pic:'ZZZ9'},{av:'cmbavLogoutbehaviour'},{av:'AV55LogoutBehaviour',fld:'vLOGOUTBEHAVIOUR',pic:''},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E153J1',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("'E_CANCEL'",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_USERIDENTIFICATION","{handler:'Validv_Useridentification',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_USERIDENTIFICATION",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_USERACTIVATIONMETHOD","{handler:'Validv_Useractivationmethod',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_USERACTIVATIONMETHOD",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS","{handler:'Validv_Generatesessionstatistics',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_USERREMEMBERMETYPE","{handler:'Validv_Userremembermetype',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_USERREMEMBERMETYPE",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_LOGOUTBEHAVIOUR","{handler:'Validv_Logoutbehaviour',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_LOGOUTBEHAVIOUR",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_ENABLETRACING","{handler:'Validv_Enabletracing',iparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_ENABLETRACING",",oparms:[{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV14Language = "";
         AV18SecurityAdministratorEmail = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV28GUID = "";
         AV29NameSpace = "";
         AV30Name = "";
         AV31Dsc = "";
         AV32DefaultAuthTypeName = "";
         AV35UserIdentification = "";
         AV36UserActivationMethod = "";
         AV41GenerateSessionStatistics = "";
         AV42UserRememberMeType = "";
         AV55LogoutBehaviour = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV15AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV7SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV16FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV8SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV17FilterRole = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV9Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV11Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavNamespace_Enabled = 0;
      }

      private short AV10pId ;
      private short wcpOAV10pId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV37UserAutomaticActivationTimeout ;
      private short AV50UserSessionCacheTimeout ;
      private short AV43UserRememberMeTimeOut ;
      private short AV44UserRecoveryPasswordKeyTimeOut ;
      private short AV45MinimumAmountCharactersInLogin ;
      private short AV46LoginAttemptsToLockUser ;
      private short AV47GAMUnblockUserTimeout ;
      private short AV48LoginAttemptsToLockSession ;
      private short AV56EnableTracing ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavNamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavUserautomaticactivationtimeout_Enabled ;
      private int edtavUsersessioncachetimeout_Enabled ;
      private int edtavUserremembermetimeout_Enabled ;
      private int edtavUserrecoverypasswordkeytimeout_Enabled ;
      private int edtavMinimumamountcharactersinlogin_Enabled ;
      private int edtavLoginattemptstolockuser_Enabled ;
      private int edtavGamunblockusertimeout_Enabled ;
      private int edtavLoginattemptstolocksession_Enabled ;
      private int AV52DefaultRoleId ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV61GXV3 ;
      private int AV62GXV4 ;
      private int idxLst ;
      private long AV27Id ;
      private long AV51DefaultSecurityPolicyId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV14Language ;
      private string GXKey ;
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
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_id_Internalname ;
      private string edtavId_Internalname ;
      private string TempTags ;
      private string edtavId_Jsonclick ;
      private string divTable_container_guid_Internalname ;
      private string edtavGuid_Internalname ;
      private string AV28GUID ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_namespace_Internalname ;
      private string edtavNamespace_Internalname ;
      private string AV29NameSpace ;
      private string edtavNamespace_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV30Name ;
      private string edtavName_Jsonclick ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV31Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_defaultauthtypename_Internalname ;
      private string cmbavDefaultauthtypename_Internalname ;
      private string AV32DefaultAuthTypeName ;
      private string cmbavDefaultauthtypename_Jsonclick ;
      private string divTable_container_sessionexpiresonipchange_Internalname ;
      private string chkavSessionexpiresonipchange_Internalname ;
      private string divTable_container_allowoauthaccess_Internalname ;
      private string chkavAllowoauthaccess_Internalname ;
      private string grpUserinformation_Internalname ;
      private string divMaingroupresponsivetable_userinformation_Internalname ;
      private string divTable_container_useridentification_Internalname ;
      private string cmbavUseridentification_Internalname ;
      private string AV35UserIdentification ;
      private string cmbavUseridentification_Jsonclick ;
      private string divTable_container_useractivationmethod_Internalname ;
      private string cmbavUseractivationmethod_Internalname ;
      private string AV36UserActivationMethod ;
      private string cmbavUseractivationmethod_Jsonclick ;
      private string divTable_container_userautomaticactivationtimeout_Internalname ;
      private string edtavUserautomaticactivationtimeout_Internalname ;
      private string edtavUserautomaticactivationtimeout_Jsonclick ;
      private string divTable_container_useremailisunique_Internalname ;
      private string chkavUseremailisunique_Internalname ;
      private string divTable_container_requiredemail_Internalname ;
      private string chkavRequiredemail_Internalname ;
      private string divTable_container_requiredpassword_Internalname ;
      private string chkavRequiredpassword_Internalname ;
      private string divTable_container_requiredfirstname_Internalname ;
      private string chkavRequiredfirstname_Internalname ;
      private string divTable_container_requiredlastname_Internalname ;
      private string chkavRequiredlastname_Internalname ;
      private string grpSession_Internalname ;
      private string divMaingroupresponsivetable_session_Internalname ;
      private string divTable_container_generatesessionstatistics_Internalname ;
      private string cmbavGeneratesessionstatistics_Internalname ;
      private string AV41GenerateSessionStatistics ;
      private string cmbavGeneratesessionstatistics_Jsonclick ;
      private string divTable_container_usersessioncachetimeout_Internalname ;
      private string edtavUsersessioncachetimeout_Internalname ;
      private string edtavUsersessioncachetimeout_Jsonclick ;
      private string divTable_container_userremembermetype_Internalname ;
      private string cmbavUserremembermetype_Internalname ;
      private string AV42UserRememberMeType ;
      private string cmbavUserremembermetype_Jsonclick ;
      private string divTable_container_userremembermetimeout_Internalname ;
      private string edtavUserremembermetimeout_Internalname ;
      private string edtavUserremembermetimeout_Jsonclick ;
      private string divTable_container_userrecoverypasswordkeytimeout_Internalname ;
      private string edtavUserrecoverypasswordkeytimeout_Internalname ;
      private string edtavUserrecoverypasswordkeytimeout_Jsonclick ;
      private string divTable_container_minimumamountcharactersinlogin_Internalname ;
      private string edtavMinimumamountcharactersinlogin_Internalname ;
      private string edtavMinimumamountcharactersinlogin_Jsonclick ;
      private string divTable_container_loginattemptstolockuser_Internalname ;
      private string edtavLoginattemptstolockuser_Internalname ;
      private string edtavLoginattemptstolockuser_Jsonclick ;
      private string divTable_container_gamunblockusertimeout_Internalname ;
      private string edtavGamunblockusertimeout_Internalname ;
      private string edtavGamunblockusertimeout_Jsonclick ;
      private string divTable_container_loginattemptstolocksession_Internalname ;
      private string edtavLoginattemptstolocksession_Internalname ;
      private string edtavLoginattemptstolocksession_Jsonclick ;
      private string divTable_container_giveanonymoussession_Internalname ;
      private string chkavGiveanonymoussession_Internalname ;
      private string divTable_container_defaultsecuritypolicyid_Internalname ;
      private string cmbavDefaultsecuritypolicyid_Internalname ;
      private string cmbavDefaultsecuritypolicyid_Jsonclick ;
      private string divTable_container_defaultroleid_Internalname ;
      private string cmbavDefaultroleid_Internalname ;
      private string cmbavDefaultroleid_Jsonclick ;
      private string divTable_container_logoutbehaviour_Internalname ;
      private string cmbavLogoutbehaviour_Internalname ;
      private string AV55LogoutBehaviour ;
      private string cmbavLogoutbehaviour_Jsonclick ;
      private string divTable_container_enabletracing_Internalname ;
      private string cmbavEnabletracing_Internalname ;
      private string cmbavEnabletracing_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sStyleString ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19CanRegisterUsers ;
      private bool wbLoad ;
      private bool AV33SessionExpiresOnIPChange ;
      private bool AV34AllowOauthAccess ;
      private bool AV38UserEmailisUnique ;
      private bool AV39RequiredEmail ;
      private bool AV40RequiredPassword ;
      private bool AV53RequiredFirstName ;
      private bool AV54RequiredLastName ;
      private bool AV49GiveAnonymousSession ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV18SecurityAdministratorEmail ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP0_pId ;
      private GXCombobox cmbavDefaultauthtypename ;
      private GXCheckbox chkavSessionexpiresonipchange ;
      private GXCheckbox chkavAllowoauthaccess ;
      private GXCombobox cmbavUseridentification ;
      private GXCombobox cmbavUseractivationmethod ;
      private GXCheckbox chkavUseremailisunique ;
      private GXCheckbox chkavRequiredemail ;
      private GXCheckbox chkavRequiredpassword ;
      private GXCheckbox chkavRequiredfirstname ;
      private GXCheckbox chkavRequiredlastname ;
      private GXCombobox cmbavGeneratesessionstatistics ;
      private GXCombobox cmbavUserremembermetype ;
      private GXCheckbox chkavGiveanonymoussession ;
      private GXCombobox cmbavDefaultsecuritypolicyid ;
      private GXCombobox cmbavDefaultroleid ;
      private GXCombobox cmbavLogoutbehaviour ;
      private GXCombobox cmbavEnabletracing ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV15AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV6Roles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV7SecurityPolicies ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV5AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV9Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV17FilterRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV8SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV11Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV16FilterSecPol ;
   }

   public class repositoryconfiguration__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class repositoryconfiguration__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class repositoryconfiguration__gam : DataStoreHelperBase, IDataStoreHelper
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

public class repositoryconfiguration__default : DataStoreHelperBase, IDataStoreHelper
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
