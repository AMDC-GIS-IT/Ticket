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
   public class wwusuario : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwusuario( )
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

      public wwusuario( IGxContext context )
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
         chkavAtt_usuarioid_visible = new GXCheckbox();
         chkavAtt_usuarionombre_visible = new GXCheckbox();
         chkavAtt_usuariofecha_visible = new GXCheckbox();
         chkavAtt_usuariohora_visible = new GXCheckbox();
         chkavAtt_usuariogerencia_visible = new GXCheckbox();
         chkavAtt_usuariodepartamento_visible = new GXCheckbox();
         chkavAtt_usuariorequerimiento_visible = new GXCheckbox();
         chkavAtt_usuarioemail_visible = new GXCheckbox();
         chkavAtt_usuariotelefono_visible = new GXCheckbox();
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
               nRC_GXsfl_180 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_180"), "."));
               nGXsfl_180_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_180_idx"), "."));
               sGXsfl_180_idx = GetPar( "sGXsfl_180_idx");
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
               AV42K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV31UsuarioNombre = GetPar( "UsuarioNombre");
               AV58UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
               AV57UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV30ClassCollection);
               AV43OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV59UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
               AV65Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV49UsuarioNombre_IsAuthorized = StringUtil.StrToBool( GetPar( "UsuarioNombre_IsAuthorized"));
               AV14Att_UsuarioId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioId_Visible"));
               AV15Att_UsuarioNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioNombre_Visible"));
               AV16Att_UsuarioFecha_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioFecha_Visible"));
               AV17Att_UsuarioHora_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioHora_Visible"));
               AV18Att_UsuarioGerencia_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioGerencia_Visible"));
               AV19Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioDepartamento_Visible"));
               AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioRequerimiento_Visible"));
               AV21Att_UsuarioEmail_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioEmail_Visible"));
               AV22Att_UsuarioTelefono_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioTelefono_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV62Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
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
            return "usuario_Execute" ;
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
         PA2J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2J2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188152387", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwusuario.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV65Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV42K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIONOMBRE", AV31UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV58UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57UsuarioId), 10, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_180", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_180), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV40FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV40FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV41DeletedTag));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_TO", context.localUtil.DToC( AV59UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV44GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV44GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV65Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV65Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV30ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV30ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vUSUARIONOMBRE_ISAUTHORIZED", AV49UsuarioNombre_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV62Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_FROM", context.localUtil.DToC( AV58UsuarioFecha_From, 0, "/"));
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
            WE2J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2J2( ) ;
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
         return formatLink("wwusuario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios" ;
      }

      protected void WB2J0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Usuarios", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV42K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV42K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWUsuario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuario.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV40FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV41DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuario.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarionombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_Internalname, "Usuario:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV31UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV31UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWUsuario.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariofecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha Inicio:", "", "", lblTextblockusuariofecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV58UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV59UsuarioFecha_To);
            ucUsuariofecha_daterangepicker.Render(context, "k2bdaterangepicker", Usuariofecha_daterangepicker_Internalname, "USUARIOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarioid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsuarioid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioid_Internalname, "Id Usuario:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_180_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57UsuarioId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavUsuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV57UsuarioId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV57UsuarioId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioid_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarioid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWUsuario.htm");
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
            wb_table1_58_2J2( true) ;
         }
         else
         {
            wb_table1_58_2J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_58_2J2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"180\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(80), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Hora Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioGerencia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gerencia:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Departamento:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Descripción del Requerimiento:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Email:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Teléfono:") ;
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
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioHora_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A91UsuarioGerencia);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioGerencia_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioDepartamento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A89UsuarioEmail);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioEmail_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioTelefono_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV50Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV51Delete));
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
         if ( wbEnd == 180 )
         {
            wbEnd = 0;
            nRC_GXsfl_180 = (int)(nGXsfl_180_idx-1);
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
            wb_table2_194_2J2( true) ;
         }
         else
         {
            wb_table2_194_2J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_194_2J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV44GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV46UC_OrderedBy);
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
         if ( wbEnd == 180 )
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

      protected void START2J2( )
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
            Form.Meta.addItem("description", "Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2J0( ) ;
      }

      protected void WS2J2( )
      {
         START2J2( ) ;
         EVT2J2( ) ;
      }

      protected void EVT2J2( )
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
                              E112J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E132J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E142J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E152J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E162J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E172J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E182J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E212J2 ();
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
                              nGXsfl_180_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
                              SubsflControlProps_1802( ) ;
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtUsuarioHora_Internalname), 0));
                              A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A89UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
                              A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ".", ","));
                              AV50Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_180_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
                              AV51Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_180_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E222J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E232J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E252J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV42K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV31UsuarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariofecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 0) != AV58UsuarioFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vUSUARIOID"), ".", ",") != Convert.ToDecimal( AV57UsuarioId )) )
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

      protected void WE2J2( )
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

      protected void PA2J2( )
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
         SubsflControlProps_1802( ) ;
         while ( nGXsfl_180_idx <= nRC_GXsfl_180 )
         {
            sendrow_1802( ) ;
            nGXsfl_180_idx = ((subGrid_Islastpage==1)&&(nGXsfl_180_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_180_idx+1);
            sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
            SubsflControlProps_1802( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV42K2BToolsGenericSearchField ,
                                       string AV31UsuarioNombre ,
                                       DateTime AV58UsuarioFecha_From ,
                                       long AV57UsuarioId ,
                                       GxSimpleCollection<string> AV30ClassCollection ,
                                       short AV43OrderedBy ,
                                       DateTime AV59UsuarioFecha_To ,
                                       string AV65Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV49UsuarioNombre_IsAuthorized ,
                                       bool AV14Att_UsuarioId_Visible ,
                                       bool AV15Att_UsuarioNombre_Visible ,
                                       bool AV16Att_UsuarioFecha_Visible ,
                                       bool AV17Att_UsuarioHora_Visible ,
                                       bool AV18Att_UsuarioGerencia_Visible ,
                                       bool AV19Att_UsuarioDepartamento_Visible ,
                                       bool AV20Att_UsuarioRequerimiento_Visible ,
                                       bool AV21Att_UsuarioEmail_Visible ,
                                       bool AV22Att_UsuarioTelefono_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV62Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E232J2 ();
         GRID_nCurrentRecord = 0;
         RF2J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
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
         AV14Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_UsuarioId_Visible));
         AssignAttri("", false, "AV14Att_UsuarioId_Visible", AV14Att_UsuarioId_Visible);
         AV15Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV15Att_UsuarioNombre_Visible", AV15Att_UsuarioNombre_Visible);
         AV16Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_UsuarioFecha_Visible));
         AssignAttri("", false, "AV16Att_UsuarioFecha_Visible", AV16Att_UsuarioFecha_Visible);
         AV17Att_UsuarioHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioHora_Visible));
         AssignAttri("", false, "AV17Att_UsuarioHora_Visible", AV17Att_UsuarioHora_Visible);
         AV18Att_UsuarioGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioGerencia_Visible));
         AssignAttri("", false, "AV18Att_UsuarioGerencia_Visible", AV18Att_UsuarioGerencia_Visible);
         AV19Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioDepartamento_Visible));
         AssignAttri("", false, "AV19Att_UsuarioDepartamento_Visible", AV19Att_UsuarioDepartamento_Visible);
         AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         AV21Att_UsuarioEmail_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_UsuarioEmail_Visible));
         AssignAttri("", false, "AV21Att_UsuarioEmail_Visible", AV21Att_UsuarioEmail_Visible);
         AV22Att_UsuarioTelefono_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_UsuarioTelefono_Visible));
         AssignAttri("", false, "AV22Att_UsuarioTelefono_Visible", AV22Att_UsuarioTelefono_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E232J2 ();
         RF2J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV65Pgmname = "WWUsuario";
         context.Gx_err = 0;
      }

      protected void RF2J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 180;
         E242J2 ();
         nGXsfl_180_idx = 1;
         sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
         SubsflControlProps_1802( ) ;
         bGXsfl_180_Refreshing = true;
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
            SubsflControlProps_1802( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31UsuarioNombre ,
                                                 AV59UsuarioFecha_To ,
                                                 AV58UsuarioFecha_From ,
                                                 AV57UsuarioId ,
                                                 AV42K2BToolsGenericSearchField ,
                                                 A93UsuarioNombre ,
                                                 A90UsuarioFecha ,
                                                 A15UsuarioId ,
                                                 A91UsuarioGerencia ,
                                                 A88UsuarioDepartamento ,
                                                 A94UsuarioRequerimiento ,
                                                 A89UsuarioEmail ,
                                                 A95UsuarioTelefono ,
                                                 AV43OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            lV31UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV31UsuarioNombre), "%", "");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002J2 */
            pr_default.execute(0, new Object[] {lV31UsuarioNombre, AV59UsuarioFecha_To, AV58UsuarioFecha_From, AV57UsuarioId, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_180_idx = 1;
            sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
            SubsflControlProps_1802( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A95UsuarioTelefono = H002J2_A95UsuarioTelefono[0];
               A89UsuarioEmail = H002J2_A89UsuarioEmail[0];
               A94UsuarioRequerimiento = H002J2_A94UsuarioRequerimiento[0];
               A88UsuarioDepartamento = H002J2_A88UsuarioDepartamento[0];
               A91UsuarioGerencia = H002J2_A91UsuarioGerencia[0];
               A92UsuarioHora = H002J2_A92UsuarioHora[0];
               A90UsuarioFecha = H002J2_A90UsuarioFecha[0];
               A93UsuarioNombre = H002J2_A93UsuarioNombre[0];
               A15UsuarioId = H002J2_A15UsuarioId[0];
               E252J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 180;
            WB2J0( ) ;
         }
         bGXsfl_180_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV65Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV65Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_180_idx, GetSecureSignedToken( sGXsfl_180_idx, context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV62Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Uri, "")), context));
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
                                              AV31UsuarioNombre ,
                                              AV59UsuarioFecha_To ,
                                              AV58UsuarioFecha_From ,
                                              AV57UsuarioId ,
                                              AV42K2BToolsGenericSearchField ,
                                              A93UsuarioNombre ,
                                              A90UsuarioFecha ,
                                              A15UsuarioId ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A94UsuarioRequerimiento ,
                                              A89UsuarioEmail ,
                                              A95UsuarioTelefono ,
                                              AV43OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV31UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV31UsuarioNombre), "%", "");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         lV42K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV42K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002J3 */
         pr_default.execute(1, new Object[] {lV31UsuarioNombre, AV59UsuarioFecha_To, AV58UsuarioFecha_From, AV57UsuarioId, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField, lV42K2BToolsGenericSearchField});
         GRID_nRecordCount = H002J3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV65Pgmname = "WWUsuario";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E222J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV40FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV44GridOrders);
            /* Read saved values. */
            nRC_GXsfl_180 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_180"), ".", ","));
            AV41DeletedTag = cgiGet( "vDELETEDTAG");
            AV58UsuarioFecha_From = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_FROM"), 0);
            AV59UsuarioFecha_To = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_TO"), 0);
            AV46UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV43OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV42K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV42K2BToolsGenericSearchField", AV42K2BToolsGenericSearchField);
            AV31UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV31UsuarioNombre", AV31UsuarioNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSUARIOID");
               GX_FocusControl = edtavUsuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV57UsuarioId = 0;
               AssignAttri("", false, "AV57UsuarioId", StringUtil.LTrimStr( (decimal)(AV57UsuarioId), 10, 0));
            }
            else
            {
               AV57UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtavUsuarioid_Internalname), ".", ","));
               AssignAttri("", false, "AV57UsuarioId", StringUtil.LTrimStr( (decimal)(AV57UsuarioId), 10, 0));
            }
            AV14Att_UsuarioId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarioid_visible_Internalname));
            AssignAttri("", false, "AV14Att_UsuarioId_Visible", AV14Att_UsuarioId_Visible);
            AV15Att_UsuarioNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarionombre_visible_Internalname));
            AssignAttri("", false, "AV15Att_UsuarioNombre_Visible", AV15Att_UsuarioNombre_Visible);
            AV16Att_UsuarioFecha_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariofecha_visible_Internalname));
            AssignAttri("", false, "AV16Att_UsuarioFecha_Visible", AV16Att_UsuarioFecha_Visible);
            AV17Att_UsuarioHora_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariohora_visible_Internalname));
            AssignAttri("", false, "AV17Att_UsuarioHora_Visible", AV17Att_UsuarioHora_Visible);
            AV18Att_UsuarioGerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariogerencia_visible_Internalname));
            AssignAttri("", false, "AV18Att_UsuarioGerencia_Visible", AV18Att_UsuarioGerencia_Visible);
            AV19Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariodepartamento_visible_Internalname));
            AssignAttri("", false, "AV19Att_UsuarioDepartamento_Visible", AV19Att_UsuarioDepartamento_Visible);
            AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariorequerimiento_visible_Internalname));
            AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
            AV21Att_UsuarioEmail_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuarioemail_visible_Internalname));
            AssignAttri("", false, "AV21Att_UsuarioEmail_Visible", AV21Att_UsuarioEmail_Visible);
            AV22Att_UsuarioTelefono_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariotelefono_visible_Internalname));
            AssignAttri("", false, "AV22Att_UsuarioTelefono_Visible", AV22Att_UsuarioTelefono_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV42K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV31UsuarioNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV58UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vUSUARIOID"), ".", ",") != Convert.ToDecimal( AV57UsuarioId )) )
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
         E222J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E222J2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV31UsuarioNombre = "";
         AssignAttri("", false, "AV31UsuarioNombre", AV31UsuarioNombre);
         AV56UsuarioFecha = DateTime.MinValue;
         AV58UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV58UsuarioFecha_From", context.localUtil.Format(AV58UsuarioFecha_From, "99/99/9999"));
         AV59UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV59UsuarioFecha_To", context.localUtil.Format(AV59UsuarioFecha_To, "99/99/9999"));
         AV57UsuarioId = 0;
         AssignAttri("", false, "AV57UsuarioId", StringUtil.LTrimStr( (decimal)(AV57UsuarioId), 10, 0));
         new k2bloadrowsperpage(context ).execute(  AV65Pgmname,  "Grid", out  AV25RowsPerPageVariable, out  AV26RowsPerPageLoaded) ;
         AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         if ( ! AV26RowsPerPageLoaded )
         {
            AV25RowsPerPageVariable = 20;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         }
         AV24GridSettingsRowsPerPageVariable = AV25RowsPerPageVariable;
         AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV25RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Usuarios";
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
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45GridOrder.gxTpr_Ascendingorder = 0;
         AV45GridOrder.gxTpr_Descendingorder = 1;
         AV45GridOrder.gxTpr_Gridcolumnindex = 1;
         AV44GridOrders.Add(AV45GridOrder, 0);
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV45GridOrder.gxTpr_Ascendingorder = 2;
         AV45GridOrder.gxTpr_Descendingorder = 3;
         AV45GridOrder.gxTpr_Gridcolumnindex = 2;
         AV44GridOrders.Add(AV45GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E232J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV47Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV47Messages = GXt_objcol_SdtMessages_Message1;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV47Messages.Count )
         {
            AV48Message = ((GeneXus.Utils.SdtMessages_Message)AV47Messages.Item(AV66GXV1));
            GX_msglist.addItem(AV48Message.gxTpr_Description);
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV65Pgmname;
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV50Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         AV67Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_180_Refreshing);
         AV51Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         AV68Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_180_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV30ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV65Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV43OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
         AV46UC_OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
         AV69GXV2 = 1;
         while ( AV69GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV69GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre") == 0 )
            {
               AV31UsuarioNombre = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31UsuarioNombre", AV31UsuarioNombre);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV58UsuarioFecha_From = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV58UsuarioFecha_From", context.localUtil.Format(AV58UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV59UsuarioFecha_To = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV59UsuarioFecha_To", context.localUtil.Format(AV59UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "UsuarioId") == 0 )
            {
               AV57UsuarioId = (long)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV57UsuarioId", StringUtil.LTrimStr( (decimal)(AV57UsuarioId), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV42K2BToolsGenericSearchField = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42K2BToolsGenericSearchField", AV42K2BToolsGenericSearchField);
            }
            AV69GXV2 = (int)(AV69GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV28GridState.gxTpr_Currentpage > 0 ) && ( AV28GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV28GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV65Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV28GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV28GridState.gxTpr_Orderedby = AV43OrderedBy;
         AV28GridState.gxTpr_Filtervalues.Clear();
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre";
         AV29GridStateFilterValue.gxTpr_Value = AV31UsuarioNombre;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:From";
         AV29GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV58UsuarioFecha_From, "99/99/9999");
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:To";
         AV29GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV59UsuarioFecha_To, "99/99/9999");
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "UsuarioId";
         AV29GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV57UsuarioId), 10, 0);
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV29GridStateFilterValue.gxTpr_Value = AV42K2BToolsGenericSearchField;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV65Pgmname,  AV27GridStateKey,  AV28GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV52TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV52TrnContext.gxTpr_Returnmode = "Stack";
         AV52TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV52TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV52TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV52TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "Usuario",  AV52TrnContext) ;
      }

      protected void E132J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Usuario",  "Usuario",  "Insert",  "",  "EntityManagerUsuario") )
         {
            CallWebObject(formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtUsuarioId_Visible = 1;
         AssignProp("", false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV14Att_UsuarioId_Visible = true;
         AssignAttri("", false, "AV14Att_UsuarioId_Visible", AV14Att_UsuarioId_Visible);
         edtUsuarioNombre_Visible = 1;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV15Att_UsuarioNombre_Visible = true;
         AssignAttri("", false, "AV15Att_UsuarioNombre_Visible", AV15Att_UsuarioNombre_Visible);
         edtUsuarioFecha_Visible = 1;
         AssignProp("", false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV16Att_UsuarioFecha_Visible = true;
         AssignAttri("", false, "AV16Att_UsuarioFecha_Visible", AV16Att_UsuarioFecha_Visible);
         edtUsuarioHora_Visible = 1;
         AssignProp("", false, edtUsuarioHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioHora_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV17Att_UsuarioHora_Visible = true;
         AssignAttri("", false, "AV17Att_UsuarioHora_Visible", AV17Att_UsuarioHora_Visible);
         edtUsuarioGerencia_Visible = 1;
         AssignProp("", false, edtUsuarioGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV18Att_UsuarioGerencia_Visible = true;
         AssignAttri("", false, "AV18Att_UsuarioGerencia_Visible", AV18Att_UsuarioGerencia_Visible);
         edtUsuarioDepartamento_Visible = 1;
         AssignProp("", false, edtUsuarioDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV19Att_UsuarioDepartamento_Visible = true;
         AssignAttri("", false, "AV19Att_UsuarioDepartamento_Visible", AV19Att_UsuarioDepartamento_Visible);
         edtUsuarioRequerimiento_Visible = 1;
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV20Att_UsuarioRequerimiento_Visible = true;
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         edtUsuarioEmail_Visible = 1;
         AssignProp("", false, edtUsuarioEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV21Att_UsuarioEmail_Visible = true;
         AssignAttri("", false, "AV21Att_UsuarioEmail_Visible", AV21Att_UsuarioEmail_Visible);
         edtUsuarioTelefono_Visible = 1;
         AssignProp("", false, edtUsuarioTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefono_Visible), 5, 0), !bGXsfl_180_Refreshing);
         AV22Att_UsuarioTelefono_Visible = true;
         AssignAttri("", false, "AV22Att_UsuarioTelefono_Visible", AV22Att_UsuarioTelefono_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV65Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV70GXV3 = 1;
         while ( AV70GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV70GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  edtUsuarioId_Visible = 0;
                  AssignProp("", false, edtUsuarioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV14Att_UsuarioId_Visible = false;
                  AssignAttri("", false, "AV14Att_UsuarioId_Visible", AV14Att_UsuarioId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  edtUsuarioNombre_Visible = 0;
                  AssignProp("", false, edtUsuarioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV15Att_UsuarioNombre_Visible = false;
                  AssignAttri("", false, "AV15Att_UsuarioNombre_Visible", AV15Att_UsuarioNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  edtUsuarioFecha_Visible = 0;
                  AssignProp("", false, edtUsuarioFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV16Att_UsuarioFecha_Visible = false;
                  AssignAttri("", false, "AV16Att_UsuarioFecha_Visible", AV16Att_UsuarioFecha_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioHora") == 0 )
               {
                  edtUsuarioHora_Visible = 0;
                  AssignProp("", false, edtUsuarioHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioHora_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV17Att_UsuarioHora_Visible = false;
                  AssignAttri("", false, "AV17Att_UsuarioHora_Visible", AV17Att_UsuarioHora_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioGerencia") == 0 )
               {
                  edtUsuarioGerencia_Visible = 0;
                  AssignProp("", false, edtUsuarioGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV18Att_UsuarioGerencia_Visible = false;
                  AssignAttri("", false, "AV18Att_UsuarioGerencia_Visible", AV18Att_UsuarioGerencia_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  edtUsuarioDepartamento_Visible = 0;
                  AssignProp("", false, edtUsuarioDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV19Att_UsuarioDepartamento_Visible = false;
                  AssignAttri("", false, "AV19Att_UsuarioDepartamento_Visible", AV19Att_UsuarioDepartamento_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  edtUsuarioRequerimiento_Visible = 0;
                  AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV20Att_UsuarioRequerimiento_Visible = false;
                  AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioEmail") == 0 )
               {
                  edtUsuarioEmail_Visible = 0;
                  AssignProp("", false, edtUsuarioEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV21Att_UsuarioEmail_Visible = false;
                  AssignAttri("", false, "AV21Att_UsuarioEmail_Visible", AV21Att_UsuarioEmail_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioTelefono") == 0 )
               {
                  edtUsuarioTelefono_Visible = 0;
                  AssignProp("", false, edtUsuarioTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefono_Visible), 5, 0), !bGXsfl_180_Refreshing);
                  AV22Att_UsuarioTelefono_Visible = false;
                  AssignAttri("", false, "AV22Att_UsuarioTelefono_Visible", AV22Att_UsuarioTelefono_Visible);
               }
            }
            AV70GXV3 = (int)(AV70GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioId";
         AV13GridColumn.gxTpr_Columntitle = "Id Usuario:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV13GridColumn.gxTpr_Columntitle = "Usuario:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV13GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioHora";
         AV13GridColumn.gxTpr_Columntitle = "Hora Inicio:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioGerencia";
         AV13GridColumn.gxTpr_Columntitle = "Gerencia:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV13GridColumn.gxTpr_Columntitle = "Departamento:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV13GridColumn.gxTpr_Columntitle = "Descripción del Requerimiento:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioEmail";
         AV13GridColumn.gxTpr_Columntitle = "Email:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioTelefono";
         AV13GridColumn.gxTpr_Columntitle = "Teléfono:";
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
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV55ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuario";
         AV54ActivityList.Add(AV55ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV54ActivityList) ;
         AV49UsuarioNombre_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV49UsuarioNombre_IsAuthorized", AV49UsuarioNombre_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_180_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_180_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV54ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_180_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_180_Refreshing);
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

      protected void E242J2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV30ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV50Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         AV67Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.convertURL( context.PathToRelativeUrl( AV50Update))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV50Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_180_Refreshing);
         AV51Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         AV68Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV51Delete))), !bGXsfl_180_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV51Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_180_Refreshing);
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
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV30ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40FilterTags", AV40FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E252J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV49UsuarioNombre_IsAuthorized )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         else
         {
            edtUsuarioNombre_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 180;
         }
         sendrow_1802( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_180_Refreshing )
         {
            context.DoAjaxLoad(180, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV38K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31UsuarioNombre)) )
         {
            AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV39K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioNombre";
            AV39K2BFilterValuesSDTItem.gxTpr_Description = "Usuario:";
            AV39K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV39K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV39K2BFilterValuesSDTItem.gxTpr_Value = AV31UsuarioNombre;
            AV39K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV31UsuarioNombre;
            AV38K2BFilterValuesSDT.Add(AV39K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV58UsuarioFecha_From) || ! (DateTime.MinValue==AV59UsuarioFecha_To) )
         {
            AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV39K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV39K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Inicio:";
            AV39K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV39K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV39K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime3 = DateTimeUtil.ResetTime( AV58UsuarioFecha_From ) ;
            AV39K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV59UsuarioFecha_To ) ;
            AV39K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime3;
            AV38K2BFilterValuesSDT.Add(AV39K2BFilterValuesSDTItem, 0);
         }
         if ( ! (0==AV57UsuarioId) )
         {
            AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV39K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioId";
            AV39K2BFilterValuesSDTItem.gxTpr_Description = "Id Usuario:";
            AV39K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV39K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV39K2BFilterValuesSDTItem.gxTpr_Value = StringUtil.Str( (decimal)(AV57UsuarioId), 10, 0);
            AV39K2BFilterValuesSDTItem.gxTpr_Valuedescription = StringUtil.Str( (decimal)(AV57UsuarioId), 10, 0);
            AV38K2BFilterValuesSDT.Add(AV39K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV38K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV40FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV65Pgmname,  "Grid",  AV38K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV40FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void E112J2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41DeletedTag, "UsuarioNombre") == 0 )
         {
            AV31UsuarioNombre = "";
            AssignAttri("", false, "AV31UsuarioNombre", AV31UsuarioNombre);
         }
         else if ( StringUtil.StrCmp(AV41DeletedTag, "UsuarioFecha") == 0 )
         {
            AV58UsuarioFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV58UsuarioFecha_From", context.localUtil.Format(AV58UsuarioFecha_From, "99/99/9999"));
            AV59UsuarioFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV59UsuarioFecha_To", context.localUtil.Format(AV59UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV41DeletedTag, "UsuarioId") == 0 )
         {
            AV57UsuarioId = 0;
            AssignAttri("", false, "AV57UsuarioId", StringUtil.LTrimStr( (decimal)(AV57UsuarioId), 10, 0));
         }
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E122J2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV43OrderedBy = AV46UC_OrderedBy;
         AssignAttri("", false, "AV43OrderedBy", StringUtil.LTrimStr( (decimal)(AV43OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E142J2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV65Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV71GXV4 = 1;
         while ( AV71GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV71GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_UsuarioId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_UsuarioNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_UsuarioFecha_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioHora") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_UsuarioHora_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioGerencia") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_UsuarioGerencia_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV19Att_UsuarioDepartamento_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_UsuarioRequerimiento_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioEmail") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV21Att_UsuarioEmail_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioTelefono") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV22Att_UsuarioTelefono_Visible;
            }
            AV71GXV4 = (int)(AV71GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV65Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV46UC_OrderedBy = AV43OrderedBy;
         AssignAttri("", false, "AV46UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV46UC_OrderedBy), 4, 0));
         if ( AV25RowsPerPageVariable != AV24GridSettingsRowsPerPageVariable )
         {
            AV25RowsPerPageVariable = AV24GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV25RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV65Pgmname,  "Grid",  AV25RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV42K2BToolsGenericSearchField, AV31UsuarioNombre, AV58UsuarioFecha_From, AV57UsuarioId, AV30ClassCollection, AV43OrderedBy, AV59UsuarioFecha_To, AV65Pgmname, AV8CurrentPage, AV10GridConfiguration, AV49UsuarioNombre_IsAuthorized, AV14Att_UsuarioId_Visible, AV15Att_UsuarioNombre_Visible, AV16Att_UsuarioFecha_Visible, AV17Att_UsuarioHora_Visible, AV18Att_UsuarioGerencia_Visible, AV19Att_UsuarioDepartamento_Visible, AV20Att_UsuarioRequerimiento_Visible, AV21Att_UsuarioEmail_Visible, AV22Att_UsuarioTelefono_Visible, AV11FreezeColumnTitles, AV62Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
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

      protected void E152J2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E162J2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E172J2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void E182J2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV65Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV30ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV30ClassCollection) ;
         }
      }

      protected void E192J2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Usuario",  "Usuario",  "List",  "",  "ExportWWUsuario") )
         {
            new exportwwusuario(context ).execute(  AV31UsuarioNombre,  AV58UsuarioFecha_From,  AV59UsuarioFecha_To,  AV57UsuarioId,  AV42K2BToolsGenericSearchField,  AV43OrderedBy, out  AV60OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV60OutFile, out  AV62Uri) )
            {
               CallWebObject(formatLink(AV62Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV61Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV61Guid.ToString(),  AV60OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV61Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E202J2( )
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

      protected void E212J2( )
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

      protected void wb_table2_194_2J2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_194_2J2e( true) ;
         }
         else
         {
            wb_table2_194_2J2e( false) ;
         }
      }

      protected void wb_table1_58_2J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e262j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuario.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWUsuario.htm");
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
            GxWebStd.gx_div_start( context, divUsuarioid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuarioid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuarioid_visible_Internalname, "Id Usuario:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarioid_visible_Internalname, StringUtil.BoolToStr( AV14Att_UsuarioId_Visible), "", "Id Usuario:", 1, chkavAtt_usuarioid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(87, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,87);\"");
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
            GxWebStd.gx_label_element( context, chkavAtt_usuarionombre_visible_Internalname, "Usuario:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarionombre_visible_Internalname, StringUtil.BoolToStr( AV15Att_UsuarioNombre_Visible), "", "Usuario:", 1, chkavAtt_usuarionombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariofecha_visible_Internalname, StringUtil.BoolToStr( AV16Att_UsuarioFecha_Visible), "", "Fecha Inicio:", 1, chkavAtt_usuariofecha_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
            GxWebStd.gx_div_start( context, divUsuariohora_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariohora_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariohora_visible_Internalname, "Hora Inicio:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariohora_visible_Internalname, StringUtil.BoolToStr( AV17Att_UsuarioHora_Visible), "", "Hora Inicio:", 1, chkavAtt_usuariohora_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
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
            GxWebStd.gx_div_start( context, divUsuariogerencia_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariogerencia_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariogerencia_visible_Internalname, "Gerencia:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariogerencia_visible_Internalname, StringUtil.BoolToStr( AV18Att_UsuarioGerencia_Visible), "", "Gerencia:", 1, chkavAtt_usuariogerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
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
            GxWebStd.gx_label_element( context, chkavAtt_usuariodepartamento_visible_Internalname, "Departamento:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariodepartamento_visible_Internalname, StringUtil.BoolToStr( AV19Att_UsuarioDepartamento_Visible), "", "Departamento:", 1, chkavAtt_usuariodepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(117, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,117);\"");
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
            GxWebStd.gx_label_element( context, chkavAtt_usuariorequerimiento_visible_Internalname, "Descripción del Requerimiento:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariorequerimiento_visible_Internalname, StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible), "", "Descripción del Requerimiento:", 1, chkavAtt_usuariorequerimiento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,123);\"");
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
            GxWebStd.gx_div_start( context, divUsuarioemail_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuarioemail_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuarioemail_visible_Internalname, "Email:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuarioemail_visible_Internalname, StringUtil.BoolToStr( AV21Att_UsuarioEmail_Visible), "", "Email:", 1, chkavAtt_usuarioemail_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(129, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,129);\"");
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
            GxWebStd.gx_div_start( context, divUsuariotelefono_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariotelefono_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariotelefono_visible_Internalname, "Teléfono:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariotelefono_visible_Internalname, StringUtil.BoolToStr( AV22Att_UsuarioTelefono_Visible), "", "Teléfono:", 1, chkavAtt_usuariotelefono_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_180_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "", true, 1, "HLP_WWUsuario.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_180_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(147, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,147);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e272j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuario.htm");
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
            wb_table3_161_2J2( true) ;
         }
         else
         {
            wb_table3_161_2J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_161_2J2e( bool wbgen )
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
            wb_table4_168_2J2( true) ;
         }
         else
         {
            wb_table4_168_2J2( false) ;
         }
         return  ;
      }

      protected void wb_table4_168_2J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_58_2J2e( true) ;
         }
         else
         {
            wb_table1_58_2J2e( false) ;
         }
      }

      protected void wb_table4_168_2J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_168_2J2e( true) ;
         }
         else
         {
            wb_table4_168_2J2e( false) ;
         }
      }

      protected void wb_table3_161_2J2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e282j1_client"+"'", TempTags, "", 2, "HLP_WWUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(180), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_161_2J2e( true) ;
         }
         else
         {
            wb_table3_161_2J2e( false) ;
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
         PA2J2( ) ;
         WS2J2( ) ;
         WE2J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188153237", true, true);
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
         context.AddJavascriptSource("wwusuario.js", "?2024188153239", false, true);
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

      protected void SubsflControlProps_1802( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_180_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_180_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_180_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_180_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_180_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_180_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_180_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_180_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_180_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_180_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_180_idx;
      }

      protected void SubsflControlProps_fel_1802( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_180_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_180_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_180_fel_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_180_fel_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_180_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_180_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_180_fel_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_180_fel_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_180_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_180_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_180_fel_idx;
      }

      protected void sendrow_1802( )
      {
         SubsflControlProps_1802( ) ;
         WB2J0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_180_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_180_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_180_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtUsuarioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioHora_Internalname,context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A92UsuarioHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioGerencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioGerencia_Internalname,(string)A91UsuarioGerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioGerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioGerencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioRequerimiento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioRequerimiento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioEmail_Internalname,(string)A89UsuarioEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A89UsuarioEmail,(string)"",(string)"",(string)"",(string)edtUsuarioEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtUsuarioTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefono_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioTelefono_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)180,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV50Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV50Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV67Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV50Update)) ? AV67Update_GXI : context.PathToRelativeUrl( AV50Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV50Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV51Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV68Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV51Delete)) ? AV68Delete_GXI : context.PathToRelativeUrl( AV51Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV51Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_180_idx = ((subGrid_Islastpage==1)&&(nGXsfl_180_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_180_idx+1);
            sGXsfl_180_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_180_idx), 4, 0), 4, "0");
            SubsflControlProps_1802( ) ;
         }
         /* End function sendrow_1802 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_usuarioid_visible.Name = "vATT_USUARIOID_VISIBLE";
         chkavAtt_usuarioid_visible.WebTags = "";
         chkavAtt_usuarioid_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarioid_visible_Internalname, "TitleCaption", chkavAtt_usuarioid_visible.Caption, true);
         chkavAtt_usuarioid_visible.CheckedValue = "false";
         AV14Att_UsuarioId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_UsuarioId_Visible));
         AssignAttri("", false, "AV14Att_UsuarioId_Visible", AV14Att_UsuarioId_Visible);
         chkavAtt_usuarionombre_visible.Name = "vATT_USUARIONOMBRE_VISIBLE";
         chkavAtt_usuarionombre_visible.WebTags = "";
         chkavAtt_usuarionombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarionombre_visible_Internalname, "TitleCaption", chkavAtt_usuarionombre_visible.Caption, true);
         chkavAtt_usuarionombre_visible.CheckedValue = "false";
         AV15Att_UsuarioNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_UsuarioNombre_Visible));
         AssignAttri("", false, "AV15Att_UsuarioNombre_Visible", AV15Att_UsuarioNombre_Visible);
         chkavAtt_usuariofecha_visible.Name = "vATT_USUARIOFECHA_VISIBLE";
         chkavAtt_usuariofecha_visible.WebTags = "";
         chkavAtt_usuariofecha_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariofecha_visible_Internalname, "TitleCaption", chkavAtt_usuariofecha_visible.Caption, true);
         chkavAtt_usuariofecha_visible.CheckedValue = "false";
         AV16Att_UsuarioFecha_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_UsuarioFecha_Visible));
         AssignAttri("", false, "AV16Att_UsuarioFecha_Visible", AV16Att_UsuarioFecha_Visible);
         chkavAtt_usuariohora_visible.Name = "vATT_USUARIOHORA_VISIBLE";
         chkavAtt_usuariohora_visible.WebTags = "";
         chkavAtt_usuariohora_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariohora_visible_Internalname, "TitleCaption", chkavAtt_usuariohora_visible.Caption, true);
         chkavAtt_usuariohora_visible.CheckedValue = "false";
         AV17Att_UsuarioHora_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_UsuarioHora_Visible));
         AssignAttri("", false, "AV17Att_UsuarioHora_Visible", AV17Att_UsuarioHora_Visible);
         chkavAtt_usuariogerencia_visible.Name = "vATT_USUARIOGERENCIA_VISIBLE";
         chkavAtt_usuariogerencia_visible.WebTags = "";
         chkavAtt_usuariogerencia_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariogerencia_visible_Internalname, "TitleCaption", chkavAtt_usuariogerencia_visible.Caption, true);
         chkavAtt_usuariogerencia_visible.CheckedValue = "false";
         AV18Att_UsuarioGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_UsuarioGerencia_Visible));
         AssignAttri("", false, "AV18Att_UsuarioGerencia_Visible", AV18Att_UsuarioGerencia_Visible);
         chkavAtt_usuariodepartamento_visible.Name = "vATT_USUARIODEPARTAMENTO_VISIBLE";
         chkavAtt_usuariodepartamento_visible.WebTags = "";
         chkavAtt_usuariodepartamento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariodepartamento_visible_Internalname, "TitleCaption", chkavAtt_usuariodepartamento_visible.Caption, true);
         chkavAtt_usuariodepartamento_visible.CheckedValue = "false";
         AV19Att_UsuarioDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_UsuarioDepartamento_Visible));
         AssignAttri("", false, "AV19Att_UsuarioDepartamento_Visible", AV19Att_UsuarioDepartamento_Visible);
         chkavAtt_usuariorequerimiento_visible.Name = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         chkavAtt_usuariorequerimiento_visible.WebTags = "";
         chkavAtt_usuariorequerimiento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariorequerimiento_visible_Internalname, "TitleCaption", chkavAtt_usuariorequerimiento_visible.Caption, true);
         chkavAtt_usuariorequerimiento_visible.CheckedValue = "false";
         AV20Att_UsuarioRequerimiento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_UsuarioRequerimiento_Visible));
         AssignAttri("", false, "AV20Att_UsuarioRequerimiento_Visible", AV20Att_UsuarioRequerimiento_Visible);
         chkavAtt_usuarioemail_visible.Name = "vATT_USUARIOEMAIL_VISIBLE";
         chkavAtt_usuarioemail_visible.WebTags = "";
         chkavAtt_usuarioemail_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuarioemail_visible_Internalname, "TitleCaption", chkavAtt_usuarioemail_visible.Caption, true);
         chkavAtt_usuarioemail_visible.CheckedValue = "false";
         AV21Att_UsuarioEmail_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_UsuarioEmail_Visible));
         AssignAttri("", false, "AV21Att_UsuarioEmail_Visible", AV21Att_UsuarioEmail_Visible);
         chkavAtt_usuariotelefono_visible.Name = "vATT_USUARIOTELEFONO_VISIBLE";
         chkavAtt_usuariotelefono_visible.WebTags = "";
         chkavAtt_usuariotelefono_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariotelefono_visible_Internalname, "TitleCaption", chkavAtt_usuariotelefono_visible.Caption, true);
         chkavAtt_usuariotelefono_visible.CheckedValue = "false";
         AV22Att_UsuarioTelefono_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_UsuarioTelefono_Visible));
         AssignAttri("", false, "AV22Att_UsuarioTelefono_Visible", AV22Att_UsuarioTelefono_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
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
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         lblTextblockusuariofecha_Internalname = "TEXTBLOCKUSUARIOFECHA";
         Usuariofecha_daterangepicker_Internalname = "USUARIOFECHA_DATERANGEPICKER";
         divK2btoolstable_attributecontainerusuariofecha_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOFECHA";
         edtavUsuarioid_Internalname = "vUSUARIOID";
         divK2btoolstable_attributecontainerusuarioid_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOID";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_usuarioid_visible_Internalname = "vATT_USUARIOID_VISIBLE";
         divUsuarioid_gridsettingscontainer_Internalname = "USUARIOID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarionombre_visible_Internalname = "vATT_USUARIONOMBRE_VISIBLE";
         divUsuarionombre_gridsettingscontainer_Internalname = "USUARIONOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariofecha_visible_Internalname = "vATT_USUARIOFECHA_VISIBLE";
         divUsuariofecha_gridsettingscontainer_Internalname = "USUARIOFECHA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariohora_visible_Internalname = "vATT_USUARIOHORA_VISIBLE";
         divUsuariohora_gridsettingscontainer_Internalname = "USUARIOHORA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariogerencia_visible_Internalname = "vATT_USUARIOGERENCIA_VISIBLE";
         divUsuariogerencia_gridsettingscontainer_Internalname = "USUARIOGERENCIA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariodepartamento_visible_Internalname = "vATT_USUARIODEPARTAMENTO_VISIBLE";
         divUsuariodepartamento_gridsettingscontainer_Internalname = "USUARIODEPARTAMENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariorequerimiento_visible_Internalname = "vATT_USUARIOREQUERIMIENTO_VISIBLE";
         divUsuariorequerimiento_gridsettingscontainer_Internalname = "USUARIOREQUERIMIENTO_GRIDSETTINGSCONTAINER";
         chkavAtt_usuarioemail_visible_Internalname = "vATT_USUARIOEMAIL_VISIBLE";
         divUsuarioemail_gridsettingscontainer_Internalname = "USUARIOEMAIL_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariotelefono_visible_Internalname = "vATT_USUARIOTELEFONO_VISIBLE";
         divUsuariotelefono_gridsettingscontainer_Internalname = "USUARIOTELEFONO_GRIDSETTINGSCONTAINER";
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
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtUsuarioHora_Internalname = "USUARIOHORA";
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO";
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
         chkavAtt_usuariotelefono_visible.Caption = "Teléfono:";
         chkavAtt_usuarioemail_visible.Caption = "Email:";
         chkavAtt_usuariorequerimiento_visible.Caption = "Descripción del Requerimiento:";
         chkavAtt_usuariodepartamento_visible.Caption = "Departamento:";
         chkavAtt_usuariogerencia_visible.Caption = "Gerencia:";
         chkavAtt_usuariohora_visible.Caption = "Hora Inicio:";
         chkavAtt_usuariofecha_visible.Caption = "Fecha Inicio:";
         chkavAtt_usuarionombre_visible.Caption = "Usuario:";
         chkavAtt_usuarioid_visible.Caption = "Id Usuario:";
         edtUsuarioTelefono_Jsonclick = "";
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioGerencia_Jsonclick = "";
         edtUsuarioHora_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_usuariotelefono_visible.Enabled = 1;
         chkavAtt_usuarioemail_visible.Enabled = 1;
         chkavAtt_usuariorequerimiento_visible.Enabled = 1;
         chkavAtt_usuariodepartamento_visible.Enabled = 1;
         chkavAtt_usuariogerencia_visible.Enabled = 1;
         chkavAtt_usuariohora_visible.Enabled = 1;
         chkavAtt_usuariofecha_visible.Enabled = 1;
         chkavAtt_usuarionombre_visible.Enabled = 1;
         chkavAtt_usuarioid_visible.Enabled = 1;
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
         edtUsuarioTelefono_Visible = -1;
         edtUsuarioEmail_Visible = -1;
         edtUsuarioRequerimiento_Visible = -1;
         edtUsuarioDepartamento_Visible = -1;
         edtUsuarioGerencia_Visible = -1;
         edtUsuarioHora_Visible = -1;
         edtUsuarioFecha_Visible = -1;
         edtUsuarioNombre_Visible = -1;
         edtUsuarioId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavUsuarioid_Jsonclick = "";
         edtavUsuarioid_Enabled = 1;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuarios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E132J2',iparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E282J1',iparms:[{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E242J2',iparms:[{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV40FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E252J2',iparms:[{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E112J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV41DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E122J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E262J1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E142J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV24GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV46UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E152J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E162J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E172J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E182J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV65Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV50Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV51Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV49UsuarioNombre_IsAuthorized',fld:'vUSUARIONOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioId_Visible',ctrl:'USUARIOID',prop:'Visible'},{av:'edtUsuarioNombre_Visible',ctrl:'USUARIONOMBRE',prop:'Visible'},{av:'edtUsuarioFecha_Visible',ctrl:'USUARIOFECHA',prop:'Visible'},{av:'edtUsuarioHora_Visible',ctrl:'USUARIOHORA',prop:'Visible'},{av:'edtUsuarioGerencia_Visible',ctrl:'USUARIOGERENCIA',prop:'Visible'},{av:'edtUsuarioDepartamento_Visible',ctrl:'USUARIODEPARTAMENTO',prop:'Visible'},{av:'edtUsuarioRequerimiento_Visible',ctrl:'USUARIOREQUERIMIENTO',prop:'Visible'},{av:'edtUsuarioEmail_Visible',ctrl:'USUARIOEMAIL',prop:'Visible'},{av:'edtUsuarioTelefono_Visible',ctrl:'USUARIOTELEFONO',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E192J2',iparms:[{av:'AV31UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV58UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV59UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV57UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV42K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV43OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV62Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E202J2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E212J2',iparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E272J1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_UsuarioId_Visible',fld:'vATT_USUARIOID_VISIBLE',pic:''},{av:'AV15Att_UsuarioNombre_Visible',fld:'vATT_USUARIONOMBRE_VISIBLE',pic:''},{av:'AV16Att_UsuarioFecha_Visible',fld:'vATT_USUARIOFECHA_VISIBLE',pic:''},{av:'AV17Att_UsuarioHora_Visible',fld:'vATT_USUARIOHORA_VISIBLE',pic:''},{av:'AV18Att_UsuarioGerencia_Visible',fld:'vATT_USUARIOGERENCIA_VISIBLE',pic:''},{av:'AV19Att_UsuarioDepartamento_Visible',fld:'vATT_USUARIODEPARTAMENTO_VISIBLE',pic:''},{av:'AV20Att_UsuarioRequerimiento_Visible',fld:'vATT_USUARIOREQUERIMIENTO_VISIBLE',pic:''},{av:'AV21Att_UsuarioEmail_Visible',fld:'vATT_USUARIOEMAIL_VISIBLE',pic:''},{av:'AV22Att_UsuarioTelefono_Visible',fld:'vATT_USUARIOTELEFONO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV42K2BToolsGenericSearchField = "";
         AV31UsuarioNombre = "";
         AV58UsuarioFecha_From = DateTime.MinValue;
         AV30ClassCollection = new GxSimpleCollection<string>();
         AV59UsuarioFecha_To = DateTime.MinValue;
         AV65Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV62Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV40FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV41DeletedTag = "";
         AV44GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblockusuariofecha_Jsonclick = "";
         ucUsuariofecha_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         AV50Update = "";
         AV51Delete = "";
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
         AV67Update_GXI = "";
         AV68Delete_GXI = "";
         scmdbuf = "";
         lV31UsuarioNombre = "";
         lV42K2BToolsGenericSearchField = "";
         H002J2_A95UsuarioTelefono = new int[1] ;
         H002J2_A89UsuarioEmail = new string[] {""} ;
         H002J2_A94UsuarioRequerimiento = new string[] {""} ;
         H002J2_A88UsuarioDepartamento = new string[] {""} ;
         H002J2_A91UsuarioGerencia = new string[] {""} ;
         H002J2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         H002J2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H002J2_A93UsuarioNombre = new string[] {""} ;
         H002J2_A15UsuarioId = new long[1] ;
         H002J3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV56UsuarioFecha = DateTime.MinValue;
         AV45GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV47Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV48Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV54ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV55ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV27GridStateKey = "";
         AV28GridState = new SdtK2BGridState(context);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV52TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV38K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV39K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV60OutFile = "";
         AV61Guid = (Guid)(Guid.Empty);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwusuario__default(),
            new Object[][] {
                new Object[] {
               H002J2_A95UsuarioTelefono, H002J2_A89UsuarioEmail, H002J2_A94UsuarioRequerimiento, H002J2_A88UsuarioDepartamento, H002J2_A91UsuarioGerencia, H002J2_A92UsuarioHora, H002J2_A90UsuarioFecha, H002J2_A93UsuarioNombre, H002J2_A15UsuarioId
               }
               , new Object[] {
               H002J3_AGRID_nRecordCount
               }
            }
         );
         AV65Pgmname = "WWUsuario";
         /* GeneXus formulas. */
         AV65Pgmname = "WWUsuario";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV46UC_OrderedBy ;
      private short AV25RowsPerPageVariable ;
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
      private short AV24GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_180 ;
      private int nGXsfl_180_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuarioid_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtUsuarioId_Visible ;
      private int edtUsuarioNombre_Visible ;
      private int edtUsuarioFecha_Visible ;
      private int edtUsuarioHora_Visible ;
      private int edtUsuarioGerencia_Visible ;
      private int edtUsuarioDepartamento_Visible ;
      private int edtUsuarioRequerimiento_Visible ;
      private int edtUsuarioEmail_Visible ;
      private int edtUsuarioTelefono_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int A95UsuarioTelefono ;
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
      private int AV66GXV1 ;
      private int AV69GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV70GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV71GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV57UsuarioId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_180_idx="0001" ;
      private string AV42K2BToolsGenericSearchField ;
      private string AV65Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV41DeletedTag ;
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
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuariofecha_Internalname ;
      private string lblTextblockusuariofecha_Internalname ;
      private string lblTextblockusuariofecha_Jsonclick ;
      private string Usuariofecha_daterangepicker_Internalname ;
      private string divK2btoolstable_attributecontainerusuarioid_Internalname ;
      private string edtavUsuarioid_Internalname ;
      private string edtavUsuarioid_Jsonclick ;
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
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioHora_Internalname ;
      private string edtUsuarioGerencia_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioTelefono_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV42K2BToolsGenericSearchField ;
      private string chkavAtt_usuarioid_visible_Internalname ;
      private string chkavAtt_usuarionombre_visible_Internalname ;
      private string chkavAtt_usuariofecha_visible_Internalname ;
      private string chkavAtt_usuariohora_visible_Internalname ;
      private string chkavAtt_usuariogerencia_visible_Internalname ;
      private string chkavAtt_usuariodepartamento_visible_Internalname ;
      private string chkavAtt_usuariorequerimiento_visible_Internalname ;
      private string chkavAtt_usuarioemail_visible_Internalname ;
      private string chkavAtt_usuariotelefono_visible_Internalname ;
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
      private string divUsuarioid_gridsettingscontainer_Internalname ;
      private string divUsuarionombre_gridsettingscontainer_Internalname ;
      private string divUsuariofecha_gridsettingscontainer_Internalname ;
      private string divUsuariohora_gridsettingscontainer_Internalname ;
      private string divUsuariogerencia_gridsettingscontainer_Internalname ;
      private string divUsuariodepartamento_gridsettingscontainer_Internalname ;
      private string divUsuariorequerimiento_gridsettingscontainer_Internalname ;
      private string divUsuarioemail_gridsettingscontainer_Internalname ;
      private string divUsuariotelefono_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_180_fel_idx="0001" ;
      private string ROClassString ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtUsuarioHora_Jsonclick ;
      private string edtUsuarioGerencia_Jsonclick ;
      private string edtUsuarioDepartamento_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtUsuarioEmail_Jsonclick ;
      private string edtUsuarioTelefono_Jsonclick ;
      private DateTime A92UsuarioHora ;
      private DateTime GXt_dtime3 ;
      private DateTime AV58UsuarioFecha_From ;
      private DateTime AV59UsuarioFecha_To ;
      private DateTime A90UsuarioFecha ;
      private DateTime AV56UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV49UsuarioNombre_IsAuthorized ;
      private bool AV14Att_UsuarioId_Visible ;
      private bool AV15Att_UsuarioNombre_Visible ;
      private bool AV16Att_UsuarioFecha_Visible ;
      private bool AV17Att_UsuarioHora_Visible ;
      private bool AV18Att_UsuarioGerencia_Visible ;
      private bool AV19Att_UsuarioDepartamento_Visible ;
      private bool AV20Att_UsuarioRequerimiento_Visible ;
      private bool AV21Att_UsuarioEmail_Visible ;
      private bool AV22Att_UsuarioTelefono_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_180_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV26RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV50Update_IsBlob ;
      private bool AV51Delete_IsBlob ;
      private string AV31UsuarioNombre ;
      private string AV62Uri ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private string AV67Update_GXI ;
      private string AV68Delete_GXI ;
      private string lV31UsuarioNombre ;
      private string AV27GridStateKey ;
      private string AV60OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private string AV50Update ;
      private string AV51Delete ;
      private Guid AV61Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucUsuariofecha_daterangepicker ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_usuarioid_visible ;
      private GXCheckbox chkavAtt_usuarionombre_visible ;
      private GXCheckbox chkavAtt_usuariofecha_visible ;
      private GXCheckbox chkavAtt_usuariohora_visible ;
      private GXCheckbox chkavAtt_usuariogerencia_visible ;
      private GXCheckbox chkavAtt_usuariodepartamento_visible ;
      private GXCheckbox chkavAtt_usuariorequerimiento_visible ;
      private GXCheckbox chkavAtt_usuarioemail_visible ;
      private GXCheckbox chkavAtt_usuariotelefono_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private int[] H002J2_A95UsuarioTelefono ;
      private string[] H002J2_A89UsuarioEmail ;
      private string[] H002J2_A94UsuarioRequerimiento ;
      private string[] H002J2_A88UsuarioDepartamento ;
      private string[] H002J2_A91UsuarioGerencia ;
      private DateTime[] H002J2_A92UsuarioHora ;
      private DateTime[] H002J2_A90UsuarioFecha ;
      private string[] H002J2_A93UsuarioNombre ;
      private long[] H002J2_A15UsuarioId ;
      private long[] H002J3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV30ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV38K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV40FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV44GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV47Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV54ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV28GridState ;
      private SdtK2BGridState_FilterValue AV29GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV39K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV45GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV48Message ;
      private SdtK2BTrnContext AV52TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV55ActivityListItem ;
   }

   public class wwusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002J2( IGxContext context ,
                                             string AV31UsuarioNombre ,
                                             DateTime AV59UsuarioFecha_To ,
                                             DateTime AV58UsuarioFecha_From ,
                                             long AV57UsuarioId ,
                                             string AV42K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             long A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV43OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [UsuarioTelefono], [UsuarioEmail], [UsuarioRequerimiento], [UsuarioDepartamento], [UsuarioGerencia], [UsuarioHora], [UsuarioFecha], [UsuarioNombre], [UsuarioId]";
         sFromString = " FROM [Usuario]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV31UsuarioNombre)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV59UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV59UsuarioFecha_To)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV58UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV58UsuarioFecha_From)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV57UsuarioId) )
         {
            AddWhere(sWhereString, "([UsuarioId] = @AV57UsuarioId)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST([UsuarioId] AS decimal(10,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioNombre] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%')");
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
         }
         if ( AV43OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [UsuarioId]";
         }
         else if ( AV43OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [UsuarioId] DESC";
         }
         else if ( AV43OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [UsuarioNombre]";
         }
         else if ( AV43OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [UsuarioNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [UsuarioId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002J3( IGxContext context ,
                                             string AV31UsuarioNombre ,
                                             DateTime AV59UsuarioFecha_To ,
                                             DateTime AV58UsuarioFecha_From ,
                                             long AV57UsuarioId ,
                                             string AV42K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             long A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV43OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[11];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Usuario]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV31UsuarioNombre)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV59UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV59UsuarioFecha_To)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV58UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV58UsuarioFecha_From)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV57UsuarioId) )
         {
            AddWhere(sWhereString, "([UsuarioId] = @AV57UsuarioId)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST([UsuarioId] AS decimal(10,0))) like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioNombre] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV42K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV42K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV42K2BToolsGenericSearchField + '%')");
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
         }
         scmdbuf += sWhereString;
         if ( AV43OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV43OrderedBy == 3 )
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
                     return conditional_H002J2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (short)dynConstraints[13] );
               case 1 :
                     return conditional_H002J3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmH002J2;
          prmH002J2 = new Object[] {
          new ParDef("@lV31UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV59UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV58UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV57UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002J3;
          prmH002J3 = new Object[] {
          new ParDef("@lV31UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV59UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV58UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV57UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV42K2BToolsGenericSearchField",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
