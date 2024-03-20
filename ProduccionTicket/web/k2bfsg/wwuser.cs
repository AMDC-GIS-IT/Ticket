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
   public class wwuser : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwuser( )
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

      public wwuser( IGxContext context )
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
         cmbavFilauttype = new GXCombobox();
         chkavIsvisible_authenticationtypename = new GXCheckbox();
         chkavIsvisible_name = new GXCheckbox();
         chkavIsvisible_firstname = new GXCheckbox();
         chkavIsvisible_lastname = new GXCheckbox();
         chkavIsvisible_email = new GXCheckbox();
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
         chkavIsautoregisteruser = new GXCheckbox();
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
               nRC_GXsfl_149 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_149"), "."));
               nGXsfl_149_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_149_idx"), "."));
               sGXsfl_149_idx = GetPar( "sGXsfl_149_idx");
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
               ajax_req_read_hidden_sdt(GetNextPar( ), AV69ClassCollection_Grid);
               AV56FilName_PreviousValue = GetPar( "FilName_PreviousValue");
               AV18FilName = GetPar( "FilName");
               AV57FilNames_PreviousValue = GetPar( "FilNames_PreviousValue");
               AV19FilNames = GetPar( "FilNames");
               AV58FilEmail_PreviousValue = GetPar( "FilEmail_PreviousValue");
               AV17FilEmail = GetPar( "FilEmail");
               AV59FilAutType_PreviousValue = GetPar( "FilAutType_PreviousValue");
               cmbavFilauttype.FromJSonString( GetNextPar( ));
               AV16FilAutType = GetPar( "FilAutType");
               AV74Pgmname = GetPar( "Pgmname");
               AV11CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV66GridConfiguration);
               AV26HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
               AV39UserId = GetPar( "UserId");
               AV7AnonymousUserGUID = GetPar( "AnonymousUserGUID");
               AV29IsAutoRegisterUser = StringUtil.StrToBool( GetPar( "IsAutoRegisterUser"));
               AV54RowsPerPage_Grid = (short)(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."));
               AV28I_LoadCount_Grid = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."));
               AV45IsVisible_AuthenticationTypeName = StringUtil.StrToBool( GetPar( "IsVisible_AuthenticationTypeName"));
               AV46IsVisible_Name = StringUtil.StrToBool( GetPar( "IsVisible_Name"));
               AV47IsVisible_FirstName = StringUtil.StrToBool( GetPar( "IsVisible_FirstName"));
               AV48IsVisible_LastName = StringUtil.StrToBool( GetPar( "IsVisible_LastName"));
               AV49IsVisible_Email = StringUtil.StrToBool( GetPar( "IsVisible_Email"));
               AV70FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( AV69ClassCollection_Grid, AV56FilName_PreviousValue, AV18FilName, AV57FilNames_PreviousValue, AV19FilNames, AV58FilEmail_PreviousValue, AV17FilEmail, AV59FilAutType_PreviousValue, AV16FilAutType, AV74Pgmname, AV11CurrentPage_Grid, AV66GridConfiguration, AV26HasNextPage_Grid, AV39UserId, AV7AnonymousUserGUID, AV29IsAutoRegisterUser, AV54RowsPerPage_Grid, AV28I_LoadCount_Grid, AV45IsVisible_AuthenticationTypeName, AV46IsVisible_Name, AV47IsVisible_FirstName, AV48IsVisible_LastName, AV49IsVisible_Email, AV70FreezeColumnTitles_Grid) ;
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
         PA3F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3F2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188371995", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwuser.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vANONYMOUSUSERGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7AnonymousUserGUID, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_149", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_149), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_GRID", AV67FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_GRID", AV67FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_GRID", StringUtil.RTrim( AV68DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, "vANONYMOUSUSERGUID", StringUtil.RTrim( AV7AnonymousUserGUID));
         GxWebStd.gx_hidden_field( context, "gxhash_vANONYMOUSUSERGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7AnonymousUserGUID, "")), context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV66GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV66GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV69ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV69ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vFILNAME_PREVIOUSVALUE", AV56FilName_PreviousValue);
         GxWebStd.gx_hidden_field( context, "vFILNAMES_PREVIOUSVALUE", StringUtil.RTrim( AV57FilNames_PreviousValue));
         GxWebStd.gx_hidden_field( context, "vFILEMAIL_PREVIOUSVALUE", AV58FilEmail_PreviousValue);
         GxWebStd.gx_hidden_field( context, "vFILAUTTYPE_PREVIOUSVALUE", StringUtil.RTrim( AV59FilAutType_PreviousValue));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE3F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3F2( ) ;
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
         return formatLink("k2bfsg.wwuser.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.WWUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios" ;
      }

      protected void WB3F0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_onlydetailedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section5_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_OnlyDetailedFilters", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWUser.htm");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV67FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV68DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, "FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_filname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, "Usuario", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_149_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, AV18FilName, StringUtil.RTrim( context.localUtil.Format( AV18FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_K2BFSG\\WWUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filnames_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFilnames_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilnames_Internalname, "Nombre", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_149_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilnames_Internalname, StringUtil.RTrim( AV19FilNames), StringUtil.RTrim( context.localUtil.Format( AV19FilNames, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name or Last name", edtavFilnames_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilnames_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\WWUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFilemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilemail_Internalname, "Correo electrónico", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_149_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilemail_Internalname, AV17FilEmail, StringUtil.RTrim( context.localUtil.Format( AV17FilEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilemail_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilemail_Enabled, 0, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_K2BFSG\\WWUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filauttype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavFilauttype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilauttype_Internalname, "Tipo de autenticación", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_149_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilauttype, cmbavFilauttype_Internalname, StringUtil.RTrim( AV16FilAutType), 1, cmbavFilauttype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFilauttype.Enabled, 0, 0, 60, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 1, "HLP_K2BFSG\\WWUser.htm");
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV16FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", (string)(cmbavFilauttype.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_67_3F2( true) ;
         }
         else
         {
            wb_table1_67_3F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_67_3F2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"149\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Autenticación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Primer nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Apellido") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Correo electrónico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Es usuario autoregistrado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
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
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV9AuthenticationTypeName));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV32Name));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavName_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV22FirstName));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV30LastName));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV39UserId));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUserid_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV12Email);
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmail_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmail_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV29IsAutoRegisterUser));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsautoregisteruser.Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV63Update_Action));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_action_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV64Password_Action));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPassword_action_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavPassword_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV65Delete_Action));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_action_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_action_Tooltiptext));
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
         if ( wbEnd == 149 )
         {
            wbEnd = 0;
            nRC_GXsfl_149 = (int)(nGXsfl_149_idx-1);
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
            wb_table2_162_3F2( true) ;
         }
         else
         {
            wb_table2_162_3F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_162_3F2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_grid_Internalname, divPaginationbar_pagingcontainertable_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113f1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123f1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113f1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e133f1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e133f1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
         if ( wbEnd == 149 )
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

      protected void START3F2( )
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
            Form.Meta.addItem("description", "Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3F0( ) ;
      }

      protected void WS3F2( )
      {
         START3F2( ) ;
         EVT3F2( ) ;
      }

      protected void EVT3F2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E143F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E153F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E163F2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_149_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
                              SubsflControlProps_1492( ) ;
                              AV9AuthenticationTypeName = cgiGet( edtavAuthenticationtypename_Internalname);
                              AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
                              AV32Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV32Name);
                              AV22FirstName = cgiGet( edtavFirstname_Internalname);
                              AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
                              AV30LastName = cgiGet( edtavLastname_Internalname);
                              AssignAttri("", false, edtavLastname_Internalname, AV30LastName);
                              AV39UserId = cgiGet( edtavUserid_Internalname);
                              AssignAttri("", false, edtavUserid_Internalname, AV39UserId);
                              AV12Email = cgiGet( edtavEmail_Internalname);
                              AssignAttri("", false, edtavEmail_Internalname, AV12Email);
                              AV29IsAutoRegisterUser = StringUtil.StrToBool( cgiGet( chkavIsautoregisteruser_Internalname));
                              AssignAttri("", false, chkavIsautoregisteruser_Internalname, AV29IsAutoRegisterUser);
                              GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER"+"_"+sGXsfl_149_idx, GetSecureSignedToken( sGXsfl_149_idx, AV29IsAutoRegisterUser, context));
                              AV63Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp("", false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update_Action)) ? AV76Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update_Action))), !bGXsfl_149_Refreshing);
                              AssignProp("", false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update_Action), true);
                              AV64Password_Action = cgiGet( edtavPassword_action_Internalname);
                              AssignProp("", false, edtavPassword_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Password_Action)) ? AV77Password_action_GXI : context.convertURL( context.PathToRelativeUrl( AV64Password_Action))), !bGXsfl_149_Refreshing);
                              AssignProp("", false, edtavPassword_action_Internalname, "SrcSet", context.GetImageSrcSet( AV64Password_Action), true);
                              AV65Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp("", false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65Delete_Action)) ? AV78Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV65Delete_Action))), !bGXsfl_149_Refreshing);
                              AssignProp("", false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV65Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E173F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E183F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E193F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E203F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE3F2( )
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

      protected void PA3F2( )
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
               GX_FocusControl = edtavFilname_Internalname;
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
         SubsflControlProps_1492( ) ;
         while ( nGXsfl_149_idx <= nRC_GXsfl_149 )
         {
            sendrow_1492( ) ;
            nGXsfl_149_idx = ((subGrid_Islastpage==1)&&(nGXsfl_149_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_149_idx+1);
            sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
            SubsflControlProps_1492( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( GxSimpleCollection<string> AV69ClassCollection_Grid ,
                                       string AV56FilName_PreviousValue ,
                                       string AV18FilName ,
                                       string AV57FilNames_PreviousValue ,
                                       string AV19FilNames ,
                                       string AV58FilEmail_PreviousValue ,
                                       string AV17FilEmail ,
                                       string AV59FilAutType_PreviousValue ,
                                       string AV16FilAutType ,
                                       string AV74Pgmname ,
                                       short AV11CurrentPage_Grid ,
                                       SdtK2BGridConfiguration AV66GridConfiguration ,
                                       bool AV26HasNextPage_Grid ,
                                       string AV39UserId ,
                                       string AV7AnonymousUserGUID ,
                                       bool AV29IsAutoRegisterUser ,
                                       short AV54RowsPerPage_Grid ,
                                       short AV28I_LoadCount_Grid ,
                                       bool AV45IsVisible_AuthenticationTypeName ,
                                       bool AV46IsVisible_Name ,
                                       bool AV47IsVisible_FirstName ,
                                       bool AV48IsVisible_LastName ,
                                       bool AV49IsVisible_Email ,
                                       bool AV70FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E193F2 ();
         GRID_nCurrentRecord = 0;
         RF3F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER", GetSecureSignedToken( "", AV29IsAutoRegisterUser, context));
         GxWebStd.gx_hidden_field( context, "vISAUTOREGISTERUSER", StringUtil.BoolToStr( AV29IsAutoRegisterUser));
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
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV16FilAutType = cmbavFilauttype.getValidValue(AV16FilAutType);
            AssignAttri("", false, "AV16FilAutType", AV16FilAutType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV16FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         }
         AV45IsVisible_AuthenticationTypeName = StringUtil.StrToBool( StringUtil.BoolToStr( AV45IsVisible_AuthenticationTypeName));
         AssignAttri("", false, "AV45IsVisible_AuthenticationTypeName", AV45IsVisible_AuthenticationTypeName);
         AV46IsVisible_Name = StringUtil.StrToBool( StringUtil.BoolToStr( AV46IsVisible_Name));
         AssignAttri("", false, "AV46IsVisible_Name", AV46IsVisible_Name);
         AV47IsVisible_FirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV47IsVisible_FirstName));
         AssignAttri("", false, "AV47IsVisible_FirstName", AV47IsVisible_FirstName);
         AV48IsVisible_LastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV48IsVisible_LastName));
         AssignAttri("", false, "AV48IsVisible_LastName", AV48IsVisible_LastName);
         AV49IsVisible_Email = StringUtil.StrToBool( StringUtil.BoolToStr( AV49IsVisible_Email));
         AssignAttri("", false, "AV49IsVisible_Email", AV49IsVisible_Email);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV55GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV55GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV70FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV70FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV70FreezeColumnTitles_Grid", AV70FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E193F2 ();
         RF3F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV74Pgmname = "K2BFSG.WWUser";
         context.Gx_err = 0;
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavEmail_Enabled = 0;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         chkavIsautoregisteruser.Enabled = 0;
         AssignProp("", false, chkavIsautoregisteruser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsautoregisteruser.Enabled), 5, 0), !bGXsfl_149_Refreshing);
      }

      protected void RF3F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 149;
         E203F2 ();
         nGXsfl_149_idx = 1;
         sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
         SubsflControlProps_1492( ) ;
         bGXsfl_149_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1492( ) ;
            E183F2 ();
            wbEnd = 149;
            WB3F0( ) ;
         }
         bGXsfl_149_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3F2( )
      {
         GxWebStd.gx_hidden_field( context, "vANONYMOUSUSERGUID", StringUtil.RTrim( AV7AnonymousUserGUID));
         GxWebStd.gx_hidden_field( context, "gxhash_vANONYMOUSUSERGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7AnonymousUserGUID, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER"+"_"+sGXsfl_149_idx, GetSecureSignedToken( sGXsfl_149_idx, AV29IsAutoRegisterUser, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV74Pgmname = "K2BFSG.WWUser";
         context.Gx_err = 0;
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         edtavEmail_Enabled = 0;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), !bGXsfl_149_Refreshing);
         chkavIsautoregisteruser.Enabled = 0;
         AssignProp("", false, chkavIsautoregisteruser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsautoregisteruser.Enabled), 5, 0), !bGXsfl_149_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E173F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_GRID"), AV67FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_149 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_149"), ".", ","));
            AV68DeletedTag_Grid = cgiGet( "vDELETEDTAG_GRID");
            AV54RowsPerPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), ".", ","));
            AV11CurrentPage_Grid = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","));
            AV26HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible"), ".", ","));
            /* Read variables values. */
            AV18FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri("", false, "AV18FilName", AV18FilName);
            AV19FilNames = cgiGet( edtavFilnames_Internalname);
            AssignAttri("", false, "AV19FilNames", AV19FilNames);
            AV17FilEmail = cgiGet( edtavFilemail_Internalname);
            AssignAttri("", false, "AV17FilEmail", AV17FilEmail);
            cmbavFilauttype.Name = cmbavFilauttype_Internalname;
            cmbavFilauttype.CurrentValue = cgiGet( cmbavFilauttype_Internalname);
            AV16FilAutType = cgiGet( cmbavFilauttype_Internalname);
            AssignAttri("", false, "AV16FilAutType", AV16FilAutType);
            AV45IsVisible_AuthenticationTypeName = StringUtil.StrToBool( cgiGet( chkavIsvisible_authenticationtypename_Internalname));
            AssignAttri("", false, "AV45IsVisible_AuthenticationTypeName", AV45IsVisible_AuthenticationTypeName);
            AV46IsVisible_Name = StringUtil.StrToBool( cgiGet( chkavIsvisible_name_Internalname));
            AssignAttri("", false, "AV46IsVisible_Name", AV46IsVisible_Name);
            AV47IsVisible_FirstName = StringUtil.StrToBool( cgiGet( chkavIsvisible_firstname_Internalname));
            AssignAttri("", false, "AV47IsVisible_FirstName", AV47IsVisible_FirstName);
            AV48IsVisible_LastName = StringUtil.StrToBool( cgiGet( chkavIsvisible_lastname_Internalname));
            AssignAttri("", false, "AV48IsVisible_LastName", AV48IsVisible_LastName);
            AV49IsVisible_Email = StringUtil.StrToBool( cgiGet( chkavIsvisible_email_Internalname));
            AssignAttri("", false, "AV49IsVisible_Email", AV49IsVisible_Email);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV55GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV55GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
            AV70FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV70FreezeColumnTitles_Grid", AV70FreezeColumnTitles_Grid);
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

      protected void S232( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV42Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV42Messages = GXt_objcol_SdtMessages_Message1;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV42Messages.Count )
         {
            AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV42Messages.Item(AV73GXV1));
            GX_msglist.addItem(AV31Message.gxTpr_Description);
            AV73GXV1 = (int)(AV73GXV1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E173F2 ();
         if (returnInSub) return;
      }

      protected void E173F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV74Pgmname,  "Grid", out  AV54RowsPerPage_Grid, out  AV60RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV54RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV54RowsPerPage_Grid), 4, 0));
         if ( ! AV60RowsPerPageLoaded_Grid )
         {
            AV54RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV54RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV54RowsPerPage_Grid), 4, 0));
         }
         AV55GridSettingsRowsPerPage_Grid = AV54RowsPerPage_Grid;
         AssignAttri("", false, "AV55GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV56FilName_PreviousValue = AV18FilName;
         AssignAttri("", false, "AV56FilName_PreviousValue", AV56FilName_PreviousValue);
         AV57FilNames_PreviousValue = AV19FilNames;
         AssignAttri("", false, "AV57FilNames_PreviousValue", AV57FilNames_PreviousValue);
         AV58FilEmail_PreviousValue = AV17FilEmail;
         AssignAttri("", false, "AV58FilEmail_PreviousValue", AV58FilEmail_PreviousValue);
         AV59FilAutType_PreviousValue = AV16FilAutType;
         AssignAttri("", false, "AV59FilAutType_PreviousValue", AV59FilAutType_PreviousValue);
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void S262( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         cmbavFilauttype.removeAllItems();
         cmbavFilauttype.addItem("", "(Todos)", 0);
         AV10AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV21FilterAutType, out  AV14Errors);
         AV75GXV2 = 1;
         while ( AV75GXV2 <= AV10AuthenticationTypes.Count )
         {
            AV8AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV10AuthenticationTypes.Item(AV75GXV2));
            cmbavFilauttype.addItem(AV8AuthenticationType.gxTpr_Name, AV8AuthenticationType.gxTpr_Description, 0);
            AV75GXV2 = (int)(AV75GXV2+1);
         }
         AV35Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV7AnonymousUserGUID = AV35Repository.gxTpr_Anonymoususerguid;
         AssignAttri("", false, "AV7AnonymousUserGUID", AV7AnonymousUserGUID);
         GxWebStd.gx_hidden_field( context, "gxhash_vANONYMOUSUSERGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7AnonymousUserGUID, "")), context));
      }

      private void E183F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV28I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         AV26HasNextPage_Grid = false;
         AssignAttri("", false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         AV15Exit_Grid = false;
         while ( true )
         {
            AV28I_LoadCount_Grid = (short)(AV28I_LoadCount_Grid+1);
            AssignAttri("", false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S142 ();
            if (returnInSub) return;
            if ( ( StringUtil.StrCmp(StringUtil.Trim( AV39UserId), StringUtil.Trim( AV7AnonymousUserGUID)) != 0 ) && ! AV29IsAutoRegisterUser )
            {
               AV63Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
               AssignAttri("", false, edtavUpdate_action_Internalname, AV63Update_Action);
               AV76Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
               edtavUpdate_action_Enabled = 1;
               edtavUpdate_action_Tooltiptext = "Actualizar";
            }
            else
            {
               AV63Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
               AssignAttri("", false, edtavUpdate_action_Internalname, AV63Update_Action);
               AV76Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
               edtavUpdate_action_Enabled = 0;
               edtavUpdate_action_Tooltiptext = "";
            }
            if ( ( StringUtil.StrCmp(StringUtil.Trim( AV39UserId), StringUtil.Trim( AV7AnonymousUserGUID)) != 0 ) && ! AV29IsAutoRegisterUser )
            {
               AV64Password_Action = context.GetImagePath( "5d0ba1d7-fc8e-4bed-ab1f-d50d4004d962", "", context.GetTheme( ));
               AssignAttri("", false, edtavPassword_action_Internalname, AV64Password_Action);
               AV77Password_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5d0ba1d7-fc8e-4bed-ab1f-d50d4004d962", "", context.GetTheme( )));
               edtavPassword_action_Enabled = 1;
               edtavPassword_action_Tooltiptext = "Cambiar Contraseña";
            }
            else
            {
               AV64Password_Action = context.GetImagePath( "5d0ba1d7-fc8e-4bed-ab1f-d50d4004d962", "", context.GetTheme( ));
               AssignAttri("", false, edtavPassword_action_Internalname, AV64Password_Action);
               AV77Password_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5d0ba1d7-fc8e-4bed-ab1f-d50d4004d962", "", context.GetTheme( )));
               edtavPassword_action_Enabled = 0;
               edtavPassword_action_Tooltiptext = "";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( AV39UserId), StringUtil.Trim( AV7AnonymousUserGUID)) != 0 )
            {
               AV65Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri("", false, edtavDelete_action_Internalname, AV65Delete_Action);
               AV78Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 1;
               edtavDelete_action_Tooltiptext = "Eliminar";
            }
            else
            {
               AV65Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri("", false, edtavDelete_action_Internalname, AV65Delete_Action);
               AV78Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 0;
               edtavDelete_action_Tooltiptext = "";
            }
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S152 ();
            if (returnInSub) return;
            if ( AV15Exit_Grid )
            {
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV54RowsPerPage_Grid * AV11CurrentPage_Grid )
            {
               AV26HasNextPage_Grid = true;
               AssignAttri("", false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV54RowsPerPage_Grid * ( AV11CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 149;
               }
               sendrow_1492( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_149_Refreshing )
               {
                  context.DoAjaxLoad(149, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20Filter", AV20Filter);
      }

      protected void S142( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV28I_LoadCount_Grid == 1 )
         {
            AV20Filter.gxTpr_Name = AV18FilName;
            AV20Filter.gxTpr_Names = AV19FilNames;
            AV20Filter.gxTpr_Email = AV17FilEmail;
            AV20Filter.gxTpr_Isactive = "A";
            AV20Filter.gxTpr_Gender = "";
            AV20Filter.gxTpr_Authenticationtypename = AV16FilAutType;
            AV20Filter.gxTpr_Returnanonymoususer = true;
            AV20Filter.gxTpr_Isenabledinrepository = "A";
            AV40Users = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusersorderby(AV20Filter, 3, out  AV14Errors);
         }
         if ( AV40Users.Count >= AV28I_LoadCount_Grid )
         {
            AV38User = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV40Users.Item(AV28I_LoadCount_Grid));
            AV9AuthenticationTypeName = AV38User.gxTpr_Authenticationtypename;
            AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
            AV39UserId = AV38User.gxTpr_Guid;
            AssignAttri("", false, edtavUserid_Internalname, AV39UserId);
            AV32Name = AV38User.gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV32Name);
            AV22FirstName = AV38User.gxTpr_Firstname;
            AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
            AV30LastName = AV38User.gxTpr_Lastname;
            AssignAttri("", false, edtavLastname_Internalname, AV30LastName);
            AV12Email = AV38User.gxTpr_Email;
            AssignAttri("", false, edtavEmail_Internalname, AV12Email);
            AV29IsAutoRegisterUser = AV38User.gxTpr_Isautoregistereduser;
            AssignAttri("", false, chkavIsautoregisteruser_Internalname, AV29IsAutoRegisterUser);
            GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER"+"_"+sGXsfl_149_idx, GetSecureSignedToken( sGXsfl_149_idx, AV29IsAutoRegisterUser, context));
            edtavName_Link = formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"Mode","UserId"}) ;
            AssignProp("", false, edtavName_Internalname, "Link", edtavName_Link, !bGXsfl_149_Refreshing);
         }
         else
         {
            AV15Exit_Grid = true;
         }
      }

      protected void S162( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV11CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV11CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV11CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV11CurrentPage_Grid) || ( AV11CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV11CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV11CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV26HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV11CurrentPage_Grid <= 1 ) && ! AV26HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'U_PASSWORD' Routine */
         returnInSub = false;
         context.PopUp(formatLink("k2bfsg.setpassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"UserId"}) , new Object[] {});
      }

      protected void S202( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"Mode","UserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV23GridState.gxTpr_Currentpage = AV11CurrentPage_Grid;
         AV23GridState.gxTpr_Filtervalues.Clear();
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "FilName";
         AV24GridStateFilterValue.gxTpr_Value = AV18FilName;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "FilNames";
         AV24GridStateFilterValue.gxTpr_Value = AV19FilNames;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "FilEmail";
         AV24GridStateFilterValue.gxTpr_Value = AV17FilEmail;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "FilAutType";
         AV24GridStateFilterValue.gxTpr_Value = AV16FilAutType;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV74Pgmname,  AV25GridStateKey,  AV23GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV74Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV79GXV3 = 1;
         while ( AV79GXV3 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV79GXV3));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "FilName") == 0 )
            {
               AV18FilName = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18FilName", AV18FilName);
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "FilNames") == 0 )
            {
               AV19FilNames = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilNames", AV19FilNames);
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "FilEmail") == 0 )
            {
               AV17FilEmail = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilEmail", AV17FilEmail);
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "FilAutType") == 0 )
            {
               AV16FilAutType = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilAutType", AV16FilAutType);
            }
            AV79GXV3 = (int)(AV79GXV3+1);
         }
         if ( AV23GridState.gxTpr_Currentpage > 0 )
         {
            AV11CurrentPage_Grid = AV23GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
      }

      protected void E143F2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'E_LOADAVAILABLECOLUMNS(GRID)' */
         S212 ();
         if (returnInSub) return;
         new k2bloadgridconfiguration(context ).execute(  AV74Pgmname,  "Grid", ref  AV66GridConfiguration) ;
         AV80GXV4 = 1;
         while ( AV80GXV4 <= AV66GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV44GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV66GridConfiguration.gxTpr_Gridcolumns.Item(AV80GXV4));
            if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&AuthenticationTypeName") == 0 )
            {
               AV44GridColumn.gxTpr_Showattribute = AV45IsVisible_AuthenticationTypeName;
            }
            else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&Name") == 0 )
            {
               AV44GridColumn.gxTpr_Showattribute = AV46IsVisible_Name;
            }
            else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&FirstName") == 0 )
            {
               AV44GridColumn.gxTpr_Showattribute = AV47IsVisible_FirstName;
            }
            else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&LastName") == 0 )
            {
               AV44GridColumn.gxTpr_Showattribute = AV48IsVisible_LastName;
            }
            else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&Email") == 0 )
            {
               AV44GridColumn.gxTpr_Showattribute = AV49IsVisible_Email;
            }
            AV80GXV4 = (int)(AV80GXV4+1);
         }
         AV66GridConfiguration.gxTpr_Freezecolumntitles = AV70FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV74Pgmname,  "Grid",  AV66GridConfiguration,  true) ;
         if ( AV54RowsPerPage_Grid != AV55GridSettingsRowsPerPage_Grid )
         {
            AV54RowsPerPage_Grid = AV55GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV54RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV54RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV74Pgmname,  "Grid",  AV54RowsPerPage_Grid) ;
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV69ClassCollection_Grid, AV56FilName_PreviousValue, AV18FilName, AV57FilNames_PreviousValue, AV19FilNames, AV58FilEmail_PreviousValue, AV17FilEmail, AV59FilAutType_PreviousValue, AV16FilAutType, AV74Pgmname, AV11CurrentPage_Grid, AV66GridConfiguration, AV26HasNextPage_Grid, AV39UserId, AV7AnonymousUserGUID, AV29IsAutoRegisterUser, AV54RowsPerPage_Grid, AV28I_LoadCount_Grid, AV45IsVisible_AuthenticationTypeName, AV46IsVisible_Name, AV47IsVisible_FirstName, AV48IsVisible_LastName, AV49IsVisible_Email, AV70FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridConfiguration", AV66GridConfiguration);
         cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV16FilAutType);
         AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69ClassCollection_Grid", AV69ClassCollection_Grid);
      }

      protected void S282( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp("", false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
      }

      protected void S222( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"Mode","UserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E193F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S232 ();
         if (returnInSub) return;
         if ( (0==AV11CurrentPage_Grid) )
         {
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         AV34Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S252 ();
         if (returnInSub) return;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV69ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridConfiguration", AV66GridConfiguration);
         cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV16FilAutType);
         AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69ClassCollection_Grid", AV69ClassCollection_Grid);
      }

      protected void S292( )
      {
         /* 'E_HIDESHOWCOLUMNS(GRID)' Routine */
         returnInSub = false;
         edtavAuthenticationtypename_Visible = 1;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_149_Refreshing);
         AV45IsVisible_AuthenticationTypeName = true;
         AssignAttri("", false, "AV45IsVisible_AuthenticationTypeName", AV45IsVisible_AuthenticationTypeName);
         edtavName_Visible = 1;
         AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), !bGXsfl_149_Refreshing);
         AV46IsVisible_Name = true;
         AssignAttri("", false, "AV46IsVisible_Name", AV46IsVisible_Name);
         edtavFirstname_Visible = 1;
         AssignProp("", false, edtavFirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFirstname_Visible), 5, 0), !bGXsfl_149_Refreshing);
         AV47IsVisible_FirstName = true;
         AssignAttri("", false, "AV47IsVisible_FirstName", AV47IsVisible_FirstName);
         edtavLastname_Visible = 1;
         AssignProp("", false, edtavLastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLastname_Visible), 5, 0), !bGXsfl_149_Refreshing);
         AV48IsVisible_LastName = true;
         AssignAttri("", false, "AV48IsVisible_LastName", AV48IsVisible_LastName);
         edtavEmail_Visible = 1;
         AssignProp("", false, edtavEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmail_Visible), 5, 0), !bGXsfl_149_Refreshing);
         AV49IsVisible_Email = true;
         AssignAttri("", false, "AV49IsVisible_Email", AV49IsVisible_Email);
         new k2bsavegridconfiguration(context ).execute(  AV74Pgmname,  "Grid",  AV66GridConfiguration,  false) ;
         AV81GXV5 = 1;
         while ( AV81GXV5 <= AV66GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV44GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV66GridConfiguration.gxTpr_Gridcolumns.Item(AV81GXV5));
            if ( ! AV44GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&AuthenticationTypeName") == 0 )
               {
                  edtavAuthenticationtypename_Visible = 0;
                  AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_149_Refreshing);
                  AV45IsVisible_AuthenticationTypeName = false;
                  AssignAttri("", false, "AV45IsVisible_AuthenticationTypeName", AV45IsVisible_AuthenticationTypeName);
               }
               else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&Name") == 0 )
               {
                  edtavName_Visible = 0;
                  AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), !bGXsfl_149_Refreshing);
                  AV46IsVisible_Name = false;
                  AssignAttri("", false, "AV46IsVisible_Name", AV46IsVisible_Name);
               }
               else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&FirstName") == 0 )
               {
                  edtavFirstname_Visible = 0;
                  AssignProp("", false, edtavFirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFirstname_Visible), 5, 0), !bGXsfl_149_Refreshing);
                  AV47IsVisible_FirstName = false;
                  AssignAttri("", false, "AV47IsVisible_FirstName", AV47IsVisible_FirstName);
               }
               else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&LastName") == 0 )
               {
                  edtavLastname_Visible = 0;
                  AssignProp("", false, edtavLastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLastname_Visible), 5, 0), !bGXsfl_149_Refreshing);
                  AV48IsVisible_LastName = false;
                  AssignAttri("", false, "AV48IsVisible_LastName", AV48IsVisible_LastName);
               }
               else if ( StringUtil.StrCmp(AV44GridColumn.gxTpr_Attributename, "&Email") == 0 )
               {
                  edtavEmail_Visible = 0;
                  AssignProp("", false, edtavEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmail_Visible), 5, 0), !bGXsfl_149_Refreshing);
                  AV49IsVisible_Email = false;
                  AssignAttri("", false, "AV49IsVisible_Email", AV49IsVisible_Email);
               }
            }
            AV81GXV5 = (int)(AV81GXV5+1);
         }
      }

      protected void S272( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E203F2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV69ClassCollection_Grid) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV56FilName_PreviousValue, AV18FilName) != 0 )
         {
            AV56FilName_PreviousValue = AV18FilName;
            AssignAttri("", false, "AV56FilName_PreviousValue", AV56FilName_PreviousValue);
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV57FilNames_PreviousValue, AV19FilNames) != 0 )
         {
            AV57FilNames_PreviousValue = AV19FilNames;
            AssignAttri("", false, "AV57FilNames_PreviousValue", AV57FilNames_PreviousValue);
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV58FilEmail_PreviousValue, AV17FilEmail) != 0 )
         {
            AV58FilEmail_PreviousValue = AV17FilEmail;
            AssignAttri("", false, "AV58FilEmail_PreviousValue", AV58FilEmail_PreviousValue);
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV59FilAutType_PreviousValue, AV16FilAutType) != 0 )
         {
            AV59FilAutType_PreviousValue = AV16FilAutType;
            AssignAttri("", false, "AV59FilAutType_PreviousValue", AV59FilAutType_PreviousValue);
            AV11CurrentPage_Grid = 1;
            AssignAttri("", false, "AV11CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV11CurrentPage_Grid), 4, 0));
         }
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S272 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S252 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S162 ();
         if (returnInSub) return;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV69ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69ClassCollection_Grid", AV69ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67FilterTagsCollection_Grid", AV67FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridConfiguration", AV66GridConfiguration);
      }

      protected void S212( )
      {
         /* 'E_LOADAVAILABLECOLUMNS(GRID)' Routine */
         returnInSub = false;
         AV43GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV44GridColumn.gxTpr_Attributename = "&AuthenticationTypeName";
         AV44GridColumn.gxTpr_Columntitle = "Autenticación";
         AV44GridColumn.gxTpr_Showattribute = true;
         AV43GridColumns.Add(AV44GridColumn, 0);
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV44GridColumn.gxTpr_Attributename = "&Name";
         AV44GridColumn.gxTpr_Columntitle = "Nombre";
         AV44GridColumn.gxTpr_Showattribute = true;
         AV43GridColumns.Add(AV44GridColumn, 0);
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV44GridColumn.gxTpr_Attributename = "&FirstName";
         AV44GridColumn.gxTpr_Columntitle = "Primer nombre";
         AV44GridColumn.gxTpr_Showattribute = true;
         AV43GridColumns.Add(AV44GridColumn, 0);
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV44GridColumn.gxTpr_Attributename = "&LastName";
         AV44GridColumn.gxTpr_Columntitle = "Apellido";
         AV44GridColumn.gxTpr_Showattribute = true;
         AV43GridColumns.Add(AV44GridColumn, 0);
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV44GridColumn.gxTpr_Attributename = "&Email";
         AV44GridColumn.gxTpr_Columntitle = "Correo electrónico";
         AV44GridColumn.gxTpr_Showattribute = true;
         AV43GridColumns.Add(AV44GridColumn, 0);
         AV66GridConfiguration.gxTpr_Gridcolumns = AV43GridColumns;
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV61K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18FilName)) )
         {
            AV62K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilName";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Usuario";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV18FilName;
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV18FilName;
            AV61K2BFilterValuesSDT_WebForm.Add(AV62K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FilNames)) )
         {
            AV62K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilNames";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Nombre";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV19FilNames;
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV19FilNames;
            AV61K2BFilterValuesSDT_WebForm.Add(AV62K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17FilEmail)) )
         {
            AV62K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilEmail";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Correo electrónico";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV17FilEmail;
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV17FilEmail;
            AV61K2BFilterValuesSDT_WebForm.Add(AV62K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilAutType)) )
         {
            AV62K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilAutType";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Tipo de autenticación";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV16FilAutType;
            AV62K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV16FilAutType;
            AV61K2BFilterValuesSDT_WebForm.Add(AV62K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No hay filtros aplicados";
         ucFiltertagsusercontrol_grid.SendProperty(context, "", false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV61K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV67FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV74Pgmname,  "Grid",  AV61K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV67FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E153F2( )
      {
         /* Layoutdefined_filtertoggle_onlydetailed_grid_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E163F2( )
      {
         /* Layoutdefined_filterclose_onlydetailed_grid_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void S242( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S282 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S252( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'E_LOADAVAILABLECOLUMNS(GRID)' */
         S212 ();
         if (returnInSub) return;
         new k2bloadgridconfiguration(context ).execute(  AV74Pgmname,  "Grid", ref  AV66GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S302 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_HIDESHOWCOLUMNS(GRID)' */
         S292 ();
         if (returnInSub) return;
      }

      protected void S302( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV70FreezeColumnTitles_Grid = AV66GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV70FreezeColumnTitles_Grid", AV70FreezeColumnTitles_Grid);
         if ( AV70FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV69ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV69ClassCollection_Grid) ;
         }
      }

      protected void wb_table2_162_3F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_162_3F2e( true) ;
         }
         else
         {
            wb_table2_162_3F2e( false) ;
         }
      }

      protected void wb_table1_67_3F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_Internalname, tblLayoutdefined_table7_grid_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e213f1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_Internalname, divGridsettings_contentoutertablegrid_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_tablecontentgrid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAuthenticationtypename_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsvisible_authenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsvisible_authenticationtypename_Internalname, "Autenticación", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsvisible_authenticationtypename_Internalname, StringUtil.BoolToStr( AV45IsVisible_AuthenticationTypeName), "", "Autenticación", 1, chkavIsvisible_authenticationtypename.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(96, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
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
            GxWebStd.gx_div_start( context, divName_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsvisible_name_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsvisible_name_Internalname, "Nombre", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsvisible_name_Internalname, StringUtil.BoolToStr( AV46IsVisible_Name), "", "Nombre", 1, chkavIsvisible_name.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(102, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,102);\"");
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
            GxWebStd.gx_div_start( context, divFirstname_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsvisible_firstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsvisible_firstname_Internalname, "Primer nombre", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsvisible_firstname_Internalname, StringUtil.BoolToStr( AV47IsVisible_FirstName), "", "Primer nombre", 1, chkavIsvisible_firstname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
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
            GxWebStd.gx_div_start( context, divLastname_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsvisible_lastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsvisible_lastname_Internalname, "Apellido", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsvisible_lastname_Internalname, StringUtil.BoolToStr( AV48IsVisible_LastName), "", "Apellido", 1, chkavIsvisible_lastname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(114, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,114);\"");
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
            GxWebStd.gx_div_start( context, divEmail_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsvisible_email_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsvisible_email_Internalname, "Correo electrónico", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsvisible_email_Internalname, StringUtil.BoolToStr( AV49IsVisible_Email), "", "Correo electrónico", 1, chkavIsvisible_email.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
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
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_149_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "", true, 1, "HLP_K2BFSG\\WWUser.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, "Inmovilizar títulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_149_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV70FreezeColumnTitles_Grid), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(132, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,132);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(149), 3, 0)+","+"null"+");", "Aplicar", bttGridsettings_savegrid_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWUser.htm");
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
            wb_table3_137_3F2( true) ;
         }
         else
         {
            wb_table3_137_3F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_137_3F2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_67_3F2e( true) ;
         }
         else
         {
            wb_table1_67_3F2e( false) ;
         }
      }

      protected void wb_table3_137_3F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_grid_topright_Internalname, tblActions_grid_topright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(149), 3, 0)+","+"null"+");", "Nuevo", bttAdd_Jsonclick, 7, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e223f1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WWUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_137_3F2e( true) ;
         }
         else
         {
            wb_table3_137_3F2e( false) ;
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
         PA3F2( ) ;
         WS3F2( ) ;
         WE3F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188375525", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bfsg/wwuser.js", "?2024188375533", false, true);
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1492( )
      {
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_149_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_149_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_149_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_149_idx;
         edtavUserid_Internalname = "vUSERID_"+sGXsfl_149_idx;
         edtavEmail_Internalname = "vEMAIL_"+sGXsfl_149_idx;
         chkavIsautoregisteruser_Internalname = "vISAUTOREGISTERUSER_"+sGXsfl_149_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_149_idx;
         edtavPassword_action_Internalname = "vPASSWORD_ACTION_"+sGXsfl_149_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_149_idx;
      }

      protected void SubsflControlProps_fel_1492( )
      {
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_149_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_149_fel_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_149_fel_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_149_fel_idx;
         edtavUserid_Internalname = "vUSERID_"+sGXsfl_149_fel_idx;
         edtavEmail_Internalname = "vEMAIL_"+sGXsfl_149_fel_idx;
         chkavIsautoregisteruser_Internalname = "vISAUTOREGISTERUSER_"+sGXsfl_149_fel_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_149_fel_idx;
         edtavPassword_action_Internalname = "vPASSWORD_ACTION_"+sGXsfl_149_fel_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_149_fel_idx;
      }

      protected void sendrow_1492( )
      {
         SubsflControlProps_1492( ) ;
         WB3F0( ) ;
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
            if ( ((int)((nGXsfl_149_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_149_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 150,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAuthenticationtypename_Internalname,StringUtil.RTrim( AV9AuthenticationTypeName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,150);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAuthenticationtypename_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(int)edtavAuthenticationtypename_Visible,(int)edtavAuthenticationtypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 151,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV32Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,151);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavName_Link,(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavName_Visible,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 152,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFirstname_Internalname,StringUtil.RTrim( AV22FirstName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,152);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFirstname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(int)edtavFirstname_Visible,(int)edtavFirstname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 153,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLastname_Internalname,StringUtil.RTrim( AV30LastName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,153);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLastname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(int)edtavLastname_Visible,(int)edtavLastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavUserid_Enabled!=0)&&(edtavUserid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 154,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserid_Internalname,StringUtil.RTrim( AV39UserId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUserid_Enabled!=0)&&(edtavUserid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,154);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUserid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavUserid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavEmail_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavEmail_Enabled!=0)&&(edtavEmail_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 155,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEmail_Internalname,(string)AV12Email,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEmail_Enabled!=0)&&(edtavEmail_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,155);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavEmail_Visible,(int)edtavEmail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)149,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMEMail",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavIsautoregisteruser.Enabled!=0)&&(chkavIsautoregisteruser.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 156,'',false,'"+sGXsfl_149_idx+"',149)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vISAUTOREGISTERUSER_" + sGXsfl_149_idx;
         chkavIsautoregisteruser.Name = GXCCtl;
         chkavIsautoregisteruser.WebTags = "";
         chkavIsautoregisteruser.Caption = "";
         AssignProp("", false, chkavIsautoregisteruser_Internalname, "TitleCaption", chkavIsautoregisteruser.Caption, !bGXsfl_149_Refreshing);
         chkavIsautoregisteruser.CheckedValue = "false";
         AV29IsAutoRegisterUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV29IsAutoRegisterUser));
         AssignAttri("", false, chkavIsautoregisteruser_Internalname, AV29IsAutoRegisterUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER"+"_"+sGXsfl_149_idx, GetSecureSignedToken( sGXsfl_149_idx, AV29IsAutoRegisterUser, context));
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsautoregisteruser_Internalname,StringUtil.BoolToStr( AV29IsAutoRegisterUser),(string)"",(string)"",(short)0,chkavIsautoregisteruser.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(156, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavIsautoregisteruser.Enabled!=0)&&(chkavIsautoregisteruser.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,156);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 157,'',false,'',149)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV63Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV63Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV76Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV63Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update_Action)) ? AV76Update_action_GXI : context.PathToRelativeUrl( AV63Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtavUpdate_action_Enabled,(string)"Update",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUpdate_action_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e233f2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV63Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavPassword_action_Enabled!=0)&&(edtavPassword_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 158,'',false,'',149)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV64Password_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV64Password_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV77Password_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV64Password_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV64Password_Action)) ? AV77Password_action_GXI : context.PathToRelativeUrl( AV64Password_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavPassword_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtavPassword_action_Enabled,(string)"Change Password",(string)edtavPassword_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavPassword_action_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e243f2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV64Password_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 159,'',false,'',149)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV65Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV65Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV78Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV65Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV65Delete_Action)) ? AV78Delete_action_GXI : context.PathToRelativeUrl( AV65Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtavDelete_action_Enabled,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavDelete_action_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e253f2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV65Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3F2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_149_idx = ((subGrid_Islastpage==1)&&(nGXsfl_149_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_149_idx+1);
         sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
         SubsflControlProps_1492( ) ;
         /* End function sendrow_1492 */
      }

      protected void init_web_controls( )
      {
         cmbavFilauttype.Name = "vFILAUTTYPE";
         cmbavFilauttype.WebTags = "";
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV16FilAutType = cmbavFilauttype.getValidValue(AV16FilAutType);
            AssignAttri("", false, "AV16FilAutType", AV16FilAutType);
         }
         chkavIsvisible_authenticationtypename.Name = "vISVISIBLE_AUTHENTICATIONTYPENAME";
         chkavIsvisible_authenticationtypename.WebTags = "";
         chkavIsvisible_authenticationtypename.Caption = "";
         AssignProp("", false, chkavIsvisible_authenticationtypename_Internalname, "TitleCaption", chkavIsvisible_authenticationtypename.Caption, true);
         chkavIsvisible_authenticationtypename.CheckedValue = "false";
         AV45IsVisible_AuthenticationTypeName = StringUtil.StrToBool( StringUtil.BoolToStr( AV45IsVisible_AuthenticationTypeName));
         AssignAttri("", false, "AV45IsVisible_AuthenticationTypeName", AV45IsVisible_AuthenticationTypeName);
         chkavIsvisible_name.Name = "vISVISIBLE_NAME";
         chkavIsvisible_name.WebTags = "";
         chkavIsvisible_name.Caption = "";
         AssignProp("", false, chkavIsvisible_name_Internalname, "TitleCaption", chkavIsvisible_name.Caption, true);
         chkavIsvisible_name.CheckedValue = "false";
         AV46IsVisible_Name = StringUtil.StrToBool( StringUtil.BoolToStr( AV46IsVisible_Name));
         AssignAttri("", false, "AV46IsVisible_Name", AV46IsVisible_Name);
         chkavIsvisible_firstname.Name = "vISVISIBLE_FIRSTNAME";
         chkavIsvisible_firstname.WebTags = "";
         chkavIsvisible_firstname.Caption = "";
         AssignProp("", false, chkavIsvisible_firstname_Internalname, "TitleCaption", chkavIsvisible_firstname.Caption, true);
         chkavIsvisible_firstname.CheckedValue = "false";
         AV47IsVisible_FirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV47IsVisible_FirstName));
         AssignAttri("", false, "AV47IsVisible_FirstName", AV47IsVisible_FirstName);
         chkavIsvisible_lastname.Name = "vISVISIBLE_LASTNAME";
         chkavIsvisible_lastname.WebTags = "";
         chkavIsvisible_lastname.Caption = "";
         AssignProp("", false, chkavIsvisible_lastname_Internalname, "TitleCaption", chkavIsvisible_lastname.Caption, true);
         chkavIsvisible_lastname.CheckedValue = "false";
         AV48IsVisible_LastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV48IsVisible_LastName));
         AssignAttri("", false, "AV48IsVisible_LastName", AV48IsVisible_LastName);
         chkavIsvisible_email.Name = "vISVISIBLE_EMAIL";
         chkavIsvisible_email.WebTags = "";
         chkavIsvisible_email.Caption = "";
         AssignProp("", false, chkavIsvisible_email_Internalname, "TitleCaption", chkavIsvisible_email.Caption, true);
         chkavIsvisible_email.CheckedValue = "false";
         AV49IsVisible_Email = StringUtil.StrToBool( StringUtil.BoolToStr( AV49IsVisible_Email));
         AssignAttri("", false, "AV49IsVisible_Email", AV49IsVisible_Email);
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV55GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV55GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV55GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV70FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV70FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV70FreezeColumnTitles_Grid", AV70FreezeColumnTitles_Grid);
         GXCCtl = "vISAUTOREGISTERUSER_" + sGXsfl_149_idx;
         chkavIsautoregisteruser.Name = GXCCtl;
         chkavIsautoregisteruser.WebTags = "";
         chkavIsautoregisteruser.Caption = "";
         AssignProp("", false, chkavIsautoregisteruser_Internalname, "TitleCaption", chkavIsautoregisteruser.Caption, !bGXsfl_149_Refreshing);
         chkavIsautoregisteruser.CheckedValue = "false";
         AV29IsAutoRegisterUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV29IsAutoRegisterUser));
         AssignAttri("", false, chkavIsautoregisteruser_Internalname, AV29IsAutoRegisterUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTOREGISTERUSER"+"_"+sGXsfl_149_idx, GetSecureSignedToken( sGXsfl_149_idx, AV29IsAutoRegisterUser, context));
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         Filtertagsusercontrol_grid_Internalname = "FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_section5_grid_Internalname = "LAYOUTDEFINED_SECTION5_GRID";
         imgLayoutdefined_filterclose_onlydetailed_grid_Internalname = "LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID";
         edtavFilname_Internalname = "vFILNAME";
         divTable_container_filname_Internalname = "TABLE_CONTAINER_FILNAME";
         edtavFilnames_Internalname = "vFILNAMES";
         divTable_container_filnames_Internalname = "TABLE_CONTAINER_FILNAMES";
         edtavFilemail_Internalname = "vFILEMAIL";
         divTable_container_filemail_Internalname = "TABLE_CONTAINER_FILEMAIL";
         cmbavFilauttype_Internalname = "vFILAUTTYPE";
         divTable_container_filauttype_Internalname = "TABLE_CONTAINER_FILAUTTYPE";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = "LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         imgGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         chkavIsvisible_authenticationtypename_Internalname = "vISVISIBLE_AUTHENTICATIONTYPENAME";
         divAuthenticationtypename_gridsettingscontainer_Internalname = "AUTHENTICATIONTYPENAME_GRIDSETTINGSCONTAINER";
         chkavIsvisible_name_Internalname = "vISVISIBLE_NAME";
         divName_gridsettingscontainer_Internalname = "NAME_GRIDSETTINGSCONTAINER";
         chkavIsvisible_firstname_Internalname = "vISVISIBLE_FIRSTNAME";
         divFirstname_gridsettingscontainer_Internalname = "FIRSTNAME_GRIDSETTINGSCONTAINER";
         chkavIsvisible_lastname_Internalname = "vISVISIBLE_LASTNAME";
         divLastname_gridsettingscontainer_Internalname = "LASTNAME_GRIDSETTINGSCONTAINER";
         chkavIsvisible_email_Internalname = "vISVISIBLE_EMAIL";
         divEmail_gridsettingscontainer_Internalname = "EMAIL_GRIDSETTINGSCONTAINER";
         divGridsettings_tablecontentgrid_Internalname = "GRIDSETTINGS_TABLECONTENTGRID";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = "ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = "vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRID";
         bttAdd_Internalname = "ADD";
         tblActions_grid_topright_Internalname = "ACTIONS_GRID_TOPRIGHT";
         tblLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         edtavName_Internalname = "vNAME";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         edtavUserid_Internalname = "vUSERID";
         edtavEmail_Internalname = "vEMAIL";
         chkavIsautoregisteruser_Internalname = "vISAUTOREGISTERUSER";
         edtavUpdate_action_Internalname = "vUPDATE_ACTION";
         edtavPassword_action_Internalname = "vPASSWORD_ACTION";
         edtavDelete_action_Internalname = "vDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = "LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
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
         chkavFreezecolumntitles_grid.Caption = "Inmovilizar títulos";
         chkavIsvisible_email.Caption = "Correo electrónico";
         chkavIsvisible_lastname.Caption = "Apellido";
         chkavIsvisible_firstname.Caption = "Primer nombre";
         chkavIsvisible_name.Caption = "Nombre";
         chkavIsvisible_authenticationtypename.Caption = "Autenticación";
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_Visible = -1;
         edtavPassword_action_Jsonclick = "";
         edtavPassword_action_Visible = -1;
         edtavUpdate_action_Jsonclick = "";
         edtavUpdate_action_Visible = -1;
         chkavIsautoregisteruser.Caption = "";
         chkavIsautoregisteruser.Visible = 0;
         edtavEmail_Jsonclick = "";
         edtavUserid_Jsonclick = "";
         edtavUserid_Visible = 0;
         edtavLastname_Jsonclick = "";
         edtavFirstname_Jsonclick = "";
         edtavName_Jsonclick = "";
         edtavAuthenticationtypename_Jsonclick = "";
         bttAdd_Visible = 1;
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         chkavIsvisible_email.Enabled = 1;
         chkavIsvisible_lastname.Enabled = 1;
         chkavIsvisible_firstname.Enabled = 1;
         chkavIsvisible_name.Enabled = 1;
         chkavIsvisible_authenticationtypename.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_grid_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_action_Tooltiptext = "";
         edtavDelete_action_Enabled = 1;
         edtavPassword_action_Tooltiptext = "";
         edtavPassword_action_Enabled = 1;
         edtavUpdate_action_Tooltiptext = "";
         edtavUpdate_action_Enabled = 1;
         chkavIsautoregisteruser.Enabled = 1;
         edtavEmail_Enabled = 1;
         edtavUserid_Enabled = 1;
         edtavLastname_Enabled = 1;
         edtavFirstname_Enabled = 1;
         edtavName_Link = "";
         edtavName_Enabled = 1;
         edtavAuthenticationtypename_Enabled = 1;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavEmail_Visible = -1;
         edtavLastname_Visible = -1;
         edtavFirstname_Visible = -1;
         edtavName_Visible = -1;
         edtavAuthenticationtypename_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         cmbavFilauttype_Jsonclick = "";
         cmbavFilauttype.Enabled = 1;
         edtavFilemail_Jsonclick = "";
         edtavFilemail_Enabled = 1;
         edtavFilnames_Jsonclick = "";
         edtavFilnames_Enabled = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuarios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{ctrl:'ADD',prop:'Visible'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E183F2',iparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV63Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Enabled',ctrl:'vUPDATE_ACTION',prop:'Enabled'},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV64Password_Action',fld:'vPASSWORD_ACTION',pic:''},{av:'edtavPassword_action_Enabled',ctrl:'vPASSWORD_ACTION',prop:'Enabled'},{av:'edtavPassword_action_Tooltiptext',ctrl:'vPASSWORD_ACTION',prop:'Tooltiptext'},{av:'AV65Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Enabled',ctrl:'vDELETE_ACTION',prop:'Enabled'},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV9AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV32Name',fld:'vNAME',pic:''},{av:'AV22FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV30LastName',fld:'vLASTNAME',pic:''},{av:'AV12Email',fld:'vEMAIL',pic:''},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'edtavName_Link',ctrl:'vNAME',prop:'Link'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E113F1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{ctrl:'ADD',prop:'Visible'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E133F1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{ctrl:'ADD',prop:'Visible'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ADD'","{handler:'E223F1',iparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_PASSWORD'","{handler:'E243F2',iparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_PASSWORD'",",oparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E253F2',iparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E123F1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{ctrl:'ADD',prop:'Visible'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E213F1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV55GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E143F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{av:'AV29IsAutoRegisterUser',fld:'vISAUTOREGISTERUSER',pic:'',hsh:true},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV55GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV7AnonymousUserGUID',fld:'vANONYMOUSUSERGUID',pic:'',hsh:true},{ctrl:'ADD',prop:'Visible'},{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E233F2',iparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV39UserId',fld:'vUSERID',pic:''},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E203F2',iparms:[{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV18FilName',fld:'vFILNAME',pic:''},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV19FilNames',fld:'vFILNAMES',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV17FilEmail',fld:'vFILEMAIL',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavFilauttype'},{av:'AV16FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV69ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV56FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:''},{av:'AV11CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57FilNames_PreviousValue',fld:'vFILNAMES_PREVIOUSVALUE',pic:''},{av:'AV58FilEmail_PreviousValue',fld:'vFILEMAIL_PREVIOUSVALUE',pic:''},{av:'AV59FilAutType_PreviousValue',fld:'vFILAUTTYPE_PREVIOUSVALUE',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'AV67FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'AV66GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{ctrl:'ADD',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavEmail_Visible',ctrl:'vEMAIL',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E153F2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK","{handler:'E163F2',iparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete_action',iparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV45IsVisible_AuthenticationTypeName',fld:'vISVISIBLE_AUTHENTICATIONTYPENAME',pic:''},{av:'AV46IsVisible_Name',fld:'vISVISIBLE_NAME',pic:''},{av:'AV47IsVisible_FirstName',fld:'vISVISIBLE_FIRSTNAME',pic:''},{av:'AV48IsVisible_LastName',fld:'vISVISIBLE_LASTNAME',pic:''},{av:'AV49IsVisible_Email',fld:'vISVISIBLE_EMAIL',pic:''},{av:'AV70FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
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
         AV69ClassCollection_Grid = new GxSimpleCollection<string>();
         AV56FilName_PreviousValue = "";
         AV18FilName = "";
         AV57FilNames_PreviousValue = "";
         AV19FilNames = "";
         AV58FilEmail_PreviousValue = "";
         AV17FilEmail = "";
         AV59FilAutType_PreviousValue = "";
         AV16FilAutType = "";
         AV74Pgmname = "";
         AV66GridConfiguration = new SdtK2BGridConfiguration(context);
         AV39UserId = "";
         AV7AnonymousUserGUID = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV67FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV68DeletedTag_Grid = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV9AuthenticationTypeName = "";
         AV32Name = "";
         AV22FirstName = "";
         AV30LastName = "";
         AV12Email = "";
         AV63Update_Action = "";
         AV64Password_Action = "";
         AV65Delete_Action = "";
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV76Update_action_GXI = "";
         AV77Password_action_GXI = "";
         AV78Delete_action_GXI = "";
         AV42Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV21FilterAutType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV14Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV35Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         GridRow = new GXWebRow();
         AV20Filter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV40Users = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV38User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV25GridStateKey = "";
         AV23GridState = new SdtK2BGridState(context);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV44GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         GXt_char2 = "";
         AV43GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV61K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV62K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         bttAdd_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         AV74Pgmname = "K2BFSG.WWUser";
         /* GeneXus formulas. */
         AV74Pgmname = "K2BFSG.WWUser";
         context.Gx_err = 0;
         edtavAuthenticationtypename_Enabled = 0;
         edtavName_Enabled = 0;
         edtavFirstname_Enabled = 0;
         edtavLastname_Enabled = 0;
         edtavUserid_Enabled = 0;
         edtavEmail_Enabled = 0;
         chkavIsautoregisteruser.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11CurrentPage_Grid ;
      private short AV54RowsPerPage_Grid ;
      private short AV28I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV55GridSettingsRowsPerPage_Grid ;
      private short GRID_nEOF ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_149 ;
      private int nGXsfl_149_idx=1 ;
      private int edtavFilname_Enabled ;
      private int edtavFilnames_Enabled ;
      private int edtavFilemail_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavAuthenticationtypename_Visible ;
      private int edtavName_Visible ;
      private int edtavFirstname_Visible ;
      private int edtavLastname_Visible ;
      private int edtavEmail_Visible ;
      private int edtavAuthenticationtypename_Enabled ;
      private int edtavName_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavUserid_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavUpdate_action_Enabled ;
      private int edtavPassword_action_Enabled ;
      private int edtavDelete_action_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int AV73GXV1 ;
      private int AV75GXV2 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV79GXV3 ;
      private int AV80GXV4 ;
      private int bttAdd_Visible ;
      private int AV81GXV5 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavUserid_Visible ;
      private int edtavUpdate_action_Visible ;
      private int edtavPassword_action_Visible ;
      private int edtavDelete_action_Visible ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_149_idx="0001" ;
      private string AV57FilNames_PreviousValue ;
      private string AV19FilNames ;
      private string AV59FilAutType_PreviousValue ;
      private string AV16FilAutType ;
      private string AV74Pgmname ;
      private string AV39UserId ;
      private string AV7AnonymousUserGUID ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV68DeletedTag_Grid ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlydetailedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_section5_grid_Internalname ;
      private string TempTags ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filterclose_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_filname_Internalname ;
      private string edtavFilname_Internalname ;
      private string edtavFilname_Jsonclick ;
      private string divTable_container_filnames_Internalname ;
      private string edtavFilnames_Internalname ;
      private string edtavFilnames_Jsonclick ;
      private string divTable_container_filemail_Internalname ;
      private string edtavFilemail_Internalname ;
      private string edtavFilemail_Jsonclick ;
      private string divTable_container_filauttype_Internalname ;
      private string cmbavFilauttype_Internalname ;
      private string cmbavFilauttype_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string AV9AuthenticationTypeName ;
      private string AV32Name ;
      private string edtavName_Link ;
      private string AV22FirstName ;
      private string AV30LastName ;
      private string edtavUpdate_action_Tooltiptext ;
      private string edtavPassword_action_Tooltiptext ;
      private string edtavDelete_action_Tooltiptext ;
      private string divLayoutdefined_section8_grid_Internalname ;
      private string divPaginationbar_pagingcontainertable_grid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Class ;
      private string lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private string lblPaginationbar_firstpagetextblockgrid_Caption ;
      private string lblPaginationbar_firstpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgrid_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagetextblockgrid_Caption ;
      private string lblPaginationbar_previouspagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private string lblPaginationbar_currentpagetextblockgrid_Caption ;
      private string lblPaginationbar_currentpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagetextblockgrid_Caption ;
      private string lblPaginationbar_nextpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAuthenticationtypename_Internalname ;
      private string edtavName_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavUserid_Internalname ;
      private string edtavEmail_Internalname ;
      private string chkavIsautoregisteruser_Internalname ;
      private string edtavUpdate_action_Internalname ;
      private string edtavPassword_action_Internalname ;
      private string edtavDelete_action_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Internalname ;
      private string chkavIsvisible_authenticationtypename_Internalname ;
      private string chkavIsvisible_name_Internalname ;
      private string chkavIsvisible_firstname_Internalname ;
      private string chkavIsvisible_lastname_Internalname ;
      private string chkavIsvisible_email_Internalname ;
      private string chkavFreezecolumntitles_grid_Internalname ;
      private string divGridsettings_contentoutertablegrid_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string bttAdd_Internalname ;
      private string GXt_char2 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string tblLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string imgGridsettings_labelgrid_Internalname ;
      private string imgGridsettings_labelgrid_Jsonclick ;
      private string divGslayoutdefined_gridcontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_grid_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname ;
      private string divGridsettings_tablecontentgrid_Internalname ;
      private string divAuthenticationtypename_gridsettingscontainer_Internalname ;
      private string divName_gridsettingscontainer_Internalname ;
      private string divFirstname_gridsettingscontainer_Internalname ;
      private string divLastname_gridsettingscontainer_Internalname ;
      private string divEmail_gridsettingscontainer_Internalname ;
      private string divRowsperpagecontainer_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private string divFreezecolumntitlescontainer_grid_Internalname ;
      private string bttGridsettings_savegrid_Internalname ;
      private string bttGridsettings_savegrid_Jsonclick ;
      private string tblActions_grid_topright_Internalname ;
      private string bttAdd_Jsonclick ;
      private string sGXsfl_149_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavAuthenticationtypename_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Jsonclick ;
      private string edtavUserid_Jsonclick ;
      private string edtavEmail_Jsonclick ;
      private string GXCCtl ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavPassword_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26HasNextPage_Grid ;
      private bool AV29IsAutoRegisterUser ;
      private bool AV45IsVisible_AuthenticationTypeName ;
      private bool AV46IsVisible_Name ;
      private bool AV47IsVisible_FirstName ;
      private bool AV48IsVisible_LastName ;
      private bool AV49IsVisible_Email ;
      private bool AV70FreezeColumnTitles_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_149_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV60RowsPerPageLoaded_Grid ;
      private bool AV15Exit_Grid ;
      private bool gx_refresh_fired ;
      private bool AV34Reload_Grid ;
      private bool AV63Update_Action_IsBlob ;
      private bool AV64Password_Action_IsBlob ;
      private bool AV65Delete_Action_IsBlob ;
      private string AV56FilName_PreviousValue ;
      private string AV18FilName ;
      private string AV58FilEmail_PreviousValue ;
      private string AV17FilEmail ;
      private string AV12Email ;
      private string AV76Update_action_GXI ;
      private string AV77Password_action_GXI ;
      private string AV78Delete_action_GXI ;
      private string AV25GridStateKey ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap ;
      private string AV63Update_Action ;
      private string AV64Password_Action ;
      private string AV65Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFilauttype ;
      private GXCheckbox chkavIsvisible_authenticationtypename ;
      private GXCheckbox chkavIsvisible_name ;
      private GXCheckbox chkavIsvisible_firstname ;
      private GXCheckbox chkavIsvisible_lastname ;
      private GXCheckbox chkavIsvisible_email ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private GXCheckbox chkavIsautoregisteruser ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV69ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV10AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV42Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV40Users ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV43GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV61K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV67FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV8AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV20Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV21FilterAutType ;
      private SdtK2BGridState AV23GridState ;
      private SdtK2BGridState_FilterValue AV24GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV31Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV35Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV38User ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV44GridColumn ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV62K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV66GridConfiguration ;
   }

}
