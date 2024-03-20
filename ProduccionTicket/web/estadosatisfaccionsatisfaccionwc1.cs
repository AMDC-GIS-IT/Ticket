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
   public class estadosatisfaccionsatisfaccionwc1 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public estadosatisfaccionsatisfaccionwc1( )
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

      public estadosatisfaccionsatisfaccionwc1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SatisfaccionTecnicoProblemaId )
      {
         this.AV6SatisfaccionTecnicoProblemaId = aP0_SatisfaccionTecnicoProblemaId;
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
         chkavAtt_ticketid_visible = new GXCheckbox();
         chkavAtt_usuarioid_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariofecha_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         chkavAtt_satisfaccionresueltonombre_visible = new GXCheckbox();
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
               gxfirstwebparm = GetFirstPar( "SatisfaccionTecnicoProblemaId");
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
                  AV6SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProblemaId"), "."));
                  AssignAttri(sPrefix, false, "AV6SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV6SatisfaccionTecnicoProblemaId});
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
                  gxfirstwebparm = GetFirstPar( "SatisfaccionTecnicoProblemaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SatisfaccionTecnicoProblemaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_223 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_223"), "."));
                  nGXsfl_223_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_223_idx"), "."));
                  sGXsfl_223_idx = GetPar( "sGXsfl_223_idx");
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
                  AV50K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV36SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
                  AV39UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV41SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
                  AV42SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
                  AV43SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
                  AV44SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
                  AV45SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
                  AV6SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProblemaId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV34ClassCollection);
                  AV51OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV37SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
                  AV40UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV70Pgmname = GetPar( "Pgmname");
                  AV9CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridConfiguration);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV60AutoLinksActivityList);
                  AV62SatisfaccionFecha_IsAuthorized = StringUtil.StrToBool( GetPar( "SatisfaccionFecha_IsAuthorized"));
                  AV15Att_SatisfaccionId_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionId_Visible"));
                  AV16Att_SatisfaccionFecha_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionFecha_Visible"));
                  AV17Att_TicketId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketId_Visible"));
                  AV18Att_UsuarioId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioId_Visible"));
                  AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
                  AV20Att_UsuarioFecha_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioFecha_Visible"));
                  AV21Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
                  AV22Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionResueltoNombre_Visible"));
                  AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTecnicoCompetenteNombre_Visible"));
                  AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTecnicoProfesionalismoNombre_Visible"));
                  AV25Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionTiempoNombre_Visible"));
                  AV26Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionAtencionNombre_Visible"));
                  AV27Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( GetPar( "Att_SatisfaccionSugerencia_Visible"));
                  AV12FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV67Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
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
            PA282( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV70Pgmname = "EstadoSatisfaccionSatisfaccionWC1";
               context.Gx_err = 0;
               WS282( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188344279", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosatisfaccionsatisfaccionwc1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6SatisfaccionTecnicoProblemaId,4,0))}, new string[] {"SatisfaccionTecnicoProblemaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV50K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONFECHA_FROM", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE", AV41SatisfaccionResueltoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE", AV42SatisfaccionTecnicoCompetenteNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE", AV43SatisfaccionTecnicoProfesionalismoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE", AV44SatisfaccionTiempoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE", AV45SatisfaccionAtencionNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_223", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_223), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGS", AV48FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGS", AV48FilterTags);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG", StringUtil.RTrim( AV49DeletedTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_TO", context.localUtil.DToC( AV37SatisfaccionFecha_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOFECHA_TO", context.localUtil.DToC( AV40UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV52GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV52GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6SatisfaccionTecnicoProblemaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV34ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV34ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONTECNICOPROBLEMAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAUTOLINKSACTIVITYLIST", AV60AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAUTOLINKSACTIVITYLIST", AV60AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_ISAUTHORIZED", AV62SatisfaccionFecha_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV67Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Uri, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONFECHA_FROM", context.localUtil.DToC( AV36SatisfaccionFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOFECHA_FROM", context.localUtil.DToC( AV39UsuarioFecha_From, 0, "/"));
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

      protected void RenderHtmlCloseForm282( )
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
         return "EstadoSatisfaccionSatisfaccionWC1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Satisfacciones" ;
      }

      protected void WB280( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "estadosatisfaccionsatisfaccionwc1.aspx");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV50K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV50K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV48FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV49DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocksatisfaccionfecha_Internalname, "Fecha Encuesta:", "", "", lblTextblocksatisfaccionfecha_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* User Defined Control */
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueFrom", AV36SatisfaccionFecha_From);
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueTo", AV37SatisfaccionFecha_To);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha", "", "", lblTextblockusuariofecha_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV39UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV40UsuarioFecha_To);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionresueltonombre_Internalname, AV41SatisfaccionResueltoNombre, StringUtil.RTrim( context.localUtil.Format( AV41SatisfaccionResueltoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionresueltonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionresueltonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicocompetentenombre_Internalname, AV42SatisfaccionTecnicoCompetenteNombre, StringUtil.RTrim( context.localUtil.Format( AV42SatisfaccionTecnicoCompetenteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicocompetentenombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicocompetentenombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, AV43SatisfaccionTecnicoProfesionalismoNombre, StringUtil.RTrim( context.localUtil.Format( AV43SatisfaccionTecnicoProfesionalismoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoprofesionalismonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontiemponombre_Internalname, AV44SatisfaccionTiempoNombre, StringUtil.RTrim( context.localUtil.Format( AV44SatisfaccionTiempoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontiemponombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontiemponombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionatencionnombre_Internalname, AV45SatisfaccionAtencionNombre, StringUtil.RTrim( context.localUtil.Format( AV45SatisfaccionAtencionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionatencionnombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionatencionnombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            wb_table1_77_282( true) ;
         }
         else
         {
            wb_table1_77_282( false) ;
         }
         return  ;
      }

      protected void wb_table1_77_282e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"223\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Requerimiento") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFecha_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV63Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV64Delete));
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
         if ( wbEnd == 223 )
         {
            wbEnd = 0;
            nRC_GXsfl_223 = (int)(nGXsfl_223_idx-1);
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
            wb_table2_246_282( true) ;
         }
         else
         {
            wb_table2_246_282( false) ;
         }
         return  ;
      }

      protected void wb_table2_246_282e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV52GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV54UC_OrderedBy);
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
         if ( wbEnd == 223 )
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

      protected void START282( )
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
               STRUP280( ) ;
            }
         }
      }

      protected void WS282( )
      {
         START282( ) ;
         EVT282( ) ;
      }

      protected void EVT282( )
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
                                 STRUP280( ) ;
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
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E13282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E14282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E15282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E16282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E17282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E18282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E19282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
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
                                 STRUP280( ) ;
                              }
                              nGXsfl_223_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_223_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_223_idx), 4, 0), 4, "0");
                              SubsflControlProps_2232( ) ;
                              A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
                              A32SatisfaccionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSatisfaccionFecha_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ","));
                              A33SatisfaccionResueltoNombre = cgiGet( edtSatisfaccionResueltoNombre_Internalname);
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
                              AV63Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update))), !bGXsfl_223_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update), true);
                              AV64Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV64Delete))), !bGXsfl_223_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV64Delete), true);
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
                                          E22282 ();
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
                                          E23282 ();
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
                                          E24282 ();
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
                                          E25282 ();
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
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV50K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionfecha_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSATISFACCIONFECHA_FROM"), 0) != AV36SatisfaccionFecha_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Usuariofecha_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vUSUARIOFECHA_FROM"), 0) != AV39UsuarioFecha_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionresueltonombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE"), AV41SatisfaccionResueltoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontecnicocompetentenombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV42SatisfaccionTecnicoCompetenteNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontecnicoprofesionalismonombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV43SatisfaccionTecnicoProfesionalismoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfacciontiemponombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE"), AV44SatisfaccionTiempoNombre) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Satisfaccionatencionnombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE"), AV45SatisfaccionAtencionNombre) != 0 )
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
                                       STRUP280( ) ;
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

      protected void WE282( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm282( ) ;
            }
         }
      }

      protected void PA282( )
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
         SubsflControlProps_2232( ) ;
         while ( nGXsfl_223_idx <= nRC_GXsfl_223 )
         {
            sendrow_2232( ) ;
            nGXsfl_223_idx = ((subGrid_Islastpage==1)&&(nGXsfl_223_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_223_idx+1);
            sGXsfl_223_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_223_idx), 4, 0), 4, "0");
            SubsflControlProps_2232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV50K2BToolsGenericSearchField ,
                                       DateTime AV36SatisfaccionFecha_From ,
                                       DateTime AV39UsuarioFecha_From ,
                                       string AV41SatisfaccionResueltoNombre ,
                                       string AV42SatisfaccionTecnicoCompetenteNombre ,
                                       string AV43SatisfaccionTecnicoProfesionalismoNombre ,
                                       string AV44SatisfaccionTiempoNombre ,
                                       string AV45SatisfaccionAtencionNombre ,
                                       short AV6SatisfaccionTecnicoProblemaId ,
                                       GxSimpleCollection<string> AV34ClassCollection ,
                                       short AV51OrderedBy ,
                                       DateTime AV37SatisfaccionFecha_To ,
                                       DateTime AV40UsuarioFecha_To ,
                                       string AV70Pgmname ,
                                       int AV9CurrentPage ,
                                       SdtK2BGridConfiguration AV11GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV60AutoLinksActivityList ,
                                       bool AV62SatisfaccionFecha_IsAuthorized ,
                                       bool AV15Att_SatisfaccionId_Visible ,
                                       bool AV16Att_SatisfaccionFecha_Visible ,
                                       bool AV17Att_TicketId_Visible ,
                                       bool AV18Att_UsuarioId_Visible ,
                                       bool AV19Att_UsuarioNombre_Visible ,
                                       bool AV20Att_UsuarioFecha_Visible ,
                                       bool AV21Att_UsuarioRequerimiento_Visible ,
                                       bool AV22Att_SatisfaccionResueltoNombre_Visible ,
                                       bool AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible ,
                                       bool AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible ,
                                       bool AV25Att_SatisfaccionTiempoNombre_Visible ,
                                       bool AV26Att_SatisfaccionAtencionNombre_Visible ,
                                       bool AV27Att_SatisfaccionSugerencia_Visible ,
                                       bool AV12FreezeColumnTitles ,
                                       string AV67Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E23282 ();
         GRID_nCurrentRecord = 0;
         RF282( ) ;
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
         AV17Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TicketId_Visible));
         AssignAttri(sPrefix, false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
         AV18Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioId_Visible));
         AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
         AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioNombre_Visible));
         AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
         AV20Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioFecha_Visible));
         AssignAttri(sPrefix, false, "AV20Att_UsuarioFecha_Visible", AV20Att_UsuarioFecha_Visible);
         AV21Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_UsuarioRequerimiento_Visible));
         AssignAttri(sPrefix, false, "AV21Att_UsuarioRequerimiento_Visible", AV21Att_UsuarioRequerimiento_Visible);
         AV22Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_SatisfaccionResueltoNombre_Visible));
         AssignAttri(sPrefix, false, "AV22Att_SatisfaccionResueltoNombre_Visible", AV22Att_SatisfaccionResueltoNombre_Visible);
         AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible));
         AssignAttri(sPrefix, false, "AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible);
         AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible));
         AssignAttri(sPrefix, false, "AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
         AV25Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_SatisfaccionTiempoNombre_Visible));
         AssignAttri(sPrefix, false, "AV25Att_SatisfaccionTiempoNombre_Visible", AV25Att_SatisfaccionTiempoNombre_Visible);
         AV26Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV26Att_SatisfaccionAtencionNombre_Visible));
         AssignAttri(sPrefix, false, "AV26Att_SatisfaccionAtencionNombre_Visible", AV26Att_SatisfaccionAtencionNombre_Visible);
         AV27Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV27Att_SatisfaccionSugerencia_Visible));
         AssignAttri(sPrefix, false, "AV27Att_SatisfaccionSugerencia_Visible", AV27Att_SatisfaccionSugerencia_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV28GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV12FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV12FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E23282 ();
         RF282( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV70Pgmname = "EstadoSatisfaccionSatisfaccionWC1";
         context.Gx_err = 0;
      }

      protected void RF282( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 223;
         E24282 ();
         nGXsfl_223_idx = 1;
         sGXsfl_223_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_223_idx), 4, 0), 4, "0");
         SubsflControlProps_2232( ) ;
         bGXsfl_223_Refreshing = true;
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
            SubsflControlProps_2232( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV37SatisfaccionFecha_To ,
                                                 AV36SatisfaccionFecha_From ,
                                                 AV40UsuarioFecha_To ,
                                                 AV39UsuarioFecha_From ,
                                                 AV41SatisfaccionResueltoNombre ,
                                                 AV42SatisfaccionTecnicoCompetenteNombre ,
                                                 AV43SatisfaccionTecnicoProfesionalismoNombre ,
                                                 AV44SatisfaccionTiempoNombre ,
                                                 AV45SatisfaccionAtencionNombre ,
                                                 AV50K2BToolsGenericSearchField ,
                                                 A32SatisfaccionFecha ,
                                                 A90UsuarioFecha ,
                                                 A33SatisfaccionResueltoNombre ,
                                                 A35SatisfaccionTecnicoCompetenteNombre ,
                                                 A37SatisfaccionTecnicoProfesionalismoNombre ,
                                                 A38SatisfaccionTiempoNombre ,
                                                 A31SatisfaccionAtencionNombre ,
                                                 A7SatisfaccionId ,
                                                 A14TicketId ,
                                                 A15UsuarioId ,
                                                 A93UsuarioNombre ,
                                                 A94UsuarioRequerimiento ,
                                                 A34SatisfaccionSugerencia ,
                                                 AV51OrderedBy ,
                                                 AV6SatisfaccionTecnicoProblemaId ,
                                                 A9SatisfaccionTecnicoProblemaId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV41SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionResueltoNombre), "%", "");
            lV42SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTecnicoCompetenteNombre), "%", "");
            lV43SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionTecnicoProfesionalismoNombre), "%", "");
            lV44SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV44SatisfaccionTiempoNombre), "%", "");
            lV45SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV45SatisfaccionAtencionNombre), "%", "");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H00282 */
            pr_default.execute(0, new Object[] {AV6SatisfaccionTecnicoProblemaId, AV37SatisfaccionFecha_To, AV36SatisfaccionFecha_From, AV40UsuarioFecha_To, AV39UsuarioFecha_From, lV41SatisfaccionResueltoNombre, lV42SatisfaccionTecnicoCompetenteNombre, lV43SatisfaccionTecnicoProfesionalismoNombre, lV44SatisfaccionTiempoNombre, lV45SatisfaccionAtencionNombre, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_223_idx = 1;
            sGXsfl_223_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_223_idx), 4, 0), 4, "0");
            SubsflControlProps_2232( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A9SatisfaccionTecnicoProblemaId = H00282_A9SatisfaccionTecnicoProblemaId[0];
               A34SatisfaccionSugerencia = H00282_A34SatisfaccionSugerencia[0];
               n34SatisfaccionSugerencia = H00282_n34SatisfaccionSugerencia[0];
               A31SatisfaccionAtencionNombre = H00282_A31SatisfaccionAtencionNombre[0];
               A13SatisfaccionAtencionId = H00282_A13SatisfaccionAtencionId[0];
               A38SatisfaccionTiempoNombre = H00282_A38SatisfaccionTiempoNombre[0];
               A12SatisfaccionTiempoId = H00282_A12SatisfaccionTiempoId[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H00282_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A11SatisfaccionTecnicoProfesionalismoId = H00282_A11SatisfaccionTecnicoProfesionalismoId[0];
               A35SatisfaccionTecnicoCompetenteNombre = H00282_A35SatisfaccionTecnicoCompetenteNombre[0];
               A10SatisfaccionTecnicoCompetenteId = H00282_A10SatisfaccionTecnicoCompetenteId[0];
               A33SatisfaccionResueltoNombre = H00282_A33SatisfaccionResueltoNombre[0];
               A8SatisfaccionResueltoId = H00282_A8SatisfaccionResueltoId[0];
               A94UsuarioRequerimiento = H00282_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H00282_A90UsuarioFecha[0];
               A93UsuarioNombre = H00282_A93UsuarioNombre[0];
               A15UsuarioId = H00282_A15UsuarioId[0];
               A14TicketId = H00282_A14TicketId[0];
               A32SatisfaccionFecha = H00282_A32SatisfaccionFecha[0];
               A7SatisfaccionId = H00282_A7SatisfaccionId[0];
               A31SatisfaccionAtencionNombre = H00282_A31SatisfaccionAtencionNombre[0];
               A38SatisfaccionTiempoNombre = H00282_A38SatisfaccionTiempoNombre[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H00282_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A35SatisfaccionTecnicoCompetenteNombre = H00282_A35SatisfaccionTecnicoCompetenteNombre[0];
               A33SatisfaccionResueltoNombre = H00282_A33SatisfaccionResueltoNombre[0];
               A15UsuarioId = H00282_A15UsuarioId[0];
               A94UsuarioRequerimiento = H00282_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H00282_A90UsuarioFecha[0];
               A93UsuarioNombre = H00282_A93UsuarioNombre[0];
               E25282 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 223;
            WB280( ) ;
         }
         bGXsfl_223_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes282( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SATISFACCIONID"+"_"+sGXsfl_223_idx, GetSecureSignedToken( sPrefix+sGXsfl_223_idx, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV67Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Uri, "")), context));
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
                                              AV37SatisfaccionFecha_To ,
                                              AV36SatisfaccionFecha_From ,
                                              AV40UsuarioFecha_To ,
                                              AV39UsuarioFecha_From ,
                                              AV41SatisfaccionResueltoNombre ,
                                              AV42SatisfaccionTecnicoCompetenteNombre ,
                                              AV43SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV44SatisfaccionTiempoNombre ,
                                              AV45SatisfaccionAtencionNombre ,
                                              AV50K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A7SatisfaccionId ,
                                              A14TicketId ,
                                              A15UsuarioId ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              A34SatisfaccionSugerencia ,
                                              AV51OrderedBy ,
                                              AV6SatisfaccionTecnicoProblemaId ,
                                              A9SatisfaccionTecnicoProblemaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV41SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionResueltoNombre), "%", "");
         lV42SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV43SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV44SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV44SatisfaccionTiempoNombre), "%", "");
         lV45SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV45SatisfaccionAtencionNombre), "%", "");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         lV50K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV50K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H00283 */
         pr_default.execute(1, new Object[] {AV6SatisfaccionTecnicoProblemaId, AV37SatisfaccionFecha_To, AV36SatisfaccionFecha_From, AV40UsuarioFecha_To, AV39UsuarioFecha_From, lV41SatisfaccionResueltoNombre, lV42SatisfaccionTecnicoCompetenteNombre, lV43SatisfaccionTecnicoProfesionalismoNombre, lV44SatisfaccionTiempoNombre, lV45SatisfaccionAtencionNombre, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField, lV50K2BToolsGenericSearchField});
         GRID_nRecordCount = H00283_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV70Pgmname = "EstadoSatisfaccionSatisfaccionWC1";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP280( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22282 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGS"), AV48FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV52GridOrders);
            /* Read saved values. */
            nRC_GXsfl_223 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_223"), ".", ","));
            AV49DeletedTag = cgiGet( sPrefix+"vDELETEDTAG");
            AV36SatisfaccionFecha_From = context.localUtil.CToD( cgiGet( sPrefix+"vSATISFACCIONFECHA_FROM"), 0);
            AV37SatisfaccionFecha_To = context.localUtil.CToD( cgiGet( sPrefix+"vSATISFACCIONFECHA_TO"), 0);
            AV39UsuarioFecha_From = context.localUtil.CToD( cgiGet( sPrefix+"vUSUARIOFECHA_FROM"), 0);
            AV40UsuarioFecha_To = context.localUtil.CToD( cgiGet( sPrefix+"vUSUARIOFECHA_TO"), 0);
            AV54UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SatisfaccionTecnicoProblemaId"), ".", ","));
            AV51OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vSATISFACCIONTECNICOPROBLEMAID"), ".", ","));
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
            AV50K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV50K2BToolsGenericSearchField", AV50K2BToolsGenericSearchField);
            AV41SatisfaccionResueltoNombre = cgiGet( edtavSatisfaccionresueltonombre_Internalname);
            AssignAttri(sPrefix, false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
            AV42SatisfaccionTecnicoCompetenteNombre = cgiGet( edtavSatisfacciontecnicocompetentenombre_Internalname);
            AssignAttri(sPrefix, false, "AV42SatisfaccionTecnicoCompetenteNombre", AV42SatisfaccionTecnicoCompetenteNombre);
            AV43SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtavSatisfacciontecnicoprofesionalismonombre_Internalname);
            AssignAttri(sPrefix, false, "AV43SatisfaccionTecnicoProfesionalismoNombre", AV43SatisfaccionTecnicoProfesionalismoNombre);
            AV44SatisfaccionTiempoNombre = cgiGet( edtavSatisfacciontiemponombre_Internalname);
            AssignAttri(sPrefix, false, "AV44SatisfaccionTiempoNombre", AV44SatisfaccionTiempoNombre);
            AV45SatisfaccionAtencionNombre = cgiGet( edtavSatisfaccionatencionnombre_Internalname);
            AssignAttri(sPrefix, false, "AV45SatisfaccionAtencionNombre", AV45SatisfaccionAtencionNombre);
            AV15Att_SatisfaccionId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
            AV16Att_SatisfaccionFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionfecha_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
            AV17Att_TicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
            AV18Att_UsuarioId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarioid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
            AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
            AV20Att_UsuarioFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariofecha_visible_Internalname));
            AssignAttri(sPrefix, false, "AV20Att_UsuarioFecha_Visible", AV20Att_UsuarioFecha_Visible);
            AV21Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri(sPrefix, false, "AV21Att_UsuarioRequerimiento_Visible", AV21Att_UsuarioRequerimiento_Visible);
            AV22Att_SatisfaccionResueltoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionresueltonombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV22Att_SatisfaccionResueltoNombre_Visible", AV22Att_SatisfaccionResueltoNombre_Visible);
            AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible);
            AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
            AV25Att_SatisfaccionTiempoNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfacciontiemponombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV25Att_SatisfaccionTiempoNombre_Visible", AV25Att_SatisfaccionTiempoNombre_Visible);
            AV26Att_SatisfaccionAtencionNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionatencionnombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV26Att_SatisfaccionAtencionNombre_Visible", AV26Att_SatisfaccionAtencionNombre_Visible);
            AV27Att_SatisfaccionSugerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_satisfaccionsugerencia_visible_Internalname));
            AssignAttri(sPrefix, false, "AV27Att_SatisfaccionSugerencia_Visible", AV27Att_SatisfaccionSugerencia_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV28GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
            AV12FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV50K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vSATISFACCIONFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV36SatisfaccionFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV39UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONRESUELTONOMBRE"), AV41SatisfaccionResueltoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV42SatisfaccionTecnicoCompetenteNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV43SatisfaccionTecnicoProfesionalismoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONTIEMPONOMBRE"), AV44SatisfaccionTiempoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSATISFACCIONATENCIONNOMBRE"), AV45SatisfaccionAtencionNombre) != 0 )
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
         E22282 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22282( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV35SatisfaccionFecha = DateTime.MinValue;
         AV36SatisfaccionFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri(sPrefix, false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
         AV37SatisfaccionFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
         AV38UsuarioFecha = DateTime.MinValue;
         AV39UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri(sPrefix, false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
         AV40UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
         AV41SatisfaccionResueltoNombre = "";
         AssignAttri(sPrefix, false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
         AV42SatisfaccionTecnicoCompetenteNombre = "";
         AssignAttri(sPrefix, false, "AV42SatisfaccionTecnicoCompetenteNombre", AV42SatisfaccionTecnicoCompetenteNombre);
         AV43SatisfaccionTecnicoProfesionalismoNombre = "";
         AssignAttri(sPrefix, false, "AV43SatisfaccionTecnicoProfesionalismoNombre", AV43SatisfaccionTecnicoProfesionalismoNombre);
         AV44SatisfaccionTiempoNombre = "";
         AssignAttri(sPrefix, false, "AV44SatisfaccionTiempoNombre", AV44SatisfaccionTiempoNombre);
         AV45SatisfaccionAtencionNombre = "";
         AssignAttri(sPrefix, false, "AV45SatisfaccionAtencionNombre", AV45SatisfaccionAtencionNombre);
         new k2bloadrowsperpage(context ).execute(  AV70Pgmname,  "Grid", out  AV29RowsPerPageVariable, out  AV30RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
         if ( ! AV30RowsPerPageLoaded )
         {
            AV29RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
         }
         AV28GridSettingsRowsPerPageVariable = AV29RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV29RowsPerPageVariable;
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
         AV52GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV53GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV53GridOrder.gxTpr_Ascendingorder = 0;
         AV53GridOrder.gxTpr_Descendingorder = 1;
         AV53GridOrder.gxTpr_Gridcolumnindex = 1;
         AV52GridOrders.Add(AV53GridOrder, 0);
         AV53GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV53GridOrder.gxTpr_Ascendingorder = 2;
         AV53GridOrder.gxTpr_Descendingorder = 3;
         AV53GridOrder.gxTpr_Gridcolumnindex = 2;
         AV52GridOrders.Add(AV53GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E23282( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV55Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV55Messages = GXt_objcol_SdtMessages_Message1;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV55Messages.Count )
         {
            AV56Message = ((GeneXus.Utils.SdtMessages_Message)AV55Messages.Item(AV71GXV1));
            GX_msglist.addItem(AV56Message.gxTpr_Description);
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV59ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV70Pgmname;
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV59ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV63Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update), true);
         AV72Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_223_Refreshing);
         AV64Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV64Delete))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV64Delete), true);
         AV73Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV64Delete))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV64Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_223_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV34ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV31GridStateKey = StringUtil.Str( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV70Pgmname,  AV31GridStateKey, out  AV32GridState) ;
         AV51OrderedBy = AV32GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV51OrderedBy", StringUtil.LTrimStr( (decimal)(AV51OrderedBy), 4, 0));
         AV54UC_OrderedBy = AV32GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV54UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV54UC_OrderedBy), 4, 0));
         AV74GXV2 = 1;
         while ( AV74GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV74GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:From") == 0 )
            {
               AV36SatisfaccionFecha_From = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:To") == 0 )
            {
               AV37SatisfaccionFecha_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV39UsuarioFecha_From = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV40UsuarioFecha_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionResueltoNombre") == 0 )
            {
               AV41SatisfaccionResueltoNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoCompetenteNombre") == 0 )
            {
               AV42SatisfaccionTecnicoCompetenteNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42SatisfaccionTecnicoCompetenteNombre", AV42SatisfaccionTecnicoCompetenteNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
            {
               AV43SatisfaccionTecnicoProfesionalismoNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43SatisfaccionTecnicoProfesionalismoNombre", AV43SatisfaccionTecnicoProfesionalismoNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTiempoNombre") == 0 )
            {
               AV44SatisfaccionTiempoNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV44SatisfaccionTiempoNombre", AV44SatisfaccionTiempoNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionAtencionNombre") == 0 )
            {
               AV45SatisfaccionAtencionNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV45SatisfaccionAtencionNombre", AV45SatisfaccionAtencionNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV50K2BToolsGenericSearchField = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV50K2BToolsGenericSearchField", AV50K2BToolsGenericSearchField);
            }
            AV74GXV2 = (int)(AV74GXV2+1);
         }
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV32GridState.gxTpr_Currentpage > 0 ) && ( AV32GridState.gxTpr_Currentpage <= AV10K2BMaxPages ) )
         {
            AV9CurrentPage = AV32GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_gotopage( AV9CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV31GridStateKey = StringUtil.Str( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV70Pgmname,  AV31GridStateKey, out  AV32GridState) ;
         AV32GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV32GridState.gxTpr_Orderedby = AV51OrderedBy;
         AV32GridState.gxTpr_Filtervalues.Clear();
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:From";
         AV33GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV36SatisfaccionFecha_From, "99/99/9999");
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:To";
         AV33GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV37SatisfaccionFecha_To, "99/99/9999");
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:From";
         AV33GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV39UsuarioFecha_From, "99/99/9999");
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:To";
         AV33GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV40UsuarioFecha_To, "99/99/9999");
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionResueltoNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV41SatisfaccionResueltoNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoCompetenteNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV42SatisfaccionTecnicoCompetenteNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoProfesionalismoNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV43SatisfaccionTecnicoProfesionalismoNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTiempoNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV44SatisfaccionTiempoNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "SatisfaccionAtencionNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV45SatisfaccionAtencionNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV33GridStateFilterValue.gxTpr_Value = AV50K2BToolsGenericSearchField;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV70Pgmname,  AV31GridStateKey,  AV32GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV57TrnContext = new SdtK2BTrnContext(context);
         AV57TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV57TrnContext.gxTpr_Returnmode = "Stack";
         AV57TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV57TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV57TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV57TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV57TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV57TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV58TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV58TrnContextAtt.gxTpr_Attributename = "SatisfaccionTecnicoProblemaId";
         AV58TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0);
         AV57TrnContext.gxTpr_Attributes.Add(AV58TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "Satisfaccion",  AV57TrnContext) ;
      }

      protected void E13282( )
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
         AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV15Att_SatisfaccionId_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
         edtSatisfaccionFecha_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV16Att_SatisfaccionFecha_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
         edtTicketId_Visible = 1;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV17Att_TicketId_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
         edtUsuarioId_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV18Att_UsuarioId_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV19Att_UsuarioNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
         edtUsuarioFecha_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV20Att_UsuarioFecha_Visible = true;
         AssignAttri(sPrefix, false, "AV20Att_UsuarioFecha_Visible", AV20Att_UsuarioFecha_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV21Att_UsuarioRequerimiento_Visible = true;
         AssignAttri(sPrefix, false, "AV21Att_UsuarioRequerimiento_Visible", AV21Att_UsuarioRequerimiento_Visible);
         edtSatisfaccionResueltoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV22Att_SatisfaccionResueltoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV22Att_SatisfaccionResueltoNombre_Visible", AV22Att_SatisfaccionResueltoNombre_Visible);
         edtSatisfaccionTecnicoCompetenteNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible);
         edtSatisfaccionTecnicoProfesionalismoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
         edtSatisfaccionTiempoNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV25Att_SatisfaccionTiempoNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV25Att_SatisfaccionTiempoNombre_Visible", AV25Att_SatisfaccionTiempoNombre_Visible);
         edtSatisfaccionAtencionNombre_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV26Att_SatisfaccionAtencionNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV26Att_SatisfaccionAtencionNombre_Visible", AV26Att_SatisfaccionAtencionNombre_Visible);
         edtSatisfaccionSugerencia_Visible = 1;
         AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Visible), 5, 0), !bGXsfl_223_Refreshing);
         AV27Att_SatisfaccionSugerencia_Visible = true;
         AssignAttri(sPrefix, false, "AV27Att_SatisfaccionSugerencia_Visible", AV27Att_SatisfaccionSugerencia_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV70Pgmname,  "Grid",  AV11GridConfiguration,  false) ;
         AV75GXV3 = 1;
         while ( AV75GXV3 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV75GXV3));
            if ( ! AV14GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
               {
                  edtSatisfaccionId_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV15Att_SatisfaccionId_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_SatisfaccionId_Visible", AV15Att_SatisfaccionId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
               {
                  edtSatisfaccionFecha_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV16Att_SatisfaccionFecha_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_SatisfaccionFecha_Visible", AV16Att_SatisfaccionFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  edtTicketId_Visible = 0;
                  AssignProp(sPrefix, false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV17Att_TicketId_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  edtUsuarioId_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV18Att_UsuarioId_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV19Att_UsuarioNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  edtUsuarioFecha_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV20Att_UsuarioFecha_Visible = false;
                  AssignAttri(sPrefix, false, "AV20Att_UsuarioFecha_Visible", AV20Att_UsuarioFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV21Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri(sPrefix, false, "AV21Att_UsuarioRequerimiento_Visible", AV21Att_UsuarioRequerimiento_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
               {
                  edtSatisfaccionResueltoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV22Att_SatisfaccionResueltoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV22Att_SatisfaccionResueltoNombre_Visible", AV22Att_SatisfaccionResueltoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
               {
                  edtSatisfaccionTecnicoCompetenteNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible", AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
               {
                  edtSatisfaccionTecnicoProfesionalismoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible", AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
               {
                  edtSatisfaccionTiempoNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV25Att_SatisfaccionTiempoNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV25Att_SatisfaccionTiempoNombre_Visible", AV25Att_SatisfaccionTiempoNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionAtencionNombre") == 0 )
               {
                  edtSatisfaccionAtencionNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV26Att_SatisfaccionAtencionNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV26Att_SatisfaccionAtencionNombre_Visible", AV26Att_SatisfaccionAtencionNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
               {
                  edtSatisfaccionSugerencia_Visible = 0;
                  AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Visible), 5, 0), !bGXsfl_223_Refreshing);
                  AV27Att_SatisfaccionSugerencia_Visible = false;
                  AssignAttri(sPrefix, false, "AV27Att_SatisfaccionSugerencia_Visible", AV27Att_SatisfaccionSugerencia_Visible);
               }
            }
            AV75GXV3 = (int)(AV75GXV3+1);
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
         AV14GridColumn.gxTpr_Attributename = "TicketId";
         AV14GridColumn.gxTpr_Columntitle = "RST No.";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioId";
         AV14GridColumn.gxTpr_Columntitle = "Id Usuario";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV14GridColumn.gxTpr_Columntitle = "Usuario";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV14GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV14GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "SatisfaccionResueltoNombre";
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
         AV59ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportEstadoSatisfaccionSatisfaccionWC1";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportEstadoSatisfaccionSatisfaccionWC1";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV59ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV59ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV59ActivityList.Add(AV61ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV59ActivityList) ;
         AV62SatisfaccionFecha_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV62SatisfaccionFecha_IsAuthorized", AV62SatisfaccionFecha_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_223_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_223_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV59ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_223_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_223_Refreshing);
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

      protected void E24282( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV34ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV63Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update), true);
         AV72Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.convertURL( context.PathToRelativeUrl( AV63Update))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV63Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_223_Refreshing);
         AV64Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV64Delete))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV64Delete), true);
         AV73Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV64Delete))), !bGXsfl_223_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV64Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_223_Refreshing);
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
         AV60AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV61ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoSatisfaccion";
         AV60AutoLinksActivityList.Add(AV61ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV60AutoLinksActivityList) ;
         AV54UC_OrderedBy = AV51OrderedBy;
         AssignAttri(sPrefix, false, "AV54UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV54UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV34ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV60AutoLinksActivityList", AV60AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48FilterTags", AV48FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
      }

      private void E25282( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(4)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(5)).gxTpr_Isauthorized )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV60AutoLinksActivityList.Item(6)).gxTpr_Isauthorized )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         if ( AV62SatisfaccionFecha_IsAuthorized )
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
            wbStart = 223;
         }
         sendrow_2232( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_223_Refreshing )
         {
            context.DoAjaxLoad(223, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV46K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) || ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionFecha";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Encuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV47K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36SatisfaccionFecha_From ) ;
            AV47K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37SatisfaccionFecha_To ) ;
            AV47K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) || ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Fecha";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV47K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39UsuarioFecha_From ) ;
            AV47K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40UsuarioFecha_To ) ;
            AV47K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionResueltoNombre)) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionResueltoNombre";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV47K2BFilterValuesSDTItem.gxTpr_Value = AV41SatisfaccionResueltoNombre;
            AV47K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV41SatisfaccionResueltoNombre;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTecnicoCompetenteNombre)) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoCompetenteNombre";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV47K2BFilterValuesSDTItem.gxTpr_Value = AV42SatisfaccionTecnicoCompetenteNombre;
            AV47K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV42SatisfaccionTecnicoCompetenteNombre;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoProfesionalismoNombre";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV47K2BFilterValuesSDTItem.gxTpr_Value = AV43SatisfaccionTecnicoProfesionalismoNombre;
            AV47K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV43SatisfaccionTecnicoProfesionalismoNombre;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SatisfaccionTiempoNombre)) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTiempoNombre";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV47K2BFilterValuesSDTItem.gxTpr_Value = AV44SatisfaccionTiempoNombre;
            AV47K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV44SatisfaccionTiempoNombre;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SatisfaccionAtencionNombre)) )
         {
            AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV47K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionAtencionNombre";
            AV47K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV47K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV47K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV47K2BFilterValuesSDTItem.gxTpr_Value = AV45SatisfaccionAtencionNombre;
            AV47K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV45SatisfaccionAtencionNombre;
            AV46K2BFilterValuesSDT.Add(AV47K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, sPrefix, false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV46K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV48FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV70Pgmname,  "Grid",  AV46K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV48FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E11282( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionFecha") == 0 )
         {
            AV36SatisfaccionFecha_From = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
            AV37SatisfaccionFecha_To = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "UsuarioFecha") == 0 )
         {
            AV39UsuarioFecha_From = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
            AV40UsuarioFecha_To = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionResueltoNombre") == 0 )
         {
            AV41SatisfaccionResueltoNombre = "";
            AssignAttri(sPrefix, false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionTecnicoCompetenteNombre") == 0 )
         {
            AV42SatisfaccionTecnicoCompetenteNombre = "";
            AssignAttri(sPrefix, false, "AV42SatisfaccionTecnicoCompetenteNombre", AV42SatisfaccionTecnicoCompetenteNombre);
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
         {
            AV43SatisfaccionTecnicoProfesionalismoNombre = "";
            AssignAttri(sPrefix, false, "AV43SatisfaccionTecnicoProfesionalismoNombre", AV43SatisfaccionTecnicoProfesionalismoNombre);
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionTiempoNombre") == 0 )
         {
            AV44SatisfaccionTiempoNombre = "";
            AssignAttri(sPrefix, false, "AV44SatisfaccionTiempoNombre", AV44SatisfaccionTiempoNombre);
         }
         else if ( StringUtil.StrCmp(AV49DeletedTag, "SatisfaccionAtencionNombre") == 0 )
         {
            AV45SatisfaccionAtencionNombre = "";
            AssignAttri(sPrefix, false, "AV45SatisfaccionAtencionNombre", AV45SatisfaccionAtencionNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E12282( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV51OrderedBy = AV54UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV51OrderedBy", StringUtil.LTrimStr( (decimal)(AV51OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E14282( )
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
         new k2bloadgridconfiguration(context ).execute(  AV70Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         AV76GXV4 = 1;
         while ( AV76GXV4 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV76GXV4));
            if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV15Att_SatisfaccionId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV16Att_SatisfaccionFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV17Att_TicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV18Att_UsuarioId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV19Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV20Att_UsuarioFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV21Att_UsuarioRequerimiento_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV22Att_SatisfaccionResueltoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV25Att_SatisfaccionTiempoNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionAtencionNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV26Att_SatisfaccionAtencionNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV27Att_SatisfaccionSugerencia_Visible;
            }
            AV76GXV4 = (int)(AV76GXV4+1);
         }
         AV11GridConfiguration.gxTpr_Freezecolumntitles = AV12FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV70Pgmname,  "Grid",  AV11GridConfiguration,  true) ;
         AV54UC_OrderedBy = AV51OrderedBy;
         AssignAttri(sPrefix, false, "AV54UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV54UC_OrderedBy), 4, 0));
         if ( AV29RowsPerPageVariable != AV28GridSettingsRowsPerPageVariable )
         {
            AV29RowsPerPageVariable = AV28GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV29RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV70Pgmname,  "Grid",  AV29RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV50K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoCompetenteNombre, AV43SatisfaccionTecnicoProfesionalismoNombre, AV44SatisfaccionTiempoNombre, AV45SatisfaccionAtencionNombre, AV6SatisfaccionTecnicoProblemaId, AV34ClassCollection, AV51OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV70Pgmname, AV9CurrentPage, AV11GridConfiguration, AV60AutoLinksActivityList, AV62SatisfaccionFecha_IsAuthorized, AV15Att_SatisfaccionId_Visible, AV16Att_SatisfaccionFecha_Visible, AV17Att_TicketId_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioFecha_Visible, AV21Att_UsuarioRequerimiento_Visible, AV22Att_SatisfaccionResueltoNombre_Visible, AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible, AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible, AV25Att_SatisfaccionTiempoNombre_Visible, AV26Att_SatisfaccionAtencionNombre_Visible, AV27Att_SatisfaccionSugerencia_Visible, AV12FreezeColumnTitles, AV67Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
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

      protected void E15282( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E16282( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E17282( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E18282( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34ClassCollection", AV34ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV70Pgmname,  "Grid", ref  AV11GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV34ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV34ClassCollection) ;
         }
      }

      protected void E19282( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "ExportEstadoSatisfaccionSatisfaccionWC1") )
         {
            new exportestadosatisfaccionsatisfaccionwc1(context ).execute(  AV6SatisfaccionTecnicoProblemaId,  AV36SatisfaccionFecha_From,  AV37SatisfaccionFecha_To,  AV39UsuarioFecha_From,  AV40UsuarioFecha_To,  AV41SatisfaccionResueltoNombre,  AV42SatisfaccionTecnicoCompetenteNombre,  AV43SatisfaccionTecnicoProfesionalismoNombre,  AV44SatisfaccionTiempoNombre,  AV45SatisfaccionAtencionNombre,  AV50K2BToolsGenericSearchField,  AV51OrderedBy, out  AV65OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV65OutFile, out  AV67Uri) )
            {
               CallWebObject(formatLink(AV67Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV66Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV66Guid.ToString(),  AV65OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV66Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E20282( )
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

      protected void E21282( )
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

      protected void wb_table2_246_282( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_246_282e( true) ;
         }
         else
         {
            wb_table2_246_282e( false) ;
         }
      }

      protected void wb_table1_77_282( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e26281_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionid_visible_Internalname, StringUtil.BoolToStr( AV15Att_SatisfaccionId_Visible), "", "Id", 1, chkavAtt_satisfaccionid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(106, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,106);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionfecha_visible_Internalname, StringUtil.BoolToStr( AV16Att_SatisfaccionFecha_Visible), "", "Fecha Encuesta:", 1, chkavAtt_satisfaccionfecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
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
            GxWebStd.gx_div_start( context, divTicketid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketid_visible_Internalname, "RST No.", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketid_visible_Internalname, StringUtil.BoolToStr( AV17Att_TicketId_Visible), "", "RST No.", 1, chkavAtt_ticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
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
            GxWebStd.gx_div_start( context, divUsuarioid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuarioid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuarioid_visible_Internalname, "Id Usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarioid_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioId_Visible), "", "Id Usuario", 1, chkavAtt_usuarioid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(124, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,124);\"");
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
            GxWebStd.gx_div_start( context, divUsuarionombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuarionombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuarionombre_visible_Internalname, "Usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioNombre_Visible), "", "Usuario", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariofecha_visible_Internalname, StringUtil.BoolToStr( AV20Att_UsuarioFecha_Visible), "", "Fecha Inicio:", 1, chkavAtt_usuariofecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(136, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,136);\"");
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
            GxWebStd.gx_div_start( context, divUsuariorequerimiento_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariorequerimiento_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariorequerimiento_visible_Internalname, "Requerimiento", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV21Att_UsuarioRequerimiento_Visible), "", "Requerimiento", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionresueltonombre_visible_Internalname, StringUtil.BoolToStr( AV22Att_SatisfaccionResueltoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfaccionresueltonombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(148, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,148);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontecnicocompetentenombre_visible_Internalname, StringUtil.BoolToStr( AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontecnicocompetentenombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(154, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,154);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible_Internalname, StringUtil.BoolToStr( AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontecnicoprofesionalismonombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfacciontiemponombre_visible_Internalname, StringUtil.BoolToStr( AV25Att_SatisfaccionTiempoNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfacciontiemponombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(166, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,166);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionatencionnombre_visible_Internalname, StringUtil.BoolToStr( AV26Att_SatisfaccionAtencionNombre_Visible), "", "Respuesta:", 1, chkavAtt_satisfaccionatencionnombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(172, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,172);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_satisfaccionsugerencia_visible_Internalname, StringUtil.BoolToStr( AV27Att_SatisfaccionSugerencia_Visible), "", "Sugerencia:", 1, chkavAtt_satisfaccionsugerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(178, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,178);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "", true, 1, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'" + sGXsfl_223_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV12FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(190, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,190);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(223), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e27281_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
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
            wb_table3_204_282( true) ;
         }
         else
         {
            wb_table3_204_282( false) ;
         }
         return  ;
      }

      protected void wb_table3_204_282e( bool wbgen )
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
            wb_table4_211_282( true) ;
         }
         else
         {
            wb_table4_211_282( false) ;
         }
         return  ;
      }

      protected void wb_table4_211_282e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_77_282e( true) ;
         }
         else
         {
            wb_table1_77_282e( false) ;
         }
      }

      protected void wb_table4_211_282( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(223), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_211_282e( true) ;
         }
         else
         {
            wb_table4_211_282e( false) ;
         }
      }

      protected void wb_table3_204_282( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(223), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e28281_client"+"'", TempTags, "", 2, "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(223), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoSatisfaccionSatisfaccionWC1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_204_282e( true) ;
         }
         else
         {
            wb_table3_204_282e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6SatisfaccionTecnicoProblemaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0));
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
         PA282( ) ;
         WS282( ) ;
         WE282( ) ;
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
         sCtrlAV6SatisfaccionTecnicoProblemaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA282( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "estadosatisfaccionsatisfaccionwc1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA282( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6SatisfaccionTecnicoProblemaId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0));
         }
         wcpOAV6SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SatisfaccionTecnicoProblemaId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6SatisfaccionTecnicoProblemaId != wcpOAV6SatisfaccionTecnicoProblemaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6SatisfaccionTecnicoProblemaId = AV6SatisfaccionTecnicoProblemaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6SatisfaccionTecnicoProblemaId = cgiGet( sPrefix+"AV6SatisfaccionTecnicoProblemaId_CTRL");
         if ( StringUtil.Len( sCtrlAV6SatisfaccionTecnicoProblemaId) > 0 )
         {
            AV6SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV6SatisfaccionTecnicoProblemaId), ".", ","));
            AssignAttri(sPrefix, false, "AV6SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0));
         }
         else
         {
            AV6SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV6SatisfaccionTecnicoProblemaId_PARM"), ".", ","));
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
         PA282( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS282( ) ;
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
         WS282( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6SatisfaccionTecnicoProblemaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6SatisfaccionTecnicoProblemaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6SatisfaccionTecnicoProblemaId_CTRL", StringUtil.RTrim( sCtrlAV6SatisfaccionTecnicoProblemaId));
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
            WE282( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188345553", true, true);
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
         context.AddJavascriptSource("estadosatisfaccionsatisfaccionwc1.js", "?2024188345555", false, true);
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

      protected void SubsflControlProps_2232( )
      {
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID_"+sGXsfl_223_idx;
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA_"+sGXsfl_223_idx;
         edtTicketId_Internalname = sPrefix+"TICKETID_"+sGXsfl_223_idx;
         edtUsuarioId_Internalname = sPrefix+"USUARIOID_"+sGXsfl_223_idx;
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE_"+sGXsfl_223_idx;
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA_"+sGXsfl_223_idx;
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO_"+sGXsfl_223_idx;
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID_"+sGXsfl_223_idx;
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_"+sGXsfl_223_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_223_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_223_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_223_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_223_idx;
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID_"+sGXsfl_223_idx;
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE_"+sGXsfl_223_idx;
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID_"+sGXsfl_223_idx;
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE_"+sGXsfl_223_idx;
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA_"+sGXsfl_223_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_223_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_223_idx;
      }

      protected void SubsflControlProps_fel_2232( )
      {
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA_"+sGXsfl_223_fel_idx;
         edtTicketId_Internalname = sPrefix+"TICKETID_"+sGXsfl_223_fel_idx;
         edtUsuarioId_Internalname = sPrefix+"USUARIOID_"+sGXsfl_223_fel_idx;
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE_"+sGXsfl_223_fel_idx;
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA_"+sGXsfl_223_fel_idx;
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO_"+sGXsfl_223_fel_idx;
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE_"+sGXsfl_223_fel_idx;
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID_"+sGXsfl_223_fel_idx;
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE_"+sGXsfl_223_fel_idx;
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA_"+sGXsfl_223_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_223_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_223_fel_idx;
      }

      protected void sendrow_2232( )
      {
         SubsflControlProps_2232( ) ;
         WB280( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_223_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_223_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_223_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtSatisfaccionId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtSatisfaccionFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionFecha_Internalname,context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"),context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionFecha_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtSatisfaccionFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionResueltoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoNombre_Internalname,(string)A33SatisfaccionResueltoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionResueltoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionResueltoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTecnicoCompetenteNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteNombre_Internalname,(string)A35SatisfaccionTecnicoCompetenteNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTecnicoCompetenteNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTecnicoCompetenteNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTecnicoProfesionalismoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoNombre_Internalname,(string)A37SatisfaccionTecnicoProfesionalismoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTecnicoProfesionalismoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12SatisfaccionTiempoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionTiempoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoNombre_Internalname,(string)A38SatisfaccionTiempoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionTiempoNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionTiempoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SatisfaccionAtencionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionAtencionNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionNombre_Internalname,(string)A31SatisfaccionAtencionNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionAtencionNombre_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionAtencionNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtSatisfaccionSugerencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionSugerencia_Internalname,(string)A34SatisfaccionSugerencia,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionSugerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtSatisfaccionSugerencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)223,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV63Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV63Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV72Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV63Update)) ? AV72Update_GXI : context.PathToRelativeUrl( AV63Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV63Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV64Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV73Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV64Delete)) ? AV73Delete_GXI : context.PathToRelativeUrl( AV64Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV64Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes282( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_223_idx = ((subGrid_Islastpage==1)&&(nGXsfl_223_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_223_idx+1);
            sGXsfl_223_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_223_idx), 4, 0), 4, "0");
            SubsflControlProps_2232( ) ;
         }
         /* End function sendrow_2232 */
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
         chkavAtt_ticketid_visible.Name = "vATT_TICKETID_VISIBLE";
         chkavAtt_ticketid_visible.WebTags = "";
         chkavAtt_ticketid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketid_visible_Internalname, "TitleCaption", chkavAtt_ticketid_visible.Caption, true);
         chkavAtt_ticketid_visible.CheckedValue = "false";
         chkavAtt_usuarioid_visible.Name = "vATT_USUARIOID_VISIBLE";
         chkavAtt_usuarioid_visible.WebTags = "";
         chkavAtt_usuarioid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuarioid_visible_Internalname, "TitleCaption", chkavAtt_usuarioid_visible.Caption, true);
         chkavAtt_usuarioid_visible.CheckedValue = "false";
         chkavAtt_usuarionombre_visible.Name = "vATT_USUARIONOMBRE_VISIBLE";
         chkavAtt_usuarionombre_visible.WebTags = "";
         chkavAtt_usuarionombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuarionombre_visible_Internalname, "TitleCaption", chkavAtt_usuarionombre_visible.Caption, true);
         chkavAtt_usuarionombre_visible.CheckedValue = "false";
         chkavAtt_usuariofecha_visible.Name = "vATT_USUARIOFECHA_VISIBLE";
         chkavAtt_usuariofecha_visible.WebTags = "";
         chkavAtt_usuariofecha_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariofecha_visible_Internalname, "TitleCaption", chkavAtt_usuariofecha_visible.Caption, true);
         chkavAtt_usuariofecha_visible.CheckedValue = "false";
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         chkavAtt_satisfaccionresueltonombre_visible.Name = "vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE";
         chkavAtt_satisfaccionresueltonombre_visible.WebTags = "";
         chkavAtt_satisfaccionresueltonombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_satisfaccionresueltonombre_visible_Internalname, "TitleCaption", chkavAtt_satisfaccionresueltonombre_visible.Caption, true);
         chkavAtt_satisfaccionresueltonombre_visible.CheckedValue = "false";
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
         chkavAtt_ticketid_visible_Internalname = sPrefix+"vATT_TICKETID_VISIBLE";
         divTicketid_gridsettingscontainer_Internalname = sPrefix+"TICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarioid_visible_Internalname = sPrefix+"vATT_USUARIOID_VISIBLE";
         divUsuarioid_gridsettingscontainer_Internalname = sPrefix+"USUARIOID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = sPrefix+"vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = sPrefix+"USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariofecha_visible_Internalname = sPrefix+"vATT_USUARIOFECHA_VISIBLE";
         divUsuariofecha_gridsettingscontainer_Internalname = sPrefix+"USUARIOFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = sPrefix+"vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = sPrefix+"USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_satisfaccionresueltonombre_visible_Internalname = sPrefix+"vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE";
         divSatisfaccionresueltonombre_gridsettingscontainer_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE_GRIDSETTINGSCONTAINER";
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
         edtTicketId_Internalname = sPrefix+"TICKETID";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID";
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE";
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
         chkavAtt_satisfaccionresueltonombre_visible.Caption = "Respuesta:";
         chkavAtt_usuariorequerimiento_visible.Caption = "Requerimiento";
         chkavAtt_usuariofecha_visible.Caption = "Fecha Inicio:";
         chkavAtt_usuarionombre_visible.Caption = "Usuario";
         chkavAtt_usuarioid_visible.Caption = "Id Usuario";
         chkavAtt_ticketid_visible.Caption = "RST No.";
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
         edtSatisfaccionResueltoNombre_Jsonclick = "";
         edtSatisfaccionResueltoId_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
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
         chkavAtt_satisfaccionresueltonombre_visible.Enabled = 1;
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuariofecha_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
         chkavAtt_usuarioid_visible.Enabled = 1;
         chkavAtt_ticketid_visible.Enabled = 1;
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
         edtSatisfaccionResueltoNombre_Link = "";
         edtUsuarioNombre_Link = "";
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
         edtSatisfaccionResueltoNombre_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioFecha_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtUsuarioId_Visible = -1;
         edtTicketId_Visible = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E13282',iparms:[{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E28281',iparms:[{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E24282',iparms:[{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV54UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV48FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E25282',iparms:[{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A8SatisfaccionResueltoId',fld:'SATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'A10SatisfaccionTecnicoCompetenteId',fld:'SATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'A11SatisfaccionTecnicoProfesionalismoId',fld:'SATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'A12SatisfaccionTiempoId',fld:'SATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'A13SatisfaccionAtencionId',fld:'SATISFACCIONATENCIONID',pic:'ZZZ9'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtSatisfaccionResueltoNombre_Link',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Link'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Link',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Link'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Link',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Link'},{av:'edtSatisfaccionTiempoNombre_Link',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Link'},{av:'edtSatisfaccionAtencionNombre_Link',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Link'},{av:'edtSatisfaccionFecha_Link',ctrl:'SATISFACCIONFECHA',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E11282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV49DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E12282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV54UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E26281',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E14282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV29RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV28GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV29RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E15282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E16282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E17282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E18282',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV70Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV60AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV63Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV64Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV62SatisfaccionFecha_IsAuthorized',fld:'vSATISFACCIONFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtSatisfaccionId_Visible',ctrl:'SATISFACCIONID',prop:'Visible'},{av:'edtSatisfaccionFecha_Visible',ctrl:'SATISFACCIONFECHA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtSatisfaccionResueltoNombre_Visible',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Visible',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Visible'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Visible',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Visible'},{av:'edtSatisfaccionTiempoNombre_Visible',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Visible'},{av:'edtSatisfaccionAtencionNombre_Visible',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Visible'},{av:'edtSatisfaccionSugerencia_Visible',ctrl:'SATISFACCIONSUGERENCIA',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E19282',iparms:[{av:'AV6SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV44SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV45SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV50K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV51OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV67Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E27281',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E20282',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E21282',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID","{handler:'Valid_Satisfaccionresueltoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID","{handler:'Valid_Satisfacciontecnicocompetenteid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID","{handler:'Valid_Satisfacciontecnicoprofesionalismoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID","{handler:'Valid_Satisfacciontiempoid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONATENCIONID","{handler:'Valid_Satisfaccionatencionid',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONATENCIONID",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Att_SatisfaccionId_Visible',fld:'vATT_SATISFACCIONID_VISIBLE',pic:''},{av:'AV16Att_SatisfaccionFecha_Visible',fld:'vATT_SATISFACCIONFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV21Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV22Att_SatisfaccionResueltoNombre_Visible',fld:'vATT_SATISFACCIONRESUELTONOMBRE_VISIBLE',pic:''},{av:'AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible',fld:'vATT_SATISFACCIONTECNICOCOMPETENTENOMBRE_VISIBLE',pic:''},{av:'AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible',fld:'vATT_SATISFACCIONTECNICOPROFESIONALISMONOMBRE_VISIBLE',pic:''},{av:'AV25Att_SatisfaccionTiempoNombre_Visible',fld:'vATT_SATISFACCIONTIEMPONOMBRE_VISIBLE',pic:''},{av:'AV26Att_SatisfaccionAtencionNombre_Visible',fld:'vATT_SATISFACCIONATENCIONNOMBRE_VISIBLE',pic:''},{av:'AV27Att_SatisfaccionSugerencia_Visible',fld:'vATT_SATISFACCIONSUGERENCIA_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV50K2BToolsGenericSearchField = "";
         AV36SatisfaccionFecha_From = DateTime.MinValue;
         AV39UsuarioFecha_From = DateTime.MinValue;
         AV41SatisfaccionResueltoNombre = "";
         AV42SatisfaccionTecnicoCompetenteNombre = "";
         AV43SatisfaccionTecnicoProfesionalismoNombre = "";
         AV44SatisfaccionTiempoNombre = "";
         AV45SatisfaccionAtencionNombre = "";
         AV34ClassCollection = new GxSimpleCollection<string>();
         AV37SatisfaccionFecha_To = DateTime.MinValue;
         AV40UsuarioFecha_To = DateTime.MinValue;
         AV70Pgmname = "";
         AV11GridConfiguration = new SdtK2BGridConfiguration(context);
         AV60AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV67Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV48FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV49DeletedTag = "";
         AV52GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A94UsuarioRequerimiento = "";
         A33SatisfaccionResueltoNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A34SatisfaccionSugerencia = "";
         AV63Update = "";
         AV64Delete = "";
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
         AV72Update_GXI = "";
         AV73Delete_GXI = "";
         scmdbuf = "";
         lV41SatisfaccionResueltoNombre = "";
         lV42SatisfaccionTecnicoCompetenteNombre = "";
         lV43SatisfaccionTecnicoProfesionalismoNombre = "";
         lV44SatisfaccionTiempoNombre = "";
         lV45SatisfaccionAtencionNombre = "";
         lV50K2BToolsGenericSearchField = "";
         H00282_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         H00282_A34SatisfaccionSugerencia = new string[] {""} ;
         H00282_n34SatisfaccionSugerencia = new bool[] {false} ;
         H00282_A31SatisfaccionAtencionNombre = new string[] {""} ;
         H00282_A13SatisfaccionAtencionId = new short[1] ;
         H00282_A38SatisfaccionTiempoNombre = new string[] {""} ;
         H00282_A12SatisfaccionTiempoId = new short[1] ;
         H00282_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         H00282_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         H00282_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         H00282_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         H00282_A33SatisfaccionResueltoNombre = new string[] {""} ;
         H00282_A8SatisfaccionResueltoId = new short[1] ;
         H00282_A94UsuarioRequerimiento = new string[] {""} ;
         H00282_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H00282_A93UsuarioNombre = new string[] {""} ;
         H00282_A15UsuarioId = new long[1] ;
         H00282_A14TicketId = new long[1] ;
         H00282_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         H00282_A7SatisfaccionId = new long[1] ;
         H00283_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV35SatisfaccionFecha = DateTime.MinValue;
         AV38UsuarioFecha = DateTime.MinValue;
         AV53GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV55Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV56Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV59ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV61ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV31GridStateKey = "";
         AV32GridState = new SdtK2BGridState(context);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV57TrnContext = new SdtK2BTrnContext(context);
         AV58TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV46K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV47K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV65OutFile = "";
         AV66Guid = (Guid)(Guid.Empty);
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
         sCtrlAV6SatisfaccionTecnicoProblemaId = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosatisfaccionsatisfaccionwc1__default(),
            new Object[][] {
                new Object[] {
               H00282_A9SatisfaccionTecnicoProblemaId, H00282_A34SatisfaccionSugerencia, H00282_n34SatisfaccionSugerencia, H00282_A31SatisfaccionAtencionNombre, H00282_A13SatisfaccionAtencionId, H00282_A38SatisfaccionTiempoNombre, H00282_A12SatisfaccionTiempoId, H00282_A37SatisfaccionTecnicoProfesionalismoNombre, H00282_A11SatisfaccionTecnicoProfesionalismoId, H00282_A35SatisfaccionTecnicoCompetenteNombre,
               H00282_A10SatisfaccionTecnicoCompetenteId, H00282_A33SatisfaccionResueltoNombre, H00282_A8SatisfaccionResueltoId, H00282_A94UsuarioRequerimiento, H00282_A90UsuarioFecha, H00282_A93UsuarioNombre, H00282_A15UsuarioId, H00282_A14TicketId, H00282_A32SatisfaccionFecha, H00282_A7SatisfaccionId
               }
               , new Object[] {
               H00283_AGRID_nRecordCount
               }
            }
         );
         AV70Pgmname = "EstadoSatisfaccionSatisfaccionWC1";
         /* GeneXus formulas. */
         AV70Pgmname = "EstadoSatisfaccionSatisfaccionWC1";
         context.Gx_err = 0;
      }

      private short AV6SatisfaccionTecnicoProblemaId ;
      private short wcpOAV6SatisfaccionTecnicoProblemaId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV51OrderedBy ;
      private short initialized ;
      private short AV54UC_OrderedBy ;
      private short AV29RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A8SatisfaccionResueltoId ;
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
      private short AV28GridSettingsRowsPerPageVariable ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_223 ;
      private int nGXsfl_223_idx=1 ;
      private int subGrid_Rows ;
      private int AV9CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavSatisfaccionresueltonombre_Enabled ;
      private int edtavSatisfacciontecnicocompetentenombre_Enabled ;
      private int edtavSatisfacciontecnicoprofesionalismonombre_Enabled ;
      private int edtavSatisfacciontiemponombre_Enabled ;
      private int edtavSatisfaccionatencionnombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtSatisfaccionId_Visible ;
      private int edtSatisfaccionFecha_Visible ;
      private int edtTicketId_Visible ;
      private int edtUsuarioId_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioFecha_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
      private int edtSatisfaccionResueltoNombre_Visible ;
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
      private int AV71GXV1 ;
      private int AV74GXV2 ;
      private int AV10K2BMaxPages ;
      private int AV75GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV76GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_223_idx="0001" ;
      private string AV50K2BToolsGenericSearchField ;
      private string AV70Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV49DeletedTag ;
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
      private string edtUsuarioNombre_Link ;
      private string edtSatisfaccionResueltoNombre_Link ;
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
      private string edtTicketId_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtSatisfaccionResueltoId_Internalname ;
      private string edtSatisfaccionResueltoNombre_Internalname ;
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
      private string lV50K2BToolsGenericSearchField ;
      private string chkavAtt_satisfaccionid_visible_Internalname ;
      private string chkavAtt_satisfaccionfecha_visible_Internalname ;
      private string chkavAtt_ticketid_visible_Internalname ;
      private string chkavAtt_usuarioid_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariofecha_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
      private string chkavAtt_satisfaccionresueltonombre_visible_Internalname ;
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
      private string divTicketid_gridsettingscontainer_Internalname ;
      private string divUsuarioid_gridsettingscontainer_Internalname ;
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariofecha_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
      private string divSatisfaccionresueltonombre_gridsettingscontainer_Internalname ;
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
      private string sCtrlAV6SatisfaccionTecnicoProblemaId ;
      private string sGXsfl_223_fel_idx="0001" ;
      private string ROClassString ;
      private string edtSatisfaccionId_Jsonclick ;
      private string edtSatisfaccionFecha_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtSatisfaccionResueltoId_Jsonclick ;
      private string edtSatisfaccionResueltoNombre_Jsonclick ;
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
      private DateTime AV36SatisfaccionFecha_From ;
      private DateTime AV39UsuarioFecha_From ;
      private DateTime AV37SatisfaccionFecha_To ;
      private DateTime AV40UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime AV35SatisfaccionFecha ;
      private DateTime AV38UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV62SatisfaccionFecha_IsAuthorized ;
      private bool AV15Att_SatisfaccionId_Visible ;
      private bool AV16Att_SatisfaccionFecha_Visible ;
      private bool AV17Att_TicketId_Visible ;
      private bool AV18Att_UsuarioId_Visible ;
      private bool AV19Att_UsuarioNombre_Visible ;
      private bool AV20Att_UsuarioFecha_Visible ;
      private bool AV21Att_UsuarioRequerimiento_Visible ;
      private bool AV22Att_SatisfaccionResueltoNombre_Visible ;
      private bool AV23Att_SatisfaccionTecnicoCompetenteNombre_Visible ;
      private bool AV24Att_SatisfaccionTecnicoProfesionalismoNombre_Visible ;
      private bool AV25Att_SatisfaccionTiempoNombre_Visible ;
      private bool AV26Att_SatisfaccionAtencionNombre_Visible ;
      private bool AV27Att_SatisfaccionSugerencia_Visible ;
      private bool AV12FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n34SatisfaccionSugerencia ;
      private bool bGXsfl_223_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV30RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV63Update_IsBlob ;
      private bool AV64Delete_IsBlob ;
      private string AV41SatisfaccionResueltoNombre ;
      private string AV42SatisfaccionTecnicoCompetenteNombre ;
      private string AV43SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV44SatisfaccionTiempoNombre ;
      private string AV45SatisfaccionAtencionNombre ;
      private string AV67Uri ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A33SatisfaccionResueltoNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A34SatisfaccionSugerencia ;
      private string AV72Update_GXI ;
      private string AV73Delete_GXI ;
      private string lV41SatisfaccionResueltoNombre ;
      private string lV42SatisfaccionTecnicoCompetenteNombre ;
      private string lV43SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV44SatisfaccionTiempoNombre ;
      private string lV45SatisfaccionAtencionNombre ;
      private string AV31GridStateKey ;
      private string AV65OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV63Update ;
      private string AV64Delete ;
      private Guid AV66Guid ;
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
      private GXCheckbox chkavAtt_ticketid_visible ;
      private GXCheckbox chkavAtt_usuarioid_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariofecha_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCheckbox chkavAtt_satisfaccionresueltonombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontecnicocompetentenombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontecnicoprofesionalismonombre_visible ;
      private GXCheckbox chkavAtt_satisfacciontiemponombre_visible ;
      private GXCheckbox chkavAtt_satisfaccionatencionnombre_visible ;
      private GXCheckbox chkavAtt_satisfaccionsugerencia_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private short[] H00282_A9SatisfaccionTecnicoProblemaId ;
      private string[] H00282_A34SatisfaccionSugerencia ;
      private bool[] H00282_n34SatisfaccionSugerencia ;
      private string[] H00282_A31SatisfaccionAtencionNombre ;
      private short[] H00282_A13SatisfaccionAtencionId ;
      private string[] H00282_A38SatisfaccionTiempoNombre ;
      private short[] H00282_A12SatisfaccionTiempoId ;
      private string[] H00282_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] H00282_A11SatisfaccionTecnicoProfesionalismoId ;
      private string[] H00282_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] H00282_A10SatisfaccionTecnicoCompetenteId ;
      private string[] H00282_A33SatisfaccionResueltoNombre ;
      private short[] H00282_A8SatisfaccionResueltoId ;
      private string[] H00282_A94UsuarioRequerimiento ;
      private DateTime[] H00282_A90UsuarioFecha ;
      private string[] H00282_A93UsuarioNombre ;
      private long[] H00282_A15UsuarioId ;
      private long[] H00282_A14TicketId ;
      private DateTime[] H00282_A32SatisfaccionFecha ;
      private long[] H00282_A7SatisfaccionId ;
      private long[] H00283_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV34ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV46K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV48FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV52GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV60AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV59ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV11GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV14GridColumn ;
      private SdtK2BGridState AV32GridState ;
      private SdtK2BGridState_FilterValue AV33GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV47K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV53GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV56Message ;
      private SdtK2BTrnContext AV57TrnContext ;
      private SdtK2BTrnContext_Attribute AV58TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV61ActivityListItem ;
   }

   public class estadosatisfaccionsatisfaccionwc1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00282( IGxContext context ,
                                             DateTime AV37SatisfaccionFecha_To ,
                                             DateTime AV36SatisfaccionFecha_From ,
                                             DateTime AV40UsuarioFecha_To ,
                                             DateTime AV39UsuarioFecha_From ,
                                             string AV41SatisfaccionResueltoNombre ,
                                             string AV42SatisfaccionTecnicoCompetenteNombre ,
                                             string AV43SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV44SatisfaccionTiempoNombre ,
                                             string AV45SatisfaccionAtencionNombre ,
                                             string AV50K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV51OrderedBy ,
                                             short AV6SatisfaccionTecnicoProblemaId ,
                                             short A9SatisfaccionTecnicoProblemaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SatisfaccionTecnicoProblemaId], T1.[SatisfaccionSugerencia], T2.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T6.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T8.[UsuarioRequerimiento], T8.[UsuarioFecha], T8.[UsuarioNombre], T7.[UsuarioId], T1.[TicketId], T1.[SatisfaccionFecha], T1.[SatisfaccionId]";
         sFromString = " FROM ((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T7 ON T7.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T8 ON T8.[UsuarioId] = T7.[UsuarioId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[SatisfaccionTecnicoProblemaId] = @AV6SatisfaccionTecnicoProblemaId)");
         if ( ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV37SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV36SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] <= @AV40UsuarioFecha_To)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] >= @AV39UsuarioFecha_From)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV41SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV43SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV44SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV45SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T7.[UsuarioId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or T8.[UsuarioNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T8.[UsuarioRequerimiento] like '%' + @lV50K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T3.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T2.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV50K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
            GXv_int5[18] = 1;
            GXv_int5[19] = 1;
            GXv_int5[20] = 1;
         }
         if ( AV51OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV51OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV51OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV51OrderedBy == 3 )
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

      protected Object[] conditional_H00283( IGxContext context ,
                                             DateTime AV37SatisfaccionFecha_To ,
                                             DateTime AV36SatisfaccionFecha_From ,
                                             DateTime AV40UsuarioFecha_To ,
                                             DateTime AV39UsuarioFecha_From ,
                                             string AV41SatisfaccionResueltoNombre ,
                                             string AV42SatisfaccionTecnicoCompetenteNombre ,
                                             string AV43SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV44SatisfaccionTiempoNombre ,
                                             string AV45SatisfaccionAtencionNombre ,
                                             string AV50K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV51OrderedBy ,
                                             short AV6SatisfaccionTecnicoProblemaId ,
                                             short A9SatisfaccionTecnicoProblemaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[21];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T8 ON T8.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId])";
         AddWhere(sWhereString, "(T1.[SatisfaccionTecnicoProblemaId] = @AV6SatisfaccionTecnicoProblemaId)");
         if ( ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV37SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV36SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] <= @AV40UsuarioFecha_To)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioFecha] >= @AV39UsuarioFecha_From)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV41SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV43SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV44SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T8.[EstadoSatisfaccionNombre] like @lV45SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T2.[UsuarioId] AS decimal(10,0))) like '%' + @lV50K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV50K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T7.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T8.[EstadoSatisfaccionNombre] like '%' + @lV50K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV50K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
            GXv_int7[16] = 1;
            GXv_int7[17] = 1;
            GXv_int7[18] = 1;
            GXv_int7[19] = 1;
            GXv_int7[20] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV51OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV51OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV51OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV51OrderedBy == 3 )
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
                     return conditional_H00282(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_H00283(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmH00282;
          prmH00282 = new Object[] {
          new ParDef("@AV6SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@AV37SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV40UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV39UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV41SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV44SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV45SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00283;
          prmH00283 = new Object[] {
          new ParDef("@AV6SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@AV37SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV40UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV39UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV41SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV44SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV45SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV50K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00282", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00282,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00283", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00283,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((long[]) buf[16])[0] = rslt.getLong(16);
                ((long[]) buf[17])[0] = rslt.getLong(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
