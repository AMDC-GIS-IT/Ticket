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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamremotelogin : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public gamremotelogin( )
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

      public gamremotelogin( IGxContext context )
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

      public void execute( ref string aP0_IDP_State )
      {
         this.AV13IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV13IDP_State;
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
         cmbavTypeauthtype = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridauthtypes") == 0 )
            {
               nRC_GXsfl_59 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_59"), "."));
               nGXsfl_59_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_59_idx"), "."));
               sGXsfl_59_idx = GetPar( "sGXsfl_59_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridauthtypes_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridauthtypes") == 0 )
            {
               AV13IDP_State = GetPar( "IDP_State");
               AV18Language = GetPar( "Language");
               AV37AuxUserName = GetPar( "AuxUserName");
               AV30UserRememberMe = (short)(NumberUtil.Val( GetPar( "UserRememberMe"), "."));
               AV17KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
               AV22RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridauthtypes_refresh( AV13IDP_State, AV18Language, AV37AuxUserName, AV30UserRememberMe, AV17KeepMeLoggedIn, AV22RememberMe) ;
               GxWebStd.gx_hidden_field( context, "TABLEBUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTablebuttons_Visible), 5, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "TABLEBUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTablebuttons_Visible), 5, 0, ".", "")));
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
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
            ValidateSpaRequest();
            PA3A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               cmbavTypeauthtype.Enabled = 0;
               AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_59_Refreshing);
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_59_Refreshing);
               WS3A2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE3A2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Remote Login ") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2023124953285", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamremotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_59", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_59), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV37AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "TABLEBUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTablebuttons_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABLEBUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTablebuttons_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3A2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMRemoteLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return "Remote Login " ;
      }

      protected void WB3A0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "LoginContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbllogin_Internalname, divTbllogin_Visible, 0, "px", 0, "px", "TableLogin", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Identity Provider", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigTitle", 0, "", 1, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Logo App Client", "col-sm-3 ImageLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV20LogoAppClient_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient))&&String.IsNullOrEmpty(StringUtil.RTrim( AV40Logoappclient_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)) ? AV40Logoappclient_GXI : context.PathToRelativeUrl( AV20LogoAppClient));
            GxWebStd.gx_bitmap( context, imgavLogoappclient_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavLogoappclient_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV20LogoAppClient_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbappname_Internalname, lblTbappname_Caption, "", "", lblTbappname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTbappname_Visible, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log on to", "col-sm-5 LoginComboAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-7 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV21LogOnTo), 1, cmbavLogonto_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVLOGONTO.CLICK."+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "LoginComboAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 1, "HLP_GAMRemoteLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "col-sm-3 col-lg-2 LoginAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV28UserName, StringUtil.RTrim( context.localUtil.Format( AV28UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "User name", edtavUsername_Jsonclick, 0, "LoginAttribute", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 50, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "User Password", "col-sm-3 col-lg-2 LoginAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV29UserPassword), StringUtil.RTrim( context.localUtil.Format( AV29UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUserpassword_Invitemessage, edtavUserpassword_Jsonclick, 0, "LoginAttribute", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-xs-offset-3 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_59_idx + "',0)\"";
            ClassString = "CheckBox Label";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV17KeepMeLoggedIn), "", "", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "Keep me signed in", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-xs-offset-3 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_59_idx + "',0)\"";
            ClassString = "CheckBox Label";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV22RememberMe), "", "", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "Remember Me", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(45, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,45);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "BtnLogin";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", bttLogin_Caption, bttLogin_Jsonclick, 5, "SIGN IN", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 col-xs-offset-1 col-sm-12 col-sm-offset-0", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbforgotpwd_Internalname, "FORGOT YOUR PASSWORD?", "", "", lblTbforgotpwd_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113a1_client"+"'", "", "PagingText TextLikeLink", 7, "", lblTbforgotpwd_Visible, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttons_Internalname, divTablebuttons_Visible, 0, "px", 0, "px", "TableButtons", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-sm-offset-1", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, "OR USE", "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-0", "Center", "top", "", "", "div");
            /*  Grid Control  */
            GridauthtypesContainer.SetIsFreestyle(true);
            GridauthtypesContainer.SetWrapped(nGXWrapped);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"DivS\" data-gxgridid=\"59\">") ;
               sStyleString = "";
               if ( subGridauthtypes_Visible == 0 )
               {
                  sStyleString += "display:none;";
               }
               GxWebStd.gx_table_start( context, subGridauthtypes_Internalname, subGridauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
            }
            else
            {
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
               GridauthtypesContainer.AddObjectProperty("Header", subGridauthtypes_Header);
               GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("CmpContext", "");
               GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", context.convertURL( AV34ImageAuthType));
               GridauthtypesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavImageauthtype_Tooltiptext));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV35TypeAuthType));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Enabled), 5, 0, ".", "")));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV36NameAuthType));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectedindex), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowselection), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectioncolor), 9, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowhovering), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Hoveringcolor), 9, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowcollapsing), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 59 )
         {
            wbEnd = 0;
            nRC_GXsfl_59 = (int)(nGXsfl_59_idx-1);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               if ( subGridauthtypes_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 59 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridauthtypesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  if ( subGridauthtypes_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3A2( )
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
            Form.Meta.addItem("description", "Remote Login ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3A0( ) ;
      }

      protected void WS3A2( )
      {
         START3A2( ) ;
         EVT3A2( ) ;
      }

      protected void EVT3A2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "VLOGONTO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E123A2 ();
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
                                 E133A2 ();
                              }
                              dynload_actions( ) ;
                           }
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) )
                        {
                           nGXsfl_59_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
                           SubsflControlProps_592( ) ;
                           AV34ImageAuthType = cgiGet( edtavImageauthtype_Internalname);
                           AssignProp("", false, edtavImageauthtype_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34ImageAuthType)) ? AV44Imageauthtype_GXI : context.convertURL( context.PathToRelativeUrl( AV34ImageAuthType))), !bGXsfl_59_Refreshing);
                           AssignProp("", false, edtavImageauthtype_Internalname, "SrcSet", context.GetImageSrcSet( AV34ImageAuthType), true);
                           cmbavTypeauthtype.Name = cmbavTypeauthtype_Internalname;
                           cmbavTypeauthtype.CurrentValue = cgiGet( cmbavTypeauthtype_Internalname);
                           AV35TypeAuthType = cgiGet( cmbavTypeauthtype_Internalname);
                           AssignAttri("", false, cmbavTypeauthtype_Internalname, AV35TypeAuthType);
                           AV36NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV36NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV36NameAuthType, "")), context));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E143A2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E153A2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRIDAUTHTYPES.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E163A2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E173A2 ();
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

      protected void WE3A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3A2( ) ;
            }
         }
      }

      protected void PA3A2( )
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

      protected void gxnrGridauthtypes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_592( ) ;
         while ( nGXsfl_59_idx <= nRC_GXsfl_59 )
         {
            sendrow_592( ) ;
            nGXsfl_59_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_59_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridauthtypesContainer)) ;
         /* End function gxnrGridauthtypes_newrow */
      }

      protected void gxgrGridauthtypes_refresh( string AV13IDP_State ,
                                                string AV18Language ,
                                                string AV37AuxUserName ,
                                                short AV30UserRememberMe ,
                                                bool AV17KeepMeLoggedIn ,
                                                bool AV22RememberMe )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E153A2 ();
         GRIDAUTHTYPES_nCurrentRecord = 0;
         RF3A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV36NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV36NameAuthType));
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
            AV21LogOnTo = cmbavLogonto.getValidValue(AV21LogOnTo);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         AV22RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RememberMe));
         AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_59_Refreshing);
      }

      protected void RF3A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridauthtypesContainer.ClearRows();
         }
         wbStart = 59;
         /* Execute user event: Refresh */
         E153A2 ();
         nGXsfl_59_idx = 1;
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         bGXsfl_59_Refreshing = true;
         GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
         GridauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
         GridauthtypesContainer.PageSize = subGridauthtypes_fnc_Recordsperpage( );
         if ( subGridauthtypes_Islastpage != 0 )
         {
            GRIDAUTHTYPES_nFirstRecordOnPage = (long)(subGridauthtypes_fnc_Recordcount( )-subGridauthtypes_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDAUTHTYPES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDAUTHTYPES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("GRIDAUTHTYPES_nFirstRecordOnPage", GRIDAUTHTYPES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_592( ) ;
            E163A2 ();
            wbEnd = 59;
            WB3A0( ) ;
         }
         bGXsfl_59_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3A2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV37AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV36NameAuthType, "")), context));
      }

      protected int subGridauthtypes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_59 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), ",", "."));
            AV13IDP_State = cgiGet( "vIDP_STATE");
            divTablebuttons_Visible = (int)(context.localUtil.CToN( cgiGet( "TABLEBUTTONS_Visible"), ",", "."));
            /* Read variables values. */
            AV20LogoAppClient = cgiGet( imgavLogoappclient_Internalname);
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV21LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
            AV28UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV28UserName", AV28UserName);
            AV29UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
            AV17KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
            AV22RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
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
         E143A2 ();
         if (returnInSub) return;
      }

      protected void E143A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV14isConnectionOK )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV24RepositoryGUID) )
               {
                  AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV24RepositoryGUID, out  AV10Errors);
                  AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
               }
               else
               {
                  AV8ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
                  if ( AV8ConnectionInfoCollection.Count > 0 )
                  {
                     AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV8ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV10Errors);
                     AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
                  }
               }
            }
         }
         AV31GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getremoteapplication(AV13IDP_State, out  AV10Errors);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31GAMApplication.gxTpr_Clientimageurl)) )
         {
            imgavLogoappclient_Visible = 1;
            AssignProp("", false, imgavLogoappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavLogoappclient_Visible), 5, 0), true);
            lblTbappname_Visible = 0;
            AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
            AV20LogoAppClient = AV31GAMApplication.gxTpr_Clientimageurl;
            AssignProp("", false, imgavLogoappclient_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)) ? AV40Logoappclient_GXI : context.convertURL( context.PathToRelativeUrl( AV20LogoAppClient))), true);
            AssignProp("", false, imgavLogoappclient_Internalname, "SrcSet", context.GetImageSrcSet( AV20LogoAppClient), true);
            AV40Logoappclient_GXI = GXDbFile.PathToUrl( AV31GAMApplication.gxTpr_Clientimageurl);
            AssignProp("", false, imgavLogoappclient_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)) ? AV40Logoappclient_GXI : context.convertURL( context.PathToRelativeUrl( AV20LogoAppClient))), true);
            AssignProp("", false, imgavLogoappclient_Internalname, "SrcSet", context.GetImageSrcSet( AV20LogoAppClient), true);
         }
         else
         {
            imgavLogoappclient_Visible = 0;
            AssignProp("", false, imgavLogoappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavLogoappclient_Visible), 5, 0), true);
            lblTbappname_Visible = 1;
            AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
            lblTbappname_Caption = AV31GAMApplication.gxTpr_Name;
            AssignProp("", false, lblTbappname_Internalname, "Caption", lblTbappname_Caption, true);
         }
      }

      protected void E153A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         subGridauthtypes_Visible = 0;
         AssignProp("", false, "GridauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridauthtypes_Visible), 5, 0), true);
         divTableauthtypeinfo_Visible = 0;
         AssignProp("", false, divTableauthtypeinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableauthtypeinfo_Visible), 5, 0), !bGXsfl_59_Refreshing);
         AV16isRedirect = false;
         AV11ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV11ErrorsLogin.Count > 0 )
         {
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 1 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 104 ) )
            {
            }
            else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("gamexamplechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
               AV16isRedirect = true;
            }
            else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 161 )
            {
               CallWebObject(formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
               AV16isRedirect = true;
            }
            else
            {
               AV29UserPassword = "";
               AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
               AV10Errors = AV11ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
               divTbllogin_Visible = 0;
               AssignProp("", false, divTbllogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbllogin_Visible), 5, 0), true);
            }
         }
         if ( ! AV16isRedirect )
         {
            AV26SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV25Session, out  AV10Errors);
            if ( AV26SessionValid && ! AV25Session.gxTpr_Isanonymous )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV13IDP_State) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV13IDP_State) ;
               }
               else
               {
                  AV27URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27URL)) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV27URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV18Language, out  AV10Errors);
               AV41GXV1 = 1;
               while ( AV41GXV1 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV41GXV1));
                  if ( AV6AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV6AuthenticationType.gxTpr_Name, AV6AuthenticationType.gxTpr_Description, 0);
                  }
                  else
                  {
                     subGridauthtypes_Visible = 1;
                     AssignProp("", false, "GridauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridauthtypes_Visible), 5, 0), true);
                  }
                  AV41GXV1 = (int)(AV41GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               else
               {
                  AV21LogOnTo = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(1)).gxTpr_Name;
                  AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
               }
               AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV21LogOnTo, out  AV37AuxUserName, out  AV30UserRememberMe, out  AV10Errors);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37AuxUserName)) )
               {
                  AV28UserName = AV37AuxUserName;
                  AssignAttri("", false, "AV28UserName", AV28UserName);
               }
               if ( AV30UserRememberMe == 2 )
               {
                  AV22RememberMe = true;
                  AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
               }
               AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV21LogOnTo = AV12GAMRepository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
               }
               /* Execute user subroutine: 'DISPLAYCHECKBOX' */
               S132 ();
               if (returnInSub) return;
               AV42GXV2 = 1;
               while ( AV42GXV2 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV42GXV2));
                  if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV21LogOnTo) == 0 )
                  {
                     /* Execute user subroutine: 'VALIDLOGONTOOTP' */
                     S142 ();
                     if (returnInSub) return;
                     if (true) break;
                  }
                  AV42GXV2 = (int)(AV42GXV2+1);
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      private void E163A2( )
      {
         /* Gridauthtypes_Load Routine */
         returnInSub = false;
         AV43GXV3 = 1;
         while ( AV43GXV3 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV43GXV3));
            if ( AV6AuthenticationType.gxTpr_Redirtoauthenticate )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6AuthenticationType.gxTpr_Smallimagename)) )
               {
                  AV34ImageAuthType = context.GetImagePath( AV6AuthenticationType.gxTpr_Smallimagename, "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV34ImageAuthType);
                  AV44Imageauthtype_GXI = GXDbFile.PathToUrl( AV6AuthenticationType.gxTpr_Smallimagename);
               }
               else
               {
                  AV34ImageAuthType = context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV34ImageAuthType);
                  AV44Imageauthtype_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( )));
               }
               AV35TypeAuthType = AV6AuthenticationType.gxTpr_Type;
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV35TypeAuthType);
               AV36NameAuthType = StringUtil.Trim( AV6AuthenticationType.gxTpr_Name);
               AssignAttri("", false, edtavNameauthtype_Internalname, AV36NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV36NameAuthType, "")), context));
               edtavImageauthtype_Tooltiptext = StringUtil.Format( "Sign in with %1", StringUtil.Trim( AV6AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               if ( divTablebuttons_Visible == 0 )
               {
                  divTablebuttons_Visible = 1;
                  AssignProp("", false, divTablebuttons_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablebuttons_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 59;
               }
               sendrow_592( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_59_Refreshing )
               {
                  context.DoAjaxLoad(59, GridauthtypesRow);
               }
            }
            AV43GXV3 = (int)(AV43GXV3+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV35TypeAuthType);
      }

      protected void E123A2( )
      {
         /* Logonto_Click Routine */
         returnInSub = false;
         AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV18Language, out  AV10Errors);
         AV33isModeOTP = false;
         AV45GXV4 = 1;
         while ( AV45GXV4 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV45GXV4));
            if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV21LogOnTo) == 0 )
            {
               /* Execute user subroutine: 'VALIDLOGONTOOTP' */
               S142 ();
               if (returnInSub) return;
               if (true) break;
            }
            AV45GXV4 = (int)(AV45GXV4+1);
         }
         if ( ! AV33isModeOTP )
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavUserpassword_Invitemessage = "Password";
            AssignProp("", false, edtavUserpassword_Internalname, "Invitemessage", edtavUserpassword_Invitemessage, true);
            bttLogin_Caption = "SING IN";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblTbforgotpwd_Visible = 1;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E133A2 ();
         if (returnInSub) return;
      }

      protected void E133A2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV17KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV22RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV32GAMProperties = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getgamremoteinitialproperties(AV13IDP_State);
         AV5AdditionalParameter.gxTpr_Properties = AV32GAMProperties;
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV21LogOnTo;
         AV5AdditionalParameter.gxTpr_Idpstate = AV13IDP_State;
         AV5AdditionalParameter.gxTpr_Otpstep = 1;
         AV19LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV28UserName, AV29UserPassword, AV5AdditionalParameter, out  AV10Errors);
         if ( AV19LoginOK )
         {
         }
         else
         {
            if ( AV10Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamexamplechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 400 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 410 ) )
               {
                  CallWebObject(formatLink("gamexampleotpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV29UserPassword = "";
                  AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void E173A2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         if ( AV17KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV22RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV36NameAuthType;
         AV5AdditionalParameter.gxTpr_Idpstate = AV13IDP_State;
         AV19LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV28UserName, AV29UserPassword, AV5AdditionalParameter, out  AV10Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S112( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV12GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV12GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV10Errors);
            AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
         }
         if ( ! AV14isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV24RepositoryGUID) )
            {
               AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV24RepositoryGUID, out  AV10Errors);
               AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
            }
            else
            {
               AV8ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV8ConnectionInfoCollection.Count > 0 )
               {
                  AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV8ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV10Errors);
                  AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
               }
            }
         }
         if ( AV14isConnectionOK )
         {
            AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV12GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV14isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV12GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV10Errors);
               AssignAttri("", false, "AV14isConnectionOK", AV14isConnectionOK);
               AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
         }
      }

      protected void S132( )
      {
         /* 'DISPLAYCHECKBOX' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Login") == 0 )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Auth") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Both") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'VALIDLOGONTOOTP' Routine */
         returnInSub = false;
         if ( ! AV6AuthenticationType.gxTpr_Needuserpassword )
         {
            AV33isModeOTP = true;
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            bttLogin_Caption = "SEND ME A CODE";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblTbforgotpwd_Visible = 0;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV46GXV5 = 1;
         while ( AV46GXV5 <= AV10Errors.Count )
         {
            AV9Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(AV46GXV5));
            if ( AV9Error.gxTpr_Code != 13 )
            {
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV9Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV9Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            }
            AV46GXV5 = (int)(AV46GXV5+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
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
         PA3A2( ) ;
         WS3A2( ) ;
         WE3A2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023124953511", true, true);
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
         context.AddJavascriptSource("gamremotelogin.js", "?2023124953514", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_592( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_59_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_59_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_59_idx;
      }

      protected void SubsflControlProps_fel_592( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_59_fel_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_59_fel_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_59_fel_idx;
      }

      protected void sendrow_592( )
      {
         SubsflControlProps_592( ) ;
         WB3A0( ) ;
         GridauthtypesRow = GXWebRow.GetNew(context,GridauthtypesContainer);
         if ( subGridauthtypes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            subGridauthtypes_Backcolor = subGridauthtypes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Uniform";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
            subGridauthtypes_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridauthtypes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( ((int)((nGXsfl_59_idx) % (2))) == 0 )
            {
               subGridauthtypes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Even";
               }
            }
            else
            {
               subGridauthtypes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_59_idx+"\">") ;
         }
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridauthtypestable1_Internalname+"_"+sGXsfl_59_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)45,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Image Auth Type",(string)"col-sm-3 Fixed30Label",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavImageauthtype_Enabled!=0)&&(edtavImageauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 64,'',false,'',59)\"" : " ");
         ClassString = "Fixed30";
         StyleString = "";
         AV34ImageAuthType_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV34ImageAuthType))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Imageauthtype_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV34ImageAuthType)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV34ImageAuthType)) ? AV44Imageauthtype_GXI : context.PathToRelativeUrl( AV34ImageAuthType));
         GridauthtypesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImageauthtype_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)edtavImageauthtype_Tooltiptext,(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavImageauthtype_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_59_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV34ImageAuthType_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableauthtypeinfo_Internalname+"_"+sGXsfl_59_idx,(int)divTableauthtypeinfo_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavTypeauthtype_Internalname,(string)"Type Auth Type",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         TempTags = " " + ((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 71,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
         if ( ( cmbavTypeauthtype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_59_idx;
            cmbavTypeauthtype.Name = GXCCtl;
            cmbavTypeauthtype.WebTags = "";
            cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
            cmbavTypeauthtype.addItem("Custom", "Custom", 0);
            cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
            cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
            cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
            cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
            cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
            cmbavTypeauthtype.addItem("Google", "Google", 0);
            cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
            cmbavTypeauthtype.addItem("OTP", "One Time Password", 0);
            cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
            cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
            cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
            if ( cmbavTypeauthtype.ItemCount > 0 )
            {
               AV35TypeAuthType = cmbavTypeauthtype.getValidValue(AV35TypeAuthType);
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV35TypeAuthType);
            }
         }
         /* ComboBox */
         GridauthtypesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTypeauthtype,(string)cmbavTypeauthtype_Internalname,StringUtil.RTrim( AV35TypeAuthType),(short)1,(string)cmbavTypeauthtype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)1,cmbavTypeauthtype.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,71);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV35TypeAuthType);
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Values", (string)(cmbavTypeauthtype.ToJavascriptSource()), !bGXsfl_59_Refreshing);
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,(string)"Name Auth Type",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 75,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
         ROClassString = "Attribute";
         GridauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV36NameAuthType),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,75);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)59,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"left",(bool)true,(string)""});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3A2( ) ;
         /* End of Columns property logic. */
         GridauthtypesContainer.AddRow(GridauthtypesRow);
         nGXsfl_59_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_59_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         /* End function sendrow_592 */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV21LogOnTo = cmbavLogonto.getValidValue(AV21LogOnTo);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "Keep me signed in";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "Remember Me";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV22RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RememberMe));
         AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
         GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_59_idx;
         cmbavTypeauthtype.Name = GXCCtl;
         cmbavTypeauthtype.WebTags = "";
         cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
         cmbavTypeauthtype.addItem("Custom", "Custom", 0);
         cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
         cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
         cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
         cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
         cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
         cmbavTypeauthtype.addItem("Google", "Google", 0);
         cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
         cmbavTypeauthtype.addItem("OTP", "One Time Password", 0);
         cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
         cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
         cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
         if ( cmbavTypeauthtype.ItemCount > 0 )
         {
            AV35TypeAuthType = cmbavTypeauthtype.getValidValue(AV35TypeAuthType);
            AssignAttri("", false, cmbavTypeauthtype_Internalname, AV35TypeAuthType);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         imgavLogoappclient_Internalname = "vLOGOAPPCLIENT";
         lblTbappname_Internalname = "TBAPPNAME";
         cmbavLogonto_Internalname = "vLOGONTO";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         chkavRememberme_Internalname = "vREMEMBERME";
         bttLogin_Internalname = "LOGIN";
         lblTbforgotpwd_Internalname = "TBFORGOTPWD";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE";
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         divTableauthtypeinfo_Internalname = "TABLEAUTHTYPEINFO";
         divGridauthtypestable1_Internalname = "GRIDAUTHTYPESTABLE1";
         divTablebuttons_Internalname = "TABLEBUTTONS";
         divTbllogin_Internalname = "TBLLOGIN";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridauthtypes_Internalname = "GRIDAUTHTYPES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavRememberme.Caption = "";
         chkavKeepmeloggedin.Caption = "";
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Visible = 1;
         cmbavTypeauthtype_Jsonclick = "";
         cmbavTypeauthtype.Visible = 1;
         divTableauthtypeinfo_Visible = 1;
         edtavImageauthtype_Jsonclick = "";
         edtavImageauthtype_Visible = 1;
         edtavImageauthtype_Enabled = 1;
         subGridauthtypes_Class = "FreeStyleGrid";
         subGridauthtypes_Allowcollapsing = 0;
         edtavNameauthtype_Enabled = 1;
         cmbavTypeauthtype.Enabled = 1;
         edtavImageauthtype_Tooltiptext = "";
         subGridauthtypes_Backcolorstyle = 0;
         subGridauthtypes_Visible = 1;
         divTablebuttons_Visible = 1;
         lblTbforgotpwd_Visible = 1;
         bttLogin_Caption = "SIGN IN";
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Invitemessage = "Password";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         lblTbappname_Caption = "App Name";
         lblTbappname_Visible = 1;
         imgavLogoappclient_Visible = 1;
         divTbllogin_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDAUTHTYPES_nEOF'},{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV18Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV37AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV30UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGridauthtypes_Visible',ctrl:'GRIDAUTHTYPES',prop:'Visible'},{av:'divTableauthtypeinfo_Visible',ctrl:'TABLEAUTHTYPEINFO',prop:'Visible'},{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'divTbllogin_Visible',ctrl:'TBLLOGIN',prop:'Visible'},{av:'cmbavLogonto'},{av:'AV21LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV28UserName',fld:'vUSERNAME',pic:''},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblTbforgotpwd_Visible',ctrl:'TBFORGOTPWD',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("GRIDAUTHTYPES.LOAD","{handler:'E163A2',iparms:[{av:'divTablebuttons_Visible',ctrl:'TABLEBUTTONS',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("GRIDAUTHTYPES.LOAD",",oparms:[{av:'AV34ImageAuthType',fld:'vIMAGEAUTHTYPE',pic:''},{av:'cmbavTypeauthtype'},{av:'AV35TypeAuthType',fld:'vTYPEAUTHTYPE',pic:''},{av:'AV36NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'edtavImageauthtype_Tooltiptext',ctrl:'vIMAGEAUTHTYPE',prop:'Tooltiptext'},{av:'divTablebuttons_Visible',ctrl:'TABLEBUTTONS',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("VLOGONTO.CLICK","{handler:'E123A2',iparms:[{av:'AV18Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavLogonto'},{av:'AV21LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("VLOGONTO.CLICK",",oparms:[{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavUserpassword_Invitemessage',ctrl:'vUSERPASSWORD',prop:'Invitemessage'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblTbforgotpwd_Visible',ctrl:'TBFORGOTPWD',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E133A2',iparms:[{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'cmbavLogonto'},{av:'AV21LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV28UserName',fld:'vUSERNAME',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'FORGOTPASSWORD'","{handler:'E113A1',iparms:[{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'FORGOTPASSWORD'",",oparms:[{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E173A2',iparms:[{av:'AV36NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV13IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV28UserName',fld:'vUSERNAME',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("VALIDV_TYPEAUTHTYPE","{handler:'Validv_Typeauthtype',iparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("VALIDV_TYPEAUTHTYPE",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Nameauthtype',iparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
         wcpOAV13IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV18Language = "";
         AV37AuxUserName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblock1_Jsonclick = "";
         AV20LogoAppClient = "";
         AV40Logoappclient_GXI = "";
         sImgUrl = "";
         lblTbappname_Jsonclick = "";
         TempTags = "";
         AV21LogOnTo = "";
         AV28UserName = "";
         AV29UserPassword = "";
         bttLogin_Jsonclick = "";
         lblTbforgotpwd_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridauthtypes_Header = "";
         GridauthtypesColumn = new GXWebColumn();
         AV34ImageAuthType = "";
         AV35TypeAuthType = "";
         AV36NameAuthType = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV44Imageauthtype_GXI = "";
         AV24RepositoryGUID = "";
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV31GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV11ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV25Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV27URL = "";
         AV7AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         GridauthtypesRow = new GXWebRow();
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV32GAMProperties = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty>( context, "GeneXus.Programs.genexussecurity.SdtGAMProperty", "GeneXus.Programs");
         AV23Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV9Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridauthtypes_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         edtavNameauthtype_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV30UserRememberMe ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridauthtypes_Backcolorstyle ;
      private short subGridauthtypes_Allowselection ;
      private short subGridauthtypes_Allowhovering ;
      private short subGridauthtypes_Allowcollapsing ;
      private short subGridauthtypes_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GRIDAUTHTYPES_nEOF ;
      private short nGXWrapped ;
      private short subGridauthtypes_Backstyle ;
      private int divTablebuttons_Visible ;
      private int nRC_GXsfl_59 ;
      private int nGXsfl_59_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int divTbllogin_Visible ;
      private int imgavLogoappclient_Visible ;
      private int lblTbappname_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int lblTbforgotpwd_Visible ;
      private int subGridauthtypes_Visible ;
      private int subGridauthtypes_Selectedindex ;
      private int subGridauthtypes_Selectioncolor ;
      private int subGridauthtypes_Hoveringcolor ;
      private int subGridauthtypes_Islastpage ;
      private int divTableauthtypeinfo_Visible ;
      private int AV41GXV1 ;
      private int AV42GXV2 ;
      private int AV43GXV3 ;
      private int AV45GXV4 ;
      private int AV46GXV5 ;
      private int idxLst ;
      private int subGridauthtypes_Backcolor ;
      private int subGridauthtypes_Allbackcolor ;
      private int edtavImageauthtype_Enabled ;
      private int edtavImageauthtype_Visible ;
      private int edtavNameauthtype_Visible ;
      private long GRIDAUTHTYPES_nCurrentRecord ;
      private long GRIDAUTHTYPES_nFirstRecordOnPage ;
      private string AV13IDP_State ;
      private string wcpOAV13IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_59_idx="0001" ;
      private string AV18Language ;
      private string cmbavTypeauthtype_Internalname ;
      private string edtavNameauthtype_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTbllogin_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sImgUrl ;
      private string imgavLogoappclient_Internalname ;
      private string lblTbappname_Internalname ;
      private string lblTbappname_Caption ;
      private string lblTbappname_Jsonclick ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string AV21LogOnTo ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV29UserPassword ;
      private string edtavUserpassword_Invitemessage ;
      private string edtavUserpassword_Jsonclick ;
      private string chkavKeepmeloggedin_Internalname ;
      private string chkavRememberme_Internalname ;
      private string bttLogin_Internalname ;
      private string bttLogin_Caption ;
      private string bttLogin_Jsonclick ;
      private string lblTbforgotpwd_Internalname ;
      private string lblTbforgotpwd_Jsonclick ;
      private string divTablebuttons_Internalname ;
      private string lblTbexternalauthentication_Internalname ;
      private string lblTbexternalauthentication_Jsonclick ;
      private string sStyleString ;
      private string subGridauthtypes_Internalname ;
      private string subGridauthtypes_Header ;
      private string edtavImageauthtype_Tooltiptext ;
      private string AV35TypeAuthType ;
      private string AV36NameAuthType ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavImageauthtype_Internalname ;
      private string AV24RepositoryGUID ;
      private string divTableauthtypeinfo_Internalname ;
      private string sGXsfl_59_fel_idx="0001" ;
      private string subGridauthtypes_Class ;
      private string subGridauthtypes_Linesclass ;
      private string divGridauthtypestable1_Internalname ;
      private string edtavImageauthtype_Jsonclick ;
      private string GXCCtl ;
      private string cmbavTypeauthtype_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17KeepMeLoggedIn ;
      private bool AV22RememberMe ;
      private bool bGXsfl_59_Refreshing=false ;
      private bool wbLoad ;
      private bool AV20LogoAppClient_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14isConnectionOK ;
      private bool gx_refresh_fired ;
      private bool AV16isRedirect ;
      private bool AV26SessionValid ;
      private bool AV15isOK ;
      private bool AV33isModeOTP ;
      private bool AV19LoginOK ;
      private bool AV34ImageAuthType_IsBlob ;
      private string AV37AuxUserName ;
      private string AV40Logoappclient_GXI ;
      private string AV28UserName ;
      private string AV44Imageauthtype_GXI ;
      private string AV27URL ;
      private string AV20LogoAppClient ;
      private string AV34ImageAuthType ;
      private GXWebGrid GridauthtypesContainer ;
      private GXWebRow GridauthtypesRow ;
      private GXWebColumn GridauthtypesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private GXCombobox cmbavTypeauthtype ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV32GAMProperties ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV7AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV8ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11ErrorsLogin ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV9Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV12GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV23Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV25Session ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV31GAMApplication ;
   }

}
