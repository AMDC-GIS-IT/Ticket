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
   public class prompttickettecnico : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public prompttickettecnico( )
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

      public prompttickettecnico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pTicketTecnicoId )
      {
         this.AV17pTicketTecnicoId = 0 ;
         executePrivate();
         aP0_pTicketTecnicoId=this.AV17pTicketTecnicoId;
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
            gxfirstwebparm = GetFirstPar( "pTicketTecnicoId");
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
               gxfirstwebparm = GetFirstPar( "pTicketTecnicoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pTicketTecnicoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_87 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_87"), "."));
               nGXsfl_87_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_87_idx"), "."));
               sGXsfl_87_idx = GetPar( "sGXsfl_87_idx");
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
               AV28K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV39flResponsable = GetPar( "flResponsable");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV15ClassCollection);
               AV29OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV42Pgmname = GetPar( "Pgmname");
               AV5CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV7GridConfiguration);
               AV17pTicketTecnicoId = (long)(NumberUtil.Val( GetPar( "pTicketTecnicoId"), "."));
               AV8FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
               AV17pTicketTecnicoId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV17pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV17pTicketTecnicoId), 10, 0));
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
         PA4U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4U2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188204432", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("prompttickettecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pTicketTecnicoId,10,0))}, new string[] {"pTicketTecnicoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV28K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vFLRESPONSABLE", AV39flResponsable);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_87", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_87), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV26FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV26FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV27DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV31GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV31GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17pTicketTecnicoId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29OrderedBy), 4, 0, ".", "")));
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
            WE4U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4U2( ) ;
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
         return formatLink("prompttickettecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pTicketTecnicoId,10,0))}, new string[] {"pTicketTecnicoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PromptTicketTecnico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seleccionar %1" ;
      }

      protected void WB4U0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_87_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV28K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV28K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptTicketTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptTicketTecnico.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV26FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV27DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptTicketTecnico.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerflresponsable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFlresponsable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFlresponsable_Internalname, "Técnico", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_87_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFlresponsable_Internalname, AV39flResponsable, StringUtil.RTrim( context.localUtil.Format( AV39flResponsable, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFlresponsable_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFlresponsable_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptTicketTecnico.htm");
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
            wb_table1_43_4U2( true) ;
         }
         else
         {
            wb_table1_43_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_4U2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"87\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(86), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Ticket Tecnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Técnico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Técnico") ;
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
               context.SendWebValue( "Departamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
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
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTicketTecnicoFecha_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A30ResponsableNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88UsuarioDepartamento);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A74TicketTecnicoInventarioSerie);
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
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 87 )
         {
            wbEnd = 0;
            nRC_GXsfl_87 = (int)(nGXsfl_87_idx-1);
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
            wb_table2_126_4U2( true) ;
         }
         else
         {
            wb_table2_126_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_126_4U2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV31GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV33UC_OrderedBy);
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
         if ( wbEnd == 87 )
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

      protected void START4U2( )
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
         STRUP4U0( ) ;
      }

      protected void WS4U2( )
      {
         START4U2( ) ;
         EVT4U2( ) ;
      }

      protected void EVT4U2( )
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
                              E114U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E134U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E144U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E154U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E164U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E174U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E184U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E194U2 ();
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
                              nGXsfl_87_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
                              SubsflControlProps_872( ) ;
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
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E204U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E214U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV28K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Flresponsable Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFLRESPONSABLE"), AV39flResponsable) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E224U2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E234U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E244U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOSEARCH'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSearch' */
                                    E254U2 ();
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

      protected void WE4U2( )
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

      protected void PA4U2( )
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
         SubsflControlProps_872( ) ;
         while ( nGXsfl_87_idx <= nRC_GXsfl_87 )
         {
            sendrow_872( ) ;
            nGXsfl_87_idx = ((subGrid_Islastpage==1)&&(nGXsfl_87_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_87_idx+1);
            sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
            SubsflControlProps_872( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV28K2BToolsGenericSearchField ,
                                       string AV39flResponsable ,
                                       GxSimpleCollection<string> AV15ClassCollection ,
                                       short AV29OrderedBy ,
                                       string AV42Pgmname ,
                                       int AV5CurrentPage ,
                                       SdtK2BGridConfiguration AV7GridConfiguration ,
                                       long AV17pTicketTecnicoId ,
                                       bool AV8FreezeColumnTitles )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E214U2 ();
         GRID_nCurrentRecord = 0;
         RF4U2( ) ;
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
         E214U2 ();
         RF4U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV42Pgmname = "PromptTicketTecnico";
         context.Gx_err = 0;
      }

      protected void RF4U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 87;
         E234U2 ();
         nGXsfl_87_idx = 1;
         sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
         SubsflControlProps_872( ) ;
         bGXsfl_87_Refreshing = true;
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
            SubsflControlProps_872( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV39flResponsable ,
                                                 AV28K2BToolsGenericSearchField ,
                                                 A30ResponsableNombre ,
                                                 A18TicketTecnicoId ,
                                                 A14TicketId ,
                                                 A6ResponsableId ,
                                                 A93UsuarioNombre ,
                                                 A94UsuarioRequerimiento ,
                                                 A88UsuarioDepartamento ,
                                                 A74TicketTecnicoInventarioSerie ,
                                                 AV29OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV39flResponsable = StringUtil.Concat( StringUtil.RTrim( AV39flResponsable), "%", "");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H004U2 */
            pr_default.execute(0, new Object[] {lV39flResponsable, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_87_idx = 1;
            sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
            SubsflControlProps_872( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A97TicketTecnicoDetalle = H004U2_A97TicketTecnicoDetalle[0];
               A77TicketTecnicoObservacion = H004U2_A77TicketTecnicoObservacion[0];
               n77TicketTecnicoObservacion = H004U2_n77TicketTecnicoObservacion[0];
               A79TicketTecnicoPasaTaller = H004U2_A79TicketTecnicoPasaTaller[0];
               A80TicketTecnicoPendiente = H004U2_A80TicketTecnicoPendiente[0];
               A65TicketTecnicoCerrado = H004U2_A65TicketTecnicoCerrado[0];
               A78TicketTecnicoOtrosTaller = H004U2_A78TicketTecnicoOtrosTaller[0];
               A61TicketTecnicoCableEspecial = H004U2_A61TicketTecnicoCableEspecial[0];
               A64TicketTecnicoCDsDVDs = H004U2_A64TicketTecnicoCDsDVDs[0];
               A63TicketTecnicoCargadorLaptop = H004U2_A63TicketTecnicoCargadorLaptop[0];
               A85TicketTecnicoTarjetaVideoExtra = H004U2_A85TicketTecnicoTarjetaVideoExtra[0];
               A86TicketTecnicoTonerCinta = H004U2_A86TicketTecnicoTonerCinta[0];
               A76TicketTecnicoMaletin = H004U2_A76TicketTecnicoMaletin[0];
               A81TicketTecnicoProcesador = H004U2_A81TicketTecnicoProcesador[0];
               A68TicketTecnicoDiscoDuro = H004U2_A68TicketTecnicoDiscoDuro[0];
               A83TicketTecnicoRam = H004U2_A83TicketTecnicoRam[0];
               A67TicketTecnicoCopiasRespaldo = H004U2_A67TicketTecnicoCopiasRespaldo[0];
               A62TicketTecnicoCambiosHardware = H004U2_A62TicketTecnicoCambiosHardware[0];
               A82TicketTecnicoPuntoRed = H004U2_A82TicketTecnicoPuntoRed[0];
               A75TicketTecnicoLimpieza = H004U2_A75TicketTecnicoLimpieza[0];
               A84TicketTecnicoReparacion = H004U2_A84TicketTecnicoReparacion[0];
               A70TicketTecnicoFormateo = H004U2_A70TicketTecnicoFormateo[0];
               A73TicketTecnicoInternetRouter = H004U2_A73TicketTecnicoInternetRouter[0];
               A66TicketTecnicoConfiguracion = H004U2_A66TicketTecnicoConfiguracion[0];
               A72TicketTecnicoInstalacion = H004U2_A72TicketTecnicoInstalacion[0];
               A74TicketTecnicoInventarioSerie = H004U2_A74TicketTecnicoInventarioSerie[0];
               A88UsuarioDepartamento = H004U2_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H004U2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H004U2_A93UsuarioNombre[0];
               A15UsuarioId = H004U2_A15UsuarioId[0];
               A30ResponsableNombre = H004U2_A30ResponsableNombre[0];
               A6ResponsableId = H004U2_A6ResponsableId[0];
               A16TicketResponsableId = H004U2_A16TicketResponsableId[0];
               A14TicketId = H004U2_A14TicketId[0];
               A71TicketTecnicoHora = H004U2_A71TicketTecnicoHora[0];
               A69TicketTecnicoFecha = H004U2_A69TicketTecnicoFecha[0];
               A18TicketTecnicoId = H004U2_A18TicketTecnicoId[0];
               A30ResponsableNombre = H004U2_A30ResponsableNombre[0];
               A15UsuarioId = H004U2_A15UsuarioId[0];
               A88UsuarioDepartamento = H004U2_A88UsuarioDepartamento[0];
               A94UsuarioRequerimiento = H004U2_A94UsuarioRequerimiento[0];
               A93UsuarioNombre = H004U2_A93UsuarioNombre[0];
               E244U2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 87;
            WB4U0( ) ;
         }
         bGXsfl_87_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV42Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICOID"+"_"+sGXsfl_87_idx, GetSecureSignedToken( sGXsfl_87_idx, context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9"), context));
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
                                              AV39flResponsable ,
                                              AV28K2BToolsGenericSearchField ,
                                              A30ResponsableNombre ,
                                              A18TicketTecnicoId ,
                                              A14TicketId ,
                                              A6ResponsableId ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              A88UsuarioDepartamento ,
                                              A74TicketTecnicoInventarioSerie ,
                                              AV29OrderedBy } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV39flResponsable = StringUtil.Concat( StringUtil.RTrim( AV39flResponsable), "%", "");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         lV28K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV28K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H004U3 */
         pr_default.execute(1, new Object[] {lV39flResponsable, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField, lV28K2BToolsGenericSearchField});
         GRID_nRecordCount = H004U3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV42Pgmname = "PromptTicketTecnico";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E204U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV26FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV31GridOrders);
            /* Read saved values. */
            nRC_GXsfl_87 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_87"), ".", ","));
            AV27DeletedTag = cgiGet( "vDELETEDTAG");
            AV33UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV28K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV28K2BToolsGenericSearchField", AV28K2BToolsGenericSearchField);
            AV39flResponsable = cgiGet( edtavFlresponsable_Internalname);
            AssignAttri("", false, "AV39flResponsable", AV39flResponsable);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV28K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFLRESPONSABLE"), AV39flResponsable) != 0 )
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
         E204U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E204U2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "TicketTecnico";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "TicketTecnico";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV42Pgmname;
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV16Context) ;
         AV39flResponsable = "";
         AssignAttri("", false, "AV39flResponsable", AV39flResponsable);
         new k2bloadrowsperpage(context ).execute(  AV42Pgmname,  "Grid", out  AV10RowsPerPageVariable, out  AV11RowsPerPageLoaded) ;
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
         Form.Caption = StringUtil.Format( "Seleccionar %1", "Ticket Tecnico", "", "", "", "", "", "", "", "");
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
         AV31GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV32GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV32GridOrder.gxTpr_Ascendingorder = 0;
         AV32GridOrder.gxTpr_Descendingorder = 1;
         AV32GridOrder.gxTpr_Gridcolumnindex = 1;
         AV31GridOrders.Add(AV32GridOrder, 0);
         AV32GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV32GridOrder.gxTpr_Ascendingorder = 2;
         AV32GridOrder.gxTpr_Descendingorder = 3;
         AV32GridOrder.gxTpr_Gridcolumnindex = 2;
         AV31GridOrders.Add(AV32GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E214U2( )
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
         E224U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E224U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV17pTicketTecnicoId = A18TicketTecnicoId;
         AssignAttri("", false, "AV17pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV17pTicketTecnicoId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV17pTicketTecnicoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV17pTicketTecnicoId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E234U2( )
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
         AV33UC_OrderedBy = AV29OrderedBy;
         AssignAttri("", false, "AV33UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV33UC_OrderedBy), 4, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26FilterTags", AV26FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
      }

      private void E244U2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 87;
         }
         sendrow_872( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_87_Refreshing )
         {
            context.DoAjaxLoad(87, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E254U2( )
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
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pTicketTecnicoId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV42Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV29OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
         AV33UC_OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV33UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV33UC_OrderedBy), 4, 0));
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "flResponsable") == 0 )
            {
               AV39flResponsable = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39flResponsable", AV39flResponsable);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV28K2BToolsGenericSearchField = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28K2BToolsGenericSearchField", AV28K2BToolsGenericSearchField);
            }
            AV43GXV1 = (int)(AV43GXV1+1);
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
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pTicketTecnicoId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV42Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(AV5CurrentPage);
         AV13GridState.gxTpr_Orderedby = AV29OrderedBy;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "flResponsable";
         AV14GridStateFilterValue.gxTpr_Value = AV39flResponsable;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV14GridStateFilterValue.gxTpr_Value = AV28K2BToolsGenericSearchField;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV42Pgmname,  AV12GridStateKey,  AV13GridState) ;
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

      protected void E134U2( )
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

      protected void E144U2( )
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

      protected void E154U2( )
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

      protected void E164U2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV42Pgmname,  "Grid", ref  AV7GridConfiguration) ;
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

      protected void E174U2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         AV7GridConfiguration.gxTpr_Freezecolumntitles = AV8FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV42Pgmname,  "Grid",  AV7GridConfiguration,  true) ;
         AV33UC_OrderedBy = AV29OrderedBy;
         AssignAttri("", false, "AV33UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV33UC_OrderedBy), 4, 0));
         if ( AV10RowsPerPageVariable != AV9GridSettingsRowsPerPageVariable )
         {
            AV10RowsPerPageVariable = AV9GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV10RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV10RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV10RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV42Pgmname,  "Grid",  AV10RowsPerPageVariable) ;
            AV5CurrentPage = 1;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
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
         AV24K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39flResponsable)) )
         {
            AV25K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV25K2BFilterValuesSDTItem.gxTpr_Name = "flResponsable";
            AV25K2BFilterValuesSDTItem.gxTpr_Description = "Técnico";
            AV25K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV25K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV25K2BFilterValuesSDTItem.gxTpr_Value = AV39flResponsable;
            AV25K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV39flResponsable;
            AV24K2BFilterValuesSDT.Add(AV25K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV24K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = AV26FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV42Pgmname,  "Grid",  AV24K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item2) ;
            AV26FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item2;
         }
      }

      protected void E114U2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27DeletedTag, "flResponsable") == 0 )
         {
            AV39flResponsable = "";
            AssignAttri("", false, "AV39flResponsable", AV39flResponsable);
         }
         gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E124U2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV29OrderedBy = AV33UC_OrderedBy;
         AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV39flResponsable, AV15ClassCollection, AV29OrderedBy, AV42Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pTicketTecnicoId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E184U2( )
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

      protected void E194U2( )
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

      protected void wb_table2_126_4U2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_126_4U2e( true) ;
         }
         else
         {
            wb_table2_126_4U2e( false) ;
         }
      }

      protected void wb_table1_43_4U2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e264u1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptTicketTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_PromptTicketTecnico.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_87_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 1, "HLP_PromptTicketTecnico.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_87_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV8FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(75, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,75);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(87), 2, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromptTicketTecnico.htm");
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
            wb_table1_43_4U2e( true) ;
         }
         else
         {
            wb_table1_43_4U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17pTicketTecnicoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV17pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV17pTicketTecnicoId), 10, 0));
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
         PA4U2( ) ;
         WS4U2( ) ;
         WE4U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418820495", true, true);
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
         context.AddJavascriptSource("prompttickettecnico.js", "?202418820496", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_872( )
      {
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_87_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_87_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_87_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_87_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_87_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_87_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_87_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_87_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_87_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_87_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_87_idx;
         edtTicketTecnicoInventarioSerie_Internalname = "TICKETTECNICOINVENTARIOSERIE_"+sGXsfl_87_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_87_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_87_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_87_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_87_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_87_idx;
         chkTicketTecnicoLimpieza_Internalname = "TICKETTECNICOLIMPIEZA_"+sGXsfl_87_idx;
         chkTicketTecnicoPuntoRed_Internalname = "TICKETTECNICOPUNTORED_"+sGXsfl_87_idx;
         chkTicketTecnicoCambiosHardware_Internalname = "TICKETTECNICOCAMBIOSHARDWARE_"+sGXsfl_87_idx;
         chkTicketTecnicoCopiasRespaldo_Internalname = "TICKETTECNICOCOPIASRESPALDO_"+sGXsfl_87_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_87_idx;
         chkTicketTecnicoDiscoDuro_Internalname = "TICKETTECNICODISCODURO_"+sGXsfl_87_idx;
         chkTicketTecnicoProcesador_Internalname = "TICKETTECNICOPROCESADOR_"+sGXsfl_87_idx;
         chkTicketTecnicoMaletin_Internalname = "TICKETTECNICOMALETIN_"+sGXsfl_87_idx;
         chkTicketTecnicoTonerCinta_Internalname = "TICKETTECNICOTONERCINTA_"+sGXsfl_87_idx;
         chkTicketTecnicoTarjetaVideoExtra_Internalname = "TICKETTECNICOTARJETAVIDEOEXTRA_"+sGXsfl_87_idx;
         chkTicketTecnicoCargadorLaptop_Internalname = "TICKETTECNICOCARGADORLAPTOP_"+sGXsfl_87_idx;
         chkTicketTecnicoCDsDVDs_Internalname = "TICKETTECNICOCDSDVDS_"+sGXsfl_87_idx;
         chkTicketTecnicoCableEspecial_Internalname = "TICKETTECNICOCABLEESPECIAL_"+sGXsfl_87_idx;
         chkTicketTecnicoOtrosTaller_Internalname = "TICKETTECNICOOTROSTALLER_"+sGXsfl_87_idx;
         chkTicketTecnicoCerrado_Internalname = "TICKETTECNICOCERRADO_"+sGXsfl_87_idx;
         chkTicketTecnicoPendiente_Internalname = "TICKETTECNICOPENDIENTE_"+sGXsfl_87_idx;
         chkTicketTecnicoPasaTaller_Internalname = "TICKETTECNICOPASATALLER_"+sGXsfl_87_idx;
         chkTicketTecnicoObservacion_Internalname = "TICKETTECNICOOBSERVACION_"+sGXsfl_87_idx;
         edtTicketTecnicoDetalle_Internalname = "TICKETTECNICODETALLE_"+sGXsfl_87_idx;
      }

      protected void SubsflControlProps_fel_872( )
      {
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_87_fel_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_87_fel_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_87_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_87_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_87_fel_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_87_fel_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_87_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_87_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_87_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_87_fel_idx;
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO_"+sGXsfl_87_fel_idx;
         edtTicketTecnicoInventarioSerie_Internalname = "TICKETTECNICOINVENTARIOSERIE_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoLimpieza_Internalname = "TICKETTECNICOLIMPIEZA_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoPuntoRed_Internalname = "TICKETTECNICOPUNTORED_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCambiosHardware_Internalname = "TICKETTECNICOCAMBIOSHARDWARE_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCopiasRespaldo_Internalname = "TICKETTECNICOCOPIASRESPALDO_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoDiscoDuro_Internalname = "TICKETTECNICODISCODURO_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoProcesador_Internalname = "TICKETTECNICOPROCESADOR_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoMaletin_Internalname = "TICKETTECNICOMALETIN_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoTonerCinta_Internalname = "TICKETTECNICOTONERCINTA_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoTarjetaVideoExtra_Internalname = "TICKETTECNICOTARJETAVIDEOEXTRA_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCargadorLaptop_Internalname = "TICKETTECNICOCARGADORLAPTOP_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCDsDVDs_Internalname = "TICKETTECNICOCDSDVDS_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCableEspecial_Internalname = "TICKETTECNICOCABLEESPECIAL_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoOtrosTaller_Internalname = "TICKETTECNICOOTROSTALLER_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoCerrado_Internalname = "TICKETTECNICOCERRADO_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoPendiente_Internalname = "TICKETTECNICOPENDIENTE_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoPasaTaller_Internalname = "TICKETTECNICOPASATALLER_"+sGXsfl_87_fel_idx;
         chkTicketTecnicoObservacion_Internalname = "TICKETTECNICOOBSERVACION_"+sGXsfl_87_fel_idx;
         edtTicketTecnicoDetalle_Internalname = "TICKETTECNICODETALLE_"+sGXsfl_87_fel_idx;
      }

      protected void sendrow_872( )
      {
         SubsflControlProps_872( ) ;
         WB4U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_87_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_87_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_87_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)86,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            edtTicketTecnicoFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtTicketTecnicoFecha_Internalname, "Link", edtTicketTecnicoFecha_Link, !bGXsfl_87_Refreshing);
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoFecha_Internalname,context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"),context.localUtil.Format( A69TicketTecnicoFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTicketTecnicoFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketTecnicoFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoHora_Internalname,context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A71TicketTecnicoHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoHora_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableNombre_Internalname,(string)A30ResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDepartamento_Internalname,(string)A88UsuarioDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoInventarioSerie_Internalname,(string)A74TicketTecnicoInventarioSerie,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoInventarioSerie_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_87_idx;
            chkTicketTecnicoInstalacion.Name = GXCCtl;
            chkTicketTecnicoInstalacion.WebTags = "";
            chkTicketTecnicoInstalacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_87_idx;
            chkTicketTecnicoConfiguracion.Name = GXCCtl;
            chkTicketTecnicoConfiguracion.WebTags = "";
            chkTicketTecnicoConfiguracion.Caption = "";
            AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_87_idx;
            chkTicketTecnicoInternetRouter.Name = GXCCtl;
            chkTicketTecnicoInternetRouter.WebTags = "";
            chkTicketTecnicoInternetRouter.Caption = "";
            AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_87_idx;
            chkTicketTecnicoFormateo.Name = GXCCtl;
            chkTicketTecnicoFormateo.WebTags = "";
            chkTicketTecnicoFormateo.Caption = "";
            AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_87_idx;
            chkTicketTecnicoReparacion.Name = GXCCtl;
            chkTicketTecnicoReparacion.WebTags = "";
            chkTicketTecnicoReparacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOLIMPIEZA_" + sGXsfl_87_idx;
            chkTicketTecnicoLimpieza.Name = GXCCtl;
            chkTicketTecnicoLimpieza.WebTags = "";
            chkTicketTecnicoLimpieza.Caption = "";
            AssignProp("", false, chkTicketTecnicoLimpieza_Internalname, "TitleCaption", chkTicketTecnicoLimpieza.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOPUNTORED_" + sGXsfl_87_idx;
            chkTicketTecnicoPuntoRed.Name = GXCCtl;
            chkTicketTecnicoPuntoRed.WebTags = "";
            chkTicketTecnicoPuntoRed.Caption = "";
            AssignProp("", false, chkTicketTecnicoPuntoRed_Internalname, "TitleCaption", chkTicketTecnicoPuntoRed.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCAMBIOSHARDWARE_" + sGXsfl_87_idx;
            chkTicketTecnicoCambiosHardware.Name = GXCCtl;
            chkTicketTecnicoCambiosHardware.WebTags = "";
            chkTicketTecnicoCambiosHardware.Caption = "";
            AssignProp("", false, chkTicketTecnicoCambiosHardware_Internalname, "TitleCaption", chkTicketTecnicoCambiosHardware.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCOPIASRESPALDO_" + sGXsfl_87_idx;
            chkTicketTecnicoCopiasRespaldo.Name = GXCCtl;
            chkTicketTecnicoCopiasRespaldo.WebTags = "";
            chkTicketTecnicoCopiasRespaldo.Caption = "";
            AssignProp("", false, chkTicketTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkTicketTecnicoCopiasRespaldo.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICORAM_" + sGXsfl_87_idx;
            chkTicketTecnicoRam.Name = GXCCtl;
            chkTicketTecnicoRam.WebTags = "";
            chkTicketTecnicoRam.Caption = "";
            AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICODISCODURO_" + sGXsfl_87_idx;
            chkTicketTecnicoDiscoDuro.Name = GXCCtl;
            chkTicketTecnicoDiscoDuro.WebTags = "";
            chkTicketTecnicoDiscoDuro.Caption = "";
            AssignProp("", false, chkTicketTecnicoDiscoDuro_Internalname, "TitleCaption", chkTicketTecnicoDiscoDuro.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOPROCESADOR_" + sGXsfl_87_idx;
            chkTicketTecnicoProcesador.Name = GXCCtl;
            chkTicketTecnicoProcesador.WebTags = "";
            chkTicketTecnicoProcesador.Caption = "";
            AssignProp("", false, chkTicketTecnicoProcesador_Internalname, "TitleCaption", chkTicketTecnicoProcesador.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOMALETIN_" + sGXsfl_87_idx;
            chkTicketTecnicoMaletin.Name = GXCCtl;
            chkTicketTecnicoMaletin.WebTags = "";
            chkTicketTecnicoMaletin.Caption = "";
            AssignProp("", false, chkTicketTecnicoMaletin_Internalname, "TitleCaption", chkTicketTecnicoMaletin.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOTONERCINTA_" + sGXsfl_87_idx;
            chkTicketTecnicoTonerCinta.Name = GXCCtl;
            chkTicketTecnicoTonerCinta.WebTags = "";
            chkTicketTecnicoTonerCinta.Caption = "";
            AssignProp("", false, chkTicketTecnicoTonerCinta_Internalname, "TitleCaption", chkTicketTecnicoTonerCinta.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOTARJETAVIDEOEXTRA_" + sGXsfl_87_idx;
            chkTicketTecnicoTarjetaVideoExtra.Name = GXCCtl;
            chkTicketTecnicoTarjetaVideoExtra.WebTags = "";
            chkTicketTecnicoTarjetaVideoExtra.Caption = "";
            AssignProp("", false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "TitleCaption", chkTicketTecnicoTarjetaVideoExtra.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCARGADORLAPTOP_" + sGXsfl_87_idx;
            chkTicketTecnicoCargadorLaptop.Name = GXCCtl;
            chkTicketTecnicoCargadorLaptop.WebTags = "";
            chkTicketTecnicoCargadorLaptop.Caption = "";
            AssignProp("", false, chkTicketTecnicoCargadorLaptop_Internalname, "TitleCaption", chkTicketTecnicoCargadorLaptop.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCDSDVDS_" + sGXsfl_87_idx;
            chkTicketTecnicoCDsDVDs.Name = GXCCtl;
            chkTicketTecnicoCDsDVDs.WebTags = "";
            chkTicketTecnicoCDsDVDs.Caption = "";
            AssignProp("", false, chkTicketTecnicoCDsDVDs_Internalname, "TitleCaption", chkTicketTecnicoCDsDVDs.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCABLEESPECIAL_" + sGXsfl_87_idx;
            chkTicketTecnicoCableEspecial.Name = GXCCtl;
            chkTicketTecnicoCableEspecial.WebTags = "";
            chkTicketTecnicoCableEspecial.Caption = "";
            AssignProp("", false, chkTicketTecnicoCableEspecial_Internalname, "TitleCaption", chkTicketTecnicoCableEspecial.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOOTROSTALLER_" + sGXsfl_87_idx;
            chkTicketTecnicoOtrosTaller.Name = GXCCtl;
            chkTicketTecnicoOtrosTaller.WebTags = "";
            chkTicketTecnicoOtrosTaller.Caption = "";
            AssignProp("", false, chkTicketTecnicoOtrosTaller_Internalname, "TitleCaption", chkTicketTecnicoOtrosTaller.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOCERRADO_" + sGXsfl_87_idx;
            chkTicketTecnicoCerrado.Name = GXCCtl;
            chkTicketTecnicoCerrado.WebTags = "";
            chkTicketTecnicoCerrado.Caption = "";
            AssignProp("", false, chkTicketTecnicoCerrado_Internalname, "TitleCaption", chkTicketTecnicoCerrado.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOPENDIENTE_" + sGXsfl_87_idx;
            chkTicketTecnicoPendiente.Name = GXCCtl;
            chkTicketTecnicoPendiente.WebTags = "";
            chkTicketTecnicoPendiente.Caption = "";
            AssignProp("", false, chkTicketTecnicoPendiente_Internalname, "TitleCaption", chkTicketTecnicoPendiente.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOPASATALLER_" + sGXsfl_87_idx;
            chkTicketTecnicoPasaTaller.Name = GXCCtl;
            chkTicketTecnicoPasaTaller.WebTags = "";
            chkTicketTecnicoPasaTaller.Caption = "";
            AssignProp("", false, chkTicketTecnicoPasaTaller_Internalname, "TitleCaption", chkTicketTecnicoPasaTaller.Caption, !bGXsfl_87_Refreshing);
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
            GXCCtl = "TICKETTECNICOOBSERVACION_" + sGXsfl_87_idx;
            chkTicketTecnicoObservacion.Name = GXCCtl;
            chkTicketTecnicoObservacion.WebTags = "";
            chkTicketTecnicoObservacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoObservacion_Internalname, "TitleCaption", chkTicketTecnicoObservacion.Caption, !bGXsfl_87_Refreshing);
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoDetalle_Internalname,(string)A97TicketTecnicoDetalle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoDetalle_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)87,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes4U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_87_idx = ((subGrid_Islastpage==1)&&(nGXsfl_87_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_87_idx+1);
            sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
            SubsflControlProps_872( ) ;
         }
         /* End function sendrow_872 */
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
         GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_87_idx;
         chkTicketTecnicoInstalacion.Name = GXCCtl;
         chkTicketTecnicoInstalacion.WebTags = "";
         chkTicketTecnicoInstalacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoInstalacion.CheckedValue = "false";
         A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
         GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_87_idx;
         chkTicketTecnicoConfiguracion.Name = GXCCtl;
         chkTicketTecnicoConfiguracion.WebTags = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoConfiguracion.CheckedValue = "false";
         A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
         GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_87_idx;
         chkTicketTecnicoInternetRouter.Name = GXCCtl;
         chkTicketTecnicoInternetRouter.WebTags = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoInternetRouter.CheckedValue = "false";
         A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
         GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_87_idx;
         chkTicketTecnicoFormateo.Name = GXCCtl;
         chkTicketTecnicoFormateo.WebTags = "";
         chkTicketTecnicoFormateo.Caption = "";
         AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoFormateo.CheckedValue = "false";
         A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
         GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_87_idx;
         chkTicketTecnicoReparacion.Name = GXCCtl;
         chkTicketTecnicoReparacion.WebTags = "";
         chkTicketTecnicoReparacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoReparacion.CheckedValue = "false";
         A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
         GXCCtl = "TICKETTECNICOLIMPIEZA_" + sGXsfl_87_idx;
         chkTicketTecnicoLimpieza.Name = GXCCtl;
         chkTicketTecnicoLimpieza.WebTags = "";
         chkTicketTecnicoLimpieza.Caption = "";
         AssignProp("", false, chkTicketTecnicoLimpieza_Internalname, "TitleCaption", chkTicketTecnicoLimpieza.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoLimpieza.CheckedValue = "false";
         A75TicketTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A75TicketTecnicoLimpieza));
         GXCCtl = "TICKETTECNICOPUNTORED_" + sGXsfl_87_idx;
         chkTicketTecnicoPuntoRed.Name = GXCCtl;
         chkTicketTecnicoPuntoRed.WebTags = "";
         chkTicketTecnicoPuntoRed.Caption = "";
         AssignProp("", false, chkTicketTecnicoPuntoRed_Internalname, "TitleCaption", chkTicketTecnicoPuntoRed.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoPuntoRed.CheckedValue = "false";
         A82TicketTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A82TicketTecnicoPuntoRed));
         GXCCtl = "TICKETTECNICOCAMBIOSHARDWARE_" + sGXsfl_87_idx;
         chkTicketTecnicoCambiosHardware.Name = GXCCtl;
         chkTicketTecnicoCambiosHardware.WebTags = "";
         chkTicketTecnicoCambiosHardware.Caption = "";
         AssignProp("", false, chkTicketTecnicoCambiosHardware_Internalname, "TitleCaption", chkTicketTecnicoCambiosHardware.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCambiosHardware.CheckedValue = "false";
         A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware));
         GXCCtl = "TICKETTECNICOCOPIASRESPALDO_" + sGXsfl_87_idx;
         chkTicketTecnicoCopiasRespaldo.Name = GXCCtl;
         chkTicketTecnicoCopiasRespaldo.WebTags = "";
         chkTicketTecnicoCopiasRespaldo.Caption = "";
         AssignProp("", false, chkTicketTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkTicketTecnicoCopiasRespaldo.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCopiasRespaldo.CheckedValue = "false";
         A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo));
         GXCCtl = "TICKETTECNICORAM_" + sGXsfl_87_idx;
         chkTicketTecnicoRam.Name = GXCCtl;
         chkTicketTecnicoRam.WebTags = "";
         chkTicketTecnicoRam.Caption = "";
         AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoRam.CheckedValue = "false";
         A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
         GXCCtl = "TICKETTECNICODISCODURO_" + sGXsfl_87_idx;
         chkTicketTecnicoDiscoDuro.Name = GXCCtl;
         chkTicketTecnicoDiscoDuro.WebTags = "";
         chkTicketTecnicoDiscoDuro.Caption = "";
         AssignProp("", false, chkTicketTecnicoDiscoDuro_Internalname, "TitleCaption", chkTicketTecnicoDiscoDuro.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoDiscoDuro.CheckedValue = "false";
         A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro));
         GXCCtl = "TICKETTECNICOPROCESADOR_" + sGXsfl_87_idx;
         chkTicketTecnicoProcesador.Name = GXCCtl;
         chkTicketTecnicoProcesador.WebTags = "";
         chkTicketTecnicoProcesador.Caption = "";
         AssignProp("", false, chkTicketTecnicoProcesador_Internalname, "TitleCaption", chkTicketTecnicoProcesador.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoProcesador.CheckedValue = "false";
         A81TicketTecnicoProcesador = StringUtil.StrToBool( StringUtil.BoolToStr( A81TicketTecnicoProcesador));
         GXCCtl = "TICKETTECNICOMALETIN_" + sGXsfl_87_idx;
         chkTicketTecnicoMaletin.Name = GXCCtl;
         chkTicketTecnicoMaletin.WebTags = "";
         chkTicketTecnicoMaletin.Caption = "";
         AssignProp("", false, chkTicketTecnicoMaletin_Internalname, "TitleCaption", chkTicketTecnicoMaletin.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoMaletin.CheckedValue = "false";
         A76TicketTecnicoMaletin = StringUtil.StrToBool( StringUtil.BoolToStr( A76TicketTecnicoMaletin));
         GXCCtl = "TICKETTECNICOTONERCINTA_" + sGXsfl_87_idx;
         chkTicketTecnicoTonerCinta.Name = GXCCtl;
         chkTicketTecnicoTonerCinta.WebTags = "";
         chkTicketTecnicoTonerCinta.Caption = "";
         AssignProp("", false, chkTicketTecnicoTonerCinta_Internalname, "TitleCaption", chkTicketTecnicoTonerCinta.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoTonerCinta.CheckedValue = "false";
         A86TicketTecnicoTonerCinta = StringUtil.StrToBool( StringUtil.BoolToStr( A86TicketTecnicoTonerCinta));
         GXCCtl = "TICKETTECNICOTARJETAVIDEOEXTRA_" + sGXsfl_87_idx;
         chkTicketTecnicoTarjetaVideoExtra.Name = GXCCtl;
         chkTicketTecnicoTarjetaVideoExtra.WebTags = "";
         chkTicketTecnicoTarjetaVideoExtra.Caption = "";
         AssignProp("", false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "TitleCaption", chkTicketTecnicoTarjetaVideoExtra.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoTarjetaVideoExtra.CheckedValue = "false";
         A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra));
         GXCCtl = "TICKETTECNICOCARGADORLAPTOP_" + sGXsfl_87_idx;
         chkTicketTecnicoCargadorLaptop.Name = GXCCtl;
         chkTicketTecnicoCargadorLaptop.WebTags = "";
         chkTicketTecnicoCargadorLaptop.Caption = "";
         AssignProp("", false, chkTicketTecnicoCargadorLaptop_Internalname, "TitleCaption", chkTicketTecnicoCargadorLaptop.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCargadorLaptop.CheckedValue = "false";
         A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop));
         GXCCtl = "TICKETTECNICOCDSDVDS_" + sGXsfl_87_idx;
         chkTicketTecnicoCDsDVDs.Name = GXCCtl;
         chkTicketTecnicoCDsDVDs.WebTags = "";
         chkTicketTecnicoCDsDVDs.Caption = "";
         AssignProp("", false, chkTicketTecnicoCDsDVDs_Internalname, "TitleCaption", chkTicketTecnicoCDsDVDs.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCDsDVDs.CheckedValue = "false";
         A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs));
         GXCCtl = "TICKETTECNICOCABLEESPECIAL_" + sGXsfl_87_idx;
         chkTicketTecnicoCableEspecial.Name = GXCCtl;
         chkTicketTecnicoCableEspecial.WebTags = "";
         chkTicketTecnicoCableEspecial.Caption = "";
         AssignProp("", false, chkTicketTecnicoCableEspecial_Internalname, "TitleCaption", chkTicketTecnicoCableEspecial.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCableEspecial.CheckedValue = "false";
         A61TicketTecnicoCableEspecial = StringUtil.StrToBool( StringUtil.BoolToStr( A61TicketTecnicoCableEspecial));
         GXCCtl = "TICKETTECNICOOTROSTALLER_" + sGXsfl_87_idx;
         chkTicketTecnicoOtrosTaller.Name = GXCCtl;
         chkTicketTecnicoOtrosTaller.WebTags = "";
         chkTicketTecnicoOtrosTaller.Caption = "";
         AssignProp("", false, chkTicketTecnicoOtrosTaller_Internalname, "TitleCaption", chkTicketTecnicoOtrosTaller.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoOtrosTaller.CheckedValue = "false";
         A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller));
         GXCCtl = "TICKETTECNICOCERRADO_" + sGXsfl_87_idx;
         chkTicketTecnicoCerrado.Name = GXCCtl;
         chkTicketTecnicoCerrado.WebTags = "";
         chkTicketTecnicoCerrado.Caption = "";
         AssignProp("", false, chkTicketTecnicoCerrado_Internalname, "TitleCaption", chkTicketTecnicoCerrado.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoCerrado.CheckedValue = "false";
         A65TicketTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A65TicketTecnicoCerrado));
         GXCCtl = "TICKETTECNICOPENDIENTE_" + sGXsfl_87_idx;
         chkTicketTecnicoPendiente.Name = GXCCtl;
         chkTicketTecnicoPendiente.WebTags = "";
         chkTicketTecnicoPendiente.Caption = "";
         AssignProp("", false, chkTicketTecnicoPendiente_Internalname, "TitleCaption", chkTicketTecnicoPendiente.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoPendiente.CheckedValue = "false";
         A80TicketTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A80TicketTecnicoPendiente));
         GXCCtl = "TICKETTECNICOPASATALLER_" + sGXsfl_87_idx;
         chkTicketTecnicoPasaTaller.Name = GXCCtl;
         chkTicketTecnicoPasaTaller.WebTags = "";
         chkTicketTecnicoPasaTaller.Caption = "";
         AssignProp("", false, chkTicketTecnicoPasaTaller_Internalname, "TitleCaption", chkTicketTecnicoPasaTaller.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoPasaTaller.CheckedValue = "false";
         A79TicketTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A79TicketTecnicoPasaTaller));
         GXCCtl = "TICKETTECNICOOBSERVACION_" + sGXsfl_87_idx;
         chkTicketTecnicoObservacion.Name = GXCCtl;
         chkTicketTecnicoObservacion.WebTags = "";
         chkTicketTecnicoObservacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoObservacion_Internalname, "TitleCaption", chkTicketTecnicoObservacion.Caption, !bGXsfl_87_Refreshing);
         chkTicketTecnicoObservacion.CheckedValue = "false";
         A77TicketTecnicoObservacion = StringUtil.StrToBool( StringUtil.BoolToStr( A77TicketTecnicoObservacion));
         n77TicketTecnicoObservacion = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = "FILTERTOGGLE_COMBINED";
         Filtersummarytagsuc_Internalname = "FILTERSUMMARYTAGSUC";
         divSection4_Internalname = "SECTION4";
         imgFilterclose_combined_Internalname = "FILTERCLOSE_COMBINED";
         edtavFlresponsable_Internalname = "vFLRESPONSABLE";
         divK2btoolstable_attributecontainerflresponsable_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERFLRESPONSABLE";
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
         edtTicketTecnicoFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavFlresponsable_Jsonclick = "";
         edtavFlresponsable_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E224U2',iparms:[{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E234U2',iparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV33UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV26FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E244U2',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOSEARCH'","{handler:'E254U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOSEARCH'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E134U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E144U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E154U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E164U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E264U1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E174U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV9GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV33UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E114U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV27DeletedTag',fld:'vDELETEDTAG',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E124U2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV39flResponsable',fld:'vFLRESPONSABLE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV42Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV33UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E184U2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E194U2',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Tickettecnicodetalle',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
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
         AV28K2BToolsGenericSearchField = "";
         AV39flResponsable = "";
         AV15ClassCollection = new GxSimpleCollection<string>();
         AV42Pgmname = "";
         AV7GridConfiguration = new SdtK2BGridConfiguration(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV27DeletedTag = "";
         AV31GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lV39flResponsable = "";
         lV28K2BToolsGenericSearchField = "";
         H004U2_A97TicketTecnicoDetalle = new string[] {""} ;
         H004U2_A77TicketTecnicoObservacion = new bool[] {false} ;
         H004U2_n77TicketTecnicoObservacion = new bool[] {false} ;
         H004U2_A79TicketTecnicoPasaTaller = new bool[] {false} ;
         H004U2_A80TicketTecnicoPendiente = new bool[] {false} ;
         H004U2_A65TicketTecnicoCerrado = new bool[] {false} ;
         H004U2_A78TicketTecnicoOtrosTaller = new bool[] {false} ;
         H004U2_A61TicketTecnicoCableEspecial = new bool[] {false} ;
         H004U2_A64TicketTecnicoCDsDVDs = new bool[] {false} ;
         H004U2_A63TicketTecnicoCargadorLaptop = new bool[] {false} ;
         H004U2_A85TicketTecnicoTarjetaVideoExtra = new bool[] {false} ;
         H004U2_A86TicketTecnicoTonerCinta = new bool[] {false} ;
         H004U2_A76TicketTecnicoMaletin = new bool[] {false} ;
         H004U2_A81TicketTecnicoProcesador = new bool[] {false} ;
         H004U2_A68TicketTecnicoDiscoDuro = new bool[] {false} ;
         H004U2_A83TicketTecnicoRam = new bool[] {false} ;
         H004U2_A67TicketTecnicoCopiasRespaldo = new bool[] {false} ;
         H004U2_A62TicketTecnicoCambiosHardware = new bool[] {false} ;
         H004U2_A82TicketTecnicoPuntoRed = new bool[] {false} ;
         H004U2_A75TicketTecnicoLimpieza = new bool[] {false} ;
         H004U2_A84TicketTecnicoReparacion = new bool[] {false} ;
         H004U2_A70TicketTecnicoFormateo = new bool[] {false} ;
         H004U2_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         H004U2_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         H004U2_A72TicketTecnicoInstalacion = new bool[] {false} ;
         H004U2_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         H004U2_A88UsuarioDepartamento = new string[] {""} ;
         H004U2_A94UsuarioRequerimiento = new string[] {""} ;
         H004U2_A93UsuarioNombre = new string[] {""} ;
         H004U2_A15UsuarioId = new long[1] ;
         H004U2_A30ResponsableNombre = new string[] {""} ;
         H004U2_A6ResponsableId = new short[1] ;
         H004U2_A16TicketResponsableId = new long[1] ;
         H004U2_A14TicketId = new long[1] ;
         H004U2_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         H004U2_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         H004U2_A18TicketTecnicoId = new long[1] ;
         H004U3_AGRID_nRecordCount = new long[1] ;
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV16Context = new SdtK2BContext(context);
         AV32GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         GXt_char1 = "";
         GridRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV25K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prompttickettecnico__default(),
            new Object[][] {
                new Object[] {
               H004U2_A97TicketTecnicoDetalle, H004U2_A77TicketTecnicoObservacion, H004U2_n77TicketTecnicoObservacion, H004U2_A79TicketTecnicoPasaTaller, H004U2_A80TicketTecnicoPendiente, H004U2_A65TicketTecnicoCerrado, H004U2_A78TicketTecnicoOtrosTaller, H004U2_A61TicketTecnicoCableEspecial, H004U2_A64TicketTecnicoCDsDVDs, H004U2_A63TicketTecnicoCargadorLaptop,
               H004U2_A85TicketTecnicoTarjetaVideoExtra, H004U2_A86TicketTecnicoTonerCinta, H004U2_A76TicketTecnicoMaletin, H004U2_A81TicketTecnicoProcesador, H004U2_A68TicketTecnicoDiscoDuro, H004U2_A83TicketTecnicoRam, H004U2_A67TicketTecnicoCopiasRespaldo, H004U2_A62TicketTecnicoCambiosHardware, H004U2_A82TicketTecnicoPuntoRed, H004U2_A75TicketTecnicoLimpieza,
               H004U2_A84TicketTecnicoReparacion, H004U2_A70TicketTecnicoFormateo, H004U2_A73TicketTecnicoInternetRouter, H004U2_A66TicketTecnicoConfiguracion, H004U2_A72TicketTecnicoInstalacion, H004U2_A74TicketTecnicoInventarioSerie, H004U2_A88UsuarioDepartamento, H004U2_A94UsuarioRequerimiento, H004U2_A93UsuarioNombre, H004U2_A15UsuarioId,
               H004U2_A30ResponsableNombre, H004U2_A6ResponsableId, H004U2_A16TicketResponsableId, H004U2_A14TicketId, H004U2_A71TicketTecnicoHora, H004U2_A69TicketTecnicoFecha, H004U2_A18TicketTecnicoId
               }
               , new Object[] {
               H004U3_AGRID_nRecordCount
               }
            }
         );
         AV42Pgmname = "PromptTicketTecnico";
         /* GeneXus formulas. */
         AV42Pgmname = "PromptTicketTecnico";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV29OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV33UC_OrderedBy ;
      private short AV10RowsPerPageVariable ;
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
      private short AV9GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_87 ;
      private int nGXsfl_87_idx=1 ;
      private int subGrid_Rows ;
      private int AV5CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavFlresponsable_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
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
      private int AV43GXV1 ;
      private int AV6K2BMaxPages ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long AV17pTicketTecnicoId ;
      private long GRID_nFirstRecordOnPage ;
      private long A18TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_87_idx="0001" ;
      private string AV28K2BToolsGenericSearchField ;
      private string AV42Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV27DeletedTag ;
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
      private string divK2btoolstable_attributecontainerflresponsable_Internalname ;
      private string edtavFlresponsable_Internalname ;
      private string edtavFlresponsable_Jsonclick ;
      private string divTable3_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtTicketTecnicoFecha_Link ;
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
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV28K2BToolsGenericSearchField ;
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
      private string sGXsfl_87_fel_idx="0001" ;
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
      private DateTime A71TicketTecnicoHora ;
      private DateTime A69TicketTecnicoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8FreezeColumnTitles ;
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
      private bool bGXsfl_87_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV39flResponsable ;
      private string A30ResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A88UsuarioDepartamento ;
      private string A74TicketTecnicoInventarioSerie ;
      private string A97TicketTecnicoDetalle ;
      private string lV39flResponsable ;
      private string AV12GridStateKey ;
      private string imgFiltertoggle_combined_Bitmap ;
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
      private string[] H004U2_A97TicketTecnicoDetalle ;
      private bool[] H004U2_A77TicketTecnicoObservacion ;
      private bool[] H004U2_n77TicketTecnicoObservacion ;
      private bool[] H004U2_A79TicketTecnicoPasaTaller ;
      private bool[] H004U2_A80TicketTecnicoPendiente ;
      private bool[] H004U2_A65TicketTecnicoCerrado ;
      private bool[] H004U2_A78TicketTecnicoOtrosTaller ;
      private bool[] H004U2_A61TicketTecnicoCableEspecial ;
      private bool[] H004U2_A64TicketTecnicoCDsDVDs ;
      private bool[] H004U2_A63TicketTecnicoCargadorLaptop ;
      private bool[] H004U2_A85TicketTecnicoTarjetaVideoExtra ;
      private bool[] H004U2_A86TicketTecnicoTonerCinta ;
      private bool[] H004U2_A76TicketTecnicoMaletin ;
      private bool[] H004U2_A81TicketTecnicoProcesador ;
      private bool[] H004U2_A68TicketTecnicoDiscoDuro ;
      private bool[] H004U2_A83TicketTecnicoRam ;
      private bool[] H004U2_A67TicketTecnicoCopiasRespaldo ;
      private bool[] H004U2_A62TicketTecnicoCambiosHardware ;
      private bool[] H004U2_A82TicketTecnicoPuntoRed ;
      private bool[] H004U2_A75TicketTecnicoLimpieza ;
      private bool[] H004U2_A84TicketTecnicoReparacion ;
      private bool[] H004U2_A70TicketTecnicoFormateo ;
      private bool[] H004U2_A73TicketTecnicoInternetRouter ;
      private bool[] H004U2_A66TicketTecnicoConfiguracion ;
      private bool[] H004U2_A72TicketTecnicoInstalacion ;
      private string[] H004U2_A74TicketTecnicoInventarioSerie ;
      private string[] H004U2_A88UsuarioDepartamento ;
      private string[] H004U2_A94UsuarioRequerimiento ;
      private string[] H004U2_A93UsuarioNombre ;
      private long[] H004U2_A15UsuarioId ;
      private string[] H004U2_A30ResponsableNombre ;
      private short[] H004U2_A6ResponsableId ;
      private long[] H004U2_A16TicketResponsableId ;
      private long[] H004U2_A14TicketId ;
      private DateTime[] H004U2_A71TicketTecnicoHora ;
      private DateTime[] H004U2_A69TicketTecnicoFecha ;
      private long[] H004U2_A18TicketTecnicoId ;
      private long[] H004U3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTicketTecnicoId ;
      private GxSimpleCollection<string> AV15ClassCollection ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV24K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV26FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item2 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV31GridOrders ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV35ActivityList ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV7GridConfiguration ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtK2BContext AV16Context ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV25K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV32GridOrder ;
      private SdtK2BActivityList_K2BActivityListItem AV36ActivityListItem ;
   }

   public class prompttickettecnico__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004U2( IGxContext context ,
                                             string AV39flResponsable ,
                                             string AV28K2BToolsGenericSearchField ,
                                             string A30ResponsableNombre ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             short A6ResponsableId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV29OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[TicketTecnicoDetalle], T1.[TicketTecnicoObservacion], T1.[TicketTecnicoPasaTaller], T1.[TicketTecnicoPendiente], T1.[TicketTecnicoCerrado], T1.[TicketTecnicoOtrosTaller], T1.[TicketTecnicoCableEspecial], T1.[TicketTecnicoCDsDVDs], T1.[TicketTecnicoCargadorLaptop], T1.[TicketTecnicoTarjetaVideoExtra], T1.[TicketTecnicoTonerCinta], T1.[TicketTecnicoMaletin], T1.[TicketTecnicoProcesador], T1.[TicketTecnicoDiscoDuro], T1.[TicketTecnicoRam], T1.[TicketTecnicoCopiasRespaldo], T1.[TicketTecnicoCambiosHardware], T1.[TicketTecnicoPuntoRed], T1.[TicketTecnicoLimpieza], T1.[TicketTecnicoReparacion], T1.[TicketTecnicoFormateo], T1.[TicketTecnicoInternetRouter], T1.[TicketTecnicoConfiguracion], T1.[TicketTecnicoInstalacion], T1.[TicketTecnicoInventarioSerie], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T4.[UsuarioNombre], T3.[UsuarioId], T2.[ResponsableNombre], T1.[ResponsableId], T1.[TicketResponsableId], T1.[TicketId], T1.[TicketTecnicoHora], T1.[TicketTecnicoFecha], T1.[TicketTecnicoId]";
         sFromString = " FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39flResponsable)) )
         {
            AddWhere(sWhereString, "(T2.[ResponsableNombre] like @lV39flResponsable)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[ResponsableId] AS decimal(4,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or T2.[ResponsableNombre] like '%' + @lV28K2BToolsGenericSearchField + '%' or T4.[UsuarioNombre] like '%' + @lV28K2BToolsGenericSearchField + '%' or T4.[UsuarioRequerimiento] like '%' + @lV28K2BToolsGenericSearchField + '%' or T4.[UsuarioDepartamento] like '%' + @lV28K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV28K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( AV29OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId]";
         }
         else if ( AV29OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId] DESC";
         }
         else if ( AV29OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoFecha]";
         }
         else if ( AV29OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TicketTecnicoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H004U3( IGxContext context ,
                                             string AV39flResponsable ,
                                             string AV28K2BToolsGenericSearchField ,
                                             string A30ResponsableNombre ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             short A6ResponsableId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV29OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T4 ON T4.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39flResponsable)) )
         {
            AddWhere(sWhereString, "(T4.[ResponsableNombre] like @lV39flResponsable)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[ResponsableId] AS decimal(4,0))) like '%' + @lV28K2BToolsGenericSearchField + '%' or T4.[ResponsableNombre] like '%' + @lV28K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV28K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV28K2BToolsGenericSearchField + '%' or T3.[UsuarioDepartamento] like '%' + @lV28K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV28K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV29OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV29OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV29OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV29OrderedBy == 3 )
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
                     return conditional_H004U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H004U3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH004U2;
          prmH004U2 = new Object[] {
          new ParDef("@lV39flResponsable",GXType.NVarChar,60,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004U3;
          prmH004U3 = new Object[] {
          new ParDef("@lV39flResponsable",GXType.NVarChar,60,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV28K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U3,1, GxCacheFrequency.OFF ,true,false )
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
