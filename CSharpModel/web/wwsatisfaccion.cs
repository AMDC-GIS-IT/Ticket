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
   public class wwsatisfaccion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwsatisfaccion( )
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

      public wwsatisfaccion( IGxContext context )
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
         chkavAtt_ticketresponsableid_visible = new GXCheckbox();
         chkavAtt_tickettecnicoresponsablenombre_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariofecha_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
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
               nRC_GXsfl_197 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_197"), "."));
               nGXsfl_197_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_197_idx"), "."));
               sGXsfl_197_idx = GetPar( "sGXsfl_197_idx");
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
               AV51K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV36SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
               AV39UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
               AV41SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
               AV42SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
               AV43SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
               AV44SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
               AV45SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
               AV46SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
               AV71UsuarioNombre = GetPar( "UsuarioNombre");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV34ClassCollection);
               AV52OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV37SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
               AV40UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
               AV77Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV64AutoLinksActivityList);
               AV70Att_TicketId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketId_Visible"));
               AV68Att_TicketResponsableId_Visible = StringUtil.StrToBool( GetPar( "Att_TicketResponsableId_Visible"));
               AV69Att_TicketTecnicoResponsableNombre_Visible = StringUtil.StrToBool( GetPar( "Att_TicketTecnicoResponsableNombre_Visible"));
               AV18Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
               AV19Att_UsuarioFecha_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioFecha_Visible"));
               AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV74Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
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
         PA2Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Y2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418816847", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwsatisfaccion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV51K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONFECHA_FROM", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONRESUELTONOMBRE", AV41SatisfaccionResueltoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE", AV42SatisfaccionTecnicoProblemaNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE", AV43SatisfaccionTecnicoCompetenteNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE", AV44SatisfaccionTecnicoProfesionalismoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTIEMPONOMBRE", AV45SatisfaccionTiempoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONATENCIONNOMBRE", AV46SatisfaccionAtencionNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIONOMBRE", AV71UsuarioNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_197", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_197), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV49FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV49FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV50DeletedTag));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONFECHA_TO", context.localUtil.DToC( AV37SatisfaccionFecha_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_TO", context.localUtil.DToC( AV40UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV53GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV53GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV34ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV34ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUTOLINKSACTIVITYLIST", AV64AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUTOLINKSACTIVITYLIST", AV64AutoLinksActivityList);
         }
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV74Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONFECHA_FROM", context.localUtil.DToC( AV36SatisfaccionFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_FROM", context.localUtil.DToC( AV39UsuarioFecha_From, 0, "/"));
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
            WE2Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Y2( ) ;
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
         return formatLink("wwsatisfaccion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWSatisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Satisfacciones" ;
      }

      protected void WB2Y0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Satisfacciones", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV51K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV51K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWSatisfaccion.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV49FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV50DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocksatisfaccionfecha_Internalname, "Fecha Encuesta:", "", "", lblTextblocksatisfaccionfecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* User Defined Control */
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueFrom", AV36SatisfaccionFecha_From);
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueTo", AV37SatisfaccionFecha_To);
            ucSatisfaccionfecha_daterangepicker.Render(context, "k2bdaterangepicker", Satisfaccionfecha_daterangepicker_Internalname, "SATISFACCIONFECHA_DATERANGEPICKERContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha", "", "", lblTextblockusuariofecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV39UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV40UsuarioFecha_To);
            ucUsuariofecha_daterangepicker.Render(context, "k2bdaterangepicker", Usuariofecha_daterangepicker_Internalname, "USUARIOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionresueltonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionresueltonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionresueltonombre_Internalname, AV41SatisfaccionResueltoNombre, StringUtil.RTrim( context.localUtil.Format( AV41SatisfaccionResueltoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionresueltonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionresueltonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoproblemanombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoproblemanombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoproblemanombre_Internalname, AV42SatisfaccionTecnicoProblemaNombre, StringUtil.RTrim( context.localUtil.Format( AV42SatisfaccionTecnicoProblemaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoproblemanombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoproblemanombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicocompetentenombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicocompetentenombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicocompetentenombre_Internalname, AV43SatisfaccionTecnicoCompetenteNombre, StringUtil.RTrim( context.localUtil.Format( AV43SatisfaccionTecnicoCompetenteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicocompetentenombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicocompetentenombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoprofesionalismonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, AV44SatisfaccionTecnicoProfesionalismoNombre, StringUtil.RTrim( context.localUtil.Format( AV44SatisfaccionTecnicoProfesionalismoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoprofesionalismonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname, divK2btoolstable_attributecontainersatisfacciontiemponombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontiemponombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontiemponombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontiemponombre_Internalname, AV45SatisfaccionTiempoNombre, StringUtil.RTrim( context.localUtil.Format( AV45SatisfaccionTiempoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontiemponombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontiemponombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionatencionnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionatencionnombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionatencionnombre_Internalname, AV46SatisfaccionAtencionNombre, StringUtil.RTrim( context.localUtil.Format( AV46SatisfaccionAtencionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionatencionnombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionatencionnombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_197_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV71UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV71UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWSatisfaccion.htm");
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
            wb_table1_93_2Y2( true) ;
         }
         else
         {
            wb_table1_93_2Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_93_2Y2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"197\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(80), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Fecha Encuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketResponsableId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtTicketTecnicoResponsableNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Respuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A144SatisfaccionHora, 10, 8, 0, 3, "/", ":", " "));
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
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
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A36SatisfaccionTecnicoProblemaNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A35SatisfaccionTecnicoCompetenteNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A37SatisfaccionTecnicoProfesionalismoNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A38SatisfaccionTiempoNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A31SatisfaccionAtencionNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A34SatisfaccionSugerencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV59Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV60Delete));
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
         if ( wbEnd == 197 )
         {
            wbEnd = 0;
            nRC_GXsfl_197 = (int)(nGXsfl_197_idx-1);
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
            wb_table2_226_2Y2( true) ;
         }
         else
         {
            wb_table2_226_2Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_226_2Y2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV53GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV55UC_OrderedBy);
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
         if ( wbEnd == 197 )
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

      protected void START2Y2( )
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
            Form.Meta.addItem("description", "Satisfacciones", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2Y0( ) ;
      }

      protected void WS2Y2( )
      {
         START2Y2( ) ;
         EVT2Y2( ) ;
      }

      protected void EVT2Y2( )
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
                              E112Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E132Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E142Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E152Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E162Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E172Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E182Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E212Y2 ();
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
                              nGXsfl_197_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
                              SubsflControlProps_1972( ) ;
                              A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
                              A32SatisfaccionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSatisfaccionFecha_Internalname), 0));
                              A144SatisfaccionHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSatisfaccionHora_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                              A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ".", ","));
                              A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
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
                              AV59Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.convertURL( context.PathToRelativeUrl( AV59Update))), !bGXsfl_197_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV59Update), true);
                              AV60Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV60Delete))), !bGXsfl_197_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV60Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E222Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E232Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E252Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV51K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionfecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSATISFACCIONFECHA_FROM"), 0) != AV36SatisfaccionFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariofecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 0) != AV39UsuarioFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionresueltonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONRESUELTONOMBRE"), AV41SatisfaccionResueltoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicoproblemanombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV42SatisfaccionTecnicoProblemaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicocompetentenombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV43SatisfaccionTecnicoCompetenteNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicoprofesionalismonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV44SatisfaccionTecnicoProfesionalismoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontiemponombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTIEMPONOMBRE"), AV45SatisfaccionTiempoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionatencionnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONATENCIONNOMBRE"), AV46SatisfaccionAtencionNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV71UsuarioNombre) != 0 )
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

      protected void WE2Y2( )
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

      protected void PA2Y2( )
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
         SubsflControlProps_1972( ) ;
         while ( nGXsfl_197_idx <= nRC_GXsfl_197 )
         {
            sendrow_1972( ) ;
            nGXsfl_197_idx = ((subGrid_Islastpage==1)&&(nGXsfl_197_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_197_idx+1);
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV51K2BToolsGenericSearchField ,
                                       DateTime AV36SatisfaccionFecha_From ,
                                       DateTime AV39UsuarioFecha_From ,
                                       string AV41SatisfaccionResueltoNombre ,
                                       string AV42SatisfaccionTecnicoProblemaNombre ,
                                       string AV43SatisfaccionTecnicoCompetenteNombre ,
                                       string AV44SatisfaccionTecnicoProfesionalismoNombre ,
                                       string AV45SatisfaccionTiempoNombre ,
                                       string AV46SatisfaccionAtencionNombre ,
                                       string AV71UsuarioNombre ,
                                       GxSimpleCollection<string> AV34ClassCollection ,
                                       short AV52OrderedBy ,
                                       DateTime AV37SatisfaccionFecha_To ,
                                       DateTime AV40UsuarioFecha_To ,
                                       string AV77Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV64AutoLinksActivityList ,
                                       bool AV70Att_TicketId_Visible ,
                                       bool AV68Att_TicketResponsableId_Visible ,
                                       bool AV69Att_TicketTecnicoResponsableNombre_Visible ,
                                       bool AV18Att_UsuarioNombre_Visible ,
                                       bool AV19Att_UsuarioFecha_Visible ,
                                       bool AV20Att_UsuarioRequerimiento_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV74Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232Y2 ();
         GRID_nCurrentRecord = 0;
         RF2Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SATISFACCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
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
         AV70Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV70Att_TicketId_Visible));
         AssignAttri("", false, "AV70Att_TicketId_Visible", AV70Att_TicketId_Visible);
         AV68Att_TicketResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV68Att_TicketResponsableId_Visible));
         AssignAttri("", false, "AV68Att_TicketResponsableId_Visible", AV68Att_TicketResponsableId_Visible);
         AV69Att_TicketTecnicoResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV69Att_TicketTecnicoResponsableNombre_Visible));
         AssignAttri("", false, "AV69Att_TicketTecnicoResponsableNombre_Visible", AV69Att_TicketTecnicoResponsableNombre_Visible);
         AV18Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV18Att_UsuarioNombre_Visible", AV18Att_UsuarioNombre_Visible);
         AV19Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioFecha_Visible));
         AssignAttri("", false, "AV19Att_UsuarioFecha_Visible", AV19Att_UsuarioFecha_Visible);
         AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV28GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232Y2 ();
         RF2Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV77Pgmname = "WWSatisfaccion";
         context.Gx_err = 0;
      }

      protected void RF2Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 197;
         E242Y2 ();
         nGXsfl_197_idx = 1;
         sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
         SubsflControlProps_1972( ) ;
         bGXsfl_197_Refreshing = true;
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
            SubsflControlProps_1972( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV37SatisfaccionFecha_To ,
                                                 AV36SatisfaccionFecha_From ,
                                                 AV40UsuarioFecha_To ,
                                                 AV39UsuarioFecha_From ,
                                                 AV41SatisfaccionResueltoNombre ,
                                                 AV42SatisfaccionTecnicoProblemaNombre ,
                                                 AV43SatisfaccionTecnicoCompetenteNombre ,
                                                 AV44SatisfaccionTecnicoProfesionalismoNombre ,
                                                 AV45SatisfaccionTiempoNombre ,
                                                 AV46SatisfaccionAtencionNombre ,
                                                 AV71UsuarioNombre ,
                                                 AV51K2BToolsGenericSearchField ,
                                                 A32SatisfaccionFecha ,
                                                 A90UsuarioFecha ,
                                                 A33SatisfaccionResueltoNombre ,
                                                 A36SatisfaccionTecnicoProblemaNombre ,
                                                 A35SatisfaccionTecnicoCompetenteNombre ,
                                                 A37SatisfaccionTecnicoProfesionalismoNombre ,
                                                 A38SatisfaccionTiempoNombre ,
                                                 A31SatisfaccionAtencionNombre ,
                                                 A93UsuarioNombre ,
                                                 A14TicketId ,
                                                 A16TicketResponsableId ,
                                                 A199TicketTecnicoResponsableNombre ,
                                                 A94UsuarioRequerimiento ,
                                                 AV52OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            lV41SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionResueltoNombre), "%", "");
            lV42SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTecnicoProblemaNombre), "%", "");
            lV43SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionTecnicoCompetenteNombre), "%", "");
            lV44SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV44SatisfaccionTecnicoProfesionalismoNombre), "%", "");
            lV45SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV45SatisfaccionTiempoNombre), "%", "");
            lV46SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV46SatisfaccionAtencionNombre), "%", "");
            lV71UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV71UsuarioNombre), "%", "");
            lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
            lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
            lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
            lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
            lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002Y2 */
            pr_default.execute(0, new Object[] {AV37SatisfaccionFecha_To, AV36SatisfaccionFecha_From, AV40UsuarioFecha_To, AV39UsuarioFecha_From, lV41SatisfaccionResueltoNombre, lV42SatisfaccionTecnicoProblemaNombre, lV43SatisfaccionTecnicoCompetenteNombre, lV44SatisfaccionTecnicoProfesionalismoNombre, lV45SatisfaccionTiempoNombre, lV46SatisfaccionAtencionNombre, lV71UsuarioNombre, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_197_idx = 1;
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A34SatisfaccionSugerencia = H002Y2_A34SatisfaccionSugerencia[0];
               n34SatisfaccionSugerencia = H002Y2_n34SatisfaccionSugerencia[0];
               A31SatisfaccionAtencionNombre = H002Y2_A31SatisfaccionAtencionNombre[0];
               A13SatisfaccionAtencionId = H002Y2_A13SatisfaccionAtencionId[0];
               A38SatisfaccionTiempoNombre = H002Y2_A38SatisfaccionTiempoNombre[0];
               A12SatisfaccionTiempoId = H002Y2_A12SatisfaccionTiempoId[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H002Y2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A11SatisfaccionTecnicoProfesionalismoId = H002Y2_A11SatisfaccionTecnicoProfesionalismoId[0];
               A35SatisfaccionTecnicoCompetenteNombre = H002Y2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A10SatisfaccionTecnicoCompetenteId = H002Y2_A10SatisfaccionTecnicoCompetenteId[0];
               A36SatisfaccionTecnicoProblemaNombre = H002Y2_A36SatisfaccionTecnicoProblemaNombre[0];
               A9SatisfaccionTecnicoProblemaId = H002Y2_A9SatisfaccionTecnicoProblemaId[0];
               A33SatisfaccionResueltoNombre = H002Y2_A33SatisfaccionResueltoNombre[0];
               A8SatisfaccionResueltoId = H002Y2_A8SatisfaccionResueltoId[0];
               A94UsuarioRequerimiento = H002Y2_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H002Y2_A90UsuarioFecha[0];
               A93UsuarioNombre = H002Y2_A93UsuarioNombre[0];
               A15UsuarioId = H002Y2_A15UsuarioId[0];
               A199TicketTecnicoResponsableNombre = H002Y2_A199TicketTecnicoResponsableNombre[0];
               A198TicketTecnicoResponsableId = H002Y2_A198TicketTecnicoResponsableId[0];
               A16TicketResponsableId = H002Y2_A16TicketResponsableId[0];
               A14TicketId = H002Y2_A14TicketId[0];
               A144SatisfaccionHora = H002Y2_A144SatisfaccionHora[0];
               A32SatisfaccionFecha = H002Y2_A32SatisfaccionFecha[0];
               A7SatisfaccionId = H002Y2_A7SatisfaccionId[0];
               A31SatisfaccionAtencionNombre = H002Y2_A31SatisfaccionAtencionNombre[0];
               A38SatisfaccionTiempoNombre = H002Y2_A38SatisfaccionTiempoNombre[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H002Y2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A35SatisfaccionTecnicoCompetenteNombre = H002Y2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A36SatisfaccionTecnicoProblemaNombre = H002Y2_A36SatisfaccionTecnicoProblemaNombre[0];
               A33SatisfaccionResueltoNombre = H002Y2_A33SatisfaccionResueltoNombre[0];
               A15UsuarioId = H002Y2_A15UsuarioId[0];
               A94UsuarioRequerimiento = H002Y2_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H002Y2_A90UsuarioFecha[0];
               A93UsuarioNombre = H002Y2_A93UsuarioNombre[0];
               A198TicketTecnicoResponsableId = H002Y2_A198TicketTecnicoResponsableId[0];
               A199TicketTecnicoResponsableNombre = H002Y2_A199TicketTecnicoResponsableNombre[0];
               E252Y2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 197;
            WB2Y0( ) ;
         }
         bGXsfl_197_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SATISFACCIONID"+"_"+sGXsfl_197_idx, GetSecureSignedToken( sGXsfl_197_idx, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV74Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Uri, "")), context));
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
                                              AV42SatisfaccionTecnicoProblemaNombre ,
                                              AV43SatisfaccionTecnicoCompetenteNombre ,
                                              AV44SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV45SatisfaccionTiempoNombre ,
                                              AV46SatisfaccionAtencionNombre ,
                                              AV71UsuarioNombre ,
                                              AV51K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A93UsuarioNombre ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A199TicketTecnicoResponsableNombre ,
                                              A94UsuarioRequerimiento ,
                                              AV52OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV41SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV41SatisfaccionResueltoNombre), "%", "");
         lV42SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV42SatisfaccionTecnicoProblemaNombre), "%", "");
         lV43SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV43SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV44SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV44SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV45SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV45SatisfaccionTiempoNombre), "%", "");
         lV46SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV46SatisfaccionAtencionNombre), "%", "");
         lV71UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV71UsuarioNombre), "%", "");
         lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
         lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
         lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
         lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
         lV51K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV51K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002Y3 */
         pr_default.execute(1, new Object[] {AV37SatisfaccionFecha_To, AV36SatisfaccionFecha_From, AV40UsuarioFecha_To, AV39UsuarioFecha_From, lV41SatisfaccionResueltoNombre, lV42SatisfaccionTecnicoProblemaNombre, lV43SatisfaccionTecnicoCompetenteNombre, lV44SatisfaccionTecnicoProfesionalismoNombre, lV45SatisfaccionTiempoNombre, lV46SatisfaccionAtencionNombre, lV71UsuarioNombre, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField, lV51K2BToolsGenericSearchField});
         GRID_nRecordCount = H002Y3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV77Pgmname = "WWSatisfaccion";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV49FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV53GridOrders);
            /* Read saved values. */
            nRC_GXsfl_197 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_197"), ".", ","));
            AV50DeletedTag = cgiGet( "vDELETEDTAG");
            AV36SatisfaccionFecha_From = context.localUtil.CToD( cgiGet( "vSATISFACCIONFECHA_FROM"), 0);
            AV37SatisfaccionFecha_To = context.localUtil.CToD( cgiGet( "vSATISFACCIONFECHA_TO"), 0);
            AV39UsuarioFecha_From = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_FROM"), 0);
            AV40UsuarioFecha_To = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_TO"), 0);
            AV55UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV52OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV51K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV51K2BToolsGenericSearchField", AV51K2BToolsGenericSearchField);
            AV41SatisfaccionResueltoNombre = cgiGet( edtavSatisfaccionresueltonombre_Internalname);
            AssignAttri("", false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
            AV42SatisfaccionTecnicoProblemaNombre = cgiGet( edtavSatisfacciontecnicoproblemanombre_Internalname);
            AssignAttri("", false, "AV42SatisfaccionTecnicoProblemaNombre", AV42SatisfaccionTecnicoProblemaNombre);
            AV43SatisfaccionTecnicoCompetenteNombre = cgiGet( edtavSatisfacciontecnicocompetentenombre_Internalname);
            AssignAttri("", false, "AV43SatisfaccionTecnicoCompetenteNombre", AV43SatisfaccionTecnicoCompetenteNombre);
            AV44SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtavSatisfacciontecnicoprofesionalismonombre_Internalname);
            AssignAttri("", false, "AV44SatisfaccionTecnicoProfesionalismoNombre", AV44SatisfaccionTecnicoProfesionalismoNombre);
            AV45SatisfaccionTiempoNombre = cgiGet( edtavSatisfacciontiemponombre_Internalname);
            AssignAttri("", false, "AV45SatisfaccionTiempoNombre", AV45SatisfaccionTiempoNombre);
            AV46SatisfaccionAtencionNombre = cgiGet( edtavSatisfaccionatencionnombre_Internalname);
            AssignAttri("", false, "AV46SatisfaccionAtencionNombre", AV46SatisfaccionAtencionNombre);
            AV71UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV71UsuarioNombre", AV71UsuarioNombre);
            AV70Att_TicketId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketid_visible_Internalname));
            AssignAttri("", false, "AV70Att_TicketId_Visible", AV70Att_TicketId_Visible);
            AV68Att_TicketResponsableId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ticketresponsableid_visible_Internalname));
            AssignAttri("", false, "AV68Att_TicketResponsableId_Visible", AV68Att_TicketResponsableId_Visible);
            AV69Att_TicketTecnicoResponsableNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_tickettecnicoresponsablenombre_visible_Internalname));
            AssignAttri("", false, "AV69Att_TicketTecnicoResponsableNombre_Visible", AV69Att_TicketTecnicoResponsableNombre_Visible);
            AV18Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri("", false, "AV18Att_UsuarioNombre_Visible", AV18Att_UsuarioNombre_Visible);
            AV19Att_UsuarioFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariofecha_visible_Internalname));
            AssignAttri("", false, "AV19Att_UsuarioFecha_Visible", AV19Att_UsuarioFecha_Visible);
            AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV28GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV51K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSATISFACCIONFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV36SatisfaccionFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV39UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONRESUELTONOMBRE"), AV41SatisfaccionResueltoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV42SatisfaccionTecnicoProblemaNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV43SatisfaccionTecnicoCompetenteNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV44SatisfaccionTecnicoProfesionalismoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTIEMPONOMBRE"), AV45SatisfaccionTiempoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONATENCIONNOMBRE"), AV46SatisfaccionAtencionNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV71UsuarioNombre) != 0 )
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
         E222Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV35SatisfaccionFecha = DateTime.MinValue;
         AV36SatisfaccionFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
         AV37SatisfaccionFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
         AV38UsuarioFecha = DateTime.MinValue;
         AV39UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
         AV40UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
         divK2btoolstable_attributecontainersatisfaccionresueltonombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfaccionresueltonombre_Visible), 5, 0), true);
         AV41SatisfaccionResueltoNombre = "";
         AssignAttri("", false, "AV41SatisfaccionResueltoNombre", AV41SatisfaccionResueltoNombre);
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Visible), 5, 0), true);
         AV42SatisfaccionTecnicoProblemaNombre = "";
         AssignAttri("", false, "AV42SatisfaccionTecnicoProblemaNombre", AV42SatisfaccionTecnicoProblemaNombre);
         divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Visible), 5, 0), true);
         AV43SatisfaccionTecnicoCompetenteNombre = "";
         AssignAttri("", false, "AV43SatisfaccionTecnicoCompetenteNombre", AV43SatisfaccionTecnicoCompetenteNombre);
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Visible), 5, 0), true);
         AV44SatisfaccionTecnicoProfesionalismoNombre = "";
         AssignAttri("", false, "AV44SatisfaccionTecnicoProfesionalismoNombre", AV44SatisfaccionTecnicoProfesionalismoNombre);
         divK2btoolstable_attributecontainersatisfacciontiemponombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfacciontiemponombre_Visible), 5, 0), true);
         AV45SatisfaccionTiempoNombre = "";
         AssignAttri("", false, "AV45SatisfaccionTiempoNombre", AV45SatisfaccionTiempoNombre);
         divK2btoolstable_attributecontainersatisfaccionatencionnombre_Visible = 0;
         AssignProp("", false, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfaccionatencionnombre_Visible), 5, 0), true);
         AV46SatisfaccionAtencionNombre = "";
         AssignAttri("", false, "AV46SatisfaccionAtencionNombre", AV46SatisfaccionAtencionNombre);
         AV71UsuarioNombre = "";
         AssignAttri("", false, "AV71UsuarioNombre", AV71UsuarioNombre);
         new k2bloadrowsperpage(context ).execute(  AV77Pgmname,  "Grid", out  AV29RowsPerPageVariable, out  AV30RowsPerPageLoaded) ;
         AssignAttri("", false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
         if ( ! AV30RowsPerPageLoaded )
         {
            AV29RowsPerPageVariable = 20;
            AssignAttri("", false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
         }
         AV28GridSettingsRowsPerPageVariable = AV29RowsPerPageVariable;
         AssignAttri("", false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV29RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Satisfacciones";
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
         AV53GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV54GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV54GridOrder.gxTpr_Ascendingorder = 0;
         AV54GridOrder.gxTpr_Descendingorder = 1;
         AV54GridOrder.gxTpr_Gridcolumnindex = 1;
         AV53GridOrders.Add(AV54GridOrder, 0);
         AV54GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV54GridOrder.gxTpr_Ascendingorder = 2;
         AV54GridOrder.gxTpr_Descendingorder = 3;
         AV54GridOrder.gxTpr_Gridcolumnindex = 2;
         AV53GridOrders.Add(AV54GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV56Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV56Messages = GXt_objcol_SdtMessages_Message1;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV56Messages.Count )
         {
            AV57Message = ((GeneXus.Utils.SdtMessages_Message)AV56Messages.Item(AV78GXV1));
            GX_msglist.addItem(AV57Message.gxTpr_Description);
            AV78GXV1 = (int)(AV78GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV63ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV77Pgmname;
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV63ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV59Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.convertURL( context.PathToRelativeUrl( AV59Update))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV59Update), true);
         AV79Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.convertURL( context.PathToRelativeUrl( AV59Update))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV59Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_197_Refreshing);
         AV60Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV60Delete))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV60Delete), true);
         AV80Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV60Delete))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV60Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_197_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV34ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV31GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV77Pgmname,  AV31GridStateKey, out  AV32GridState) ;
         AV52OrderedBy = AV32GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
         AV55UC_OrderedBy = AV32GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV55UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV55UC_OrderedBy), 4, 0));
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV81GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:From") == 0 )
            {
               AV36SatisfaccionFecha_From = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:To") == 0 )
            {
               AV37SatisfaccionFecha_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV39UsuarioFecha_From = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV40UsuarioFecha_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre") == 0 )
            {
               AV71UsuarioNombre = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71UsuarioNombre", AV71UsuarioNombre);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV51K2BToolsGenericSearchField = AV33GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51K2BToolsGenericSearchField", AV51K2BToolsGenericSearchField);
            }
            AV81GXV2 = (int)(AV81GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV32GridState.gxTpr_Currentpage > 0 ) && ( AV32GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV32GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV31GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV77Pgmname,  AV31GridStateKey, out  AV32GridState) ;
         AV32GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV32GridState.gxTpr_Orderedby = AV52OrderedBy;
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
         AV33GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre";
         AV33GridStateFilterValue.gxTpr_Value = AV71UsuarioNombre;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV33GridStateFilterValue.gxTpr_Value = AV51K2BToolsGenericSearchField;
         AV32GridState.gxTpr_Filtervalues.Add(AV33GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV77Pgmname,  AV31GridStateKey,  AV32GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV61TrnContext = new SdtK2BTrnContext(context);
         AV61TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV61TrnContext.gxTpr_Returnmode = "Stack";
         AV61TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV61TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV61TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV61TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV61TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV61TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "Satisfaccion",  AV61TrnContext) ;
      }

      protected void E132Y2( )
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
         edtTicketId_Visible = 1;
         AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV70Att_TicketId_Visible = true;
         AssignAttri("", false, "AV70Att_TicketId_Visible", AV70Att_TicketId_Visible);
         edtTicketResponsableId_Visible = 1;
         AssignProp("", false, edtTicketResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV68Att_TicketResponsableId_Visible = true;
         AssignAttri("", false, "AV68Att_TicketResponsableId_Visible", AV68Att_TicketResponsableId_Visible);
         edtTicketTecnicoResponsableNombre_Visible = 1;
         AssignProp("", false, edtTicketTecnicoResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV69Att_TicketTecnicoResponsableNombre_Visible = true;
         AssignAttri("", false, "AV69Att_TicketTecnicoResponsableNombre_Visible", AV69Att_TicketTecnicoResponsableNombre_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV18Att_UsuarioNombre_Visible = true;
         AssignAttri("", false, "AV18Att_UsuarioNombre_Visible", AV18Att_UsuarioNombre_Visible);
         edtUsuarioFecha_Visible = 1;
         AssignProp("", false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV19Att_UsuarioFecha_Visible = true;
         AssignAttri("", false, "AV19Att_UsuarioFecha_Visible", AV19Att_UsuarioFecha_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_197_Refreshing);
         AV20Att_UsuarioRequerimiento_Visible = true;
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV77Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV82GXV3 = 1;
         while ( AV82GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV82GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  edtTicketId_Visible = 0;
                  AssignProp("", false, edtTicketId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketId_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV70Att_TicketId_Visible = false;
                  AssignAttri("", false, "AV70Att_TicketId_Visible", AV70Att_TicketId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  edtTicketResponsableId_Visible = 0;
                  AssignProp("", false, edtTicketResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV68Att_TicketResponsableId_Visible = false;
                  AssignAttri("", false, "AV68Att_TicketResponsableId_Visible", AV68Att_TicketResponsableId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoResponsableNombre") == 0 )
               {
                  edtTicketTecnicoResponsableNombre_Visible = 0;
                  AssignProp("", false, edtTicketTecnicoResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV69Att_TicketTecnicoResponsableNombre_Visible = false;
                  AssignAttri("", false, "AV69Att_TicketTecnicoResponsableNombre_Visible", AV69Att_TicketTecnicoResponsableNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV18Att_UsuarioNombre_Visible = false;
                  AssignAttri("", false, "AV18Att_UsuarioNombre_Visible", AV18Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  edtUsuarioFecha_Visible = 0;
                  AssignProp("", false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV19Att_UsuarioFecha_Visible = false;
                  AssignAttri("", false, "AV19Att_UsuarioFecha_Visible", AV19Att_UsuarioFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_197_Refreshing);
                  AV20Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
               }
            }
            AV82GXV3 = (int)(AV82GXV3+1);
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
         AV13GridColumn.gxTpr_Attributename = "TicketResponsableId";
         AV13GridColumn.gxTpr_Columntitle = "Id TR:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "TicketTecnicoResponsableNombre";
         AV13GridColumn.gxTpr_Columntitle = "Técnico";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV13GridColumn.gxTpr_Columntitle = "Usuario";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV13GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV13GridColumn.gxTpr_Columntitle = "Requerimiento";
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
         AV63ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWSatisfaccion";
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWSatisfaccion";
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV63ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV63ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerSatisfaccion";
         AV63ActivityList.Add(AV65ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV63ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_197_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_197_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV63ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_197_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_197_Refreshing);
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

      protected void E242Y2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV34ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV59Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.convertURL( context.PathToRelativeUrl( AV59Update))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV59Update), true);
         AV79Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.convertURL( context.PathToRelativeUrl( AV59Update))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV59Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_197_Refreshing);
         AV60Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV60Delete))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV60Delete), true);
         AV80Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV60Delete))), !bGXsfl_197_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV60Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_197_Refreshing);
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
         AV64AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV65ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV64AutoLinksActivityList.Add(AV65ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV64AutoLinksActivityList) ;
         AV55UC_OrderedBy = AV52OrderedBy;
         AssignAttri("", false, "AV55UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV55UC_OrderedBy), 4, 0));
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
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64AutoLinksActivityList", AV64AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49FilterTags", AV49FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E252Y2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV64AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
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
            wbStart = 197;
         }
         sendrow_1972( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_197_Refreshing )
         {
            context.DoAjaxLoad(197, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV47K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) || ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AV48K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV48K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionFecha";
            AV48K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Encuesta:";
            AV48K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV48K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV48K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36SatisfaccionFecha_From ) ;
            AV48K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37SatisfaccionFecha_To ) ;
            AV48K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV47K2BFilterValuesSDT.Add(AV48K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) || ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AV48K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV48K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV48K2BFilterValuesSDTItem.gxTpr_Description = "Fecha";
            AV48K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV48K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV48K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39UsuarioFecha_From ) ;
            AV48K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40UsuarioFecha_To ) ;
            AV48K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV47K2BFilterValuesSDT.Add(AV48K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71UsuarioNombre)) )
         {
            AV48K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV48K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioNombre";
            AV48K2BFilterValuesSDTItem.gxTpr_Description = "Usuario";
            AV48K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV48K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV48K2BFilterValuesSDTItem.gxTpr_Value = AV71UsuarioNombre;
            AV48K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV71UsuarioNombre;
            AV47K2BFilterValuesSDT.Add(AV48K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV47K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV49FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV77Pgmname,  "Grid",  AV47K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV49FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112Y2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV50DeletedTag, "SatisfaccionFecha") == 0 )
         {
            AV36SatisfaccionFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV36SatisfaccionFecha_From", context.localUtil.Format(AV36SatisfaccionFecha_From, "99/99/9999"));
            AV37SatisfaccionFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV37SatisfaccionFecha_To", context.localUtil.Format(AV37SatisfaccionFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV50DeletedTag, "UsuarioFecha") == 0 )
         {
            AV39UsuarioFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV39UsuarioFecha_From", context.localUtil.Format(AV39UsuarioFecha_From, "99/99/9999"));
            AV40UsuarioFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV40UsuarioFecha_To", context.localUtil.Format(AV40UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV50DeletedTag, "UsuarioNombre") == 0 )
         {
            AV71UsuarioNombre = "";
            AssignAttri("", false, "AV71UsuarioNombre", AV71UsuarioNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E122Y2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV52OrderedBy = AV55UC_OrderedBy;
         AssignAttri("", false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E142Y2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV77Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV83GXV4 = 1;
         while ( AV83GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV83GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV70Att_TicketId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV68Att_TicketResponsableId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "TicketTecnicoResponsableNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV69Att_TicketTecnicoResponsableNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV19Att_UsuarioFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_UsuarioRequerimiento_Visible;
            }
            AV83GXV4 = (int)(AV83GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV77Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV55UC_OrderedBy = AV52OrderedBy;
         AssignAttri("", false, "AV55UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV55UC_OrderedBy), 4, 0));
         if ( AV29RowsPerPageVariable != AV28GridSettingsRowsPerPageVariable )
         {
            AV29RowsPerPageVariable = AV28GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV29RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV29RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV29RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV77Pgmname,  "Grid",  AV29RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV51K2BToolsGenericSearchField, AV36SatisfaccionFecha_From, AV39UsuarioFecha_From, AV41SatisfaccionResueltoNombre, AV42SatisfaccionTecnicoProblemaNombre, AV43SatisfaccionTecnicoCompetenteNombre, AV44SatisfaccionTecnicoProfesionalismoNombre, AV45SatisfaccionTiempoNombre, AV46SatisfaccionAtencionNombre, AV71UsuarioNombre, AV34ClassCollection, AV52OrderedBy, AV37SatisfaccionFecha_To, AV40UsuarioFecha_To, AV77Pgmname, AV8CurrentPage, AV10GridConfiguration, AV64AutoLinksActivityList, AV70Att_TicketId_Visible, AV68Att_TicketResponsableId_Visible, AV69Att_TicketTecnicoResponsableNombre_Visible, AV18Att_UsuarioNombre_Visible, AV19Att_UsuarioFecha_Visible, AV20Att_UsuarioRequerimiento_Visible, AV11FreezeColumnTitles, AV74Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
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

      protected void E152Y2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E162Y2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E172Y2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
      }

      protected void E182Y2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ClassCollection", AV34ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV77Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV34ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV34ClassCollection) ;
         }
      }

      protected void E192Y2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "ExportWWSatisfaccion") )
         {
            new exportwwsatisfaccion(context ).execute(  AV36SatisfaccionFecha_From,  AV37SatisfaccionFecha_To,  AV39UsuarioFecha_From,  AV40UsuarioFecha_To,  AV41SatisfaccionResueltoNombre,  AV42SatisfaccionTecnicoProblemaNombre,  AV43SatisfaccionTecnicoCompetenteNombre,  AV44SatisfaccionTecnicoProfesionalismoNombre,  AV45SatisfaccionTiempoNombre,  AV46SatisfaccionAtencionNombre,  AV71UsuarioNombre,  AV51K2BToolsGenericSearchField,  AV52OrderedBy, out  AV72OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV72OutFile, out  AV74Uri) )
            {
               CallWebObject(formatLink(AV74Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV73Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV73Guid.ToString(),  AV72OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV73Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202Y2( )
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

      protected void E212Y2( )
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

      protected void wb_table2_226_2Y2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_226_2Y2e( true) ;
         }
         else
         {
            wb_table2_226_2Y2e( false) ;
         }
      }

      protected void wb_table1_93_2Y2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e262y1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWSatisfaccion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketid_visible_Internalname, StringUtil.BoolToStr( AV70Att_TicketId_Visible), "", "RST No.", 1, chkavAtt_ticketid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(122, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,122);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ticketresponsableid_visible_Internalname, StringUtil.BoolToStr( AV68Att_TicketResponsableId_Visible), "", "Id TR:", 1, chkavAtt_ticketresponsableid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(128, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
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
            GxWebStd.gx_div_start( context, divTickettecnicoresponsablenombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_tickettecnicoresponsablenombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_tickettecnicoresponsablenombre_visible_Internalname, "Técnico", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_tickettecnicoresponsablenombre_visible_Internalname, StringUtil.BoolToStr( AV69Att_TicketTecnicoResponsableNombre_Visible), "", "Técnico", 1, chkavAtt_tickettecnicoresponsablenombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioNombre_Visible), "", "Usuario", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(140, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,140);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariofecha_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioFecha_Visible), "", "Fecha Inicio:", 1, chkavAtt_usuariofecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(146, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,146);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible), "", "Requerimiento", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(152, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,152);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_197_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "", true, 1, "HLP_WWSatisfaccion.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_197_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(164, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,164);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e272y1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWSatisfaccion.htm");
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
            wb_table3_178_2Y2( true) ;
         }
         else
         {
            wb_table3_178_2Y2( false) ;
         }
         return  ;
      }

      protected void wb_table3_178_2Y2e( bool wbgen )
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
            wb_table4_185_2Y2( true) ;
         }
         else
         {
            wb_table4_185_2Y2( false) ;
         }
         return  ;
      }

      protected void wb_table4_185_2Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_93_2Y2e( true) ;
         }
         else
         {
            wb_table1_93_2Y2e( false) ;
         }
      }

      protected void wb_table4_185_2Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_185_2Y2e( true) ;
         }
         else
         {
            wb_table4_185_2Y2e( false) ;
         }
      }

      protected void wb_table3_178_2Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e282y1_client"+"'", TempTags, "", 2, "HLP_WWSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(197), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_178_2Y2e( true) ;
         }
         else
         {
            wb_table3_178_2Y2e( false) ;
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
         PA2Y2( ) ;
         WS2Y2( ) ;
         WE2Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188162011", true, true);
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
         context.AddJavascriptSource("wwsatisfaccion.js", "?2024188162012", false, true);
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

      protected void SubsflControlProps_1972( )
      {
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_197_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_197_idx;
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA_"+sGXsfl_197_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_197_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_197_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_197_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_197_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_197_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_197_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_197_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_197_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_197_idx;
         edtSatisfaccionResueltoNombre_Internalname = "SATISFACCIONRESUELTONOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = "SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = "SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_197_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = "SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionTiempoId_Internalname = "SATISFACCIONTIEMPOID_"+sGXsfl_197_idx;
         edtSatisfaccionTiempoNombre_Internalname = "SATISFACCIONTIEMPONOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionAtencionId_Internalname = "SATISFACCIONATENCIONID_"+sGXsfl_197_idx;
         edtSatisfaccionAtencionNombre_Internalname = "SATISFACCIONATENCIONNOMBRE_"+sGXsfl_197_idx;
         edtSatisfaccionSugerencia_Internalname = "SATISFACCIONSUGERENCIA_"+sGXsfl_197_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_197_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_197_idx;
      }

      protected void SubsflControlProps_fel_1972( )
      {
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_197_fel_idx;
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA_"+sGXsfl_197_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_197_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_197_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_197_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_197_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_197_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_197_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_197_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_197_fel_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionResueltoNombre_Internalname = "SATISFACCIONRESUELTONOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = "SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = "SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = "SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTiempoId_Internalname = "SATISFACCIONTIEMPOID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionTiempoNombre_Internalname = "SATISFACCIONTIEMPONOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionAtencionId_Internalname = "SATISFACCIONATENCIONID_"+sGXsfl_197_fel_idx;
         edtSatisfaccionAtencionNombre_Internalname = "SATISFACCIONATENCIONNOMBRE_"+sGXsfl_197_fel_idx;
         edtSatisfaccionSugerencia_Internalname = "SATISFACCIONSUGERENCIA_"+sGXsfl_197_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_197_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_197_fel_idx;
      }

      protected void sendrow_1972( )
      {
         SubsflControlProps_1972( ) ;
         WB2Y0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_197_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_197_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_197_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionFecha_Internalname,context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"),context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionHora_Internalname,context.localUtil.TToC( A144SatisfaccionHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A144SatisfaccionHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtTicketResponsableId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketResponsableId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtTicketTecnicoResponsableNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtTicketTecnicoResponsableNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoNombre_Internalname,(string)A33SatisfaccionResueltoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SatisfaccionTecnicoProblemaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaNombre_Internalname,(string)A36SatisfaccionTecnicoProblemaNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteNombre_Internalname,(string)A35SatisfaccionTecnicoCompetenteNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoNombre_Internalname,(string)A37SatisfaccionTecnicoProfesionalismoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12SatisfaccionTiempoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoNombre_Internalname,(string)A38SatisfaccionTiempoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SatisfaccionAtencionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionNombre_Internalname,(string)A31SatisfaccionAtencionNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionSugerencia_Internalname,(string)A34SatisfaccionSugerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionSugerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)197,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV59Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV59Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV79Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV59Update)) ? AV79Update_GXI : context.PathToRelativeUrl( AV59Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV59Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV60Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV80Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete)) ? AV80Delete_GXI : context.PathToRelativeUrl( AV60Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV60Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2Y2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_197_idx = ((subGrid_Islastpage==1)&&(nGXsfl_197_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_197_idx+1);
            sGXsfl_197_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_197_idx), 4, 0), 4, "0");
            SubsflControlProps_1972( ) ;
         }
         /* End function sendrow_1972 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_ticketid_visible.Name = "vATT_TICKETID_VISIBLE";
         chkavAtt_ticketid_visible.WebTags = "";
         chkavAtt_ticketid_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketid_visible_Internalname, "TitleCaption", chkavAtt_ticketid_visible.Caption, true);
         chkavAtt_ticketid_visible.CheckedValue = "false";
         AV70Att_TicketId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV70Att_TicketId_Visible));
         AssignAttri("", false, "AV70Att_TicketId_Visible", AV70Att_TicketId_Visible);
         chkavAtt_ticketresponsableid_visible.Name = "vATT_TICKETRESPONSABLEID_VISIBLE";
         chkavAtt_ticketresponsableid_visible.WebTags = "";
         chkavAtt_ticketresponsableid_visible.Caption = "";
         AssignProp("", false, chkavAtt_ticketresponsableid_visible_Internalname, "TitleCaption", chkavAtt_ticketresponsableid_visible.Caption, true);
         chkavAtt_ticketresponsableid_visible.CheckedValue = "false";
         AV68Att_TicketResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV68Att_TicketResponsableId_Visible));
         AssignAttri("", false, "AV68Att_TicketResponsableId_Visible", AV68Att_TicketResponsableId_Visible);
         chkavAtt_tickettecnicoresponsablenombre_visible.Name = "vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE";
         chkavAtt_tickettecnicoresponsablenombre_visible.WebTags = "";
         chkavAtt_tickettecnicoresponsablenombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_tickettecnicoresponsablenombre_visible_Internalname, "TitleCaption", chkavAtt_tickettecnicoresponsablenombre_visible.Caption, true);
         chkavAtt_tickettecnicoresponsablenombre_visible.CheckedValue = "false";
         AV69Att_TicketTecnicoResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV69Att_TicketTecnicoResponsableNombre_Visible));
         AssignAttri("", false, "AV69Att_TicketTecnicoResponsableNombre_Visible", AV69Att_TicketTecnicoResponsableNombre_Visible);
         chkavAtt_usuarionombre_visible.Name = "vATT_USUARIONOMBRE_VISIBLE";
         chkavAtt_usuarionombre_visible.WebTags = "";
         chkavAtt_usuarionombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarionombre_visible_Internalname, "TitleCaption", chkavAtt_usuarionombre_visible.Caption, true);
         chkavAtt_usuarionombre_visible.CheckedValue = "false";
         AV18Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV18Att_UsuarioNombre_Visible", AV18Att_UsuarioNombre_Visible);
         chkavAtt_usuariofecha_visible.Name = "vATT_USUARIOFECHA_VISIBLE";
         chkavAtt_usuariofecha_visible.WebTags = "";
         chkavAtt_usuariofecha_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariofecha_visible_Internalname, "TitleCaption", chkavAtt_usuariofecha_visible.Caption, true);
         chkavAtt_usuariofecha_visible.CheckedValue = "false";
         AV19Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioFecha_Visible));
         AssignAttri("", false, "AV19Att_UsuarioFecha_Visible", AV19Att_UsuarioFecha_Visible);
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV28GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV28GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV28GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
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
         lblTextblocksatisfaccionfecha_Internalname = "TEXTBLOCKSATISFACCIONFECHA";
         Satisfaccionfecha_daterangepicker_Internalname = "SATISFACCIONFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainersatisfaccionfecha_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONFECHA";
         lblTextblockusuariofecha_Internalname = "TEXTBLOCKUSUARIOFECHA";
         Usuariofecha_daterangepicker_Internalname = "USUARIOFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainerusuariofecha_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOFECHA";
         edtavSatisfaccionresueltonombre_Internalname = "vSATISFACCIONRESUELTONOMBRE";
         divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONRESUELTONOMBRE";
         edtavSatisfacciontecnicoproblemanombre_Internalname = "vSATISFACCIONTECNICOPROBLEMANOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROBLEMANOMBRE";
         edtavSatisfacciontecnicocompetentenombre_Internalname = "vSATISFACCIONTECNICOCOMPETENTENOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOCOMPETENTENOMBRE";
         edtavSatisfacciontecnicoprofesionalismonombre_Internalname = "vSATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         edtavSatisfacciontiemponombre_Internalname = "vSATISFACCIONTIEMPONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTIEMPONOMBRE";
         edtavSatisfaccionatencionnombre_Internalname = "vSATISFACCIONATENCIONNOMBRE";
         divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONATENCIONNOMBRE";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_ticketid_visible_Internalname = "vATT_TICKETID_VISIBLE";
         divTicketid_gridsettingscontainer_Internalname = "TICKETID_GRIDSETTINGSCONTAINER";
         chkavAtt_ticketresponsableid_visible_Internalname = "vATT_TICKETRESPONSABLEID_VISIBLE";
         divTicketresponsableid_gridsettingscontainer_Internalname = "TICKETRESPONSABLEID_GRIDSETTINGSCONTAINER";
         chkavAtt_tickettecnicoresponsablenombre_visible_Internalname = "vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE";
         divTickettecnicoresponsablenombre_gridsettingscontainer_Internalname = "TICKETTECNICORESPONSABLENOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = "vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = "USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariofecha_visible_Internalname = "vATT_USUARIOFECHA_VISIBLE";
         divUsuariofecha_gridsettingscontainer_Internalname = "USUARIOFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = "USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
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
         edtSatisfaccionId_Internalname = "SATISFACCIONID";
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA";
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA";
         edtTicketId_Internalname = "TICKETID";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID";
         edtSatisfaccionResueltoNombre_Internalname = "SATISFACCIONRESUELTONOMBRE";
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID";
         edtSatisfaccionTecnicoProblemaNombre_Internalname = "SATISFACCIONTECNICOPROBLEMANOMBRE";
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID";
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = "SATISFACCIONTECNICOCOMPETENTENOMBRE";
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOID";
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = "SATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         edtSatisfaccionTiempoId_Internalname = "SATISFACCIONTIEMPOID";
         edtSatisfaccionTiempoNombre_Internalname = "SATISFACCIONTIEMPONOMBRE";
         edtSatisfaccionAtencionId_Internalname = "SATISFACCIONATENCIONID";
         edtSatisfaccionAtencionNombre_Internalname = "SATISFACCIONATENCIONNOMBRE";
         edtSatisfaccionSugerencia_Internalname = "SATISFACCIONSUGERENCIA";
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
         chkavAtt_usuariorequerimiento_visible.Caption = "Requerimiento";
         chkavAtt_usuariofecha_visible.Caption = "Fecha Inicio:";
         chkavAtt_usuarionombre_visible.Caption = "Usuario";
         chkavAtt_tickettecnicoresponsablenombre_visible.Caption = "Técnico";
         chkavAtt_ticketresponsableid_visible.Caption = "Id TR:";
         chkavAtt_ticketid_visible.Caption = "RST No.";
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
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         edtSatisfaccionHora_Jsonclick = "";
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
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuariofecha_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
         chkavAtt_tickettecnicoresponsablenombre_visible.Enabled = 1;
         chkavAtt_ticketresponsableid_visible.Enabled = 1;
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
         edtUsuarioNombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioFecha_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtTicketTecnicoResponsableNombre_Visible = -1;
         edtTicketResponsableId_Visible = -1;
         edtTicketId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 1;
         edtavSatisfaccionatencionnombre_Jsonclick = "";
         edtavSatisfaccionatencionnombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfaccionatencionnombre_Visible = 1;
         edtavSatisfacciontiemponombre_Jsonclick = "";
         edtavSatisfacciontiemponombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfacciontiemponombre_Visible = 1;
         edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick = "";
         edtavSatisfacciontecnicoprofesionalismonombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Visible = 1;
         edtavSatisfacciontecnicocompetentenombre_Jsonclick = "";
         edtavSatisfacciontecnicocompetentenombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Visible = 1;
         edtavSatisfacciontecnicoproblemanombre_Jsonclick = "";
         edtavSatisfacciontecnicoproblemanombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Visible = 1;
         edtavSatisfaccionresueltonombre_Jsonclick = "";
         edtavSatisfaccionresueltonombre_Enabled = 1;
         divK2btoolstable_attributecontainersatisfaccionresueltonombre_Visible = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Satisfacciones";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132Y2',iparms:[{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282Y1',iparms:[{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242Y2',iparms:[{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV55UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV49FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252Y2',iparms:[{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV50DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV55UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262Y1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV29RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV28GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV29RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV64AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV59Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV60Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV34ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtTicketId_Visible',ctrl:'TICKETID',prop:'Visible'},{av:'edtTicketResponsableId_Visible',ctrl:'TICKETRESPONSABLEID',prop:'Visible'},{av:'edtTicketTecnicoResponsableNombre_Visible',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192Y2',iparms:[{av:'AV36SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV37SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV39UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV40UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV41SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV42SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV43SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV44SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV45SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV46SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV71UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV51K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV52OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV74Uri',fld:'vURI',pic:'',hsh:true},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202Y2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212Y2',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272Y1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETRESPONSABLEID","{handler:'Valid_Ticketresponsableid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETRESPONSABLEID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID","{handler:'Valid_Satisfaccionresueltoid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID","{handler:'Valid_Satisfacciontecnicoproblemaid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID","{handler:'Valid_Satisfacciontecnicocompetenteid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID","{handler:'Valid_Satisfacciontecnicoprofesionalismoid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID","{handler:'Valid_Satisfacciontiempoid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONATENCIONID","{handler:'Valid_Satisfaccionatencionid',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONATENCIONID",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV70Att_TicketId_Visible',fld:'vATT_TICKETID_VISIBLE',pic:''},{av:'AV68Att_TicketResponsableId_Visible',fld:'vATT_TICKETRESPONSABLEID_VISIBLE',pic:''},{av:'AV69Att_TicketTecnicoResponsableNombre_Visible',fld:'vATT_TICKETTECNICORESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV18Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV19Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV51K2BToolsGenericSearchField = "";
         AV36SatisfaccionFecha_From = DateTime.MinValue;
         AV39UsuarioFecha_From = DateTime.MinValue;
         AV41SatisfaccionResueltoNombre = "";
         AV42SatisfaccionTecnicoProblemaNombre = "";
         AV43SatisfaccionTecnicoCompetenteNombre = "";
         AV44SatisfaccionTecnicoProfesionalismoNombre = "";
         AV45SatisfaccionTiempoNombre = "";
         AV46SatisfaccionAtencionNombre = "";
         AV71UsuarioNombre = "";
         AV34ClassCollection = new GxSimpleCollection<string>();
         AV37SatisfaccionFecha_To = DateTime.MinValue;
         AV40UsuarioFecha_To = DateTime.MinValue;
         AV77Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV64AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV74Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV49FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV50DeletedTag = "";
         AV53GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblocksatisfaccionfecha_Jsonclick = "";
         ucSatisfaccionfecha_daterangepicker = new GXUserControl();
         lblTextblockusuariofecha_Jsonclick = "";
         ucUsuariofecha_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A32SatisfaccionFecha = DateTime.MinValue;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         A199TicketTecnicoResponsableNombre = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A94UsuarioRequerimiento = "";
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A34SatisfaccionSugerencia = "";
         AV59Update = "";
         AV60Delete = "";
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
         AV79Update_GXI = "";
         AV80Delete_GXI = "";
         scmdbuf = "";
         lV41SatisfaccionResueltoNombre = "";
         lV42SatisfaccionTecnicoProblemaNombre = "";
         lV43SatisfaccionTecnicoCompetenteNombre = "";
         lV44SatisfaccionTecnicoProfesionalismoNombre = "";
         lV45SatisfaccionTiempoNombre = "";
         lV46SatisfaccionAtencionNombre = "";
         lV71UsuarioNombre = "";
         lV51K2BToolsGenericSearchField = "";
         H002Y2_A34SatisfaccionSugerencia = new string[] {""} ;
         H002Y2_n34SatisfaccionSugerencia = new bool[] {false} ;
         H002Y2_A31SatisfaccionAtencionNombre = new string[] {""} ;
         H002Y2_A13SatisfaccionAtencionId = new short[1] ;
         H002Y2_A38SatisfaccionTiempoNombre = new string[] {""} ;
         H002Y2_A12SatisfaccionTiempoId = new short[1] ;
         H002Y2_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         H002Y2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         H002Y2_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         H002Y2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         H002Y2_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         H002Y2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         H002Y2_A33SatisfaccionResueltoNombre = new string[] {""} ;
         H002Y2_A8SatisfaccionResueltoId = new short[1] ;
         H002Y2_A94UsuarioRequerimiento = new string[] {""} ;
         H002Y2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H002Y2_A93UsuarioNombre = new string[] {""} ;
         H002Y2_A15UsuarioId = new long[1] ;
         H002Y2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H002Y2_A198TicketTecnicoResponsableId = new short[1] ;
         H002Y2_A16TicketResponsableId = new long[1] ;
         H002Y2_A14TicketId = new long[1] ;
         H002Y2_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         H002Y2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         H002Y2_A7SatisfaccionId = new long[1] ;
         H002Y3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV35SatisfaccionFecha = DateTime.MinValue;
         AV38UsuarioFecha = DateTime.MinValue;
         AV54GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV56Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV57Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV63ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV65ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV31GridStateKey = "";
         AV32GridState = new SdtK2BGridState(context);
         AV33GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV61TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV47K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV48K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV72OutFile = "";
         AV73Guid = (Guid)(Guid.Empty);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               H002Y2_A34SatisfaccionSugerencia, H002Y2_n34SatisfaccionSugerencia, H002Y2_A31SatisfaccionAtencionNombre, H002Y2_A13SatisfaccionAtencionId, H002Y2_A38SatisfaccionTiempoNombre, H002Y2_A12SatisfaccionTiempoId, H002Y2_A37SatisfaccionTecnicoProfesionalismoNombre, H002Y2_A11SatisfaccionTecnicoProfesionalismoId, H002Y2_A35SatisfaccionTecnicoCompetenteNombre, H002Y2_A10SatisfaccionTecnicoCompetenteId,
               H002Y2_A36SatisfaccionTecnicoProblemaNombre, H002Y2_A9SatisfaccionTecnicoProblemaId, H002Y2_A33SatisfaccionResueltoNombre, H002Y2_A8SatisfaccionResueltoId, H002Y2_A94UsuarioRequerimiento, H002Y2_A90UsuarioFecha, H002Y2_A93UsuarioNombre, H002Y2_A15UsuarioId, H002Y2_A199TicketTecnicoResponsableNombre, H002Y2_A198TicketTecnicoResponsableId,
               H002Y2_A16TicketResponsableId, H002Y2_A14TicketId, H002Y2_A144SatisfaccionHora, H002Y2_A32SatisfaccionFecha, H002Y2_A7SatisfaccionId
               }
               , new Object[] {
               H002Y3_AGRID_nRecordCount
               }
            }
         );
         AV77Pgmname = "WWSatisfaccion";
         /* GeneXus formulas. */
         AV77Pgmname = "WWSatisfaccion";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV52OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV55UC_OrderedBy ;
      private short AV29RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A198TicketTecnicoResponsableId ;
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
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV28GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_197 ;
      private int nGXsfl_197_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int divK2btoolstable_attributecontainersatisfaccionresueltonombre_Visible ;
      private int edtavSatisfaccionresueltonombre_Enabled ;
      private int divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Visible ;
      private int edtavSatisfacciontecnicoproblemanombre_Enabled ;
      private int divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Visible ;
      private int edtavSatisfacciontecnicocompetentenombre_Enabled ;
      private int divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Visible ;
      private int edtavSatisfacciontecnicoprofesionalismonombre_Enabled ;
      private int divK2btoolstable_attributecontainersatisfacciontiemponombre_Visible ;
      private int edtavSatisfacciontiemponombre_Enabled ;
      private int divK2btoolstable_attributecontainersatisfaccionatencionnombre_Visible ;
      private int edtavSatisfaccionatencionnombre_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtTicketId_Visible ;
      private int edtTicketResponsableId_Visible ;
      private int edtTicketTecnicoResponsableNombre_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioFecha_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
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
      private int AV78GXV1 ;
      private int AV81GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV82GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV83GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_197_idx="0001" ;
      private string AV51K2BToolsGenericSearchField ;
      private string AV77Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV50DeletedTag ;
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
      private string edtSatisfaccionId_Internalname ;
      private string edtSatisfaccionFecha_Internalname ;
      private string edtSatisfaccionHora_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
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
      private string lV51K2BToolsGenericSearchField ;
      private string chkavAtt_ticketid_visible_Internalname ;
      private string chkavAtt_ticketresponsableid_visible_Internalname ;
      private string chkavAtt_tickettecnicoresponsablenombre_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariofecha_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
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
      private string divTicketresponsableid_gridsettingscontainer_Internalname ;
      private string divTickettecnicoresponsablenombre_gridsettingscontainer_Internalname ;
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariofecha_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_197_fel_idx="0001" ;
      private string ROClassString ;
      private string edtSatisfaccionId_Jsonclick ;
      private string edtSatisfaccionFecha_Jsonclick ;
      private string edtSatisfaccionHora_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
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
      private DateTime A144SatisfaccionHora ;
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
      private bool AV70Att_TicketId_Visible ;
      private bool AV68Att_TicketResponsableId_Visible ;
      private bool AV69Att_TicketTecnicoResponsableNombre_Visible ;
      private bool AV18Att_UsuarioNombre_Visible ;
      private bool AV19Att_UsuarioFecha_Visible ;
      private bool AV20Att_UsuarioRequerimiento_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n34SatisfaccionSugerencia ;
      private bool bGXsfl_197_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV30RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV59Update_IsBlob ;
      private bool AV60Delete_IsBlob ;
      private string AV41SatisfaccionResueltoNombre ;
      private string AV42SatisfaccionTecnicoProblemaNombre ;
      private string AV43SatisfaccionTecnicoCompetenteNombre ;
      private string AV44SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV45SatisfaccionTiempoNombre ;
      private string AV46SatisfaccionAtencionNombre ;
      private string AV71UsuarioNombre ;
      private string AV74Uri ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A34SatisfaccionSugerencia ;
      private string AV79Update_GXI ;
      private string AV80Delete_GXI ;
      private string lV41SatisfaccionResueltoNombre ;
      private string lV42SatisfaccionTecnicoProblemaNombre ;
      private string lV43SatisfaccionTecnicoCompetenteNombre ;
      private string lV44SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV45SatisfaccionTiempoNombre ;
      private string lV46SatisfaccionAtencionNombre ;
      private string lV71UsuarioNombre ;
      private string AV31GridStateKey ;
      private string AV72OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV59Update ;
      private string AV60Delete ;
      private Guid AV73Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucSatisfaccionfecha_daterangepicker ;
      private GXUserControl ucUsuariofecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_ticketid_visible ;
      private GXCheckbox chkavAtt_ticketresponsableid_visible ;
      private GXCheckbox chkavAtt_tickettecnicoresponsablenombre_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariofecha_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H002Y2_A34SatisfaccionSugerencia ;
      private bool[] H002Y2_n34SatisfaccionSugerencia ;
      private string[] H002Y2_A31SatisfaccionAtencionNombre ;
      private short[] H002Y2_A13SatisfaccionAtencionId ;
      private string[] H002Y2_A38SatisfaccionTiempoNombre ;
      private short[] H002Y2_A12SatisfaccionTiempoId ;
      private string[] H002Y2_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] H002Y2_A11SatisfaccionTecnicoProfesionalismoId ;
      private string[] H002Y2_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] H002Y2_A10SatisfaccionTecnicoCompetenteId ;
      private string[] H002Y2_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] H002Y2_A9SatisfaccionTecnicoProblemaId ;
      private string[] H002Y2_A33SatisfaccionResueltoNombre ;
      private short[] H002Y2_A8SatisfaccionResueltoId ;
      private string[] H002Y2_A94UsuarioRequerimiento ;
      private DateTime[] H002Y2_A90UsuarioFecha ;
      private string[] H002Y2_A93UsuarioNombre ;
      private long[] H002Y2_A15UsuarioId ;
      private string[] H002Y2_A199TicketTecnicoResponsableNombre ;
      private short[] H002Y2_A198TicketTecnicoResponsableId ;
      private long[] H002Y2_A16TicketResponsableId ;
      private long[] H002Y2_A14TicketId ;
      private DateTime[] H002Y2_A144SatisfaccionHora ;
      private DateTime[] H002Y2_A32SatisfaccionFecha ;
      private long[] H002Y2_A7SatisfaccionId ;
      private long[] H002Y3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV34ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV47K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV49FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV53GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV56Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV64AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV63ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV32GridState ;
      private SdtK2BGridState_FilterValue AV33GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV48K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV54GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV57Message ;
      private SdtK2BTrnContext AV61TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV65ActivityListItem ;
   }

   public class wwsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002Y2( IGxContext context ,
                                             DateTime AV37SatisfaccionFecha_To ,
                                             DateTime AV36SatisfaccionFecha_From ,
                                             DateTime AV40UsuarioFecha_To ,
                                             DateTime AV39UsuarioFecha_From ,
                                             string AV41SatisfaccionResueltoNombre ,
                                             string AV42SatisfaccionTecnicoProblemaNombre ,
                                             string AV43SatisfaccionTecnicoCompetenteNombre ,
                                             string AV44SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV45SatisfaccionTiempoNombre ,
                                             string AV46SatisfaccionAtencionNombre ,
                                             string AV71UsuarioNombre ,
                                             string AV51K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV52OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[19];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SatisfaccionSugerencia], T2.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T7.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T9.[UsuarioRequerimiento], T9.[UsuarioFecha], T9.[UsuarioNombre], T8.[UsuarioId], T11.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T10.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T1.[TicketResponsableId], T1.[TicketId], T1.[SatisfaccionHora], T1.[SatisfaccionFecha], T1.[SatisfaccionId]";
         sFromString = " FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T8 ON T8.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T9 ON T9.[UsuarioId] = T8.[UsuarioId]) INNER JOIN [TicketResponsable] T10 ON T10.[TicketId] = T1.[TicketId] AND T10.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T11 ON T11.[ResponsableId] = T10.[TicketTecnicoResponsableId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV37SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV36SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] <= @AV40UsuarioFecha_To)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] >= @AV39UsuarioFecha_From)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV41SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV43SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV44SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV45SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV46SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioNombre] like @lV71UsuarioNombre)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV51K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV51K2BToolsGenericSearchField + '%' or T11.[ResponsableNombre] like '%' + @lV51K2BToolsGenericSearchField + '%' or T9.[UsuarioNombre] like '%' + @lV51K2BToolsGenericSearchField + '%' or T9.[UsuarioRequerimiento] like '%' + @lV51K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
         }
         if ( AV52OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV52OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV52OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV52OrderedBy == 3 )
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

      protected Object[] conditional_H002Y3( IGxContext context ,
                                             DateTime AV37SatisfaccionFecha_To ,
                                             DateTime AV36SatisfaccionFecha_From ,
                                             DateTime AV40UsuarioFecha_To ,
                                             DateTime AV39UsuarioFecha_From ,
                                             string AV41SatisfaccionResueltoNombre ,
                                             string AV42SatisfaccionTecnicoProblemaNombre ,
                                             string AV43SatisfaccionTecnicoCompetenteNombre ,
                                             string AV44SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV45SatisfaccionTiempoNombre ,
                                             string AV46SatisfaccionAtencionNombre ,
                                             string AV71UsuarioNombre ,
                                             string AV51K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV52OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T11 ON T11.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T10 ON T10.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T9 ON T9.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T8 ON T8.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T4 ON T4.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T5 ON T5.[UsuarioId] = T4.[UsuarioId]) INNER JOIN [TicketResponsable] T2 ON T2.[TicketId] = T1.[TicketId] AND T2.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T3 ON T3.[ResponsableId] = T2.[TicketTecnicoResponsableId])";
         if ( ! (DateTime.MinValue==AV37SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV37SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV36SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV36SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV40UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioFecha] <= @AV40UsuarioFecha_To)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV39UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioFecha] >= @AV39UsuarioFecha_From)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV41SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV42SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T8.[EstadoSatisfaccionNombre] like @lV43SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T9.[EstadoSatisfaccionNombre] like @lV44SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T10.[EstadoSatisfaccionNombre] like @lV45SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T11.[EstadoSatisfaccionNombre] like @lV46SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioNombre] like @lV71UsuarioNombre)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV51K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV51K2BToolsGenericSearchField + '%' or T3.[ResponsableNombre] like '%' + @lV51K2BToolsGenericSearchField + '%' or T5.[UsuarioNombre] like '%' + @lV51K2BToolsGenericSearchField + '%' or T5.[UsuarioRequerimiento] like '%' + @lV51K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV52OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV52OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV52OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV52OrderedBy == 3 )
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
                     return conditional_H002Y2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_H002Y3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmH002Y2;
          prmH002Y2 = new Object[] {
          new ParDef("@AV37SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV40UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV39UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV41SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV44SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV45SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV46SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV71UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002Y3;
          prmH002Y3 = new Object[] {
          new ParDef("@AV37SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV36SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV40UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV39UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV41SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV42SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV43SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV44SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV45SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV46SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV71UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV51K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
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
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((long[]) buf[17])[0] = rslt.getLong(17);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(22);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(23);
                ((long[]) buf[24])[0] = rslt.getLong(24);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
