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
   public class estadoticketticketwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public estadoticketticketwc( )
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

      public estadoticketticketwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EstadoTicketTecnicoId )
      {
         this.AV6EstadoTicketTecnicoId = aP0_EstadoTicketTecnicoId;
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
         chkavAtt_ticketid_visible = new GXCheckbox();
         chkavAtt_ticketfecha_visible = new GXCheckbox();
         chkavAtt_tickethora_visible = new GXCheckbox();
         chkavAtt_usuarioid_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         chkavAtt_estadoticketid_visible = new GXCheckbox();
         chkavAtt_estadoticketnombre_visible = new GXCheckbox();
         chkavAtt_ticketlastid_visible = new GXCheckbox();
         chkavAtt_ticketlaptop_visible = new GXCheckbox();
         chkavAtt_ticketdesktop_visible = new GXCheckbox();
         chkavAtt_ticketmonitor_visible = new GXCheckbox();
         chkavAtt_ticketimpresora_visible = new GXCheckbox();
         chkavAtt_ticketescaner_visible = new GXCheckbox();
         chkavAtt_ticketrouter_visible = new GXCheckbox();
         chkavAtt_ticketsistemaoperativo_visible = new GXCheckbox();
         chkavAtt_ticketoffice_visible = new GXCheckbox();
         chkavAtt_ticketantivirus_visible = new GXCheckbox();
         chkavAtt_ticketaplicacion_visible = new GXCheckbox();
         chkavAtt_ticketdisenio_visible = new GXCheckbox();
         chkavAtt_ticketingenieria_visible = new GXCheckbox();
         chkavAtt_ticketdiscoduroexterno_visible = new GXCheckbox();
         chkavAtt_ticketperifericos_visible = new GXCheckbox();
         chkavAtt_ticketups_visible = new GXCheckbox();
         chkavAtt_ticketapoyousuario_visible = new GXCheckbox();
         chkavAtt_ticketinstalardatashow_visible = new GXCheckbox();
         chkavAtt_ticketotros_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
         chkTicketLaptop = new GXCheckbox();
         chkTicketDesktop = new GXCheckbox();
         chkTicketMonitor = new GXCheckbox();
         chkTicketImpresora = new GXCheckbox();
         chkTicketEscaner = new GXCheckbox();
         chkTicketRouter = new GXCheckbox();
         chkTicketSistemaOperativo = new GXCheckbox();
         chkTicketOffice = new GXCheckbox();
         chkTicketAntivirus = new GXCheckbox();
         chkTicketAplicacion = new GXCheckbox();
         chkTicketDisenio = new GXCheckbox();
         chkTicketIngenieria = new GXCheckbox();
         chkTicketDiscoDuroExterno = new GXCheckbox();
         chkTicketPerifericos = new GXCheckbox();
         chkTicketUps = new GXCheckbox();
         chkTicketApoyoUsuario = new GXCheckbox();
         chkTicketInstalarDataShow = new GXCheckbox();
         chkTicketOtros = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EstadoTicketTecnicoId");
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
                  AV6EstadoTicketTecnicoId = (short)(NumberUtil.Val( GetPar( "EstadoTicketTecnicoId"), "."));
                  AssignAttri(sPrefix, false, "AV6EstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6EstadoTicketTecnicoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV6EstadoTicketTecnicoId});
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
                  gxfirstwebparm = GetFirstPar( "EstadoTicketTecnicoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EstadoTicketTecnicoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_288 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_288"), "."));
                  nGXsfl_288_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_288_idx"), "."));
                  sGXsfl_288_idx = GetPar( "sGXsfl_288_idx");
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
                  AV60K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV50TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
                  AV53TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV54TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
                  AV55UsuarioNombre = GetPar( "UsuarioNombre");
                  A17EstadoTicketTecnicoId = (short)(NumberUtil.Val( GetPar( "EstadoTicketTecnicoId"), "."));
                  AV6EstadoTicketTecnicoId = (short)(NumberUtil.Val( GetPar( "EstadoTicketTecnicoId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV48ClassCollection);
                  AV61OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
                  AV51TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV80Pgmname = GetPar( "Pgmname");
                  AV9CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridConfiguration);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV70AutoLinksActivityList);
                  A5EstadoTicketId = (short)(NumberUtil.Val( GetPar( "EstadoTicketId"), "."));
                  AV72TicketFecha_IsAuthorized = StringUtil.StrToBool( GetPar( "TicketFecha_IsAuthorized"));
                  AV15Att_TicketId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketId_Visible"));
                  AV16Att_TicketFecha_Visible = StringUtil.StrToBool( GetPar( "Att_TicketFecha_Visible"));
                  AV17Att_TicketHora_Visible = StringUtil.StrToBool( GetPar( "Att_TicketHora_Visible"));
                  AV18Att_UsuarioId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioId_Visible"));
                  AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
                  AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
                  AV21Att_EstadoTicketId_Visible = StringUtil.StrToBool( GetPar( "Att_EstadoTicketId_Visible"));
                  AV22Att_EstadoTicketNombre_Visible = StringUtil.StrToBool( GetPar( "Att_EstadoTicketNombre_Visible"));
                  AV23Att_TicketLastId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketLastId_Visible"));
                  AV24Att_TicketLaptop_Visible = StringUtil.StrToBool( GetPar( "Att_TicketLaptop_Visible"));
                  AV25Att_TicketDesktop_Visible = StringUtil.StrToBool( GetPar( "Att_TicketDesktop_Visible"));
                  AV26Att_TicketMonitor_Visible = StringUtil.StrToBool( GetPar( "Att_TicketMonitor_Visible"));
                  AV27Att_TicketImpresora_Visible = StringUtil.StrToBool( GetPar( "Att_TicketImpresora_Visible"));
                  AV28Att_TicketEscaner_Visible = StringUtil.StrToBool( GetPar( "Att_TicketEscaner_Visible"));
                  AV29Att_TicketRouter_Visible = StringUtil.StrToBool( GetPar( "Att_TicketRouter_Visible"));
                  AV30Att_TicketSistemaOperativo_Visible = StringUtil.StrToBool( GetPar( "Att_TicketSistemaOperativo_Visible"));
                  AV31Att_TicketOffice_Visible = StringUtil.StrToBool( GetPar( "Att_TicketOffice_Visible"));
                  AV32Att_TicketAntivirus_Visible = StringUtil.StrToBool( GetPar( "Att_TicketAntivirus_Visible"));
                  AV33Att_TicketAplicacion_Visible = StringUtil.StrToBool( GetPar( "Att_TicketAplicacion_Visible"));
                  AV34Att_TicketDisenio_Visible = StringUtil.StrToBool( GetPar( "Att_TicketDisenio_Visible"));
                  AV35Att_TicketIngenieria_Visible = StringUtil.StrToBool( GetPar( "Att_TicketIngenieria_Visible"));
                  AV36Att_TicketDiscoDuroExterno_Visible = StringUtil.StrToBool( GetPar( "Att_TicketDiscoDuroExterno_Visible"));
                  AV37Att_TicketPerifericos_Visible = StringUtil.StrToBool( GetPar( "Att_TicketPerifericos_Visible"));
                  AV38Att_TicketUps_Visible = StringUtil.StrToBool( GetPar( "Att_TicketUps_Visible"));
                  AV39Att_TicketApoyoUsuario_Visible = StringUtil.StrToBool( GetPar( "Att_TicketApoyoUsuario_Visible"));
                  AV40Att_TicketInstalarDataShow_Visible = StringUtil.StrToBool( GetPar( "Att_TicketInstalarDataShow_Visible"));
                  AV41Att_TicketOtros_Visible = StringUtil.StrToBool( GetPar( "Att_TicketOtros_Visible"));
                  AV12FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
                  AV77Uri = GetPar( "Uri");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
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
            return "ticket_Execute" ;
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
            PA2H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV80Pgmname = "EstadoTicketTicketWC";
               context.Gx_err = 0;
               WS2H2( ) ;
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
            context.SendWebValue( "Ticketes") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188124079", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadoticketticketwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6EstadoTicketTecnicoId,4,0))}, new string[] {"EstadoTicketTecnicoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV60K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTICKETFECHA_FROM", context.localUtil.Format(AV50TicketFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTICKETHORA_FROM", context.localUtil.TToC( AV53TicketHora_From, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTICKETHORA_TO", context.localUtil.TToC( AV54TicketHora_To, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vUSUARIONOMBRE", AV55UsuarioNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_288", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_288), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGS", AV58FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGS", AV58FilterTags);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG", StringUtil.RTrim( AV59DeletedTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTICKETFECHA_TO", context.localUtil.DToC( AV51TicketFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDORDERS", AV62GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDORDERS", AV62GridOrders);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6EstadoTicketTecnicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6EstadoTicketTecnicoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION", AV48ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION", AV48ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTADOTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EstadoTicketTecnicoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAUTOLINKSACTIVITYLIST", AV70AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAUTOLINKSACTIVITYLIST", AV70AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vTICKETFECHA_ISAUTHORIZED", AV72TicketFecha_IsAuthorized);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV77Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Uri, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ESTADOTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTICKETFECHA_FROM", context.localUtil.DToC( AV50TicketFecha_From, 0, "/"));
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

      protected void RenderHtmlCloseForm2H2( )
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
         return "EstadoTicketTicketWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticketes" ;
      }

      protected void WB2H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "estadoticketticketwc.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV60K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV60K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoTicketTicketWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoTicketTicketWC.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV58FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV59DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoTicketTicketWC.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketfecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockticketfecha_Internalname, "Fecha:", "", "", lblTextblockticketfecha_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* User Defined Control */
            ucTicketfecha_daterangepicker.SetProperty("ValueFrom", AV50TicketFecha_From);
            ucTicketfecha_daterangepicker.SetProperty("ValueTo", AV51TicketFecha_To);
            ucTicketfecha_daterangepicker.Render(context, "k2bdaterangepicker", Ticketfecha_daterangepicker_Internalname, sPrefix+"TICKETFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickethora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktickethora_Internalname, "Hora:", "", "", lblTextblocktickethora_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDaterangefiltermaintable_tickethora_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickethora_from_Internalname, "Desde", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickethora_from_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickethora_from_Internalname, context.localUtil.TToC( AV53TicketHora_From, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV53TicketHora_From, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickethora_from_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickethora_from_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EstadoTicketTicketWC.htm");
            GxWebStd.gx_bitmap( context, edtavTickethora_from_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickethora_from_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDaterangeseparator_tickethora_Internalname, "-", "", "", lblDaterangeseparator_tickethora_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickethora_to_Internalname, "Hasta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickethora_to_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickethora_to_Internalname, context.localUtil.TToC( AV54TicketHora_To, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV54TicketHora_To, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickethora_to_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickethora_to_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EstadoTicketTicketWC.htm");
            GxWebStd.gx_bitmap( context, edtavTickethora_to_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickethora_to_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarionombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_Internalname, "Usuario", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV55UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV55UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_EstadoTicketTicketWC.htm");
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
            wb_table1_58_2H2( true) ;
         }
         else
         {
            wb_table1_58_2H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_58_2H2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"288\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(80), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Hora:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Requerimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtEstadoTicketId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtEstadoTicketNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Estado Ticket") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketLastId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Last Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketLaptop.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "aptop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketDesktop.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Desktop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketMonitor.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Monitor") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketImpresora.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Impresora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketEscaner.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Escaner") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketRouter.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Internet/Router/Access Point") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketSistemaOperativo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Operativo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketOffice.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Office") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketAntivirus.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Antivirus") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketAplicacion.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Aplicación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketDisenio.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Diseño") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketIngenieria.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Ingeniería") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketDiscoDuroExterno.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Duro ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketPerifericos.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Periféricos") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketUps.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "UPS") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketApoyoUsuario.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketInstalarDataShow.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Data Show") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkTicketOtros.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Otros") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTicketFecha_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFecha_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHora_Visible), 5, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EstadoTicketId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A24EstadoTicketNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadoTicketNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketLastId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A53TicketLaptop));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketLaptop.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A42TicketDesktop));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketDesktop.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A55TicketMonitor));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketMonitor.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A50TicketImpresora));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketImpresora.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A45TicketEscaner));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketEscaner.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A59TicketRouter));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketRouter.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A60TicketSistemaOperativo));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketSistemaOperativo.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A56TicketOffice));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketOffice.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A39TicketAntivirus));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketAntivirus.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A40TicketAplicacion));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketAplicacion.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A44TicketDisenio));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketDisenio.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A51TicketIngenieria));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketIngenieria.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketDiscoDuroExterno.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A58TicketPerifericos));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketPerifericos.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A87TicketUps));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketUps.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A41TicketApoyoUsuario));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketApoyoUsuario.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A52TicketInstalarDataShow));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketInstalarDataShow.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A57TicketOtros));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkTicketOtros.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV73Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV74Delete));
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
         if ( wbEnd == 288 )
         {
            wbEnd = 0;
            nRC_GXsfl_288 = (int)(nGXsfl_288_idx-1);
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
            wb_table2_320_2H2( true) ;
         }
         else
         {
            wb_table2_320_2H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_320_2H2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV62GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV64UC_OrderedBy);
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
         if ( wbEnd == 288 )
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

      protected void START2H2( )
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
               Form.Meta.addItem("description", "Ticketes", 0) ;
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
               STRUP2H0( ) ;
            }
         }
      }

      protected void WS2H2( )
      {
         START2H2( ) ;
         EVT2H2( ) ;
      }

      protected void EVT2H2( )
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
                                 STRUP2H0( ) ;
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
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E132H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings' */
                                    E142H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFirst' */
                                    E152H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrevious' */
                                    E162H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E172H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoLast' */
                                    E182H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E192H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E202H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E212H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2H0( ) ;
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
                                 STRUP2H0( ) ;
                              }
                              nGXsfl_288_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_288_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_288_idx), 4, 0), 4, "0");
                              SubsflControlProps_2882( ) ;
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFecha_Internalname), 0));
                              A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname), 0));
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A5EstadoTicketId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketId_Internalname), ".", ","));
                              A24EstadoTicketNombre = cgiGet( edtEstadoTicketNombre_Internalname);
                              A54TicketLastId = (long)(context.localUtil.CToN( cgiGet( edtTicketLastId_Internalname), ".", ","));
                              A53TicketLaptop = StringUtil.StrToBool( cgiGet( chkTicketLaptop_Internalname));
                              n53TicketLaptop = false;
                              A42TicketDesktop = StringUtil.StrToBool( cgiGet( chkTicketDesktop_Internalname));
                              n42TicketDesktop = false;
                              A55TicketMonitor = StringUtil.StrToBool( cgiGet( chkTicketMonitor_Internalname));
                              n55TicketMonitor = false;
                              A50TicketImpresora = StringUtil.StrToBool( cgiGet( chkTicketImpresora_Internalname));
                              n50TicketImpresora = false;
                              A45TicketEscaner = StringUtil.StrToBool( cgiGet( chkTicketEscaner_Internalname));
                              n45TicketEscaner = false;
                              A59TicketRouter = StringUtil.StrToBool( cgiGet( chkTicketRouter_Internalname));
                              n59TicketRouter = false;
                              A60TicketSistemaOperativo = StringUtil.StrToBool( cgiGet( chkTicketSistemaOperativo_Internalname));
                              n60TicketSistemaOperativo = false;
                              A56TicketOffice = StringUtil.StrToBool( cgiGet( chkTicketOffice_Internalname));
                              n56TicketOffice = false;
                              A39TicketAntivirus = StringUtil.StrToBool( cgiGet( chkTicketAntivirus_Internalname));
                              n39TicketAntivirus = false;
                              A40TicketAplicacion = StringUtil.StrToBool( cgiGet( chkTicketAplicacion_Internalname));
                              n40TicketAplicacion = false;
                              A44TicketDisenio = StringUtil.StrToBool( cgiGet( chkTicketDisenio_Internalname));
                              n44TicketDisenio = false;
                              A51TicketIngenieria = StringUtil.StrToBool( cgiGet( chkTicketIngenieria_Internalname));
                              n51TicketIngenieria = false;
                              A43TicketDiscoDuroExterno = StringUtil.StrToBool( cgiGet( chkTicketDiscoDuroExterno_Internalname));
                              n43TicketDiscoDuroExterno = false;
                              A58TicketPerifericos = StringUtil.StrToBool( cgiGet( chkTicketPerifericos_Internalname));
                              n58TicketPerifericos = false;
                              A87TicketUps = StringUtil.StrToBool( cgiGet( chkTicketUps_Internalname));
                              n87TicketUps = false;
                              A41TicketApoyoUsuario = StringUtil.StrToBool( cgiGet( chkTicketApoyoUsuario_Internalname));
                              n41TicketApoyoUsuario = false;
                              A52TicketInstalarDataShow = StringUtil.StrToBool( cgiGet( chkTicketInstalarDataShow_Internalname));
                              n52TicketInstalarDataShow = false;
                              A57TicketOtros = StringUtil.StrToBool( cgiGet( chkTicketOtros_Internalname));
                              n57TicketOtros = false;
                              AV73Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_288_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
                              AV74Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV74Delete))), !bGXsfl_288_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV74Delete), true);
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
                                          E222H2 ();
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
                                          E232H2 ();
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
                                          E242H2 ();
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
                                          E252H2 ();
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
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV60K2BToolsGenericSearchField) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ticketfecha_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTICKETFECHA_FROM"), 0) != AV50TicketFecha_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Tickethora_from Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTICKETHORA_FROM"), 0) != AV53TicketHora_From )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Tickethora_to Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTICKETHORA_TO"), 0) != AV54TicketHora_To )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Usuarionombre Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIONOMBRE"), AV55UsuarioNombre) != 0 )
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
                                       STRUP2H0( ) ;
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

      protected void WE2H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2H2( ) ;
            }
         }
      }

      protected void PA2H2( )
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
         SubsflControlProps_2882( ) ;
         while ( nGXsfl_288_idx <= nRC_GXsfl_288 )
         {
            sendrow_2882( ) ;
            nGXsfl_288_idx = ((subGrid_Islastpage==1)&&(nGXsfl_288_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_288_idx+1);
            sGXsfl_288_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_288_idx), 4, 0), 4, "0");
            SubsflControlProps_2882( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV60K2BToolsGenericSearchField ,
                                       DateTime AV50TicketFecha_From ,
                                       DateTime AV53TicketHora_From ,
                                       DateTime AV54TicketHora_To ,
                                       string AV55UsuarioNombre ,
                                       short A17EstadoTicketTecnicoId ,
                                       short AV6EstadoTicketTecnicoId ,
                                       GxSimpleCollection<string> AV48ClassCollection ,
                                       short AV61OrderedBy ,
                                       DateTime AV51TicketFecha_To ,
                                       string AV80Pgmname ,
                                       int AV9CurrentPage ,
                                       SdtK2BGridConfiguration AV11GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV70AutoLinksActivityList ,
                                       short A5EstadoTicketId ,
                                       bool AV72TicketFecha_IsAuthorized ,
                                       bool AV15Att_TicketId_Visible ,
                                       bool AV16Att_TicketFecha_Visible ,
                                       bool AV17Att_TicketHora_Visible ,
                                       bool AV18Att_UsuarioId_Visible ,
                                       bool AV19Att_UsuarioNombre_Visible ,
                                       bool AV20Att_UsuarioRequerimiento_Visible ,
                                       bool AV21Att_EstadoTicketId_Visible ,
                                       bool AV22Att_EstadoTicketNombre_Visible ,
                                       bool AV23Att_TicketLastId_Visible ,
                                       bool AV24Att_TicketLaptop_Visible ,
                                       bool AV25Att_TicketDesktop_Visible ,
                                       bool AV26Att_TicketMonitor_Visible ,
                                       bool AV27Att_TicketImpresora_Visible ,
                                       bool AV28Att_TicketEscaner_Visible ,
                                       bool AV29Att_TicketRouter_Visible ,
                                       bool AV30Att_TicketSistemaOperativo_Visible ,
                                       bool AV31Att_TicketOffice_Visible ,
                                       bool AV32Att_TicketAntivirus_Visible ,
                                       bool AV33Att_TicketAplicacion_Visible ,
                                       bool AV34Att_TicketDisenio_Visible ,
                                       bool AV35Att_TicketIngenieria_Visible ,
                                       bool AV36Att_TicketDiscoDuroExterno_Visible ,
                                       bool AV37Att_TicketPerifericos_Visible ,
                                       bool AV38Att_TicketUps_Visible ,
                                       bool AV39Att_TicketApoyoUsuario_Visible ,
                                       bool AV40Att_TicketInstalarDataShow_Visible ,
                                       bool AV41Att_TicketOtros_Visible ,
                                       bool AV12FreezeColumnTitles ,
                                       string AV77Uri ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232H2 ();
         GRID_nCurrentRecord = 0;
         RF2H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TICKETID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
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
         AV15Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TicketId_Visible));
         AssignAttri(sPrefix, false, "AV15Att_TicketId_Visible", AV15Att_TicketId_Visible);
         AV16Att_TicketFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TicketFecha_Visible));
         AssignAttri(sPrefix, false, "AV16Att_TicketFecha_Visible", AV16Att_TicketFecha_Visible);
         AV17Att_TicketHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TicketHora_Visible));
         AssignAttri(sPrefix, false, "AV17Att_TicketHora_Visible", AV17Att_TicketHora_Visible);
         AV18Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioId_Visible));
         AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
         AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioNombre_Visible));
         AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
         AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible));
         AssignAttri(sPrefix, false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         AV21Att_EstadoTicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_EstadoTicketId_Visible));
         AssignAttri(sPrefix, false, "AV21Att_EstadoTicketId_Visible", AV21Att_EstadoTicketId_Visible);
         AV22Att_EstadoTicketNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_EstadoTicketNombre_Visible));
         AssignAttri(sPrefix, false, "AV22Att_EstadoTicketNombre_Visible", AV22Att_EstadoTicketNombre_Visible);
         AV23Att_TicketLastId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_TicketLastId_Visible));
         AssignAttri(sPrefix, false, "AV23Att_TicketLastId_Visible", AV23Att_TicketLastId_Visible);
         AV24Att_TicketLaptop_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_TicketLaptop_Visible));
         AssignAttri(sPrefix, false, "AV24Att_TicketLaptop_Visible", AV24Att_TicketLaptop_Visible);
         AV25Att_TicketDesktop_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_TicketDesktop_Visible));
         AssignAttri(sPrefix, false, "AV25Att_TicketDesktop_Visible", AV25Att_TicketDesktop_Visible);
         AV26Att_TicketMonitor_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV26Att_TicketMonitor_Visible));
         AssignAttri(sPrefix, false, "AV26Att_TicketMonitor_Visible", AV26Att_TicketMonitor_Visible);
         AV27Att_TicketImpresora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV27Att_TicketImpresora_Visible));
         AssignAttri(sPrefix, false, "AV27Att_TicketImpresora_Visible", AV27Att_TicketImpresora_Visible);
         AV28Att_TicketEscaner_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV28Att_TicketEscaner_Visible));
         AssignAttri(sPrefix, false, "AV28Att_TicketEscaner_Visible", AV28Att_TicketEscaner_Visible);
         AV29Att_TicketRouter_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV29Att_TicketRouter_Visible));
         AssignAttri(sPrefix, false, "AV29Att_TicketRouter_Visible", AV29Att_TicketRouter_Visible);
         AV30Att_TicketSistemaOperativo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV30Att_TicketSistemaOperativo_Visible));
         AssignAttri(sPrefix, false, "AV30Att_TicketSistemaOperativo_Visible", AV30Att_TicketSistemaOperativo_Visible);
         AV31Att_TicketOffice_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV31Att_TicketOffice_Visible));
         AssignAttri(sPrefix, false, "AV31Att_TicketOffice_Visible", AV31Att_TicketOffice_Visible);
         AV32Att_TicketAntivirus_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV32Att_TicketAntivirus_Visible));
         AssignAttri(sPrefix, false, "AV32Att_TicketAntivirus_Visible", AV32Att_TicketAntivirus_Visible);
         AV33Att_TicketAplicacion_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV33Att_TicketAplicacion_Visible));
         AssignAttri(sPrefix, false, "AV33Att_TicketAplicacion_Visible", AV33Att_TicketAplicacion_Visible);
         AV34Att_TicketDisenio_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV34Att_TicketDisenio_Visible));
         AssignAttri(sPrefix, false, "AV34Att_TicketDisenio_Visible", AV34Att_TicketDisenio_Visible);
         AV35Att_TicketIngenieria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV35Att_TicketIngenieria_Visible));
         AssignAttri(sPrefix, false, "AV35Att_TicketIngenieria_Visible", AV35Att_TicketIngenieria_Visible);
         AV36Att_TicketDiscoDuroExterno_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV36Att_TicketDiscoDuroExterno_Visible));
         AssignAttri(sPrefix, false, "AV36Att_TicketDiscoDuroExterno_Visible", AV36Att_TicketDiscoDuroExterno_Visible);
         AV37Att_TicketPerifericos_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV37Att_TicketPerifericos_Visible));
         AssignAttri(sPrefix, false, "AV37Att_TicketPerifericos_Visible", AV37Att_TicketPerifericos_Visible);
         AV38Att_TicketUps_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV38Att_TicketUps_Visible));
         AssignAttri(sPrefix, false, "AV38Att_TicketUps_Visible", AV38Att_TicketUps_Visible);
         AV39Att_TicketApoyoUsuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Att_TicketApoyoUsuario_Visible));
         AssignAttri(sPrefix, false, "AV39Att_TicketApoyoUsuario_Visible", AV39Att_TicketApoyoUsuario_Visible);
         AV40Att_TicketInstalarDataShow_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV40Att_TicketInstalarDataShow_Visible));
         AssignAttri(sPrefix, false, "AV40Att_TicketInstalarDataShow_Visible", AV40Att_TicketInstalarDataShow_Visible);
         AV41Att_TicketOtros_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV41Att_TicketOtros_Visible));
         AssignAttri(sPrefix, false, "AV41Att_TicketOtros_Visible", AV41Att_TicketOtros_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV42GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV42GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV12FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV12FreezeColumnTitles));
         AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232H2 ();
         RF2H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV80Pgmname = "EstadoTicketTicketWC";
         context.Gx_err = 0;
      }

      protected void RF2H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 288;
         E242H2 ();
         nGXsfl_288_idx = 1;
         sGXsfl_288_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_288_idx), 4, 0), 4, "0");
         SubsflControlProps_2882( ) ;
         bGXsfl_288_Refreshing = true;
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
            SubsflControlProps_2882( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV51TicketFecha_To ,
                                                 AV50TicketFecha_From ,
                                                 AV54TicketHora_To ,
                                                 AV53TicketHora_From ,
                                                 AV55UsuarioNombre ,
                                                 AV60K2BToolsGenericSearchField ,
                                                 A46TicketFecha ,
                                                 A48TicketHora ,
                                                 A93UsuarioNombre ,
                                                 A14TicketId ,
                                                 A15UsuarioId ,
                                                 A94UsuarioRequerimiento ,
                                                 A5EstadoTicketId ,
                                                 A24EstadoTicketNombre ,
                                                 A54TicketLastId ,
                                                 AV61OrderedBy ,
                                                 A17EstadoTicketTecnicoId ,
                                                 AV6EstadoTicketTecnicoId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV55UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV55UsuarioNombre), "%", "");
            /* Using cursor H002H2 */
            pr_default.execute(0, new Object[] {A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV51TicketFecha_To, AV50TicketFecha_From, AV54TicketHora_To, AV53TicketHora_From, lV55UsuarioNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_288_idx = 1;
            sGXsfl_288_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_288_idx), 4, 0), 4, "0");
            SubsflControlProps_2882( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A57TicketOtros = H002H2_A57TicketOtros[0];
               n57TicketOtros = H002H2_n57TicketOtros[0];
               A52TicketInstalarDataShow = H002H2_A52TicketInstalarDataShow[0];
               n52TicketInstalarDataShow = H002H2_n52TicketInstalarDataShow[0];
               A41TicketApoyoUsuario = H002H2_A41TicketApoyoUsuario[0];
               n41TicketApoyoUsuario = H002H2_n41TicketApoyoUsuario[0];
               A87TicketUps = H002H2_A87TicketUps[0];
               n87TicketUps = H002H2_n87TicketUps[0];
               A58TicketPerifericos = H002H2_A58TicketPerifericos[0];
               n58TicketPerifericos = H002H2_n58TicketPerifericos[0];
               A43TicketDiscoDuroExterno = H002H2_A43TicketDiscoDuroExterno[0];
               n43TicketDiscoDuroExterno = H002H2_n43TicketDiscoDuroExterno[0];
               A51TicketIngenieria = H002H2_A51TicketIngenieria[0];
               n51TicketIngenieria = H002H2_n51TicketIngenieria[0];
               A44TicketDisenio = H002H2_A44TicketDisenio[0];
               n44TicketDisenio = H002H2_n44TicketDisenio[0];
               A40TicketAplicacion = H002H2_A40TicketAplicacion[0];
               n40TicketAplicacion = H002H2_n40TicketAplicacion[0];
               A39TicketAntivirus = H002H2_A39TicketAntivirus[0];
               n39TicketAntivirus = H002H2_n39TicketAntivirus[0];
               A56TicketOffice = H002H2_A56TicketOffice[0];
               n56TicketOffice = H002H2_n56TicketOffice[0];
               A60TicketSistemaOperativo = H002H2_A60TicketSistemaOperativo[0];
               n60TicketSistemaOperativo = H002H2_n60TicketSistemaOperativo[0];
               A59TicketRouter = H002H2_A59TicketRouter[0];
               n59TicketRouter = H002H2_n59TicketRouter[0];
               A45TicketEscaner = H002H2_A45TicketEscaner[0];
               n45TicketEscaner = H002H2_n45TicketEscaner[0];
               A50TicketImpresora = H002H2_A50TicketImpresora[0];
               n50TicketImpresora = H002H2_n50TicketImpresora[0];
               A55TicketMonitor = H002H2_A55TicketMonitor[0];
               n55TicketMonitor = H002H2_n55TicketMonitor[0];
               A42TicketDesktop = H002H2_A42TicketDesktop[0];
               n42TicketDesktop = H002H2_n42TicketDesktop[0];
               A53TicketLaptop = H002H2_A53TicketLaptop[0];
               n53TicketLaptop = H002H2_n53TicketLaptop[0];
               A54TicketLastId = H002H2_A54TicketLastId[0];
               A94UsuarioRequerimiento = H002H2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002H2_A93UsuarioNombre[0];
               A15UsuarioId = H002H2_A15UsuarioId[0];
               A48TicketHora = H002H2_A48TicketHora[0];
               A46TicketFecha = H002H2_A46TicketFecha[0];
               A14TicketId = H002H2_A14TicketId[0];
               A94UsuarioRequerimiento = H002H2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002H2_A93UsuarioNombre[0];
               E252H2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 288;
            WB2H0( ) ;
         }
         bGXsfl_288_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2H2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_TICKETID"+"_"+sGXsfl_288_idx, GetSecureSignedToken( sPrefix+sGXsfl_288_idx, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vURI", AV77Uri);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vURI", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV77Uri, "")), context));
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
                                              AV51TicketFecha_To ,
                                              AV50TicketFecha_From ,
                                              AV54TicketHora_To ,
                                              AV53TicketHora_From ,
                                              AV55UsuarioNombre ,
                                              AV60K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A93UsuarioNombre ,
                                              A14TicketId ,
                                              A15UsuarioId ,
                                              A94UsuarioRequerimiento ,
                                              A5EstadoTicketId ,
                                              A24EstadoTicketNombre ,
                                              A54TicketLastId ,
                                              AV61OrderedBy ,
                                              A17EstadoTicketTecnicoId ,
                                              AV6EstadoTicketTecnicoId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV55UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV55UsuarioNombre), "%", "");
         /* Using cursor H002H3 */
         pr_default.execute(1, new Object[] {A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV51TicketFecha_To, AV50TicketFecha_From, AV54TicketHora_To, AV53TicketHora_From, lV55UsuarioNombre});
         GRID_nRecordCount = H002H3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV80Pgmname = "EstadoTicketTicketWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGS"), AV58FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vGRIDORDERS"), AV62GridOrders);
            /* Read saved values. */
            nRC_GXsfl_288 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_288"), ".", ","));
            AV59DeletedTag = cgiGet( sPrefix+"vDELETEDTAG");
            AV50TicketFecha_From = context.localUtil.CToD( cgiGet( sPrefix+"vTICKETFECHA_FROM"), 0);
            AV51TicketFecha_To = context.localUtil.CToD( cgiGet( sPrefix+"vTICKETFECHA_TO"), 0);
            AV64UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUC_ORDEREDBY"), ".", ","));
            wcpOAV6EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6EstadoTicketTecnicoId"), ".", ","));
            AV61OrderedBy = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vORDEREDBY"), ".", ","));
            AV6EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vESTADOTICKETTECNICOID"), ".", ","));
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
            AV60K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri(sPrefix, false, "AV60K2BToolsGenericSearchField", AV60K2BToolsGenericSearchField);
            if ( context.localUtil.VCDate( cgiGet( edtavTickethora_from_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora_From"}), 1, "vTICKETHORA_FROM");
               GX_FocusControl = edtavTickethora_from_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV53TicketHora_From = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV53TicketHora_From", context.localUtil.TToC( AV53TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV53TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickethora_from_Internalname)));
               AssignAttri(sPrefix, false, "AV53TicketHora_From", context.localUtil.TToC( AV53TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTickethora_to_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora_To"}), 1, "vTICKETHORA_TO");
               GX_FocusControl = edtavTickethora_to_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV54TicketHora_To = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV54TicketHora_To", context.localUtil.TToC( AV54TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV54TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickethora_to_Internalname)));
               AssignAttri(sPrefix, false, "AV54TicketHora_To", context.localUtil.TToC( AV54TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            AV55UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri(sPrefix, false, "AV55UsuarioNombre", AV55UsuarioNombre);
            AV15Att_TicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV15Att_TicketId_Visible", AV15Att_TicketId_Visible);
            AV16Att_TicketFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketfecha_visible_Internalname));
            AssignAttri(sPrefix, false, "AV16Att_TicketFecha_Visible", AV16Att_TicketFecha_Visible);
            AV17Att_TicketHora_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickethora_visible_Internalname));
            AssignAttri(sPrefix, false, "AV17Att_TicketHora_Visible", AV17Att_TicketHora_Visible);
            AV18Att_UsuarioId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarioid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
            AV19Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
            AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri(sPrefix, false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
            AV21Att_EstadoTicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estadoticketid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV21Att_EstadoTicketId_Visible", AV21Att_EstadoTicketId_Visible);
            AV22Att_EstadoTicketNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estadoticketnombre_visible_Internalname));
            AssignAttri(sPrefix, false, "AV22Att_EstadoTicketNombre_Visible", AV22Att_EstadoTicketNombre_Visible);
            AV23Att_TicketLastId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketlastid_visible_Internalname));
            AssignAttri(sPrefix, false, "AV23Att_TicketLastId_Visible", AV23Att_TicketLastId_Visible);
            AV24Att_TicketLaptop_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketlaptop_visible_Internalname));
            AssignAttri(sPrefix, false, "AV24Att_TicketLaptop_Visible", AV24Att_TicketLaptop_Visible);
            AV25Att_TicketDesktop_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketdesktop_visible_Internalname));
            AssignAttri(sPrefix, false, "AV25Att_TicketDesktop_Visible", AV25Att_TicketDesktop_Visible);
            AV26Att_TicketMonitor_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketmonitor_visible_Internalname));
            AssignAttri(sPrefix, false, "AV26Att_TicketMonitor_Visible", AV26Att_TicketMonitor_Visible);
            AV27Att_TicketImpresora_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketimpresora_visible_Internalname));
            AssignAttri(sPrefix, false, "AV27Att_TicketImpresora_Visible", AV27Att_TicketImpresora_Visible);
            AV28Att_TicketEscaner_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketescaner_visible_Internalname));
            AssignAttri(sPrefix, false, "AV28Att_TicketEscaner_Visible", AV28Att_TicketEscaner_Visible);
            AV29Att_TicketRouter_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketrouter_visible_Internalname));
            AssignAttri(sPrefix, false, "AV29Att_TicketRouter_Visible", AV29Att_TicketRouter_Visible);
            AV30Att_TicketSistemaOperativo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketsistemaoperativo_visible_Internalname));
            AssignAttri(sPrefix, false, "AV30Att_TicketSistemaOperativo_Visible", AV30Att_TicketSistemaOperativo_Visible);
            AV31Att_TicketOffice_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketoffice_visible_Internalname));
            AssignAttri(sPrefix, false, "AV31Att_TicketOffice_Visible", AV31Att_TicketOffice_Visible);
            AV32Att_TicketAntivirus_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketantivirus_visible_Internalname));
            AssignAttri(sPrefix, false, "AV32Att_TicketAntivirus_Visible", AV32Att_TicketAntivirus_Visible);
            AV33Att_TicketAplicacion_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketaplicacion_visible_Internalname));
            AssignAttri(sPrefix, false, "AV33Att_TicketAplicacion_Visible", AV33Att_TicketAplicacion_Visible);
            AV34Att_TicketDisenio_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketdisenio_visible_Internalname));
            AssignAttri(sPrefix, false, "AV34Att_TicketDisenio_Visible", AV34Att_TicketDisenio_Visible);
            AV35Att_TicketIngenieria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketingenieria_visible_Internalname));
            AssignAttri(sPrefix, false, "AV35Att_TicketIngenieria_Visible", AV35Att_TicketIngenieria_Visible);
            AV36Att_TicketDiscoDuroExterno_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketdiscoduroexterno_visible_Internalname));
            AssignAttri(sPrefix, false, "AV36Att_TicketDiscoDuroExterno_Visible", AV36Att_TicketDiscoDuroExterno_Visible);
            AV37Att_TicketPerifericos_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketperifericos_visible_Internalname));
            AssignAttri(sPrefix, false, "AV37Att_TicketPerifericos_Visible", AV37Att_TicketPerifericos_Visible);
            AV38Att_TicketUps_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketups_visible_Internalname));
            AssignAttri(sPrefix, false, "AV38Att_TicketUps_Visible", AV38Att_TicketUps_Visible);
            AV39Att_TicketApoyoUsuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketapoyousuario_visible_Internalname));
            AssignAttri(sPrefix, false, "AV39Att_TicketApoyoUsuario_Visible", AV39Att_TicketApoyoUsuario_Visible);
            AV40Att_TicketInstalarDataShow_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketinstalardatashow_visible_Internalname));
            AssignAttri(sPrefix, false, "AV40Att_TicketInstalarDataShow_Visible", AV40Att_TicketInstalarDataShow_Visible);
            AV41Att_TicketOtros_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketotros_visible_Internalname));
            AssignAttri(sPrefix, false, "AV41Att_TicketOtros_Visible", AV41Att_TicketOtros_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV42GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri(sPrefix, false, "AV42GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0));
            AV12FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri(sPrefix, false, "AV12FreezeColumnTitles", AV12FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV60K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vTICKETFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV50TicketFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTICKETHORA_FROM")) != AV53TicketHora_From )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTICKETHORA_TO")) != AV54TicketHora_To )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vUSUARIONOMBRE"), AV55UsuarioNombre) != 0 )
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
         E222H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp(sPrefix, false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp(sPrefix, false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV49TicketFecha = DateTime.MinValue;
         AV50TicketFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri(sPrefix, false, "AV50TicketFecha_From", context.localUtil.Format(AV50TicketFecha_From, "99/99/9999"));
         AV51TicketFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV51TicketFecha_To", context.localUtil.Format(AV51TicketFecha_To, "99/99/9999"));
         AV52TicketHora = (DateTime)(DateTime.MinValue);
         AV53TicketHora_From = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.ServerDate( context, pr_default) , - ( (int)(30) )) ) ;
         AssignAttri(sPrefix, false, "AV53TicketHora_From", context.localUtil.TToC( AV53TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
         AV54TicketHora_To = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri(sPrefix, false, "AV54TicketHora_To", context.localUtil.TToC( AV54TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
         AV55UsuarioNombre = "";
         AssignAttri(sPrefix, false, "AV55UsuarioNombre", AV55UsuarioNombre);
         new k2bloadrowsperpage(context ).execute(  AV80Pgmname,  "Grid", out  AV43RowsPerPageVariable, out  AV44RowsPerPageLoaded) ;
         AssignAttri(sPrefix, false, "AV43RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV43RowsPerPageVariable), 4, 0));
         if ( ! AV44RowsPerPageLoaded )
         {
            AV43RowsPerPageVariable = 20;
            AssignAttri(sPrefix, false, "AV43RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV43RowsPerPageVariable), 4, 0));
         }
         AV42GridSettingsRowsPerPageVariable = AV43RowsPerPageVariable;
         AssignAttri(sPrefix, false, "AV42GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV43RowsPerPageVariable;
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
         AV62GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV63GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV63GridOrder.gxTpr_Ascendingorder = 0;
         AV63GridOrder.gxTpr_Descendingorder = 1;
         AV63GridOrder.gxTpr_Gridcolumnindex = 1;
         AV62GridOrders.Add(AV63GridOrder, 0);
         AV63GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV63GridOrder.gxTpr_Ascendingorder = 2;
         AV63GridOrder.gxTpr_Descendingorder = 3;
         AV63GridOrder.gxTpr_Gridcolumnindex = 2;
         AV62GridOrders.Add(AV63GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232H2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV65Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV65Messages = GXt_objcol_SdtMessages_Message1;
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV65Messages.Count )
         {
            AV66Message = ((GeneXus.Utils.SdtMessages_Message)AV65Messages.Item(AV81GXV1));
            GX_msglist.addItem(AV66Message.gxTpr_Description);
            AV81GXV1 = (int)(AV81GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV80Pgmname;
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV73Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         AV82Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_288_Refreshing);
         AV74Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV74Delete))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV74Delete), true);
         AV83Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV74Delete))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV74Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_288_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV48ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV45GridStateKey = StringUtil.Str( (decimal)(AV6EstadoTicketTecnicoId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV80Pgmname,  AV45GridStateKey, out  AV46GridState) ;
         AV61OrderedBy = AV46GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV61OrderedBy", StringUtil.LTrimStr( (decimal)(AV61OrderedBy), 4, 0));
         AV64UC_OrderedBy = AV46GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV64UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV64UC_OrderedBy), 4, 0));
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "TicketFecha:From") == 0 )
            {
               AV50TicketFecha_From = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV50TicketFecha_From", context.localUtil.Format(AV50TicketFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "TicketFecha:To") == 0 )
            {
               AV51TicketFecha_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV51TicketFecha_To", context.localUtil.Format(AV51TicketFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "TicketHora:From") == 0 )
            {
               AV53TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( AV47GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri(sPrefix, false, "AV53TicketHora_From", context.localUtil.TToC( AV53TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "TicketHora:To") == 0 )
            {
               AV54TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV47GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri(sPrefix, false, "AV54TicketHora_To", context.localUtil.TToC( AV54TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre") == 0 )
            {
               AV55UsuarioNombre = AV47GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV55UsuarioNombre", AV55UsuarioNombre);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV60K2BToolsGenericSearchField = AV47GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV60K2BToolsGenericSearchField", AV60K2BToolsGenericSearchField);
            }
            AV84GXV2 = (int)(AV84GXV2+1);
         }
         AV10K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV46GridState.gxTpr_Currentpage > 0 ) && ( AV46GridState.gxTpr_Currentpage <= AV10K2BMaxPages ) )
         {
            AV9CurrentPage = AV46GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_gotopage( AV9CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV45GridStateKey = StringUtil.Str( (decimal)(AV6EstadoTicketTecnicoId), 4, 0);
         new k2bloadgridstate(context ).execute(  AV80Pgmname,  AV45GridStateKey, out  AV46GridState) ;
         AV46GridState.gxTpr_Currentpage = (short)(AV9CurrentPage);
         AV46GridState.gxTpr_Orderedby = AV61OrderedBy;
         AV46GridState.gxTpr_Filtervalues.Clear();
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "TicketFecha:From";
         AV47GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV50TicketFecha_From, "99/99/9999");
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "TicketFecha:To";
         AV47GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV51TicketFecha_To, "99/99/9999");
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "TicketHora:From";
         AV47GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV53TicketHora_From, "99:99");
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "TicketHora:To";
         AV47GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV54TicketHora_To, "99:99");
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre";
         AV47GridStateFilterValue.gxTpr_Value = AV55UsuarioNombre;
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV47GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV47GridStateFilterValue.gxTpr_Value = AV60K2BToolsGenericSearchField;
         AV46GridState.gxTpr_Filtervalues.Add(AV47GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV80Pgmname,  AV45GridStateKey,  AV46GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV67TrnContext = new SdtK2BTrnContext(context);
         AV67TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV67TrnContext.gxTpr_Returnmode = "Stack";
         AV67TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV67TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV67TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV67TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         AV68TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV68TrnContextAtt.gxTpr_Attributename = "EstadoTicketTecnicoId";
         AV68TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EstadoTicketTecnicoId), 4, 0);
         AV67TrnContext.gxTpr_Attributes.Add(AV68TrnContextAtt, 0);
         new k2bsettrncontextbyname(context ).execute(  "Ticket",  AV67TrnContext) ;
      }

      protected void E132H2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "Insert",  "",  "EntityManagerTicket") )
         {
            CallWebObject(formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtTicketId_Visible = 1;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV15Att_TicketId_Visible = true;
         AssignAttri(sPrefix, false, "AV15Att_TicketId_Visible", AV15Att_TicketId_Visible);
         edtTicketFecha_Visible = 1;
         AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV16Att_TicketFecha_Visible = true;
         AssignAttri(sPrefix, false, "AV16Att_TicketFecha_Visible", AV16Att_TicketFecha_Visible);
         edtTicketHora_Visible = 1;
         AssignProp(sPrefix, false, edtTicketHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketHora_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV17Att_TicketHora_Visible = true;
         AssignAttri(sPrefix, false, "AV17Att_TicketHora_Visible", AV17Att_TicketHora_Visible);
         edtUsuarioId_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV18Att_UsuarioId_Visible = true;
         AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV19Att_UsuarioNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV20Att_UsuarioRequerimiento_Visible = true;
         AssignAttri(sPrefix, false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         edtEstadoTicketId_Visible = 1;
         AssignProp(sPrefix, false, edtEstadoTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketId_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV21Att_EstadoTicketId_Visible = true;
         AssignAttri(sPrefix, false, "AV21Att_EstadoTicketId_Visible", AV21Att_EstadoTicketId_Visible);
         edtEstadoTicketNombre_Visible = 1;
         AssignProp(sPrefix, false, edtEstadoTicketNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketNombre_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV22Att_EstadoTicketNombre_Visible = true;
         AssignAttri(sPrefix, false, "AV22Att_EstadoTicketNombre_Visible", AV22Att_EstadoTicketNombre_Visible);
         edtTicketLastId_Visible = 1;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV23Att_TicketLastId_Visible = true;
         AssignAttri(sPrefix, false, "AV23Att_TicketLastId_Visible", AV23Att_TicketLastId_Visible);
         chkTicketLaptop.Visible = 1;
         AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketLaptop.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV24Att_TicketLaptop_Visible = true;
         AssignAttri(sPrefix, false, "AV24Att_TicketLaptop_Visible", AV24Att_TicketLaptop_Visible);
         chkTicketDesktop.Visible = 1;
         AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDesktop.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV25Att_TicketDesktop_Visible = true;
         AssignAttri(sPrefix, false, "AV25Att_TicketDesktop_Visible", AV25Att_TicketDesktop_Visible);
         chkTicketMonitor.Visible = 1;
         AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketMonitor.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV26Att_TicketMonitor_Visible = true;
         AssignAttri(sPrefix, false, "AV26Att_TicketMonitor_Visible", AV26Att_TicketMonitor_Visible);
         chkTicketImpresora.Visible = 1;
         AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketImpresora.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV27Att_TicketImpresora_Visible = true;
         AssignAttri(sPrefix, false, "AV27Att_TicketImpresora_Visible", AV27Att_TicketImpresora_Visible);
         chkTicketEscaner.Visible = 1;
         AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketEscaner.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV28Att_TicketEscaner_Visible = true;
         AssignAttri(sPrefix, false, "AV28Att_TicketEscaner_Visible", AV28Att_TicketEscaner_Visible);
         chkTicketRouter.Visible = 1;
         AssignProp(sPrefix, false, chkTicketRouter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketRouter.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV29Att_TicketRouter_Visible = true;
         AssignAttri(sPrefix, false, "AV29Att_TicketRouter_Visible", AV29Att_TicketRouter_Visible);
         chkTicketSistemaOperativo.Visible = 1;
         AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketSistemaOperativo.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV30Att_TicketSistemaOperativo_Visible = true;
         AssignAttri(sPrefix, false, "AV30Att_TicketSistemaOperativo_Visible", AV30Att_TicketSistemaOperativo_Visible);
         chkTicketOffice.Visible = 1;
         AssignProp(sPrefix, false, chkTicketOffice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketOffice.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV31Att_TicketOffice_Visible = true;
         AssignAttri(sPrefix, false, "AV31Att_TicketOffice_Visible", AV31Att_TicketOffice_Visible);
         chkTicketAntivirus.Visible = 1;
         AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketAntivirus.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV32Att_TicketAntivirus_Visible = true;
         AssignAttri(sPrefix, false, "AV32Att_TicketAntivirus_Visible", AV32Att_TicketAntivirus_Visible);
         chkTicketAplicacion.Visible = 1;
         AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketAplicacion.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV33Att_TicketAplicacion_Visible = true;
         AssignAttri(sPrefix, false, "AV33Att_TicketAplicacion_Visible", AV33Att_TicketAplicacion_Visible);
         chkTicketDisenio.Visible = 1;
         AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDisenio.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV34Att_TicketDisenio_Visible = true;
         AssignAttri(sPrefix, false, "AV34Att_TicketDisenio_Visible", AV34Att_TicketDisenio_Visible);
         chkTicketIngenieria.Visible = 1;
         AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketIngenieria.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV35Att_TicketIngenieria_Visible = true;
         AssignAttri(sPrefix, false, "AV35Att_TicketIngenieria_Visible", AV35Att_TicketIngenieria_Visible);
         chkTicketDiscoDuroExterno.Visible = 1;
         AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDiscoDuroExterno.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV36Att_TicketDiscoDuroExterno_Visible = true;
         AssignAttri(sPrefix, false, "AV36Att_TicketDiscoDuroExterno_Visible", AV36Att_TicketDiscoDuroExterno_Visible);
         chkTicketPerifericos.Visible = 1;
         AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketPerifericos.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV37Att_TicketPerifericos_Visible = true;
         AssignAttri(sPrefix, false, "AV37Att_TicketPerifericos_Visible", AV37Att_TicketPerifericos_Visible);
         chkTicketUps.Visible = 1;
         AssignProp(sPrefix, false, chkTicketUps_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketUps.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV38Att_TicketUps_Visible = true;
         AssignAttri(sPrefix, false, "AV38Att_TicketUps_Visible", AV38Att_TicketUps_Visible);
         chkTicketApoyoUsuario.Visible = 1;
         AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketApoyoUsuario.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV39Att_TicketApoyoUsuario_Visible = true;
         AssignAttri(sPrefix, false, "AV39Att_TicketApoyoUsuario_Visible", AV39Att_TicketApoyoUsuario_Visible);
         chkTicketInstalarDataShow.Visible = 1;
         AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketInstalarDataShow.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV40Att_TicketInstalarDataShow_Visible = true;
         AssignAttri(sPrefix, false, "AV40Att_TicketInstalarDataShow_Visible", AV40Att_TicketInstalarDataShow_Visible);
         chkTicketOtros.Visible = 1;
         AssignProp(sPrefix, false, chkTicketOtros_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketOtros.Visible), 5, 0), !bGXsfl_288_Refreshing);
         AV41Att_TicketOtros_Visible = true;
         AssignAttri(sPrefix, false, "AV41Att_TicketOtros_Visible", AV41Att_TicketOtros_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV80Pgmname,  "Grid",  AV11GridConfiguration,  false) ;
         AV85GXV3 = 1;
         while ( AV85GXV3 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV85GXV3));
            if ( ! AV14GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  edtTicketId_Visible = 0;
                  AssignProp(sPrefix, false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV15Att_TicketId_Visible = false;
                  AssignAttri(sPrefix, false, "AV15Att_TicketId_Visible", AV15Att_TicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  edtTicketFecha_Visible = 0;
                  AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV16Att_TicketFecha_Visible = false;
                  AssignAttri(sPrefix, false, "AV16Att_TicketFecha_Visible", AV16Att_TicketFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  edtTicketHora_Visible = 0;
                  AssignProp(sPrefix, false, edtTicketHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketHora_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV17Att_TicketHora_Visible = false;
                  AssignAttri(sPrefix, false, "AV17Att_TicketHora_Visible", AV17Att_TicketHora_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  edtUsuarioId_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV18Att_UsuarioId_Visible = false;
                  AssignAttri(sPrefix, false, "AV18Att_UsuarioId_Visible", AV18Att_UsuarioId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV19Att_UsuarioNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV19Att_UsuarioNombre_Visible", AV19Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV20Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri(sPrefix, false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "EstadoTicketId") == 0 )
               {
                  edtEstadoTicketId_Visible = 0;
                  AssignProp(sPrefix, false, edtEstadoTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketId_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV21Att_EstadoTicketId_Visible = false;
                  AssignAttri(sPrefix, false, "AV21Att_EstadoTicketId_Visible", AV21Att_EstadoTicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "EstadoTicketNombre") == 0 )
               {
                  edtEstadoTicketNombre_Visible = 0;
                  AssignProp(sPrefix, false, edtEstadoTicketNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketNombre_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV22Att_EstadoTicketNombre_Visible = false;
                  AssignAttri(sPrefix, false, "AV22Att_EstadoTicketNombre_Visible", AV22Att_EstadoTicketNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketLastId") == 0 )
               {
                  edtTicketLastId_Visible = 0;
                  AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV23Att_TicketLastId_Visible = false;
                  AssignAttri(sPrefix, false, "AV23Att_TicketLastId_Visible", AV23Att_TicketLastId_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketLaptop") == 0 )
               {
                  chkTicketLaptop.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketLaptop.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV24Att_TicketLaptop_Visible = false;
                  AssignAttri(sPrefix, false, "AV24Att_TicketLaptop_Visible", AV24Att_TicketLaptop_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDesktop") == 0 )
               {
                  chkTicketDesktop.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDesktop.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV25Att_TicketDesktop_Visible = false;
                  AssignAttri(sPrefix, false, "AV25Att_TicketDesktop_Visible", AV25Att_TicketDesktop_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketMonitor") == 0 )
               {
                  chkTicketMonitor.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketMonitor.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV26Att_TicketMonitor_Visible = false;
                  AssignAttri(sPrefix, false, "AV26Att_TicketMonitor_Visible", AV26Att_TicketMonitor_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketImpresora") == 0 )
               {
                  chkTicketImpresora.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketImpresora.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV27Att_TicketImpresora_Visible = false;
                  AssignAttri(sPrefix, false, "AV27Att_TicketImpresora_Visible", AV27Att_TicketImpresora_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketEscaner") == 0 )
               {
                  chkTicketEscaner.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketEscaner.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV28Att_TicketEscaner_Visible = false;
                  AssignAttri(sPrefix, false, "AV28Att_TicketEscaner_Visible", AV28Att_TicketEscaner_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketRouter") == 0 )
               {
                  chkTicketRouter.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketRouter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketRouter.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV29Att_TicketRouter_Visible = false;
                  AssignAttri(sPrefix, false, "AV29Att_TicketRouter_Visible", AV29Att_TicketRouter_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketSistemaOperativo") == 0 )
               {
                  chkTicketSistemaOperativo.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketSistemaOperativo.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV30Att_TicketSistemaOperativo_Visible = false;
                  AssignAttri(sPrefix, false, "AV30Att_TicketSistemaOperativo_Visible", AV30Att_TicketSistemaOperativo_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketOffice") == 0 )
               {
                  chkTicketOffice.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketOffice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketOffice.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV31Att_TicketOffice_Visible = false;
                  AssignAttri(sPrefix, false, "AV31Att_TicketOffice_Visible", AV31Att_TicketOffice_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketAntivirus") == 0 )
               {
                  chkTicketAntivirus.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketAntivirus.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV32Att_TicketAntivirus_Visible = false;
                  AssignAttri(sPrefix, false, "AV32Att_TicketAntivirus_Visible", AV32Att_TicketAntivirus_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketAplicacion") == 0 )
               {
                  chkTicketAplicacion.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketAplicacion.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV33Att_TicketAplicacion_Visible = false;
                  AssignAttri(sPrefix, false, "AV33Att_TicketAplicacion_Visible", AV33Att_TicketAplicacion_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDisenio") == 0 )
               {
                  chkTicketDisenio.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDisenio.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV34Att_TicketDisenio_Visible = false;
                  AssignAttri(sPrefix, false, "AV34Att_TicketDisenio_Visible", AV34Att_TicketDisenio_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketIngenieria") == 0 )
               {
                  chkTicketIngenieria.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketIngenieria.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV35Att_TicketIngenieria_Visible = false;
                  AssignAttri(sPrefix, false, "AV35Att_TicketIngenieria_Visible", AV35Att_TicketIngenieria_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDiscoDuroExterno") == 0 )
               {
                  chkTicketDiscoDuroExterno.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketDiscoDuroExterno.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV36Att_TicketDiscoDuroExterno_Visible = false;
                  AssignAttri(sPrefix, false, "AV36Att_TicketDiscoDuroExterno_Visible", AV36Att_TicketDiscoDuroExterno_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketPerifericos") == 0 )
               {
                  chkTicketPerifericos.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketPerifericos.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV37Att_TicketPerifericos_Visible = false;
                  AssignAttri(sPrefix, false, "AV37Att_TicketPerifericos_Visible", AV37Att_TicketPerifericos_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketUps") == 0 )
               {
                  chkTicketUps.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketUps_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketUps.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV38Att_TicketUps_Visible = false;
                  AssignAttri(sPrefix, false, "AV38Att_TicketUps_Visible", AV38Att_TicketUps_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketApoyoUsuario") == 0 )
               {
                  chkTicketApoyoUsuario.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketApoyoUsuario.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV39Att_TicketApoyoUsuario_Visible = false;
                  AssignAttri(sPrefix, false, "AV39Att_TicketApoyoUsuario_Visible", AV39Att_TicketApoyoUsuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketInstalarDataShow") == 0 )
               {
                  chkTicketInstalarDataShow.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketInstalarDataShow.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV40Att_TicketInstalarDataShow_Visible = false;
                  AssignAttri(sPrefix, false, "AV40Att_TicketInstalarDataShow_Visible", AV40Att_TicketInstalarDataShow_Visible);
               }
               else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketOtros") == 0 )
               {
                  chkTicketOtros.Visible = 0;
                  AssignProp(sPrefix, false, chkTicketOtros_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkTicketOtros.Visible), 5, 0), !bGXsfl_288_Refreshing);
                  AV41Att_TicketOtros_Visible = false;
                  AssignAttri(sPrefix, false, "AV41Att_TicketOtros_Visible", AV41Att_TicketOtros_Visible);
               }
            }
            AV85GXV3 = (int)(AV85GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketId";
         AV14GridColumn.gxTpr_Columntitle = "RST No.";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketFecha";
         AV14GridColumn.gxTpr_Columntitle = "Fecha:";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketHora";
         AV14GridColumn.gxTpr_Columntitle = "Hora:";
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
         AV14GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV14GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "EstadoTicketId";
         AV14GridColumn.gxTpr_Columntitle = "Id";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "EstadoTicketNombre";
         AV14GridColumn.gxTpr_Columntitle = "Estado Ticket";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketLastId";
         AV14GridColumn.gxTpr_Columntitle = "Last Id";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketLaptop";
         AV14GridColumn.gxTpr_Columntitle = "aptop";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketDesktop";
         AV14GridColumn.gxTpr_Columntitle = "Desktop";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketMonitor";
         AV14GridColumn.gxTpr_Columntitle = "Monitor";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketImpresora";
         AV14GridColumn.gxTpr_Columntitle = "Impresora";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketEscaner";
         AV14GridColumn.gxTpr_Columntitle = "Escaner";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketRouter";
         AV14GridColumn.gxTpr_Columntitle = "Internet/Router/Access Point";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketSistemaOperativo";
         AV14GridColumn.gxTpr_Columntitle = "Operativo";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketOffice";
         AV14GridColumn.gxTpr_Columntitle = "Office";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketAntivirus";
         AV14GridColumn.gxTpr_Columntitle = "Antivirus";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketAplicacion";
         AV14GridColumn.gxTpr_Columntitle = "Aplicación";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketDisenio";
         AV14GridColumn.gxTpr_Columntitle = "Diseño";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketIngenieria";
         AV14GridColumn.gxTpr_Columntitle = "Ingeniería";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketDiscoDuroExterno";
         AV14GridColumn.gxTpr_Columntitle = "Duro ";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketPerifericos";
         AV14GridColumn.gxTpr_Columntitle = "Periféricos";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketUps";
         AV14GridColumn.gxTpr_Columntitle = "UPS";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketApoyoUsuario";
         AV14GridColumn.gxTpr_Columntitle = "Usuario";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketInstalarDataShow";
         AV14GridColumn.gxTpr_Columntitle = "Data Show";
         AV14GridColumn.gxTpr_Showattribute = true;
         AV13GridColumns.Add(AV14GridColumn, 0);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV14GridColumn.gxTpr_Attributename = "TicketOtros";
         AV14GridColumn.gxTpr_Columntitle = "Otros";
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
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportEstadoTicketTicketWC";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportEstadoTicketTicketWC";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp(sPrefix, false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp(sPrefix, false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV69ActivityList.Add(AV71ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV69ActivityList) ;
         AV72TicketFecha_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri(sPrefix, false, "AV72TicketFecha_IsAuthorized", AV72TicketFecha_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_288_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_288_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV69ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_288_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_288_Refreshing);
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

      protected void E242H2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV48ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp(sPrefix, false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp(sPrefix, false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV73Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         AV82Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_288_Refreshing);
         AV74Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV74Delete))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV74Delete), true);
         AV83Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV74Delete))), !bGXsfl_288_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV74Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_288_Refreshing);
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
         AV70AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV70AutoLinksActivityList.Add(AV71ActivityListItem, 0);
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTicket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTicket";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV71ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTicket";
         AV70AutoLinksActivityList.Add(AV71ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV70AutoLinksActivityList) ;
         AV64UC_OrderedBy = AV61OrderedBy;
         AssignAttri(sPrefix, false, "AV64UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV64UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV48ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV70AutoLinksActivityList", AV70AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV58FilterTags", AV58FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
      }

      private void E252H2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV70AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV70AutoLinksActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtEstadoTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A5EstadoTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
         }
         if ( AV72TicketFecha_IsAuthorized )
         {
            edtTicketFecha_Link = formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketId","TabCode"}) ;
         }
         else
         {
            edtTicketFecha_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 288;
         }
         sendrow_2882( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_288_Refreshing )
         {
            context.DoAjaxLoad(288, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV56K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV50TicketFecha_From) || ! (DateTime.MinValue==AV51TicketFecha_To) )
         {
            AV57K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV57K2BFilterValuesSDTItem.gxTpr_Name = "TicketFecha";
            AV57K2BFilterValuesSDTItem.gxTpr_Description = "Fecha:";
            AV57K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV57K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV57K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TicketFecha_From ) ;
            AV57K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TicketFecha_To ) ;
            AV57K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV56K2BFilterValuesSDT.Add(AV57K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV53TicketHora_From) || ! (DateTime.MinValue==AV54TicketHora_To) )
         {
            AV57K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV57K2BFilterValuesSDTItem.gxTpr_Name = "TicketHora";
            AV57K2BFilterValuesSDTItem.gxTpr_Description = "Hora:";
            AV57K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV57K2BFilterValuesSDTItem.gxTpr_Type = "DateTimeRange";
            AV57K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            AV57K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = AV53TicketHora_From;
            AV57K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = AV54TicketHora_To;
            AV56K2BFilterValuesSDT.Add(AV57K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55UsuarioNombre)) )
         {
            AV57K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV57K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioNombre";
            AV57K2BFilterValuesSDTItem.gxTpr_Description = "Usuario";
            AV57K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV57K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV57K2BFilterValuesSDTItem.gxTpr_Value = AV55UsuarioNombre;
            AV57K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV55UsuarioNombre;
            AV56K2BFilterValuesSDT.Add(AV57K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, sPrefix, false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV56K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV58FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV80Pgmname,  "Grid",  AV56K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV58FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112H2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV59DeletedTag, "TicketFecha") == 0 )
         {
            AV50TicketFecha_From = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV50TicketFecha_From", context.localUtil.Format(AV50TicketFecha_From, "99/99/9999"));
            AV51TicketFecha_To = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV51TicketFecha_To", context.localUtil.Format(AV51TicketFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV59DeletedTag, "TicketHora") == 0 )
         {
            AV53TicketHora_From = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV53TicketHora_From", context.localUtil.TToC( AV53TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            AV54TicketHora_To = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV54TicketHora_To", context.localUtil.TToC( AV54TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
         }
         else if ( StringUtil.StrCmp(AV59DeletedTag, "UsuarioNombre") == 0 )
         {
            AV55UsuarioNombre = "";
            AssignAttri(sPrefix, false, "AV55UsuarioNombre", AV55UsuarioNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void E122H2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV61OrderedBy = AV64UC_OrderedBy;
         AssignAttri(sPrefix, false, "AV61OrderedBy", StringUtil.LTrimStr( (decimal)(AV61OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void E142H2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV80Pgmname,  "Grid", ref  AV11GridConfiguration) ;
         AV86GXV4 = 1;
         while ( AV86GXV4 <= AV11GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV14GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV11GridConfiguration.gxTpr_Gridcolumns.Item(AV86GXV4));
            if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV15Att_TicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV16Att_TicketFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV17Att_TicketHora_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV18Att_UsuarioId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV19Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV20Att_UsuarioRequerimiento_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "EstadoTicketId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV21Att_EstadoTicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "EstadoTicketNombre") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV22Att_EstadoTicketNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketLastId") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV23Att_TicketLastId_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketLaptop") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV24Att_TicketLaptop_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDesktop") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV25Att_TicketDesktop_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketMonitor") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV26Att_TicketMonitor_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketImpresora") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV27Att_TicketImpresora_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketEscaner") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV28Att_TicketEscaner_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketRouter") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV29Att_TicketRouter_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketSistemaOperativo") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV30Att_TicketSistemaOperativo_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketOffice") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV31Att_TicketOffice_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketAntivirus") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV32Att_TicketAntivirus_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketAplicacion") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV33Att_TicketAplicacion_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDisenio") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV34Att_TicketDisenio_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketIngenieria") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV35Att_TicketIngenieria_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketDiscoDuroExterno") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV36Att_TicketDiscoDuroExterno_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketPerifericos") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV37Att_TicketPerifericos_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketUps") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV38Att_TicketUps_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketApoyoUsuario") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV39Att_TicketApoyoUsuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketInstalarDataShow") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV40Att_TicketInstalarDataShow_Visible;
            }
            else if ( StringUtil.StrCmp(AV14GridColumn.gxTpr_Attributename, "TicketOtros") == 0 )
            {
               AV14GridColumn.gxTpr_Showattribute = AV41Att_TicketOtros_Visible;
            }
            AV86GXV4 = (int)(AV86GXV4+1);
         }
         AV11GridConfiguration.gxTpr_Freezecolumntitles = AV12FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV80Pgmname,  "Grid",  AV11GridConfiguration,  true) ;
         AV64UC_OrderedBy = AV61OrderedBy;
         AssignAttri(sPrefix, false, "AV64UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV64UC_OrderedBy), 4, 0));
         if ( AV43RowsPerPageVariable != AV42GridSettingsRowsPerPageVariable )
         {
            AV43RowsPerPageVariable = AV42GridSettingsRowsPerPageVariable;
            AssignAttri(sPrefix, false, "AV43RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV43RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV43RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV80Pgmname,  "Grid",  AV43RowsPerPageVariable) ;
            AV9CurrentPage = 1;
            AssignAttri(sPrefix, false, "AV9CurrentPage", StringUtil.LTrimStr( (decimal)(AV9CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV60K2BToolsGenericSearchField, AV50TicketFecha_From, AV53TicketHora_From, AV54TicketHora_To, AV55UsuarioNombre, A17EstadoTicketTecnicoId, AV6EstadoTicketTecnicoId, AV48ClassCollection, AV61OrderedBy, AV51TicketFecha_To, AV80Pgmname, AV9CurrentPage, AV11GridConfiguration, AV70AutoLinksActivityList, A5EstadoTicketId, AV72TicketFecha_IsAuthorized, AV15Att_TicketId_Visible, AV16Att_TicketFecha_Visible, AV17Att_TicketHora_Visible, AV18Att_UsuarioId_Visible, AV19Att_UsuarioNombre_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_EstadoTicketId_Visible, AV22Att_EstadoTicketNombre_Visible, AV23Att_TicketLastId_Visible, AV24Att_TicketLaptop_Visible, AV25Att_TicketDesktop_Visible, AV26Att_TicketMonitor_Visible, AV27Att_TicketImpresora_Visible, AV28Att_TicketEscaner_Visible, AV29Att_TicketRouter_Visible, AV30Att_TicketSistemaOperativo_Visible, AV31Att_TicketOffice_Visible, AV32Att_TicketAntivirus_Visible, AV33Att_TicketAplicacion_Visible, AV34Att_TicketDisenio_Visible, AV35Att_TicketIngenieria_Visible, AV36Att_TicketDiscoDuroExterno_Visible, AV37Att_TicketPerifericos_Visible, AV38Att_TicketUps_Visible, AV39Att_TicketApoyoUsuario_Visible, AV40Att_TicketInstalarDataShow_Visible, AV41Att_TicketOtros_Visible, AV12FreezeColumnTitles, AV77Uri, sPrefix) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp(sPrefix, false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridConfiguration", AV11GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
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

      protected void E152H2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void E162H2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void E172H2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
      }

      protected void E182H2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection", AV48ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV80Pgmname,  "Grid", ref  AV11GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV48ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV48ClassCollection) ;
         }
      }

      protected void E192H2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  "ExportEstadoTicketTicketWC") )
         {
            new exportestadoticketticketwc(context ).execute(  AV6EstadoTicketTecnicoId,  AV50TicketFecha_From,  AV51TicketFecha_To,  AV53TicketHora_From,  AV54TicketHora_To,  AV55UsuarioNombre,  AV60K2BToolsGenericSearchField,  AV61OrderedBy, out  AV75OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV75OutFile, out  AV77Uri) )
            {
               CallWebObject(formatLink(AV77Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV76Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV76Guid.ToString(),  AV75OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV76Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202H2( )
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

      protected void E212H2( )
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

      protected void wb_table2_320_2H2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_320_2H2e( true) ;
         }
         else
         {
            wb_table2_320_2H2e( false) ;
         }
      }

      protected void wb_table1_58_2H2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e262h1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoTicketTicketWC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_EstadoTicketTicketWC.htm");
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
            GxWebStd.gx_div_start( context, divTicketid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketid_visible_Internalname, "RST No.", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketid_visible_Internalname, StringUtil.BoolToStr( AV15Att_TicketId_Visible), "", "RST No.", 1, chkavAtt_ticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(87, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,87);\"");
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
            GxWebStd.gx_div_start( context, divTicketfecha_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketfecha_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketfecha_visible_Internalname, "Fecha:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketfecha_visible_Internalname, StringUtil.BoolToStr( AV16Att_TicketFecha_Visible), "", "Fecha:", 1, chkavAtt_ticketfecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
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
            GxWebStd.gx_div_start( context, divTickethora_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickethora_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickethora_visible_Internalname, "Hora:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickethora_visible_Internalname, StringUtil.BoolToStr( AV17Att_TicketHora_Visible), "", "Hora:", 1, chkavAtt_tickethora_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarioid_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioId_Visible), "", "Id Usuario", 1, chkavAtt_usuarioid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioNombre_Visible), "", "Usuario", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible), "", "Requerimiento", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(117, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,117);\"");
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
            GxWebStd.gx_div_start( context, divEstadoticketid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estadoticketid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estadoticketid_visible_Internalname, "Id", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estadoticketid_visible_Internalname, StringUtil.BoolToStr( AV21Att_EstadoTicketId_Visible), "", "Id", 1, chkavAtt_estadoticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,123);\"");
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
            GxWebStd.gx_div_start( context, divEstadoticketnombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estadoticketnombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estadoticketnombre_visible_Internalname, "Estado Ticket", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estadoticketnombre_visible_Internalname, StringUtil.BoolToStr( AV22Att_EstadoTicketNombre_Visible), "", "Estado Ticket", 1, chkavAtt_estadoticketnombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(129, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,129);\"");
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
            GxWebStd.gx_div_start( context, divTicketlastid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketlastid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketlastid_visible_Internalname, "Last Id", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketlastid_visible_Internalname, StringUtil.BoolToStr( AV23Att_TicketLastId_Visible), "", "Last Id", 1, chkavAtt_ticketlastid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
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
            GxWebStd.gx_div_start( context, divTicketlaptop_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketlaptop_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketlaptop_visible_Internalname, "aptop", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketlaptop_visible_Internalname, StringUtil.BoolToStr( AV24Att_TicketLaptop_Visible), "", "aptop", 1, chkavAtt_ticketlaptop_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(141, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,141);\"");
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
            GxWebStd.gx_div_start( context, divTicketdesktop_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketdesktop_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketdesktop_visible_Internalname, "Desktop", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketdesktop_visible_Internalname, StringUtil.BoolToStr( AV25Att_TicketDesktop_Visible), "", "Desktop", 1, chkavAtt_ticketdesktop_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(147, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,147);\"");
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
            GxWebStd.gx_div_start( context, divTicketmonitor_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketmonitor_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketmonitor_visible_Internalname, "Monitor", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketmonitor_visible_Internalname, StringUtil.BoolToStr( AV26Att_TicketMonitor_Visible), "", "Monitor", 1, chkavAtt_ticketmonitor_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(153, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,153);\"");
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
            GxWebStd.gx_div_start( context, divTicketimpresora_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketimpresora_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketimpresora_visible_Internalname, "Impresora", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketimpresora_visible_Internalname, StringUtil.BoolToStr( AV27Att_TicketImpresora_Visible), "", "Impresora", 1, chkavAtt_ticketimpresora_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(159, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,159);\"");
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
            GxWebStd.gx_div_start( context, divTicketescaner_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketescaner_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketescaner_visible_Internalname, "Escaner", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketescaner_visible_Internalname, StringUtil.BoolToStr( AV28Att_TicketEscaner_Visible), "", "Escaner", 1, chkavAtt_ticketescaner_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(165, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,165);\"");
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
            GxWebStd.gx_div_start( context, divTicketrouter_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketrouter_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketrouter_visible_Internalname, "Internet/Router/Access Point", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketrouter_visible_Internalname, StringUtil.BoolToStr( AV29Att_TicketRouter_Visible), "", "Internet/Router/Access Point", 1, chkavAtt_ticketrouter_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(171, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,171);\"");
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
            GxWebStd.gx_div_start( context, divTicketsistemaoperativo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketsistemaoperativo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketsistemaoperativo_visible_Internalname, "Operativo", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketsistemaoperativo_visible_Internalname, StringUtil.BoolToStr( AV30Att_TicketSistemaOperativo_Visible), "", "Operativo", 1, chkavAtt_ticketsistemaoperativo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(177, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,177);\"");
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
            GxWebStd.gx_div_start( context, divTicketoffice_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketoffice_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketoffice_visible_Internalname, "Office", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketoffice_visible_Internalname, StringUtil.BoolToStr( AV31Att_TicketOffice_Visible), "", "Office", 1, chkavAtt_ticketoffice_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
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
            GxWebStd.gx_div_start( context, divTicketantivirus_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketantivirus_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketantivirus_visible_Internalname, "Antivirus", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketantivirus_visible_Internalname, StringUtil.BoolToStr( AV32Att_TicketAntivirus_Visible), "", "Antivirus", 1, chkavAtt_ticketantivirus_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(189, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,189);\"");
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
            GxWebStd.gx_div_start( context, divTicketaplicacion_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketaplicacion_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketaplicacion_visible_Internalname, "Aplicación", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketaplicacion_visible_Internalname, StringUtil.BoolToStr( AV33Att_TicketAplicacion_Visible), "", "Aplicación", 1, chkavAtt_ticketaplicacion_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(195, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,195);\"");
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
            GxWebStd.gx_div_start( context, divTicketdisenio_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketdisenio_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketdisenio_visible_Internalname, "Diseño", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketdisenio_visible_Internalname, StringUtil.BoolToStr( AV34Att_TicketDisenio_Visible), "", "Diseño", 1, chkavAtt_ticketdisenio_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(201, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,201);\"");
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
            GxWebStd.gx_div_start( context, divTicketingenieria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketingenieria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketingenieria_visible_Internalname, "Ingeniería", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketingenieria_visible_Internalname, StringUtil.BoolToStr( AV35Att_TicketIngenieria_Visible), "", "Ingeniería", 1, chkavAtt_ticketingenieria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(207, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,207);\"");
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
            GxWebStd.gx_div_start( context, divTicketdiscoduroexterno_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketdiscoduroexterno_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketdiscoduroexterno_visible_Internalname, "Duro ", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketdiscoduroexterno_visible_Internalname, StringUtil.BoolToStr( AV36Att_TicketDiscoDuroExterno_Visible), "", "Duro ", 1, chkavAtt_ticketdiscoduroexterno_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(213, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,213);\"");
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
            GxWebStd.gx_div_start( context, divTicketperifericos_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketperifericos_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketperifericos_visible_Internalname, "Periféricos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketperifericos_visible_Internalname, StringUtil.BoolToStr( AV37Att_TicketPerifericos_Visible), "", "Periféricos", 1, chkavAtt_ticketperifericos_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(219, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,219);\"");
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
            GxWebStd.gx_div_start( context, divTicketups_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketups_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketups_visible_Internalname, "UPS", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketups_visible_Internalname, StringUtil.BoolToStr( AV38Att_TicketUps_Visible), "", "UPS", 1, chkavAtt_ticketups_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(225, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,225);\"");
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
            GxWebStd.gx_div_start( context, divTicketapoyousuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketapoyousuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketapoyousuario_visible_Internalname, "Usuario", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketapoyousuario_visible_Internalname, StringUtil.BoolToStr( AV39Att_TicketApoyoUsuario_Visible), "", "Usuario", 1, chkavAtt_ticketapoyousuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(231, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,231);\"");
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
            GxWebStd.gx_div_start( context, divTicketinstalardatashow_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketinstalardatashow_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketinstalardatashow_visible_Internalname, "Data Show", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 237,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketinstalardatashow_visible_Internalname, StringUtil.BoolToStr( AV40Att_TicketInstalarDataShow_Visible), "", "Data Show", 1, chkavAtt_ticketinstalardatashow_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(237, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,237);\"");
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
            GxWebStd.gx_div_start( context, divTicketotros_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketotros_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketotros_visible_Internalname, "Otros", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 243,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketotros_visible_Internalname, StringUtil.BoolToStr( AV41Att_TicketOtros_Visible), "", "Otros", 1, chkavAtt_ticketotros_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(243, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,243);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "", true, 1, "HLP_EstadoTicketTicketWC.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 255,'" + sPrefix + "',false,'" + sGXsfl_288_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV12FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(255, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,255);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(288), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoTicketTicketWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 263,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e272h1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_EstadoTicketTicketWC.htm");
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
            wb_table3_269_2H2( true) ;
         }
         else
         {
            wb_table3_269_2H2( false) ;
         }
         return  ;
      }

      protected void wb_table3_269_2H2e( bool wbgen )
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
            wb_table4_276_2H2( true) ;
         }
         else
         {
            wb_table4_276_2H2( false) ;
         }
         return  ;
      }

      protected void wb_table4_276_2H2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_58_2H2e( true) ;
         }
         else
         {
            wb_table1_58_2H2e( false) ;
         }
      }

      protected void wb_table4_276_2H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 279,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(288), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_276_2H2e( true) ;
         }
         else
         {
            wb_table4_276_2H2e( false) ;
         }
      }

      protected void wb_table3_269_2H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 272,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(288), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e282h1_client"+"'", TempTags, "", 2, "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(288), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoTicketTicketWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_269_2H2e( true) ;
         }
         else
         {
            wb_table3_269_2H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6EstadoTicketTecnicoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6EstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6EstadoTicketTecnicoId), 4, 0));
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
         PA2H2( ) ;
         WS2H2( ) ;
         WE2H2( ) ;
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
         sCtrlAV6EstadoTicketTecnicoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "estadoticketticketwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6EstadoTicketTecnicoId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6EstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6EstadoTicketTecnicoId), 4, 0));
         }
         wcpOAV6EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6EstadoTicketTecnicoId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6EstadoTicketTecnicoId != wcpOAV6EstadoTicketTecnicoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6EstadoTicketTecnicoId = AV6EstadoTicketTecnicoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6EstadoTicketTecnicoId = cgiGet( sPrefix+"AV6EstadoTicketTecnicoId_CTRL");
         if ( StringUtil.Len( sCtrlAV6EstadoTicketTecnicoId) > 0 )
         {
            AV6EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV6EstadoTicketTecnicoId), ".", ","));
            AssignAttri(sPrefix, false, "AV6EstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6EstadoTicketTecnicoId), 4, 0));
         }
         else
         {
            AV6EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV6EstadoTicketTecnicoId_PARM"), ".", ","));
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
         PA2H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2H2( ) ;
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
         WS2H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6EstadoTicketTecnicoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EstadoTicketTecnicoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6EstadoTicketTecnicoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6EstadoTicketTecnicoId_CTRL", StringUtil.RTrim( sCtrlAV6EstadoTicketTecnicoId));
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
            WE2H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188125857", true, true);
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
         context.AddJavascriptSource("estadoticketticketwc.js", "?2024188125857", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/bootstrap-daterangepicker/daterangepicker.js", "", false, true);
         context.AddJavascriptSource("K2BDateRangePicker/K2BDateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_2882( )
      {
         edtTicketId_Internalname = sPrefix+"TICKETID_"+sGXsfl_288_idx;
         edtTicketFecha_Internalname = sPrefix+"TICKETFECHA_"+sGXsfl_288_idx;
         edtTicketHora_Internalname = sPrefix+"TICKETHORA_"+sGXsfl_288_idx;
         edtUsuarioId_Internalname = sPrefix+"USUARIOID_"+sGXsfl_288_idx;
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE_"+sGXsfl_288_idx;
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO_"+sGXsfl_288_idx;
         edtEstadoTicketId_Internalname = sPrefix+"ESTADOTICKETID_"+sGXsfl_288_idx;
         edtEstadoTicketNombre_Internalname = sPrefix+"ESTADOTICKETNOMBRE_"+sGXsfl_288_idx;
         edtTicketLastId_Internalname = sPrefix+"TICKETLASTID_"+sGXsfl_288_idx;
         chkTicketLaptop_Internalname = sPrefix+"TICKETLAPTOP_"+sGXsfl_288_idx;
         chkTicketDesktop_Internalname = sPrefix+"TICKETDESKTOP_"+sGXsfl_288_idx;
         chkTicketMonitor_Internalname = sPrefix+"TICKETMONITOR_"+sGXsfl_288_idx;
         chkTicketImpresora_Internalname = sPrefix+"TICKETIMPRESORA_"+sGXsfl_288_idx;
         chkTicketEscaner_Internalname = sPrefix+"TICKETESCANER_"+sGXsfl_288_idx;
         chkTicketRouter_Internalname = sPrefix+"TICKETROUTER_"+sGXsfl_288_idx;
         chkTicketSistemaOperativo_Internalname = sPrefix+"TICKETSISTEMAOPERATIVO_"+sGXsfl_288_idx;
         chkTicketOffice_Internalname = sPrefix+"TICKETOFFICE_"+sGXsfl_288_idx;
         chkTicketAntivirus_Internalname = sPrefix+"TICKETANTIVIRUS_"+sGXsfl_288_idx;
         chkTicketAplicacion_Internalname = sPrefix+"TICKETAPLICACION_"+sGXsfl_288_idx;
         chkTicketDisenio_Internalname = sPrefix+"TICKETDISENIO_"+sGXsfl_288_idx;
         chkTicketIngenieria_Internalname = sPrefix+"TICKETINGENIERIA_"+sGXsfl_288_idx;
         chkTicketDiscoDuroExterno_Internalname = sPrefix+"TICKETDISCODUROEXTERNO_"+sGXsfl_288_idx;
         chkTicketPerifericos_Internalname = sPrefix+"TICKETPERIFERICOS_"+sGXsfl_288_idx;
         chkTicketUps_Internalname = sPrefix+"TICKETUPS_"+sGXsfl_288_idx;
         chkTicketApoyoUsuario_Internalname = sPrefix+"TICKETAPOYOUSUARIO_"+sGXsfl_288_idx;
         chkTicketInstalarDataShow_Internalname = sPrefix+"TICKETINSTALARDATASHOW_"+sGXsfl_288_idx;
         chkTicketOtros_Internalname = sPrefix+"TICKETOTROS_"+sGXsfl_288_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_288_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_288_idx;
      }

      protected void SubsflControlProps_fel_2882( )
      {
         edtTicketId_Internalname = sPrefix+"TICKETID_"+sGXsfl_288_fel_idx;
         edtTicketFecha_Internalname = sPrefix+"TICKETFECHA_"+sGXsfl_288_fel_idx;
         edtTicketHora_Internalname = sPrefix+"TICKETHORA_"+sGXsfl_288_fel_idx;
         edtUsuarioId_Internalname = sPrefix+"USUARIOID_"+sGXsfl_288_fel_idx;
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE_"+sGXsfl_288_fel_idx;
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO_"+sGXsfl_288_fel_idx;
         edtEstadoTicketId_Internalname = sPrefix+"ESTADOTICKETID_"+sGXsfl_288_fel_idx;
         edtEstadoTicketNombre_Internalname = sPrefix+"ESTADOTICKETNOMBRE_"+sGXsfl_288_fel_idx;
         edtTicketLastId_Internalname = sPrefix+"TICKETLASTID_"+sGXsfl_288_fel_idx;
         chkTicketLaptop_Internalname = sPrefix+"TICKETLAPTOP_"+sGXsfl_288_fel_idx;
         chkTicketDesktop_Internalname = sPrefix+"TICKETDESKTOP_"+sGXsfl_288_fel_idx;
         chkTicketMonitor_Internalname = sPrefix+"TICKETMONITOR_"+sGXsfl_288_fel_idx;
         chkTicketImpresora_Internalname = sPrefix+"TICKETIMPRESORA_"+sGXsfl_288_fel_idx;
         chkTicketEscaner_Internalname = sPrefix+"TICKETESCANER_"+sGXsfl_288_fel_idx;
         chkTicketRouter_Internalname = sPrefix+"TICKETROUTER_"+sGXsfl_288_fel_idx;
         chkTicketSistemaOperativo_Internalname = sPrefix+"TICKETSISTEMAOPERATIVO_"+sGXsfl_288_fel_idx;
         chkTicketOffice_Internalname = sPrefix+"TICKETOFFICE_"+sGXsfl_288_fel_idx;
         chkTicketAntivirus_Internalname = sPrefix+"TICKETANTIVIRUS_"+sGXsfl_288_fel_idx;
         chkTicketAplicacion_Internalname = sPrefix+"TICKETAPLICACION_"+sGXsfl_288_fel_idx;
         chkTicketDisenio_Internalname = sPrefix+"TICKETDISENIO_"+sGXsfl_288_fel_idx;
         chkTicketIngenieria_Internalname = sPrefix+"TICKETINGENIERIA_"+sGXsfl_288_fel_idx;
         chkTicketDiscoDuroExterno_Internalname = sPrefix+"TICKETDISCODUROEXTERNO_"+sGXsfl_288_fel_idx;
         chkTicketPerifericos_Internalname = sPrefix+"TICKETPERIFERICOS_"+sGXsfl_288_fel_idx;
         chkTicketUps_Internalname = sPrefix+"TICKETUPS_"+sGXsfl_288_fel_idx;
         chkTicketApoyoUsuario_Internalname = sPrefix+"TICKETAPOYOUSUARIO_"+sGXsfl_288_fel_idx;
         chkTicketInstalarDataShow_Internalname = sPrefix+"TICKETINSTALARDATASHOW_"+sGXsfl_288_fel_idx;
         chkTicketOtros_Internalname = sPrefix+"TICKETOTROS_"+sGXsfl_288_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_288_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_288_fel_idx;
      }

      protected void sendrow_2882( )
      {
         SubsflControlProps_2882( ) ;
         WB2H0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_288_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_288_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_288_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFecha_Internalname,context.localUtil.Format(A46TicketFecha, "99/99/9999"),context.localUtil.Format( A46TicketFecha, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtTicketFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtTicketFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHora_Internalname,context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A48TicketHora, "99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtEstadoTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EstadoTicketId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EstadoTicketId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtEstadoTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtEstadoTicketNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketNombre_Internalname,(string)A24EstadoTicketNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtEstadoTicketNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadoTicketNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtEstadoTicketNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketLastId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketLastId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketLastId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketLastId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)288,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketLaptop.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETLAPTOP_" + sGXsfl_288_idx;
            chkTicketLaptop.Name = GXCCtl;
            chkTicketLaptop.WebTags = "";
            chkTicketLaptop.Caption = "";
            AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_288_Refreshing);
            chkTicketLaptop.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketLaptop_Internalname,StringUtil.BoolToStr( A53TicketLaptop),(string)"",(string)"",chkTicketLaptop.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketDesktop.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDESKTOP_" + sGXsfl_288_idx;
            chkTicketDesktop.Name = GXCCtl;
            chkTicketDesktop.WebTags = "";
            chkTicketDesktop.Caption = "";
            AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_288_Refreshing);
            chkTicketDesktop.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDesktop_Internalname,StringUtil.BoolToStr( A42TicketDesktop),(string)"",(string)"",chkTicketDesktop.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketMonitor.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETMONITOR_" + sGXsfl_288_idx;
            chkTicketMonitor.Name = GXCCtl;
            chkTicketMonitor.WebTags = "";
            chkTicketMonitor.Caption = "";
            AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_288_Refreshing);
            chkTicketMonitor.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketMonitor_Internalname,StringUtil.BoolToStr( A55TicketMonitor),(string)"",(string)"",chkTicketMonitor.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketImpresora.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETIMPRESORA_" + sGXsfl_288_idx;
            chkTicketImpresora.Name = GXCCtl;
            chkTicketImpresora.WebTags = "";
            chkTicketImpresora.Caption = "";
            AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_288_Refreshing);
            chkTicketImpresora.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketImpresora_Internalname,StringUtil.BoolToStr( A50TicketImpresora),(string)"",(string)"",chkTicketImpresora.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketEscaner.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETESCANER_" + sGXsfl_288_idx;
            chkTicketEscaner.Name = GXCCtl;
            chkTicketEscaner.WebTags = "";
            chkTicketEscaner.Caption = "";
            AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_288_Refreshing);
            chkTicketEscaner.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketEscaner_Internalname,StringUtil.BoolToStr( A45TicketEscaner),(string)"",(string)"",chkTicketEscaner.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketRouter.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETROUTER_" + sGXsfl_288_idx;
            chkTicketRouter.Name = GXCCtl;
            chkTicketRouter.WebTags = "";
            chkTicketRouter.Caption = "";
            AssignProp(sPrefix, false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_288_Refreshing);
            chkTicketRouter.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketRouter_Internalname,StringUtil.BoolToStr( A59TicketRouter),(string)"",(string)"",chkTicketRouter.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketSistemaOperativo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_288_idx;
            chkTicketSistemaOperativo.Name = GXCCtl;
            chkTicketSistemaOperativo.WebTags = "";
            chkTicketSistemaOperativo.Caption = "";
            AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_288_Refreshing);
            chkTicketSistemaOperativo.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketSistemaOperativo_Internalname,StringUtil.BoolToStr( A60TicketSistemaOperativo),(string)"",(string)"",chkTicketSistemaOperativo.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketOffice.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETOFFICE_" + sGXsfl_288_idx;
            chkTicketOffice.Name = GXCCtl;
            chkTicketOffice.WebTags = "";
            chkTicketOffice.Caption = "";
            AssignProp(sPrefix, false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_288_Refreshing);
            chkTicketOffice.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketOffice_Internalname,StringUtil.BoolToStr( A56TicketOffice),(string)"",(string)"",chkTicketOffice.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketAntivirus.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_288_idx;
            chkTicketAntivirus.Name = GXCCtl;
            chkTicketAntivirus.WebTags = "";
            chkTicketAntivirus.Caption = "";
            AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_288_Refreshing);
            chkTicketAntivirus.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketAntivirus_Internalname,StringUtil.BoolToStr( A39TicketAntivirus),(string)"",(string)"",chkTicketAntivirus.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketAplicacion.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETAPLICACION_" + sGXsfl_288_idx;
            chkTicketAplicacion.Name = GXCCtl;
            chkTicketAplicacion.WebTags = "";
            chkTicketAplicacion.Caption = "";
            AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "TitleCaption", chkTicketAplicacion.Caption, !bGXsfl_288_Refreshing);
            chkTicketAplicacion.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketAplicacion_Internalname,StringUtil.BoolToStr( A40TicketAplicacion),(string)"",(string)"",chkTicketAplicacion.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketDisenio.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDISENIO_" + sGXsfl_288_idx;
            chkTicketDisenio.Name = GXCCtl;
            chkTicketDisenio.WebTags = "";
            chkTicketDisenio.Caption = "";
            AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "TitleCaption", chkTicketDisenio.Caption, !bGXsfl_288_Refreshing);
            chkTicketDisenio.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDisenio_Internalname,StringUtil.BoolToStr( A44TicketDisenio),(string)"",(string)"",chkTicketDisenio.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketIngenieria.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETINGENIERIA_" + sGXsfl_288_idx;
            chkTicketIngenieria.Name = GXCCtl;
            chkTicketIngenieria.WebTags = "";
            chkTicketIngenieria.Caption = "";
            AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "TitleCaption", chkTicketIngenieria.Caption, !bGXsfl_288_Refreshing);
            chkTicketIngenieria.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketIngenieria_Internalname,StringUtil.BoolToStr( A51TicketIngenieria),(string)"",(string)"",chkTicketIngenieria.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketDiscoDuroExterno.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_288_idx;
            chkTicketDiscoDuroExterno.Name = GXCCtl;
            chkTicketDiscoDuroExterno.WebTags = "";
            chkTicketDiscoDuroExterno.Caption = "";
            AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_288_Refreshing);
            chkTicketDiscoDuroExterno.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDiscoDuroExterno_Internalname,StringUtil.BoolToStr( A43TicketDiscoDuroExterno),(string)"",(string)"",chkTicketDiscoDuroExterno.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketPerifericos.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_288_idx;
            chkTicketPerifericos.Name = GXCCtl;
            chkTicketPerifericos.WebTags = "";
            chkTicketPerifericos.Caption = "";
            AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_288_Refreshing);
            chkTicketPerifericos.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketPerifericos_Internalname,StringUtil.BoolToStr( A58TicketPerifericos),(string)"",(string)"",chkTicketPerifericos.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketUps.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETUPS_" + sGXsfl_288_idx;
            chkTicketUps.Name = GXCCtl;
            chkTicketUps.WebTags = "";
            chkTicketUps.Caption = "";
            AssignProp(sPrefix, false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_288_Refreshing);
            chkTicketUps.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketUps_Internalname,StringUtil.BoolToStr( A87TicketUps),(string)"",(string)"",chkTicketUps.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketApoyoUsuario.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETAPOYOUSUARIO_" + sGXsfl_288_idx;
            chkTicketApoyoUsuario.Name = GXCCtl;
            chkTicketApoyoUsuario.WebTags = "";
            chkTicketApoyoUsuario.Caption = "";
            AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "TitleCaption", chkTicketApoyoUsuario.Caption, !bGXsfl_288_Refreshing);
            chkTicketApoyoUsuario.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketApoyoUsuario_Internalname,StringUtil.BoolToStr( A41TicketApoyoUsuario),(string)"",(string)"",chkTicketApoyoUsuario.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketInstalarDataShow.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_288_idx;
            chkTicketInstalarDataShow.Name = GXCCtl;
            chkTicketInstalarDataShow.WebTags = "";
            chkTicketInstalarDataShow.Caption = "";
            AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_288_Refreshing);
            chkTicketInstalarDataShow.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketInstalarDataShow_Internalname,StringUtil.BoolToStr( A52TicketInstalarDataShow),(string)"",(string)"",chkTicketInstalarDataShow.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkTicketOtros.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETOTROS_" + sGXsfl_288_idx;
            chkTicketOtros.Name = GXCCtl;
            chkTicketOtros.WebTags = "";
            chkTicketOtros.Caption = "";
            AssignProp(sPrefix, false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_288_Refreshing);
            chkTicketOtros.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketOtros_Internalname,StringUtil.BoolToStr( A57TicketOtros),(string)"",(string)"",chkTicketOtros.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV73Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV73Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV82Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV82Update_GXI : context.PathToRelativeUrl( AV73Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV73Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV74Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV83Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74Delete)) ? AV83Delete_GXI : context.PathToRelativeUrl( AV74Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV74Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2H2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_288_idx = ((subGrid_Islastpage==1)&&(nGXsfl_288_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_288_idx+1);
            sGXsfl_288_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_288_idx), 4, 0), 4, "0");
            SubsflControlProps_2882( ) ;
         }
         /* End function sendrow_2882 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_ticketid_visible.Name = "vATT_TICKETID_VISIBLE";
         chkavAtt_ticketid_visible.WebTags = "";
         chkavAtt_ticketid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketid_visible_Internalname, "TitleCaption", chkavAtt_ticketid_visible.Caption, true);
         chkavAtt_ticketid_visible.CheckedValue = "false";
         chkavAtt_ticketfecha_visible.Name = "vATT_TICKETFECHA_VISIBLE";
         chkavAtt_ticketfecha_visible.WebTags = "";
         chkavAtt_ticketfecha_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketfecha_visible_Internalname, "TitleCaption", chkavAtt_ticketfecha_visible.Caption, true);
         chkavAtt_ticketfecha_visible.CheckedValue = "false";
         chkavAtt_tickethora_visible.Name = "vATT_TICKETHORA_VISIBLE";
         chkavAtt_tickethora_visible.WebTags = "";
         chkavAtt_tickethora_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_tickethora_visible_Internalname, "TitleCaption", chkavAtt_tickethora_visible.Caption, true);
         chkavAtt_tickethora_visible.CheckedValue = "false";
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
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         chkavAtt_estadoticketid_visible.Name = "vATT_ESTADOTICKETID_VISIBLE";
         chkavAtt_estadoticketid_visible.WebTags = "";
         chkavAtt_estadoticketid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_estadoticketid_visible_Internalname, "TitleCaption", chkavAtt_estadoticketid_visible.Caption, true);
         chkavAtt_estadoticketid_visible.CheckedValue = "false";
         chkavAtt_estadoticketnombre_visible.Name = "vATT_ESTADOTICKETNOMBRE_VISIBLE";
         chkavAtt_estadoticketnombre_visible.WebTags = "";
         chkavAtt_estadoticketnombre_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_estadoticketnombre_visible_Internalname, "TitleCaption", chkavAtt_estadoticketnombre_visible.Caption, true);
         chkavAtt_estadoticketnombre_visible.CheckedValue = "false";
         chkavAtt_ticketlastid_visible.Name = "vATT_TICKETLASTID_VISIBLE";
         chkavAtt_ticketlastid_visible.WebTags = "";
         chkavAtt_ticketlastid_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketlastid_visible_Internalname, "TitleCaption", chkavAtt_ticketlastid_visible.Caption, true);
         chkavAtt_ticketlastid_visible.CheckedValue = "false";
         chkavAtt_ticketlaptop_visible.Name = "vATT_TICKETLAPTOP_VISIBLE";
         chkavAtt_ticketlaptop_visible.WebTags = "";
         chkavAtt_ticketlaptop_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketlaptop_visible_Internalname, "TitleCaption", chkavAtt_ticketlaptop_visible.Caption, true);
         chkavAtt_ticketlaptop_visible.CheckedValue = "false";
         chkavAtt_ticketdesktop_visible.Name = "vATT_TICKETDESKTOP_VISIBLE";
         chkavAtt_ticketdesktop_visible.WebTags = "";
         chkavAtt_ticketdesktop_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketdesktop_visible_Internalname, "TitleCaption", chkavAtt_ticketdesktop_visible.Caption, true);
         chkavAtt_ticketdesktop_visible.CheckedValue = "false";
         chkavAtt_ticketmonitor_visible.Name = "vATT_TICKETMONITOR_VISIBLE";
         chkavAtt_ticketmonitor_visible.WebTags = "";
         chkavAtt_ticketmonitor_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketmonitor_visible_Internalname, "TitleCaption", chkavAtt_ticketmonitor_visible.Caption, true);
         chkavAtt_ticketmonitor_visible.CheckedValue = "false";
         chkavAtt_ticketimpresora_visible.Name = "vATT_TICKETIMPRESORA_VISIBLE";
         chkavAtt_ticketimpresora_visible.WebTags = "";
         chkavAtt_ticketimpresora_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketimpresora_visible_Internalname, "TitleCaption", chkavAtt_ticketimpresora_visible.Caption, true);
         chkavAtt_ticketimpresora_visible.CheckedValue = "false";
         chkavAtt_ticketescaner_visible.Name = "vATT_TICKETESCANER_VISIBLE";
         chkavAtt_ticketescaner_visible.WebTags = "";
         chkavAtt_ticketescaner_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketescaner_visible_Internalname, "TitleCaption", chkavAtt_ticketescaner_visible.Caption, true);
         chkavAtt_ticketescaner_visible.CheckedValue = "false";
         chkavAtt_ticketrouter_visible.Name = "vATT_TICKETROUTER_VISIBLE";
         chkavAtt_ticketrouter_visible.WebTags = "";
         chkavAtt_ticketrouter_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketrouter_visible_Internalname, "TitleCaption", chkavAtt_ticketrouter_visible.Caption, true);
         chkavAtt_ticketrouter_visible.CheckedValue = "false";
         chkavAtt_ticketsistemaoperativo_visible.Name = "vATT_TICKETSISTEMAOPERATIVO_VISIBLE";
         chkavAtt_ticketsistemaoperativo_visible.WebTags = "";
         chkavAtt_ticketsistemaoperativo_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketsistemaoperativo_visible_Internalname, "TitleCaption", chkavAtt_ticketsistemaoperativo_visible.Caption, true);
         chkavAtt_ticketsistemaoperativo_visible.CheckedValue = "false";
         chkavAtt_ticketoffice_visible.Name = "vATT_TICKETOFFICE_VISIBLE";
         chkavAtt_ticketoffice_visible.WebTags = "";
         chkavAtt_ticketoffice_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketoffice_visible_Internalname, "TitleCaption", chkavAtt_ticketoffice_visible.Caption, true);
         chkavAtt_ticketoffice_visible.CheckedValue = "false";
         chkavAtt_ticketantivirus_visible.Name = "vATT_TICKETANTIVIRUS_VISIBLE";
         chkavAtt_ticketantivirus_visible.WebTags = "";
         chkavAtt_ticketantivirus_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketantivirus_visible_Internalname, "TitleCaption", chkavAtt_ticketantivirus_visible.Caption, true);
         chkavAtt_ticketantivirus_visible.CheckedValue = "false";
         chkavAtt_ticketaplicacion_visible.Name = "vATT_TICKETAPLICACION_VISIBLE";
         chkavAtt_ticketaplicacion_visible.WebTags = "";
         chkavAtt_ticketaplicacion_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketaplicacion_visible_Internalname, "TitleCaption", chkavAtt_ticketaplicacion_visible.Caption, true);
         chkavAtt_ticketaplicacion_visible.CheckedValue = "false";
         chkavAtt_ticketdisenio_visible.Name = "vATT_TICKETDISENIO_VISIBLE";
         chkavAtt_ticketdisenio_visible.WebTags = "";
         chkavAtt_ticketdisenio_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketdisenio_visible_Internalname, "TitleCaption", chkavAtt_ticketdisenio_visible.Caption, true);
         chkavAtt_ticketdisenio_visible.CheckedValue = "false";
         chkavAtt_ticketingenieria_visible.Name = "vATT_TICKETINGENIERIA_VISIBLE";
         chkavAtt_ticketingenieria_visible.WebTags = "";
         chkavAtt_ticketingenieria_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketingenieria_visible_Internalname, "TitleCaption", chkavAtt_ticketingenieria_visible.Caption, true);
         chkavAtt_ticketingenieria_visible.CheckedValue = "false";
         chkavAtt_ticketdiscoduroexterno_visible.Name = "vATT_TICKETDISCODUROEXTERNO_VISIBLE";
         chkavAtt_ticketdiscoduroexterno_visible.WebTags = "";
         chkavAtt_ticketdiscoduroexterno_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketdiscoduroexterno_visible_Internalname, "TitleCaption", chkavAtt_ticketdiscoduroexterno_visible.Caption, true);
         chkavAtt_ticketdiscoduroexterno_visible.CheckedValue = "false";
         chkavAtt_ticketperifericos_visible.Name = "vATT_TICKETPERIFERICOS_VISIBLE";
         chkavAtt_ticketperifericos_visible.WebTags = "";
         chkavAtt_ticketperifericos_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketperifericos_visible_Internalname, "TitleCaption", chkavAtt_ticketperifericos_visible.Caption, true);
         chkavAtt_ticketperifericos_visible.CheckedValue = "false";
         chkavAtt_ticketups_visible.Name = "vATT_TICKETUPS_VISIBLE";
         chkavAtt_ticketups_visible.WebTags = "";
         chkavAtt_ticketups_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketups_visible_Internalname, "TitleCaption", chkavAtt_ticketups_visible.Caption, true);
         chkavAtt_ticketups_visible.CheckedValue = "false";
         chkavAtt_ticketapoyousuario_visible.Name = "vATT_TICKETAPOYOUSUARIO_VISIBLE";
         chkavAtt_ticketapoyousuario_visible.WebTags = "";
         chkavAtt_ticketapoyousuario_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketapoyousuario_visible_Internalname, "TitleCaption", chkavAtt_ticketapoyousuario_visible.Caption, true);
         chkavAtt_ticketapoyousuario_visible.CheckedValue = "false";
         chkavAtt_ticketinstalardatashow_visible.Name = "vATT_TICKETINSTALARDATASHOW_VISIBLE";
         chkavAtt_ticketinstalardatashow_visible.WebTags = "";
         chkavAtt_ticketinstalardatashow_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketinstalardatashow_visible_Internalname, "TitleCaption", chkavAtt_ticketinstalardatashow_visible.Caption, true);
         chkavAtt_ticketinstalardatashow_visible.CheckedValue = "false";
         chkavAtt_ticketotros_visible.Name = "vATT_TICKETOTROS_VISIBLE";
         chkavAtt_ticketotros_visible.WebTags = "";
         chkavAtt_ticketotros_visible.Caption = "";
         AssignProp(sPrefix, false, chkavAtt_ticketotros_visible_Internalname, "TitleCaption", chkavAtt_ticketotros_visible.Caption, true);
         chkavAtt_ticketotros_visible.CheckedValue = "false";
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
         GXCCtl = "TICKETLAPTOP_" + sGXsfl_288_idx;
         chkTicketLaptop.Name = GXCCtl;
         chkTicketLaptop.WebTags = "";
         chkTicketLaptop.Caption = "";
         AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_288_Refreshing);
         chkTicketLaptop.CheckedValue = "false";
         GXCCtl = "TICKETDESKTOP_" + sGXsfl_288_idx;
         chkTicketDesktop.Name = GXCCtl;
         chkTicketDesktop.WebTags = "";
         chkTicketDesktop.Caption = "";
         AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_288_Refreshing);
         chkTicketDesktop.CheckedValue = "false";
         GXCCtl = "TICKETMONITOR_" + sGXsfl_288_idx;
         chkTicketMonitor.Name = GXCCtl;
         chkTicketMonitor.WebTags = "";
         chkTicketMonitor.Caption = "";
         AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_288_Refreshing);
         chkTicketMonitor.CheckedValue = "false";
         GXCCtl = "TICKETIMPRESORA_" + sGXsfl_288_idx;
         chkTicketImpresora.Name = GXCCtl;
         chkTicketImpresora.WebTags = "";
         chkTicketImpresora.Caption = "";
         AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_288_Refreshing);
         chkTicketImpresora.CheckedValue = "false";
         GXCCtl = "TICKETESCANER_" + sGXsfl_288_idx;
         chkTicketEscaner.Name = GXCCtl;
         chkTicketEscaner.WebTags = "";
         chkTicketEscaner.Caption = "";
         AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_288_Refreshing);
         chkTicketEscaner.CheckedValue = "false";
         GXCCtl = "TICKETROUTER_" + sGXsfl_288_idx;
         chkTicketRouter.Name = GXCCtl;
         chkTicketRouter.WebTags = "";
         chkTicketRouter.Caption = "";
         AssignProp(sPrefix, false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_288_Refreshing);
         chkTicketRouter.CheckedValue = "false";
         GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_288_idx;
         chkTicketSistemaOperativo.Name = GXCCtl;
         chkTicketSistemaOperativo.WebTags = "";
         chkTicketSistemaOperativo.Caption = "";
         AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_288_Refreshing);
         chkTicketSistemaOperativo.CheckedValue = "false";
         GXCCtl = "TICKETOFFICE_" + sGXsfl_288_idx;
         chkTicketOffice.Name = GXCCtl;
         chkTicketOffice.WebTags = "";
         chkTicketOffice.Caption = "";
         AssignProp(sPrefix, false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_288_Refreshing);
         chkTicketOffice.CheckedValue = "false";
         GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_288_idx;
         chkTicketAntivirus.Name = GXCCtl;
         chkTicketAntivirus.WebTags = "";
         chkTicketAntivirus.Caption = "";
         AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_288_Refreshing);
         chkTicketAntivirus.CheckedValue = "false";
         GXCCtl = "TICKETAPLICACION_" + sGXsfl_288_idx;
         chkTicketAplicacion.Name = GXCCtl;
         chkTicketAplicacion.WebTags = "";
         chkTicketAplicacion.Caption = "";
         AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "TitleCaption", chkTicketAplicacion.Caption, !bGXsfl_288_Refreshing);
         chkTicketAplicacion.CheckedValue = "false";
         GXCCtl = "TICKETDISENIO_" + sGXsfl_288_idx;
         chkTicketDisenio.Name = GXCCtl;
         chkTicketDisenio.WebTags = "";
         chkTicketDisenio.Caption = "";
         AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "TitleCaption", chkTicketDisenio.Caption, !bGXsfl_288_Refreshing);
         chkTicketDisenio.CheckedValue = "false";
         GXCCtl = "TICKETINGENIERIA_" + sGXsfl_288_idx;
         chkTicketIngenieria.Name = GXCCtl;
         chkTicketIngenieria.WebTags = "";
         chkTicketIngenieria.Caption = "";
         AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "TitleCaption", chkTicketIngenieria.Caption, !bGXsfl_288_Refreshing);
         chkTicketIngenieria.CheckedValue = "false";
         GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_288_idx;
         chkTicketDiscoDuroExterno.Name = GXCCtl;
         chkTicketDiscoDuroExterno.WebTags = "";
         chkTicketDiscoDuroExterno.Caption = "";
         AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_288_Refreshing);
         chkTicketDiscoDuroExterno.CheckedValue = "false";
         GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_288_idx;
         chkTicketPerifericos.Name = GXCCtl;
         chkTicketPerifericos.WebTags = "";
         chkTicketPerifericos.Caption = "";
         AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_288_Refreshing);
         chkTicketPerifericos.CheckedValue = "false";
         GXCCtl = "TICKETUPS_" + sGXsfl_288_idx;
         chkTicketUps.Name = GXCCtl;
         chkTicketUps.WebTags = "";
         chkTicketUps.Caption = "";
         AssignProp(sPrefix, false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_288_Refreshing);
         chkTicketUps.CheckedValue = "false";
         GXCCtl = "TICKETAPOYOUSUARIO_" + sGXsfl_288_idx;
         chkTicketApoyoUsuario.Name = GXCCtl;
         chkTicketApoyoUsuario.WebTags = "";
         chkTicketApoyoUsuario.Caption = "";
         AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "TitleCaption", chkTicketApoyoUsuario.Caption, !bGXsfl_288_Refreshing);
         chkTicketApoyoUsuario.CheckedValue = "false";
         GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_288_idx;
         chkTicketInstalarDataShow.Name = GXCCtl;
         chkTicketInstalarDataShow.WebTags = "";
         chkTicketInstalarDataShow.Caption = "";
         AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_288_Refreshing);
         chkTicketInstalarDataShow.CheckedValue = "false";
         GXCCtl = "TICKETOTROS_" + sGXsfl_288_idx;
         chkTicketOtros.Name = GXCCtl;
         chkTicketOtros.WebTags = "";
         chkTicketOtros.Caption = "";
         AssignProp(sPrefix, false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_288_Refreshing);
         chkTicketOtros.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavK2btoolsgenericsearchfield_Internalname = sPrefix+"vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = sPrefix+"FILTERTOGGLE_COMBINED";
         Filtersummarytagsuc_Internalname = sPrefix+"FILTERSUMMARYTAGSUC";
         divSection4_Internalname = sPrefix+"SECTION4";
         imgFilterclose_combined_Internalname = sPrefix+"FILTERCLOSE_COMBINED";
         lblTextblockticketfecha_Internalname = sPrefix+"TEXTBLOCKTICKETFECHA";
         Ticketfecha_daterangepicker_Internalname = sPrefix+"TICKETFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainerticketfecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETFECHA";
         lblTextblocktickethora_Internalname = sPrefix+"TEXTBLOCKTICKETHORA";
         edtavTickethora_from_Internalname = sPrefix+"vTICKETHORA_FROM";
         lblDaterangeseparator_tickethora_Internalname = sPrefix+"DATERANGESEPARATOR_TICKETHORA";
         edtavTickethora_to_Internalname = sPrefix+"vTICKETHORA_TO";
         divDaterangefiltermaintable_tickethora_Internalname = sPrefix+"DATERANGEFILTERMAINTABLE_TICKETHORA";
         divK2btoolstable_attributecontainertickethora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETHORA";
         edtavUsuarionombre_Internalname = sPrefix+"vUSUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         divFilterattributestable_Internalname = sPrefix+"FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = sPrefix+"K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = sPrefix+"FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = sPrefix+"COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = sPrefix+"FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = sPrefix+"K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = sPrefix+"RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_ticketid_visible_Internalname = sPrefix+"vATT_TICKETID_VISIBLE";
         divTicketid_gridsettingscontainer_Internalname = sPrefix+"TICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketfecha_visible_Internalname = sPrefix+"vATT_TICKETFECHA_VISIBLE";
         divTicketfecha_gridsettingscontainer_Internalname = sPrefix+"TICKETFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_tickethora_visible_Internalname = sPrefix+"vATT_TICKETHORA_VISIBLE";
         divTickethora_gridsettingscontainer_Internalname = sPrefix+"TICKETHORA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarioid_visible_Internalname = sPrefix+"vATT_USUARIOID_VISIBLE";
         divUsuarioid_gridsettingscontainer_Internalname = sPrefix+"USUARIOID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = sPrefix+"vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = sPrefix+"USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = sPrefix+"vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = sPrefix+"USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_estadoticketid_visible_Internalname = sPrefix+"vATT_ESTADOTICKETID_VISIBLE";
         divEstadoticketid_gridsettingscontainer_Internalname = sPrefix+"ESTADOTICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_estadoticketnombre_visible_Internalname = sPrefix+"vATT_ESTADOTICKETNOMBRE_VISIBLE";
         divEstadoticketnombre_gridsettingscontainer_Internalname = sPrefix+"ESTADOTICKETNOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketlastid_visible_Internalname = sPrefix+"vATT_TICKETLASTID_VISIBLE";
         divTicketlastid_gridsettingscontainer_Internalname = sPrefix+"TICKETLASTID_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketlaptop_visible_Internalname = sPrefix+"vATT_TICKETLAPTOP_VISIBLE";
         divTicketlaptop_gridsettingscontainer_Internalname = sPrefix+"TICKETLAPTOP_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketdesktop_visible_Internalname = sPrefix+"vATT_TICKETDESKTOP_VISIBLE";
         divTicketdesktop_gridsettingscontainer_Internalname = sPrefix+"TICKETDESKTOP_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketmonitor_visible_Internalname = sPrefix+"vATT_TICKETMONITOR_VISIBLE";
         divTicketmonitor_gridsettingscontainer_Internalname = sPrefix+"TICKETMONITOR_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketimpresora_visible_Internalname = sPrefix+"vATT_TICKETIMPRESORA_VISIBLE";
         divTicketimpresora_gridsettingscontainer_Internalname = sPrefix+"TICKETIMPRESORA_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketescaner_visible_Internalname = sPrefix+"vATT_TICKETESCANER_VISIBLE";
         divTicketescaner_gridsettingscontainer_Internalname = sPrefix+"TICKETESCANER_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketrouter_visible_Internalname = sPrefix+"vATT_TICKETROUTER_VISIBLE";
         divTicketrouter_gridsettingscontainer_Internalname = sPrefix+"TICKETROUTER_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketsistemaoperativo_visible_Internalname = sPrefix+"vATT_TICKETSISTEMAOPERATIVO_VISIBLE";
         divTicketsistemaoperativo_gridsettingscontainer_Internalname = sPrefix+"TICKETSISTEMAOPERATIVO_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketoffice_visible_Internalname = sPrefix+"vATT_TICKETOFFICE_VISIBLE";
         divTicketoffice_gridsettingscontainer_Internalname = sPrefix+"TICKETOFFICE_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketantivirus_visible_Internalname = sPrefix+"vATT_TICKETANTIVIRUS_VISIBLE";
         divTicketantivirus_gridsettingscontainer_Internalname = sPrefix+"TICKETANTIVIRUS_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketaplicacion_visible_Internalname = sPrefix+"vATT_TICKETAPLICACION_VISIBLE";
         divTicketaplicacion_gridsettingscontainer_Internalname = sPrefix+"TICKETAPLICACION_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketdisenio_visible_Internalname = sPrefix+"vATT_TICKETDISENIO_VISIBLE";
         divTicketdisenio_gridsettingscontainer_Internalname = sPrefix+"TICKETDISENIO_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketingenieria_visible_Internalname = sPrefix+"vATT_TICKETINGENIERIA_VISIBLE";
         divTicketingenieria_gridsettingscontainer_Internalname = sPrefix+"TICKETINGENIERIA_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketdiscoduroexterno_visible_Internalname = sPrefix+"vATT_TICKETDISCODUROEXTERNO_VISIBLE";
         divTicketdiscoduroexterno_gridsettingscontainer_Internalname = sPrefix+"TICKETDISCODUROEXTERNO_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketperifericos_visible_Internalname = sPrefix+"vATT_TICKETPERIFERICOS_VISIBLE";
         divTicketperifericos_gridsettingscontainer_Internalname = sPrefix+"TICKETPERIFERICOS_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketups_visible_Internalname = sPrefix+"vATT_TICKETUPS_VISIBLE";
         divTicketups_gridsettingscontainer_Internalname = sPrefix+"TICKETUPS_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketapoyousuario_visible_Internalname = sPrefix+"vATT_TICKETAPOYOUSUARIO_VISIBLE";
         divTicketapoyousuario_gridsettingscontainer_Internalname = sPrefix+"TICKETAPOYOUSUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketinstalardatashow_visible_Internalname = sPrefix+"vATT_TICKETINSTALARDATASHOW_VISIBLE";
         divTicketinstalardatashow_gridsettingscontainer_Internalname = sPrefix+"TICKETINSTALARDATASHOW_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketotros_visible_Internalname = sPrefix+"vATT_TICKETOTROS_VISIBLE";
         divTicketotros_gridsettingscontainer_Internalname = sPrefix+"TICKETOTROS_GRIDSETTINGSCONTAINER";
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
         edtTicketId_Internalname = sPrefix+"TICKETID";
         edtTicketFecha_Internalname = sPrefix+"TICKETFECHA";
         edtTicketHora_Internalname = sPrefix+"TICKETHORA";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         edtEstadoTicketId_Internalname = sPrefix+"ESTADOTICKETID";
         edtEstadoTicketNombre_Internalname = sPrefix+"ESTADOTICKETNOMBRE";
         edtTicketLastId_Internalname = sPrefix+"TICKETLASTID";
         chkTicketLaptop_Internalname = sPrefix+"TICKETLAPTOP";
         chkTicketDesktop_Internalname = sPrefix+"TICKETDESKTOP";
         chkTicketMonitor_Internalname = sPrefix+"TICKETMONITOR";
         chkTicketImpresora_Internalname = sPrefix+"TICKETIMPRESORA";
         chkTicketEscaner_Internalname = sPrefix+"TICKETESCANER";
         chkTicketRouter_Internalname = sPrefix+"TICKETROUTER";
         chkTicketSistemaOperativo_Internalname = sPrefix+"TICKETSISTEMAOPERATIVO";
         chkTicketOffice_Internalname = sPrefix+"TICKETOFFICE";
         chkTicketAntivirus_Internalname = sPrefix+"TICKETANTIVIRUS";
         chkTicketAplicacion_Internalname = sPrefix+"TICKETAPLICACION";
         chkTicketDisenio_Internalname = sPrefix+"TICKETDISENIO";
         chkTicketIngenieria_Internalname = sPrefix+"TICKETINGENIERIA";
         chkTicketDiscoDuroExterno_Internalname = sPrefix+"TICKETDISCODUROEXTERNO";
         chkTicketPerifericos_Internalname = sPrefix+"TICKETPERIFERICOS";
         chkTicketUps_Internalname = sPrefix+"TICKETUPS";
         chkTicketApoyoUsuario_Internalname = sPrefix+"TICKETAPOYOUSUARIO";
         chkTicketInstalarDataShow_Internalname = sPrefix+"TICKETINSTALARDATASHOW";
         chkTicketOtros_Internalname = sPrefix+"TICKETOTROS";
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
         chkavAtt_ticketotros_visible.Caption = "Otros";
         chkavAtt_ticketinstalardatashow_visible.Caption = "Data Show";
         chkavAtt_ticketapoyousuario_visible.Caption = "Usuario";
         chkavAtt_ticketups_visible.Caption = "UPS";
         chkavAtt_ticketperifericos_visible.Caption = "Periféricos";
         chkavAtt_ticketdiscoduroexterno_visible.Caption = "Duro ";
         chkavAtt_ticketingenieria_visible.Caption = "Ingeniería";
         chkavAtt_ticketdisenio_visible.Caption = "Diseño";
         chkavAtt_ticketaplicacion_visible.Caption = "Aplicación";
         chkavAtt_ticketantivirus_visible.Caption = "Antivirus";
         chkavAtt_ticketoffice_visible.Caption = "Office";
         chkavAtt_ticketsistemaoperativo_visible.Caption = "Operativo";
         chkavAtt_ticketrouter_visible.Caption = "Internet/Router/Access Point";
         chkavAtt_ticketescaner_visible.Caption = "Escaner";
         chkavAtt_ticketimpresora_visible.Caption = "Impresora";
         chkavAtt_ticketmonitor_visible.Caption = "Monitor";
         chkavAtt_ticketdesktop_visible.Caption = "Desktop";
         chkavAtt_ticketlaptop_visible.Caption = "aptop";
         chkavAtt_ticketlastid_visible.Caption = "Last Id";
         chkavAtt_estadoticketnombre_visible.Caption = "Estado Ticket";
         chkavAtt_estadoticketid_visible.Caption = "Id";
         chkavAtt_usuariorequerimiento_visible.Caption = "Requerimiento";
         chkavAtt_usuarionombre_visible.Caption = "Usuario";
         chkavAtt_usuarioid_visible.Caption = "Id Usuario";
         chkavAtt_tickethora_visible.Caption = "Hora:";
         chkavAtt_ticketfecha_visible.Caption = "Fecha:";
         chkavAtt_ticketid_visible.Caption = "RST No.";
         chkTicketOtros.Caption = "";
         chkTicketInstalarDataShow.Caption = "";
         chkTicketApoyoUsuario.Caption = "";
         chkTicketUps.Caption = "";
         chkTicketPerifericos.Caption = "";
         chkTicketDiscoDuroExterno.Caption = "";
         chkTicketIngenieria.Caption = "";
         chkTicketDisenio.Caption = "";
         chkTicketAplicacion.Caption = "";
         chkTicketAntivirus.Caption = "";
         chkTicketOffice.Caption = "";
         chkTicketSistemaOperativo.Caption = "";
         chkTicketRouter.Caption = "";
         chkTicketEscaner.Caption = "";
         chkTicketImpresora.Caption = "";
         chkTicketMonitor.Caption = "";
         chkTicketDesktop.Caption = "";
         chkTicketLaptop.Caption = "";
         edtTicketLastId_Jsonclick = "";
         edtEstadoTicketNombre_Jsonclick = "";
         edtEstadoTicketId_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtTicketHora_Jsonclick = "";
         edtTicketFecha_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_ticketotros_visible.Enabled = 1;
         chkavAtt_ticketinstalardatashow_visible.Enabled = 1;
         chkavAtt_ticketapoyousuario_visible.Enabled = 1;
         chkavAtt_ticketups_visible.Enabled = 1;
         chkavAtt_ticketperifericos_visible.Enabled = 1;
         chkavAtt_ticketdiscoduroexterno_visible.Enabled = 1;
         chkavAtt_ticketingenieria_visible.Enabled = 1;
         chkavAtt_ticketdisenio_visible.Enabled = 1;
         chkavAtt_ticketaplicacion_visible.Enabled = 1;
         chkavAtt_ticketantivirus_visible.Enabled = 1;
         chkavAtt_ticketoffice_visible.Enabled = 1;
         chkavAtt_ticketsistemaoperativo_visible.Enabled = 1;
         chkavAtt_ticketrouter_visible.Enabled = 1;
         chkavAtt_ticketescaner_visible.Enabled = 1;
         chkavAtt_ticketimpresora_visible.Enabled = 1;
         chkavAtt_ticketmonitor_visible.Enabled = 1;
         chkavAtt_ticketdesktop_visible.Enabled = 1;
         chkavAtt_ticketlaptop_visible.Enabled = 1;
         chkavAtt_ticketlastid_visible.Enabled = 1;
         chkavAtt_estadoticketnombre_visible.Enabled = 1;
         chkavAtt_estadoticketid_visible.Enabled = 1;
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
         chkavAtt_usuarioid_visible.Enabled = 1;
         chkavAtt_tickethora_visible.Enabled = 1;
         chkavAtt_ticketfecha_visible.Enabled = 1;
         chkavAtt_ticketid_visible.Enabled = 1;
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
         edtEstadoTicketNombre_Link = "";
         edtUsuarioNombre_Link = "";
         edtTicketFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         chkTicketOtros.Visible = -1;
         chkTicketInstalarDataShow.Visible = -1;
         chkTicketApoyoUsuario.Visible = -1;
         chkTicketUps.Visible = -1;
         chkTicketPerifericos.Visible = -1;
         chkTicketDiscoDuroExterno.Visible = -1;
         chkTicketIngenieria.Visible = -1;
         chkTicketDisenio.Visible = -1;
         chkTicketAplicacion.Visible = -1;
         chkTicketAntivirus.Visible = -1;
         chkTicketOffice.Visible = -1;
         chkTicketSistemaOperativo.Visible = -1;
         chkTicketRouter.Visible = -1;
         chkTicketEscaner.Visible = -1;
         chkTicketImpresora.Visible = -1;
         chkTicketMonitor.Visible = -1;
         chkTicketDesktop.Visible = -1;
         chkTicketLaptop.Visible = -1;
         edtTicketLastId_Visible = -1;
         edtEstadoTicketNombre_Visible = -1;
         edtEstadoTicketId_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtUsuarioId_Visible = -1;
         edtTicketHora_Visible = -1;
         edtTicketFecha_Visible = -1;
         edtTicketId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 1;
         edtavTickethora_to_Jsonclick = "";
         edtavTickethora_to_Enabled = 1;
         edtavTickethora_from_Jsonclick = "";
         edtavTickethora_from_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'sPrefix'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132H2',iparms:[{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282H1',iparms:[{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242H2',iparms:[{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV64UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV58FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252H2',iparms:[{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtEstadoTicketNombre_Link',ctrl:'ESTADOTICKETNOMBRE',prop:'Link'},{av:'edtTicketFecha_Link',ctrl:'TICKETFECHA',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV59DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV64UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262H1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{av:'AV43RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV42GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV43RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'A17EstadoTicketTecnicoId',fld:'ESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A5EstadoTicketId',fld:'ESTADOTICKETID',pic:'ZZZ9'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'sPrefix'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV9CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV74Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV11GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV72TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV48ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketId_Visible',ctrl:'ESTADOTICKETID',prop:'Visible'},{av:'edtEstadoTicketNombre_Visible',ctrl:'ESTADOTICKETNOMBRE',prop:'Visible'},{av:'edtTicketLastId_Visible',ctrl:'TICKETLASTID',prop:'Visible'},{av:'chkTicketLaptop.Visible',ctrl:'TICKETLAPTOP',prop:'Visible'},{av:'chkTicketDesktop.Visible',ctrl:'TICKETDESKTOP',prop:'Visible'},{av:'chkTicketMonitor.Visible',ctrl:'TICKETMONITOR',prop:'Visible'},{av:'chkTicketImpresora.Visible',ctrl:'TICKETIMPRESORA',prop:'Visible'},{av:'chkTicketEscaner.Visible',ctrl:'TICKETESCANER',prop:'Visible'},{av:'chkTicketRouter.Visible',ctrl:'TICKETROUTER',prop:'Visible'},{av:'chkTicketSistemaOperativo.Visible',ctrl:'TICKETSISTEMAOPERATIVO',prop:'Visible'},{av:'chkTicketOffice.Visible',ctrl:'TICKETOFFICE',prop:'Visible'},{av:'chkTicketAntivirus.Visible',ctrl:'TICKETANTIVIRUS',prop:'Visible'},{av:'chkTicketAplicacion.Visible',ctrl:'TICKETAPLICACION',prop:'Visible'},{av:'chkTicketDisenio.Visible',ctrl:'TICKETDISENIO',prop:'Visible'},{av:'chkTicketIngenieria.Visible',ctrl:'TICKETINGENIERIA',prop:'Visible'},{av:'chkTicketDiscoDuroExterno.Visible',ctrl:'TICKETDISCODUROEXTERNO',prop:'Visible'},{av:'chkTicketPerifericos.Visible',ctrl:'TICKETPERIFERICOS',prop:'Visible'},{av:'chkTicketUps.Visible',ctrl:'TICKETUPS',prop:'Visible'},{av:'chkTicketApoyoUsuario.Visible',ctrl:'TICKETAPOYOUSUARIO',prop:'Visible'},{av:'chkTicketInstalarDataShow.Visible',ctrl:'TICKETINSTALARDATASHOW',prop:'Visible'},{av:'chkTicketOtros.Visible',ctrl:'TICKETOTROS',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192H2',iparms:[{av:'AV6EstadoTicketTecnicoId',fld:'vESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV50TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV53TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV54TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV55UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV60K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV61OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV77Uri',fld:'vURI',pic:'',hsh:true},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272H1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202H2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212H2',iparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV16Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV17Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV19Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_EstadoTicketId_Visible',fld:'vATT_ESTADOTICKETID_VISIBLE',pic:''},{av:'AV22Att_EstadoTicketNombre_Visible',fld:'vATT_ESTADOTICKETNOMBRE_VISIBLE',pic:''},{av:'AV23Att_TicketLastId_Visible',fld:'vATT_TICKETLASTID_VISIBLE',pic:''},{av:'AV24Att_TicketLaptop_Visible',fld:'vATT_TICKETLAPTOP_VISIBLE',pic:''},{av:'AV25Att_TicketDesktop_Visible',fld:'vATT_TICKETDESKTOP_VISIBLE',pic:''},{av:'AV26Att_TicketMonitor_Visible',fld:'vATT_TICKETMONITOR_VISIBLE',pic:''},{av:'AV27Att_TicketImpresora_Visible',fld:'vATT_TICKETIMPRESORA_VISIBLE',pic:''},{av:'AV28Att_TicketEscaner_Visible',fld:'vATT_TICKETESCANER_VISIBLE',pic:''},{av:'AV29Att_TicketRouter_Visible',fld:'vATT_TICKETROUTER_VISIBLE',pic:''},{av:'AV30Att_TicketSistemaOperativo_Visible',fld:'vATT_TICKETSISTEMAOPERATIVO_VISIBLE',pic:''},{av:'AV31Att_TicketOffice_Visible',fld:'vATT_TICKETOFFICE_VISIBLE',pic:''},{av:'AV32Att_TicketAntivirus_Visible',fld:'vATT_TICKETANTIVIRUS_VISIBLE',pic:''},{av:'AV33Att_TicketAplicacion_Visible',fld:'vATT_TICKETAPLICACION_VISIBLE',pic:''},{av:'AV34Att_TicketDisenio_Visible',fld:'vATT_TICKETDISENIO_VISIBLE',pic:''},{av:'AV35Att_TicketIngenieria_Visible',fld:'vATT_TICKETINGENIERIA_VISIBLE',pic:''},{av:'AV36Att_TicketDiscoDuroExterno_Visible',fld:'vATT_TICKETDISCODUROEXTERNO_VISIBLE',pic:''},{av:'AV37Att_TicketPerifericos_Visible',fld:'vATT_TICKETPERIFERICOS_VISIBLE',pic:''},{av:'AV38Att_TicketUps_Visible',fld:'vATT_TICKETUPS_VISIBLE',pic:''},{av:'AV39Att_TicketApoyoUsuario_Visible',fld:'vATT_TICKETAPOYOUSUARIO_VISIBLE',pic:''},{av:'AV40Att_TicketInstalarDataShow_Visible',fld:'vATT_TICKETINSTALARDATASHOW_VISIBLE',pic:''},{av:'AV41Att_TicketOtros_Visible',fld:'vATT_TICKETOTROS_VISIBLE',pic:''},{av:'AV12FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV60K2BToolsGenericSearchField = "";
         AV50TicketFecha_From = DateTime.MinValue;
         AV53TicketHora_From = (DateTime)(DateTime.MinValue);
         AV54TicketHora_To = (DateTime)(DateTime.MinValue);
         AV55UsuarioNombre = "";
         AV48ClassCollection = new GxSimpleCollection<string>();
         AV51TicketFecha_To = DateTime.MinValue;
         AV80Pgmname = "";
         AV11GridConfiguration = new SdtK2BGridConfiguration(context);
         AV70AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV77Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV58FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV59DeletedTag = "";
         AV62GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblockticketfecha_Jsonclick = "";
         ucTicketfecha_daterangepicker = new GXUserControl();
         lblTextblocktickethora_Jsonclick = "";
         lblDaterangeseparator_tickethora_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A24EstadoTicketNombre = "";
         AV73Update = "";
         AV74Delete = "";
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
         AV82Update_GXI = "";
         AV83Delete_GXI = "";
         scmdbuf = "";
         lV55UsuarioNombre = "";
         lV60K2BToolsGenericSearchField = "";
         H002H2_A57TicketOtros = new bool[] {false} ;
         H002H2_n57TicketOtros = new bool[] {false} ;
         H002H2_A52TicketInstalarDataShow = new bool[] {false} ;
         H002H2_n52TicketInstalarDataShow = new bool[] {false} ;
         H002H2_A41TicketApoyoUsuario = new bool[] {false} ;
         H002H2_n41TicketApoyoUsuario = new bool[] {false} ;
         H002H2_A87TicketUps = new bool[] {false} ;
         H002H2_n87TicketUps = new bool[] {false} ;
         H002H2_A58TicketPerifericos = new bool[] {false} ;
         H002H2_n58TicketPerifericos = new bool[] {false} ;
         H002H2_A43TicketDiscoDuroExterno = new bool[] {false} ;
         H002H2_n43TicketDiscoDuroExterno = new bool[] {false} ;
         H002H2_A51TicketIngenieria = new bool[] {false} ;
         H002H2_n51TicketIngenieria = new bool[] {false} ;
         H002H2_A44TicketDisenio = new bool[] {false} ;
         H002H2_n44TicketDisenio = new bool[] {false} ;
         H002H2_A40TicketAplicacion = new bool[] {false} ;
         H002H2_n40TicketAplicacion = new bool[] {false} ;
         H002H2_A39TicketAntivirus = new bool[] {false} ;
         H002H2_n39TicketAntivirus = new bool[] {false} ;
         H002H2_A56TicketOffice = new bool[] {false} ;
         H002H2_n56TicketOffice = new bool[] {false} ;
         H002H2_A60TicketSistemaOperativo = new bool[] {false} ;
         H002H2_n60TicketSistemaOperativo = new bool[] {false} ;
         H002H2_A59TicketRouter = new bool[] {false} ;
         H002H2_n59TicketRouter = new bool[] {false} ;
         H002H2_A45TicketEscaner = new bool[] {false} ;
         H002H2_n45TicketEscaner = new bool[] {false} ;
         H002H2_A50TicketImpresora = new bool[] {false} ;
         H002H2_n50TicketImpresora = new bool[] {false} ;
         H002H2_A55TicketMonitor = new bool[] {false} ;
         H002H2_n55TicketMonitor = new bool[] {false} ;
         H002H2_A42TicketDesktop = new bool[] {false} ;
         H002H2_n42TicketDesktop = new bool[] {false} ;
         H002H2_A53TicketLaptop = new bool[] {false} ;
         H002H2_n53TicketLaptop = new bool[] {false} ;
         H002H2_A54TicketLastId = new long[1] ;
         H002H2_A94UsuarioRequerimiento = new string[] {""} ;
         H002H2_A93UsuarioNombre = new string[] {""} ;
         H002H2_A15UsuarioId = new long[1] ;
         H002H2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H002H2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H002H2_A14TicketId = new long[1] ;
         H002H3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV49TicketFecha = DateTime.MinValue;
         AV52TicketHora = (DateTime)(DateTime.MinValue);
         AV63GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV65Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV66Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV69ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV71ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV45GridStateKey = "";
         AV46GridState = new SdtK2BGridState(context);
         AV47GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV67TrnContext = new SdtK2BTrnContext(context);
         AV68TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV14GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV56K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV57K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV75OutFile = "";
         AV76Guid = (Guid)(Guid.Empty);
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
         sCtrlAV6EstadoTicketTecnicoId = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadoticketticketwc__default(),
            new Object[][] {
                new Object[] {
               H002H2_A57TicketOtros, H002H2_n57TicketOtros, H002H2_A52TicketInstalarDataShow, H002H2_n52TicketInstalarDataShow, H002H2_A41TicketApoyoUsuario, H002H2_n41TicketApoyoUsuario, H002H2_A87TicketUps, H002H2_n87TicketUps, H002H2_A58TicketPerifericos, H002H2_n58TicketPerifericos,
               H002H2_A43TicketDiscoDuroExterno, H002H2_n43TicketDiscoDuroExterno, H002H2_A51TicketIngenieria, H002H2_n51TicketIngenieria, H002H2_A44TicketDisenio, H002H2_n44TicketDisenio, H002H2_A40TicketAplicacion, H002H2_n40TicketAplicacion, H002H2_A39TicketAntivirus, H002H2_n39TicketAntivirus,
               H002H2_A56TicketOffice, H002H2_n56TicketOffice, H002H2_A60TicketSistemaOperativo, H002H2_n60TicketSistemaOperativo, H002H2_A59TicketRouter, H002H2_n59TicketRouter, H002H2_A45TicketEscaner, H002H2_n45TicketEscaner, H002H2_A50TicketImpresora, H002H2_n50TicketImpresora,
               H002H2_A55TicketMonitor, H002H2_n55TicketMonitor, H002H2_A42TicketDesktop, H002H2_n42TicketDesktop, H002H2_A53TicketLaptop, H002H2_n53TicketLaptop, H002H2_A54TicketLastId, H002H2_A94UsuarioRequerimiento, H002H2_A93UsuarioNombre, H002H2_A15UsuarioId,
               H002H2_A48TicketHora, H002H2_A46TicketFecha, H002H2_A14TicketId
               }
               , new Object[] {
               H002H3_AGRID_nRecordCount
               }
            }
         );
         AV80Pgmname = "EstadoTicketTicketWC";
         /* GeneXus formulas. */
         AV80Pgmname = "EstadoTicketTicketWC";
         context.Gx_err = 0;
      }

      private short AV6EstadoTicketTecnicoId ;
      private short wcpOAV6EstadoTicketTecnicoId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A17EstadoTicketTecnicoId ;
      private short AV61OrderedBy ;
      private short A5EstadoTicketId ;
      private short initialized ;
      private short AV64UC_OrderedBy ;
      private short AV43RowsPerPageVariable ;
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
      private short AV42GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_288 ;
      private int nGXsfl_288_idx=1 ;
      private int subGrid_Rows ;
      private int AV9CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavTickethora_from_Enabled ;
      private int edtavTickethora_to_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTicketId_Visible ;
      private int edtTicketFecha_Visible ;
      private int edtTicketHora_Visible ;
      private int edtUsuarioId_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
      private int edtEstadoTicketId_Visible ;
      private int edtEstadoTicketNombre_Visible ;
      private int edtTicketLastId_Visible ;
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
      private int AV81GXV1 ;
      private int AV84GXV2 ;
      private int AV10K2BMaxPages ;
      private int AV85GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV86GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long A54TicketLastId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_288_idx="0001" ;
      private string AV60K2BToolsGenericSearchField ;
      private string AV80Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV59DeletedTag ;
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
      private string divK2btoolstable_attributecontainerticketfecha_Internalname ;
      private string lblTextblockticketfecha_Internalname ;
      private string lblTextblockticketfecha_Jsonclick ;
      private string Ticketfecha_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainertickethora_Internalname ;
      private string lblTextblocktickethora_Internalname ;
      private string lblTextblocktickethora_Jsonclick ;
      private string divDaterangefiltermaintable_tickethora_Internalname ;
      private string edtavTickethora_from_Internalname ;
      private string edtavTickethora_from_Jsonclick ;
      private string lblDaterangeseparator_tickethora_Internalname ;
      private string lblDaterangeseparator_tickethora_Jsonclick ;
      private string edtavTickethora_to_Internalname ;
      private string edtavTickethora_to_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtTicketFecha_Link ;
      private string edtUsuarioNombre_Link ;
      private string edtEstadoTicketNombre_Link ;
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
      private string edtTicketId_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtEstadoTicketId_Internalname ;
      private string edtEstadoTicketNombre_Internalname ;
      private string edtTicketLastId_Internalname ;
      private string chkTicketLaptop_Internalname ;
      private string chkTicketDesktop_Internalname ;
      private string chkTicketMonitor_Internalname ;
      private string chkTicketImpresora_Internalname ;
      private string chkTicketEscaner_Internalname ;
      private string chkTicketRouter_Internalname ;
      private string chkTicketSistemaOperativo_Internalname ;
      private string chkTicketOffice_Internalname ;
      private string chkTicketAntivirus_Internalname ;
      private string chkTicketAplicacion_Internalname ;
      private string chkTicketDisenio_Internalname ;
      private string chkTicketIngenieria_Internalname ;
      private string chkTicketDiscoDuroExterno_Internalname ;
      private string chkTicketPerifericos_Internalname ;
      private string chkTicketUps_Internalname ;
      private string chkTicketApoyoUsuario_Internalname ;
      private string chkTicketInstalarDataShow_Internalname ;
      private string chkTicketOtros_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV60K2BToolsGenericSearchField ;
      private string chkavAtt_ticketid_visible_Internalname ;
      private string chkavAtt_ticketfecha_visible_Internalname ;
      private string chkavAtt_tickethora_visible_Internalname ;
      private string chkavAtt_usuarioid_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
      private string chkavAtt_estadoticketid_visible_Internalname ;
      private string chkavAtt_estadoticketnombre_visible_Internalname ;
      private string chkavAtt_ticketlastid_visible_Internalname ;
      private string chkavAtt_ticketlaptop_visible_Internalname ;
      private string chkavAtt_ticketdesktop_visible_Internalname ;
      private string chkavAtt_ticketmonitor_visible_Internalname ;
      private string chkavAtt_ticketimpresora_visible_Internalname ;
      private string chkavAtt_ticketescaner_visible_Internalname ;
      private string chkavAtt_ticketrouter_visible_Internalname ;
      private string chkavAtt_ticketsistemaoperativo_visible_Internalname ;
      private string chkavAtt_ticketoffice_visible_Internalname ;
      private string chkavAtt_ticketantivirus_visible_Internalname ;
      private string chkavAtt_ticketaplicacion_visible_Internalname ;
      private string chkavAtt_ticketdisenio_visible_Internalname ;
      private string chkavAtt_ticketingenieria_visible_Internalname ;
      private string chkavAtt_ticketdiscoduroexterno_visible_Internalname ;
      private string chkavAtt_ticketperifericos_visible_Internalname ;
      private string chkavAtt_ticketups_visible_Internalname ;
      private string chkavAtt_ticketapoyousuario_visible_Internalname ;
      private string chkavAtt_ticketinstalardatashow_visible_Internalname ;
      private string chkavAtt_ticketotros_visible_Internalname ;
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
      private string divTicketid_gridsettingscontainer_Internalname ;
      private string divTicketfecha_gridsettingscontainer_Internalname ;
      private string divTickethora_gridsettingscontainer_Internalname ;
      private string divUsuarioid_gridsettingscontainer_Internalname ;
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
      private string divEstadoticketid_gridsettingscontainer_Internalname ;
      private string divEstadoticketnombre_gridsettingscontainer_Internalname ;
      private string divTicketlastid_gridsettingscontainer_Internalname ;
      private string divTicketlaptop_gridsettingscontainer_Internalname ;
      private string divTicketdesktop_gridsettingscontainer_Internalname ;
      private string divTicketmonitor_gridsettingscontainer_Internalname ;
      private string divTicketimpresora_gridsettingscontainer_Internalname ;
      private string divTicketescaner_gridsettingscontainer_Internalname ;
      private string divTicketrouter_gridsettingscontainer_Internalname ;
      private string divTicketsistemaoperativo_gridsettingscontainer_Internalname ;
      private string divTicketoffice_gridsettingscontainer_Internalname ;
      private string divTicketantivirus_gridsettingscontainer_Internalname ;
      private string divTicketaplicacion_gridsettingscontainer_Internalname ;
      private string divTicketdisenio_gridsettingscontainer_Internalname ;
      private string divTicketingenieria_gridsettingscontainer_Internalname ;
      private string divTicketdiscoduroexterno_gridsettingscontainer_Internalname ;
      private string divTicketperifericos_gridsettingscontainer_Internalname ;
      private string divTicketups_gridsettingscontainer_Internalname ;
      private string divTicketapoyousuario_gridsettingscontainer_Internalname ;
      private string divTicketinstalardatashow_gridsettingscontainer_Internalname ;
      private string divTicketotros_gridsettingscontainer_Internalname ;
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
      private string sCtrlAV6EstadoTicketTecnicoId ;
      private string sGXsfl_288_fel_idx="0001" ;
      private string ROClassString ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketHora_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtEstadoTicketId_Jsonclick ;
      private string edtEstadoTicketNombre_Jsonclick ;
      private string edtTicketLastId_Jsonclick ;
      private string GXCCtl ;
      private DateTime AV53TicketHora_From ;
      private DateTime AV54TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime AV52TicketHora ;
      private DateTime GXt_dtime3 ;
      private DateTime AV50TicketFecha_From ;
      private DateTime AV51TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime AV49TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV72TicketFecha_IsAuthorized ;
      private bool AV15Att_TicketId_Visible ;
      private bool AV16Att_TicketFecha_Visible ;
      private bool AV17Att_TicketHora_Visible ;
      private bool AV18Att_UsuarioId_Visible ;
      private bool AV19Att_UsuarioNombre_Visible ;
      private bool AV20Att_UsuarioRequerimiento_Visible ;
      private bool AV21Att_EstadoTicketId_Visible ;
      private bool AV22Att_EstadoTicketNombre_Visible ;
      private bool AV23Att_TicketLastId_Visible ;
      private bool AV24Att_TicketLaptop_Visible ;
      private bool AV25Att_TicketDesktop_Visible ;
      private bool AV26Att_TicketMonitor_Visible ;
      private bool AV27Att_TicketImpresora_Visible ;
      private bool AV28Att_TicketEscaner_Visible ;
      private bool AV29Att_TicketRouter_Visible ;
      private bool AV30Att_TicketSistemaOperativo_Visible ;
      private bool AV31Att_TicketOffice_Visible ;
      private bool AV32Att_TicketAntivirus_Visible ;
      private bool AV33Att_TicketAplicacion_Visible ;
      private bool AV34Att_TicketDisenio_Visible ;
      private bool AV35Att_TicketIngenieria_Visible ;
      private bool AV36Att_TicketDiscoDuroExterno_Visible ;
      private bool AV37Att_TicketPerifericos_Visible ;
      private bool AV38Att_TicketUps_Visible ;
      private bool AV39Att_TicketApoyoUsuario_Visible ;
      private bool AV40Att_TicketInstalarDataShow_Visible ;
      private bool AV41Att_TicketOtros_Visible ;
      private bool AV12FreezeColumnTitles ;
      private bool wbLoad ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n53TicketLaptop ;
      private bool n42TicketDesktop ;
      private bool n55TicketMonitor ;
      private bool n50TicketImpresora ;
      private bool n45TicketEscaner ;
      private bool n59TicketRouter ;
      private bool n60TicketSistemaOperativo ;
      private bool n56TicketOffice ;
      private bool n39TicketAntivirus ;
      private bool n40TicketAplicacion ;
      private bool n44TicketDisenio ;
      private bool n51TicketIngenieria ;
      private bool n43TicketDiscoDuroExterno ;
      private bool n58TicketPerifericos ;
      private bool n87TicketUps ;
      private bool n41TicketApoyoUsuario ;
      private bool n52TicketInstalarDataShow ;
      private bool n57TicketOtros ;
      private bool bGXsfl_288_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV44RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV73Update_IsBlob ;
      private bool AV74Delete_IsBlob ;
      private string AV55UsuarioNombre ;
      private string AV77Uri ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A24EstadoTicketNombre ;
      private string AV82Update_GXI ;
      private string AV83Delete_GXI ;
      private string lV55UsuarioNombre ;
      private string AV45GridStateKey ;
      private string AV75OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV73Update ;
      private string AV74Delete ;
      private Guid AV76Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucTicketfecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_ticketid_visible ;
      private GXCheckbox chkavAtt_ticketfecha_visible ;
      private GXCheckbox chkavAtt_tickethora_visible ;
      private GXCheckbox chkavAtt_usuarioid_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCheckbox chkavAtt_estadoticketid_visible ;
      private GXCheckbox chkavAtt_estadoticketnombre_visible ;
      private GXCheckbox chkavAtt_ticketlastid_visible ;
      private GXCheckbox chkavAtt_ticketlaptop_visible ;
      private GXCheckbox chkavAtt_ticketdesktop_visible ;
      private GXCheckbox chkavAtt_ticketmonitor_visible ;
      private GXCheckbox chkavAtt_ticketimpresora_visible ;
      private GXCheckbox chkavAtt_ticketescaner_visible ;
      private GXCheckbox chkavAtt_ticketrouter_visible ;
      private GXCheckbox chkavAtt_ticketsistemaoperativo_visible ;
      private GXCheckbox chkavAtt_ticketoffice_visible ;
      private GXCheckbox chkavAtt_ticketantivirus_visible ;
      private GXCheckbox chkavAtt_ticketaplicacion_visible ;
      private GXCheckbox chkavAtt_ticketdisenio_visible ;
      private GXCheckbox chkavAtt_ticketingenieria_visible ;
      private GXCheckbox chkavAtt_ticketdiscoduroexterno_visible ;
      private GXCheckbox chkavAtt_ticketperifericos_visible ;
      private GXCheckbox chkavAtt_ticketups_visible ;
      private GXCheckbox chkavAtt_ticketapoyousuario_visible ;
      private GXCheckbox chkavAtt_ticketinstalardatashow_visible ;
      private GXCheckbox chkavAtt_ticketotros_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private GXCheckbox chkTicketLaptop ;
      private GXCheckbox chkTicketDesktop ;
      private GXCheckbox chkTicketMonitor ;
      private GXCheckbox chkTicketImpresora ;
      private GXCheckbox chkTicketEscaner ;
      private GXCheckbox chkTicketRouter ;
      private GXCheckbox chkTicketSistemaOperativo ;
      private GXCheckbox chkTicketOffice ;
      private GXCheckbox chkTicketAntivirus ;
      private GXCheckbox chkTicketAplicacion ;
      private GXCheckbox chkTicketDisenio ;
      private GXCheckbox chkTicketIngenieria ;
      private GXCheckbox chkTicketDiscoDuroExterno ;
      private GXCheckbox chkTicketPerifericos ;
      private GXCheckbox chkTicketUps ;
      private GXCheckbox chkTicketApoyoUsuario ;
      private GXCheckbox chkTicketInstalarDataShow ;
      private GXCheckbox chkTicketOtros ;
      private IDataStoreProvider pr_default ;
      private bool[] H002H2_A57TicketOtros ;
      private bool[] H002H2_n57TicketOtros ;
      private bool[] H002H2_A52TicketInstalarDataShow ;
      private bool[] H002H2_n52TicketInstalarDataShow ;
      private bool[] H002H2_A41TicketApoyoUsuario ;
      private bool[] H002H2_n41TicketApoyoUsuario ;
      private bool[] H002H2_A87TicketUps ;
      private bool[] H002H2_n87TicketUps ;
      private bool[] H002H2_A58TicketPerifericos ;
      private bool[] H002H2_n58TicketPerifericos ;
      private bool[] H002H2_A43TicketDiscoDuroExterno ;
      private bool[] H002H2_n43TicketDiscoDuroExterno ;
      private bool[] H002H2_A51TicketIngenieria ;
      private bool[] H002H2_n51TicketIngenieria ;
      private bool[] H002H2_A44TicketDisenio ;
      private bool[] H002H2_n44TicketDisenio ;
      private bool[] H002H2_A40TicketAplicacion ;
      private bool[] H002H2_n40TicketAplicacion ;
      private bool[] H002H2_A39TicketAntivirus ;
      private bool[] H002H2_n39TicketAntivirus ;
      private bool[] H002H2_A56TicketOffice ;
      private bool[] H002H2_n56TicketOffice ;
      private bool[] H002H2_A60TicketSistemaOperativo ;
      private bool[] H002H2_n60TicketSistemaOperativo ;
      private bool[] H002H2_A59TicketRouter ;
      private bool[] H002H2_n59TicketRouter ;
      private bool[] H002H2_A45TicketEscaner ;
      private bool[] H002H2_n45TicketEscaner ;
      private bool[] H002H2_A50TicketImpresora ;
      private bool[] H002H2_n50TicketImpresora ;
      private bool[] H002H2_A55TicketMonitor ;
      private bool[] H002H2_n55TicketMonitor ;
      private bool[] H002H2_A42TicketDesktop ;
      private bool[] H002H2_n42TicketDesktop ;
      private bool[] H002H2_A53TicketLaptop ;
      private bool[] H002H2_n53TicketLaptop ;
      private long[] H002H2_A54TicketLastId ;
      private string[] H002H2_A94UsuarioRequerimiento ;
      private string[] H002H2_A93UsuarioNombre ;
      private long[] H002H2_A15UsuarioId ;
      private DateTime[] H002H2_A48TicketHora ;
      private DateTime[] H002H2_A46TicketFecha ;
      private long[] H002H2_A14TicketId ;
      private long[] H002H3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV48ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV56K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV58FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV62GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV65Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV70AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV69ActivityList ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV11GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV14GridColumn ;
      private SdtK2BGridState AV46GridState ;
      private SdtK2BGridState_FilterValue AV47GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV57K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV63GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV66Message ;
      private SdtK2BTrnContext AV67TrnContext ;
      private SdtK2BTrnContext_Attribute AV68TrnContextAtt ;
      private SdtK2BActivityList_K2BActivityListItem AV71ActivityListItem ;
   }

   public class estadoticketticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002H2( IGxContext context ,
                                             DateTime AV51TicketFecha_To ,
                                             DateTime AV50TicketFecha_From ,
                                             DateTime AV54TicketHora_To ,
                                             DateTime AV53TicketHora_From ,
                                             string AV55UsuarioNombre ,
                                             string AV60K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A94UsuarioRequerimiento ,
                                             short A5EstadoTicketId ,
                                             string A24EstadoTicketNombre ,
                                             long A54TicketLastId ,
                                             short AV61OrderedBy ,
                                             short A17EstadoTicketTecnicoId ,
                                             short AV6EstadoTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[TicketOtros], T1.[TicketInstalarDataShow], T1.[TicketApoyoUsuario], T1.[TicketUps], T1.[TicketPerifericos], T1.[TicketDiscoDuroExterno], T1.[TicketIngenieria], T1.[TicketDisenio], T1.[TicketAplicacion], T1.[TicketAntivirus], T1.[TicketOffice], T1.[TicketSistemaOperativo], T1.[TicketRouter], T1.[TicketEscaner], T1.[TicketImpresora], T1.[TicketMonitor], T1.[TicketDesktop], T1.[TicketLaptop], T1.[TicketLastId], T2.[UsuarioRequerimiento], T2.[UsuarioNombre], T1.[UsuarioId], T1.[TicketHora], T1.[TicketFecha], T1.[TicketId]";
         sFromString = " FROM ([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId])";
         sOrderString = "";
         AddWhere(sWhereString, "(@EstadoTicketTecnicoId = @AV6EstadoTicketTecnicoId)");
         if ( ! (DateTime.MinValue==AV51TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV51TicketFecha_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV50TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV50TicketFecha_From)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV54TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV54TicketHora_To)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV53TicketHora_From)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV55UsuarioNombre)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV61OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[TicketId]";
         }
         else if ( AV61OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV61OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV61OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[TicketFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TicketId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002H3( IGxContext context ,
                                             DateTime AV51TicketFecha_To ,
                                             DateTime AV50TicketFecha_From ,
                                             DateTime AV54TicketHora_To ,
                                             DateTime AV53TicketHora_From ,
                                             string AV55UsuarioNombre ,
                                             string AV60K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A94UsuarioRequerimiento ,
                                             short A5EstadoTicketId ,
                                             string A24EstadoTicketNombre ,
                                             long A54TicketLastId ,
                                             short AV61OrderedBy ,
                                             short A17EstadoTicketTecnicoId ,
                                             short AV6EstadoTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId])";
         AddWhere(sWhereString, "(@EstadoTicketTecnicoId = @AV6EstadoTicketTecnicoId)");
         if ( ! (DateTime.MinValue==AV51TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV51TicketFecha_To)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV50TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV50TicketFecha_From)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV54TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV54TicketHora_To)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV53TicketHora_From)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV55UsuarioNombre)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV61OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV61OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV61OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV61OrderedBy == 3 )
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
                     return conditional_H002H2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
               case 1 :
                     return conditional_H002H3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
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
          Object[] prmH002H2;
          prmH002H2 = new Object[] {
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV6EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV51TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV50TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV54TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV53TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV55UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002H3;
          prmH002H3 = new Object[] {
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV6EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV51TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV50TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV54TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV53TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV55UsuarioNombre",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((bool[]) buf[10])[0] = rslt.getBool(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((bool[]) buf[14])[0] = rslt.getBool(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((bool[]) buf[16])[0] = rslt.getBool(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((bool[]) buf[18])[0] = rslt.getBool(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((bool[]) buf[20])[0] = rslt.getBool(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((bool[]) buf[22])[0] = rslt.getBool(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((bool[]) buf[24])[0] = rslt.getBool(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((bool[]) buf[30])[0] = rslt.getBool(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((bool[]) buf[32])[0] = rslt.getBool(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((bool[]) buf[34])[0] = rslt.getBool(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((long[]) buf[36])[0] = rslt.getLong(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((string[]) buf[38])[0] = rslt.getVarchar(21);
                ((long[]) buf[39])[0] = rslt.getLong(22);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(23);
                ((DateTime[]) buf[41])[0] = rslt.getGXDate(24);
                ((long[]) buf[42])[0] = rslt.getLong(25);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
