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
   public class promptusuario : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public promptusuario( )
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

      public promptusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pUsuarioId )
      {
         this.AV17pUsuarioId = 0 ;
         executePrivate();
         aP0_pUsuarioId=this.AV17pUsuarioId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pUsuarioId");
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
               gxfirstwebparm = GetFirstPar( "pUsuarioId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pUsuarioId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_102 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_102"), "."));
               nGXsfl_102_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_102_idx"), "."));
               sGXsfl_102_idx = GetPar( "sGXsfl_102_idx");
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
               AV29K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV18UsuarioNombre = GetPar( "UsuarioNombre");
               AV20UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
               AV23UsuarioHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_From")));
               AV24UsuarioHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_To")));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV15ClassCollection);
               AV30OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV21UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
               AV40Pgmname = GetPar( "Pgmname");
               AV5CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV7GridConfiguration);
               AV17pUsuarioId = (long)(NumberUtil.Val( GetPar( "pUsuarioId"), "."));
               AV8FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV17pUsuarioId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV17pUsuarioId", StringUtil.LTrimStr( (decimal)(AV17pUsuarioId), 10, 0));
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
         PA302( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START302( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188361665", false, true);
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promptusuario.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pUsuarioId,10,0))}, new string[] {"pUsuarioId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV29K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIONOMBRE", AV18UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV20UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOHORA_FROM", context.localUtil.TToC( AV23UsuarioHora_From, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOHORA_TO", context.localUtil.TToC( AV24UsuarioHora_To, 10, 8, 0, 3, "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_102", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_102), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV27FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV27FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV28DeletedTag));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_TO", context.localUtil.DToC( AV21UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV32GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV32GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17pUsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV7GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV7GridConfiguration);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV15ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV15ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_FROM", context.localUtil.DToC( AV20UsuarioFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSUMMARYTAGSUC_Emptystatemessage", StringUtil.RTrim( Filtersummarytagsuc_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "K2BORDERBYUSERCONTROL_Gridcontrolname", StringUtil.RTrim( K2borderbyusercontrol_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
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
            WE302( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT302( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("promptusuario.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pUsuarioId,10,0))}, new string[] {"pUsuarioId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PromptUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seleccionar %1" ;
      }

      protected void WB300( )
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "PromptMainTable", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV29K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV29K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptUsuario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptUsuario.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV27FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV28DeletedTag);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV18UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV18UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptUsuario.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha Inicio:", "", "", lblTextblockusuariofecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_FilterDesc K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV20UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV21UsuarioFecha_To);
            ucUsuariofecha_daterangepicker.Render(context, "k2bdaterangepicker", Usuariofecha_daterangepicker_Internalname, "USUARIOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariohora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariohora_Internalname, "Hora Inicio:", "", "", lblTextblockusuariohora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_FilterDesc K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDaterangefiltermaintable_usuariohora_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariohora_from_Internalname, "Desde", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_102_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuariohora_from_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuariohora_from_Internalname, context.localUtil.TToC( AV23UsuarioHora_From, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV23UsuarioHora_From, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariohora_from_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuariohora_from_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PromptUsuario.htm");
            GxWebStd.gx_bitmap( context, edtavUsuariohora_from_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuariohora_from_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PromptUsuario.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDaterangeseparator_usuariohora_Internalname, "-", "", "", lblDaterangeseparator_usuariohora_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariohora_to_Internalname, "Hasta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_102_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuariohora_to_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuariohora_to_Internalname, context.localUtil.TToC( AV24UsuarioHora_To, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV24UsuarioHora_To, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariohora_to_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuariohora_to_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PromptUsuario.htm");
            GxWebStd.gx_bitmap( context, edtavUsuariohora_to_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuariohora_to_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PromptUsuario.htm");
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
            wb_table1_58_302( true) ;
         }
         else
         {
            wb_table1_58_302( false) ;
         }
         return  ;
      }

      protected void wb_table1_58_302e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"102\">") ;
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
               context.SendWebValue( "Id Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario:") ;
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
               context.SendWebValue( "Descripción del Requerimiento:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Email:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono:") ;
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
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioNombre_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A91UsuarioGerencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A89UsuarioEmail);
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
         if ( wbEnd == 102 )
         {
            wbEnd = 0;
            nRC_GXsfl_102 = (int)(nGXsfl_102_idx-1);
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
            wb_table2_114_302( true) ;
         }
         else
         {
            wb_table2_114_302( false) ;
         }
         return  ;
      }

      protected void wb_table2_114_302e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divK2btoolspagingcontainertable_Internalname, divK2btoolspagingcontainertable_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_PromptUsuario.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolsabstracthiddenitemsprompt_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV32GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV34UC_OrderedBy);
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
         if ( wbEnd == 102 )
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

      protected void START302( )
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
            Form.Meta.addItem("description", "Seleccionar %1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP300( ) ;
      }

      protected void WS302( )
      {
         START302( ) ;
         EVT302( ) ;
      }

      protected void EVT302( )
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
                              E11302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E13302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E14302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E15302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E16302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E17302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18302 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19302 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOSEARCH'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_102_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
                              SubsflControlProps_1022( ) ;
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtUsuarioHora_Internalname), 0));
                              A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
                              A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
                              A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
                              A89UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
                              A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E20302 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E21302 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV29K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV18UsuarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariofecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 0) != AV20UsuarioFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariohora_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOHORA_FROM"), 0) != AV23UsuarioHora_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariohora_to Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOHORA_TO"), 0) != AV24UsuarioHora_To )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E22302 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E23302 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24302 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOSEARCH'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSearch' */
                                    E25302 ();
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

      protected void WE302( )
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

      protected void PA302( )
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
         SubsflControlProps_1022( ) ;
         while ( nGXsfl_102_idx <= nRC_GXsfl_102 )
         {
            sendrow_1022( ) ;
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV29K2BToolsGenericSearchField ,
                                       string AV18UsuarioNombre ,
                                       DateTime AV20UsuarioFecha_From ,
                                       DateTime AV23UsuarioHora_From ,
                                       DateTime AV24UsuarioHora_To ,
                                       GxSimpleCollection<string> AV15ClassCollection ,
                                       short AV30OrderedBy ,
                                       DateTime AV21UsuarioFecha_To ,
                                       string AV40Pgmname ,
                                       int AV5CurrentPage ,
                                       SdtK2BGridConfiguration AV7GridConfiguration ,
                                       long AV17pUsuarioId ,
                                       bool AV8FreezeColumnTitles )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E21302 ();
         GRID_nCurrentRecord = 0;
         RF302( ) ;
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
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV9GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV9GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV8FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV8FreezeColumnTitles));
         AssignAttri("", false, "AV8FreezeColumnTitles", AV8FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E21302 ();
         RF302( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV40Pgmname = "PromptUsuario";
         context.Gx_err = 0;
      }

      protected void RF302( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 102;
         E23302 ();
         nGXsfl_102_idx = 1;
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         bGXsfl_102_Refreshing = true;
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
            SubsflControlProps_1022( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV18UsuarioNombre ,
                                                 AV21UsuarioFecha_To ,
                                                 AV20UsuarioFecha_From ,
                                                 AV24UsuarioHora_To ,
                                                 AV23UsuarioHora_From ,
                                                 AV29K2BToolsGenericSearchField ,
                                                 A93UsuarioNombre ,
                                                 A90UsuarioFecha ,
                                                 A92UsuarioHora ,
                                                 A91UsuarioGerencia ,
                                                 A88UsuarioDepartamento ,
                                                 A94UsuarioRequerimiento ,
                                                 A89UsuarioEmail ,
                                                 A95UsuarioTelefono ,
                                                 AV30OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            lV18UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV18UsuarioNombre), "%", "");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H00302 */
            pr_default.execute(0, new Object[] {lV18UsuarioNombre, AV21UsuarioFecha_To, AV20UsuarioFecha_From, AV24UsuarioHora_To, AV23UsuarioHora_From, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_102_idx = 1;
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A95UsuarioTelefono = H00302_A95UsuarioTelefono[0];
               A89UsuarioEmail = H00302_A89UsuarioEmail[0];
               A94UsuarioRequerimiento = H00302_A94UsuarioRequerimiento[0];
               A88UsuarioDepartamento = H00302_A88UsuarioDepartamento[0];
               A91UsuarioGerencia = H00302_A91UsuarioGerencia[0];
               A92UsuarioHora = H00302_A92UsuarioHora[0];
               A90UsuarioFecha = H00302_A90UsuarioFecha[0];
               A93UsuarioNombre = H00302_A93UsuarioNombre[0];
               A15UsuarioId = H00302_A15UsuarioId[0];
               E24302 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 102;
            WB300( ) ;
         }
         bGXsfl_102_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes302( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_102_idx, GetSecureSignedToken( sGXsfl_102_idx, context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"), context));
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
                                              AV18UsuarioNombre ,
                                              AV21UsuarioFecha_To ,
                                              AV20UsuarioFecha_From ,
                                              AV24UsuarioHora_To ,
                                              AV23UsuarioHora_From ,
                                              AV29K2BToolsGenericSearchField ,
                                              A93UsuarioNombre ,
                                              A90UsuarioFecha ,
                                              A92UsuarioHora ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A94UsuarioRequerimiento ,
                                              A89UsuarioEmail ,
                                              A95UsuarioTelefono ,
                                              AV30OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV18UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV18UsuarioNombre), "%", "");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         lV29K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV29K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H00303 */
         pr_default.execute(1, new Object[] {lV18UsuarioNombre, AV21UsuarioFecha_To, AV20UsuarioFecha_From, AV24UsuarioHora_To, AV23UsuarioHora_From, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField, lV29K2BToolsGenericSearchField});
         GRID_nRecordCount = H00303_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV40Pgmname = "PromptUsuario";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP300( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E20302 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV27FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV32GridOrders);
            /* Read saved values. */
            nRC_GXsfl_102 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_102"), ".", ","));
            AV28DeletedTag = cgiGet( "vDELETEDTAG");
            AV20UsuarioFecha_From = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_FROM"), 0);
            AV21UsuarioFecha_To = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_TO"), 0);
            AV34UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV29K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV29K2BToolsGenericSearchField", AV29K2BToolsGenericSearchField);
            AV18UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV18UsuarioNombre", AV18UsuarioNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuariohora_from_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Usuario Hora_From"}), 1, "vUSUARIOHORA_FROM");
               GX_FocusControl = edtavUsuariohora_from_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23UsuarioHora_From = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV23UsuarioHora_From", context.localUtil.TToC( AV23UsuarioHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV23UsuarioHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavUsuariohora_from_Internalname)));
               AssignAttri("", false, "AV23UsuarioHora_From", context.localUtil.TToC( AV23UsuarioHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavUsuariohora_to_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Usuario Hora_To"}), 1, "vUSUARIOHORA_TO");
               GX_FocusControl = edtavUsuariohora_to_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24UsuarioHora_To = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV24UsuarioHora_To", context.localUtil.TToC( AV24UsuarioHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV24UsuarioHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavUsuariohora_to_Internalname)));
               AssignAttri("", false, "AV24UsuarioHora_To", context.localUtil.TToC( AV24UsuarioHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV9GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV9GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
            AV8FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV8FreezeColumnTitles", AV8FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV29K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIONOMBRE"), AV18UsuarioNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV20UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOHORA_FROM")) != AV23UsuarioHora_From )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOHORA_TO")) != AV24UsuarioHora_To )
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
         E20302 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20302( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         AV36ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV37ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV37ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV37ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV37ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV37ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV37ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV40Pgmname;
         AV36ActivityList.Add(AV37ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV36ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV36ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV16Context) ;
         AV18UsuarioNombre = "";
         AssignAttri("", false, "AV18UsuarioNombre", AV18UsuarioNombre);
         AV19UsuarioFecha = DateTime.MinValue;
         AV20UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV20UsuarioFecha_From", context.localUtil.Format(AV20UsuarioFecha_From, "99/99/9999"));
         AV21UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV21UsuarioFecha_To", context.localUtil.Format(AV21UsuarioFecha_To, "99/99/9999"));
         AV22UsuarioHora = (DateTime)(DateTime.MinValue);
         AV23UsuarioHora_From = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.ServerDate( context, pr_default) , - ( (int)(30) )) ) ;
         AssignAttri("", false, "AV23UsuarioHora_From", context.localUtil.TToC( AV23UsuarioHora_From, 0, 5, 0, 3, "/", ":", " "));
         AV24UsuarioHora_To = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV24UsuarioHora_To", context.localUtil.TToC( AV24UsuarioHora_To, 0, 5, 0, 3, "/", ":", " "));
         new k2bloadrowsperpage(context ).execute(  AV40Pgmname,  "Grid", out  AV10RowsPerPageVariable, out  AV11RowsPerPageLoaded) ;
         AssignAttri("", false, "AV10RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV10RowsPerPageVariable), 4, 0));
         if ( ! AV11RowsPerPageLoaded )
         {
            AV10RowsPerPageVariable = 20;
            AssignAttri("", false, "AV10RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV10RowsPerPageVariable), 4, 0));
         }
         AV9GridSettingsRowsPerPageVariable = AV10RowsPerPageVariable;
         AssignAttri("", false, "AV9GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV10RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = StringUtil.Format( "Seleccionar %1", "Usuario", "", "", "", "", "", "", "", "");
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
         AV32GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV33GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV33GridOrder.gxTpr_Ascendingorder = 0;
         AV33GridOrder.gxTpr_Descendingorder = 1;
         AV33GridOrder.gxTpr_Gridcolumnindex = 1;
         AV32GridOrders.Add(AV33GridOrder, 0);
         AV33GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV33GridOrder.gxTpr_Ascendingorder = 2;
         AV33GridOrder.gxTpr_Descendingorder = 3;
         AV33GridOrder.gxTpr_Gridcolumnindex = 2;
         AV32GridOrders.Add(AV33GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E21302( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E22302 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22302( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV17pUsuarioId = A15UsuarioId;
         AssignAttri("", false, "AV17pUsuarioId", StringUtil.LTrimStr( (decimal)(AV17pUsuarioId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV17pUsuarioId});
         context.setWebReturnParmsMetadata(new Object[] {"AV17pUsuarioId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E23302( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV15ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV16Context) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV34UC_OrderedBy = AV30OrderedBy;
         AssignAttri("", false, "AV34UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV34UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S132 ();
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
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV15ClassCollection,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27FilterTags", AV27FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
      }

      private void E24302( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 102;
         }
         sendrow_1022( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_102_Refreshing )
         {
            context.DoAjaxLoad(102, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E25302( )
      {
         /* 'DoSearch' Routine */
         returnInSub = false;
         AV5CurrentPage = 1;
         AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pUsuarioId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV30OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV30OrderedBy", StringUtil.LTrimStr( (decimal)(AV30OrderedBy), 4, 0));
         AV34UC_OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV34UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV34UC_OrderedBy), 4, 0));
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioNombre") == 0 )
            {
               AV18UsuarioNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18UsuarioNombre", AV18UsuarioNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV20UsuarioFecha_From = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV20UsuarioFecha_From", context.localUtil.Format(AV20UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV21UsuarioFecha_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV21UsuarioFecha_To", context.localUtil.Format(AV21UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioHora:From") == 0 )
            {
               AV23UsuarioHora_From = DateTimeUtil.ResetDate(context.localUtil.CToT( AV14GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV23UsuarioHora_From", context.localUtil.TToC( AV23UsuarioHora_From, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioHora:To") == 0 )
            {
               AV24UsuarioHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV14GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV24UsuarioHora_To", context.localUtil.TToC( AV24UsuarioHora_To, 0, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV29K2BToolsGenericSearchField = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29K2BToolsGenericSearchField", AV29K2BToolsGenericSearchField);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
         AV6K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV13GridState.gxTpr_Currentpage > 0 ) && ( AV13GridState.gxTpr_Currentpage <= AV6K2BMaxPages ) )
         {
            AV5CurrentPage = AV13GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_gotopage( AV5CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pUsuarioId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(AV5CurrentPage);
         AV13GridState.gxTpr_Orderedby = AV30OrderedBy;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV18UsuarioNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:From";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV20UsuarioFecha_From, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:To";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV21UsuarioFecha_To, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioHora:From";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV23UsuarioHora_From, "99:99");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioHora:To";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV24UsuarioHora_To, "99:99");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV14GridStateFilterValue.gxTpr_Value = AV29K2BToolsGenericSearchField;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV40Pgmname,  AV12GridStateKey,  AV13GridState) ;
      }

      protected void S152( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV6K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV5CurrentPage > AV6K2BMaxPages ) && ( AV6K2BMaxPages > 0 ) )
         {
            AV5CurrentPage = AV6K2BMaxPages;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefresh();
         }
         if ( AV6K2BMaxPages == 0 )
         {
            AV5CurrentPage = 1;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
         }
         else
         {
            AV5CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp("", false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV5CurrentPage-1), 10, 0);
         AssignProp("", false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV5CurrentPage), 5, 0);
         AssignProp("", false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV5CurrentPage+1), 10, 0);
         AssignProp("", false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV6K2BMaxPages), 6, 0);
         AssignProp("", false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV5CurrentPage) || ( AV5CurrentPage <= 1 ) )
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
            if ( AV5CurrentPage == 2 )
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
               if ( AV5CurrentPage == 3 )
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
         if ( AV5CurrentPage == AV6K2BMaxPages )
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
            if ( AV5CurrentPage == AV6K2BMaxPages - 1 )
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
               if ( AV5CurrentPage == AV6K2BMaxPages - 2 )
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
         if ( ( AV5CurrentPage <= 1 ) && ( AV6K2BMaxPages <= 1 ) )
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

      protected void E13302( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV5CurrentPage = 1;
         AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E14302( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV5CurrentPage > 1 )
         {
            AV5CurrentPage = (int)(AV5CurrentPage-1);
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E15302( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV6K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV5CurrentPage != AV6K2BMaxPages )
         {
            AV5CurrentPage = (int)(AV5CurrentPage+1);
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_nextpage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E16302( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV6K2BMaxPages = subGrid_fnc_Pagecount( );
         AV5CurrentPage = AV6K2BMaxPages;
         AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void S132( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV40Pgmname,  "Grid", ref  AV7GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S162( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV8FreezeColumnTitles = AV7GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV8FreezeColumnTitles", AV8FreezeColumnTitles);
         if ( AV8FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV15ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV15ClassCollection) ;
         }
      }

      protected void E17302( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         AV7GridConfiguration.gxTpr_Freezecolumntitles = AV8FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV40Pgmname,  "Grid",  AV7GridConfiguration,  true) ;
         AV34UC_OrderedBy = AV30OrderedBy;
         AssignAttri("", false, "AV34UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV34UC_OrderedBy), 4, 0));
         if ( AV10RowsPerPageVariable != AV9GridSettingsRowsPerPageVariable )
         {
            AV10RowsPerPageVariable = AV9GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV10RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV10RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV10RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV40Pgmname,  "Grid",  AV10RowsPerPageVariable) ;
            AV5CurrentPage = 1;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void S142( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV25K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuarioNombre)) )
         {
            AV26K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV26K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioNombre";
            AV26K2BFilterValuesSDTItem.gxTpr_Description = "Usuario:";
            AV26K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV26K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV26K2BFilterValuesSDTItem.gxTpr_Value = AV18UsuarioNombre;
            AV26K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV18UsuarioNombre;
            AV25K2BFilterValuesSDT.Add(AV26K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV20UsuarioFecha_From) || ! (DateTime.MinValue==AV21UsuarioFecha_To) )
         {
            AV26K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV26K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV26K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Inicio:";
            AV26K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV26K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV26K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime2 = DateTimeUtil.ResetTime( AV20UsuarioFecha_From ) ;
            AV26K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime2;
            GXt_dtime2 = DateTimeUtil.ResetTime( AV21UsuarioFecha_To ) ;
            AV26K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime2;
            AV25K2BFilterValuesSDT.Add(AV26K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV23UsuarioHora_From) || ! (DateTime.MinValue==AV24UsuarioHora_To) )
         {
            AV26K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV26K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioHora";
            AV26K2BFilterValuesSDTItem.gxTpr_Description = "Hora Inicio:";
            AV26K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV26K2BFilterValuesSDTItem.gxTpr_Type = "DateTimeRange";
            AV26K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            AV26K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = AV23UsuarioHora_From;
            AV26K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = AV24UsuarioHora_To;
            AV25K2BFilterValuesSDT.Add(AV26K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV25K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV27FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV40Pgmname,  "Grid",  AV25K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV27FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E11302( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28DeletedTag, "UsuarioNombre") == 0 )
         {
            AV18UsuarioNombre = "";
            AssignAttri("", false, "AV18UsuarioNombre", AV18UsuarioNombre);
         }
         else if ( StringUtil.StrCmp(AV28DeletedTag, "UsuarioFecha") == 0 )
         {
            AV20UsuarioFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV20UsuarioFecha_From", context.localUtil.Format(AV20UsuarioFecha_From, "99/99/9999"));
            AV21UsuarioFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV21UsuarioFecha_To", context.localUtil.Format(AV21UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV28DeletedTag, "UsuarioHora") == 0 )
         {
            AV23UsuarioHora_From = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV23UsuarioHora_From", context.localUtil.TToC( AV23UsuarioHora_From, 0, 5, 0, 3, "/", ":", " "));
            AV24UsuarioHora_To = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV24UsuarioHora_To", context.localUtil.TToC( AV24UsuarioHora_To, 0, 5, 0, 3, "/", ":", " "));
         }
         gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E12302( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV30OrderedBy = AV34UC_OrderedBy;
         AssignAttri("", false, "AV30OrderedBy", StringUtil.LTrimStr( (decimal)(AV30OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV29K2BToolsGenericSearchField, AV18UsuarioNombre, AV20UsuarioFecha_From, AV23UsuarioHora_From, AV24UsuarioHora_To, AV15ClassCollection, AV30OrderedBy, AV21UsuarioFecha_To, AV40Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pUsuarioId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E18302( )
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

      protected void E19302( )
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

      protected void wb_table2_114_302( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_114_302e( true) ;
         }
         else
         {
            wb_table2_114_302e( false) ;
         }
      }

      protected void wb_table1_58_302( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e26301_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptUsuario.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_PromptUsuario.htm");
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
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpagevariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 1, "HLP_PromptUsuario.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_102_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV8FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(90, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromptUsuario.htm");
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
            wb_table1_58_302e( true) ;
         }
         else
         {
            wb_table1_58_302e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17pUsuarioId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV17pUsuarioId", StringUtil.LTrimStr( (decimal)(AV17pUsuarioId), 10, 0));
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
         PA302( ) ;
         WS302( ) ;
         WE302( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188362052", true, true);
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
         context.AddJavascriptSource("promptusuario.js", "?2024188362052", false, true);
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

      protected void SubsflControlProps_1022( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_102_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_102_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_102_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_102_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_102_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_102_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_102_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_102_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_102_idx;
      }

      protected void SubsflControlProps_fel_1022( )
      {
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_102_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_102_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_102_fel_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_102_fel_idx;
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA_"+sGXsfl_102_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_102_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_102_fel_idx;
         edtUsuarioEmail_Internalname = "USUARIOEMAIL_"+sGXsfl_102_fel_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_102_fel_idx;
      }

      protected void sendrow_1022( )
      {
         SubsflControlProps_1022( ) ;
         WB300( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_102_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_102_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_102_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            edtUsuarioNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, !bGXsfl_102_Refreshing);
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioHora_Internalname,context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A92UsuarioHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioGerencia_Internalname,(string)A91UsuarioGerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioGerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioEmail_Internalname,(string)A89UsuarioEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A89UsuarioEmail,(string)"",(string)"",(string)"",(string)edtUsuarioEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefono_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)102,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes302( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         /* End function sendrow_1022 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV9GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV9GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV8FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV8FreezeColumnTitles));
         AssignAttri("", false, "AV8FreezeColumnTitles", AV8FreezeColumnTitles);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
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
         lblTextblockusuariohora_Internalname = "TEXTBLOCKUSUARIOHORA";
         edtavUsuariohora_from_Internalname = "vUSUARIOHORA_FROM";
         lblDaterangeseparator_usuariohora_Internalname = "DATERANGESEPARATOR_USUARIOHORA";
         edtavUsuariohora_to_Internalname = "vUSUARIOHORA_TO";
         divDaterangefiltermaintable_usuariohora_Internalname = "DATERANGEFILTERMAINTABLE_USUARIOHORA";
         divK2btoolstable_attributecontainerusuariohora_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOHORA";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
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
         tblTable5_Internalname = "TABLE5";
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
         divTable4_Internalname = "TABLE4";
         divTable3_Internalname = "TABLE3";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divTable2_Internalname = "TABLE2";
         K2borderbyusercontrol_Internalname = "K2BORDERBYUSERCONTROL";
         divK2btoolsabstracthiddenitemsprompt_Internalname = "K2BTOOLSABSTRACTHIDDENITEMSPROMPT";
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
         edtUsuarioTelefono_Jsonclick = "";
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioRequerimiento_Jsonclick = "";
         edtUsuarioDepartamento_Jsonclick = "";
         edtUsuarioGerencia_Jsonclick = "";
         edtUsuarioHora_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         tblNoresultsfoundtable_Visible = 1;
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
         edtUsuarioNombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavUsuariohora_to_Jsonclick = "";
         edtavUsuariohora_to_Enabled = 1;
         edtavUsuariohora_from_Jsonclick = "";
         edtavUsuariohora_from_Enabled = 1;
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
         Form.Caption = "Seleccionar %1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E22302',iparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E23302',iparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV34UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV27FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E24302',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOSEARCH'","{handler:'E25302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOSEARCH'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E13302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E14302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E15302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E16302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E26301',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E17302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV9GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV34UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E11302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV28DeletedTag',fld:'vDELETEDTAG',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E12302',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV29K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV18UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV20UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioHora_From',fld:'vUSUARIOHORA_FROM',pic:'99:99'},{av:'AV24UsuarioHora_To',fld:'vUSUARIOHORA_TO',pic:'99:99'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV21UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV34UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E18302',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E19302',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariotelefono',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV29K2BToolsGenericSearchField = "";
         AV18UsuarioNombre = "";
         AV20UsuarioFecha_From = DateTime.MinValue;
         AV23UsuarioHora_From = (DateTime)(DateTime.MinValue);
         AV24UsuarioHora_To = (DateTime)(DateTime.MinValue);
         AV15ClassCollection = new GxSimpleCollection<string>();
         AV21UsuarioFecha_To = DateTime.MinValue;
         AV40Pgmname = "";
         AV7GridConfiguration = new SdtK2BGridConfiguration(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV28DeletedTag = "";
         AV32GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         Filtersummarytagsuc_Emptystatemessage = "";
         K2borderbyusercontrol_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgFiltertoggle_combined_Jsonclick = "";
         ucFiltersummarytagsuc = new GXUserControl();
         imgFilterclose_combined_Jsonclick = "";
         lblTextblockusuariofecha_Jsonclick = "";
         ucUsuariofecha_daterangepicker = new GXUserControl();
         lblTextblockusuariohora_Jsonclick = "";
         lblDaterangeseparator_usuariohora_Jsonclick = "";
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
         lV18UsuarioNombre = "";
         lV29K2BToolsGenericSearchField = "";
         H00302_A95UsuarioTelefono = new int[1] ;
         H00302_A89UsuarioEmail = new string[] {""} ;
         H00302_A94UsuarioRequerimiento = new string[] {""} ;
         H00302_A88UsuarioDepartamento = new string[] {""} ;
         H00302_A91UsuarioGerencia = new string[] {""} ;
         H00302_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         H00302_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H00302_A93UsuarioNombre = new string[] {""} ;
         H00302_A15UsuarioId = new long[1] ;
         H00303_AGRID_nRecordCount = new long[1] ;
         AV36ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV37ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV16Context = new SdtK2BContext(context);
         AV19UsuarioFecha = DateTime.MinValue;
         AV22UsuarioHora = (DateTime)(DateTime.MinValue);
         AV33GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         GXt_char1 = "";
         GridRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV25K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV26K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promptusuario__default(),
            new Object[][] {
                new Object[] {
               H00302_A95UsuarioTelefono, H00302_A89UsuarioEmail, H00302_A94UsuarioRequerimiento, H00302_A88UsuarioDepartamento, H00302_A91UsuarioGerencia, H00302_A92UsuarioHora, H00302_A90UsuarioFecha, H00302_A93UsuarioNombre, H00302_A15UsuarioId
               }
               , new Object[] {
               H00303_AGRID_nRecordCount
               }
            }
         );
         AV40Pgmname = "PromptUsuario";
         /* GeneXus formulas. */
         AV40Pgmname = "PromptUsuario";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV30OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV34UC_OrderedBy ;
      private short AV10RowsPerPageVariable ;
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
      private short AV9GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_102 ;
      private int nGXsfl_102_idx=1 ;
      private int subGrid_Rows ;
      private int AV5CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariohora_from_Enabled ;
      private int edtavUsuariohora_to_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A95UsuarioTelefono ;
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
      private int tblNoresultsfoundtable_Visible ;
      private int AV41GXV1 ;
      private int AV6K2BMaxPages ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long AV17pUsuarioId ;
      private long GRID_nFirstRecordOnPage ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_102_idx="0001" ;
      private string AV29K2BToolsGenericSearchField ;
      private string AV40Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV28DeletedTag ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string K2borderbyusercontrol_Gridcontrolname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divGlobalgridtable_Internalname ;
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
      private string divK2btoolstable_attributecontainerusuariohora_Internalname ;
      private string lblTextblockusuariohora_Internalname ;
      private string lblTextblockusuariohora_Jsonclick ;
      private string divDaterangefiltermaintable_usuariohora_Internalname ;
      private string edtavUsuariohora_from_Internalname ;
      private string edtavUsuariohora_from_Jsonclick ;
      private string lblDaterangeseparator_usuariohora_Internalname ;
      private string lblDaterangeseparator_usuariohora_Jsonclick ;
      private string edtavUsuariohora_to_Internalname ;
      private string edtavUsuariohora_to_Jsonclick ;
      private string divTable3_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtUsuarioNombre_Link ;
      private string divTable4_Internalname ;
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
      private string divK2btoolsabstracthiddenitemsprompt_Internalname ;
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
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV29K2BToolsGenericSearchField ;
      private string chkavFreezecolumntitles_Internalname ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string tblNoresultsfoundtable_Internalname ;
      private string GXt_char1 ;
      private string lblNoresultsfoundtextblock_Internalname ;
      private string lblNoresultsfoundtextblock_Jsonclick ;
      private string tblTable5_Internalname ;
      private string divK2bgridsettingstable_Internalname ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string sGXsfl_102_fel_idx="0001" ;
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
      private DateTime AV23UsuarioHora_From ;
      private DateTime AV24UsuarioHora_To ;
      private DateTime A92UsuarioHora ;
      private DateTime AV22UsuarioHora ;
      private DateTime GXt_dtime2 ;
      private DateTime AV20UsuarioFecha_From ;
      private DateTime AV21UsuarioFecha_To ;
      private DateTime A90UsuarioFecha ;
      private DateTime AV19UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_102_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV18UsuarioNombre ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private string lV18UsuarioNombre ;
      private string AV12GridStateKey ;
      private string imgFiltertoggle_combined_Bitmap ;
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
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private int[] H00302_A95UsuarioTelefono ;
      private string[] H00302_A89UsuarioEmail ;
      private string[] H00302_A94UsuarioRequerimiento ;
      private string[] H00302_A88UsuarioDepartamento ;
      private string[] H00302_A91UsuarioGerencia ;
      private DateTime[] H00302_A92UsuarioHora ;
      private DateTime[] H00302_A90UsuarioFecha ;
      private string[] H00302_A93UsuarioNombre ;
      private long[] H00302_A15UsuarioId ;
      private long[] H00303_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pUsuarioId ;
      private GxSimpleCollection<string> AV15ClassCollection ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV25K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV27FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV32GridOrders ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV36ActivityList ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV7GridConfiguration ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtK2BContext AV16Context ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV26K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV33GridOrder ;
      private SdtK2BActivityList_K2BActivityListItem AV37ActivityListItem ;
   }

   public class promptusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00302( IGxContext context ,
                                             string AV18UsuarioNombre ,
                                             DateTime AV21UsuarioFecha_To ,
                                             DateTime AV20UsuarioFecha_From ,
                                             DateTime AV24UsuarioHora_To ,
                                             DateTime AV23UsuarioHora_From ,
                                             string AV29K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV30OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [UsuarioTelefono], [UsuarioEmail], [UsuarioRequerimiento], [UsuarioDepartamento], [UsuarioGerencia], [UsuarioHora], [UsuarioFecha], [UsuarioNombre], [UsuarioId]";
         sFromString = " FROM [Usuario]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV18UsuarioNombre)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV21UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV21UsuarioFecha_To)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV20UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV20UsuarioFecha_From)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV24UsuarioHora_To) )
         {
            AddWhere(sWhereString, "([UsuarioHora] <= @AV24UsuarioHora_To)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV23UsuarioHora_From) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV23UsuarioHora_From)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV29K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV29K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
            GXv_int4[9] = 1;
            GXv_int4[10] = 1;
         }
         if ( AV30OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [UsuarioId]";
         }
         else if ( AV30OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [UsuarioId] DESC";
         }
         else if ( AV30OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [UsuarioNombre]";
         }
         else if ( AV30OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [UsuarioNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [UsuarioId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00303( IGxContext context ,
                                             string AV18UsuarioNombre ,
                                             DateTime AV21UsuarioFecha_To ,
                                             DateTime AV20UsuarioFecha_From ,
                                             DateTime AV24UsuarioHora_To ,
                                             DateTime AV23UsuarioHora_From ,
                                             string AV29K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV30OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[11];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Usuario]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV18UsuarioNombre)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV21UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV21UsuarioFecha_To)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV20UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV20UsuarioFecha_From)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV24UsuarioHora_To) )
         {
            AddWhere(sWhereString, "([UsuarioHora] <= @AV24UsuarioHora_To)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV23UsuarioHora_From) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV23UsuarioHora_From)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV29K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV29K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV29K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
            GXv_int6[9] = 1;
            GXv_int6[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV30OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV30OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV30OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV30OrderedBy == 3 )
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
                     return conditional_H00302(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] );
               case 1 :
                     return conditional_H00303(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] );
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
          Object[] prmH00302;
          prmH00302 = new Object[] {
          new ParDef("@lV18UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV21UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV20UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV24UsuarioHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV23UsuarioHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00303;
          prmH00303 = new Object[] {
          new ParDef("@lV18UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV21UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV20UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV24UsuarioHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV23UsuarioHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV29K2BToolsGenericSearchField",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00302", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00302,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00303", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00303,1, GxCacheFrequency.OFF ,true,false )
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
