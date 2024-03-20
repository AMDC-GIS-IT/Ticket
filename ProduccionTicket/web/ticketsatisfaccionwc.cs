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
   public class ticketsatisfaccionwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public ticketsatisfaccionwc( )
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

      public ticketsatisfaccionwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TicketId )
      {
         this.AV6TicketId = aP0_TicketId;
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
         chkavAtt_satisfaccionid_visible = new GXCheckbox();
         chkavAtt_satisfaccionfecha_visible = new GXCheckbox();
         chkavAtt_usuariofecha_visible = new GXCheckbox();
         chkavAtt_satisfaccionresueltonombre_visible = new GXCheckbox();
         chkavAtt_satisfacciontecnicoproblemanombre_visible = new GXCheckbox();
         chkavAtt_satisfacciontecnicocompetentenombre_visible = new GXCheckbox();
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible = new GXCheckbox();
         chkavAtt_satisfacciontiemponombre_visible = new GXCheckbox();
         chkavAtt_satisfaccionatencionnombre_visible = new GXCheckbox();
         chkavAtt_satisfaccionsugerencia_visible = new GXCheckbox();
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
               gxfirstwebparm = GetFirstPar( "TicketId");
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
                  AV6TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
                  AssignAttri(sPrefix, false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV6TicketId});
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
                  gxfirstwebparm = GetFirstPar( "TicketId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TicketId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_211 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_211"), "."));
                  nGXsfl_211_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_211_idx"), "."));
                  sGXsfl_211_idx = GetPar( "sGXsfl_211_idx");
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
                  AV48K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV33SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
                  AV36UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV38SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
                  AV39SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
                  AV40SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
                  AV41SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
                  AV42SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
                  AV43SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
                  AV6TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV31ClassCollection);
                  AV49OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV34SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
                  AV37UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV68Pgmname = GetPar( "Pgmname");
                  AV9CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridConfiguration);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV58AutoLinksActivityList);
                  AV60SatisfaccionFecha_IsAuthorized = StringUtil.StrToBool( GetPar( "SatisfaccionFecha_IsAuthorized"));
                  AV15Att_SatisfaccionId_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionId_Visible"));
                  AV16Att_SatisfaccionFecha_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionFecha_Visible"));
                  AV17Att_UsuarioFecha_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioFecha_Visible"));
                  AV18Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionResueltoNombre_Visible"));
                  AV19Att_SatisfaccionTecnicoProblemaNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTecnicoProblemaNombre_Visible"));
                  AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTecnicoCompetenteNombre_Visible"));
                  AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTecnicoProfesionalismoNombre_Visible"));
                  AV22Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTiempoNombre_Visible"));
                  AV23Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionAtencionNombre_Visible"));
                  AV24Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionSugerencia_Visible"));
                  AV12FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV65Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
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
            return "satisfaccion_Execute" ;
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
            PA2T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV68Pgmname = "TicketSatisfaccionWC";
               context.Gx_err = 0;
               WS2T2( ) ;
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
            context.SendWebValue( "Satisfacciones") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188341551", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ticketsatisfaccionwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6TicketId,10,0))}, new string[] {"TicketId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV48K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONFECHA_FROM", context.localUtil.Format(AV33SatisfaccionFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV36UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE", AV38SatisfaccionResueltoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE", AV39SatisfaccionTecnicoProblemaNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE", AV40SatisfaccionTecnicoCompetenteNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE", AV41SatisfaccionTecnicoProfesionalismoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE", AV42SatisfaccionTiempoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE", AV43SatisfaccionAtencionNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_211", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_211), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGS", AV46FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGS", AV46FilterTags);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG", StringUtil.RTrim( AV47DeletedTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_TO", context.localUtil.DToC( AV34SatisfaccionFecha_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOFECHA_TO", context.localUtil.DToC( AV37UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV50GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV50GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV68Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV31ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV31ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAUTOLINKSACTIVITYLIST", AV58AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAUTOLINKSACTIVITYLIST", AV58AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_ISAUTHORIZED", AV60SatisfaccionFecha_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV65Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65Uri, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_FROM", context.localUtil.DToC( AV33SatisfaccionFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOFECHA_FROM", context.localUtil.DToC( AV36UsuarioFecha_From, 0, "/"));
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

      protected void RenderHtmlCloseForm2T2( )
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
         return "TicketSatisfaccionWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Satisfacciones" ;
      }

      protected void WB2T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "ticketsatisfaccionwc.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
               context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV48K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV48K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketSatisfaccionWC.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV46FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV47DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionfecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksatisfaccionfecha_Internalname, "Fecha Encuesta:", "", "", lblTextblocksatisfaccionfecha_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* User Defined Control */
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueFrom", AV33SatisfaccionFecha_From);
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueTo", AV34SatisfaccionFecha_To);
            ucSatisfaccionfecha_daterangepicker.Render(context, "k2bdaterangepicker", Satisfaccionfecha_daterangepicker_Internalname, sPrefix+"SATISFACCIONFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariofecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha", "", "", lblTextblockusuariofecha_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV36UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV37UsuarioFecha_To);
            ucUsuariofecha_daterangepicker.Render(context, "k2bdaterangepicker", Usuariofecha_daterangepicker_Internalname, sPrefix+"USUARIOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionresueltonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionresueltonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionresueltonombre_Internalname, AV38SatisfaccionResueltoNombre, StringUtil.RTrim( context.localUtil.Format( AV38SatisfaccionResueltoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionresueltonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionresueltonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoproblemanombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoproblemanombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoproblemanombre_Internalname, AV39SatisfaccionTecnicoProblemaNombre, StringUtil.RTrim( context.localUtil.Format( AV39SatisfaccionTecnicoProblemaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoproblemanombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoproblemanombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicocompetentenombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicocompetentenombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicocompetentenombre_Internalname, AV40SatisfaccionTecnicoCompetenteNombre, StringUtil.RTrim( context.localUtil.Format( AV40SatisfaccionTecnicoCompetenteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicocompetentenombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicocompetentenombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoprofesionalismonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, AV41SatisfaccionTecnicoProfesionalismoNombre, StringUtil.RTrim( context.localUtil.Format( AV41SatisfaccionTecnicoProfesionalismoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoprofesionalismonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontiemponombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontiemponombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontiemponombre_Internalname, AV42SatisfaccionTiempoNombre, StringUtil.RTrim( context.localUtil.Format( AV42SatisfaccionTiempoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontiemponombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontiemponombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionatencionnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionatencionnombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionatencionnombre_Internalname, AV43SatisfaccionAtencionNombre, StringUtil.RTrim( context.localUtil.Format( AV43SatisfaccionAtencionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionatencionnombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionatencionnombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TicketSatisfaccionWC.htm");
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
            wb_table1_83_2T2( true) ;
         }
         else
         {
            wb_table1_83_2T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_83_2T2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"211\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(80), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Encuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionResueltoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionTecnicoProblemaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionTecnicoCompetenteNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionTecnicoProfesionalismoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionTiempoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionAtencionNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtSatisfaccionSugerencia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Sugerencia:") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionFecha_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionFecha_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFecha_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A33SatisfaccionResueltoNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionResueltoNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionResueltoNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A36SatisfaccionTecnicoProblemaNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionTecnicoProblemaNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionTecnicoProblemaNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A35SatisfaccionTecnicoCompetenteNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionTecnicoCompetenteNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A37SatisfaccionTecnicoProfesionalismoNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionTecnicoProfesionalismoNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A38SatisfaccionTiempoNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionTiempoNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionTiempoNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A31SatisfaccionAtencionNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionAtencionNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionAtencionNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A34SatisfaccionSugerencia);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSatisfaccionSugerencia_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV61Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV62Delete));
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
         if ( wbEnd == 211 )
         {
            wbEnd = 0;
            nRC_GXsfl_211 = (int)(nGXsfl_211_idx-1);
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
            wb_table2_232_2T2( true) ;
         }
         else
         {
            wb_table2_232_2T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_232_2T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV50GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV52UC_OrderedBy);
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
         if ( wbEnd == 211 )
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

      protected void START2T2( )
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
               Form.Meta.addItem("description", "Satisfacciones", 0) ;
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
               STRUP2T0( ) ;
            }
         }
      }

      protected void WS2T2( )
      {
         START2T2( ) ;
         EVT2T2( ) ;
      }

      protected void EVT2T2( )
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
                                 STRUP2T0( ) ;
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
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E132T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E142T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E152T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E162T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E172T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E182T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E192T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E202T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E212T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2T0( ) ;
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
                                 STRUP2T0( ) ;
                              }
                              nGXsfl_211_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_211_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_211_idx), 4, 0), 4, "0");
                              SubsflControlProps_2112( ) ;
                              A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
                              A32SatisfaccionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSatisfaccionFecha_Internalname), 0));
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ","));
                              A33SatisfaccionResueltoNombre = cgiGet( edtSatisfaccionResueltoNombre_Internalname);
                              A9SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProblemaId_Internalname), ".", ","));
                              A36SatisfaccionTecnicoProblemaNombre = cgiGet( edtSatisfaccionTecnicoProblemaNombre_Internalname);
                              A10SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoCompetenteId_Internalname), ".", ","));
                              A35SatisfaccionTecnicoCompetenteNombre = cgiGet( edtSatisfaccionTecnicoCompetenteNombre_Internalname);
                              A11SatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProfesionalismoId_Internalname), ".", ","));
                              A37SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtSatisfaccionTecnicoProfesionalismoNombre_Internalname);
                              A12SatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTiempoId_Internalname), ".", ","));
                              A38SatisfaccionTiempoNombre = cgiGet( edtSatisfaccionTiempoNombre_Internalname);
                              A13SatisfaccionAtencionId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionAtencionId_Internalname), ".", ","));
                              A31SatisfaccionAtencionNombre = cgiGet( edtSatisfaccionAtencionNombre_Internalname);
                              A34SatisfaccionSugerencia = cgiGet( edtSatisfaccionSugerencia_Internalname);
                              n34SatisfaccionSugerencia = false;
                              AV61Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.convertURL( context.PathToRelativeUrl( AV61Update))), !bGXsfl_211_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV61Update), true);
                              AV62Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV62Delete))), !bGXsfl_211_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV62Delete), true);
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
                                          E222T2 ();
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
                                          E232T2 ();
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
                                          E242T2 ();
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
                                          E252T2 ();
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
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV48K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionfecha_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSATISFACCIONFECHA_FROM"), 0) != AV33SatisfaccionFecha_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Usuariofecha_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vUSUARIOFECHA_FROM"), 0) != AV36UsuarioFecha_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionresueltonombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE"), AV38SatisfaccionResueltoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontecnicoproblemanombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV39SatisfaccionTecnicoProblemaNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontecnicocompetentenombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV40SatisfaccionTecnicoCompetenteNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontecnicoprofesionalismonombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV41SatisfaccionTecnicoProfesionalismoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontiemponombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE"), AV42SatisfaccionTiempoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionatencionnombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE"), AV43SatisfaccionAtencionNombre) != 0 )
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
                                       STRUP2T0( ) ;
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

      protected void WE2T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2T2( ) ;
            }
         }
      }

      protected void PA2T2( )
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
         SubsflControlProps_2112( ) ;
         while ( nGXsfl_211_idx <= nRC_GXsfl_211 )
         {
            sendrow_2112( ) ;
            nGXsfl_211_idx = ((subGrid_Islastpage==1)&&(nGXsfl_211_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_211_idx+1);
            sGXsfl_211_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_211_idx), 4, 0), 4, "0");
            SubsflControlProps_2112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV48K2BToolsGenericSearchField ,
                                       DateTime AV33SatisfaccionFecha_From ,
                                       DateTime AV36UsuarioFecha_From ,
                                       string AV38SatisfaccionResueltoNombre ,
                                       string AV39SatisfaccionTecnicoProblemaNombre ,
                                       string AV40SatisfaccionTecnicoCompetenteNombre ,
                                       string AV41SatisfaccionTecnicoProfesionalismoNombre ,
                                       string AV42SatisfaccionTiempoNombre ,
                                       string AV43SatisfaccionAtencionNombre ,
                                       long AV6TicketId ,
                                       GxSimpleCollection<string> AV31ClassCollection ,
                                       short AV49OrderedBy ,
                                       DateTime AV34SatisfaccionFecha_To ,
                                       DateTime AV37UsuarioFecha_To ,
                                       string AV68Pgmname ,
                                       int AV9CurrentPage ,
                                       SdtK2BGridConfiguration AV11GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV58AutoLinksActivityList ,
                                       bool AV60SatisfaccionFecha_IsAuthorized ,
                                       bool AV15Att_SatisfaccionId_Visible ,
                                       bool AV16Att_SatisfaccionFecha_Visible ,
                                       bool AV17Att_UsuarioFecha_Visible ,
                                       bool AV18Att_SatisfaccionResueltoNombre_Visible ,
                                       bool AV19Att_SatisfaccionTecnicoProblemaNombre_Visible ,
                                       bool AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible ,
                                       bool AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible ,
                                       bool AV22Att_SatisfaccionTiempoNombre_Visible ,
                                       bool AV23Att_SatisfaccionAtencionNombre_Visible ,
                                       bool AV24Att_SatisfaccionSugerencia_Visible ,
                                       bool AV12FreezeColumnTitles ,
                                       string AV65Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232T2 ();
         GRID_nCurrentRecord = 0;
         RF2T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SATISFACCIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
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
         AV15Att_SatisfaccionId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_SatisfaccionId_Visible));
         AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
         AV16Att_SatisfaccionFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_SatisfaccionFecha_Visible));
         AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
         AV17Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioFecha_Visible));
         AssignAttri(sPrefix, false, "AV17Att_UsuarioFecha_Visible", AV17Att_UsuarioFecha_Visible);
         AV18Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_SatisfaccionResueltoNombre_Visible));
         AssignAttri(sPrefix, false, "AV18Att_SatisfaccionResueltoNombre_Visible", AV18Att_SatisfaccionResueltoNombre_Visible);
         AV19Att_SatisfaccionTecnicoProblemaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_SatisfaccionTecnicoProblemaNombre_Visible));
         AssignAttri(sPrefix, false, "AV19Att_SatisfaccionTecnicoProblemaNombre_Visible", AV19Att_SatisfaccionTecnicoProblemaNombre_Visible);
         AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible));
         AssignAttri(sPrefix, false, "AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible);
         AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible));
         AssignAttri(sPrefix, false, "AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
         AV22Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_SatisfaccionTiempoNombre_Visible));
         AssignAttri(sPrefix, false, "AV22Att_SatisfaccionTiempoNombre_Visible", AV22Att_SatisfaccionTiempoNombre_Visible);
         AV23Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_SatisfaccionAtencionNombre_Visible));
         AssignAttri(sPrefix, false, "AV23Att_SatisfaccionAtencionNombre_Visible", AV23Att_SatisfaccionAtencionNombre_Visible);
         AV24Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_SatisfaccionSugerencia_Visible));
         AssignAttri(sPrefix, false, "AV24Att_SatisfaccionSugerencia_Visible", AV24Att_SatisfaccionSugerencia_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV25GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV25GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV12FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV12FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232T2 ();
         RF2T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV68Pgmname = "TicketSatisfaccionWC";
         context.Gx_err = 0;
      }

      protected void RF2T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 211;
         E242T2 ();
         nGXsfl_211_idx = 1;
         sGXsfl_211_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_211_idx), 4, 0), 4, "0");
         SubsflControlProps_2112( ) ;
         bGXsfl_211_Refreshing = true;
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
            SubsflControlProps_2112( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV34SatisfaccionFecha_To ,
                                                 AV33SatisfaccionFecha_From ,
                                                 AV37UsuarioFecha_To ,
                                                 AV36UsuarioFecha_From ,
                                                 AV38SatisfaccionResueltoNombre ,
                                                 AV39SatisfaccionTecnicoProblemaNombre ,
                                                 AV40SatisfaccionTecnicoCompetenteNombre ,
                                                 AV41SatisfaccionTecnicoProfesionalismoNombre ,
                                                 AV42SatisfaccionTiempoNombre ,
                                                 AV43SatisfaccionAtencionNombre ,
                                                 AV48K2BToolsGenericSearchField ,
                                                 A32SatisfaccionFecha ,
                                                 A90UsuarioFecha ,
                                                 A33SatisfaccionResueltoNombre ,
                                                 A36SatisfaccionTecnicoProblemaNombre ,
                                                 A35SatisfaccionTecnicoCompetenteNombre ,
                                                 A37SatisfaccionTecnicoProfesionalismoNombre ,
                                                 A38SatisfaccionTiempoNombre ,
                                                 A31SatisfaccionAtencionNombre ,
                                                 A7SatisfaccionId ,
                                                 A34SatisfaccionSugerencia ,
                                                 AV49OrderedBy ,
                                                 AV6TicketId ,
                                                 A14TicketId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV38SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV38SatisfaccionResueltoNombre), "%", "");
            lV39SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV39SatisfaccionTecnicoProblemaNombre), "%", "");
            lV40SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV40SatisfaccionTecnicoCompetenteNombre), "%", "");
            lV41SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionTecnicoProfesionalismoNombre), "%", "");
            lV42SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTiempoNombre), "%", "");
            lV43SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionAtencionNombre), "%", "");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002T2 */
            pr_default.execute(0, new Object[] {AV6TicketId, AV34SatisfaccionFecha_To, AV33SatisfaccionFecha_From, AV37UsuarioFecha_To, AV36UsuarioFecha_From, lV38SatisfaccionResueltoNombre, lV39SatisfaccionTecnicoProblemaNombre, lV40SatisfaccionTecnicoCompetenteNombre, lV41SatisfaccionTecnicoProfesionalismoNombre, lV42SatisfaccionTiempoNombre, lV43SatisfaccionAtencionNombre, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_211_idx = 1;
            sGXsfl_211_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_211_idx), 4, 0), 4, "0");
            SubsflControlProps_2112( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A15UsuarioId = H002T2_A15UsuarioId[0];
               A14TicketId = H002T2_A14TicketId[0];
               A34SatisfaccionSugerencia = H002T2_A34SatisfaccionSugerencia[0];
               n34SatisfaccionSugerencia = H002T2_n34SatisfaccionSugerencia[0];
               A31SatisfaccionAtencionNombre = H002T2_A31SatisfaccionAtencionNombre[0];
               A13SatisfaccionAtencionId = H002T2_A13SatisfaccionAtencionId[0];
               A38SatisfaccionTiempoNombre = H002T2_A38SatisfaccionTiempoNombre[0];
               A12SatisfaccionTiempoId = H002T2_A12SatisfaccionTiempoId[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H002T2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A11SatisfaccionTecnicoProfesionalismoId = H002T2_A11SatisfaccionTecnicoProfesionalismoId[0];
               A35SatisfaccionTecnicoCompetenteNombre = H002T2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A10SatisfaccionTecnicoCompetenteId = H002T2_A10SatisfaccionTecnicoCompetenteId[0];
               A36SatisfaccionTecnicoProblemaNombre = H002T2_A36SatisfaccionTecnicoProblemaNombre[0];
               A9SatisfaccionTecnicoProblemaId = H002T2_A9SatisfaccionTecnicoProblemaId[0];
               A33SatisfaccionResueltoNombre = H002T2_A33SatisfaccionResueltoNombre[0];
               A8SatisfaccionResueltoId = H002T2_A8SatisfaccionResueltoId[0];
               A90UsuarioFecha = H002T2_A90UsuarioFecha[0];
               A32SatisfaccionFecha = H002T2_A32SatisfaccionFecha[0];
               A7SatisfaccionId = H002T2_A7SatisfaccionId[0];
               A15UsuarioId = H002T2_A15UsuarioId[0];
               A90UsuarioFecha = H002T2_A90UsuarioFecha[0];
               A31SatisfaccionAtencionNombre = H002T2_A31SatisfaccionAtencionNombre[0];
               A38SatisfaccionTiempoNombre = H002T2_A38SatisfaccionTiempoNombre[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H002T2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A35SatisfaccionTecnicoCompetenteNombre = H002T2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A36SatisfaccionTecnicoProblemaNombre = H002T2_A36SatisfaccionTecnicoProblemaNombre[0];
               A33SatisfaccionResueltoNombre = H002T2_A33SatisfaccionResueltoNombre[0];
               E252T2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 211;
            WB2T0( ) ;
         }
         bGXsfl_211_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2T2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV68Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SATISFACCIONID"+"_"+sGXsfl_211_idx, GetSecureSignedToken( sPrefix+sGXsfl_211_idx, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV65Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65Uri, "")), context));
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
                                              AV34SatisfaccionFecha_To ,
                                              AV33SatisfaccionFecha_From ,
                                              AV37UsuarioFecha_To ,
                                              AV36UsuarioFecha_From ,
                                              AV38SatisfaccionResueltoNombre ,
                                              AV39SatisfaccionTecnicoProblemaNombre ,
                                              AV40SatisfaccionTecnicoCompetenteNombre ,
                                              AV41SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV42SatisfaccionTiempoNombre ,
                                              AV43SatisfaccionAtencionNombre ,
                                              AV48K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A7SatisfaccionId ,
                                              A34SatisfaccionSugerencia ,
                                              AV49OrderedBy ,
                                              AV6TicketId ,
                                              A14TicketId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV38SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV38SatisfaccionResueltoNombre), "%", "");
         lV39SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV39SatisfaccionTecnicoProblemaNombre), "%", "");
         lV40SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV40SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV41SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV42SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTiempoNombre), "%", "");
         lV43SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionAtencionNombre), "%", "");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         lV48K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV48K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002T3 */
         pr_default.execute(1, new Object[] {AV6TicketId, AV34SatisfaccionFecha_To, AV33SatisfaccionFecha_From, AV37UsuarioFecha_To, AV36UsuarioFecha_From, lV38SatisfaccionResueltoNombre, lV39SatisfaccionTecnicoProblemaNombre, lV40SatisfaccionTecnicoCompetenteNombre, lV41SatisfaccionTecnicoProfesionalismoNombre, lV42SatisfaccionTiempoNombre, lV43SatisfaccionAtencionNombre, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField, lV48K2BToolsGenericSearchField});
         GRID_nRecordCount = H002T3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV68Pgmname = "TicketSatisfaccionWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGS"), AV46FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV50GridOrders);
            /* Read saved values. */
            nRC_GXsfl_211 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_211"), ".", ","));
            AV47DeletedTag = cgiGet( sPrefix+"vDELETEDTAG");
            AV33SatisfaccionFecha_From = context.localUtil.CToD( cgiGet( sPrefix+"vSATISFACCIONFECHA_FROM"), 0);
            AV34SatisfaccionFecha_To = context.localUtil.CToD( cgiGet( sPrefix+"vSATISFACCIONFECHA_TO"), 0);
            AV36UsuarioFecha_From = context.localUtil.CToD( cgiGet( sPrefix+"vUSUARIOFECHA_FROM"), 0);
            AV37UsuarioFecha_To = context.localUtil.CToD( cgiGet( sPrefix+"vUSUARIOFECHA_TO"), 0);
            AV52UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6TicketId"), ".", ","));
            AV49OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vTICKETID"), ".", ","));
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
            AV48K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV48K2BToolsGenericSearchField", AV48K2BToolsGenericSearchField);
            AV38SatisfaccionResueltoNombre = cgiGet( edtavSatisfaccionresueltonombre_Internalname);
            AssignAttri(sPrefix, false, "AV38SatisfaccionResueltoNombre", AV38SatisfaccionResueltoNombre);
            AV39SatisfaccionTecnicoProblemaNombre = cgiGet( edtavSatisfacciontecnicoproblemanombre_Internalname);
            AssignAttri(sPrefix, false, "AV39SatisfaccionTecnicoProblemaNombre", AV39SatisfaccionTecnicoProblemaNombre);
            AV40SatisfaccionTecnicoCompetenteNombre = cgiGet( edtavSatisfacciontecnicocompetentenombre_Internalname);
            AssignAttri(sPrefix, false, "AV40SatisfaccionTecnicoCompetenteNombre", AV40SatisfaccionTecnicoCompetenteNombre);
            AV41SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtavSatisfacciontecnicoprofesionalismonombre_Internalname);
            AssignAttri(sPrefix, false, "AV41SatisfaccionTecnicoProfesionalismoNombre", AV41SatisfaccionTecnicoProfesionalismoNombre);
            AV42SatisfaccionTiempoNombre = cgiGet( edtavSatisfacciontiemponombre_Internalname);
            AssignAttri(sPrefix, false, "AV42SatisfaccionTiempoNombre", AV42SatisfaccionTiempoNombre);
            AV43SatisfaccionAtencionNombre = cgiGet( edtavSatisfaccionatencionnombre_Internalname);
            AssignAttri(sPrefix, false, "AV43SatisfaccionAtencionNombre", AV43SatisfaccionAtencionNombre);
            AV15Att_SatisfaccionId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
            AV16Att_SatisfaccionFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionfecha_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
            AV17Att_UsuarioFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariofecha_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_UsuarioFecha_Visible", AV17Att_UsuarioFecha_Visible);
            AV18Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionresueltonombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_SatisfaccionResueltoNombre_Visible", AV18Att_SatisfaccionResueltoNombre_Visible);
            AV19Att_SatisfaccionTecnicoProblemaNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_SatisfaccionTecnicoProblemaNombre_Visible", AV19Att_SatisfaccionTecnicoProblemaNombre_Visible);
            AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible);
            AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
            AV22Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontiemponombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV22Att_SatisfaccionTiempoNombre_Visible", AV22Att_SatisfaccionTiempoNombre_Visible);
            AV23Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionatencionnombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV23Att_SatisfaccionAtencionNombre_Visible", AV23Att_SatisfaccionAtencionNombre_Visible);
            AV24Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionsugerencia_visible_Internalname));
            AssignAttri(sPrefix, false, "AV24Att_SatisfaccionSugerencia_Visible", AV24Att_SatisfaccionSugerencia_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV25GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV25GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0));
            AV12FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV48K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vSATISFACCIONFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV33SatisfaccionFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV36UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE"), AV38SatisfaccionResueltoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV39SatisfaccionTecnicoProblemaNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV40SatisfaccionTecnicoCompetenteNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV41SatisfaccionTecnicoProfesionalismoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE"), AV42SatisfaccionTiempoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE"), AV43SatisfaccionAtencionNombre) != 0 )
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
         E222T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222T2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV32SatisfaccionFecha = DateTime.MinValue;
         AV33SatisfaccionFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri(sPrefix, false, "AV33SatisfaccionFecha_From", context.localUtil.Format(AV33SatisfaccionFecha_From, "99/99/9999"));
         AV34SatisfaccionFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV34SatisfaccionFecha_To", context.localUtil.Format(AV34SatisfaccionFecha_To, "99/99/9999"));
         AV35UsuarioFecha = DateTime.MinValue;
         AV36UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri(sPrefix, false, "AV36UsuarioFecha_From", context.localUtil.Format(AV36UsuarioFecha_From, "99/99/9999"));
         AV37UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV37UsuarioFecha_To", context.localUtil.Format(AV37UsuarioFecha_To, "99/99/9999"));
         AV38SatisfaccionResueltoNombre = "";
         AssignAttri(sPrefix, false, "AV38SatisfaccionResueltoNombre", AV38SatisfaccionResueltoNombre);
         AV39SatisfaccionTecnicoProblemaNombre = "";
         AssignAttri(sPrefix, false, "AV39SatisfaccionTecnicoProblemaNombre", AV39SatisfaccionTecnicoProblemaNombre);
         AV40SatisfaccionTecnicoCompetenteNombre = "";
         AssignAttri(sPrefix, false, "AV40SatisfaccionTecnicoCompetenteNombre", AV40SatisfaccionTecnicoCompetenteNombre);
         AV41SatisfaccionTecnicoProfesionalismoNombre = "";
         AssignAttri(sPrefix, false, "AV41SatisfaccionTecnicoProfesionalismoNombre", AV41SatisfaccionTecnicoProfesionalismoNombre);
         AV42SatisfaccionTiempoNombre = "";
         AssignAttri(sPrefix, false, "AV42SatisfaccionTiempoNombre", AV42SatisfaccionTiempoNombre);
         AV43SatisfaccionAtencionNombre = "";
         AssignAttri(sPrefix, false, "AV43SatisfaccionAtencionNombre", AV43SatisfaccionAtencionNombre);
         new k2bloadrowsperpage(context ).execute(  AV68Pgmname,  "Grid", out  AV26RowsPerPageVariable, out  AV27RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV26RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV26RowsPerPageVariable), 4, 0));
         if ( ! AV27RowsPerPageLoaded )
         {
            AV26RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV26RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV26RowsPerPageVariable), 4, 0));
         }
         AV25GridSettingsRowsPerPageVariable = AV26RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV25GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV26RowsPerPageVariable;
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
         AV50GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV51GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV51GridOrder.gxTpr_Ascendingorder = 0;
         AV51GridOrder.gxTpr_Descendingorder = 1;
         AV51GridOrder.gxTpr_Gridcolumnindex = 1;
         AV50GridOrders.Add(AV51GridOrder, 0);
         AV51GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV51GridOrder.gxTpr_Ascendingorder = 2;
         AV51GridOrder.gxTpr_Descendingorder = 3;
         AV51GridOrder.gxTpr_Gridcolumnindex = 2;
         AV50GridOrders.Add(AV51GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV53Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV53Messages = GXt_objcol_SdtMessages_Message1;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV53Messages.Count )
         {
            AV54Message = ((GeneXus.Utils.SdtMessages_Message)AV53Messages.Item(AV69GXV1));
            GX_msglist.addItem(AV54Message.gxTpr_Description);
            AV69GXV1 = (int)(AV69GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV57ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV68Pgmname;
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV57ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV61Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.convertURL( context.PathToRelativeUrl( AV61Update))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV61Update), true);
         AV70Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.convertURL( context.PathToRelativeUrl( AV61Update))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV61Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_211_Refreshing);
         AV62Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV62Delete))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV62Delete), true);
         AV71Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV62Delete))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV62Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_211_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV31ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV28GridStateKey = StringUtil.Str( (decimal)(AV6TicketId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV68Pgmname,  AV28GridStateKey, out  AV29GridState) ;
         AV49OrderedBy = AV29GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV49OrderedBy", StringUtil.LTrimStr( (decimal)(AV49OrderedBy), 4, 0));
         AV52UC_OrderedBy = AV29GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV52UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV52UC_OrderedBy), 4, 0));
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV72GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:From") == 0 )
            {
               AV33SatisfaccionFecha_From = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV33SatisfaccionFecha_From", context.localUtil.Format(AV33SatisfaccionFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:To") == 0 )
            {
               AV34SatisfaccionFecha_To = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV34SatisfaccionFecha_To", context.localUtil.Format(AV34SatisfaccionFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV36UsuarioFecha_From = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV36UsuarioFecha_From", context.localUtil.Format(AV36UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV37UsuarioFecha_To = context.localUtil.CToD( AV30GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV37UsuarioFecha_To", context.localUtil.Format(AV37UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionResueltoNombre") == 0 )
            {
               AV38SatisfaccionResueltoNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38SatisfaccionResueltoNombre", AV38SatisfaccionResueltoNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoProblemaNombre") == 0 )
            {
               AV39SatisfaccionTecnicoProblemaNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39SatisfaccionTecnicoProblemaNombre", AV39SatisfaccionTecnicoProblemaNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoCompetenteNombre") == 0 )
            {
               AV40SatisfaccionTecnicoCompetenteNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40SatisfaccionTecnicoCompetenteNombre", AV40SatisfaccionTecnicoCompetenteNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
            {
               AV41SatisfaccionTecnicoProfesionalismoNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41SatisfaccionTecnicoProfesionalismoNombre", AV41SatisfaccionTecnicoProfesionalismoNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTiempoNombre") == 0 )
            {
               AV42SatisfaccionTiempoNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42SatisfaccionTiempoNombre", AV42SatisfaccionTiempoNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "SatisfaccionAtencionNombre") == 0 )
            {
               AV43SatisfaccionAtencionNombre = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43SatisfaccionAtencionNombre", AV43SatisfaccionAtencionNombre);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV48K2BToolsGenericSearchField = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV48K2BToolsGenericSearchField", AV48K2BToolsGenericSearchField);
            }
            AV72GXV2 = (int)(AV72GXV2+1);
         }
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV29GridState.gxTpr_Currentpage > 0 ) && ( AV29GridState.gxTpr_Currentpage <= AV10K2BMaxPages ) )
         {
            AV9CurrentPage = AV29GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_gotopage( AV9CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV28GridStateKey = StringUtil.Str( (decimal)(AV6TicketId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV68Pgmname,  AV28GridStateKey, out  AV29GridState) ;
         AV29GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV29GridState.gxTpr_Orderedby = AV49OrderedBy;
         AV29GridState.gxTpr_Filtervalues.Clear();
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:From";
         AV30GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV33SatisfaccionFecha_From, "99/99/9999");
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:To";
         AV30GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV34SatisfaccionFecha_To, "99/99/9999");
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:From";
         AV30GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV36UsuarioFecha_From, "99/99/9999");
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:To";
         AV30GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV37UsuarioFecha_To, "99/99/9999");
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionResueltoNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV38SatisfaccionResueltoNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoProblemaNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV39SatisfaccionTecnicoProblemaNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoCompetenteNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV40SatisfaccionTecnicoCompetenteNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoProfesionalismoNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV41SatisfaccionTecnicoProfesionalismoNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTiempoNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV42SatisfaccionTiempoNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "SatisfaccionAtencionNombre";
         AV30GridStateFilterValue.gxTpr_Value = AV43SatisfaccionAtencionNombre;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV30GridStateFilterValue.gxTpr_Value = AV48K2BToolsGenericSearchField;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV68Pgmname,  AV28GridStateKey,  AV29GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV55TrnContext = new SdtK2BTrnContext(context);
         AV55TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV55TrnContext.gxTpr_Returnmode = "Stack";
         AV55TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV55TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV55TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV55TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV55TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV55TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV56TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV56TrnContextAtt.gxTpr_Attributename = "TicketId";
         AV56TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6TicketId), 10, 0);
         AV55TrnContext.gxTpr_Attributes.Add(AV56TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "Satisfaccion",  AV55TrnContext) ;
      }

      protected void E132T2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "Insert",  "",  "EntityManagerSatisfaccion") )
         {
            CallWebObject(formatLink("entitymanagersatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","SatisfaccionId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtSatisfaccionId_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV15Att_SatisfaccionId_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
         edtSatisfaccionFecha_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV16Att_SatisfaccionFecha_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
         edtUsuarioFecha_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV17Att_UsuarioFecha_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_UsuarioFecha_Visible", AV17Att_UsuarioFecha_Visible);
         edtSatisfaccionResueltoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV18Att_SatisfaccionResueltoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_SatisfaccionResueltoNombre_Visible", AV18Att_SatisfaccionResueltoNombre_Visible);
         edtSatisfaccionTecnicoProblemaNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV19Att_SatisfaccionTecnicoProblemaNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_SatisfaccionTecnicoProblemaNombre_Visible", AV19Att_SatisfaccionTecnicoProblemaNombre_Visible);
         edtSatisfaccionTecnicoCompetenteNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible);
         edtSatisfaccionTecnicoProfesionalismoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
         edtSatisfaccionTiempoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV22Att_SatisfaccionTiempoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV22Att_SatisfaccionTiempoNombre_Visible", AV22Att_SatisfaccionTiempoNombre_Visible);
         edtSatisfaccionAtencionNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV23Att_SatisfaccionAtencionNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV23Att_SatisfaccionAtencionNombre_Visible", AV23Att_SatisfaccionAtencionNombre_Visible);
         edtSatisfaccionSugerencia_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Visible), 5, 0), !bGXsfl_211_Refreshing);
         AV24Att_SatisfaccionSugerencia_Visible = true;
         AssignAttri(sPrefix, false, "AV24Att_SatisfaccionSugerencia_Visible", AV24Att_SatisfaccionSugerencia_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV68Pgmname,  "Grid",  AV11GridConfiguration,  false) ;
         AV73GXV3 = 1;
         while ( AV73GXV3 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV73GXV3));
            if ( ! AV14GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
               {
                  edtSatisfaccionId_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV15Att_SatisfaccionId_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
               {
                  edtSatisfaccionFecha_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV16Att_SatisfaccionFecha_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  edtUsuarioFecha_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV17Att_UsuarioFecha_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_UsuarioFecha_Visible", AV17Att_UsuarioFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
               {
                  edtSatisfaccionResueltoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV18Att_SatisfaccionResueltoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_SatisfaccionResueltoNombre_Visible", AV18Att_SatisfaccionResueltoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProblemaNombre") == 0 )
               {
                  edtSatisfaccionTecnicoProblemaNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV19Att_SatisfaccionTecnicoProblemaNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_SatisfaccionTecnicoProblemaNombre_Visible", AV19Att_SatisfaccionTecnicoProblemaNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
               {
                  edtSatisfaccionTecnicoCompetenteNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
               {
                  edtSatisfaccionTecnicoProfesionalismoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
               {
                  edtSatisfaccionTiempoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV22Att_SatisfaccionTiempoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV22Att_SatisfaccionTiempoNombre_Visible", AV22Att_SatisfaccionTiempoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionAtencionNombre") == 0 )
               {
                  edtSatisfaccionAtencionNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV23Att_SatisfaccionAtencionNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV23Att_SatisfaccionAtencionNombre_Visible", AV23Att_SatisfaccionAtencionNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
               {
                  edtSatisfaccionSugerencia_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Visible), 5, 0), !bGXsfl_211_Refreshing);
                  AV24Att_SatisfaccionSugerencia_Visible = false;
                  AssignAttri(sPrefix, false, "AV24Att_SatisfaccionSugerencia_Visible", AV24Att_SatisfaccionSugerencia_Visible);
               }
            }
            AV73GXV3 = (int)(AV73GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionId";
         AV14GridColumn.gxTpr_Columntitle = "Id";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionFecha";
         AV14GridColumn.gxTpr_Columntitle = "Fecha Encuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV14GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionResueltoNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProblemaNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoCompetenteNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProfesionalismoNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionTiempoNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionAtencionNombre";
         AV14GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionSugerencia";
         AV14GridColumn.gxTpr_Columntitle = "Sugerencia:";
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
         AV57ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportTicketSatisfaccionWC";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportTicketSatisfaccionWC";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV57ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV57ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV57ActivityList.Add(AV59ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV57ActivityList) ;
         AV60SatisfaccionFecha_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV60SatisfaccionFecha_IsAuthorized", AV60SatisfaccionFecha_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_211_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_211_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV57ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_211_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_211_Refreshing);
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

      protected void E242T2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV31ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV61Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.convertURL( context.PathToRelativeUrl( AV61Update))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV61Update), true);
         AV70Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.convertURL( context.PathToRelativeUrl( AV61Update))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV61Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_211_Refreshing);
         AV62Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV62Delete))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV62Delete), true);
         AV71Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV62Delete))), !bGXsfl_211_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV62Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_211_Refreshing);
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
         AV58AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV59ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV58AutoLinksActivityList.Add(AV59ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV58AutoLinksActivityList) ;
         AV52UC_OrderedBy = AV49OrderedBy;
         AssignAttri(sPrefix, false, "AV52UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV52UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV31ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV58AutoLinksActivityList", AV58AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46FilterTags", AV46FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
      }

      private void E252T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(4)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(5)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV58AutoLinksActivityList.Item(6)).gxTpr_Isauthorized )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( AV60SatisfaccionFecha_IsAuthorized )
         {
            edtSatisfaccionFecha_Link = formatLink("entitymanagersatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","SatisfaccionId","TabCode"}) ;
         }
         else
         {
            edtSatisfaccionFecha_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagersatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","SatisfaccionId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagersatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","SatisfaccionId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 211;
         }
         sendrow_2112( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_211_Refreshing )
         {
            context.DoAjaxLoad(211, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV44K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV33SatisfaccionFecha_From) || ! (DateTime.MinValue==AV34SatisfaccionFecha_To) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionFecha";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Encuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV45K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV33SatisfaccionFecha_From ) ;
            AV45K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV34SatisfaccionFecha_To ) ;
            AV45K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV36UsuarioFecha_From) || ! (DateTime.MinValue==AV37UsuarioFecha_To) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Fecha";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV45K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36UsuarioFecha_From ) ;
            AV45K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37UsuarioFecha_To ) ;
            AV45K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SatisfaccionResueltoNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionResueltoNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV38SatisfaccionResueltoNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV38SatisfaccionResueltoNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39SatisfaccionTecnicoProblemaNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoProblemaNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV39SatisfaccionTecnicoProblemaNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV39SatisfaccionTecnicoProblemaNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40SatisfaccionTecnicoCompetenteNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoCompetenteNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV40SatisfaccionTecnicoCompetenteNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV40SatisfaccionTecnicoCompetenteNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoProfesionalismoNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV41SatisfaccionTecnicoProfesionalismoNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV41SatisfaccionTecnicoProfesionalismoNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTiempoNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTiempoNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV42SatisfaccionTiempoNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV42SatisfaccionTiempoNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionAtencionNombre)) )
         {
            AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionAtencionNombre";
            AV45K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV45K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV45K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem.gxTpr_Value = AV43SatisfaccionAtencionNombre;
            AV45K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV43SatisfaccionAtencionNombre;
            AV44K2BFilterValuesSDT.Add(AV45K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, sPrefix, false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV44K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV46FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV68Pgmname,  "Grid",  AV44K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV46FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112T2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionFecha") == 0 )
         {
            AV33SatisfaccionFecha_From = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV33SatisfaccionFecha_From", context.localUtil.Format(AV33SatisfaccionFecha_From, "99/99/9999"));
            AV34SatisfaccionFecha_To = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV34SatisfaccionFecha_To", context.localUtil.Format(AV34SatisfaccionFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "UsuarioFecha") == 0 )
         {
            AV36UsuarioFecha_From = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV36UsuarioFecha_From", context.localUtil.Format(AV36UsuarioFecha_From, "99/99/9999"));
            AV37UsuarioFecha_To = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV37UsuarioFecha_To", context.localUtil.Format(AV37UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionResueltoNombre") == 0 )
         {
            AV38SatisfaccionResueltoNombre = "";
            AssignAttri(sPrefix, false, "AV38SatisfaccionResueltoNombre", AV38SatisfaccionResueltoNombre);
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionTecnicoProblemaNombre") == 0 )
         {
            AV39SatisfaccionTecnicoProblemaNombre = "";
            AssignAttri(sPrefix, false, "AV39SatisfaccionTecnicoProblemaNombre", AV39SatisfaccionTecnicoProblemaNombre);
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionTecnicoCompetenteNombre") == 0 )
         {
            AV40SatisfaccionTecnicoCompetenteNombre = "";
            AssignAttri(sPrefix, false, "AV40SatisfaccionTecnicoCompetenteNombre", AV40SatisfaccionTecnicoCompetenteNombre);
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
         {
            AV41SatisfaccionTecnicoProfesionalismoNombre = "";
            AssignAttri(sPrefix, false, "AV41SatisfaccionTecnicoProfesionalismoNombre", AV41SatisfaccionTecnicoProfesionalismoNombre);
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionTiempoNombre") == 0 )
         {
            AV42SatisfaccionTiempoNombre = "";
            AssignAttri(sPrefix, false, "AV42SatisfaccionTiempoNombre", AV42SatisfaccionTiempoNombre);
         }
         else if ( StringUtil.StrCmp(AV47DeletedTag, "SatisfaccionAtencionNombre") == 0 )
         {
            AV43SatisfaccionAtencionNombre = "";
            AssignAttri(sPrefix, false, "AV43SatisfaccionAtencionNombre", AV43SatisfaccionAtencionNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void E122T2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV49OrderedBy = AV52UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV49OrderedBy", StringUtil.LTrimStr( (decimal)(AV49OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void E142T2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV68Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         AV74GXV4 = 1;
         while ( AV74GXV4 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV74GXV4));
            if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV15Att_SatisfaccionId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV16Att_SatisfaccionFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV17Att_UsuarioFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV18Att_SatisfaccionResueltoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProblemaNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV19Att_SatisfaccionTecnicoProblemaNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV22Att_SatisfaccionTiempoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionAtencionNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV23Att_SatisfaccionAtencionNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV24Att_SatisfaccionSugerencia_Visible;
            }
            AV74GXV4 = (int)(AV74GXV4+1);
         }
         AV11GridConfiguration.gxTpr_Freezecolumntitles = AV12FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV68Pgmname,  "Grid",  AV11GridConfiguration,  true) ;
         AV52UC_OrderedBy = AV49OrderedBy;
         AssignAttri(sPrefix, false, "AV52UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV52UC_OrderedBy), 4, 0));
         if ( AV26RowsPerPageVariable != AV25GridSettingsRowsPerPageVariable )
         {
            AV26RowsPerPageVariable = AV25GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV26RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV26RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV26RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV68Pgmname,  "Grid",  AV26RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV48K2BToolsGenericSearchField, AV33SatisfaccionFecha_From, AV36UsuarioFecha_From, AV38SatisfaccionResueltoNombre, AV39SatisfaccionTecnicoProblemaNombre, AV40SatisfaccionTecnicoCompetenteNombre, AV41SatisfaccionTecnicoProfesionalismoNombre, AV42SatisfaccionTiempoNombre, AV43SatisfaccionAtencionNombre, AV6TicketId, AV31ClassCollection, AV49OrderedBy, AV34SatisfaccionFecha_To, AV37UsuarioFecha_To, AV68Pgmname, AV9CurrentPage, AV11GridConfiguration, AV58AutoLinksActivityList, AV60SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_UsuarioFecha_Visible, AV18Att_SatisfaccionResueltoNombre_Visible, AV19Att_SatisfaccionTecnicoProblemaNombre_Visible, AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV22Att_SatisfaccionTiempoNombre_Visible, AV23Att_SatisfaccionAtencionNombre_Visible, AV24Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV65Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
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

      protected void E152T2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void E162T2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void E172T2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
      }

      protected void E182T2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ClassCollection", AV31ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV68Pgmname,  "Grid", ref  AV11GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV31ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV31ClassCollection) ;
         }
      }

      protected void E192T2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "ExportTicketSatisfaccionWC") )
         {
            new exportticketsatisfaccionwc(context ).execute(  AV6TicketId,  AV33SatisfaccionFecha_From,  AV34SatisfaccionFecha_To,  AV36UsuarioFecha_From,  AV37UsuarioFecha_To,  AV38SatisfaccionResueltoNombre,  AV39SatisfaccionTecnicoProblemaNombre,  AV40SatisfaccionTecnicoCompetenteNombre,  AV41SatisfaccionTecnicoProfesionalismoNombre,  AV42SatisfaccionTiempoNombre,  AV43SatisfaccionAtencionNombre,  AV48K2BToolsGenericSearchField,  AV49OrderedBy, out  AV63OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV63OutFile, out  AV65Uri) )
            {
               CallWebObject(formatLink(AV65Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV64Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV64Guid.ToString(),  AV63OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV64Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202T2( )
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

      protected void E212T2( )
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

      protected void wb_table2_232_2T2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_232_2T2e( true) ;
         }
         else
         {
            wb_table2_232_2T2e( false) ;
         }
      }

      protected void wb_table1_83_2T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e262t1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_TicketSatisfaccionWC.htm");
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
            GxWebStd.gx_div_start( context, divSatisfaccionid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfaccionid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfaccionid_visible_Internalname, "Id", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionid_visible_Internalname, StringUtil.BoolToStr( AV15Att_SatisfaccionId_Visible), "", "Id", 1, chkavAtt_satisfaccionid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
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
            GxWebStd.gx_div_start( context, divSatisfaccionfecha_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfaccionfecha_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfaccionfecha_visible_Internalname, "Fecha Encuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionfecha_visible_Internalname, StringUtil.BoolToStr( AV16Att_SatisfaccionFecha_Visible), "", "Fecha Encuesta:", 1, chkavAtt_satisfaccionfecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
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
            GxWebStd.gx_div_start( context, divUsuariofecha_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariofecha_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariofecha_visible_Internalname, "Fecha Inicio:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariofecha_visible_Internalname, StringUtil.BoolToStr( AV17Att_UsuarioFecha_Visible), "", "Fecha Inicio:", 1, chkavAtt_usuariofecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(124, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,124);\"");
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
            GxWebStd.gx_div_start( context, divSatisfaccionresueltonombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfaccionresueltonombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfaccionresueltonombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionresueltonombre_visible_Internalname, StringUtil.BoolToStr( AV18Att_SatisfaccionResueltoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfaccionresueltonombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicoproblemanombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname, StringUtil.BoolToStr( AV19Att_SatisfaccionTecnicoProblemaNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontecnicoproblemanombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(136, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,136);\"");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicocompetentenombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname, StringUtil.BoolToStr( AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontecnicocompetentenombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicoprofesionalismonombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname, StringUtil.BoolToStr( AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(148, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,148);\"");
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
            GxWebStd.gx_div_start( context, divSatisfacciontiemponombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfacciontiemponombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfacciontiemponombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontiemponombre_visible_Internalname, StringUtil.BoolToStr( AV22Att_SatisfaccionTiempoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontiemponombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(154, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,154);\"");
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
            GxWebStd.gx_div_start( context, divSatisfaccionatencionnombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfaccionatencionnombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfaccionatencionnombre_visible_Internalname, "Respuesta:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionatencionnombre_visible_Internalname, StringUtil.BoolToStr( AV23Att_SatisfaccionAtencionNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfaccionatencionnombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
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
            GxWebStd.gx_div_start( context, divSatisfaccionsugerencia_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_satisfaccionsugerencia_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_satisfaccionsugerencia_visible_Internalname, "Sugerencia:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionsugerencia_visible_Internalname, StringUtil.BoolToStr( AV24Att_SatisfaccionSugerencia_Visible), "", "Sugerencia:", 1, chkavAtt_satisfaccionsugerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(166, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,166);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "", true, 1, "HLP_TicketSatisfaccionWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'" + sPrefix + "',false,'" + sGXsfl_211_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV12FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(178, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,178);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(211), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TicketSatisfaccionWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e272t1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketSatisfaccionWC.htm");
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
            wb_table3_192_2T2( true) ;
         }
         else
         {
            wb_table3_192_2T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_192_2T2e( bool wbgen )
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
            wb_table4_199_2T2( true) ;
         }
         else
         {
            wb_table4_199_2T2( false) ;
         }
         return  ;
      }

      protected void wb_table4_199_2T2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_83_2T2e( true) ;
         }
         else
         {
            wb_table1_83_2T2e( false) ;
         }
      }

      protected void wb_table4_199_2T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(211), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TicketSatisfaccionWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_199_2T2e( true) ;
         }
         else
         {
            wb_table4_199_2T2e( false) ;
         }
      }

      protected void wb_table3_192_2T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(211), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e282t1_client"+"'", TempTags, "", 2, "HLP_TicketSatisfaccionWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(211), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TicketSatisfaccionWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_192_2T2e( true) ;
         }
         else
         {
            wb_table3_192_2T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6TicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
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
         PA2T2( ) ;
         WS2T2( ) ;
         WE2T2( ) ;
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
         sCtrlAV6TicketId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "ticketsatisfaccionwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6TicketId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
         }
         wcpOAV6TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6TicketId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6TicketId != wcpOAV6TicketId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6TicketId = AV6TicketId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6TicketId = cgiGet( sPrefix+"AV6TicketId_CTRL");
         if ( StringUtil.Len( sCtrlAV6TicketId) > 0 )
         {
            AV6TicketId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV6TicketId), ".", ","));
            AssignAttri(sPrefix, false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
         }
         else
         {
            AV6TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV6TicketId_PARM"), ".", ","));
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
         PA2T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2T2( ) ;
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
         WS2T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6TicketId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6TicketId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6TicketId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6TicketId_CTRL", StringUtil.RTrim( sCtrlAV6TicketId));
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
            WE2T2( ) ;
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
         AddStyleSheetFile("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188342769", true, true);
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
         context.AddJavascriptSource("ticketsatisfaccionwc.js", "?2024188342771", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_2112( )
      {
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID_"+sGXsfl_211_idx;
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA_"+sGXsfl_211_idx;
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA_"+sGXsfl_211_idx;
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID_"+sGXsfl_211_idx;
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_211_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID_"+sGXsfl_211_idx;
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID_"+sGXsfl_211_idx;
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE_"+sGXsfl_211_idx;
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA_"+sGXsfl_211_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_211_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_211_idx;
      }

      protected void SubsflControlProps_fel_2112( )
      {
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA_"+sGXsfl_211_fel_idx;
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA_"+sGXsfl_211_fel_idx;
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID_"+sGXsfl_211_fel_idx;
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE_"+sGXsfl_211_fel_idx;
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA_"+sGXsfl_211_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_211_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_211_fel_idx;
      }

      protected void sendrow_2112( )
      {
         SubsflControlProps_2112( ) ;
         WB2T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_211_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_211_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_211_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtSatisfaccionId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtSatisfaccionFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionFecha_Internalname,context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"),context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionFecha_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtSatisfaccionFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionResueltoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoNombre_Internalname,(string)A33SatisfaccionResueltoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionResueltoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionResueltoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SatisfaccionTecnicoProblemaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTecnicoProblemaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaNombre_Internalname,(string)A36SatisfaccionTecnicoProblemaNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTecnicoProblemaNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTecnicoProblemaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTecnicoCompetenteNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteNombre_Internalname,(string)A35SatisfaccionTecnicoCompetenteNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTecnicoCompetenteNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTecnicoCompetenteNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTecnicoProfesionalismoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoNombre_Internalname,(string)A37SatisfaccionTecnicoProfesionalismoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTecnicoProfesionalismoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12SatisfaccionTiempoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTiempoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoNombre_Internalname,(string)A38SatisfaccionTiempoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTiempoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTiempoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SatisfaccionAtencionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionAtencionNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionNombre_Internalname,(string)A31SatisfaccionAtencionNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionAtencionNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionAtencionNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionSugerencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionSugerencia_Internalname,(string)A34SatisfaccionSugerencia,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionSugerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionSugerencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)211,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV61Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV61Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV70Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV61Update)) ? AV70Update_GXI : context.PathToRelativeUrl( AV61Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV61Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV62Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV71Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV62Delete)) ? AV71Delete_GXI : context.PathToRelativeUrl( AV62Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV62Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_211_idx = ((subGrid_Islastpage==1)&&(nGXsfl_211_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_211_idx+1);
            sGXsfl_211_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_211_idx), 4, 0), 4, "0");
            SubsflControlProps_2112( ) ;
         }
         /* End function sendrow_2112 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_satisfaccionid_visible.Name = "vATT_SATISFACCIONID_VISIBLE";
         chkavAtt_satisfaccionid_visible.WebTags = "";
         chkavAtt_satisfaccionid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionid_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionid_visible.Caption, true);
         chkavAtt_satisfaccionid_visible.CheckedValue = "false";
         chkavAtt_satisfaccionfecha_visible.Name = "vATT_SATISFACCIONFECHA_VISIBLE";
         chkavAtt_satisfaccionfecha_visible.WebTags = "";
         chkavAtt_satisfaccionfecha_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionfecha_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionfecha_visible.Caption, true);
         chkavAtt_satisfaccionfecha_visible.CheckedValue = "false";
         chkavAtt_usuariofecha_visible.Name = "vATT_USUARIOFECHA_VISIBLE";
         chkavAtt_usuariofecha_visible.WebTags = "";
         chkavAtt_usuariofecha_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariofecha_visible_Internalname, "TitleCaption", chkavAtt_usuariofecha_visible.Caption, true);
         chkavAtt_usuariofecha_visible.CheckedValue = "false";
         chkavAtt_satisfaccionresueltonombre_visible.Name = "vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE";
         chkavAtt_satisfaccionresueltonombre_visible.WebTags = "";
         chkavAtt_satisfaccionresueltonombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionresueltonombre_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionresueltonombre_visible.Caption, true);
         chkavAtt_satisfaccionresueltonombre_visible.CheckedValue = "false";
         chkavAtt_satisfacciontecnicoproblemanombre_visible.Name = "vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE";
         chkavAtt_satisfacciontecnicoproblemanombre_visible.WebTags = "";
         chkavAtt_satisfacciontecnicoproblemanombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname, "TitleCaption", chkavAtt_satisfacciontecnicoproblemanombre_visible.Caption, true);
         chkavAtt_satisfacciontecnicoproblemanombre_visible.CheckedValue = "false";
         chkavAtt_satisfacciontecnicocompetentenombre_visible.Name = "vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE";
         chkavAtt_satisfacciontecnicocompetentenombre_visible.WebTags = "";
         chkavAtt_satisfacciontecnicocompetentenombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname, "TitleCaption", chkavAtt_satisfacciontecnicocompetentenombre_visible.Caption, true);
         chkavAtt_satisfacciontecnicocompetentenombre_visible.CheckedValue = "false";
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Name = "vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE";
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.WebTags = "";
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname, "TitleCaption", chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Caption, true);
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.CheckedValue = "false";
         chkavAtt_satisfacciontiemponombre_visible.Name = "vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE";
         chkavAtt_satisfacciontiemponombre_visible.WebTags = "";
         chkavAtt_satisfacciontiemponombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfacciontiemponombre_visible_Internalname, "TitleCaption", chkavAtt_satisfacciontiemponombre_visible.Caption, true);
         chkavAtt_satisfacciontiemponombre_visible.CheckedValue = "false";
         chkavAtt_satisfaccionatencionnombre_visible.Name = "vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE";
         chkavAtt_satisfaccionatencionnombre_visible.WebTags = "";
         chkavAtt_satisfaccionatencionnombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionatencionnombre_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionatencionnombre_visible.Caption, true);
         chkavAtt_satisfaccionatencionnombre_visible.CheckedValue = "false";
         chkavAtt_satisfaccionsugerencia_visible.Name = "vATT_SATISFACCIONSUGERENCIA_VISIBLE";
         chkavAtt_satisfaccionsugerencia_visible.WebTags = "";
         chkavAtt_satisfaccionsugerencia_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionsugerencia_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionsugerencia_visible.Caption, true);
         chkavAtt_satisfaccionsugerencia_visible.CheckedValue = "false";
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
         lblTextblocksatisfaccionfecha_Internalname = sPrefix+"TEXTBLOCKSATISFACCIONFECHA";
         Satisfaccionfecha_daterangepicker_Internalname = sPrefix+"SATISFACCIONFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainersatisfaccionfecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONFECHA";
         lblTextblockusuariofecha_Internalname = sPrefix+"TEXTBLOCKUSUARIOFECHA";
         Usuariofecha_daterangepicker_Internalname = sPrefix+"USUARIOFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainerusuariofecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOFECHA";
         edtavSatisfaccionresueltonombre_Internalname = sPrefix+"vSATISFACCIONRESUELTONOMBRE";
         divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONRESUELTONOMBRE";
         edtavSatisfacciontecnicoproblemanombre_Internalname = sPrefix+"vSATISFACCIONTECNICOPROBLEMANOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROBLEMANOMBRE";
         edtavSatisfacciontecnicocompetentenombre_Internalname = sPrefix+"vSATISFACCIONTECNICOCOMPETENTENOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOCOMPETENTENOMBRE";
         edtavSatisfacciontecnicoprofesionalismonombre_Internalname = sPrefix+"vSATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         edtavSatisfacciontiemponombre_Internalname = sPrefix+"vSATISFACCIONTIEMPONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTIEMPONOMBRE";
         edtavSatisfaccionatencionnombre_Internalname = sPrefix+"vSATISFACCIONATENCIONNOMBRE";
         divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONATENCIONNOMBRE";
         divFilterattributestable_Internalname = sPrefix+"FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = sPrefix+"K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = sPrefix+"COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = sPrefix+"FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = sPrefix+"K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = sPrefix+"RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_satisfaccionid_visible_Internalname = sPrefix+"vATT_SATISFACCIONID_VISIBLE";
         divSatisfaccionid_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONID_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfaccionfecha_visible_Internalname = sPrefix+"vATT_SATISFACCIONFECHA_VISIBLE";
         divSatisfaccionfecha_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariofecha_visible_Internalname = sPrefix+"vATT_USUARIOFECHA_VISIBLE";
         divUsuariofecha_gridsettingscontainer_Internalname = sPrefix+"USUARIOFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfaccionresueltonombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE";
         divSatisfaccionresueltonombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE";
         divSatisfacciontecnicoproblemanombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMANOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE";
         divSatisfacciontecnicocompetentenombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE";
         divSatisfacciontecnicoprofesionalismonombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfacciontiemponombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE";
         divSatisfacciontiemponombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfaccionatencionnombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE";
         divSatisfaccionatencionnombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfaccionsugerencia_visible_Internalname = sPrefix+"vATT_SATISFACCIONSUGERENCIA_VISIBLE";
         divSatisfaccionsugerencia_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONSUGERENCIA_GRIDSETTINGSCONTAINER";
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
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID";
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA";
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA";
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID";
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE";
         edtSatisfaccionTecnicoProblemaId_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMAID";
         edtSatisfaccionTecnicoProblemaNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMANOMBRE";
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID";
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE";
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID";
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID";
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE";
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID";
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE";
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA";
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
         chkavAtt_satisfaccionsugerencia_visible.Caption = "Sugerencia:";
         chkavAtt_satisfaccionatencionnombre_visible.Caption = "Respuesta:";
         chkavAtt_satisfacciontiemponombre_visible.Caption = "Respuesta:";
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Caption = "Respuesta:";
         chkavAtt_satisfacciontecnicocompetentenombre_visible.Caption = "Respuesta:";
         chkavAtt_satisfacciontecnicoproblemanombre_visible.Caption = "Respuesta:";
         chkavAtt_satisfaccionresueltonombre_visible.Caption = "Respuesta:";
         chkavAtt_usuariofecha_visible.Caption = "Fecha Inicio:";
         chkavAtt_satisfaccionfecha_visible.Caption = "Fecha Encuesta:";
         chkavAtt_satisfaccionid_visible.Caption = "Id";
         edtSatisfaccionSugerencia_Jsonclick = "";
         edtSatisfaccionAtencionNombre_Jsonclick = "";
         edtSatisfaccionAtencionId_Jsonclick = "";
         edtSatisfaccionTiempoNombre_Jsonclick = "";
         edtSatisfaccionTiempoId_Jsonclick = "";
         edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick = "";
         edtSatisfaccionTecnicoProfesionalismoId_Jsonclick = "";
         edtSatisfaccionTecnicoCompetenteNombre_Jsonclick = "";
         edtSatisfaccionTecnicoCompetenteId_Jsonclick = "";
         edtSatisfaccionTecnicoProblemaNombre_Jsonclick = "";
         edtSatisfaccionTecnicoProblemaId_Jsonclick = "";
         edtSatisfaccionResueltoNombre_Jsonclick = "";
         edtSatisfaccionResueltoId_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtSatisfaccionFecha_Jsonclick = "";
         edtSatisfaccionId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_satisfaccionsugerencia_visible.Enabled = 1;
         chkavAtt_satisfaccionatencionnombre_visible.Enabled = 1;
         chkavAtt_satisfacciontiemponombre_visible.Enabled = 1;
         chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Enabled = 1;
         chkavAtt_satisfacciontecnicocompetentenombre_visible.Enabled = 1;
         chkavAtt_satisfacciontecnicoproblemanombre_visible.Enabled = 1;
         chkavAtt_satisfaccionresueltonombre_visible.Enabled = 1;
         chkavAtt_usuariofecha_visible.Enabled = 1;
         chkavAtt_satisfaccionfecha_visible.Enabled = 1;
         chkavAtt_satisfaccionid_visible.Enabled = 1;
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
         edtSatisfaccionAtencionNombre_Link = "";
         edtSatisfaccionTiempoNombre_Link = "";
         edtSatisfaccionTecnicoProfesionalismoNombre_Link = "";
         edtSatisfaccionTecnicoCompetenteNombre_Link = "";
         edtSatisfaccionTecnicoProblemaNombre_Link = "";
         edtSatisfaccionResueltoNombre_Link = "";
         edtSatisfaccionFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtSatisfaccionSugerencia_Visible = -1;
         edtSatisfaccionAtencionNombre_Visible = -1;
         edtSatisfaccionTiempoNombre_Visible = -1;
         edtSatisfaccionTecnicoProfesionalismoNombre_Visible = -1;
         edtSatisfaccionTecnicoCompetenteNombre_Visible = -1;
         edtSatisfaccionTecnicoProblemaNombre_Visible = -1;
         edtSatisfaccionResueltoNombre_Visible = -1;
         edtUsuarioFecha_Visible = -1;
         edtSatisfaccionFecha_Visible = -1;
         edtSatisfaccionId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavSatisfaccionatencionnombre_Jsonclick = "";
         edtavSatisfaccionatencionnombre_Enabled = 1;
         edtavSatisfacciontiemponombre_Jsonclick = "";
         edtavSatisfacciontiemponombre_Enabled = 1;
         edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick = "";
         edtavSatisfacciontecnicoprofesionalismonombre_Enabled = 1;
         edtavSatisfacciontecnicocompetentenombre_Jsonclick = "";
         edtavSatisfacciontecnicocompetentenombre_Enabled = 1;
         edtavSatisfacciontecnicoproblemanombre_Jsonclick = "";
         edtavSatisfacciontecnicoproblemanombre_Enabled = 1;
         edtavSatisfaccionresueltonombre_Jsonclick = "";
         edtavSatisfaccionresueltonombre_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132T2',iparms:[{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282T1',iparms:[{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242T2',iparms:[{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV52UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV46FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252T2',iparms:[{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A8SatisfaccionResueltoId',fld:'SATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'A9SatisfaccionTecnicoProblemaId',fld:'SATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'A10SatisfaccionTecnicoCompetenteId',fld:'SATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'A11SatisfaccionTecnicoProfesionalismoId',fld:'SATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'A12SatisfaccionTiempoId',fld:'SATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'A13SatisfaccionAtencionId',fld:'SATISFACCIONATENCIONID',pic:'ZZZ9'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Link',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Link'},{av:'edtSatisfaccionTecnicoProblemaNombre_Link',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Link'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Link',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Link'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Link',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Link'},{av:'edtSatisfaccionTiempoNombre_Link',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Link'},{av:'edtSatisfaccionAtencionNombre_Link',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Link'},{av:'edtSatisfaccionFecha_Link',ctrl:'SATISFACCIONFECHA',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV47DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV52UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262T1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV26RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV25GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV52UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV26RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182T2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV68Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV58AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV61Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV62Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV60SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV31ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProblemaNombre_Visible',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192T2',iparms:[{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV33SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV34SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV36UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV37UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV38SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV40SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV48K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV49OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV65Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272T1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202T2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212T2',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID","{handler:'Valid_Satisfaccionresueltoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID","{handler:'Valid_Satisfacciontecnicoproblemaid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID","{handler:'Valid_Satisfacciontecnicocompetenteid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID","{handler:'Valid_Satisfacciontecnicoprofesionalismoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID","{handler:'Valid_Satisfacciontiempoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONATENCIONID","{handler:'Valid_Satisfaccionatencionid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONATENCIONID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV18Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV19Att_SatisfaccionTecnicoProblemaNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROBLEMANOMBRE_VISIBLE',pic:''},{av:'AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV48K2BToolsGenericSearchField = "";
         AV33SatisfaccionFecha_From = DateTime.MinValue;
         AV36UsuarioFecha_From = DateTime.MinValue;
         AV38SatisfaccionResueltoNombre = "";
         AV39SatisfaccionTecnicoProblemaNombre = "";
         AV40SatisfaccionTecnicoCompetenteNombre = "";
         AV41SatisfaccionTecnicoProfesionalismoNombre = "";
         AV42SatisfaccionTiempoNombre = "";
         AV43SatisfaccionAtencionNombre = "";
         AV31ClassCollection = new GxSimpleCollection<string>();
         AV34SatisfaccionFecha_To = DateTime.MinValue;
         AV37UsuarioFecha_To = DateTime.MinValue;
         AV68Pgmname = "";
         AV11GridConfiguration = new SdtK2BGridConfiguration(context);
         AV58AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV46FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV47DeletedTag = "";
         AV50GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblocksatisfaccionfecha_Jsonclick = "";
         ucSatisfaccionfecha_daterangepicker = new GXUserControl();
         lblTextblockusuariofecha_Jsonclick = "";
         ucUsuariofecha_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A34SatisfaccionSugerencia = "";
         AV61Update = "";
         AV62Delete = "";
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
         AV70Update_GXI = "";
         AV71Delete_GXI = "";
         scmdbuf = "";
         lV38SatisfaccionResueltoNombre = "";
         lV39SatisfaccionTecnicoProblemaNombre = "";
         lV40SatisfaccionTecnicoCompetenteNombre = "";
         lV41SatisfaccionTecnicoProfesionalismoNombre = "";
         lV42SatisfaccionTiempoNombre = "";
         lV43SatisfaccionAtencionNombre = "";
         lV48K2BToolsGenericSearchField = "";
         H002T2_A15UsuarioId = new long[1] ;
         H002T2_A14TicketId = new long[1] ;
         H002T2_A34SatisfaccionSugerencia = new string[] {""} ;
         H002T2_n34SatisfaccionSugerencia = new bool[] {false} ;
         H002T2_A31SatisfaccionAtencionNombre = new string[] {""} ;
         H002T2_A13SatisfaccionAtencionId = new short[1] ;
         H002T2_A38SatisfaccionTiempoNombre = new string[] {""} ;
         H002T2_A12SatisfaccionTiempoId = new short[1] ;
         H002T2_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         H002T2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         H002T2_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         H002T2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         H002T2_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         H002T2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         H002T2_A33SatisfaccionResueltoNombre = new string[] {""} ;
         H002T2_A8SatisfaccionResueltoId = new short[1] ;
         H002T2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H002T2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         H002T2_A7SatisfaccionId = new long[1] ;
         H002T3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV32SatisfaccionFecha = DateTime.MinValue;
         AV35UsuarioFecha = DateTime.MinValue;
         AV51GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV53Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV54Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV57ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV59ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV28GridStateKey = "";
         AV29GridState = new SdtK2BGridState(context);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV55TrnContext = new SdtK2BTrnContext(context);
         AV56TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV44K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV45K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV63OutFile = "";
         AV64Guid = (Guid)(Guid.Empty);
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
         sCtrlAV6TicketId = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticketsatisfaccionwc__default(),
            new Object[][] {
                new Object[] {
               H002T2_A15UsuarioId, H002T2_A14TicketId, H002T2_A34SatisfaccionSugerencia, H002T2_n34SatisfaccionSugerencia, H002T2_A31SatisfaccionAtencionNombre, H002T2_A13SatisfaccionAtencionId, H002T2_A38SatisfaccionTiempoNombre, H002T2_A12SatisfaccionTiempoId, H002T2_A37SatisfaccionTecnicoProfesionalismoNombre, H002T2_A11SatisfaccionTecnicoProfesionalismoId,
               H002T2_A35SatisfaccionTecnicoCompetenteNombre, H002T2_A10SatisfaccionTecnicoCompetenteId, H002T2_A36SatisfaccionTecnicoProblemaNombre, H002T2_A9SatisfaccionTecnicoProblemaId, H002T2_A33SatisfaccionResueltoNombre, H002T2_A8SatisfaccionResueltoId, H002T2_A90UsuarioFecha, H002T2_A32SatisfaccionFecha, H002T2_A7SatisfaccionId
               }
               , new Object[] {
               H002T3_AGRID_nRecordCount
               }
            }
         );
         AV68Pgmname = "TicketSatisfaccionWC";
         /* GeneXus formulas. */
         AV68Pgmname = "TicketSatisfaccionWC";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV49OrderedBy ;
      private short initialized ;
      private short AV52UC_OrderedBy ;
      private short AV26RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV25GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_211 ;
      private int nGXsfl_211_idx=1 ;
      private int subGrid_Rows ;
      private int AV9CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavSatisfaccionresueltonombre_Enabled ;
      private int edtavSatisfacciontecnicoproblemanombre_Enabled ;
      private int edtavSatisfacciontecnicocompetentenombre_Enabled ;
      private int edtavSatisfacciontecnicoprofesionalismonombre_Enabled ;
      private int edtavSatisfacciontiemponombre_Enabled ;
      private int edtavSatisfaccionatencionnombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtSatisfaccionId_Visible ;
      private int edtSatisfaccionFecha_Visible ;
      private int edtUsuarioFecha_Visible ;
      private int edtSatisfaccionResueltoNombre_Visible ;
      private int edtSatisfaccionTecnicoProblemaNombre_Visible ;
      private int edtSatisfaccionTecnicoCompetenteNombre_Visible ;
      private int edtSatisfaccionTecnicoProfesionalismoNombre_Visible ;
      private int edtSatisfaccionTiempoNombre_Visible ;
      private int edtSatisfaccionAtencionNombre_Visible ;
      private int edtSatisfaccionSugerencia_Visible ;
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
      private int AV69GXV1 ;
      private int AV72GXV2 ;
      private int AV10K2BMaxPages ;
      private int AV73GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV74GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long AV6TicketId ;
      private long wcpOAV6TicketId ;
      private long GRID_nFirstRecordOnPage ;
      private long A7SatisfaccionId ;
      private long GRID_nCurrentRecord ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_211_idx="0001" ;
      private string AV48K2BToolsGenericSearchField ;
      private string AV68Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV47DeletedTag ;
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
      private string divK2btoolstable_attributecontainersatisfaccionfecha_Internalname ;
      private string lblTextblocksatisfaccionfecha_Internalname ;
      private string lblTextblocksatisfaccionfecha_Jsonclick ;
      private string Satisfaccionfecha_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainerusuariofecha_Internalname ;
      private string lblTextblockusuariofecha_Internalname ;
      private string lblTextblockusuariofecha_Jsonclick ;
      private string Usuariofecha_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname ;
      private string edtavSatisfaccionresueltonombre_Internalname ;
      private string edtavSatisfaccionresueltonombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname ;
      private string edtavSatisfacciontecnicoproblemanombre_Internalname ;
      private string edtavSatisfacciontecnicoproblemanombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname ;
      private string edtavSatisfacciontecnicocompetentenombre_Internalname ;
      private string edtavSatisfacciontecnicocompetentenombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname ;
      private string edtavSatisfacciontecnicoprofesionalismonombre_Internalname ;
      private string edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname ;
      private string edtavSatisfacciontiemponombre_Internalname ;
      private string edtavSatisfacciontiemponombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname ;
      private string edtavSatisfaccionatencionnombre_Internalname ;
      private string edtavSatisfaccionatencionnombre_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtSatisfaccionFecha_Link ;
      private string edtSatisfaccionResueltoNombre_Link ;
      private string edtSatisfaccionTecnicoProblemaNombre_Link ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Link ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Link ;
      private string edtSatisfaccionTiempoNombre_Link ;
      private string edtSatisfaccionAtencionNombre_Link ;
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
      private string edtSatisfaccionId_Internalname ;
      private string edtSatisfaccionFecha_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtSatisfaccionResueltoId_Internalname ;
      private string edtSatisfaccionResueltoNombre_Internalname ;
      private string edtSatisfaccionTecnicoProblemaId_Internalname ;
      private string edtSatisfaccionTecnicoProblemaNombre_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteId_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoId_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Internalname ;
      private string edtSatisfaccionTiempoId_Internalname ;
      private string edtSatisfaccionTiempoNombre_Internalname ;
      private string edtSatisfaccionAtencionId_Internalname ;
      private string edtSatisfaccionAtencionNombre_Internalname ;
      private string edtSatisfaccionSugerencia_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV48K2BToolsGenericSearchField ;
      private string chkavAtt_satisfaccionid_visible_Internalname ;
      private string chkavAtt_satisfaccionfecha_visible_Internalname ;
      private string chkavAtt_usuariofecha_visible_Internalname ;
      private string chkavAtt_satisfaccionresueltonombre_visible_Internalname ;
      private string chkavAtt_satisfacciontecnicoproblemanombre_visible_Internalname ;
      private string chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname ;
      private string chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname ;
      private string chkavAtt_satisfacciontiemponombre_visible_Internalname ;
      private string chkavAtt_satisfaccionatencionnombre_visible_Internalname ;
      private string chkavAtt_satisfaccionsugerencia_visible_Internalname ;
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
      private string divSatisfaccionid_gridsettingscontainer_Internalname ;
      private string divSatisfaccionfecha_gridsettingscontainer_Internalname ;
      private string divUsuariofecha_gridsettingscontainer_Internalname ;
      private string divSatisfaccionresueltonombre_gridsettingscontainer_Internalname ;
      private string divSatisfacciontecnicoproblemanombre_gridsettingscontainer_Internalname ;
      private string divSatisfacciontecnicocompetentenombre_gridsettingscontainer_Internalname ;
      private string divSatisfacciontecnicoprofesionalismonombre_gridsettingscontainer_Internalname ;
      private string divSatisfacciontiemponombre_gridsettingscontainer_Internalname ;
      private string divSatisfaccionatencionnombre_gridsettingscontainer_Internalname ;
      private string divSatisfaccionsugerencia_gridsettingscontainer_Internalname ;
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
      private string sCtrlAV6TicketId ;
      private string sGXsfl_211_fel_idx="0001" ;
      private string ROClassString ;
      private string edtSatisfaccionId_Jsonclick ;
      private string edtSatisfaccionFecha_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtSatisfaccionResueltoId_Jsonclick ;
      private string edtSatisfaccionResueltoNombre_Jsonclick ;
      private string edtSatisfaccionTecnicoProblemaId_Jsonclick ;
      private string edtSatisfaccionTecnicoProblemaNombre_Jsonclick ;
      private string edtSatisfaccionTecnicoCompetenteId_Jsonclick ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Jsonclick ;
      private string edtSatisfaccionTecnicoProfesionalismoId_Jsonclick ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick ;
      private string edtSatisfaccionTiempoId_Jsonclick ;
      private string edtSatisfaccionTiempoNombre_Jsonclick ;
      private string edtSatisfaccionAtencionId_Jsonclick ;
      private string edtSatisfaccionAtencionNombre_Jsonclick ;
      private string edtSatisfaccionSugerencia_Jsonclick ;
      private DateTime GXt_dtime3 ;
      private DateTime AV33SatisfaccionFecha_From ;
      private DateTime AV36UsuarioFecha_From ;
      private DateTime AV34SatisfaccionFecha_To ;
      private DateTime AV37UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime AV32SatisfaccionFecha ;
      private DateTime AV35UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV60SatisfaccionFecha_IsAuthorized ;
      private bool AV15Att_SatisfaccionId_Visible ;
      private bool AV16Att_SatisfaccionFecha_Visible ;
      private bool AV17Att_UsuarioFecha_Visible ;
      private bool AV18Att_SatisfaccionResueltoNombre_Visible ;
      private bool AV19Att_SatisfaccionTecnicoProblemaNombre_Visible ;
      private bool AV20Att_SatisfaccionTecnicoCompetenteNombre_Visible ;
      private bool AV21Att_SatisfaccionTecnicoProfesionalismoNombre_Visible ;
      private bool AV22Att_SatisfaccionTiempoNombre_Visible ;
      private bool AV23Att_SatisfaccionAtencionNombre_Visible ;
      private bool AV24Att_SatisfaccionSugerencia_Visible ;
      private bool AV12FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n34SatisfaccionSugerencia ;
      private bool bGXsfl_211_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV27RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV61Update_IsBlob ;
      private bool AV62Delete_IsBlob ;
      private string AV38SatisfaccionResueltoNombre ;
      private string AV39SatisfaccionTecnicoProblemaNombre ;
      private string AV40SatisfaccionTecnicoCompetenteNombre ;
      private string AV41SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV42SatisfaccionTiempoNombre ;
      private string AV43SatisfaccionAtencionNombre ;
      private string AV65Uri ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A34SatisfaccionSugerencia ;
      private string AV70Update_GXI ;
      private string AV71Delete_GXI ;
      private string lV38SatisfaccionResueltoNombre ;
      private string lV39SatisfaccionTecnicoProblemaNombre ;
      private string lV40SatisfaccionTecnicoCompetenteNombre ;
      private string lV41SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV42SatisfaccionTiempoNombre ;
      private string lV43SatisfaccionAtencionNombre ;
      private string AV28GridStateKey ;
      private string AV63OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV61Update ;
      private string AV62Delete ;
      private Guid AV64Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucSatisfaccionfecha_daterangepicker ;
      private GXUserControl ucUsuariofecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_satisfaccionid_visible ;
      private GXCheckbox chkavAtt_satisfaccionfecha_visible ;
      private GXCheckbox chkavAtt_usuariofecha_visible ;
      private GXCheckbox chkavAtt_satisfaccionresueltonombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontecnicoproblemanombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontecnicocompetentenombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontecnicoprofesionalismonombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontiemponombre_visible ;
      private GXCheckbox chkavAtt_satisfaccionatencionnombre_visible ;
      private GXCheckbox chkavAtt_satisfaccionsugerencia_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private long[] H002T2_A15UsuarioId ;
      private long[] H002T2_A14TicketId ;
      private string[] H002T2_A34SatisfaccionSugerencia ;
      private bool[] H002T2_n34SatisfaccionSugerencia ;
      private string[] H002T2_A31SatisfaccionAtencionNombre ;
      private short[] H002T2_A13SatisfaccionAtencionId ;
      private string[] H002T2_A38SatisfaccionTiempoNombre ;
      private short[] H002T2_A12SatisfaccionTiempoId ;
      private string[] H002T2_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] H002T2_A11SatisfaccionTecnicoProfesionalismoId ;
      private string[] H002T2_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] H002T2_A10SatisfaccionTecnicoCompetenteId ;
      private string[] H002T2_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] H002T2_A9SatisfaccionTecnicoProblemaId ;
      private string[] H002T2_A33SatisfaccionResueltoNombre ;
      private short[] H002T2_A8SatisfaccionResueltoId ;
      private DateTime[] H002T2_A90UsuarioFecha ;
      private DateTime[] H002T2_A32SatisfaccionFecha ;
      private long[] H002T2_A7SatisfaccionId ;
      private long[] H002T3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV31ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV44K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV46FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV50GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV53Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV58AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV57ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV11GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV14GridColumn ;
      private SdtK2BGridState AV29GridState ;
      private SdtK2BGridState_FilterValue AV30GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV45K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV51GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV54Message ;
      private SdtK2BTrnContext AV55TrnContext ;
      private SdtK2BTrnContext_Attribute AV56TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV59ActivityListItem ;
   }

   public class ticketsatisfaccionwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002T2( IGxContext context ,
                                             DateTime AV34SatisfaccionFecha_To ,
                                             DateTime AV33SatisfaccionFecha_From ,
                                             DateTime AV37UsuarioFecha_To ,
                                             DateTime AV36UsuarioFecha_From ,
                                             string AV38SatisfaccionResueltoNombre ,
                                             string AV39SatisfaccionTecnicoProblemaNombre ,
                                             string AV40SatisfaccionTecnicoCompetenteNombre ,
                                             string AV41SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV42SatisfaccionTiempoNombre ,
                                             string AV43SatisfaccionAtencionNombre ,
                                             string AV48K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV49OrderedBy ,
                                             long AV6TicketId ,
                                             long A14TicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[22];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[UsuarioId], T1.[TicketId], T1.[SatisfaccionSugerencia], T4.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T7.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T8.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T9.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T3.[UsuarioFecha], T1.[SatisfaccionFecha], T1.[SatisfaccionId]";
         sFromString = " FROM (((((((([Satisfaccion] T1 INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T8 ON T8.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T9 ON T9.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[TicketId] = @AV6TicketId)");
         if ( ! (DateTime.MinValue==AV34SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV34SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV33SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV33SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV37UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] <= @AV37UsuarioFecha_To)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV36UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] >= @AV36UsuarioFecha_From)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T9.[EstadoSatisfaccionNombre] like @lV38SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T8.[EstadoSatisfaccionNombre] like @lV39SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV40SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV41SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV43SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV48K2BToolsGenericSearchField + '%' or T9.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T8.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T7.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV48K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
            GXv_int5[18] = 1;
         }
         if ( AV49OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV49OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV49OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV49OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002T3( IGxContext context ,
                                             DateTime AV34SatisfaccionFecha_To ,
                                             DateTime AV33SatisfaccionFecha_From ,
                                             DateTime AV37UsuarioFecha_To ,
                                             DateTime AV36UsuarioFecha_From ,
                                             string AV38SatisfaccionResueltoNombre ,
                                             string AV39SatisfaccionTecnicoProblemaNombre ,
                                             string AV40SatisfaccionTecnicoCompetenteNombre ,
                                             string AV41SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV42SatisfaccionTiempoNombre ,
                                             string AV43SatisfaccionAtencionNombre ,
                                             string AV48K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV49OrderedBy ,
                                             long AV6TicketId ,
                                             long A14TicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[19];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((([Satisfaccion] T1 INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId]) INNER JOIN [EstadoSatisfaccion] T9 ON T9.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T8 ON T8.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId])";
         AddWhere(sWhereString, "(T1.[TicketId] = @AV6TicketId)");
         if ( ! (DateTime.MinValue==AV34SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV34SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV33SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV33SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV37UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] <= @AV37UsuarioFecha_To)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV36UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] >= @AV36UsuarioFecha_From)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV38SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV39SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV40SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV41SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T8.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T9.[EstadoSatisfaccionNombre] like @lV43SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV48K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T7.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T8.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T9.[EstadoSatisfaccionNombre] like '%' + @lV48K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV48K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
            GXv_int7[16] = 1;
            GXv_int7[17] = 1;
            GXv_int7[18] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV49OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV49OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV49OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV49OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002T2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 1 :
                     return conditional_H002T3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
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
          Object[] prmH002T2;
          prmH002T2 = new Object[] {
          new ParDef("@AV6TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV34SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV33SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV37UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV38SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV39SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV40SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV41SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002T3;
          prmH002T3 = new Object[] {
          new ParDef("@AV6TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV34SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV33SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV37UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV38SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV39SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV40SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV41SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV48K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((short[]) buf[15])[0] = rslt.getShort(15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(17);
                ((long[]) buf[18])[0] = rslt.getLong(18);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
