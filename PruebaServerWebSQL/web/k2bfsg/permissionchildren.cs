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
   public class permissionchildren : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public permissionchildren( )
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

      public permissionchildren( IGxContext context )
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

      public void execute( ref long aP0_ApplicationId ,
                           ref string aP1_PermissionId )
      {
         this.AV32ApplicationId = aP0_ApplicationId;
         this.AV28PermissionId = aP1_PermissionId;
         executePrivate();
         aP0_ApplicationId=this.AV32ApplicationId;
         aP1_PermissionId=this.AV28PermissionId;
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
         cmbavAccesstype = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ApplicationId");
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
                  AV32ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
                  AssignAttri(sPrefix, false, "AV32ApplicationId", StringUtil.LTrimStr( (decimal)(AV32ApplicationId), 12, 0));
                  AV28PermissionId = GetPar( "PermissionId");
                  AssignAttri(sPrefix, false, "AV28PermissionId", AV28PermissionId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV32ApplicationId,(string)AV28PermissionId});
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
                  gxfirstwebparm = GetFirstPar( "ApplicationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ApplicationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_55 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_55"), "."));
                  nGXsfl_55_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_55_idx"), "."));
                  sGXsfl_55_idx = GetPar( "sGXsfl_55_idx");
                  sPrefix = GetPar( "sPrefix");
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
                  AV39Pgmname = GetPar( "Pgmname");
                  AV15CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
                  AV20GenericFilter_Grid = GetPar( "GenericFilter_Grid");
                  AV18HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
                  AV17I_LoadCount_Grid = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."));
                  AV32ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
                  AV28PermissionId = GetPar( "PermissionId");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( AV39Pgmname, AV15CurrentPage_Grid, AV20GenericFilter_Grid, AV18HasNextPage_Grid, AV17I_LoadCount_Grid, AV32ApplicationId, AV28PermissionId, sPrefix) ;
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
            PA4L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV39Pgmname = "K2BFSG.PermissionChildren";
               context.Gx_err = 0;
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_55_Refreshing);
               edtavDsc_Enabled = 0;
               AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_55_Refreshing);
               cmbavAccesstype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_55_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
               WS4L2( ) ;
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
            context.SendWebValue( "Permission Children") ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20231249485452", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.permissionchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV32ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV28PermissionId))}, new string[] {"ApplicationId","PermissionId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_55), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV32ApplicationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV32ApplicationId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28PermissionId", StringUtil.RTrim( wcpOAV28PermissionId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentPage_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ApplicationId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONID", StringUtil.RTrim( AV28PermissionId));
      }

      protected void RenderHtmlCloseForm4L2( )
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
         return "K2BFSG.PermissionChildren" ;
      }

      public override string GetPgmdesc( )
      {
         return "Permission Children" ;
      }

      protected void WB4L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.permissionchildren.aspx");
               context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_4L2( true) ;
         }
         else
         {
            wb_table1_15_4L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_4L2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_onlygenericfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section6_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_OnlyGenericFilter", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_grid_Internalname, "Generic Filter_Grid", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV20GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV20GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_grid_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\PermissionChildren.htm");
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
            wb_table2_40_4L2( true) ;
         }
         else
         {
            wb_table2_40_4L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_40_4L2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"55\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de acceso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
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
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV21Name));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV22Dsc));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV23AccessType));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAccesstype.Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV24Id));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV25Delete_Action));
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
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            nRC_GXsfl_55 = (int)(nGXsfl_55_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_63_4L2( true) ;
         }
         else
         {
            wb_table3_63_4L2( false) ;
         }
         return  ;
      }

      protected void wb_table3_63_4L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e114l1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e124l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e114l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e134l1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e134l1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
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
         if ( wbEnd == 55 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4L2( )
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
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
               }
               Form.Meta.addItem("description", "Permission Children", 0) ;
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
               STRUP4L0( ) ;
            }
         }
      }

      protected void WS4L2( )
      {
         START4L2( ) ;
         EVT4L2( ) ;
      }

      protected void EVT4L2( )
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
                                 STRUP4L0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E144L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavName_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              nGXsfl_55_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
                              SubsflControlProps_552( ) ;
                              AV21Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV21Name);
                              AV22Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri(sPrefix, false, edtavDsc_Internalname, AV22Dsc);
                              cmbavAccesstype.Name = cmbavAccesstype_Internalname;
                              cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
                              AV23AccessType = cgiGet( cmbavAccesstype_Internalname);
                              AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV23AccessType);
                              AV24Id = cgiGet( edtavId_Internalname);
                              AssignAttri(sPrefix, false, edtavId_Internalname, AV24Id);
                              AV25Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25Delete_Action)) ? AV38Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV25Delete_Action))), !bGXsfl_55_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV25Delete_Action), true);
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E154L2 ();
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E164L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E174L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E184L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Delete' */
                                          E194L2 ();
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
                                       STRUP4L0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void WE4L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4L2( ) ;
            }
         }
      }

      protected void PA4L2( )
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
               GX_FocusControl = edtavGenericfilter_grid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_552( ) ;
         while ( nGXsfl_55_idx <= nRC_GXsfl_55 )
         {
            sendrow_552( ) ;
            nGXsfl_55_idx = ((subGrid_Islastpage==1)&&(nGXsfl_55_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV39Pgmname ,
                                       short AV15CurrentPage_Grid ,
                                       string AV20GenericFilter_Grid ,
                                       bool AV18HasNextPage_Grid ,
                                       short AV17I_LoadCount_Grid ,
                                       long AV32ApplicationId ,
                                       string AV28PermissionId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E164L2 ();
         GRID_nCurrentRecord = 0;
         RF4L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         E164L2 ();
         RF4L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV39Pgmname = "K2BFSG.PermissionChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
      }

      protected void RF4L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 55;
         E174L2 ();
         nGXsfl_55_idx = 1;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         bGXsfl_55_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_552( ) ;
            E184L2 ();
            wbEnd = 55;
            WB4L0( ) ;
         }
         bGXsfl_55_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4L2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
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
         AV39Pgmname = "K2BFSG.PermissionChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E154L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_55 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_55"), ",", "."));
            wcpOAV32ApplicationId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32ApplicationId"), ",", "."));
            wcpOAV28PermissionId = cgiGet( sPrefix+"wcpOAV28PermissionId");
            AV32ApplicationId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vAPPLICATIONID"), ",", "."));
            AV15CurrentPage_Grid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), ",", "."));
            AV18HasNextPage_Grid = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_GRID"));
            /* Read variables values. */
            AV20GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri(sPrefix, false, "AV20GenericFilter_Grid", AV20GenericFilter_Grid);
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
         E154L2 ();
         if (returnInSub) return;
      }

      protected void E154L2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
      }

      protected void E164L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
         if ( (0==AV15CurrentPage_Grid) )
         {
            AV15CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         AV16Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV26GAMApplication.load( AV32ApplicationId);
         AV35GAMPermission = AV26GAMApplication.getpermissionbyguid(AV28PermissionId, out  AV30Errors);
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E174L2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E184L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV17I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         AV18HasNextPage_Grid = false;
         AssignAttri(sPrefix, false, "AV18HasNextPage_Grid", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV18HasNextPage_Grid, context));
         AV19Exit_Grid = false;
         while ( true )
         {
            AV17I_LoadCount_Grid = (short)(AV17I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S192 ();
            if (returnInSub) return;
            if ( ! AV35GAMPermission.gxTpr_Isautomaticpermission )
            {
               AV25Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV25Delete_Action);
               AV38Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 1;
               edtavDelete_action_Tooltiptext = "Eliminar";
            }
            else
            {
               AV25Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV25Delete_Action);
               AV38Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 0;
               edtavDelete_action_Tooltiptext = "";
            }
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S202 ();
            if (returnInSub) return;
            if ( AV19Exit_Grid )
            {
               if (true) break;
            }
            if ( AV17I_LoadCount_Grid > 20 * AV15CurrentPage_Grid )
            {
               AV18HasNextPage_Grid = true;
               AssignAttri(sPrefix, false, "AV18HasNextPage_Grid", AV18HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV18HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV17I_LoadCount_Grid > 20 * ( AV15CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 55;
               }
               sendrow_552( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_55_Refreshing )
               {
                  context.DoAjaxLoad(55, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV23AccessType);
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV17I_LoadCount_Grid == 1 )
         {
            AV26GAMApplication.load( AV32ApplicationId);
            AV31SDT = AV26GAMApplication.getpermissionchildren(AV28PermissionId, AV29Filter, out  AV30Errors);
         }
         if ( AV31SDT.Count >= AV17I_LoadCount_Grid )
         {
            AV21Name = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV31SDT.Item(AV17I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri(sPrefix, false, edtavName_Internalname, AV21Name);
            AV22Dsc = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV31SDT.Item(AV17I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri(sPrefix, false, edtavDsc_Internalname, AV22Dsc);
            AV23AccessType = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV31SDT.Item(AV17I_LoadCount_Grid)).gxTpr_Accesstype;
            AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV23AccessType);
            AV24Id = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV31SDT.Item(AV17I_LoadCount_Grid)).gxTpr_Guid;
            AssignAttri(sPrefix, false, edtavId_Internalname, AV24Id);
         }
         else
         {
            AV19Exit_Grid = true;
         }
      }

      protected void S202( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV15CurrentPage_Grid) || ( AV15CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV15CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV15CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV18HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV15CurrentPage_Grid <= 1 ) && ! AV18HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV39Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = AV15CurrentPage_Grid;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV14GridStateFilterValue.gxTpr_Value = AV20GenericFilter_Grid;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV39Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV39Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV20GenericFilter_Grid = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20GenericFilter_Grid", AV20GenericFilter_Grid);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         if ( AV13GridState.gxTpr_Currentpage > 0 )
         {
            AV15CurrentPage_Grid = AV13GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
      }

      protected void S142( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S232 ();
         if (returnInSub) return;
      }

      protected void S232( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
         if ( ! AV35GAMPermission.gxTpr_Isautomaticpermission )
         {
            bttAdd_Visible = 1;
            AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
         }
         else
         {
            bttAdd_Visible = 0;
            AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
            bttAdd_Tooltiptext = "";
            AssignProp(sPrefix, false, bttAdd_Internalname, "Tooltiptext", bttAdd_Tooltiptext, true);
         }
      }

      protected void E194L2( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV26GAMApplication.load( AV32ApplicationId);
         AV34isOK = AV26GAMApplication.deletepermissionchild(AV28PermissionId, AV24Id, out  AV30Errors);
         if ( AV34isOK )
         {
            context.CommitDataStores("k2bfsg.permissionchildren",pr_default);
         }
         else
         {
            AV41GXV2 = 1;
            while ( AV41GXV2 <= AV30Errors.Count )
            {
               AV33Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(AV41GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV33Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV33Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV41GXV2 = (int)(AV41GXV2+1);
            }
         }
         gxgrGrid_refresh( AV39Pgmname, AV15CurrentPage_Grid, AV20GenericFilter_Grid, AV18HasNextPage_Grid, AV17I_LoadCount_Grid, AV32ApplicationId, AV28PermissionId, sPrefix) ;
      }

      protected void E144L2( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S222( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         context.PopUp(formatLink("k2bfsg.addpermissionchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV32ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV28PermissionId))}, new string[] {"ApplicationId","PermissionId"}) , new Object[] {"AV32ApplicationId","AV28PermissionId"});
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void wb_table3_63_4L2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No se encontraron hijos", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_63_4L2e( true) ;
         }
         else
         {
            wb_table3_63_4L2e( false) ;
         }
      }

      protected void wb_table2_40_4L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_Internalname, tblLayoutdefined_table7_grid_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_43_4L2( true) ;
         }
         else
         {
            wb_table4_43_4L2( false) ;
         }
         return  ;
      }

      protected void wb_table4_43_4L2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_40_4L2e( true) ;
         }
         else
         {
            wb_table2_40_4L2e( false) ;
         }
      }

      protected void wb_table4_43_4L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_grid_topright_Internalname, tblActions_grid_topright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", "Nuevo", bttAdd_Jsonclick, 5, bttAdd_Tooltiptext, "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\PermissionChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_43_4L2e( true) ;
         }
         else
         {
            wb_table4_43_4L2e( false) ;
         }
      }

      protected void wb_table1_15_4L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_grid_Internalname, tblGridtitlecontainertable_grid_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_grid_Internalname, "Permisos hijo", "", "", lblGridtitle_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\PermissionChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_4L2e( true) ;
         }
         else
         {
            wb_table1_15_4L2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV32ApplicationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV32ApplicationId", StringUtil.LTrimStr( (decimal)(AV32ApplicationId), 12, 0));
         AV28PermissionId = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV28PermissionId", AV28PermissionId);
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
         PA4L2( ) ;
         WS4L2( ) ;
         WE4L2( ) ;
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
         sCtrlAV32ApplicationId = (string)((string)getParm(obj,0));
         sCtrlAV28PermissionId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\permissionchildren", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV32ApplicationId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV32ApplicationId", StringUtil.LTrimStr( (decimal)(AV32ApplicationId), 12, 0));
            AV28PermissionId = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV28PermissionId", AV28PermissionId);
         }
         wcpOAV32ApplicationId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32ApplicationId"), ",", "."));
         wcpOAV28PermissionId = cgiGet( sPrefix+"wcpOAV28PermissionId");
         if ( ! GetJustCreated( ) && ( ( AV32ApplicationId != wcpOAV32ApplicationId ) || ( StringUtil.StrCmp(AV28PermissionId, wcpOAV28PermissionId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV32ApplicationId = AV32ApplicationId;
         wcpOAV28PermissionId = AV28PermissionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV32ApplicationId = cgiGet( sPrefix+"AV32ApplicationId_CTRL");
         if ( StringUtil.Len( sCtrlAV32ApplicationId) > 0 )
         {
            AV32ApplicationId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV32ApplicationId), ",", "."));
            AssignAttri(sPrefix, false, "AV32ApplicationId", StringUtil.LTrimStr( (decimal)(AV32ApplicationId), 12, 0));
         }
         else
         {
            AV32ApplicationId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV32ApplicationId_PARM"), ",", "."));
         }
         sCtrlAV28PermissionId = cgiGet( sPrefix+"AV28PermissionId_CTRL");
         if ( StringUtil.Len( sCtrlAV28PermissionId) > 0 )
         {
            AV28PermissionId = cgiGet( sCtrlAV28PermissionId);
            AssignAttri(sPrefix, false, "AV28PermissionId", AV28PermissionId);
         }
         else
         {
            AV28PermissionId = cgiGet( sPrefix+"AV28PermissionId_PARM");
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
         PA4L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4L2( ) ;
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
         WS4L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV32ApplicationId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ApplicationId), 12, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32ApplicationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32ApplicationId_CTRL", StringUtil.RTrim( sCtrlAV32ApplicationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28PermissionId_PARM", StringUtil.RTrim( AV28PermissionId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28PermissionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28PermissionId_CTRL", StringUtil.RTrim( sCtrlAV28PermissionId));
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
         WE4L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249485873", true, true);
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
         context.AddJavascriptSource("k2bfsg/permissionchildren.js", "?20231249485875", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_552( )
      {
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_55_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_55_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_55_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_55_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_552( )
      {
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_55_fel_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_55_fel_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_55_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_55_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_55_fel_idx;
      }

      protected void sendrow_552( )
      {
         SubsflControlProps_552( ) ;
         WB4L0( ) ;
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
            if ( ((int)((nGXsfl_55_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_55_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 56,'"+sPrefix+"',false,'"+sGXsfl_55_idx+"',55)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV21Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,56);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e204l2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 57,'"+sPrefix+"',false,'"+sGXsfl_55_idx+"',55)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV22Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,57);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 58,'"+sPrefix+"',false,'"+sGXsfl_55_idx+"',55)\"" : " ");
         if ( ( cmbavAccesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vACCESSTYPE_" + sGXsfl_55_idx;
            cmbavAccesstype.Name = GXCCtl;
            cmbavAccesstype.WebTags = "";
            cmbavAccesstype.addItem("A", "Allow", 0);
            cmbavAccesstype.addItem("R", "Restricted", 0);
            if ( cmbavAccesstype.ItemCount > 0 )
            {
               AV23AccessType = cmbavAccesstype.getValidValue(AV23AccessType);
               AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV23AccessType);
            }
         }
         /* ComboBox */
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccesstype,(string)cmbavAccesstype_Internalname,StringUtil.RTrim( AV23AccessType),(short)1,(string)cmbavAccesstype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavAccesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,58);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV23AccessType);
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Values", (string)(cmbavAccesstype.ToJavascriptSource()), !bGXsfl_55_Refreshing);
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'"+sPrefix+"',false,'"+sGXsfl_55_idx+"',55)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV24Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,59);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'"+sPrefix+"',false,'',55)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV25Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV38Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25Delete_Action)) ? AV38Delete_action_GXI : context.PathToRelativeUrl( AV25Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtavDelete_action_Enabled,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETE\\'."+sGXsfl_55_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV25Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes4L2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_55_idx = ((subGrid_Islastpage==1)&&(nGXsfl_55_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         /* End function sendrow_552 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vACCESSTYPE_" + sGXsfl_55_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", "Allow", 0);
         cmbavAccesstype.addItem("R", "Restricted", 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGridtitle_grid_Internalname = sPrefix+"GRIDTITLE_GRID";
         tblGridtitlecontainertable_grid_Internalname = sPrefix+"GRIDTITLECONTAINERTABLE_GRID";
         edtavGenericfilter_grid_Internalname = sPrefix+"vGENERICFILTER_GRID";
         divLayoutdefined_section6_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION6_GRID";
         divLayoutdefined_onlygenericfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         bttAdd_Internalname = sPrefix+"ADD";
         tblActions_grid_topright_Internalname = sPrefix+"ACTIONS_GRID_TOPRIGHT";
         tblLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavDsc_Internalname = sPrefix+"vDSC";
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE";
         edtavId_Internalname = sPrefix+"vID";
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = sPrefix+"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         divGridcomponent_grid_Internalname = sPrefix+"GRIDCOMPONENT_GRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_Visible = -1;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         cmbavAccesstype_Jsonclick = "";
         cmbavAccesstype.Visible = -1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Visible = -1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         bttAdd_Visible = 1;
         bttAdd_Tooltiptext = "";
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
         edtavId_Enabled = 1;
         cmbavAccesstype.Enabled = 1;
         edtavDsc_Enabled = 1;
         edtavName_Enabled = 1;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E174L2',iparms:[{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E184L2',iparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV25Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Enabled',ctrl:'vDELETE_ACTION',prop:'Enabled'},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV21Name',fld:'vNAME',pic:''},{av:'AV22Dsc',fld:'vDSC',pic:''},{av:'cmbavAccesstype'},{av:'AV23AccessType',fld:'vACCESSTYPE',pic:''},{av:'AV24Id',fld:'vID',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E124L1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E114L1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E134L1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E194L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'},{av:'AV24Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_ADD'","{handler:'E144L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV28PermissionId',fld:'vPERMISSIONID',pic:''},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{ctrl:'ADD',prop:'Visible'},{ctrl:'ADD',prop:'Tooltiptext'}]}");
         setEventMetadata("VNAME.CLICK","{handler:'E204L2',iparms:[{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV24Id',fld:'vID',pic:''}]");
         setEventMetadata("VNAME.CLICK",",oparms:[{av:'AV24Id',fld:'vID',pic:''},{av:'AV32ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_ACCESSTYPE","{handler:'Validv_Accesstype',iparms:[]");
         setEventMetadata("VALIDV_ACCESSTYPE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete_action',iparms:[]");
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
         wcpOAV28PermissionId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV39Pgmname = "";
         AV20GenericFilter_Grid = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV21Name = "";
         AV22Dsc = "";
         AV23AccessType = "";
         AV24Id = "";
         AV25Delete_Action = "";
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV38Delete_action_GXI = "";
         AV26GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV35GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV30Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridRow = new GXWebRow();
         AV31SDT = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV29Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         bttAdd_Jsonclick = "";
         lblGridtitle_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV32ApplicationId = "";
         sCtrlAV28PermissionId = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.permissionchildren__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.permissionchildren__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.permissionchildren__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.permissionchildren__default(),
            new Object[][] {
            }
         );
         AV39Pgmname = "K2BFSG.PermissionChildren";
         /* GeneXus formulas. */
         AV39Pgmname = "K2BFSG.PermissionChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15CurrentPage_Grid ;
      private short AV17I_LoadCount_Grid ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GRID_nEOF ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_55 ;
      private int nGXsfl_55_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int edtavGenericfilter_grid_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
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
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV40GXV1 ;
      private int bttAdd_Visible ;
      private int AV41GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int edtavId_Visible ;
      private int edtavDelete_action_Visible ;
      private long AV32ApplicationId ;
      private long wcpOAV32ApplicationId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string AV28PermissionId ;
      private string wcpOAV28PermissionId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_55_idx="0001" ;
      private string AV39Pgmname ;
      private string AV20GenericFilter_Grid ;
      private string edtavName_Internalname ;
      private string edtavDsc_Internalname ;
      private string cmbavAccesstype_Internalname ;
      private string edtavId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponent_grid_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlygenericfilterlayout_grid_Internalname ;
      private string divLayoutdefined_section6_grid_Internalname ;
      private string edtavGenericfilter_grid_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_grid_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string AV21Name ;
      private string AV22Dsc ;
      private string AV23AccessType ;
      private string AV24Id ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDelete_action_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string bttAdd_Internalname ;
      private string bttAdd_Tooltiptext ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string tblLayoutdefined_table7_grid_Internalname ;
      private string tblActions_grid_topright_Internalname ;
      private string bttAdd_Jsonclick ;
      private string tblGridtitlecontainertable_grid_Internalname ;
      private string lblGridtitle_grid_Internalname ;
      private string lblGridtitle_grid_Jsonclick ;
      private string sCtrlAV32ApplicationId ;
      private string sCtrlAV28PermissionId ;
      private string sGXsfl_55_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string GXCCtl ;
      private string cmbavAccesstype_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string sImgUrl ;
      private string edtavDelete_action_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18HasNextPage_Grid ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV16Reload_Grid ;
      private bool AV19Exit_Grid ;
      private bool AV34isOK ;
      private bool AV25Delete_Action_IsBlob ;
      private string AV38Delete_action_GXI ;
      private string AV12GridStateKey ;
      private string AV25Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_ApplicationId ;
      private string aP1_PermissionId ;
      private GXCombobox cmbavAccesstype ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV31SDT ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV26GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV33Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV35GAMPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV29Filter ;
   }

   public class permissionchildren__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class permissionchildren__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class permissionchildren__gam : DataStoreHelperBase, IDataStoreHelper
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

public class permissionchildren__default : DataStoreHelperBase, IDataStoreHelper
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
