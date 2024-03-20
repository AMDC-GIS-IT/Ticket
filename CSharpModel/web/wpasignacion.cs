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
   public class wpasignacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpasignacion( )
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

      public wpasignacion( IGxContext context )
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
         chkTicketResponsablePasaTaller = new GXCheckbox();
         chkTicketLaptop = new GXCheckbox();
         chkTicketDesktop = new GXCheckbox();
         chkTicketMonitor = new GXCheckbox();
         chkTicketImpresora = new GXCheckbox();
         chkTicketEscaner = new GXCheckbox();
         chkTicketRouter = new GXCheckbox();
         chkTicketSistemaOperativo = new GXCheckbox();
         chkTicketOffice = new GXCheckbox();
         chkTicketAntivirus = new GXCheckbox();
         chkTicketDiscoDuroExterno = new GXCheckbox();
         chkTicketPerifericos = new GXCheckbox();
         chkTicketUps = new GXCheckbox();
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
               nRC_GXsfl_68 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_68"), "."));
               nGXsfl_68_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_68_idx"), "."));
               sGXsfl_68_idx = GetPar( "sGXsfl_68_idx");
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
               ajax_req_read_hidden_sdt(GetNextPar( ), AV17ClassCollection_Grid);
               AV32Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV15GridConfiguration);
               AV16CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
               AV23FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
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
            return "wpasignacion_Execute" ;
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
         PA4X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188203083", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpasignacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_68", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_68), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV17ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV17ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV15GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV15GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
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
            WE4X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4X2( ) ;
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
         return formatLink("wpasignacion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPAsignacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Solución Ticket " ;
      }

      protected void WB4X0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Solicitud Soporte Técnico", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
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
            wb_table1_24_4X2( true) ;
         }
         else
         {
            wb_table1_24_4X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_4X2e( bool wbgen )
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
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"68\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Requerimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Departamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Email") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
               context.SendWebValue( "Id Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Técnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Pasa Taller") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
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
               context.SendWebValue( "Sistema Operativo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Office") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Antivirus") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Disco Duro ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Periféricos") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "UPS") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Instalar Data Show") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Otros") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Teléfono") ;
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
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombre_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioRequerimiento_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioDepartamento_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A89UsuarioEmail);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFecha_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
               GridColumn.AddObjectProperty("Forecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Forecolor), 9, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A167TicketResponsablePasaTaller));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV25ActionRegistrar_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActionregistrar_action_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV26ActionReasignar_Action));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActionreasignar_action_Tooltiptext));
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
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A58TicketPerifericos));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A87TicketUps));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A52TicketInstalarDataShow));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A57TicketOtros));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")));
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
         if ( wbEnd == 68 )
         {
            wbEnd = 0;
            nRC_GXsfl_68 = (int)(nGXsfl_68_idx-1);
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
            wb_table2_101_4X2( true) ;
         }
         else
         {
            wb_table2_101_4X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_101_4X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 5, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgrid_Internalname, lblPaginationbar_lastpagetextblockgrid_Caption, "", "", lblPaginationbar_lastpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRID)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgrid_Visible, 1, 0, 0, "HLP_WPAsignacion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRID)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 5, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
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
         if ( wbEnd == 68 )
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

      protected void START4X2( )
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
            Form.Meta.addItem("description", "Solución Ticket ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4X0( ) ;
      }

      protected void WS4X2( )
      {
         START4X2( ) ;
         EVT4X2( ) ;
      }

      protected void EVT4X2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(Grid)' */
                              E114X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(Grid)' */
                              E124X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(Grid)' */
                              E134X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(Grid)' */
                              E144X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E154X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ACTIONREGISTRAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ACTIONREASIGNAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ACTIONREGISTRAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "'E_ACTIONREASIGNAR'") == 0 ) )
                           {
                              nGXsfl_68_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
                              SubsflControlProps_682( ) ;
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A89UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                              A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFecha_Internalname), 0));
                              A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname), 0));
                              A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ".", ","));
                              A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
                              A167TicketResponsablePasaTaller = StringUtil.StrToBool( cgiGet( chkTicketResponsablePasaTaller_Internalname));
                              n167TicketResponsablePasaTaller = false;
                              AV25ActionRegistrar_Action = cgiGet( edtavActionregistrar_action_Internalname);
                              AssignProp("", false, edtavActionregistrar_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25ActionRegistrar_Action)) ? AV33Actionregistrar_action_GXI : context.convertURL( context.PathToRelativeUrl( AV25ActionRegistrar_Action))), !bGXsfl_68_Refreshing);
                              AssignProp("", false, edtavActionregistrar_action_Internalname, "SrcSet", context.GetImageSrcSet( AV25ActionRegistrar_Action), true);
                              AV26ActionReasignar_Action = cgiGet( edtavActionreasignar_action_Internalname);
                              AssignProp("", false, edtavActionreasignar_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26ActionReasignar_Action)) ? AV34Actionreasignar_action_GXI : context.convertURL( context.PathToRelativeUrl( AV26ActionReasignar_Action))), !bGXsfl_68_Refreshing);
                              AssignProp("", false, edtavActionreasignar_action_Internalname, "SrcSet", context.GetImageSrcSet( AV26ActionReasignar_Action), true);
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
                              A43TicketDiscoDuroExterno = StringUtil.StrToBool( cgiGet( chkTicketDiscoDuroExterno_Internalname));
                              n43TicketDiscoDuroExterno = false;
                              A58TicketPerifericos = StringUtil.StrToBool( cgiGet( chkTicketPerifericos_Internalname));
                              n58TicketPerifericos = false;
                              A87TicketUps = StringUtil.StrToBool( cgiGet( chkTicketUps_Internalname));
                              n87TicketUps = false;
                              A52TicketInstalarDataShow = StringUtil.StrToBool( cgiGet( chkTicketInstalarDataShow_Internalname));
                              n52TicketInstalarDataShow = false;
                              A57TicketOtros = StringUtil.StrToBool( cgiGet( chkTicketOtros_Internalname));
                              n57TicketOtros = false;
                              A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E164X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E174X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E184X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ACTIONREGISTRAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ActionRegistrar' */
                                    E204X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_ACTIONREASIGNAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ActionReasignar' */
                                    E214X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE4X2( )
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

      protected void PA4X2( )
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
               GX_FocusControl = cmbavGridsettingsrowsperpage_grid_Internalname;
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
         SubsflControlProps_682( ) ;
         while ( nGXsfl_68_idx <= nRC_GXsfl_68 )
         {
            sendrow_682( ) ;
            nGXsfl_68_idx = ((subGrid_Islastpage==1)&&(nGXsfl_68_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       GxSimpleCollection<string> AV17ClassCollection_Grid ,
                                       string AV32Pgmname ,
                                       SdtK2BGridConfiguration AV15GridConfiguration ,
                                       short AV16CurrentPage_Grid ,
                                       bool AV23FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E164X2 ();
         GRID_nCurrentRecord = 0;
         RF4X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
            AV21GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV23FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV23FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV23FreezeColumnTitles_Grid", AV23FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E164X2 ();
         RF4X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV32Pgmname = "WPAsignacion";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         /* Using cursor H004X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A290EtapaDesarrolloId = H004X2_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = H004X2_n290EtapaDesarrolloId[0];
            A17EstadoTicketTecnicoId = H004X2_A17EstadoTicketTecnicoId[0];
            A95UsuarioTelefono = H004X2_A95UsuarioTelefono[0];
            A57TicketOtros = H004X2_A57TicketOtros[0];
            n57TicketOtros = H004X2_n57TicketOtros[0];
            A52TicketInstalarDataShow = H004X2_A52TicketInstalarDataShow[0];
            n52TicketInstalarDataShow = H004X2_n52TicketInstalarDataShow[0];
            A87TicketUps = H004X2_A87TicketUps[0];
            n87TicketUps = H004X2_n87TicketUps[0];
            A58TicketPerifericos = H004X2_A58TicketPerifericos[0];
            n58TicketPerifericos = H004X2_n58TicketPerifericos[0];
            A43TicketDiscoDuroExterno = H004X2_A43TicketDiscoDuroExterno[0];
            n43TicketDiscoDuroExterno = H004X2_n43TicketDiscoDuroExterno[0];
            A39TicketAntivirus = H004X2_A39TicketAntivirus[0];
            n39TicketAntivirus = H004X2_n39TicketAntivirus[0];
            A56TicketOffice = H004X2_A56TicketOffice[0];
            n56TicketOffice = H004X2_n56TicketOffice[0];
            A60TicketSistemaOperativo = H004X2_A60TicketSistemaOperativo[0];
            n60TicketSistemaOperativo = H004X2_n60TicketSistemaOperativo[0];
            A59TicketRouter = H004X2_A59TicketRouter[0];
            n59TicketRouter = H004X2_n59TicketRouter[0];
            A45TicketEscaner = H004X2_A45TicketEscaner[0];
            n45TicketEscaner = H004X2_n45TicketEscaner[0];
            A50TicketImpresora = H004X2_A50TicketImpresora[0];
            n50TicketImpresora = H004X2_n50TicketImpresora[0];
            A55TicketMonitor = H004X2_A55TicketMonitor[0];
            n55TicketMonitor = H004X2_n55TicketMonitor[0];
            A42TicketDesktop = H004X2_A42TicketDesktop[0];
            n42TicketDesktop = H004X2_n42TicketDesktop[0];
            A53TicketLaptop = H004X2_A53TicketLaptop[0];
            n53TicketLaptop = H004X2_n53TicketLaptop[0];
            A167TicketResponsablePasaTaller = H004X2_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = H004X2_n167TicketResponsablePasaTaller[0];
            A199TicketTecnicoResponsableNombre = H004X2_A199TicketTecnicoResponsableNombre[0];
            A198TicketTecnicoResponsableId = H004X2_A198TicketTecnicoResponsableId[0];
            A48TicketHora = H004X2_A48TicketHora[0];
            A46TicketFecha = H004X2_A46TicketFecha[0];
            A16TicketResponsableId = H004X2_A16TicketResponsableId[0];
            A14TicketId = H004X2_A14TicketId[0];
            A90UsuarioFecha = H004X2_A90UsuarioFecha[0];
            A89UsuarioEmail = H004X2_A89UsuarioEmail[0];
            A88UsuarioDepartamento = H004X2_A88UsuarioDepartamento[0];
            A94UsuarioRequerimiento = H004X2_A94UsuarioRequerimiento[0];
            A15UsuarioId = H004X2_A15UsuarioId[0];
            A93UsuarioNombre = H004X2_A93UsuarioNombre[0];
            A199TicketTecnicoResponsableNombre = H004X2_A199TicketTecnicoResponsableNombre[0];
            A57TicketOtros = H004X2_A57TicketOtros[0];
            n57TicketOtros = H004X2_n57TicketOtros[0];
            A52TicketInstalarDataShow = H004X2_A52TicketInstalarDataShow[0];
            n52TicketInstalarDataShow = H004X2_n52TicketInstalarDataShow[0];
            A87TicketUps = H004X2_A87TicketUps[0];
            n87TicketUps = H004X2_n87TicketUps[0];
            A58TicketPerifericos = H004X2_A58TicketPerifericos[0];
            n58TicketPerifericos = H004X2_n58TicketPerifericos[0];
            A43TicketDiscoDuroExterno = H004X2_A43TicketDiscoDuroExterno[0];
            n43TicketDiscoDuroExterno = H004X2_n43TicketDiscoDuroExterno[0];
            A39TicketAntivirus = H004X2_A39TicketAntivirus[0];
            n39TicketAntivirus = H004X2_n39TicketAntivirus[0];
            A56TicketOffice = H004X2_A56TicketOffice[0];
            n56TicketOffice = H004X2_n56TicketOffice[0];
            A60TicketSistemaOperativo = H004X2_A60TicketSistemaOperativo[0];
            n60TicketSistemaOperativo = H004X2_n60TicketSistemaOperativo[0];
            A59TicketRouter = H004X2_A59TicketRouter[0];
            n59TicketRouter = H004X2_n59TicketRouter[0];
            A45TicketEscaner = H004X2_A45TicketEscaner[0];
            n45TicketEscaner = H004X2_n45TicketEscaner[0];
            A50TicketImpresora = H004X2_A50TicketImpresora[0];
            n50TicketImpresora = H004X2_n50TicketImpresora[0];
            A55TicketMonitor = H004X2_A55TicketMonitor[0];
            n55TicketMonitor = H004X2_n55TicketMonitor[0];
            A42TicketDesktop = H004X2_A42TicketDesktop[0];
            n42TicketDesktop = H004X2_n42TicketDesktop[0];
            A53TicketLaptop = H004X2_A53TicketLaptop[0];
            n53TicketLaptop = H004X2_n53TicketLaptop[0];
            A48TicketHora = H004X2_A48TicketHora[0];
            A46TicketFecha = H004X2_A46TicketFecha[0];
            A15UsuarioId = H004X2_A15UsuarioId[0];
            A95UsuarioTelefono = H004X2_A95UsuarioTelefono[0];
            A90UsuarioFecha = H004X2_A90UsuarioFecha[0];
            A89UsuarioEmail = H004X2_A89UsuarioEmail[0];
            A88UsuarioDepartamento = H004X2_A88UsuarioDepartamento[0];
            A94UsuarioRequerimiento = H004X2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = H004X2_A93UsuarioNombre[0];
            if ( (Convert.ToDecimal( A198TicketTecnicoResponsableId ) == NumberUtil.Val( AV29WebSession.Get("IdResponsable"), ".") ) )
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

      protected void RF4X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 68;
         E194X2 ();
         nGXsfl_68_idx = 1;
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_682( ) ;
         bGXsfl_68_Refreshing = true;
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
            SubsflControlProps_682( ) ;
            /* Using cursor H004X3 */
            pr_default.execute(1);
            nGXsfl_68_idx = 1;
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A290EtapaDesarrolloId = H004X3_A290EtapaDesarrolloId[0];
               n290EtapaDesarrolloId = H004X3_n290EtapaDesarrolloId[0];
               A17EstadoTicketTecnicoId = H004X3_A17EstadoTicketTecnicoId[0];
               A95UsuarioTelefono = H004X3_A95UsuarioTelefono[0];
               A57TicketOtros = H004X3_A57TicketOtros[0];
               n57TicketOtros = H004X3_n57TicketOtros[0];
               A52TicketInstalarDataShow = H004X3_A52TicketInstalarDataShow[0];
               n52TicketInstalarDataShow = H004X3_n52TicketInstalarDataShow[0];
               A87TicketUps = H004X3_A87TicketUps[0];
               n87TicketUps = H004X3_n87TicketUps[0];
               A58TicketPerifericos = H004X3_A58TicketPerifericos[0];
               n58TicketPerifericos = H004X3_n58TicketPerifericos[0];
               A43TicketDiscoDuroExterno = H004X3_A43TicketDiscoDuroExterno[0];
               n43TicketDiscoDuroExterno = H004X3_n43TicketDiscoDuroExterno[0];
               A39TicketAntivirus = H004X3_A39TicketAntivirus[0];
               n39TicketAntivirus = H004X3_n39TicketAntivirus[0];
               A56TicketOffice = H004X3_A56TicketOffice[0];
               n56TicketOffice = H004X3_n56TicketOffice[0];
               A60TicketSistemaOperativo = H004X3_A60TicketSistemaOperativo[0];
               n60TicketSistemaOperativo = H004X3_n60TicketSistemaOperativo[0];
               A59TicketRouter = H004X3_A59TicketRouter[0];
               n59TicketRouter = H004X3_n59TicketRouter[0];
               A45TicketEscaner = H004X3_A45TicketEscaner[0];
               n45TicketEscaner = H004X3_n45TicketEscaner[0];
               A50TicketImpresora = H004X3_A50TicketImpresora[0];
               n50TicketImpresora = H004X3_n50TicketImpresora[0];
               A55TicketMonitor = H004X3_A55TicketMonitor[0];
               n55TicketMonitor = H004X3_n55TicketMonitor[0];
               A42TicketDesktop = H004X3_A42TicketDesktop[0];
               n42TicketDesktop = H004X3_n42TicketDesktop[0];
               A53TicketLaptop = H004X3_A53TicketLaptop[0];
               n53TicketLaptop = H004X3_n53TicketLaptop[0];
               A167TicketResponsablePasaTaller = H004X3_A167TicketResponsablePasaTaller[0];
               n167TicketResponsablePasaTaller = H004X3_n167TicketResponsablePasaTaller[0];
               A199TicketTecnicoResponsableNombre = H004X3_A199TicketTecnicoResponsableNombre[0];
               A198TicketTecnicoResponsableId = H004X3_A198TicketTecnicoResponsableId[0];
               A48TicketHora = H004X3_A48TicketHora[0];
               A46TicketFecha = H004X3_A46TicketFecha[0];
               A16TicketResponsableId = H004X3_A16TicketResponsableId[0];
               A14TicketId = H004X3_A14TicketId[0];
               A90UsuarioFecha = H004X3_A90UsuarioFecha[0];
               A89UsuarioEmail = H004X3_A89UsuarioEmail[0];
               A88UsuarioDepartamento = H004X3_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H004X3_A94UsuarioRequerimiento[0];
               A15UsuarioId = H004X3_A15UsuarioId[0];
               A93UsuarioNombre = H004X3_A93UsuarioNombre[0];
               A199TicketTecnicoResponsableNombre = H004X3_A199TicketTecnicoResponsableNombre[0];
               A57TicketOtros = H004X3_A57TicketOtros[0];
               n57TicketOtros = H004X3_n57TicketOtros[0];
               A52TicketInstalarDataShow = H004X3_A52TicketInstalarDataShow[0];
               n52TicketInstalarDataShow = H004X3_n52TicketInstalarDataShow[0];
               A87TicketUps = H004X3_A87TicketUps[0];
               n87TicketUps = H004X3_n87TicketUps[0];
               A58TicketPerifericos = H004X3_A58TicketPerifericos[0];
               n58TicketPerifericos = H004X3_n58TicketPerifericos[0];
               A43TicketDiscoDuroExterno = H004X3_A43TicketDiscoDuroExterno[0];
               n43TicketDiscoDuroExterno = H004X3_n43TicketDiscoDuroExterno[0];
               A39TicketAntivirus = H004X3_A39TicketAntivirus[0];
               n39TicketAntivirus = H004X3_n39TicketAntivirus[0];
               A56TicketOffice = H004X3_A56TicketOffice[0];
               n56TicketOffice = H004X3_n56TicketOffice[0];
               A60TicketSistemaOperativo = H004X3_A60TicketSistemaOperativo[0];
               n60TicketSistemaOperativo = H004X3_n60TicketSistemaOperativo[0];
               A59TicketRouter = H004X3_A59TicketRouter[0];
               n59TicketRouter = H004X3_n59TicketRouter[0];
               A45TicketEscaner = H004X3_A45TicketEscaner[0];
               n45TicketEscaner = H004X3_n45TicketEscaner[0];
               A50TicketImpresora = H004X3_A50TicketImpresora[0];
               n50TicketImpresora = H004X3_n50TicketImpresora[0];
               A55TicketMonitor = H004X3_A55TicketMonitor[0];
               n55TicketMonitor = H004X3_n55TicketMonitor[0];
               A42TicketDesktop = H004X3_A42TicketDesktop[0];
               n42TicketDesktop = H004X3_n42TicketDesktop[0];
               A53TicketLaptop = H004X3_A53TicketLaptop[0];
               n53TicketLaptop = H004X3_n53TicketLaptop[0];
               A48TicketHora = H004X3_A48TicketHora[0];
               A46TicketFecha = H004X3_A46TicketFecha[0];
               A15UsuarioId = H004X3_A15UsuarioId[0];
               A95UsuarioTelefono = H004X3_A95UsuarioTelefono[0];
               A90UsuarioFecha = H004X3_A90UsuarioFecha[0];
               A89UsuarioEmail = H004X3_A89UsuarioEmail[0];
               A88UsuarioDepartamento = H004X3_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H004X3_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H004X3_A93UsuarioNombre[0];
               if ( (Convert.ToDecimal( A198TicketTecnicoResponsableId ) == NumberUtil.Val( AV29WebSession.Get("IdResponsable"), ".") ) )
               {
                  E184X2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 68;
            WB4X0( ) ;
         }
         bGXsfl_68_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID"+"_"+sGXsfl_68_idx, GetSecureSignedToken( sGXsfl_68_idx, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETRESPONSABLEID"+"_"+sGXsfl_68_idx, GetSecureSignedToken( sGXsfl_68_idx, context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICORESPONSABLEID"+"_"+sGXsfl_68_idx, GetSecureSignedToken( sGXsfl_68_idx, context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV32Pgmname = "WPAsignacion";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E174X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_68 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV21GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
            AV23FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV23FreezeColumnTitles_Grid", AV23FreezeColumnTitles_Grid);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E164X2( )
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
         if ( (0==AV16CurrentPage_Grid) )
         {
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV17ClassCollection_Grid,  " ", out  GXt_char1) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ClassCollection_Grid", AV17ClassCollection_Grid);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E174X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E174X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bloadrowsperpage(context ).execute(  AV32Pgmname,  "Grid", out  AV19RowsPerPage_Grid, out  AV20RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV19RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19RowsPerPage_Grid), 4, 0));
         if ( ! AV20RowsPerPageLoaded_Grid )
         {
            AV19RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV19RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19RowsPerPage_Grid), 4, 0));
         }
         AV21GridSettingsRowsPerPage_Grid = AV19RowsPerPage_Grid;
         AssignAttri("", false, "AV21GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
         subGrid_Rows = AV19RowsPerPage_Grid;
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
         AV23FreezeColumnTitles_Grid = AV15GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV23FreezeColumnTitles_Grid", AV23FreezeColumnTitles_Grid);
         if ( AV23FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV17ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV17ClassCollection_Grid) ;
         }
      }

      protected void S122( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV32Pgmname,  "Grid", ref  AV15GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E184X2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            AV25ActionRegistrar_Action = context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( ));
            AssignAttri("", false, edtavActionregistrar_action_Internalname, AV25ActionRegistrar_Action);
            AV33Actionregistrar_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )));
            edtavActionregistrar_action_Tooltiptext = "Action Registrar";
            AV26ActionReasignar_Action = context.GetImagePath( "49aab9cd-117e-44e0-a44a-469a4c44e38d", "", context.GetTheme( ));
            AssignAttri("", false, edtavActionreasignar_action_Internalname, AV26ActionReasignar_Action);
            AV34Actionreasignar_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "49aab9cd-117e-44e0-a44a-469a4c44e38d", "", context.GetTheme( )));
            edtavActionreasignar_action_Tooltiptext = "Action Reasignar";
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 68;
            }
            sendrow_682( ) ;
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
         if ( isFullAjaxMode( ) && ! bGXsfl_68_Refreshing )
         {
            context.DoAjaxLoad(68, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E194X2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV17ClassCollection_Grid) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV17ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ClassCollection_Grid", AV17ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridConfiguration", AV15GridConfiguration);
      }

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         edtUsuarioNombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioNombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtUsuarioRequerimiento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtUsuarioDepartamento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioDepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtUsuarioFecha_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtUsuarioFecha_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtTicketFecha_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketFecha_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtTicketHora_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketHora_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketHora_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
         edtTicketTecnicoResponsableNombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtTicketTecnicoResponsableNombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Forecolor), 9, 0), !bGXsfl_68_Refreshing);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV32Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV11GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV32Pgmname,  AV10GridStateKey,  AV11GridState) ;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV32Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV22PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( ( AV11GridState.gxTpr_Currentpage > 0 ) && ( AV11GridState.gxTpr_Currentpage <= AV22PageCount_Grid ) )
         {
            AV16CurrentPage_Grid = AV11GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
            subgrid_gotopage( AV16CurrentPage_Grid) ;
         }
      }

      protected void E114X2( )
      {
         /* 'PagingFirst(Grid)' Routine */
         returnInSub = false;
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E124X2( )
      {
         /* 'PagingPrevious(Grid)' Routine */
         returnInSub = false;
         subgrid_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         AV22PageCount_Grid = (short)(subGrid_fnc_Pagecount( ));
         if ( AV16CurrentPage_Grid > AV22PageCount_Grid )
         {
            AV16CurrentPage_Grid = AV22PageCount_Grid;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
            subgrid_lastpage( ) ;
         }
         if ( AV22PageCount_Grid == 0 )
         {
            AV16CurrentPage_Grid = 0;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         else
         {
            AV16CurrentPage_Grid = (short)(subGrid_fnc_Currentpage( ));
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_lastpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV22PageCount_Grid), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgrid_Internalname, "Caption", lblPaginationbar_lastpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV16CurrentPage_Grid) || ( AV16CurrentPage_Grid <= 1 ) )
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
            if ( AV16CurrentPage_Grid == 2 )
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
               if ( AV16CurrentPage_Grid == 3 )
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
         if ( AV16CurrentPage_Grid == AV22PageCount_Grid )
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
            if ( AV16CurrentPage_Grid == AV22PageCount_Grid - 1 )
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
               if ( AV16CurrentPage_Grid == AV22PageCount_Grid - 2 )
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
         if ( ( AV16CurrentPage_Grid <= 1 ) && ( AV22PageCount_Grid <= 1 ) )
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

      protected void E134X2( )
      {
         /* 'PagingNext(Grid)' Routine */
         returnInSub = false;
         subgrid_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E144X2( )
      {
         /* 'PagingLast(Grid)' Routine */
         returnInSub = false;
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E154X2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV32Pgmname,  "Grid", ref  AV15GridConfiguration) ;
         AV15GridConfiguration.gxTpr_Freezecolumntitles = AV23FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV32Pgmname,  "Grid",  AV15GridConfiguration,  true) ;
         subGrid_Rows = AV21GridSettingsRowsPerPage_Grid;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         if ( AV19RowsPerPage_Grid != AV21GridSettingsRowsPerPage_Grid )
         {
            AV19RowsPerPage_Grid = AV21GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV19RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV19RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV32Pgmname,  "Grid",  AV19RowsPerPage_Grid) ;
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17ClassCollection_Grid, AV32Pgmname, AV15GridConfiguration, AV16CurrentPage_Grid, AV23FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ClassCollection_Grid", AV17ClassCollection_Grid);
      }

      protected void E204X2( )
      {
         /* 'E_ActionRegistrar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ACTIONREGISTRAR' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ClassCollection_Grid", AV17ClassCollection_Grid);
      }

      protected void S202( )
      {
         /* 'U_ACTIONREGISTRAR' Routine */
         returnInSub = false;
         context.PopUp(formatLink("wpsoportetecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(A16TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(A198TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(A89UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(A90UsuarioFecha)),UrlEncode(StringUtil.RTrim(A93UsuarioNombre)),UrlEncode(StringUtil.RTrim(A88UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(A94UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(A167TicketResponsablePasaTaller))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2"}) , new Object[] {"A167TicketResponsablePasaTaller"});
         context.DoAjaxRefresh();
      }

      protected void E214X2( )
      {
         /* 'E_ActionReasignar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ACTIONREASIGNAR' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ClassCollection_Grid", AV17ClassCollection_Grid);
      }

      protected void S212( )
      {
         /* 'U_ACTIONREASIGNAR' Routine */
         returnInSub = false;
         context.PopUp(formatLink("wpreasignarsoportetecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(A16TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(A198TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(A89UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(A90UsuarioFecha)),UrlEncode(StringUtil.RTrim(A93UsuarioNombre)),UrlEncode(StringUtil.RTrim(A88UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(A94UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(A167TicketResponsablePasaTaller))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2"}) , new Object[] {"A167TicketResponsablePasaTaller"});
         context.DoAjaxRefresh();
      }

      protected void wb_table2_101_4X2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_101_4X2e( true) ;
         }
         else
         {
            wb_table2_101_4X2e( false) ;
         }
      }

      protected void wb_table1_24_4X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e224x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAsignacion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WPAsignacion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_68_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 1, "HLP_WPAsignacion.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_68_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV23FreezeColumnTitles_Grid), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "Aplicar", bttGridsettings_savegrid_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAsignacion.htm");
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
            wb_table1_24_4X2e( true) ;
         }
         else
         {
            wb_table1_24_4X2e( false) ;
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
         PA4X2( ) ;
         WS4X2( ) ;
         WE4X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188203349", true, true);
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
            context.AddJavascriptSource("wpasignacion.js", "?2024188203349", false, true);
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_682( )
      {
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_68_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_68_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_68_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_68_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_68_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_68_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_68_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_68_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_68_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_68_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_68_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_68_idx;
         chkTicketResponsablePasaTaller_Internalname = "TICKETRESPONSABLEPASATALLER_"+sGXsfl_68_idx;
         edtavActionregistrar_action_Internalname = "vACTIONREGISTRAR_ACTION_"+sGXsfl_68_idx;
         edtavActionreasignar_action_Internalname = "vACTIONREASIGNAR_ACTION_"+sGXsfl_68_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_68_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_68_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_68_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_68_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_68_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_68_idx;
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO_"+sGXsfl_68_idx;
         chkTicketOffice_Internalname = "TICKETOFFICE_"+sGXsfl_68_idx;
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS_"+sGXsfl_68_idx;
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO_"+sGXsfl_68_idx;
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS_"+sGXsfl_68_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_68_idx;
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW_"+sGXsfl_68_idx;
         chkTicketOtros_Internalname = "TICKETOTROS_"+sGXsfl_68_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_68_idx;
      }

      protected void SubsflControlProps_fel_682( )
      {
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_68_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_68_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_68_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_68_fel_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_68_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_68_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_68_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_68_fel_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_68_fel_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_68_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_68_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_68_fel_idx;
         chkTicketResponsablePasaTaller_Internalname = "TICKETRESPONSABLEPASATALLER_"+sGXsfl_68_fel_idx;
         edtavActionregistrar_action_Internalname = "vACTIONREGISTRAR_ACTION_"+sGXsfl_68_fel_idx;
         edtavActionreasignar_action_Internalname = "vACTIONREASIGNAR_ACTION_"+sGXsfl_68_fel_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_68_fel_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_68_fel_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_68_fel_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_68_fel_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_68_fel_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_68_fel_idx;
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO_"+sGXsfl_68_fel_idx;
         chkTicketOffice_Internalname = "TICKETOFFICE_"+sGXsfl_68_fel_idx;
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS_"+sGXsfl_68_fel_idx;
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO_"+sGXsfl_68_fel_idx;
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS_"+sGXsfl_68_fel_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_68_fel_idx;
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW_"+sGXsfl_68_fel_idx;
         chkTicketOtros_Internalname = "TICKETOTROS_"+sGXsfl_68_fel_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_68_fel_idx;
      }

      protected void sendrow_682( )
      {
         SubsflControlProps_682( ) ;
         WB4X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_68_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_68_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_68_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioNombre_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioRequerimiento_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioDepartamento_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioEmail_Internalname,(string)A89UsuarioEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A89UsuarioEmail,(string)"",(string)"",(string)"",(string)edtUsuarioEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtUsuarioFecha_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFecha_Internalname,context.localUtil.Format(A46TicketFecha, "99/99/9999"),context.localUtil.Format( A46TicketFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketFecha_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketFecha_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHora_Internalname,context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A48TicketHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHora_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketHora_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid","color:"+context.BuildHTMLColor( edtTicketTecnicoResponsableNombre_Forecolor)+";",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETRESPONSABLEPASATALLER_" + sGXsfl_68_idx;
            chkTicketResponsablePasaTaller.Name = GXCCtl;
            chkTicketResponsablePasaTaller.WebTags = "";
            chkTicketResponsablePasaTaller.Caption = "";
            AssignProp("", false, chkTicketResponsablePasaTaller_Internalname, "TitleCaption", chkTicketResponsablePasaTaller.Caption, !bGXsfl_68_Refreshing);
            chkTicketResponsablePasaTaller.CheckedValue = "false";
            A167TicketResponsablePasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A167TicketResponsablePasaTaller));
            n167TicketResponsablePasaTaller = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketResponsablePasaTaller_Internalname,StringUtil.BoolToStr( A167TicketResponsablePasaTaller),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActionregistrar_action_Enabled!=0)&&(edtavActionregistrar_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 82,'',false,'',68)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV25ActionRegistrar_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25ActionRegistrar_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV33Actionregistrar_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25ActionRegistrar_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25ActionRegistrar_Action)) ? AV33Actionregistrar_action_GXI : context.PathToRelativeUrl( AV25ActionRegistrar_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActionregistrar_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Registrar",(string)edtavActionregistrar_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavActionregistrar_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ACTIONREGISTRAR\\'."+sGXsfl_68_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV25ActionRegistrar_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavActionreasignar_action_Enabled!=0)&&(edtavActionreasignar_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 83,'',false,'',68)\"" : " ");
            ClassString = "Image_Action";
            StyleString = "";
            AV26ActionReasignar_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV26ActionReasignar_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV34Actionreasignar_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV26ActionReasignar_Action)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26ActionReasignar_Action)) ? AV34Actionreasignar_action_GXI : context.PathToRelativeUrl( AV26ActionReasignar_Action));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActionreasignar_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Reasignar",(string)edtavActionreasignar_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavActionreasignar_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_ACTIONREASIGNAR\\'."+sGXsfl_68_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV26ActionReasignar_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETLAPTOP_" + sGXsfl_68_idx;
            chkTicketLaptop.Name = GXCCtl;
            chkTicketLaptop.WebTags = "";
            chkTicketLaptop.Caption = "";
            AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETDESKTOP_" + sGXsfl_68_idx;
            chkTicketDesktop.Name = GXCCtl;
            chkTicketDesktop.WebTags = "";
            chkTicketDesktop.Caption = "";
            AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETMONITOR_" + sGXsfl_68_idx;
            chkTicketMonitor.Name = GXCCtl;
            chkTicketMonitor.WebTags = "";
            chkTicketMonitor.Caption = "";
            AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETIMPRESORA_" + sGXsfl_68_idx;
            chkTicketImpresora.Name = GXCCtl;
            chkTicketImpresora.WebTags = "";
            chkTicketImpresora.Caption = "";
            AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETESCANER_" + sGXsfl_68_idx;
            chkTicketEscaner.Name = GXCCtl;
            chkTicketEscaner.WebTags = "";
            chkTicketEscaner.Caption = "";
            AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETROUTER_" + sGXsfl_68_idx;
            chkTicketRouter.Name = GXCCtl;
            chkTicketRouter.WebTags = "";
            chkTicketRouter.Caption = "";
            AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_68_idx;
            chkTicketSistemaOperativo.Name = GXCCtl;
            chkTicketSistemaOperativo.WebTags = "";
            chkTicketSistemaOperativo.Caption = "";
            AssignProp("", false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETOFFICE_" + sGXsfl_68_idx;
            chkTicketOffice.Name = GXCCtl;
            chkTicketOffice.WebTags = "";
            chkTicketOffice.Caption = "";
            AssignProp("", false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_68_idx;
            chkTicketAntivirus.Name = GXCCtl;
            chkTicketAntivirus.WebTags = "";
            chkTicketAntivirus.Caption = "";
            AssignProp("", false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_68_idx;
            chkTicketDiscoDuroExterno.Name = GXCCtl;
            chkTicketDiscoDuroExterno.WebTags = "";
            chkTicketDiscoDuroExterno.Caption = "";
            AssignProp("", false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_68_idx;
            chkTicketPerifericos.Name = GXCCtl;
            chkTicketPerifericos.WebTags = "";
            chkTicketPerifericos.Caption = "";
            AssignProp("", false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETUPS_" + sGXsfl_68_idx;
            chkTicketUps.Name = GXCCtl;
            chkTicketUps.WebTags = "";
            chkTicketUps.Caption = "";
            AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_68_idx;
            chkTicketInstalarDataShow.Name = GXCCtl;
            chkTicketInstalarDataShow.WebTags = "";
            chkTicketInstalarDataShow.Caption = "";
            AssignProp("", false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_68_Refreshing);
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
            GXCCtl = "TICKETOTROS_" + sGXsfl_68_idx;
            chkTicketOtros.Name = GXCCtl;
            chkTicketOtros.WebTags = "";
            chkTicketOtros.Caption = "";
            AssignProp("", false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_68_Refreshing);
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefono_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes4X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_68_idx = ((subGrid_Islastpage==1)&&(nGXsfl_68_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         /* End function sendrow_682 */
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
            AV21GridSettingsRowsPerPage_Grid = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0))), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV23FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV23FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV23FreezeColumnTitles_Grid", AV23FreezeColumnTitles_Grid);
         GXCCtl = "TICKETRESPONSABLEPASATALLER_" + sGXsfl_68_idx;
         chkTicketResponsablePasaTaller.Name = GXCCtl;
         chkTicketResponsablePasaTaller.WebTags = "";
         chkTicketResponsablePasaTaller.Caption = "";
         AssignProp("", false, chkTicketResponsablePasaTaller_Internalname, "TitleCaption", chkTicketResponsablePasaTaller.Caption, !bGXsfl_68_Refreshing);
         chkTicketResponsablePasaTaller.CheckedValue = "false";
         A167TicketResponsablePasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A167TicketResponsablePasaTaller));
         n167TicketResponsablePasaTaller = false;
         GXCCtl = "TICKETLAPTOP_" + sGXsfl_68_idx;
         chkTicketLaptop.Name = GXCCtl;
         chkTicketLaptop.WebTags = "";
         chkTicketLaptop.Caption = "";
         AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_68_Refreshing);
         chkTicketLaptop.CheckedValue = "false";
         A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
         n53TicketLaptop = false;
         GXCCtl = "TICKETDESKTOP_" + sGXsfl_68_idx;
         chkTicketDesktop.Name = GXCCtl;
         chkTicketDesktop.WebTags = "";
         chkTicketDesktop.Caption = "";
         AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_68_Refreshing);
         chkTicketDesktop.CheckedValue = "false";
         A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
         n42TicketDesktop = false;
         GXCCtl = "TICKETMONITOR_" + sGXsfl_68_idx;
         chkTicketMonitor.Name = GXCCtl;
         chkTicketMonitor.WebTags = "";
         chkTicketMonitor.Caption = "";
         AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_68_Refreshing);
         chkTicketMonitor.CheckedValue = "false";
         A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
         n55TicketMonitor = false;
         GXCCtl = "TICKETIMPRESORA_" + sGXsfl_68_idx;
         chkTicketImpresora.Name = GXCCtl;
         chkTicketImpresora.WebTags = "";
         chkTicketImpresora.Caption = "";
         AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_68_Refreshing);
         chkTicketImpresora.CheckedValue = "false";
         A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
         n50TicketImpresora = false;
         GXCCtl = "TICKETESCANER_" + sGXsfl_68_idx;
         chkTicketEscaner.Name = GXCCtl;
         chkTicketEscaner.WebTags = "";
         chkTicketEscaner.Caption = "";
         AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_68_Refreshing);
         chkTicketEscaner.CheckedValue = "false";
         A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
         n45TicketEscaner = false;
         GXCCtl = "TICKETROUTER_" + sGXsfl_68_idx;
         chkTicketRouter.Name = GXCCtl;
         chkTicketRouter.WebTags = "";
         chkTicketRouter.Caption = "";
         AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_68_Refreshing);
         chkTicketRouter.CheckedValue = "false";
         A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
         n59TicketRouter = false;
         GXCCtl = "TICKETSISTEMAOPERATIVO_" + sGXsfl_68_idx;
         chkTicketSistemaOperativo.Name = GXCCtl;
         chkTicketSistemaOperativo.WebTags = "";
         chkTicketSistemaOperativo.Caption = "";
         AssignProp("", false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, !bGXsfl_68_Refreshing);
         chkTicketSistemaOperativo.CheckedValue = "false";
         A60TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( A60TicketSistemaOperativo));
         n60TicketSistemaOperativo = false;
         GXCCtl = "TICKETOFFICE_" + sGXsfl_68_idx;
         chkTicketOffice.Name = GXCCtl;
         chkTicketOffice.WebTags = "";
         chkTicketOffice.Caption = "";
         AssignProp("", false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, !bGXsfl_68_Refreshing);
         chkTicketOffice.CheckedValue = "false";
         A56TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( A56TicketOffice));
         n56TicketOffice = false;
         GXCCtl = "TICKETANTIVIRUS_" + sGXsfl_68_idx;
         chkTicketAntivirus.Name = GXCCtl;
         chkTicketAntivirus.WebTags = "";
         chkTicketAntivirus.Caption = "";
         AssignProp("", false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, !bGXsfl_68_Refreshing);
         chkTicketAntivirus.CheckedValue = "false";
         A39TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( A39TicketAntivirus));
         n39TicketAntivirus = false;
         GXCCtl = "TICKETDISCODUROEXTERNO_" + sGXsfl_68_idx;
         chkTicketDiscoDuroExterno.Name = GXCCtl;
         chkTicketDiscoDuroExterno.WebTags = "";
         chkTicketDiscoDuroExterno.Caption = "";
         AssignProp("", false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, !bGXsfl_68_Refreshing);
         chkTicketDiscoDuroExterno.CheckedValue = "false";
         A43TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
         n43TicketDiscoDuroExterno = false;
         GXCCtl = "TICKETPERIFERICOS_" + sGXsfl_68_idx;
         chkTicketPerifericos.Name = GXCCtl;
         chkTicketPerifericos.WebTags = "";
         chkTicketPerifericos.Caption = "";
         AssignProp("", false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, !bGXsfl_68_Refreshing);
         chkTicketPerifericos.CheckedValue = "false";
         A58TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( A58TicketPerifericos));
         n58TicketPerifericos = false;
         GXCCtl = "TICKETUPS_" + sGXsfl_68_idx;
         chkTicketUps.Name = GXCCtl;
         chkTicketUps.WebTags = "";
         chkTicketUps.Caption = "";
         AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_68_Refreshing);
         chkTicketUps.CheckedValue = "false";
         A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
         n87TicketUps = false;
         GXCCtl = "TICKETINSTALARDATASHOW_" + sGXsfl_68_idx;
         chkTicketInstalarDataShow.Name = GXCCtl;
         chkTicketInstalarDataShow.WebTags = "";
         chkTicketInstalarDataShow.Caption = "";
         AssignProp("", false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, !bGXsfl_68_Refreshing);
         chkTicketInstalarDataShow.CheckedValue = "false";
         A52TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( A52TicketInstalarDataShow));
         n52TicketInstalarDataShow = false;
         GXCCtl = "TICKETOTROS_" + sGXsfl_68_idx;
         chkTicketOtros.Name = GXCCtl;
         chkTicketOtros.WebTags = "";
         chkTicketOtros.Caption = "";
         AssignProp("", false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, !bGXsfl_68_Refreshing);
         chkTicketOtros.CheckedValue = "false";
         A57TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( A57TicketOtros));
         n57TicketOtros = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
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
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtTicketId_Internalname = "TICKETID";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtTicketFecha_Internalname = "TICKETFECHA";
         edtTicketHora_Internalname = "TICKETHORA";
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE";
         chkTicketResponsablePasaTaller_Internalname = "TICKETRESPONSABLEPASATALLER";
         edtavActionregistrar_action_Internalname = "vACTIONREGISTRAR_ACTION";
         edtavActionreasignar_action_Internalname = "vACTIONREASIGNAR_ACTION";
         chkTicketLaptop_Internalname = "TICKETLAPTOP";
         chkTicketDesktop_Internalname = "TICKETDESKTOP";
         chkTicketMonitor_Internalname = "TICKETMONITOR";
         chkTicketImpresora_Internalname = "TICKETIMPRESORA";
         chkTicketEscaner_Internalname = "TICKETESCANER";
         chkTicketRouter_Internalname = "TICKETROUTER";
         chkTicketSistemaOperativo_Internalname = "TICKETSISTEMAOPERATIVO";
         chkTicketOffice_Internalname = "TICKETOFFICE";
         chkTicketAntivirus_Internalname = "TICKETANTIVIRUS";
         chkTicketDiscoDuroExterno_Internalname = "TICKETDISCODUROEXTERNO";
         chkTicketPerifericos_Internalname = "TICKETPERIFERICOS";
         chkTicketUps_Internalname = "TICKETUPS";
         chkTicketInstalarDataShow_Internalname = "TICKETINSTALARDATASHOW";
         chkTicketOtros_Internalname = "TICKETOTROS";
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO";
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
         edtUsuarioTelefono_Jsonclick = "";
         chkTicketOtros.Caption = "";
         chkTicketInstalarDataShow.Caption = "";
         chkTicketUps.Caption = "";
         chkTicketPerifericos.Caption = "";
         chkTicketDiscoDuroExterno.Caption = "";
         chkTicketAntivirus.Caption = "";
         chkTicketOffice.Caption = "";
         chkTicketSistemaOperativo.Caption = "";
         chkTicketRouter.Caption = "";
         chkTicketEscaner.Caption = "";
         chkTicketImpresora.Caption = "";
         chkTicketMonitor.Caption = "";
         chkTicketDesktop.Caption = "";
         chkTicketLaptop.Caption = "";
         edtavActionreasignar_action_Jsonclick = "";
         edtavActionreasignar_action_Visible = -1;
         edtavActionreasignar_action_Enabled = 1;
         edtavActionregistrar_action_Jsonclick = "";
         edtavActionregistrar_action_Visible = -1;
         edtavActionregistrar_action_Enabled = 1;
         chkTicketResponsablePasaTaller.Caption = "";
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketHora_Jsonclick = "";
         edtTicketFecha_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavActionreasignar_action_Tooltiptext = "";
         edtavActionregistrar_action_Tooltiptext = "";
         edtTicketTecnicoResponsableNombre_Forecolor = (int)(0x000000);
         edtTicketHora_Forecolor = (int)(0x000000);
         edtTicketFecha_Forecolor = (int)(0x000000);
         edtUsuarioFecha_Forecolor = (int)(0x000000);
         edtUsuarioDepartamento_Forecolor = (int)(0x000000);
         edtUsuarioRequerimiento_Forecolor = (int)(0x000000);
         edtUsuarioNombre_Forecolor = (int)(0x000000);
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Solución Ticket ";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E184X2',iparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV25ActionRegistrar_Action',fld:'vACTIONREGISTRAR_ACTION',pic:''},{av:'edtavActionregistrar_action_Tooltiptext',ctrl:'vACTIONREGISTRAR_ACTION',prop:'Tooltiptext'},{av:'AV26ActionReasignar_Action',fld:'vACTIONREASIGNAR_ACTION',pic:''},{av:'edtavActionreasignar_action_Tooltiptext',ctrl:'vACTIONREASIGNAR_ACTION',prop:'Tooltiptext'},{av:'edtUsuarioNombre_Forecolor',ctrl:'USUARIONOMBRE',prop:'Forecolor'},{av:'edtUsuarioRequerimiento_Forecolor',ctrl:'USUARIOREQUERIMIENTO',prop:'Forecolor'},{av:'edtUsuarioDepartamento_Forecolor',ctrl:'USUARIODEPARTAMENTO',prop:'Forecolor'},{av:'edtUsuarioFecha_Forecolor',ctrl:'USUARIOFECHA',prop:'Forecolor'},{av:'edtTicketFecha_Forecolor',ctrl:'TICKETFECHA',prop:'Forecolor'},{av:'edtTicketHora_Forecolor',ctrl:'TICKETHORA',prop:'Forecolor'},{av:'edtTicketTecnicoResponsableNombre_Forecolor',ctrl:'TICKETTECNICORESPONSABLENOMBRE',prop:'Forecolor'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E194X2',iparms:[{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E114X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E124X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E134X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGLAST(GRID)'","{handler:'E144X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGLAST(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E224X1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E154X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV21GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ACTIONREGISTRAR'","{handler:'E204X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'A89UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A90UsuarioFecha',fld:'USUARIOFECHA',pic:''},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A167TicketResponsablePasaTaller',fld:'TICKETRESPONSABLEPASATALLER',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ACTIONREGISTRAR'",",oparms:[{av:'A167TicketResponsablePasaTaller',fld:'TICKETRESPONSABLEPASATALLER',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ACTIONREASIGNAR'","{handler:'E214X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'A89UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A90UsuarioFecha',fld:'USUARIOFECHA',pic:''},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A167TicketResponsablePasaTaller',fld:'TICKETRESPONSABLEPASATALLER',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ACTIONREASIGNAR'",",oparms:[{av:'A167TicketResponsablePasaTaller',fld:'TICKETRESPONSABLEPASATALLER',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariotelefono',iparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV23FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
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
         AV17ClassCollection_Grid = new GxSimpleCollection<string>();
         AV32Pgmname = "";
         AV15GridConfiguration = new SdtK2BGridConfiguration(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A88UsuarioDepartamento = "";
         A89UsuarioEmail = "";
         A90UsuarioFecha = DateTime.MinValue;
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A199TicketTecnicoResponsableNombre = "";
         AV25ActionRegistrar_Action = "";
         AV26ActionReasignar_Action = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV33Actionregistrar_action_GXI = "";
         AV34Actionreasignar_action_GXI = "";
         scmdbuf = "";
         H004X2_A290EtapaDesarrolloId = new short[1] ;
         H004X2_n290EtapaDesarrolloId = new bool[] {false} ;
         H004X2_A17EstadoTicketTecnicoId = new short[1] ;
         H004X2_A95UsuarioTelefono = new int[1] ;
         H004X2_A57TicketOtros = new bool[] {false} ;
         H004X2_n57TicketOtros = new bool[] {false} ;
         H004X2_A52TicketInstalarDataShow = new bool[] {false} ;
         H004X2_n52TicketInstalarDataShow = new bool[] {false} ;
         H004X2_A87TicketUps = new bool[] {false} ;
         H004X2_n87TicketUps = new bool[] {false} ;
         H004X2_A58TicketPerifericos = new bool[] {false} ;
         H004X2_n58TicketPerifericos = new bool[] {false} ;
         H004X2_A43TicketDiscoDuroExterno = new bool[] {false} ;
         H004X2_n43TicketDiscoDuroExterno = new bool[] {false} ;
         H004X2_A39TicketAntivirus = new bool[] {false} ;
         H004X2_n39TicketAntivirus = new bool[] {false} ;
         H004X2_A56TicketOffice = new bool[] {false} ;
         H004X2_n56TicketOffice = new bool[] {false} ;
         H004X2_A60TicketSistemaOperativo = new bool[] {false} ;
         H004X2_n60TicketSistemaOperativo = new bool[] {false} ;
         H004X2_A59TicketRouter = new bool[] {false} ;
         H004X2_n59TicketRouter = new bool[] {false} ;
         H004X2_A45TicketEscaner = new bool[] {false} ;
         H004X2_n45TicketEscaner = new bool[] {false} ;
         H004X2_A50TicketImpresora = new bool[] {false} ;
         H004X2_n50TicketImpresora = new bool[] {false} ;
         H004X2_A55TicketMonitor = new bool[] {false} ;
         H004X2_n55TicketMonitor = new bool[] {false} ;
         H004X2_A42TicketDesktop = new bool[] {false} ;
         H004X2_n42TicketDesktop = new bool[] {false} ;
         H004X2_A53TicketLaptop = new bool[] {false} ;
         H004X2_n53TicketLaptop = new bool[] {false} ;
         H004X2_A167TicketResponsablePasaTaller = new bool[] {false} ;
         H004X2_n167TicketResponsablePasaTaller = new bool[] {false} ;
         H004X2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H004X2_A198TicketTecnicoResponsableId = new short[1] ;
         H004X2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H004X2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H004X2_A16TicketResponsableId = new long[1] ;
         H004X2_A14TicketId = new long[1] ;
         H004X2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H004X2_A89UsuarioEmail = new string[] {""} ;
         H004X2_A88UsuarioDepartamento = new string[] {""} ;
         H004X2_A94UsuarioRequerimiento = new string[] {""} ;
         H004X2_A15UsuarioId = new long[1] ;
         H004X2_A93UsuarioNombre = new string[] {""} ;
         AV29WebSession = context.GetSession();
         H004X3_A290EtapaDesarrolloId = new short[1] ;
         H004X3_n290EtapaDesarrolloId = new bool[] {false} ;
         H004X3_A17EstadoTicketTecnicoId = new short[1] ;
         H004X3_A95UsuarioTelefono = new int[1] ;
         H004X3_A57TicketOtros = new bool[] {false} ;
         H004X3_n57TicketOtros = new bool[] {false} ;
         H004X3_A52TicketInstalarDataShow = new bool[] {false} ;
         H004X3_n52TicketInstalarDataShow = new bool[] {false} ;
         H004X3_A87TicketUps = new bool[] {false} ;
         H004X3_n87TicketUps = new bool[] {false} ;
         H004X3_A58TicketPerifericos = new bool[] {false} ;
         H004X3_n58TicketPerifericos = new bool[] {false} ;
         H004X3_A43TicketDiscoDuroExterno = new bool[] {false} ;
         H004X3_n43TicketDiscoDuroExterno = new bool[] {false} ;
         H004X3_A39TicketAntivirus = new bool[] {false} ;
         H004X3_n39TicketAntivirus = new bool[] {false} ;
         H004X3_A56TicketOffice = new bool[] {false} ;
         H004X3_n56TicketOffice = new bool[] {false} ;
         H004X3_A60TicketSistemaOperativo = new bool[] {false} ;
         H004X3_n60TicketSistemaOperativo = new bool[] {false} ;
         H004X3_A59TicketRouter = new bool[] {false} ;
         H004X3_n59TicketRouter = new bool[] {false} ;
         H004X3_A45TicketEscaner = new bool[] {false} ;
         H004X3_n45TicketEscaner = new bool[] {false} ;
         H004X3_A50TicketImpresora = new bool[] {false} ;
         H004X3_n50TicketImpresora = new bool[] {false} ;
         H004X3_A55TicketMonitor = new bool[] {false} ;
         H004X3_n55TicketMonitor = new bool[] {false} ;
         H004X3_A42TicketDesktop = new bool[] {false} ;
         H004X3_n42TicketDesktop = new bool[] {false} ;
         H004X3_A53TicketLaptop = new bool[] {false} ;
         H004X3_n53TicketLaptop = new bool[] {false} ;
         H004X3_A167TicketResponsablePasaTaller = new bool[] {false} ;
         H004X3_n167TicketResponsablePasaTaller = new bool[] {false} ;
         H004X3_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H004X3_A198TicketTecnicoResponsableId = new short[1] ;
         H004X3_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H004X3_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H004X3_A16TicketResponsableId = new long[1] ;
         H004X3_A14TicketId = new long[1] ;
         H004X3_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H004X3_A89UsuarioEmail = new string[] {""} ;
         H004X3_A88UsuarioDepartamento = new string[] {""} ;
         H004X3_A94UsuarioRequerimiento = new string[] {""} ;
         H004X3_A15UsuarioId = new long[1] ;
         H004X3_A93UsuarioNombre = new string[] {""} ;
         GridRow = new GXWebRow();
         GXt_char1 = "";
         AV10GridStateKey = "";
         AV11GridState = new SdtK2BGridState(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpasignacion__default(),
            new Object[][] {
                new Object[] {
               H004X2_A290EtapaDesarrolloId, H004X2_n290EtapaDesarrolloId, H004X2_A17EstadoTicketTecnicoId, H004X2_A95UsuarioTelefono, H004X2_A57TicketOtros, H004X2_n57TicketOtros, H004X2_A52TicketInstalarDataShow, H004X2_n52TicketInstalarDataShow, H004X2_A87TicketUps, H004X2_n87TicketUps,
               H004X2_A58TicketPerifericos, H004X2_n58TicketPerifericos, H004X2_A43TicketDiscoDuroExterno, H004X2_n43TicketDiscoDuroExterno, H004X2_A39TicketAntivirus, H004X2_n39TicketAntivirus, H004X2_A56TicketOffice, H004X2_n56TicketOffice, H004X2_A60TicketSistemaOperativo, H004X2_n60TicketSistemaOperativo,
               H004X2_A59TicketRouter, H004X2_n59TicketRouter, H004X2_A45TicketEscaner, H004X2_n45TicketEscaner, H004X2_A50TicketImpresora, H004X2_n50TicketImpresora, H004X2_A55TicketMonitor, H004X2_n55TicketMonitor, H004X2_A42TicketDesktop, H004X2_n42TicketDesktop,
               H004X2_A53TicketLaptop, H004X2_n53TicketLaptop, H004X2_A167TicketResponsablePasaTaller, H004X2_n167TicketResponsablePasaTaller, H004X2_A199TicketTecnicoResponsableNombre, H004X2_A198TicketTecnicoResponsableId, H004X2_A48TicketHora, H004X2_A46TicketFecha, H004X2_A16TicketResponsableId, H004X2_A14TicketId,
               H004X2_A90UsuarioFecha, H004X2_A89UsuarioEmail, H004X2_A88UsuarioDepartamento, H004X2_A94UsuarioRequerimiento, H004X2_A15UsuarioId, H004X2_A93UsuarioNombre
               }
               , new Object[] {
               H004X3_A290EtapaDesarrolloId, H004X3_n290EtapaDesarrolloId, H004X3_A17EstadoTicketTecnicoId, H004X3_A95UsuarioTelefono, H004X3_A57TicketOtros, H004X3_n57TicketOtros, H004X3_A52TicketInstalarDataShow, H004X3_n52TicketInstalarDataShow, H004X3_A87TicketUps, H004X3_n87TicketUps,
               H004X3_A58TicketPerifericos, H004X3_n58TicketPerifericos, H004X3_A43TicketDiscoDuroExterno, H004X3_n43TicketDiscoDuroExterno, H004X3_A39TicketAntivirus, H004X3_n39TicketAntivirus, H004X3_A56TicketOffice, H004X3_n56TicketOffice, H004X3_A60TicketSistemaOperativo, H004X3_n60TicketSistemaOperativo,
               H004X3_A59TicketRouter, H004X3_n59TicketRouter, H004X3_A45TicketEscaner, H004X3_n45TicketEscaner, H004X3_A50TicketImpresora, H004X3_n50TicketImpresora, H004X3_A55TicketMonitor, H004X3_n55TicketMonitor, H004X3_A42TicketDesktop, H004X3_n42TicketDesktop,
               H004X3_A53TicketLaptop, H004X3_n53TicketLaptop, H004X3_A167TicketResponsablePasaTaller, H004X3_n167TicketResponsablePasaTaller, H004X3_A199TicketTecnicoResponsableNombre, H004X3_A198TicketTecnicoResponsableId, H004X3_A48TicketHora, H004X3_A46TicketFecha, H004X3_A16TicketResponsableId, H004X3_A14TicketId,
               H004X3_A90UsuarioFecha, H004X3_A89UsuarioEmail, H004X3_A88UsuarioDepartamento, H004X3_A94UsuarioRequerimiento, H004X3_A15UsuarioId, H004X3_A93UsuarioNombre
               }
            }
         );
         AV32Pgmname = "WPAsignacion";
         /* GeneXus formulas. */
         AV32Pgmname = "WPAsignacion";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16CurrentPage_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short AV19RowsPerPage_Grid ;
      private short A17EstadoTicketTecnicoId ;
      private short A290EtapaDesarrolloId ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A198TicketTecnicoResponsableId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV21GridSettingsRowsPerPage_Grid ;
      private short AV22PageCount_Grid ;
      private short subGrid_Backstyle ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int nRC_GXsfl_68 ;
      private int nGXsfl_68_idx=1 ;
      private int subGrid_Rows ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtUsuarioNombre_Forecolor ;
      private int edtUsuarioRequerimiento_Forecolor ;
      private int edtUsuarioDepartamento_Forecolor ;
      private int edtUsuarioFecha_Forecolor ;
      private int edtTicketFecha_Forecolor ;
      private int edtTicketHora_Forecolor ;
      private int edtTicketTecnicoResponsableNombre_Forecolor ;
      private int A95UsuarioTelefono ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int lblPaginationbar_lastpagetextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavActionregistrar_action_Enabled ;
      private int edtavActionregistrar_action_Visible ;
      private int edtavActionreasignar_action_Enabled ;
      private int edtavActionreasignar_action_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long A15UsuarioId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_68_idx="0001" ;
      private string AV32Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtavActionregistrar_action_Tooltiptext ;
      private string edtavActionreasignar_action_Tooltiptext ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string chkTicketResponsablePasaTaller_Internalname ;
      private string edtavActionregistrar_action_Internalname ;
      private string edtavActionreasignar_action_Internalname ;
      private string chkTicketLaptop_Internalname ;
      private string chkTicketDesktop_Internalname ;
      private string chkTicketMonitor_Internalname ;
      private string chkTicketImpresora_Internalname ;
      private string chkTicketEscaner_Internalname ;
      private string chkTicketRouter_Internalname ;
      private string chkTicketSistemaOperativo_Internalname ;
      private string chkTicketOffice_Internalname ;
      private string chkTicketAntivirus_Internalname ;
      private string chkTicketDiscoDuroExterno_Internalname ;
      private string chkTicketPerifericos_Internalname ;
      private string chkTicketUps_Internalname ;
      private string chkTicketInstalarDataShow_Internalname ;
      private string chkTicketOtros_Internalname ;
      private string edtUsuarioTelefono_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Internalname ;
      private string scmdbuf ;
      private string chkavFreezecolumntitles_grid_Internalname ;
      private string divGridsettings_contentoutertablegrid_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string GXt_char1 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string tblLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string TempTags ;
      private string sImgUrl ;
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
      private string sGXsfl_68_fel_idx="0001" ;
      private string ROClassString ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtUsuarioDepartamento_Jsonclick ;
      private string edtUsuarioEmail_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketHora_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string GXCCtl ;
      private string edtavActionregistrar_action_Jsonclick ;
      private string edtavActionreasignar_action_Jsonclick ;
      private string edtUsuarioTelefono_Jsonclick ;
      private DateTime A48TicketHora ;
      private DateTime A90UsuarioFecha ;
      private DateTime A46TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV23FreezeColumnTitles_Grid ;
      private bool wbLoad ;
      private bool A167TicketResponsablePasaTaller ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool A52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n167TicketResponsablePasaTaller ;
      private bool bGXsfl_68_Refreshing=false ;
      private bool n53TicketLaptop ;
      private bool n42TicketDesktop ;
      private bool n55TicketMonitor ;
      private bool n50TicketImpresora ;
      private bool n45TicketEscaner ;
      private bool n59TicketRouter ;
      private bool n60TicketSistemaOperativo ;
      private bool n56TicketOffice ;
      private bool n39TicketAntivirus ;
      private bool n43TicketDiscoDuroExterno ;
      private bool n58TicketPerifericos ;
      private bool n87TicketUps ;
      private bool n52TicketInstalarDataShow ;
      private bool n57TicketOtros ;
      private bool n290EtapaDesarrolloId ;
      private bool gxdyncontrolsrefreshing ;
      private bool gx_refresh_fired ;
      private bool returnInSub ;
      private bool AV20RowsPerPageLoaded_Grid ;
      private bool AV25ActionRegistrar_Action_IsBlob ;
      private bool AV26ActionReasignar_Action_IsBlob ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A88UsuarioDepartamento ;
      private string A89UsuarioEmail ;
      private string A199TicketTecnicoResponsableNombre ;
      private string AV33Actionregistrar_action_GXI ;
      private string AV34Actionreasignar_action_GXI ;
      private string AV10GridStateKey ;
      private string AV25ActionRegistrar_Action ;
      private string AV26ActionReasignar_Action ;
      private IGxSession AV29WebSession ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private GXCheckbox chkTicketResponsablePasaTaller ;
      private GXCheckbox chkTicketLaptop ;
      private GXCheckbox chkTicketDesktop ;
      private GXCheckbox chkTicketMonitor ;
      private GXCheckbox chkTicketImpresora ;
      private GXCheckbox chkTicketEscaner ;
      private GXCheckbox chkTicketRouter ;
      private GXCheckbox chkTicketSistemaOperativo ;
      private GXCheckbox chkTicketOffice ;
      private GXCheckbox chkTicketAntivirus ;
      private GXCheckbox chkTicketDiscoDuroExterno ;
      private GXCheckbox chkTicketPerifericos ;
      private GXCheckbox chkTicketUps ;
      private GXCheckbox chkTicketInstalarDataShow ;
      private GXCheckbox chkTicketOtros ;
      private IDataStoreProvider pr_default ;
      private short[] H004X2_A290EtapaDesarrolloId ;
      private bool[] H004X2_n290EtapaDesarrolloId ;
      private short[] H004X2_A17EstadoTicketTecnicoId ;
      private int[] H004X2_A95UsuarioTelefono ;
      private bool[] H004X2_A57TicketOtros ;
      private bool[] H004X2_n57TicketOtros ;
      private bool[] H004X2_A52TicketInstalarDataShow ;
      private bool[] H004X2_n52TicketInstalarDataShow ;
      private bool[] H004X2_A87TicketUps ;
      private bool[] H004X2_n87TicketUps ;
      private bool[] H004X2_A58TicketPerifericos ;
      private bool[] H004X2_n58TicketPerifericos ;
      private bool[] H004X2_A43TicketDiscoDuroExterno ;
      private bool[] H004X2_n43TicketDiscoDuroExterno ;
      private bool[] H004X2_A39TicketAntivirus ;
      private bool[] H004X2_n39TicketAntivirus ;
      private bool[] H004X2_A56TicketOffice ;
      private bool[] H004X2_n56TicketOffice ;
      private bool[] H004X2_A60TicketSistemaOperativo ;
      private bool[] H004X2_n60TicketSistemaOperativo ;
      private bool[] H004X2_A59TicketRouter ;
      private bool[] H004X2_n59TicketRouter ;
      private bool[] H004X2_A45TicketEscaner ;
      private bool[] H004X2_n45TicketEscaner ;
      private bool[] H004X2_A50TicketImpresora ;
      private bool[] H004X2_n50TicketImpresora ;
      private bool[] H004X2_A55TicketMonitor ;
      private bool[] H004X2_n55TicketMonitor ;
      private bool[] H004X2_A42TicketDesktop ;
      private bool[] H004X2_n42TicketDesktop ;
      private bool[] H004X2_A53TicketLaptop ;
      private bool[] H004X2_n53TicketLaptop ;
      private bool[] H004X2_A167TicketResponsablePasaTaller ;
      private bool[] H004X2_n167TicketResponsablePasaTaller ;
      private string[] H004X2_A199TicketTecnicoResponsableNombre ;
      private short[] H004X2_A198TicketTecnicoResponsableId ;
      private DateTime[] H004X2_A48TicketHora ;
      private DateTime[] H004X2_A46TicketFecha ;
      private long[] H004X2_A16TicketResponsableId ;
      private long[] H004X2_A14TicketId ;
      private DateTime[] H004X2_A90UsuarioFecha ;
      private string[] H004X2_A89UsuarioEmail ;
      private string[] H004X2_A88UsuarioDepartamento ;
      private string[] H004X2_A94UsuarioRequerimiento ;
      private long[] H004X2_A15UsuarioId ;
      private string[] H004X2_A93UsuarioNombre ;
      private short[] H004X3_A290EtapaDesarrolloId ;
      private bool[] H004X3_n290EtapaDesarrolloId ;
      private short[] H004X3_A17EstadoTicketTecnicoId ;
      private int[] H004X3_A95UsuarioTelefono ;
      private bool[] H004X3_A57TicketOtros ;
      private bool[] H004X3_n57TicketOtros ;
      private bool[] H004X3_A52TicketInstalarDataShow ;
      private bool[] H004X3_n52TicketInstalarDataShow ;
      private bool[] H004X3_A87TicketUps ;
      private bool[] H004X3_n87TicketUps ;
      private bool[] H004X3_A58TicketPerifericos ;
      private bool[] H004X3_n58TicketPerifericos ;
      private bool[] H004X3_A43TicketDiscoDuroExterno ;
      private bool[] H004X3_n43TicketDiscoDuroExterno ;
      private bool[] H004X3_A39TicketAntivirus ;
      private bool[] H004X3_n39TicketAntivirus ;
      private bool[] H004X3_A56TicketOffice ;
      private bool[] H004X3_n56TicketOffice ;
      private bool[] H004X3_A60TicketSistemaOperativo ;
      private bool[] H004X3_n60TicketSistemaOperativo ;
      private bool[] H004X3_A59TicketRouter ;
      private bool[] H004X3_n59TicketRouter ;
      private bool[] H004X3_A45TicketEscaner ;
      private bool[] H004X3_n45TicketEscaner ;
      private bool[] H004X3_A50TicketImpresora ;
      private bool[] H004X3_n50TicketImpresora ;
      private bool[] H004X3_A55TicketMonitor ;
      private bool[] H004X3_n55TicketMonitor ;
      private bool[] H004X3_A42TicketDesktop ;
      private bool[] H004X3_n42TicketDesktop ;
      private bool[] H004X3_A53TicketLaptop ;
      private bool[] H004X3_n53TicketLaptop ;
      private bool[] H004X3_A167TicketResponsablePasaTaller ;
      private bool[] H004X3_n167TicketResponsablePasaTaller ;
      private string[] H004X3_A199TicketTecnicoResponsableNombre ;
      private short[] H004X3_A198TicketTecnicoResponsableId ;
      private DateTime[] H004X3_A48TicketHora ;
      private DateTime[] H004X3_A46TicketFecha ;
      private long[] H004X3_A16TicketResponsableId ;
      private long[] H004X3_A14TicketId ;
      private DateTime[] H004X3_A90UsuarioFecha ;
      private string[] H004X3_A89UsuarioEmail ;
      private string[] H004X3_A88UsuarioDepartamento ;
      private string[] H004X3_A94UsuarioRequerimiento ;
      private long[] H004X3_A15UsuarioId ;
      private string[] H004X3_A93UsuarioNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV17ClassCollection_Grid ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV15GridConfiguration ;
      private SdtK2BGridState AV11GridState ;
   }

   public class wpasignacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004X2;
          prmH004X2 = new Object[] {
          };
          Object[] prmH004X3;
          prmH004X3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004X2", "SELECT T1.[EtapaDesarrolloId], T1.[EstadoTicketTecnicoId], T4.[UsuarioTelefono], T3.[TicketOtros], T3.[TicketInstalarDataShow], T3.[TicketUps], T3.[TicketPerifericos], T3.[TicketDiscoDuroExterno], T3.[TicketAntivirus], T3.[TicketOffice], T3.[TicketSistemaOperativo], T3.[TicketRouter], T3.[TicketEscaner], T3.[TicketImpresora], T3.[TicketMonitor], T3.[TicketDesktop], T3.[TicketLaptop], T1.[TicketResponsablePasaTaller], T2.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T3.[TicketHora], T3.[TicketFecha], T1.[TicketResponsableId], T1.[TicketId], T4.[UsuarioFecha], T4.[UsuarioEmail], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T3.[UsuarioId], T4.[UsuarioNombre] FROM ((([TicketResponsable] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[TicketTecnicoResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId]) WHERE (T1.[EstadoTicketTecnicoId] = 3) AND (T1.[EtapaDesarrolloId] = 8) ORDER BY T1.[EstadoTicketTecnicoId]  OPTION (FAST 21)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004X2,21, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004X3", "SELECT T1.[EtapaDesarrolloId], T1.[EstadoTicketTecnicoId], T4.[UsuarioTelefono], T3.[TicketOtros], T3.[TicketInstalarDataShow], T3.[TicketUps], T3.[TicketPerifericos], T3.[TicketDiscoDuroExterno], T3.[TicketAntivirus], T3.[TicketOffice], T3.[TicketSistemaOperativo], T3.[TicketRouter], T3.[TicketEscaner], T3.[TicketImpresora], T3.[TicketMonitor], T3.[TicketDesktop], T3.[TicketLaptop], T1.[TicketResponsablePasaTaller], T2.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T3.[TicketHora], T3.[TicketFecha], T1.[TicketResponsableId], T1.[TicketId], T4.[UsuarioFecha], T4.[UsuarioEmail], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T3.[UsuarioId], T4.[UsuarioNombre] FROM ((([TicketResponsable] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[TicketTecnicoResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId]) WHERE (T1.[EstadoTicketTecnicoId] = 3) AND (T1.[EtapaDesarrolloId] = 8) ORDER BY T1.[EstadoTicketTecnicoId]  OPTION (FAST 21)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004X3,21, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((bool[]) buf[12])[0] = rslt.getBool(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((bool[]) buf[14])[0] = rslt.getBool(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((bool[]) buf[16])[0] = rslt.getBool(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((bool[]) buf[18])[0] = rslt.getBool(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((bool[]) buf[20])[0] = rslt.getBool(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((bool[]) buf[22])[0] = rslt.getBool(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((bool[]) buf[24])[0] = rslt.getBool(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((bool[]) buf[26])[0] = rslt.getBool(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((bool[]) buf[28])[0] = rslt.getBool(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((bool[]) buf[30])[0] = rslt.getBool(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((bool[]) buf[32])[0] = rslt.getBool(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((string[]) buf[34])[0] = rslt.getVarchar(19);
                ((short[]) buf[35])[0] = rslt.getShort(20);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(21);
                ((DateTime[]) buf[37])[0] = rslt.getGXDate(22);
                ((long[]) buf[38])[0] = rslt.getLong(23);
                ((long[]) buf[39])[0] = rslt.getLong(24);
                ((DateTime[]) buf[40])[0] = rslt.getGXDate(25);
                ((string[]) buf[41])[0] = rslt.getVarchar(26);
                ((string[]) buf[42])[0] = rslt.getVarchar(27);
                ((string[]) buf[43])[0] = rslt.getVarchar(28);
                ((long[]) buf[44])[0] = rslt.getLong(29);
                ((string[]) buf[45])[0] = rslt.getVarchar(30);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((bool[]) buf[12])[0] = rslt.getBool(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((bool[]) buf[14])[0] = rslt.getBool(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((bool[]) buf[16])[0] = rslt.getBool(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((bool[]) buf[18])[0] = rslt.getBool(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((bool[]) buf[20])[0] = rslt.getBool(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((bool[]) buf[22])[0] = rslt.getBool(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((bool[]) buf[24])[0] = rslt.getBool(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((bool[]) buf[26])[0] = rslt.getBool(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((bool[]) buf[28])[0] = rslt.getBool(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((bool[]) buf[30])[0] = rslt.getBool(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((bool[]) buf[32])[0] = rslt.getBool(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((string[]) buf[34])[0] = rslt.getVarchar(19);
                ((short[]) buf[35])[0] = rslt.getShort(20);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(21);
                ((DateTime[]) buf[37])[0] = rslt.getGXDate(22);
                ((long[]) buf[38])[0] = rslt.getLong(23);
                ((long[]) buf[39])[0] = rslt.getLong(24);
                ((DateTime[]) buf[40])[0] = rslt.getGXDate(25);
                ((string[]) buf[41])[0] = rslt.getVarchar(26);
                ((string[]) buf[42])[0] = rslt.getVarchar(27);
                ((string[]) buf[43])[0] = rslt.getVarchar(28);
                ((long[]) buf[44])[0] = rslt.getLong(29);
                ((string[]) buf[45])[0] = rslt.getVarchar(30);
                return;
       }
    }

 }

}
