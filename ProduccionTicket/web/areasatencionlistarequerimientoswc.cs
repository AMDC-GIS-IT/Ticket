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
   public class areasatencionlistarequerimientoswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public areasatencionlistarequerimientoswc( )
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

      public areasatencionlistarequerimientoswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AreasAtencionId )
      {
         this.AV6AreasAtencionId = aP0_AreasAtencionId;
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
         chkavAtt_listarequerimientosid_visible = new GXCheckbox();
         chkavAtt_listarequerimientosdescripcion_visible = new GXCheckbox();
         chkavAtt_listarequerimientosusuariosistema_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "AreasAtencionId");
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
                  AV6AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
                  AssignAttri(sPrefix, false, "AV6AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV6AreasAtencionId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV6AreasAtencionId});
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
                  gxfirstwebparm = GetFirstPar( "AreasAtencionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "AreasAtencionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_106 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_106"), "."));
                  nGXsfl_106_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_106_idx"), "."));
                  sGXsfl_106_idx = GetPar( "sGXsfl_106_idx");
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
                  subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
                  AV25K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV6AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV24ClassCollection);
                  AV26OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV9CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  AV44Pgmname = GetPar( "Pgmname");
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridConfiguration);
                  AV39ListaRequerimientosDescripcion_IsAuthorized = StringUtil.StrToBool( GetPar( "ListaRequerimientosDescripcion_IsAuthorized"));
                  AV15Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosId_Visible"));
                  AV16Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosDescripcion_Visible"));
                  AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( GetPar( "Att_ListaRequerimientosUsuarioSistema_Visible"));
                  AV12FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV32Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
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
            return "listarequerimientos_Execute" ;
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
            PA8A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV44Pgmname = "AreasAtencionListaRequerimientosWC";
               context.Gx_err = 0;
               WS8A2( ) ;
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
            context.SendWebValue( "Lista requerimientoses") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188313129", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("areasatencionlistarequerimientoswc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6AreasAtencionId,4,0))}, new string[] {"AreasAtencionId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV25K2BToolsGenericSearchField));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_106", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_106), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV27GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV27GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6AreasAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV24ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV24ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vAREASATENCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV11GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV11GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED", AV39ListaRequerimientosDescripcion_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV32Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Uri, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm8A2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", "notset");
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
         return "AreasAtencionListaRequerimientosWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista requerimientoses" ;
      }

      protected void WB8A0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "areasatencionlistarequerimientoswc.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SubWorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV25K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV25K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AreasAtencionListaRequerimientosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_20_8A2( true) ;
         }
         else
         {
            wb_table1_20_8A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_20_8A2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"106\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(38), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Descripción:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtListaRequerimientosUsuarioSistema_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Registro:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A370ListaRequerimientosDescripcion);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtListaRequerimientosDescripcion_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A371ListaRequerimientosUsuarioSistema);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV40Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV41Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            nRC_GXsfl_106 = (int)(nGXsfl_106_idx-1);
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
            wb_table2_114_8A2( true) ;
         }
         else
         {
            wb_table2_114_8A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_114_8A2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection8_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolspagingcontainertable_Internalname, divK2btoolspagingcontainertable_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsabstracthiddenitemsgrid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV27GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV29UC_OrderedBy);
            ucK2borderbyusercontrol.Render(context, "k2borderby", K2borderbyusercontrol_Internalname, sPrefix+"K2BORDERBYUSERCONTROLContainer");
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
         if ( wbEnd == 106 )
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

      protected void START8A2( )
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
               Form.Meta.addItem("description", "Lista requerimientoses", 0) ;
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
               STRUP8A0( ) ;
            }
         }
      }

      protected void WS8A2( )
      {
         START8A2( ) ;
         EVT8A2( ) ;
      }

      protected void EVT8A2( )
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
                                 STRUP8A0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E118A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E128A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E138A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E148A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E158A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E168A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E178A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E188A2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8A0( ) ;
                              }
                              nGXsfl_106_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
                              SubsflControlProps_1062( ) ;
                              A369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ","));
                              A370ListaRequerimientosDescripcion = cgiGet( edtListaRequerimientosDescripcion_Internalname);
                              A371ListaRequerimientosUsuarioSistema = cgiGet( edtListaRequerimientosUsuarioSistema_Internalname);
                              AV40Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.convertURL( context.PathToRelativeUrl( AV40Update))), !bGXsfl_106_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV40Update), true);
                              AV41Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete))), !bGXsfl_106_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete), true);
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
                                          GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E198A2 ();
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
                                          GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E208A2 ();
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
                                          GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E218A2 ();
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
                                          GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E228A2 ();
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
                                             /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV25K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP8A0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
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

      protected void WE8A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8A2( ) ;
            }
         }
      }

      protected void PA8A2( )
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
         SubsflControlProps_1062( ) ;
         while ( nGXsfl_106_idx <= nRC_GXsfl_106 )
         {
            sendrow_1062( ) ;
            nGXsfl_106_idx = ((subGrid_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV25K2BToolsGenericSearchField ,
                                       short AV6AreasAtencionId ,
                                       GxSimpleCollection<string> AV24ClassCollection ,
                                       short AV26OrderedBy ,
                                       int AV9CurrentPage ,
                                       string AV44Pgmname ,
                                       SdtK2BGridConfiguration AV11GridConfiguration ,
                                       bool AV39ListaRequerimientosDescripcion_IsAuthorized ,
                                       bool AV15Att_ListaRequerimientosId_Visible ,
                                       bool AV16Att_ListaRequerimientosDescripcion_Visible ,
                                       bool AV17Att_ListaRequerimientosUsuarioSistema_Visible ,
                                       bool AV12FreezeColumnTitles ,
                                       string AV32Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E208A2 ();
         GRID_nCurrentRecord = 0;
         RF8A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LISTAREQUERIMIENTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LISTAREQUERIMIENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")));
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
         AV15Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_ListaRequerimientosId_Visible));
         AssignAttri(sPrefix, false, "AV15Att_ListaRequerimientosId_Visible", AV15Att_ListaRequerimientosId_Visible);
         AV16Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_ListaRequerimientosDescripcion_Visible));
         AssignAttri(sPrefix, false, "AV16Att_ListaRequerimientosDescripcion_Visible", AV16Att_ListaRequerimientosDescripcion_Visible);
         AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_ListaRequerimientosUsuarioSistema_Visible));
         AssignAttri(sPrefix, false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV18GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV12FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV12FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E208A2 ();
         RF8A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "AreasAtencionListaRequerimientosWC";
         context.Gx_err = 0;
      }

      protected void RF8A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 106;
         E218A2 ();
         nGXsfl_106_idx = 1;
         sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
         SubsflControlProps_1062( ) ;
         bGXsfl_106_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1062( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV25K2BToolsGenericSearchField ,
                                                 A369ListaRequerimientosId ,
                                                 A370ListaRequerimientosDescripcion ,
                                                 A371ListaRequerimientosUsuarioSistema ,
                                                 AV26OrderedBy ,
                                                 AV6AreasAtencionId ,
                                                 A366AreasAtencionId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
            lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
            lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H008A2 */
            pr_default.execute(0, new Object[] {AV6AreasAtencionId, lV25K2BToolsGenericSearchField, lV25K2BToolsGenericSearchField, lV25K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_106_idx = 1;
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A366AreasAtencionId = H008A2_A366AreasAtencionId[0];
               A371ListaRequerimientosUsuarioSistema = H008A2_A371ListaRequerimientosUsuarioSistema[0];
               A370ListaRequerimientosDescripcion = H008A2_A370ListaRequerimientosDescripcion[0];
               A369ListaRequerimientosId = H008A2_A369ListaRequerimientosId[0];
               E228A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 106;
            WB8A0( ) ;
         }
         bGXsfl_106_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8A2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LISTAREQUERIMIENTOSID"+"_"+sGXsfl_106_idx, GetSecureSignedToken( sPrefix+sGXsfl_106_idx, context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV32Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Uri, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV25K2BToolsGenericSearchField ,
                                              A369ListaRequerimientosId ,
                                              A370ListaRequerimientosDescripcion ,
                                              A371ListaRequerimientosUsuarioSistema ,
                                              AV26OrderedBy ,
                                              AV6AreasAtencionId ,
                                              A366AreasAtencionId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
         lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
         lV25K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV25K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H008A3 */
         pr_default.execute(1, new Object[] {AV6AreasAtencionId, lV25K2BToolsGenericSearchField, lV25K2BToolsGenericSearchField, lV25K2BToolsGenericSearchField});
         GRID_nRecordCount = H008A3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "AreasAtencionListaRequerimientosWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E198A2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV27GridOrders);
            /* Read saved values. */
            nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_106"), ".", ","));
            AV29UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6AreasAtencionId"), ".", ","));
            AV26OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vAREASATENCIONID"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"EXPORT_Visible"), ".", ","));
            /* Read variables values. */
            AV25K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV25K2BToolsGenericSearchField", AV25K2BToolsGenericSearchField);
            AV15Att_ListaRequerimientosId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_ListaRequerimientosId_Visible", AV15Att_ListaRequerimientosId_Visible);
            AV16Att_ListaRequerimientosDescripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosdescripcion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_ListaRequerimientosDescripcion_Visible", AV16Att_ListaRequerimientosDescripcion_Visible);
            AV17Att_ListaRequerimientosUsuarioSistema_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_listarequerimientosusuariosistema_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV18GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
            AV12FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV25K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E198A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E198A2( )
      {
         /* Start Routine */
         returnInSub = false;
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV44Pgmname,  "Grid", out  AV19RowsPerPageVariable, out  AV20RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
         if ( ! AV20RowsPerPageLoaded )
         {
            AV19RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
         }
         AV18GridSettingsRowsPerPageVariable = AV19RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV18GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV19RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, sPrefix, false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV27GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV28GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV28GridOrder.gxTpr_Ascendingorder = 0;
         AV28GridOrder.gxTpr_Descendingorder = 1;
         AV28GridOrder.gxTpr_Gridcolumnindex = 1;
         AV27GridOrders.Add(AV28GridOrder, 0);
         AV28GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV28GridOrder.gxTpr_Ascendingorder = 2;
         AV28GridOrder.gxTpr_Descendingorder = 3;
         AV28GridOrder.gxTpr_Gridcolumnindex = 2;
         AV27GridOrders.Add(AV28GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E208A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV33Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV33Messages = GXt_objcol_SdtMessages_Message1;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV33Messages.Count )
         {
            AV34Message = ((GeneXus.Utils.SdtMessages_Message)AV33Messages.Item(AV45GXV1));
            GX_msglist.addItem(AV34Message.gxTpr_Description);
            AV45GXV1 = (int)(AV45GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV37ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV44Pgmname;
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV37ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV40Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.convertURL( context.PathToRelativeUrl( AV40Update))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV40Update), true);
         AV46Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.convertURL( context.PathToRelativeUrl( AV40Update))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV40Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_106_Refreshing);
         AV41Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete), true);
         AV47Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_106_Refreshing);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV24ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV21GridStateKey = StringUtil.Str( (decimal)(AV6AreasAtencionId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV44Pgmname,  AV21GridStateKey, out  AV22GridState) ;
         AV26OrderedBy = AV22GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
         AV29UC_OrderedBy = AV22GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV29UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV29UC_OrderedBy), 4, 0));
         AV48GXV2 = 1;
         while ( AV48GXV2 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV48GXV2));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV25K2BToolsGenericSearchField = AV23GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25K2BToolsGenericSearchField", AV25K2BToolsGenericSearchField);
            }
            AV48GXV2 = (int)(AV48GXV2+1);
         }
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV22GridState.gxTpr_Currentpage > 0 ) && ( AV22GridState.gxTpr_Currentpage <= AV10K2BMaxPages ) )
         {
            AV9CurrentPage = AV22GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_gotopage( AV9CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV21GridStateKey = StringUtil.Str( (decimal)(AV6AreasAtencionId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV44Pgmname,  AV21GridStateKey, out  AV22GridState) ;
         AV22GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV22GridState.gxTpr_Orderedby = AV26OrderedBy;
         AV22GridState.gxTpr_Filtervalues.Clear();
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV23GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV23GridStateFilterValue.gxTpr_Value = AV25K2BToolsGenericSearchField;
         AV22GridState.gxTpr_Filtervalues.Add(AV23GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV44Pgmname,  AV21GridStateKey,  AV22GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV35TrnContext = new SdtK2BTrnContext(context);
         AV35TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV35TrnContext.gxTpr_Returnmode = "Stack";
         AV35TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV35TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV35TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV35TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV35TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV35TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV36TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV36TrnContextAtt.gxTpr_Attributename = "AreasAtencionId";
         AV36TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6AreasAtencionId), 4, 0);
         AV35TrnContext.gxTpr_Attributes.Add(AV36TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "ListaRequerimientos",  AV35TrnContext) ;
      }

      protected void E128A2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "ListaRequerimientos",  "ListaRequerimientos",  "Insert",  "",  "EntityManagerListaRequerimientos") )
         {
            CallWebObject(formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtListaRequerimientosId_Visible = 1;
         AssignProp(sPrefix, false, edtListaRequerimientosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV15Att_ListaRequerimientosId_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_ListaRequerimientosId_Visible", AV15Att_ListaRequerimientosId_Visible);
         edtListaRequerimientosDescripcion_Visible = 1;
         AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV16Att_ListaRequerimientosDescripcion_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_ListaRequerimientosDescripcion_Visible", AV16Att_ListaRequerimientosDescripcion_Visible);
         edtListaRequerimientosUsuarioSistema_Visible = 1;
         AssignProp(sPrefix, false, edtListaRequerimientosUsuarioSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0), !bGXsfl_106_Refreshing);
         AV17Att_ListaRequerimientosUsuarioSistema_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV44Pgmname,  "Grid",  AV11GridConfiguration,  false) ;
         AV49GXV3 = 1;
         while ( AV49GXV3 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV49GXV3));
            if ( ! AV14GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
               {
                  edtListaRequerimientosId_Visible = 0;
                  AssignProp(sPrefix, false, edtListaRequerimientosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV15Att_ListaRequerimientosId_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_ListaRequerimientosId_Visible", AV15Att_ListaRequerimientosId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
               {
                  edtListaRequerimientosDescripcion_Visible = 0;
                  AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV16Att_ListaRequerimientosDescripcion_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_ListaRequerimientosDescripcion_Visible", AV16Att_ListaRequerimientosDescripcion_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
               {
                  edtListaRequerimientosUsuarioSistema_Visible = 0;
                  AssignProp(sPrefix, false, edtListaRequerimientosUsuarioSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Visible), 5, 0), !bGXsfl_106_Refreshing);
                  AV17Att_ListaRequerimientosUsuarioSistema_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_ListaRequerimientosUsuarioSistema_Visible", AV17Att_ListaRequerimientosUsuarioSistema_Visible);
               }
            }
            AV49GXV3 = (int)(AV49GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "ListaRequerimientosId";
         AV14GridColumn.gxTpr_Columntitle = "";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "ListaRequerimientosDescripcion";
         AV14GridColumn.gxTpr_Columntitle = "Descripción:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "ListaRequerimientosUsuarioSistema";
         AV14GridColumn.gxTpr_Columntitle = "Registro:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV11GridConfiguration.gxTpr_Gridcolumns = AV13GridColumns;
      }

      protected void S132( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV37ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportAreasAtencionListaRequerimientosWC";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportAreasAtencionListaRequerimientosWC";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV37ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttInsert_Visible = 1;
            AssignProp(sPrefix, false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
         else
         {
            bttInsert_Visible = 0;
            AssignProp(sPrefix, false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV37ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV38ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerListaRequerimientos";
         AV37ActivityList.Add(AV38ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV37ActivityList) ;
         AV39ListaRequerimientosDescripcion_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV39ListaRequerimientosDescripcion_IsAuthorized", AV39ListaRequerimientosDescripcion_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_106_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_106_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV37ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_106_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_106_Refreshing);
         }
      }

      protected void S142( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         returnInSub = false;
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp(sPrefix, false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp(sPrefix, false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E218A2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV24ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV40Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.convertURL( context.PathToRelativeUrl( AV40Update))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV40Update), true);
         AV46Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.convertURL( context.PathToRelativeUrl( AV40Update))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV40Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_106_Refreshing);
         AV41Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete), true);
         AV47Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete))), !bGXsfl_106_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_106_Refreshing);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV29UC_OrderedBy = AV26OrderedBy;
         AssignAttri(sPrefix, false, "AV29UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV29UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV24ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
      }

      private void E228A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV39ListaRequerimientosDescripcion_IsAuthorized )
         {
            edtListaRequerimientosDescripcion_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         }
         else
         {
            edtListaRequerimientosDescripcion_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerlistarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ListaRequerimientosId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 106;
         }
         sendrow_1062( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_106_Refreshing )
         {
            context.DoAjaxLoad(106, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E118A2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV26OrderedBy = AV29UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E138A2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV44Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         AV50GXV4 = 1;
         while ( AV50GXV4 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV50GXV4));
            if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV15Att_ListaRequerimientosId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV16Att_ListaRequerimientosDescripcion_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV17Att_ListaRequerimientosUsuarioSistema_Visible;
            }
            AV50GXV4 = (int)(AV50GXV4+1);
         }
         AV11GridConfiguration.gxTpr_Freezecolumntitles = AV12FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV44Pgmname,  "Grid",  AV11GridConfiguration,  true) ;
         AV29UC_OrderedBy = AV26OrderedBy;
         AssignAttri(sPrefix, false, "AV29UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV29UC_OrderedBy), 4, 0));
         if ( AV19RowsPerPageVariable != AV18GridSettingsRowsPerPageVariable )
         {
            AV19RowsPerPageVariable = AV18GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV19RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV19RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV44Pgmname,  "Grid",  AV19RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV25K2BToolsGenericSearchField, AV6AreasAtencionId, AV24ClassCollection, AV26OrderedBy, AV9CurrentPage, AV44Pgmname, AV11GridConfiguration, AV39ListaRequerimientosDescripcion_IsAuthorized, AV15Att_ListaRequerimientosId_Visible, AV16Att_ListaRequerimientosDescripcion_Visible, AV17Att_ListaRequerimientosUsuarioSistema_Visible, AV12FreezeColumnTitles, AV32Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void S162( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV9CurrentPage > AV10K2BMaxPages ) && ( AV10K2BMaxPages > 0 ) )
         {
            AV9CurrentPage = AV10K2BMaxPages;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefreshCmp(sPrefix);
         }
         if ( AV10K2BMaxPages == 0 )
         {
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         }
         else
         {
            AV9CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage-1), 10, 0);
         AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage), 5, 0);
         AssignProp(sPrefix, false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV9CurrentPage+1), 10, 0);
         AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV10K2BMaxPages), 6, 0);
         AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV9CurrentPage) || ( AV9CurrentPage <= 1 ) )
         {
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblPreviouspagetextblock_Visible = 1;
            AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV9CurrentPage == 2 )
            {
               lblFirstpagetextblock_Visible = 0;
               AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblFirstpagetextblock_Visible = 1;
               AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV9CurrentPage == 3 )
               {
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp(sPrefix, false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV9CurrentPage == AV10K2BMaxPages )
         {
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            lblNextpagetextblock_Visible = 0;
            AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblNextpagetextblock_Visible = 1;
            AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV9CurrentPage == AV10K2BMaxPages - 1 )
            {
               lblLastpagetextblock_Visible = 0;
               AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblLastpagetextblock_Visible = 1;
               AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV9CurrentPage == AV10K2BMaxPages - 2 )
               {
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp(sPrefix, false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV9CurrentPage <= 1 ) && ( AV10K2BMaxPages <= 1 ) )
         {
            divK2btoolspagingcontainertable_Visible = 0;
            AssignProp(sPrefix, false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            divK2btoolspagingcontainertable_Visible = 1;
            AssignProp(sPrefix, false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E148A2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV9CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E158A2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV9CurrentPage > 1 )
         {
            AV9CurrentPage = (int)(AV9CurrentPage-1);
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E168A2( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV9CurrentPage != AV10K2BMaxPages )
         {
            AV9CurrentPage = (int)(AV9CurrentPage+1);
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_nextpage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void E178A2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         AV9CurrentPage = AV10K2BMaxPages;
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ClassCollection", AV24ClassCollection);
      }

      protected void S152( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV44Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S222( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV12FreezeColumnTitles = AV11GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
         if ( AV12FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV24ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV24ClassCollection) ;
         }
      }

      protected void E188A2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "ListaRequerimientos",  "ListaRequerimientos",  "List",  "",  "ExportAreasAtencionListaRequerimientosWC") )
         {
            new exportareasatencionlistarequerimientoswc(context ).execute(  AV6AreasAtencionId,  AV25K2BToolsGenericSearchField,  AV26OrderedBy, out  AV30OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV30OutFile, out  AV32Uri) )
            {
               CallWebObject(formatLink(AV32Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV31Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV31Guid.ToString(),  AV30OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV31Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table2_114_8A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblNoresultsfoundtable_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblNoresultsfoundtable_Internalname, tblNoresultsfoundtable_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_114_8A2e( true) ;
         }
         else
         {
            wb_table2_114_8A2e( false) ;
         }
      }

      protected void wb_table1_20_8A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e238a1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AreasAtencionListaRequerimientosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingscontentoutertable_Internalname, divK2bgridsettingscontentoutertable_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_AreasAtencionListaRequerimientosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettingstable_content_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divListarequerimientosid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosid_visible_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosid_visible_Internalname, StringUtil.BoolToStr( AV15Att_ListaRequerimientosId_Visible), "", "", 1, chkavAtt_listarequerimientosid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
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
            GxWebStd.gx_div_start( context, divListarequerimientosdescripcion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosdescripcion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_listarequerimientosdescripcion_visible_Internalname, "Descripción:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosdescripcion_visible_Internalname, StringUtil.BoolToStr( AV16Att_ListaRequerimientosDescripcion_Visible), "", "Descripción:", 1, chkavAtt_listarequerimientosdescripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(55, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
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
            GxWebStd.gx_div_start( context, divListarequerimientosusuariosistema_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_listarequerimientosusuariosistema_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, "Registro:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, StringUtil.BoolToStr( AV17Att_ListaRequerimientosUsuarioSistema_Visible), "", "Registro:", 1, chkavAtt_listarequerimientosusuariosistema_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"");
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
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpagevariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 1, "HLP_AreasAtencionListaRequerimientosWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (string)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezegridcolumntitlescontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_Internalname, "Inmovilizar títulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'" + sGXsfl_106_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV12FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreasAtencionListaRequerimientosWC.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, divDownloadsactionssectioncontainer_Visible, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e248a1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AreasAtencionListaRequerimientosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadactionstable_Internalname, divDownloadactionstable_Visible, 0, "px", 0, "px", "K2BToolsDownloadActionsTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_87_8A2( true) ;
         }
         else
         {
            wb_table3_87_8A2( false) ;
         }
         return  ;
      }

      protected void wb_table3_87_8A2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_94_8A2( true) ;
         }
         else
         {
            wb_table4_94_8A2( false) ;
         }
         return  ;
      }

      protected void wb_table4_94_8A2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_20_8A2e( true) ;
         }
         else
         {
            wb_table1_20_8A2e( false) ;
         }
      }

      protected void wb_table4_94_8A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreasAtencionListaRequerimientosWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_94_8A2e( true) ;
         }
         else
         {
            wb_table4_94_8A2e( false) ;
         }
      }

      protected void wb_table3_87_8A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e258a1_client"+"'", TempTags, "", 2, "HLP_AreasAtencionListaRequerimientosWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(106), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreasAtencionListaRequerimientosWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_87_8A2e( true) ;
         }
         else
         {
            wb_table3_87_8A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6AreasAtencionId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV6AreasAtencionId), 4, 0));
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
         PA8A2( ) ;
         WS8A2( ) ;
         WE8A2( ) ;
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
         sCtrlAV6AreasAtencionId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA8A2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "areasatencionlistarequerimientoswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8A2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6AreasAtencionId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV6AreasAtencionId), 4, 0));
         }
         wcpOAV6AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6AreasAtencionId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6AreasAtencionId != wcpOAV6AreasAtencionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6AreasAtencionId = AV6AreasAtencionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6AreasAtencionId = cgiGet( sPrefix+"AV6AreasAtencionId_CTRL");
         if ( StringUtil.Len( sCtrlAV6AreasAtencionId) > 0 )
         {
            AV6AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV6AreasAtencionId), ".", ","));
            AssignAttri(sPrefix, false, "AV6AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV6AreasAtencionId), 4, 0));
         }
         else
         {
            AV6AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV6AreasAtencionId_PARM"), ".", ","));
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
         PA8A2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8A2( ) ;
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
         WS8A2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6AreasAtencionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AreasAtencionId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6AreasAtencionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6AreasAtencionId_CTRL", StringUtil.RTrim( sCtrlAV6AreasAtencionId));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            WE8A2( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188313510", true, true);
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
         context.AddJavascriptSource("areasatencionlistarequerimientoswc.js", "?2024188313511", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1062( )
      {
         edtListaRequerimientosId_Internalname = sPrefix+"LISTAREQUERIMIENTOSID_"+sGXsfl_106_idx;
         edtListaRequerimientosDescripcion_Internalname = sPrefix+"LISTAREQUERIMIENTOSDESCRIPCION_"+sGXsfl_106_idx;
         edtListaRequerimientosUsuarioSistema_Internalname = sPrefix+"LISTAREQUERIMIENTOSUSUARIOSISTEMA_"+sGXsfl_106_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_106_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_106_idx;
      }

      protected void SubsflControlProps_fel_1062( )
      {
         edtListaRequerimientosId_Internalname = sPrefix+"LISTAREQUERIMIENTOSID_"+sGXsfl_106_fel_idx;
         edtListaRequerimientosDescripcion_Internalname = sPrefix+"LISTAREQUERIMIENTOSDESCRIPCION_"+sGXsfl_106_fel_idx;
         edtListaRequerimientosUsuarioSistema_Internalname = sPrefix+"LISTAREQUERIMIENTOSUSUARIOSISTEMA_"+sGXsfl_106_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_106_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_106_fel_idx;
      }

      protected void sendrow_1062( )
      {
         SubsflControlProps_1062( ) ;
         WB8A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_106_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_106_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_106_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtListaRequerimientosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaRequerimientosId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtListaRequerimientosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)38,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtListaRequerimientosDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosDescripcion_Internalname,(string)A370ListaRequerimientosDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtListaRequerimientosDescripcion_Link,(string)"",(string)"",(string)"",(string)edtListaRequerimientosDescripcion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtListaRequerimientosDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)-1,(bool)true,(string)"TextoCorto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtListaRequerimientosUsuarioSistema_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaRequerimientosUsuarioSistema_Internalname,(string)A371ListaRequerimientosUsuarioSistema,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaRequerimientosUsuarioSistema_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtListaRequerimientosUsuarioSistema_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)106,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV40Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV40Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV40Update)) ? AV46Update_GXI : context.PathToRelativeUrl( AV40Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV40Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV41Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete)) ? AV47Delete_GXI : context.PathToRelativeUrl( AV41Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV41Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes8A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_106_idx = ((subGrid_Islastpage==1)&&(nGXsfl_106_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1062( ) ;
         }
         /* End function sendrow_1062 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_listarequerimientosid_visible.Name = "vATT_LISTAREQUERIMIENTOSID_VISIBLE";
         chkavAtt_listarequerimientosid_visible.WebTags = "";
         chkavAtt_listarequerimientosid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_listarequerimientosid_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosid_visible.Caption, true);
         chkavAtt_listarequerimientosid_visible.CheckedValue = "false";
         chkavAtt_listarequerimientosdescripcion_visible.Name = "vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE";
         chkavAtt_listarequerimientosdescripcion_visible.WebTags = "";
         chkavAtt_listarequerimientosdescripcion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_listarequerimientosdescripcion_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosdescripcion_visible.Caption, true);
         chkavAtt_listarequerimientosdescripcion_visible.CheckedValue = "false";
         chkavAtt_listarequerimientosusuariosistema_visible.Name = "vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE";
         chkavAtt_listarequerimientosusuariosistema_visible.WebTags = "";
         chkavAtt_listarequerimientosusuariosistema_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_listarequerimientosusuariosistema_visible_Internalname, "TitleCaption", chkavAtt_listarequerimientosusuariosistema_visible.Caption, true);
         chkavAtt_listarequerimientosusuariosistema_visible.CheckedValue = "false";
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp(sPrefix, false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavK2btoolsgenericsearchfield_Internalname = sPrefix+"vK2BTOOLSGENERICSEARCHFIELD";
         imgK2bgridsettingslabel_Internalname = sPrefix+"K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = sPrefix+"RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_listarequerimientosid_visible_Internalname = sPrefix+"vATT_LISTAREQUERIMIENTOSID_VISIBLE";
         divListarequerimientosid_gridsettingscontainer_Internalname = sPrefix+"LISTAREQUERIMIENTOSID_GRIDSETTINGSCONTAINER";
         chkavAtt_listarequerimientosdescripcion_visible_Internalname = sPrefix+"vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE";
         divListarequerimientosdescripcion_gridsettingscontainer_Internalname = sPrefix+"LISTAREQUERIMIENTOSDESCRIPCION_GRIDSETTINGSCONTAINER";
         chkavAtt_listarequerimientosusuariosistema_visible_Internalname = sPrefix+"vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE";
         divListarequerimientosusuariosistema_gridsettingscontainer_Internalname = sPrefix+"LISTAREQUERIMIENTOSUSUARIOSISTEMA_GRIDSETTINGSCONTAINER";
         divGridsettingstable_content_Internalname = sPrefix+"GRIDSETTINGSTABLE_CONTENT";
         cmbavGridsettingsrowsperpagevariable_Internalname = sPrefix+"vGRIDSETTINGSROWSPERPAGEVARIABLE";
         divRowsperpagecontainer_Internalname = sPrefix+"ROWSPERPAGECONTAINER";
         chkavFreezecolumntitles_Internalname = sPrefix+"vFREEZECOLUMNTITLES";
         divFreezegridcolumntitlescontainer_Internalname = sPrefix+"FREEZEGRIDCOLUMNTITLESCONTAINER";
         bttK2bgridsettingssave_Internalname = sPrefix+"K2BGRIDSETTINGSSAVE";
         divCustomizationcollapsiblesection_Internalname = sPrefix+"CUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_Internalname = sPrefix+"GRIDCUSTOMIZATIONCONTAINER";
         divContentinnertable_Internalname = sPrefix+"CONTENTINNERTABLE";
         divK2bgridsettingscontentoutertable_Internalname = sPrefix+"K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = sPrefix+"K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = sPrefix+"IMAGE1";
         bttReport_Internalname = sPrefix+"REPORT";
         bttExport_Internalname = sPrefix+"EXPORT";
         tblK2btabledownloadssectioncontainer_Internalname = sPrefix+"K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = sPrefix+"DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = sPrefix+"DOWNLOADSACTIONSSECTIONCONTAINER";
         bttInsert_Internalname = sPrefix+"INSERT";
         tblK2btableactionsrightcontainer_Internalname = sPrefix+"K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable7_Internalname = sPrefix+"TABLE7";
         divTable10_Internalname = sPrefix+"TABLE10";
         edtListaRequerimientosId_Internalname = sPrefix+"LISTAREQUERIMIENTOSID";
         edtListaRequerimientosDescripcion_Internalname = sPrefix+"LISTAREQUERIMIENTOSDESCRIPCION";
         edtListaRequerimientosUsuarioSistema_Internalname = sPrefix+"LISTAREQUERIMIENTOSUSUARIOSISTEMA";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         lblNoresultsfoundtextblock_Internalname = sPrefix+"NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = sPrefix+"NORESULTSFOUNDTABLE";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         lblPreviouspagebuttontextblock_Internalname = sPrefix+"PREVIOUSPAGEBUTTONTEXTBLOCK";
         lblFirstpagetextblock_Internalname = sPrefix+"FIRSTPAGETEXTBLOCK";
         lblSpacinglefttextblock_Internalname = sPrefix+"SPACINGLEFTTEXTBLOCK";
         lblPreviouspagetextblock_Internalname = sPrefix+"PREVIOUSPAGETEXTBLOCK";
         lblCurrentpagetextblock_Internalname = sPrefix+"CURRENTPAGETEXTBLOCK";
         lblNextpagetextblock_Internalname = sPrefix+"NEXTPAGETEXTBLOCK";
         lblSpacingrighttextblock_Internalname = sPrefix+"SPACINGRIGHTTEXTBLOCK";
         lblLastpagetextblock_Internalname = sPrefix+"LASTPAGETEXTBLOCK";
         lblNextpagebuttontextblock_Internalname = sPrefix+"NEXTPAGEBUTTONTEXTBLOCK";
         divK2btoolspagingcontainertable_Internalname = sPrefix+"K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = sPrefix+"SECTION8";
         divTable4_Internalname = sPrefix+"TABLE4";
         divGlobalgridtable_Internalname = sPrefix+"GLOBALGRIDTABLE";
         divTable6_Internalname = sPrefix+"TABLE6";
         divTable2_Internalname = sPrefix+"TABLE2";
         K2borderbyusercontrol_Internalname = sPrefix+"K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsgrid_Internalname = sPrefix+"K2BTOOLSABSTRACTHIDDENITEMSGRID";
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
         chkavFreezecolumntitles.Caption = "Inmovilizar títulos";
         chkavAtt_listarequerimientosusuariosistema_visible.Caption = "Registro:";
         chkavAtt_listarequerimientosdescripcion_visible.Caption = "Descripción:";
         chkavAtt_listarequerimientosid_visible.Caption = "";
         edtListaRequerimientosUsuarioSistema_Jsonclick = "";
         edtListaRequerimientosDescripcion_Jsonclick = "";
         edtListaRequerimientosId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_listarequerimientosusuariosistema_visible.Enabled = 1;
         chkavAtt_listarequerimientosdescripcion_visible.Enabled = 1;
         chkavAtt_listarequerimientosid_visible.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         tblNoresultsfoundtable_Visible = 1;
         bttInsert_Tooltiptext = "Agregar";
         bttExport_Tooltiptext = "";
         bttReport_Tooltiptext = "";
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         lblLastpagetextblock_Caption = "1";
         lblLastpagetextblock_Visible = 1;
         lblSpacingrighttextblock_Visible = 1;
         lblNextpagetextblock_Caption = "#";
         lblNextpagetextblock_Visible = 1;
         lblCurrentpagetextblock_Caption = "#";
         lblPreviouspagetextblock_Caption = "#";
         lblPreviouspagetextblock_Visible = 1;
         lblSpacinglefttextblock_Visible = 1;
         lblFirstpagetextblock_Caption = "1";
         lblFirstpagetextblock_Visible = 1;
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         divK2btoolspagingcontainertable_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Tooltiptext = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Tooltiptext = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtListaRequerimientosDescripcion_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtListaRequerimientosUsuarioSistema_Visible = -1;
         edtListaRequerimientosDescripcion_Visible = -1;
         edtListaRequerimientosId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E128A2',iparms:[{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9',hsh:true},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E258A1',iparms:[{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E218A2',iparms:[{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV29UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E228A2',iparms:[{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9',hsh:true},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Link',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E118A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV29UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E238A1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E138A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV19RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV18GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV29UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV19RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E148A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E158A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E168A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E178A2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV40Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV41Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV39ListaRequerimientosDescripcion_IsAuthorized',fld:'vLISTAREQUERIMIENTOSDESCRIPCION_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV24ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtListaRequerimientosId_Visible',ctrl:'LISTAREQUERIMIENTOSID',prop:'Visible'},{av:'edtListaRequerimientosDescripcion_Visible',ctrl:'LISTAREQUERIMIENTOSDESCRIPCION',prop:'Visible'},{av:'edtListaRequerimientosUsuarioSistema_Visible',ctrl:'LISTAREQUERIMIENTOSUSUARIOSISTEMA',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E188A2',iparms:[{av:'AV6AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'},{av:'AV25K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV26OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E248A1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Att_ListaRequerimientosId_Visible',fld:'vATT_LISTAREQUERIMIENTOSID_VISIBLE',pic:''},{av:'AV16Att_ListaRequerimientosDescripcion_Visible',fld:'vATT_LISTAREQUERIMIENTOSDESCRIPCION_VISIBLE',pic:''},{av:'AV17Att_ListaRequerimientosUsuarioSistema_Visible',fld:'vATT_LISTAREQUERIMIENTOSUSUARIOSISTEMA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         sPrefix = "";
         AV25K2BToolsGenericSearchField = "";
         AV24ClassCollection = new GxSimpleCollection<string>();
         AV44Pgmname = "";
         AV11GridConfiguration = new SdtK2BGridConfiguration(context);
         AV32Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A370ListaRequerimientosDescripcion = "";
         A371ListaRequerimientosUsuarioSistema = "";
         AV40Update = "";
         AV41Delete = "";
         lblPreviouspagebuttontextblock_Jsonclick = "";
         lblFirstpagetextblock_Jsonclick = "";
         lblSpacinglefttextblock_Jsonclick = "";
         lblPreviouspagetextblock_Jsonclick = "";
         lblCurrentpagetextblock_Jsonclick = "";
         lblNextpagetextblock_Jsonclick = "";
         lblSpacingrighttextblock_Jsonclick = "";
         lblLastpagetextblock_Jsonclick = "";
         lblNextpagebuttontextblock_Jsonclick = "";
         ucK2borderbyusercontrol = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV46Update_GXI = "";
         AV47Delete_GXI = "";
         scmdbuf = "";
         lV25K2BToolsGenericSearchField = "";
         H008A2_A366AreasAtencionId = new short[1] ;
         H008A2_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         H008A2_A370ListaRequerimientosDescripcion = new string[] {""} ;
         H008A2_A369ListaRequerimientosId = new short[1] ;
         H008A3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV28GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV33Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV34Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV37ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV38ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV21GridStateKey = "";
         AV22GridState = new SdtK2BGridState(context);
         AV23GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV35TrnContext = new SdtK2BTrnContext(context);
         AV36TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV30OutFile = "";
         AV31Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         sImgUrl = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_Jsonclick = "";
         bttInsert_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6AreasAtencionId = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areasatencionlistarequerimientoswc__default(),
            new Object[][] {
                new Object[] {
               H008A2_A366AreasAtencionId, H008A2_A371ListaRequerimientosUsuarioSistema, H008A2_A370ListaRequerimientosDescripcion, H008A2_A369ListaRequerimientosId
               }
               , new Object[] {
               H008A3_AGRID_nRecordCount
               }
            }
         );
         AV44Pgmname = "AreasAtencionListaRequerimientosWC";
         /* GeneXus formulas. */
         AV44Pgmname = "AreasAtencionListaRequerimientosWC";
         context.Gx_err = 0;
      }

      private short AV6AreasAtencionId ;
      private short wcpOAV6AreasAtencionId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV26OrderedBy ;
      private short initialized ;
      private short AV29UC_OrderedBy ;
      private short AV19RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A369ListaRequerimientosId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV18GridSettingsRowsPerPageVariable ;
      private short A366AreasAtencionId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_106 ;
      private int nGXsfl_106_idx=1 ;
      private int subGrid_Rows ;
      private int AV9CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtListaRequerimientosId_Visible ;
      private int edtListaRequerimientosDescripcion_Visible ;
      private int edtListaRequerimientosUsuarioSistema_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int divK2btoolspagingcontainertable_Visible ;
      private int lblFirstpagetextblock_Visible ;
      private int lblSpacinglefttextblock_Visible ;
      private int lblPreviouspagetextblock_Visible ;
      private int lblNextpagetextblock_Visible ;
      private int lblSpacingrighttextblock_Visible ;
      private int lblLastpagetextblock_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV45GXV1 ;
      private int AV48GXV2 ;
      private int AV10K2BMaxPages ;
      private int AV49GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV50GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_106_idx="0001" ;
      private string AV25K2BToolsGenericSearchField ;
      private string AV44Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable6_Internalname ;
      private string divTable10_Internalname ;
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtListaRequerimientosDescripcion_Link ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Tooltiptext ;
      private string edtavDelete_Link ;
      private string edtavDelete_Tooltiptext ;
      private string divTable4_Internalname ;
      private string divSection8_Internalname ;
      private string divK2btoolspagingcontainertable_Internalname ;
      private string lblPreviouspagebuttontextblock_Internalname ;
      private string lblPreviouspagebuttontextblock_Jsonclick ;
      private string lblPreviouspagebuttontextblock_Class ;
      private string lblFirstpagetextblock_Internalname ;
      private string lblFirstpagetextblock_Caption ;
      private string lblFirstpagetextblock_Jsonclick ;
      private string lblSpacinglefttextblock_Internalname ;
      private string lblSpacinglefttextblock_Jsonclick ;
      private string lblPreviouspagetextblock_Internalname ;
      private string lblPreviouspagetextblock_Caption ;
      private string lblPreviouspagetextblock_Jsonclick ;
      private string lblCurrentpagetextblock_Internalname ;
      private string lblCurrentpagetextblock_Caption ;
      private string lblCurrentpagetextblock_Jsonclick ;
      private string lblNextpagetextblock_Internalname ;
      private string lblNextpagetextblock_Caption ;
      private string lblNextpagetextblock_Jsonclick ;
      private string lblSpacingrighttextblock_Internalname ;
      private string lblSpacingrighttextblock_Jsonclick ;
      private string lblLastpagetextblock_Internalname ;
      private string lblLastpagetextblock_Caption ;
      private string lblLastpagetextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Internalname ;
      private string lblNextpagebuttontextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Class ;
      private string divK2btoolsabstracthiddenitemsgrid_Internalname ;
      private string K2borderbyusercontrol_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtListaRequerimientosId_Internalname ;
      private string edtListaRequerimientosDescripcion_Internalname ;
      private string edtListaRequerimientosUsuarioSistema_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV25K2BToolsGenericSearchField ;
      private string chkavAtt_listarequerimientosid_visible_Internalname ;
      private string chkavAtt_listarequerimientosdescripcion_visible_Internalname ;
      private string chkavAtt_listarequerimientosusuariosistema_visible_Internalname ;
      private string chkavFreezecolumntitles_Internalname ;
      private string divDownloadactionstable_Internalname ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string bttReport_Tooltiptext ;
      private string bttReport_Internalname ;
      private string bttExport_Tooltiptext ;
      private string bttExport_Internalname ;
      private string bttInsert_Tooltiptext ;
      private string bttInsert_Internalname ;
      private string divDownloadsactionssectioncontainer_Internalname ;
      private string tblNoresultsfoundtable_Internalname ;
      private string GXt_char2 ;
      private string lblNoresultsfoundtextblock_Internalname ;
      private string lblNoresultsfoundtextblock_Jsonclick ;
      private string tblTable7_Internalname ;
      private string divK2bgridsettingstable_Internalname ;
      private string sImgUrl ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divListarequerimientosid_gridsettingscontainer_Internalname ;
      private string divListarequerimientosdescripcion_gridsettingscontainer_Internalname ;
      private string divListarequerimientosusuariosistema_gridsettingscontainer_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string tblK2btableactionsrightcontainer_Internalname ;
      private string bttInsert_Jsonclick ;
      private string tblK2btabledownloadssectioncontainer_Internalname ;
      private string bttReport_Jsonclick ;
      private string bttExport_Jsonclick ;
      private string sCtrlAV6AreasAtencionId ;
      private string sGXsfl_106_fel_idx="0001" ;
      private string ROClassString ;
      private string edtListaRequerimientosId_Jsonclick ;
      private string edtListaRequerimientosDescripcion_Jsonclick ;
      private string edtListaRequerimientosUsuarioSistema_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV39ListaRequerimientosDescripcion_IsAuthorized ;
      private bool AV15Att_ListaRequerimientosId_Visible ;
      private bool AV16Att_ListaRequerimientosDescripcion_Visible ;
      private bool AV17Att_ListaRequerimientosUsuarioSistema_Visible ;
      private bool AV12FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_106_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV20RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV40Update_IsBlob ;
      private bool AV41Delete_IsBlob ;
      private string AV32Uri ;
      private string A370ListaRequerimientosDescripcion ;
      private string A371ListaRequerimientosUsuarioSistema ;
      private string AV46Update_GXI ;
      private string AV47Delete_GXI ;
      private string AV21GridStateKey ;
      private string AV30OutFile ;
      private string AV40Update ;
      private string AV41Delete ;
      private Guid AV31Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_listarequerimientosid_visible ;
      private GXCheckbox chkavAtt_listarequerimientosdescripcion_visible ;
      private GXCheckbox chkavAtt_listarequerimientosusuariosistema_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private short[] H008A2_A366AreasAtencionId ;
      private string[] H008A2_A371ListaRequerimientosUsuarioSistema ;
      private string[] H008A2_A370ListaRequerimientosDescripcion ;
      private short[] H008A2_A369ListaRequerimientosId ;
      private long[] H008A3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV24ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV27GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV37ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV11GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV14GridColumn ;
      private SdtK2BGridState AV22GridState ;
      private SdtK2BGridState_FilterValue AV23GridStateFilterValue ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV28GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV34Message ;
      private SdtK2BTrnContext AV35TrnContext ;
      private SdtK2BTrnContext_Attribute AV36TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV38ActivityListItem ;
   }

   public class areasatencionlistarequerimientoswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008A2( IGxContext context ,
                                             string AV25K2BToolsGenericSearchField ,
                                             short A369ListaRequerimientosId ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV26OrderedBy ,
                                             short AV6AreasAtencionId ,
                                             short A366AreasAtencionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [AreasAtencionId], [ListaRequerimientosUsuarioSistema], [ListaRequerimientosDescripcion], [ListaRequerimientosId]";
         sFromString = " FROM [ListaRequerimientos]";
         sOrderString = "";
         AddWhere(sWhereString, "([AreasAtencionId] = @AV6AreasAtencionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV25K2BToolsGenericSearchField + '%' or [ListaRequerimientosDescripcion] like '%' + @lV25K2BToolsGenericSearchField + '%' or [ListaRequerimientosUsuarioSistema] like '%' + @lV25K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( AV26OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [ListaRequerimientosId]";
         }
         else if ( AV26OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [ListaRequerimientosId] DESC";
         }
         else if ( AV26OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [ListaRequerimientosDescripcion]";
         }
         else if ( AV26OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [ListaRequerimientosDescripcion] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [ListaRequerimientosId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H008A3( IGxContext context ,
                                             string AV25K2BToolsGenericSearchField ,
                                             short A369ListaRequerimientosId ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV26OrderedBy ,
                                             short AV6AreasAtencionId ,
                                             short A366AreasAtencionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [ListaRequerimientos]";
         AddWhere(sWhereString, "([AreasAtencionId] = @AV6AreasAtencionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV25K2BToolsGenericSearchField + '%' or [ListaRequerimientosDescripcion] like '%' + @lV25K2BToolsGenericSearchField + '%' or [ListaRequerimientosUsuarioSistema] like '%' + @lV25K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV26OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV26OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV26OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV26OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H008A2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_H008A3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH008A2;
          prmH008A2 = new Object[] {
          new ParDef("@AV6AreasAtencionId",GXType.Int16,4,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008A3;
          prmH008A3 = new Object[] {
          new ParDef("@AV6AreasAtencionId",GXType.Int16,4,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV25K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008A2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008A3,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
