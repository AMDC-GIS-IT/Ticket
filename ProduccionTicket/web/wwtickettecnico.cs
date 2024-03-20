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
   public class wwtickettecnico : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwtickettecnico( )
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

      public wwtickettecnico( IGxContext context )
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
         chkavAtt_tickettecnicoid_visible = new GXCheckbox();
         chkavAtt_tickettecnicofecha_visible = new GXCheckbox();
         chkavAtt_tickettecnicohora_visible = new GXCheckbox();
         chkavAtt_ticketid_visible = new GXCheckbox();
         chkavAtt_ticketresponsableid_visible = new GXCheckbox();
         chkavAtt_responsablenombre_visible = new GXCheckbox();
         chkavAtt_usuarioid_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         chkavAtt_usuariodepartamento_visible = new GXCheckbox();
         chkavAtt_tickettecnicoinventarioserie_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
         chkTicketTecnicoInstalacion = new GXCheckbox();
         chkTicketTecnicoConfiguracion = new GXCheckbox();
         chkTicketTecnicoInternetRouter = new GXCheckbox();
         chkTicketTecnicoFormateo = new GXCheckbox();
         chkTicketTecnicoReparacion = new GXCheckbox();
         chkTicketTecnicoLimpieza = new GXCheckbox();
         chkTicketTecnicoPuntoRed = new GXCheckbox();
         chkTicketTecnicoCambiosHardware = new GXCheckbox();
         chkTicketTecnicoCopiasRespaldo = new GXCheckbox();
         chkTicketTecnicoRam = new GXCheckbox();
         chkTicketTecnicoDiscoDuro = new GXCheckbox();
         chkTicketTecnicoProcesador = new GXCheckbox();
         chkTicketTecnicoMaletin = new GXCheckbox();
         chkTicketTecnicoTonerCinta = new GXCheckbox();
         chkTicketTecnicoTarjetaVideoExtra = new GXCheckbox();
         chkTicketTecnicoCargadorLaptop = new GXCheckbox();
         chkTicketTecnicoCDsDVDs = new GXCheckbox();
         chkTicketTecnicoCableEspecial = new GXCheckbox();
         chkTicketTecnicoOtrosTaller = new GXCheckbox();
         chkTicketTecnicoCerrado = new GXCheckbox();
         chkTicketTecnicoPendiente = new GXCheckbox();
         chkTicketTecnicoPasaTaller = new GXCheckbox();
         chkTicketTecnicoObservacion = new GXCheckbox();
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
               nRC_GXsfl_190 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_190"), "."));
               nGXsfl_190_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_190_idx"), "."));
               sGXsfl_190_idx = GetPar( "sGXsfl_190_idx");
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
               AV66K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV57TicketTecnicoFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketTecnicoFecha_From"));
               AV60TicketTecnicoHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketTecnicoHora_From")));
               AV61TicketTecnicoHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketTecnicoHora_To")));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV55ClassCollection);
               AV67OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV58TicketTecnicoFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketTecnicoFecha_To"));
               AV86Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV79AutoLinksActivityList);
               AV73TicketTecnicoFecha_IsAuthorized = StringUtil.StrToBool( GetPar( "TicketTecnicoFecha_IsAuthorized"));
               AV14Att_TicketTecnicoId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketTecnicoId_Visible"));
               AV15Att_TicketTecnicoFecha_Visible = StringUtil.StrToBool( GetPar( "Att_TicketTecnicoFecha_Visible"));
               AV16Att_TicketTecnicoHora_Visible = StringUtil.StrToBool( GetPar( "Att_TicketTecnicoHora_Visible"));
               AV17Att_TicketId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketId_Visible"));
               AV18Att_TicketResponsableId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketResponsableId_Visible"));
               AV20Att_ResponsableNombre_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableNombre_Visible"));
               AV21Att_UsuarioId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioId_Visible"));
               AV22Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
               AV23Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
               AV24Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioDepartamento_Visible"));
               AV25Att_TicketTecnicoInventarioSerie_Visible = StringUtil.StrToBool( GetPar( "Att_TicketTecnicoInventarioSerie_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV83Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
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
            return "tickettecnico_Execute" ;
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
         PA2V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188362459", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwtickettecnico.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV66K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETTECNICOFECHA_FROM", context.localUtil.Format(AV57TicketTecnicoFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETTECNICOHORA_FROM", context.localUtil.TToC( AV60TicketTecnicoHora_From, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vTICKETTECNICOHORA_TO", context.localUtil.TToC( AV61TicketTecnicoHora_To, 10, 8, 0, 3, "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_190", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_190), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV64FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV64FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV65DeletedTag));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICOFECHA_TO", context.localUtil.DToC( AV58TicketTecnicoFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV68GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV68GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV86Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV55ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV55ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUTOLINKSACTIVITYLIST", AV79AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUTOLINKSACTIVITYLIST", AV79AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vTICKETTECNICOFECHA_ISAUTHORIZED", AV73TicketTecnicoFecha_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV83Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICOFECHA_FROM", context.localUtil.DToC( AV57TicketTecnicoFecha_From, 0, "/"));
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
            WE2V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2V2( ) ;
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
         return formatLink("wwtickettecnico.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWTicketTecnico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticket tecnicos" ;
      }

      protected void WB2V0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Ticket tecnicos", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_190_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV66K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV66K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWTicketTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicketTecnico.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV64FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV65DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicketTecnico.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicofecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktickettecnicofecha_Internalname, "Fecha", "", "", lblTextblocktickettecnicofecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* User Defined Control */
            ucTickettecnicofecha_daterangepicker.SetProperty("ValueFrom", AV57TicketTecnicoFecha_From);
            ucTickettecnicofecha_daterangepicker.SetProperty("ValueTo", AV58TicketTecnicoFecha_To);
            ucTickettecnicofecha_daterangepicker.Render(context, "k2bdaterangepicker", Tickettecnicofecha_daterangepicker_Internalname, "TICKETTECNICOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicohora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktickettecnicohora_Internalname, "Hora", "", "", lblTextblocktickettecnicohora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDaterangefiltermaintable_tickettecnicohora_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickettecnicohora_from_Internalname, "Desde", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_190_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickettecnicohora_from_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickettecnicohora_from_Internalname, context.localUtil.TToC( AV60TicketTecnicoHora_From, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV60TicketTecnicoHora_From, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickettecnicohora_from_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickettecnicohora_from_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWTicketTecnico.htm");
            GxWebStd.gx_bitmap( context, edtavTickettecnicohora_from_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickettecnicohora_from_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWTicketTecnico.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDaterangeseparator_tickettecnicohora_Internalname, "-", "", "", lblDaterangeseparator_tickettecnicohora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTickettecnicohora_to_Internalname, "Hasta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_190_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTickettecnicohora_to_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTickettecnicohora_to_Internalname, context.localUtil.TToC( AV61TicketTecnicoHora_To, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV61TicketTecnicoHora_To, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickettecnicohora_to_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTickettecnicohora_to_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWTicketTecnico.htm");
            GxWebStd.gx_bitmap( context, edtavTickettecnicohora_to_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTickettecnicohora_to_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWTicketTecnico.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            wb_table1_56_2V2( true) ;
         }
         else
         {
            wb_table1_56_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_56_2V2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"190\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(86), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketTecnicoId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Ticket Tecnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketTecnicoFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketTecnicoHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketResponsableId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Técnico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Técnico") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Departamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketTecnicoInventarioSerie_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Serie") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Instalación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Configuración") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Internet/Router") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Formateo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Reparación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Limpieza/Mantenimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Nuevo Punto de Red") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cambios de Hardware") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Copias de Respaldo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "RAM") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Disco Duro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Procesador") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Maletin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Toner/Cinta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tarjeta de Video Extra") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cargador para Laptop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "CDs/DVDs") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cable Especial") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Otros") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cerrado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Pendiente") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Pasa al Taller") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Observación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Observación") ;
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
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTicketTecnicoFecha_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoFecha_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoHora_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketResponsableId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A30ResponsableNombre);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableNombre_Visible), 5, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioDepartamento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A74TicketTecnicoInventarioSerie);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoInventarioSerie_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A70TicketTecnicoFormateo));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A84TicketTecnicoReparacion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A75TicketTecnicoLimpieza));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A82TicketTecnicoPuntoRed));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A83TicketTecnicoRam));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A81TicketTecnicoProcesador));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A76TicketTecnicoMaletin));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A86TicketTecnicoTonerCinta));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A61TicketTecnicoCableEspecial));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A65TicketTecnicoCerrado));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A80TicketTecnicoPendiente));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A79TicketTecnicoPasaTaller));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A77TicketTecnicoObservacion));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A97TicketTecnicoDetalle);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV74Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV75Delete));
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
         if ( wbEnd == 190 )
         {
            wbEnd = 0;
            nRC_GXsfl_190 = (int)(nGXsfl_190_idx-1);
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
            wb_table2_231_2V2( true) ;
         }
         else
         {
            wb_table2_231_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_231_2V2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV68GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV70UC_OrderedBy);
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
         if ( wbEnd == 190 )
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

      protected void START2V2( )
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
            Form.Meta.addItem("description", "Ticket tecnicos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2V0( ) ;
      }

      protected void WS2V2( )
      {
         START2V2( ) ;
         EVT2V2( ) ;
      }

      protected void EVT2V2( )
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
                              E112V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E132V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E142V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E152V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E162V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E172V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E182V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E212V2 ();
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
                              nGXsfl_190_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
                              SubsflControlProps_1902( ) ;
                              A18TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtTicketTecnicoId_Internalname), ".", ","));
                              A69TicketTecnicoFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketTecnicoFecha_Internalname), 0));
                              A71TicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketTecnicoHora_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                              A6ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ".", ","));
                              A30ResponsableNombre = cgiGet( edtResponsableNombre_Internalname);
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A74TicketTecnicoInventarioSerie = cgiGet( edtTicketTecnicoInventarioSerie_Internalname);
                              A72TicketTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInstalacion_Internalname));
                              A66TicketTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoConfiguracion_Internalname));
                              A73TicketTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInternetRouter_Internalname));
                              A70TicketTecnicoFormateo = StringUtil.StrToBool( cgiGet( chkTicketTecnicoFormateo_Internalname));
                              A84TicketTecnicoReparacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoReparacion_Internalname));
                              A75TicketTecnicoLimpieza = StringUtil.StrToBool( cgiGet( chkTicketTecnicoLimpieza_Internalname));
                              A82TicketTecnicoPuntoRed = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPuntoRed_Internalname));
                              A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCambiosHardware_Internalname));
                              A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCopiasRespaldo_Internalname));
                              A83TicketTecnicoRam = StringUtil.StrToBool( cgiGet( chkTicketTecnicoRam_Internalname));
                              A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( cgiGet( chkTicketTecnicoDiscoDuro_Internalname));
                              A81TicketTecnicoProcesador = StringUtil.StrToBool( cgiGet( chkTicketTecnicoProcesador_Internalname));
                              A76TicketTecnicoMaletin = StringUtil.StrToBool( cgiGet( chkTicketTecnicoMaletin_Internalname));
                              A86TicketTecnicoTonerCinta = StringUtil.StrToBool( cgiGet( chkTicketTecnicoTonerCinta_Internalname));
                              A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( cgiGet( chkTicketTecnicoTarjetaVideoExtra_Internalname));
                              A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCargadorLaptop_Internalname));
                              A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCDsDVDs_Internalname));
                              A61TicketTecnicoCableEspecial = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCableEspecial_Internalname));
                              A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( cgiGet( chkTicketTecnicoOtrosTaller_Internalname));
                              A65TicketTecnicoCerrado = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCerrado_Internalname));
                              A80TicketTecnicoPendiente = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPendiente_Internalname));
                              A79TicketTecnicoPasaTaller = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPasaTaller_Internalname));
                              A77TicketTecnicoObservacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoObservacion_Internalname));
                              n77TicketTecnicoObservacion = false;
                              A97TicketTecnicoDetalle = cgiGet( edtTicketTecnicoDetalle_Internalname);
                              AV74Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.convertURL( context.PathToRelativeUrl( AV74Update))), !bGXsfl_190_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV74Update), true);
                              AV75Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV75Delete))), !bGXsfl_190_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV75Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E222V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E232V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E252V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV66K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tickettecnicofecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETTECNICOFECHA_FROM"), 0) != AV57TicketTecnicoFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tickettecnicohora_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETTECNICOHORA_FROM"), 0) != AV60TicketTecnicoHora_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tickettecnicohora_to Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETTECNICOHORA_TO"), 0) != AV61TicketTecnicoHora_To )
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

      protected void WE2V2( )
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

      protected void PA2V2( )
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
         SubsflControlProps_1902( ) ;
         while ( nGXsfl_190_idx <= nRC_GXsfl_190 )
         {
            sendrow_1902( ) ;
            nGXsfl_190_idx = ((subGrid_Islastpage==1)&&(nGXsfl_190_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_190_idx+1);
            sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
            SubsflControlProps_1902( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV66K2BToolsGenericSearchField ,
                                       DateTime AV57TicketTecnicoFecha_From ,
                                       DateTime AV60TicketTecnicoHora_From ,
                                       DateTime AV61TicketTecnicoHora_To ,
                                       GxSimpleCollection<string> AV55ClassCollection ,
                                       short AV67OrderedBy ,
                                       DateTime AV58TicketTecnicoFecha_To ,
                                       string AV86Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV79AutoLinksActivityList ,
                                       bool AV73TicketTecnicoFecha_IsAuthorized ,
                                       bool AV14Att_TicketTecnicoId_Visible ,
                                       bool AV15Att_TicketTecnicoFecha_Visible ,
                                       bool AV16Att_TicketTecnicoHora_Visible ,
                                       bool AV17Att_TicketId_Visible ,
                                       bool AV18Att_TicketResponsableId_Visible ,
                                       bool AV20Att_ResponsableNombre_Visible ,
                                       bool AV21Att_UsuarioId_Visible ,
                                       bool AV22Att_UsuarioNombre_Visible ,
                                       bool AV23Att_UsuarioRequerimiento_Visible ,
                                       bool AV24Att_UsuarioDepartamento_Visible ,
                                       bool AV25Att_TicketTecnicoInventarioSerie_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV83Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232V2 ();
         GRID_nCurrentRecord = 0;
         RF2V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")));
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
         AV14Att_TicketTecnicoId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TicketTecnicoId_Visible));
         AssignAttri("", false, "AV14Att_TicketTecnicoId_Visible", AV14Att_TicketTecnicoId_Visible);
         AV15Att_TicketTecnicoFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TicketTecnicoFecha_Visible));
         AssignAttri("", false, "AV15Att_TicketTecnicoFecha_Visible", AV15Att_TicketTecnicoFecha_Visible);
         AV16Att_TicketTecnicoHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TicketTecnicoHora_Visible));
         AssignAttri("", false, "AV16Att_TicketTecnicoHora_Visible", AV16Att_TicketTecnicoHora_Visible);
         AV17Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TicketId_Visible));
         AssignAttri("", false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
         AV18Att_TicketResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_TicketResponsableId_Visible));
         AssignAttri("", false, "AV18Att_TicketResponsableId_Visible", AV18Att_TicketResponsableId_Visible);
         AV20Att_ResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ResponsableNombre_Visible));
         AssignAttri("", false, "AV20Att_ResponsableNombre_Visible", AV20Att_ResponsableNombre_Visible);
         AV21Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_UsuarioId_Visible));
         AssignAttri("", false, "AV21Att_UsuarioId_Visible", AV21Att_UsuarioId_Visible);
         AV22Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV22Att_UsuarioNombre_Visible", AV22Att_UsuarioNombre_Visible);
         AV23Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV23Att_UsuarioRequerimiento_Visible", AV23Att_UsuarioRequerimiento_Visible);
         AV24Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_UsuarioDepartamento_Visible));
         AssignAttri("", false, "AV24Att_UsuarioDepartamento_Visible", AV24Att_UsuarioDepartamento_Visible);
         AV25Att_TicketTecnicoInventarioSerie_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_TicketTecnicoInventarioSerie_Visible));
         AssignAttri("", false, "AV25Att_TicketTecnicoInventarioSerie_Visible", AV25Att_TicketTecnicoInventarioSerie_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV49GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV49GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232V2 ();
         RF2V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV86Pgmname = "WWTicketTecnico";
         context.Gx_err = 0;
      }

      protected void RF2V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 190;
         E242V2 ();
         nGXsfl_190_idx = 1;
         sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
         SubsflControlProps_1902( ) ;
         bGXsfl_190_Refreshing = true;
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
            SubsflControlProps_1902( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV58TicketTecnicoFecha_To ,
                                                 AV57TicketTecnicoFecha_From ,
                                                 AV61TicketTecnicoHora_To ,
                                                 AV60TicketTecnicoHora_From ,
                                                 AV66K2BToolsGenericSearchField ,
                                                 A69TicketTecnicoFecha ,
                                                 A71TicketTecnicoHora ,
                                                 A18TicketTecnicoId ,
                                                 A14TicketId ,
                                                 A16TicketResponsableId ,
                                                 A30ResponsableNombre ,
                                                 A15UsuarioId ,
                                                 A93UsuarioNombre ,
                                                 A94UsuarioRequerimiento ,
                                                 A88UsuarioDepartamento ,
                                                 A74TicketTecnicoInventarioSerie ,
                                                 AV67OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.SHORT
                                                 }
            });
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002V2 */
            pr_default.execute(0, new Object[] {AV58TicketTecnicoFecha_To, AV57TicketTecnicoFecha_From, AV61TicketTecnicoHora_To, AV60TicketTecnicoHora_From, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_190_idx = 1;
            sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
            SubsflControlProps_1902( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A97TicketTecnicoDetalle = H002V2_A97TicketTecnicoDetalle[0];
               A77TicketTecnicoObservacion = H002V2_A77TicketTecnicoObservacion[0];
               n77TicketTecnicoObservacion = H002V2_n77TicketTecnicoObservacion[0];
               A79TicketTecnicoPasaTaller = H002V2_A79TicketTecnicoPasaTaller[0];
               A80TicketTecnicoPendiente = H002V2_A80TicketTecnicoPendiente[0];
               A65TicketTecnicoCerrado = H002V2_A65TicketTecnicoCerrado[0];
               A78TicketTecnicoOtrosTaller = H002V2_A78TicketTecnicoOtrosTaller[0];
               A61TicketTecnicoCableEspecial = H002V2_A61TicketTecnicoCableEspecial[0];
               A64TicketTecnicoCDsDVDs = H002V2_A64TicketTecnicoCDsDVDs[0];
               A63TicketTecnicoCargadorLaptop = H002V2_A63TicketTecnicoCargadorLaptop[0];
               A85TicketTecnicoTarjetaVideoExtra = H002V2_A85TicketTecnicoTarjetaVideoExtra[0];
               A86TicketTecnicoTonerCinta = H002V2_A86TicketTecnicoTonerCinta[0];
               A76TicketTecnicoMaletin = H002V2_A76TicketTecnicoMaletin[0];
               A81TicketTecnicoProcesador = H002V2_A81TicketTecnicoProcesador[0];
               A68TicketTecnicoDiscoDuro = H002V2_A68TicketTecnicoDiscoDuro[0];
               A83TicketTecnicoRam = H002V2_A83TicketTecnicoRam[0];
               A67TicketTecnicoCopiasRespaldo = H002V2_A67TicketTecnicoCopiasRespaldo[0];
               A62TicketTecnicoCambiosHardware = H002V2_A62TicketTecnicoCambiosHardware[0];
               A82TicketTecnicoPuntoRed = H002V2_A82TicketTecnicoPuntoRed[0];
               A75TicketTecnicoLimpieza = H002V2_A75TicketTecnicoLimpieza[0];
               A84TicketTecnicoReparacion = H002V2_A84TicketTecnicoReparacion[0];
               A70TicketTecnicoFormateo = H002V2_A70TicketTecnicoFormateo[0];
               A73TicketTecnicoInternetRouter = H002V2_A73TicketTecnicoInternetRouter[0];
               A66TicketTecnicoConfiguracion = H002V2_A66TicketTecnicoConfiguracion[0];
               A72TicketTecnicoInstalacion = H002V2_A72TicketTecnicoInstalacion[0];
               A74TicketTecnicoInventarioSerie = H002V2_A74TicketTecnicoInventarioSerie[0];
               A88UsuarioDepartamento = H002V2_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H002V2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002V2_A93UsuarioNombre[0];
               A15UsuarioId = H002V2_A15UsuarioId[0];
               A30ResponsableNombre = H002V2_A30ResponsableNombre[0];
               A6ResponsableId = H002V2_A6ResponsableId[0];
               A16TicketResponsableId = H002V2_A16TicketResponsableId[0];
               A14TicketId = H002V2_A14TicketId[0];
               A71TicketTecnicoHora = H002V2_A71TicketTecnicoHora[0];
               A69TicketTecnicoFecha = H002V2_A69TicketTecnicoFecha[0];
               A18TicketTecnicoId = H002V2_A18TicketTecnicoId[0];
               A30ResponsableNombre = H002V2_A30ResponsableNombre[0];
               A15UsuarioId = H002V2_A15UsuarioId[0];
               A88UsuarioDepartamento = H002V2_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H002V2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H002V2_A93UsuarioNombre[0];
               E252V2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 190;
            WB2V0( ) ;
         }
         bGXsfl_190_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV86Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICOID"+"_"+sGXsfl_190_idx, GetSecureSignedToken( sGXsfl_190_idx, context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV83Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Uri, "")), context));
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
                                              AV58TicketTecnicoFecha_To ,
                                              AV57TicketTecnicoFecha_From ,
                                              AV61TicketTecnicoHora_To ,
                                              AV60TicketTecnicoHora_From ,
                                              AV66K2BToolsGenericSearchField ,
                                              A69TicketTecnicoFecha ,
                                              A71TicketTecnicoHora ,
                                              A18TicketTecnicoId ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A30ResponsableNombre ,
                                              A15UsuarioId ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              A88UsuarioDepartamento ,
                                              A74TicketTecnicoInventarioSerie ,
                                              AV67OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT
                                              }
         });
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         lV66K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV66K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002V3 */
         pr_default.execute(1, new Object[] {AV58TicketTecnicoFecha_To, AV57TicketTecnicoFecha_From, AV61TicketTecnicoHora_To, AV60TicketTecnicoHora_From, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField, lV66K2BToolsGenericSearchField});
         GRID_nRecordCount = H002V3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV86Pgmname = "WWTicketTecnico";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV64FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV68GridOrders);
            /* Read saved values. */
            nRC_GXsfl_190 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_190"), ".", ","));
            AV65DeletedTag = cgiGet( "vDELETEDTAG");
            AV57TicketTecnicoFecha_From = context.localUtil.CToD( cgiGet( "vTICKETTECNICOFECHA_FROM"), 0);
            AV58TicketTecnicoFecha_To = context.localUtil.CToD( cgiGet( "vTICKETTECNICOFECHA_TO"), 0);
            AV70UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV67OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV66K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV66K2BToolsGenericSearchField", AV66K2BToolsGenericSearchField);
            if ( context.localUtil.VCDate( cgiGet( edtavTickettecnicohora_from_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Tecnico Hora_From"}), 1, "vTICKETTECNICOHORA_FROM");
               GX_FocusControl = edtavTickettecnicohora_from_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV60TicketTecnicoHora_From = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV60TicketTecnicoHora_From", context.localUtil.TToC( AV60TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV60TicketTecnicoHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickettecnicohora_from_Internalname)));
               AssignAttri("", false, "AV60TicketTecnicoHora_From", context.localUtil.TToC( AV60TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTickettecnicohora_to_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Tecnico Hora_To"}), 1, "vTICKETTECNICOHORA_TO");
               GX_FocusControl = edtavTickettecnicohora_to_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV61TicketTecnicoHora_To = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV61TicketTecnicoHora_To", context.localUtil.TToC( AV61TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV61TicketTecnicoHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTickettecnicohora_to_Internalname)));
               AssignAttri("", false, "AV61TicketTecnicoHora_To", context.localUtil.TToC( AV61TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            AV14Att_TicketTecnicoId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickettecnicoid_visible_Internalname));
            AssignAttri("", false, "AV14Att_TicketTecnicoId_Visible", AV14Att_TicketTecnicoId_Visible);
            AV15Att_TicketTecnicoFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickettecnicofecha_visible_Internalname));
            AssignAttri("", false, "AV15Att_TicketTecnicoFecha_Visible", AV15Att_TicketTecnicoFecha_Visible);
            AV16Att_TicketTecnicoHora_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickettecnicohora_visible_Internalname));
            AssignAttri("", false, "AV16Att_TicketTecnicoHora_Visible", AV16Att_TicketTecnicoHora_Visible);
            AV17Att_TicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketid_visible_Internalname));
            AssignAttri("", false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
            AV18Att_TicketResponsableId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketresponsableid_visible_Internalname));
            AssignAttri("", false, "AV18Att_TicketResponsableId_Visible", AV18Att_TicketResponsableId_Visible);
            AV20Att_ResponsableNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsablenombre_visible_Internalname));
            AssignAttri("", false, "AV20Att_ResponsableNombre_Visible", AV20Att_ResponsableNombre_Visible);
            AV21Att_UsuarioId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarioid_visible_Internalname));
            AssignAttri("", false, "AV21Att_UsuarioId_Visible", AV21Att_UsuarioId_Visible);
            AV22Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri("", false, "AV22Att_UsuarioNombre_Visible", AV22Att_UsuarioNombre_Visible);
            AV23Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri("", false, "AV23Att_UsuarioRequerimiento_Visible", AV23Att_UsuarioRequerimiento_Visible);
            AV24Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariodepartamento_visible_Internalname));
            AssignAttri("", false, "AV24Att_UsuarioDepartamento_Visible", AV24Att_UsuarioDepartamento_Visible);
            AV25Att_TicketTecnicoInventarioSerie_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickettecnicoinventarioserie_visible_Internalname));
            AssignAttri("", false, "AV25Att_TicketTecnicoInventarioSerie_Visible", AV25Att_TicketTecnicoInventarioSerie_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV49GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV49GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV66K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTICKETTECNICOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV57TicketTecnicoFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETTECNICOHORA_FROM")) != AV60TicketTecnicoHora_From )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vTICKETTECNICOHORA_TO")) != AV61TicketTecnicoHora_To )
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
         E222V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV56TicketTecnicoFecha = DateTime.MinValue;
         AV57TicketTecnicoFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV57TicketTecnicoFecha_From", context.localUtil.Format(AV57TicketTecnicoFecha_From, "99/99/9999"));
         AV58TicketTecnicoFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV58TicketTecnicoFecha_To", context.localUtil.Format(AV58TicketTecnicoFecha_To, "99/99/9999"));
         AV59TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         AV60TicketTecnicoHora_From = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.ServerDate( context, pr_default) , - ( (int)(30) )) ) ;
         AssignAttri("", false, "AV60TicketTecnicoHora_From", context.localUtil.TToC( AV60TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " "));
         AV61TicketTecnicoHora_To = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV61TicketTecnicoHora_To", context.localUtil.TToC( AV61TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " "));
         new k2bloadrowsperpage(context ).execute(  AV86Pgmname,  "Grid", out  AV50RowsPerPageVariable, out  AV51RowsPerPageLoaded) ;
         AssignAttri("", false, "AV50RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV50RowsPerPageVariable), 4, 0));
         if ( ! AV51RowsPerPageLoaded )
         {
            AV50RowsPerPageVariable = 20;
            AssignAttri("", false, "AV50RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV50RowsPerPageVariable), 4, 0));
         }
         AV49GridSettingsRowsPerPageVariable = AV50RowsPerPageVariable;
         AssignAttri("", false, "AV49GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV50RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Ticket tecnicos";
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
         AV68GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV69GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV69GridOrder.gxTpr_Ascendingorder = 0;
         AV69GridOrder.gxTpr_Descendingorder = 1;
         AV69GridOrder.gxTpr_Gridcolumnindex = 1;
         AV68GridOrders.Add(AV69GridOrder, 0);
         AV69GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV69GridOrder.gxTpr_Ascendingorder = 2;
         AV69GridOrder.gxTpr_Descendingorder = 3;
         AV69GridOrder.gxTpr_Gridcolumnindex = 2;
         AV68GridOrders.Add(AV69GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV71Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV71Messages = GXt_objcol_SdtMessages_Message1;
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV71Messages.Count )
         {
            AV72Message = ((GeneXus.Utils.SdtMessages_Message)AV71Messages.Item(AV87GXV1));
            GX_msglist.addItem(AV72Message.gxTpr_Description);
            AV87GXV1 = (int)(AV87GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV78ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV86Pgmname;
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV78ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV74Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.convertURL( context.PathToRelativeUrl( AV74Update))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV74Update), true);
         AV88Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.convertURL( context.PathToRelativeUrl( AV74Update))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV74Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_190_Refreshing);
         AV75Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV75Delete))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV75Delete), true);
         AV89Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV75Delete))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV75Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_190_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV55ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV52GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV86Pgmname,  AV52GridStateKey, out  AV53GridState) ;
         AV67OrderedBy = AV53GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV67OrderedBy", StringUtil.LTrimStr( (decimal)(AV67OrderedBy), 4, 0));
         AV70UC_OrderedBy = AV53GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV70UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV70UC_OrderedBy), 4, 0));
         AV90GXV2 = 1;
         while ( AV90GXV2 <= AV53GridState.gxTpr_Filtervalues.Count )
         {
            AV54GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV53GridState.gxTpr_Filtervalues.Item(AV90GXV2));
            if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Filtername, "TicketTecnicoFecha:From") == 0 )
            {
               AV57TicketTecnicoFecha_From = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV57TicketTecnicoFecha_From", context.localUtil.Format(AV57TicketTecnicoFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Filtername, "TicketTecnicoFecha:To") == 0 )
            {
               AV58TicketTecnicoFecha_To = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV58TicketTecnicoFecha_To", context.localUtil.Format(AV58TicketTecnicoFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Filtername, "TicketTecnicoHora:From") == 0 )
            {
               AV60TicketTecnicoHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( AV54GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV60TicketTecnicoHora_From", context.localUtil.TToC( AV60TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Filtername, "TicketTecnicoHora:To") == 0 )
            {
               AV61TicketTecnicoHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV54GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV61TicketTecnicoHora_To", context.localUtil.TToC( AV61TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV66K2BToolsGenericSearchField = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66K2BToolsGenericSearchField", AV66K2BToolsGenericSearchField);
            }
            AV90GXV2 = (int)(AV90GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV53GridState.gxTpr_Currentpage > 0 ) && ( AV53GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV53GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV52GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV86Pgmname,  AV52GridStateKey, out  AV53GridState) ;
         AV53GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV53GridState.gxTpr_Orderedby = AV67OrderedBy;
         AV53GridState.gxTpr_Filtervalues.Clear();
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV54GridStateFilterValue.gxTpr_Filtername = "TicketTecnicoFecha:From";
         AV54GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV57TicketTecnicoFecha_From, "99/99/9999");
         AV53GridState.gxTpr_Filtervalues.Add(AV54GridStateFilterValue, 0);
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV54GridStateFilterValue.gxTpr_Filtername = "TicketTecnicoFecha:To";
         AV54GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV58TicketTecnicoFecha_To, "99/99/9999");
         AV53GridState.gxTpr_Filtervalues.Add(AV54GridStateFilterValue, 0);
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV54GridStateFilterValue.gxTpr_Filtername = "TicketTecnicoHora:From";
         AV54GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV60TicketTecnicoHora_From, "99:99");
         AV53GridState.gxTpr_Filtervalues.Add(AV54GridStateFilterValue, 0);
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV54GridStateFilterValue.gxTpr_Filtername = "TicketTecnicoHora:To";
         AV54GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV61TicketTecnicoHora_To, "99:99");
         AV53GridState.gxTpr_Filtervalues.Add(AV54GridStateFilterValue, 0);
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV54GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV54GridStateFilterValue.gxTpr_Value = AV66K2BToolsGenericSearchField;
         AV53GridState.gxTpr_Filtervalues.Add(AV54GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV86Pgmname,  AV52GridStateKey,  AV53GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV76TrnContext = new SdtK2BTrnContext(context);
         AV76TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV76TrnContext.gxTpr_Returnmode = "Stack";
         AV76TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV76TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV76TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV76TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV76TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV76TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "TicketTecnico",  AV76TrnContext) ;
      }

      protected void E132V2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "TicketTecnico",  "TicketTecnico",  "Insert",  "",  "EntityManagerTicketTecnico") )
         {
            CallWebObject(formatLink("entitymanagertickettecnico.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketTecnicoId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtTicketTecnicoId_Visible = 1;
         AssignProp("", false, edtTicketTecnicoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoId_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV14Att_TicketTecnicoId_Visible = true;
         AssignAttri("", false, "AV14Att_TicketTecnicoId_Visible", AV14Att_TicketTecnicoId_Visible);
         edtTicketTecnicoFecha_Visible = 1;
         AssignProp("", false, edtTicketTecnicoFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoFecha_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV15Att_TicketTecnicoFecha_Visible = true;
         AssignAttri("", false, "AV15Att_TicketTecnicoFecha_Visible", AV15Att_TicketTecnicoFecha_Visible);
         edtTicketTecnicoHora_Visible = 1;
         AssignProp("", false, edtTicketTecnicoHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoHora_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV16Att_TicketTecnicoHora_Visible = true;
         AssignAttri("", false, "AV16Att_TicketTecnicoHora_Visible", AV16Att_TicketTecnicoHora_Visible);
         edtTicketId_Visible = 1;
         AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV17Att_TicketId_Visible = true;
         AssignAttri("", false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
         edtTicketResponsableId_Visible = 1;
         AssignProp("", false, edtTicketResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV18Att_TicketResponsableId_Visible = true;
         AssignAttri("", false, "AV18Att_TicketResponsableId_Visible", AV18Att_TicketResponsableId_Visible);
         edtResponsableNombre_Visible = 1;
         AssignProp("", false, edtResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV20Att_ResponsableNombre_Visible = true;
         AssignAttri("", false, "AV20Att_ResponsableNombre_Visible", AV20Att_ResponsableNombre_Visible);
         edtUsuarioId_Visible = 1;
         AssignProp("", false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV21Att_UsuarioId_Visible = true;
         AssignAttri("", false, "AV21Att_UsuarioId_Visible", AV21Att_UsuarioId_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV22Att_UsuarioNombre_Visible = true;
         AssignAttri("", false, "AV22Att_UsuarioNombre_Visible", AV22Att_UsuarioNombre_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV23Att_UsuarioRequerimiento_Visible = true;
         AssignAttri("", false, "AV23Att_UsuarioRequerimiento_Visible", AV23Att_UsuarioRequerimiento_Visible);
         edtUsuarioDepartamento_Visible = 1;
         AssignProp("", false, edtUsuarioDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV24Att_UsuarioDepartamento_Visible = true;
         AssignAttri("", false, "AV24Att_UsuarioDepartamento_Visible", AV24Att_UsuarioDepartamento_Visible);
         edtTicketTecnicoInventarioSerie_Visible = 1;
         AssignProp("", false, edtTicketTecnicoInventarioSerie_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoInventarioSerie_Visible), 5, 0), !bGXsfl_190_Refreshing);
         AV25Att_TicketTecnicoInventarioSerie_Visible = true;
         AssignAttri("", false, "AV25Att_TicketTecnicoInventarioSerie_Visible", AV25Att_TicketTecnicoInventarioSerie_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV86Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV91GXV3 = 1;
         while ( AV91GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV91GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoId") == 0 )
               {
                  edtTicketTecnicoId_Visible = 0;
                  AssignProp("", false, edtTicketTecnicoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoId_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV14Att_TicketTecnicoId_Visible = false;
                  AssignAttri("", false, "AV14Att_TicketTecnicoId_Visible", AV14Att_TicketTecnicoId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoFecha") == 0 )
               {
                  edtTicketTecnicoFecha_Visible = 0;
                  AssignProp("", false, edtTicketTecnicoFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoFecha_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV15Att_TicketTecnicoFecha_Visible = false;
                  AssignAttri("", false, "AV15Att_TicketTecnicoFecha_Visible", AV15Att_TicketTecnicoFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoHora") == 0 )
               {
                  edtTicketTecnicoHora_Visible = 0;
                  AssignProp("", false, edtTicketTecnicoHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoHora_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV16Att_TicketTecnicoHora_Visible = false;
                  AssignAttri("", false, "AV16Att_TicketTecnicoHora_Visible", AV16Att_TicketTecnicoHora_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  edtTicketId_Visible = 0;
                  AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV17Att_TicketId_Visible = false;
                  AssignAttri("", false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  edtTicketResponsableId_Visible = 0;
                  AssignProp("", false, edtTicketResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV18Att_TicketResponsableId_Visible = false;
                  AssignAttri("", false, "AV18Att_TicketResponsableId_Visible", AV18Att_TicketResponsableId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
               {
                  edtResponsableNombre_Visible = 0;
                  AssignProp("", false, edtResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV20Att_ResponsableNombre_Visible = false;
                  AssignAttri("", false, "AV20Att_ResponsableNombre_Visible", AV20Att_ResponsableNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  edtUsuarioId_Visible = 0;
                  AssignProp("", false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV21Att_UsuarioId_Visible = false;
                  AssignAttri("", false, "AV21Att_UsuarioId_Visible", AV21Att_UsuarioId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV22Att_UsuarioNombre_Visible = false;
                  AssignAttri("", false, "AV22Att_UsuarioNombre_Visible", AV22Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV23Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri("", false, "AV23Att_UsuarioRequerimiento_Visible", AV23Att_UsuarioRequerimiento_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  edtUsuarioDepartamento_Visible = 0;
                  AssignProp("", false, edtUsuarioDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV24Att_UsuarioDepartamento_Visible = false;
                  AssignAttri("", false, "AV24Att_UsuarioDepartamento_Visible", AV24Att_UsuarioDepartamento_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoInventarioSerie") == 0 )
               {
                  edtTicketTecnicoInventarioSerie_Visible = 0;
                  AssignProp("", false, edtTicketTecnicoInventarioSerie_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoInventarioSerie_Visible), 5, 0), !bGXsfl_190_Refreshing);
                  AV25Att_TicketTecnicoInventarioSerie_Visible = false;
                  AssignAttri("", false, "AV25Att_TicketTecnicoInventarioSerie_Visible", AV25Att_TicketTecnicoInventarioSerie_Visible);
               }
            }
            AV91GXV3 = (int)(AV91GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketTecnicoId";
         AV13GridColumn.gxTpr_Columntitle = "Ticket Tecnico";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketTecnicoFecha";
         AV13GridColumn.gxTpr_Columntitle = "Fecha";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketTecnicoHora";
         AV13GridColumn.gxTpr_Columntitle = "Hora";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketId";
         AV13GridColumn.gxTpr_Columntitle = "RST No.";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketResponsableId";
         AV13GridColumn.gxTpr_Columntitle = "Id TR:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableNombre";
         AV13GridColumn.gxTpr_Columntitle = "Técnico";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioId";
         AV13GridColumn.gxTpr_Columntitle = "Id Usuario";
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
         AV13GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV13GridColumn.gxTpr_Columntitle = "Departamento";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketTecnicoInventarioSerie";
         AV13GridColumn.gxTpr_Columntitle = "Serie";
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
         AV78ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV78ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV78ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerTicketTecnico";
         AV78ActivityList.Add(AV80ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV78ActivityList) ;
         AV73TicketTecnicoFecha_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV73TicketTecnicoFecha_IsAuthorized", AV73TicketTecnicoFecha_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_190_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_190_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV78ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_190_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_190_Refreshing);
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

      protected void E242V2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV55ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV74Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.convertURL( context.PathToRelativeUrl( AV74Update))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV74Update), true);
         AV88Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.convertURL( context.PathToRelativeUrl( AV74Update))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV74Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_190_Refreshing);
         AV75Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV75Delete))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV75Delete), true);
         AV89Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV75Delete))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV75Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_190_Refreshing);
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
         AV79AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV80ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV79AutoLinksActivityList.Add(AV80ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV79AutoLinksActivityList) ;
         AV70UC_OrderedBy = AV67OrderedBy;
         AssignAttri("", false, "AV70UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV70UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV55ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV79AutoLinksActivityList", AV79AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64FilterTags", AV64FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E252V2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV79AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         if ( AV73TicketTecnicoFecha_IsAuthorized )
         {
            edtTicketTecnicoFecha_Link = formatLink("entitymanagertickettecnico.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketTecnicoId","TabCode"}) ;
         }
         else
         {
            edtTicketTecnicoFecha_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagertickettecnico.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketTecnicoId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagertickettecnico.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","TicketTecnicoId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 190;
         }
         sendrow_1902( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_190_Refreshing )
         {
            context.DoAjaxLoad(190, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV62K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV57TicketTecnicoFecha_From) || ! (DateTime.MinValue==AV58TicketTecnicoFecha_To) )
         {
            AV63K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV63K2BFilterValuesSDTItem.gxTpr_Name = "TicketTecnicoFecha";
            AV63K2BFilterValuesSDTItem.gxTpr_Description = "Fecha";
            AV63K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV63K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV63K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV57TicketTecnicoFecha_From ) ;
            AV63K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV58TicketTecnicoFecha_To ) ;
            AV63K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV62K2BFilterValuesSDT.Add(AV63K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV60TicketTecnicoHora_From) || ! (DateTime.MinValue==AV61TicketTecnicoHora_To) )
         {
            AV63K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV63K2BFilterValuesSDTItem.gxTpr_Name = "TicketTecnicoHora";
            AV63K2BFilterValuesSDTItem.gxTpr_Description = "Hora";
            AV63K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV63K2BFilterValuesSDTItem.gxTpr_Type = "DateTimeRange";
            AV63K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            AV63K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = AV60TicketTecnicoHora_From;
            AV63K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = AV61TicketTecnicoHora_To;
            AV62K2BFilterValuesSDT.Add(AV63K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV62K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV64FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV86Pgmname,  "Grid",  AV62K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV64FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112V2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV65DeletedTag, "TicketTecnicoFecha") == 0 )
         {
            AV57TicketTecnicoFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV57TicketTecnicoFecha_From", context.localUtil.Format(AV57TicketTecnicoFecha_From, "99/99/9999"));
            AV58TicketTecnicoFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV58TicketTecnicoFecha_To", context.localUtil.Format(AV58TicketTecnicoFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV65DeletedTag, "TicketTecnicoHora") == 0 )
         {
            AV60TicketTecnicoHora_From = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV60TicketTecnicoHora_From", context.localUtil.TToC( AV60TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " "));
            AV61TicketTecnicoHora_To = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV61TicketTecnicoHora_To", context.localUtil.TToC( AV61TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " "));
         }
         gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void E122V2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV67OrderedBy = AV70UC_OrderedBy;
         AssignAttri("", false, "AV67OrderedBy", StringUtil.LTrimStr( (decimal)(AV67OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void E142V2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV86Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV92GXV4 = 1;
         while ( AV92GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV92GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_TicketTecnicoId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoFecha") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_TicketTecnicoFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoHora") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_TicketTecnicoHora_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_TicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_TicketResponsableId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_ResponsableNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV21Att_UsuarioId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV22Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV23Att_UsuarioRequerimiento_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV24Att_UsuarioDepartamento_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoInventarioSerie") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV25Att_TicketTecnicoInventarioSerie_Visible;
            }
            AV92GXV4 = (int)(AV92GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV86Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV70UC_OrderedBy = AV67OrderedBy;
         AssignAttri("", false, "AV70UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV70UC_OrderedBy), 4, 0));
         if ( AV50RowsPerPageVariable != AV49GridSettingsRowsPerPageVariable )
         {
            AV50RowsPerPageVariable = AV49GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV50RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV50RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV50RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV86Pgmname,  "Grid",  AV50RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV66K2BToolsGenericSearchField, AV57TicketTecnicoFecha_From, AV60TicketTecnicoHora_From, AV61TicketTecnicoHora_To, AV55ClassCollection, AV67OrderedBy, AV58TicketTecnicoFecha_To, AV86Pgmname, AV8CurrentPage, AV10GridConfiguration, AV79AutoLinksActivityList, AV73TicketTecnicoFecha_IsAuthorized, AV14Att_TicketTecnicoId_Visible, AV15Att_TicketTecnicoFecha_Visible, AV16Att_TicketTecnicoHora_Visible, AV17Att_TicketId_Visible, AV18Att_TicketResponsableId_Visible, AV20Att_ResponsableNombre_Visible, AV21Att_UsuarioId_Visible, AV22Att_UsuarioNombre_Visible, AV23Att_UsuarioRequerimiento_Visible, AV24Att_UsuarioDepartamento_Visible, AV25Att_TicketTecnicoInventarioSerie_Visible, AV11FreezeColumnTitles, AV83Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
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

      protected void E152V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void E162V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void E172V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
      }

      protected void E182V2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection", AV55ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV86Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV55ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV55ClassCollection) ;
         }
      }

      protected void E192V2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "TicketTecnico",  "TicketTecnico",  "List",  "",  "ExportWWTicketTecnico") )
         {
            new exportwwtickettecnico(context ).execute(  AV57TicketTecnicoFecha_From,  AV58TicketTecnicoFecha_To,  AV60TicketTecnicoHora_From,  AV61TicketTecnicoHora_To,  AV66K2BToolsGenericSearchField,  AV67OrderedBy, out  AV81OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV81OutFile, out  AV83Uri) )
            {
               CallWebObject(formatLink(AV83Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV82Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV82Guid.ToString(),  AV81OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV82Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202V2( )
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

      protected void E212V2( )
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

      protected void wb_table2_231_2V2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_231_2V2e( true) ;
         }
         else
         {
            wb_table2_231_2V2e( false) ;
         }
      }

      protected void wb_table1_56_2V2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e262v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicketTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWTicketTecnico.htm");
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
            GxWebStd.gx_div_start( context, divTickettecnicoid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickettecnicoid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickettecnicoid_visible_Internalname, "Ticket Tecnico", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickettecnicoid_visible_Internalname, StringUtil.BoolToStr( AV14Att_TicketTecnicoId_Visible), "", "Ticket Tecnico", 1, chkavAtt_tickettecnicoid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
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
            GxWebStd.gx_div_start( context, divTickettecnicofecha_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickettecnicofecha_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickettecnicofecha_visible_Internalname, "Fecha", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickettecnicofecha_visible_Internalname, StringUtil.BoolToStr( AV15Att_TicketTecnicoFecha_Visible), "", "Fecha", 1, chkavAtt_tickettecnicofecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
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
            GxWebStd.gx_div_start( context, divTickettecnicohora_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickettecnicohora_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickettecnicohora_visible_Internalname, "Hora", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickettecnicohora_visible_Internalname, StringUtil.BoolToStr( AV16Att_TicketTecnicoHora_Visible), "", "Hora", 1, chkavAtt_tickettecnicohora_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketid_visible_Internalname, StringUtil.BoolToStr( AV17Att_TicketId_Visible), "", "RST No.", 1, chkavAtt_ticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
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
            GxWebStd.gx_div_start( context, divTicketresponsableid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_ticketresponsableid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ticketresponsableid_visible_Internalname, "Id TR:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketresponsableid_visible_Internalname, StringUtil.BoolToStr( AV18Att_TicketResponsableId_Visible), "", "Id TR:", 1, chkavAtt_ticketresponsableid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
            GxWebStd.gx_div_start( context, divResponsablenombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsablenombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsablenombre_visible_Internalname, "Técnico", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsablenombre_visible_Internalname, StringUtil.BoolToStr( AV20Att_ResponsableNombre_Visible), "", "Técnico", 1, chkavAtt_responsablenombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(115, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,115);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarioid_visible_Internalname, StringUtil.BoolToStr( AV21Att_UsuarioId_Visible), "", "Id Usuario", 1, chkavAtt_usuarioid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV22Att_UsuarioNombre_Visible), "", "Usuario", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV23Att_UsuarioRequerimiento_Visible), "", "Requerimiento", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(133, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,133);\"");
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
            GxWebStd.gx_div_start( context, divUsuariodepartamento_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariodepartamento_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariodepartamento_visible_Internalname, "Departamento", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariodepartamento_visible_Internalname, StringUtil.BoolToStr( AV24Att_UsuarioDepartamento_Visible), "", "Departamento", 1, chkavAtt_usuariodepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(139, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,139);\"");
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
            GxWebStd.gx_div_start( context, divTickettecnicoinventarioserie_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickettecnicoinventarioserie_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickettecnicoinventarioserie_visible_Internalname, "Serie", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickettecnicoinventarioserie_visible_Internalname, StringUtil.BoolToStr( AV25Att_TicketTecnicoInventarioSerie_Visible), "", "Serie", 1, chkavAtt_tickettecnicoinventarioserie_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(145, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,145);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_190_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "", true, 1, "HLP_WWTicketTecnico.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_190_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(157, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,157);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(190), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicketTecnico.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e272v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWTicketTecnico.htm");
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
            wb_table3_171_2V2( true) ;
         }
         else
         {
            wb_table3_171_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table3_171_2V2e( bool wbgen )
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
            wb_table4_178_2V2( true) ;
         }
         else
         {
            wb_table4_178_2V2( false) ;
         }
         return  ;
      }

      protected void wb_table4_178_2V2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_56_2V2e( true) ;
         }
         else
         {
            wb_table1_56_2V2e( false) ;
         }
      }

      protected void wb_table4_178_2V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(190), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicketTecnico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_178_2V2e( true) ;
         }
         else
         {
            wb_table4_178_2V2e( false) ;
         }
      }

      protected void wb_table3_171_2V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(190), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e282v1_client"+"'", TempTags, "", 2, "HLP_WWTicketTecnico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(190), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTicketTecnico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_171_2V2e( true) ;
         }
         else
         {
            wb_table3_171_2V2e( false) ;
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
         PA2V2( ) ;
         WS2V2( ) ;
         WE2V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188363713", true, true);
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
         context.AddJavascriptSource("wwtickettecnico.js", "?2024188363714", false, true);
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

      protected void SubsflControlProps_1902( )
      {
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_190_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_190_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_190_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_190_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_190_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_190_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_190_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_190_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_190_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_190_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_190_idx;
         edtTicketTecnicoInventarioSerie_Internalname = "TICKETTECNICOINVENTARIOSERIE_"+sGXsfl_190_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_190_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_190_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_190_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_190_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_190_idx;
         chkTicketTecnicoLimpieza_Internalname = "TICKETTECNICOLIMPIEZA_"+sGXsfl_190_idx;
         chkTicketTecnicoPuntoRed_Internalname = "TICKETTECNICOPUNTORED_"+sGXsfl_190_idx;
         chkTicketTecnicoCambiosHardware_Internalname = "TICKETTECNICOCAMBIOSHARDWARE_"+sGXsfl_190_idx;
         chkTicketTecnicoCopiasRespaldo_Internalname = "TICKETTECNICOCOPIASRESPALDO_"+sGXsfl_190_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_190_idx;
         chkTicketTecnicoDiscoDuro_Internalname = "TICKETTECNICODISCODURO_"+sGXsfl_190_idx;
         chkTicketTecnicoProcesador_Internalname = "TICKETTECNICOPROCESADOR_"+sGXsfl_190_idx;
         chkTicketTecnicoMaletin_Internalname = "TICKETTECNICOMALETIN_"+sGXsfl_190_idx;
         chkTicketTecnicoTonerCinta_Internalname = "TICKETTECNICOTONERCINTA_"+sGXsfl_190_idx;
         chkTicketTecnicoTarjetaVideoExtra_Internalname = "TICKETTECNICOTARJETAVIDEOEXTRA_"+sGXsfl_190_idx;
         chkTicketTecnicoCargadorLaptop_Internalname = "TICKETTECNICOCARGADORLAPTOP_"+sGXsfl_190_idx;
         chkTicketTecnicoCDsDVDs_Internalname = "TICKETTECNICOCDSDVDS_"+sGXsfl_190_idx;
         chkTicketTecnicoCableEspecial_Internalname = "TICKETTECNICOCABLEESPECIAL_"+sGXsfl_190_idx;
         chkTicketTecnicoOtrosTaller_Internalname = "TICKETTECNICOOTROSTALLER_"+sGXsfl_190_idx;
         chkTicketTecnicoCerrado_Internalname = "TICKETTECNICOCERRADO_"+sGXsfl_190_idx;
         chkTicketTecnicoPendiente_Internalname = "TICKETTECNICOPENDIENTE_"+sGXsfl_190_idx;
         chkTicketTecnicoPasaTaller_Internalname = "TICKETTECNICOPASATALLER_"+sGXsfl_190_idx;
         chkTicketTecnicoObservacion_Internalname = "TICKETTECNICOOBSERVACION_"+sGXsfl_190_idx;
         edtTicketTecnicoDetalle_Internalname = "TICKETTECNICODETALLE_"+sGXsfl_190_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_190_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_190_idx;
      }

      protected void SubsflControlProps_fel_1902( )
      {
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_190_fel_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_190_fel_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_190_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_190_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_190_fel_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_190_fel_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_190_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_190_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_190_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_190_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_190_fel_idx;
         edtTicketTecnicoInventarioSerie_Internalname = "TICKETTECNICOINVENTARIOSERIE_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoLimpieza_Internalname = "TICKETTECNICOLIMPIEZA_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoPuntoRed_Internalname = "TICKETTECNICOPUNTORED_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCambiosHardware_Internalname = "TICKETTECNICOCAMBIOSHARDWARE_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCopiasRespaldo_Internalname = "TICKETTECNICOCOPIASRESPALDO_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoDiscoDuro_Internalname = "TICKETTECNICODISCODURO_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoProcesador_Internalname = "TICKETTECNICOPROCESADOR_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoMaletin_Internalname = "TICKETTECNICOMALETIN_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoTonerCinta_Internalname = "TICKETTECNICOTONERCINTA_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoTarjetaVideoExtra_Internalname = "TICKETTECNICOTARJETAVIDEOEXTRA_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCargadorLaptop_Internalname = "TICKETTECNICOCARGADORLAPTOP_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCDsDVDs_Internalname = "TICKETTECNICOCDSDVDS_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCableEspecial_Internalname = "TICKETTECNICOCABLEESPECIAL_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoOtrosTaller_Internalname = "TICKETTECNICOOTROSTALLER_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoCerrado_Internalname = "TICKETTECNICOCERRADO_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoPendiente_Internalname = "TICKETTECNICOPENDIENTE_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoPasaTaller_Internalname = "TICKETTECNICOPASATALLER_"+sGXsfl_190_fel_idx;
         chkTicketTecnicoObservacion_Internalname = "TICKETTECNICOOBSERVACION_"+sGXsfl_190_fel_idx;
         edtTicketTecnicoDetalle_Internalname = "TICKETTECNICODETALLE_"+sGXsfl_190_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_190_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_190_fel_idx;
      }

      protected void sendrow_1902( )
      {
         SubsflControlProps_1902( ) ;
         WB2V0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_190_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_190_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_190_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketTecnicoId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketTecnicoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)86,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketTecnicoFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoFecha_Internalname,context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"),context.localUtil.Format( A69TicketTecnicoFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTicketTecnicoFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketTecnicoFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtTicketTecnicoFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketTecnicoHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoHora_Internalname,context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A71TicketTecnicoHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketTecnicoHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketResponsableId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketResponsableId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableNombre_Internalname,(string)A30ResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTicketTecnicoInventarioSerie_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoInventarioSerie_Internalname,(string)A74TicketTecnicoInventarioSerie,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoInventarioSerie_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketTecnicoInventarioSerie_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_190_idx;
            chkTicketTecnicoInstalacion.Name = GXCCtl;
            chkTicketTecnicoInstalacion.WebTags = "";
            chkTicketTecnicoInstalacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoInstalacion.CheckedValue = "false";
            A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoInstalacion_Internalname,StringUtil.BoolToStr( A72TicketTecnicoInstalacion),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_190_idx;
            chkTicketTecnicoConfiguracion.Name = GXCCtl;
            chkTicketTecnicoConfiguracion.WebTags = "";
            chkTicketTecnicoConfiguracion.Caption = "";
            AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoConfiguracion.CheckedValue = "false";
            A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoConfiguracion_Internalname,StringUtil.BoolToStr( A66TicketTecnicoConfiguracion),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_190_idx;
            chkTicketTecnicoInternetRouter.Name = GXCCtl;
            chkTicketTecnicoInternetRouter.WebTags = "";
            chkTicketTecnicoInternetRouter.Caption = "";
            AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoInternetRouter.CheckedValue = "false";
            A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoInternetRouter_Internalname,StringUtil.BoolToStr( A73TicketTecnicoInternetRouter),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_190_idx;
            chkTicketTecnicoFormateo.Name = GXCCtl;
            chkTicketTecnicoFormateo.WebTags = "";
            chkTicketTecnicoFormateo.Caption = "";
            AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoFormateo.CheckedValue = "false";
            A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoFormateo_Internalname,StringUtil.BoolToStr( A70TicketTecnicoFormateo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_190_idx;
            chkTicketTecnicoReparacion.Name = GXCCtl;
            chkTicketTecnicoReparacion.WebTags = "";
            chkTicketTecnicoReparacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoReparacion.CheckedValue = "false";
            A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoReparacion_Internalname,StringUtil.BoolToStr( A84TicketTecnicoReparacion),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOLIMPIEZA_" + sGXsfl_190_idx;
            chkTicketTecnicoLimpieza.Name = GXCCtl;
            chkTicketTecnicoLimpieza.WebTags = "";
            chkTicketTecnicoLimpieza.Caption = "";
            AssignProp("", false, chkTicketTecnicoLimpieza_Internalname, "TitleCaption", chkTicketTecnicoLimpieza.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoLimpieza.CheckedValue = "false";
            A75TicketTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A75TicketTecnicoLimpieza));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoLimpieza_Internalname,StringUtil.BoolToStr( A75TicketTecnicoLimpieza),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOPUNTORED_" + sGXsfl_190_idx;
            chkTicketTecnicoPuntoRed.Name = GXCCtl;
            chkTicketTecnicoPuntoRed.WebTags = "";
            chkTicketTecnicoPuntoRed.Caption = "";
            AssignProp("", false, chkTicketTecnicoPuntoRed_Internalname, "TitleCaption", chkTicketTecnicoPuntoRed.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoPuntoRed.CheckedValue = "false";
            A82TicketTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A82TicketTecnicoPuntoRed));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoPuntoRed_Internalname,StringUtil.BoolToStr( A82TicketTecnicoPuntoRed),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCAMBIOSHARDWARE_" + sGXsfl_190_idx;
            chkTicketTecnicoCambiosHardware.Name = GXCCtl;
            chkTicketTecnicoCambiosHardware.WebTags = "";
            chkTicketTecnicoCambiosHardware.Caption = "";
            AssignProp("", false, chkTicketTecnicoCambiosHardware_Internalname, "TitleCaption", chkTicketTecnicoCambiosHardware.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCambiosHardware.CheckedValue = "false";
            A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCambiosHardware_Internalname,StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCOPIASRESPALDO_" + sGXsfl_190_idx;
            chkTicketTecnicoCopiasRespaldo.Name = GXCCtl;
            chkTicketTecnicoCopiasRespaldo.WebTags = "";
            chkTicketTecnicoCopiasRespaldo.Caption = "";
            AssignProp("", false, chkTicketTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkTicketTecnicoCopiasRespaldo.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCopiasRespaldo.CheckedValue = "false";
            A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCopiasRespaldo_Internalname,StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICORAM_" + sGXsfl_190_idx;
            chkTicketTecnicoRam.Name = GXCCtl;
            chkTicketTecnicoRam.WebTags = "";
            chkTicketTecnicoRam.Caption = "";
            AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoRam.CheckedValue = "false";
            A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoRam_Internalname,StringUtil.BoolToStr( A83TicketTecnicoRam),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICODISCODURO_" + sGXsfl_190_idx;
            chkTicketTecnicoDiscoDuro.Name = GXCCtl;
            chkTicketTecnicoDiscoDuro.WebTags = "";
            chkTicketTecnicoDiscoDuro.Caption = "";
            AssignProp("", false, chkTicketTecnicoDiscoDuro_Internalname, "TitleCaption", chkTicketTecnicoDiscoDuro.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoDiscoDuro.CheckedValue = "false";
            A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoDiscoDuro_Internalname,StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOPROCESADOR_" + sGXsfl_190_idx;
            chkTicketTecnicoProcesador.Name = GXCCtl;
            chkTicketTecnicoProcesador.WebTags = "";
            chkTicketTecnicoProcesador.Caption = "";
            AssignProp("", false, chkTicketTecnicoProcesador_Internalname, "TitleCaption", chkTicketTecnicoProcesador.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoProcesador.CheckedValue = "false";
            A81TicketTecnicoProcesador = StringUtil.StrToBool( StringUtil.BoolToStr( A81TicketTecnicoProcesador));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoProcesador_Internalname,StringUtil.BoolToStr( A81TicketTecnicoProcesador),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOMALETIN_" + sGXsfl_190_idx;
            chkTicketTecnicoMaletin.Name = GXCCtl;
            chkTicketTecnicoMaletin.WebTags = "";
            chkTicketTecnicoMaletin.Caption = "";
            AssignProp("", false, chkTicketTecnicoMaletin_Internalname, "TitleCaption", chkTicketTecnicoMaletin.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoMaletin.CheckedValue = "false";
            A76TicketTecnicoMaletin = StringUtil.StrToBool( StringUtil.BoolToStr( A76TicketTecnicoMaletin));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoMaletin_Internalname,StringUtil.BoolToStr( A76TicketTecnicoMaletin),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOTONERCINTA_" + sGXsfl_190_idx;
            chkTicketTecnicoTonerCinta.Name = GXCCtl;
            chkTicketTecnicoTonerCinta.WebTags = "";
            chkTicketTecnicoTonerCinta.Caption = "";
            AssignProp("", false, chkTicketTecnicoTonerCinta_Internalname, "TitleCaption", chkTicketTecnicoTonerCinta.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoTonerCinta.CheckedValue = "false";
            A86TicketTecnicoTonerCinta = StringUtil.StrToBool( StringUtil.BoolToStr( A86TicketTecnicoTonerCinta));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoTonerCinta_Internalname,StringUtil.BoolToStr( A86TicketTecnicoTonerCinta),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOTARJETAVIDEOEXTRA_" + sGXsfl_190_idx;
            chkTicketTecnicoTarjetaVideoExtra.Name = GXCCtl;
            chkTicketTecnicoTarjetaVideoExtra.WebTags = "";
            chkTicketTecnicoTarjetaVideoExtra.Caption = "";
            AssignProp("", false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "TitleCaption", chkTicketTecnicoTarjetaVideoExtra.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoTarjetaVideoExtra.CheckedValue = "false";
            A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoTarjetaVideoExtra_Internalname,StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCARGADORLAPTOP_" + sGXsfl_190_idx;
            chkTicketTecnicoCargadorLaptop.Name = GXCCtl;
            chkTicketTecnicoCargadorLaptop.WebTags = "";
            chkTicketTecnicoCargadorLaptop.Caption = "";
            AssignProp("", false, chkTicketTecnicoCargadorLaptop_Internalname, "TitleCaption", chkTicketTecnicoCargadorLaptop.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCargadorLaptop.CheckedValue = "false";
            A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCargadorLaptop_Internalname,StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCDSDVDS_" + sGXsfl_190_idx;
            chkTicketTecnicoCDsDVDs.Name = GXCCtl;
            chkTicketTecnicoCDsDVDs.WebTags = "";
            chkTicketTecnicoCDsDVDs.Caption = "";
            AssignProp("", false, chkTicketTecnicoCDsDVDs_Internalname, "TitleCaption", chkTicketTecnicoCDsDVDs.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCDsDVDs.CheckedValue = "false";
            A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCDsDVDs_Internalname,StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCABLEESPECIAL_" + sGXsfl_190_idx;
            chkTicketTecnicoCableEspecial.Name = GXCCtl;
            chkTicketTecnicoCableEspecial.WebTags = "";
            chkTicketTecnicoCableEspecial.Caption = "";
            AssignProp("", false, chkTicketTecnicoCableEspecial_Internalname, "TitleCaption", chkTicketTecnicoCableEspecial.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCableEspecial.CheckedValue = "false";
            A61TicketTecnicoCableEspecial = StringUtil.StrToBool( StringUtil.BoolToStr( A61TicketTecnicoCableEspecial));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCableEspecial_Internalname,StringUtil.BoolToStr( A61TicketTecnicoCableEspecial),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOOTROSTALLER_" + sGXsfl_190_idx;
            chkTicketTecnicoOtrosTaller.Name = GXCCtl;
            chkTicketTecnicoOtrosTaller.WebTags = "";
            chkTicketTecnicoOtrosTaller.Caption = "";
            AssignProp("", false, chkTicketTecnicoOtrosTaller_Internalname, "TitleCaption", chkTicketTecnicoOtrosTaller.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoOtrosTaller.CheckedValue = "false";
            A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoOtrosTaller_Internalname,StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCERRADO_" + sGXsfl_190_idx;
            chkTicketTecnicoCerrado.Name = GXCCtl;
            chkTicketTecnicoCerrado.WebTags = "";
            chkTicketTecnicoCerrado.Caption = "";
            AssignProp("", false, chkTicketTecnicoCerrado_Internalname, "TitleCaption", chkTicketTecnicoCerrado.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoCerrado.CheckedValue = "false";
            A65TicketTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A65TicketTecnicoCerrado));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoCerrado_Internalname,StringUtil.BoolToStr( A65TicketTecnicoCerrado),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOPENDIENTE_" + sGXsfl_190_idx;
            chkTicketTecnicoPendiente.Name = GXCCtl;
            chkTicketTecnicoPendiente.WebTags = "";
            chkTicketTecnicoPendiente.Caption = "";
            AssignProp("", false, chkTicketTecnicoPendiente_Internalname, "TitleCaption", chkTicketTecnicoPendiente.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoPendiente.CheckedValue = "false";
            A80TicketTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A80TicketTecnicoPendiente));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoPendiente_Internalname,StringUtil.BoolToStr( A80TicketTecnicoPendiente),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOPASATALLER_" + sGXsfl_190_idx;
            chkTicketTecnicoPasaTaller.Name = GXCCtl;
            chkTicketTecnicoPasaTaller.WebTags = "";
            chkTicketTecnicoPasaTaller.Caption = "";
            AssignProp("", false, chkTicketTecnicoPasaTaller_Internalname, "TitleCaption", chkTicketTecnicoPasaTaller.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoPasaTaller.CheckedValue = "false";
            A79TicketTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A79TicketTecnicoPasaTaller));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoPasaTaller_Internalname,StringUtil.BoolToStr( A79TicketTecnicoPasaTaller),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOOBSERVACION_" + sGXsfl_190_idx;
            chkTicketTecnicoObservacion.Name = GXCCtl;
            chkTicketTecnicoObservacion.WebTags = "";
            chkTicketTecnicoObservacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoObservacion_Internalname, "TitleCaption", chkTicketTecnicoObservacion.Caption, !bGXsfl_190_Refreshing);
            chkTicketTecnicoObservacion.CheckedValue = "false";
            A77TicketTecnicoObservacion = StringUtil.StrToBool( StringUtil.BoolToStr( A77TicketTecnicoObservacion));
            n77TicketTecnicoObservacion = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoObservacion_Internalname,StringUtil.BoolToStr( A77TicketTecnicoObservacion),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoDetalle_Internalname,(string)A97TicketTecnicoDetalle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoDetalle_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)190,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV74Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV74Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV88Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74Update)) ? AV88Update_GXI : context.PathToRelativeUrl( AV74Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV74Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV75Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV89Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV75Delete)) ? AV89Delete_GXI : context.PathToRelativeUrl( AV75Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV75Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2V2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_190_idx = ((subGrid_Islastpage==1)&&(nGXsfl_190_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_190_idx+1);
            sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
            SubsflControlProps_1902( ) ;
         }
         /* End function sendrow_1902 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_tickettecnicoid_visible.Name = "vATT_TICKETTECNICOID_VISIBLE";
         chkavAtt_tickettecnicoid_visible.WebTags = "";
         chkavAtt_tickettecnicoid_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickettecnicoid_visible_Internalname, "TitleCaption", chkavAtt_tickettecnicoid_visible.Caption, true);
         chkavAtt_tickettecnicoid_visible.CheckedValue = "false";
         AV14Att_TicketTecnicoId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_TicketTecnicoId_Visible));
         AssignAttri("", false, "AV14Att_TicketTecnicoId_Visible", AV14Att_TicketTecnicoId_Visible);
         chkavAtt_tickettecnicofecha_visible.Name = "vATT_TICKETTECNICOFECHA_VISIBLE";
         chkavAtt_tickettecnicofecha_visible.WebTags = "";
         chkavAtt_tickettecnicofecha_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickettecnicofecha_visible_Internalname, "TitleCaption", chkavAtt_tickettecnicofecha_visible.Caption, true);
         chkavAtt_tickettecnicofecha_visible.CheckedValue = "false";
         AV15Att_TicketTecnicoFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_TicketTecnicoFecha_Visible));
         AssignAttri("", false, "AV15Att_TicketTecnicoFecha_Visible", AV15Att_TicketTecnicoFecha_Visible);
         chkavAtt_tickettecnicohora_visible.Name = "vATT_TICKETTECNICOHORA_VISIBLE";
         chkavAtt_tickettecnicohora_visible.WebTags = "";
         chkavAtt_tickettecnicohora_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickettecnicohora_visible_Internalname, "TitleCaption", chkavAtt_tickettecnicohora_visible.Caption, true);
         chkavAtt_tickettecnicohora_visible.CheckedValue = "false";
         AV16Att_TicketTecnicoHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_TicketTecnicoHora_Visible));
         AssignAttri("", false, "AV16Att_TicketTecnicoHora_Visible", AV16Att_TicketTecnicoHora_Visible);
         chkavAtt_ticketid_visible.Name = "vATT_TICKETID_VISIBLE";
         chkavAtt_ticketid_visible.WebTags = "";
         chkavAtt_ticketid_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketid_visible_Internalname, "TitleCaption", chkavAtt_ticketid_visible.Caption, true);
         chkavAtt_ticketid_visible.CheckedValue = "false";
         AV17Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_TicketId_Visible));
         AssignAttri("", false, "AV17Att_TicketId_Visible", AV17Att_TicketId_Visible);
         chkavAtt_ticketresponsableid_visible.Name = "vATT_TICKETRESPONSABLEID_VISIBLE";
         chkavAtt_ticketresponsableid_visible.WebTags = "";
         chkavAtt_ticketresponsableid_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketresponsableid_visible_Internalname, "TitleCaption", chkavAtt_ticketresponsableid_visible.Caption, true);
         chkavAtt_ticketresponsableid_visible.CheckedValue = "false";
         AV18Att_TicketResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_TicketResponsableId_Visible));
         AssignAttri("", false, "AV18Att_TicketResponsableId_Visible", AV18Att_TicketResponsableId_Visible);
         chkavAtt_responsablenombre_visible.Name = "vATT_RESPONSABLENOMBRE_VISIBLE";
         chkavAtt_responsablenombre_visible.WebTags = "";
         chkavAtt_responsablenombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsablenombre_visible_Internalname, "TitleCaption", chkavAtt_responsablenombre_visible.Caption, true);
         chkavAtt_responsablenombre_visible.CheckedValue = "false";
         AV20Att_ResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ResponsableNombre_Visible));
         AssignAttri("", false, "AV20Att_ResponsableNombre_Visible", AV20Att_ResponsableNombre_Visible);
         chkavAtt_usuarioid_visible.Name = "vATT_USUARIOID_VISIBLE";
         chkavAtt_usuarioid_visible.WebTags = "";
         chkavAtt_usuarioid_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarioid_visible_Internalname, "TitleCaption", chkavAtt_usuarioid_visible.Caption, true);
         chkavAtt_usuarioid_visible.CheckedValue = "false";
         AV21Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_UsuarioId_Visible));
         AssignAttri("", false, "AV21Att_UsuarioId_Visible", AV21Att_UsuarioId_Visible);
         chkavAtt_usuarionombre_visible.Name = "vATT_USUARIONOMBRE_VISIBLE";
         chkavAtt_usuarionombre_visible.WebTags = "";
         chkavAtt_usuarionombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarionombre_visible_Internalname, "TitleCaption", chkavAtt_usuarionombre_visible.Caption, true);
         chkavAtt_usuarionombre_visible.CheckedValue = "false";
         AV22Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV22Att_UsuarioNombre_Visible", AV22Att_UsuarioNombre_Visible);
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         AV23Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV23Att_UsuarioRequerimiento_Visible", AV23Att_UsuarioRequerimiento_Visible);
         chkavAtt_usuariodepartamento_visible.Name = "vATT_USUARIODEPARTAMENTO_VISIBLE";
         chkavAtt_usuariodepartamento_visible.WebTags = "";
         chkavAtt_usuariodepartamento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariodepartamento_visible_Internalname, "TitleCaption", chkavAtt_usuariodepartamento_visible.Caption, true);
         chkavAtt_usuariodepartamento_visible.CheckedValue = "false";
         AV24Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Att_UsuarioDepartamento_Visible));
         AssignAttri("", false, "AV24Att_UsuarioDepartamento_Visible", AV24Att_UsuarioDepartamento_Visible);
         chkavAtt_tickettecnicoinventarioserie_visible.Name = "vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE";
         chkavAtt_tickettecnicoinventarioserie_visible.WebTags = "";
         chkavAtt_tickettecnicoinventarioserie_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickettecnicoinventarioserie_visible_Internalname, "TitleCaption", chkavAtt_tickettecnicoinventarioserie_visible.Caption, true);
         chkavAtt_tickettecnicoinventarioserie_visible.CheckedValue = "false";
         AV25Att_TicketTecnicoInventarioSerie_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Att_TicketTecnicoInventarioSerie_Visible));
         AssignAttri("", false, "AV25Att_TicketTecnicoInventarioSerie_Visible", AV25Att_TicketTecnicoInventarioSerie_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV49GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV49GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV49GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_190_idx;
         chkTicketTecnicoInstalacion.Name = GXCCtl;
         chkTicketTecnicoInstalacion.WebTags = "";
         chkTicketTecnicoInstalacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoInstalacion.CheckedValue = "false";
         A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
         GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_190_idx;
         chkTicketTecnicoConfiguracion.Name = GXCCtl;
         chkTicketTecnicoConfiguracion.WebTags = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoConfiguracion.CheckedValue = "false";
         A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
         GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_190_idx;
         chkTicketTecnicoInternetRouter.Name = GXCCtl;
         chkTicketTecnicoInternetRouter.WebTags = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoInternetRouter.CheckedValue = "false";
         A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
         GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_190_idx;
         chkTicketTecnicoFormateo.Name = GXCCtl;
         chkTicketTecnicoFormateo.WebTags = "";
         chkTicketTecnicoFormateo.Caption = "";
         AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoFormateo.CheckedValue = "false";
         A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
         GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_190_idx;
         chkTicketTecnicoReparacion.Name = GXCCtl;
         chkTicketTecnicoReparacion.WebTags = "";
         chkTicketTecnicoReparacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoReparacion.CheckedValue = "false";
         A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
         GXCCtl = "TICKETTECNICOLIMPIEZA_" + sGXsfl_190_idx;
         chkTicketTecnicoLimpieza.Name = GXCCtl;
         chkTicketTecnicoLimpieza.WebTags = "";
         chkTicketTecnicoLimpieza.Caption = "";
         AssignProp("", false, chkTicketTecnicoLimpieza_Internalname, "TitleCaption", chkTicketTecnicoLimpieza.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoLimpieza.CheckedValue = "false";
         A75TicketTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A75TicketTecnicoLimpieza));
         GXCCtl = "TICKETTECNICOPUNTORED_" + sGXsfl_190_idx;
         chkTicketTecnicoPuntoRed.Name = GXCCtl;
         chkTicketTecnicoPuntoRed.WebTags = "";
         chkTicketTecnicoPuntoRed.Caption = "";
         AssignProp("", false, chkTicketTecnicoPuntoRed_Internalname, "TitleCaption", chkTicketTecnicoPuntoRed.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoPuntoRed.CheckedValue = "false";
         A82TicketTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A82TicketTecnicoPuntoRed));
         GXCCtl = "TICKETTECNICOCAMBIOSHARDWARE_" + sGXsfl_190_idx;
         chkTicketTecnicoCambiosHardware.Name = GXCCtl;
         chkTicketTecnicoCambiosHardware.WebTags = "";
         chkTicketTecnicoCambiosHardware.Caption = "";
         AssignProp("", false, chkTicketTecnicoCambiosHardware_Internalname, "TitleCaption", chkTicketTecnicoCambiosHardware.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCambiosHardware.CheckedValue = "false";
         A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware));
         GXCCtl = "TICKETTECNICOCOPIASRESPALDO_" + sGXsfl_190_idx;
         chkTicketTecnicoCopiasRespaldo.Name = GXCCtl;
         chkTicketTecnicoCopiasRespaldo.WebTags = "";
         chkTicketTecnicoCopiasRespaldo.Caption = "";
         AssignProp("", false, chkTicketTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkTicketTecnicoCopiasRespaldo.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCopiasRespaldo.CheckedValue = "false";
         A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo));
         GXCCtl = "TICKETTECNICORAM_" + sGXsfl_190_idx;
         chkTicketTecnicoRam.Name = GXCCtl;
         chkTicketTecnicoRam.WebTags = "";
         chkTicketTecnicoRam.Caption = "";
         AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoRam.CheckedValue = "false";
         A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
         GXCCtl = "TICKETTECNICODISCODURO_" + sGXsfl_190_idx;
         chkTicketTecnicoDiscoDuro.Name = GXCCtl;
         chkTicketTecnicoDiscoDuro.WebTags = "";
         chkTicketTecnicoDiscoDuro.Caption = "";
         AssignProp("", false, chkTicketTecnicoDiscoDuro_Internalname, "TitleCaption", chkTicketTecnicoDiscoDuro.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoDiscoDuro.CheckedValue = "false";
         A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro));
         GXCCtl = "TICKETTECNICOPROCESADOR_" + sGXsfl_190_idx;
         chkTicketTecnicoProcesador.Name = GXCCtl;
         chkTicketTecnicoProcesador.WebTags = "";
         chkTicketTecnicoProcesador.Caption = "";
         AssignProp("", false, chkTicketTecnicoProcesador_Internalname, "TitleCaption", chkTicketTecnicoProcesador.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoProcesador.CheckedValue = "false";
         A81TicketTecnicoProcesador = StringUtil.StrToBool( StringUtil.BoolToStr( A81TicketTecnicoProcesador));
         GXCCtl = "TICKETTECNICOMALETIN_" + sGXsfl_190_idx;
         chkTicketTecnicoMaletin.Name = GXCCtl;
         chkTicketTecnicoMaletin.WebTags = "";
         chkTicketTecnicoMaletin.Caption = "";
         AssignProp("", false, chkTicketTecnicoMaletin_Internalname, "TitleCaption", chkTicketTecnicoMaletin.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoMaletin.CheckedValue = "false";
         A76TicketTecnicoMaletin = StringUtil.StrToBool( StringUtil.BoolToStr( A76TicketTecnicoMaletin));
         GXCCtl = "TICKETTECNICOTONERCINTA_" + sGXsfl_190_idx;
         chkTicketTecnicoTonerCinta.Name = GXCCtl;
         chkTicketTecnicoTonerCinta.WebTags = "";
         chkTicketTecnicoTonerCinta.Caption = "";
         AssignProp("", false, chkTicketTecnicoTonerCinta_Internalname, "TitleCaption", chkTicketTecnicoTonerCinta.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoTonerCinta.CheckedValue = "false";
         A86TicketTecnicoTonerCinta = StringUtil.StrToBool( StringUtil.BoolToStr( A86TicketTecnicoTonerCinta));
         GXCCtl = "TICKETTECNICOTARJETAVIDEOEXTRA_" + sGXsfl_190_idx;
         chkTicketTecnicoTarjetaVideoExtra.Name = GXCCtl;
         chkTicketTecnicoTarjetaVideoExtra.WebTags = "";
         chkTicketTecnicoTarjetaVideoExtra.Caption = "";
         AssignProp("", false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "TitleCaption", chkTicketTecnicoTarjetaVideoExtra.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoTarjetaVideoExtra.CheckedValue = "false";
         A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra));
         GXCCtl = "TICKETTECNICOCARGADORLAPTOP_" + sGXsfl_190_idx;
         chkTicketTecnicoCargadorLaptop.Name = GXCCtl;
         chkTicketTecnicoCargadorLaptop.WebTags = "";
         chkTicketTecnicoCargadorLaptop.Caption = "";
         AssignProp("", false, chkTicketTecnicoCargadorLaptop_Internalname, "TitleCaption", chkTicketTecnicoCargadorLaptop.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCargadorLaptop.CheckedValue = "false";
         A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop));
         GXCCtl = "TICKETTECNICOCDSDVDS_" + sGXsfl_190_idx;
         chkTicketTecnicoCDsDVDs.Name = GXCCtl;
         chkTicketTecnicoCDsDVDs.WebTags = "";
         chkTicketTecnicoCDsDVDs.Caption = "";
         AssignProp("", false, chkTicketTecnicoCDsDVDs_Internalname, "TitleCaption", chkTicketTecnicoCDsDVDs.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCDsDVDs.CheckedValue = "false";
         A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs));
         GXCCtl = "TICKETTECNICOCABLEESPECIAL_" + sGXsfl_190_idx;
         chkTicketTecnicoCableEspecial.Name = GXCCtl;
         chkTicketTecnicoCableEspecial.WebTags = "";
         chkTicketTecnicoCableEspecial.Caption = "";
         AssignProp("", false, chkTicketTecnicoCableEspecial_Internalname, "TitleCaption", chkTicketTecnicoCableEspecial.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCableEspecial.CheckedValue = "false";
         A61TicketTecnicoCableEspecial = StringUtil.StrToBool( StringUtil.BoolToStr( A61TicketTecnicoCableEspecial));
         GXCCtl = "TICKETTECNICOOTROSTALLER_" + sGXsfl_190_idx;
         chkTicketTecnicoOtrosTaller.Name = GXCCtl;
         chkTicketTecnicoOtrosTaller.WebTags = "";
         chkTicketTecnicoOtrosTaller.Caption = "";
         AssignProp("", false, chkTicketTecnicoOtrosTaller_Internalname, "TitleCaption", chkTicketTecnicoOtrosTaller.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoOtrosTaller.CheckedValue = "false";
         A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller));
         GXCCtl = "TICKETTECNICOCERRADO_" + sGXsfl_190_idx;
         chkTicketTecnicoCerrado.Name = GXCCtl;
         chkTicketTecnicoCerrado.WebTags = "";
         chkTicketTecnicoCerrado.Caption = "";
         AssignProp("", false, chkTicketTecnicoCerrado_Internalname, "TitleCaption", chkTicketTecnicoCerrado.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoCerrado.CheckedValue = "false";
         A65TicketTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A65TicketTecnicoCerrado));
         GXCCtl = "TICKETTECNICOPENDIENTE_" + sGXsfl_190_idx;
         chkTicketTecnicoPendiente.Name = GXCCtl;
         chkTicketTecnicoPendiente.WebTags = "";
         chkTicketTecnicoPendiente.Caption = "";
         AssignProp("", false, chkTicketTecnicoPendiente_Internalname, "TitleCaption", chkTicketTecnicoPendiente.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoPendiente.CheckedValue = "false";
         A80TicketTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A80TicketTecnicoPendiente));
         GXCCtl = "TICKETTECNICOPASATALLER_" + sGXsfl_190_idx;
         chkTicketTecnicoPasaTaller.Name = GXCCtl;
         chkTicketTecnicoPasaTaller.WebTags = "";
         chkTicketTecnicoPasaTaller.Caption = "";
         AssignProp("", false, chkTicketTecnicoPasaTaller_Internalname, "TitleCaption", chkTicketTecnicoPasaTaller.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoPasaTaller.CheckedValue = "false";
         A79TicketTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A79TicketTecnicoPasaTaller));
         GXCCtl = "TICKETTECNICOOBSERVACION_" + sGXsfl_190_idx;
         chkTicketTecnicoObservacion.Name = GXCCtl;
         chkTicketTecnicoObservacion.WebTags = "";
         chkTicketTecnicoObservacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoObservacion_Internalname, "TitleCaption", chkTicketTecnicoObservacion.Caption, !bGXsfl_190_Refreshing);
         chkTicketTecnicoObservacion.CheckedValue = "false";
         A77TicketTecnicoObservacion = StringUtil.StrToBool( StringUtil.BoolToStr( A77TicketTecnicoObservacion));
         n77TicketTecnicoObservacion = false;
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
         lblTextblocktickettecnicofecha_Internalname = "TEXTBLOCKTICKETTECNICOFECHA";
         Tickettecnicofecha_daterangepicker_Internalname = "TICKETTECNICOFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainertickettecnicofecha_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOFECHA";
         lblTextblocktickettecnicohora_Internalname = "TEXTBLOCKTICKETTECNICOHORA";
         edtavTickettecnicohora_from_Internalname = "vTICKETTECNICOHORA_FROM";
         lblDaterangeseparator_tickettecnicohora_Internalname = "DATERANGESEPARATOR_TICKETTECNICOHORA";
         edtavTickettecnicohora_to_Internalname = "vTICKETTECNICOHORA_TO";
         divDaterangefiltermaintable_tickettecnicohora_Internalname = "DATERANGEFILTERMAINTABLE_TICKETTECNICOHORA";
         divK2btoolstable_attributecontainertickettecnicohora_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOHORA";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_tickettecnicoid_visible_Internalname = "vATT_TICKETTECNICOID_VISIBLE";
         divTickettecnicoid_gridsettingscontainer_Internalname = "TICKETTECNICOID_GRIDSETTINGSCONTAINER";
         chkavAtt_tickettecnicofecha_visible_Internalname = "vATT_TICKETTECNICOFECHA_VISIBLE";
         divTickettecnicofecha_gridsettingscontainer_Internalname = "TICKETTECNICOFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_tickettecnicohora_visible_Internalname = "vATT_TICKETTECNICOHORA_VISIBLE";
         divTickettecnicohora_gridsettingscontainer_Internalname = "TICKETTECNICOHORA_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketid_visible_Internalname = "vATT_TICKETID_VISIBLE";
         divTicketid_gridsettingscontainer_Internalname = "TICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketresponsableid_visible_Internalname = "vATT_TICKETRESPONSABLEID_VISIBLE";
         divTicketresponsableid_gridsettingscontainer_Internalname = "TICKETRESPONSABLEID_GRIDSETTINGSCONTAINER";
         chkavAtt_responsablenombre_visible_Internalname = "vATT_RESPONSABLENOMBRE_VISIBLE";
         divResponsablenombre_gridsettingscontainer_Internalname = "RESPONSABLENOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarioid_visible_Internalname = "vATT_USUARIOID_VISIBLE";
         divUsuarioid_gridsettingscontainer_Internalname = "USUARIOID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = "vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = "USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = "USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariodepartamento_visible_Internalname = "vATT_USUARIODEPARTAMENTO_VISIBLE";
         divUsuariodepartamento_gridsettingscontainer_Internalname = "USUARIODEPARTAMENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_tickettecnicoinventarioserie_visible_Internalname = "vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE";
         divTickettecnicoinventarioserie_gridsettingscontainer_Internalname = "TICKETTECNICOINVENTARIOSERIE_GRIDSETTINGSCONTAINER";
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
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID";
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA";
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA";
         edtTicketId_Internalname = "TICKETID";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtResponsableId_Internalname = "RESPONSABLEID";
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtTicketTecnicoInventarioSerie_Internalname = "TICKETTECNICOINVENTARIOSERIE";
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION";
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION";
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER";
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO";
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION";
         chkTicketTecnicoLimpieza_Internalname = "TICKETTECNICOLIMPIEZA";
         chkTicketTecnicoPuntoRed_Internalname = "TICKETTECNICOPUNTORED";
         chkTicketTecnicoCambiosHardware_Internalname = "TICKETTECNICOCAMBIOSHARDWARE";
         chkTicketTecnicoCopiasRespaldo_Internalname = "TICKETTECNICOCOPIASRESPALDO";
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM";
         chkTicketTecnicoDiscoDuro_Internalname = "TICKETTECNICODISCODURO";
         chkTicketTecnicoProcesador_Internalname = "TICKETTECNICOPROCESADOR";
         chkTicketTecnicoMaletin_Internalname = "TICKETTECNICOMALETIN";
         chkTicketTecnicoTonerCinta_Internalname = "TICKETTECNICOTONERCINTA";
         chkTicketTecnicoTarjetaVideoExtra_Internalname = "TICKETTECNICOTARJETAVIDEOEXTRA";
         chkTicketTecnicoCargadorLaptop_Internalname = "TICKETTECNICOCARGADORLAPTOP";
         chkTicketTecnicoCDsDVDs_Internalname = "TICKETTECNICOCDSDVDS";
         chkTicketTecnicoCableEspecial_Internalname = "TICKETTECNICOCABLEESPECIAL";
         chkTicketTecnicoOtrosTaller_Internalname = "TICKETTECNICOOTROSTALLER";
         chkTicketTecnicoCerrado_Internalname = "TICKETTECNICOCERRADO";
         chkTicketTecnicoPendiente_Internalname = "TICKETTECNICOPENDIENTE";
         chkTicketTecnicoPasaTaller_Internalname = "TICKETTECNICOPASATALLER";
         chkTicketTecnicoObservacion_Internalname = "TICKETTECNICOOBSERVACION";
         edtTicketTecnicoDetalle_Internalname = "TICKETTECNICODETALLE";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
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
         chkavAtt_tickettecnicoinventarioserie_visible.Caption = "Serie";
         chkavAtt_usuariodepartamento_visible.Caption = "Departamento";
         chkavAtt_usuariorequerimiento_visible.Caption = "Requerimiento";
         chkavAtt_usuarionombre_visible.Caption = "Usuario";
         chkavAtt_usuarioid_visible.Caption = "Id Usuario";
         chkavAtt_responsablenombre_visible.Caption = "Técnico";
         chkavAtt_ticketresponsableid_visible.Caption = "Id TR:";
         chkavAtt_ticketid_visible.Caption = "RST No.";
         chkavAtt_tickettecnicohora_visible.Caption = "Hora";
         chkavAtt_tickettecnicofecha_visible.Caption = "Fecha";
         chkavAtt_tickettecnicoid_visible.Caption = "Ticket Tecnico";
         edtTicketTecnicoDetalle_Jsonclick = "";
         chkTicketTecnicoObservacion.Caption = "";
         chkTicketTecnicoPasaTaller.Caption = "";
         chkTicketTecnicoPendiente.Caption = "";
         chkTicketTecnicoCerrado.Caption = "";
         chkTicketTecnicoOtrosTaller.Caption = "";
         chkTicketTecnicoCableEspecial.Caption = "";
         chkTicketTecnicoCDsDVDs.Caption = "";
         chkTicketTecnicoCargadorLaptop.Caption = "";
         chkTicketTecnicoTarjetaVideoExtra.Caption = "";
         chkTicketTecnicoTonerCinta.Caption = "";
         chkTicketTecnicoMaletin.Caption = "";
         chkTicketTecnicoProcesador.Caption = "";
         chkTicketTecnicoDiscoDuro.Caption = "";
         chkTicketTecnicoRam.Caption = "";
         chkTicketTecnicoCopiasRespaldo.Caption = "";
         chkTicketTecnicoCambiosHardware.Caption = "";
         chkTicketTecnicoPuntoRed.Caption = "";
         chkTicketTecnicoLimpieza.Caption = "";
         chkTicketTecnicoReparacion.Caption = "";
         chkTicketTecnicoFormateo.Caption = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         chkTicketTecnicoInstalacion.Caption = "";
         edtTicketTecnicoInventarioSerie_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtResponsableNombre_Jsonclick = "";
         edtResponsableId_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         edtTicketTecnicoHora_Jsonclick = "";
         edtTicketTecnicoFecha_Jsonclick = "";
         edtTicketTecnicoId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_tickettecnicoinventarioserie_visible.Enabled = 1;
         chkavAtt_usuariodepartamento_visible.Enabled = 1;
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
         chkavAtt_usuarioid_visible.Enabled = 1;
         chkavAtt_responsablenombre_visible.Enabled = 1;
         chkavAtt_ticketresponsableid_visible.Enabled = 1;
         chkavAtt_ticketid_visible.Enabled = 1;
         chkavAtt_tickettecnicohora_visible.Enabled = 1;
         chkavAtt_tickettecnicofecha_visible.Enabled = 1;
         chkavAtt_tickettecnicoid_visible.Enabled = 1;
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
         edtUsuarioNombre_Link = "";
         edtTicketTecnicoFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtTicketTecnicoInventarioSerie_Visible = -1;
         edtUsuarioDepartamento_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtUsuarioId_Visible = -1;
         edtResponsableNombre_Visible = -1;
         edtTicketResponsableId_Visible = -1;
         edtTicketId_Visible = -1;
         edtTicketTecnicoHora_Visible = -1;
         edtTicketTecnicoFecha_Visible = -1;
         edtTicketTecnicoId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavTickettecnicohora_to_Jsonclick = "";
         edtavTickettecnicohora_to_Enabled = 1;
         edtavTickettecnicohora_from_Jsonclick = "";
         edtavTickettecnicohora_from_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Ticket tecnicos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132V2',iparms:[{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282V1',iparms:[{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242V2',iparms:[{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV70UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV64FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252V2',iparms:[{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtTicketTecnicoFecha_Link',ctrl:'TICKETTECNICOFECHA',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV65DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV70UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262V1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV50RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV49GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV70UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV50RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV86Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV79AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV74Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV75Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV73TicketTecnicoFecha_IsAuthorized',fld:'vTICKETTECNICOFECHA_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV55ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketTecnicoId_Visible',ctrl:'TICKETTECNICOID',prop:'Visible'},{av:'edtTicketTecnicoFecha_Visible',ctrl:'TICKETTECNICOFECHA',prop:'Visible'},{av:'edtTicketTecnicoHora_Visible',ctrl:'TICKETTECNICOHORA',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtTicketTecnicoInventarioSerie_Visible',ctrl:'TICKETTECNICOINVENTARIOSERIE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192V2',iparms:[{av:'AV57TicketTecnicoFecha_From',fld:'vTICKETTECNICOFECHA_FROM',pic:''},{av:'AV58TicketTecnicoFecha_To',fld:'vTICKETTECNICOFECHA_TO',pic:''},{av:'AV60TicketTecnicoHora_From',fld:'vTICKETTECNICOHORA_FROM',pic:'99:99'},{av:'AV61TicketTecnicoHora_To',fld:'vTICKETTECNICOHORA_TO',pic:'99:99'},{av:'AV66K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV67OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV83Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202V2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212V2',iparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272V1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_TicketTecnicoId_Visible',fld:'vATT_TICKETTECNICOID_VISIBLE',pic:''},{av:'AV15Att_TicketTecnicoFecha_Visible',fld:'vATT_TICKETTECNICOFECHA_VISIBLE',pic:''},{av:'AV16Att_TicketTecnicoHora_Visible',fld:'vATT_TICKETTECNICOHORA_VISIBLE',pic:''},{av:'AV17Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV18Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV20Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV21Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV22Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV23Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV24Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV25Att_TicketTecnicoInventarioSerie_Visible',fld:'vATT_TICKETTECNICOINVENTARIOSERIE_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV66K2BToolsGenericSearchField = "";
         AV57TicketTecnicoFecha_From = DateTime.MinValue;
         AV60TicketTecnicoHora_From = (DateTime)(DateTime.MinValue);
         AV61TicketTecnicoHora_To = (DateTime)(DateTime.MinValue);
         AV55ClassCollection = new GxSimpleCollection<string>();
         AV58TicketTecnicoFecha_To = DateTime.MinValue;
         AV86Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV79AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV83Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV64FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV65DeletedTag = "";
         AV68GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblocktickettecnicofecha_Jsonclick = "";
         ucTickettecnicofecha_daterangepicker = new GXUserControl();
         lblTextblocktickettecnicohora_Jsonclick = "";
         lblDaterangeseparator_tickettecnicohora_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A69TicketTecnicoFecha = DateTime.MinValue;
         A71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         A30ResponsableNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A88UsuarioDepartamento = "";
         A74TicketTecnicoInventarioSerie = "";
         A97TicketTecnicoDetalle = "";
         AV74Update = "";
         AV75Delete = "";
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
         AV88Update_GXI = "";
         AV89Delete_GXI = "";
         scmdbuf = "";
         lV66K2BToolsGenericSearchField = "";
         H002V2_A97TicketTecnicoDetalle = new string[] {""} ;
         H002V2_A77TicketTecnicoObservacion = new bool[] {false} ;
         H002V2_n77TicketTecnicoObservacion = new bool[] {false} ;
         H002V2_A79TicketTecnicoPasaTaller = new bool[] {false} ;
         H002V2_A80TicketTecnicoPendiente = new bool[] {false} ;
         H002V2_A65TicketTecnicoCerrado = new bool[] {false} ;
         H002V2_A78TicketTecnicoOtrosTaller = new bool[] {false} ;
         H002V2_A61TicketTecnicoCableEspecial = new bool[] {false} ;
         H002V2_A64TicketTecnicoCDsDVDs = new bool[] {false} ;
         H002V2_A63TicketTecnicoCargadorLaptop = new bool[] {false} ;
         H002V2_A85TicketTecnicoTarjetaVideoExtra = new bool[] {false} ;
         H002V2_A86TicketTecnicoTonerCinta = new bool[] {false} ;
         H002V2_A76TicketTecnicoMaletin = new bool[] {false} ;
         H002V2_A81TicketTecnicoProcesador = new bool[] {false} ;
         H002V2_A68TicketTecnicoDiscoDuro = new bool[] {false} ;
         H002V2_A83TicketTecnicoRam = new bool[] {false} ;
         H002V2_A67TicketTecnicoCopiasRespaldo = new bool[] {false} ;
         H002V2_A62TicketTecnicoCambiosHardware = new bool[] {false} ;
         H002V2_A82TicketTecnicoPuntoRed = new bool[] {false} ;
         H002V2_A75TicketTecnicoLimpieza = new bool[] {false} ;
         H002V2_A84TicketTecnicoReparacion = new bool[] {false} ;
         H002V2_A70TicketTecnicoFormateo = new bool[] {false} ;
         H002V2_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         H002V2_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         H002V2_A72TicketTecnicoInstalacion = new bool[] {false} ;
         H002V2_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         H002V2_A88UsuarioDepartamento = new string[] {""} ;
         H002V2_A94UsuarioRequerimiento = new string[] {""} ;
         H002V2_A93UsuarioNombre = new string[] {""} ;
         H002V2_A15UsuarioId = new long[1] ;
         H002V2_A30ResponsableNombre = new string[] {""} ;
         H002V2_A6ResponsableId = new short[1] ;
         H002V2_A16TicketResponsableId = new long[1] ;
         H002V2_A14TicketId = new long[1] ;
         H002V2_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         H002V2_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         H002V2_A18TicketTecnicoId = new long[1] ;
         H002V3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV56TicketTecnicoFecha = DateTime.MinValue;
         AV59TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         AV69GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV71Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV72Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV78ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV80ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV52GridStateKey = "";
         AV53GridState = new SdtK2BGridState(context);
         AV54GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV76TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV62K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV63K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV81OutFile = "";
         AV82Guid = (Guid)(Guid.Empty);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwtickettecnico__default(),
            new Object[][] {
                new Object[] {
               H002V2_A97TicketTecnicoDetalle, H002V2_A77TicketTecnicoObservacion, H002V2_n77TicketTecnicoObservacion, H002V2_A79TicketTecnicoPasaTaller, H002V2_A80TicketTecnicoPendiente, H002V2_A65TicketTecnicoCerrado, H002V2_A78TicketTecnicoOtrosTaller, H002V2_A61TicketTecnicoCableEspecial, H002V2_A64TicketTecnicoCDsDVDs, H002V2_A63TicketTecnicoCargadorLaptop,
               H002V2_A85TicketTecnicoTarjetaVideoExtra, H002V2_A86TicketTecnicoTonerCinta, H002V2_A76TicketTecnicoMaletin, H002V2_A81TicketTecnicoProcesador, H002V2_A68TicketTecnicoDiscoDuro, H002V2_A83TicketTecnicoRam, H002V2_A67TicketTecnicoCopiasRespaldo, H002V2_A62TicketTecnicoCambiosHardware, H002V2_A82TicketTecnicoPuntoRed, H002V2_A75TicketTecnicoLimpieza,
               H002V2_A84TicketTecnicoReparacion, H002V2_A70TicketTecnicoFormateo, H002V2_A73TicketTecnicoInternetRouter, H002V2_A66TicketTecnicoConfiguracion, H002V2_A72TicketTecnicoInstalacion, H002V2_A74TicketTecnicoInventarioSerie, H002V2_A88UsuarioDepartamento, H002V2_A94UsuarioRequerimiento, H002V2_A93UsuarioNombre, H002V2_A15UsuarioId,
               H002V2_A30ResponsableNombre, H002V2_A6ResponsableId, H002V2_A16TicketResponsableId, H002V2_A14TicketId, H002V2_A71TicketTecnicoHora, H002V2_A69TicketTecnicoFecha, H002V2_A18TicketTecnicoId
               }
               , new Object[] {
               H002V3_AGRID_nRecordCount
               }
            }
         );
         AV86Pgmname = "WWTicketTecnico";
         /* GeneXus formulas. */
         AV86Pgmname = "WWTicketTecnico";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV67OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV70UC_OrderedBy ;
      private short AV50RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A6ResponsableId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV49GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_190 ;
      private int nGXsfl_190_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavTickettecnicohora_from_Enabled ;
      private int edtavTickettecnicohora_to_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTicketTecnicoId_Visible ;
      private int edtTicketTecnicoFecha_Visible ;
      private int edtTicketTecnicoHora_Visible ;
      private int edtTicketId_Visible ;
      private int edtTicketResponsableId_Visible ;
      private int edtResponsableNombre_Visible ;
      private int edtUsuarioId_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
      private int edtUsuarioDepartamento_Visible ;
      private int edtTicketTecnicoInventarioSerie_Visible ;
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
      private int AV87GXV1 ;
      private int AV90GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV91GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV92GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A18TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_190_idx="0001" ;
      private string AV66K2BToolsGenericSearchField ;
      private string AV86Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV65DeletedTag ;
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
      private string divK2btoolstable_attributecontainertickettecnicofecha_Internalname ;
      private string lblTextblocktickettecnicofecha_Internalname ;
      private string lblTextblocktickettecnicofecha_Jsonclick ;
      private string Tickettecnicofecha_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicohora_Internalname ;
      private string lblTextblocktickettecnicohora_Internalname ;
      private string lblTextblocktickettecnicohora_Jsonclick ;
      private string divDaterangefiltermaintable_tickettecnicohora_Internalname ;
      private string edtavTickettecnicohora_from_Internalname ;
      private string edtavTickettecnicohora_from_Jsonclick ;
      private string lblDaterangeseparator_tickettecnicohora_Internalname ;
      private string lblDaterangeseparator_tickettecnicohora_Jsonclick ;
      private string edtavTickettecnicohora_to_Internalname ;
      private string edtavTickettecnicohora_to_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtTicketTecnicoFecha_Link ;
      private string edtUsuarioNombre_Link ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTicketTecnicoId_Internalname ;
      private string edtTicketTecnicoFecha_Internalname ;
      private string edtTicketTecnicoHora_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtResponsableId_Internalname ;
      private string edtResponsableNombre_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtTicketTecnicoInventarioSerie_Internalname ;
      private string chkTicketTecnicoInstalacion_Internalname ;
      private string chkTicketTecnicoConfiguracion_Internalname ;
      private string chkTicketTecnicoInternetRouter_Internalname ;
      private string chkTicketTecnicoFormateo_Internalname ;
      private string chkTicketTecnicoReparacion_Internalname ;
      private string chkTicketTecnicoLimpieza_Internalname ;
      private string chkTicketTecnicoPuntoRed_Internalname ;
      private string chkTicketTecnicoCambiosHardware_Internalname ;
      private string chkTicketTecnicoCopiasRespaldo_Internalname ;
      private string chkTicketTecnicoRam_Internalname ;
      private string chkTicketTecnicoDiscoDuro_Internalname ;
      private string chkTicketTecnicoProcesador_Internalname ;
      private string chkTicketTecnicoMaletin_Internalname ;
      private string chkTicketTecnicoTonerCinta_Internalname ;
      private string chkTicketTecnicoTarjetaVideoExtra_Internalname ;
      private string chkTicketTecnicoCargadorLaptop_Internalname ;
      private string chkTicketTecnicoCDsDVDs_Internalname ;
      private string chkTicketTecnicoCableEspecial_Internalname ;
      private string chkTicketTecnicoOtrosTaller_Internalname ;
      private string chkTicketTecnicoCerrado_Internalname ;
      private string chkTicketTecnicoPendiente_Internalname ;
      private string chkTicketTecnicoPasaTaller_Internalname ;
      private string chkTicketTecnicoObservacion_Internalname ;
      private string edtTicketTecnicoDetalle_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV66K2BToolsGenericSearchField ;
      private string chkavAtt_tickettecnicoid_visible_Internalname ;
      private string chkavAtt_tickettecnicofecha_visible_Internalname ;
      private string chkavAtt_tickettecnicohora_visible_Internalname ;
      private string chkavAtt_ticketid_visible_Internalname ;
      private string chkavAtt_ticketresponsableid_visible_Internalname ;
      private string chkavAtt_responsablenombre_visible_Internalname ;
      private string chkavAtt_usuarioid_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
      private string chkavAtt_usuariodepartamento_visible_Internalname ;
      private string chkavAtt_tickettecnicoinventarioserie_visible_Internalname ;
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
      private string divTickettecnicoid_gridsettingscontainer_Internalname ;
      private string divTickettecnicofecha_gridsettingscontainer_Internalname ;
      private string divTickettecnicohora_gridsettingscontainer_Internalname ;
      private string divTicketid_gridsettingscontainer_Internalname ;
      private string divTicketresponsableid_gridsettingscontainer_Internalname ;
      private string divResponsablenombre_gridsettingscontainer_Internalname ;
      private string divUsuarioid_gridsettingscontainer_Internalname ;
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
      private string divUsuariodepartamento_gridsettingscontainer_Internalname ;
      private string divTickettecnicoinventarioserie_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_190_fel_idx="0001" ;
      private string ROClassString ;
      private string edtTicketTecnicoId_Jsonclick ;
      private string edtTicketTecnicoFecha_Jsonclick ;
      private string edtTicketTecnicoHora_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtResponsableId_Jsonclick ;
      private string edtResponsableNombre_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtUsuarioDepartamento_Jsonclick ;
      private string edtTicketTecnicoInventarioSerie_Jsonclick ;
      private string GXCCtl ;
      private string edtTicketTecnicoDetalle_Jsonclick ;
      private DateTime AV60TicketTecnicoHora_From ;
      private DateTime AV61TicketTecnicoHora_To ;
      private DateTime A71TicketTecnicoHora ;
      private DateTime AV59TicketTecnicoHora ;
      private DateTime GXt_dtime3 ;
      private DateTime AV57TicketTecnicoFecha_From ;
      private DateTime AV58TicketTecnicoFecha_To ;
      private DateTime A69TicketTecnicoFecha ;
      private DateTime AV56TicketTecnicoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV73TicketTecnicoFecha_IsAuthorized ;
      private bool AV14Att_TicketTecnicoId_Visible ;
      private bool AV15Att_TicketTecnicoFecha_Visible ;
      private bool AV16Att_TicketTecnicoHora_Visible ;
      private bool AV17Att_TicketId_Visible ;
      private bool AV18Att_TicketResponsableId_Visible ;
      private bool AV20Att_ResponsableNombre_Visible ;
      private bool AV21Att_UsuarioId_Visible ;
      private bool AV22Att_UsuarioNombre_Visible ;
      private bool AV23Att_UsuarioRequerimiento_Visible ;
      private bool AV24Att_UsuarioDepartamento_Visible ;
      private bool AV25Att_TicketTecnicoInventarioSerie_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool A72TicketTecnicoInstalacion ;
      private bool A66TicketTecnicoConfiguracion ;
      private bool A73TicketTecnicoInternetRouter ;
      private bool A70TicketTecnicoFormateo ;
      private bool A84TicketTecnicoReparacion ;
      private bool A75TicketTecnicoLimpieza ;
      private bool A82TicketTecnicoPuntoRed ;
      private bool A62TicketTecnicoCambiosHardware ;
      private bool A67TicketTecnicoCopiasRespaldo ;
      private bool A83TicketTecnicoRam ;
      private bool A68TicketTecnicoDiscoDuro ;
      private bool A81TicketTecnicoProcesador ;
      private bool A76TicketTecnicoMaletin ;
      private bool A86TicketTecnicoTonerCinta ;
      private bool A85TicketTecnicoTarjetaVideoExtra ;
      private bool A63TicketTecnicoCargadorLaptop ;
      private bool A64TicketTecnicoCDsDVDs ;
      private bool A61TicketTecnicoCableEspecial ;
      private bool A78TicketTecnicoOtrosTaller ;
      private bool A65TicketTecnicoCerrado ;
      private bool A80TicketTecnicoPendiente ;
      private bool A79TicketTecnicoPasaTaller ;
      private bool A77TicketTecnicoObservacion ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n77TicketTecnicoObservacion ;
      private bool bGXsfl_190_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV51RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV74Update_IsBlob ;
      private bool AV75Delete_IsBlob ;
      private string AV83Uri ;
      private string A30ResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A88UsuarioDepartamento ;
      private string A74TicketTecnicoInventarioSerie ;
      private string A97TicketTecnicoDetalle ;
      private string AV88Update_GXI ;
      private string AV89Delete_GXI ;
      private string AV52GridStateKey ;
      private string AV81OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV74Update ;
      private string AV75Delete ;
      private Guid AV82Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucTickettecnicofecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_tickettecnicoid_visible ;
      private GXCheckbox chkavAtt_tickettecnicofecha_visible ;
      private GXCheckbox chkavAtt_tickettecnicohora_visible ;
      private GXCheckbox chkavAtt_ticketid_visible ;
      private GXCheckbox chkavAtt_ticketresponsableid_visible ;
      private GXCheckbox chkavAtt_responsablenombre_visible ;
      private GXCheckbox chkavAtt_usuarioid_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCheckbox chkavAtt_usuariodepartamento_visible ;
      private GXCheckbox chkavAtt_tickettecnicoinventarioserie_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private GXCheckbox chkTicketTecnicoInstalacion ;
      private GXCheckbox chkTicketTecnicoConfiguracion ;
      private GXCheckbox chkTicketTecnicoInternetRouter ;
      private GXCheckbox chkTicketTecnicoFormateo ;
      private GXCheckbox chkTicketTecnicoReparacion ;
      private GXCheckbox chkTicketTecnicoLimpieza ;
      private GXCheckbox chkTicketTecnicoPuntoRed ;
      private GXCheckbox chkTicketTecnicoCambiosHardware ;
      private GXCheckbox chkTicketTecnicoCopiasRespaldo ;
      private GXCheckbox chkTicketTecnicoRam ;
      private GXCheckbox chkTicketTecnicoDiscoDuro ;
      private GXCheckbox chkTicketTecnicoProcesador ;
      private GXCheckbox chkTicketTecnicoMaletin ;
      private GXCheckbox chkTicketTecnicoTonerCinta ;
      private GXCheckbox chkTicketTecnicoTarjetaVideoExtra ;
      private GXCheckbox chkTicketTecnicoCargadorLaptop ;
      private GXCheckbox chkTicketTecnicoCDsDVDs ;
      private GXCheckbox chkTicketTecnicoCableEspecial ;
      private GXCheckbox chkTicketTecnicoOtrosTaller ;
      private GXCheckbox chkTicketTecnicoCerrado ;
      private GXCheckbox chkTicketTecnicoPendiente ;
      private GXCheckbox chkTicketTecnicoPasaTaller ;
      private GXCheckbox chkTicketTecnicoObservacion ;
      private IDataStoreProvider pr_default ;
      private string[] H002V2_A97TicketTecnicoDetalle ;
      private bool[] H002V2_A77TicketTecnicoObservacion ;
      private bool[] H002V2_n77TicketTecnicoObservacion ;
      private bool[] H002V2_A79TicketTecnicoPasaTaller ;
      private bool[] H002V2_A80TicketTecnicoPendiente ;
      private bool[] H002V2_A65TicketTecnicoCerrado ;
      private bool[] H002V2_A78TicketTecnicoOtrosTaller ;
      private bool[] H002V2_A61TicketTecnicoCableEspecial ;
      private bool[] H002V2_A64TicketTecnicoCDsDVDs ;
      private bool[] H002V2_A63TicketTecnicoCargadorLaptop ;
      private bool[] H002V2_A85TicketTecnicoTarjetaVideoExtra ;
      private bool[] H002V2_A86TicketTecnicoTonerCinta ;
      private bool[] H002V2_A76TicketTecnicoMaletin ;
      private bool[] H002V2_A81TicketTecnicoProcesador ;
      private bool[] H002V2_A68TicketTecnicoDiscoDuro ;
      private bool[] H002V2_A83TicketTecnicoRam ;
      private bool[] H002V2_A67TicketTecnicoCopiasRespaldo ;
      private bool[] H002V2_A62TicketTecnicoCambiosHardware ;
      private bool[] H002V2_A82TicketTecnicoPuntoRed ;
      private bool[] H002V2_A75TicketTecnicoLimpieza ;
      private bool[] H002V2_A84TicketTecnicoReparacion ;
      private bool[] H002V2_A70TicketTecnicoFormateo ;
      private bool[] H002V2_A73TicketTecnicoInternetRouter ;
      private bool[] H002V2_A66TicketTecnicoConfiguracion ;
      private bool[] H002V2_A72TicketTecnicoInstalacion ;
      private string[] H002V2_A74TicketTecnicoInventarioSerie ;
      private string[] H002V2_A88UsuarioDepartamento ;
      private string[] H002V2_A94UsuarioRequerimiento ;
      private string[] H002V2_A93UsuarioNombre ;
      private long[] H002V2_A15UsuarioId ;
      private string[] H002V2_A30ResponsableNombre ;
      private short[] H002V2_A6ResponsableId ;
      private long[] H002V2_A16TicketResponsableId ;
      private long[] H002V2_A14TicketId ;
      private DateTime[] H002V2_A71TicketTecnicoHora ;
      private DateTime[] H002V2_A69TicketTecnicoFecha ;
      private long[] H002V2_A18TicketTecnicoId ;
      private long[] H002V3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV55ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV62K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV64FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV68GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV71Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV79AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV78ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV53GridState ;
      private SdtK2BGridState_FilterValue AV54GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV63K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV69GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV72Message ;
      private SdtK2BTrnContext AV76TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV80ActivityListItem ;
   }

   public class wwtickettecnico__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002V2( IGxContext context ,
                                             DateTime AV58TicketTecnicoFecha_To ,
                                             DateTime AV57TicketTecnicoFecha_From ,
                                             DateTime AV61TicketTecnicoHora_To ,
                                             DateTime AV60TicketTecnicoHora_From ,
                                             string AV66K2BToolsGenericSearchField ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A30ResponsableNombre ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV67OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[TicketTecnicoDetalle], T1.[TicketTecnicoObservacion], T1.[TicketTecnicoPasaTaller], T1.[TicketTecnicoPendiente], T1.[TicketTecnicoCerrado], T1.[TicketTecnicoOtrosTaller], T1.[TicketTecnicoCableEspecial], T1.[TicketTecnicoCDsDVDs], T1.[TicketTecnicoCargadorLaptop], T1.[TicketTecnicoTarjetaVideoExtra], T1.[TicketTecnicoTonerCinta], T1.[TicketTecnicoMaletin], T1.[TicketTecnicoProcesador], T1.[TicketTecnicoDiscoDuro], T1.[TicketTecnicoRam], T1.[TicketTecnicoCopiasRespaldo], T1.[TicketTecnicoCambiosHardware], T1.[TicketTecnicoPuntoRed], T1.[TicketTecnicoLimpieza], T1.[TicketTecnicoReparacion], T1.[TicketTecnicoFormateo], T1.[TicketTecnicoInternetRouter], T1.[TicketTecnicoConfiguracion], T1.[TicketTecnicoInstalacion], T1.[TicketTecnicoInventarioSerie], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T4.[UsuarioNombre], T3.[UsuarioId], T2.[ResponsableNombre], T1.[ResponsableId], T1.[TicketResponsableId], T1.[TicketId], T1.[TicketTecnicoHora], T1.[TicketTecnicoFecha], T1.[TicketTecnicoId]";
         sFromString = " FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV58TicketTecnicoFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] <= @AV58TicketTecnicoFecha_To)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV57TicketTecnicoFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] >= @AV57TicketTecnicoFecha_From)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV61TicketTecnicoHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] <= @AV61TicketTecnicoHora_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV60TicketTecnicoHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] >= @AV60TicketTecnicoHora_From)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or T2.[ResponsableNombre] like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T3.[UsuarioId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or T4.[UsuarioNombre] like '%' + @lV66K2BToolsGenericSearchField + '%' or T4.[UsuarioRequerimiento] like '%' + @lV66K2BToolsGenericSearchField + '%' or T4.[UsuarioDepartamento] like '%' + @lV66K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV66K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
         }
         if ( AV67OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId]";
         }
         else if ( AV67OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId] DESC";
         }
         else if ( AV67OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoFecha]";
         }
         else if ( AV67OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002V3( IGxContext context ,
                                             DateTime AV58TicketTecnicoFecha_To ,
                                             DateTime AV57TicketTecnicoFecha_From ,
                                             DateTime AV61TicketTecnicoHora_To ,
                                             DateTime AV60TicketTecnicoHora_From ,
                                             string AV66K2BToolsGenericSearchField ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A30ResponsableNombre ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV67OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T4 ON T4.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV58TicketTecnicoFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] <= @AV58TicketTecnicoFecha_To)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV57TicketTecnicoFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] >= @AV57TicketTecnicoFecha_From)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV61TicketTecnicoHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] <= @AV61TicketTecnicoHora_To)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV60TicketTecnicoHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] >= @AV60TicketTecnicoHora_From)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or T4.[ResponsableNombre] like '%' + @lV66K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T2.[UsuarioId] AS decimal(10,0))) like '%' + @lV66K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV66K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV66K2BToolsGenericSearchField + '%' or T3.[UsuarioDepartamento] like '%' + @lV66K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV66K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV67OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV67OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV67OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV67OrderedBy == 3 )
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
                     return conditional_H002V2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] );
               case 1 :
                     return conditional_H002V3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmH002V2;
          prmH002V2 = new Object[] {
          new ParDef("@AV58TicketTecnicoFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV57TicketTecnicoFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV61TicketTecnicoHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV60TicketTecnicoHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002V3;
          prmH002V3 = new Object[] {
          new ParDef("@AV58TicketTecnicoFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV57TicketTecnicoFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV61TicketTecnicoHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV60TicketTecnicoHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV66K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.getBool(10);
                ((bool[]) buf[11])[0] = rslt.getBool(11);
                ((bool[]) buf[12])[0] = rslt.getBool(12);
                ((bool[]) buf[13])[0] = rslt.getBool(13);
                ((bool[]) buf[14])[0] = rslt.getBool(14);
                ((bool[]) buf[15])[0] = rslt.getBool(15);
                ((bool[]) buf[16])[0] = rslt.getBool(16);
                ((bool[]) buf[17])[0] = rslt.getBool(17);
                ((bool[]) buf[18])[0] = rslt.getBool(18);
                ((bool[]) buf[19])[0] = rslt.getBool(19);
                ((bool[]) buf[20])[0] = rslt.getBool(20);
                ((bool[]) buf[21])[0] = rslt.getBool(21);
                ((bool[]) buf[22])[0] = rslt.getBool(22);
                ((bool[]) buf[23])[0] = rslt.getBool(23);
                ((bool[]) buf[24])[0] = rslt.getBool(24);
                ((string[]) buf[25])[0] = rslt.getVarchar(25);
                ((string[]) buf[26])[0] = rslt.getVarchar(26);
                ((string[]) buf[27])[0] = rslt.getVarchar(27);
                ((string[]) buf[28])[0] = rslt.getVarchar(28);
                ((long[]) buf[29])[0] = rslt.getLong(29);
                ((string[]) buf[30])[0] = rslt.getVarchar(30);
                ((short[]) buf[31])[0] = rslt.getShort(31);
                ((long[]) buf[32])[0] = rslt.getLong(32);
                ((long[]) buf[33])[0] = rslt.getLong(33);
                ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(34);
                ((DateTime[]) buf[35])[0] = rslt.getGXDate(35);
                ((long[]) buf[36])[0] = rslt.getLong(36);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
