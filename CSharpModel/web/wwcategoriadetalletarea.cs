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
   public class wwcategoriadetalletarea : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwcategoriadetalletarea( )
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

      public wwcategoriadetalletarea( IGxContext context )
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
         chkavAtt_categoriadetalletareaid_visible = new GXCheckbox();
         chkavAtt_categoriadetalletareanombre_visible = new GXCheckbox();
         chkavAtt_id_actividad_categoria_visible = new GXCheckbox();
         chkavAtt_nombre_actividad_visible = new GXCheckbox();
         chkavAtt_categoriadetalleusuarioregistro_visible = new GXCheckbox();
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
               nRC_GXsfl_122 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_122"), "."));
               nGXsfl_122_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_122_idx"), "."));
               sGXsfl_122_idx = GetPar( "sGXsfl_122_idx");
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
               AV26K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV25ClassCollection);
               AV27OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               AV45Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV33CategoriaDetalleTareaNombre_IsAuthorized = StringUtil.StrToBool( GetPar( "CategoriaDetalleTareaNombre_IsAuthorized"));
               AV14Att_CategoriaDetalleTareaId_Visible = StringUtil.StrToBool( GetPar( "Att_CategoriaDetalleTareaId_Visible"));
               AV15Att_CategoriaDetalleTareaNombre_Visible = StringUtil.StrToBool( GetPar( "Att_CategoriaDetalleTareaNombre_Visible"));
               AV16Att_id_actividad_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_id_actividad_categoria_Visible"));
               AV17Att_nombre_actividad_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_actividad_Visible"));
               AV18Att_CategoriaDetalleUsuarioRegistro_Visible = StringUtil.StrToBool( GetPar( "Att_CategoriaDetalleUsuarioRegistro_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV42Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
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
            return "categoriadetalletarea_Execute" ;
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
         PA7H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7H2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188215436", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwcategoriadetalletarea.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV26K2BToolsGenericSearchField));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_122", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_122), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV28GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV28GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV25ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV25ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED", AV33CategoriaDetalleTareaNombre_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV42Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
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
            WE7H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7H2( ) ;
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
         return formatLink("wwcategoriadetalletarea.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWCategoriaDetalleTarea" ;
      }

      public override string GetPgmdesc( )
      {
         return "Categoria detalle tareas" ;
      }

      protected void WB7H0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Categoria detalle tareas", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_122_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV26K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV26K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWCategoriaDetalleTarea.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_24_7H2( true) ;
         }
         else
         {
            wb_table1_24_7H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_7H2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"122\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(38), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtCategoriaDetalleTareaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtCategoriaDetalleTareaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_actividad_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id. ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_actividad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Actividad Categoría") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtCategoriaDetalleUsuarioRegistro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario Registro") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A294CategoriaDetalleTareaId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaDetalleTareaId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A295CategoriaDetalleTareaNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCategoriaDetalleTareaNombre_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaDetalleTareaNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_actividad_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A123nombre_actividad);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_actividad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A296CategoriaDetalleUsuarioRegistro);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaDetalleUsuarioRegistro_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV34Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV35Delete));
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
         if ( wbEnd == 122 )
         {
            wbEnd = 0;
            nRC_GXsfl_122 = (int)(nGXsfl_122_idx-1);
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
            wb_table2_132_7H2( true) ;
         }
         else
         {
            wb_table2_132_7H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_132_7H2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV28GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV30UC_OrderedBy);
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
         if ( wbEnd == 122 )
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

      protected void START7H2( )
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
            Form.Meta.addItem("description", "Categoria detalle tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7H0( ) ;
      }

      protected void WS7H2( )
      {
         START7H2( ) ;
         EVT7H2( ) ;
      }

      protected void EVT7H2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E117H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E127H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E137H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E147H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E157H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E167H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E177H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E187H2 ();
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
                              nGXsfl_122_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
                              SubsflControlProps_1222( ) ;
                              A294CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( edtCategoriaDetalleTareaId_Internalname), ".", ","));
                              A295CategoriaDetalleTareaNombre = cgiGet( edtCategoriaDetalleTareaNombre_Internalname);
                              A102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ".", ","));
                              A123nombre_actividad = cgiGet( edtnombre_actividad_Internalname);
                              n123nombre_actividad = false;
                              A296CategoriaDetalleUsuarioRegistro = cgiGet( edtCategoriaDetalleUsuarioRegistro_Internalname);
                              AV34Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.convertURL( context.PathToRelativeUrl( AV34Update))), !bGXsfl_122_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV34Update), true);
                              AV35Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV35Delete))), !bGXsfl_122_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV35Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E197H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E207H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E217H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E227H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV26K2BToolsGenericSearchField) != 0 )
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

      protected void WE7H2( )
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

      protected void PA7H2( )
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
         SubsflControlProps_1222( ) ;
         while ( nGXsfl_122_idx <= nRC_GXsfl_122 )
         {
            sendrow_1222( ) ;
            nGXsfl_122_idx = ((subGrid_Islastpage==1)&&(nGXsfl_122_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_122_idx+1);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_1222( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV26K2BToolsGenericSearchField ,
                                       GxSimpleCollection<string> AV25ClassCollection ,
                                       short AV27OrderedBy ,
                                       int AV8CurrentPage ,
                                       string AV45Pgmname ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV33CategoriaDetalleTareaNombre_IsAuthorized ,
                                       bool AV14Att_CategoriaDetalleTareaId_Visible ,
                                       bool AV15Att_CategoriaDetalleTareaNombre_Visible ,
                                       bool AV16Att_id_actividad_categoria_Visible ,
                                       bool AV17Att_nombre_actividad_Visible ,
                                       bool AV18Att_CategoriaDetalleUsuarioRegistro_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV42Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E207H2 ();
         GRID_nCurrentRecord = 0;
         RF7H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIADETALLETAREAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A294CategoriaDetalleTareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CATEGORIADETALLETAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A294CategoriaDetalleTareaId), 4, 0, ".", "")));
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
         AV14Att_CategoriaDetalleTareaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_CategoriaDetalleTareaId_Visible));
         AssignAttri("", false, "AV14Att_CategoriaDetalleTareaId_Visible", AV14Att_CategoriaDetalleTareaId_Visible);
         AV15Att_CategoriaDetalleTareaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_CategoriaDetalleTareaNombre_Visible));
         AssignAttri("", false, "AV15Att_CategoriaDetalleTareaNombre_Visible", AV15Att_CategoriaDetalleTareaNombre_Visible);
         AV16Att_id_actividad_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_id_actividad_categoria_Visible));
         AssignAttri("", false, "AV16Att_id_actividad_categoria_Visible", AV16Att_id_actividad_categoria_Visible);
         AV17Att_nombre_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_nombre_actividad_Visible));
         AssignAttri("", false, "AV17Att_nombre_actividad_Visible", AV17Att_nombre_actividad_Visible);
         AV18Att_CategoriaDetalleUsuarioRegistro_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_CategoriaDetalleUsuarioRegistro_Visible));
         AssignAttri("", false, "AV18Att_CategoriaDetalleUsuarioRegistro_Visible", AV18Att_CategoriaDetalleUsuarioRegistro_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV19GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E207H2 ();
         RF7H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV45Pgmname = "WWCategoriaDetalleTarea";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV27OrderedBy ,
                                              AV26K2BToolsGenericSearchField ,
                                              A294CategoriaDetalleTareaId ,
                                              A295CategoriaDetalleTareaNombre ,
                                              A102id_actividad_categoria ,
                                              A123nombre_actividad ,
                                              A296CategoriaDetalleUsuarioRegistro } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H007H2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A296CategoriaDetalleUsuarioRegistro = H007H2_A296CategoriaDetalleUsuarioRegistro[0];
            A102id_actividad_categoria = H007H2_A102id_actividad_categoria[0];
            A295CategoriaDetalleTareaNombre = H007H2_A295CategoriaDetalleTareaNombre[0];
            A294CategoriaDetalleTareaId = H007H2_A294CategoriaDetalleTareaId[0];
            /* Using cursor H007H3 */
            pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
            A123nombre_actividad = H007H3_A123nombre_actividad[0];
            n123nombre_actividad = H007H3_n123nombre_actividad[0];
            pr_datastore1.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A294CategoriaDetalleTareaId), 4, 0) , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A295CategoriaDetalleTareaNombre , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A102id_actividad_categoria), 9, 0) , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A123nombre_actividad , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 200 , "%"),  ' ' ) || StringUtil.Like( A296CategoriaDetalleUsuarioRegistro , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) ) )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         pr_datastore1.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF7H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 122;
         E217H2 ();
         nGXsfl_122_idx = 1;
         sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
         SubsflControlProps_1222( ) ;
         bGXsfl_122_Refreshing = true;
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
            SubsflControlProps_1222( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV27OrderedBy ,
                                                 AV26K2BToolsGenericSearchField ,
                                                 A294CategoriaDetalleTareaId ,
                                                 A295CategoriaDetalleTareaNombre ,
                                                 A102id_actividad_categoria ,
                                                 A123nombre_actividad ,
                                                 A296CategoriaDetalleUsuarioRegistro } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H007H4 */
            pr_default.execute(1);
            nGXsfl_122_idx = 1;
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_1222( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A296CategoriaDetalleUsuarioRegistro = H007H4_A296CategoriaDetalleUsuarioRegistro[0];
               A102id_actividad_categoria = H007H4_A102id_actividad_categoria[0];
               A295CategoriaDetalleTareaNombre = H007H4_A295CategoriaDetalleTareaNombre[0];
               A294CategoriaDetalleTareaId = H007H4_A294CategoriaDetalleTareaId[0];
               /* Using cursor H007H5 */
               pr_datastore1.execute(1, new Object[] {A102id_actividad_categoria});
               A123nombre_actividad = H007H5_A123nombre_actividad[0];
               n123nombre_actividad = H007H5_n123nombre_actividad[0];
               pr_datastore1.close(1);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A294CategoriaDetalleTareaId), 4, 0) , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A295CategoriaDetalleTareaNombre , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A102id_actividad_categoria), 9, 0) , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A123nombre_actividad , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 200 , "%"),  ' ' ) || StringUtil.Like( A296CategoriaDetalleUsuarioRegistro , StringUtil.PadR( "%" + AV26K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) ) )
               {
                  E227H2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            pr_datastore1.close(1);
            wbEnd = 122;
            WB7H0( ) ;
         }
         bGXsfl_122_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7H2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIADETALLETAREAID"+"_"+sGXsfl_122_idx, GetSecureSignedToken( sGXsfl_122_idx, context.localUtil.Format( (decimal)(A294CategoriaDetalleTareaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV42Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Uri, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV45Pgmname = "WWCategoriaDetalleTarea";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E197H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV28GridOrders);
            /* Read saved values. */
            nRC_GXsfl_122 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_122"), ".", ","));
            AV30UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV27OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            /* Read variables values. */
            AV26K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV26K2BToolsGenericSearchField", AV26K2BToolsGenericSearchField);
            AV14Att_CategoriaDetalleTareaId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_categoriadetalletareaid_visible_Internalname));
            AssignAttri("", false, "AV14Att_CategoriaDetalleTareaId_Visible", AV14Att_CategoriaDetalleTareaId_Visible);
            AV15Att_CategoriaDetalleTareaNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_categoriadetalletareanombre_visible_Internalname));
            AssignAttri("", false, "AV15Att_CategoriaDetalleTareaNombre_Visible", AV15Att_CategoriaDetalleTareaNombre_Visible);
            AV16Att_id_actividad_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_actividad_categoria_visible_Internalname));
            AssignAttri("", false, "AV16Att_id_actividad_categoria_Visible", AV16Att_id_actividad_categoria_Visible);
            AV17Att_nombre_actividad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_actividad_visible_Internalname));
            AssignAttri("", false, "AV17Att_nombre_actividad_Visible", AV17Att_nombre_actividad_Visible);
            AV18Att_CategoriaDetalleUsuarioRegistro_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_categoriadetalleusuarioregistro_visible_Internalname));
            AssignAttri("", false, "AV18Att_CategoriaDetalleUsuarioRegistro_Visible", AV18Att_CategoriaDetalleUsuarioRegistro_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV19GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV26K2BToolsGenericSearchField) != 0 )
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
         E197H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E197H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV45Pgmname,  "Grid", out  AV20RowsPerPageVariable, out  AV21RowsPerPageLoaded) ;
         AssignAttri("", false, "AV20RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20RowsPerPageVariable), 4, 0));
         if ( ! AV21RowsPerPageLoaded )
         {
            AV20RowsPerPageVariable = 20;
            AssignAttri("", false, "AV20RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20RowsPerPageVariable), 4, 0));
         }
         AV19GridSettingsRowsPerPageVariable = AV20RowsPerPageVariable;
         AssignAttri("", false, "AV19GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV20RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Categoria detalle tareas";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         K2borderbyusercontrol_Gridcontrolname = subGrid_Internalname;
         ucK2borderbyusercontrol.SendProperty(context, "", false, K2borderbyusercontrol_Internalname, "GridControlName", K2borderbyusercontrol_Gridcontrolname);
         AV28GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV29GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV29GridOrder.gxTpr_Ascendingorder = 0;
         AV29GridOrder.gxTpr_Descendingorder = 1;
         AV29GridOrder.gxTpr_Gridcolumnindex = 1;
         AV28GridOrders.Add(AV29GridOrder, 0);
         AV29GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV29GridOrder.gxTpr_Ascendingorder = 2;
         AV29GridOrder.gxTpr_Descendingorder = 3;
         AV29GridOrder.gxTpr_Gridcolumnindex = 2;
         AV28GridOrders.Add(AV29GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E207H2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV31Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV31Messages = GXt_objcol_SdtMessages_Message1;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV31Messages.Count )
         {
            AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV31Messages.Item(AV46GXV1));
            GX_msglist.addItem(AV32Message.gxTpr_Description);
            AV46GXV1 = (int)(AV46GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV45Pgmname;
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV38ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
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
         AV34Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.convertURL( context.PathToRelativeUrl( AV34Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV34Update), true);
         AV47Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.convertURL( context.PathToRelativeUrl( AV34Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV34Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_122_Refreshing);
         AV35Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV35Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV35Delete), true);
         AV48Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV35Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV35Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_122_Refreshing);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV25ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV22GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV22GridStateKey, out  AV23GridState) ;
         AV27OrderedBy = AV23GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV27OrderedBy", StringUtil.LTrimStr( (decimal)(AV27OrderedBy), 4, 0));
         AV30UC_OrderedBy = AV23GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV30UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV30UC_OrderedBy), 4, 0));
         AV49GXV2 = 1;
         while ( AV49GXV2 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV49GXV2));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV26K2BToolsGenericSearchField = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26K2BToolsGenericSearchField", AV26K2BToolsGenericSearchField);
            }
            AV49GXV2 = (int)(AV49GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV23GridState.gxTpr_Currentpage > 0 ) && ( AV23GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV23GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV22GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV22GridStateKey, out  AV23GridState) ;
         AV23GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV23GridState.gxTpr_Orderedby = AV27OrderedBy;
         AV23GridState.gxTpr_Filtervalues.Clear();
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV24GridStateFilterValue.gxTpr_Value = AV26K2BToolsGenericSearchField;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV45Pgmname,  AV22GridStateKey,  AV23GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV36TrnContext = new SdtK2BTrnContext(context);
         AV36TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV36TrnContext.gxTpr_Returnmode = "Stack";
         AV36TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV36TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV36TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV36TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV36TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV36TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "CategoriaDetalleTarea",  AV36TrnContext) ;
      }

      protected void E127H2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "CategoriaDetalleTarea",  "CategoriaDetalleTarea",  "Insert",  "",  "EntityManagerCategoriaDetalleTarea") )
         {
            CallWebObject(formatLink("entitymanagercategoriadetalletarea.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CategoriaDetalleTareaId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtCategoriaDetalleTareaId_Visible = 1;
         AssignProp("", false, edtCategoriaDetalleTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaId_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV14Att_CategoriaDetalleTareaId_Visible = true;
         AssignAttri("", false, "AV14Att_CategoriaDetalleTareaId_Visible", AV14Att_CategoriaDetalleTareaId_Visible);
         edtCategoriaDetalleTareaNombre_Visible = 1;
         AssignProp("", false, edtCategoriaDetalleTareaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaNombre_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV15Att_CategoriaDetalleTareaNombre_Visible = true;
         AssignAttri("", false, "AV15Att_CategoriaDetalleTareaNombre_Visible", AV15Att_CategoriaDetalleTareaNombre_Visible);
         edtid_actividad_categoria_Visible = 1;
         AssignProp("", false, edtid_actividad_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV16Att_id_actividad_categoria_Visible = true;
         AssignAttri("", false, "AV16Att_id_actividad_categoria_Visible", AV16Att_id_actividad_categoria_Visible);
         edtnombre_actividad_Visible = 1;
         AssignProp("", false, edtnombre_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV17Att_nombre_actividad_Visible = true;
         AssignAttri("", false, "AV17Att_nombre_actividad_Visible", AV17Att_nombre_actividad_Visible);
         edtCategoriaDetalleUsuarioRegistro_Visible = 1;
         AssignProp("", false, edtCategoriaDetalleUsuarioRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleUsuarioRegistro_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV18Att_CategoriaDetalleUsuarioRegistro_Visible = true;
         AssignAttri("", false, "AV18Att_CategoriaDetalleUsuarioRegistro_Visible", AV18Att_CategoriaDetalleUsuarioRegistro_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV45Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV50GXV3 = 1;
         while ( AV50GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV50GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaId") == 0 )
               {
                  edtCategoriaDetalleTareaId_Visible = 0;
                  AssignProp("", false, edtCategoriaDetalleTareaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaId_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV14Att_CategoriaDetalleTareaId_Visible = false;
                  AssignAttri("", false, "AV14Att_CategoriaDetalleTareaId_Visible", AV14Att_CategoriaDetalleTareaId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaNombre") == 0 )
               {
                  edtCategoriaDetalleTareaNombre_Visible = 0;
                  AssignProp("", false, edtCategoriaDetalleTareaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaNombre_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV15Att_CategoriaDetalleTareaNombre_Visible = false;
                  AssignAttri("", false, "AV15Att_CategoriaDetalleTareaNombre_Visible", AV15Att_CategoriaDetalleTareaNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
               {
                  edtid_actividad_categoria_Visible = 0;
                  AssignProp("", false, edtid_actividad_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV16Att_id_actividad_categoria_Visible = false;
                  AssignAttri("", false, "AV16Att_id_actividad_categoria_Visible", AV16Att_id_actividad_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
               {
                  edtnombre_actividad_Visible = 0;
                  AssignProp("", false, edtnombre_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV17Att_nombre_actividad_Visible = false;
                  AssignAttri("", false, "AV17Att_nombre_actividad_Visible", AV17Att_nombre_actividad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleUsuarioRegistro") == 0 )
               {
                  edtCategoriaDetalleUsuarioRegistro_Visible = 0;
                  AssignProp("", false, edtCategoriaDetalleUsuarioRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleUsuarioRegistro_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV18Att_CategoriaDetalleUsuarioRegistro_Visible = false;
                  AssignAttri("", false, "AV18Att_CategoriaDetalleUsuarioRegistro_Visible", AV18Att_CategoriaDetalleUsuarioRegistro_Visible);
               }
            }
            AV50GXV3 = (int)(AV50GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "CategoriaDetalleTareaId";
         AV13GridColumn.gxTpr_Columntitle = "Id.";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "CategoriaDetalleTareaNombre";
         AV13GridColumn.gxTpr_Columntitle = "Tarea";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_actividad_categoria";
         AV13GridColumn.gxTpr_Columntitle = "Id. ";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_actividad";
         AV13GridColumn.gxTpr_Columntitle = "Actividad Categoría";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "CategoriaDetalleUsuarioRegistro";
         AV13GridColumn.gxTpr_Columntitle = "Usuario Registro";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV10GridConfiguration.gxTpr_Gridcolumns = AV12GridColumns;
      }

      protected void S132( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV38ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV38ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(3)).gxTpr_Isauthorized )
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

      protected void S212( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV38ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV39ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerCategoriaDetalleTarea";
         AV38ActivityList.Add(AV39ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV38ActivityList) ;
         AV33CategoriaDetalleTareaNombre_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV33CategoriaDetalleTareaNombre_IsAuthorized", AV33CategoriaDetalleTareaNombre_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV38ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
      }

      protected void S142( )
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

      protected void E217H2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV25ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV34Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.convertURL( context.PathToRelativeUrl( AV34Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV34Update), true);
         AV47Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.convertURL( context.PathToRelativeUrl( AV34Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV34Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_122_Refreshing);
         AV35Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV35Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV35Delete), true);
         AV48Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV35Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV35Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_122_Refreshing);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV30UC_OrderedBy = AV27OrderedBy;
         AssignAttri("", false, "AV30UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV30UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV25ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E227H2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblNoresultsfoundtable_Visible = 0;
            AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
            if ( AV33CategoriaDetalleTareaNombre_IsAuthorized )
            {
               edtCategoriaDetalleTareaNombre_Link = formatLink("entitymanagercategoriadetalletarea.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CategoriaDetalleTareaId","TabCode"}) ;
            }
            else
            {
               edtCategoriaDetalleTareaNombre_Link = "";
            }
            edtavUpdate_Enabled = 1;
            edtavUpdate_Link = formatLink("entitymanagercategoriadetalletarea.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CategoriaDetalleTareaId","TabCode"}) ;
            edtavUpdate_Tooltiptext = "Actualizar";
            edtavDelete_Enabled = 1;
            edtavDelete_Link = formatLink("entitymanagercategoriadetalletarea.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CategoriaDetalleTareaId","TabCode"}) ;
            edtavDelete_Tooltiptext = "Eliminar";
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 122;
            }
            sendrow_1222( ) ;
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
         if ( isFullAjaxMode( ) && ! bGXsfl_122_Refreshing )
         {
            context.DoAjaxLoad(122, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E117H2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV27OrderedBy = AV30UC_OrderedBy;
         AssignAttri("", false, "AV27OrderedBy", StringUtil.LTrimStr( (decimal)(AV27OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void E137H2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV45Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV51GXV4 = 1;
         while ( AV51GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV51GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_CategoriaDetalleTareaId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_CategoriaDetalleTareaNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_id_actividad_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_nombre_actividad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "CategoriaDetalleUsuarioRegistro") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_CategoriaDetalleUsuarioRegistro_Visible;
            }
            AV51GXV4 = (int)(AV51GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV45Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV30UC_OrderedBy = AV27OrderedBy;
         AssignAttri("", false, "AV30UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV30UC_OrderedBy), 4, 0));
         if ( AV20RowsPerPageVariable != AV19GridSettingsRowsPerPageVariable )
         {
            AV20RowsPerPageVariable = AV19GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV20RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV20RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV20RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV45Pgmname,  "Grid",  AV20RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV26K2BToolsGenericSearchField, AV25ClassCollection, AV27OrderedBy, AV8CurrentPage, AV45Pgmname, AV10GridConfiguration, AV33CategoriaDetalleTareaNombre_IsAuthorized, AV14Att_CategoriaDetalleTareaId_Visible, AV15Att_CategoriaDetalleTareaNombre_Visible, AV16Att_id_actividad_categoria_Visible, AV17Att_nombre_actividad_Visible, AV18Att_CategoriaDetalleUsuarioRegistro_Visible, AV11FreezeColumnTitles, AV42Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void S162( )
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

      protected void E147H2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV8CurrentPage = 1;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void E157H2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV8CurrentPage > 1 )
         {
            AV8CurrentPage = (int)(AV8CurrentPage-1);
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void E167H2( )
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void E177H2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         AV8CurrentPage = AV9K2BMaxPages;
         AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ClassCollection", AV25ClassCollection);
      }

      protected void S152( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV45Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S222( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11FreezeColumnTitles = AV10GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         if ( AV11FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV25ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV25ClassCollection) ;
         }
      }

      protected void E187H2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "CategoriaDetalleTarea",  "CategoriaDetalleTarea",  "List",  "",  "ExportWWCategoriaDetalleTarea") )
         {
            new exportwwcategoriadetalletarea(context ).execute(  AV26K2BToolsGenericSearchField,  AV27OrderedBy, out  AV40OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV40OutFile, out  AV42Uri) )
            {
               CallWebObject(formatLink(AV42Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV41Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV41Guid.ToString(),  AV40OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV41Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table2_132_7H2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_132_7H2e( true) ;
         }
         else
         {
            wb_table2_132_7H2e( false) ;
         }
      }

      protected void wb_table1_24_7H2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e237h1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWCategoriaDetalleTarea.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWCategoriaDetalleTarea.htm");
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
            GxWebStd.gx_div_start( context, divCategoriadetalletareaid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_categoriadetalletareaid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_categoriadetalletareaid_visible_Internalname, "Id.", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_categoriadetalletareaid_visible_Internalname, StringUtil.BoolToStr( AV14Att_CategoriaDetalleTareaId_Visible), "", "Id.", 1, chkavAtt_categoriadetalletareaid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
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
            GxWebStd.gx_div_start( context, divCategoriadetalletareanombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_categoriadetalletareanombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_categoriadetalletareanombre_visible_Internalname, "Tarea", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_categoriadetalletareanombre_visible_Internalname, StringUtil.BoolToStr( AV15Att_CategoriaDetalleTareaNombre_Visible), "", "Tarea", 1, chkavAtt_categoriadetalletareanombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
            GxWebStd.gx_div_start( context, divId_actividad_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_actividad_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_actividad_categoria_visible_Internalname, "Id. ", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_actividad_categoria_visible_Internalname, StringUtil.BoolToStr( AV16Att_id_actividad_categoria_Visible), "", "Id. ", 1, chkavAtt_id_actividad_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(65, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,65);\"");
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
            GxWebStd.gx_div_start( context, divNombre_actividad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_actividad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_actividad_visible_Internalname, "Actividad Categoría", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_actividad_visible_Internalname, StringUtil.BoolToStr( AV17Att_nombre_actividad_Visible), "", "Actividad Categoría", 1, chkavAtt_nombre_actividad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(71, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"");
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
            GxWebStd.gx_div_start( context, divCategoriadetalleusuarioregistro_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_categoriadetalleusuarioregistro_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_categoriadetalleusuarioregistro_visible_Internalname, "Usuario Registro", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_categoriadetalleusuarioregistro_visible_Internalname, StringUtil.BoolToStr( AV18Att_CategoriaDetalleUsuarioRegistro_Visible), "", "Usuario Registro", 1, chkavAtt_categoriadetalleusuarioregistro_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,77);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_122_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 1, "HLP_WWCategoriaDetalleTarea.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWCategoriaDetalleTarea.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e247h1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWCategoriaDetalleTarea.htm");
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
            wb_table3_103_7H2( true) ;
         }
         else
         {
            wb_table3_103_7H2( false) ;
         }
         return  ;
      }

      protected void wb_table3_103_7H2e( bool wbgen )
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
            wb_table4_110_7H2( true) ;
         }
         else
         {
            wb_table4_110_7H2( false) ;
         }
         return  ;
      }

      protected void wb_table4_110_7H2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_24_7H2e( true) ;
         }
         else
         {
            wb_table1_24_7H2e( false) ;
         }
      }

      protected void wb_table4_110_7H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWCategoriaDetalleTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_110_7H2e( true) ;
         }
         else
         {
            wb_table4_110_7H2e( false) ;
         }
      }

      protected void wb_table3_103_7H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e257h1_client"+"'", TempTags, "", 2, "HLP_WWCategoriaDetalleTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWCategoriaDetalleTarea.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_103_7H2e( true) ;
         }
         else
         {
            wb_table3_103_7H2e( false) ;
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
         PA7H2( ) ;
         WS7H2( ) ;
         WE7H2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188215842", true, true);
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
         context.AddJavascriptSource("wwcategoriadetalletarea.js", "?2024188215843", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1222( )
      {
         edtCategoriaDetalleTareaId_Internalname = "CATEGORIADETALLETAREAID_"+sGXsfl_122_idx;
         edtCategoriaDetalleTareaNombre_Internalname = "CATEGORIADETALLETAREANOMBRE_"+sGXsfl_122_idx;
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_122_idx;
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD_"+sGXsfl_122_idx;
         edtCategoriaDetalleUsuarioRegistro_Internalname = "CATEGORIADETALLEUSUARIOREGISTRO_"+sGXsfl_122_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_122_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_122_idx;
      }

      protected void SubsflControlProps_fel_1222( )
      {
         edtCategoriaDetalleTareaId_Internalname = "CATEGORIADETALLETAREAID_"+sGXsfl_122_fel_idx;
         edtCategoriaDetalleTareaNombre_Internalname = "CATEGORIADETALLETAREANOMBRE_"+sGXsfl_122_fel_idx;
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_122_fel_idx;
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD_"+sGXsfl_122_fel_idx;
         edtCategoriaDetalleUsuarioRegistro_Internalname = "CATEGORIADETALLEUSUARIOREGISTRO_"+sGXsfl_122_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_122_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_122_fel_idx;
      }

      protected void sendrow_1222( )
      {
         SubsflControlProps_1222( ) ;
         WB7H0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_122_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_122_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_122_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtCategoriaDetalleTareaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaDetalleTareaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A294CategoriaDetalleTareaId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A294CategoriaDetalleTareaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaDetalleTareaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtCategoriaDetalleTareaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)38,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtCategoriaDetalleTareaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaDetalleTareaNombre_Internalname,(string)A295CategoriaDetalleTareaNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCategoriaDetalleTareaNombre_Link,(string)"",(string)"",(string)"",(string)edtCategoriaDetalleTareaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtCategoriaDetalleTareaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_actividad_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_actividad_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_actividad_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_actividad_categoria_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_actividad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_actividad_Internalname,(string)A123nombre_actividad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombre_actividad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombre_actividad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtCategoriaDetalleUsuarioRegistro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaDetalleUsuarioRegistro_Internalname,(string)A296CategoriaDetalleUsuarioRegistro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaDetalleUsuarioRegistro_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtCategoriaDetalleUsuarioRegistro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)122,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV34Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV34Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV47Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV34Update)) ? AV47Update_GXI : context.PathToRelativeUrl( AV34Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV34Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV35Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35Delete)) ? AV48Delete_GXI : context.PathToRelativeUrl( AV35Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV35Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes7H2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_122_idx = ((subGrid_Islastpage==1)&&(nGXsfl_122_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_122_idx+1);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_1222( ) ;
         }
         /* End function sendrow_1222 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_categoriadetalletareaid_visible.Name = "vATT_CATEGORIADETALLETAREAID_VISIBLE";
         chkavAtt_categoriadetalletareaid_visible.WebTags = "";
         chkavAtt_categoriadetalletareaid_visible.Caption = "";
         AssignProp("", false, chkavAtt_categoriadetalletareaid_visible_Internalname, "TitleCaption", chkavAtt_categoriadetalletareaid_visible.Caption, true);
         chkavAtt_categoriadetalletareaid_visible.CheckedValue = "false";
         AV14Att_CategoriaDetalleTareaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_CategoriaDetalleTareaId_Visible));
         AssignAttri("", false, "AV14Att_CategoriaDetalleTareaId_Visible", AV14Att_CategoriaDetalleTareaId_Visible);
         chkavAtt_categoriadetalletareanombre_visible.Name = "vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE";
         chkavAtt_categoriadetalletareanombre_visible.WebTags = "";
         chkavAtt_categoriadetalletareanombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_categoriadetalletareanombre_visible_Internalname, "TitleCaption", chkavAtt_categoriadetalletareanombre_visible.Caption, true);
         chkavAtt_categoriadetalletareanombre_visible.CheckedValue = "false";
         AV15Att_CategoriaDetalleTareaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_CategoriaDetalleTareaNombre_Visible));
         AssignAttri("", false, "AV15Att_CategoriaDetalleTareaNombre_Visible", AV15Att_CategoriaDetalleTareaNombre_Visible);
         chkavAtt_id_actividad_categoria_visible.Name = "vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE";
         chkavAtt_id_actividad_categoria_visible.WebTags = "";
         chkavAtt_id_actividad_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_actividad_categoria_visible_Internalname, "TitleCaption", chkavAtt_id_actividad_categoria_visible.Caption, true);
         chkavAtt_id_actividad_categoria_visible.CheckedValue = "false";
         AV16Att_id_actividad_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_id_actividad_categoria_Visible));
         AssignAttri("", false, "AV16Att_id_actividad_categoria_Visible", AV16Att_id_actividad_categoria_Visible);
         chkavAtt_nombre_actividad_visible.Name = "vATT_NOMBRE_ACTIVIDAD_VISIBLE";
         chkavAtt_nombre_actividad_visible.WebTags = "";
         chkavAtt_nombre_actividad_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_actividad_visible_Internalname, "TitleCaption", chkavAtt_nombre_actividad_visible.Caption, true);
         chkavAtt_nombre_actividad_visible.CheckedValue = "false";
         AV17Att_nombre_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_nombre_actividad_Visible));
         AssignAttri("", false, "AV17Att_nombre_actividad_Visible", AV17Att_nombre_actividad_Visible);
         chkavAtt_categoriadetalleusuarioregistro_visible.Name = "vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE";
         chkavAtt_categoriadetalleusuarioregistro_visible.WebTags = "";
         chkavAtt_categoriadetalleusuarioregistro_visible.Caption = "";
         AssignProp("", false, chkavAtt_categoriadetalleusuarioregistro_visible_Internalname, "TitleCaption", chkavAtt_categoriadetalleusuarioregistro_visible.Caption, true);
         chkavAtt_categoriadetalleusuarioregistro_visible.CheckedValue = "false";
         AV18Att_CategoriaDetalleUsuarioRegistro_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_CategoriaDetalleUsuarioRegistro_Visible));
         AssignAttri("", false, "AV18Att_CategoriaDetalleUsuarioRegistro_Visible", AV18Att_CategoriaDetalleUsuarioRegistro_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV19GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV19GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV19GridSettingsRowsPerPageVariable), 4, 0));
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
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_categoriadetalletareaid_visible_Internalname = "vATT_CATEGORIADETALLETAREAID_VISIBLE";
         divCategoriadetalletareaid_gridsettingscontainer_Internalname = "CATEGORIADETALLETAREAID_GRIDSETTINGSCONTAINER";
         chkavAtt_categoriadetalletareanombre_visible_Internalname = "vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE";
         divCategoriadetalletareanombre_gridsettingscontainer_Internalname = "CATEGORIADETALLETAREANOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_id_actividad_categoria_visible_Internalname = "vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE";
         divId_actividad_categoria_gridsettingscontainer_Internalname = "ID_ACTIVIDAD_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_actividad_visible_Internalname = "vATT_NOMBRE_ACTIVIDAD_VISIBLE";
         divNombre_actividad_gridsettingscontainer_Internalname = "NOMBRE_ACTIVIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_categoriadetalleusuarioregistro_visible_Internalname = "vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE";
         divCategoriadetalleusuarioregistro_gridsettingscontainer_Internalname = "CATEGORIADETALLEUSUARIOREGISTRO_GRIDSETTINGSCONTAINER";
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
         edtCategoriaDetalleTareaId_Internalname = "CATEGORIADETALLETAREAID";
         edtCategoriaDetalleTareaNombre_Internalname = "CATEGORIADETALLETAREANOMBRE";
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA";
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD";
         edtCategoriaDetalleUsuarioRegistro_Internalname = "CATEGORIADETALLEUSUARIOREGISTRO";
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
         chkavAtt_categoriadetalleusuarioregistro_visible.Caption = "Usuario Registro";
         chkavAtt_nombre_actividad_visible.Caption = "Actividad Categoría";
         chkavAtt_id_actividad_categoria_visible.Caption = "Id. ";
         chkavAtt_categoriadetalletareanombre_visible.Caption = "Tarea";
         chkavAtt_categoriadetalletareaid_visible.Caption = "Id.";
         edtCategoriaDetalleUsuarioRegistro_Jsonclick = "";
         edtnombre_actividad_Jsonclick = "";
         edtid_actividad_categoria_Jsonclick = "";
         edtCategoriaDetalleTareaNombre_Jsonclick = "";
         edtCategoriaDetalleTareaId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_categoriadetalleusuarioregistro_visible.Enabled = 1;
         chkavAtt_nombre_actividad_visible.Enabled = 1;
         chkavAtt_id_actividad_categoria_visible.Enabled = 1;
         chkavAtt_categoriadetalletareanombre_visible.Enabled = 1;
         chkavAtt_categoriadetalletareaid_visible.Enabled = 1;
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
         edtCategoriaDetalleTareaNombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtCategoriaDetalleUsuarioRegistro_Visible = -1;
         edtnombre_actividad_Visible = -1;
         edtid_actividad_categoria_Visible = -1;
         edtCategoriaDetalleTareaNombre_Visible = -1;
         edtCategoriaDetalleTareaId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Categoria detalle tareas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E127H2',iparms:[{av:'A294CategoriaDetalleTareaId',fld:'CATEGORIADETALLETAREAID',pic:'ZZZ9',hsh:true},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E257H1',iparms:[{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E217H2',iparms:[{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV30UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E227H2',iparms:[{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'A294CategoriaDetalleTareaId',fld:'CATEGORIADETALLETAREAID',pic:'ZZZ9',hsh:true},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Link',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E117H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{av:'AV30UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E237H1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E137H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{av:'AV20RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV19GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV20RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E147H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E157H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E167H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E177H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV34Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV35Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV33CategoriaDetalleTareaNombre_IsAuthorized',fld:'vCATEGORIADETALLETAREANOMBRE_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV25ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtCategoriaDetalleTareaId_Visible',ctrl:'CATEGORIADETALLETAREAID',prop:'Visible'},{av:'edtCategoriaDetalleTareaNombre_Visible',ctrl:'CATEGORIADETALLETAREANOMBRE',prop:'Visible'},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtCategoriaDetalleUsuarioRegistro_Visible',ctrl:'CATEGORIADETALLEUSUARIOREGISTRO',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E187H2',iparms:[{av:'AV26K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E247H1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_CATEGORIADETALLETAREAID","{handler:'Valid_Categoriadetalletareaid',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_CATEGORIADETALLETAREAID",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_CATEGORIADETALLETAREANOMBRE","{handler:'Valid_Categoriadetalletareanombre',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_CATEGORIADETALLETAREANOMBRE",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA","{handler:'Valid_Id_actividad_categoria',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_NOMBRE_ACTIVIDAD","{handler:'Valid_Nombre_actividad',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_NOMBRE_ACTIVIDAD",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_CATEGORIADETALLEUSUARIOREGISTRO","{handler:'Valid_Categoriadetalleusuarioregistro',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_CATEGORIADETALLEUSUARIOREGISTRO",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_CategoriaDetalleTareaId_Visible',fld:'vATT_CATEGORIADETALLETAREAID_VISIBLE',pic:''},{av:'AV15Att_CategoriaDetalleTareaNombre_Visible',fld:'vATT_CATEGORIADETALLETAREANOMBRE_VISIBLE',pic:''},{av:'AV16Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV17Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV18Att_CategoriaDetalleUsuarioRegistro_Visible',fld:'vATT_CATEGORIADETALLEUSUARIOREGISTRO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV26K2BToolsGenericSearchField = "";
         AV25ClassCollection = new GxSimpleCollection<string>();
         AV45Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV42Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV28GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A295CategoriaDetalleTareaNombre = "";
         A123nombre_actividad = "";
         A296CategoriaDetalleUsuarioRegistro = "";
         AV34Update = "";
         AV35Delete = "";
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
         AV47Update_GXI = "";
         AV48Delete_GXI = "";
         scmdbuf = "";
         lV26K2BToolsGenericSearchField = "";
         H007H2_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         H007H2_A102id_actividad_categoria = new int[1] ;
         H007H2_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         H007H2_A294CategoriaDetalleTareaId = new short[1] ;
         H007H3_A123nombre_actividad = new string[] {""} ;
         H007H3_n123nombre_actividad = new bool[] {false} ;
         H007H4_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         H007H4_A102id_actividad_categoria = new int[1] ;
         H007H4_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         H007H4_A294CategoriaDetalleTareaId = new short[1] ;
         H007H5_A123nombre_actividad = new string[] {""} ;
         H007H5_n123nombre_actividad = new bool[] {false} ;
         AV5Context = new SdtK2BContext(context);
         AV29GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV31Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV38ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV39ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV22GridStateKey = "";
         AV23GridState = new SdtK2BGridState(context);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV36TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV40OutFile = "";
         AV41Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         sImgUrl = "";
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
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwcategoriadetalletarea__datastore1(),
            new Object[][] {
                new Object[] {
               H007H3_A123nombre_actividad, H007H3_n123nombre_actividad
               }
               , new Object[] {
               H007H5_A123nombre_actividad, H007H5_n123nombre_actividad
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwcategoriadetalletarea__default(),
            new Object[][] {
                new Object[] {
               H007H2_A296CategoriaDetalleUsuarioRegistro, H007H2_A102id_actividad_categoria, H007H2_A295CategoriaDetalleTareaNombre, H007H2_A294CategoriaDetalleTareaId
               }
               , new Object[] {
               H007H4_A296CategoriaDetalleUsuarioRegistro, H007H4_A102id_actividad_categoria, H007H4_A295CategoriaDetalleTareaNombre, H007H4_A294CategoriaDetalleTareaId
               }
            }
         );
         AV45Pgmname = "WWCategoriaDetalleTarea";
         /* GeneXus formulas. */
         AV45Pgmname = "WWCategoriaDetalleTarea";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV27OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV30UC_OrderedBy ;
      private short AV20RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A294CategoriaDetalleTareaId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV19GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_122 ;
      private int nGXsfl_122_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtCategoriaDetalleTareaId_Visible ;
      private int edtCategoriaDetalleTareaNombre_Visible ;
      private int edtid_actividad_categoria_Visible ;
      private int edtnombre_actividad_Visible ;
      private int edtCategoriaDetalleUsuarioRegistro_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int A102id_actividad_categoria ;
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
      private int AV46GXV1 ;
      private int AV49GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV50GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV51GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_122_idx="0001" ;
      private string AV26K2BToolsGenericSearchField ;
      private string AV45Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtCategoriaDetalleTareaNombre_Link ;
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
      private string edtCategoriaDetalleTareaId_Internalname ;
      private string edtCategoriaDetalleTareaNombre_Internalname ;
      private string edtid_actividad_categoria_Internalname ;
      private string edtnombre_actividad_Internalname ;
      private string edtCategoriaDetalleUsuarioRegistro_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV26K2BToolsGenericSearchField ;
      private string chkavAtt_categoriadetalletareaid_visible_Internalname ;
      private string chkavAtt_categoriadetalletareanombre_visible_Internalname ;
      private string chkavAtt_id_actividad_categoria_visible_Internalname ;
      private string chkavAtt_nombre_actividad_visible_Internalname ;
      private string chkavAtt_categoriadetalleusuarioregistro_visible_Internalname ;
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
      private string sImgUrl ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divCategoriadetalletareaid_gridsettingscontainer_Internalname ;
      private string divCategoriadetalletareanombre_gridsettingscontainer_Internalname ;
      private string divId_actividad_categoria_gridsettingscontainer_Internalname ;
      private string divNombre_actividad_gridsettingscontainer_Internalname ;
      private string divCategoriadetalleusuarioregistro_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_122_fel_idx="0001" ;
      private string ROClassString ;
      private string edtCategoriaDetalleTareaId_Jsonclick ;
      private string edtCategoriaDetalleTareaNombre_Jsonclick ;
      private string edtid_actividad_categoria_Jsonclick ;
      private string edtnombre_actividad_Jsonclick ;
      private string edtCategoriaDetalleUsuarioRegistro_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV33CategoriaDetalleTareaNombre_IsAuthorized ;
      private bool AV14Att_CategoriaDetalleTareaId_Visible ;
      private bool AV15Att_CategoriaDetalleTareaNombre_Visible ;
      private bool AV16Att_id_actividad_categoria_Visible ;
      private bool AV17Att_nombre_actividad_Visible ;
      private bool AV18Att_CategoriaDetalleUsuarioRegistro_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n123nombre_actividad ;
      private bool bGXsfl_122_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV21RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV34Update_IsBlob ;
      private bool AV35Delete_IsBlob ;
      private string AV42Uri ;
      private string A295CategoriaDetalleTareaNombre ;
      private string A123nombre_actividad ;
      private string A296CategoriaDetalleUsuarioRegistro ;
      private string AV47Update_GXI ;
      private string AV48Delete_GXI ;
      private string AV22GridStateKey ;
      private string AV40OutFile ;
      private string AV34Update ;
      private string AV35Delete ;
      private Guid AV41Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_categoriadetalletareaid_visible ;
      private GXCheckbox chkavAtt_categoriadetalletareanombre_visible ;
      private GXCheckbox chkavAtt_id_actividad_categoria_visible ;
      private GXCheckbox chkavAtt_nombre_actividad_visible ;
      private GXCheckbox chkavAtt_categoriadetalleusuarioregistro_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H007H2_A296CategoriaDetalleUsuarioRegistro ;
      private int[] H007H2_A102id_actividad_categoria ;
      private string[] H007H2_A295CategoriaDetalleTareaNombre ;
      private short[] H007H2_A294CategoriaDetalleTareaId ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] H007H3_A123nombre_actividad ;
      private bool[] H007H3_n123nombre_actividad ;
      private string[] H007H4_A296CategoriaDetalleUsuarioRegistro ;
      private int[] H007H4_A102id_actividad_categoria ;
      private string[] H007H4_A295CategoriaDetalleTareaNombre ;
      private short[] H007H4_A294CategoriaDetalleTareaId ;
      private string[] H007H5_A123nombre_actividad ;
      private bool[] H007H5_n123nombre_actividad ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV25ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV28GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV38ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV23GridState ;
      private SdtK2BGridState_FilterValue AV24GridStateFilterValue ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV29GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV32Message ;
      private SdtK2BTrnContext AV36TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV39ActivityListItem ;
   }

   public class wwcategoriadetalletarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007H3;
          prmH007H3 = new Object[] {
          new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
          };
          Object[] prmH007H5;
          prmH007H5 = new Object[] {
          new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007H3", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007H5", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007H5,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wwcategoriadetalletarea__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H007H2( IGxContext context ,
                                           short AV27OrderedBy ,
                                           string AV26K2BToolsGenericSearchField ,
                                           short A294CategoriaDetalleTareaId ,
                                           string A295CategoriaDetalleTareaNombre ,
                                           int A102id_actividad_categoria ,
                                           string A123nombre_actividad ,
                                           string A296CategoriaDetalleUsuarioRegistro )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria], [CategoriaDetalleTareaNombre], [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea]";
       scmdbuf += sWhereString;
       if ( AV27OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId]";
       }
       else if ( AV27OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId] DESC";
       }
       else if ( AV27OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre]";
       }
       else if ( AV27OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre] DESC";
       }
       GXv_Object3[0] = scmdbuf;
       return GXv_Object3 ;
    }

    protected Object[] conditional_H007H4( IGxContext context ,
                                           short AV27OrderedBy ,
                                           string AV26K2BToolsGenericSearchField ,
                                           short A294CategoriaDetalleTareaId ,
                                           string A295CategoriaDetalleTareaNombre ,
                                           int A102id_actividad_categoria ,
                                           string A123nombre_actividad ,
                                           string A296CategoriaDetalleUsuarioRegistro )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria], [CategoriaDetalleTareaNombre], [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea]";
       scmdbuf += sWhereString;
       if ( AV27OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId]";
       }
       else if ( AV27OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId] DESC";
       }
       else if ( AV27OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre]";
       }
       else if ( AV27OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre] DESC";
       }
       GXv_Object4[0] = scmdbuf;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H007H2(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
             case 1 :
                   return conditional_H007H4(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
        Object[] prmH007H2;
        prmH007H2 = new Object[] {
        };
        Object[] prmH007H4;
        prmH007H4 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H007H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007H2,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007H4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007H4,11, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
     }
  }

}

}
