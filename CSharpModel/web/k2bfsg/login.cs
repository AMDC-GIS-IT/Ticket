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
   public class login : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public login( )
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

      public login( IGxContext context )
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
         cmbavTypeauthtype = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridauthtypes") == 0 )
            {
               nRC_GXsfl_27 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."));
               nGXsfl_27_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."));
               sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
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
               cmbavLogonto.FromJSonString( GetNextPar( ));
               AV47LogOnTo = GetPar( "LogOnTo");
               AV59UserName = GetPar( "UserName");
               AV61UserRememberMe = (short)(NumberUtil.Val( GetPar( "UserRememberMe"), "."));
               AV55ShowDetailedMessages = StringUtil.StrToBool( GetPar( "ShowDetailedMessages"));
               AV8AmountOfCharacters = (short)(NumberUtil.Val( GetPar( "AmountOfCharacters"), "."));
               AV69LogOnToDefault = GetPar( "LogOnToDefault");
               AV42KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
               AV50RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridauthtypes_refresh( AV47LogOnTo, AV59UserName, AV61UserRememberMe, AV55ShowDetailedMessages, AV8AmountOfCharacters, AV69LogOnToDefault, AV42KeepMeLoggedIn, AV50RememberMe) ;
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
         PA3R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188181415", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BFormLogin\" data-gx-class=\"form-horizontal K2BFormLogin\" novalidate action=\""+formatLink("k2bfsg.login.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV55ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69LogOnToDefault, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV55ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV55ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8AmountOfCharacters), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONCLIENTID", StringUtil.RTrim( AV10ApplicationClientId));
         GxWebStd.gx_hidden_field( context, "vURL", AV58URL);
         GxWebStd.gx_hidden_field( context, "vLOGONTODEFAULT", StringUtil.RTrim( AV69LogOnToDefault));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69LogOnToDefault, "")), context));
         GxWebStd.gx_hidden_field( context, "EXTERNALAUTHENTICATIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divExternalauthentications_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXTERNALAUTHENTICATIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divExternalauthentications_Visible), 5, 0, ".", "")));
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
            WE3R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3R2( ) ;
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
         return formatLink("k2bfsg.login.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.Login" ;
      }

      public override string GetPgmdesc( )
      {
         return "Iniciar sesión" ;
      }

      protected void WB3R0( )
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
            sImgUrl = (string)(context.GetImagePath( "6f7ec616-f723-4ae4-8846-34750a32b74a", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentrepository_Internalname, lblCurrentrepository_Caption, "", "", lblCurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblCurrentrepository_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divExternalauthentications_Internalname, divExternalauthentications_Visible, 0, "px", 0, "px", "TableButtons", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, "Login using", "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridauthtypesContainer.SetIsFreestyle(true);
            GridauthtypesContainer.SetWrapped(nGXWrapped);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"DivS\" data-gxgridid=\"27\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridauthtypes_Internalname, subGridauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
            }
            else
            {
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
               GridauthtypesContainer.AddObjectProperty("Header", subGridauthtypes_Header);
               GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
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
               GridauthtypesColumn.AddObjectProperty("Value", context.convertURL( AV67ImageAuthType));
               GridauthtypesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavImageauthtype_Tooltiptext));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV66NameAuthType));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
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
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV68TypeAuthType));
               GridauthtypesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Visible), 5, 0, ".", "")));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Enabled), 5, 0, ".", "")));
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
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
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
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Ingresar a", "gx-form-item K2BToolsFSGAM_Attribute100WidthLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_27_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV47LogOnTo), 1, cmbavLogonto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsFSGAM_Attribute100Width", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 1, "HLP_K2BFSG\\Login.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV47LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV59UserName, StringUtil.RTrim( context.localUtil.Format( AV59UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Nombre de usuario o correo electrónico", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\Login.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV60UserPassword), StringUtil.RTrim( context.localUtil.Format( AV60UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Contraseña", edtavUserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_K2BFSG\\Login.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavForgotpassword_action_Internalname, StringUtil.RTrim( AV31ForgotPassword_Action), StringUtil.RTrim( context.localUtil.Format( AV31ForgotPassword_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+"e113r1_client"+"'", "", "", "", "", edtavForgotpassword_action_Jsonclick, 7, "TextBlock_FloatRight", "", "", "", "", 1, edtavForgotpassword_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCreateanaccount_action_Internalname, "Create An Account_Action", "col-sm-3 TextBlock_FloatRightLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCreateanaccount_action_Internalname, StringUtil.RTrim( AV25CreateAnAccount_Action), StringUtil.RTrim( context.localUtil.Format( AV25CreateAnAccount_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+"e123r1_client"+"'", "", "", "", "", edtavCreateanaccount_action_Jsonclick, 7, "TextBlock_FloatRight", "", "", "", "", 1, edtavCreateanaccount_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\Login.htm");
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
            wb_table1_78_3R2( true) ;
         }
         else
         {
            wb_table1_78_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_78_3R2e( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, "Recordarme", "col-sm-3 CheckBoxAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_27_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV50RememberMe), "", "Recordarme", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
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
            wb_table2_92_3R2( true) ;
         }
         else
         {
            wb_table2_92_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_92_3R2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(27), 2, 0)+","+"null"+");", "Iniciar sesión", bttLogin_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\Login.htm");
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
         if ( wbEnd == 27 )
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
                  sStyleString = "";
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

      protected void START3R2( )
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
            Form.Meta.addItem("description", "Iniciar sesión", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3R0( ) ;
      }

      protected void WS3R2( )
      {
         START3R2( ) ;
         EVT3R2( ) ;
      }

      protected void EVT3R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E133R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) )
                           {
                              nGXsfl_27_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              AV67ImageAuthType = cgiGet( edtavImageauthtype_Internalname);
                              AssignProp("", false, edtavImageauthtype_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV67ImageAuthType)) ? AV90Imageauthtype_GXI : context.convertURL( context.PathToRelativeUrl( AV67ImageAuthType))), !bGXsfl_27_Refreshing);
                              AssignProp("", false, edtavImageauthtype_Internalname, "SrcSet", context.GetImageSrcSet( AV67ImageAuthType), true);
                              AV66NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                              AssignAttri("", false, edtavNameauthtype_Internalname, AV66NameAuthType);
                              GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, StringUtil.RTrim( context.localUtil.Format( AV66NameAuthType, "")), context));
                              cmbavTypeauthtype.Name = cmbavTypeauthtype_Internalname;
                              cmbavTypeauthtype.CurrentValue = cgiGet( cmbavTypeauthtype_Internalname);
                              AV68TypeAuthType = cgiGet( cmbavTypeauthtype_Internalname);
                              AssignAttri("", false, cmbavTypeauthtype_Internalname, AV68TypeAuthType);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E143R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E153R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDAUTHTYPES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E163R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SelectAuthenticationType' */
                                    E173R2 ();
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

      protected void WE3R2( )
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

      protected void PA3R2( )
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
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_27_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridauthtypesContainer)) ;
         /* End function gxnrGridauthtypes_newrow */
      }

      protected void gxgrGridauthtypes_refresh( string AV47LogOnTo ,
                                                string AV59UserName ,
                                                short AV61UserRememberMe ,
                                                bool AV55ShowDetailedMessages ,
                                                short AV8AmountOfCharacters ,
                                                string AV69LogOnToDefault ,
                                                bool AV42KeepMeLoggedIn ,
                                                bool AV50RememberMe )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E153R2 ();
         GRIDAUTHTYPES_nCurrentRecord = 0;
         RF3R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV66NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV66NameAuthType));
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
            AV47LogOnTo = cmbavLogonto.getValidValue(AV47LogOnTo);
            AssignAttri("", false, "AV47LogOnTo", AV47LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV47LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV42KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV42KeepMeLoggedIn));
         AssignAttri("", false, "AV42KeepMeLoggedIn", AV42KeepMeLoggedIn);
         AV50RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV50RememberMe));
         AssignAttri("", false, "AV50RememberMe", AV50RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavForgotpassword_action_Enabled = 0;
         AssignProp("", false, edtavForgotpassword_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavForgotpassword_action_Enabled), 5, 0), true);
         edtavCreateanaccount_action_Enabled = 0;
         AssignProp("", false, edtavCreateanaccount_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCreateanaccount_action_Enabled), 5, 0), true);
      }

      protected void RF3R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridauthtypesContainer.ClearRows();
         }
         wbStart = 27;
         /* Execute user event: Refresh */
         E153R2 ();
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
         GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
         GridauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
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
            SubsflControlProps_272( ) ;
            E163R2 ();
            wbEnd = 27;
            WB3R0( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3R2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV55ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV55ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vLOGONTODEFAULT", StringUtil.RTrim( AV69LogOnToDefault));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69LogOnToDefault, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, StringUtil.RTrim( context.localUtil.Format( AV66NameAuthType, "")), context));
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
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavForgotpassword_action_Enabled = 0;
         AssignProp("", false, edtavForgotpassword_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavForgotpassword_action_Enabled), 5, 0), true);
         edtavCreateanaccount_action_Enabled = 0;
         AssignProp("", false, edtavCreateanaccount_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCreateanaccount_action_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), ".", ","));
            divExternalauthentications_Visible = (int)(context.localUtil.CToN( cgiGet( "EXTERNALAUTHENTICATIONS_Visible"), ".", ","));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV47LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV47LogOnTo", AV47LogOnTo);
            AV59UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV59UserName", AV59UserName);
            AV60UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV60UserPassword", AV60UserPassword);
            AV31ForgotPassword_Action = cgiGet( edtavForgotpassword_action_Internalname);
            AssignAttri("", false, "AV31ForgotPassword_Action", AV31ForgotPassword_Action);
            AV25CreateAnAccount_Action = cgiGet( edtavCreateanaccount_action_Internalname);
            AssignAttri("", false, "AV25CreateAnAccount_Action", AV25CreateAnAccount_Action);
            AV42KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV42KeepMeLoggedIn", AV42KeepMeLoggedIn);
            AV50RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV50RememberMe", AV50RememberMe);
            AV17CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV21CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV21CaptchaText", AV21CaptchaText);
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
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV8AmountOfCharacters, out  AV9AmountOfFailedLogins, out  AV13BadLoginsExpire, out  AV54ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV8AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV8AmountOfCharacters), 4, 0));
         Form.Class = "K2BFormLogin";
         AssignProp("", false, "FORM", "Class", Form.Class, true);
         lblCurrentrepository_Visible = 0;
         AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         AV40isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AV23ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
         if ( ! AV40isOK )
         {
            if ( AV23ConnectionInfoCollection.Count > 0 )
            {
               AV40isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV23ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV29Errors);
            }
         }
         if ( AV23ConnectionInfoCollection.Count > 1 )
         {
            AV64GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            lblCurrentrepository_Caption = "Repositorio:"+AV64GAMRepository.gxTpr_Name;
            AssignProp("", false, lblCurrentrepository_Internalname, "Caption", lblCurrentrepository_Caption, true);
            lblCurrentrepository_Visible = 1;
            AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         }
         cmbavLogonto.removeAllItems();
         divExternalauthentications_Visible = 0;
         AssignProp("", false, divExternalauthentications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divExternalauthentications_Visible), 5, 0), true);
         AV12AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV43Language, out  AV29Errors);
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV12AuthenticationTypes.Count )
         {
            AV11AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV12AuthenticationTypes.Item(AV85GXV1));
            if ( AV11AuthenticationType.gxTpr_Needusername )
            {
               cmbavLogonto.addItem(AV11AuthenticationType.gxTpr_Name, AV11AuthenticationType.gxTpr_Description, 0);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         if ( cmbavLogonto.ItemCount <= 1 )
         {
            cmbavLogonto.Visible = 0;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
         }
         AV51Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( cmbavLogonto.ItemCount > 1 )
         {
            AV47LogOnTo = AV51Repository.gxTpr_Defaultauthenticationtypename;
            AssignAttri("", false, "AV47LogOnTo", AV47LogOnTo);
            AV69LogOnToDefault = AV51Repository.gxTpr_Defaultauthenticationtypename;
            AssignAttri("", false, "AV69LogOnToDefault", AV69LogOnToDefault);
            GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69LogOnToDefault, "")), context));
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV23ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
         if ( ( AV23ConnectionInfoCollection.Count > 0 ) && (0==new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getid()) )
         {
            new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV23ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV29Errors) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E143R2 ();
         if (returnInSub) return;
      }

      protected void E143R2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E153R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV31ForgotPassword_Action = "Olvidó su contraseña";
         AssignAttri("", false, "AV31ForgotPassword_Action", AV31ForgotPassword_Action);
         AV25CreateAnAccount_Action = "Crear cuenta";
         AssignAttri("", false, "AV25CreateAnAccount_Action", AV25CreateAnAccount_Action);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S172 ();
         if (returnInSub) return;
         AV41isRedirect = false;
         AV30ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV30ErrorsLogin.Count > 0 )
         {
            AV60UserPassword = "";
            AssignAttri("", false, "AV60UserPassword", AV60UserPassword);
            AV29Errors = AV30ErrorsLogin;
         }
         /* Execute user subroutine: 'DISPLAYMESSAGES' */
         S182 ();
         if (returnInSub) return;
         if ( ! AV41isRedirect )
         {
            AV53SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV52Session, out  AV29Errors);
            if ( AV53SessionValid && ! AV52Session.gxTpr_Isanonymous )
            {
               AV58URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               AssignAttri("", false, "AV58URL", AV58URL);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58URL)) )
               {
                  new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV47LogOnTo,  AV59UserName) ;
                  /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
                  S192 ();
                  if (returnInSub) return;
                  new GeneXus.Programs.k2bfsg.updatecontextafterlogin(context ).execute( ) ;
                  CallWebObject(formatLink("k2bfsg.applicationhome.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV47LogOnTo,  AV59UserName) ;
                  /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
                  S192 ();
                  if (returnInSub) return;
                  new GeneXus.Programs.k2bfsg.updatecontextafterlogin(context ).execute( ) ;
                  CallWebObject(formatLink(AV58URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV47LogOnTo, out  AV59UserName, out  AV61UserRememberMe, out  AV29Errors) ;
               if ( AV61UserRememberMe == 2 )
               {
                  AV50RememberMe = true;
                  AssignAttri("", false, "AV50RememberMe", AV50RememberMe);
               }
               chkavRememberme.Visible = 0;
               AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               chkavKeepmeloggedin.Visible = 0;
               AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               if ( StringUtil.StrCmp(AV51Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV51Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV51Repository.gxTpr_Userremembermetype, "Both") == 0 )
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
         E133R2 ();
         if (returnInSub) return;
      }

      protected void E133R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_LOGIN' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7AdditionalParameter", AV7AdditionalParameter);
      }

      protected void S142( )
      {
         /* 'U_LOGIN' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VARIABLEDESESION' */
         S202 ();
         if (returnInSub) return;
         GXt_char1 = AV58URL;
         new k2bsessionget(context ).execute(  "SessionCaptchaRedirectURL", out  GXt_char1) ;
         AV58URL = GXt_char1;
         AssignAttri("", false, "AV58URL", AV58URL);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58URL)) )
         {
            AV58URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            AssignAttri("", false, "AV58URL", AV58URL);
         }
         GXt_boolean2 = AV39IncorrectLoginsExisted;
         new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV47LogOnTo,  AV59UserName, out  GXt_boolean2) ;
         AV39IncorrectLoginsExisted = GXt_boolean2;
         if ( AV39IncorrectLoginsExisted )
         {
            GXt_boolean2 = AV18CaptchaIsCorrect;
            new GeneXus.Programs.k2bfsg.evaluatecaptchacorrectness(context ).execute(  AV21CaptchaText, out  GXt_boolean2) ;
            AV18CaptchaIsCorrect = GXt_boolean2;
            if ( AV18CaptchaIsCorrect )
            {
               /* Execute user subroutine: 'PROCESSLOGIN' */
               S212 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'ACTIVATECAPTCHA' */
               S222 ();
               if (returnInSub) return;
               CallWebObject(formatLink("k2bfsg.login.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            /* Execute user subroutine: 'PROCESSLOGIN' */
            S212 ();
            if (returnInSub) return;
         }
      }

      protected void S212( )
      {
         /* 'PROCESSLOGIN' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV8AmountOfCharacters, out  AV9AmountOfFailedLogins, out  AV13BadLoginsExpire, out  AV54ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV8AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV8AmountOfCharacters), 4, 0));
         if ( AV42KeepMeLoggedIn )
         {
            AV7AdditionalParameter.gxTpr_Rememberusertype = (short)((AV42KeepMeLoggedIn ? 3 : 1));
         }
         else
         {
            if ( AV50RememberMe )
            {
               AV7AdditionalParameter.gxTpr_Rememberusertype = (short)((AV50RememberMe ? 2 : 1));
            }
            else
            {
               AV7AdditionalParameter.gxTpr_Rememberusertype = 1;
            }
         }
         AV7AdditionalParameter.gxTpr_Authenticationtypename = AV47LogOnTo;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV16CaptchaActive) ;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV20CaptchaRequiredText) ;
         AV46LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV59UserName, AV60UserPassword, AV7AdditionalParameter, out  AV29Errors);
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  AV16CaptchaActive) ;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV20CaptchaRequiredText) ;
         if ( ! AV46LoginOK )
         {
            if ( AV29Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10ApplicationClientId))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  new GeneXus.Programs.k2bfsg.saveincorrectlogin(context ).execute(  AV47LogOnTo,  AV59UserName) ;
                  if ( AV9AmountOfFailedLogins == 1 )
                  {
                     /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                     S222 ();
                     if (returnInSub) return;
                  }
                  else
                  {
                     GXt_boolean2 = AV39IncorrectLoginsExisted;
                     new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV47LogOnTo,  AV59UserName, out  GXt_boolean2) ;
                     AV39IncorrectLoginsExisted = GXt_boolean2;
                     if ( AV39IncorrectLoginsExisted )
                     {
                        /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                        S222 ();
                        if (returnInSub) return;
                     }
                  }
                  CallWebObject(formatLink("k2bfsg.login.aspx") );
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         else
         {
            new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV47LogOnTo,  AV59UserName) ;
            /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
            S192 ();
            if (returnInSub) return;
            new GeneXus.Programs.k2bfsg.updatecontextafterlogin(context ).execute( ) ;
            /* Execute user subroutine: 'VARIABLEDESESION' */
            S202 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58URL)) )
            {
               CallWebObject(formatLink("k2bfsg.applicationhome.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink(AV58URL) );
               context.wjLocDisableFrm = 0;
            }
         }
      }

      protected void S182( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV20CaptchaRequiredText) ;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV55ShowDetailedMessages) ;
         AssignAttri("", false, "AV55ShowDetailedMessages", AV55ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV55ShowDetailedMessages, context));
         AV28ErrorCount = 0;
         AV86GXV2 = 1;
         while ( AV86GXV2 <= AV29Errors.Count )
         {
            AV27Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(AV86GXV2));
            if ( AV27Error.gxTpr_Code == 104 )
            {
               new k2btoolsmsg(context ).execute(  AV27Error.gxTpr_Message,  2) ;
            }
            else
            {
               AV28ErrorCount = (short)(AV28ErrorCount+1);
            }
            AV86GXV2 = (int)(AV86GXV2+1);
         }
         if ( ( AV28ErrorCount > 0 ) || ( StringUtil.StrCmp(AV20CaptchaRequiredText, "true") == 0 ) )
         {
            new k2btoolsmsg(context ).execute(  "Usuario o contraseña incorrectos",  2) ;
         }
         if ( AV55ShowDetailedMessages )
         {
            AV87GXV3 = 1;
            while ( AV87GXV3 <= AV29Errors.Count )
            {
               AV27Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(AV87GXV3));
               if ( AV27Error.gxTpr_Code != 13 )
               {
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV27Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV27Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  new k2btoolsmsg(context ).execute(  StringUtil.Format( "%1 (GAM%2)", AV27Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV27Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""),  2) ;
               }
               AV87GXV3 = (int)(AV87GXV3+1);
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
      }

      protected void S222( )
      {
         /* 'ACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "true") ;
         new k2bsessionset(context ).execute(  "SessionCaptchaRedirectURL",  AV58URL) ;
      }

      protected void S192( )
      {
         /* 'DEACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "false") ;
      }

      protected void S232( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV19CaptchaProvider.generatestringtoken(AV8AmountOfCharacters)) ;
      }

      protected void S172( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV20CaptchaRequiredText) ;
         if ( StringUtil.StrCmp(AV20CaptchaRequiredText, "true") == 0 )
         {
            /* Execute user subroutine: 'CREATENEWCAPTCHA' */
            S232 ();
            if (returnInSub) return;
            new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV20CaptchaRequiredText) ;
            lblCaptchadescription_Visible = 1;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 1;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 1;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV14Base64String = AV19CaptchaProvider.generateimage(180, 75, AV20CaptchaRequiredText);
            AV17CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV14Base64String;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17CaptchaImage)) ? AV88Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV17CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV17CaptchaImage), true);
            AV88Captchaimage_GXI = GXDbFile.PathToUrl( "data:image/jpeg;charset=utf-8;base64,"+AV14Base64String);
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17CaptchaImage)) ? AV88Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV17CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV17CaptchaImage), true);
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

      private void E163R2( )
      {
         /* Gridauthtypes_Load Routine */
         returnInSub = false;
         AV47LogOnTo = AV69LogOnToDefault;
         AssignAttri("", false, "AV47LogOnTo", AV47LogOnTo);
         cmbavTypeauthtype.Visible = 0;
         AV89GXV4 = 1;
         while ( AV89GXV4 <= AV12AuthenticationTypes.Count )
         {
            AV11AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV12AuthenticationTypes.Item(AV89GXV4));
            if ( ! AV11AuthenticationType.gxTpr_Needusername )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11AuthenticationType.gxTpr_Smallimagename)) )
               {
                  AV67ImageAuthType = context.GetImagePath( AV11AuthenticationType.gxTpr_Smallimagename, "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV67ImageAuthType);
                  AV90Imageauthtype_GXI = GXDbFile.PathToUrl( AV11AuthenticationType.gxTpr_Smallimagename);
               }
               else
               {
                  AV67ImageAuthType = context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV67ImageAuthType);
                  AV90Imageauthtype_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( )));
               }
               AV68TypeAuthType = AV11AuthenticationType.gxTpr_Type;
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV68TypeAuthType);
               AV66NameAuthType = StringUtil.Trim( AV11AuthenticationType.gxTpr_Name);
               AssignAttri("", false, edtavNameauthtype_Internalname, AV66NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, StringUtil.RTrim( context.localUtil.Format( AV66NameAuthType, "")), context));
               edtavImageauthtype_Tooltiptext = StringUtil.Format( "Sign in with %1", StringUtil.Trim( AV11AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               if ( divExternalauthentications_Visible == 0 )
               {
                  divExternalauthentications_Visible = 1;
                  AssignProp("", false, divExternalauthentications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divExternalauthentications_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 27;
               }
               sendrow_272( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
               {
                  context.DoAjaxLoad(27, GridauthtypesRow);
               }
            }
            AV89GXV4 = (int)(AV89GXV4+1);
         }
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV47LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV68TypeAuthType);
      }

      protected void E173R2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         AV7AdditionalParameter.gxTpr_Authenticationtypename = AV66NameAuthType;
         AV46LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV59UserName, AV60UserPassword, AV7AdditionalParameter, out  AV29Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7AdditionalParameter", AV7AdditionalParameter);
      }

      protected void S202( )
      {
         /* 'VARIABLEDESESION' Routine */
         returnInSub = false;
         new prcgetdatosusuario(context ).execute(  AV59UserName, out  AV70UsuarioSistemaIdentidad, out  AV71UsuarioSistemaNombre, out  AV77UsuarioSistemaGerencia, out  AV78UsuarioSistemaDepartamento, out  AV79UsuarioSistemaEmail, out  AV81UsuarioSistemaTelefono) ;
         AV62WebSession.Set("IdentidadUsuario", AV70UsuarioSistemaIdentidad);
         AV62WebSession.Set("NombreUsuario", AV71UsuarioSistemaNombre);
         AV62WebSession.Set("UsuarioConectado", StringUtil.Lower( AV59UserName));
         AV62WebSession.Set("GerenciaUsuario", AV77UsuarioSistemaGerencia);
         AV62WebSession.Set("DepartamentoUsuario", AV78UsuarioSistemaDepartamento);
         AV62WebSession.Set("TelefonoUsuario", StringUtil.Str( (decimal)(AV81UsuarioSistemaTelefono), 9, 0));
         AV62WebSession.Set("EmailUsuario", AV79UsuarioSistemaEmail);
         new prcgettecnicoid(context ).execute(  AV59UserName, out  AV72ResponsableId, out  AV73ResponsableIdentidad, out  AV75ResponsableNombre, out  AV76ResponsableEmail, out  AV74ResponsableCargo, out  AV82id_unidad_tecnico) ;
         AV62WebSession.Set("IdResponsable", StringUtil.Str( (decimal)(AV72ResponsableId), 4, 0));
         AV62WebSession.Set("IdentidadResponsable", AV73ResponsableIdentidad);
         AV62WebSession.Set("NombreResponsable", AV75ResponsableNombre);
         AV62WebSession.Set("EmailResponsable", AV76ResponsableEmail);
         AV62WebSession.Set("CargoResponsable", AV74ResponsableCargo);
         AV62WebSession.Set("UsuarioSistema", StringUtil.Lower( AV59UserName));
         AV62WebSession.Set("id_unidad_tecnico", StringUtil.Str( (decimal)(AV82id_unidad_tecnico), 9, 0));
      }

      protected void wb_table2_92_3R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "K2BFSGTable_CAPTCHAContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, "Por favor, ingrese el texto abajo", "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            AV17CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV17CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV88Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV17CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17CaptchaImage)) ? AV88Captchaimage_GXI : context.PathToRelativeUrl( AV17CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV17CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV21CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV21CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "K2BFSG_CAPTCHAField", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 10, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "K2BDescription", "left", true, "", "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_92_3R2e( true) ;
         }
         else
         {
            wb_table2_92_3R2e( false) ;
         }
      }

      protected void wb_table1_78_3R2( bool wbgen )
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
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, "Keep me Logged In", "gx-form-item CheckBoxAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_27_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV42KeepMeLoggedIn), "", "Keep me Logged In", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_keepmeloggedin_Internalname, "Mantenerme conectado", "", "", lblTextblock_var_keepmeloggedin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_78_3R2e( true) ;
         }
         else
         {
            wb_table1_78_3R2e( false) ;
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
         PA3R2( ) ;
         WS3R2( ) ;
         WE3R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188185165", true, true);
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
         context.AddJavascriptSource("k2bfsg/login.js", "?2024188185170", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_27_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_27_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_272( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_27_fel_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_27_fel_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_27_fel_idx;
      }

      protected void sendrow_272( )
      {
         SubsflControlProps_272( ) ;
         WB3R0( ) ;
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
            if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subGridauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_27_idx+"\">") ;
         }
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridauthtypestable1_Internalname+"_"+sGXsfl_27_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Image Auth Type",(string)"col-sm-3 Fixed30Label",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavImageauthtype_Enabled!=0)&&(edtavImageauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'',false,'',27)\"" : " ");
         ClassString = "Fixed30";
         StyleString = "";
         AV67ImageAuthType_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV67ImageAuthType))&&String.IsNullOrEmpty(StringUtil.RTrim( AV90Imageauthtype_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV67ImageAuthType)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV67ImageAuthType)) ? AV90Imageauthtype_GXI : context.PathToRelativeUrl( AV67ImageAuthType));
         GridauthtypesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImageauthtype_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)edtavImageauthtype_Tooltiptext,(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavImageauthtype_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_27_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV67ImageAuthType_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
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
         TempTags = " " + ((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 36,'',false,'"+sGXsfl_27_idx+"',27)\"" : " ");
         ROClassString = "Attribute";
         GridauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV66NameAuthType),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,36);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_27_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"left",(bool)true,(string)""});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divSection1_Internalname+"_"+sGXsfl_27_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section_Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavTypeauthtype_Internalname,(string)"Type Auth Type",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         TempTags = " " + ((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 41,'',false,'"+sGXsfl_27_idx+"',27)\"" : " ");
         if ( ( cmbavTypeauthtype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_27_idx;
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
               AV68TypeAuthType = cmbavTypeauthtype.getValidValue(AV68TypeAuthType);
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV68TypeAuthType);
            }
         }
         /* ComboBox */
         GridauthtypesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTypeauthtype,(string)cmbavTypeauthtype_Internalname,StringUtil.RTrim( AV68TypeAuthType),(short)1,(string)cmbavTypeauthtype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavTypeauthtype.Visible,cmbavTypeauthtype.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,41);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV68TypeAuthType);
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Values", (string)(cmbavTypeauthtype.ToJavascriptSource()), !bGXsfl_27_Refreshing);
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3R2( ) ;
         /* End of Columns property logic. */
         GridauthtypesContainer.AddRow(GridauthtypesRow);
         nGXsfl_27_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_27_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         /* End function sendrow_272 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_27_idx;
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
            AV68TypeAuthType = cmbavTypeauthtype.getValidValue(AV68TypeAuthType);
            AssignAttri("", false, cmbavTypeauthtype_Internalname, AV68TypeAuthType);
         }
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV47LogOnTo = cmbavLogonto.getValidValue(AV47LogOnTo);
            AssignAttri("", false, "AV47LogOnTo", AV47LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV42KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV42KeepMeLoggedIn));
         AssignAttri("", false, "AV42KeepMeLoggedIn", AV42KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV50RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV50RememberMe));
         AssignAttri("", false, "AV50RememberMe", AV50RememberMe);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImage_Internalname = "IMAGE";
         lblCurrentrepository_Internalname = "CURRENTREPOSITORY";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE";
         divSection1_Internalname = "SECTION1";
         divGridauthtypestable1_Internalname = "GRIDAUTHTYPESTABLE1";
         divExternalauthentications_Internalname = "EXTERNALAUTHENTICATIONS";
         cmbavLogonto_Internalname = "vLOGONTO";
         divSection2_Internalname = "SECTION2";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divTable30_Internalname = "TABLE30";
         edtavForgotpassword_action_Internalname = "vFORGOTPASSWORD_ACTION";
         edtavCreateanaccount_action_Internalname = "vCREATEANACCOUNT_ACTION";
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
         chkavRememberme.Caption = "Recordarme";
         chkavKeepmeloggedin.Caption = "Keep me Logged In";
         cmbavTypeauthtype_Jsonclick = "";
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Visible = 1;
         edtavImageauthtype_Jsonclick = "";
         edtavImageauthtype_Visible = 1;
         edtavImageauthtype_Enabled = 1;
         subGridauthtypes_Class = "FreeStyleGrid";
         chkavKeepmeloggedin.Enabled = 1;
         edtavCaptchatext_Jsonclick = "";
         edtavCaptchatext_Enabled = 1;
         lblCaptchadescription_Visible = 1;
         edtavCaptchatext_Visible = 1;
         imgavCaptchaimage_Visible = 1;
         chkavKeepmeloggedin.Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         edtavCreateanaccount_action_Jsonclick = "";
         edtavCreateanaccount_action_Enabled = 1;
         edtavForgotpassword_action_Jsonclick = "";
         edtavForgotpassword_action_Enabled = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         subGridauthtypes_Allowcollapsing = 0;
         cmbavTypeauthtype.Enabled = 1;
         cmbavTypeauthtype.Visible = 1;
         edtavNameauthtype_Enabled = 1;
         edtavImageauthtype_Tooltiptext = "";
         subGridauthtypes_Backcolorstyle = 0;
         divExternalauthentications_Visible = 1;
         lblCurrentrepository_Caption = "Text Block";
         lblCurrentrepository_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Iniciar sesión";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDAUTHTYPES_nEOF'},{av:'cmbavLogonto'},{av:'AV47LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV59UserName',fld:'vUSERNAME',pic:''},{av:'AV8AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV61UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV55ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'AV69LogOnToDefault',fld:'vLOGONTODEFAULT',pic:'',hsh:true},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV31ForgotPassword_Action',fld:'vFORGOTPASSWORD_ACTION',pic:''},{av:'AV25CreateAnAccount_Action',fld:'vCREATEANACCOUNT_ACTION',pic:''},{av:'AV60UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV58URL',fld:'vURL',pic:''},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'AV17CaptchaImage',fld:'vCAPTCHAIMAGE',pic:''},{av:'lblCaptchadescription_Visible',ctrl:'CAPTCHADESCRIPTION',prop:'Visible'},{av:'imgavCaptchaimage_Visible',ctrl:'vCAPTCHAIMAGE',prop:'Visible'},{av:'edtavCaptchatext_Visible',ctrl:'vCAPTCHATEXT',prop:'Visible'},{av:'AV55ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E133R2',iparms:[{av:'cmbavLogonto'},{av:'AV47LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV59UserName',fld:'vUSERNAME',pic:''},{av:'AV21CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV60UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV10ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV58URL',fld:'vURL',pic:''},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV58URL',fld:'vURL',pic:''},{av:'AV8AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV10ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'E_FORGOTPASSWORD'","{handler:'E113R1',iparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'E_FORGOTPASSWORD'",",oparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'E_CREATEANACCOUNT'","{handler:'E123R1',iparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'E_CREATEANACCOUNT'",",oparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("GRIDAUTHTYPES.LOAD","{handler:'E163R2',iparms:[{av:'AV69LogOnToDefault',fld:'vLOGONTODEFAULT',pic:'',hsh:true},{av:'divExternalauthentications_Visible',ctrl:'EXTERNALAUTHENTICATIONS',prop:'Visible'},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("GRIDAUTHTYPES.LOAD",",oparms:[{av:'cmbavLogonto'},{av:'AV47LogOnTo',fld:'vLOGONTO',pic:''},{av:'cmbavTypeauthtype'},{av:'AV67ImageAuthType',fld:'vIMAGEAUTHTYPE',pic:''},{av:'AV68TypeAuthType',fld:'vTYPEAUTHTYPE',pic:''},{av:'AV66NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'edtavImageauthtype_Tooltiptext',ctrl:'vIMAGEAUTHTYPE',prop:'Tooltiptext'},{av:'divExternalauthentications_Visible',ctrl:'EXTERNALAUTHENTICATIONS',prop:'Visible'},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E173R2',iparms:[{av:'AV66NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV59UserName',fld:'vUSERNAME',pic:''},{av:'AV60UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("VALIDV_TYPEAUTHTYPE","{handler:'Validv_Typeauthtype',iparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("VALIDV_TYPEAUTHTYPE",",oparms:[{av:'AV42KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV50RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
         AV47LogOnTo = "";
         AV59UserName = "";
         AV69LogOnToDefault = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10ApplicationClientId = "";
         AV58URL = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblCurrentrepository_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridauthtypes_Header = "";
         GridauthtypesColumn = new GXWebColumn();
         AV67ImageAuthType = "";
         AV66NameAuthType = "";
         AV68TypeAuthType = "";
         TempTags = "";
         AV60UserPassword = "";
         AV31ForgotPassword_Action = "";
         AV25CreateAnAccount_Action = "";
         bttLogin_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV90Imageauthtype_GXI = "";
         AV17CaptchaImage = "";
         AV21CaptchaText = "";
         AV23ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV29Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV64GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV43Language = "";
         AV11AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV51Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV30ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV52Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV7AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         GXt_char1 = "";
         AV16CaptchaActive = "";
         AV20CaptchaRequiredText = "";
         AV27Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV19CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV14Base64String = "";
         AV88Captchaimage_GXI = "";
         GridauthtypesRow = new GXWebRow();
         AV70UsuarioSistemaIdentidad = "";
         AV71UsuarioSistemaNombre = "";
         AV77UsuarioSistemaGerencia = "";
         AV78UsuarioSistemaDepartamento = "";
         AV79UsuarioSistemaEmail = "";
         AV62WebSession = context.GetSession();
         AV73ResponsableIdentidad = "";
         AV75ResponsableNombre = "";
         AV76ResponsableEmail = "";
         AV74ResponsableCargo = "";
         lblCaptchadescription_Jsonclick = "";
         lblTextblock_var_keepmeloggedin_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridauthtypes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavNameauthtype_Enabled = 0;
         cmbavTypeauthtype.Enabled = 0;
         edtavForgotpassword_action_Enabled = 0;
         edtavCreateanaccount_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV61UserRememberMe ;
      private short AV8AmountOfCharacters ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridauthtypes_Backcolorstyle ;
      private short subGridauthtypes_Allowselection ;
      private short subGridauthtypes_Allowhovering ;
      private short subGridauthtypes_Allowcollapsing ;
      private short subGridauthtypes_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV9AmountOfFailedLogins ;
      private short GRIDAUTHTYPES_nEOF ;
      private short AV28ErrorCount ;
      private short AV72ResponsableId ;
      private short nGXWrapped ;
      private short subGridauthtypes_Backstyle ;
      private int divExternalauthentications_Visible ;
      private int nRC_GXsfl_27 ;
      private int nGXsfl_27_idx=1 ;
      private int lblCurrentrepository_Visible ;
      private int edtavNameauthtype_Enabled ;
      private int subGridauthtypes_Selectedindex ;
      private int subGridauthtypes_Selectioncolor ;
      private int subGridauthtypes_Hoveringcolor ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int edtavForgotpassword_action_Enabled ;
      private int edtavCreateanaccount_action_Enabled ;
      private int subGridauthtypes_Islastpage ;
      private int AV85GXV1 ;
      private int AV86GXV2 ;
      private int AV87GXV3 ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int AV89GXV4 ;
      private int AV81UsuarioSistemaTelefono ;
      private int AV82id_unidad_tecnico ;
      private int edtavCaptchatext_Enabled ;
      private int idxLst ;
      private int subGridauthtypes_Backcolor ;
      private int subGridauthtypes_Allbackcolor ;
      private int edtavImageauthtype_Enabled ;
      private int edtavImageauthtype_Visible ;
      private int edtavNameauthtype_Visible ;
      private long GRIDAUTHTYPES_nCurrentRecord ;
      private long GRIDAUTHTYPES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_27_idx="0001" ;
      private string AV47LogOnTo ;
      private string AV69LogOnToDefault ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV10ApplicationClientId ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divContenttable_Internalname ;
      private string divColumns_maincolumnstable_Internalname ;
      private string divTable22_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage_Internalname ;
      private string lblCurrentrepository_Internalname ;
      private string lblCurrentrepository_Caption ;
      private string lblCurrentrepository_Jsonclick ;
      private string divExternalauthentications_Internalname ;
      private string lblTbexternalauthentication_Internalname ;
      private string lblTbexternalauthentication_Jsonclick ;
      private string sStyleString ;
      private string subGridauthtypes_Internalname ;
      private string subGridauthtypes_Header ;
      private string edtavImageauthtype_Tooltiptext ;
      private string AV66NameAuthType ;
      private string AV68TypeAuthType ;
      private string divColumns3_maincolumnstable_Internalname ;
      private string divTable1_Internalname ;
      private string divTable30_Internalname ;
      private string divSection2_Internalname ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV60UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string edtavForgotpassword_action_Internalname ;
      private string AV31ForgotPassword_Action ;
      private string edtavForgotpassword_action_Jsonclick ;
      private string edtavCreateanaccount_action_Internalname ;
      private string AV25CreateAnAccount_Action ;
      private string edtavCreateanaccount_action_Jsonclick ;
      private string divTable5_Internalname ;
      private string chkavRememberme_Internalname ;
      private string bttLogin_Internalname ;
      private string bttLogin_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavImageauthtype_Internalname ;
      private string edtavNameauthtype_Internalname ;
      private string cmbavTypeauthtype_Internalname ;
      private string chkavKeepmeloggedin_Internalname ;
      private string imgavCaptchaimage_Internalname ;
      private string AV21CaptchaText ;
      private string edtavCaptchatext_Internalname ;
      private string AV43Language ;
      private string GXt_char1 ;
      private string AV16CaptchaActive ;
      private string AV20CaptchaRequiredText ;
      private string lblCaptchadescription_Internalname ;
      private string AV14Base64String ;
      private string tblTable4_Internalname ;
      private string lblCaptchadescription_Jsonclick ;
      private string edtavCaptchatext_Jsonclick ;
      private string tblTable2_Internalname ;
      private string lblTextblock_var_keepmeloggedin_Internalname ;
      private string lblTextblock_var_keepmeloggedin_Jsonclick ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string subGridauthtypes_Class ;
      private string subGridauthtypes_Linesclass ;
      private string divGridauthtypestable1_Internalname ;
      private string edtavImageauthtype_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private string divSection1_Internalname ;
      private string GXCCtl ;
      private string cmbavTypeauthtype_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV55ShowDetailedMessages ;
      private bool AV42KeepMeLoggedIn ;
      private bool AV50RememberMe ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_27_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13BadLoginsExpire ;
      private bool AV54ShouldAddSleepOnFailure ;
      private bool AV40isOK ;
      private bool gx_refresh_fired ;
      private bool AV41isRedirect ;
      private bool AV53SessionValid ;
      private bool AV39IncorrectLoginsExisted ;
      private bool AV18CaptchaIsCorrect ;
      private bool AV46LoginOK ;
      private bool GXt_boolean2 ;
      private bool AV17CaptchaImage_IsBlob ;
      private bool AV67ImageAuthType_IsBlob ;
      private string AV59UserName ;
      private string AV58URL ;
      private string AV90Imageauthtype_GXI ;
      private string AV88Captchaimage_GXI ;
      private string AV70UsuarioSistemaIdentidad ;
      private string AV71UsuarioSistemaNombre ;
      private string AV77UsuarioSistemaGerencia ;
      private string AV78UsuarioSistemaDepartamento ;
      private string AV79UsuarioSistemaEmail ;
      private string AV73ResponsableIdentidad ;
      private string AV75ResponsableNombre ;
      private string AV76ResponsableEmail ;
      private string AV74ResponsableCargo ;
      private string AV67ImageAuthType ;
      private string AV17CaptchaImage ;
      private GXWebGrid GridauthtypesContainer ;
      private GXWebRow GridauthtypesRow ;
      private GXWebColumn GridauthtypesColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private SdtK2BToolsCaptchaProvider AV19CaptchaProvider ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTypeauthtype ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV62WebSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV12AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV23ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV29Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30ErrorsLogin ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV7AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV11AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV27Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV64GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV51Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV52Session ;
   }

}
