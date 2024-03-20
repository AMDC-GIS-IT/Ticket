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
   public class wwticket : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwticket( )
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

      public wwticket( IGxContext context )
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
         chkavAtt_ticketid_visible = new GXCheckbox();
         chkavAtt_ticketfecha_visible = new GXCheckbox();
         chkavAtt_tickethora_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         chkavAtt_estadoticketticketnombre_visible = new GXCheckbox();
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
               nRC_GXsfl_172 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_172"), "."));
               nGXsfl_172_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_172_idx"), "."));
               sGXsfl_172_idx = GetPar( "sGXsfl_172_idx");
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
               AV58K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV48TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
               AV51TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
               AV52TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
               AV53UsuarioNombre = GetPar( "UsuarioNombre");
               AV74EstadoTicketTicketNombre = GetPar( "EstadoTicketTicketNombre");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV46ClassCollection);
               AV59OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV49TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
               AV81Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV71AutoLinksActivityList);
               AV65TicketFecha_IsAuthorized = StringUtil.StrToBool( GetPar( "TicketFecha_IsAuthorized"));
               AV14Att_TicketId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketId_Visible"));
               AV15Att_TicketFecha_Visible = StringUtil.StrToBool( GetPar( "Att_TicketFecha_Visible"));
               AV16Att_TicketHora_Visible = StringUtil.StrToBool( GetPar( "Att_TicketHora_Visible"));
               AV17Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
               AV18Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
               AV75Att_EstadoTicketTicketNombre_Visible = StringUtil.StrToBool( GetPar( "Att_EstadoTicketTicketNombre_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV78Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
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
         PA2R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188361118", false, true);
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwticket.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV58K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETFECHA_FROM", context.localUtil.Format(AV48TicketFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETHORA_FROM", context.localUtil.TToC( AV51TicketHora_From, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETHORA_TO", context.localUtil.TToC( AV52TicketHora_To, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIONOMBRE", AV53UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vESTADOTICKETTICKETNOMBRE", AV74EstadoTicketTicketNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_172", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_172), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV56FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV56FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV57DeletedTag));
         GxWebStd.gx_hidden_field( context, "vTICKETFECHA_TO", context.localUtil.DToC( AV49TicketFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV60GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV60GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV81Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV46ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV46ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUTOLINKSACTIVITYLIST", AV71AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUTOLINKSACTIVITYLIST", AV71AutoLinksActivityList);
         }
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vTICKETFECHA_ISAUTHORIZED", AV65TicketFecha_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV78Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTICKETFECHA_FROM", context.localUtil.DToC( AV48TicketFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSUMMARYTAGSUC_Emptystatemessage", StringUtil.RTrim( Filtersummarytagsuc_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
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
         context.WriteHtmlTextNl( "</form>") ;
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
            WE2R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2R2( ) ;
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
         return formatLink("wwticket.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWTicket" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticketes" ;
      }

      protected void WB2R0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Ticketes", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WorkWithContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_172_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV58K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV58K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicket.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV56FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV57DeletedTag);
            ucFiltersummarytagsuc.Render(context, "k2btagsviewer", Filtersummarytagsuc_Internalname, "FILTERSUMMARYTAGSUCContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicket.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockticketfecha_Internalname, "Fecha:", "", "", lblTextblockticketfecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            /* User Defined Control */
            ucTicketfecha_daterangepicker.SetProperty("ValueFrom", AV48TicketFecha_From);
            ucTicketfecha_daterangepicker.SetProperty("ValueTo", AV49TicketFecha_To);
            ucTicketfecha_daterangepicker.Render(context, "k2bdaterangepicker", Ticketfecha_daterangepicker_Internalname, "TICKETFECHA_DATERANGEPICKERContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocktickethora_Internalname, "Hora:", "", "", lblTextblocktickethora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDaterangefiltermaintable_tickethora_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickethora_from_Internalname, "Desde", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_172_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickethora_from_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickethora_from_Internalname, context.localUtil.TToC( AV51TicketHora_From, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV51TicketHora_From, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickethora_from_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickethora_from_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWTicket.htm");
            GxWebStd.gx_bitmap( context, edtavTickethora_from_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickethora_from_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWTicket.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDaterangeseparator_tickethora_Internalname, "-", "", "", lblDaterangeseparator_tickethora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickethora_to_Internalname, "Hasta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_172_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickethora_to_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickethora_to_Internalname, context.localUtil.TToC( AV52TicketHora_To, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV52TicketHora_To, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickethora_to_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickethora_to_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWTicket.htm");
            GxWebStd.gx_bitmap( context, edtavTickethora_to_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickethora_to_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWTicket.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_172_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV53UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV53UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWTicket.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEstadoticketticketnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEstadoticketticketnombre_Internalname, "Ticket", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_172_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstadoticketticketnombre_Internalname, AV74EstadoTicketTicketNombre, StringUtil.RTrim( context.localUtil.Format( AV74EstadoTicketTicketNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstadoticketticketnombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavEstadoticketticketnombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWTicket.htm");
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
            wb_table1_68_2R2( true) ;
         }
         else
         {
            wb_table1_68_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_68_2R2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"172\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Requerimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtEstadoTicketTicketNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Ticket") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Last Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "aptop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Desktop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Monitor") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Impresora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Escaner") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Internet/Router/Access Point") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Operativo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Office") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Antivirus") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Aplicación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Diseño") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Ingeniería") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Duro ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Periféricos") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "UPS") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Data Show") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Otros") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
               GridContainer.AddObjectProperty("CmpContext", "");
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
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A188EstadoTicketTicketNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadoTicketTicketNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTicketNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A53TicketLaptop));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A42TicketDesktop));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A55TicketMonitor));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A50TicketImpresora));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A45TicketEscaner));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A59TicketRouter));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A60TicketSistemaOperativo));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A56TicketOffice));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A39TicketAntivirus));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A40TicketAplicacion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A44TicketDisenio));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A51TicketIngenieria));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A58TicketPerifericos));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A87TicketUps));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A41TicketApoyoUsuario));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A52TicketInstalarDataShow));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A57TicketOtros));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV73Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 172 )
         {
            wbEnd = 0;
            nRC_GXsfl_172 = (int)(nGXsfl_172_idx-1);
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
            wb_table2_203_2R2( true) ;
         }
         else
         {
            wb_table2_203_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_203_2R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWTicket.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV60GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV62UC_OrderedBy);
            ucK2borderbyusercontrol.Render(context, "k2borderby", K2borderbyusercontrol_Internalname, "K2BORDERBYUSERCONTROLContainer");
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
         if ( wbEnd == 172 )
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

      protected void START2R2( )
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
            Form.Meta.addItem("description", "Ticketes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2R0( ) ;
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERSUMMARYTAGSUC.TAGDELETED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E132R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E142R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E152R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E162R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E172R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E182R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E212R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_172_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_172_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_172_idx), 4, 0), 4, "0");
                              SubsflControlProps_1722( ) ;
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFecha_Internalname), 0));
                              A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname), 0));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A188EstadoTicketTicketNombre = cgiGet( edtEstadoTicketTicketNombre_Internalname);
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
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
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                              AV73Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_172_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E222R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E232R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E252R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV58K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ticketfecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETFECHA_FROM"), 0) != AV48TicketFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tickethora_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETHORA_FROM"), 0) != AV51TicketHora_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tickethora_to Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETHORA_TO"), 0) != AV52TicketHora_To )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV53UsuarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Estadoticketticketnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vESTADOTICKETTICKETNOMBRE"), AV74EstadoTicketTicketNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE2R2( )
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

      protected void PA2R2( )
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
               GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
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
         SubsflControlProps_1722( ) ;
         while ( nGXsfl_172_idx <= nRC_GXsfl_172 )
         {
            sendrow_1722( ) ;
            nGXsfl_172_idx = ((subGrid_Islastpage==1)&&(nGXsfl_172_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_172_idx+1);
            sGXsfl_172_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_172_idx), 4, 0), 4, "0");
            SubsflControlProps_1722( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV58K2BToolsGenericSearchField ,
                                       DateTime AV48TicketFecha_From ,
                                       DateTime AV51TicketHora_From ,
                                       DateTime AV52TicketHora_To ,
                                       string AV53UsuarioNombre ,
                                       string AV74EstadoTicketTicketNombre ,
                                       GxSimpleCollection<string> AV46ClassCollection ,
                                       short AV59OrderedBy ,
                                       DateTime AV49TicketFecha_To ,
                                       string AV81Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV71AutoLinksActivityList ,
                                       bool AV65TicketFecha_IsAuthorized ,
                                       bool AV14Att_TicketId_Visible ,
                                       bool AV15Att_TicketFecha_Visible ,
                                       bool AV16Att_TicketHora_Visible ,
                                       bool AV17Att_UsuarioNombre_Visible ,
                                       bool AV18Att_UsuarioRequerimiento_Visible ,
                                       bool AV75Att_EstadoTicketTicketNombre_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV78Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232R2 ();
         GRID_nCurrentRecord = 0;
         RF2R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
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
         AV14Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TicketId_Visible));
         AssignAttri("", false, "AV14Att_TicketId_Visible", AV14Att_TicketId_Visible);
         AV15Att_TicketFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TicketFecha_Visible));
         AssignAttri("", false, "AV15Att_TicketFecha_Visible", AV15Att_TicketFecha_Visible);
         AV16Att_TicketHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TicketHora_Visible));
         AssignAttri("", false, "AV16Att_TicketHora_Visible", AV16Att_TicketHora_Visible);
         AV17Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV17Att_UsuarioNombre_Visible", AV17Att_UsuarioNombre_Visible);
         AV18Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV18Att_UsuarioRequerimiento_Visible", AV18Att_UsuarioRequerimiento_Visible);
         AV75Att_EstadoTicketTicketNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV75Att_EstadoTicketTicketNombre_Visible));
         AssignAttri("", false, "AV75Att_EstadoTicketTicketNombre_Visible", AV75Att_EstadoTicketTicketNombre_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV40GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV40GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232R2 ();
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV81Pgmname = "WWTicket";
         context.Gx_err = 0;
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 172;
         E242R2 ();
         nGXsfl_172_idx = 1;
         sGXsfl_172_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_172_idx), 4, 0), 4, "0");
         SubsflControlProps_1722( ) ;
         bGXsfl_172_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_1722( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV49TicketFecha_To ,
                                                 AV48TicketFecha_From ,
                                                 AV52TicketHora_To ,
                                                 AV51TicketHora_From ,
                                                 AV53UsuarioNombre ,
                                                 AV74EstadoTicketTicketNombre ,
                                                 AV58K2BToolsGenericSearchField ,
                                                 A46TicketFecha ,
                                                 A48TicketHora ,
                                                 A93UsuarioNombre ,
                                                 A188EstadoTicketTicketNombre ,
                                                 A14TicketId ,
                                                 A94UsuarioRequerimiento ,
                                                 AV59OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            lV53UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV53UsuarioNombre), "%", "");
            lV74EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV74EstadoTicketTicketNombre), "%", "");
            lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
            lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
            lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
            lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002R2 */
            pr_default.execute(0, new Object[] {AV49TicketFecha_To, AV48TicketFecha_From, AV52TicketHora_To, AV51TicketHora_From, lV53UsuarioNombre, lV74EstadoTicketTicketNombre, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_172_idx = 1;
            sGXsfl_172_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_172_idx), 4, 0), 4, "0");
            SubsflControlProps_1722( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A187EstadoTicketTicketId = H002R2_A187EstadoTicketTicketId[0];
               A57TicketOtros = H002R2_A57TicketOtros[0];
               n57TicketOtros = H002R2_n57TicketOtros[0];
               A52TicketInstalarDataShow = H002R2_A52TicketInstalarDataShow[0];
               n52TicketInstalarDataShow = H002R2_n52TicketInstalarDataShow[0];
               A41TicketApoyoUsuario = H002R2_A41TicketApoyoUsuario[0];
               n41TicketApoyoUsuario = H002R2_n41TicketApoyoUsuario[0];
               A87TicketUps = H002R2_A87TicketUps[0];
               n87TicketUps = H002R2_n87TicketUps[0];
               A58TicketPerifericos = H002R2_A58TicketPerifericos[0];
               n58TicketPerifericos = H002R2_n58TicketPerifericos[0];
               A43TicketDiscoDuroExterno = H002R2_A43TicketDiscoDuroExterno[0];
               n43TicketDiscoDuroExterno = H002R2_n43TicketDiscoDuroExterno[0];
               A51TicketIngenieria = H002R2_A51TicketIngenieria[0];
               n51TicketIngenieria = H002R2_n51TicketIngenieria[0];
               A44TicketDisenio = H002R2_A44TicketDisenio[0];
               n44TicketDisenio = H002R2_n44TicketDisenio[0];
               A40TicketAplicacion = H002R2_A40TicketAplicacion[0];
               n40TicketAplicacion = H002R2_n40TicketAplicacion[0];
               A39TicketAntivirus = H002R2_A39TicketAntivirus[0];
               n39TicketAntivirus = H002R2_n39TicketAntivirus[0];
               A56TicketOffice = H002R2_A56TicketOffice[0];
               n56TicketOffice = H002R2_n56TicketOffice[0];
               A60TicketSistemaOperativo = H002R2_A60TicketSistemaOperativo[0];
               n60TicketSistemaOperativo = H002R2_n60TicketSistemaOperativo[0];
               A59TicketRouter = H002R2_A59TicketRouter[0];
               n59TicketRouter = H002R2_n59TicketRouter[0];
               A45TicketEscaner = H002R2_A45TicketEscaner[0];
               n45TicketEscaner = H002R2_n45TicketEscaner[0];
               A50TicketImpresora = H002R2_A50TicketImpresora[0];
               n50TicketImpresora = H002R2_n50TicketImpresora[0];
               A55TicketMonitor = H002R2_A55TicketMonitor[0];
               n55TicketMonitor = H002R2_n55TicketMonitor[0];
               A42TicketDesktop = H002R2_A42TicketDesktop[0];
               n42TicketDesktop = H002R2_n42TicketDesktop[0];
               A53TicketLaptop = H002R2_A53TicketLaptop[0];
               n53TicketLaptop = H002R2_n53TicketLaptop[0];
               A54TicketLastId = H002R2_A54TicketLastId[0];
               A15UsuarioId = H002R2_A15UsuarioId[0];
               A188EstadoTicketTicketNombre = H002R2_A188EstadoTicketTicketNombre[0];
               A94UsuarioRequerimiento = H002R2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002R2_A93UsuarioNombre[0];
               A48TicketHora = H002R2_A48TicketHora[0];
               A46TicketFecha = H002R2_A46TicketFecha[0];
               A14TicketId = H002R2_A14TicketId[0];
               A188EstadoTicketTicketNombre = H002R2_A188EstadoTicketTicketNombre[0];
               A94UsuarioRequerimiento = H002R2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002R2_A93UsuarioNombre[0];
               E252R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 172;
            WB2R0( ) ;
         }
         bGXsfl_172_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV81Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID"+"_"+sGXsfl_172_idx, GetSecureSignedToken( sGXsfl_172_idx, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV78Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78Uri, "")), context));
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
                                              AV49TicketFecha_To ,
                                              AV48TicketFecha_From ,
                                              AV52TicketHora_To ,
                                              AV51TicketHora_From ,
                                              AV53UsuarioNombre ,
                                              AV74EstadoTicketTicketNombre ,
                                              AV58K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A93UsuarioNombre ,
                                              A188EstadoTicketTicketNombre ,
                                              A14TicketId ,
                                              A94UsuarioRequerimiento ,
                                              AV59OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV53UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV53UsuarioNombre), "%", "");
         lV74EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV74EstadoTicketTicketNombre), "%", "");
         lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
         lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
         lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
         lV58K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV58K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002R3 */
         pr_default.execute(1, new Object[] {AV49TicketFecha_To, AV48TicketFecha_From, AV52TicketHora_To, AV51TicketHora_From, lV53UsuarioNombre, lV74EstadoTicketTicketNombre, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField, lV58K2BToolsGenericSearchField});
         GRID_nRecordCount = H002R3_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV81Pgmname = "WWTicket";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV56FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV60GridOrders);
            /* Read saved values. */
            nRC_GXsfl_172 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_172"), ".", ","));
            AV57DeletedTag = cgiGet( "vDELETEDTAG");
            AV48TicketFecha_From = context.localUtil.CToD( cgiGet( "vTICKETFECHA_FROM"), 0);
            AV49TicketFecha_To = context.localUtil.CToD( cgiGet( "vTICKETFECHA_TO"), 0);
            AV62UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV59OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV58K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV58K2BToolsGenericSearchField", AV58K2BToolsGenericSearchField);
            if ( context.localUtil.VCDate( cgiGet( edtavTickethora_from_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora_From"}), 1, "vTICKETHORA_FROM");
               GX_FocusControl = edtavTickethora_from_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV51TicketHora_From = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV51TicketHora_From", context.localUtil.TToC( AV51TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV51TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickethora_from_Internalname)));
               AssignAttri("", false, "AV51TicketHora_From", context.localUtil.TToC( AV51TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTickethora_to_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora_To"}), 1, "vTICKETHORA_TO");
               GX_FocusControl = edtavTickethora_to_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52TicketHora_To = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV52TicketHora_To", context.localUtil.TToC( AV52TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV52TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickethora_to_Internalname)));
               AssignAttri("", false, "AV52TicketHora_To", context.localUtil.TToC( AV52TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            AV53UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV53UsuarioNombre", AV53UsuarioNombre);
            AV74EstadoTicketTicketNombre = cgiGet( edtavEstadoticketticketnombre_Internalname);
            AssignAttri("", false, "AV74EstadoTicketTicketNombre", AV74EstadoTicketTicketNombre);
            AV14Att_TicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketid_visible_Internalname));
            AssignAttri("", false, "AV14Att_TicketId_Visible", AV14Att_TicketId_Visible);
            AV15Att_TicketFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketfecha_visible_Internalname));
            AssignAttri("", false, "AV15Att_TicketFecha_Visible", AV15Att_TicketFecha_Visible);
            AV16Att_TicketHora_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickethora_visible_Internalname));
            AssignAttri("", false, "AV16Att_TicketHora_Visible", AV16Att_TicketHora_Visible);
            AV17Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri("", false, "AV17Att_UsuarioNombre_Visible", AV17Att_UsuarioNombre_Visible);
            AV18Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri("", false, "AV18Att_UsuarioRequerimiento_Visible", AV18Att_UsuarioRequerimiento_Visible);
            AV75Att_EstadoTicketTicketNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_estadoticketticketnombre_visible_Internalname));
            AssignAttri("", false, "AV75Att_EstadoTicketTicketNombre_Visible", AV75Att_EstadoTicketTicketNombre_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV40GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV40GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV58K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTICKETFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV48TicketFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETHORA_FROM")) != AV51TicketHora_From )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETHORA_TO")) != AV52TicketHora_To )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV53UsuarioNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vESTADOTICKETTICKETNOMBRE"), AV74EstadoTicketTicketNombre) != 0 )
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
         E222R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV47TicketFecha = DateTime.MinValue;
         AV48TicketFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV48TicketFecha_From", context.localUtil.Format(AV48TicketFecha_From, "99/99/9999"));
         AV49TicketFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV49TicketFecha_To", context.localUtil.Format(AV49TicketFecha_To, "99/99/9999"));
         AV50TicketHora = (DateTime)(DateTime.MinValue);
         AV51TicketHora_From = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.ServerDate( context, pr_default) , - ( (int)(30) )) ) ;
         AssignAttri("", false, "AV51TicketHora_From", context.localUtil.TToC( AV51TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
         AV52TicketHora_To = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV52TicketHora_To", context.localUtil.TToC( AV52TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
         AV53UsuarioNombre = "";
         AssignAttri("", false, "AV53UsuarioNombre", AV53UsuarioNombre);
         AV74EstadoTicketTicketNombre = "";
         AssignAttri("", false, "AV74EstadoTicketTicketNombre", AV74EstadoTicketTicketNombre);
         new k2bloadrowsperpage(context ).execute(  AV81Pgmname,  "Grid", out  AV41RowsPerPageVariable, out  AV42RowsPerPageLoaded) ;
         AssignAttri("", false, "AV41RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV41RowsPerPageVariable), 4, 0));
         if ( ! AV42RowsPerPageLoaded )
         {
            AV41RowsPerPageVariable = 20;
            AssignAttri("", false, "AV41RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV41RowsPerPageVariable), 4, 0));
         }
         AV40GridSettingsRowsPerPageVariable = AV41RowsPerPageVariable;
         AssignAttri("", false, "AV40GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV41RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Ticketes";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
         ucK2borderbyusercontrol.SendProperty(context, "", false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV60GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV61GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV61GridOrder.gxTpr_Ascendingorder = 0;
         AV61GridOrder.gxTpr_Descendingorder = 1;
         AV61GridOrder.gxTpr_Gridcolumnindex = 1;
         AV60GridOrders.Add(AV61GridOrder, 0);
         AV61GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV61GridOrder.gxTpr_Ascendingorder = 2;
         AV61GridOrder.gxTpr_Descendingorder = 3;
         AV61GridOrder.gxTpr_Gridcolumnindex = 2;
         AV60GridOrders.Add(AV61GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV63Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV63Messages = GXt_objcol_SdtMessages_Message1;
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV63Messages.Count )
         {
            AV64Message = ((GeneXus.Utils.SdtMessages_Message)AV63Messages.Item(AV82GXV1));
            GX_msglist.addItem(AV64Message.gxTpr_Description);
            AV82GXV1 = (int)(AV82GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV70ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV81Pgmname;
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV70ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV73Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_172_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         AV83Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_172_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_172_Refreshing);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
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
         new k2bscjoinstring(context ).execute(  AV46ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV43GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV81Pgmname,  AV43GridStateKey, out  AV44GridState) ;
         AV59OrderedBy = AV44GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV59OrderedBy", StringUtil.LTrimStr( (decimal)(AV59OrderedBy), 4, 0));
         AV62UC_OrderedBy = AV44GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV62UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV62UC_OrderedBy), 4, 0));
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "TicketFecha:From") == 0 )
            {
               AV48TicketFecha_From = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV48TicketFecha_From", context.localUtil.Format(AV48TicketFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "TicketFecha:To") == 0 )
            {
               AV49TicketFecha_To = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV49TicketFecha_To", context.localUtil.Format(AV49TicketFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "TicketHora:From") == 0 )
            {
               AV51TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( AV45GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV51TicketHora_From", context.localUtil.TToC( AV51TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "TicketHora:To") == 0 )
            {
               AV52TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV45GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV52TicketHora_To", context.localUtil.TToC( AV52TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre") == 0 )
            {
               AV53UsuarioNombre = AV45GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53UsuarioNombre", AV53UsuarioNombre);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "EstadoTicketTicketNombre") == 0 )
            {
               AV74EstadoTicketTicketNombre = AV45GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74EstadoTicketTicketNombre", AV74EstadoTicketTicketNombre);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV58K2BToolsGenericSearchField = AV45GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58K2BToolsGenericSearchField", AV58K2BToolsGenericSearchField);
            }
            AV84GXV2 = (int)(AV84GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV44GridState.gxTpr_Currentpage > 0 ) && ( AV44GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV44GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV43GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV81Pgmname,  AV43GridStateKey, out  AV44GridState) ;
         AV44GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV44GridState.gxTpr_Orderedby = AV59OrderedBy;
         AV44GridState.gxTpr_Filtervalues.Clear();
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "TicketFecha:From";
         AV45GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV48TicketFecha_From, "99/99/9999");
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "TicketFecha:To";
         AV45GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV49TicketFecha_To, "99/99/9999");
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "TicketHora:From";
         AV45GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV51TicketHora_From, "99:99");
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "TicketHora:To";
         AV45GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV52TicketHora_To, "99:99");
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre";
         AV45GridStateFilterValue.gxTpr_Value = AV53UsuarioNombre;
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "EstadoTicketTicketNombre";
         AV45GridStateFilterValue.gxTpr_Value = AV74EstadoTicketTicketNombre;
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV45GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV45GridStateFilterValue.gxTpr_Value = AV58K2BToolsGenericSearchField;
         AV44GridState.gxTpr_Filtervalues.Add(AV45GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV81Pgmname,  AV43GridStateKey,  AV44GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV68TrnContext = new SdtK2BTrnContext(context);
         AV68TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV68TrnContext.gxTpr_Returnmode = "Stack";
         AV68TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV68TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV68TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV68TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV68TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV68TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "Ticket",  AV68TrnContext) ;
      }

      protected void E132R2( )
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
         AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV14Att_TicketId_Visible = true;
         AssignAttri("", false, "AV14Att_TicketId_Visible", AV14Att_TicketId_Visible);
         edtTicketFecha_Visible = 1;
         AssignProp("", false, edtTicketFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV15Att_TicketFecha_Visible = true;
         AssignAttri("", false, "AV15Att_TicketFecha_Visible", AV15Att_TicketFecha_Visible);
         edtTicketHora_Visible = 1;
         AssignProp("", false, edtTicketHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketHora_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV16Att_TicketHora_Visible = true;
         AssignAttri("", false, "AV16Att_TicketHora_Visible", AV16Att_TicketHora_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV17Att_UsuarioNombre_Visible = true;
         AssignAttri("", false, "AV17Att_UsuarioNombre_Visible", AV17Att_UsuarioNombre_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV18Att_UsuarioRequerimiento_Visible = true;
         AssignAttri("", false, "AV18Att_UsuarioRequerimiento_Visible", AV18Att_UsuarioRequerimiento_Visible);
         edtEstadoTicketTicketNombre_Visible = 1;
         AssignProp("", false, edtEstadoTicketTicketNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketNombre_Visible), 5, 0), !bGXsfl_172_Refreshing);
         AV75Att_EstadoTicketTicketNombre_Visible = true;
         AssignAttri("", false, "AV75Att_EstadoTicketTicketNombre_Visible", AV75Att_EstadoTicketTicketNombre_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV81Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV85GXV3 = 1;
         while ( AV85GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV85GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  edtTicketId_Visible = 0;
                  AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV14Att_TicketId_Visible = false;
                  AssignAttri("", false, "AV14Att_TicketId_Visible", AV14Att_TicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  edtTicketFecha_Visible = 0;
                  AssignProp("", false, edtTicketFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV15Att_TicketFecha_Visible = false;
                  AssignAttri("", false, "AV15Att_TicketFecha_Visible", AV15Att_TicketFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  edtTicketHora_Visible = 0;
                  AssignProp("", false, edtTicketHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketHora_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV16Att_TicketHora_Visible = false;
                  AssignAttri("", false, "AV16Att_TicketHora_Visible", AV16Att_TicketHora_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV17Att_UsuarioNombre_Visible = false;
                  AssignAttri("", false, "AV17Att_UsuarioNombre_Visible", AV17Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV18Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri("", false, "AV18Att_UsuarioRequerimiento_Visible", AV18Att_UsuarioRequerimiento_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTicketTicketNombre") == 0 )
               {
                  edtEstadoTicketTicketNombre_Visible = 0;
                  AssignProp("", false, edtEstadoTicketTicketNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketNombre_Visible), 5, 0), !bGXsfl_172_Refreshing);
                  AV75Att_EstadoTicketTicketNombre_Visible = false;
                  AssignAttri("", false, "AV75Att_EstadoTicketTicketNombre_Visible", AV75Att_EstadoTicketTicketNombre_Visible);
               }
            }
            AV85GXV3 = (int)(AV85GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketId";
         AV13GridColumn.gxTpr_Columntitle = "RST No.";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketFecha";
         AV13GridColumn.gxTpr_Columntitle = "Fecha:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketHora";
         AV13GridColumn.gxTpr_Columntitle = "Hora:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV13GridColumn.gxTpr_Columntitle = "Usuario";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV13GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "EstadoTicketTicketNombre";
         AV13GridColumn.gxTpr_Columntitle = "Ticket";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV10GridConfiguration.gxTpr_Gridcolumns = AV12GridColumns;
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
         AV70ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWTicket";
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWTicket";
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV70ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttInsert_Visible = 1;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
         else
         {
            bttInsert_Visible = 0;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV70ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicket";
         AV70ActivityList.Add(AV72ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV70ActivityList) ;
         AV65TicketFecha_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV65TicketFecha_IsAuthorized", AV65TicketFecha_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV70ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_172_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_172_Refreshing);
         }
      }

      protected void S152( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         returnInSub = false;
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E242R2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV46ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV73Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_172_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         AV83Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.convertURL( context.PathToRelativeUrl( AV73Update))), !bGXsfl_172_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV73Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_172_Refreshing);
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
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV71AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV71AutoLinksActivityList.Add(AV72ActivityListItem, 0);
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTicket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTicket";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV72ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerEstadoTicket";
         AV71AutoLinksActivityList.Add(AV72ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV71AutoLinksActivityList) ;
         AV62UC_OrderedBy = AV59OrderedBy;
         AssignAttri("", false, "AV62UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV62UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV46ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV71AutoLinksActivityList", AV71AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56FilterTags", AV56FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E252R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV71AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV71AutoLinksActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
         }
         if ( AV65TicketFecha_IsAuthorized )
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
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 172;
         }
         sendrow_1722( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_172_Refreshing )
         {
            context.DoAjaxLoad(172, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV54K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV48TicketFecha_From) || ! (DateTime.MinValue==AV49TicketFecha_To) )
         {
            AV55K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV55K2BFilterValuesSDTItem.gxTpr_Name = "TicketFecha";
            AV55K2BFilterValuesSDTItem.gxTpr_Description = "Fecha:";
            AV55K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV55K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV55K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV48TicketFecha_From ) ;
            AV55K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV49TicketFecha_To ) ;
            AV55K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV54K2BFilterValuesSDT.Add(AV55K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV51TicketHora_From) || ! (DateTime.MinValue==AV52TicketHora_To) )
         {
            AV55K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV55K2BFilterValuesSDTItem.gxTpr_Name = "TicketHora";
            AV55K2BFilterValuesSDTItem.gxTpr_Description = "Hora:";
            AV55K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV55K2BFilterValuesSDTItem.gxTpr_Type = "DateTimeRange";
            AV55K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            AV55K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = AV51TicketHora_From;
            AV55K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = AV52TicketHora_To;
            AV54K2BFilterValuesSDT.Add(AV55K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53UsuarioNombre)) )
         {
            AV55K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV55K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioNombre";
            AV55K2BFilterValuesSDTItem.gxTpr_Description = "Usuario";
            AV55K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV55K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV55K2BFilterValuesSDTItem.gxTpr_Value = AV53UsuarioNombre;
            AV55K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV53UsuarioNombre;
            AV54K2BFilterValuesSDT.Add(AV55K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74EstadoTicketTicketNombre)) )
         {
            AV55K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV55K2BFilterValuesSDTItem.gxTpr_Name = "EstadoTicketTicketNombre";
            AV55K2BFilterValuesSDTItem.gxTpr_Description = "Ticket";
            AV55K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV55K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV55K2BFilterValuesSDTItem.gxTpr_Value = AV74EstadoTicketTicketNombre;
            AV55K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV74EstadoTicketTicketNombre;
            AV54K2BFilterValuesSDT.Add(AV55K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV54K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV56FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV81Pgmname,  "Grid",  AV54K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV56FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112R2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV57DeletedTag, "TicketFecha") == 0 )
         {
            AV48TicketFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV48TicketFecha_From", context.localUtil.Format(AV48TicketFecha_From, "99/99/9999"));
            AV49TicketFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV49TicketFecha_To", context.localUtil.Format(AV49TicketFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV57DeletedTag, "TicketHora") == 0 )
         {
            AV51TicketHora_From = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV51TicketHora_From", context.localUtil.TToC( AV51TicketHora_From, 0, 5, 0, 3, "/", ":", " "));
            AV52TicketHora_To = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV52TicketHora_To", context.localUtil.TToC( AV52TicketHora_To, 0, 5, 0, 3, "/", ":", " "));
         }
         else if ( StringUtil.StrCmp(AV57DeletedTag, "UsuarioNombre") == 0 )
         {
            AV53UsuarioNombre = "";
            AssignAttri("", false, "AV53UsuarioNombre", AV53UsuarioNombre);
         }
         else if ( StringUtil.StrCmp(AV57DeletedTag, "EstadoTicketTicketNombre") == 0 )
         {
            AV74EstadoTicketTicketNombre = "";
            AssignAttri("", false, "AV74EstadoTicketTicketNombre", AV74EstadoTicketTicketNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void E122R2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV59OrderedBy = AV62UC_OrderedBy;
         AssignAttri("", false, "AV59OrderedBy", StringUtil.LTrimStr( (decimal)(AV59OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void E142R2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV81Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV86GXV4 = 1;
         while ( AV86GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV86GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_TicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_TicketFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_TicketHora_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_UsuarioRequerimiento_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "EstadoTicketTicketNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV75Att_EstadoTicketTicketNombre_Visible;
            }
            AV86GXV4 = (int)(AV86GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV81Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV62UC_OrderedBy = AV59OrderedBy;
         AssignAttri("", false, "AV62UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV62UC_OrderedBy), 4, 0));
         if ( AV41RowsPerPageVariable != AV40GridSettingsRowsPerPageVariable )
         {
            AV41RowsPerPageVariable = AV40GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV41RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV41RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV41RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV81Pgmname,  "Grid",  AV41RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV58K2BToolsGenericSearchField, AV48TicketFecha_From, AV51TicketHora_From, AV52TicketHora_To, AV53UsuarioNombre, AV74EstadoTicketTicketNombre, AV46ClassCollection, AV59OrderedBy, AV49TicketFecha_To, AV81Pgmname, AV8CurrentPage, AV10GridConfiguration, AV71AutoLinksActivityList, AV65TicketFecha_IsAuthorized, AV14Att_TicketId_Visible, AV15Att_TicketFecha_Visible, AV16Att_TicketHora_Visible, AV17Att_UsuarioNombre_Visible, AV18Att_UsuarioRequerimiento_Visible, AV75Att_EstadoTicketTicketNombre_Visible, AV11FreezeColumnTitles, AV78Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void S172( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV8CurrentPage > AV9K2BMaxPages ) && ( AV9K2BMaxPages > 0 ) )
         {
            AV8CurrentPage = AV9K2BMaxPages;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefresh();
         }
         if ( AV9K2BMaxPages == 0 )
         {
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         else
         {
            AV8CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp("", false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage-1), 10, 0);
         AssignProp("", false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage), 5, 0);
         AssignProp("", false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV8CurrentPage+1), 10, 0);
         AssignProp("", false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV9K2BMaxPages), 6, 0);
         AssignProp("", false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV8CurrentPage) || ( AV8CurrentPage <= 1 ) )
         {
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblPreviouspagetextblock_Visible = 1;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == 2 )
            {
               lblFirstpagetextblock_Visible = 0;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblFirstpagetextblock_Visible = 1;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == 3 )
               {
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV8CurrentPage == AV9K2BMaxPages )
         {
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            lblNextpagetextblock_Visible = 0;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblNextpagetextblock_Visible = 1;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV8CurrentPage == AV9K2BMaxPages - 1 )
            {
               lblLastpagetextblock_Visible = 0;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblLastpagetextblock_Visible = 1;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV8CurrentPage == AV9K2BMaxPages - 2 )
               {
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV8CurrentPage <= 1 ) && ( AV9K2BMaxPages <= 1 ) )
         {
            divK2btoolspagingcontainertable_Visible = 0;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            divK2btoolspagingcontainertable_Visible = 1;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E152R2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV8CurrentPage = 1;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void E162R2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV8CurrentPage > 1 )
         {
            AV8CurrentPage = (int)(AV8CurrentPage-1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void E172R2( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV8CurrentPage != AV9K2BMaxPages )
         {
            AV8CurrentPage = (int)(AV8CurrentPage+1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
      }

      protected void E182R2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         AV8CurrentPage = AV9K2BMaxPages;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46ClassCollection", AV46ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV81Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
         AV11FreezeColumnTitles = AV10GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         if ( AV11FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV46ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV46ClassCollection) ;
         }
      }

      protected void E192R2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  "ExportWWTicket") )
         {
            new exportwwticket(context ).execute(  AV48TicketFecha_From,  AV49TicketFecha_To,  AV51TicketHora_From,  AV52TicketHora_To,  AV53UsuarioNombre,  AV74EstadoTicketTicketNombre,  AV58K2BToolsGenericSearchField,  AV59OrderedBy, out  AV76OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV76OutFile, out  AV78Uri) )
            {
               CallWebObject(formatLink(AV78Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV77Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV77Guid.ToString(),  AV76OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV77Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202R2( )
      {
         /* Filtertoggle_combined_Click Routine */
         returnInSub = false;
         if ( divFiltercollapsiblesection_combined_Visible != 0 )
         {
            divFiltercollapsiblesection_combined_Visible = 0;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         else
         {
            divFiltercollapsiblesection_combined_Visible = 1;
            AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
            imgFiltertoggle_combined_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
            AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E212R2( )
      {
         /* Filterclose_combined_Click Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         imgFiltertoggle_combined_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgFiltertoggle_combined_Bitmap)), true);
         AssignProp("", false, imgFiltertoggle_combined_Internalname, "SrcSet", context.GetImageSrcSet( imgFiltertoggle_combined_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void wb_table2_203_2R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_203_2R2e( true) ;
         }
         else
         {
            wb_table2_203_2R2e( false) ;
         }
      }

      protected void wb_table1_68_2R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e262r1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicket.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWTicket.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketid_visible_Internalname, StringUtil.BoolToStr( AV14Att_TicketId_Visible), "", "RST No.", 1, chkavAtt_ticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketfecha_visible_Internalname, StringUtil.BoolToStr( AV15Att_TicketFecha_Visible), "", "Fecha:", 1, chkavAtt_ticketfecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickethora_visible_Internalname, StringUtil.BoolToStr( AV16Att_TicketHora_Visible), "", "Hora:", 1, chkavAtt_tickethora_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV17Att_UsuarioNombre_Visible), "", "Usuario", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(115, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,115);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioRequerimiento_Visible), "", "Requerimiento", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
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
            GxWebStd.gx_div_start( context, divEstadoticketticketnombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_estadoticketticketnombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_estadoticketticketnombre_visible_Internalname, "Ticket", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_estadoticketticketnombre_visible_Internalname, StringUtil.BoolToStr( AV75Att_EstadoTicketTicketNombre_Visible), "", "Ticket", 1, chkavAtt_estadoticketticketnombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_172_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "", true, 1, "HLP_WWTicket.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (string)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_172_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(139, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,139);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(172), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicket.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e272r1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicket.htm");
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
            wb_table3_153_2R2( true) ;
         }
         else
         {
            wb_table3_153_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_153_2R2e( bool wbgen )
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
            wb_table4_160_2R2( true) ;
         }
         else
         {
            wb_table4_160_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_160_2R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_68_2R2e( true) ;
         }
         else
         {
            wb_table1_68_2R2e( false) ;
         }
      }

      protected void wb_table4_160_2R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(172), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicket.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_160_2R2e( true) ;
         }
         else
         {
            wb_table4_160_2R2e( false) ;
         }
      }

      protected void wb_table3_153_2R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(172), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e282r1_client"+"'", TempTags, "", 2, "HLP_WWTicket.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(172), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicket.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_153_2R2e( true) ;
         }
         else
         {
            wb_table3_153_2R2e( false) ;
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188362096", true, true);
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
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wwticket.js", "?2024188362097", false, true);
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

      protected void SubsflControlProps_1722( )
      {
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_172_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_172_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_172_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_172_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_172_idx;
         edtEstadoTicketTicketNombre_Internalname = "ESTADOTICKETTICKETNOMBRE_"+sGXsfl_172_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_172_idx;
         edtTicketLastId_Internalname = "TICKETLASTID_"+sGXsfl_172_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_172_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_172_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_172_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_172_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_172_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_172_idx;
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO_"+sGXsfl_172_idx;
         chkTicketOffice_Internalname = "TICKETOFFICE_"+sGXsfl_172_idx;
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS_"+sGXsfl_172_idx;
         chkTicketAplicacion_Internalname = "TICKETAPLICACION_"+sGXsfl_172_idx;
         chkTicketDisenio_Internalname = "TICKETDISENIO_"+sGXsfl_172_idx;
         chkTicketIngenieria_Internalname = "TICKETINGENIERIA_"+sGXsfl_172_idx;
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO_"+sGXsfl_172_idx;
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS_"+sGXsfl_172_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_172_idx;
         chkTicketApoyoUsuario_Internalname = "TICKETAPOYOUSUARIO_"+sGXsfl_172_idx;
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW_"+sGXsfl_172_idx;
         chkTicketOtros_Internalname = "TICKETOTROS_"+sGXsfl_172_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_172_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_172_idx;
      }

      protected void SubsflControlProps_fel_1722( )
      {
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_172_fel_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_172_fel_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_172_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_172_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_172_fel_idx;
         edtEstadoTicketTicketNombre_Internalname = "ESTADOTICKETTICKETNOMBRE_"+sGXsfl_172_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_172_fel_idx;
         edtTicketLastId_Internalname = "TICKETLASTID_"+sGXsfl_172_fel_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_172_fel_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_172_fel_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_172_fel_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_172_fel_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_172_fel_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_172_fel_idx;
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO_"+sGXsfl_172_fel_idx;
         chkTicketOffice_Internalname = "TICKETOFFICE_"+sGXsfl_172_fel_idx;
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS_"+sGXsfl_172_fel_idx;
         chkTicketAplicacion_Internalname = "TICKETAPLICACION_"+sGXsfl_172_fel_idx;
         chkTicketDisenio_Internalname = "TICKETDISENIO_"+sGXsfl_172_fel_idx;
         chkTicketIngenieria_Internalname = "TICKETINGENIERIA_"+sGXsfl_172_fel_idx;
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO_"+sGXsfl_172_fel_idx;
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS_"+sGXsfl_172_fel_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_172_fel_idx;
         chkTicketApoyoUsuario_Internalname = "TICKETAPOYOUSUARIO_"+sGXsfl_172_fel_idx;
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW_"+sGXsfl_172_fel_idx;
         chkTicketOtros_Internalname = "TICKETOTROS_"+sGXsfl_172_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_172_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_172_fel_idx;
      }

      protected void sendrow_1722( )
      {
         SubsflControlProps_1722( ) ;
         WB2R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_172_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_172_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_172_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFecha_Internalname,context.localUtil.Format(A46TicketFecha, "99/99/9999"),context.localUtil.Format( A46TicketFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTicketFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtTicketFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHora_Internalname,context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A48TicketHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtEstadoTicketTicketNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketTicketNombre_Internalname,(string)A188EstadoTicketTicketNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadoTicketTicketNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadoTicketTicketNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtEstadoTicketTicketNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketLastId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketLastId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETLAPTOP_" + sGXsfl_172_idx;
            chkTicketLaptop.Name = GXCCtl;
            chkTicketLaptop.WebTags = "";
            chkTicketLaptop.Caption = "";
            AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_172_Refreshing);
            chkTicketLaptop.CheckedValue = "false";
            A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
            n53TicketLaptop = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketLaptop_Internalname,StringUtil.BoolToStr( A53TicketLaptop),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDESKTOP_" + sGXsfl_172_idx;
            chkTicketDesktop.Name = GXCCtl;
            chkTicketDesktop.WebTags = "";
            chkTicketDesktop.Caption = "";
            AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_172_Refreshing);
            chkTicketDesktop.CheckedValue = "false";
            A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
            n42TicketDesktop = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDesktop_Internalname,StringUtil.BoolToStr( A42TicketDesktop),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETMONITOR_" + sGXsfl_172_idx;
            chkTicketMonitor.Name = GXCCtl;
            chkTicketMonitor.WebTags = "";
            chkTicketMonitor.Caption = "";
            AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_172_Refreshing);
            chkTicketMonitor.CheckedValue = "false";
            A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
            n55TicketMonitor = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketMonitor_Internalname,StringUtil.BoolToStr( A55TicketMonitor),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETIMPRESORA_" + sGXsfl_172_idx;
            chkTicketImpresora.Name = GXCCtl;
            chkTicketImpresora.WebTags = "";
            chkTicketImpresora.Caption = "";
            AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_172_Refreshing);
            chkTicketImpresora.CheckedValue = "false";
            A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
            n50TicketImpresora = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketImpresora_Internalname,StringUtil.BoolToStr( A50TicketImpresora),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETESCANER_" + sGXsfl_172_idx;
            chkTicketEscaner.Name = GXCCtl;
            chkTicketEscaner.WebTags = "";
            chkTicketEscaner.Caption = "";
            AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_172_Refreshing);
            chkTicketEscaner.CheckedValue = "false";
            A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
            n45TicketEscaner = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketEscaner_Internalname,StringUtil.BoolToStr( A45TicketEscaner),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETROUTER_" + sGXsfl_172_idx;
            chkTicketRouter.Name = GXCCtl;
            chkTicketRouter.WebTags = "";
            chkTicketRouter.Caption = "";
            AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_172_Refreshing);
            chkTicketRouter.CheckedValue = "false";
            A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
            n59TicketRouter = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketRouter_Internalname,StringUtil.BoolToStr( A59TicketRouter),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_172_idx;
            chkTicketSistemaOperativo.Name = GXCCtl;
            chkTicketSistemaOperativo.WebTags = "";
            chkTicketSistemaOperativo.Caption = "";
            AssignProp("", false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_172_Refreshing);
            chkTicketSistemaOperativo.CheckedValue = "false";
            A60TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( A60TicketSistemaOperativo));
            n60TicketSistemaOperativo = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketSistemaOperativo_Internalname,StringUtil.BoolToStr( A60TicketSistemaOperativo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETOFFICE_" + sGXsfl_172_idx;
            chkTicketOffice.Name = GXCCtl;
            chkTicketOffice.WebTags = "";
            chkTicketOffice.Caption = "";
            AssignProp("", false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_172_Refreshing);
            chkTicketOffice.CheckedValue = "false";
            A56TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( A56TicketOffice));
            n56TicketOffice = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketOffice_Internalname,StringUtil.BoolToStr( A56TicketOffice),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_172_idx;
            chkTicketAntivirus.Name = GXCCtl;
            chkTicketAntivirus.WebTags = "";
            chkTicketAntivirus.Caption = "";
            AssignProp("", false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_172_Refreshing);
            chkTicketAntivirus.CheckedValue = "false";
            A39TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( A39TicketAntivirus));
            n39TicketAntivirus = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketAntivirus_Internalname,StringUtil.BoolToStr( A39TicketAntivirus),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETAPLICACION_" + sGXsfl_172_idx;
            chkTicketAplicacion.Name = GXCCtl;
            chkTicketAplicacion.WebTags = "";
            chkTicketAplicacion.Caption = "";
            AssignProp("", false, chkTicketAplicacion_Internalname, "TitleCaption", chkTicketAplicacion.Caption, !bGXsfl_172_Refreshing);
            chkTicketAplicacion.CheckedValue = "false";
            A40TicketAplicacion = StringUtil.StrToBool( StringUtil.BoolToStr( A40TicketAplicacion));
            n40TicketAplicacion = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketAplicacion_Internalname,StringUtil.BoolToStr( A40TicketAplicacion),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDISENIO_" + sGXsfl_172_idx;
            chkTicketDisenio.Name = GXCCtl;
            chkTicketDisenio.WebTags = "";
            chkTicketDisenio.Caption = "";
            AssignProp("", false, chkTicketDisenio_Internalname, "TitleCaption", chkTicketDisenio.Caption, !bGXsfl_172_Refreshing);
            chkTicketDisenio.CheckedValue = "false";
            A44TicketDisenio = StringUtil.StrToBool( StringUtil.BoolToStr( A44TicketDisenio));
            n44TicketDisenio = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDisenio_Internalname,StringUtil.BoolToStr( A44TicketDisenio),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETINGENIERIA_" + sGXsfl_172_idx;
            chkTicketIngenieria.Name = GXCCtl;
            chkTicketIngenieria.WebTags = "";
            chkTicketIngenieria.Caption = "";
            AssignProp("", false, chkTicketIngenieria_Internalname, "TitleCaption", chkTicketIngenieria.Caption, !bGXsfl_172_Refreshing);
            chkTicketIngenieria.CheckedValue = "false";
            A51TicketIngenieria = StringUtil.StrToBool( StringUtil.BoolToStr( A51TicketIngenieria));
            n51TicketIngenieria = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketIngenieria_Internalname,StringUtil.BoolToStr( A51TicketIngenieria),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_172_idx;
            chkTicketDiscoDuroExterno.Name = GXCCtl;
            chkTicketDiscoDuroExterno.WebTags = "";
            chkTicketDiscoDuroExterno.Caption = "";
            AssignProp("", false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_172_Refreshing);
            chkTicketDiscoDuroExterno.CheckedValue = "false";
            A43TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
            n43TicketDiscoDuroExterno = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDiscoDuroExterno_Internalname,StringUtil.BoolToStr( A43TicketDiscoDuroExterno),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_172_idx;
            chkTicketPerifericos.Name = GXCCtl;
            chkTicketPerifericos.WebTags = "";
            chkTicketPerifericos.Caption = "";
            AssignProp("", false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_172_Refreshing);
            chkTicketPerifericos.CheckedValue = "false";
            A58TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( A58TicketPerifericos));
            n58TicketPerifericos = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketPerifericos_Internalname,StringUtil.BoolToStr( A58TicketPerifericos),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETUPS_" + sGXsfl_172_idx;
            chkTicketUps.Name = GXCCtl;
            chkTicketUps.WebTags = "";
            chkTicketUps.Caption = "";
            AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_172_Refreshing);
            chkTicketUps.CheckedValue = "false";
            A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
            n87TicketUps = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketUps_Internalname,StringUtil.BoolToStr( A87TicketUps),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETAPOYOUSUARIO_" + sGXsfl_172_idx;
            chkTicketApoyoUsuario.Name = GXCCtl;
            chkTicketApoyoUsuario.WebTags = "";
            chkTicketApoyoUsuario.Caption = "";
            AssignProp("", false, chkTicketApoyoUsuario_Internalname, "TitleCaption", chkTicketApoyoUsuario.Caption, !bGXsfl_172_Refreshing);
            chkTicketApoyoUsuario.CheckedValue = "false";
            A41TicketApoyoUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( A41TicketApoyoUsuario));
            n41TicketApoyoUsuario = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketApoyoUsuario_Internalname,StringUtil.BoolToStr( A41TicketApoyoUsuario),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_172_idx;
            chkTicketInstalarDataShow.Name = GXCCtl;
            chkTicketInstalarDataShow.WebTags = "";
            chkTicketInstalarDataShow.Caption = "";
            AssignProp("", false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_172_Refreshing);
            chkTicketInstalarDataShow.CheckedValue = "false";
            A52TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( A52TicketInstalarDataShow));
            n52TicketInstalarDataShow = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketInstalarDataShow_Internalname,StringUtil.BoolToStr( A52TicketInstalarDataShow),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETOTROS_" + sGXsfl_172_idx;
            chkTicketOtros.Name = GXCCtl;
            chkTicketOtros.WebTags = "";
            chkTicketOtros.Caption = "";
            AssignProp("", false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_172_Refreshing);
            chkTicketOtros.CheckedValue = "false";
            A57TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( A57TicketOtros));
            n57TicketOtros = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketOtros_Internalname,StringUtil.BoolToStr( A57TicketOtros),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)172,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV73Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV73Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV83Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV73Update)) ? AV83Update_GXI : context.PathToRelativeUrl( AV73Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV73Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_172_idx = ((subGrid_Islastpage==1)&&(nGXsfl_172_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_172_idx+1);
            sGXsfl_172_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_172_idx), 4, 0), 4, "0");
            SubsflControlProps_1722( ) ;
         }
         /* End function sendrow_1722 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_ticketid_visible.Name = "vATT_TICKETID_VISIBLE";
         chkavAtt_ticketid_visible.WebTags = "";
         chkavAtt_ticketid_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketid_visible_Internalname, "TitleCaption", chkavAtt_ticketid_visible.Caption, true);
         chkavAtt_ticketid_visible.CheckedValue = "false";
         AV14Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TicketId_Visible));
         AssignAttri("", false, "AV14Att_TicketId_Visible", AV14Att_TicketId_Visible);
         chkavAtt_ticketfecha_visible.Name = "vATT_TICKETFECHA_VISIBLE";
         chkavAtt_ticketfecha_visible.WebTags = "";
         chkavAtt_ticketfecha_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketfecha_visible_Internalname, "TitleCaption", chkavAtt_ticketfecha_visible.Caption, true);
         chkavAtt_ticketfecha_visible.CheckedValue = "false";
         AV15Att_TicketFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TicketFecha_Visible));
         AssignAttri("", false, "AV15Att_TicketFecha_Visible", AV15Att_TicketFecha_Visible);
         chkavAtt_tickethora_visible.Name = "vATT_TICKETHORA_VISIBLE";
         chkavAtt_tickethora_visible.WebTags = "";
         chkavAtt_tickethora_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickethora_visible_Internalname, "TitleCaption", chkavAtt_tickethora_visible.Caption, true);
         chkavAtt_tickethora_visible.CheckedValue = "false";
         AV16Att_TicketHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TicketHora_Visible));
         AssignAttri("", false, "AV16Att_TicketHora_Visible", AV16Att_TicketHora_Visible);
         chkavAtt_usuarionombre_visible.Name = "vATT_USUARIONOMBRE_VISIBLE";
         chkavAtt_usuarionombre_visible.WebTags = "";
         chkavAtt_usuarionombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarionombre_visible_Internalname, "TitleCaption", chkavAtt_usuarionombre_visible.Caption, true);
         chkavAtt_usuarionombre_visible.CheckedValue = "false";
         AV17Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV17Att_UsuarioNombre_Visible", AV17Att_UsuarioNombre_Visible);
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         AV18Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV18Att_UsuarioRequerimiento_Visible", AV18Att_UsuarioRequerimiento_Visible);
         chkavAtt_estadoticketticketnombre_visible.Name = "vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE";
         chkavAtt_estadoticketticketnombre_visible.WebTags = "";
         chkavAtt_estadoticketticketnombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_estadoticketticketnombre_visible_Internalname, "TitleCaption", chkavAtt_estadoticketticketnombre_visible.Caption, true);
         chkavAtt_estadoticketticketnombre_visible.CheckedValue = "false";
         AV75Att_EstadoTicketTicketNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV75Att_EstadoTicketTicketNombre_Visible));
         AssignAttri("", false, "AV75Att_EstadoTicketTicketNombre_Visible", AV75Att_EstadoTicketTicketNombre_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV40GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV40GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV40GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         GXCCtl = "TICKETLAPTOP_" + sGXsfl_172_idx;
         chkTicketLaptop.Name = GXCCtl;
         chkTicketLaptop.WebTags = "";
         chkTicketLaptop.Caption = "";
         AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_172_Refreshing);
         chkTicketLaptop.CheckedValue = "false";
         A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
         n53TicketLaptop = false;
         GXCCtl = "TICKETDESKTOP_" + sGXsfl_172_idx;
         chkTicketDesktop.Name = GXCCtl;
         chkTicketDesktop.WebTags = "";
         chkTicketDesktop.Caption = "";
         AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_172_Refreshing);
         chkTicketDesktop.CheckedValue = "false";
         A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
         n42TicketDesktop = false;
         GXCCtl = "TICKETMONITOR_" + sGXsfl_172_idx;
         chkTicketMonitor.Name = GXCCtl;
         chkTicketMonitor.WebTags = "";
         chkTicketMonitor.Caption = "";
         AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_172_Refreshing);
         chkTicketMonitor.CheckedValue = "false";
         A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
         n55TicketMonitor = false;
         GXCCtl = "TICKETIMPRESORA_" + sGXsfl_172_idx;
         chkTicketImpresora.Name = GXCCtl;
         chkTicketImpresora.WebTags = "";
         chkTicketImpresora.Caption = "";
         AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_172_Refreshing);
         chkTicketImpresora.CheckedValue = "false";
         A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
         n50TicketImpresora = false;
         GXCCtl = "TICKETESCANER_" + sGXsfl_172_idx;
         chkTicketEscaner.Name = GXCCtl;
         chkTicketEscaner.WebTags = "";
         chkTicketEscaner.Caption = "";
         AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_172_Refreshing);
         chkTicketEscaner.CheckedValue = "false";
         A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
         n45TicketEscaner = false;
         GXCCtl = "TICKETROUTER_" + sGXsfl_172_idx;
         chkTicketRouter.Name = GXCCtl;
         chkTicketRouter.WebTags = "";
         chkTicketRouter.Caption = "";
         AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_172_Refreshing);
         chkTicketRouter.CheckedValue = "false";
         A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
         n59TicketRouter = false;
         GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_172_idx;
         chkTicketSistemaOperativo.Name = GXCCtl;
         chkTicketSistemaOperativo.WebTags = "";
         chkTicketSistemaOperativo.Caption = "";
         AssignProp("", false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_172_Refreshing);
         chkTicketSistemaOperativo.CheckedValue = "false";
         A60TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( A60TicketSistemaOperativo));
         n60TicketSistemaOperativo = false;
         GXCCtl = "TICKETOFFICE_" + sGXsfl_172_idx;
         chkTicketOffice.Name = GXCCtl;
         chkTicketOffice.WebTags = "";
         chkTicketOffice.Caption = "";
         AssignProp("", false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_172_Refreshing);
         chkTicketOffice.CheckedValue = "false";
         A56TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( A56TicketOffice));
         n56TicketOffice = false;
         GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_172_idx;
         chkTicketAntivirus.Name = GXCCtl;
         chkTicketAntivirus.WebTags = "";
         chkTicketAntivirus.Caption = "";
         AssignProp("", false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_172_Refreshing);
         chkTicketAntivirus.CheckedValue = "false";
         A39TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( A39TicketAntivirus));
         n39TicketAntivirus = false;
         GXCCtl = "TICKETAPLICACION_" + sGXsfl_172_idx;
         chkTicketAplicacion.Name = GXCCtl;
         chkTicketAplicacion.WebTags = "";
         chkTicketAplicacion.Caption = "";
         AssignProp("", false, chkTicketAplicacion_Internalname, "TitleCaption", chkTicketAplicacion.Caption, !bGXsfl_172_Refreshing);
         chkTicketAplicacion.CheckedValue = "false";
         A40TicketAplicacion = StringUtil.StrToBool( StringUtil.BoolToStr( A40TicketAplicacion));
         n40TicketAplicacion = false;
         GXCCtl = "TICKETDISENIO_" + sGXsfl_172_idx;
         chkTicketDisenio.Name = GXCCtl;
         chkTicketDisenio.WebTags = "";
         chkTicketDisenio.Caption = "";
         AssignProp("", false, chkTicketDisenio_Internalname, "TitleCaption", chkTicketDisenio.Caption, !bGXsfl_172_Refreshing);
         chkTicketDisenio.CheckedValue = "false";
         A44TicketDisenio = StringUtil.StrToBool( StringUtil.BoolToStr( A44TicketDisenio));
         n44TicketDisenio = false;
         GXCCtl = "TICKETINGENIERIA_" + sGXsfl_172_idx;
         chkTicketIngenieria.Name = GXCCtl;
         chkTicketIngenieria.WebTags = "";
         chkTicketIngenieria.Caption = "";
         AssignProp("", false, chkTicketIngenieria_Internalname, "TitleCaption", chkTicketIngenieria.Caption, !bGXsfl_172_Refreshing);
         chkTicketIngenieria.CheckedValue = "false";
         A51TicketIngenieria = StringUtil.StrToBool( StringUtil.BoolToStr( A51TicketIngenieria));
         n51TicketIngenieria = false;
         GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_172_idx;
         chkTicketDiscoDuroExterno.Name = GXCCtl;
         chkTicketDiscoDuroExterno.WebTags = "";
         chkTicketDiscoDuroExterno.Caption = "";
         AssignProp("", false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_172_Refreshing);
         chkTicketDiscoDuroExterno.CheckedValue = "false";
         A43TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
         n43TicketDiscoDuroExterno = false;
         GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_172_idx;
         chkTicketPerifericos.Name = GXCCtl;
         chkTicketPerifericos.WebTags = "";
         chkTicketPerifericos.Caption = "";
         AssignProp("", false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_172_Refreshing);
         chkTicketPerifericos.CheckedValue = "false";
         A58TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( A58TicketPerifericos));
         n58TicketPerifericos = false;
         GXCCtl = "TICKETUPS_" + sGXsfl_172_idx;
         chkTicketUps.Name = GXCCtl;
         chkTicketUps.WebTags = "";
         chkTicketUps.Caption = "";
         AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_172_Refreshing);
         chkTicketUps.CheckedValue = "false";
         A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
         n87TicketUps = false;
         GXCCtl = "TICKETAPOYOUSUARIO_" + sGXsfl_172_idx;
         chkTicketApoyoUsuario.Name = GXCCtl;
         chkTicketApoyoUsuario.WebTags = "";
         chkTicketApoyoUsuario.Caption = "";
         AssignProp("", false, chkTicketApoyoUsuario_Internalname, "TitleCaption", chkTicketApoyoUsuario.Caption, !bGXsfl_172_Refreshing);
         chkTicketApoyoUsuario.CheckedValue = "false";
         A41TicketApoyoUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( A41TicketApoyoUsuario));
         n41TicketApoyoUsuario = false;
         GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_172_idx;
         chkTicketInstalarDataShow.Name = GXCCtl;
         chkTicketInstalarDataShow.WebTags = "";
         chkTicketInstalarDataShow.Caption = "";
         AssignProp("", false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_172_Refreshing);
         chkTicketInstalarDataShow.CheckedValue = "false";
         A52TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( A52TicketInstalarDataShow));
         n52TicketInstalarDataShow = false;
         GXCCtl = "TICKETOTROS_" + sGXsfl_172_idx;
         chkTicketOtros.Name = GXCCtl;
         chkTicketOtros.WebTags = "";
         chkTicketOtros.Caption = "";
         AssignProp("", false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_172_Refreshing);
         chkTicketOtros.CheckedValue = "false";
         A57TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( A57TicketOtros));
         n57TicketOtros = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblPgmdescriptortextblock_Internalname = "PGMDESCRIPTORTEXTBLOCK";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = "FILTERTOGGLE_COMBINED";
         Filtersummarytagsuc_Internalname = "FILTERSUMMARYTAGSUC";
         divSection4_Internalname = "SECTION4";
         imgFilterclose_combined_Internalname = "FILTERCLOSE_COMBINED";
         lblTextblockticketfecha_Internalname = "TEXTBLOCKTICKETFECHA";
         Ticketfecha_daterangepicker_Internalname = "TICKETFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainerticketfecha_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETFECHA";
         lblTextblocktickethora_Internalname = "TEXTBLOCKTICKETHORA";
         edtavTickethora_from_Internalname = "vTICKETHORA_FROM";
         lblDaterangeseparator_tickethora_Internalname = "DATERANGESEPARATOR_TICKETHORA";
         edtavTickethora_to_Internalname = "vTICKETHORA_TO";
         divDaterangefiltermaintable_tickethora_Internalname = "DATERANGEFILTERMAINTABLE_TICKETHORA";
         divK2btoolstable_attributecontainertickethora_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETHORA";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         edtavEstadoticketticketnombre_Internalname = "vESTADOTICKETTICKETNOMBRE";
         divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOTICKETTICKETNOMBRE";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_ticketid_visible_Internalname = "vATT_TICKETID_VISIBLE";
         divTicketid_gridsettingscontainer_Internalname = "TICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketfecha_visible_Internalname = "vATT_TICKETFECHA_VISIBLE";
         divTicketfecha_gridsettingscontainer_Internalname = "TICKETFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_tickethora_visible_Internalname = "vATT_TICKETHORA_VISIBLE";
         divTickethora_gridsettingscontainer_Internalname = "TICKETHORA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = "vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = "USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = "USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_estadoticketticketnombre_visible_Internalname = "vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE";
         divEstadoticketticketnombre_gridsettingscontainer_Internalname = "ESTADOTICKETTICKETNOMBRE_GRIDSETTINGSCONTAINER";
         divGridsettingstable_content_Internalname = "GRIDSETTINGSTABLE_CONTENT";
         cmbavGridsettingsrowsperpagevariable_Internalname = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         divRowsperpagecontainer_Internalname = "ROWSPERPAGECONTAINER";
         chkavFreezecolumntitles_Internalname = "vFREEZECOLUMNTITLES";
         divFreezegridcolumntitlescontainer_Internalname = "FREEZEGRIDCOLUMNTITLESCONTAINER";
         bttK2bgridsettingssave_Internalname = "K2BGRIDSETTINGSSAVE";
         divCustomizationcollapsiblesection_Internalname = "CUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_Internalname = "GRIDCUSTOMIZATIONCONTAINER";
         divContentinnertable_Internalname = "CONTENTINNERTABLE";
         divK2bgridsettingscontentoutertable_Internalname = "K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = "K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = "IMAGE1";
         bttReport_Internalname = "REPORT";
         bttExport_Internalname = "EXPORT";
         tblK2btabledownloadssectioncontainer_Internalname = "K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = "DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = "DOWNLOADSACTIONSSECTIONCONTAINER";
         bttInsert_Internalname = "INSERT";
         tblK2btableactionsrightcontainer_Internalname = "K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtTicketId_Internalname = "TICKETID";
         edtTicketFecha_Internalname = "TICKETFECHA";
         edtTicketHora_Internalname = "TICKETHORA";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtEstadoTicketTicketNombre_Internalname = "ESTADOTICKETTICKETNOMBRE";
         edtUsuarioId_Internalname = "USUARIOID";
         edtTicketLastId_Internalname = "TICKETLASTID";
         chkTicketLaptop_Internalname = "TICKETLAPTOP";
         chkTicketDesktop_Internalname = "TICKETDESKTOP";
         chkTicketMonitor_Internalname = "TICKETMONITOR";
         chkTicketImpresora_Internalname = "TICKETIMPRESORA";
         chkTicketEscaner_Internalname = "TICKETESCANER";
         chkTicketRouter_Internalname = "TICKETROUTER";
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO";
         chkTicketOffice_Internalname = "TICKETOFFICE";
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS";
         chkTicketAplicacion_Internalname = "TICKETAPLICACION";
         chkTicketDisenio_Internalname = "TICKETDISENIO";
         chkTicketIngenieria_Internalname = "TICKETINGENIERIA";
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO";
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS";
         chkTicketUps_Internalname = "TICKETUPS";
         chkTicketApoyoUsuario_Internalname = "TICKETAPOYOUSUARIO";
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW";
         chkTicketOtros_Internalname = "TICKETOTROS";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtavUpdate_Internalname = "vUPDATE";
         lblNoresultsfoundtextblock_Internalname = "NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = "NORESULTSFOUNDTABLE";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPreviouspagebuttontextblock_Internalname = "PREVIOUSPAGEBUTTONTEXTBLOCK";
         lblFirstpagetextblock_Internalname = "FIRSTPAGETEXTBLOCK";
         lblSpacinglefttextblock_Internalname = "SPACINGLEFTTEXTBLOCK";
         lblPreviouspagetextblock_Internalname = "PREVIOUSPAGETEXTBLOCK";
         lblCurrentpagetextblock_Internalname = "CURRENTPAGETEXTBLOCK";
         lblNextpagetextblock_Internalname = "NEXTPAGETEXTBLOCK";
         lblSpacingrighttextblock_Internalname = "SPACINGRIGHTTEXTBLOCK";
         lblLastpagetextblock_Internalname = "LASTPAGETEXTBLOCK";
         lblNextpagebuttontextblock_Internalname = "NEXTPAGEBUTTONTEXTBLOCK";
         divK2btoolspagingcontainertable_Internalname = "K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = "SECTION8";
         divTable4_Internalname = "TABLE4";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         K2borderbyusercontrol_Internalname = "K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsgrid_Internalname = "K2BTOOLSABSTRACTHIDDENITEMSGRID";
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
         chkavFreezecolumntitles.Caption = "Inmovilizar títulos";
         chkavAtt_estadoticketticketnombre_visible.Caption = "Ticket";
         chkavAtt_usuariorequerimiento_visible.Caption = "Requerimiento";
         chkavAtt_usuarionombre_visible.Caption = "Usuario";
         chkavAtt_tickethora_visible.Caption = "Hora:";
         chkavAtt_ticketfecha_visible.Caption = "Fecha:";
         chkavAtt_ticketid_visible.Caption = "RST No.";
         edtTicketResponsableId_Jsonclick = "";
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
         edtUsuarioId_Jsonclick = "";
         edtEstadoTicketTicketNombre_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
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
         chkavAtt_estadoticketticketnombre_visible.Enabled = 1;
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
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
         edtavUpdate_Tooltiptext = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtEstadoTicketTicketNombre_Link = "";
         edtUsuarioNombre_Link = "";
         edtTicketFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavUpdate_Visible = -1;
         edtEstadoTicketTicketNombre_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtTicketHora_Visible = -1;
         edtTicketFecha_Visible = -1;
         edtTicketId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavEstadoticketticketnombre_Jsonclick = "";
         edtavEstadoticketticketnombre_Enabled = 1;
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Ticketes";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132R2',iparms:[{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282R1',iparms:[{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242R2',iparms:[{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV62UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV56FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252R2',iparms:[{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A187EstadoTicketTicketId',fld:'ESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtEstadoTicketTicketNombre_Link',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Link'},{av:'edtTicketFecha_Link',ctrl:'TICKETFECHA',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV57DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV62UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262R1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV41RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV40GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV41RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV71AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV73Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV65TicketFecha_IsAuthorized',fld:'vTICKETFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV46ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketFecha_Visible',ctrl:'TICKETFECHA',prop:'Visible'},{av:'edtTicketHora_Visible',ctrl:'TICKETHORA',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtEstadoTicketTicketNombre_Visible',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192R2',iparms:[{av:'AV48TicketFecha_From',fld:'vTICKETFECHA_FROM',pic:''},{av:'AV49TicketFecha_To',fld:'vTICKETFECHA_TO',pic:''},{av:'AV51TicketHora_From',fld:'vTICKETHORA_FROM',pic:'99:99'},{av:'AV52TicketHora_To',fld:'vTICKETHORA_TO',pic:'99:99'},{av:'AV53UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV74EstadoTicketTicketNombre',fld:'vESTADOTICKETTICKETNOMBRE',pic:''},{av:'AV58K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV59OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV78Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202R2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212R2',iparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272R1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Update',iparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV15Att_TicketFecha_Visible',fld:'vATT_TICKETFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketHora_Visible',fld:'vATT_TICKETHORA_VISIBLE',pic:''},{av:'AV17Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV75Att_EstadoTicketTicketNombre_Visible',fld:'vATT_ESTADOTICKETTICKETNOMBRE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV58K2BToolsGenericSearchField = "";
         AV48TicketFecha_From = DateTime.MinValue;
         AV51TicketHora_From = (DateTime)(DateTime.MinValue);
         AV52TicketHora_To = (DateTime)(DateTime.MinValue);
         AV53UsuarioNombre = "";
         AV74EstadoTicketTicketNombre = "";
         AV46ClassCollection = new GxSimpleCollection<string>();
         AV49TicketFecha_To = DateTime.MinValue;
         AV81Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV71AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV78Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV56FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV57DeletedTag = "";
         AV60GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         Filtersummarytagsuc_Emptystatemessage = "";
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
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
         A188EstadoTicketTicketNombre = "";
         AV73Update = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV83Update_GXI = "";
         scmdbuf = "";
         lV53UsuarioNombre = "";
         lV74EstadoTicketTicketNombre = "";
         lV58K2BToolsGenericSearchField = "";
         H002R2_A187EstadoTicketTicketId = new short[1] ;
         H002R2_A57TicketOtros = new bool[] {false} ;
         H002R2_n57TicketOtros = new bool[] {false} ;
         H002R2_A52TicketInstalarDataShow = new bool[] {false} ;
         H002R2_n52TicketInstalarDataShow = new bool[] {false} ;
         H002R2_A41TicketApoyoUsuario = new bool[] {false} ;
         H002R2_n41TicketApoyoUsuario = new bool[] {false} ;
         H002R2_A87TicketUps = new bool[] {false} ;
         H002R2_n87TicketUps = new bool[] {false} ;
         H002R2_A58TicketPerifericos = new bool[] {false} ;
         H002R2_n58TicketPerifericos = new bool[] {false} ;
         H002R2_A43TicketDiscoDuroExterno = new bool[] {false} ;
         H002R2_n43TicketDiscoDuroExterno = new bool[] {false} ;
         H002R2_A51TicketIngenieria = new bool[] {false} ;
         H002R2_n51TicketIngenieria = new bool[] {false} ;
         H002R2_A44TicketDisenio = new bool[] {false} ;
         H002R2_n44TicketDisenio = new bool[] {false} ;
         H002R2_A40TicketAplicacion = new bool[] {false} ;
         H002R2_n40TicketAplicacion = new bool[] {false} ;
         H002R2_A39TicketAntivirus = new bool[] {false} ;
         H002R2_n39TicketAntivirus = new bool[] {false} ;
         H002R2_A56TicketOffice = new bool[] {false} ;
         H002R2_n56TicketOffice = new bool[] {false} ;
         H002R2_A60TicketSistemaOperativo = new bool[] {false} ;
         H002R2_n60TicketSistemaOperativo = new bool[] {false} ;
         H002R2_A59TicketRouter = new bool[] {false} ;
         H002R2_n59TicketRouter = new bool[] {false} ;
         H002R2_A45TicketEscaner = new bool[] {false} ;
         H002R2_n45TicketEscaner = new bool[] {false} ;
         H002R2_A50TicketImpresora = new bool[] {false} ;
         H002R2_n50TicketImpresora = new bool[] {false} ;
         H002R2_A55TicketMonitor = new bool[] {false} ;
         H002R2_n55TicketMonitor = new bool[] {false} ;
         H002R2_A42TicketDesktop = new bool[] {false} ;
         H002R2_n42TicketDesktop = new bool[] {false} ;
         H002R2_A53TicketLaptop = new bool[] {false} ;
         H002R2_n53TicketLaptop = new bool[] {false} ;
         H002R2_A54TicketLastId = new long[1] ;
         H002R2_A15UsuarioId = new long[1] ;
         H002R2_A188EstadoTicketTicketNombre = new string[] {""} ;
         H002R2_A94UsuarioRequerimiento = new string[] {""} ;
         H002R2_A93UsuarioNombre = new string[] {""} ;
         H002R2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H002R2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H002R2_A14TicketId = new long[1] ;
         H002R3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV47TicketFecha = DateTime.MinValue;
         AV50TicketHora = (DateTime)(DateTime.MinValue);
         AV61GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV63Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV64Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV70ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV72ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV43GridStateKey = "";
         AV44GridState = new SdtK2BGridState(context);
         AV45GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV68TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV54K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV55K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV76OutFile = "";
         AV77Guid = (Guid)(Guid.Empty);
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
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwticket__default(),
            new Object[][] {
                new Object[] {
               H002R2_A187EstadoTicketTicketId, H002R2_A57TicketOtros, H002R2_n57TicketOtros, H002R2_A52TicketInstalarDataShow, H002R2_n52TicketInstalarDataShow, H002R2_A41TicketApoyoUsuario, H002R2_n41TicketApoyoUsuario, H002R2_A87TicketUps, H002R2_n87TicketUps, H002R2_A58TicketPerifericos,
               H002R2_n58TicketPerifericos, H002R2_A43TicketDiscoDuroExterno, H002R2_n43TicketDiscoDuroExterno, H002R2_A51TicketIngenieria, H002R2_n51TicketIngenieria, H002R2_A44TicketDisenio, H002R2_n44TicketDisenio, H002R2_A40TicketAplicacion, H002R2_n40TicketAplicacion, H002R2_A39TicketAntivirus,
               H002R2_n39TicketAntivirus, H002R2_A56TicketOffice, H002R2_n56TicketOffice, H002R2_A60TicketSistemaOperativo, H002R2_n60TicketSistemaOperativo, H002R2_A59TicketRouter, H002R2_n59TicketRouter, H002R2_A45TicketEscaner, H002R2_n45TicketEscaner, H002R2_A50TicketImpresora,
               H002R2_n50TicketImpresora, H002R2_A55TicketMonitor, H002R2_n55TicketMonitor, H002R2_A42TicketDesktop, H002R2_n42TicketDesktop, H002R2_A53TicketLaptop, H002R2_n53TicketLaptop, H002R2_A54TicketLastId, H002R2_A15UsuarioId, H002R2_A188EstadoTicketTicketNombre,
               H002R2_A94UsuarioRequerimiento, H002R2_A93UsuarioNombre, H002R2_A48TicketHora, H002R2_A46TicketFecha, H002R2_A14TicketId
               }
               , new Object[] {
               H002R3_AGRID_nRecordCount
               }
            }
         );
         AV81Pgmname = "WWTicket";
         /* GeneXus formulas. */
         AV81Pgmname = "WWTicket";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV59OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV62UC_OrderedBy ;
      private short A187EstadoTicketTicketId ;
      private short AV41RowsPerPageVariable ;
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
      private short AV40GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_172 ;
      private int nGXsfl_172_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavTickethora_from_Enabled ;
      private int edtavTickethora_to_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavEstadoticketticketnombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTicketId_Visible ;
      private int edtTicketFecha_Visible ;
      private int edtTicketHora_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
      private int edtEstadoTicketTicketNombre_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavUpdate_Enabled ;
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
      private int AV82GXV1 ;
      private int AV84GXV2 ;
      private int AV9K2BMaxPages ;
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
      private long A16TicketResponsableId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_172_idx="0001" ;
      private string AV58K2BToolsGenericSearchField ;
      private string AV81Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV57DeletedTag ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblPgmdescriptortextblock_Internalname ;
      private string lblPgmdescriptortextblock_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable7_Internalname ;
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
      private string divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname ;
      private string edtavEstadoticketticketnombre_Internalname ;
      private string edtavEstadoticketticketnombre_Jsonclick ;
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
      private string edtEstadoTicketTicketNombre_Link ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Tooltiptext ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTicketId_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtEstadoTicketTicketNombre_Internalname ;
      private string edtUsuarioId_Internalname ;
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
      private string edtTicketResponsableId_Internalname ;
      private string edtavUpdate_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV58K2BToolsGenericSearchField ;
      private string chkavAtt_ticketid_visible_Internalname ;
      private string chkavAtt_ticketfecha_visible_Internalname ;
      private string chkavAtt_tickethora_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
      private string chkavAtt_estadoticketticketnombre_visible_Internalname ;
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
      private string tblTable6_Internalname ;
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
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
      private string divEstadoticketticketnombre_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_172_fel_idx="0001" ;
      private string ROClassString ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketHora_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtEstadoTicketTicketNombre_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtTicketLastId_Jsonclick ;
      private string GXCCtl ;
      private string edtTicketResponsableId_Jsonclick ;
      private DateTime AV51TicketHora_From ;
      private DateTime AV52TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime AV50TicketHora ;
      private DateTime GXt_dtime3 ;
      private DateTime AV48TicketFecha_From ;
      private DateTime AV49TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime AV47TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV65TicketFecha_IsAuthorized ;
      private bool AV14Att_TicketId_Visible ;
      private bool AV15Att_TicketFecha_Visible ;
      private bool AV16Att_TicketHora_Visible ;
      private bool AV17Att_UsuarioNombre_Visible ;
      private bool AV18Att_UsuarioRequerimiento_Visible ;
      private bool AV75Att_EstadoTicketTicketNombre_Visible ;
      private bool AV11FreezeColumnTitles ;
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
      private bool bGXsfl_172_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV42RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV73Update_IsBlob ;
      private string AV53UsuarioNombre ;
      private string AV74EstadoTicketTicketNombre ;
      private string AV78Uri ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A188EstadoTicketTicketNombre ;
      private string AV83Update_GXI ;
      private string lV53UsuarioNombre ;
      private string lV74EstadoTicketTicketNombre ;
      private string AV43GridStateKey ;
      private string AV76OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV73Update ;
      private Guid AV77Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucTicketfecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_ticketid_visible ;
      private GXCheckbox chkavAtt_ticketfecha_visible ;
      private GXCheckbox chkavAtt_tickethora_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCheckbox chkavAtt_estadoticketticketnombre_visible ;
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
      private short[] H002R2_A187EstadoTicketTicketId ;
      private bool[] H002R2_A57TicketOtros ;
      private bool[] H002R2_n57TicketOtros ;
      private bool[] H002R2_A52TicketInstalarDataShow ;
      private bool[] H002R2_n52TicketInstalarDataShow ;
      private bool[] H002R2_A41TicketApoyoUsuario ;
      private bool[] H002R2_n41TicketApoyoUsuario ;
      private bool[] H002R2_A87TicketUps ;
      private bool[] H002R2_n87TicketUps ;
      private bool[] H002R2_A58TicketPerifericos ;
      private bool[] H002R2_n58TicketPerifericos ;
      private bool[] H002R2_A43TicketDiscoDuroExterno ;
      private bool[] H002R2_n43TicketDiscoDuroExterno ;
      private bool[] H002R2_A51TicketIngenieria ;
      private bool[] H002R2_n51TicketIngenieria ;
      private bool[] H002R2_A44TicketDisenio ;
      private bool[] H002R2_n44TicketDisenio ;
      private bool[] H002R2_A40TicketAplicacion ;
      private bool[] H002R2_n40TicketAplicacion ;
      private bool[] H002R2_A39TicketAntivirus ;
      private bool[] H002R2_n39TicketAntivirus ;
      private bool[] H002R2_A56TicketOffice ;
      private bool[] H002R2_n56TicketOffice ;
      private bool[] H002R2_A60TicketSistemaOperativo ;
      private bool[] H002R2_n60TicketSistemaOperativo ;
      private bool[] H002R2_A59TicketRouter ;
      private bool[] H002R2_n59TicketRouter ;
      private bool[] H002R2_A45TicketEscaner ;
      private bool[] H002R2_n45TicketEscaner ;
      private bool[] H002R2_A50TicketImpresora ;
      private bool[] H002R2_n50TicketImpresora ;
      private bool[] H002R2_A55TicketMonitor ;
      private bool[] H002R2_n55TicketMonitor ;
      private bool[] H002R2_A42TicketDesktop ;
      private bool[] H002R2_n42TicketDesktop ;
      private bool[] H002R2_A53TicketLaptop ;
      private bool[] H002R2_n53TicketLaptop ;
      private long[] H002R2_A54TicketLastId ;
      private long[] H002R2_A15UsuarioId ;
      private string[] H002R2_A188EstadoTicketTicketNombre ;
      private string[] H002R2_A94UsuarioRequerimiento ;
      private string[] H002R2_A93UsuarioNombre ;
      private DateTime[] H002R2_A48TicketHora ;
      private DateTime[] H002R2_A46TicketFecha ;
      private long[] H002R2_A14TicketId ;
      private long[] H002R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV46ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV54K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV56FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV60GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV71AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV70ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV44GridState ;
      private SdtK2BGridState_FilterValue AV45GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV55K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV61GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV64Message ;
      private SdtK2BTrnContext AV68TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV72ActivityListItem ;
   }

   public class wwticket__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002R2( IGxContext context ,
                                             DateTime AV49TicketFecha_To ,
                                             DateTime AV48TicketFecha_From ,
                                             DateTime AV52TicketHora_To ,
                                             DateTime AV51TicketHora_From ,
                                             string AV53UsuarioNombre ,
                                             string AV74EstadoTicketTicketNombre ,
                                             string AV58K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             short AV59OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[EstadoTicketTicketId] AS EstadoTicketTicketId, T1.[TicketOtros], T1.[TicketInstalarDataShow], T1.[TicketApoyoUsuario], T1.[TicketUps], T1.[TicketPerifericos], T1.[TicketDiscoDuroExterno], T1.[TicketIngenieria], T1.[TicketDisenio], T1.[TicketAplicacion], T1.[TicketAntivirus], T1.[TicketOffice], T1.[TicketSistemaOperativo], T1.[TicketRouter], T1.[TicketEscaner], T1.[TicketImpresora], T1.[TicketMonitor], T1.[TicketDesktop], T1.[TicketLaptop], T1.[TicketLastId], T1.[UsuarioId], T2.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T3.[UsuarioRequerimiento], T3.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha], T1.[TicketId]";
         sFromString = " FROM (([Ticket] T1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = T1.[EstadoTicketTicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T1.[UsuarioId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV49TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV49TicketFecha_To)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV48TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV48TicketFecha_From)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV52TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV52TicketHora_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV51TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV51TicketHora_From)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioNombre] like @lV53UsuarioNombre)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoTicketNombre] like @lV74EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV58K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV58K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV58K2BToolsGenericSearchField + '%' or T2.[EstadoTicketNombre] like '%' + @lV58K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
         }
         if ( AV59OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[TicketId]";
         }
         else if ( AV59OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV59OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV59OrderedBy == 3 )
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

      protected Object[] conditional_H002R3( IGxContext context ,
                                             DateTime AV49TicketFecha_To ,
                                             DateTime AV48TicketFecha_From ,
                                             DateTime AV52TicketHora_To ,
                                             DateTime AV51TicketHora_From ,
                                             string AV53UsuarioNombre ,
                                             string AV74EstadoTicketTicketNombre ,
                                             string AV58K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             short AV59OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([Ticket] T1 INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = T1.[EstadoTicketTicketId]) INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV49TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV49TicketFecha_To)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV48TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV48TicketFecha_From)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV52TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV52TicketHora_To)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV51TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV51TicketHora_From)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV53UsuarioNombre)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoTicketNombre] like @lV74EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV58K2BToolsGenericSearchField + '%' or T2.[UsuarioNombre] like '%' + @lV58K2BToolsGenericSearchField + '%' or T2.[UsuarioRequerimiento] like '%' + @lV58K2BToolsGenericSearchField + '%' or T3.[EstadoTicketNombre] like '%' + @lV58K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV59OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV59OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV59OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV59OrderedBy == 3 )
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
                     return conditional_H002R2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
               case 1 :
                     return conditional_H002R3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          new ParDef("@AV49TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV48TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV52TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV51TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV53UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV74EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002R3;
          prmH002R3 = new Object[] {
          new ParDef("@AV49TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV48TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV52TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV51TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV53UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV74EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV58K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((bool[]) buf[27])[0] = rslt.getBool(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((bool[]) buf[29])[0] = rslt.getBool(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((long[]) buf[37])[0] = rslt.getLong(20);
                ((long[]) buf[38])[0] = rslt.getLong(21);
                ((string[]) buf[39])[0] = rslt.getVarchar(22);
                ((string[]) buf[40])[0] = rslt.getVarchar(23);
                ((string[]) buf[41])[0] = rslt.getVarchar(24);
                ((DateTime[]) buf[42])[0] = rslt.getGXDateTime(25);
                ((DateTime[]) buf[43])[0] = rslt.getGXDate(26);
                ((long[]) buf[44])[0] = rslt.getLong(27);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
