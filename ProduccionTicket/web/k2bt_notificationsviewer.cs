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
   public class k2bt_notificationsviewer : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public k2bt_notificationsviewer( )
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

      public k2bt_notificationsviewer( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavNotificationisread = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Notificationsgrid") == 0 )
               {
                  nRC_GXsfl_54 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."));
                  nGXsfl_54_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."));
                  sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
                  sPrefix = GetPar( "sPrefix");
                  AV25MarkAsRead_Action = GetPar( "MarkAsRead_Action");
                  edtavMarkasread_action_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_54_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrNotificationsgrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Notificationsgrid") == 0 )
               {
                  AV25MarkAsRead_Action = GetPar( "MarkAsRead_Action");
                  edtavMarkasread_action_Tooltiptext = GetNextPar( );
                  AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_54_Refreshing);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV12DP_SDT_ITEM_NotificationsGrid);
                  AV33NotificationIsRead = StringUtil.StrToBool( GetPar( "NotificationIsRead"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrNotificationsgrid_refresh( AV25MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, AV33NotificationIsRead, sPrefix) ;
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
            PA132( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavViewall_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
               edtavEnablenotifications_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnablenotifications_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnablenotifications_action_Enabled), 5, 0), true);
               edtavRefresh_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
               WS132( ) ;
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
            context.SendWebValue( "K2 BT_Notifications Viewer") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188312678", false, true);
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
         context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bt_notificationsviewer.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_54), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESKTOPNOTIFICATIONSPERMISSION", StringUtil.RTrim( AV10DesktopNotificationsPermission));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESKTOPNOTIFICATIONTAG", StringUtil.RTrim( AV11DesktopNotificationTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICATIONINFO", AV32NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICATIONINFO", AV32NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTIFICATIONINFO_Message", AV32NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMARKASREAD_ACTION_Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
      }

      protected void RenderHtmlCloseForm132( )
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
         return "K2BT_NotificationsViewer" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2 BT_Notifications Viewer" ;
      }

      protected void WB130( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bt_notificationsviewer.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
               context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_132( true) ;
         }
         else
         {
            wb_table1_15_132( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_132e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_notificationsgrid_Internalname, divGridcomponentcontent_notificationsgrid_Visible, 0, "px", 0, "px", divGridcomponentcontent_notificationsgrid_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            wb_table2_32_132( true) ;
         }
         else
         {
            wb_table2_32_132( false) ;
         }
         return  ;
      }

      protected void wb_table2_32_132e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            wb_table3_41_132( true) ;
         }
         else
         {
            wb_table3_41_132( false) ;
         }
         return  ;
      }

      protected void wb_table3_41_132e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutcontent_userregion_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            NotificationsgridContainer.SetIsFreestyle(true);
            NotificationsgridContainer.SetWrapped(nGXWrapped);
            if ( NotificationsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"DivS\" data-gxgridid=\"54\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subNotificationsgrid_Internalname, subNotificationsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
            }
            else
            {
               NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
               NotificationsgridContainer.AddObjectProperty("Header", subNotificationsgrid_Header);
               NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
               NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV30NotificationIcon));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV25MarkAsRead_Action));
               NotificationsgridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
               NotificationsgridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Visible), 5, 0, ".", "")));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", AV34NotificationText);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", context.localUtil.TToC( AV15EventCreationDateTime, 10, 12, 0, 3, "/", ":", " "));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV33NotificationIsRead));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31NotificationId), 15, 0, ".", "")));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               NotificationsgridColumn.AddObjectProperty("Value", AV16EventTargetUrl);
               NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
               NotificationsgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectedindex), 4, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowselection), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectioncolor), 9, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowhovering), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Hoveringcolor), 9, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowcollapsing), 1, 0, ".", "")));
               NotificationsgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            nRC_GXsfl_54 = (int)(nGXsfl_54_idx-1);
            if ( NotificationsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
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
            wb_table4_88_132( true) ;
         }
         else
         {
            wb_table4_88_132( false) ;
         }
         return  ;
      }

      protected void wb_table4_88_132e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bdesktopnotification.SetProperty("Permission", AV10DesktopNotificationsPermission);
            ucK2bdesktopnotification.SetProperty("ClickedNotificationTag", AV11DesktopNotificationTag);
            ucK2bdesktopnotification.Render(context, "k2bdesktopnotification", K2bdesktopnotification_Internalname, sPrefix+"K2BDESKTOPNOTIFICATIONContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( NotificationsgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START132( )
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
               Form.Meta.addItem("description", "K2 BT_Notifications Viewer", 0) ;
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
               STRUP130( ) ;
            }
         }
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
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
                                 STRUP130( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ViewNotification' */
                                    E11132 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavNotificationtext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E12132 ();
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "NOTIFICATIONSGRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "NOTIFICATIONSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'E_VIEWNOTIFICATION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              nGXsfl_54_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
                              SubsflControlProps_542( ) ;
                              AV30NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30NotificationIcon)) ? AV44Notificationicon_GXI : context.convertURL( context.PathToRelativeUrl( AV30NotificationIcon))), !bGXsfl_54_Refreshing);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "SrcSet", context.GetImageSrcSet( AV30NotificationIcon), true);
                              AV25MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action)) ? AV42Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV25MarkAsRead_Action))), !bGXsfl_54_Refreshing);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV25MarkAsRead_Action), true);
                              AV34NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV34NotificationText);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavEventcreationdatetime_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Event Creation Date Time"}), 1, "vEVENTCREATIONDATETIME");
                                 GX_FocusControl = edtavEventcreationdatetime_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV15EventCreationDateTime = (DateTime)(DateTime.MinValue);
                                 AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV15EventCreationDateTime, 8, 12, 0, 3, "/", ":", " "));
                              }
                              else
                              {
                                 AV15EventCreationDateTime = context.localUtil.CToT( cgiGet( edtavEventcreationdatetime_Internalname), 0);
                                 AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV15EventCreationDateTime, 8, 12, 0, 3, "/", ":", " "));
                              }
                              AV33NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV33NotificationIsRead);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV31NotificationId = 0;
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV31NotificationId), 15, 0));
                              }
                              else
                              {
                                 AV31NotificationId = (long)(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ","));
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV31NotificationId), 15, 0));
                              }
                              AV16EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV16EventTargetUrl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E13132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E14132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E15132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMARKASREAD_ACTION.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_ViewNotification' */
                                          E11132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E12132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP130( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E12132 ();
                                       }
                                    }
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

      protected void WE132( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm132( ) ;
            }
         }
      }

      protected void PA132( )
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
               GX_FocusControl = edtavViewall_action_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrNotificationsgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_542( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            sendrow_542( ) ;
            nGXsfl_54_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_54_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( NotificationsgridContainer)) ;
         /* End function gxnrNotificationsgrid_newrow */
      }

      protected void gxgrNotificationsgrid_refresh( string AV25MarkAsRead_Action ,
                                                    GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV12DP_SDT_ITEM_NotificationsGrid ,
                                                    bool AV33NotificationIsRead ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E14132 ();
         NOTIFICATIONSGRID_nCurrentRecord = 0;
         RF132( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrNotificationsgrid_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E14132 ();
         RF132( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
         edtavEnablenotifications_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavEnablenotifications_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnablenotifications_action_Enabled), 5, 0), true);
         edtavRefresh_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
      }

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            NotificationsgridContainer.ClearRows();
         }
         wbStart = 54;
         E15132 ();
         nGXsfl_54_idx = 1;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         bGXsfl_54_Refreshing = true;
         NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
         NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
         NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
         NotificationsgridContainer.PageSize = subNotificationsgrid_fnc_Recordsperpage( );
         if ( subNotificationsgrid_Islastpage != 0 )
         {
            NOTIFICATIONSGRID_nFirstRecordOnPage = (long)(subNotificationsgrid_fnc_Recordcount( )-subNotificationsgrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONSGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(NOTIFICATIONSGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("NOTIFICATIONSGRID_nFirstRecordOnPage", NOTIFICATIONSGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_542( ) ;
            E16132 ();
            wbEnd = 54;
            WB130( ) ;
         }
         bGXsfl_54_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes132( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
      }

      protected int subNotificationsgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Enabled), 5, 0), true);
         edtavEnablenotifications_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavEnablenotifications_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnablenotifications_action_Enabled), 5, 0), true);
         edtavRefresh_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13132 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTIFICATIONINFO"), AV32NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_54 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_54"), ".", ","));
            AV10DesktopNotificationsPermission = cgiGet( sPrefix+"vDESKTOPNOTIFICATIONSPERMISSION");
            AV11DesktopNotificationTag = cgiGet( sPrefix+"vDESKTOPNOTIFICATIONTAG");
            /* Read variables values. */
            AV37ViewAll_Action = cgiGet( edtavViewall_action_Internalname);
            AssignAttri(sPrefix, false, "AV37ViewAll_Action", AV37ViewAll_Action);
            AV14EnableNotifications_Action = cgiGet( edtavEnablenotifications_action_Internalname);
            AssignAttri(sPrefix, false, "AV14EnableNotifications_Action", AV14EnableNotifications_Action);
            AV35Refresh_Action = cgiGet( edtavRefresh_action_Internalname);
            AssignAttri(sPrefix, false, "AV35Refresh_Action", AV35Refresh_Action);
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
         E13132 ();
         if (returnInSub) return;
      }

      protected void E13132( )
      {
         /* Start Routine */
         returnInSub = false;
         subNotificationsgrid_Backcolorstyle = 3;
         if ( (0==AV8CurrentPage_NotificationsGrid) )
         {
            AV8CurrentPage_NotificationsGrid = 1;
            AssignAttri(sPrefix, false, "AV8CurrentPage_NotificationsGrid", StringUtil.LTrimStr( (decimal)(AV8CurrentPage_NotificationsGrid), 4, 0));
         }
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' */
         S112 ();
         if (returnInSub) return;
         imgTogglenotifications_Bitmap = context.GetImagePath( "1942f1bc-1f65-4fa8-8c23-b53fd3aa4826", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgTogglenotifications_Bitmap)), true);
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "SrcSet", context.GetImageSrcSet( imgTogglenotifications_Bitmap), true);
         AV25MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action)) ? AV42Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV25MarkAsRead_Action))), !bGXsfl_54_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV25MarkAsRead_Action), true);
         AV42Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action)) ? AV42Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV25MarkAsRead_Action))), !bGXsfl_54_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV25MarkAsRead_Action), true);
         edtavMarkasread_action_Tooltiptext = "Marcar como leído";
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_54_Refreshing);
         if ( StringUtil.StrCmp(AV18HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S122 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E14132( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         divGridcomponentcontent_notificationsgrid_Class = "ControlBeautify_CollapsableTable"+" "+"K2BT_NotificationsTableContainer";
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Class", divGridcomponentcontent_notificationsgrid_Class, true);
         divContenttable_Class = "ControlBeautify_ParentCollapsableTable";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         divGridcomponentcontent_notificationsgrid_Visible = 0;
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV14EnableNotifications_Action = "Habilitar notificaciones en escritorio";
         AssignAttri(sPrefix, false, "AV14EnableNotifications_Action", AV14EnableNotifications_Action);
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'U_TOGGLENOTIFICATIONS' Routine */
         returnInSub = false;
         divGridcomponentcontent_notificationsgrid_Visible = (!((divGridcomponentcontent_notificationsgrid_Visible==1)) ? 1 : 0);
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      protected void E15132( )
      {
         /* Notificationsgrid_Refresh Routine */
         returnInSub = false;
         subNotificationsgrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(NOTIFICATIONSGRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_GRIDREFRESH(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         GXt_char1 = new k2bgetusercode(context).executeUdp( );
         new GeneXus.Programs.k2btools.integrationprocedures.registerclient(context ).execute( ref  GXt_char1) ;
         imgTogglenotifications_Bitmap = context.GetImagePath( "1942f1bc-1f65-4fa8-8c23-b53fd3aa4826", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgTogglenotifications_Bitmap)), true);
         AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "SrcSet", context.GetImageSrcSet( imgTogglenotifications_Bitmap), true);
      }

      private void E16132( )
      {
         /* Notificationsgrid_Load Routine */
         returnInSub = false;
         AV19I_LoadCount_NotificationsGrid = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification2 = AV13DP_SDT_NotificationsGrid;
         new GeneXus.Programs.k2btools.integrationprocedures.getlatestnotificationsforcurrentuser(context ).execute( out  GXt_objcol_SdtWebNotificationSDT_Notification2) ;
         AV13DP_SDT_NotificationsGrid = GXt_objcol_SdtWebNotificationSDT_Notification2;
         if ( AV13DP_SDT_NotificationsGrid.Count == 0 )
         {
            tblI_noresultsfoundtablename_notificationsgrid_Visible = 1;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         else
         {
            tblI_noresultsfoundtablename_notificationsgrid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV13DP_SDT_NotificationsGrid.Count )
         {
            AV12DP_SDT_ITEM_NotificationsGrid = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV13DP_SDT_NotificationsGrid.Item(AV43GXV1));
            AV19I_LoadCount_NotificationsGrid = (short)(AV19I_LoadCount_NotificationsGrid+1);
            AV24LoadRow_NotificationsGrid = true;
            AV30NotificationIcon = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon;
            AssignAttri(sPrefix, false, edtavNotificationicon_Internalname, AV30NotificationIcon);
            AV44Notificationicon_GXI = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon_gxi;
            AV34NotificationText = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationtext;
            AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV34NotificationText);
            AV15EventCreationDateTime = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventcreationdatetime;
            AssignAttri(sPrefix, false, edtavEventcreationdatetime_Internalname, context.localUtil.TToC( AV15EventCreationDateTime, 8, 12, 0, 3, "/", ":", " "));
            AV33NotificationIsRead = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationisread;
            AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV33NotificationIsRead);
            AV31NotificationId = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationid;
            AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV31NotificationId), 15, 0));
            AV16EventTargetUrl = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventtargeturl;
            AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV16EventTargetUrl);
            AV25MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavMarkasread_action_Internalname, AV25MarkAsRead_Action);
            AV42Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
            edtavMarkasread_action_Tooltiptext = "Marcar como leído";
            lblNotificationsgrid_notificationtexttb_Caption = AV34NotificationText;
            GXt_char1 = "";
            new getdatefriendlystring(context ).execute(  AV15EventCreationDateTime, out  GXt_char1) ;
            lblNotificationsgrid_notificationdatetb_Caption = GXt_char1;
            if ( AV33NotificationIsRead )
            {
               edtavMarkasread_action_Visible = 0;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_54_Refreshing);
            }
            else
            {
               edtavMarkasread_action_Visible = 1;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer"+" "+"K2BT_UnreadNotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_54_Refreshing);
            }
            /* Execute user subroutine: 'U_LOADROWVARS(NOTIFICATIONSGRID)' */
            S172 ();
            if (returnInSub) return;
            if ( AV24LoadRow_NotificationsGrid )
            {
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 54;
               }
               sendrow_542( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_54_Refreshing )
               {
                  context.DoAjaxLoad(54, NotificationsgridRow);
               }
            }
            else
            {
               AV19I_LoadCount_NotificationsGrid = (short)(AV19I_LoadCount_NotificationsGrid-1);
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12DP_SDT_ITEM_NotificationsGrid", AV12DP_SDT_ITEM_NotificationsGrid);
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         bttViewnotification_Caption = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationactioncaption;
         AssignProp(sPrefix, false, bttViewnotification_Internalname, "Caption", bttViewnotification_Caption, !bGXsfl_54_Refreshing);
         if ( ! AV33NotificationIsRead )
         {
            imgTogglenotifications_Bitmap = context.GetImagePath( "f26a7e3e-7126-48a2-8f29-3aaa280b1932", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgTogglenotifications_Bitmap)), true);
            AssignProp(sPrefix, false, imgTogglenotifications_Internalname, "SrcSet", context.GetImageSrcSet( imgTogglenotifications_Bitmap), true);
         }
      }

      protected void E17132( )
      {
         /* Markasread_action_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S182 ();
         if (returnInSub) return;
      }

      protected void S182( )
      {
         /* 'U_MARKASREAD' Routine */
         returnInSub = false;
         GXt_int3 = (short)(Convert.ToInt16(AV36Success));
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV31NotificationId), out  GXt_int3, out  AV27Messages) ;
         AV36Success = (bool)(Convert.ToBoolean(GXt_int3));
         if ( AV36Success )
         {
            context.CommitDataStores("k2bt_notificationsviewer",pr_default);
         }
         else
         {
            AV45GXV2 = 1;
            while ( AV45GXV2 <= AV27Messages.Count )
            {
               AV26Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV45GXV2));
               GX_msglist.addItem(AV26Message.gxTpr_Description);
               AV45GXV2 = (int)(AV45GXV2+1);
            }
         }
         gxgrNotificationsgrid_refresh( AV25MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, AV33NotificationIsRead, sPrefix) ;
      }

      protected void E11132( )
      {
         /* 'E_ViewNotification' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_VIEWNOTIFICATION' */
         S192 ();
         if (returnInSub) return;
      }

      protected void S192( )
      {
         /* 'U_VIEWNOTIFICATION' Routine */
         returnInSub = false;
         AV5Url = AV16EventTargetUrl;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S182 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV5Url) );
         context.wjLocDisableFrm = 0;
      }

      protected void S112( )
      {
         /* 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' */
         S222 ();
         if (returnInSub) return;
      }

      protected void S222( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         edtavViewall_action_Visible = 1;
         AssignProp(sPrefix, false, edtavViewall_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavViewall_action_Visible), 5, 0), true);
         AV37ViewAll_Action = "Ver todas";
         AssignAttri(sPrefix, false, "AV37ViewAll_Action", AV37ViewAll_Action);
         edtavRefresh_action_Visible = 1;
         AssignProp(sPrefix, false, edtavRefresh_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRefresh_action_Visible), 5, 0), true);
         AV35Refresh_Action = "Refrescar";
         AssignAttri(sPrefix, false, "AV35Refresh_Action", AV35Refresh_Action);
      }

      protected void S202( )
      {
         /* 'U_VIEWALL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bt_viewallnotifications.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'U_REFRESH' Routine */
         returnInSub = false;
         gxgrNotificationsgrid_refresh( AV25MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, AV33NotificationIsRead, sPrefix) ;
      }

      protected void E12132( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32NotificationInfo.gxTpr_Id, "K2BTools.Notifications.DesktopNotification") == 0 )
         {
            AV28NewNotificationId = (long)(NumberUtil.Val( AV32NotificationInfo.gxTpr_Message, "."));
            GXt_boolean4 = AV23Loaded;
            new GeneXus.Programs.k2btools.integrationprocedures.getdesktopnotificationinformation(context ).execute(  (short)(AV28NewNotificationId), out  AV9DesktopNotificationInfoSDT, out  GXt_boolean4) ;
            AV23Loaded = GXt_boolean4;
            if ( AV23Loaded )
            {
               this.executeUsercontrolMethod(sPrefix, false, "K2BDESKTOPNOTIFICATIONContainer", "ShowNotification", "", new Object[] {(SdtDesktopNotificationInfoSDT)AV9DesktopNotificationInfoSDT});
            }
            gxgrNotificationsgrid_refresh( AV25MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, AV33NotificationIsRead, sPrefix) ;
         }
         else
         {
            if ( StringUtil.StrCmp(AV32NotificationInfo.gxTpr_Id, "K2BTools.Notifications.Refresh") == 0 )
            {
               gxgrNotificationsgrid_refresh( AV25MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, AV33NotificationIsRead, sPrefix) ;
            }
         }
      }

      protected void wb_table4_88_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_notificationsgrid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_notificationsgrid_Internalname, tblI_noresultsfoundtablename_notificationsgrid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_notificationsgrid_Internalname, "No tiene notificaciones", "", "", lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BT_NotificationsViewer.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_88_132e( true) ;
         }
         else
         {
            wb_table4_88_132e( false) ;
         }
      }

      protected void wb_table3_41_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_notificationsgrid_gridassociatedright_Internalname, tblActions_notificationsgrid_gridassociatedright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRefresh_action_Internalname, StringUtil.RTrim( AV35Refresh_Action), StringUtil.RTrim( context.localUtil.Format( AV35Refresh_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+"e18131_client"+"'", "", "", "", "", edtavRefresh_action_Jsonclick, 7, "K2BT_TextAction", "", "", "", "", edtavRefresh_action_Visible, edtavRefresh_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BT_NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_41_132e( true) ;
         }
         else
         {
            wb_table3_41_132e( false) ;
         }
      }

      protected void wb_table2_32_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_notificationsgrid_gridassociatedleft_Internalname, tblActions_notificationsgrid_gridassociatedleft_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavViewall_action_Internalname, StringUtil.RTrim( AV37ViewAll_Action), StringUtil.RTrim( context.localUtil.Format( AV37ViewAll_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+"e19131_client"+"'", "", "", "", "", edtavViewall_action_Jsonclick, 7, "K2BT_TextAction", "", "", "", "", edtavViewall_action_Visible, edtavViewall_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BT_NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnablenotifications_action_Internalname, StringUtil.RTrim( AV14EnableNotifications_Action), StringUtil.RTrim( context.localUtil.Format( AV14EnableNotifications_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+"e20131_client"+"'", "", "", "", "", edtavEnablenotifications_action_Jsonclick, 7, "K2BT_TextAction", "", "", "", "", edtavEnablenotifications_action_Visible, edtavEnablenotifications_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BT_NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_32_132e( true) ;
         }
         else
         {
            wb_table2_32_132e( false) ;
         }
      }

      protected void wb_table1_15_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_NotificationToggle";
            StyleString = "";
            sImgUrl = imgTogglenotifications_Bitmap;
            GxWebStd.gx_bitmap( context, imgTogglenotifications_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Toggle Notifications", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgTogglenotifications_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e21131_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BT_NotificationsViewer.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_132e( true) ;
         }
         else
         {
            wb_table1_15_132e( false) ;
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
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA132( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bt_notificationsviewer", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA132( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA132( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS132( ) ;
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
         WS132( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE132( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188312779", true, true);
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
         context.AddJavascriptSource("k2bt_notificationsviewer.js", "?2024188312779", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_542( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_54_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_54_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_54_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_54_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_54_idx;
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME_"+sGXsfl_54_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_54_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_54_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_542( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_54_fel_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_54_fel_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_54_fel_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_54_fel_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_54_fel_idx;
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME_"+sGXsfl_54_fel_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_54_fel_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_54_fel_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_54_fel_idx;
      }

      protected void sendrow_542( )
      {
         SubsflControlProps_542( ) ;
         WB130( ) ;
         NotificationsgridRow = GXWebRow.GetNew(context,NotificationsgridContainer);
         if ( subNotificationsgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            subNotificationsgrid_Backcolor = subNotificationsgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Uniform";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
            subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subNotificationsgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
            {
               subNotificationsgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Even";
               }
            }
            else
            {
               subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( NotificationsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subNotificationsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_54_idx+"\">") ;
         }
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_notificationsgridtable1_Internalname+"_"+sGXsfl_54_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"K2BToolsSection_HoverActionContainer",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_notificationcontainer_Internalname+"_"+sGXsfl_54_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divNotificationsgrid_notificationcontainer_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Static Bitmap Variable */
         ClassString = "K2BT_NotificationIcon";
         StyleString = "";
         AV30NotificationIcon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV30NotificationIcon))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Notificationicon_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV30NotificationIcon)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30NotificationIcon)) ? AV44Notificationicon_GXI : context.PathToRelativeUrl( AV30NotificationIcon));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV30NotificationIcon_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_section1_Internalname+"_"+sGXsfl_54_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"K2BT_NotificationContentContainer",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_section2_Internalname+"_"+sGXsfl_54_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationsgrid_notificationtexttb_Internalname,(string)lblNotificationsgrid_notificationtexttb_Caption,(string)"",(string)"",(string)lblNotificationsgrid_notificationtexttb_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"K2BT_NotificationMessage",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"MarkAsRead",(string)"gx-form-item Image_ActionLabel Image_Action_OnSectionHoverLabel K2BT_NotificationMarkAsReadLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 65,'"+sPrefix+"',false,'',54)\"" : " ");
         ClassString = "Image_Action Image_Action_OnSectionHover K2BT_NotificationMarkAsRead";
         StyleString = "";
         AV25MarkAsRead_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV42Markasread_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25MarkAsRead_Action)) ? AV42Markasread_action_GXI : context.PathToRelativeUrl( AV25MarkAsRead_Action));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavMarkasread_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavMarkasread_action_Visible,(short)1,(string)"",(string)edtavMarkasread_action_Tooltiptext,(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavMarkasread_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVMARKASREAD_ACTION.CLICK."+sGXsfl_54_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV25MarkAsRead_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationsgrid_notificationdatetb_Internalname,(string)lblNotificationsgrid_notificationdatetb_Caption,(string)"",(string)"",(string)lblNotificationsgrid_notificationdatetb_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"K2BT_NotificationDate",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MinimalAction";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttViewnotification_Internalname+"_"+sGXsfl_54_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");",(string)bttViewnotification_Caption,(string)bttViewnotification_Jsonclick,(short)5,(string)"",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_VIEWNOTIFICATION\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutcontent_invisiblecontrolssection_Internalname+"_"+sGXsfl_54_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section_Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavNotificationtext_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,(string)"Notification Text",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Multiple line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 73,'"+sPrefix+"',false,'"+sGXsfl_54_idx+"',54)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,(string)AV34NotificationText,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,73);\"" : " "),(short)0,(short)1,(short)1,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"10000",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"K2BTools\\K2BT_NotificationMessage",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavEventcreationdatetime_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavEventcreationdatetime_Internalname,(string)"Event Creation Date Time",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEventcreationdatetime_Enabled!=0)&&(edtavEventcreationdatetime_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 76,'"+sPrefix+"',false,'"+sGXsfl_54_idx+"',54)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEventcreationdatetime_Internalname,context.localUtil.TToC( AV15EventCreationDateTime, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( AV15EventCreationDateTime, "99/99/99 99:99:99.999"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',12,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavEventcreationdatetime_Enabled!=0)&&(edtavEventcreationdatetime_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 8,'DMY',12,24,'spa',false,0);"+";gx.evt.onblur(this,76);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEventcreationdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)21,(string)"chr",(short)1,(string)"row",(short)21,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"K2BTools\\K2BT_DatetimeWithMilliseconds",(string)"right",(bool)false,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"left",(string)"top",(string)""+" data-gx-for=\""+chkavNotificationisread_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,(string)"Notification Is Read",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'"+sPrefix+"',false,'"+sGXsfl_54_idx+"',54)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_54_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_54_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         NotificationsgridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV33NotificationIsRead),(string)"",(string)"Notification Is Read",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,79);\"" : " ")});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavNotificationid_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,(string)"Notification Id",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 82,'"+sPrefix+"',false,'"+sGXsfl_54_idx+"',54)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31NotificationId), 15, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31NotificationId), "ZZZZZZZZZZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,82);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)15,(string)"chr",(short)1,(string)"row",(short)15,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"K2BTools\\K2BT_LargeId",(string)"right",(bool)false,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavEventtargeturl_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,(string)"Event Target Url",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 85,'"+sPrefix+"',false,'"+sGXsfl_54_idx+"',54)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,(string)AV16EventTargetUrl,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,85);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)AV16EventTargetUrl,(string)"_blank",(string)"",(string)"",(string)edtavEventtargeturl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"url",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"left",(bool)true,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes132( ) ;
         /* End of Columns property logic. */
         NotificationsgridContainer.AddRow(NotificationsgridRow);
         nGXsfl_54_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_54_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         /* End function sendrow_542 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_54_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_54_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgTogglenotifications_Internalname = sPrefix+"TOGGLENOTIFICATIONS";
         tblActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         edtavViewall_action_Internalname = sPrefix+"vVIEWALL_ACTION";
         edtavEnablenotifications_action_Internalname = sPrefix+"vENABLENOTIFICATIONS_ACTION";
         tblActions_notificationsgrid_gridassociatedleft_Internalname = sPrefix+"ACTIONS_NOTIFICATIONSGRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_NOTIFICATIONSGRID";
         edtavRefresh_action_Internalname = sPrefix+"vREFRESH_ACTION";
         tblActions_notificationsgrid_gridassociatedright_Internalname = sPrefix+"ACTIONS_NOTIFICATIONSGRID_GRIDASSOCIATEDRIGHT";
         divLayoutdefined_section3_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_NOTIFICATIONSGRID";
         divLayoutdefined_section1_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_NOTIFICATIONSGRID";
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON";
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB";
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION";
         divNotificationsgrid_section2_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION2";
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB";
         bttViewnotification_Internalname = sPrefix+"VIEWNOTIFICATION";
         divNotificationsgrid_section1_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION1";
         divNotificationsgrid_notificationcontainer_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONCONTAINER";
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT";
         edtavEventcreationdatetime_Internalname = sPrefix+"vEVENTCREATIONDATETIME";
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD";
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID";
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL";
         divLayoutcontent_invisiblecontrolssection_Internalname = sPrefix+"LAYOUTCONTENT_INVISIBLECONTROLSSECTION";
         divNotificationsgrid_notificationsgridtable1_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONSGRIDTABLE1";
         divLayoutcontent_userregion_Internalname = sPrefix+"LAYOUTCONTENT_USERREGION";
         lblI_noresultsfoundtextblock_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_NOTIFICATIONSGRID";
         tblI_noresultsfoundtablename_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID";
         divMaingrid_responsivetable_notificationsgrid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_NOTIFICATIONSGRID";
         divLayoutdefined_section8_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_NOTIFICATIONSGRID";
         divLayoutdefined_table3_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_NOTIFICATIONSGRID";
         divLayoutdefined_grid_inner_notificationsgrid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_NOTIFICATIONSGRID";
         divGridcomponentcontent_notificationsgrid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         K2bdesktopnotification_Internalname = sPrefix+"K2BDESKTOPNOTIFICATION";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subNotificationsgrid_Internalname = sPrefix+"NOTIFICATIONSGRID";
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
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Visible = 1;
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 1;
         edtavNotificationid_Enabled = 1;
         chkavNotificationisread.Caption = "Notification Is Read";
         chkavNotificationisread.Visible = 1;
         chkavNotificationisread.Enabled = 1;
         edtavEventcreationdatetime_Jsonclick = "";
         edtavEventcreationdatetime_Visible = 1;
         edtavEventcreationdatetime_Enabled = 1;
         edtavNotificationtext_Visible = 1;
         edtavNotificationtext_Enabled = 1;
         lblNotificationsgrid_notificationdatetb_Caption = "";
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Enabled = 1;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         subNotificationsgrid_Class = "FreeStyleGrid";
         imgTogglenotifications_Bitmap = (string)(context.GetImagePath( "1942f1bc-1f65-4fa8-8c23-b53fd3aa4826", "", context.GetTheme( )));
         edtavEnablenotifications_action_Jsonclick = "";
         edtavEnablenotifications_action_Enabled = 1;
         edtavEnablenotifications_action_Visible = 1;
         edtavViewall_action_Jsonclick = "";
         edtavViewall_action_Enabled = 1;
         edtavRefresh_action_Jsonclick = "";
         edtavRefresh_action_Enabled = 1;
         edtavRefresh_action_Visible = 1;
         edtavViewall_action_Visible = 1;
         bttViewnotification_Caption = "";
         divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer K2BT_UnreadNotificationContainer";
         tblI_noresultsfoundtablename_notificationsgrid_Visible = 1;
         subNotificationsgrid_Allowcollapsing = 0;
         edtavMarkasread_action_Visible = 1;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         subNotificationsgrid_Backcolorstyle = 0;
         divGridcomponentcontent_notificationsgrid_Class = "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer";
         divGridcomponentcontent_notificationsgrid_Visible = 1;
         divContenttable_Class = "K2BToolsTable_WebPanelDesignerContent";
         edtavMarkasread_action_Tooltiptext = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_TOGGLENOTIFICATIONS'","{handler:'E21131',iparms:[{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]");
         setEventMetadata("'E_TOGGLENOTIFICATIONS'",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("NOTIFICATIONSGRID.REFRESH","{handler:'E15132',iparms:[]");
         setEventMetadata("NOTIFICATIONSGRID.REFRESH",",oparms:[{av:'subNotificationsgrid_Backcolorstyle',ctrl:'NOTIFICATIONSGRID',prop:'Backcolorstyle'},{av:'edtavViewall_action_Visible',ctrl:'vVIEWALL_ACTION',prop:'Visible'},{av:'AV37ViewAll_Action',fld:'vVIEWALL_ACTION',pic:''},{av:'edtavRefresh_action_Visible',ctrl:'vREFRESH_ACTION',prop:'Visible'},{av:'AV35Refresh_Action',fld:'vREFRESH_ACTION',pic:''}]}");
         setEventMetadata("NOTIFICATIONSGRID.LOAD","{handler:'E16132',iparms:[{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("NOTIFICATIONSGRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_notificationsgrid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID',prop:'Visible'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV30NotificationIcon',fld:'vNOTIFICATIONICON',pic:''},{av:'AV34NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV15EventCreationDateTime',fld:'vEVENTCREATIONDATETIME',pic:'99/99/99 99:99:99.999'},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV31NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'},{av:'AV16EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'lblNotificationsgrid_notificationtexttb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONTEXTTB',prop:'Caption'},{av:'lblNotificationsgrid_notificationdatetb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONDATETB',prop:'Caption'},{av:'edtavMarkasread_action_Visible',ctrl:'vMARKASREAD_ACTION',prop:'Visible'},{av:'divNotificationsgrid_notificationcontainer_Class',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONCONTAINER',prop:'Class'},{ctrl:'VIEWNOTIFICATION',prop:'Caption'}]}");
         setEventMetadata("VMARKASREAD_ACTION.CLICK","{handler:'E17132',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV31NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("VMARKASREAD_ACTION.CLICK",",oparms:[]}");
         setEventMetadata("'E_VIEWNOTIFICATION'","{handler:'E11132',iparms:[{av:'AV16EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV31NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_VIEWNOTIFICATION'",",oparms:[]}");
         setEventMetadata("'E_VIEWALL'","{handler:'E19131',iparms:[]");
         setEventMetadata("'E_VIEWALL'",",oparms:[]}");
         setEventMetadata("'E_REFRESH'","{handler:'E18131',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_REFRESH'",",oparms:[]}");
         setEventMetadata("VENABLENOTIFICATIONS_ACTION.CLICK","{handler:'E20131',iparms:[]");
         setEventMetadata("VENABLENOTIFICATIONS_ACTION.CLICK",",oparms:[]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E12132',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV25MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV33NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'sPrefix'},{av:'AV32NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTCREATIONDATETIME","{handler:'Validv_Eventcreationdatetime',iparms:[]");
         setEventMetadata("VALIDV_EVENTCREATIONDATETIME",",oparms:[]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
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
         AV32NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV25MarkAsRead_Action = "";
         AV12DP_SDT_ITEM_NotificationsGrid = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10DesktopNotificationsPermission = "";
         AV11DesktopNotificationTag = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         NotificationsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         subNotificationsgrid_Header = "";
         NotificationsgridColumn = new GXWebColumn();
         AV30NotificationIcon = "";
         AV34NotificationText = "";
         AV15EventCreationDateTime = (DateTime)(DateTime.MinValue);
         AV16EventTargetUrl = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         ucK2bdesktopnotification = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV44Notificationicon_GXI = "";
         AV42Markasread_action_GXI = "";
         AV37ViewAll_Action = "";
         AV14EnableNotifications_Action = "";
         AV35Refresh_Action = "";
         AV18HttpRequest = new GxHttpRequest( context);
         AV13DP_SDT_NotificationsGrid = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "kb_ticket");
         GXt_objcol_SdtWebNotificationSDT_Notification2 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "kb_ticket");
         GXt_char1 = "";
         NotificationsgridRow = new GXWebRow();
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV26Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV5Url = "";
         AV9DesktopNotificationInfoSDT = new SdtDesktopNotificationInfoSDT(context);
         lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgTogglenotifications_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subNotificationsgrid_Linesclass = "";
         lblNotificationsgrid_notificationtexttb_Jsonclick = "";
         lblNotificationsgrid_notificationdatetb_Jsonclick = "";
         bttViewnotification_Jsonclick = "";
         ROClassString = "";
         GXCCtl = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bt_notificationsviewer__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bt_notificationsviewer__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bt_notificationsviewer__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bt_notificationsviewer__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavViewall_action_Enabled = 0;
         edtavEnablenotifications_action_Enabled = 0;
         edtavRefresh_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subNotificationsgrid_Backcolorstyle ;
      private short subNotificationsgrid_Allowselection ;
      private short subNotificationsgrid_Allowhovering ;
      private short subNotificationsgrid_Allowcollapsing ;
      private short subNotificationsgrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV8CurrentPage_NotificationsGrid ;
      private short NOTIFICATIONSGRID_nEOF ;
      private short AV19I_LoadCount_NotificationsGrid ;
      private short GXt_int3 ;
      private short nGXWrapped ;
      private short subNotificationsgrid_Backstyle ;
      private int divGridcomponentcontent_notificationsgrid_Visible ;
      private int nRC_GXsfl_54 ;
      private int nGXsfl_54_idx=1 ;
      private int edtavViewall_action_Enabled ;
      private int edtavEnablenotifications_action_Enabled ;
      private int edtavRefresh_action_Enabled ;
      private int edtavMarkasread_action_Visible ;
      private int subNotificationsgrid_Selectedindex ;
      private int subNotificationsgrid_Selectioncolor ;
      private int subNotificationsgrid_Hoveringcolor ;
      private int subNotificationsgrid_Islastpage ;
      private int tblI_noresultsfoundtablename_notificationsgrid_Visible ;
      private int AV43GXV1 ;
      private int AV45GXV2 ;
      private int edtavViewall_action_Visible ;
      private int edtavRefresh_action_Visible ;
      private int edtavEnablenotifications_action_Visible ;
      private int idxLst ;
      private int subNotificationsgrid_Backcolor ;
      private int subNotificationsgrid_Allbackcolor ;
      private int edtavMarkasread_action_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavNotificationtext_Visible ;
      private int edtavEventcreationdatetime_Enabled ;
      private int edtavEventcreationdatetime_Visible ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationid_Visible ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavEventtargeturl_Visible ;
      private long AV31NotificationId ;
      private long NOTIFICATIONSGRID_nCurrentRecord ;
      private long NOTIFICATIONSGRID_nFirstRecordOnPage ;
      private long AV28NewNotificationId ;
      private string edtavMarkasread_action_Tooltiptext ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_54_idx="0001" ;
      private string edtavMarkasread_action_Internalname ;
      private string edtavViewall_action_Internalname ;
      private string edtavEnablenotifications_action_Internalname ;
      private string edtavRefresh_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV10DesktopNotificationsPermission ;
      private string AV11DesktopNotificationTag ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divContenttable_Class ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divGridcomponentcontent_notificationsgrid_Internalname ;
      private string divGridcomponentcontent_notificationsgrid_Class ;
      private string divLayoutdefined_grid_inner_notificationsgrid_Internalname ;
      private string divLayoutdefined_table3_notificationsgrid_Internalname ;
      private string divLayoutdefined_section1_notificationsgrid_Internalname ;
      private string divLayoutdefined_section7_notificationsgrid_Internalname ;
      private string divLayoutdefined_section3_notificationsgrid_Internalname ;
      private string divMaingrid_responsivetable_notificationsgrid_Internalname ;
      private string divLayoutcontent_userregion_Internalname ;
      private string sStyleString ;
      private string subNotificationsgrid_Internalname ;
      private string subNotificationsgrid_Header ;
      private string lblNotificationsgrid_notificationtexttb_Caption ;
      private string divLayoutdefined_section8_notificationsgrid_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string K2bdesktopnotification_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationtext_Internalname ;
      private string edtavNotificationicon_Internalname ;
      private string edtavEventcreationdatetime_Internalname ;
      private string chkavNotificationisread_Internalname ;
      private string edtavNotificationid_Internalname ;
      private string edtavEventtargeturl_Internalname ;
      private string AV37ViewAll_Action ;
      private string AV14EnableNotifications_Action ;
      private string AV35Refresh_Action ;
      private string imgTogglenotifications_Internalname ;
      private string tblI_noresultsfoundtablename_notificationsgrid_Internalname ;
      private string lblNotificationsgrid_notificationdatetb_Caption ;
      private string GXt_char1 ;
      private string divNotificationsgrid_notificationcontainer_Class ;
      private string divNotificationsgrid_notificationcontainer_Internalname ;
      private string bttViewnotification_Caption ;
      private string bttViewnotification_Internalname ;
      private string lblI_noresultsfoundtextblock_notificationsgrid_Internalname ;
      private string lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick ;
      private string tblActions_notificationsgrid_gridassociatedright_Internalname ;
      private string TempTags ;
      private string edtavRefresh_action_Jsonclick ;
      private string tblActions_notificationsgrid_gridassociatedleft_Internalname ;
      private string edtavViewall_action_Jsonclick ;
      private string edtavEnablenotifications_action_Jsonclick ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string sImgUrl ;
      private string imgTogglenotifications_Jsonclick ;
      private string lblNotificationsgrid_notificationtexttb_Internalname ;
      private string lblNotificationsgrid_notificationdatetb_Internalname ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string subNotificationsgrid_Class ;
      private string subNotificationsgrid_Linesclass ;
      private string divNotificationsgrid_notificationsgridtable1_Internalname ;
      private string divNotificationsgrid_section1_Internalname ;
      private string divNotificationsgrid_section2_Internalname ;
      private string lblNotificationsgrid_notificationtexttb_Jsonclick ;
      private string edtavMarkasread_action_Jsonclick ;
      private string lblNotificationsgrid_notificationdatetb_Jsonclick ;
      private string bttViewnotification_Jsonclick ;
      private string divLayoutcontent_invisiblecontrolssection_Internalname ;
      private string ROClassString ;
      private string edtavEventcreationdatetime_Jsonclick ;
      private string GXCCtl ;
      private string edtavNotificationid_Jsonclick ;
      private string edtavEventtargeturl_Jsonclick ;
      private DateTime AV15EventCreationDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_54_Refreshing=false ;
      private bool AV33NotificationIsRead ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV24LoadRow_NotificationsGrid ;
      private bool AV36Success ;
      private bool AV23Loaded ;
      private bool GXt_boolean4 ;
      private bool AV30NotificationIcon_IsBlob ;
      private bool AV25MarkAsRead_Action_IsBlob ;
      private string AV34NotificationText ;
      private string AV16EventTargetUrl ;
      private string AV44Notificationicon_GXI ;
      private string AV42Markasread_action_GXI ;
      private string AV5Url ;
      private string AV25MarkAsRead_Action ;
      private string AV30NotificationIcon ;
      private string imgTogglenotifications_Bitmap ;
      private GXWebGrid NotificationsgridContainer ;
      private GXWebRow NotificationsgridRow ;
      private GXWebColumn NotificationsgridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucK2bdesktopnotification ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV18HttpRequest ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV13DP_SDT_NotificationsGrid ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private SdtDesktopNotificationInfoSDT AV9DesktopNotificationInfoSDT ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV12DP_SDT_ITEM_NotificationsGrid ;
      private GeneXus.Utils.SdtMessages_Message AV26Message ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV32NotificationInfo ;
   }

   public class k2bt_notificationsviewer__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class k2bt_notificationsviewer__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class k2bt_notificationsviewer__gam : DataStoreHelperBase, IDataStoreHelper
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

public class k2bt_notificationsviewer__default : DataStoreHelperBase, IDataStoreHelper
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
