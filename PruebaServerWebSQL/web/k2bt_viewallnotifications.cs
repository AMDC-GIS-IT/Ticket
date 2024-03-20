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
   public class k2bt_viewallnotifications : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public k2bt_viewallnotifications( )
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

      public k2bt_viewallnotifications( IGxContext context )
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
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp = new GXCombobox();
         chkavNotificationisread = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridgetlatestnotificationsforcurrentuserdp") == 0 )
            {
               nRC_GXsfl_57 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."));
               nGXsfl_57_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."));
               sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridgetlatestnotificationsforcurrentuserdp_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridgetlatestnotificationsforcurrentuserdp") == 0 )
            {
               AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( GetPar( "CurrentPage_GridGetLatestNotificationsForCurrentUserDP"), "."));
               AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( GetPar( "RowsPerPage_GridGetLatestNotificationsForCurrentUserDP"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
               AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = StringUtil.StrToBool( GetPar( "HasNextPage_GridGetLatestNotificationsForCurrentUserDP"));
               AV29Pgmname = GetPar( "Pgmname");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP, AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP, AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, AV29Pgmname) ;
               GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0, ".", "")));
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
            return "k2bt_viewallnotifications_Execute" ;
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
         PA1S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1S2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249524767", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bt_viewallnotifications.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0, ".", "")));
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
            WE1S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1S2( ) ;
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
         return formatLink("k2bt_viewallnotifications.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BT_ViewAllNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2 BT_View All Notifications" ;
      }

      protected void WB1S0( )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_21_1S2( true) ;
         }
         else
         {
            wb_table1_21_1S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_1S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridgetlatestnotificationsforcurrentuserdpContainer.SetWrapped(nGXWrapped);
            if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"DivS\" data-gxgridid=\"57\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridgetlatestnotificationsforcurrentuserdp_Internalname, subGridgetlatestnotificationsforcurrentuserdp_Internalname, "", "Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                  {
                     subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Title";
                  }
               }
               else
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle = 1;
                  if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 1 )
                  {
                     subGridgetlatestnotificationsforcurrentuserdp_Titlebackcolor = subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor;
                     if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                     {
                        subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridgetlatestnotificationsforcurrentuserdp_Class) > 0 )
                     {
                        subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Texto de notificación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(97), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Event Target Url") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Notificación leída?") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
            }
            else
            {
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Header", subGridgetlatestnotificationsforcurrentuserdp_Header);
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "Grid_WorkWith");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationid_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", AV20NotificationText);
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationtext_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", AV10EventTargetUrl);
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEventtargeturl_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV19NotificationIsRead));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavNotificationisread.Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.RTrim( AV21Open_Action));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOpen_action_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", StringUtil.RTrim( AV15MarkAsRead_Action));
               GridgetlatestnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Enabled), 5, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetlatestnotificationsforcurrentuserdpColumn);
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Selectedindex), 4, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowselection), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Selectioncolor), 9, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowhovering), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Hoveringcolor), 9, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing), 1, 0, ".", "")));
               GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
            if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetlatestnotificationsforcurrentuserdp", GridgetlatestnotificationsforcurrentuserdpContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData", GridgetlatestnotificationsforcurrentuserdpContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData"+"V", GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetlatestnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_66_1S2( true) ;
         }
         else
         {
            wb_table2_66_1S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_66_1S2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111s1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121s1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111s1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131s1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131s1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
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
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridgetlatestnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetlatestnotificationsforcurrentuserdp", GridgetlatestnotificationsforcurrentuserdpContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData", GridgetlatestnotificationsforcurrentuserdpContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetlatestnotificationsforcurrentuserdpContainerData"+"V", GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetlatestnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetlatestnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1S2( )
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
            Form.Meta.addItem("description", "K2 BT_View All Notifications", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1S0( ) ;
      }

      protected void WS1S2( )
      {
         START1S2( ) ;
         EVT1S2( ) ;
      }

      protected void EVT1S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(GridGetLatestNotificationsForCurrentUserDP)' */
                              E141S2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 47), "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) )
                           {
                              nGXsfl_57_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV18NotificationId = 0;
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV18NotificationId = (long)(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ",", "."));
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              AV20NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri("", false, edtavNotificationtext_Internalname, AV20NotificationText);
                              AV10EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri("", false, edtavEventtargeturl_Internalname, AV10EventTargetUrl);
                              GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
                              AV19NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
                              AV21Open_Action = cgiGet( edtavOpen_action_Internalname);
                              AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
                              AV15MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignAttri("", false, edtavMarkasread_action_Internalname, AV15MarkAsRead_Action);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E151S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E161S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E171S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_OPEN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Open' */
                                    E181S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_MARKASREAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_MarkAsRead' */
                                    E191S2 ();
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

      protected void WE1S2( )
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

      protected void PA1S2( )
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
               GX_FocusControl = cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridgetlatestnotificationsforcurrentuserdp_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGridgetlatestnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_57_idx+1>subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridgetlatestnotificationsforcurrentuserdpContainer)) ;
         /* End function gxnrGridgetlatestnotificationsforcurrentuserdp_newrow */
      }

      protected void gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( short AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             short AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             bool AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP ,
                                                                             string AV29Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E161S2 ();
         GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord = 0;
         RF1S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridgetlatestnotificationsforcurrentuserdp_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "vEVENTTARGETURL", AV10EventTargetUrl);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0))), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Values", cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void RF1S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridgetlatestnotificationsforcurrentuserdpContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E161S2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetlatestnotificationsforcurrentuserdp");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "Grid_WorkWith");
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetlatestnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
         GridgetlatestnotificationsforcurrentuserdpContainer.PageSize = subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( );
         if ( subGridgetlatestnotificationsforcurrentuserdp_Islastpage != 0 )
         {
            GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage = (long)(subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordcount( )-subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage), 15, 0, ".", "")));
            GridgetlatestnotificationsforcurrentuserdpContainer.AddObjectProperty("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_572( ) ;
            E171S2 ();
            wbEnd = 57;
            WB1S0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1S2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetlatestnotificationsforcurrentuserdp_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E151S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), ",", "."));
            AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP"), ",", "."));
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP"), ",", "."));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Name = cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname;
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname);
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
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
         E151S2 ();
         if (returnInSub) return;
      }

      protected void E151S2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle = 3;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         if ( (0==AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP) )
         {
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         if ( StringUtil.StrCmp(AV13HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E161S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
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
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      private void E171S2( )
      {
         /* Gridgetlatestnotificationsforcurrentuserdp_Load Routine */
         returnInSub = false;
         AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification1 = AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP;
         new GeneXus.Programs.k2btools.integrationprocedures.getallnotificationsforcurrentuserdp(context ).execute(  AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP,  (AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP-1)*(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), out  GXt_objcol_SdtWebNotificationSDT_Notification1) ;
         AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP = GXt_objcol_SdtWebNotificationSDT_Notification1;
         if ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count == 0 )
         {
            tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count == 0 ) || ( AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count < AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ) )
         {
            AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = false;
            AssignAttri("", false, "AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         }
         else
         {
            AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP = true;
            AssignAttri("", false, "AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, context));
         }
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Count )
         {
            AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP.Item(AV28GXV1));
            AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP = (short)(AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP+1);
            AV18NotificationId = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationid;
            AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV18NotificationId), 15, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9"), context));
            AV20NotificationText = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationtext;
            AssignAttri("", false, edtavNotificationtext_Internalname, AV20NotificationText);
            AV10EventTargetUrl = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Eventtargeturl;
            AssignAttri("", false, edtavEventtargeturl_Internalname, AV10EventTargetUrl);
            GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_57_idx, GetSecureSignedToken( sGXsfl_57_idx, StringUtil.RTrim( context.localUtil.Format( AV10EventTargetUrl, "")), context));
            AV19NotificationIsRead = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationisread;
            AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
            AV21Open_Action = "Abrir";
            AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
            AV15MarkAsRead_Action = "Marcar como leído";
            AssignAttri("", false, edtavMarkasread_action_Internalname, AV15MarkAsRead_Action);
            /* Execute user subroutine: 'U_LOADROWVARS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' */
            S142 ();
            if (returnInSub) return;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 57;
            }
            sendrow_572( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
            {
               context.DoAjaxLoad(57, GridgetlatestnotificationsforcurrentuserdpRow);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP", AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP);
      }

      protected void S142( )
      {
         /* 'U_LOADROWVARS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         AV21Open_Action = AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP.gxTpr_Notificationactioncaption;
         AssignAttri("", false, edtavOpen_action_Internalname, AV21Open_Action);
      }

      protected void S172( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
         if ( (0==AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP) || ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            if ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP == 2 )
            {
               lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               if ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP <= 1 ) && ! AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
      }

      protected void E141S2( )
      {
         /* 'SaveGridSettings(GridGetLatestNotificationsForCurrentUserDP)' Routine */
         returnInSub = false;
         if ( AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP != AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP )
         {
            AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP = AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP;
            AssignAttri("", false, "AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV29Pgmname,  "GridGetLatestNotificationsForCurrentUserDP",  AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP) ;
            AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         gxgrGridgetlatestnotificationsforcurrentuserdp_refresh( AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP, AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP, AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP, AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP, AV29Pgmname) ;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E181S2( )
      {
         /* 'E_Open' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPEN' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'U_OPEN' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV10EventTargetUrl) );
         context.wjLocDisableFrm = 0;
      }

      protected void E191S2( )
      {
         /* 'E_MarkAsRead' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'U_MARKASREAD' Routine */
         returnInSub = false;
         GXt_int2 = (short)(Convert.ToInt16(AV24Success));
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV18NotificationId), out  GXt_int2, out  AV17Messages) ;
         AV24Success = (bool)(Convert.ToBoolean(GXt_int2));
         if ( AV24Success )
         {
            context.CommitDataStores("k2bt_viewallnotifications",pr_default);
         }
         else
         {
            AV30GXV2 = 1;
            while ( AV30GXV2 <= AV17Messages.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV17Messages.Item(AV30GXV2));
               new GeneXus.Core.genexus.common.SdtLog(context).error("Error marking notification as read: "+AV16Message.gxTpr_Id+" - "+AV16Message.gxTpr_Description, "K2BTools.Notifications.ViewAllNotifications") ;
               AV30GXV2 = (int)(AV30GXV2+1);
            }
            context.RollbackDataStores("k2bt_viewallnotifications",pr_default);
         }
      }

      protected void wb_table2_66_1S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_66_1S2e( true) ;
         }
         else
         {
            wb_table2_66_1S2e( false) ;
         }
      }

      protected void wb_table1_21_1S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname, tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "", "", lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e201s1_client"+"'", "", "K2BToolsTextBlock_GridSettingsTitle", 7, "", 1, 1, 0, 1, "HLP_K2BT_ViewAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname, divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_33_1S2( true) ;
         }
         else
         {
            wb_table3_33_1S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_33_1S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", "Guardar", bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BT_ViewAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_1S2e( true) ;
         }
         else
         {
            wb_table1_21_1S2e( false) ;
         }
      }

      protected void wb_table3_33_1S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname, tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_GridSettingsContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname, "Filas por página", "", "", lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BT_ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Grid Settings Rows Per Page_Grid Get Latest Notifications For Current User DP", "gx-form-item K2BToolsEnhancedComboLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0)), 1, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "Filas por página", 1, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsEnhancedCombo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 1, "HLP_K2BT_ViewAllNotifications.htm");
            cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_33_1S2e( true) ;
         }
         else
         {
            wb_table3_33_1S2e( false) ;
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
         PA1S2( ) ;
         WS1S2( ) ;
         WE1S2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249524835", true, true);
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
            context.AddJavascriptSource("k2bt_viewallnotifications.js", "?20231249524835", false, true);
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_572( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_57_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_57_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_57_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_57_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_57_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_57_fel_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_57_fel_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_57_fel_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_57_fel_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_57_fel_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         SubsflControlProps_572( ) ;
         WB1S0( ) ;
         GridgetlatestnotificationsforcurrentuserdpRow = GXWebRow.GetNew(context,GridgetlatestnotificationsforcurrentuserdpContainer);
         if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
            }
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 0;
            subGridgetlatestnotificationsforcurrentuserdp_Backcolor = subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Uniform";
            }
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
            }
            subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
         }
         else if ( subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridgetlatestnotificationsforcurrentuserdp_Backstyle = 1;
            if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
            {
               subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Even";
               }
            }
            else
            {
               subGridgetlatestnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetlatestnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetlatestnotificationsforcurrentuserdp_Linesclass = subGridgetlatestnotificationsforcurrentuserdp_Class+"Odd";
               }
            }
         }
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 58,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NotificationId), 15, 0, ",", "")),((edtavNotificationid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV18NotificationId), "ZZZZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtavNotificationid_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(string)"K2BTools\\K2BT_LargeId",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,(string)AV20NotificationText,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,59);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationtext_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavNotificationtext_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"K2BTools\\K2BT_NotificationMessage",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,(string)AV10EventTargetUrl,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)AV10EventTargetUrl,(string)"_blank",(string)"",(string)"",(string)edtavEventtargeturl_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavEventtargeturl_Enabled,(short)0,(string)"url",(string)"",(short)97,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 61,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_57_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_57_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV19NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV19NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV19NotificationIsRead),(string)"",(string)"",(short)-1,chkavNotificationisread.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,61);\"" : " ")});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOpen_action_Internalname,StringUtil.RTrim( AV21Open_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,62);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_OPEN\\'."+sGXsfl_57_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOpen_action_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavOpen_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetlatestnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 63,'',false,'"+sGXsfl_57_idx+"',57)\"" : " ");
         ROClassString = "Attribute";
         GridgetlatestnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMarkasread_action_Internalname,StringUtil.RTrim( AV15MarkAsRead_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,63);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_MARKASREAD\\'."+sGXsfl_57_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMarkasread_action_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavMarkasread_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes1S2( ) ;
         GridgetlatestnotificationsforcurrentuserdpContainer.AddRow(GridgetlatestnotificationsforcurrentuserdpRow);
         nGXsfl_57_idx = ((subGridgetlatestnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_57_idx+1>subGridgetlatestnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Name = "vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.WebTags = "";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0))), "."));
            AssignAttri("", false, "AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP), 4, 0));
         }
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_57_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_57_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV19NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV19NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV19NotificationIsRead);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_LABELGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_ROWSPERPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_TABLECONTENTGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_SAVEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_GLOBALTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE7_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE10_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION7_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION3_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION1_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         edtavNotificationid_Internalname = "vNOTIFICATIONID";
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT";
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL";
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD";
         edtavOpen_action_Internalname = "vOPEN_ACTION";
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION";
         lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTABLENAME_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname = "MAINGRID_RESPONSIVETABLE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION8_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE3_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_GRID_INNER_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDCOMPONENTCONTENT_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridgetlatestnotificationsforcurrentuserdp_Internalname = "GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Visible = -1;
         edtavOpen_action_Jsonclick = "";
         edtavOpen_action_Visible = -1;
         chkavNotificationisread.Caption = "";
         chkavNotificationisread.Visible = -1;
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Visible = 0;
         edtavNotificationtext_Jsonclick = "";
         edtavNotificationtext_Visible = -1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 0;
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp.Enabled = 1;
         divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption = "1";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible = 1;
         subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing = 0;
         subGridgetlatestnotificationsforcurrentuserdp_Allowselection = 0;
         edtavMarkasread_action_Enabled = 1;
         edtavOpen_action_Enabled = 1;
         chkavNotificationisread.Enabled = 1;
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationtext_Enabled = 1;
         edtavNotificationid_Enabled = 1;
         subGridgetlatestnotificationsforcurrentuserdp_Sortable = 0;
         subGridgetlatestnotificationsforcurrentuserdp_Header = "";
         subGridgetlatestnotificationsforcurrentuserdp_Class = "Grid_WorkWith";
         subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "K2 BT_View All Notifications";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV29Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD","{handler:'E171S2',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true}]");
         setEventMetadata("GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true},{av:'AV20NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV10EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'AV19NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV21Open_Action',fld:'vOPEN_ACTION',pic:''},{av:'AV15MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E121S1',iparms:[]");
         setEventMetadata("'PAGINGFIRST(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E111S1',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'PAGINGNEXT(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E131S1',iparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'PAGINGNEXT(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E201S1',iparms:[{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp'},{av:'AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E141S2',iparms:[{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV29Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp'},{av:'AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'E_OPEN'","{handler:'E181S2',iparms:[{av:'AV10EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_OPEN'",",oparms:[]}");
         setEventMetadata("'E_MARKASREAD'","{handler:'E191S2',iparms:[{av:'AV18NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_MARKASREAD'",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Markasread_action',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         AV29Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridgetlatestnotificationsforcurrentuserdpContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridgetlatestnotificationsforcurrentuserdp_Linesclass = "";
         GridgetlatestnotificationsforcurrentuserdpColumn = new GXWebColumn();
         AV20NotificationText = "";
         AV10EventTargetUrl = "";
         AV21Open_Action = "";
         AV15MarkAsRead_Action = "";
         lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13HttpRequest = new GxHttpRequest( context);
         AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "kb_ticket");
         GXt_objcol_SdtWebNotificationSDT_Notification1 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "kb_ticket");
         GridgetlatestnotificationsforcurrentuserdpRow = new GXWebRow();
         AV17Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         TempTags = "";
         bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bt_viewallnotifications__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bt_viewallnotifications__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bt_viewallnotifications__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bt_viewallnotifications__default(),
            new Object[][] {
            }
         );
         AV29Pgmname = "K2BT_ViewAllNotifications";
         /* GeneXus formulas. */
         AV29Pgmname = "K2BT_ViewAllNotifications";
         context.Gx_err = 0;
         edtavNotificationid_Enabled = 0;
         edtavNotificationtext_Enabled = 0;
         edtavEventtargeturl_Enabled = 0;
         chkavNotificationisread.Enabled = 0;
         edtavOpen_action_Enabled = 0;
         edtavMarkasread_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV7CurrentPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short AV22RowsPerPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Backcolorstyle ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Titlebackstyle ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Sortable ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowselection ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowhovering ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Allowcollapsing ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV11GridSettingsRowsPerPage_GridGetLatestNotificationsForCurrentUserDP ;
      private short GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nEOF ;
      private short AV14I_LoadCount_GridGetLatestNotificationsForCurrentUserDP ;
      private short GXt_int2 ;
      private short subGridgetlatestnotificationsforcurrentuserdp_Backstyle ;
      private int divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int nRC_GXsfl_57 ;
      private int nGXsfl_57_idx=1 ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Titlebackcolor ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Allbackcolor ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavOpen_action_Enabled ;
      private int edtavMarkasread_action_Enabled ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Selectedindex ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Selectioncolor ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Hoveringcolor ;
      private int divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Islastpage ;
      private int tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Visible ;
      private int AV28GXV1 ;
      private int AV30GXV2 ;
      private int idxLst ;
      private int subGridgetlatestnotificationsforcurrentuserdp_Backcolor ;
      private int edtavNotificationid_Visible ;
      private int edtavNotificationtext_Visible ;
      private int edtavEventtargeturl_Visible ;
      private int edtavOpen_action_Visible ;
      private int edtavMarkasread_action_Visible ;
      private long AV18NotificationId ;
      private long GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord ;
      private long GRIDGETLATESTNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_57_idx="0001" ;
      private string AV29Pgmname ;
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
      private string divGridcomponentcontent_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_grid_inner_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_table10_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_table3_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_section1_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_section7_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_section3_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divMaingrid_responsivetable_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string sStyleString ;
      private string subGridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string subGridgetlatestnotificationsforcurrentuserdp_Class ;
      private string subGridgetlatestnotificationsforcurrentuserdp_Linesclass ;
      private string subGridgetlatestnotificationsforcurrentuserdp_Header ;
      private string AV21Open_Action ;
      private string AV15MarkAsRead_Action ;
      private string divLayoutdefined_section8_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divPaginationbar_pagingcontainertablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class ;
      private string lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_firstpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_previouspagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_currentpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_nextpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetlatestnotificationsforcurrentuserdp_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationid_Internalname ;
      private string edtavNotificationtext_Internalname ;
      private string edtavEventtargeturl_Internalname ;
      private string chkavNotificationisread_Internalname ;
      private string edtavOpen_action_Internalname ;
      private string edtavMarkasread_action_Internalname ;
      private string cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divGridsettings_contentoutertablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string tblI_noresultsfoundtablename_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblI_noresultsfoundtextblock_gridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string tblLayoutdefined_table7_gridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string divGridsettings_globaltablegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblGridsettings_labelgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string TempTags ;
      private string bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string bttGridsettings_savegridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string tblGridsettings_tablecontentgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Internalname ;
      private string lblGridsettings_rowsperpagetextblockgridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp_Jsonclick ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavNotificationid_Jsonclick ;
      private string edtavNotificationtext_Jsonclick ;
      private string edtavEventtargeturl_Jsonclick ;
      private string GXCCtl ;
      private string edtavOpen_action_Jsonclick ;
      private string edtavMarkasread_action_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12HasNextPage_GridGetLatestNotificationsForCurrentUserDP ;
      private bool wbLoad ;
      private bool AV19NotificationIsRead ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV24Success ;
      private string AV20NotificationText ;
      private string AV10EventTargetUrl ;
      private GXWebGrid GridgetlatestnotificationsforcurrentuserdpContainer ;
      private GXWebRow GridgetlatestnotificationsforcurrentuserdpRow ;
      private GXWebColumn GridgetlatestnotificationsforcurrentuserdpColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_gridgetlatestnotificationsforcurrentuserdp ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV13HttpRequest ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV8DP_SDT_GridGetLatestNotificationsForCurrentUserDP ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification1 ;
      private GXBaseCollection<SdtMessages_Message> AV17Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV9DP_SDT_ITEM_GridGetLatestNotificationsForCurrentUserDP ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
   }

   public class k2bt_viewallnotifications__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class k2bt_viewallnotifications__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class k2bt_viewallnotifications__gam : DataStoreHelperBase, IDataStoreHelper
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

public class k2bt_viewallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
