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
   public class remotelogin : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public remotelogin( )
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

      public remotelogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV42IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV42IDP_State;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavLogonto = new GXCombobox();
         chkavKeepmeloggedin = new GXCheckbox();
         chkavRememberme = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
               AV42IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV42IDP_State", AV42IDP_State);
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bfsg.masterpagelogin", "GeneXus.Programs.k2bfsg.masterpagelogin", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA4Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188405617", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal K2BFormLogin\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BFormLogin\" data-gx-class=\"form-horizontal K2BFormLogin\" novalidate action=\""+formatLink("k2bfsg.remotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal K2BFormLogin", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV42IDP_State));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV48Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AmountOfCharacters), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURL", AV64URL);
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal K2BFormLogin" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4Q2( ) ;
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
         return formatLink("k2bfsg.remotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RemoteLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return "Remote Login" ;
      }

      protected void WB4Q0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_MainContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsFSGAM_LoginTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "";
            StyleString = "";
            sImgUrl = imgAppimage_Bitmap;
            GxWebStd.gx_bitmap( context, imgAppimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAppimage_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbappname_Internalname, lblTbappname_Caption, "", "", lblTbappname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTbappname_Visible, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns3_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsFSGAM_Table_Basic", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable30_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log On To", "col-sm-3 K2BToolsFSGAM_Attribute100WidthLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV52LogOnTo), 1, cmbavLogonto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsFSGAM_Attribute100Width", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_K2BFSG\\RemoteLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV65UserName, StringUtil.RTrim( context.localUtil.Format( AV65UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Username or email", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV66UserPassword), StringUtil.RTrim( context.localUtil.Format( AV66UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Password", edtavUserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavForgotpassword_action_Internalname, StringUtil.RTrim( AV34ForgotPassword_Action), StringUtil.RTrim( context.localUtil.Format( AV34ForgotPassword_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+"e114q1_client"+"'", "", "", "", "", edtavForgotpassword_action_Jsonclick, 7, "TextBlock_FloatRight", "", "", "", "", 1, edtavForgotpassword_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_50_4Q2( true) ;
         }
         else
         {
            wb_table1_50_4Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_50_4Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, "Remember me", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV55RememberMe), "", "Remember me", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"");
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
            wb_table2_64_4Q2( true) ;
         }
         else
         {
            wb_table2_64_4Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_4Q2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "", "Login", bttLogin_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RemoteLogin.htm");
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

      protected void START4Q2( )
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
            Form.Meta.addItem("description", "Remote Login", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4Q0( ) ;
      }

      protected void WS4Q2( )
      {
         START4Q2( ) ;
         EVT4Q2( ) ;
      }

      protected void EVT4Q2( )
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
                              E124Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E134Q2 ();
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
                                    E144Q2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E154Q2 ();
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

      protected void WE4Q2( )
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

      protected void PA4Q2( )
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
               GX_FocusControl = cmbavLogonto_Internalname;
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
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV52LogOnTo = cmbavLogonto.getValidValue(AV52LogOnTo);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV47KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV47KeepMeLoggedIn));
         AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
         AV55RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV55RememberMe));
         AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavForgotpassword_action_Enabled = 0;
         AssignProp("", false, edtavForgotpassword_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavForgotpassword_action_Enabled), 5, 0), true);
      }

      protected void RF4Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E134Q2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E154Q2 ();
            WB4Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV48Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavForgotpassword_action_Enabled = 0;
         AssignProp("", false, edtavForgotpassword_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavForgotpassword_action_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV52LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
            AV65UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV65UserName", AV65UserName);
            AV66UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV66UserPassword", AV66UserPassword);
            AV34ForgotPassword_Action = cgiGet( edtavForgotpassword_action_Internalname);
            AssignAttri("", false, "AV34ForgotPassword_Action", AV34ForgotPassword_Action);
            AV47KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
            AV55RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
            AV20CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV24CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV24CaptchaText", AV24CaptchaText);
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
         AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S172 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV8isConnectionOK )
            {
               AV26ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV26ConnectionInfoCollection.Count > 0 )
               {
                  AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV26ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV32Errors);
                  AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               }
            }
         }
         lblTbappname_Visible = 0;
         AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
         imgAppimage_Visible = 0;
         AssignProp("", false, imgAppimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAppimage_Visible), 5, 0), true);
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
         {
            AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getremoteapplication(AV42IDP_State, out  AV32Errors);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5GAMApplication.gxTpr_Clientimageurl)) )
            {
               imgAppimage_Visible = 1;
               AssignProp("", false, imgAppimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAppimage_Visible), 5, 0), true);
               imgAppimage_Bitmap = AV5GAMApplication.gxTpr_Clientimageurl;
               AssignProp("", false, imgAppimage_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgAppimage_Bitmap)), true);
               AssignProp("", false, imgAppimage_Internalname, "SrcSet", context.GetImageSrcSet( imgAppimage_Bitmap), true);
            }
            else
            {
               lblTbappname_Visible = 1;
               AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
               lblTbappname_Caption = AV5GAMApplication.gxTpr_Name;
               AssignProp("", false, lblTbappname_Internalname, "Caption", lblTbappname_Caption, true);
            }
         }
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV12AmountOfCharacters, out  AV13AmountOfFailedLogins, out  AV17BadLoginsExpire, out  AV60ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV12AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV12AmountOfCharacters), 4, 0));
         Form.Class = "K2BFormLogin";
         AssignProp("", false, "FORM", "Class", Form.Class, true);
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E124Q2 ();
         if (returnInSub) return;
      }

      protected void E124Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E134Q2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV34ForgotPassword_Action = "Olvidó su contraseña";
         AssignAttri("", false, "AV34ForgotPassword_Action", AV34ForgotPassword_Action);
         AV28CreateAnAccount_Action = "Crear cuenta";
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S182 ();
         if (returnInSub) return;
         AV7hasError = false;
         AV33ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV33ErrorsLogin.Count > 0 )
         {
            AV7hasError = true;
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV33ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV33ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV66UserPassword = "";
               AssignAttri("", false, "AV66UserPassword", AV66UserPassword);
               AV32Errors = AV33ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S192 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV7hasError )
         {
            AV59SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV58Session, out  AV32Errors);
            if ( AV59SessionValid && ! AV58Session.gxTpr_Isanonymous )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV42IDP_State) ;
               }
               else
               {
                  AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  AssignAttri("", false, "AV64URL", AV64URL);
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV64URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV16AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV48Language, out  AV32Errors);
               AV73GXV1 = 1;
               while ( AV73GXV1 <= AV16AuthenticationTypes.Count )
               {
                  AV15AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV16AuthenticationTypes.Item(AV73GXV1));
                  if ( AV15AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV15AuthenticationType.gxTpr_Name, AV15AuthenticationType.gxTpr_Description, 0);
                  }
                  AV73GXV1 = (int)(AV73GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV52LogOnTo, out  AV65UserName, out  AV67UserRememberMe, out  AV32Errors) ;
               if ( AV67UserRememberMe == 2 )
               {
                  AV55RememberMe = true;
                  AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
               }
               AV56Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV52LogOnTo = AV56Repository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
               }
               chkavRememberme.Visible = 0;
               AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               chkavKeepmeloggedin.Visible = 0;
               AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Both") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144Q2 ();
         if (returnInSub) return;
      }

      protected void E144Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_LOGIN' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AdditionalParameter", AV11AdditionalParameter);
      }

      protected void S142( )
      {
         /* 'U_LOGIN' Routine */
         returnInSub = false;
         GXt_char1 = AV64URL;
         new k2bsessionget(context ).execute(  "SessionCaptchaRedirectURL", out  GXt_char1) ;
         AV64URL = GXt_char1;
         AssignAttri("", false, "AV64URL", AV64URL);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
         {
            AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            AssignAttri("", false, "AV64URL", AV64URL);
         }
         GXt_boolean2 = AV44IncorrectLoginsExisted;
         new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV52LogOnTo,  AV65UserName, out  GXt_boolean2) ;
         AV44IncorrectLoginsExisted = GXt_boolean2;
         if ( AV44IncorrectLoginsExisted )
         {
            GXt_boolean2 = AV21CaptchaIsCorrect;
            new GeneXus.Programs.k2bfsg.evaluatecaptchacorrectness(context ).execute(  AV24CaptchaText, out  GXt_boolean2) ;
            AV21CaptchaIsCorrect = GXt_boolean2;
            if ( AV21CaptchaIsCorrect )
            {
               /* Execute user subroutine: 'PROCESSLOGIN' */
               S202 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'ACTIVATECAPTCHA' */
               S212 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'PROCESSLOGIN' */
            S202 ();
            if (returnInSub) return;
         }
      }

      protected void S202( )
      {
         /* 'PROCESSLOGIN' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV12AmountOfCharacters, out  AV13AmountOfFailedLogins, out  AV17BadLoginsExpire, out  AV60ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV12AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV12AmountOfCharacters), 4, 0));
         if ( AV47KeepMeLoggedIn )
         {
            AV11AdditionalParameter.gxTpr_Rememberusertype = (short)((AV47KeepMeLoggedIn ? 3 : 1));
         }
         else
         {
            if ( AV55RememberMe )
            {
               AV11AdditionalParameter.gxTpr_Rememberusertype = (short)((AV55RememberMe ? 2 : 1));
            }
            else
            {
               AV11AdditionalParameter.gxTpr_Rememberusertype = 1;
            }
         }
         AV11AdditionalParameter.gxTpr_Authenticationtypename = AV52LogOnTo;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV70CaptchaActive) ;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV23CaptchaRequiredText) ;
         AV51LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV65UserName, AV66UserPassword, AV11AdditionalParameter, out  AV32Errors);
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  AV70CaptchaActive) ;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV23CaptchaRequiredText) ;
         if ( ! AV51LoginOK )
         {
            if ( AV32Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  new GeneXus.Programs.k2bfsg.saveincorrectlogin(context ).execute(  AV52LogOnTo,  AV65UserName) ;
                  if ( AV13AmountOfFailedLogins == 1 )
                  {
                     /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                     S212 ();
                     if (returnInSub) return;
                  }
                  else
                  {
                     GXt_boolean2 = AV44IncorrectLoginsExisted;
                     new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV52LogOnTo,  AV65UserName, out  GXt_boolean2) ;
                     AV44IncorrectLoginsExisted = GXt_boolean2;
                     if ( AV44IncorrectLoginsExisted )
                     {
                        /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                        S212 ();
                        if (returnInSub) return;
                     }
                  }
               }
            }
         }
         else
         {
            new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV52LogOnTo,  AV65UserName) ;
            /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
            S222 ();
            if (returnInSub) return;
            new GeneXus.Programs.k2bfsg.updatecontextafterlogin(context ).execute( ) ;
            context.CommitDataStores("k2bfsg.remotelogin",pr_default);
            if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
            {
               new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV42IDP_State) ;
            }
            else
            {
               AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               AssignAttri("", false, "AV64URL", AV64URL);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
               }
               else
               {
                  CallWebObject(formatLink(AV64URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
         }
      }

      protected void S192( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV23CaptchaRequiredText) ;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV61ShowDetailedMessages) ;
         AssignAttri("", false, "AV61ShowDetailedMessages", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         AV31ErrorCount = 0;
         AV74GXV2 = 1;
         while ( AV74GXV2 <= AV32Errors.Count )
         {
            AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(AV74GXV2));
            if ( AV30Error.gxTpr_Code == 104 )
            {
               new k2btoolsmsg(context ).execute(  AV30Error.gxTpr_Message,  2) ;
            }
            else
            {
               AV31ErrorCount = (short)(AV31ErrorCount+1);
            }
            AV74GXV2 = (int)(AV74GXV2+1);
         }
         if ( ( AV31ErrorCount > 0 ) || ( StringUtil.StrCmp(AV23CaptchaRequiredText, "true") == 0 ) )
         {
            new k2btoolsmsg(context ).execute(  "Usuario o contraseña incorrectos",  2) ;
         }
         if ( AV61ShowDetailedMessages )
         {
            AV75GXV3 = 1;
            while ( AV75GXV3 <= AV32Errors.Count )
            {
               AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(AV75GXV3));
               if ( AV30Error.gxTpr_Code != 13 )
               {
                  new k2btoolsmsg(context ).execute(  StringUtil.Format( "%1 (GAM%2)", AV30Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV30Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""),  2) ;
               }
               AV75GXV3 = (int)(AV75GXV3+1);
            }
         }
      }

      protected void S152( )
      {
         /* 'U_FORGOTPASSWORD' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.recoverpasswordstep1.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'U_CREATEANACCOUNT' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.registeruser.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'ACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "true") ;
         new k2bsessionset(context ).execute(  "SessionCaptchaRedirectURL",  AV64URL) ;
         CallWebObject(formatLink("k2bfsg.remotelogin.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DEACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "false") ;
      }

      protected void S232( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV22CaptchaProvider.generatestringtoken(AV12AmountOfCharacters)) ;
      }

      protected void S182( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV23CaptchaRequiredText) ;
         if ( StringUtil.StrCmp(AV23CaptchaRequiredText, "true") == 0 )
         {
            /* Execute user subroutine: 'CREATENEWCAPTCHA' */
            S232 ();
            if (returnInSub) return;
            new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV23CaptchaRequiredText) ;
            lblCaptchadescription_Visible = 1;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 1;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 1;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV18Base64String = AV22CaptchaProvider.generateimage(180, 75, AV23CaptchaRequiredText);
            AV20CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV18Base64String;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV76Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
            AV76Captchaimage_GXI = GXDbFile.PathToUrl( "data:image/jpeg;charset=utf-8;base64,"+AV18Base64String);
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV76Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
         }
         else
         {
            lblCaptchadescription_Visible = 0;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 0;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 0;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV32Errors);
            AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
         }
         if ( ! AV8isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV57RepositoryGUID) )
            {
               AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV57RepositoryGUID, out  AV32Errors);
               AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
            }
            else
            {
               AV26ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV26ConnectionInfoCollection.Count > 0 )
               {
                  AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV26ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV32Errors);
                  AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               }
            }
         }
         if ( AV8isConnectionOK )
         {
            AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV32Errors);
               AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E154Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_64_4Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "K2BFSGTable_CAPTCHAContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, "Please insert the text below", "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute_Trn";
            StyleString = "";
            AV20CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV76Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV76Captchaimage_GXI : context.PathToRelativeUrl( AV20CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV20CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV24CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV24CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "K2BFSG_CAPTCHAField", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 10, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "K2BDescription", "left", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_4Q2e( true) ;
         }
         else
         {
            wb_table2_64_4Q2e( false) ;
         }
      }

      protected void wb_table1_50_4Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, "Keep me Logged In", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV47KeepMeLoggedIn), "", "Keep me Logged In", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_keepmeloggedin_Internalname, "Keep me logged in", "", "", lblTextblock_var_keepmeloggedin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_50_4Q2e( true) ;
         }
         else
         {
            wb_table1_50_4Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV42IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV42IDP_State", AV42IDP_State);
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
         PA4Q2( ) ;
         WS4Q2( ) ;
         WE4Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188414135", true, true);
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
         context.AddJavascriptSource("k2bfsg/remotelogin.js", "?2024188414140", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV52LogOnTo = cmbavLogonto.getValidValue(AV52LogOnTo);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV47KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV47KeepMeLoggedIn));
         AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV55RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV55RememberMe));
         AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgAppimage_Internalname = "APPIMAGE";
         lblTbappname_Internalname = "TBAPPNAME";
         cmbavLogonto_Internalname = "vLOGONTO";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divTable30_Internalname = "TABLE30";
         edtavForgotpassword_action_Internalname = "vFORGOTPASSWORD_ACTION";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         lblTextblock_var_keepmeloggedin_Internalname = "TEXTBLOCK_VAR_KEEPMELOGGEDIN";
         tblTable2_Internalname = "TABLE2";
         chkavRememberme_Internalname = "vREMEMBERME";
         divTable5_Internalname = "TABLE5";
         lblCaptchadescription_Internalname = "CAPTCHADESCRIPTION";
         imgavCaptchaimage_Internalname = "vCAPTCHAIMAGE";
         edtavCaptchatext_Internalname = "vCAPTCHATEXT";
         tblTable4_Internalname = "TABLE4";
         divTable1_Internalname = "TABLE1";
         divColumns3_maincolumnstable_Internalname = "COLUMNS3_MAINCOLUMNSTABLE";
         bttLogin_Internalname = "LOGIN";
         divTable22_Internalname = "TABLE22";
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
         chkavRememberme.Caption = "Remember me";
         chkavKeepmeloggedin.Caption = "Keep me Logged In";
         chkavKeepmeloggedin.Enabled = 1;
         edtavCaptchatext_Jsonclick = "";
         edtavCaptchatext_Enabled = 1;
         lblCaptchadescription_Visible = 1;
         edtavCaptchatext_Visible = 1;
         imgavCaptchaimage_Visible = 1;
         chkavKeepmeloggedin.Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         edtavForgotpassword_action_Jsonclick = "";
         edtavForgotpassword_action_Enabled = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         lblTbappname_Caption = "Application Name";
         lblTbappname_Visible = 1;
         imgAppimage_Visible = 1;
         imgAppimage_Bitmap = (string)(context.GetImagePath( "b204c38c-79ae-43b6-aab7-fdc3fcbe6833", "", context.GetTheme( )));
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Remote Login";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV65UserName',fld:'vUSERNAME',pic:''},{av:'AV12AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV48Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV67UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV61ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV34ForgotPassword_Action',fld:'vFORGOTPASSWORD_ACTION',pic:''},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV66UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV64URL',fld:'vURL',pic:''},{av:'cmbavLogonto'},{av:'AV52LogOnTo',fld:'vLOGONTO',pic:''},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'AV20CaptchaImage',fld:'vCAPTCHAIMAGE',pic:''},{av:'lblCaptchadescription_Visible',ctrl:'CAPTCHADESCRIPTION',prop:'Visible'},{av:'imgavCaptchaimage_Visible',ctrl:'vCAPTCHAIMAGE',prop:'Visible'},{av:'edtavCaptchatext_Visible',ctrl:'vCAPTCHATEXT',prop:'Visible'},{av:'AV61ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E144Q2',iparms:[{av:'cmbavLogonto'},{av:'AV52LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV65UserName',fld:'vUSERNAME',pic:''},{av:'AV24CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV66UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV64URL',fld:'vURL',pic:''},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV64URL',fld:'vURL',pic:''},{av:'AV12AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'E_FORGOTPASSWORD'","{handler:'E114Q1',iparms:[{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'E_FORGOTPASSWORD'",",oparms:[{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
         wcpOAV42IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV48Language = "";
         GXKey = "";
         AV64URL = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTbappname_Jsonclick = "";
         TempTags = "";
         AV52LogOnTo = "";
         AV65UserName = "";
         AV66UserPassword = "";
         AV34ForgotPassword_Action = "";
         bttLogin_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV20CaptchaImage = "";
         AV24CaptchaText = "";
         AV26ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV32Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV28CreateAnAccount_Action = "";
         AV33ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV58Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV16AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV15AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV56Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         GXt_char1 = "";
         AV70CaptchaActive = "";
         AV23CaptchaRequiredText = "";
         AV30Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV22CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV18Base64String = "";
         AV76Captchaimage_GXI = "";
         AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV57RepositoryGUID = "";
         sStyleString = "";
         lblCaptchadescription_Jsonclick = "";
         lblTextblock_var_keepmeloggedin_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavForgotpassword_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV67UserRememberMe ;
      private short AV12AmountOfCharacters ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV13AmountOfFailedLogins ;
      private short AV31ErrorCount ;
      private short nGXWrapped ;
      private int imgAppimage_Visible ;
      private int lblTbappname_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int edtavForgotpassword_action_Enabled ;
      private int AV73GXV1 ;
      private int AV74GXV2 ;
      private int AV75GXV3 ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int edtavCaptchatext_Enabled ;
      private int idxLst ;
      private string AV42IDP_State ;
      private string wcpOAV42IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV48Language ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divContenttable_Internalname ;
      private string divColumns_maincolumnstable_Internalname ;
      private string divTable22_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgAppimage_Internalname ;
      private string lblTbappname_Internalname ;
      private string lblTbappname_Caption ;
      private string lblTbappname_Jsonclick ;
      private string divColumns3_maincolumnstable_Internalname ;
      private string divTable1_Internalname ;
      private string divTable30_Internalname ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string AV52LogOnTo ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV66UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string edtavForgotpassword_action_Internalname ;
      private string AV34ForgotPassword_Action ;
      private string edtavForgotpassword_action_Jsonclick ;
      private string divTable5_Internalname ;
      private string chkavRememberme_Internalname ;
      private string bttLogin_Internalname ;
      private string bttLogin_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavKeepmeloggedin_Internalname ;
      private string imgavCaptchaimage_Internalname ;
      private string AV24CaptchaText ;
      private string edtavCaptchatext_Internalname ;
      private string AV28CreateAnAccount_Action ;
      private string GXt_char1 ;
      private string AV70CaptchaActive ;
      private string AV23CaptchaRequiredText ;
      private string lblCaptchadescription_Internalname ;
      private string AV18Base64String ;
      private string AV57RepositoryGUID ;
      private string sStyleString ;
      private string tblTable4_Internalname ;
      private string lblCaptchadescription_Jsonclick ;
      private string edtavCaptchatext_Jsonclick ;
      private string tblTable2_Internalname ;
      private string lblTextblock_var_keepmeloggedin_Internalname ;
      private string lblTextblock_var_keepmeloggedin_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV61ShowDetailedMessages ;
      private bool wbLoad ;
      private bool AV55RememberMe ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV47KeepMeLoggedIn ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV8isConnectionOK ;
      private bool AV17BadLoginsExpire ;
      private bool AV60ShouldAddSleepOnFailure ;
      private bool AV7hasError ;
      private bool AV59SessionValid ;
      private bool AV44IncorrectLoginsExisted ;
      private bool AV21CaptchaIsCorrect ;
      private bool AV51LoginOK ;
      private bool GXt_boolean2 ;
      private bool AV20CaptchaImage_IsBlob ;
      private string AV64URL ;
      private string AV65UserName ;
      private string AV76Captchaimage_GXI ;
      private string imgAppimage_Bitmap ;
      private string AV20CaptchaImage ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private SdtK2BToolsCaptchaProvider AV22CaptchaProvider ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV32Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV33ErrorsLogin ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV16AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV26ConnectionInfoCollection ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV5GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV30Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV56Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV6GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV11AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV58Session ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV15AuthenticationType ;
   }

   public class remotelogin__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class remotelogin__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class remotelogin__gam : DataStoreHelperBase, IDataStoreHelper
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

public class remotelogin__default : DataStoreHelperBase, IDataStoreHelper
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
