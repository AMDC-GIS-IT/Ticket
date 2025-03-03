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
   public class wplistaticketasignados : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wplistaticketasignados( )
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

      public wplistaticketasignados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
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
         cmbavGridsettingsrowsperpage_gridusuario = new GXCombobox();
         chkavFreezecolumntitles_gridusuario = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridusuario") == 0 )
            {
               nRC_GXsfl_100 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_100"), "."));
               nGXsfl_100_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_100_idx"), "."));
               sGXsfl_100_idx = GetPar( "sGXsfl_100_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridusuario_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridusuario") == 0 )
            {
               subGridusuario_Rows = (int)(NumberUtil.Val( GetPar( "subGridusuario_Rows"), "."));
               AV28GenericFilter_GridUsuario = GetPar( "GenericFilter_GridUsuario");
               AV33UsuarioNombre_Filter = GetPar( "UsuarioNombre_Filter");
               AV34EstadoTicketUsuarioNombre_Filter = GetPar( "EstadoTicketUsuarioNombre_Filter");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV22ClassCollection_GridUsuario);
               AV21OrderedBy_GridUsuario = (short)(NumberUtil.Val( GetPar( "OrderedBy_GridUsuario"), "."));
               AV40Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV17GridConfiguration);
               AV18CurrentPage_GridUsuario = (short)(NumberUtil.Val( GetPar( "CurrentPage_GridUsuario"), "."));
               AV32FreezeColumnTitles_GridUsuario = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_GridUsuario"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
               GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Rows), 6, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRIDUSUARIO_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_gridusuario_Emptystatemessage));
               GxWebStd.gx_hidden_field( context, "ORDERBYUC_GRIDUSUARIO_Gridcontrolname", StringUtil.RTrim( Orderbyuc_gridusuario_Gridcontrolname));
               GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridusuario_Visible), 5, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0, ".", "")));
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
            return "wpregistrarticket_Execute" ;
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
         PA6V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6V2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202211711452025", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wplistaticketasignados.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vGENERICFILTER_GRIDUSUARIO", StringUtil.RTrim( AV28GenericFilter_GridUsuario));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIONOMBRE_FILTER", AV33UsuarioNombre_Filter);
         GxWebStd.gx_hidden_field( context, "GXH_vESTADOTICKETUSUARIONOMBRE_FILTER", AV34EstadoTicketUsuarioNombre_Filter);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_100", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_100), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_GRIDUSUARIO", AV19FilterTagsCollection_GridUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_GRIDUSUARIO", AV19FilterTagsCollection_GridUsuario);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_GRIDUSUARIO", StringUtil.RTrim( AV20DeletedTag_GridUsuario));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS_GRIDUSUARIO", AV30GridOrders_GridUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS_GRIDUSUARIO", AV30GridOrders_GridUsuario);
         }
         GxWebStd.gx_hidden_field( context, "vSELECTEDORDERBY_GRIDUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29SelectedOrderBy_GridUsuario), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18CurrentPage_GridUsuario), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRIDUSUARIO", AV22ClassCollection_GridUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRIDUSUARIO", AV22ClassCollection_GridUsuario);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV17GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV17GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY_GRIDUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21OrderedBy_GridUsuario), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRIDUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RowsPerPage_GridUsuario), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRIDUSUARIO_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_gridusuario_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "ORDERBYUC_GRIDUSUARIO_Gridcontrolname", StringUtil.RTrim( Orderbyuc_gridusuario_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridusuario_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0, ".", "")));
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
            WE6V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6V2( ) ;
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
         return formatLink("wplistaticketasignados.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPListaTicketAsignados" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPLista Ticket Asignados" ;
      }

      protected void WB6V0( )
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_gridusuario_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_gridusuario_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_gridusuario_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section4_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_gridusuario_Internalname, "Generic Filter_Grid Usuario", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_100_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_gridusuario_Internalname, StringUtil.RTrim( AV28GenericFilter_GridUsuario), StringUtil.RTrim( context.localUtil.Format( AV28GenericFilter_GridUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_gridusuario_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_gridusuario_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPListaTicketAsignados.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_gridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRIDUSUARIO.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPListaTicketAsignados.htm");
            /* User Defined Control */
            ucFiltertagsusercontrol_gridusuario.SetProperty("TagValues", AV19FilterTagsCollection_GridUsuario);
            ucFiltertagsusercontrol_gridusuario.SetProperty("DeletedTag", AV20DeletedTag_GridUsuario);
            ucFiltertagsusercontrol_gridusuario.Render(context, "k2btagsviewer", Filtertagsusercontrol_gridusuario_Internalname, "FILTERTAGSUSERCONTROL_GRIDUSUARIOContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_gridusuario_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_gridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_GRIDUSUARIO.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPListaTicketAsignados.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_usuarionombre_filter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsuarionombre_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_filter_Internalname, "Usuario:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_100_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_filter_Internalname, AV33UsuarioNombre_Filter, StringUtil.RTrim( context.localUtil.Format( AV33UsuarioNombre_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_filter_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPListaTicketAsignados.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_estadoticketusuarionombre_filter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavEstadoticketusuarionombre_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEstadoticketusuarionombre_filter_Internalname, "Estado Ticket", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_100_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstadoticketusuarionombre_filter_Internalname, AV34EstadoTicketUsuarioNombre_Filter, StringUtil.RTrim( context.localUtil.Format( AV34EstadoTicketUsuarioNombre_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstadoticketusuarionombre_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavEstadoticketusuarionombre_filter_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPListaTicketAsignados.htm");
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
            wb_table1_53_6V2( true) ;
         }
         else
         {
            wb_table1_53_6V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_53_6V2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridusuario_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_gridusuario_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_97_6V2( true) ;
         }
         else
         {
            wb_table2_97_6V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_97_6V2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_121_6V2( true) ;
         }
         else
         {
            wb_table3_121_6V2( false) ;
         }
         return  ;
      }

      protected void wb_table3_121_6V2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_gridusuario_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_gridusuario_Internalname, divPaginationbar_pagingcontainertable_gridusuario_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgridusuario_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRIDUSUARIO)\\'."+"'", "", lblPaginationbar_previouspagebuttontextblockgridusuario_Class, 5, "", 1, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgridusuario_Internalname, lblPaginationbar_firstpagetextblockgridusuario_Caption, "", "", lblPaginationbar_firstpagetextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGFIRST(GRIDUSUARIO)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_firstpagetextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgridusuario_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgridusuario_Internalname, lblPaginationbar_previouspagetextblockgridusuario_Caption, "", "", lblPaginationbar_previouspagetextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGPREVIOUS(GRIDUSUARIO)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_previouspagetextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgridusuario_Internalname, lblPaginationbar_currentpagetextblockgridusuario_Caption, "", "", lblPaginationbar_currentpagetextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgridusuario_Internalname, lblPaginationbar_nextpagetextblockgridusuario_Caption, "", "", lblPaginationbar_nextpagetextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRIDUSUARIO)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_nextpagetextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgridusuario_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_lastpagetextblockgridusuario_Internalname, lblPaginationbar_lastpagetextblockgridusuario_Caption, "", "", lblPaginationbar_lastpagetextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGLAST(GRIDUSUARIO)\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPaginationbar_lastpagetextblockgridusuario_Visible, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgridusuario_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'PAGINGNEXT(GRIDUSUARIO)\\'."+"'", "", lblPaginationbar_nextpagebuttontextblockgridusuario_Class, 5, "", 1, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
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
         if ( wbEnd == 100 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridusuarioContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridusuarioContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusuario", GridusuarioContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusuarioContainerData", GridusuarioContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusuarioContainerData"+"V", GridusuarioContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusuarioContainerData"+"V"+"\" value='"+GridusuarioContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
            }
            Form.Meta.addItem("description", "WPLista Ticket Asignados", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6V0( ) ;
      }

      protected void WS6V2( )
      {
         START6V2( ) ;
         EVT6V2( ) ;
      }

      protected void EVT6V2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTAGSUSERCONTROL_GRIDUSUARIO.TAGDELETED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E116V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBYUC_GRIDUSUARIO.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E126V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGFIRST(GRIDUSUARIO)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingFirst(GridUsuario)' */
                              E136V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGPREVIOUS(GRIDUSUARIO)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingPrevious(GridUsuario)' */
                              E146V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGNEXT(GRIDUSUARIO)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingNext(GridUsuario)' */
                              E156V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAGINGLAST(GRIDUSUARIO)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PagingLast(GridUsuario)' */
                              E166V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRIDUSUARIO)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(GridUsuario)' */
                              E176V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRIDUSUARIO.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E186V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRIDUSUARIO.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E196V2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDUSUARIO.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDUSUARIO.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_100_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
                              SubsflControlProps_1002( ) ;
                              A15UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtUsuarioHora_Internalname), 0));
                              A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A89UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
                              A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ",", "."));
                              A189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ",", "."));
                              A190EstadoTicketUsuarioNombre = cgiGet( edtEstadoTicketUsuarioNombre_Internalname);
                              A278TicketUsuarioAsigno = cgiGet( edtTicketUsuarioAsigno_Internalname);
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", "."));
                              A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ",", "."));
                              A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E206V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E216V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDUSUARIO.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E226V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDUSUARIO.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E236V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Genericfilter_gridusuario Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRIDUSUARIO"), AV28GenericFilter_GridUsuario) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarionombre_filter Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE_FILTER"), AV33UsuarioNombre_Filter) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Estadoticketusuarionombre_filter Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vESTADOTICKETUSUARIONOMBRE_FILTER"), AV34EstadoTicketUsuarioNombre_Filter) != 0 )
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

      protected void WE6V2( )
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

      protected void PA6V2( )
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
               GX_FocusControl = edtavGenericfilter_gridusuario_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridusuario_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1002( ) ;
         while ( nGXsfl_100_idx <= nRC_GXsfl_100 )
         {
            sendrow_1002( ) ;
            nGXsfl_100_idx = ((subGridusuario_Islastpage==1)&&(nGXsfl_100_idx+1>subGridusuario_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1002( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridusuarioContainer)) ;
         /* End function gxnrGridusuario_newrow */
      }

      protected void gxgrGridusuario_refresh( int subGridusuario_Rows ,
                                              string AV28GenericFilter_GridUsuario ,
                                              string AV33UsuarioNombre_Filter ,
                                              string AV34EstadoTicketUsuarioNombre_Filter ,
                                              GxSimpleCollection<string> AV22ClassCollection_GridUsuario ,
                                              short AV21OrderedBy_GridUsuario ,
                                              string AV40Pgmname ,
                                              SdtK2BGridConfiguration AV17GridConfiguration ,
                                              short AV18CurrentPage_GridUsuario ,
                                              bool AV32FreezeColumnTitles_GridUsuario )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E206V2 ();
         GRIDUSUARIO_nCurrentRecord = 0;
         RF6V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridusuario_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         if ( cmbavGridsettingsrowsperpage_gridusuario.ItemCount > 0 )
         {
            AV26GridSettingsRowsPerPage_GridUsuario = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridusuario.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_gridusuario.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridusuario_Internalname, "Values", cmbavGridsettingsrowsperpage_gridusuario.ToJavascriptSource(), true);
         }
         AV32FreezeColumnTitles_GridUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( AV32FreezeColumnTitles_GridUsuario));
         AssignAttri("", false, "AV32FreezeColumnTitles_GridUsuario", AV32FreezeColumnTitles_GridUsuario);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E206V2 ();
         RF6V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV40Pgmname = "WPListaTicketAsignados";
         context.Gx_err = 0;
      }

      protected void RF6V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridusuarioContainer.ClearRows();
         }
         wbStart = 100;
         E236V2 ();
         nGXsfl_100_idx = 1;
         sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
         SubsflControlProps_1002( ) ;
         bGXsfl_100_Refreshing = true;
         GridusuarioContainer.AddObjectProperty("GridName", "Gridusuario");
         GridusuarioContainer.AddObjectProperty("CmpContext", "");
         GridusuarioContainer.AddObjectProperty("InMasterPage", "false");
         GridusuarioContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridusuarioContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridusuarioContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridusuarioContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Backcolorstyle), 1, 0, ".", "")));
         GridusuarioContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Sortable), 1, 0, ".", "")));
         GridusuarioContainer.PageSize = subGridusuario_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1002( ) ;
            GXPagingFrom2 = (int)(((subGridusuario_Rows==0) ? 0 : GRIDUSUARIO_nFirstRecordOnPage));
            GXPagingTo2 = ((subGridusuario_Rows==0) ? 10000 : subGridusuario_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV33UsuarioNombre_Filter ,
                                                 AV34EstadoTicketUsuarioNombre_Filter ,
                                                 AV28GenericFilter_GridUsuario ,
                                                 A93UsuarioNombre ,
                                                 A190EstadoTicketUsuarioNombre ,
                                                 A15UsuarioId ,
                                                 A91UsuarioGerencia ,
                                                 A88UsuarioDepartamento ,
                                                 A94UsuarioRequerimiento ,
                                                 A199TicketTecnicoResponsableNombre ,
                                                 AV21OrderedBy_GridUsuario } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV33UsuarioNombre_Filter = StringUtil.Concat( StringUtil.RTrim( AV33UsuarioNombre_Filter), "%", "");
            lV34EstadoTicketUsuarioNombre_Filter = StringUtil.Concat( StringUtil.RTrim( AV34EstadoTicketUsuarioNombre_Filter), "%", "");
            /* Using cursor H006V2 */
            pr_default.execute(0, new Object[] {lV33UsuarioNombre_Filter, lV34EstadoTicketUsuarioNombre_Filter, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_100_idx = 1;
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1002( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGridusuario_Rows == 0 ) || ( GRIDUSUARIO_nCurrentRecord < subGridusuario_fnc_Recordsperpage( ) ) ) ) )
            {
               A190EstadoTicketUsuarioNombre = H006V2_A190EstadoTicketUsuarioNombre[0];
               A189EstadoTicketUsuarioId = H006V2_A189EstadoTicketUsuarioId[0];
               A95UsuarioTelefono = H006V2_A95UsuarioTelefono[0];
               A89UsuarioEmail = H006V2_A89UsuarioEmail[0];
               A94UsuarioRequerimiento = H006V2_A94UsuarioRequerimiento[0];
               A88UsuarioDepartamento = H006V2_A88UsuarioDepartamento[0];
               A91UsuarioGerencia = H006V2_A91UsuarioGerencia[0];
               A92UsuarioHora = H006V2_A92UsuarioHora[0];
               A90UsuarioFecha = H006V2_A90UsuarioFecha[0];
               A93UsuarioNombre = H006V2_A93UsuarioNombre[0];
               A15UsuarioId = H006V2_A15UsuarioId[0];
               A190EstadoTicketUsuarioNombre = H006V2_A190EstadoTicketUsuarioNombre[0];
               E226V2 ();
               pr_default.readNext(0);
            }
            GRIDUSUARIO_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 100;
            WB6V0( ) ;
         }
         bGXsfl_100_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
      }

      protected int subGridusuario_fnc_Pagecount( )
      {
         GRIDUSUARIO_nRecordCount = subGridusuario_fnc_Recordcount( );
         if ( ((int)((GRIDUSUARIO_nRecordCount) % (subGridusuario_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDUSUARIO_nRecordCount/ (decimal)(subGridusuario_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDUSUARIO_nRecordCount/ (decimal)(subGridusuario_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridusuario_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV33UsuarioNombre_Filter ,
                                              AV34EstadoTicketUsuarioNombre_Filter ,
                                              AV28GenericFilter_GridUsuario ,
                                              A93UsuarioNombre ,
                                              A190EstadoTicketUsuarioNombre ,
                                              A15UsuarioId ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A94UsuarioRequerimiento ,
                                              A199TicketTecnicoResponsableNombre ,
                                              AV21OrderedBy_GridUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV33UsuarioNombre_Filter = StringUtil.Concat( StringUtil.RTrim( AV33UsuarioNombre_Filter), "%", "");
         lV34EstadoTicketUsuarioNombre_Filter = StringUtil.Concat( StringUtil.RTrim( AV34EstadoTicketUsuarioNombre_Filter), "%", "");
         /* Using cursor H006V3 */
         pr_default.execute(1, new Object[] {lV33UsuarioNombre_Filter, lV34EstadoTicketUsuarioNombre_Filter});
         GRIDUSUARIO_nRecordCount = H006V3_AGRIDUSUARIO_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRIDUSUARIO_nRecordCount) ;
      }

      protected int subGridusuario_fnc_Recordsperpage( )
      {
         if ( subGridusuario_Rows > 0 )
         {
            return subGridusuario_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridusuario_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDUSUARIO_nFirstRecordOnPage/ (decimal)(subGridusuario_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridusuario_firstpage( )
      {
         GRIDUSUARIO_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusuario_nextpage( )
      {
         GRIDUSUARIO_nRecordCount = subGridusuario_fnc_Recordcount( );
         if ( ( GRIDUSUARIO_nRecordCount >= subGridusuario_fnc_Recordsperpage( ) ) && ( GRIDUSUARIO_nEOF == 0 ) )
         {
            GRIDUSUARIO_nFirstRecordOnPage = (long)(GRIDUSUARIO_nFirstRecordOnPage+subGridusuario_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ".", "")));
         GridusuarioContainer.AddObjectProperty("GRIDUSUARIO_nFirstRecordOnPage", GRIDUSUARIO_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDUSUARIO_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridusuario_previouspage( )
      {
         if ( GRIDUSUARIO_nFirstRecordOnPage >= subGridusuario_fnc_Recordsperpage( ) )
         {
            GRIDUSUARIO_nFirstRecordOnPage = (long)(GRIDUSUARIO_nFirstRecordOnPage-subGridusuario_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusuario_lastpage( )
      {
         GRIDUSUARIO_nRecordCount = subGridusuario_fnc_Recordcount( );
         if ( GRIDUSUARIO_nRecordCount > subGridusuario_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDUSUARIO_nRecordCount) % (subGridusuario_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDUSUARIO_nFirstRecordOnPage = (long)(GRIDUSUARIO_nRecordCount-subGridusuario_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDUSUARIO_nFirstRecordOnPage = (long)(GRIDUSUARIO_nRecordCount-((int)((GRIDUSUARIO_nRecordCount) % (subGridusuario_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDUSUARIO_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridusuario_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDUSUARIO_nFirstRecordOnPage = (long)(subGridusuario_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDUSUARIO_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIO_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV40Pgmname = "WPListaTicketAsignados";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E216V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_GRIDUSUARIO"), AV19FilterTagsCollection_GridUsuario);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS_GRIDUSUARIO"), AV30GridOrders_GridUsuario);
            /* Read saved values. */
            nRC_GXsfl_100 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_100"), ",", "."));
            AV20DeletedTag_GridUsuario = cgiGet( "vDELETEDTAG_GRIDUSUARIO");
            AV29SelectedOrderBy_GridUsuario = (short)(context.localUtil.CToN( cgiGet( "vSELECTEDORDERBY_GRIDUSUARIO"), ",", "."));
            GRIDUSUARIO_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDUSUARIO_nFirstRecordOnPage"), ",", "."));
            GRIDUSUARIO_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDUSUARIO_nEOF"), ",", "."));
            subGridusuario_Rows = (int)(context.localUtil.CToN( cgiGet( "GRIDUSUARIO_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Rows), 6, 0, ".", "")));
            Filtertagsusercontrol_gridusuario_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_GRIDUSUARIO_Emptystatemessage");
            Orderbyuc_gridusuario_Gridcontrolname = cgiGet( "ORDERBYUC_GRIDUSUARIO_Gridcontrolname");
            divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO_Visible"), ",", "."));
            /* Read variables values. */
            AV28GenericFilter_GridUsuario = cgiGet( edtavGenericfilter_gridusuario_Internalname);
            AssignAttri("", false, "AV28GenericFilter_GridUsuario", AV28GenericFilter_GridUsuario);
            AV33UsuarioNombre_Filter = cgiGet( edtavUsuarionombre_filter_Internalname);
            AssignAttri("", false, "AV33UsuarioNombre_Filter", AV33UsuarioNombre_Filter);
            AV34EstadoTicketUsuarioNombre_Filter = cgiGet( edtavEstadoticketusuarionombre_filter_Internalname);
            AssignAttri("", false, "AV34EstadoTicketUsuarioNombre_Filter", AV34EstadoTicketUsuarioNombre_Filter);
            cmbavGridsettingsrowsperpage_gridusuario.Name = cmbavGridsettingsrowsperpage_gridusuario_Internalname;
            cmbavGridsettingsrowsperpage_gridusuario.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_gridusuario_Internalname);
            AV26GridSettingsRowsPerPage_GridUsuario = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_gridusuario_Internalname), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
            AV32FreezeColumnTitles_GridUsuario = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_gridusuario_Internalname));
            AssignAttri("", false, "AV32FreezeColumnTitles_GridUsuario", AV32FreezeColumnTitles_GridUsuario);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vGENERICFILTER_GRIDUSUARIO"), AV28GenericFilter_GridUsuario) != 0 )
            {
               GRIDUSUARIO_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE_FILTER"), AV33UsuarioNombre_Filter) != 0 )
            {
               GRIDUSUARIO_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vESTADOTICKETUSUARIONOMBRE_FILTER"), AV34EstadoTicketUsuarioNombre_Filter) != 0 )
            {
               GRIDUSUARIO_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E206V2( )
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
         if ( (0==AV18CurrentPage_GridUsuario) )
         {
            AV18CurrentPage_GridUsuario = 1;
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
         }
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRIDUSUARIO)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV22ClassCollection_GridUsuario,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_gridusuario_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_gridusuario_Internalname, "Class", divMaingrid_responsivetable_gridusuario_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection_GridUsuario", AV22ClassCollection_GridUsuario);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E216V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E216V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV40Pgmname,  "GridUsuario", out  AV24RowsPerPage_GridUsuario, out  AV25RowsPerPageLoaded_GridUsuario) ;
         AssignAttri("", false, "AV24RowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_GridUsuario), 4, 0));
         if ( ! AV25RowsPerPageLoaded_GridUsuario )
         {
            AV24RowsPerPage_GridUsuario = 20;
            AssignAttri("", false, "AV24RowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_GridUsuario), 4, 0));
         }
         AV26GridSettingsRowsPerPage_GridUsuario = AV24RowsPerPage_GridUsuario;
         AssignAttri("", false, "AV26GridSettingsRowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
         subGridusuario_Rows = AV24RowsPerPage_GridUsuario;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE(GRIDUSUARIO)' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRIDUSUARIO)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Orderbyuc_gridusuario_Gridcontrolname = subGridusuario_Internalname;
         ucOrderbyuc_gridusuario.SendProperty(context, "", false, Orderbyuc_gridusuario_Internalname, "GridControlName", Orderbyuc_gridusuario_Gridcontrolname);
         AV30GridOrders_GridUsuario = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV31GridOrder_GridUsuario = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV31GridOrder_GridUsuario.gxTpr_Ascendingorder = 0;
         AV31GridOrder_GridUsuario.gxTpr_Descendingorder = 1;
         AV31GridOrder_GridUsuario.gxTpr_Gridcolumnindex = 1;
         AV30GridOrders_GridUsuario.Add(AV31GridOrder_GridUsuario, 0);
         AV31GridOrder_GridUsuario = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV31GridOrder_GridUsuario.gxTpr_Ascendingorder = 2;
         AV31GridOrder_GridUsuario.gxTpr_Descendingorder = 3;
         AV31GridOrder_GridUsuario.gxTpr_Gridcolumnindex = 2;
         AV30GridOrders_GridUsuario.Add(AV31GridOrder_GridUsuario, 0);
         subGridusuario_Backcolorstyle = 3;
         divGridsettings_contentoutertablegridusuario_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridusuario_Visible), 5, 0), true);
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
         AV36TicketUsuarioAsigno = AV35WebSession.Get("UsuarioSistema");
         AV37horaenter = context.localUtil.Time( );
         GX_msglist.addItem(AV37horaenter);
      }

      protected void E126V2( )
      {
         /* Orderbyuc_gridusuario_Orderbychanged Routine */
         returnInSub = false;
         AV21OrderedBy_GridUsuario = AV29SelectedOrderBy_GridUsuario;
         AssignAttri("", false, "AV21OrderedBy_GridUsuario", StringUtil.LTrimStr( (decimal)(AV21OrderedBy_GridUsuario), 4, 0));
         gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection_GridUsuario", AV22ClassCollection_GridUsuario);
      }

      protected void S212( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRIDUSUARIO)' Routine */
         returnInSub = false;
         AV32FreezeColumnTitles_GridUsuario = AV17GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV32FreezeColumnTitles_GridUsuario", AV32FreezeColumnTitles_GridUsuario);
         if ( AV32FreezeColumnTitles_GridUsuario )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV22ClassCollection_GridUsuario) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV22ClassCollection_GridUsuario) ;
         }
      }

      protected void S122( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRIDUSUARIO)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV40Pgmname,  "GridUsuario", ref  AV17GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRIDUSUARIO)' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E226V2( )
      {
         /* Gridusuario_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_gridusuario_Visible = 0;
         AssignProp("", false, tblI_noresultsfoundtablename_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridusuario_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_LOADROWVARS(GRIDUSUARIO)' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 100;
         }
         sendrow_1002( ) ;
         GRIDUSUARIO_nCurrentRecord = (long)(GRIDUSUARIO_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_100_Refreshing )
         {
            context.DoAjaxLoad(100, GridusuarioRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E236V2( )
      {
         /* Gridusuario_Refresh Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_gridusuario_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridusuario_Visible), 5, 0), true);
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV22ClassCollection_GridUsuario) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRIDUSUARIO)' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRIDUSUARIO)' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGridusuario_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRIDUSUARIO)' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29SelectedOrderBy_GridUsuario = AV21OrderedBy_GridUsuario;
         AssignAttri("", false, "AV29SelectedOrderBy_GridUsuario", StringUtil.LTrimStr( (decimal)(AV29SelectedOrderBy_GridUsuario), 4, 0));
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRIDUSUARIO)' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV22ClassCollection_GridUsuario,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_gridusuario_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_gridusuario_Internalname, "Class", divMaingrid_responsivetable_gridusuario_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection_GridUsuario", AV22ClassCollection_GridUsuario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19FilterTagsCollection_GridUsuario", AV19FilterTagsCollection_GridUsuario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
      }

      protected void S192( )
      {
         /* 'U_GRIDREFRESH(GRIDUSUARIO)' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(GRIDUSUARIO)' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE(GRIDUSUARIO)' Routine */
         returnInSub = false;
         AV12GridStateKey = "GridUsuario";
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(subGridusuario_fnc_Currentpage( ));
         AV13GridState.gxTpr_Orderedby = AV21OrderedBy_GridUsuario;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre_Filter";
         AV14GridStateFilterValue.gxTpr_Value = AV33UsuarioNombre_Filter;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "EstadoTicketUsuarioNombre_Filter";
         AV14GridStateFilterValue.gxTpr_Value = AV34EstadoTicketUsuarioNombre_Filter;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "GenericFilter_GridUsuario";
         AV14GridStateFilterValue.gxTpr_Value = AV28GenericFilter_GridUsuario;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE(GRIDUSUARIO)' Routine */
         returnInSub = false;
         AV12GridStateKey = "GridUsuario";
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV21OrderedBy_GridUsuario = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV21OrderedBy_GridUsuario", StringUtil.LTrimStr( (decimal)(AV21OrderedBy_GridUsuario), 4, 0));
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre_Filter") == 0 )
            {
               AV33UsuarioNombre_Filter = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33UsuarioNombre_Filter", AV33UsuarioNombre_Filter);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "EstadoTicketUsuarioNombre_Filter") == 0 )
            {
               AV34EstadoTicketUsuarioNombre_Filter = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34EstadoTicketUsuarioNombre_Filter", AV34EstadoTicketUsuarioNombre_Filter);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "GenericFilter_GridUsuario") == 0 )
            {
               AV28GenericFilter_GridUsuario = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28GenericFilter_GridUsuario", AV28GenericFilter_GridUsuario);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
         AV27PageCount_GridUsuario = (short)(subGridusuario_fnc_Pagecount( ));
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV27PageCount_GridUsuario ) )
         {
            AV18CurrentPage_GridUsuario = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
            subgridusuario_gotopage( AV18CurrentPage_GridUsuario) ;
         }
      }

      protected void E136V2( )
      {
         /* 'PagingFirst(GridUsuario)' Routine */
         returnInSub = false;
         subgridusuario_firstpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E146V2( )
      {
         /* 'PagingPrevious(GridUsuario)' Routine */
         returnInSub = false;
         subgridusuario_previouspage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' */
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
         /* 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' Routine */
         returnInSub = false;
         AV27PageCount_GridUsuario = (short)(subGridusuario_fnc_Pagecount( ));
         if ( AV18CurrentPage_GridUsuario > AV27PageCount_GridUsuario )
         {
            AV18CurrentPage_GridUsuario = AV27PageCount_GridUsuario;
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
            subgridusuario_lastpage( ) ;
         }
         if ( AV27PageCount_GridUsuario == 0 )
         {
            AV18CurrentPage_GridUsuario = 0;
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
         }
         else
         {
            AV18CurrentPage_GridUsuario = (short)(subGridusuario_fnc_Currentpage( ));
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
         }
         lblPaginationbar_firstpagetextblockgridusuario_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgridusuario_Internalname, "Caption", lblPaginationbar_firstpagetextblockgridusuario_Caption, true);
         lblPaginationbar_previouspagetextblockgridusuario_Caption = StringUtil.Str( (decimal)(AV18CurrentPage_GridUsuario-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgridusuario_Internalname, "Caption", lblPaginationbar_previouspagetextblockgridusuario_Caption, true);
         lblPaginationbar_currentpagetextblockgridusuario_Caption = StringUtil.Str( (decimal)(AV18CurrentPage_GridUsuario), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgridusuario_Internalname, "Caption", lblPaginationbar_currentpagetextblockgridusuario_Caption, true);
         lblPaginationbar_nextpagetextblockgridusuario_Caption = StringUtil.Str( (decimal)(AV18CurrentPage_GridUsuario+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgridusuario_Internalname, "Caption", lblPaginationbar_nextpagetextblockgridusuario_Caption, true);
         lblPaginationbar_lastpagetextblockgridusuario_Caption = StringUtil.Str( (decimal)(AV27PageCount_GridUsuario), 10, 0);
         AssignProp("", false, lblPaginationbar_lastpagetextblockgridusuario_Internalname, "Caption", lblPaginationbar_lastpagetextblockgridusuario_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridusuario_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridusuario_Class, true);
         lblPaginationbar_nextpagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridusuario_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridusuario_Class, true);
         if ( (0==AV18CurrentPage_GridUsuario) || ( AV18CurrentPage_GridUsuario <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridusuario_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridusuario_Class, true);
            lblPaginationbar_firstpagetextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridusuario_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridusuario_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridusuario_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgridusuario_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridusuario_Visible), 5, 0), true);
            if ( AV18CurrentPage_GridUsuario == 2 )
            {
               lblPaginationbar_firstpagetextblockgridusuario_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridusuario_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgridusuario_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridusuario_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgridusuario_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridusuario_Visible), 5, 0), true);
               if ( AV18CurrentPage_GridUsuario == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgridusuario_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridusuario_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgridusuario_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridusuario_Visible), 5, 0), true);
               }
            }
         }
         if ( AV18CurrentPage_GridUsuario == AV27PageCount_GridUsuario )
         {
            lblPaginationbar_nextpagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridusuario_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridusuario_Class, true);
            lblPaginationbar_lastpagetextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_lastpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgridusuario_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridusuario_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgridusuario_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridusuario_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgridusuario_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridusuario_Visible), 5, 0), true);
            if ( AV18CurrentPage_GridUsuario == AV27PageCount_GridUsuario - 1 )
            {
               lblPaginationbar_lastpagetextblockgridusuario_Visible = 0;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgridusuario_Visible), 5, 0), true);
               lblPaginationbar_spacingrighttextblockgridusuario_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacingrighttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridusuario_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_lastpagetextblockgridusuario_Visible = 1;
               AssignProp("", false, lblPaginationbar_lastpagetextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_lastpagetextblockgridusuario_Visible), 5, 0), true);
               if ( AV18CurrentPage_GridUsuario == AV27PageCount_GridUsuario - 2 )
               {
                  lblPaginationbar_spacingrighttextblockgridusuario_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridusuario_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacingrighttextblockgridusuario_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacingrighttextblockgridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridusuario_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV18CurrentPage_GridUsuario <= 1 ) && ( AV27PageCount_GridUsuario <= 1 ) )
         {
            divPaginationbar_pagingcontainertable_gridusuario_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_gridusuario_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_gridusuario_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_gridusuario_Visible), 5, 0), true);
         }
      }

      protected void E156V2( )
      {
         /* 'PagingNext(GridUsuario)' Routine */
         returnInSub = false;
         subgridusuario_nextpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E166V2( )
      {
         /* 'PagingLast(GridUsuario)' Routine */
         returnInSub = false;
         subgridusuario_lastpage( ) ;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDUSUARIO)' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E176V2( )
      {
         /* 'SaveGridSettings(GridUsuario)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV40Pgmname,  "GridUsuario", ref  AV17GridConfiguration) ;
         AV17GridConfiguration.gxTpr_Freezecolumntitles = AV32FreezeColumnTitles_GridUsuario;
         new k2bsavegridconfiguration(context ).execute(  AV40Pgmname,  "GridUsuario",  AV17GridConfiguration,  true) ;
         subGridusuario_Rows = AV26GridSettingsRowsPerPage_GridUsuario;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIO_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Rows), 6, 0, ".", "")));
         if ( AV24RowsPerPage_GridUsuario != AV26GridSettingsRowsPerPage_GridUsuario )
         {
            AV24RowsPerPage_GridUsuario = AV26GridSettingsRowsPerPage_GridUsuario;
            AssignAttri("", false, "AV24RowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV24RowsPerPage_GridUsuario), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV40Pgmname,  "GridUsuario",  AV24RowsPerPage_GridUsuario) ;
            AV18CurrentPage_GridUsuario = 1;
            AssignAttri("", false, "AV18CurrentPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV18CurrentPage_GridUsuario), 4, 0));
            subgridusuario_firstpage( ) ;
         }
         gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         divGridsettings_contentoutertablegridusuario_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridusuario_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection_GridUsuario", AV22ClassCollection_GridUsuario);
      }

      protected void S162( )
      {
         /* 'UPDATEFILTERSUMMARY(GRIDUSUARIO)' Routine */
         returnInSub = false;
         AV15K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33UsuarioNombre_Filter)) )
         {
            AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "UsuarioNombre_Filter";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Usuario:";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV33UsuarioNombre_Filter;
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV33UsuarioNombre_Filter;
            AV15K2BFilterValuesSDT_WebForm.Add(AV16K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34EstadoTicketUsuarioNombre_Filter)) )
         {
            AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "EstadoTicketUsuarioNombre_Filter";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Estado Ticket";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV34EstadoTicketUsuarioNombre_Filter;
            AV16K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV34EstadoTicketUsuarioNombre_Filter;
            AV15K2BFilterValuesSDT_WebForm.Add(AV16K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_gridusuario_Emptystatemessage = "No hay filtros aplicados";
         ucFiltertagsusercontrol_gridusuario.SendProperty(context, "", false, Filtertagsusercontrol_gridusuario_Internalname, "EmptyStateMessage", Filtertagsusercontrol_gridusuario_Emptystatemessage);
         if ( AV15K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = AV19FilterTagsCollection_GridUsuario;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV40Pgmname,  "GridUsuario",  AV15K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item2) ;
            AV19FilterTagsCollection_GridUsuario = GXt_objcol_SdtK2BValueDescriptionCollection_Item2;
         }
      }

      protected void E116V2( )
      {
         /* Filtertagsusercontrol_gridusuario_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20DeletedTag_GridUsuario, "UsuarioNombre_Filter") == 0 )
         {
            AV33UsuarioNombre_Filter = "";
            AssignAttri("", false, "AV33UsuarioNombre_Filter", AV33UsuarioNombre_Filter);
         }
         else if ( StringUtil.StrCmp(AV20DeletedTag_GridUsuario, "EstadoTicketUsuarioNombre_Filter") == 0 )
         {
            AV34EstadoTicketUsuarioNombre_Filter = "";
            AssignAttri("", false, "AV34EstadoTicketUsuarioNombre_Filter", AV34EstadoTicketUsuarioNombre_Filter);
         }
         gxgrGridusuario_refresh( subGridusuario_Rows, AV28GenericFilter_GridUsuario, AV33UsuarioNombre_Filter, AV34EstadoTicketUsuarioNombre_Filter, AV22ClassCollection_GridUsuario, AV21OrderedBy_GridUsuario, AV40Pgmname, AV17GridConfiguration, AV18CurrentPage_GridUsuario, AV32FreezeColumnTitles_GridUsuario) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridConfiguration", AV17GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection_GridUsuario", AV22ClassCollection_GridUsuario);
      }

      protected void E186V2( )
      {
         /* Layoutdefined_filtertoggle_combined_gridusuario_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = 0;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = 1;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E196V2( )
      {
         /* Layoutdefined_filterclose_combined_gridusuario_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void wb_table3_121_6V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_gridusuario_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_gridusuario_Internalname, tblI_noresultsfoundtablename_gridusuario_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_gridusuario_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_gridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_121_6V2e( true) ;
         }
         else
         {
            wb_table3_121_6V2e( false) ;
         }
      }

      protected void wb_table2_97_6V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_gridusuario_Internalname, tblTablegridcontainer_gridusuario_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            GridusuarioContainer.SetWrapped(nGXWrapped);
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridusuarioContainer"+"DivS\" data-gxgridid=\"100\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridusuario_Internalname, subGridusuario_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridusuario_Backcolorstyle == 0 )
               {
                  subGridusuario_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridusuario_Class) > 0 )
                  {
                     subGridusuario_Linesclass = subGridusuario_Class+"Title";
                  }
               }
               else
               {
                  subGridusuario_Titlebackstyle = 1;
                  if ( subGridusuario_Backcolorstyle == 1 )
                  {
                     subGridusuario_Titlebackcolor = subGridusuario_Allbackcolor;
                     if ( StringUtil.Len( subGridusuario_Class) > 0 )
                     {
                        subGridusuario_Linesclass = subGridusuario_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridusuario_Class) > 0 )
                     {
                        subGridusuario_Linesclass = subGridusuario_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gerencia:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Departamento:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripci�n del Requerimiento:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Email:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tel�fono:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Estado Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado Ticket") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Ticket Usuario Asigno") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id T�cnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "T�cnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridusuarioContainer.AddObjectProperty("GridName", "Gridusuario");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridusuarioContainer = new GXWebGrid( context);
               }
               else
               {
                  GridusuarioContainer.Clear();
               }
               GridusuarioContainer.SetWrapped(nGXWrapped);
               GridusuarioContainer.AddObjectProperty("GridName", "Gridusuario");
               GridusuarioContainer.AddObjectProperty("Header", subGridusuario_Header);
               GridusuarioContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               GridusuarioContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Backcolorstyle), 1, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Sortable), 1, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("CmpContext", "");
               GridusuarioContainer.AddObjectProperty("InMasterPage", "false");
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A91UsuarioGerencia);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A89UsuarioEmail);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A190EstadoTicketUsuarioNombre);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A278TicketUsuarioAsigno);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridusuarioColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
               GridusuarioContainer.AddColumnProperties(GridusuarioColumn);
               GridusuarioContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Selectedindex), 4, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Allowselection), 1, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Selectioncolor), 9, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Allowhovering), 1, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Hoveringcolor), 9, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Allowcollapsing), 1, 0, ".", "")));
               GridusuarioContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuario_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 100 )
         {
            wbEnd = 0;
            nRC_GXsfl_100 = (int)(nGXsfl_100_idx-1);
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridusuarioContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusuario", GridusuarioContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusuarioContainerData", GridusuarioContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusuarioContainerData"+"V", GridusuarioContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusuarioContainerData"+"V"+"\" value='"+GridusuarioContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucOrderbyuc_gridusuario.SetProperty("GridOrders", AV30GridOrders_GridUsuario);
            ucOrderbyuc_gridusuario.SetProperty("SelectedOrderBy", AV29SelectedOrderBy_GridUsuario);
            ucOrderbyuc_gridusuario.Render(context, "k2borderby", Orderbyuc_gridusuario_Internalname, "ORDERBYUC_GRIDUSUARIOContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_97_6V2e( true) ;
         }
         else
         {
            wb_table2_97_6V2e( false) ;
         }
      }

      protected void wb_table1_53_6V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_gridusuario_Internalname, tblLayoutdefined_table7_gridusuario_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgridusuario_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgridusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+"e246v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPListaTicketAsignados.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegridusuario_Internalname, divGridsettings_contentoutertablegridusuario_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridusuariocontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WPListaTicketAsignados.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridusuariocustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_gridusuario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_gridusuario_Internalname, "Filas por p�gina", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_100_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_gridusuario, cmbavGridsettingsrowsperpage_gridusuario_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0)), 1, cmbavGridsettingsrowsperpage_gridusuario_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_gridusuario.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 1, "HLP_WPListaTicketAsignados.htm");
            cmbavGridsettingsrowsperpage_gridusuario.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridusuario_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_gridusuario.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_gridusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_gridusuario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_gridusuario_Internalname, "Inmovilizar t�tulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_100_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_gridusuario_Internalname, StringUtil.BoolToStr( AV32FreezeColumnTitles_GridUsuario), "", "Inmovilizar t�tulos", 1, chkavFreezecolumntitles_gridusuario.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegridusuario_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(100), 3, 0)+","+"null"+");", "Aplicar", bttGridsettings_savegridusuario_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRIDUSUARIO)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPListaTicketAsignados.htm");
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
            wb_table1_53_6V2e( true) ;
         }
         else
         {
            wb_table1_53_6V2e( false) ;
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
         PA6V2( ) ;
         WS6V2( ) ;
         WE6V2( ) ;
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
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211711452295", true, true);
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
         context.AddJavascriptSource("wplistaticketasignados.js", "?202211711452296", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1002( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_100_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_100_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_100_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_100_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_100_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_100_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_100_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_100_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_100_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_100_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_100_idx;
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE_"+sGXsfl_100_idx;
         edtTicketUsuarioAsigno_Internalname = "TICKETUSUARIOASIGNO_"+sGXsfl_100_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_100_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_100_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_100_idx;
      }

      protected void SubsflControlProps_fel_1002( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_100_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_100_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_100_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_100_fel_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_100_fel_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_100_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_100_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_100_fel_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_100_fel_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_100_fel_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_100_fel_idx;
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE_"+sGXsfl_100_fel_idx;
         edtTicketUsuarioAsigno_Internalname = "TICKETUSUARIOASIGNO_"+sGXsfl_100_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_100_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_100_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_100_fel_idx;
      }

      protected void sendrow_1002( )
      {
         SubsflControlProps_1002( ) ;
         WB6V0( ) ;
         if ( ( subGridusuario_Rows * 1 == 0 ) || ( nGXsfl_100_idx <= subGridusuario_fnc_Recordsperpage( ) * 1 ) )
         {
            GridusuarioRow = GXWebRow.GetNew(context,GridusuarioContainer);
            if ( subGridusuario_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridusuario_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridusuario_Class, "") != 0 )
               {
                  subGridusuario_Linesclass = subGridusuario_Class+"Odd";
               }
            }
            else if ( subGridusuario_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridusuario_Backstyle = 0;
               subGridusuario_Backcolor = subGridusuario_Allbackcolor;
               if ( StringUtil.StrCmp(subGridusuario_Class, "") != 0 )
               {
                  subGridusuario_Linesclass = subGridusuario_Class+"Uniform";
               }
            }
            else if ( subGridusuario_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridusuario_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridusuario_Class, "") != 0 )
               {
                  subGridusuario_Linesclass = subGridusuario_Class+"Odd";
               }
               subGridusuario_Backcolor = (int)(0x0);
            }
            else if ( subGridusuario_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridusuario_Backstyle = 1;
               if ( ((int)((nGXsfl_100_idx) % (2))) == 0 )
               {
                  subGridusuario_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusuario_Class, "") != 0 )
                  {
                     subGridusuario_Linesclass = subGridusuario_Class+"Even";
                  }
               }
               else
               {
                  subGridusuario_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusuario_Class, "") != 0 )
                  {
                     subGridusuario_Linesclass = subGridusuario_Class+"Odd";
                  }
               }
            }
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_100_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioHora_Internalname,context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A92UsuarioHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioGerencia_Internalname,(string)A91UsuarioGerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioGerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioEmail_Internalname,(string)A89UsuarioEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A89UsuarioEmail,(string)"",(string)"",(string)"",(string)edtUsuarioEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefono_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A189EstadoTicketUsuarioId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketUsuarioNombre_Internalname,(string)A190EstadoTicketUsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketUsuarioAsigno_Internalname,(string)A278TicketUsuarioAsigno,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketUsuarioAsigno_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)100,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusuarioContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridusuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)100,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes6V2( ) ;
            GridusuarioContainer.AddRow(GridusuarioRow);
            nGXsfl_100_idx = ((subGridusuario_Islastpage==1)&&(nGXsfl_100_idx+1>subGridusuario_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1002( ) ;
         }
         /* End function sendrow_1002 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_gridusuario.Name = "vGRIDSETTINGSROWSPERPAGE_GRIDUSUARIO";
         cmbavGridsettingsrowsperpage_gridusuario.WebTags = "";
         cmbavGridsettingsrowsperpage_gridusuario.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_gridusuario.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_gridusuario.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_gridusuario.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_gridusuario.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_gridusuario.ItemCount > 0 )
         {
            AV26GridSettingsRowsPerPage_GridUsuario = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridusuario.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0))), "."));
            AssignAttri("", false, "AV26GridSettingsRowsPerPage_GridUsuario", StringUtil.LTrimStr( (decimal)(AV26GridSettingsRowsPerPage_GridUsuario), 4, 0));
         }
         chkavFreezecolumntitles_gridusuario.Name = "vFREEZECOLUMNTITLES_GRIDUSUARIO";
         chkavFreezecolumntitles_gridusuario.WebTags = "";
         chkavFreezecolumntitles_gridusuario.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_gridusuario_Internalname, "TitleCaption", chkavFreezecolumntitles_gridusuario.Caption, true);
         chkavFreezecolumntitles_gridusuario.CheckedValue = "false";
         AV32FreezeColumnTitles_GridUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( AV32FreezeColumnTitles_GridUsuario));
         AssignAttri("", false, "AV32FreezeColumnTitles_GridUsuario", AV32FreezeColumnTitles_GridUsuario);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavGenericfilter_gridusuario_Internalname = "vGENERICFILTER_GRIDUSUARIO";
         imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRIDUSUARIO";
         Filtertagsusercontrol_gridusuario_Internalname = "FILTERTAGSUSERCONTROL_GRIDUSUARIO";
         divLayoutdefined_section4_gridusuario_Internalname = "LAYOUTDEFINED_SECTION4_GRIDUSUARIO";
         imgLayoutdefined_filterclose_combined_gridusuario_Internalname = "LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRIDUSUARIO";
         edtavUsuarionombre_filter_Internalname = "vUSUARIONOMBRE_FILTER";
         divTable_container_usuarionombre_filter_Internalname = "TABLE_CONTAINER_USUARIONOMBRE_FILTER";
         edtavEstadoticketusuarionombre_filter_Internalname = "vESTADOTICKETUSUARIONOMBRE_FILTER";
         divTable_container_estadoticketusuarionombre_filter_Internalname = "TABLE_CONTAINER_ESTADOTICKETUSUARIONOMBRE_FILTER";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO";
         divLayoutdefined_combinedfilterlayout_gridusuario_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRIDUSUARIO";
         divLayoutdefined_filterglobalcontainer_gridusuario_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRIDUSUARIO";
         imgGridsettings_labelgridusuario_Internalname = "GRIDSETTINGS_LABELGRIDUSUARIO";
         lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDUSUARIORUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_gridusuario_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRIDUSUARIO";
         divRowsperpagecontainer_gridusuario_Internalname = "ROWSPERPAGECONTAINER_GRIDUSUARIO";
         chkavFreezecolumntitles_gridusuario_Internalname = "vFREEZECOLUMNTITLES_GRIDUSUARIO";
         divFreezecolumntitlescontainer_gridusuario_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRIDUSUARIO";
         bttGridsettings_savegridusuario_Internalname = "GRIDSETTINGS_SAVEGRIDUSUARIO";
         divGslayoutdefined_gridusuariocustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDUSUARIOCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_gridusuario_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRIDUSUARIO";
         divGslayoutdefined_gridusuariocontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDUSUARIOCONTENTINNERTABLE";
         divGridsettings_contentoutertablegridusuario_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO";
         divGridsettings_globaltable_gridusuario_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRIDUSUARIO";
         tblLayoutdefined_table7_gridusuario_Internalname = "LAYOUTDEFINED_TABLE7_GRIDUSUARIO";
         divLayoutdefined_table10_gridusuario_Internalname = "LAYOUTDEFINED_TABLE10_GRIDUSUARIO";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtTicketId_Internalname = "TICKETID";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtUsuarioHora_Internalname = "USUARIOHORA";
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO";
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID";
         edtEstadoTicketUsuarioNombre_Internalname = "ESTADOTICKETUSUARIONOMBRE";
         edtTicketUsuarioAsigno_Internalname = "TICKETUSUARIOASIGNO";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE";
         Orderbyuc_gridusuario_Internalname = "ORDERBYUC_GRIDUSUARIO";
         tblTablegridcontainer_gridusuario_Internalname = "TABLEGRIDCONTAINER_GRIDUSUARIO";
         lblI_noresultsfoundtextblock_gridusuario_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRIDUSUARIO";
         tblI_noresultsfoundtablename_gridusuario_Internalname = "I_NORESULTSFOUNDTABLENAME_GRIDUSUARIO";
         divMaingrid_responsivetable_gridusuario_Internalname = "MAINGRID_RESPONSIVETABLE_GRIDUSUARIO";
         lblPaginationbar_previouspagebuttontextblockgridusuario_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_firstpagetextblockgridusuario_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_spacinglefttextblockgridusuario_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_previouspagetextblockgridusuario_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_currentpagetextblockgridusuario_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_nextpagetextblockgridusuario_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_spacingrighttextblockgridusuario_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_lastpagetextblockgridusuario_Internalname = "PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO";
         lblPaginationbar_nextpagebuttontextblockgridusuario_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO";
         divPaginationbar_pagingcontainertable_gridusuario_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO";
         divLayoutdefined_section8_gridusuario_Internalname = "LAYOUTDEFINED_SECTION8_GRIDUSUARIO";
         divLayoutdefined_table3_gridusuario_Internalname = "LAYOUTDEFINED_TABLE3_GRIDUSUARIO";
         divLayoutdefined_grid_inner_gridusuario_Internalname = "LAYOUTDEFINED_GRID_INNER_GRIDUSUARIO";
         divGridcomponentcontent_gridusuario_Internalname = "GRIDCOMPONENTCONTENT_GRIDUSUARIO";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridusuario_Internalname = "GRIDUSUARIO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavFreezecolumntitles_gridusuario.Caption = "Inmovilizar t�tulos";
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketUsuarioAsigno_Jsonclick = "";
         edtEstadoTicketUsuarioNombre_Jsonclick = "";
         edtEstadoTicketUsuarioId_Jsonclick = "";
         edtUsuarioTelefono_Jsonclick = "";
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioGerencia_Jsonclick = "";
         edtUsuarioHora_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         chkavFreezecolumntitles_gridusuario.Enabled = 1;
         cmbavGridsettingsrowsperpage_gridusuario_Jsonclick = "";
         cmbavGridsettingsrowsperpage_gridusuario.Enabled = 1;
         divGridsettings_contentoutertablegridusuario_Visible = 1;
         subGridusuario_Allowcollapsing = 0;
         subGridusuario_Allowselection = 0;
         subGridusuario_Header = "";
         subGridusuario_Class = "K2BT_SG Grid_WorkWith";
         subGridusuario_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_gridusuario_Visible = 1;
         subGridusuario_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_lastpagetextblockgridusuario_Caption = "1";
         lblPaginationbar_lastpagetextblockgridusuario_Visible = 1;
         lblPaginationbar_spacingrighttextblockgridusuario_Visible = 1;
         lblPaginationbar_nextpagetextblockgridusuario_Caption = "#";
         lblPaginationbar_nextpagetextblockgridusuario_Visible = 1;
         lblPaginationbar_currentpagetextblockgridusuario_Caption = "#";
         lblPaginationbar_previouspagetextblockgridusuario_Caption = "#";
         lblPaginationbar_previouspagetextblockgridusuario_Visible = 1;
         lblPaginationbar_spacinglefttextblockgridusuario_Visible = 1;
         lblPaginationbar_firstpagetextblockgridusuario_Caption = "1";
         lblPaginationbar_firstpagetextblockgridusuario_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgridusuario_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_gridusuario_Visible = 1;
         divMaingrid_responsivetable_gridusuario_Class = "Section_Grid";
         edtavEstadoticketusuarionombre_filter_Jsonclick = "";
         edtavEstadoticketusuarionombre_filter_Enabled = 1;
         edtavUsuarionombre_filter_Jsonclick = "";
         edtavUsuarionombre_filter_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible = 1;
         imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_gridusuario_Jsonclick = "";
         edtavGenericfilter_gridusuario_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPLista Ticket Asignados";
         subGridusuario_Rows = 20;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridusuario_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDUSUARIO',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("ORDERBYUC_GRIDUSUARIO.ORDERBYCHANGED","{handler:'E126V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV29SelectedOrderBy_GridUsuario',fld:'vSELECTEDORDERBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("ORDERBYUC_GRIDUSUARIO.ORDERBYCHANGED",",oparms:[{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridusuario_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDUSUARIO',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("GRIDUSUARIO.LOAD","{handler:'E226V2',iparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("GRIDUSUARIO.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_gridusuario_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("GRIDUSUARIO.REFRESH","{handler:'E236V2',iparms:[{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("GRIDUSUARIO.REFRESH",",oparms:[{av:'tblI_noresultsfoundtablename_gridusuario_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDUSUARIO',prop:'Visible'},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'subGridusuario_Backcolorstyle',ctrl:'GRIDUSUARIO',prop:'Backcolorstyle'},{av:'AV29SelectedOrderBy_GridUsuario',fld:'vSELECTEDORDERBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridusuario_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDUSUARIO',prop:'Class'},{av:'Filtertagsusercontrol_gridusuario_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRIDUSUARIO',prop:'EmptyStateMessage'},{av:'AV19FilterTagsCollection_GridUsuario',fld:'vFILTERTAGSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridusuario_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(GRIDUSUARIO)'","{handler:'E136V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRIDUSUARIO)'",",oparms:[{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridusuario_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRIDUSUARIO)'","{handler:'E146V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRIDUSUARIO)'",",oparms:[{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridusuario_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRIDUSUARIO)'","{handler:'E156V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRIDUSUARIO)'",",oparms:[{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridusuario_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'PAGINGLAST(GRIDUSUARIO)'","{handler:'E166V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'PAGINGLAST(GRIDUSUARIO)'",",oparms:[{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Caption',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridusuario_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDUSUARIO',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_lastpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_LASTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridusuario_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDUSUARIO',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridusuario_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDUSUARIO)'","{handler:'E246V1',iparms:[{av:'divGridsettings_contentoutertablegridusuario_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDUSUARIO)'",",oparms:[{av:'divGridsettings_contentoutertablegridusuario_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDUSUARIO)'","{handler:'E176V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpage_gridusuario'},{av:'AV26GridSettingsRowsPerPage_GridUsuario',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV24RowsPerPage_GridUsuario',fld:'vROWSPERPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDUSUARIO)'",",oparms:[{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV24RowsPerPage_GridUsuario',fld:'vROWSPERPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridusuario_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDUSUARIO',prop:'Visible'},{av:'divMaingrid_responsivetable_gridusuario_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDUSUARIO',prop:'Class'},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("FILTERTAGSUSERCONTROL_GRIDUSUARIO.TAGDELETED","{handler:'E116V2',iparms:[{av:'GRIDUSUARIO_nFirstRecordOnPage'},{av:'GRIDUSUARIO_nEOF'},{av:'subGridusuario_Rows',ctrl:'GRIDUSUARIO',prop:'Rows'},{av:'AV28GenericFilter_GridUsuario',fld:'vGENERICFILTER_GRIDUSUARIO',pic:''},{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV21OrderedBy_GridUsuario',fld:'vORDEREDBY_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'AV20DeletedTag_GridUsuario',fld:'vDELETEDTAG_GRIDUSUARIO',pic:''},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("FILTERTAGSUSERCONTROL_GRIDUSUARIO.TAGDELETED",",oparms:[{av:'AV33UsuarioNombre_Filter',fld:'vUSUARIONOMBRE_FILTER',pic:''},{av:'AV34EstadoTicketUsuarioNombre_Filter',fld:'vESTADOTICKETUSUARIONOMBRE_FILTER',pic:''},{av:'AV18CurrentPage_GridUsuario',fld:'vCURRENTPAGE_GRIDUSUARIO',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridusuario_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDUSUARIO',prop:'Class'},{av:'AV17GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV22ClassCollection_GridUsuario',fld:'vCLASSCOLLECTION_GRIDUSUARIO',pic:''},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRIDUSUARIO.CLICK","{handler:'E186V2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRIDUSUARIO.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRIDUSUARIO.CLICK","{handler:'E196V2',iparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_GRIDUSUARIO.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRIDUSUARIO',prop:'Visible'},{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID","{handler:'Valid_Estadoticketusuarioid',iparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID",",oparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Tickettecnicoresponsablenombre',iparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV32FreezeColumnTitles_GridUsuario',fld:'vFREEZECOLUMNTITLES_GRIDUSUARIO',pic:''}]}");
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
         AV28GenericFilter_GridUsuario = "";
         AV33UsuarioNombre_Filter = "";
         AV34EstadoTicketUsuarioNombre_Filter = "";
         AV22ClassCollection_GridUsuario = new GxSimpleCollection<string>();
         AV40Pgmname = "";
         AV17GridConfiguration = new SdtK2BGridConfiguration(context);
         Filtertagsusercontrol_gridusuario_Emptystatemessage = "";
         Orderbyuc_gridusuario_Gridcontrolname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV19FilterTagsCollection_GridUsuario = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV20DeletedTag_GridUsuario = "";
         AV30GridOrders_GridUsuario = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_gridusuario_Jsonclick = "";
         ucFiltertagsusercontrol_gridusuario = new GXUserControl();
         imgLayoutdefined_filterclose_combined_gridusuario_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockgridusuario_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgridusuario_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgridusuario_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgridusuario_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgridusuario_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgridusuario_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgridusuario_Jsonclick = "";
         lblPaginationbar_lastpagetextblockgridusuario_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgridusuario_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         GridusuarioContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         A190EstadoTicketUsuarioNombre = "";
         A278TicketUsuarioAsigno = "";
         A199TicketTecnicoResponsableNombre = "";
         scmdbuf = "";
         lV33UsuarioNombre_Filter = "";
         lV34EstadoTicketUsuarioNombre_Filter = "";
         H006V2_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         H006V2_A189EstadoTicketUsuarioId = new short[1] ;
         H006V2_A95UsuarioTelefono = new int[1] ;
         H006V2_A89UsuarioEmail = new string[] {""} ;
         H006V2_A94UsuarioRequerimiento = new string[] {""} ;
         H006V2_A88UsuarioDepartamento = new string[] {""} ;
         H006V2_A91UsuarioGerencia = new string[] {""} ;
         H006V2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         H006V2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H006V2_A93UsuarioNombre = new string[] {""} ;
         H006V2_A15UsuarioId = new short[1] ;
         H006V3_AGRIDUSUARIO_nRecordCount = new long[1] ;
         ucOrderbyuc_gridusuario = new GXUserControl();
         AV31GridOrder_GridUsuario = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV36TicketUsuarioAsigno = "";
         AV35WebSession = context.GetSession();
         AV37horaenter = "";
         GridusuarioRow = new GXWebRow();
         GXt_char1 = "";
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV15K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV16K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblI_noresultsfoundtextblock_gridusuario_Jsonclick = "";
         subGridusuario_Linesclass = "";
         GridusuarioColumn = new GXWebColumn();
         imgGridsettings_labelgridusuario_Jsonclick = "";
         lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegridusuario_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistaticketasignados__default(),
            new Object[][] {
                new Object[] {
               H006V2_A190EstadoTicketUsuarioNombre, H006V2_A189EstadoTicketUsuarioId, H006V2_A95UsuarioTelefono, H006V2_A89UsuarioEmail, H006V2_A94UsuarioRequerimiento, H006V2_A88UsuarioDepartamento, H006V2_A91UsuarioGerencia, H006V2_A92UsuarioHora, H006V2_A90UsuarioFecha, H006V2_A93UsuarioNombre,
               H006V2_A15UsuarioId
               }
               , new Object[] {
               H006V3_AGRIDUSUARIO_nRecordCount
               }
            }
         );
         AV40Pgmname = "WPListaTicketAsignados";
         /* GeneXus formulas. */
         AV40Pgmname = "WPListaTicketAsignados";
         context.Gx_err = 0;
      }

      private short GRIDUSUARIO_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV21OrderedBy_GridUsuario ;
      private short AV18CurrentPage_GridUsuario ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV29SelectedOrderBy_GridUsuario ;
      private short AV24RowsPerPage_GridUsuario ;
      private short wbEnd ;
      private short wbStart ;
      private short A15UsuarioId ;
      private short A189EstadoTicketUsuarioId ;
      private short A198TicketTecnicoResponsableId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV26GridSettingsRowsPerPage_GridUsuario ;
      private short subGridusuario_Backcolorstyle ;
      private short subGridusuario_Sortable ;
      private short AV27PageCount_GridUsuario ;
      private short subGridusuario_Titlebackstyle ;
      private short subGridusuario_Allowselection ;
      private short subGridusuario_Allowhovering ;
      private short subGridusuario_Allowcollapsing ;
      private short subGridusuario_Collapsed ;
      private short nGXWrapped ;
      private short subGridusuario_Backstyle ;
      private int divGridsettings_contentoutertablegridusuario_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Visible ;
      private int nRC_GXsfl_100 ;
      private int nGXsfl_100_idx=1 ;
      private int subGridusuario_Rows ;
      private int edtavGenericfilter_gridusuario_Enabled ;
      private int edtavUsuarionombre_filter_Enabled ;
      private int edtavEstadoticketusuarionombre_filter_Enabled ;
      private int divPaginationbar_pagingcontainertable_gridusuario_Visible ;
      private int lblPaginationbar_firstpagetextblockgridusuario_Visible ;
      private int lblPaginationbar_spacinglefttextblockgridusuario_Visible ;
      private int lblPaginationbar_previouspagetextblockgridusuario_Visible ;
      private int lblPaginationbar_nextpagetextblockgridusuario_Visible ;
      private int lblPaginationbar_spacingrighttextblockgridusuario_Visible ;
      private int lblPaginationbar_lastpagetextblockgridusuario_Visible ;
      private int A95UsuarioTelefono ;
      private int subGridusuario_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int tblI_noresultsfoundtablename_gridusuario_Visible ;
      private int AV41GXV1 ;
      private int subGridusuario_Titlebackcolor ;
      private int subGridusuario_Allbackcolor ;
      private int subGridusuario_Selectedindex ;
      private int subGridusuario_Selectioncolor ;
      private int subGridusuario_Hoveringcolor ;
      private int idxLst ;
      private int subGridusuario_Backcolor ;
      private long GRIDUSUARIO_nFirstRecordOnPage ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long GRIDUSUARIO_nCurrentRecord ;
      private long GRIDUSUARIO_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_100_idx="0001" ;
      private string AV28GenericFilter_GridUsuario ;
      private string AV40Pgmname ;
      private string Filtertagsusercontrol_gridusuario_Emptystatemessage ;
      private string Orderbyuc_gridusuario_Gridcontrolname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV20DeletedTag_GridUsuario ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_gridusuario_Internalname ;
      private string divLayoutdefined_grid_inner_gridusuario_Internalname ;
      private string divLayoutdefined_table10_gridusuario_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_gridusuario_Internalname ;
      private string divLayoutdefined_combinedfilterlayout_gridusuario_Internalname ;
      private string divLayoutdefined_section4_gridusuario_Internalname ;
      private string edtavGenericfilter_gridusuario_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_gridusuario_Jsonclick ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_combined_gridusuario_Internalname ;
      private string imgLayoutdefined_filtertoggle_combined_gridusuario_Jsonclick ;
      private string Filtertagsusercontrol_gridusuario_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_combined_gridusuario_Internalname ;
      private string imgLayoutdefined_filterclose_combined_gridusuario_Internalname ;
      private string imgLayoutdefined_filterclose_combined_gridusuario_Jsonclick ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_usuarionombre_filter_Internalname ;
      private string edtavUsuarionombre_filter_Internalname ;
      private string edtavUsuarionombre_filter_Jsonclick ;
      private string divTable_container_estadoticketusuarionombre_filter_Internalname ;
      private string edtavEstadoticketusuarionombre_filter_Internalname ;
      private string edtavEstadoticketusuarionombre_filter_Jsonclick ;
      private string divLayoutdefined_table3_gridusuario_Internalname ;
      private string divMaingrid_responsivetable_gridusuario_Internalname ;
      private string divMaingrid_responsivetable_gridusuario_Class ;
      private string divLayoutdefined_section8_gridusuario_Internalname ;
      private string divPaginationbar_pagingcontainertable_gridusuario_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridusuario_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgridusuario_Class ;
      private string lblPaginationbar_firstpagetextblockgridusuario_Internalname ;
      private string lblPaginationbar_firstpagetextblockgridusuario_Caption ;
      private string lblPaginationbar_firstpagetextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgridusuario_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgridusuario_Internalname ;
      private string lblPaginationbar_previouspagetextblockgridusuario_Caption ;
      private string lblPaginationbar_previouspagetextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgridusuario_Internalname ;
      private string lblPaginationbar_currentpagetextblockgridusuario_Caption ;
      private string lblPaginationbar_currentpagetextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgridusuario_Internalname ;
      private string lblPaginationbar_nextpagetextblockgridusuario_Caption ;
      private string lblPaginationbar_nextpagetextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgridusuario_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_lastpagetextblockgridusuario_Internalname ;
      private string lblPaginationbar_lastpagetextblockgridusuario_Caption ;
      private string lblPaginationbar_lastpagetextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridusuario_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgridusuario_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridusuario_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioHora_Internalname ;
      private string edtUsuarioGerencia_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioTelefono_Internalname ;
      private string edtEstadoTicketUsuarioId_Internalname ;
      private string edtEstadoTicketUsuarioNombre_Internalname ;
      private string edtTicketUsuarioAsigno_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string cmbavGridsettingsrowsperpage_gridusuario_Internalname ;
      private string scmdbuf ;
      private string chkavFreezecolumntitles_gridusuario_Internalname ;
      private string subGridusuario_Internalname ;
      private string Orderbyuc_gridusuario_Internalname ;
      private string divGridsettings_contentoutertablegridusuario_Internalname ;
      private string AV37horaenter ;
      private string tblI_noresultsfoundtablename_gridusuario_Internalname ;
      private string GXt_char1 ;
      private string lblI_noresultsfoundtextblock_gridusuario_Internalname ;
      private string lblI_noresultsfoundtextblock_gridusuario_Jsonclick ;
      private string tblTablegridcontainer_gridusuario_Internalname ;
      private string subGridusuario_Class ;
      private string subGridusuario_Linesclass ;
      private string subGridusuario_Header ;
      private string tblLayoutdefined_table7_gridusuario_Internalname ;
      private string divGridsettings_globaltable_gridusuario_Internalname ;
      private string imgGridsettings_labelgridusuario_Internalname ;
      private string imgGridsettings_labelgridusuario_Jsonclick ;
      private string divGslayoutdefined_gridusuariocontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_gridusuario_Internalname ;
      private string lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridusuarioruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridusuariocustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_gridusuario_Internalname ;
      private string cmbavGridsettingsrowsperpage_gridusuario_Jsonclick ;
      private string divFreezecolumntitlescontainer_gridusuario_Internalname ;
      private string bttGridsettings_savegridusuario_Internalname ;
      private string bttGridsettings_savegridusuario_Jsonclick ;
      private string sGXsfl_100_fel_idx="0001" ;
      private string ROClassString ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtUsuarioHora_Jsonclick ;
      private string edtUsuarioGerencia_Jsonclick ;
      private string edtUsuarioDepartamento_Jsonclick ;
      private string edtUsuarioRequerimiento_Jsonclick ;
      private string edtUsuarioEmail_Jsonclick ;
      private string edtUsuarioTelefono_Jsonclick ;
      private string edtEstadoTicketUsuarioId_Jsonclick ;
      private string edtEstadoTicketUsuarioNombre_Jsonclick ;
      private string edtTicketUsuarioAsigno_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private DateTime A92UsuarioHora ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV32FreezeColumnTitles_GridUsuario ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_100_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool gx_refresh_fired ;
      private bool returnInSub ;
      private bool AV25RowsPerPageLoaded_GridUsuario ;
      private string AV33UsuarioNombre_Filter ;
      private string AV34EstadoTicketUsuarioNombre_Filter ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private string A190EstadoTicketUsuarioNombre ;
      private string A278TicketUsuarioAsigno ;
      private string A199TicketTecnicoResponsableNombre ;
      private string lV33UsuarioNombre_Filter ;
      private string lV34EstadoTicketUsuarioNombre_Filter ;
      private string AV36TicketUsuarioAsigno ;
      private string AV12GridStateKey ;
      private string imgLayoutdefined_filtertoggle_combined_gridusuario_Bitmap ;
      private IGxSession AV35WebSession ;
      private GXWebGrid GridusuarioContainer ;
      private GXWebRow GridusuarioRow ;
      private GXWebColumn GridusuarioColumn ;
      private GXUserControl ucFiltertagsusercontrol_gridusuario ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucOrderbyuc_gridusuario ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_gridusuario ;
      private GXCheckbox chkavFreezecolumntitles_gridusuario ;
      private IDataStoreProvider pr_default ;
      private string[] H006V2_A190EstadoTicketUsuarioNombre ;
      private short[] H006V2_A189EstadoTicketUsuarioId ;
      private int[] H006V2_A95UsuarioTelefono ;
      private string[] H006V2_A89UsuarioEmail ;
      private string[] H006V2_A94UsuarioRequerimiento ;
      private string[] H006V2_A88UsuarioDepartamento ;
      private string[] H006V2_A91UsuarioGerencia ;
      private DateTime[] H006V2_A92UsuarioHora ;
      private DateTime[] H006V2_A90UsuarioFecha ;
      private string[] H006V2_A93UsuarioNombre ;
      private short[] H006V2_A15UsuarioId ;
      private long[] H006V3_AGRIDUSUARIO_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV22ClassCollection_GridUsuario ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV19FilterTagsCollection_GridUsuario ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item2 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV30GridOrders_GridUsuario ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV15K2BFilterValuesSDT_WebForm ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV17GridConfiguration ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV31GridOrder_GridUsuario ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV16K2BFilterValuesSDTItem_WebForm ;
   }

   public class wplistaticketasignados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006V2( IGxContext context ,
                                             string AV33UsuarioNombre_Filter ,
                                             string AV34EstadoTicketUsuarioNombre_Filter ,
                                             string AV28GenericFilter_GridUsuario ,
                                             string A93UsuarioNombre ,
                                             string A190EstadoTicketUsuarioNombre ,
                                             short A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             short AV21OrderedBy_GridUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[EstadoTicketNombre] AS EstadoTicketUsuarioNombre, T1.[EstadoTicketUsuarioId] AS EstadoTicketUsuarioId, T1.[UsuarioTelefono], T1.[UsuarioEmail], T1.[UsuarioRequerimiento], T1.[UsuarioDepartamento], T1.[UsuarioGerencia], T1.[UsuarioHora], T1.[UsuarioFecha], T1.[UsuarioNombre], T1.[UsuarioId]";
         sFromString = " FROM ([Usuario] T1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = T1.[EstadoTicketUsuarioId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33UsuarioNombre_Filter)) )
         {
            AddWhere(sWhereString, "(T1.[UsuarioNombre] like @lV33UsuarioNombre_Filter)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34EstadoTicketUsuarioNombre_Filter)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoTicketNombre] like @lV34EstadoTicketUsuarioNombre_Filter)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV21OrderedBy_GridUsuario == 0 )
         {
            sOrderString += " ORDER BY T1.[UsuarioId]";
         }
         else if ( AV21OrderedBy_GridUsuario == 1 )
         {
            sOrderString += " ORDER BY T1.[UsuarioId] DESC";
         }
         else if ( AV21OrderedBy_GridUsuario == 2 )
         {
            sOrderString += " ORDER BY T1.[UsuarioNombre]";
         }
         else if ( AV21OrderedBy_GridUsuario == 3 )
         {
            sOrderString += " ORDER BY T1.[UsuarioNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[UsuarioId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H006V3( IGxContext context ,
                                             string AV33UsuarioNombre_Filter ,
                                             string AV34EstadoTicketUsuarioNombre_Filter ,
                                             string AV28GenericFilter_GridUsuario ,
                                             string A93UsuarioNombre ,
                                             string A190EstadoTicketUsuarioNombre ,
                                             short A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             short AV21OrderedBy_GridUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Usuario] T1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = T1.[EstadoTicketUsuarioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33UsuarioNombre_Filter)) )
         {
            AddWhere(sWhereString, "(T1.[UsuarioNombre] like @lV33UsuarioNombre_Filter)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34EstadoTicketUsuarioNombre_Filter)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoTicketNombre] like @lV34EstadoTicketUsuarioNombre_Filter)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV21OrderedBy_GridUsuario == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV21OrderedBy_GridUsuario == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV21OrderedBy_GridUsuario == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV21OrderedBy_GridUsuario == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
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
                     return conditional_H006V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H006V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH006V2;
          prmH006V2 = new Object[] {
          new ParDef("@lV33UsuarioNombre_Filter",GXType.NVarChar,60,0) ,
          new ParDef("@lV34EstadoTicketUsuarioNombre_Filter",GXType.NVarChar,30,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006V3;
          prmH006V3 = new Object[] {
          new ParDef("@lV33UsuarioNombre_Filter",GXType.NVarChar,60,0) ,
          new ParDef("@lV34EstadoTicketUsuarioNombre_Filter",GXType.NVarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006V2,21, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006V3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
