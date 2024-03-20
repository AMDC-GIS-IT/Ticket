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
   public class direccionesusuariosistemawc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public direccionesusuariosistemawc( )
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

      public direccionesusuariosistemawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_DireccionId )
      {
         this.AV6DireccionId = aP0_DireccionId;
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
         chkavAtt_usuariosistemaid_visible = new GXCheckbox();
         chkavAtt_usuariosistemaidentidad_visible = new GXCheckbox();
         chkavAtt_usuariosistemanombre_visible = new GXCheckbox();
         chkavAtt_usuariosistemagerencia_visible = new GXCheckbox();
         chkavAtt_usuariosistemadepartamento_visible = new GXCheckbox();
         chkavAtt_departamentonombre_visible = new GXCheckbox();
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
               gxfirstwebparm = GetFirstPar( "DireccionId");
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
                  AV6DireccionId = (short)(NumberUtil.Val( GetPar( "DireccionId"), "."));
                  AssignAttri(sPrefix, false, "AV6DireccionId", StringUtil.LTrimStr( (decimal)(AV6DireccionId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV6DireccionId});
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
                  gxfirstwebparm = GetFirstPar( "DireccionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "DireccionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_153 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_153"), "."));
                  nGXsfl_153_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_153_idx"), "."));
                  sGXsfl_153_idx = GetPar( "sGXsfl_153_idx");
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
                  AV34K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV28UsuarioSistemaIdentidad = GetPar( "UsuarioSistemaIdentidad");
                  AV29DepartamentoNombre = GetPar( "DepartamentoNombre");
                  AV6DireccionId = (short)(NumberUtil.Val( GetPar( "DireccionId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV27ClassCollection);
                  AV35OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV54Pgmname = GetPar( "Pgmname");
                  AV9CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridConfiguration);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV47AutoLinksActivityList);
                  AV41UsuarioSistemaIdentidad_IsAuthorized = StringUtil.StrToBool( GetPar( "UsuarioSistemaIdentidad_IsAuthorized"));
                  AV15Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaId_Visible"));
                  AV16Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaIdentidad_Visible"));
                  AV17Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaNombre_Visible"));
                  AV18Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaGerencia_Visible"));
                  AV19Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaDepartamento_Visible"));
                  AV20Att_DepartamentoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_DepartamentoNombre_Visible"));
                  AV12FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV51Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
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
            return "usuariosistema_Execute" ;
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
            PA682( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV54Pgmname = "DireccionesUsuarioSistemaWC";
               context.Gx_err = 0;
               WS682( ) ;
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
            context.SendWebValue( "Usuario sistemas") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418811948", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("direccionesusuariosistemawc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6DireccionId,4,0))}, new string[] {"DireccionId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV34K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD", AV28UsuarioSistemaIdentidad);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDEPARTAMENTONOMBRE", AV29DepartamentoNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_153", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_153), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGS", AV32FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGS", AV32FilterTags);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG", StringUtil.RTrim( AV33DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV36GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV36GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6DireccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6DireccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV27ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV27ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDIRECCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DireccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV11GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV11GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAUTOLINKSACTIVITYLIST", AV47AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAUTOLINKSACTIVITYLIST", AV47AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED", AV41UsuarioSistemaIdentidad_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV51Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51Uri, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERSUMMARYTAGSUC_Emptystatemessage", StringUtil.RTrim( Filtersummarytagsuc_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm682( )
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
         return "DireccionesUsuarioSistemaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario sistemas" ;
      }

      protected void WB680( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "direccionesusuariosistemawc.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divFilterglobalcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombinedfilterlayout_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection4_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV34K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV34K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_DireccionesUsuarioSistemaWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DireccionesUsuarioSistemaWC.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV32FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV33DeletedTag);
            ucFiltersummarytagsuc.Render(context, "k2btagsviewer", Filtersummarytagsuc_Internalname, sPrefix+"FILTERSUMMARYTAGSUCContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercollapsiblesection_combined_Internalname, divFiltercollapsiblesection_combined_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsfilterscontainer_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterattributestable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsuariosistemaidentidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariosistemaidentidad_Internalname, "Identidad", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariosistemaidentidad_Internalname, AV28UsuarioSistemaIdentidad, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioSistemaIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosistemaidentidad_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuariosistemaidentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_DireccionesUsuarioSistemaWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdepartamentonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavDepartamentonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDepartamentonombre_Internalname, "Departamento Nombre", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDepartamentonombre_Internalname, AV29DepartamentoNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavDepartamentonombre_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DireccionesUsuarioSistemaWC.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_49_682( true) ;
         }
         else
         {
            wb_table1_49_682( false) ;
         }
         return  ;
      }

      protected void wb_table1_49_682e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"153\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario Sistema:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaIdentidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Identidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaGerencia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gerencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Departamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Centrodecosto Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Departamento Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtDepartamentoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Departamento Nombre") ;
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
               GridColumn.AddObjectProperty("Value", A99UsuarioSistemaId);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A101UsuarioSistemaIdentidad);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioSistemaIdentidad_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A100UsuarioSistemaNombre);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A263UsuarioSistemaGerencia);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A257UsuarioSistemaDepartamento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A259CentrodecostoId);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A261DepartamentoNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDepartamentoNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV42Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV43Delete));
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
         if ( wbEnd == 153 )
         {
            wbEnd = 0;
            nRC_GXsfl_153 = (int)(nGXsfl_153_idx-1);
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
            wb_table2_166_682( true) ;
         }
         else
         {
            wb_table2_166_682( false) ;
         }
         return  ;
      }

      protected void wb_table2_166_682e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV36GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV38UC_OrderedBy);
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
         if ( wbEnd == 153 )
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

      protected void START682( )
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
               Form.Meta.addItem("description", "Usuario sistemas", 0) ;
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
               STRUP680( ) ;
            }
         }
      }

      protected void WS682( )
      {
         START682( ) ;
         EVT682( ) ;
      }

      protected void EVT682( )
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
                                 STRUP680( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERSUMMARYTAGSUC.TAGDELETED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E13682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E14682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E15682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E16682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E17682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E18682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E19682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21682 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP680( ) ;
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
                                 STRUP680( ) ;
                              }
                              nGXsfl_153_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
                              SubsflControlProps_1532( ) ;
                              A99UsuarioSistemaId = cgiGet( edtUsuarioSistemaId_Internalname);
                              A101UsuarioSistemaIdentidad = cgiGet( edtUsuarioSistemaIdentidad_Internalname);
                              A100UsuarioSistemaNombre = cgiGet( edtUsuarioSistemaNombre_Internalname);
                              A263UsuarioSistemaGerencia = cgiGet( edtUsuarioSistemaGerencia_Internalname);
                              n263UsuarioSistemaGerencia = false;
                              A257UsuarioSistemaDepartamento = cgiGet( edtUsuarioSistemaDepartamento_Internalname);
                              n257UsuarioSistemaDepartamento = false;
                              A259CentrodecostoId = cgiGet( edtCentrodecostoId_Internalname);
                              A260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ".", ","));
                              A261DepartamentoNombre = cgiGet( edtDepartamentoNombre_Internalname);
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_153_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
                              AV43Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_153_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
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
                                          E22682 ();
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
                                          E23682 ();
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
                                          E24682 ();
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
                                          E25682 ();
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
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV34K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Usuariosistemaidentidad Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD"), AV28UsuarioSistemaIdentidad) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Departamentonombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDEPARTAMENTONOMBRE"), AV29DepartamentoNombre) != 0 )
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
                                       STRUP680( ) ;
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

      protected void WE682( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm682( ) ;
            }
         }
      }

      protected void PA682( )
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
         SubsflControlProps_1532( ) ;
         while ( nGXsfl_153_idx <= nRC_GXsfl_153 )
         {
            sendrow_1532( ) ;
            nGXsfl_153_idx = ((subGrid_Islastpage==1)&&(nGXsfl_153_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_153_idx+1);
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_1532( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV34K2BToolsGenericSearchField ,
                                       string AV28UsuarioSistemaIdentidad ,
                                       string AV29DepartamentoNombre ,
                                       short AV6DireccionId ,
                                       GxSimpleCollection<string> AV27ClassCollection ,
                                       short AV35OrderedBy ,
                                       string AV54Pgmname ,
                                       int AV9CurrentPage ,
                                       SdtK2BGridConfiguration AV11GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV47AutoLinksActivityList ,
                                       bool AV41UsuarioSistemaIdentidad_IsAuthorized ,
                                       bool AV15Att_UsuarioSistemaId_Visible ,
                                       bool AV16Att_UsuarioSistemaIdentidad_Visible ,
                                       bool AV17Att_UsuarioSistemaNombre_Visible ,
                                       bool AV18Att_UsuarioSistemaGerencia_Visible ,
                                       bool AV19Att_UsuarioSistemaDepartamento_Visible ,
                                       bool AV20Att_DepartamentoNombre_Visible ,
                                       bool AV12FreezeColumnTitles ,
                                       string AV51Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E23682 ();
         GRID_nCurrentRecord = 0;
         RF682( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOSISTEMAID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSISTEMAID", A99UsuarioSistemaId);
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
         AV15Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_UsuarioSistemaId_Visible));
         AssignAttri(sPrefix, false, "AV15Att_UsuarioSistemaId_Visible", AV15Att_UsuarioSistemaId_Visible);
         AV16Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_UsuarioSistemaIdentidad_Visible));
         AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaIdentidad_Visible", AV16Att_UsuarioSistemaIdentidad_Visible);
         AV17Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioSistemaNombre_Visible));
         AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaNombre_Visible", AV17Att_UsuarioSistemaNombre_Visible);
         AV18Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioSistemaGerencia_Visible));
         AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaGerencia_Visible", AV18Att_UsuarioSistemaGerencia_Visible);
         AV19Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioSistemaDepartamento_Visible));
         AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaDepartamento_Visible", AV19Att_UsuarioSistemaDepartamento_Visible);
         AV20Att_DepartamentoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_DepartamentoNombre_Visible));
         AssignAttri(sPrefix, false, "AV20Att_DepartamentoNombre_Visible", AV20Att_DepartamentoNombre_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV21GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV12FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV12FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E23682 ();
         RF682( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "DireccionesUsuarioSistemaWC";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV28UsuarioSistemaIdentidad ,
                                              A101UsuarioSistemaIdentidad ,
                                              AV35OrderedBy ,
                                              AV34K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              A261DepartamentoNombre ,
                                              AV29DepartamentoNombre ,
                                              AV6DireccionId ,
                                              A258DireccionId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV28UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV28UsuarioSistemaIdentidad), "%", "");
         /* Using cursor H00682 */
         pr_default.execute(0, new Object[] {AV6DireccionId, lV28UsuarioSistemaIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A258DireccionId = H00682_A258DireccionId[0];
            A260DepartamentoId = H00682_A260DepartamentoId[0];
            A259CentrodecostoId = H00682_A259CentrodecostoId[0];
            A257UsuarioSistemaDepartamento = H00682_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = H00682_n257UsuarioSistemaDepartamento[0];
            A263UsuarioSistemaGerencia = H00682_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = H00682_n263UsuarioSistemaGerencia[0];
            A100UsuarioSistemaNombre = H00682_A100UsuarioSistemaNombre[0];
            A101UsuarioSistemaIdentidad = H00682_A101UsuarioSistemaIdentidad[0];
            A99UsuarioSistemaId = H00682_A99UsuarioSistemaId[0];
            /* Using cursor H00683 */
            pr_datastore2.execute(0, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            A261DepartamentoNombre = H00683_A261DepartamentoNombre[0];
            pr_datastore2.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29DepartamentoNombre)) || ( StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( AV29DepartamentoNombre , 300 , "%"),  ' ' ) ) )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
               {
                  GRID_nRecordCount = (long)(GRID_nRecordCount+1);
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         pr_datastore2.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF682( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 153;
         E24682 ();
         nGXsfl_153_idx = 1;
         sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
         SubsflControlProps_1532( ) ;
         bGXsfl_153_Refreshing = true;
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
            SubsflControlProps_1532( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV28UsuarioSistemaIdentidad ,
                                                 A101UsuarioSistemaIdentidad ,
                                                 AV35OrderedBy ,
                                                 AV34K2BToolsGenericSearchField ,
                                                 A99UsuarioSistemaId ,
                                                 A100UsuarioSistemaNombre ,
                                                 A263UsuarioSistemaGerencia ,
                                                 A257UsuarioSistemaDepartamento ,
                                                 A261DepartamentoNombre ,
                                                 AV29DepartamentoNombre ,
                                                 AV6DireccionId ,
                                                 A258DireccionId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV28UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV28UsuarioSistemaIdentidad), "%", "");
            /* Using cursor H00684 */
            pr_default.execute(1, new Object[] {AV6DireccionId, lV28UsuarioSistemaIdentidad});
            nGXsfl_153_idx = 1;
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_1532( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A258DireccionId = H00684_A258DireccionId[0];
               A260DepartamentoId = H00684_A260DepartamentoId[0];
               A259CentrodecostoId = H00684_A259CentrodecostoId[0];
               A257UsuarioSistemaDepartamento = H00684_A257UsuarioSistemaDepartamento[0];
               n257UsuarioSistemaDepartamento = H00684_n257UsuarioSistemaDepartamento[0];
               A263UsuarioSistemaGerencia = H00684_A263UsuarioSistemaGerencia[0];
               n263UsuarioSistemaGerencia = H00684_n263UsuarioSistemaGerencia[0];
               A100UsuarioSistemaNombre = H00684_A100UsuarioSistemaNombre[0];
               A101UsuarioSistemaIdentidad = H00684_A101UsuarioSistemaIdentidad[0];
               A99UsuarioSistemaId = H00684_A99UsuarioSistemaId[0];
               /* Using cursor H00685 */
               pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
               A261DepartamentoNombre = H00685_A261DepartamentoNombre[0];
               pr_datastore2.close(1);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29DepartamentoNombre)) || ( StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( AV29DepartamentoNombre , 300 , "%"),  ' ' ) ) )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( "%" + AV34K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
                  {
                     E25682 ();
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            pr_datastore2.close(1);
            wbEnd = 153;
            WB680( ) ;
         }
         bGXsfl_153_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes682( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOSISTEMAID"+"_"+sGXsfl_153_idx, GetSecureSignedToken( sPrefix+sGXsfl_153_idx, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV51Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51Uri, "")), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "DireccionesUsuarioSistemaWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP680( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22682 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGS"), AV32FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV36GridOrders);
            /* Read saved values. */
            nRC_GXsfl_153 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_153"), ".", ","));
            AV33DeletedTag = cgiGet( sPrefix+"vDELETEDTAG");
            AV38UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DireccionId"), ".", ","));
            AV35OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vDIRECCIONID"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( sPrefix+"FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( sPrefix+"K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"EXPORT_Visible"), ".", ","));
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV34K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV34K2BToolsGenericSearchField", AV34K2BToolsGenericSearchField);
            AV28UsuarioSistemaIdentidad = cgiGet( edtavUsuariosistemaidentidad_Internalname);
            AssignAttri(sPrefix, false, "AV28UsuarioSistemaIdentidad", AV28UsuarioSistemaIdentidad);
            AV29DepartamentoNombre = cgiGet( edtavDepartamentonombre_Internalname);
            AssignAttri(sPrefix, false, "AV29DepartamentoNombre", AV29DepartamentoNombre);
            AV15Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_UsuarioSistemaId_Visible", AV15Att_UsuarioSistemaId_Visible);
            AV16Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaidentidad_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaIdentidad_Visible", AV16Att_UsuarioSistemaIdentidad_Visible);
            AV17Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemanombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaNombre_Visible", AV17Att_UsuarioSistemaNombre_Visible);
            AV18Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemagerencia_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaGerencia_Visible", AV18Att_UsuarioSistemaGerencia_Visible);
            AV19Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemadepartamento_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaDepartamento_Visible", AV19Att_UsuarioSistemaDepartamento_Visible);
            AV20Att_DepartamentoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_departamentonombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV20Att_DepartamentoNombre_Visible", AV20Att_DepartamentoNombre_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV21GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
            AV12FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV34K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD"), AV28UsuarioSistemaIdentidad) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDEPARTAMENTONOMBRE"), AV29DepartamentoNombre) != 0 )
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
         E22682 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22682( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV28UsuarioSistemaIdentidad = "";
         AssignAttri(sPrefix, false, "AV28UsuarioSistemaIdentidad", AV28UsuarioSistemaIdentidad);
         AV29DepartamentoNombre = "";
         AssignAttri(sPrefix, false, "AV29DepartamentoNombre", AV29DepartamentoNombre);
         new k2bloadrowsperpage(context ).execute(  AV54Pgmname,  "Grid", out  AV22RowsPerPageVariable, out  AV23RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
         if ( ! AV23RowsPerPageLoaded )
         {
            AV22RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
         }
         AV21GridSettingsRowsPerPageVariable = AV22RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV22RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, sPrefix, false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV36GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV37GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV37GridOrder.gxTpr_Ascendingorder = 0;
         AV37GridOrder.gxTpr_Descendingorder = 1;
         AV37GridOrder.gxTpr_Gridcolumnindex = 1;
         AV36GridOrders.Add(AV37GridOrder, 0);
         AV37GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV37GridOrder.gxTpr_Ascendingorder = 2;
         AV37GridOrder.gxTpr_Descendingorder = 3;
         AV37GridOrder.gxTpr_Gridcolumnindex = 2;
         AV36GridOrders.Add(AV37GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E23682( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV39Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV39Messages = GXt_objcol_SdtMessages_Message1;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV39Messages.Count )
         {
            AV40Message = ((GeneXus.Utils.SdtMessages_Message)AV39Messages.Item(AV55GXV1));
            GX_msglist.addItem(AV40Message.gxTpr_Description);
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV54Pgmname;
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
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
         AV42Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         AV56Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_153_Refreshing);
         AV43Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         AV57Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_153_Refreshing);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV27ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV24GridStateKey = StringUtil.Str( (decimal)(AV6DireccionId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV54Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV35OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         AV38UC_OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV38UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV38UC_OrderedBy), 4, 0));
         AV58GXV2 = 1;
         while ( AV58GXV2 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV58GXV2));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Filtername, "UsuarioSistemaIdentidad") == 0 )
            {
               AV28UsuarioSistemaIdentidad = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28UsuarioSistemaIdentidad", AV28UsuarioSistemaIdentidad);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Filtername, "DepartamentoNombre") == 0 )
            {
               AV29DepartamentoNombre = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29DepartamentoNombre", AV29DepartamentoNombre);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV34K2BToolsGenericSearchField = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34K2BToolsGenericSearchField", AV34K2BToolsGenericSearchField);
            }
            AV58GXV2 = (int)(AV58GXV2+1);
         }
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV25GridState.gxTpr_Currentpage > 0 ) && ( AV25GridState.gxTpr_Currentpage <= AV10K2BMaxPages ) )
         {
            AV9CurrentPage = AV25GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_gotopage( AV9CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV24GridStateKey = StringUtil.Str( (decimal)(AV6DireccionId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV54Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV25GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV25GridState.gxTpr_Orderedby = AV35OrderedBy;
         AV25GridState.gxTpr_Filtervalues.Clear();
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV26GridStateFilterValue.gxTpr_Filtername = "UsuarioSistemaIdentidad";
         AV26GridStateFilterValue.gxTpr_Value = AV28UsuarioSistemaIdentidad;
         AV25GridState.gxTpr_Filtervalues.Add(AV26GridStateFilterValue, 0);
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV26GridStateFilterValue.gxTpr_Filtername = "DepartamentoNombre";
         AV26GridStateFilterValue.gxTpr_Value = AV29DepartamentoNombre;
         AV25GridState.gxTpr_Filtervalues.Add(AV26GridStateFilterValue, 0);
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV26GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV26GridStateFilterValue.gxTpr_Value = AV34K2BToolsGenericSearchField;
         AV25GridState.gxTpr_Filtervalues.Add(AV26GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV54Pgmname,  AV24GridStateKey,  AV25GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV44TrnContext = new SdtK2BTrnContext(context);
         AV44TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV44TrnContext.gxTpr_Returnmode = "Stack";
         AV44TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV44TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV44TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV44TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV45TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV45TrnContextAtt.gxTpr_Attributename = "DireccionId";
         AV45TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6DireccionId), 4, 0);
         AV44TrnContext.gxTpr_Attributes.Add(AV45TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "UsuarioSistema",  AV44TrnContext) ;
      }

      protected void E13682( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "Insert",  "",  "EntityManagerUsuarioSistema") )
         {
            CallWebObject(formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtUsuarioSistemaId_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV15Att_UsuarioSistemaId_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_UsuarioSistemaId_Visible", AV15Att_UsuarioSistemaId_Visible);
         edtUsuarioSistemaIdentidad_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV16Att_UsuarioSistemaIdentidad_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaIdentidad_Visible", AV16Att_UsuarioSistemaIdentidad_Visible);
         edtUsuarioSistemaNombre_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV17Att_UsuarioSistemaNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaNombre_Visible", AV17Att_UsuarioSistemaNombre_Visible);
         edtUsuarioSistemaGerencia_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV18Att_UsuarioSistemaGerencia_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaGerencia_Visible", AV18Att_UsuarioSistemaGerencia_Visible);
         edtUsuarioSistemaDepartamento_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV19Att_UsuarioSistemaDepartamento_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaDepartamento_Visible", AV19Att_UsuarioSistemaDepartamento_Visible);
         edtDepartamentoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDepartamentoNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV20Att_DepartamentoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV20Att_DepartamentoNombre_Visible", AV20Att_DepartamentoNombre_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV54Pgmname,  "Grid",  AV11GridConfiguration,  false) ;
         AV59GXV3 = 1;
         while ( AV59GXV3 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV59GXV3));
            if ( ! AV14GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  edtUsuarioSistemaId_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV15Att_UsuarioSistemaId_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_UsuarioSistemaId_Visible", AV15Att_UsuarioSistemaId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  edtUsuarioSistemaIdentidad_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV16Att_UsuarioSistemaIdentidad_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaIdentidad_Visible", AV16Att_UsuarioSistemaIdentidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  edtUsuarioSistemaNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV17Att_UsuarioSistemaNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaNombre_Visible", AV17Att_UsuarioSistemaNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  edtUsuarioSistemaGerencia_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV18Att_UsuarioSistemaGerencia_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaGerencia_Visible", AV18Att_UsuarioSistemaGerencia_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  edtUsuarioSistemaDepartamento_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV19Att_UsuarioSistemaDepartamento_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaDepartamento_Visible", AV19Att_UsuarioSistemaDepartamento_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "DepartamentoNombre") == 0 )
               {
                  edtDepartamentoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDepartamentoNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV20Att_DepartamentoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV20Att_DepartamentoNombre_Visible", AV20Att_DepartamentoNombre_Visible);
               }
            }
            AV59GXV3 = (int)(AV59GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV14GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV14GridColumn.gxTpr_Columntitle = "Identidad";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV14GridColumn.gxTpr_Columntitle = "Nombre";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV14GridColumn.gxTpr_Columntitle = "Gerencia";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV14GridColumn.gxTpr_Columntitle = "Departamento";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "DepartamentoNombre";
         AV14GridColumn.gxTpr_Columntitle = "Departamento Nombre";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV11GridConfiguration.gxTpr_Gridcolumns = AV13GridColumns;
      }

      protected void S142( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportDireccionesUsuarioSistemaWC";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportDireccionesUsuarioSistemaWC";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(3)).gxTpr_Isauthorized )
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

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV46ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV46ActivityList) ;
         AV41UsuarioSistemaIdentidad_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV41UsuarioSistemaIdentidad_IsAuthorized", AV41UsuarioSistemaIdentidad_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV46ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
      }

      protected void S152( )
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

      protected void E24682( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV27ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV42Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         AV56Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_153_Refreshing);
         AV43Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         AV57Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_153_Refreshing);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV47AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Depto";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Depto";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerDepto";
         AV47AutoLinksActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV47AutoLinksActivityList) ;
         AV38UC_OrderedBy = AV35OrderedBy;
         AssignAttri(sPrefix, false, "AV38UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV38UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV27ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47AutoLinksActivityList", AV47AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32FilterTags", AV32FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
      }

      private void E25682( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblNoresultsfoundtable_Visible = 0;
            AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
            if ( ((SdtK2BActivityList_K2BActivityListItem)AV47AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
            {
               edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
            }
            if ( AV41UsuarioSistemaIdentidad_IsAuthorized )
            {
               edtUsuarioSistemaIdentidad_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
            }
            else
            {
               edtUsuarioSistemaIdentidad_Link = "";
            }
            edtavUpdate_Enabled = 1;
            edtavUpdate_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
            edtavUpdate_Tooltiptext = "Actualizar";
            edtavDelete_Enabled = 1;
            edtavDelete_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
            edtavDelete_Tooltiptext = "Eliminar";
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 153;
            }
            sendrow_1532( ) ;
            GRID_nEOF = 1;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
            {
               GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
            }
         }
         if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         }
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_153_Refreshing )
         {
            context.DoAjaxLoad(153, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV30K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UsuarioSistemaIdentidad)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioSistemaIdentidad";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Identidad";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV28UsuarioSistemaIdentidad;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV28UsuarioSistemaIdentidad;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29DepartamentoNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "DepartamentoNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Departamento Nombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV29DepartamentoNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV29DepartamentoNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, sPrefix, false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV30K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV32FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV54Pgmname,  "Grid",  AV30K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV32FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E11682( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33DeletedTag, "UsuarioSistemaIdentidad") == 0 )
         {
            AV28UsuarioSistemaIdentidad = "";
            AssignAttri(sPrefix, false, "AV28UsuarioSistemaIdentidad", AV28UsuarioSistemaIdentidad);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "DepartamentoNombre") == 0 )
         {
            AV29DepartamentoNombre = "";
            AssignAttri(sPrefix, false, "AV29DepartamentoNombre", AV29DepartamentoNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E12682( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV35OrderedBy = AV38UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E14682( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV54Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         AV60GXV4 = 1;
         while ( AV60GXV4 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV60GXV4));
            if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV15Att_UsuarioSistemaId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV16Att_UsuarioSistemaIdentidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV17Att_UsuarioSistemaNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV18Att_UsuarioSistemaGerencia_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV19Att_UsuarioSistemaDepartamento_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "DepartamentoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV20Att_DepartamentoNombre_Visible;
            }
            AV60GXV4 = (int)(AV60GXV4+1);
         }
         AV11GridConfiguration.gxTpr_Freezecolumntitles = AV12FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV54Pgmname,  "Grid",  AV11GridConfiguration,  true) ;
         AV38UC_OrderedBy = AV35OrderedBy;
         AssignAttri(sPrefix, false, "AV38UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV38UC_OrderedBy), 4, 0));
         if ( AV22RowsPerPageVariable != AV21GridSettingsRowsPerPageVariable )
         {
            AV22RowsPerPageVariable = AV21GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV22RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV54Pgmname,  "Grid",  AV22RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV28UsuarioSistemaIdentidad, AV29DepartamentoNombre, AV6DireccionId, AV27ClassCollection, AV35OrderedBy, AV54Pgmname, AV9CurrentPage, AV11GridConfiguration, AV47AutoLinksActivityList, AV41UsuarioSistemaIdentidad_IsAuthorized, AV15Att_UsuarioSistemaId_Visible, AV16Att_UsuarioSistemaIdentidad_Visible, AV17Att_UsuarioSistemaNombre_Visible, AV18Att_UsuarioSistemaGerencia_Visible, AV19Att_UsuarioSistemaDepartamento_Visible, AV20Att_DepartamentoNombre_Visible, AV12FreezeColumnTitles, AV51Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void S172( )
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

      protected void E15682( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV9CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E16682( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV9CurrentPage > 1 )
         {
            AV9CurrentPage = (int)(AV9CurrentPage-1);
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E17682( )
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
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E18682( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         AV9CurrentPage = AV10K2BMaxPages;
         AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void S162( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV54Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S232( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV12FreezeColumnTitles = AV11GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
         if ( AV12FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV27ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV27ClassCollection) ;
         }
      }

      protected void E19682( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "List",  "",  "ExportDireccionesUsuarioSistemaWC") )
         {
            new exportdireccionesusuariosistemawc(context ).execute(  AV6DireccionId,  AV28UsuarioSistemaIdentidad,  AV29DepartamentoNombre,  AV34K2BToolsGenericSearchField,  AV35OrderedBy, out  AV49OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV49OutFile, out  AV51Uri) )
            {
               CallWebObject(formatLink(AV51Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV50Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV50Guid.ToString(),  AV49OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV50Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E20682( )
      {
         /* Filtertoggle_combined_Click Routine */
         returnInSub = false;
         if ( divFiltercollapsiblesection_combined_Visible != 0 )
         {
            divFiltercollapsiblesection_combined_Visible = 0;
            AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         else
         {
            divFiltercollapsiblesection_combined_Visible = 1;
            AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E21682( )
      {
         /* Filterclose_combined_Click Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
         AssignProp(sPrefix, false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void wb_table2_166_682( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_166_682e( true) ;
         }
         else
         {
            wb_table2_166_682e( false) ;
         }
      }

      protected void wb_table1_49_682( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e26681_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DireccionesUsuarioSistemaWC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_DireccionesUsuarioSistemaWC.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosistemaid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemaid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemaid_visible_Internalname, "Usuario Sistema:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaid_visible_Internalname, StringUtil.BoolToStr( AV15Att_UsuarioSistemaId_Visible), "", "Usuario Sistema:", 1, chkavAtt_usuariosistemaid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(78, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,78);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemaidentidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemaidentidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemaidentidad_visible_Internalname, "Identidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaidentidad_visible_Internalname, StringUtil.BoolToStr( AV16Att_UsuarioSistemaIdentidad_Visible), "", "Identidad", 1, chkavAtt_usuariosistemaidentidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemanombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemanombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemanombre_visible_Internalname, "Nombre", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemanombre_visible_Internalname, StringUtil.BoolToStr( AV17Att_UsuarioSistemaNombre_Visible), "", "Nombre", 1, chkavAtt_usuariosistemanombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(90, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemagerencia_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemagerencia_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemagerencia_visible_Internalname, "Gerencia", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemagerencia_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioSistemaGerencia_Visible), "", "Gerencia", 1, chkavAtt_usuariosistemagerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(96, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemadepartamento_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemadepartamento_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemadepartamento_visible_Internalname, "Departamento", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemadepartamento_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioSistemaDepartamento_Visible), "", "Departamento", 1, chkavAtt_usuariosistemadepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(102, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,102);\"");
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
            GxWebStd.gx_div_start( context, divDepartamentonombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_departamentonombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_departamentonombre_visible_Internalname, "Departamento Nombre", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_departamentonombre_visible_Internalname, StringUtil.BoolToStr( AV20Att_DepartamentoNombre_Visible), "", "Departamento Nombre", 1, chkavAtt_departamentonombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", true, 1, "HLP_DireccionesUsuarioSistemaWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV12FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DireccionesUsuarioSistemaWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e27681_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DireccionesUsuarioSistemaWC.htm");
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
            wb_table3_134_682( true) ;
         }
         else
         {
            wb_table3_134_682( false) ;
         }
         return  ;
      }

      protected void wb_table3_134_682e( bool wbgen )
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
            wb_table4_141_682( true) ;
         }
         else
         {
            wb_table4_141_682( false) ;
         }
         return  ;
      }

      protected void wb_table4_141_682e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_49_682e( true) ;
         }
         else
         {
            wb_table1_49_682e( false) ;
         }
      }

      protected void wb_table4_141_682( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DireccionesUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_141_682e( true) ;
         }
         else
         {
            wb_table4_141_682e( false) ;
         }
      }

      protected void wb_table3_134_682( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e28681_client"+"'", TempTags, "", 2, "HLP_DireccionesUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DireccionesUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_134_682e( true) ;
         }
         else
         {
            wb_table3_134_682e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6DireccionId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6DireccionId", StringUtil.LTrimStr( (decimal)(AV6DireccionId), 4, 0));
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
         PA682( ) ;
         WS682( ) ;
         WE682( ) ;
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
         sCtrlAV6DireccionId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA682( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "direccionesusuariosistemawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA682( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6DireccionId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6DireccionId", StringUtil.LTrimStr( (decimal)(AV6DireccionId), 4, 0));
         }
         wcpOAV6DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6DireccionId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6DireccionId != wcpOAV6DireccionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6DireccionId = AV6DireccionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6DireccionId = cgiGet( sPrefix+"AV6DireccionId_CTRL");
         if ( StringUtil.Len( sCtrlAV6DireccionId) > 0 )
         {
            AV6DireccionId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV6DireccionId), ".", ","));
            AssignAttri(sPrefix, false, "AV6DireccionId", StringUtil.LTrimStr( (decimal)(AV6DireccionId), 4, 0));
         }
         else
         {
            AV6DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV6DireccionId_PARM"), ".", ","));
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
         PA682( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS682( ) ;
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
         WS682( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6DireccionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DireccionId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6DireccionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6DireccionId_CTRL", StringUtil.RTrim( sCtrlAV6DireccionId));
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
            WE682( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188111686", true, true);
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
         context.AddJavascriptSource("direccionesusuariosistemawc.js", "?2024188111688", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1532( )
      {
         edtUsuarioSistemaId_Internalname = sPrefix+"USUARIOSISTEMAID_"+sGXsfl_153_idx;
         edtUsuarioSistemaIdentidad_Internalname = sPrefix+"USUARIOSISTEMAIDENTIDAD_"+sGXsfl_153_idx;
         edtUsuarioSistemaNombre_Internalname = sPrefix+"USUARIOSISTEMANOMBRE_"+sGXsfl_153_idx;
         edtUsuarioSistemaGerencia_Internalname = sPrefix+"USUARIOSISTEMAGERENCIA_"+sGXsfl_153_idx;
         edtUsuarioSistemaDepartamento_Internalname = sPrefix+"USUARIOSISTEMADEPARTAMENTO_"+sGXsfl_153_idx;
         edtCentrodecostoId_Internalname = sPrefix+"CENTRODECOSTOID_"+sGXsfl_153_idx;
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID_"+sGXsfl_153_idx;
         edtDepartamentoNombre_Internalname = sPrefix+"DEPARTAMENTONOMBRE_"+sGXsfl_153_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_153_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_153_idx;
      }

      protected void SubsflControlProps_fel_1532( )
      {
         edtUsuarioSistemaId_Internalname = sPrefix+"USUARIOSISTEMAID_"+sGXsfl_153_fel_idx;
         edtUsuarioSistemaIdentidad_Internalname = sPrefix+"USUARIOSISTEMAIDENTIDAD_"+sGXsfl_153_fel_idx;
         edtUsuarioSistemaNombre_Internalname = sPrefix+"USUARIOSISTEMANOMBRE_"+sGXsfl_153_fel_idx;
         edtUsuarioSistemaGerencia_Internalname = sPrefix+"USUARIOSISTEMAGERENCIA_"+sGXsfl_153_fel_idx;
         edtUsuarioSistemaDepartamento_Internalname = sPrefix+"USUARIOSISTEMADEPARTAMENTO_"+sGXsfl_153_fel_idx;
         edtCentrodecostoId_Internalname = sPrefix+"CENTRODECOSTOID_"+sGXsfl_153_fel_idx;
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID_"+sGXsfl_153_fel_idx;
         edtDepartamentoNombre_Internalname = sPrefix+"DEPARTAMENTONOMBRE_"+sGXsfl_153_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_153_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_153_fel_idx;
      }

      protected void sendrow_1532( )
      {
         SubsflControlProps_1532( ) ;
         WB680( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_153_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_153_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_153_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaId_Internalname,(string)A99UsuarioSistemaId,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)153,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaIdentidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaIdentidad_Internalname,(string)A101UsuarioSistemaIdentidad,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtUsuarioSistemaIdentidad_Link,(string)"",(string)"",(string)"",(string)edtUsuarioSistemaIdentidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtUsuarioSistemaIdentidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaNombre_Internalname,(string)A100UsuarioSistemaNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaGerencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaGerencia_Internalname,(string)A263UsuarioSistemaGerencia,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaGerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaGerencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaDepartamento_Internalname,(string)A257UsuarioSistemaDepartamento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentrodecostoId_Internalname,(string)A259CentrodecostoId,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentrodecostoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A260DepartamentoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtDepartamentoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoNombre_Internalname,(string)A261DepartamentoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtDepartamentoNombre_Link,(string)"",(string)"",(string)"",(string)edtDepartamentoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtDepartamentoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV42Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV42Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV56Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update)) ? AV56Update_GXI : context.PathToRelativeUrl( AV42Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV42Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV43Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV57Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete)) ? AV57Delete_GXI : context.PathToRelativeUrl( AV43Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV43Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes682( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_153_idx = ((subGrid_Islastpage==1)&&(nGXsfl_153_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_153_idx+1);
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_1532( ) ;
         }
         /* End function sendrow_1532 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_usuariosistemaid_visible.Name = "vATT_USUARIOSISTEMAID_VISIBLE";
         chkavAtt_usuariosistemaid_visible.WebTags = "";
         chkavAtt_usuariosistemaid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariosistemaid_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemaid_visible.Caption, true);
         chkavAtt_usuariosistemaid_visible.CheckedValue = "false";
         chkavAtt_usuariosistemaidentidad_visible.Name = "vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE";
         chkavAtt_usuariosistemaidentidad_visible.WebTags = "";
         chkavAtt_usuariosistemaidentidad_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariosistemaidentidad_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemaidentidad_visible.Caption, true);
         chkavAtt_usuariosistemaidentidad_visible.CheckedValue = "false";
         chkavAtt_usuariosistemanombre_visible.Name = "vATT_USUARIOSISTEMANOMBRE_VISIBLE";
         chkavAtt_usuariosistemanombre_visible.WebTags = "";
         chkavAtt_usuariosistemanombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariosistemanombre_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemanombre_visible.Caption, true);
         chkavAtt_usuariosistemanombre_visible.CheckedValue = "false";
         chkavAtt_usuariosistemagerencia_visible.Name = "vATT_USUARIOSISTEMAGERENCIA_VISIBLE";
         chkavAtt_usuariosistemagerencia_visible.WebTags = "";
         chkavAtt_usuariosistemagerencia_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariosistemagerencia_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemagerencia_visible.Caption, true);
         chkavAtt_usuariosistemagerencia_visible.CheckedValue = "false";
         chkavAtt_usuariosistemadepartamento_visible.Name = "vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE";
         chkavAtt_usuariosistemadepartamento_visible.WebTags = "";
         chkavAtt_usuariosistemadepartamento_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariosistemadepartamento_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemadepartamento_visible.Caption, true);
         chkavAtt_usuariosistemadepartamento_visible.CheckedValue = "false";
         chkavAtt_departamentonombre_visible.Name = "vATT_DEPARTAMENTONOMBRE_VISIBLE";
         chkavAtt_departamentonombre_visible.WebTags = "";
         chkavAtt_departamentonombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_departamentonombre_visible_Internalname, "TitleCaption", chkavAtt_departamentonombre_visible.Caption, true);
         chkavAtt_departamentonombre_visible.CheckedValue = "false";
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
         imgFiltertoggle_combined_Internalname = sPrefix+"FILTERTOGGLE_COMBINED";
         Filtersummarytagsuc_Internalname = sPrefix+"FILTERSUMMARYTAGSUC";
         divSection4_Internalname = sPrefix+"SECTION4";
         imgFilterclose_combined_Internalname = sPrefix+"FILTERCLOSE_COMBINED";
         edtavUsuariosistemaidentidad_Internalname = sPrefix+"vUSUARIOSISTEMAIDENTIDAD";
         divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMAIDENTIDAD";
         edtavDepartamentonombre_Internalname = sPrefix+"vDEPARTAMENTONOMBRE";
         divK2btoolstable_attributecontainerdepartamentonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDEPARTAMENTONOMBRE";
         divFilterattributestable_Internalname = sPrefix+"FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = sPrefix+"K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = sPrefix+"COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = sPrefix+"FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = sPrefix+"K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = sPrefix+"RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_usuariosistemaid_visible_Internalname = sPrefix+"vATT_USUARIOSISTEMAID_VISIBLE";
         divUsuariosistemaid_gridsettingscontainer_Internalname = sPrefix+"USUARIOSISTEMAID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemaidentidad_visible_Internalname = sPrefix+"vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE";
         divUsuariosistemaidentidad_gridsettingscontainer_Internalname = sPrefix+"USUARIOSISTEMAIDENTIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemanombre_visible_Internalname = sPrefix+"vATT_USUARIOSISTEMANOMBRE_VISIBLE";
         divUsuariosistemanombre_gridsettingscontainer_Internalname = sPrefix+"USUARIOSISTEMANOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemagerencia_visible_Internalname = sPrefix+"vATT_USUARIOSISTEMAGERENCIA_VISIBLE";
         divUsuariosistemagerencia_gridsettingscontainer_Internalname = sPrefix+"USUARIOSISTEMAGERENCIA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemadepartamento_visible_Internalname = sPrefix+"vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE";
         divUsuariosistemadepartamento_gridsettingscontainer_Internalname = sPrefix+"USUARIOSISTEMADEPARTAMENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_departamentonombre_visible_Internalname = sPrefix+"vATT_DEPARTAMENTONOMBRE_VISIBLE";
         divDepartamentonombre_gridsettingscontainer_Internalname = sPrefix+"DEPARTAMENTONOMBRE_GRIDSETTINGSCONTAINER";
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
         edtUsuarioSistemaId_Internalname = sPrefix+"USUARIOSISTEMAID";
         edtUsuarioSistemaIdentidad_Internalname = sPrefix+"USUARIOSISTEMAIDENTIDAD";
         edtUsuarioSistemaNombre_Internalname = sPrefix+"USUARIOSISTEMANOMBRE";
         edtUsuarioSistemaGerencia_Internalname = sPrefix+"USUARIOSISTEMAGERENCIA";
         edtUsuarioSistemaDepartamento_Internalname = sPrefix+"USUARIOSISTEMADEPARTAMENTO";
         edtCentrodecostoId_Internalname = sPrefix+"CENTRODECOSTOID";
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         edtDepartamentoNombre_Internalname = sPrefix+"DEPARTAMENTONOMBRE";
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
         chkavAtt_departamentonombre_visible.Caption = "Departamento Nombre";
         chkavAtt_usuariosistemadepartamento_visible.Caption = "Departamento";
         chkavAtt_usuariosistemagerencia_visible.Caption = "Gerencia";
         chkavAtt_usuariosistemanombre_visible.Caption = "Nombre";
         chkavAtt_usuariosistemaidentidad_visible.Caption = "Identidad";
         chkavAtt_usuariosistemaid_visible.Caption = "Usuario Sistema:";
         edtDepartamentoNombre_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtCentrodecostoId_Jsonclick = "";
         edtUsuarioSistemaDepartamento_Jsonclick = "";
         edtUsuarioSistemaGerencia_Jsonclick = "";
         edtUsuarioSistemaNombre_Jsonclick = "";
         edtUsuarioSistemaIdentidad_Jsonclick = "";
         edtUsuarioSistemaId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_departamentonombre_visible.Enabled = 1;
         chkavAtt_usuariosistemadepartamento_visible.Enabled = 1;
         chkavAtt_usuariosistemagerencia_visible.Enabled = 1;
         chkavAtt_usuariosistemanombre_visible.Enabled = 1;
         chkavAtt_usuariosistemaidentidad_visible.Enabled = 1;
         chkavAtt_usuariosistemaid_visible.Enabled = 1;
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
         edtDepartamentoNombre_Link = "";
         edtUsuarioSistemaIdentidad_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtDepartamentoNombre_Visible = -1;
         edtUsuarioSistemaDepartamento_Visible = -1;
         edtUsuarioSistemaGerencia_Visible = -1;
         edtUsuarioSistemaNombre_Visible = -1;
         edtUsuarioSistemaIdentidad_Visible = -1;
         edtUsuarioSistemaId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavDepartamentonombre_Enabled = 1;
         edtavUsuariosistemaidentidad_Jsonclick = "";
         edtavUsuariosistemaidentidad_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E13682',iparms:[{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E28681',iparms:[{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E24682',iparms:[{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV38UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV32FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E25682',iparms:[{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A259CentrodecostoId',fld:'CENTRODECOSTOID',pic:''},{av:'A260DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZ9'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtDepartamentoNombre_Link',ctrl:'DEPARTAMENTONOMBRE',prop:'Link'},{av:'edtUsuarioSistemaIdentidad_Link',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E11682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV33DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E12682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV38UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E26681',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E14682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV22RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV21GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV22RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E15682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E16682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E17682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E18682',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV47AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV42Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV43Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV41UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoNombre_Visible',ctrl:'DEPARTAMENTONOMBRE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E19682',iparms:[{av:'AV6DireccionId',fld:'vDIRECCIONID',pic:'ZZZ9'},{av:'AV28UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV29DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:''},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E27681',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E20682',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E21682',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAID","{handler:'Valid_Usuariosistemaid',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAID",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD","{handler:'Valid_Usuariosistemaidentidad',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMANOMBRE","{handler:'Valid_Usuariosistemanombre',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMANOMBRE",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAGERENCIA","{handler:'Valid_Usuariosistemagerencia',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAGERENCIA",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMADEPARTAMENTO","{handler:'Valid_Usuariosistemadepartamento',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMADEPARTAMENTO",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_CENTRODECOSTOID","{handler:'Valid_Centrodecostoid',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_CENTRODECOSTOID",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_DEPARTAMENTONOMBRE","{handler:'Valid_Departamentonombre',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_DEPARTAMENTONOMBRE",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV16Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_DepartamentoNombre_Visible',fld:'vATT_DEPARTAMENTONOMBRE_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV34K2BToolsGenericSearchField = "";
         AV28UsuarioSistemaIdentidad = "";
         AV29DepartamentoNombre = "";
         AV27ClassCollection = new GxSimpleCollection<string>();
         AV54Pgmname = "";
         AV11GridConfiguration = new SdtK2BGridConfiguration(context);
         AV47AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV51Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV33DeletedTag = "";
         AV36GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         Filtersummarytagsuc_Emptystatemessage = "";
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgFiltertoggle_combined_Jsonclick = "";
         ucFiltersummarytagsuc = new GXUserControl();
         imgFilterclose_combined_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A99UsuarioSistemaId = "";
         A101UsuarioSistemaIdentidad = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A259CentrodecostoId = "";
         A261DepartamentoNombre = "";
         AV42Update = "";
         AV43Delete = "";
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
         AV56Update_GXI = "";
         AV57Delete_GXI = "";
         scmdbuf = "";
         lV28UsuarioSistemaIdentidad = "";
         H00682_A258DireccionId = new short[1] ;
         H00682_A260DepartamentoId = new short[1] ;
         H00682_A259CentrodecostoId = new string[] {""} ;
         H00682_A257UsuarioSistemaDepartamento = new string[] {""} ;
         H00682_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         H00682_A263UsuarioSistemaGerencia = new string[] {""} ;
         H00682_n263UsuarioSistemaGerencia = new bool[] {false} ;
         H00682_A100UsuarioSistemaNombre = new string[] {""} ;
         H00682_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00682_A99UsuarioSistemaId = new string[] {""} ;
         H00683_A261DepartamentoNombre = new string[] {""} ;
         H00684_A258DireccionId = new short[1] ;
         H00684_A260DepartamentoId = new short[1] ;
         H00684_A259CentrodecostoId = new string[] {""} ;
         H00684_A257UsuarioSistemaDepartamento = new string[] {""} ;
         H00684_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         H00684_A263UsuarioSistemaGerencia = new string[] {""} ;
         H00684_n263UsuarioSistemaGerencia = new bool[] {false} ;
         H00684_A100UsuarioSistemaNombre = new string[] {""} ;
         H00684_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00684_A99UsuarioSistemaId = new string[] {""} ;
         H00685_A261DepartamentoNombre = new string[] {""} ;
         AV5Context = new SdtK2BContext(context);
         AV37GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV39Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV40Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV46ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV24GridStateKey = "";
         AV25GridState = new SdtK2BGridState(context);
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV44TrnContext = new SdtK2BTrnContext(context);
         AV45TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV30K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV49OutFile = "";
         AV50Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_Jsonclick = "";
         bttInsert_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6DireccionId = "";
         ROClassString = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.direccionesusuariosistemawc__datastore2(),
            new Object[][] {
                new Object[] {
               H00683_A261DepartamentoNombre
               }
               , new Object[] {
               H00685_A261DepartamentoNombre
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.direccionesusuariosistemawc__default(),
            new Object[][] {
                new Object[] {
               H00682_A258DireccionId, H00682_A260DepartamentoId, H00682_A259CentrodecostoId, H00682_A257UsuarioSistemaDepartamento, H00682_n257UsuarioSistemaDepartamento, H00682_A263UsuarioSistemaGerencia, H00682_n263UsuarioSistemaGerencia, H00682_A100UsuarioSistemaNombre, H00682_A101UsuarioSistemaIdentidad, H00682_A99UsuarioSistemaId
               }
               , new Object[] {
               H00684_A258DireccionId, H00684_A260DepartamentoId, H00684_A259CentrodecostoId, H00684_A257UsuarioSistemaDepartamento, H00684_n257UsuarioSistemaDepartamento, H00684_A263UsuarioSistemaGerencia, H00684_n263UsuarioSistemaGerencia, H00684_A100UsuarioSistemaNombre, H00684_A101UsuarioSistemaIdentidad, H00684_A99UsuarioSistemaId
               }
            }
         );
         AV54Pgmname = "DireccionesUsuarioSistemaWC";
         /* GeneXus formulas. */
         AV54Pgmname = "DireccionesUsuarioSistemaWC";
         context.Gx_err = 0;
      }

      private short AV6DireccionId ;
      private short wcpOAV6DireccionId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV35OrderedBy ;
      private short initialized ;
      private short AV38UC_OrderedBy ;
      private short AV22RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A260DepartamentoId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV21GridSettingsRowsPerPageVariable ;
      private short A258DireccionId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_153 ;
      private int nGXsfl_153_idx=1 ;
      private int subGrid_Rows ;
      private int AV9CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavUsuariosistemaidentidad_Enabled ;
      private int edtavDepartamentonombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtUsuarioSistemaId_Visible ;
      private int edtUsuarioSistemaIdentidad_Visible ;
      private int edtUsuarioSistemaNombre_Visible ;
      private int edtUsuarioSistemaGerencia_Visible ;
      private int edtUsuarioSistemaDepartamento_Visible ;
      private int edtDepartamentoNombre_Visible ;
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
      private int AV55GXV1 ;
      private int AV58GXV2 ;
      private int AV10K2BMaxPages ;
      private int AV59GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV60GXV4 ;
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
      private string sGXsfl_153_idx="0001" ;
      private string AV34K2BToolsGenericSearchField ;
      private string AV54Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV33DeletedTag ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable6_Internalname ;
      private string divTable10_Internalname ;
      private string divFilterglobalcontainer_Internalname ;
      private string divCombinedfilterlayout_Internalname ;
      private string divSection4_Internalname ;
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string sImgUrl ;
      private string imgFiltertoggle_combined_Internalname ;
      private string imgFiltertoggle_combined_Jsonclick ;
      private string Filtersummarytagsuc_Internalname ;
      private string divFiltercollapsiblesection_combined_Internalname ;
      private string imgFilterclose_combined_Internalname ;
      private string imgFilterclose_combined_Jsonclick ;
      private string divK2btoolsfilterscontainer_Internalname ;
      private string divFilterattributestable_Internalname ;
      private string divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname ;
      private string edtavUsuariosistemaidentidad_Internalname ;
      private string edtavUsuariosistemaidentidad_Jsonclick ;
      private string divK2btoolstable_attributecontainerdepartamentonombre_Internalname ;
      private string edtavDepartamentonombre_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtUsuarioSistemaIdentidad_Link ;
      private string edtDepartamentoNombre_Link ;
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
      private string edtUsuarioSistemaId_Internalname ;
      private string edtUsuarioSistemaIdentidad_Internalname ;
      private string edtUsuarioSistemaNombre_Internalname ;
      private string edtUsuarioSistemaGerencia_Internalname ;
      private string edtUsuarioSistemaDepartamento_Internalname ;
      private string edtCentrodecostoId_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoNombre_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string chkavAtt_usuariosistemaid_visible_Internalname ;
      private string chkavAtt_usuariosistemaidentidad_visible_Internalname ;
      private string chkavAtt_usuariosistemanombre_visible_Internalname ;
      private string chkavAtt_usuariosistemagerencia_visible_Internalname ;
      private string chkavAtt_usuariosistemadepartamento_visible_Internalname ;
      private string chkavAtt_departamentonombre_visible_Internalname ;
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
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divUsuariosistemaid_gridsettingscontainer_Internalname ;
      private string divUsuariosistemaidentidad_gridsettingscontainer_Internalname ;
      private string divUsuariosistemanombre_gridsettingscontainer_Internalname ;
      private string divUsuariosistemagerencia_gridsettingscontainer_Internalname ;
      private string divUsuariosistemadepartamento_gridsettingscontainer_Internalname ;
      private string divDepartamentonombre_gridsettingscontainer_Internalname ;
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
      private string sCtrlAV6DireccionId ;
      private string sGXsfl_153_fel_idx="0001" ;
      private string ROClassString ;
      private string edtUsuarioSistemaId_Jsonclick ;
      private string edtUsuarioSistemaIdentidad_Jsonclick ;
      private string edtUsuarioSistemaNombre_Jsonclick ;
      private string edtUsuarioSistemaGerencia_Jsonclick ;
      private string edtUsuarioSistemaDepartamento_Jsonclick ;
      private string edtCentrodecostoId_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoNombre_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV41UsuarioSistemaIdentidad_IsAuthorized ;
      private bool AV15Att_UsuarioSistemaId_Visible ;
      private bool AV16Att_UsuarioSistemaIdentidad_Visible ;
      private bool AV17Att_UsuarioSistemaNombre_Visible ;
      private bool AV18Att_UsuarioSistemaGerencia_Visible ;
      private bool AV19Att_UsuarioSistemaDepartamento_Visible ;
      private bool AV20Att_DepartamentoNombre_Visible ;
      private bool AV12FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n263UsuarioSistemaGerencia ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool bGXsfl_153_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV23RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV42Update_IsBlob ;
      private bool AV43Delete_IsBlob ;
      private string AV28UsuarioSistemaIdentidad ;
      private string AV29DepartamentoNombre ;
      private string AV51Uri ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A259CentrodecostoId ;
      private string A261DepartamentoNombre ;
      private string AV56Update_GXI ;
      private string AV57Delete_GXI ;
      private string lV28UsuarioSistemaIdentidad ;
      private string AV24GridStateKey ;
      private string AV49OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV42Update ;
      private string AV43Delete ;
      private Guid AV50Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_usuariosistemaid_visible ;
      private GXCheckbox chkavAtt_usuariosistemaidentidad_visible ;
      private GXCheckbox chkavAtt_usuariosistemanombre_visible ;
      private GXCheckbox chkavAtt_usuariosistemagerencia_visible ;
      private GXCheckbox chkavAtt_usuariosistemadepartamento_visible ;
      private GXCheckbox chkavAtt_departamentonombre_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private short[] H00682_A258DireccionId ;
      private short[] H00682_A260DepartamentoId ;
      private string[] H00682_A259CentrodecostoId ;
      private string[] H00682_A257UsuarioSistemaDepartamento ;
      private bool[] H00682_n257UsuarioSistemaDepartamento ;
      private string[] H00682_A263UsuarioSistemaGerencia ;
      private bool[] H00682_n263UsuarioSistemaGerencia ;
      private string[] H00682_A100UsuarioSistemaNombre ;
      private string[] H00682_A101UsuarioSistemaIdentidad ;
      private string[] H00682_A99UsuarioSistemaId ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] H00683_A261DepartamentoNombre ;
      private short[] H00684_A258DireccionId ;
      private short[] H00684_A260DepartamentoId ;
      private string[] H00684_A259CentrodecostoId ;
      private string[] H00684_A257UsuarioSistemaDepartamento ;
      private bool[] H00684_n257UsuarioSistemaDepartamento ;
      private string[] H00684_A263UsuarioSistemaGerencia ;
      private bool[] H00684_n263UsuarioSistemaGerencia ;
      private string[] H00684_A100UsuarioSistemaNombre ;
      private string[] H00684_A101UsuarioSistemaIdentidad ;
      private string[] H00684_A99UsuarioSistemaId ;
      private string[] H00685_A261DepartamentoNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV27ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV30K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV32FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV36GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV39Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV47AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV46ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV11GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV14GridColumn ;
      private SdtK2BGridState AV25GridState ;
      private SdtK2BGridState_FilterValue AV26GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV31K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV37GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV40Message ;
      private SdtK2BTrnContext AV44TrnContext ;
      private SdtK2BTrnContext_Attribute AV45TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV48ActivityListItem ;
   }

   public class direccionesusuariosistemawc__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00683;
          prmH00683 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmH00685;
          prmH00685 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00683", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00683,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00685", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00685,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class direccionesusuariosistemawc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00682( IGxContext context ,
                                           string AV28UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV35OrderedBy ,
                                           string AV34K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A261DepartamentoNombre ,
                                           string AV29DepartamentoNombre ,
                                           short AV6DireccionId ,
                                           short A258DireccionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int4 = new short[2];
       Object[] GXv_Object5 = new Object[2];
       scmdbuf = "SELECT [DireccionId], [DepartamentoId], [CentrodecostoId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([DireccionId] = @AV6DireccionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV28UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int4[1] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV35OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV35OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV35OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV35OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad] DESC";
       }
       GXv_Object5[0] = scmdbuf;
       GXv_Object5[1] = GXv_int4;
       return GXv_Object5 ;
    }

    protected Object[] conditional_H00684( IGxContext context ,
                                           string AV28UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV35OrderedBy ,
                                           string AV34K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A261DepartamentoNombre ,
                                           string AV29DepartamentoNombre ,
                                           short AV6DireccionId ,
                                           short A258DireccionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int6 = new short[2];
       Object[] GXv_Object7 = new Object[2];
       scmdbuf = "SELECT [DireccionId], [DepartamentoId], [CentrodecostoId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([DireccionId] = @AV6DireccionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV28UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int6[1] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV35OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV35OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV35OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV35OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad] DESC";
       }
       GXv_Object7[0] = scmdbuf;
       GXv_Object7[1] = GXv_int6;
       return GXv_Object7 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H00682(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
             case 1 :
                   return conditional_H00684(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
        Object[] prmH00682;
        prmH00682 = new Object[] {
        new ParDef("@AV6DireccionId",GXType.Int16,4,0) ,
        new ParDef("@lV28UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        Object[] prmH00684;
        prmH00684 = new Object[] {
        new ParDef("@AV6DireccionId",GXType.Int16,4,0) ,
        new ParDef("@lV28UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        def= new CursorDef[] {
            new CursorDef("H00682", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00682,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00684", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00684,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              return;
     }
  }

}

}
