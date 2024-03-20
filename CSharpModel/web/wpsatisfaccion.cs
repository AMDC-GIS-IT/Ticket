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
   public class wpsatisfaccion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpsatisfaccion( )
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

      public wpsatisfaccion( IGxContext context )
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
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
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
               nRC_GXsfl_110 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_110"), "."));
               nGXsfl_110_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_110_idx"), "."));
               sGXsfl_110_idx = GetPar( "sGXsfl_110_idx");
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
               AV64GenericFilter_Grid = GetPar( "GenericFilter_Grid");
               AV66Variable_FilterUsuario = GetPar( "Variable_FilterUsuario");
               AV67Variable_FilterEstado = GetPar( "Variable_FilterEstado");
               AV68Variable_FilterResponsable = GetPar( "Variable_FilterResponsable");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV55ClassCollection_Grid);
               AV69OrderedBy_Grid = (short)(NumberUtil.Val( GetPar( "OrderedBy_Grid"), "."));
               AV75Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV17GridConfiguration);
               AV54CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
               AV61FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
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
            return "wpsatisfaccion_Execute" ;
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
         PA5U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5U2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188211754", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpsatisfaccion.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vGENERICFILTER_GRID", StringUtil.RTrim( AV64GenericFilter_Grid));
         GxWebStd.gx_hidden_field( context, "GXH_vVARIABLE_FILTERUSUARIO", AV66Variable_FilterUsuario);
         GxWebStd.gx_hidden_field( context, "GXH_vVARIABLE_FILTERESTADO", AV67Variable_FilterEstado);
         GxWebStd.gx_hidden_field( context, "GXH_vVARIABLE_FILTERRESPONSABLE", AV68Variable_FilterResponsable);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_GRID", AV62FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_GRID", AV62FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_GRID", StringUtil.RTrim( AV63DeletedTag_Grid));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS_GRID", AV71GridOrders_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS_GRID", AV71GridOrders_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vSELECTEDORDERBY_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70SelectedOrderBy_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54CurrentPage_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV55ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV55ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV17GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV17GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69OrderedBy_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMA", A191UsuarioSistema);
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "ORDERBYUC_GRID_Gridcontrolname", StringUtil.RTrim( Orderbyuc_grid_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE5U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5U2( ) ;
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
         return formatLink("wpsatisfaccion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPSatisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Satisfacción Usuario" ;
      }

      protected void WB5U0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Encuesta Satisfacción Soporte Técnico", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section4_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_grid_Internalname, "Generic Filter_Grid", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV64GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV64GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_grid_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_grid_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPSatisfaccion.htm");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV62FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV63DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, "FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, divLayoutdefined_filtercollapsiblesection_combined_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPSatisfaccion.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters1_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_variable_filterusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavVariable_filterusuario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVariable_filterusuario_Internalname, "Usuario", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVariable_filterusuario_Internalname, AV66Variable_FilterUsuario, StringUtil.RTrim( context.localUtil.Format( AV66Variable_FilterUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVariable_filterusuario_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavVariable_filterusuario_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_variable_filterestado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavVariable_filterestado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVariable_filterestado_Internalname, "Estado Ticket", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVariable_filterestado_Internalname, AV67Variable_FilterEstado, StringUtil.RTrim( context.localUtil.Format( AV67Variable_FilterEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVariable_filterestado_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavVariable_filterestado_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_variable_filterresponsable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavVariable_filterresponsable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVariable_filterresponsable_Internalname, "Técnico", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVariable_filterresponsable_Internalname, AV68Variable_FilterResponsable, StringUtil.RTrim( context.localUtil.Format( AV68Variable_FilterResponsable, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVariable_filterresponsable_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavVariable_filterresponsable_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSatisfaccion.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_63_5U2( true) ;
         }
         else
         {
            wb_table1_63_5U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_63_5U2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
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
            wb_table2_107_5U2( true) ;
         }
         else
         {
            wb_table2_107_5U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_107_5U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_131_5U2( true) ;
         }
         else
         {
            wb_table3_131_5U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_131_5U2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_grid_Internalname, divPaginationbar_pagingcontainertable_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 5, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_Internalname, lblPaginationbar_lastpagetextblockgrid_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 5, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 110 )
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

      protected void START5U2( )
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
            Form.Meta.addItem("description", "Satisfacción Usuario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5U0( ) ;
      }

      protected void WS5U2( )
      {
         START5U2( ) ;
         EVT5U2( ) ;
      }

      protected void EVT5U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTAGSUSERCONTROL_GRID.TAGDELETED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBYUC_GRID.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid)' */
                              E135U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid)' */
                              E145U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid)' */
                              E155U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid)' */
                              E165U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E175U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E185U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E195U2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'E_ACTIONENCUESTA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'E_ACTIONENCUESTA'") == 0 ) )
                           {
                              nGXsfl_110_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
                              SubsflControlProps_1102( ) ;
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                              A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFecha_Internalname), 0));
                              A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname), 0));
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ".", ","));
                              A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
                              A189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ".", ","));
                              A190EstadoTicketUsuarioNombre = cgiGet( edtEstadoTicketUsuarioNombre_Internalname);
                              AV65ActionEncuesta_Action = cgiGet( edtavActionencuesta_action_Internalname);
                              AssignProp("", false, edtavActionencuesta_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65ActionEncuesta_Action)) ? AV76Actionencuesta_action_GXI : context.convertURL( context.PathToRelativeUrl( AV65ActionEncuesta_Action))), !bGXsfl_110_Refreshing);
                              AssignProp("", false, edtavActionencuesta_action_Internalname, "SrcSet", context.GetImageSrcSet( AV65ActionEncuesta_Action), true);
                              A290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( edtEtapaDesarrolloId_Internalname), ".", ","));
                              n290EtapaDesarrolloId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E205U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E215U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E225U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E235U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ACTIONENCUESTA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ActionEncuesta' */
                                    E245U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Genericfilter_grid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRID"), AV64GenericFilter_Grid) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Variable_filterusuario Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERUSUARIO"), AV66Variable_FilterUsuario) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Variable_filterestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERESTADO"), AV67Variable_FilterEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Variable_filterresponsable Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERRESPONSABLE"), AV68Variable_FilterResponsable) != 0 )
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

      protected void WE5U2( )
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

      protected void PA5U2( )
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
               GX_FocusControl = edtavGenericfilter_grid_Internalname;
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
         SubsflControlProps_1102( ) ;
         while ( nGXsfl_110_idx <= nRC_GXsfl_110 )
         {
            sendrow_1102( ) ;
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV64GenericFilter_Grid ,
                                       string AV66Variable_FilterUsuario ,
                                       string AV67Variable_FilterEstado ,
                                       string AV68Variable_FilterResponsable ,
                                       GxSimpleCollection<string> AV55ClassCollection_Grid ,
                                       short AV69OrderedBy_Grid ,
                                       string AV75Pgmname ,
                                       SdtK2BGridConfiguration AV17GridConfiguration ,
                                       short AV54CurrentPage_Grid ,
                                       bool AV61FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E205U2 ();
         GRID_nCurrentRecord = 0;
         RF5U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV59GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV59GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV61FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV61FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV61FreezeColumnTitles_Grid", AV61FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E205U2 ();
         RF5U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV75Pgmname = "WPSatisfaccion";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A290EtapaDesarrolloId ,
                                              AV66Variable_FilterUsuario ,
                                              AV67Variable_FilterEstado ,
                                              AV68Variable_FilterResponsable ,
                                              AV64GenericFilter_Grid ,
                                              A93UsuarioNombre ,
                                              A188EstadoTicketTicketNombre ,
                                              A199TicketTecnicoResponsableNombre ,
                                              A14TicketId ,
                                              A94UsuarioRequerimiento ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A190EstadoTicketUsuarioNombre ,
                                              AV69OrderedBy_Grid ,
                                              A191UsuarioSistema ,
                                              A187EstadoTicketTicketId ,
                                              A17EstadoTicketTecnicoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV66Variable_FilterUsuario = StringUtil.Concat( StringUtil.RTrim( AV66Variable_FilterUsuario), "%", "");
         lV67Variable_FilterEstado = StringUtil.Concat( StringUtil.RTrim( AV67Variable_FilterEstado), "%", "");
         lV68Variable_FilterResponsable = StringUtil.Concat( StringUtil.RTrim( AV68Variable_FilterResponsable), "%", "");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
         /* Using cursor H005U2 */
         pr_default.execute(0, new Object[] {lV66Variable_FilterUsuario, lV67Variable_FilterEstado, lV68Variable_FilterResponsable, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A188EstadoTicketTicketNombre = H005U2_A188EstadoTicketTicketNombre[0];
            A17EstadoTicketTecnicoId = H005U2_A17EstadoTicketTecnicoId[0];
            A187EstadoTicketTicketId = H005U2_A187EstadoTicketTicketId[0];
            A191UsuarioSistema = H005U2_A191UsuarioSistema[0];
            A290EtapaDesarrolloId = H005U2_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = H005U2_n290EtapaDesarrolloId[0];
            A190EstadoTicketUsuarioNombre = H005U2_A190EstadoTicketUsuarioNombre[0];
            A189EstadoTicketUsuarioId = H005U2_A189EstadoTicketUsuarioId[0];
            A199TicketTecnicoResponsableNombre = H005U2_A199TicketTecnicoResponsableNombre[0];
            A198TicketTecnicoResponsableId = H005U2_A198TicketTecnicoResponsableId[0];
            A90UsuarioFecha = H005U2_A90UsuarioFecha[0];
            A88UsuarioDepartamento = H005U2_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = H005U2_A91UsuarioGerencia[0];
            A94UsuarioRequerimiento = H005U2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = H005U2_A93UsuarioNombre[0];
            A15UsuarioId = H005U2_A15UsuarioId[0];
            A48TicketHora = H005U2_A48TicketHora[0];
            A46TicketFecha = H005U2_A46TicketFecha[0];
            A16TicketResponsableId = H005U2_A16TicketResponsableId[0];
            A14TicketId = H005U2_A14TicketId[0];
            A199TicketTecnicoResponsableNombre = H005U2_A199TicketTecnicoResponsableNombre[0];
            A187EstadoTicketTicketId = H005U2_A187EstadoTicketTicketId[0];
            A15UsuarioId = H005U2_A15UsuarioId[0];
            A48TicketHora = H005U2_A48TicketHora[0];
            A46TicketFecha = H005U2_A46TicketFecha[0];
            A188EstadoTicketTicketNombre = H005U2_A188EstadoTicketTicketNombre[0];
            A191UsuarioSistema = H005U2_A191UsuarioSistema[0];
            A189EstadoTicketUsuarioId = H005U2_A189EstadoTicketUsuarioId[0];
            A90UsuarioFecha = H005U2_A90UsuarioFecha[0];
            A88UsuarioDepartamento = H005U2_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = H005U2_A91UsuarioGerencia[0];
            A94UsuarioRequerimiento = H005U2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = H005U2_A93UsuarioNombre[0];
            A190EstadoTicketUsuarioNombre = H005U2_A190EstadoTicketUsuarioNombre[0];
            if ( StringUtil.StrCmp(A191UsuarioSistema, AV34WebSession.Get("UsuarioConectado")) == 0 )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF5U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         E235U2 ();
         nGXsfl_110_idx = 1;
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         bGXsfl_110_Refreshing = true;
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
            SubsflControlProps_1102( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A290EtapaDesarrolloId ,
                                                 AV66Variable_FilterUsuario ,
                                                 AV67Variable_FilterEstado ,
                                                 AV68Variable_FilterResponsable ,
                                                 AV64GenericFilter_Grid ,
                                                 A93UsuarioNombre ,
                                                 A188EstadoTicketTicketNombre ,
                                                 A199TicketTecnicoResponsableNombre ,
                                                 A14TicketId ,
                                                 A94UsuarioRequerimiento ,
                                                 A91UsuarioGerencia ,
                                                 A88UsuarioDepartamento ,
                                                 A190EstadoTicketUsuarioNombre ,
                                                 AV69OrderedBy_Grid ,
                                                 A191UsuarioSistema ,
                                                 A187EstadoTicketTicketId ,
                                                 A17EstadoTicketTecnicoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV66Variable_FilterUsuario = StringUtil.Concat( StringUtil.RTrim( AV66Variable_FilterUsuario), "%", "");
            lV67Variable_FilterEstado = StringUtil.Concat( StringUtil.RTrim( AV67Variable_FilterEstado), "%", "");
            lV68Variable_FilterResponsable = StringUtil.Concat( StringUtil.RTrim( AV68Variable_FilterResponsable), "%", "");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            lV64GenericFilter_Grid = StringUtil.PadR( StringUtil.RTrim( AV64GenericFilter_Grid), 100, "%");
            /* Using cursor H005U3 */
            pr_default.execute(1, new Object[] {lV66Variable_FilterUsuario, lV67Variable_FilterEstado, lV68Variable_FilterResponsable, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid, lV64GenericFilter_Grid});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A188EstadoTicketTicketNombre = H005U3_A188EstadoTicketTicketNombre[0];
               A17EstadoTicketTecnicoId = H005U3_A17EstadoTicketTecnicoId[0];
               A187EstadoTicketTicketId = H005U3_A187EstadoTicketTicketId[0];
               A191UsuarioSistema = H005U3_A191UsuarioSistema[0];
               A290EtapaDesarrolloId = H005U3_A290EtapaDesarrolloId[0];
               n290EtapaDesarrolloId = H005U3_n290EtapaDesarrolloId[0];
               A190EstadoTicketUsuarioNombre = H005U3_A190EstadoTicketUsuarioNombre[0];
               A189EstadoTicketUsuarioId = H005U3_A189EstadoTicketUsuarioId[0];
               A199TicketTecnicoResponsableNombre = H005U3_A199TicketTecnicoResponsableNombre[0];
               A198TicketTecnicoResponsableId = H005U3_A198TicketTecnicoResponsableId[0];
               A90UsuarioFecha = H005U3_A90UsuarioFecha[0];
               A88UsuarioDepartamento = H005U3_A88UsuarioDepartamento[0];
               A91UsuarioGerencia = H005U3_A91UsuarioGerencia[0];
               A94UsuarioRequerimiento = H005U3_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H005U3_A93UsuarioNombre[0];
               A15UsuarioId = H005U3_A15UsuarioId[0];
               A48TicketHora = H005U3_A48TicketHora[0];
               A46TicketFecha = H005U3_A46TicketFecha[0];
               A16TicketResponsableId = H005U3_A16TicketResponsableId[0];
               A14TicketId = H005U3_A14TicketId[0];
               A199TicketTecnicoResponsableNombre = H005U3_A199TicketTecnicoResponsableNombre[0];
               A187EstadoTicketTicketId = H005U3_A187EstadoTicketTicketId[0];
               A15UsuarioId = H005U3_A15UsuarioId[0];
               A48TicketHora = H005U3_A48TicketHora[0];
               A46TicketFecha = H005U3_A46TicketFecha[0];
               A188EstadoTicketTicketNombre = H005U3_A188EstadoTicketTicketNombre[0];
               A191UsuarioSistema = H005U3_A191UsuarioSistema[0];
               A189EstadoTicketUsuarioId = H005U3_A189EstadoTicketUsuarioId[0];
               A90UsuarioFecha = H005U3_A90UsuarioFecha[0];
               A88UsuarioDepartamento = H005U3_A88UsuarioDepartamento[0];
               A91UsuarioGerencia = H005U3_A91UsuarioGerencia[0];
               A94UsuarioRequerimiento = H005U3_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H005U3_A93UsuarioNombre[0];
               A190EstadoTicketUsuarioNombre = H005U3_A190EstadoTicketUsuarioNombre[0];
               if ( StringUtil.StrCmp(A191UsuarioSistema, AV34WebSession.Get("UsuarioConectado")) == 0 )
               {
                  E225U2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 110;
            WB5U0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ETAPADESARROLLOID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETRESPONSABLEID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICORESPONSABLEID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV75Pgmname = "WPSatisfaccion";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E215U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_GRID"), AV62FilterTagsCollection_Grid);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS_GRID"), AV71GridOrders_Grid);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV63DeletedTag_Grid = cgiGet( "vDELETEDTAG_GRID");
            AV70SelectedOrderBy_Grid = (short)(context.localUtil.CToN( cgiGet( "vSELECTEDORDERBY_GRID"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            Orderbyuc_grid_Gridcontrolname = cgiGet( "ORDERBYUC_GRID_Gridcontrolname");
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible"), ".", ","));
            /* Read variables values. */
            AV64GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV64GenericFilter_Grid", AV64GenericFilter_Grid);
            AV66Variable_FilterUsuario = cgiGet( edtavVariable_filterusuario_Internalname);
            AssignAttri("", false, "AV66Variable_FilterUsuario", AV66Variable_FilterUsuario);
            AV67Variable_FilterEstado = cgiGet( edtavVariable_filterestado_Internalname);
            AssignAttri("", false, "AV67Variable_FilterEstado", AV67Variable_FilterEstado);
            AV68Variable_FilterResponsable = cgiGet( edtavVariable_filterresponsable_Internalname);
            AssignAttri("", false, "AV68Variable_FilterResponsable", AV68Variable_FilterResponsable);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV59GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV59GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
            AV61FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV61FreezeColumnTitles_Grid", AV61FreezeColumnTitles_Grid);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRID"), AV64GenericFilter_Grid) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERUSUARIO"), AV66Variable_FilterUsuario) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERESTADO"), AV67Variable_FilterEstado) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vVARIABLE_FILTERRESPONSABLE"), AV68Variable_FilterResponsable) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E205U2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( (0==AV54CurrentPage_Grid) )
         {
            AV54CurrentPage_Grid = 1;
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
         }
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV55ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E215U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215U2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV75Pgmname,  "Grid", out  AV57RowsPerPage_Grid, out  AV58RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV57RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV57RowsPerPage_Grid), 4, 0));
         if ( ! AV58RowsPerPageLoaded_Grid )
         {
            AV57RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV57RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV57RowsPerPage_Grid), 4, 0));
         }
         AV59GridSettingsRowsPerPage_Grid = AV57RowsPerPage_Grid;
         AssignAttri("", false, "AV59GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
         subGrid_Rows = AV57RowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Orderbyuc_grid_Gridcontrolname = subGrid_Internalname;
         ucOrderbyuc_grid.SendProperty(context, "", false, Orderbyuc_grid_Internalname, "GridControlName", Orderbyuc_grid_Gridcontrolname);
         AV71GridOrders_Grid = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV72GridOrder_Grid = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV72GridOrder_Grid.gxTpr_Ascendingorder = 0;
         AV72GridOrder_Grid.gxTpr_Descendingorder = 1;
         AV72GridOrder_Grid.gxTpr_Gridcolumnindex = 1;
         AV71GridOrders_Grid.Add(AV72GridOrder_Grid, 0);
         AV72GridOrder_Grid = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV72GridOrder_Grid.gxTpr_Ascendingorder = 2;
         AV72GridOrder_Grid.gxTpr_Descendingorder = 3;
         AV72GridOrder_Grid.gxTpr_Gridcolumnindex = 2;
         AV71GridOrders_Grid.Add(AV72GridOrder_Grid, 0);
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S222( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV61FreezeColumnTitles_Grid = AV17GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV61FreezeColumnTitles_Grid", AV61FreezeColumnTitles_Grid);
         if ( AV61FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV55ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV55ClassCollection_Grid) ;
         }
      }

      protected void S122( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "Grid", ref  AV17GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E225U2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            AV65ActionEncuesta_Action = context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( ));
            AssignAttri("", false, edtavActionencuesta_action_Internalname, AV65ActionEncuesta_Action);
            AV76Actionencuesta_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )));
            edtavActionencuesta_action_Tooltiptext = "Action Encuesta";
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 110;
            }
            sendrow_1102( ) ;
            GRID_nEOF = 1;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
            {
               GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
            }
         }
         if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         }
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_110_Refreshing )
         {
            context.DoAjaxLoad(110, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E235U2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV55ClassCollection_Grid) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV70SelectedOrderBy_Grid = AV69OrderedBy_Grid;
         AssignAttri("", false, "AV70SelectedOrderBy_Grid", StringUtil.LTrimStr( (decimal)(AV70SelectedOrderBy_Grid), 4, 0));
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV55ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62FilterTagsCollection_Grid", AV62FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
      }

      protected void S192( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         edtTicketId_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketId_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketId_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtTicketHora_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketHora_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketHora_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtTicketFecha_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketFecha_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtUsuarioNombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioNombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtUsuarioGerencia_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioGerencia_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtUsuarioDepartamento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioDepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtUsuarioRequerimiento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtUsuarioFecha_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioFecha_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtTicketTecnicoResponsableNombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketTecnicoResponsableNombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
         edtEstadoTicketUsuarioNombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtEstadoTicketUsuarioNombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtEstadoTicketUsuarioNombre_Forecolor), 9, 0), !bGXsfl_110_Refreshing);
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV13GridState.gxTpr_Orderedby = AV69OrderedBy_Grid;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "Variable_FilterUsuario";
         AV14GridStateFilterValue.gxTpr_Value = AV66Variable_FilterUsuario;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "Variable_FilterEstado";
         AV14GridStateFilterValue.gxTpr_Value = AV67Variable_FilterEstado;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "Variable_FilterResponsable";
         AV14GridStateFilterValue.gxTpr_Value = AV68Variable_FilterResponsable;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV14GridStateFilterValue.gxTpr_Value = AV64GenericFilter_Grid;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV75Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV12GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV69OrderedBy_Grid = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV69OrderedBy_Grid", StringUtil.LTrimStr( (decimal)(AV69OrderedBy_Grid), 4, 0));
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV77GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "Variable_FilterUsuario") == 0 )
            {
               AV66Variable_FilterUsuario = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66Variable_FilterUsuario", AV66Variable_FilterUsuario);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "Variable_FilterEstado") == 0 )
            {
               AV67Variable_FilterEstado = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67Variable_FilterEstado", AV67Variable_FilterEstado);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "Variable_FilterResponsable") == 0 )
            {
               AV68Variable_FilterResponsable = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68Variable_FilterResponsable", AV68Variable_FilterResponsable);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV64GenericFilter_Grid = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64GenericFilter_Grid", AV64GenericFilter_Grid);
            }
            AV77GXV1 = (int)(AV77GXV1+1);
         }
         AV60PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV60PageCount_Grid ) )
         {
            AV54CurrentPage_Grid = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
            subgrid_gotopage( AV54CurrentPage_Grid) ;
         }
      }

      protected void E135U2( )
      {
         /* 'PagingFirst(Grid)' Routine */
         returnInSub = false;
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E145U2( )
      {
         /* 'PagingPrevious(Grid)' Routine */
         returnInSub = false;
         subgrid_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         AV60PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( AV54CurrentPage_Grid > AV60PageCount_Grid )
         {
            AV54CurrentPage_Grid = AV60PageCount_Grid;
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
            subgrid_lastpage( ) ;
         }
         if ( AV60PageCount_Grid == 0 )
         {
            AV54CurrentPage_Grid = 0;
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
         }
         else
         {
            AV54CurrentPage_Grid = (short)(subGrid_fnc_Currentpage( ));
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV54CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV54CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV54CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV60PageCount_Grid), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV54CurrentPage_Grid) || ( AV54CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV54CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV54CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( AV54CurrentPage_Grid == AV60PageCount_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_lastpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            if ( AV54CurrentPage_Grid == AV60PageCount_Grid - 1 )
            {
               lblPaginationbar_lastpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_lastpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgrid_Visible), 5, 0), true);
               if ( AV54CurrentPage_Grid == AV60PageCount_Grid - 2 )
               {
                  lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV54CurrentPage_Grid <= 1 ) && ( AV60PageCount_Grid <= 1 ) )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void E155U2( )
      {
         /* 'PagingNext(Grid)' Routine */
         returnInSub = false;
         subgrid_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E165U2( )
      {
         /* 'PagingLast(Grid)' Routine */
         returnInSub = false;
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E175U2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "Grid", ref  AV17GridConfiguration) ;
         AV17GridConfiguration.gxTpr_Freezecolumntitles = AV61FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV75Pgmname,  "Grid",  AV17GridConfiguration,  true) ;
         subGrid_Rows = AV59GridSettingsRowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         if ( AV57RowsPerPage_Grid != AV59GridSettingsRowsPerPage_Grid )
         {
            AV57RowsPerPage_Grid = AV59GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV57RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV57RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV75Pgmname,  "Grid",  AV57RowsPerPage_Grid) ;
            AV54CurrentPage_Grid = 1;
            AssignAttri("", false, "AV54CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV54CurrentPage_Grid), 4, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
      }

      protected void S162( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV15K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Variable_FilterUsuario)) )
         {
            AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "Variable_FilterUsuario";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Usuario";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV66Variable_FilterUsuario;
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV66Variable_FilterUsuario;
            AV15K2BFilterValuesSDT_WebForm.Add(AV16K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Variable_FilterEstado)) )
         {
            AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "Variable_FilterEstado";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Estado Ticket";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV67Variable_FilterEstado;
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV67Variable_FilterEstado;
            AV15K2BFilterValuesSDT_WebForm.Add(AV16K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Variable_FilterResponsable)) )
         {
            AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "Variable_FilterResponsable";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Técnico";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV68Variable_FilterResponsable;
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV68Variable_FilterResponsable;
            AV15K2BFilterValuesSDT_WebForm.Add(AV16K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No hay filtros aplicados";
         ucFiltertagsusercontrol_grid.SendProperty(context, "", false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV15K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = AV62FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV75Pgmname,  "Grid",  AV15K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item2) ;
            AV62FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item2;
         }
      }

      protected void E115U2( )
      {
         /* Filtertagsusercontrol_grid_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV63DeletedTag_Grid, "Variable_FilterUsuario") == 0 )
         {
            AV66Variable_FilterUsuario = "";
            AssignAttri("", false, "AV66Variable_FilterUsuario", AV66Variable_FilterUsuario);
         }
         else if ( StringUtil.StrCmp(AV63DeletedTag_Grid, "Variable_FilterEstado") == 0 )
         {
            AV67Variable_FilterEstado = "";
            AssignAttri("", false, "AV67Variable_FilterEstado", AV67Variable_FilterEstado);
         }
         else if ( StringUtil.StrCmp(AV63DeletedTag_Grid, "Variable_FilterResponsable") == 0 )
         {
            AV68Variable_FilterResponsable = "";
            AssignAttri("", false, "AV68Variable_FilterResponsable", AV68Variable_FilterResponsable);
         }
         gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
      }

      protected void E185U2( )
      {
         /* Layoutdefined_filtertoggle_combined_grid_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_combined_grid_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E195U2( )
      {
         /* Layoutdefined_filterclose_combined_grid_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_grid_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_grid_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void E245U2( )
      {
         /* 'E_ActionEncuesta' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ACTIONENCUESTA' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
      }

      protected void S212( )
      {
         /* 'U_ACTIONENCUESTA' Routine */
         returnInSub = false;
         if ( A290EtapaDesarrolloId == 8 )
         {
            context.PopUp(formatLink("wpregistrarsatisfaccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(A16TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(A93UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(A198TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(A199TicketTecnicoResponsableNombre)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre","EtapaDesarrolloId"}) , new Object[] {});
         }
         else
         {
            if ( A290EtapaDesarrolloId == 7 )
            {
               context.PopUp(formatLink("wpregistrarencuestadesarrollo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(A16TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(A93UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(A198TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(A199TicketTecnicoResponsableNombre)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre","EtapaDesarrolloId"}) , new Object[] {});
            }
         }
         context.DoAjaxRefresh();
      }

      protected void E125U2( )
      {
         /* Orderbyuc_grid_Orderbychanged Routine */
         returnInSub = false;
         AV69OrderedBy_Grid = AV70SelectedOrderBy_Grid;
         AssignAttri("", false, "AV69OrderedBy_Grid", StringUtil.LTrimStr( (decimal)(AV69OrderedBy_Grid), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV64GenericFilter_Grid, AV66Variable_FilterUsuario, AV67Variable_FilterEstado, AV68Variable_FilterResponsable, AV55ClassCollection_Grid, AV69OrderedBy_Grid, AV75Pgmname, AV17GridConfiguration, AV54CurrentPage_Grid, AV61FreezeColumnTitles_Grid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55ClassCollection_Grid", AV55ClassCollection_Grid);
      }

      protected void wb_table3_131_5U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_131_5U2e( true) ;
         }
         else
         {
            wb_table3_131_5U2e( false) ;
         }
      }

      protected void wb_table2_107_5U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_grid_Internalname, tblTablegridcontainer_grid_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"110\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Requerimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gerencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Departamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Estado Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado Ticket") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
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
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketId_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFecha_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "));
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHora_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombre_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A91UsuarioGerencia);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioGerencia_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioDepartamento_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFecha_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A190EstadoTicketUsuarioNombre);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketUsuarioNombre_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV65ActionEncuesta_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActionencuesta_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")));
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
         if ( wbEnd == 110 )
         {
            wbEnd = 0;
            nRC_GXsfl_110 = (int)(nGXsfl_110_idx-1);
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucOrderbyuc_grid.SetProperty("GridOrders", AV71GridOrders_Grid);
            ucOrderbyuc_grid.SetProperty("SelectedOrderBy", AV70SelectedOrderBy_Grid);
            ucOrderbyuc_grid.Render(context, "k2borderby", Orderbyuc_grid_Internalname, "ORDERBYUC_GRIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_107_5U2e( true) ;
         }
         else
         {
            wb_table2_107_5U2e( false) ;
         }
      }

      protected void wb_table1_63_5U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_Internalname, tblLayoutdefined_table7_grid_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e255u1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_Internalname, divGridsettings_contentoutertablegrid_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WPSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 1, "HLP_WPSatisfaccion.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, "Inmovilizar títulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_110_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV61FreezeColumnTitles_Grid), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,95);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Aplicar", bttGridsettings_savegrid_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPSatisfaccion.htm");
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
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_63_5U2e( true) ;
         }
         else
         {
            wb_table1_63_5U2e( false) ;
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
         PA5U2( ) ;
         WS5U2( ) ;
         WE5U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188212184", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wpsatisfaccion.js", "?2024188212185", false, true);
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1102( )
      {
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_110_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_110_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_110_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_110_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_110_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_110_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_110_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_110_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_110_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_110_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_110_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_110_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_110_idx;
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE_"+sGXsfl_110_idx;
         edtavActionencuesta_action_Internalname = "vACTIONENCUESTA_ACTION_"+sGXsfl_110_idx;
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_110_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_110_fel_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_110_fel_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_110_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_110_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_110_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_110_fel_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_110_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_110_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_110_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_110_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_110_fel_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_110_fel_idx;
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE_"+sGXsfl_110_fel_idx;
         edtavActionencuesta_action_Internalname = "vACTIONENCUESTA_ACTION_"+sGXsfl_110_fel_idx;
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB5U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_110_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_110_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_110_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketId_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFecha_Internalname,context.localUtil.Format(A46TicketFecha, "99/99/9999"),context.localUtil.Format( A46TicketFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketFecha_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketFecha_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHora_Internalname,context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A48TicketHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHora_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketHora_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioNombre_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioRequerimiento_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioGerencia_Internalname,(string)A91UsuarioGerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioGerencia_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioGerencia_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioDepartamento_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioFecha_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketTecnicoResponsableNombre_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A189EstadoTicketUsuarioId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketUsuarioNombre_Internalname,(string)A190EstadoTicketUsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtEstadoTicketUsuarioNombre_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActionencuesta_action_Enabled!=0)&&(edtavActionencuesta_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 125,'',false,'',110)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV65ActionEncuesta_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV65ActionEncuesta_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV76Actionencuesta_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV65ActionEncuesta_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV65ActionEncuesta_Action)) ? AV76Actionencuesta_action_GXI : context.PathToRelativeUrl( AV65ActionEncuesta_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActionencuesta_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Action Encuesta",(string)edtavActionencuesta_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavActionencuesta_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ACTIONENCUESTA\\'."+sGXsfl_110_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV65ActionEncuesta_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEtapaDesarrolloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEtapaDesarrolloId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         /* End function sendrow_1102 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV59GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV59GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV59GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV61FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV61FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV61FreezeColumnTitles_Grid", AV61FreezeColumnTitles_Grid);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         imgLayoutdefined_filtertoggle_combined_grid_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID";
         Filtertagsusercontrol_grid_Internalname = "FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_section4_grid_Internalname = "LAYOUTDEFINED_SECTION4_GRID";
         imgLayoutdefined_filterclose_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID";
         edtavVariable_filterusuario_Internalname = "vVARIABLE_FILTERUSUARIO";
         divTable_container_variable_filterusuario_Internalname = "TABLE_CONTAINER_VARIABLE_FILTERUSUARIO";
         edtavVariable_filterestado_Internalname = "vVARIABLE_FILTERESTADO";
         divTable_container_variable_filterestado_Internalname = "TABLE_CONTAINER_VARIABLE_FILTERESTADO";
         edtavVariable_filterresponsable_Internalname = "vVARIABLE_FILTERRESPONSABLE";
         divTable_container_variable_filterresponsable_Internalname = "TABLE_CONTAINER_VARIABLE_FILTERRESPONSABLE";
         divFiltercontainertable_filters1_Internalname = "FILTERCONTAINERTABLE_FILTERS1";
         divMainfilterresponsivetable_filters1_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS1";
         divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID";
         divLayoutdefined_combinedfilterlayout_grid_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         imgGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = "ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = "vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRID";
         tblLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtTicketId_Internalname = "TICKETID";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtTicketFecha_Internalname = "TICKETFECHA";
         edtTicketHora_Internalname = "TICKETHORA";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE";
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID";
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE";
         edtavActionencuesta_action_Internalname = "vACTIONENCUESTA_ACTION";
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID";
         Orderbyuc_grid_Internalname = "ORDERBYUC_GRID";
         tblTablegridcontainer_grid_Internalname = "TABLEGRIDCONTAINER_GRID";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_lastpagetextblockgrid_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = "LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
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
         chkavFreezecolumntitles_grid.Caption = "Inmovilizar títulos";
         edtEtapaDesarrolloId_Jsonclick = "";
         edtavActionencuesta_action_Jsonclick = "";
         edtavActionencuesta_action_Visible = -1;
         edtavActionencuesta_action_Enabled = 1;
         edtEstadoTicketUsuarioNombre_Jsonclick = "";
         edtEstadoTicketUsuarioId_Jsonclick = "";
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioGerencia_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtTicketHora_Jsonclick = "";
         edtTicketFecha_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavActionencuesta_action_Tooltiptext = "";
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtEstadoTicketUsuarioNombre_Forecolor = (int)(0x000000);
         edtTicketTecnicoResponsableNombre_Forecolor = (int)(0x000000);
         edtUsuarioFecha_Forecolor = (int)(0x000000);
         edtUsuarioRequerimiento_Forecolor = (int)(0x000000);
         edtUsuarioDepartamento_Forecolor = (int)(0x000000);
         edtUsuarioGerencia_Forecolor = (int)(0x000000);
         edtUsuarioNombre_Forecolor = (int)(0x000000);
         edtTicketFecha_Forecolor = (int)(0x000000);
         edtTicketHora_Forecolor = (int)(0x000000);
         edtTicketId_Forecolor = (int)(0x000000);
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgrid_Caption = "1";
         lblPaginationbar_lastpagetextblockgrid_Visible = 1;
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_grid_Visible = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavVariable_filterresponsable_Jsonclick = "";
         edtavVariable_filterresponsable_Enabled = 1;
         edtavVariable_filterestado_Jsonclick = "";
         edtavVariable_filterestado_Enabled = 1;
         edtavVariable_filterusuario_Jsonclick = "";
         edtavVariable_filterusuario_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
         imgLayoutdefined_filtertoggle_combined_grid_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Satisfacción Usuario";
         subGrid_Rows = 20;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E225U2',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV65ActionEncuesta_Action',fld:'vACTIONENCUESTA_ACTION',pic:''},{av:'edtavActionencuesta_action_Tooltiptext',ctrl:'vACTIONENCUESTA_ACTION',prop:'Tooltiptext'},{av:'edtTicketId_Forecolor',ctrl:'TICKETID',prop:'Forecolor'},{av:'edtTicketHora_Forecolor',ctrl:'TICKETHORA',prop:'Forecolor'},{av:'edtTicketFecha_Forecolor',ctrl:'TICKETFECHA',prop:'Forecolor'},{av:'edtUsuarioNombre_Forecolor',ctrl:'USUARIONOMBRE',prop:'Forecolor'},{av:'edtUsuarioGerencia_Forecolor',ctrl:'USUARIOGERENCIA',prop:'Forecolor'},{av:'edtUsuarioDepartamento_Forecolor',ctrl:'USUARIODEPARTAMENTO',prop:'Forecolor'},{av:'edtUsuarioRequerimiento_Forecolor',ctrl:'USUARIOREQUERIMIENTO',prop:'Forecolor'},{av:'edtUsuarioFecha_Forecolor',ctrl:'USUARIOFECHA',prop:'Forecolor'},{av:'edtTicketTecnicoResponsableNombre_Forecolor',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Forecolor'},{av:'edtEstadoTicketUsuarioNombre_Forecolor',ctrl:'ESTADOTICKETUSUARIONOMBRE',prop:'Forecolor'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E235U2',iparms:[{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV70SelectedOrderBy_Grid',fld:'vSELECTEDORDERBY_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'AV62FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E135U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E145U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E155U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGLAST(GRID)'","{handler:'E165U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGLAST(GRID)'",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E255U1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E175U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV59GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV57RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("FILTERTAGSUSERCONTROL_GRID.TAGDELETED","{handler:'E115U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV63DeletedTag_Grid',fld:'vDELETEDTAG_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("FILTERTAGSUSERCONTROL_GRID.TAGDELETED",",oparms:[{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK","{handler:'E185U2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK","{handler:'E195U2',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ACTIONENCUESTA'","{handler:'E245U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'A290EtapaDesarrolloId',fld:'ETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'A199TicketTecnicoResponsableNombre',fld:'TICKETTECNICORESPONSABLENOMBRE',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ACTIONENCUESTA'",",oparms:[{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("ORDERBYUC_GRID.ORDERBYCHANGED","{handler:'E125U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV66Variable_FilterUsuario',fld:'vVARIABLE_FILTERUSUARIO',pic:''},{av:'AV67Variable_FilterEstado',fld:'vVARIABLE_FILTERESTADO',pic:''},{av:'AV68Variable_FilterResponsable',fld:'vVARIABLE_FILTERRESPONSABLE',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV70SelectedOrderBy_Grid',fld:'vSELECTEDORDERBY_GRID',pic:'ZZZ9'},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("ORDERBYUC_GRID.ORDERBYCHANGED",",oparms:[{av:'AV69OrderedBy_Grid',fld:'vORDEREDBY_GRID',pic:'ZZZ9'},{av:'AV54CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV55ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID","{handler:'Valid_Estadoticketusuarioid',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID",",oparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_ETAPADESARROLLOID","{handler:'Valid_Etapadesarrolloid',iparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_ETAPADESARROLLOID",",oparms:[{av:'AV61FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
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
         AV64GenericFilter_Grid = "";
         AV66Variable_FilterUsuario = "";
         AV67Variable_FilterEstado = "";
         AV68Variable_FilterResponsable = "";
         AV55ClassCollection_Grid = new GxSimpleCollection<string>();
         AV75Pgmname = "";
         AV17GridConfiguration = new SdtK2BGridConfiguration(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV62FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV63DeletedTag_Grid = "";
         AV71GridOrders_Grid = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         A191UsuarioSistema = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         Orderbyuc_grid_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         imgLayoutdefined_filterclose_combined_grid_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A90UsuarioFecha = DateTime.MinValue;
         A199TicketTecnicoResponsableNombre = "";
         A190EstadoTicketUsuarioNombre = "";
         AV65ActionEncuesta_Action = "";
         AV76Actionencuesta_action_GXI = "";
         scmdbuf = "";
         lV66Variable_FilterUsuario = "";
         lV67Variable_FilterEstado = "";
         lV68Variable_FilterResponsable = "";
         lV64GenericFilter_Grid = "";
         A188EstadoTicketTicketNombre = "";
         H005U2_A188EstadoTicketTicketNombre = new string[] {""} ;
         H005U2_A17EstadoTicketTecnicoId = new short[1] ;
         H005U2_A187EstadoTicketTicketId = new short[1] ;
         H005U2_A191UsuarioSistema = new string[] {""} ;
         H005U2_A290EtapaDesarrolloId = new short[1] ;
         H005U2_n290EtapaDesarrolloId = new bool[] {false} ;
         H005U2_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         H005U2_A189EstadoTicketUsuarioId = new short[1] ;
         H005U2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H005U2_A198TicketTecnicoResponsableId = new short[1] ;
         H005U2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H005U2_A88UsuarioDepartamento = new string[] {""} ;
         H005U2_A91UsuarioGerencia = new string[] {""} ;
         H005U2_A94UsuarioRequerimiento = new string[] {""} ;
         H005U2_A93UsuarioNombre = new string[] {""} ;
         H005U2_A15UsuarioId = new long[1] ;
         H005U2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H005U2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H005U2_A16TicketResponsableId = new long[1] ;
         H005U2_A14TicketId = new long[1] ;
         AV34WebSession = context.GetSession();
         H005U3_A188EstadoTicketTicketNombre = new string[] {""} ;
         H005U3_A17EstadoTicketTecnicoId = new short[1] ;
         H005U3_A187EstadoTicketTicketId = new short[1] ;
         H005U3_A191UsuarioSistema = new string[] {""} ;
         H005U3_A290EtapaDesarrolloId = new short[1] ;
         H005U3_n290EtapaDesarrolloId = new bool[] {false} ;
         H005U3_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         H005U3_A189EstadoTicketUsuarioId = new short[1] ;
         H005U3_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H005U3_A198TicketTecnicoResponsableId = new short[1] ;
         H005U3_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H005U3_A88UsuarioDepartamento = new string[] {""} ;
         H005U3_A91UsuarioGerencia = new string[] {""} ;
         H005U3_A94UsuarioRequerimiento = new string[] {""} ;
         H005U3_A93UsuarioNombre = new string[] {""} ;
         H005U3_A15UsuarioId = new long[1] ;
         H005U3_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H005U3_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H005U3_A16TicketResponsableId = new long[1] ;
         H005U3_A14TicketId = new long[1] ;
         ucOrderbyuc_grid = new GXUserControl();
         AV72GridOrder_Grid = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         GridRow = new GXWebRow();
         GXt_char1 = "";
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV15K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               H005U2_A188EstadoTicketTicketNombre, H005U2_A17EstadoTicketTecnicoId, H005U2_A187EstadoTicketTicketId, H005U2_A191UsuarioSistema, H005U2_A290EtapaDesarrolloId, H005U2_n290EtapaDesarrolloId, H005U2_A190EstadoTicketUsuarioNombre, H005U2_A189EstadoTicketUsuarioId, H005U2_A199TicketTecnicoResponsableNombre, H005U2_A198TicketTecnicoResponsableId,
               H005U2_A90UsuarioFecha, H005U2_A88UsuarioDepartamento, H005U2_A91UsuarioGerencia, H005U2_A94UsuarioRequerimiento, H005U2_A93UsuarioNombre, H005U2_A15UsuarioId, H005U2_A48TicketHora, H005U2_A46TicketFecha, H005U2_A16TicketResponsableId, H005U2_A14TicketId
               }
               , new Object[] {
               H005U3_A188EstadoTicketTicketNombre, H005U3_A17EstadoTicketTecnicoId, H005U3_A187EstadoTicketTicketId, H005U3_A191UsuarioSistema, H005U3_A290EtapaDesarrolloId, H005U3_n290EtapaDesarrolloId, H005U3_A190EstadoTicketUsuarioNombre, H005U3_A189EstadoTicketUsuarioId, H005U3_A199TicketTecnicoResponsableNombre, H005U3_A198TicketTecnicoResponsableId,
               H005U3_A90UsuarioFecha, H005U3_A88UsuarioDepartamento, H005U3_A91UsuarioGerencia, H005U3_A94UsuarioRequerimiento, H005U3_A93UsuarioNombre, H005U3_A15UsuarioId, H005U3_A48TicketHora, H005U3_A46TicketFecha, H005U3_A16TicketResponsableId, H005U3_A14TicketId
               }
            }
         );
         AV75Pgmname = "WPSatisfaccion";
         /* GeneXus formulas. */
         AV75Pgmname = "WPSatisfaccion";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV69OrderedBy_Grid ;
      private short AV54CurrentPage_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short AV70SelectedOrderBy_Grid ;
      private short AV57RowsPerPage_Grid ;
      private short A187EstadoTicketTicketId ;
      private short A17EstadoTicketTecnicoId ;
      private short wbEnd ;
      private short wbStart ;
      private short A198TicketTecnicoResponsableId ;
      private short A189EstadoTicketUsuarioId ;
      private short A290EtapaDesarrolloId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV59GridSettingsRowsPerPage_Grid ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV60PageCount_Grid ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_grid_Visible ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int subGrid_Rows ;
      private int edtavGenericfilter_grid_Enabled ;
      private int edtavVariable_filterusuario_Enabled ;
      private int edtavVariable_filterestado_Enabled ;
      private int edtavVariable_filterresponsable_Enabled ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int edtTicketId_Forecolor ;
      private int edtTicketHora_Forecolor ;
      private int edtTicketFecha_Forecolor ;
      private int edtUsuarioNombre_Forecolor ;
      private int edtUsuarioGerencia_Forecolor ;
      private int edtUsuarioDepartamento_Forecolor ;
      private int edtUsuarioRequerimiento_Forecolor ;
      private int edtUsuarioFecha_Forecolor ;
      private int edtTicketTecnicoResponsableNombre_Forecolor ;
      private int edtEstadoTicketUsuarioNombre_Forecolor ;
      private int AV77GXV1 ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavActionencuesta_action_Enabled ;
      private int edtavActionencuesta_action_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_110_idx="0001" ;
      private string AV64GenericFilter_Grid ;
      private string AV75Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV63DeletedTag_Grid ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string Orderbyuc_grid_Gridcontrolname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_combinedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_section4_grid_Internalname ;
      private string edtavGenericfilter_grid_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_grid_Jsonclick ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_combined_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_combined_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname ;
      private string imgLayoutdefined_filterclose_combined_grid_Internalname ;
      private string imgLayoutdefined_filterclose_combined_grid_Jsonclick ;
      private string divMainfilterresponsivetable_filters1_Internalname ;
      private string divFiltercontainertable_filters1_Internalname ;
      private string divTable_container_variable_filterusuario_Internalname ;
      private string edtavVariable_filterusuario_Internalname ;
      private string edtavVariable_filterusuario_Jsonclick ;
      private string divTable_container_variable_filterestado_Internalname ;
      private string edtavVariable_filterestado_Internalname ;
      private string edtavVariable_filterestado_Jsonclick ;
      private string divTable_container_variable_filterresponsable_Internalname ;
      private string edtavVariable_filterresponsable_Internalname ;
      private string edtavVariable_filterresponsable_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divLayoutdefined_section8_grid_Internalname ;
      private string divPaginationbar_pagingcontainertable_grid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Class ;
      private string lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private string lblPaginationbar_firstpagetextblockgrid_Caption ;
      private string lblPaginationbar_firstpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgrid_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagetextblockgrid_Caption ;
      private string lblPaginationbar_previouspagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private string lblPaginationbar_currentpagetextblockgrid_Caption ;
      private string lblPaginationbar_currentpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagetextblockgrid_Caption ;
      private string lblPaginationbar_nextpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgrid_Jsonclick ;
      private string lblPaginationbar_lastpagetextblockgrid_Internalname ;
      private string lblPaginationbar_lastpagetextblockgrid_Caption ;
      private string lblPaginationbar_lastpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTicketId_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioGerencia_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string edtEstadoTicketUsuarioId_Internalname ;
      private string edtEstadoTicketUsuarioNombre_Internalname ;
      private string edtavActionencuesta_action_Internalname ;
      private string edtEtapaDesarrolloId_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Internalname ;
      private string scmdbuf ;
      private string lV64GenericFilter_Grid ;
      private string chkavFreezecolumntitles_grid_Internalname ;
      private string subGrid_Internalname ;
      private string Orderbyuc_grid_Internalname ;
      private string divGridsettings_contentoutertablegrid_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavActionencuesta_action_Tooltiptext ;
      private string GXt_char1 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string tblTablegridcontainer_grid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string tblLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string imgGridsettings_labelgrid_Internalname ;
      private string imgGridsettings_labelgrid_Jsonclick ;
      private string divGslayoutdefined_gridcontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_grid_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private string divFreezecolumntitlescontainer_grid_Internalname ;
      private string bttGridsettings_savegrid_Internalname ;
      private string bttGridsettings_savegrid_Jsonclick ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string ROClassString ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketHora_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtUsuarioGerencia_Jsonclick ;
      private string edtUsuarioDepartamento_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string edtEstadoTicketUsuarioId_Jsonclick ;
      private string edtEstadoTicketUsuarioNombre_Jsonclick ;
      private string edtavActionencuesta_action_Jsonclick ;
      private string edtEtapaDesarrolloId_Jsonclick ;
      private DateTime A48TicketHora ;
      private DateTime A46TicketFecha ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV61FreezeColumnTitles_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool n290EtapaDesarrolloId ;
      private bool gxdyncontrolsrefreshing ;
      private bool gx_refresh_fired ;
      private bool returnInSub ;
      private bool AV58RowsPerPageLoaded_Grid ;
      private bool AV65ActionEncuesta_Action_IsBlob ;
      private string AV66Variable_FilterUsuario ;
      private string AV67Variable_FilterEstado ;
      private string AV68Variable_FilterResponsable ;
      private string A191UsuarioSistema ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A190EstadoTicketUsuarioNombre ;
      private string AV76Actionencuesta_action_GXI ;
      private string lV66Variable_FilterUsuario ;
      private string lV67Variable_FilterEstado ;
      private string lV68Variable_FilterResponsable ;
      private string A188EstadoTicketTicketNombre ;
      private string AV12GridStateKey ;
      private string imgLayoutdefined_filtertoggle_combined_grid_Bitmap ;
      private string AV65ActionEncuesta_Action ;
      private IGxSession AV34WebSession ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucOrderbyuc_grid ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private IDataStoreProvider pr_default ;
      private string[] H005U2_A188EstadoTicketTicketNombre ;
      private short[] H005U2_A17EstadoTicketTecnicoId ;
      private short[] H005U2_A187EstadoTicketTicketId ;
      private string[] H005U2_A191UsuarioSistema ;
      private short[] H005U2_A290EtapaDesarrolloId ;
      private bool[] H005U2_n290EtapaDesarrolloId ;
      private string[] H005U2_A190EstadoTicketUsuarioNombre ;
      private short[] H005U2_A189EstadoTicketUsuarioId ;
      private string[] H005U2_A199TicketTecnicoResponsableNombre ;
      private short[] H005U2_A198TicketTecnicoResponsableId ;
      private DateTime[] H005U2_A90UsuarioFecha ;
      private string[] H005U2_A88UsuarioDepartamento ;
      private string[] H005U2_A91UsuarioGerencia ;
      private string[] H005U2_A94UsuarioRequerimiento ;
      private string[] H005U2_A93UsuarioNombre ;
      private long[] H005U2_A15UsuarioId ;
      private DateTime[] H005U2_A48TicketHora ;
      private DateTime[] H005U2_A46TicketFecha ;
      private long[] H005U2_A16TicketResponsableId ;
      private long[] H005U2_A14TicketId ;
      private string[] H005U3_A188EstadoTicketTicketNombre ;
      private short[] H005U3_A17EstadoTicketTecnicoId ;
      private short[] H005U3_A187EstadoTicketTicketId ;
      private string[] H005U3_A191UsuarioSistema ;
      private short[] H005U3_A290EtapaDesarrolloId ;
      private bool[] H005U3_n290EtapaDesarrolloId ;
      private string[] H005U3_A190EstadoTicketUsuarioNombre ;
      private short[] H005U3_A189EstadoTicketUsuarioId ;
      private string[] H005U3_A199TicketTecnicoResponsableNombre ;
      private short[] H005U3_A198TicketTecnicoResponsableId ;
      private DateTime[] H005U3_A90UsuarioFecha ;
      private string[] H005U3_A88UsuarioDepartamento ;
      private string[] H005U3_A91UsuarioGerencia ;
      private string[] H005U3_A94UsuarioRequerimiento ;
      private string[] H005U3_A93UsuarioNombre ;
      private long[] H005U3_A15UsuarioId ;
      private DateTime[] H005U3_A48TicketHora ;
      private DateTime[] H005U3_A46TicketFecha ;
      private long[] H005U3_A16TicketResponsableId ;
      private long[] H005U3_A14TicketId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV55ClassCollection_Grid ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV15K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV62FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item2 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV71GridOrders_Grid ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV17GridConfiguration ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV16K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV72GridOrder_Grid ;
   }

   public class wpsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005U2( IGxContext context ,
                                             short A290EtapaDesarrolloId ,
                                             string AV66Variable_FilterUsuario ,
                                             string AV67Variable_FilterEstado ,
                                             string AV68Variable_FilterResponsable ,
                                             string AV64GenericFilter_Grid ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A190EstadoTicketUsuarioNombre ,
                                             short AV69OrderedBy_Grid ,
                                             string A191UsuarioSistema ,
                                             short A187EstadoTicketTicketId ,
                                             short A17EstadoTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T1.[EstadoTicketTecnicoId], T3.[EstadoTicketTicketId] AS EstadoTicketTicketId, T5.[UsuarioSistema], T1.[EtapaDesarrolloId], T6.[EstadoTicketNombre] AS EstadoTicketUsuarioNombre, T5.[EstadoTicketUsuarioId] AS EstadoTicketUsuarioId, T2.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T5.[UsuarioFecha], T5.[UsuarioDepartamento], T5.[UsuarioGerencia], T5.[UsuarioRequerimiento], T5.[UsuarioNombre], T3.[UsuarioId], T3.[TicketHora], T3.[TicketFecha], T1.[TicketResponsableId], T1.[TicketId] FROM ((((([TicketResponsable] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[TicketTecnicoResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [EstadoTicket] T4 ON T4.[EstadoTicketId] = T3.[EstadoTicketTicketId]) INNER JOIN [Usuario] T5 ON T5.[UsuarioId] = T3.[UsuarioId]) INNER JOIN [EstadoTicket] T6 ON T6.[EstadoTicketId] = T5.[EstadoTicketUsuarioId])";
         AddWhere(sWhereString, "(T1.[EstadoTicketTecnicoId] = 5)");
         AddWhere(sWhereString, "(T1.[EtapaDesarrolloId] IN (7,8))");
         AddWhere(sWhereString, "(T3.[EstadoTicketTicketId] = 5)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Variable_FilterUsuario)) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioNombre] like @lV66Variable_FilterUsuario)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Variable_FilterEstado)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoTicketNombre] like @lV67Variable_FilterEstado)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Variable_FilterResponsable)) )
         {
            AddWhere(sWhereString, "(T2.[ResponsableNombre] like @lV68Variable_FilterResponsable)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64GenericFilter_Grid)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioNombre] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioRequerimiento] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioGerencia] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioDepartamento] like '%' + @lV64GenericFilter_Grid + '%' or T2.[ResponsableNombre] like '%' + @lV64GenericFilter_Grid + '%' or T6.[EstadoTicketNombre] like '%' + @lV64GenericFilter_Grid + '%')");
         }
         else
         {
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV69OrderedBy_Grid == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV69OrderedBy_Grid == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV69OrderedBy_Grid == 2 )
         {
            scmdbuf += " ORDER BY T3.[TicketFecha]";
         }
         else if ( AV69OrderedBy_Grid == 3 )
         {
            scmdbuf += " ORDER BY T3.[TicketFecha] DESC";
         }
         scmdbuf += " OPTION (FAST 21)";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H005U3( IGxContext context ,
                                             short A290EtapaDesarrolloId ,
                                             string AV66Variable_FilterUsuario ,
                                             string AV67Variable_FilterEstado ,
                                             string AV68Variable_FilterResponsable ,
                                             string AV64GenericFilter_Grid ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A190EstadoTicketUsuarioNombre ,
                                             short AV69OrderedBy_Grid ,
                                             string A191UsuarioSistema ,
                                             short A187EstadoTicketTicketId ,
                                             short A17EstadoTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T4.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T1.[EstadoTicketTecnicoId], T3.[EstadoTicketTicketId] AS EstadoTicketTicketId, T5.[UsuarioSistema], T1.[EtapaDesarrolloId], T6.[EstadoTicketNombre] AS EstadoTicketUsuarioNombre, T5.[EstadoTicketUsuarioId] AS EstadoTicketUsuarioId, T2.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T5.[UsuarioFecha], T5.[UsuarioDepartamento], T5.[UsuarioGerencia], T5.[UsuarioRequerimiento], T5.[UsuarioNombre], T3.[UsuarioId], T3.[TicketHora], T3.[TicketFecha], T1.[TicketResponsableId], T1.[TicketId] FROM ((((([TicketResponsable] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[TicketTecnicoResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [EstadoTicket] T4 ON T4.[EstadoTicketId] = T3.[EstadoTicketTicketId]) INNER JOIN [Usuario] T5 ON T5.[UsuarioId] = T3.[UsuarioId]) INNER JOIN [EstadoTicket] T6 ON T6.[EstadoTicketId] = T5.[EstadoTicketUsuarioId])";
         AddWhere(sWhereString, "(T1.[EstadoTicketTecnicoId] = 5)");
         AddWhere(sWhereString, "(T1.[EtapaDesarrolloId] IN (7,8))");
         AddWhere(sWhereString, "(T3.[EstadoTicketTicketId] = 5)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Variable_FilterUsuario)) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioNombre] like @lV66Variable_FilterUsuario)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Variable_FilterEstado)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoTicketNombre] like @lV67Variable_FilterEstado)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Variable_FilterResponsable)) )
         {
            AddWhere(sWhereString, "(T2.[ResponsableNombre] like @lV68Variable_FilterResponsable)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64GenericFilter_Grid)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioNombre] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioRequerimiento] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioGerencia] like '%' + @lV64GenericFilter_Grid + '%' or T5.[UsuarioDepartamento] like '%' + @lV64GenericFilter_Grid + '%' or T2.[ResponsableNombre] like '%' + @lV64GenericFilter_Grid + '%' or T6.[EstadoTicketNombre] like '%' + @lV64GenericFilter_Grid + '%')");
         }
         else
         {
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV69OrderedBy_Grid == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV69OrderedBy_Grid == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV69OrderedBy_Grid == 2 )
         {
            scmdbuf += " ORDER BY T3.[TicketFecha]";
         }
         else if ( AV69OrderedBy_Grid == 3 )
         {
            scmdbuf += " ORDER BY T3.[TicketFecha] DESC";
         }
         scmdbuf += " OPTION (FAST 21)";
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
                     return conditional_H005U2(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 1 :
                     return conditional_H005U3(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmH005U2;
          prmH005U2 = new Object[] {
          new ParDef("@lV66Variable_FilterUsuario",GXType.NVarChar,60,0) ,
          new ParDef("@lV67Variable_FilterEstado",GXType.NVarChar,30,0) ,
          new ParDef("@lV68Variable_FilterResponsable",GXType.NVarChar,60,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.Char,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0)
          };
          Object[] prmH005U3;
          prmH005U3 = new Object[] {
          new ParDef("@lV66Variable_FilterUsuario",GXType.NVarChar,60,0) ,
          new ParDef("@lV67Variable_FilterEstado",GXType.NVarChar,30,0) ,
          new ParDef("@lV68Variable_FilterResponsable",GXType.NVarChar,60,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.Char,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0) ,
          new ParDef("@lV64GenericFilter_Grid",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005U2,21, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005U3,21, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(17);
                ((long[]) buf[18])[0] = rslt.getLong(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(17);
                ((long[]) buf[18])[0] = rslt.getLong(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                return;
       }
    }

 }

}
