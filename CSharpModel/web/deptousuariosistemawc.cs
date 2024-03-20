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
   public class deptousuariosistemawc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public deptousuariosistemawc( )
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

      public deptousuariosistemawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CentrodecostoId ,
                           short aP1_DepartamentoId )
      {
         this.AV6CentrodecostoId = aP0_CentrodecostoId;
         this.AV7DepartamentoId = aP1_DepartamentoId;
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
         chkavAtt_direcciondescripcion_visible = new GXCheckbox();
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
               gxfirstwebparm = GetFirstPar( "CentrodecostoId");
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
                  AV6CentrodecostoId = GetPar( "CentrodecostoId");
                  AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
                  AV7DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
                  AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6CentrodecostoId,(short)AV7DepartamentoId});
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
                  gxfirstwebparm = GetFirstPar( "CentrodecostoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CentrodecostoId");
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
                  AV35K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV29UsuarioSistemaIdentidad = GetPar( "UsuarioSistemaIdentidad");
                  AV30DireccionDescripcion = GetPar( "DireccionDescripcion");
                  AV6CentrodecostoId = GetPar( "CentrodecostoId");
                  AV7DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV28ClassCollection);
                  AV36OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV55Pgmname = GetPar( "Pgmname");
                  AV10CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV12GridConfiguration);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV49AutoLinksActivityList);
                  AV42UsuarioSistemaIdentidad_IsAuthorized = StringUtil.StrToBool( GetPar( "UsuarioSistemaIdentidad_IsAuthorized"));
                  AV16Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaId_Visible"));
                  AV17Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaIdentidad_Visible"));
                  AV18Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaNombre_Visible"));
                  AV19Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaGerencia_Visible"));
                  AV20Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaDepartamento_Visible"));
                  AV21Att_DireccionDescripcion_Visible = StringUtil.StrToBool( GetPar( "Att_DireccionDescripcion_Visible"));
                  AV13FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV52Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
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
            PA632( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV55Pgmname = "DeptoUsuarioSistemaWC";
               context.Gx_err = 0;
               WS632( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188112412", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("deptousuariosistemawc.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,4,0))}, new string[] {"CentrodecostoId","DepartamentoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV35K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD", AV29UsuarioSistemaIdentidad);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDIRECCIONDESCRIPCION", AV30DireccionDescripcion);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_153", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_153), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGS", AV33FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGS", AV33FilterTags);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG", StringUtil.RTrim( AV34DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV37GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV37GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6CentrodecostoId", wcpOAV6CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV28ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV28ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTRODECOSTOID", AV6CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV12GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV12GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAUTOLINKSACTIVITYLIST", AV49AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAUTOLINKSACTIVITYLIST", AV49AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED", AV42UsuarioSistemaIdentidad_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV52Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Uri, "")), context));
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

      protected void RenderHtmlCloseForm632( )
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
         return "DeptoUsuarioSistemaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario sistemas" ;
      }

      protected void WB630( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "deptousuariosistemawc.aspx");
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
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV35K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV35K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_DeptoUsuarioSistemaWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoUsuarioSistemaWC.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV33FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV34DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoUsuarioSistemaWC.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuariosistemaidentidad_Internalname, AV29UsuarioSistemaIdentidad, StringUtil.RTrim( context.localUtil.Format( AV29UsuarioSistemaIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosistemaidentidad_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuariosistemaidentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_DeptoUsuarioSistemaWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdirecciondescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavDirecciondescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDirecciondescripcion_Internalname, "Direccion Descripcion", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDirecciondescripcion_Internalname, AV30DireccionDescripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavDirecciondescripcion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_DeptoUsuarioSistemaWC.htm");
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
            wb_table1_49_632( true) ;
         }
         else
         {
            wb_table1_49_632( false) ;
         }
         return  ;
      }

      protected void wb_table1_49_632e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Direccion Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtDireccionDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Direccion Descripcion") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A262DireccionDescripcion);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDireccionDescripcion_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDireccionDescripcion_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV43Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV44Delete));
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
            wb_table2_165_632( true) ;
         }
         else
         {
            wb_table2_165_632( false) ;
         }
         return  ;
      }

      protected void wb_table2_165_632e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV37GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV39UC_OrderedBy);
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

      protected void START632( )
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
               STRUP630( ) ;
            }
         }
      }

      protected void WS632( )
      {
         START632( ) ;
         EVT632( ) ;
      }

      protected void EVT632( )
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
                                 STRUP630( ) ;
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
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E13632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E14632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E15632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E16632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E17632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E18632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E19632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21632 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP630( ) ;
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
                                 STRUP630( ) ;
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
                              A258DireccionId = (short)(context.localUtil.CToN( cgiGet( edtDireccionId_Internalname), ".", ","));
                              A262DireccionDescripcion = cgiGet( edtDireccionDescripcion_Internalname);
                              AV43Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update))), !bGXsfl_153_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update), true);
                              AV44Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete))), !bGXsfl_153_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete), true);
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
                                          E22632 ();
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
                                          E23632 ();
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
                                          E24632 ();
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
                                          E25632 ();
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
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV35K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Usuariosistemaidentidad Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD"), AV29UsuarioSistemaIdentidad) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Direcciondescripcion Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDIRECCIONDESCRIPCION"), AV30DireccionDescripcion) != 0 )
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
                                       STRUP630( ) ;
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

      protected void WE632( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm632( ) ;
            }
         }
      }

      protected void PA632( )
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
                                       string AV35K2BToolsGenericSearchField ,
                                       string AV29UsuarioSistemaIdentidad ,
                                       string AV30DireccionDescripcion ,
                                       string AV6CentrodecostoId ,
                                       short AV7DepartamentoId ,
                                       GxSimpleCollection<string> AV28ClassCollection ,
                                       short AV36OrderedBy ,
                                       string AV55Pgmname ,
                                       int AV10CurrentPage ,
                                       SdtK2BGridConfiguration AV12GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV49AutoLinksActivityList ,
                                       bool AV42UsuarioSistemaIdentidad_IsAuthorized ,
                                       bool AV16Att_UsuarioSistemaId_Visible ,
                                       bool AV17Att_UsuarioSistemaIdentidad_Visible ,
                                       bool AV18Att_UsuarioSistemaNombre_Visible ,
                                       bool AV19Att_UsuarioSistemaGerencia_Visible ,
                                       bool AV20Att_UsuarioSistemaDepartamento_Visible ,
                                       bool AV21Att_DireccionDescripcion_Visible ,
                                       bool AV13FreezeColumnTitles ,
                                       string AV52Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E23632 ();
         GRID_nCurrentRecord = 0;
         RF632( ) ;
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
         AV16Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_UsuarioSistemaId_Visible));
         AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaId_Visible", AV16Att_UsuarioSistemaId_Visible);
         AV17Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioSistemaIdentidad_Visible));
         AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaIdentidad_Visible", AV17Att_UsuarioSistemaIdentidad_Visible);
         AV18Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioSistemaNombre_Visible));
         AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaNombre_Visible", AV18Att_UsuarioSistemaNombre_Visible);
         AV19Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioSistemaGerencia_Visible));
         AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaGerencia_Visible", AV19Att_UsuarioSistemaGerencia_Visible);
         AV20Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioSistemaDepartamento_Visible));
         AssignAttri(sPrefix, false, "AV20Att_UsuarioSistemaDepartamento_Visible", AV20Att_UsuarioSistemaDepartamento_Visible);
         AV21Att_DireccionDescripcion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_DireccionDescripcion_Visible));
         AssignAttri(sPrefix, false, "AV21Att_DireccionDescripcion_Visible", AV21Att_DireccionDescripcion_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV22GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV13FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV13FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV13FreezeColumnTitles", AV13FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E23632 ();
         RF632( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "DeptoUsuarioSistemaWC";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV29UsuarioSistemaIdentidad ,
                                              A101UsuarioSistemaIdentidad ,
                                              AV36OrderedBy ,
                                              AV35K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              A262DireccionDescripcion ,
                                              AV30DireccionDescripcion ,
                                              AV6CentrodecostoId ,
                                              AV7DepartamentoId ,
                                              A259CentrodecostoId ,
                                              A260DepartamentoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV29UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV29UsuarioSistemaIdentidad), "%", "");
         /* Using cursor H00632 */
         pr_default.execute(0, new Object[] {AV6CentrodecostoId, AV7DepartamentoId, lV29UsuarioSistemaIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A260DepartamentoId = H00632_A260DepartamentoId[0];
            A259CentrodecostoId = H00632_A259CentrodecostoId[0];
            A258DireccionId = H00632_A258DireccionId[0];
            A257UsuarioSistemaDepartamento = H00632_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = H00632_n257UsuarioSistemaDepartamento[0];
            A263UsuarioSistemaGerencia = H00632_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = H00632_n263UsuarioSistemaGerencia[0];
            A100UsuarioSistemaNombre = H00632_A100UsuarioSistemaNombre[0];
            A101UsuarioSistemaIdentidad = H00632_A101UsuarioSistemaIdentidad[0];
            A99UsuarioSistemaId = H00632_A99UsuarioSistemaId[0];
            /* Using cursor H00633 */
            pr_datastore2.execute(0, new Object[] {A258DireccionId});
            A262DireccionDescripcion = H00633_A262DireccionDescripcion[0];
            pr_datastore2.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30DireccionDescripcion)) || ( StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( AV30DireccionDescripcion , 300 , "%"),  ' ' ) ) )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
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

      protected void RF632( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 153;
         E24632 ();
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
                                                 AV29UsuarioSistemaIdentidad ,
                                                 A101UsuarioSistemaIdentidad ,
                                                 AV36OrderedBy ,
                                                 AV35K2BToolsGenericSearchField ,
                                                 A99UsuarioSistemaId ,
                                                 A100UsuarioSistemaNombre ,
                                                 A263UsuarioSistemaGerencia ,
                                                 A257UsuarioSistemaDepartamento ,
                                                 A262DireccionDescripcion ,
                                                 AV30DireccionDescripcion ,
                                                 AV6CentrodecostoId ,
                                                 AV7DepartamentoId ,
                                                 A259CentrodecostoId ,
                                                 A260DepartamentoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV29UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV29UsuarioSistemaIdentidad), "%", "");
            /* Using cursor H00634 */
            pr_default.execute(1, new Object[] {AV6CentrodecostoId, AV7DepartamentoId, lV29UsuarioSistemaIdentidad});
            nGXsfl_153_idx = 1;
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_1532( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A260DepartamentoId = H00634_A260DepartamentoId[0];
               A259CentrodecostoId = H00634_A259CentrodecostoId[0];
               A258DireccionId = H00634_A258DireccionId[0];
               A257UsuarioSistemaDepartamento = H00634_A257UsuarioSistemaDepartamento[0];
               n257UsuarioSistemaDepartamento = H00634_n257UsuarioSistemaDepartamento[0];
               A263UsuarioSistemaGerencia = H00634_A263UsuarioSistemaGerencia[0];
               n263UsuarioSistemaGerencia = H00634_n263UsuarioSistemaGerencia[0];
               A100UsuarioSistemaNombre = H00634_A100UsuarioSistemaNombre[0];
               A101UsuarioSistemaIdentidad = H00634_A101UsuarioSistemaIdentidad[0];
               A99UsuarioSistemaId = H00634_A99UsuarioSistemaId[0];
               /* Using cursor H00635 */
               pr_datastore2.execute(1, new Object[] {A258DireccionId});
               A262DireccionDescripcion = H00635_A262DireccionDescripcion[0];
               pr_datastore2.close(1);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30DireccionDescripcion)) || ( StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( AV30DireccionDescripcion , 300 , "%"),  ' ' ) ) )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( "%" + AV35K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
                  {
                     E25632 ();
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            pr_datastore2.close(1);
            wbEnd = 153;
            WB630( ) ;
         }
         bGXsfl_153_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes632( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOSISTEMAID"+"_"+sGXsfl_153_idx, GetSecureSignedToken( sPrefix+sGXsfl_153_idx, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV52Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Uri, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "DeptoUsuarioSistemaWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP630( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22632 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGS"), AV33FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV37GridOrders);
            /* Read saved values. */
            nRC_GXsfl_153 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_153"), ".", ","));
            AV34DeletedTag = cgiGet( sPrefix+"vDELETEDTAG");
            AV39UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6CentrodecostoId = cgiGet( sPrefix+"wcpOAV6CentrodecostoId");
            wcpOAV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DepartamentoId"), ".", ","));
            AV36OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vDEPARTAMENTOID"), ".", ","));
            AV6CentrodecostoId = cgiGet( sPrefix+"vCENTRODECOSTOID");
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
            AV35K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV35K2BToolsGenericSearchField", AV35K2BToolsGenericSearchField);
            AV29UsuarioSistemaIdentidad = cgiGet( edtavUsuariosistemaidentidad_Internalname);
            AssignAttri(sPrefix, false, "AV29UsuarioSistemaIdentidad", AV29UsuarioSistemaIdentidad);
            AV30DireccionDescripcion = cgiGet( edtavDirecciondescripcion_Internalname);
            AssignAttri(sPrefix, false, "AV30DireccionDescripcion", AV30DireccionDescripcion);
            AV16Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaId_Visible", AV16Att_UsuarioSistemaId_Visible);
            AV17Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaidentidad_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaIdentidad_Visible", AV17Att_UsuarioSistemaIdentidad_Visible);
            AV18Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemanombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaNombre_Visible", AV18Att_UsuarioSistemaNombre_Visible);
            AV19Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemagerencia_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaGerencia_Visible", AV19Att_UsuarioSistemaGerencia_Visible);
            AV20Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemadepartamento_visible_Internalname));
            AssignAttri(sPrefix, false, "AV20Att_UsuarioSistemaDepartamento_Visible", AV20Att_UsuarioSistemaDepartamento_Visible);
            AV21Att_DireccionDescripcion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_direcciondescripcion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV21Att_DireccionDescripcion_Visible", AV21Att_DireccionDescripcion_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV22GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
            AV13FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV13FreezeColumnTitles", AV13FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV35K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIOSISTEMAIDENTIDAD"), AV29UsuarioSistemaIdentidad) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDIRECCIONDESCRIPCION"), AV30DireccionDescripcion) != 0 )
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
         E22632 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22632( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV29UsuarioSistemaIdentidad = "";
         AssignAttri(sPrefix, false, "AV29UsuarioSistemaIdentidad", AV29UsuarioSistemaIdentidad);
         AV30DireccionDescripcion = "";
         AssignAttri(sPrefix, false, "AV30DireccionDescripcion", AV30DireccionDescripcion);
         new k2bloadrowsperpage(context ).execute(  AV55Pgmname,  "Grid", out  AV23RowsPerPageVariable, out  AV24RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV23RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23RowsPerPageVariable), 4, 0));
         if ( ! AV24RowsPerPageLoaded )
         {
            AV23RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV23RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23RowsPerPageVariable), 4, 0));
         }
         AV22GridSettingsRowsPerPageVariable = AV23RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV23RowsPerPageVariable;
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
         AV37GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV38GridOrder.gxTpr_Ascendingorder = 0;
         AV38GridOrder.gxTpr_Descendingorder = 1;
         AV38GridOrder.gxTpr_Gridcolumnindex = 1;
         AV37GridOrders.Add(AV38GridOrder, 0);
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV38GridOrder.gxTpr_Ascendingorder = 2;
         AV38GridOrder.gxTpr_Descendingorder = 3;
         AV38GridOrder.gxTpr_Gridcolumnindex = 2;
         AV37GridOrders.Add(AV38GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E23632( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV40Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV40Messages = GXt_objcol_SdtMessages_Message1;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV40Messages.Count )
         {
            AV41Message = ((GeneXus.Utils.SdtMessages_Message)AV40Messages.Item(AV56GXV1));
            GX_msglist.addItem(AV41Message.gxTpr_Description);
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV47ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV55Pgmname;
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV47ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV43Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update), true);
         AV57Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_153_Refreshing);
         AV44Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete), true);
         AV58Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_153_Refreshing);
         if ( StringUtil.StrCmp(AV9HTTPRequest.Method, "GET") == 0 )
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
         new k2bscjoinstring(context ).execute(  AV28ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV25GridStateKey = AV6CentrodecostoId + StringUtil.Str( (decimal)(AV7DepartamentoId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey, out  AV26GridState) ;
         AV36OrderedBy = AV26GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV36OrderedBy", StringUtil.LTrimStr( (decimal)(AV36OrderedBy), 4, 0));
         AV39UC_OrderedBy = AV26GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV59GXV2));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Filtername, "UsuarioSistemaIdentidad") == 0 )
            {
               AV29UsuarioSistemaIdentidad = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29UsuarioSistemaIdentidad", AV29UsuarioSistemaIdentidad);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Filtername, "DireccionDescripcion") == 0 )
            {
               AV30DireccionDescripcion = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30DireccionDescripcion", AV30DireccionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV35K2BToolsGenericSearchField = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35K2BToolsGenericSearchField", AV35K2BToolsGenericSearchField);
            }
            AV59GXV2 = (int)(AV59GXV2+1);
         }
         AV11K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV26GridState.gxTpr_Currentpage > 0 ) && ( AV26GridState.gxTpr_Currentpage <= AV11K2BMaxPages ) )
         {
            AV10CurrentPage = AV26GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
            subgrid_gotopage( AV10CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV25GridStateKey = AV6CentrodecostoId + StringUtil.Str( (decimal)(AV7DepartamentoId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey, out  AV26GridState) ;
         AV26GridState.gxTpr_Currentpage = (short)(AV10CurrentPage);
         AV26GridState.gxTpr_Orderedby = AV36OrderedBy;
         AV26GridState.gxTpr_Filtervalues.Clear();
         AV27GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV27GridStateFilterValue.gxTpr_Filtername = "UsuarioSistemaIdentidad";
         AV27GridStateFilterValue.gxTpr_Value = AV29UsuarioSistemaIdentidad;
         AV26GridState.gxTpr_Filtervalues.Add(AV27GridStateFilterValue, 0);
         AV27GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV27GridStateFilterValue.gxTpr_Filtername = "DireccionDescripcion";
         AV27GridStateFilterValue.gxTpr_Value = AV30DireccionDescripcion;
         AV26GridState.gxTpr_Filtervalues.Add(AV27GridStateFilterValue, 0);
         AV27GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV27GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV27GridStateFilterValue.gxTpr_Value = AV35K2BToolsGenericSearchField;
         AV26GridState.gxTpr_Filtervalues.Add(AV27GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey,  AV26GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV45TrnContext = new SdtK2BTrnContext(context);
         AV45TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV45TrnContext.gxTpr_Returnmode = "Stack";
         AV45TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV45TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV45TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV45TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV45TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV45TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV46TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV46TrnContextAtt.gxTpr_Attributename = "CentrodecostoId";
         AV46TrnContextAtt.gxTpr_Attributevalue = AV6CentrodecostoId;
         AV45TrnContext.gxTpr_Attributes.Add(AV46TrnContextAtt, 0);
         AV46TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV46TrnContextAtt.gxTpr_Attributename = "DepartamentoId";
         AV46TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7DepartamentoId), 4, 0);
         AV45TrnContext.gxTpr_Attributes.Add(AV46TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "UsuarioSistema",  AV45TrnContext) ;
      }

      protected void E13632( )
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
         AV16Att_UsuarioSistemaId_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaId_Visible", AV16Att_UsuarioSistemaId_Visible);
         edtUsuarioSistemaIdentidad_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV17Att_UsuarioSistemaIdentidad_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaIdentidad_Visible", AV17Att_UsuarioSistemaIdentidad_Visible);
         edtUsuarioSistemaNombre_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV18Att_UsuarioSistemaNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaNombre_Visible", AV18Att_UsuarioSistemaNombre_Visible);
         edtUsuarioSistemaGerencia_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV19Att_UsuarioSistemaGerencia_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaGerencia_Visible", AV19Att_UsuarioSistemaGerencia_Visible);
         edtUsuarioSistemaDepartamento_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV20Att_UsuarioSistemaDepartamento_Visible = true;
         AssignAttri(sPrefix, false, "AV20Att_UsuarioSistemaDepartamento_Visible", AV20Att_UsuarioSistemaDepartamento_Visible);
         edtDireccionDescripcion_Visible = 1;
         AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDireccionDescripcion_Visible), 5, 0), !bGXsfl_153_Refreshing);
         AV21Att_DireccionDescripcion_Visible = true;
         AssignAttri(sPrefix, false, "AV21Att_DireccionDescripcion_Visible", AV21Att_DireccionDescripcion_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV55Pgmname,  "Grid",  AV12GridConfiguration,  false) ;
         AV60GXV3 = 1;
         while ( AV60GXV3 <= AV12GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV15GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV12GridConfiguration.gxTpr_Gridcolumns.Item(AV60GXV3));
            if ( ! AV15GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  edtUsuarioSistemaId_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV16Att_UsuarioSistemaId_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_UsuarioSistemaId_Visible", AV16Att_UsuarioSistemaId_Visible);
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  edtUsuarioSistemaIdentidad_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV17Att_UsuarioSistemaIdentidad_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_UsuarioSistemaIdentidad_Visible", AV17Att_UsuarioSistemaIdentidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  edtUsuarioSistemaNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV18Att_UsuarioSistemaNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_UsuarioSistemaNombre_Visible", AV18Att_UsuarioSistemaNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  edtUsuarioSistemaGerencia_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV19Att_UsuarioSistemaGerencia_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_UsuarioSistemaGerencia_Visible", AV19Att_UsuarioSistemaGerencia_Visible);
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  edtUsuarioSistemaDepartamento_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV20Att_UsuarioSistemaDepartamento_Visible = false;
                  AssignAttri(sPrefix, false, "AV20Att_UsuarioSistemaDepartamento_Visible", AV20Att_UsuarioSistemaDepartamento_Visible);
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "DireccionDescripcion") == 0 )
               {
                  edtDireccionDescripcion_Visible = 0;
                  AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDireccionDescripcion_Visible), 5, 0), !bGXsfl_153_Refreshing);
                  AV21Att_DireccionDescripcion_Visible = false;
                  AssignAttri(sPrefix, false, "AV21Att_DireccionDescripcion_Visible", AV21Att_DireccionDescripcion_Visible);
               }
            }
            AV60GXV3 = (int)(AV60GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV14GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV15GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV15GridColumn.gxTpr_Columntitle = "Identidad";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV15GridColumn.gxTpr_Columntitle = "Nombre";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV15GridColumn.gxTpr_Columntitle = "Gerencia";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV15GridColumn.gxTpr_Columntitle = "Departamento";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "DireccionDescripcion";
         AV15GridColumn.gxTpr_Columntitle = "Direccion Descripcion";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV12GridConfiguration.gxTpr_Gridcolumns = AV14GridColumns;
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
         AV47ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportDeptoUsuarioSistemaWC";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportDeptoUsuarioSistemaWC";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV47ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV47ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV47ActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV47ActivityList) ;
         AV42UsuarioSistemaIdentidad_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV42UsuarioSistemaIdentidad_IsAuthorized", AV42UsuarioSistemaIdentidad_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_153_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV47ActivityList.Item(3)).gxTpr_Isauthorized )
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

      protected void E24632( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV28ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV43Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update), true);
         AV57Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_153_Refreshing);
         AV44Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete), true);
         AV58Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete))), !bGXsfl_153_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete), true);
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
         AV49AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Direcciones";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Direcciones";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV48ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerDirecciones";
         AV49AutoLinksActivityList.Add(AV48ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV49AutoLinksActivityList) ;
         AV39UC_OrderedBy = AV36OrderedBy;
         AssignAttri(sPrefix, false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV28ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49AutoLinksActivityList", AV49AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33FilterTags", AV33FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
      }

      private void E25632( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblNoresultsfoundtable_Visible = 0;
            AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
            if ( ((SdtK2BActivityList_K2BActivityListItem)AV49AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
            {
               edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
            }
            if ( AV42UsuarioSistemaIdentidad_IsAuthorized )
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
         AV31K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29UsuarioSistemaIdentidad)) )
         {
            AV32K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV32K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioSistemaIdentidad";
            AV32K2BFilterValuesSDTItem.gxTpr_Description = "Identidad";
            AV32K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV32K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV32K2BFilterValuesSDTItem.gxTpr_Value = AV29UsuarioSistemaIdentidad;
            AV32K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV29UsuarioSistemaIdentidad;
            AV31K2BFilterValuesSDT.Add(AV32K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30DireccionDescripcion)) )
         {
            AV32K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV32K2BFilterValuesSDTItem.gxTpr_Name = "DireccionDescripcion";
            AV32K2BFilterValuesSDTItem.gxTpr_Description = "Direccion Descripcion";
            AV32K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV32K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV32K2BFilterValuesSDTItem.gxTpr_Value = AV30DireccionDescripcion;
            AV32K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV30DireccionDescripcion;
            AV31K2BFilterValuesSDT.Add(AV32K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, sPrefix, false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV31K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV33FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV55Pgmname,  "Grid",  AV31K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV33FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E11632( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34DeletedTag, "UsuarioSistemaIdentidad") == 0 )
         {
            AV29UsuarioSistemaIdentidad = "";
            AssignAttri(sPrefix, false, "AV29UsuarioSistemaIdentidad", AV29UsuarioSistemaIdentidad);
         }
         else if ( StringUtil.StrCmp(AV34DeletedTag, "DireccionDescripcion") == 0 )
         {
            AV30DireccionDescripcion = "";
            AssignAttri(sPrefix, false, "AV30DireccionDescripcion", AV30DireccionDescripcion);
         }
         gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void E12632( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV36OrderedBy = AV39UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV36OrderedBy", StringUtil.LTrimStr( (decimal)(AV36OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void E14632( )
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
         new k2bloadgridconfiguration(context ).execute(  AV55Pgmname,  "Grid", ref  AV12GridConfiguration) ;
         AV61GXV4 = 1;
         while ( AV61GXV4 <= AV12GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV15GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV12GridConfiguration.gxTpr_Gridcolumns.Item(AV61GXV4));
            if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV16Att_UsuarioSistemaId_Visible;
            }
            else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV17Att_UsuarioSistemaIdentidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV18Att_UsuarioSistemaNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV19Att_UsuarioSistemaGerencia_Visible;
            }
            else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV20Att_UsuarioSistemaDepartamento_Visible;
            }
            else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "DireccionDescripcion") == 0 )
            {
               AV15GridColumn.gxTpr_Showattribute = AV21Att_DireccionDescripcion_Visible;
            }
            AV61GXV4 = (int)(AV61GXV4+1);
         }
         AV12GridConfiguration.gxTpr_Freezecolumntitles = AV13FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV55Pgmname,  "Grid",  AV12GridConfiguration,  true) ;
         AV39UC_OrderedBy = AV36OrderedBy;
         AssignAttri(sPrefix, false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
         if ( AV23RowsPerPageVariable != AV22GridSettingsRowsPerPageVariable )
         {
            AV23RowsPerPageVariable = AV22GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV23RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV23RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV23RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV55Pgmname,  "Grid",  AV23RowsPerPageVariable) ;
            AV10CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV35K2BToolsGenericSearchField, AV29UsuarioSistemaIdentidad, AV30DireccionDescripcion, AV6CentrodecostoId, AV7DepartamentoId, AV28ClassCollection, AV36OrderedBy, AV55Pgmname, AV10CurrentPage, AV12GridConfiguration, AV49AutoLinksActivityList, AV42UsuarioSistemaIdentidad_IsAuthorized, AV16Att_UsuarioSistemaId_Visible, AV17Att_UsuarioSistemaIdentidad_Visible, AV18Att_UsuarioSistemaNombre_Visible, AV19Att_UsuarioSistemaGerencia_Visible, AV20Att_UsuarioSistemaDepartamento_Visible, AV21Att_DireccionDescripcion_Visible, AV13FreezeColumnTitles, AV52Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void S172( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV11K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV10CurrentPage > AV11K2BMaxPages ) && ( AV11K2BMaxPages > 0 ) )
         {
            AV10CurrentPage = AV11K2BMaxPages;
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefreshCmp(sPrefix);
         }
         if ( AV11K2BMaxPages == 0 )
         {
            AV10CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
         }
         else
         {
            AV10CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp(sPrefix, false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV10CurrentPage-1), 10, 0);
         AssignProp(sPrefix, false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV10CurrentPage), 5, 0);
         AssignProp(sPrefix, false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV10CurrentPage+1), 10, 0);
         AssignProp(sPrefix, false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV11K2BMaxPages), 6, 0);
         AssignProp(sPrefix, false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV10CurrentPage) || ( AV10CurrentPage <= 1 ) )
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
            if ( AV10CurrentPage == 2 )
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
               if ( AV10CurrentPage == 3 )
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
         if ( AV10CurrentPage == AV11K2BMaxPages )
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
            if ( AV10CurrentPage == AV11K2BMaxPages - 1 )
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
               if ( AV10CurrentPage == AV11K2BMaxPages - 2 )
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
         if ( ( AV10CurrentPage <= 1 ) && ( AV11K2BMaxPages <= 1 ) )
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

      protected void E15632( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV10CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void E16632( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV10CurrentPage > 1 )
         {
            AV10CurrentPage = (int)(AV10CurrentPage-1);
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void E17632( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV11K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV10CurrentPage != AV11K2BMaxPages )
         {
            AV10CurrentPage = (int)(AV10CurrentPage+1);
            AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
      }

      protected void E18632( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV11K2BMaxPages = subGrid_fnc_Pagecount( );
         AV10CurrentPage = AV11K2BMaxPages;
         AssignAttri(sPrefix, false, "AV10CurrentPage", StringUtil.LTrimStr( (decimal)(AV10CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridConfiguration", AV12GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ClassCollection", AV28ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV55Pgmname,  "Grid", ref  AV12GridConfiguration) ;
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
         AV13FreezeColumnTitles = AV12GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV13FreezeColumnTitles", AV13FreezeColumnTitles);
         if ( AV13FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV28ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV28ClassCollection) ;
         }
      }

      protected void E19632( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "List",  "",  "ExportDeptoUsuarioSistemaWC") )
         {
            new exportdeptousuariosistemawc(context ).execute(  AV6CentrodecostoId,  AV7DepartamentoId,  AV29UsuarioSistemaIdentidad,  AV30DireccionDescripcion,  AV35K2BToolsGenericSearchField,  AV36OrderedBy, out  AV50OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV50OutFile, out  AV52Uri) )
            {
               CallWebObject(formatLink(AV52Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV51Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV51Guid.ToString(),  AV50OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV51Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E20632( )
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

      protected void E21632( )
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

      protected void wb_table2_165_632( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_165_632e( true) ;
         }
         else
         {
            wb_table2_165_632e( false) ;
         }
      }

      protected void wb_table1_49_632( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e26631_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoUsuarioSistemaWC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_DeptoUsuarioSistemaWC.htm");
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
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaid_visible_Internalname, StringUtil.BoolToStr( AV16Att_UsuarioSistemaId_Visible), "", "Usuario Sistema:", 1, chkavAtt_usuariosistemaid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(78, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,78);\"");
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
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaidentidad_visible_Internalname, StringUtil.BoolToStr( AV17Att_UsuarioSistemaIdentidad_Visible), "", "Identidad", 1, chkavAtt_usuariosistemaidentidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
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
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemanombre_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioSistemaNombre_Visible), "", "Nombre", 1, chkavAtt_usuariosistemanombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(90, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
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
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemagerencia_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioSistemaGerencia_Visible), "", "Gerencia", 1, chkavAtt_usuariosistemagerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(96, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
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
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemadepartamento_visible_Internalname, StringUtil.BoolToStr( AV20Att_UsuarioSistemaDepartamento_Visible), "", "Departamento", 1, chkavAtt_usuariosistemadepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(102, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,102);\"");
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
            GxWebStd.gx_div_start( context, divDirecciondescripcion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_direcciondescripcion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_direcciondescripcion_visible_Internalname, "Direccion Descripcion", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_153_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_direcciondescripcion_visible_Internalname, StringUtil.BoolToStr( AV21Att_DireccionDescripcion_Visible), "", "Direccion Descripcion", 1, chkavAtt_direcciondescripcion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", true, 1, "HLP_DeptoUsuarioSistemaWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPageVariable), 4, 0));
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
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV13FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
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
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DeptoUsuarioSistemaWC.htm");
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
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e27631_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoUsuarioSistemaWC.htm");
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
            wb_table3_134_632( true) ;
         }
         else
         {
            wb_table3_134_632( false) ;
         }
         return  ;
      }

      protected void wb_table3_134_632e( bool wbgen )
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
            wb_table4_141_632( true) ;
         }
         else
         {
            wb_table4_141_632( false) ;
         }
         return  ;
      }

      protected void wb_table4_141_632e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_49_632e( true) ;
         }
         else
         {
            wb_table1_49_632e( false) ;
         }
      }

      protected void wb_table4_141_632( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DeptoUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_141_632e( true) ;
         }
         else
         {
            wb_table4_141_632e( false) ;
         }
      }

      protected void wb_table3_134_632( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e28631_client"+"'", TempTags, "", 2, "HLP_DeptoUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(153), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_DeptoUsuarioSistemaWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_134_632e( true) ;
         }
         else
         {
            wb_table3_134_632e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6CentrodecostoId = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
         AV7DepartamentoId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
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
         PA632( ) ;
         WS632( ) ;
         WE632( ) ;
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
         sCtrlAV6CentrodecostoId = (string)((string)getParm(obj,0));
         sCtrlAV7DepartamentoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA632( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "deptousuariosistemawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA632( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6CentrodecostoId = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
            AV7DepartamentoId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
         }
         wcpOAV6CentrodecostoId = cgiGet( sPrefix+"wcpOAV6CentrodecostoId");
         wcpOAV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DepartamentoId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6CentrodecostoId, wcpOAV6CentrodecostoId) != 0 ) || ( AV7DepartamentoId != wcpOAV7DepartamentoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6CentrodecostoId = AV6CentrodecostoId;
         wcpOAV7DepartamentoId = AV7DepartamentoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6CentrodecostoId = cgiGet( sPrefix+"AV6CentrodecostoId_CTRL");
         if ( StringUtil.Len( sCtrlAV6CentrodecostoId) > 0 )
         {
            AV6CentrodecostoId = cgiGet( sCtrlAV6CentrodecostoId);
            AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
         }
         else
         {
            AV6CentrodecostoId = cgiGet( sPrefix+"AV6CentrodecostoId_PARM");
         }
         sCtrlAV7DepartamentoId = cgiGet( sPrefix+"AV7DepartamentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7DepartamentoId) > 0 )
         {
            AV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7DepartamentoId), ".", ","));
            AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
         }
         else
         {
            AV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7DepartamentoId_PARM"), ".", ","));
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
         PA632( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS632( ) ;
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
         WS632( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6CentrodecostoId_PARM", AV6CentrodecostoId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6CentrodecostoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6CentrodecostoId_CTRL", StringUtil.RTrim( sCtrlAV6CentrodecostoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7DepartamentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7DepartamentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7DepartamentoId_CTRL", StringUtil.RTrim( sCtrlAV7DepartamentoId));
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
            WE632( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188113150", true, true);
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
         context.AddJavascriptSource("deptousuariosistemawc.js", "?2024188113152", false, true);
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
         edtDireccionId_Internalname = sPrefix+"DIRECCIONID_"+sGXsfl_153_idx;
         edtDireccionDescripcion_Internalname = sPrefix+"DIRECCIONDESCRIPCION_"+sGXsfl_153_idx;
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
         edtDireccionId_Internalname = sPrefix+"DIRECCIONID_"+sGXsfl_153_fel_idx;
         edtDireccionDescripcion_Internalname = sPrefix+"DIRECCIONDESCRIPCION_"+sGXsfl_153_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_153_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_153_fel_idx;
      }

      protected void sendrow_1532( )
      {
         SubsflControlProps_1532( ) ;
         WB630( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDireccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A258DireccionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDireccionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtDireccionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDireccionDescripcion_Internalname,(string)A262DireccionDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtDireccionDescripcion_Link,(string)"",(string)"",(string)"",(string)edtDireccionDescripcion_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtDireccionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)153,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV43Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV43Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV57Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update)) ? AV57Update_GXI : context.PathToRelativeUrl( AV43Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV43Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV44Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV58Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete)) ? AV58Delete_GXI : context.PathToRelativeUrl( AV44Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV44Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes632( ) ;
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
         chkavAtt_direcciondescripcion_visible.Name = "vATT_DIRECCIONDESCRIPCION_VISIBLE";
         chkavAtt_direcciondescripcion_visible.WebTags = "";
         chkavAtt_direcciondescripcion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_direcciondescripcion_visible_Internalname, "TitleCaption", chkavAtt_direcciondescripcion_visible.Caption, true);
         chkavAtt_direcciondescripcion_visible.CheckedValue = "false";
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
         edtavDirecciondescripcion_Internalname = sPrefix+"vDIRECCIONDESCRIPCION";
         divK2btoolstable_attributecontainerdirecciondescripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDIRECCIONDESCRIPCION";
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
         chkavAtt_direcciondescripcion_visible_Internalname = sPrefix+"vATT_DIRECCIONDESCRIPCION_VISIBLE";
         divDirecciondescripcion_gridsettingscontainer_Internalname = sPrefix+"DIRECCIONDESCRIPCION_GRIDSETTINGSCONTAINER";
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
         edtDireccionId_Internalname = sPrefix+"DIRECCIONID";
         edtDireccionDescripcion_Internalname = sPrefix+"DIRECCIONDESCRIPCION";
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
         chkavAtt_direcciondescripcion_visible.Caption = "Direccion Descripcion";
         chkavAtt_usuariosistemadepartamento_visible.Caption = "Departamento";
         chkavAtt_usuariosistemagerencia_visible.Caption = "Gerencia";
         chkavAtt_usuariosistemanombre_visible.Caption = "Nombre";
         chkavAtt_usuariosistemaidentidad_visible.Caption = "Identidad";
         chkavAtt_usuariosistemaid_visible.Caption = "Usuario Sistema:";
         edtDireccionDescripcion_Jsonclick = "";
         edtDireccionId_Jsonclick = "";
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
         chkavAtt_direcciondescripcion_visible.Enabled = 1;
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
         edtDireccionDescripcion_Link = "";
         edtUsuarioSistemaIdentidad_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtDireccionDescripcion_Visible = -1;
         edtUsuarioSistemaDepartamento_Visible = -1;
         edtUsuarioSistemaGerencia_Visible = -1;
         edtUsuarioSistemaNombre_Visible = -1;
         edtUsuarioSistemaIdentidad_Visible = -1;
         edtUsuarioSistemaId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavDirecciondescripcion_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E13632',iparms:[{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E28631',iparms:[{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E24632',iparms:[{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV33FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E25632',iparms:[{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A258DireccionId',fld:'DIRECCIONID',pic:'ZZZ9'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtDireccionDescripcion_Link',ctrl:'DIRECCIONDESCRIPCION',prop:'Link'},{av:'edtUsuarioSistemaIdentidad_Link',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E11632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV34DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E12632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E26631',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E14632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV23RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV22GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV23RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E15632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E16632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E17632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E18632',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV10CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV43Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV44Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV12GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV42UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV28ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'edtDireccionDescripcion_Visible',ctrl:'DIRECCIONDESCRIPCION',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E19632',iparms:[{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV29UsuarioSistemaIdentidad',fld:'vUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV30DireccionDescripcion',fld:'vDIRECCIONDESCRIPCION',pic:''},{av:'AV35K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV52Uri',fld:'vURI',pic:'',hsh:true},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E27631',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E20632',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E21632',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAID","{handler:'Valid_Usuariosistemaid',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAID",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD","{handler:'Valid_Usuariosistemaidentidad',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMANOMBRE","{handler:'Valid_Usuariosistemanombre',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMANOMBRE",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMAGERENCIA","{handler:'Valid_Usuariosistemagerencia',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMAGERENCIA",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOSISTEMADEPARTAMENTO","{handler:'Valid_Usuariosistemadepartamento',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOSISTEMADEPARTAMENTO",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_DIRECCIONID","{handler:'Valid_Direccionid',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_DIRECCIONID",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_DIRECCIONDESCRIPCION","{handler:'Valid_Direcciondescripcion',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_DIRECCIONDESCRIPCION",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV16Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV17Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV18Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV20Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV21Att_DireccionDescripcion_Visible',fld:'vATT_DIRECCIONDESCRIPCION_VISIBLE',pic:''},{av:'AV13FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         wcpOAV6CentrodecostoId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV35K2BToolsGenericSearchField = "";
         AV29UsuarioSistemaIdentidad = "";
         AV30DireccionDescripcion = "";
         AV28ClassCollection = new GxSimpleCollection<string>();
         AV55Pgmname = "";
         AV12GridConfiguration = new SdtK2BGridConfiguration(context);
         AV49AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV52Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV33FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV34DeletedTag = "";
         AV37GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         A262DireccionDescripcion = "";
         AV43Update = "";
         AV44Delete = "";
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
         AV57Update_GXI = "";
         AV58Delete_GXI = "";
         scmdbuf = "";
         lV29UsuarioSistemaIdentidad = "";
         A259CentrodecostoId = "";
         H00632_A260DepartamentoId = new short[1] ;
         H00632_A259CentrodecostoId = new string[] {""} ;
         H00632_A258DireccionId = new short[1] ;
         H00632_A257UsuarioSistemaDepartamento = new string[] {""} ;
         H00632_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         H00632_A263UsuarioSistemaGerencia = new string[] {""} ;
         H00632_n263UsuarioSistemaGerencia = new bool[] {false} ;
         H00632_A100UsuarioSistemaNombre = new string[] {""} ;
         H00632_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00632_A99UsuarioSistemaId = new string[] {""} ;
         H00633_A262DireccionDescripcion = new string[] {""} ;
         H00634_A260DepartamentoId = new short[1] ;
         H00634_A259CentrodecostoId = new string[] {""} ;
         H00634_A258DireccionId = new short[1] ;
         H00634_A257UsuarioSistemaDepartamento = new string[] {""} ;
         H00634_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         H00634_A263UsuarioSistemaGerencia = new string[] {""} ;
         H00634_n263UsuarioSistemaGerencia = new bool[] {false} ;
         H00634_A100UsuarioSistemaNombre = new string[] {""} ;
         H00634_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00634_A99UsuarioSistemaId = new string[] {""} ;
         H00635_A262DireccionDescripcion = new string[] {""} ;
         AV5Context = new SdtK2BContext(context);
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV40Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV41Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV47ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV48ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV25GridStateKey = "";
         AV26GridState = new SdtK2BGridState(context);
         AV27GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45TrnContext = new SdtK2BTrnContext(context);
         AV46TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV31K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV32K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV50OutFile = "";
         AV51Guid = (Guid)(Guid.Empty);
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
         sCtrlAV6CentrodecostoId = "";
         sCtrlAV7DepartamentoId = "";
         ROClassString = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.deptousuariosistemawc__datastore2(),
            new Object[][] {
                new Object[] {
               H00633_A262DireccionDescripcion
               }
               , new Object[] {
               H00635_A262DireccionDescripcion
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.deptousuariosistemawc__default(),
            new Object[][] {
                new Object[] {
               H00632_A260DepartamentoId, H00632_A259CentrodecostoId, H00632_A258DireccionId, H00632_A257UsuarioSistemaDepartamento, H00632_n257UsuarioSistemaDepartamento, H00632_A263UsuarioSistemaGerencia, H00632_n263UsuarioSistemaGerencia, H00632_A100UsuarioSistemaNombre, H00632_A101UsuarioSistemaIdentidad, H00632_A99UsuarioSistemaId
               }
               , new Object[] {
               H00634_A260DepartamentoId, H00634_A259CentrodecostoId, H00634_A258DireccionId, H00634_A257UsuarioSistemaDepartamento, H00634_n257UsuarioSistemaDepartamento, H00634_A263UsuarioSistemaGerencia, H00634_n263UsuarioSistemaGerencia, H00634_A100UsuarioSistemaNombre, H00634_A101UsuarioSistemaIdentidad, H00634_A99UsuarioSistemaId
               }
            }
         );
         AV55Pgmname = "DeptoUsuarioSistemaWC";
         /* GeneXus formulas. */
         AV55Pgmname = "DeptoUsuarioSistemaWC";
         context.Gx_err = 0;
      }

      private short AV7DepartamentoId ;
      private short wcpOAV7DepartamentoId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV36OrderedBy ;
      private short initialized ;
      private short AV39UC_OrderedBy ;
      private short AV23RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A258DireccionId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV22GridSettingsRowsPerPageVariable ;
      private short A260DepartamentoId ;
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
      private int AV10CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavUsuariosistemaidentidad_Enabled ;
      private int edtavDirecciondescripcion_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtUsuarioSistemaId_Visible ;
      private int edtUsuarioSistemaIdentidad_Visible ;
      private int edtUsuarioSistemaNombre_Visible ;
      private int edtUsuarioSistemaGerencia_Visible ;
      private int edtUsuarioSistemaDepartamento_Visible ;
      private int edtDireccionDescripcion_Visible ;
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
      private int AV56GXV1 ;
      private int AV59GXV2 ;
      private int AV11K2BMaxPages ;
      private int AV60GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV61GXV4 ;
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
      private string AV35K2BToolsGenericSearchField ;
      private string AV55Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV34DeletedTag ;
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
      private string divK2btoolstable_attributecontainerdirecciondescripcion_Internalname ;
      private string edtavDirecciondescripcion_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtUsuarioSistemaIdentidad_Link ;
      private string edtDireccionDescripcion_Link ;
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
      private string edtDireccionId_Internalname ;
      private string edtDireccionDescripcion_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string chkavAtt_usuariosistemaid_visible_Internalname ;
      private string chkavAtt_usuariosistemaidentidad_visible_Internalname ;
      private string chkavAtt_usuariosistemanombre_visible_Internalname ;
      private string chkavAtt_usuariosistemagerencia_visible_Internalname ;
      private string chkavAtt_usuariosistemadepartamento_visible_Internalname ;
      private string chkavAtt_direcciondescripcion_visible_Internalname ;
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
      private string divDirecciondescripcion_gridsettingscontainer_Internalname ;
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
      private string sCtrlAV6CentrodecostoId ;
      private string sCtrlAV7DepartamentoId ;
      private string sGXsfl_153_fel_idx="0001" ;
      private string ROClassString ;
      private string edtUsuarioSistemaId_Jsonclick ;
      private string edtUsuarioSistemaIdentidad_Jsonclick ;
      private string edtUsuarioSistemaNombre_Jsonclick ;
      private string edtUsuarioSistemaGerencia_Jsonclick ;
      private string edtUsuarioSistemaDepartamento_Jsonclick ;
      private string edtDireccionId_Jsonclick ;
      private string edtDireccionDescripcion_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV42UsuarioSistemaIdentidad_IsAuthorized ;
      private bool AV16Att_UsuarioSistemaId_Visible ;
      private bool AV17Att_UsuarioSistemaIdentidad_Visible ;
      private bool AV18Att_UsuarioSistemaNombre_Visible ;
      private bool AV19Att_UsuarioSistemaGerencia_Visible ;
      private bool AV20Att_UsuarioSistemaDepartamento_Visible ;
      private bool AV21Att_DireccionDescripcion_Visible ;
      private bool AV13FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n263UsuarioSistemaGerencia ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool bGXsfl_153_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV24RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV43Update_IsBlob ;
      private bool AV44Delete_IsBlob ;
      private string AV6CentrodecostoId ;
      private string wcpOAV6CentrodecostoId ;
      private string AV29UsuarioSistemaIdentidad ;
      private string AV30DireccionDescripcion ;
      private string AV52Uri ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A262DireccionDescripcion ;
      private string AV57Update_GXI ;
      private string AV58Delete_GXI ;
      private string lV29UsuarioSistemaIdentidad ;
      private string A259CentrodecostoId ;
      private string AV25GridStateKey ;
      private string AV50OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV43Update ;
      private string AV44Delete ;
      private Guid AV51Guid ;
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
      private GXCheckbox chkavAtt_direcciondescripcion_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private short[] H00632_A260DepartamentoId ;
      private string[] H00632_A259CentrodecostoId ;
      private short[] H00632_A258DireccionId ;
      private string[] H00632_A257UsuarioSistemaDepartamento ;
      private bool[] H00632_n257UsuarioSistemaDepartamento ;
      private string[] H00632_A263UsuarioSistemaGerencia ;
      private bool[] H00632_n263UsuarioSistemaGerencia ;
      private string[] H00632_A100UsuarioSistemaNombre ;
      private string[] H00632_A101UsuarioSistemaIdentidad ;
      private string[] H00632_A99UsuarioSistemaId ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] H00633_A262DireccionDescripcion ;
      private short[] H00634_A260DepartamentoId ;
      private string[] H00634_A259CentrodecostoId ;
      private short[] H00634_A258DireccionId ;
      private string[] H00634_A257UsuarioSistemaDepartamento ;
      private bool[] H00634_n257UsuarioSistemaDepartamento ;
      private string[] H00634_A263UsuarioSistemaGerencia ;
      private bool[] H00634_n263UsuarioSistemaGerencia ;
      private string[] H00634_A100UsuarioSistemaNombre ;
      private string[] H00634_A101UsuarioSistemaIdentidad ;
      private string[] H00634_A99UsuarioSistemaId ;
      private string[] H00635_A262DireccionDescripcion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV9HTTPRequest ;
      private GxSimpleCollection<string> AV28ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV14GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV31K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV33FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV37GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV40Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV49AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV47ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV12GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV15GridColumn ;
      private SdtK2BGridState AV26GridState ;
      private SdtK2BGridState_FilterValue AV27GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV32K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV38GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV41Message ;
      private SdtK2BTrnContext AV45TrnContext ;
      private SdtK2BTrnContext_Attribute AV46TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV48ActivityListItem ;
   }

   public class deptousuariosistemawc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00633;
          prmH00633 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          Object[] prmH00635;
          prmH00635 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00633", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00633,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00635", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00635,1, GxCacheFrequency.OFF ,true,false )
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

 public class deptousuariosistemawc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00632( IGxContext context ,
                                           string AV29UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV36OrderedBy ,
                                           string AV35K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A262DireccionDescripcion ,
                                           string AV30DireccionDescripcion ,
                                           string AV6CentrodecostoId ,
                                           short AV7DepartamentoId ,
                                           string A259CentrodecostoId ,
                                           short A260DepartamentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int4 = new short[3];
       Object[] GXv_Object5 = new Object[2];
       scmdbuf = "SELECT [DepartamentoId], [CentrodecostoId], [DireccionId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([CentrodecostoId] = @AV6CentrodecostoId and [DepartamentoId] = @AV7DepartamentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV29UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int4[2] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV36OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV36OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV36OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV36OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad] DESC";
       }
       GXv_Object5[0] = scmdbuf;
       GXv_Object5[1] = GXv_int4;
       return GXv_Object5 ;
    }

    protected Object[] conditional_H00634( IGxContext context ,
                                           string AV29UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV36OrderedBy ,
                                           string AV35K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A262DireccionDescripcion ,
                                           string AV30DireccionDescripcion ,
                                           string AV6CentrodecostoId ,
                                           short AV7DepartamentoId ,
                                           string A259CentrodecostoId ,
                                           short A260DepartamentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int6 = new short[3];
       Object[] GXv_Object7 = new Object[2];
       scmdbuf = "SELECT [DepartamentoId], [CentrodecostoId], [DireccionId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([CentrodecostoId] = @AV6CentrodecostoId and [DepartamentoId] = @AV7DepartamentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV29UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int6[2] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV36OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV36OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV36OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV36OrderedBy == 3 )
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
                   return conditional_H00632(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
             case 1 :
                   return conditional_H00634(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
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
        Object[] prmH00632;
        prmH00632 = new Object[] {
        new ParDef("@AV6CentrodecostoId",GXType.NVarChar,5,0) ,
        new ParDef("@AV7DepartamentoId",GXType.Int16,4,0) ,
        new ParDef("@lV29UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        Object[] prmH00634;
        prmH00634 = new Object[] {
        new ParDef("@AV6CentrodecostoId",GXType.NVarChar,5,0) ,
        new ParDef("@AV7DepartamentoId",GXType.Int16,4,0) ,
        new ParDef("@lV29UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        def= new CursorDef[] {
            new CursorDef("H00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00632,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00634", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00634,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
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
