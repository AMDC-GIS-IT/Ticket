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
   public class wwactividades_categoria : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwactividades_categoria( )
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

      public wwactividades_categoria( IGxContext context )
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
         chkavAtt_id_actividad_categoria_visible = new GXCheckbox();
         chkavAtt_actividades_categoriaid_tipo_categoria_visible = new GXCheckbox();
         chkavAtt_nombre_actividad_visible = new GXCheckbox();
         chkavAtt_unidad_medida_visible = new GXCheckbox();
         chkavAtt_actividades_categoriaestado_visible = new GXCheckbox();
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
               nRC_GXsfl_146 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_146"), "."));
               nGXsfl_146_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_146_idx"), "."));
               sGXsfl_146_idx = GetPar( "sGXsfl_146_idx");
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
               AV55K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV44actividades_categoriaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "actividades_categoriaid_tipo_categoria"), "."));
               AV69fltnombre = GetPar( "fltnombre");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV43ClassCollection);
               AV56OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV75Pgmname = GetPar( "Pgmname");
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV62actividades_categoriaid_tipo_categoria_IsAuthorized = StringUtil.StrToBool( GetPar( "actividades_categoriaid_tipo_categoria_IsAuthorized"));
               AV14Att_id_actividad_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_id_actividad_categoria_Visible"));
               AV15Att_actividades_categoriaid_tipo_categoria_Visible = StringUtil.StrToBool( GetPar( "Att_actividades_categoriaid_tipo_categoria_Visible"));
               AV16Att_nombre_actividad_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_actividad_Visible"));
               AV17Att_unidad_medida_Visible = StringUtil.StrToBool( GetPar( "Att_unidad_medida_Visible"));
               AV18Att_actividades_categoriaestado_Visible = StringUtil.StrToBool( GetPar( "Att_actividades_categoriaestado_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV72Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
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
            return "actividades_categoria_Execute" ;
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
         PA562( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START562( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418821616", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwactividades_categoria.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV55K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFLTNOMBRE", AV69fltnombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_146", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_146), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV53FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV53FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV54DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV57GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV57GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV43ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV43ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED", AV62actividades_categoriaid_tipo_categoria_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV72Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
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
            WE562( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT562( ) ;
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
         return formatLink("wwactividades_categoria.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWactividades_categoria" ;
      }

      public override string GetPgmdesc( )
      {
         return "actividades_categorias" ;
      }

      protected void WB560( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "actividades_categorias", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_146_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV55K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV55K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWactividades_categoria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWactividades_categoria.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV53FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV54DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWactividades_categoria.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavActividades_categoriaid_tipo_categoria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavActividades_categoriaid_tipo_categoria_Internalname, "id_tipo_categoria", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_146_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavActividades_categoriaid_tipo_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0, ".", "")), StringUtil.LTrim( ((edtavActividades_categoriaid_tipo_categoria_Enabled!=0) ? context.localUtil.Format( (decimal)(AV44actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV44actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActividades_categoriaid_tipo_categoria_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavActividades_categoriaid_tipo_categoria_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWactividades_categoria.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerfltnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFltnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFltnombre_Internalname, "Actividad Categoría", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute_Filter";
            StyleString = "";
            ClassString = "Attribute_Filter";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFltnombre_Internalname, AV69fltnombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtavFltnombre_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWactividades_categoria.htm");
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
            wb_table1_53_562( true) ;
         }
         else
         {
            wb_table1_53_562( false) ;
         }
         return  ;
      }

      protected void wb_table1_53_562e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"146\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(73), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_actividad_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id. ") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtactividades_categoriaid_tipo_categoria_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_tipo_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_actividad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Actividad Categoría") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtunidad_medida_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "unidad_medida") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtactividades_categoriaestado_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "estado") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_actividad_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtactividades_categoriaid_tipo_categoria_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtactividades_categoriaid_tipo_categoria_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A123nombre_actividad);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_actividad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A124unidad_medida);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtunidad_medida_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125actividades_categoriaestado), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtactividades_categoriaestado_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 146 )
         {
            wbEnd = 0;
            nRC_GXsfl_146 = (int)(nGXsfl_146_idx-1);
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
            wb_table2_154_562( true) ;
         }
         else
         {
            wb_table2_154_562( false) ;
         }
         return  ;
      }

      protected void wb_table2_154_562e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV57GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV59UC_OrderedBy);
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
         if ( wbEnd == 146 )
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

      protected void START562( )
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
            Form.Meta.addItem("description", "actividades_categorias", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP560( ) ;
      }

      protected void WS562( )
      {
         START562( ) ;
         EVT562( ) ;
      }

      protected void EVT562( )
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
                              E11562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E13562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E14562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E15562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E16562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E17562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E18562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20562 ();
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
                              nGXsfl_146_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
                              SubsflControlProps_1462( ) ;
                              A102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ".", ","));
                              A122actividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaid_tipo_categoria_Internalname), ".", ","));
                              n122actividades_categoriaid_tipo_categoria = false;
                              A123nombre_actividad = cgiGet( edtnombre_actividad_Internalname);
                              n123nombre_actividad = false;
                              A124unidad_medida = cgiGet( edtunidad_medida_Internalname);
                              n124unidad_medida = false;
                              A125actividades_categoriaestado = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaestado_Internalname), ".", ","));
                              n125actividades_categoriaestado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E21562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E22562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E23562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV55K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Actividades_categoriaid_tipo_categoria Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV44actividades_categoriaid_tipo_categoria )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fltnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFLTNOMBRE"), AV69fltnombre) != 0 )
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

      protected void WE562( )
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

      protected void PA562( )
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
         SubsflControlProps_1462( ) ;
         while ( nGXsfl_146_idx <= nRC_GXsfl_146 )
         {
            sendrow_1462( ) ;
            nGXsfl_146_idx = ((subGrid_Islastpage==1)&&(nGXsfl_146_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_idx+1);
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1462( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV55K2BToolsGenericSearchField ,
                                       int AV44actividades_categoriaid_tipo_categoria ,
                                       string AV69fltnombre ,
                                       GxSimpleCollection<string> AV43ClassCollection ,
                                       short AV56OrderedBy ,
                                       string AV75Pgmname ,
                                       int AV8CurrentPage ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV62actividades_categoriaid_tipo_categoria_IsAuthorized ,
                                       bool AV14Att_id_actividad_categoria_Visible ,
                                       bool AV15Att_actividades_categoriaid_tipo_categoria_Visible ,
                                       bool AV16Att_nombre_actividad_Visible ,
                                       bool AV17Att_unidad_medida_Visible ,
                                       bool AV18Att_actividades_categoriaestado_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV72Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E22562 ();
         GRID_nCurrentRecord = 0;
         RF562( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         AV14Att_id_actividad_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_id_actividad_categoria_Visible));
         AssignAttri("", false, "AV14Att_id_actividad_categoria_Visible", AV14Att_id_actividad_categoria_Visible);
         AV15Att_actividades_categoriaid_tipo_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_actividades_categoriaid_tipo_categoria_Visible));
         AssignAttri("", false, "AV15Att_actividades_categoriaid_tipo_categoria_Visible", AV15Att_actividades_categoriaid_tipo_categoria_Visible);
         AV16Att_nombre_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_nombre_actividad_Visible));
         AssignAttri("", false, "AV16Att_nombre_actividad_Visible", AV16Att_nombre_actividad_Visible);
         AV17Att_unidad_medida_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_unidad_medida_Visible));
         AssignAttri("", false, "AV17Att_unidad_medida_Visible", AV17Att_unidad_medida_Visible);
         AV18Att_actividades_categoriaestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_actividades_categoriaestado_Visible));
         AssignAttri("", false, "AV18Att_actividades_categoriaestado_Visible", AV18Att_actividades_categoriaestado_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV37GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV37GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E22562 ();
         RF562( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV75Pgmname = "WWactividades_categoria";
         context.Gx_err = 0;
      }

      protected void RF562( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 146;
         E23562 ();
         nGXsfl_146_idx = 1;
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1462( ) ;
         bGXsfl_146_Refreshing = true;
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
            SubsflControlProps_1462( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 1 : GRID_nFirstRecordOnPage+1));
            GXPagingTo2 = (int)(((subGrid_Rows==0) ? 10000 : GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )+1));
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV44actividades_categoriaid_tipo_categoria ,
                                                 AV69fltnombre ,
                                                 AV55K2BToolsGenericSearchField ,
                                                 A122actividades_categoriaid_tipo_categoria ,
                                                 A123nombre_actividad ,
                                                 A102id_actividad_categoria ,
                                                 A124unidad_medida ,
                                                 A125actividades_categoriaestado ,
                                                 AV56OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV69fltnombre = StringUtil.Concat( StringUtil.RTrim( AV69fltnombre), "%", "");
            lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
            lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
            lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
            lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
            lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H00562 */
            pr_datastore1.execute(0, new Object[] {AV44actividades_categoriaid_tipo_categoria, lV69fltnombre, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingFrom2, GXPagingTo2});
            nGXsfl_146_idx = 1;
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1462( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A125actividades_categoriaestado = H00562_A125actividades_categoriaestado[0];
               n125actividades_categoriaestado = H00562_n125actividades_categoriaestado[0];
               A124unidad_medida = H00562_A124unidad_medida[0];
               n124unidad_medida = H00562_n124unidad_medida[0];
               A123nombre_actividad = H00562_A123nombre_actividad[0];
               n123nombre_actividad = H00562_n123nombre_actividad[0];
               A122actividades_categoriaid_tipo_categoria = H00562_A122actividades_categoriaid_tipo_categoria[0];
               n122actividades_categoriaid_tipo_categoria = H00562_n122actividades_categoriaid_tipo_categoria[0];
               A102id_actividad_categoria = H00562_A102id_actividad_categoria[0];
               E24562 ();
               pr_datastore1.readNext(0);
            }
            GRID_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 146;
            WB560( ) ;
         }
         bGXsfl_146_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes562( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV72Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Uri, "")), context));
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
         pr_datastore1.dynParam(1, new Object[]{ new Object[]{
                                              AV44actividades_categoriaid_tipo_categoria ,
                                              AV69fltnombre ,
                                              AV55K2BToolsGenericSearchField ,
                                              A122actividades_categoriaid_tipo_categoria ,
                                              A123nombre_actividad ,
                                              A102id_actividad_categoria ,
                                              A124unidad_medida ,
                                              A125actividades_categoriaestado ,
                                              AV56OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV69fltnombre = StringUtil.Concat( StringUtil.RTrim( AV69fltnombre), "%", "");
         lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
         lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
         lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
         lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
         lV55K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV55K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H00563 */
         pr_datastore1.execute(1, new Object[] {AV44actividades_categoriaid_tipo_categoria, lV69fltnombre, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField, lV55K2BToolsGenericSearchField});
         GRID_nRecordCount = H00563_AGRID_nRecordCount[0];
         pr_datastore1.close(1);
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
            gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV75Pgmname = "WWactividades_categoria";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP560( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E21562 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV53FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV57GridOrders);
            /* Read saved values. */
            nRC_GXsfl_146 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_146"), ".", ","));
            AV54DeletedTag = cgiGet( "vDELETEDTAG");
            AV59UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV56OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
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
            AV55K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV55K2BToolsGenericSearchField", AV55K2BToolsGenericSearchField);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavActividades_categoriaid_tipo_categoria_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavActividades_categoriaid_tipo_categoria_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA");
               GX_FocusControl = edtavActividades_categoriaid_tipo_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44actividades_categoriaid_tipo_categoria = 0;
               AssignAttri("", false, "AV44actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0));
            }
            else
            {
               AV44actividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtavActividades_categoriaid_tipo_categoria_Internalname), ".", ","));
               AssignAttri("", false, "AV44actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0));
            }
            AV69fltnombre = cgiGet( edtavFltnombre_Internalname);
            AssignAttri("", false, "AV69fltnombre", AV69fltnombre);
            AV14Att_id_actividad_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_actividad_categoria_visible_Internalname));
            AssignAttri("", false, "AV14Att_id_actividad_categoria_Visible", AV14Att_id_actividad_categoria_Visible);
            AV15Att_actividades_categoriaid_tipo_categoria_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname));
            AssignAttri("", false, "AV15Att_actividades_categoriaid_tipo_categoria_Visible", AV15Att_actividades_categoriaid_tipo_categoria_Visible);
            AV16Att_nombre_actividad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_actividad_visible_Internalname));
            AssignAttri("", false, "AV16Att_nombre_actividad_Visible", AV16Att_nombre_actividad_Visible);
            AV17Att_unidad_medida_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_unidad_medida_visible_Internalname));
            AssignAttri("", false, "AV17Att_unidad_medida_Visible", AV17Att_unidad_medida_Visible);
            AV18Att_actividades_categoriaestado_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_actividades_categoriaestado_visible_Internalname));
            AssignAttri("", false, "AV18Att_actividades_categoriaestado_Visible", AV18Att_actividades_categoriaestado_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV37GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV37GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV55K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV44actividades_categoriaid_tipo_categoria )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFLTNOMBRE"), AV69fltnombre) != 0 )
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
         E21562 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21562( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV44actividades_categoriaid_tipo_categoria = 0;
         AssignAttri("", false, "AV44actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0));
         AV69fltnombre = "";
         AssignAttri("", false, "AV69fltnombre", AV69fltnombre);
         new k2bloadrowsperpage(context ).execute(  AV75Pgmname,  "Grid", out  AV38RowsPerPageVariable, out  AV39RowsPerPageLoaded) ;
         AssignAttri("", false, "AV38RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV38RowsPerPageVariable), 4, 0));
         if ( ! AV39RowsPerPageLoaded )
         {
            AV38RowsPerPageVariable = 20;
            AssignAttri("", false, "AV38RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV38RowsPerPageVariable), 4, 0));
         }
         AV37GridSettingsRowsPerPageVariable = AV38RowsPerPageVariable;
         AssignAttri("", false, "AV37GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV38RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "actividades_categorias";
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
         AV57GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV58GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV58GridOrder.gxTpr_Ascendingorder = 0;
         AV58GridOrder.gxTpr_Descendingorder = 1;
         AV58GridOrder.gxTpr_Gridcolumnindex = 1;
         AV57GridOrders.Add(AV58GridOrder, 0);
         AV58GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV58GridOrder.gxTpr_Ascendingorder = 2;
         AV58GridOrder.gxTpr_Descendingorder = 3;
         AV58GridOrder.gxTpr_Gridcolumnindex = 2;
         AV57GridOrders.Add(AV58GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E22562( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV60Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV60Messages = GXt_objcol_SdtMessages_Message1;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV60Messages.Count )
         {
            AV61Message = ((GeneXus.Utils.SdtMessages_Message)AV60Messages.Item(AV76GXV1));
            GX_msglist.addItem(AV61Message.gxTpr_Description);
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV67ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV68ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV75Pgmname;
         AV67ActivityList.Add(AV68ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV67ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bscjoinstring(context ).execute(  AV43ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV40GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV40GridStateKey, out  AV41GridState) ;
         AV56OrderedBy = AV41GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV56OrderedBy", StringUtil.LTrimStr( (decimal)(AV56OrderedBy), 4, 0));
         AV59UC_OrderedBy = AV41GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV59UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV59UC_OrderedBy), 4, 0));
         AV77GXV2 = 1;
         while ( AV77GXV2 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV77GXV2));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Filtername, "actividades_categoriaid_tipo_categoria") == 0 )
            {
               AV44actividades_categoriaid_tipo_categoria = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV44actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Filtername, "fltnombre") == 0 )
            {
               AV69fltnombre = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69fltnombre", AV69fltnombre);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV55K2BToolsGenericSearchField = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55K2BToolsGenericSearchField", AV55K2BToolsGenericSearchField);
            }
            AV77GXV2 = (int)(AV77GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV41GridState.gxTpr_Currentpage > 0 ) && ( AV41GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV41GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV40GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV40GridStateKey, out  AV41GridState) ;
         AV41GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV41GridState.gxTpr_Orderedby = AV56OrderedBy;
         AV41GridState.gxTpr_Filtervalues.Clear();
         AV42GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV42GridStateFilterValue.gxTpr_Filtername = "actividades_categoriaid_tipo_categoria";
         AV42GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0);
         AV41GridState.gxTpr_Filtervalues.Add(AV42GridStateFilterValue, 0);
         AV42GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV42GridStateFilterValue.gxTpr_Filtername = "fltnombre";
         AV42GridStateFilterValue.gxTpr_Value = AV69fltnombre;
         AV41GridState.gxTpr_Filtervalues.Add(AV42GridStateFilterValue, 0);
         AV42GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV42GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV42GridStateFilterValue.gxTpr_Value = AV55K2BToolsGenericSearchField;
         AV41GridState.gxTpr_Filtervalues.Add(AV42GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV75Pgmname,  AV40GridStateKey,  AV41GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV65TrnContext = new SdtK2BTrnContext(context);
         AV65TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV65TrnContext.gxTpr_Returnmode = "Stack";
         AV65TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV65TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV65TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV65TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV65TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV65TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "actividades_categoria",  AV65TrnContext) ;
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtid_actividad_categoria_Visible = 1;
         AssignProp("", false, edtid_actividad_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV14Att_id_actividad_categoria_Visible = true;
         AssignAttri("", false, "AV14Att_id_actividad_categoria_Visible", AV14Att_id_actividad_categoria_Visible);
         edtactividades_categoriaid_tipo_categoria_Visible = 1;
         AssignProp("", false, edtactividades_categoriaid_tipo_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaid_tipo_categoria_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV15Att_actividades_categoriaid_tipo_categoria_Visible = true;
         AssignAttri("", false, "AV15Att_actividades_categoriaid_tipo_categoria_Visible", AV15Att_actividades_categoriaid_tipo_categoria_Visible);
         edtnombre_actividad_Visible = 1;
         AssignProp("", false, edtnombre_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV16Att_nombre_actividad_Visible = true;
         AssignAttri("", false, "AV16Att_nombre_actividad_Visible", AV16Att_nombre_actividad_Visible);
         edtunidad_medida_Visible = 1;
         AssignProp("", false, edtunidad_medida_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidad_medida_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV17Att_unidad_medida_Visible = true;
         AssignAttri("", false, "AV17Att_unidad_medida_Visible", AV17Att_unidad_medida_Visible);
         edtactividades_categoriaestado_Visible = 1;
         AssignProp("", false, edtactividades_categoriaestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaestado_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV18Att_actividades_categoriaestado_Visible = true;
         AssignAttri("", false, "AV18Att_actividades_categoriaestado_Visible", AV18Att_actividades_categoriaestado_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV75Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV78GXV3 = 1;
         while ( AV78GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV78GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
               {
                  edtid_actividad_categoria_Visible = 0;
                  AssignProp("", false, edtid_actividad_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV14Att_id_actividad_categoria_Visible = false;
                  AssignAttri("", false, "AV14Att_id_actividad_categoria_Visible", AV14Att_id_actividad_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "actividades_categoriaid_tipo_categoria") == 0 )
               {
                  edtactividades_categoriaid_tipo_categoria_Visible = 0;
                  AssignProp("", false, edtactividades_categoriaid_tipo_categoria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaid_tipo_categoria_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV15Att_actividades_categoriaid_tipo_categoria_Visible = false;
                  AssignAttri("", false, "AV15Att_actividades_categoriaid_tipo_categoria_Visible", AV15Att_actividades_categoriaid_tipo_categoria_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
               {
                  edtnombre_actividad_Visible = 0;
                  AssignProp("", false, edtnombre_actividad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV16Att_nombre_actividad_Visible = false;
                  AssignAttri("", false, "AV16Att_nombre_actividad_Visible", AV16Att_nombre_actividad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidad_medida") == 0 )
               {
                  edtunidad_medida_Visible = 0;
                  AssignProp("", false, edtunidad_medida_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtunidad_medida_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV17Att_unidad_medida_Visible = false;
                  AssignAttri("", false, "AV17Att_unidad_medida_Visible", AV17Att_unidad_medida_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "actividades_categoriaestado") == 0 )
               {
                  edtactividades_categoriaestado_Visible = 0;
                  AssignProp("", false, edtactividades_categoriaestado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaestado_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV18Att_actividades_categoriaestado_Visible = false;
                  AssignAttri("", false, "AV18Att_actividades_categoriaestado_Visible", AV18Att_actividades_categoriaestado_Visible);
               }
            }
            AV78GXV3 = (int)(AV78GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_actividad_categoria";
         AV13GridColumn.gxTpr_Columntitle = "Id. ";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "actividades_categoriaid_tipo_categoria";
         AV13GridColumn.gxTpr_Columntitle = "id_tipo_categoria";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_actividad";
         AV13GridColumn.gxTpr_Columntitle = "Actividad Categoría";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "unidad_medida";
         AV13GridColumn.gxTpr_Columntitle = "unidad_medida";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "actividades_categoriaestado";
         AV13GridColumn.gxTpr_Columntitle = "estado";
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
         AV67ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV68ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWactividades_categoria";
         AV67ActivityList.Add(AV68ActivityListItem, 0);
         AV68ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWactividades_categoria";
         AV67ActivityList.Add(AV68ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV67ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV67ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV68ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "actividades_categoria";
         AV68ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManageractividades_categoria";
         AV67ActivityList.Add(AV68ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV67ActivityList) ;
         AV62actividades_categoriaid_tipo_categoria_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV67ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV62actividades_categoriaid_tipo_categoria_IsAuthorized", AV62actividades_categoriaid_tipo_categoria_IsAuthorized);
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

      protected void E23562( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV43ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
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
         AV59UC_OrderedBy = AV56OrderedBy;
         AssignAttri("", false, "AV59UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV59UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV43ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53FilterTags", AV53FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E24562( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV62actividades_categoriaid_tipo_categoria_IsAuthorized )
         {
            edtactividades_categoriaid_tipo_categoria_Link = formatLink("entitymanageractividades_categoria.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_actividad_categoria","TabCode"}) ;
         }
         else
         {
            edtactividades_categoriaid_tipo_categoria_Link = "";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 146;
         }
         sendrow_1462( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_146_Refreshing )
         {
            context.DoAjaxLoad(146, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV51K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (0==AV44actividades_categoriaid_tipo_categoria) )
         {
            AV52K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV52K2BFilterValuesSDTItem.gxTpr_Name = "actividades_categoriaid_tipo_categoria";
            AV52K2BFilterValuesSDTItem.gxTpr_Description = "id_tipo_categoria";
            AV52K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV52K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV52K2BFilterValuesSDTItem.gxTpr_Value = StringUtil.Str( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0);
            AV52K2BFilterValuesSDTItem.gxTpr_Valuedescription = StringUtil.Str( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0);
            AV51K2BFilterValuesSDT.Add(AV52K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69fltnombre)) )
         {
            AV52K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV52K2BFilterValuesSDTItem.gxTpr_Name = "fltnombre";
            AV52K2BFilterValuesSDTItem.gxTpr_Description = "Actividad Categoría";
            AV52K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV52K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV52K2BFilterValuesSDTItem.gxTpr_Value = AV69fltnombre;
            AV52K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV69fltnombre;
            AV51K2BFilterValuesSDT.Add(AV52K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV51K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV53FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV75Pgmname,  "Grid",  AV51K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV53FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E11562( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV54DeletedTag, "actividades_categoriaid_tipo_categoria") == 0 )
         {
            AV44actividades_categoriaid_tipo_categoria = 0;
            AssignAttri("", false, "AV44actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV44actividades_categoriaid_tipo_categoria), 9, 0));
         }
         else if ( StringUtil.StrCmp(AV54DeletedTag, "fltnombre") == 0 )
         {
            AV69fltnombre = "";
            AssignAttri("", false, "AV69fltnombre", AV69fltnombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void E12562( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV56OrderedBy = AV59UC_OrderedBy;
         AssignAttri("", false, "AV56OrderedBy", StringUtil.LTrimStr( (decimal)(AV56OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void E13562( )
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
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV79GXV4 = 1;
         while ( AV79GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV79GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_id_actividad_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "actividades_categoriaid_tipo_categoria") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_actividades_categoriaid_tipo_categoria_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_nombre_actividad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "unidad_medida") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_unidad_medida_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "actividades_categoriaestado") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_actividades_categoriaestado_Visible;
            }
            AV79GXV4 = (int)(AV79GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV75Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV59UC_OrderedBy = AV56OrderedBy;
         AssignAttri("", false, "AV59UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV59UC_OrderedBy), 4, 0));
         if ( AV38RowsPerPageVariable != AV37GridSettingsRowsPerPageVariable )
         {
            AV38RowsPerPageVariable = AV37GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV38RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV38RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV38RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV75Pgmname,  "Grid",  AV38RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV55K2BToolsGenericSearchField, AV44actividades_categoriaid_tipo_categoria, AV69fltnombre, AV43ClassCollection, AV56OrderedBy, AV75Pgmname, AV8CurrentPage, AV10GridConfiguration, AV62actividades_categoriaid_tipo_categoria_IsAuthorized, AV14Att_id_actividad_categoria_Visible, AV15Att_actividades_categoriaid_tipo_categoria_Visible, AV16Att_nombre_actividad_Visible, AV17Att_unidad_medida_Visible, AV18Att_actividades_categoriaestado_Visible, AV11FreezeColumnTitles, AV72Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
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

      protected void E14562( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void E15562( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void E16562( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
      }

      protected void E17562( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ClassCollection", AV43ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV43ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV43ClassCollection) ;
         }
      }

      protected void E18562( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "actividades_categoria",  "actividades_categoria",  "List",  "",  "ExportWWactividades_categoria") )
         {
            new exportwwactividades_categoria(context ).execute(  AV44actividades_categoriaid_tipo_categoria,  AV69fltnombre,  AV55K2BToolsGenericSearchField,  AV56OrderedBy, out  AV70OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV70OutFile, out  AV72Uri) )
            {
               CallWebObject(formatLink(AV72Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV71Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV71Guid.ToString(),  AV70OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV71Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void E19562( )
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

      protected void E20562( )
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

      protected void wb_table2_154_562( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_154_562e( true) ;
         }
         else
         {
            wb_table2_154_562e( false) ;
         }
      }

      protected void wb_table1_53_562( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e25561_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWactividades_categoria.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWactividades_categoria.htm");
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
            GxWebStd.gx_div_start( context, divId_actividad_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_actividad_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_actividad_categoria_visible_Internalname, "Id. ", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_actividad_categoria_visible_Internalname, StringUtil.BoolToStr( AV14Att_id_actividad_categoria_Visible), "", "Id. ", 1, chkavAtt_id_actividad_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_div_start( context, divActividades_categoriaid_tipo_categoria_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname, "id_tipo_categoria", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname, StringUtil.BoolToStr( AV15Att_actividades_categoriaid_tipo_categoria_Visible), "", "id_tipo_categoria", 1, chkavAtt_actividades_categoriaid_tipo_categoria_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_actividad_visible_Internalname, StringUtil.BoolToStr( AV16Att_nombre_actividad_Visible), "", "Actividad Categoría", 1, chkavAtt_nombre_actividad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
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
            GxWebStd.gx_div_start( context, divUnidad_medida_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_unidad_medida_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_unidad_medida_visible_Internalname, "unidad_medida", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_unidad_medida_visible_Internalname, StringUtil.BoolToStr( AV17Att_unidad_medida_Visible), "", "unidad_medida", 1, chkavAtt_unidad_medida_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            GxWebStd.gx_div_start( context, divActividades_categoriaestado_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_actividades_categoriaestado_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_actividades_categoriaestado_visible_Internalname, "estado", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_actividades_categoriaestado_visible_Internalname, StringUtil.BoolToStr( AV18Att_actividades_categoriaestado_Visible), "", "estado", 1, chkavAtt_actividades_categoriaestado_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(106, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,106);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_146_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "", true, 1, "HLP_WWactividades_categoria.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWactividades_categoria.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e26561_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWactividades_categoria.htm");
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
            wb_table3_132_562( true) ;
         }
         else
         {
            wb_table3_132_562( false) ;
         }
         return  ;
      }

      protected void wb_table3_132_562e( bool wbgen )
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
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_53_562e( true) ;
         }
         else
         {
            wb_table1_53_562e( false) ;
         }
      }

      protected void wb_table3_132_562( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e27561_client"+"'", TempTags, "", 2, "HLP_WWactividades_categoria.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWactividades_categoria.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_132_562e( true) ;
         }
         else
         {
            wb_table3_132_562e( false) ;
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
         PA562( ) ;
         WS562( ) ;
         WE562( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188211128", true, true);
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
         context.AddJavascriptSource("wwactividades_categoria.js", "?2024188211128", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1462( )
      {
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_146_idx;
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_"+sGXsfl_146_idx;
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD_"+sGXsfl_146_idx;
         edtunidad_medida_Internalname = "UNIDAD_MEDIDA_"+sGXsfl_146_idx;
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO_"+sGXsfl_146_idx;
      }

      protected void SubsflControlProps_fel_1462( )
      {
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_146_fel_idx;
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_"+sGXsfl_146_fel_idx;
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD_"+sGXsfl_146_fel_idx;
         edtunidad_medida_Internalname = "UNIDAD_MEDIDA_"+sGXsfl_146_fel_idx;
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO_"+sGXsfl_146_fel_idx;
      }

      protected void sendrow_1462( )
      {
         SubsflControlProps_1462( ) ;
         WB560( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_146_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_146_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_146_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_actividad_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_actividad_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_actividad_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_actividad_categoria_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)73,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtactividades_categoriaid_tipo_categoria_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtactividades_categoriaid_tipo_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A122actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtactividades_categoriaid_tipo_categoria_Link,(string)"",(string)"",(string)"",(string)edtactividades_categoriaid_tipo_categoria_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtactividades_categoriaid_tipo_categoria_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_actividad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_actividad_Internalname,(string)A123nombre_actividad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombre_actividad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombre_actividad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtunidad_medida_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidad_medida_Internalname,(string)A124unidad_medida,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidad_medida_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtunidad_medida_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtactividades_categoriaestado_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtactividades_categoriaestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A125actividades_categoriaestado), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A125actividades_categoriaestado), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtactividades_categoriaestado_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtactividades_categoriaestado_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes562( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_146_idx = ((subGrid_Islastpage==1)&&(nGXsfl_146_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_idx+1);
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1462( ) ;
         }
         /* End function sendrow_1462 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_id_actividad_categoria_visible.Name = "vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE";
         chkavAtt_id_actividad_categoria_visible.WebTags = "";
         chkavAtt_id_actividad_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_actividad_categoria_visible_Internalname, "TitleCaption", chkavAtt_id_actividad_categoria_visible.Caption, true);
         chkavAtt_id_actividad_categoria_visible.CheckedValue = "false";
         AV14Att_id_actividad_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_id_actividad_categoria_Visible));
         AssignAttri("", false, "AV14Att_id_actividad_categoria_Visible", AV14Att_id_actividad_categoria_Visible);
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.Name = "vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE";
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.WebTags = "";
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.Caption = "";
         AssignProp("", false, chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname, "TitleCaption", chkavAtt_actividades_categoriaid_tipo_categoria_visible.Caption, true);
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.CheckedValue = "false";
         AV15Att_actividades_categoriaid_tipo_categoria_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_actividades_categoriaid_tipo_categoria_Visible));
         AssignAttri("", false, "AV15Att_actividades_categoriaid_tipo_categoria_Visible", AV15Att_actividades_categoriaid_tipo_categoria_Visible);
         chkavAtt_nombre_actividad_visible.Name = "vATT_NOMBRE_ACTIVIDAD_VISIBLE";
         chkavAtt_nombre_actividad_visible.WebTags = "";
         chkavAtt_nombre_actividad_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_actividad_visible_Internalname, "TitleCaption", chkavAtt_nombre_actividad_visible.Caption, true);
         chkavAtt_nombre_actividad_visible.CheckedValue = "false";
         AV16Att_nombre_actividad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_nombre_actividad_Visible));
         AssignAttri("", false, "AV16Att_nombre_actividad_Visible", AV16Att_nombre_actividad_Visible);
         chkavAtt_unidad_medida_visible.Name = "vATT_UNIDAD_MEDIDA_VISIBLE";
         chkavAtt_unidad_medida_visible.WebTags = "";
         chkavAtt_unidad_medida_visible.Caption = "";
         AssignProp("", false, chkavAtt_unidad_medida_visible_Internalname, "TitleCaption", chkavAtt_unidad_medida_visible.Caption, true);
         chkavAtt_unidad_medida_visible.CheckedValue = "false";
         AV17Att_unidad_medida_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_unidad_medida_Visible));
         AssignAttri("", false, "AV17Att_unidad_medida_Visible", AV17Att_unidad_medida_Visible);
         chkavAtt_actividades_categoriaestado_visible.Name = "vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE";
         chkavAtt_actividades_categoriaestado_visible.WebTags = "";
         chkavAtt_actividades_categoriaestado_visible.Caption = "";
         AssignProp("", false, chkavAtt_actividades_categoriaestado_visible_Internalname, "TitleCaption", chkavAtt_actividades_categoriaestado_visible.Caption, true);
         chkavAtt_actividades_categoriaestado_visible.CheckedValue = "false";
         AV18Att_actividades_categoriaestado_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_actividades_categoriaestado_Visible));
         AssignAttri("", false, "AV18Att_actividades_categoriaestado_Visible", AV18Att_actividades_categoriaestado_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV37GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV37GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV37GridSettingsRowsPerPageVariable), 4, 0));
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
         edtavActividades_categoriaid_tipo_categoria_Internalname = "vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         edtavFltnombre_Internalname = "vFLTNOMBRE";
         divK2btoolstable_attributecontainerfltnombre_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERFLTNOMBRE";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_id_actividad_categoria_visible_Internalname = "vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE";
         divId_actividad_categoria_gridsettingscontainer_Internalname = "ID_ACTIVIDAD_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname = "vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE";
         divActividades_categoriaid_tipo_categoria_gridsettingscontainer_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_actividad_visible_Internalname = "vATT_NOMBRE_ACTIVIDAD_VISIBLE";
         divNombre_actividad_gridsettingscontainer_Internalname = "NOMBRE_ACTIVIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_unidad_medida_visible_Internalname = "vATT_UNIDAD_MEDIDA_VISIBLE";
         divUnidad_medida_gridsettingscontainer_Internalname = "UNIDAD_MEDIDA_GRIDSETTINGSCONTAINER";
         chkavAtt_actividades_categoriaestado_visible_Internalname = "vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE";
         divActividades_categoriaestado_gridsettingscontainer_Internalname = "ACTIVIDADES_CATEGORIAESTADO_GRIDSETTINGSCONTAINER";
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
         tblTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA";
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         edtnombre_actividad_Internalname = "NOMBRE_ACTIVIDAD";
         edtunidad_medida_Internalname = "UNIDAD_MEDIDA";
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO";
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
         chkavAtt_actividades_categoriaestado_visible.Caption = "estado";
         chkavAtt_unidad_medida_visible.Caption = "unidad_medida";
         chkavAtt_nombre_actividad_visible.Caption = "Actividad Categoría";
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.Caption = "id_tipo_categoria";
         chkavAtt_id_actividad_categoria_visible.Caption = "Id. ";
         edtactividades_categoriaestado_Jsonclick = "";
         edtunidad_medida_Jsonclick = "";
         edtnombre_actividad_Jsonclick = "";
         edtactividades_categoriaid_tipo_categoria_Jsonclick = "";
         edtid_actividad_categoria_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_actividades_categoriaestado_visible.Enabled = 1;
         chkavAtt_unidad_medida_visible.Enabled = 1;
         chkavAtt_nombre_actividad_visible.Enabled = 1;
         chkavAtt_actividades_categoriaid_tipo_categoria_visible.Enabled = 1;
         chkavAtt_id_actividad_categoria_visible.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         tblNoresultsfoundtable_Visible = 1;
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
         edtactividades_categoriaid_tipo_categoria_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtactividades_categoriaestado_Visible = -1;
         edtunidad_medida_Visible = -1;
         edtnombre_actividad_Visible = -1;
         edtactividades_categoriaid_tipo_categoria_Visible = -1;
         edtid_actividad_categoria_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavFltnombre_Enabled = 1;
         edtavActividades_categoriaid_tipo_categoria_Jsonclick = "";
         edtavActividades_categoriaid_tipo_categoria_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         imgFiltertoggle_combined_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "actividades_categorias";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E27561',iparms:[{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E23562',iparms:[{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV59UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV53FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E24562',iparms:[{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'A102id_actividad_categoria',fld:'ID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Link',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Link'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E11562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV54DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E12562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV59UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E25561',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E13562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV38RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV37GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV59UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV38RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E14562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E15562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E16562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E17562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV62actividades_categoriaid_tipo_categoria_IsAuthorized',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_ISAUTHORIZED',pic:''},{av:'AV43ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtid_actividad_categoria_Visible',ctrl:'ID_ACTIVIDAD_CATEGORIA',prop:'Visible'},{av:'edtactividades_categoriaid_tipo_categoria_Visible',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'},{av:'edtnombre_actividad_Visible',ctrl:'NOMBRE_ACTIVIDAD',prop:'Visible'},{av:'edtunidad_medida_Visible',ctrl:'UNIDAD_MEDIDA',prop:'Visible'},{av:'edtactividades_categoriaestado_Visible',ctrl:'ACTIVIDADES_CATEGORIAESTADO',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E18562',iparms:[{av:'AV44actividades_categoriaid_tipo_categoria',fld:'vACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV69fltnombre',fld:'vFLTNOMBRE',pic:''},{av:'AV55K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV56OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV72Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E19562',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E20562',iparms:[{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E26561',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Actividades_categoriaestado',iparms:[{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_id_actividad_categoria_Visible',fld:'vATT_ID_ACTIVIDAD_CATEGORIA_VISIBLE',pic:''},{av:'AV15Att_actividades_categoriaid_tipo_categoria_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_VISIBLE',pic:''},{av:'AV16Att_nombre_actividad_Visible',fld:'vATT_NOMBRE_ACTIVIDAD_VISIBLE',pic:''},{av:'AV17Att_unidad_medida_Visible',fld:'vATT_UNIDAD_MEDIDA_VISIBLE',pic:''},{av:'AV18Att_actividades_categoriaestado_Visible',fld:'vATT_ACTIVIDADES_CATEGORIAESTADO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV55K2BToolsGenericSearchField = "";
         AV69fltnombre = "";
         AV43ClassCollection = new GxSimpleCollection<string>();
         AV75Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV72Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV53FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV54DeletedTag = "";
         AV57GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A123nombre_actividad = "";
         A124unidad_medida = "";
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
         scmdbuf = "";
         lV69fltnombre = "";
         lV55K2BToolsGenericSearchField = "";
         H00562_A125actividades_categoriaestado = new int[1] ;
         H00562_n125actividades_categoriaestado = new bool[] {false} ;
         H00562_A124unidad_medida = new string[] {""} ;
         H00562_n124unidad_medida = new bool[] {false} ;
         H00562_A123nombre_actividad = new string[] {""} ;
         H00562_n123nombre_actividad = new bool[] {false} ;
         H00562_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H00562_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H00562_A102id_actividad_categoria = new int[1] ;
         H00563_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV58GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV60Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV61Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV67ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV68ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV40GridStateKey = "";
         AV41GridState = new SdtK2BGridState(context);
         AV42GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV65TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV51K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV52K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV70OutFile = "";
         AV71Guid = (Guid)(Guid.Empty);
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwactividades_categoria__datastore1(),
            new Object[][] {
                new Object[] {
               H00562_A125actividades_categoriaestado, H00562_n125actividades_categoriaestado, H00562_A124unidad_medida, H00562_n124unidad_medida, H00562_A123nombre_actividad, H00562_n123nombre_actividad, H00562_A122actividades_categoriaid_tipo_categoria, H00562_n122actividades_categoriaid_tipo_categoria, H00562_A102id_actividad_categoria
               }
               , new Object[] {
               H00563_AGRID_nRecordCount
               }
            }
         );
         AV75Pgmname = "WWactividades_categoria";
         /* GeneXus formulas. */
         AV75Pgmname = "WWactividades_categoria";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV56OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV59UC_OrderedBy ;
      private short AV38RowsPerPageVariable ;
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
      private short AV37GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_146 ;
      private int nGXsfl_146_idx=1 ;
      private int subGrid_Rows ;
      private int AV44actividades_categoriaid_tipo_categoria ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavActividades_categoriaid_tipo_categoria_Enabled ;
      private int edtavFltnombre_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtid_actividad_categoria_Visible ;
      private int edtactividades_categoriaid_tipo_categoria_Visible ;
      private int edtnombre_actividad_Visible ;
      private int edtunidad_medida_Visible ;
      private int edtactividades_categoriaestado_Visible ;
      private int A102id_actividad_categoria ;
      private int A122actividades_categoriaid_tipo_categoria ;
      private int A125actividades_categoriaestado ;
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
      private int AV76GXV1 ;
      private int AV77GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV78GXV3 ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV79GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_146_idx="0001" ;
      private string AV55K2BToolsGenericSearchField ;
      private string AV75Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV54DeletedTag ;
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
      private string divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname ;
      private string edtavActividades_categoriaid_tipo_categoria_Internalname ;
      private string edtavActividades_categoriaid_tipo_categoria_Jsonclick ;
      private string divK2btoolstable_attributecontainerfltnombre_Internalname ;
      private string edtavFltnombre_Internalname ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtactividades_categoriaid_tipo_categoria_Link ;
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
      private string edtid_actividad_categoria_Internalname ;
      private string edtactividades_categoriaid_tipo_categoria_Internalname ;
      private string edtnombre_actividad_Internalname ;
      private string edtunidad_medida_Internalname ;
      private string edtactividades_categoriaestado_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV55K2BToolsGenericSearchField ;
      private string chkavAtt_id_actividad_categoria_visible_Internalname ;
      private string chkavAtt_actividades_categoriaid_tipo_categoria_visible_Internalname ;
      private string chkavAtt_nombre_actividad_visible_Internalname ;
      private string chkavAtt_unidad_medida_visible_Internalname ;
      private string chkavAtt_actividades_categoriaestado_visible_Internalname ;
      private string chkavFreezecolumntitles_Internalname ;
      private string divDownloadactionstable_Internalname ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string bttReport_Tooltiptext ;
      private string bttReport_Internalname ;
      private string bttExport_Tooltiptext ;
      private string bttExport_Internalname ;
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
      private string divId_actividad_categoria_gridsettingscontainer_Internalname ;
      private string divActividades_categoriaid_tipo_categoria_gridsettingscontainer_Internalname ;
      private string divNombre_actividad_gridsettingscontainer_Internalname ;
      private string divUnidad_medida_gridsettingscontainer_Internalname ;
      private string divActividades_categoriaestado_gridsettingscontainer_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string tblK2btabledownloadssectioncontainer_Internalname ;
      private string bttReport_Jsonclick ;
      private string bttExport_Jsonclick ;
      private string sGXsfl_146_fel_idx="0001" ;
      private string ROClassString ;
      private string edtid_actividad_categoria_Jsonclick ;
      private string edtactividades_categoriaid_tipo_categoria_Jsonclick ;
      private string edtnombre_actividad_Jsonclick ;
      private string edtunidad_medida_Jsonclick ;
      private string edtactividades_categoriaestado_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV62actividades_categoriaid_tipo_categoria_IsAuthorized ;
      private bool AV14Att_id_actividad_categoria_Visible ;
      private bool AV15Att_actividades_categoriaid_tipo_categoria_Visible ;
      private bool AV16Att_nombre_actividad_Visible ;
      private bool AV17Att_unidad_medida_Visible ;
      private bool AV18Att_actividades_categoriaestado_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n122actividades_categoriaid_tipo_categoria ;
      private bool n123nombre_actividad ;
      private bool n124unidad_medida ;
      private bool n125actividades_categoriaestado ;
      private bool bGXsfl_146_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV69fltnombre ;
      private string AV72Uri ;
      private string A123nombre_actividad ;
      private string A124unidad_medida ;
      private string lV69fltnombre ;
      private string AV40GridStateKey ;
      private string AV70OutFile ;
      private string imgFiltertoggle_combined_Bitmap ;
      private Guid AV71Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_id_actividad_categoria_visible ;
      private GXCheckbox chkavAtt_actividades_categoriaid_tipo_categoria_visible ;
      private GXCheckbox chkavAtt_nombre_actividad_visible ;
      private GXCheckbox chkavAtt_unidad_medida_visible ;
      private GXCheckbox chkavAtt_actividades_categoriaestado_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H00562_A125actividades_categoriaestado ;
      private bool[] H00562_n125actividades_categoriaestado ;
      private string[] H00562_A124unidad_medida ;
      private bool[] H00562_n124unidad_medida ;
      private string[] H00562_A123nombre_actividad ;
      private bool[] H00562_n123nombre_actividad ;
      private int[] H00562_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H00562_n122actividades_categoriaid_tipo_categoria ;
      private int[] H00562_A102id_actividad_categoria ;
      private long[] H00563_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV43ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV51K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV53FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV57GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV60Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV67ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV41GridState ;
      private SdtK2BGridState_FilterValue AV42GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV52K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV58GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV61Message ;
      private SdtK2BTrnContext AV65TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV68ActivityListItem ;
   }

   public class wwactividades_categoria__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00562( IGxContext context ,
                                             int AV44actividades_categoriaid_tipo_categoria ,
                                             string AV69fltnombre ,
                                             string AV55K2BToolsGenericSearchField ,
                                             int A122actividades_categoriaid_tipo_categoria ,
                                             string A123nombre_actividad ,
                                             int A102id_actividad_categoria ,
                                             string A124unidad_medida ,
                                             int A125actividades_categoriaestado ,
                                             short AV56OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [estado], [unidad_medida], [nombre_actividad], [id_tipo_categoria], [id_actividad_categoria]";
         sFromString = " FROM dbo.[actividades_categoria]";
         sOrderString = "";
         if ( ! (0==AV44actividades_categoriaid_tipo_categoria) )
         {
            AddWhere(sWhereString, "([id_tipo_categoria] = @AV44actividades_categoriaid_tipo_categoria)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69fltnombre)) )
         {
            AddWhere(sWhereString, "([nombre_actividad] like @lV69fltnombre)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_actividad_categoria] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%' or [nombre_actividad] like '%' + @lV55K2BToolsGenericSearchField + '%' or [unidad_medida] like '%' + @lV55K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
         }
         if ( AV56OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [id_actividad_categoria]";
         }
         else if ( AV56OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [id_actividad_categoria] DESC";
         }
         else if ( AV56OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [id_tipo_categoria]";
         }
         else if ( AV56OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [id_tipo_categoria] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [id_actividad_categoria]";
         }
         scmdbuf = "SELECT * FROM (SELECT " + sSelectString + ", ROW_NUMBER() OVER (" + sOrderString + " ) AS GX_ROW_NUMBER" + sFromString + sWhereString + "" + ") AS GX_CTE WHERE GX_ROW_NUMBER" + " >= " + "@GXPagingFrom2" + " AND GX_ROW_NUMBER <= (CASE WHEN (" + "@GXPagingTo2" + " < " + "@GXPagingFrom2" + ") THEN CAST(0x7FFFFFFFFFFFFFFF AS bigint) ELSE " + "@GXPagingTo2" + " END)";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00563( IGxContext context ,
                                             int AV44actividades_categoriaid_tipo_categoria ,
                                             string AV69fltnombre ,
                                             string AV55K2BToolsGenericSearchField ,
                                             int A122actividades_categoriaid_tipo_categoria ,
                                             string A123nombre_actividad ,
                                             int A102id_actividad_categoria ,
                                             string A124unidad_medida ,
                                             int A125actividades_categoriaestado ,
                                             short AV56OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[actividades_categoria]";
         if ( ! (0==AV44actividades_categoriaid_tipo_categoria) )
         {
            AddWhere(sWhereString, "([id_tipo_categoria] = @AV44actividades_categoriaid_tipo_categoria)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69fltnombre)) )
         {
            AddWhere(sWhereString, "([nombre_actividad] like @lV69fltnombre)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_actividad_categoria] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%' or [nombre_actividad] like '%' + @lV55K2BToolsGenericSearchField + '%' or [unidad_medida] like '%' + @lV55K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV55K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV56OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV56OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV56OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV56OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00562(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00563(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00562;
          prmH00562 = new Object[] {
          new ParDef("@AV44actividades_categoriaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@lV69fltnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00563;
          prmH00563 = new Object[] {
          new ParDef("@AV44actividades_categoriaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@lV69fltnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV55K2BToolsGenericSearchField",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00562,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00563", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00563,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
