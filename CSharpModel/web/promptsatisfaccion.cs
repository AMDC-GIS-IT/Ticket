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
   public class promptsatisfaccion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public promptsatisfaccion( )
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

      public promptsatisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pSatisfaccionId )
      {
         this.AV17pSatisfaccionId = 0 ;
         executePrivate();
         aP0_pSatisfaccionId=this.AV17pSatisfaccionId;
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
            gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
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
               gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_127 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_127"), "."));
               nGXsfl_127_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_127_idx"), "."));
               sGXsfl_127_idx = GetPar( "sGXsfl_127_idx");
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
               AV34K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               AV19SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
               AV22UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
               AV24SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
               AV25SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
               AV26SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
               AV27SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
               AV28SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
               AV29SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV15ClassCollection);
               AV35OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV20SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
               AV23UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
               AV45Pgmname = GetPar( "Pgmname");
               AV5CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV7GridConfiguration);
               AV17pSatisfaccionId = (long)(NumberUtil.Val( GetPar( "pSatisfaccionId"), "."));
               AV8FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
               AV17pSatisfaccionId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV17pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV17pSatisfaccionId), 10, 0));
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
         PA4V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188205523", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promptsatisfaccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pSatisfaccionId,10,0))}, new string[] {"pSatisfaccionId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV34K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONFECHA_FROM", context.localUtil.Format(AV19SatisfaccionFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOFECHA_FROM", context.localUtil.Format(AV22UsuarioFecha_From, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONRESUELTONOMBRE", AV24SatisfaccionResueltoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE", AV25SatisfaccionTecnicoProblemaNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE", AV26SatisfaccionTecnicoCompetenteNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE", AV27SatisfaccionTecnicoProfesionalismoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONTIEMPONOMBRE", AV28SatisfaccionTiempoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vSATISFACCIONATENCIONNOMBRE", AV29SatisfaccionAtencionNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_127", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_127), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV32FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV32FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV33DeletedTag));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONFECHA_TO", context.localUtil.DToC( AV20SatisfaccionFecha_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_TO", context.localUtil.DToC( AV23UsuarioFecha_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV37GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV37GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPSATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17pSatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONFECHA_FROM", context.localUtil.DToC( AV19SatisfaccionFecha_From, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA_FROM", context.localUtil.DToC( AV22UsuarioFecha_From, 0, "/"));
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
            WE4V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4V2( ) ;
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
         return formatLink("promptsatisfaccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV17pSatisfaccionId,10,0))}, new string[] {"pSatisfaccionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PromptSatisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seleccionar %1" ;
      }

      protected void WB4V0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV34K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV34K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgFiltertoggle_combined_Bitmap;
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERTOGGLE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptSatisfaccion.htm");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV32FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV33DeletedTag);
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
            GxWebStd.gx_bitmap( context, imgFilterclose_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgFilterclose_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"EFILTERCLOSE_COMBINED.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocksatisfaccionfecha_Internalname, "Fecha Encuesta:", "", "", lblTextblocksatisfaccionfecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_FilterDesc K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* User Defined Control */
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueFrom", AV19SatisfaccionFecha_From);
            ucSatisfaccionfecha_daterangepicker.SetProperty("ValueTo", AV20SatisfaccionFecha_To);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockusuariofecha_Internalname, "Fecha", "", "", lblTextblockusuariofecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_FilterDesc K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* User Defined Control */
            ucUsuariofecha_daterangepicker.SetProperty("ValueFrom", AV22UsuarioFecha_From);
            ucUsuariofecha_daterangepicker.SetProperty("ValueTo", AV23UsuarioFecha_To);
            ucUsuariofecha_daterangepicker.Render(context, "k2bdaterangepicker", Usuariofecha_daterangepicker_Internalname, "USUARIOFECHA_DATERANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionresueltonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionresueltonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionresueltonombre_Internalname, AV24SatisfaccionResueltoNombre, StringUtil.RTrim( context.localUtil.Format( AV24SatisfaccionResueltoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionresueltonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionresueltonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoproblemanombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoproblemanombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoproblemanombre_Internalname, AV25SatisfaccionTecnicoProblemaNombre, StringUtil.RTrim( context.localUtil.Format( AV25SatisfaccionTecnicoProblemaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoproblemanombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoproblemanombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicocompetentenombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicocompetentenombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicocompetentenombre_Internalname, AV26SatisfaccionTecnicoCompetenteNombre, StringUtil.RTrim( context.localUtil.Format( AV26SatisfaccionTecnicoCompetenteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicocompetentenombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicocompetentenombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontecnicoprofesionalismonombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontecnicoprofesionalismonombre_Internalname, AV27SatisfaccionTecnicoProfesionalismoNombre, StringUtil.RTrim( context.localUtil.Format( AV27SatisfaccionTecnicoProfesionalismoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontecnicoprofesionalismonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfacciontiemponombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfacciontiemponombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfacciontiemponombre_Internalname, AV28SatisfaccionTiempoNombre, StringUtil.RTrim( context.localUtil.Format( AV28SatisfaccionTiempoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfacciontiemponombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfacciontiemponombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavSatisfaccionatencionnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionatencionnombre_Internalname, "Respuesta:", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSatisfaccionatencionnombre_Internalname, AV29SatisfaccionAtencionNombre, StringUtil.RTrim( context.localUtil.Format( AV29SatisfaccionAtencionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSatisfaccionatencionnombre_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavSatisfaccionatencionnombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PromptSatisfaccion.htm");
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
            wb_table1_83_4V2( true) ;
         }
         else
         {
            wb_table1_83_4V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_83_4V2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"127\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(80), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Encuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id Técnico") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
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
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionFecha_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A93UsuarioNombre);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A94UsuarioRequerimiento);
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
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 127 )
         {
            wbEnd = 0;
            nRC_GXsfl_127 = (int)(nGXsfl_127_idx-1);
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
            wb_table2_153_4V2( true) ;
         }
         else
         {
            wb_table2_153_4V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_153_4V2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV37GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV39UC_OrderedBy);
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
         if ( wbEnd == 127 )
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

      protected void START4V2( )
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
         STRUP4V0( ) ;
      }

      protected void WS4V2( )
      {
         START4V2( ) ;
         EVT4V2( ) ;
      }

      protected void EVT4V2( )
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
                              E114V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BORDERBYUSERCONTROL.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E134V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E144V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E154V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E164V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E174V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERTOGGLE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E184V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILTERCLOSE_COMBINED.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E194V2 ();
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
                              nGXsfl_127_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
                              SubsflControlProps_1272( ) ;
                              A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
                              A32SatisfaccionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSatisfaccionFecha_Internalname), 0));
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
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E204V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E214V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV34K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionfecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSATISFACCIONFECHA_FROM"), 0) != AV19SatisfaccionFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariofecha_from Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 0) != AV22UsuarioFecha_From )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionresueltonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONRESUELTONOMBRE"), AV24SatisfaccionResueltoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicoproblemanombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV25SatisfaccionTecnicoProblemaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicocompetentenombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV26SatisfaccionTecnicoCompetenteNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontecnicoprofesionalismonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV27SatisfaccionTecnicoProfesionalismoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfacciontiemponombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTIEMPONOMBRE"), AV28SatisfaccionTiempoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Satisfaccionatencionnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONATENCIONNOMBRE"), AV29SatisfaccionAtencionNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E224V2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E234V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E244V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOSEARCH'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSearch' */
                                    E254V2 ();
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

      protected void WE4V2( )
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

      protected void PA4V2( )
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
         SubsflControlProps_1272( ) ;
         while ( nGXsfl_127_idx <= nRC_GXsfl_127 )
         {
            sendrow_1272( ) ;
            nGXsfl_127_idx = ((subGrid_Islastpage==1)&&(nGXsfl_127_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV34K2BToolsGenericSearchField ,
                                       DateTime AV19SatisfaccionFecha_From ,
                                       DateTime AV22UsuarioFecha_From ,
                                       string AV24SatisfaccionResueltoNombre ,
                                       string AV25SatisfaccionTecnicoProblemaNombre ,
                                       string AV26SatisfaccionTecnicoCompetenteNombre ,
                                       string AV27SatisfaccionTecnicoProfesionalismoNombre ,
                                       string AV28SatisfaccionTiempoNombre ,
                                       string AV29SatisfaccionAtencionNombre ,
                                       GxSimpleCollection<string> AV15ClassCollection ,
                                       short AV35OrderedBy ,
                                       DateTime AV20SatisfaccionFecha_To ,
                                       DateTime AV23UsuarioFecha_To ,
                                       string AV45Pgmname ,
                                       int AV5CurrentPage ,
                                       SdtK2BGridConfiguration AV7GridConfiguration ,
                                       long AV17pSatisfaccionId ,
                                       bool AV8FreezeColumnTitles )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E214V2 ();
         GRID_nCurrentRecord = 0;
         RF4V2( ) ;
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
         E214V2 ();
         RF4V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV45Pgmname = "PromptSatisfaccion";
         context.Gx_err = 0;
      }

      protected void RF4V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 127;
         E234V2 ();
         nGXsfl_127_idx = 1;
         sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
         SubsflControlProps_1272( ) ;
         bGXsfl_127_Refreshing = true;
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
            SubsflControlProps_1272( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV20SatisfaccionFecha_To ,
                                                 AV19SatisfaccionFecha_From ,
                                                 AV23UsuarioFecha_To ,
                                                 AV22UsuarioFecha_From ,
                                                 AV24SatisfaccionResueltoNombre ,
                                                 AV25SatisfaccionTecnicoProblemaNombre ,
                                                 AV26SatisfaccionTecnicoCompetenteNombre ,
                                                 AV27SatisfaccionTecnicoProfesionalismoNombre ,
                                                 AV28SatisfaccionTiempoNombre ,
                                                 AV29SatisfaccionAtencionNombre ,
                                                 AV34K2BToolsGenericSearchField ,
                                                 A32SatisfaccionFecha ,
                                                 A90UsuarioFecha ,
                                                 A33SatisfaccionResueltoNombre ,
                                                 A36SatisfaccionTecnicoProblemaNombre ,
                                                 A35SatisfaccionTecnicoCompetenteNombre ,
                                                 A37SatisfaccionTecnicoProfesionalismoNombre ,
                                                 A38SatisfaccionTiempoNombre ,
                                                 A31SatisfaccionAtencionNombre ,
                                                 A7SatisfaccionId ,
                                                 A14TicketId ,
                                                 A16TicketResponsableId ,
                                                 A199TicketTecnicoResponsableNombre ,
                                                 A93UsuarioNombre ,
                                                 A94UsuarioRequerimiento ,
                                                 AV35OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            lV24SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV24SatisfaccionResueltoNombre), "%", "");
            lV25SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV25SatisfaccionTecnicoProblemaNombre), "%", "");
            lV26SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV26SatisfaccionTecnicoCompetenteNombre), "%", "");
            lV27SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV27SatisfaccionTecnicoProfesionalismoNombre), "%", "");
            lV28SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV28SatisfaccionTiempoNombre), "%", "");
            lV29SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV29SatisfaccionAtencionNombre), "%", "");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H004V2 */
            pr_default.execute(0, new Object[] {AV20SatisfaccionFecha_To, AV19SatisfaccionFecha_From, AV23UsuarioFecha_To, AV22UsuarioFecha_From, lV24SatisfaccionResueltoNombre, lV25SatisfaccionTecnicoProblemaNombre, lV26SatisfaccionTecnicoCompetenteNombre, lV27SatisfaccionTecnicoProfesionalismoNombre, lV28SatisfaccionTiempoNombre, lV29SatisfaccionAtencionNombre, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_127_idx = 1;
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A34SatisfaccionSugerencia = H004V2_A34SatisfaccionSugerencia[0];
               n34SatisfaccionSugerencia = H004V2_n34SatisfaccionSugerencia[0];
               A31SatisfaccionAtencionNombre = H004V2_A31SatisfaccionAtencionNombre[0];
               A13SatisfaccionAtencionId = H004V2_A13SatisfaccionAtencionId[0];
               A38SatisfaccionTiempoNombre = H004V2_A38SatisfaccionTiempoNombre[0];
               A12SatisfaccionTiempoId = H004V2_A12SatisfaccionTiempoId[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H004V2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A11SatisfaccionTecnicoProfesionalismoId = H004V2_A11SatisfaccionTecnicoProfesionalismoId[0];
               A35SatisfaccionTecnicoCompetenteNombre = H004V2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A10SatisfaccionTecnicoCompetenteId = H004V2_A10SatisfaccionTecnicoCompetenteId[0];
               A36SatisfaccionTecnicoProblemaNombre = H004V2_A36SatisfaccionTecnicoProblemaNombre[0];
               A9SatisfaccionTecnicoProblemaId = H004V2_A9SatisfaccionTecnicoProblemaId[0];
               A33SatisfaccionResueltoNombre = H004V2_A33SatisfaccionResueltoNombre[0];
               A8SatisfaccionResueltoId = H004V2_A8SatisfaccionResueltoId[0];
               A94UsuarioRequerimiento = H004V2_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H004V2_A90UsuarioFecha[0];
               A93UsuarioNombre = H004V2_A93UsuarioNombre[0];
               A15UsuarioId = H004V2_A15UsuarioId[0];
               A199TicketTecnicoResponsableNombre = H004V2_A199TicketTecnicoResponsableNombre[0];
               A198TicketTecnicoResponsableId = H004V2_A198TicketTecnicoResponsableId[0];
               A16TicketResponsableId = H004V2_A16TicketResponsableId[0];
               A14TicketId = H004V2_A14TicketId[0];
               A32SatisfaccionFecha = H004V2_A32SatisfaccionFecha[0];
               A7SatisfaccionId = H004V2_A7SatisfaccionId[0];
               A31SatisfaccionAtencionNombre = H004V2_A31SatisfaccionAtencionNombre[0];
               A38SatisfaccionTiempoNombre = H004V2_A38SatisfaccionTiempoNombre[0];
               A37SatisfaccionTecnicoProfesionalismoNombre = H004V2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
               A35SatisfaccionTecnicoCompetenteNombre = H004V2_A35SatisfaccionTecnicoCompetenteNombre[0];
               A36SatisfaccionTecnicoProblemaNombre = H004V2_A36SatisfaccionTecnicoProblemaNombre[0];
               A33SatisfaccionResueltoNombre = H004V2_A33SatisfaccionResueltoNombre[0];
               A15UsuarioId = H004V2_A15UsuarioId[0];
               A94UsuarioRequerimiento = H004V2_A94UsuarioRequerimiento[0];
               A90UsuarioFecha = H004V2_A90UsuarioFecha[0];
               A93UsuarioNombre = H004V2_A93UsuarioNombre[0];
               A198TicketTecnicoResponsableId = H004V2_A198TicketTecnicoResponsableId[0];
               A199TicketTecnicoResponsableNombre = H004V2_A199TicketTecnicoResponsableNombre[0];
               E244V2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 127;
            WB4V0( ) ;
         }
         bGXsfl_127_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SATISFACCIONID"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sGXsfl_127_idx, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
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
                                              AV20SatisfaccionFecha_To ,
                                              AV19SatisfaccionFecha_From ,
                                              AV23UsuarioFecha_To ,
                                              AV22UsuarioFecha_From ,
                                              AV24SatisfaccionResueltoNombre ,
                                              AV25SatisfaccionTecnicoProblemaNombre ,
                                              AV26SatisfaccionTecnicoCompetenteNombre ,
                                              AV27SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV28SatisfaccionTiempoNombre ,
                                              AV29SatisfaccionAtencionNombre ,
                                              AV34K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A7SatisfaccionId ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A199TicketTecnicoResponsableNombre ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              AV35OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV24SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV24SatisfaccionResueltoNombre), "%", "");
         lV25SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV25SatisfaccionTecnicoProblemaNombre), "%", "");
         lV26SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV26SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV27SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV27SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV28SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV28SatisfaccionTiempoNombre), "%", "");
         lV29SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV29SatisfaccionAtencionNombre), "%", "");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         lV34K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV34K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H004V3 */
         pr_default.execute(1, new Object[] {AV20SatisfaccionFecha_To, AV19SatisfaccionFecha_From, AV23UsuarioFecha_To, AV22UsuarioFecha_From, lV24SatisfaccionResueltoNombre, lV25SatisfaccionTecnicoProblemaNombre, lV26SatisfaccionTecnicoCompetenteNombre, lV27SatisfaccionTecnicoProfesionalismoNombre, lV28SatisfaccionTiempoNombre, lV29SatisfaccionAtencionNombre, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField, lV34K2BToolsGenericSearchField});
         GRID_nRecordCount = H004V3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV45Pgmname = "PromptSatisfaccion";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E204V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV32FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV37GridOrders);
            /* Read saved values. */
            nRC_GXsfl_127 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_127"), ".", ","));
            AV33DeletedTag = cgiGet( "vDELETEDTAG");
            AV19SatisfaccionFecha_From = context.localUtil.CToD( cgiGet( "vSATISFACCIONFECHA_FROM"), 0);
            AV20SatisfaccionFecha_To = context.localUtil.CToD( cgiGet( "vSATISFACCIONFECHA_TO"), 0);
            AV22UsuarioFecha_From = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_FROM"), 0);
            AV23UsuarioFecha_To = context.localUtil.CToD( cgiGet( "vUSUARIOFECHA_TO"), 0);
            AV39UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            divFiltercollapsiblesection_combined_Visible = (int)(context.localUtil.CToN( cgiGet( "FILTERCOLLAPSIBLESECTION_COMBINED_Visible"), ".", ","));
            /* Read variables values. */
            AV34K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV34K2BToolsGenericSearchField", AV34K2BToolsGenericSearchField);
            AV24SatisfaccionResueltoNombre = cgiGet( edtavSatisfaccionresueltonombre_Internalname);
            AssignAttri("", false, "AV24SatisfaccionResueltoNombre", AV24SatisfaccionResueltoNombre);
            AV25SatisfaccionTecnicoProblemaNombre = cgiGet( edtavSatisfacciontecnicoproblemanombre_Internalname);
            AssignAttri("", false, "AV25SatisfaccionTecnicoProblemaNombre", AV25SatisfaccionTecnicoProblemaNombre);
            AV26SatisfaccionTecnicoCompetenteNombre = cgiGet( edtavSatisfacciontecnicocompetentenombre_Internalname);
            AssignAttri("", false, "AV26SatisfaccionTecnicoCompetenteNombre", AV26SatisfaccionTecnicoCompetenteNombre);
            AV27SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtavSatisfacciontecnicoprofesionalismonombre_Internalname);
            AssignAttri("", false, "AV27SatisfaccionTecnicoProfesionalismoNombre", AV27SatisfaccionTecnicoProfesionalismoNombre);
            AV28SatisfaccionTiempoNombre = cgiGet( edtavSatisfacciontiemponombre_Internalname);
            AssignAttri("", false, "AV28SatisfaccionTiempoNombre", AV28SatisfaccionTiempoNombre);
            AV29SatisfaccionAtencionNombre = cgiGet( edtavSatisfaccionatencionnombre_Internalname);
            AssignAttri("", false, "AV29SatisfaccionAtencionNombre", AV29SatisfaccionAtencionNombre);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV34K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSATISFACCIONFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV19SatisfaccionFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vUSUARIOFECHA_FROM"), 2) ) != DateTimeUtil.ResetTime ( AV22UsuarioFecha_From ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONRESUELTONOMBRE"), AV24SatisfaccionResueltoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROBLEMANOMBRE"), AV25SatisfaccionTecnicoProblemaNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOCOMPETENTENOMBRE"), AV26SatisfaccionTecnicoCompetenteNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTECNICOPROFESIONALISMONOMBRE"), AV27SatisfaccionTecnicoProfesionalismoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONTIEMPONOMBRE"), AV28SatisfaccionTiempoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSATISFACCIONATENCIONNOMBRE"), AV29SatisfaccionAtencionNombre) != 0 )
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
         E204V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E204V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         AV41ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV42ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV42ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV42ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV42ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV42ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV42ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV45Pgmname;
         AV41ActivityList.Add(AV42ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV41ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV41ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV16Context) ;
         AV18SatisfaccionFecha = DateTime.MinValue;
         AV19SatisfaccionFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV19SatisfaccionFecha_From", context.localUtil.Format(AV19SatisfaccionFecha_From, "99/99/9999"));
         AV20SatisfaccionFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV20SatisfaccionFecha_To", context.localUtil.Format(AV20SatisfaccionFecha_To, "99/99/9999"));
         AV21UsuarioFecha = DateTime.MinValue;
         AV22UsuarioFecha_From = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(30)));
         AssignAttri("", false, "AV22UsuarioFecha_From", context.localUtil.Format(AV22UsuarioFecha_From, "99/99/9999"));
         AV23UsuarioFecha_To = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV23UsuarioFecha_To", context.localUtil.Format(AV23UsuarioFecha_To, "99/99/9999"));
         AV24SatisfaccionResueltoNombre = "";
         AssignAttri("", false, "AV24SatisfaccionResueltoNombre", AV24SatisfaccionResueltoNombre);
         AV25SatisfaccionTecnicoProblemaNombre = "";
         AssignAttri("", false, "AV25SatisfaccionTecnicoProblemaNombre", AV25SatisfaccionTecnicoProblemaNombre);
         AV26SatisfaccionTecnicoCompetenteNombre = "";
         AssignAttri("", false, "AV26SatisfaccionTecnicoCompetenteNombre", AV26SatisfaccionTecnicoCompetenteNombre);
         AV27SatisfaccionTecnicoProfesionalismoNombre = "";
         AssignAttri("", false, "AV27SatisfaccionTecnicoProfesionalismoNombre", AV27SatisfaccionTecnicoProfesionalismoNombre);
         AV28SatisfaccionTiempoNombre = "";
         AssignAttri("", false, "AV28SatisfaccionTiempoNombre", AV28SatisfaccionTiempoNombre);
         AV29SatisfaccionAtencionNombre = "";
         AssignAttri("", false, "AV29SatisfaccionAtencionNombre", AV29SatisfaccionAtencionNombre);
         new k2bloadrowsperpage(context ).execute(  AV45Pgmname,  "Grid", out  AV10RowsPerPageVariable, out  AV11RowsPerPageLoaded) ;
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
         Form.Caption = StringUtil.Format( "Seleccionar %1", "Satisfaccion", "", "", "", "", "", "", "", "");
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
         AV37GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV38GridOrder.gxTpr_Ascendingorder = 0;
         AV38GridOrder.gxTpr_Descendingorder = 1;
         AV38GridOrder.gxTpr_Gridcolumnindex = 1;
         AV37GridOrders.Add(AV38GridOrder, 0);
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV38GridOrder.gxTpr_Ascendingorder = 2;
         AV38GridOrder.gxTpr_Descendingorder = 3;
         AV38GridOrder.gxTpr_Gridcolumnindex = 2;
         AV37GridOrders.Add(AV38GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E214V2( )
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
         E224V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E224V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV17pSatisfaccionId = A7SatisfaccionId;
         AssignAttri("", false, "AV17pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV17pSatisfaccionId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV17pSatisfaccionId});
         context.setWebReturnParmsMetadata(new Object[] {"AV17pSatisfaccionId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E234V2( )
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
         AV39UC_OrderedBy = AV35OrderedBy;
         AssignAttri("", false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32FilterTags", AV32FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
      }

      private void E244V2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 127;
         }
         sendrow_1272( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_127_Refreshing )
         {
            context.DoAjaxLoad(127, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E254V2( )
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
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pSatisfaccionId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV35OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         AV39UC_OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:From") == 0 )
            {
               AV19SatisfaccionFecha_From = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV19SatisfaccionFecha_From", context.localUtil.Format(AV19SatisfaccionFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionFecha:To") == 0 )
            {
               AV20SatisfaccionFecha_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV20SatisfaccionFecha_To", context.localUtil.Format(AV20SatisfaccionFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:From") == 0 )
            {
               AV22UsuarioFecha_From = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV22UsuarioFecha_From", context.localUtil.Format(AV22UsuarioFecha_From, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "UsuarioFecha:To") == 0 )
            {
               AV23UsuarioFecha_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV23UsuarioFecha_To", context.localUtil.Format(AV23UsuarioFecha_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionResueltoNombre") == 0 )
            {
               AV24SatisfaccionResueltoNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24SatisfaccionResueltoNombre", AV24SatisfaccionResueltoNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoProblemaNombre") == 0 )
            {
               AV25SatisfaccionTecnicoProblemaNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25SatisfaccionTecnicoProblemaNombre", AV25SatisfaccionTecnicoProblemaNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoCompetenteNombre") == 0 )
            {
               AV26SatisfaccionTecnicoCompetenteNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26SatisfaccionTecnicoCompetenteNombre", AV26SatisfaccionTecnicoCompetenteNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
            {
               AV27SatisfaccionTecnicoProfesionalismoNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27SatisfaccionTecnicoProfesionalismoNombre", AV27SatisfaccionTecnicoProfesionalismoNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionTiempoNombre") == 0 )
            {
               AV28SatisfaccionTiempoNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28SatisfaccionTiempoNombre", AV28SatisfaccionTiempoNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "SatisfaccionAtencionNombre") == 0 )
            {
               AV29SatisfaccionAtencionNombre = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29SatisfaccionAtencionNombre", AV29SatisfaccionAtencionNombre);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV34K2BToolsGenericSearchField = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34K2BToolsGenericSearchField", AV34K2BToolsGenericSearchField);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
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
         AV12GridStateKey = StringUtil.Str( (decimal)(AV17pSatisfaccionId), 10, 0);
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV12GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Currentpage = (short)(AV5CurrentPage);
         AV13GridState.gxTpr_Orderedby = AV35OrderedBy;
         AV13GridState.gxTpr_Filtervalues.Clear();
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:From";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV19SatisfaccionFecha_From, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionFecha:To";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV20SatisfaccionFecha_To, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:From";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV22UsuarioFecha_From, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "UsuarioFecha:To";
         AV14GridStateFilterValue.gxTpr_Value = context.localUtil.Format( AV23UsuarioFecha_To, "99/99/9999");
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionResueltoNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV24SatisfaccionResueltoNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoProblemaNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV25SatisfaccionTecnicoProblemaNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoCompetenteNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV26SatisfaccionTecnicoCompetenteNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTecnicoProfesionalismoNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV27SatisfaccionTecnicoProfesionalismoNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionTiempoNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV28SatisfaccionTiempoNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "SatisfaccionAtencionNombre";
         AV14GridStateFilterValue.gxTpr_Value = AV29SatisfaccionAtencionNombre;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV14GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV14GridStateFilterValue.gxTpr_Value = AV34K2BToolsGenericSearchField;
         AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV45Pgmname,  AV12GridStateKey,  AV13GridState) ;
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

      protected void E134V2( )
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

      protected void E144V2( )
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

      protected void E154V2( )
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

      protected void E164V2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV45Pgmname,  "Grid", ref  AV7GridConfiguration) ;
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

      protected void E174V2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         AV7GridConfiguration.gxTpr_Freezecolumntitles = AV8FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV45Pgmname,  "Grid",  AV7GridConfiguration,  true) ;
         AV39UC_OrderedBy = AV35OrderedBy;
         AssignAttri("", false, "AV39UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV39UC_OrderedBy), 4, 0));
         if ( AV10RowsPerPageVariable != AV9GridSettingsRowsPerPageVariable )
         {
            AV10RowsPerPageVariable = AV9GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV10RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV10RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV10RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV45Pgmname,  "Grid",  AV10RowsPerPageVariable) ;
            AV5CurrentPage = 1;
            AssignAttri("", false, "AV5CurrentPage", StringUtil.LTrimStr( (decimal)(AV5CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
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
         AV30K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (DateTime.MinValue==AV19SatisfaccionFecha_From) || ! (DateTime.MinValue==AV20SatisfaccionFecha_To) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionFecha";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Fecha Encuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV31K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime2 = DateTimeUtil.ResetTime( AV19SatisfaccionFecha_From ) ;
            AV31K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime2;
            GXt_dtime2 = DateTimeUtil.ResetTime( AV20SatisfaccionFecha_To ) ;
            AV31K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime2;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! (DateTime.MinValue==AV22UsuarioFecha_From) || ! (DateTime.MinValue==AV23UsuarioFecha_To) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "UsuarioFecha";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Fecha";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "DateRange";
            AV31K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue = "K2BToolsDateRangeManual";
            GXt_dtime2 = DateTimeUtil.ResetTime( AV22UsuarioFecha_From ) ;
            AV31K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue = GXt_dtime2;
            GXt_dtime2 = DateTimeUtil.ResetTime( AV23UsuarioFecha_To ) ;
            AV31K2BFilterValuesSDTItem.gxTpr_Daterangetovalue = GXt_dtime2;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionResueltoNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionResueltoNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV24SatisfaccionResueltoNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV24SatisfaccionResueltoNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTecnicoProblemaNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoProblemaNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV25SatisfaccionTecnicoProblemaNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV25SatisfaccionTecnicoProblemaNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionTecnicoCompetenteNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoCompetenteNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV26SatisfaccionTecnicoCompetenteNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV26SatisfaccionTecnicoCompetenteNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTecnicoProfesionalismoNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV27SatisfaccionTecnicoProfesionalismoNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV27SatisfaccionTecnicoProfesionalismoNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SatisfaccionTiempoNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionTiempoNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV28SatisfaccionTiempoNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV28SatisfaccionTiempoNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SatisfaccionAtencionNombre)) )
         {
            AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV31K2BFilterValuesSDTItem.gxTpr_Name = "SatisfaccionAtencionNombre";
            AV31K2BFilterValuesSDTItem.gxTpr_Description = "Respuesta:";
            AV31K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV31K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV31K2BFilterValuesSDTItem.gxTpr_Value = AV29SatisfaccionAtencionNombre;
            AV31K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV29SatisfaccionAtencionNombre;
            AV30K2BFilterValuesSDT.Add(AV31K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = "No hay filtros aplicados";
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV30K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV32FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV45Pgmname,  "Grid",  AV30K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV32FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E114V2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionFecha") == 0 )
         {
            AV19SatisfaccionFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV19SatisfaccionFecha_From", context.localUtil.Format(AV19SatisfaccionFecha_From, "99/99/9999"));
            AV20SatisfaccionFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV20SatisfaccionFecha_To", context.localUtil.Format(AV20SatisfaccionFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "UsuarioFecha") == 0 )
         {
            AV22UsuarioFecha_From = DateTime.MinValue;
            AssignAttri("", false, "AV22UsuarioFecha_From", context.localUtil.Format(AV22UsuarioFecha_From, "99/99/9999"));
            AV23UsuarioFecha_To = DateTime.MinValue;
            AssignAttri("", false, "AV23UsuarioFecha_To", context.localUtil.Format(AV23UsuarioFecha_To, "99/99/9999"));
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionResueltoNombre") == 0 )
         {
            AV24SatisfaccionResueltoNombre = "";
            AssignAttri("", false, "AV24SatisfaccionResueltoNombre", AV24SatisfaccionResueltoNombre);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionTecnicoProblemaNombre") == 0 )
         {
            AV25SatisfaccionTecnicoProblemaNombre = "";
            AssignAttri("", false, "AV25SatisfaccionTecnicoProblemaNombre", AV25SatisfaccionTecnicoProblemaNombre);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionTecnicoCompetenteNombre") == 0 )
         {
            AV26SatisfaccionTecnicoCompetenteNombre = "";
            AssignAttri("", false, "AV26SatisfaccionTecnicoCompetenteNombre", AV26SatisfaccionTecnicoCompetenteNombre);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
         {
            AV27SatisfaccionTecnicoProfesionalismoNombre = "";
            AssignAttri("", false, "AV27SatisfaccionTecnicoProfesionalismoNombre", AV27SatisfaccionTecnicoProfesionalismoNombre);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionTiempoNombre") == 0 )
         {
            AV28SatisfaccionTiempoNombre = "";
            AssignAttri("", false, "AV28SatisfaccionTiempoNombre", AV28SatisfaccionTiempoNombre);
         }
         else if ( StringUtil.StrCmp(AV33DeletedTag, "SatisfaccionAtencionNombre") == 0 )
         {
            AV29SatisfaccionAtencionNombre = "";
            AssignAttri("", false, "AV29SatisfaccionAtencionNombre", AV29SatisfaccionAtencionNombre);
         }
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E124V2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV35OrderedBy = AV39UC_OrderedBy;
         AssignAttri("", false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV34K2BToolsGenericSearchField, AV19SatisfaccionFecha_From, AV22UsuarioFecha_From, AV24SatisfaccionResueltoNombre, AV25SatisfaccionTecnicoProblemaNombre, AV26SatisfaccionTecnicoCompetenteNombre, AV27SatisfaccionTecnicoProfesionalismoNombre, AV28SatisfaccionTiempoNombre, AV29SatisfaccionAtencionNombre, AV15ClassCollection, AV35OrderedBy, AV20SatisfaccionFecha_To, AV23UsuarioFecha_To, AV45Pgmname, AV5CurrentPage, AV7GridConfiguration, AV17pSatisfaccionId, AV8FreezeColumnTitles) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7GridConfiguration", AV7GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ClassCollection", AV15ClassCollection);
      }

      protected void E184V2( )
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

      protected void E194V2( )
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

      protected void wb_table2_153_4V2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_153_4V2e( true) ;
         }
         else
         {
            wb_table2_153_4V2e( false) ;
         }
      }

      protected void wb_table1_83_4V2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e264v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PromptSatisfaccion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_PromptSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 1, "HLP_PromptSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_127_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV8FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(115, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,115);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromptSatisfaccion.htm");
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
            wb_table1_83_4V2e( true) ;
         }
         else
         {
            wb_table1_83_4V2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17pSatisfaccionId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV17pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV17pSatisfaccionId), 10, 0));
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
         PA4V2( ) ;
         WS4V2( ) ;
         WE4V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418821128", true, true);
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
         context.AddJavascriptSource("promptsatisfaccion.js", "?202418821129", false, true);
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

      protected void SubsflControlProps_1272( )
      {
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_127_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_127_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_127_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_127_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_127_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_127_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_127_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_127_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_127_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_127_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_127_idx;
         edtSatisfaccionResueltoNombre_Internalname = "SATISFACCIONRESUELTONOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = "SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = "SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_127_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = "SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionTiempoId_Internalname = "SATISFACCIONTIEMPOID_"+sGXsfl_127_idx;
         edtSatisfaccionTiempoNombre_Internalname = "SATISFACCIONTIEMPONOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionAtencionId_Internalname = "SATISFACCIONATENCIONID_"+sGXsfl_127_idx;
         edtSatisfaccionAtencionNombre_Internalname = "SATISFACCIONATENCIONNOMBRE_"+sGXsfl_127_idx;
         edtSatisfaccionSugerencia_Internalname = "SATISFACCIONSUGERENCIA_"+sGXsfl_127_idx;
      }

      protected void SubsflControlProps_fel_1272( )
      {
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_127_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_127_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_127_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID_"+sGXsfl_127_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_127_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_127_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_127_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_127_fel_idx;
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO_"+sGXsfl_127_fel_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionResueltoNombre_Internalname = "SATISFACCIONRESUELTONOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoProblemaNombre_Internalname = "SATISFACCIONTECNICOPROBLEMANOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = "SATISFACCIONTECNICOCOMPETENTENOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = "SATISFACCIONTECNICOPROFESIONALISMONOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTiempoId_Internalname = "SATISFACCIONTIEMPOID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionTiempoNombre_Internalname = "SATISFACCIONTIEMPONOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionAtencionId_Internalname = "SATISFACCIONATENCIONID_"+sGXsfl_127_fel_idx;
         edtSatisfaccionAtencionNombre_Internalname = "SATISFACCIONATENCIONNOMBRE_"+sGXsfl_127_fel_idx;
         edtSatisfaccionSugerencia_Internalname = "SATISFACCIONSUGERENCIA_"+sGXsfl_127_fel_idx;
      }

      protected void sendrow_1272( )
      {
         SubsflControlProps_1272( ) ;
         WB4V0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_127_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_127_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_127_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            edtSatisfaccionFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtSatisfaccionFecha_Internalname, "Link", edtSatisfaccionFecha_Link, !bGXsfl_127_Refreshing);
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionFecha_Internalname,context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"),context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionFecha_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRequerimiento_Internalname,(string)A94UsuarioRequerimiento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRequerimiento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoNombre_Internalname,(string)A33SatisfaccionResueltoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SatisfaccionTecnicoProblemaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaNombre_Internalname,(string)A36SatisfaccionTecnicoProblemaNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteNombre_Internalname,(string)A35SatisfaccionTecnicoCompetenteNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProfesionalismoNombre_Internalname,(string)A37SatisfaccionTecnicoProfesionalismoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12SatisfaccionTiempoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTiempoNombre_Internalname,(string)A38SatisfaccionTiempoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTiempoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SatisfaccionAtencionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionAtencionNombre_Internalname,(string)A31SatisfaccionAtencionNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionAtencionNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionSugerencia_Internalname,(string)A34SatisfaccionSugerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionSugerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes4V2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_127_idx = ((subGrid_Islastpage==1)&&(nGXsfl_127_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         /* End function sendrow_1272 */
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
         edtSatisfaccionId_Internalname = "SATISFACCIONID";
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA";
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
         edtSatisfaccionFecha_Jsonclick = "";
         edtSatisfaccionId_Jsonclick = "";
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
         edtSatisfaccionFecha_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavSatisfaccionatencionnombre_Jsonclick = "";
         edtavSatisfaccionatencionnombre_Enabled = 1;
         edtavSatisfacciontiemponombre_Jsonclick = "";
         edtavSatisfacciontiemponombre_Enabled = 1;
         edtavSatisfacciontecnicoprofesionalismonombre_Jsonclick = "";
         edtavSatisfacciontecnicoprofesionalismonombre_Enabled = 1;
         edtavSatisfacciontecnicocompetentenombre_Jsonclick = "";
         edtavSatisfacciontecnicocompetentenombre_Enabled = 1;
         edtavSatisfacciontecnicoproblemanombre_Jsonclick = "";
         edtavSatisfacciontecnicoproblemanombre_Enabled = 1;
         edtavSatisfaccionresueltonombre_Jsonclick = "";
         edtavSatisfaccionresueltonombre_Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E224V2',iparms:[{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E234V2',iparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV32FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E244V2',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOSEARCH'","{handler:'E254V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOSEARCH'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E134V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E144V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E154V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E164V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E264V1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E174V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV9GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV10RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E114V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV33DeletedTag',fld:'vDELETEDTAG',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E124V2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV34K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV19SatisfaccionFecha_From',fld:'vSATISFACCIONFECHA_FROM',pic:''},{av:'AV22UsuarioFecha_From',fld:'vUSUARIOFECHA_FROM',pic:''},{av:'AV24SatisfaccionResueltoNombre',fld:'vSATISFACCIONRESUELTONOMBRE',pic:''},{av:'AV25SatisfaccionTecnicoProblemaNombre',fld:'vSATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'AV26SatisfaccionTecnicoCompetenteNombre',fld:'vSATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'AV27SatisfaccionTecnicoProfesionalismoNombre',fld:'vSATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'AV28SatisfaccionTiempoNombre',fld:'vSATISFACCIONTIEMPONOMBRE',pic:''},{av:'AV29SatisfaccionAtencionNombre',fld:'vSATISFACCIONATENCIONNOMBRE',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20SatisfaccionFecha_To',fld:'vSATISFACCIONFECHA_TO',pic:''},{av:'AV23UsuarioFecha_To',fld:'vUSUARIOFECHA_TO',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV5CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV39UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV35OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV7GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E184V2',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK","{handler:'E194V2',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("FILTERCLOSE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'},{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETRESPONSABLEID","{handler:'Valid_Ticketresponsableid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETRESPONSABLEID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID","{handler:'Valid_Satisfaccionresueltoid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID","{handler:'Valid_Satisfacciontecnicoproblemaid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID","{handler:'Valid_Satisfacciontecnicocompetenteid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID","{handler:'Valid_Satisfacciontecnicoprofesionalismoid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID","{handler:'Valid_Satisfacciontiempoid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_SATISFACCIONATENCIONID","{handler:'Valid_Satisfaccionatencionid',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_SATISFACCIONATENCIONID",",oparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Satisfaccionsugerencia',iparms:[{av:'AV8FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
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
         AV34K2BToolsGenericSearchField = "";
         AV19SatisfaccionFecha_From = DateTime.MinValue;
         AV22UsuarioFecha_From = DateTime.MinValue;
         AV24SatisfaccionResueltoNombre = "";
         AV25SatisfaccionTecnicoProblemaNombre = "";
         AV26SatisfaccionTecnicoCompetenteNombre = "";
         AV27SatisfaccionTecnicoProfesionalismoNombre = "";
         AV28SatisfaccionTiempoNombre = "";
         AV29SatisfaccionAtencionNombre = "";
         AV15ClassCollection = new GxSimpleCollection<string>();
         AV20SatisfaccionFecha_To = DateTime.MinValue;
         AV23UsuarioFecha_To = DateTime.MinValue;
         AV45Pgmname = "";
         AV7GridConfiguration = new SdtK2BGridConfiguration(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV33DeletedTag = "";
         AV37GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         lblTextblocksatisfaccionfecha_Jsonclick = "";
         ucSatisfaccionfecha_daterangepicker = new GXUserControl();
         lblTextblockusuariofecha_Jsonclick = "";
         ucUsuariofecha_daterangepicker = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A32SatisfaccionFecha = DateTime.MinValue;
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
         lV24SatisfaccionResueltoNombre = "";
         lV25SatisfaccionTecnicoProblemaNombre = "";
         lV26SatisfaccionTecnicoCompetenteNombre = "";
         lV27SatisfaccionTecnicoProfesionalismoNombre = "";
         lV28SatisfaccionTiempoNombre = "";
         lV29SatisfaccionAtencionNombre = "";
         lV34K2BToolsGenericSearchField = "";
         H004V2_A34SatisfaccionSugerencia = new string[] {""} ;
         H004V2_n34SatisfaccionSugerencia = new bool[] {false} ;
         H004V2_A31SatisfaccionAtencionNombre = new string[] {""} ;
         H004V2_A13SatisfaccionAtencionId = new short[1] ;
         H004V2_A38SatisfaccionTiempoNombre = new string[] {""} ;
         H004V2_A12SatisfaccionTiempoId = new short[1] ;
         H004V2_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         H004V2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         H004V2_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         H004V2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         H004V2_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         H004V2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         H004V2_A33SatisfaccionResueltoNombre = new string[] {""} ;
         H004V2_A8SatisfaccionResueltoId = new short[1] ;
         H004V2_A94UsuarioRequerimiento = new string[] {""} ;
         H004V2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H004V2_A93UsuarioNombre = new string[] {""} ;
         H004V2_A15UsuarioId = new long[1] ;
         H004V2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H004V2_A198TicketTecnicoResponsableId = new short[1] ;
         H004V2_A16TicketResponsableId = new long[1] ;
         H004V2_A14TicketId = new long[1] ;
         H004V2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         H004V2_A7SatisfaccionId = new long[1] ;
         H004V3_AGRID_nRecordCount = new long[1] ;
         AV41ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV42ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV16Context = new SdtK2BContext(context);
         AV18SatisfaccionFecha = DateTime.MinValue;
         AV21UsuarioFecha = DateTime.MinValue;
         AV38GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         GXt_char1 = "";
         GridRow = new GXWebRow();
         AV12GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV14GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV31K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblNoresultsfoundtextblock_Jsonclick = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promptsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               H004V2_A34SatisfaccionSugerencia, H004V2_n34SatisfaccionSugerencia, H004V2_A31SatisfaccionAtencionNombre, H004V2_A13SatisfaccionAtencionId, H004V2_A38SatisfaccionTiempoNombre, H004V2_A12SatisfaccionTiempoId, H004V2_A37SatisfaccionTecnicoProfesionalismoNombre, H004V2_A11SatisfaccionTecnicoProfesionalismoId, H004V2_A35SatisfaccionTecnicoCompetenteNombre, H004V2_A10SatisfaccionTecnicoCompetenteId,
               H004V2_A36SatisfaccionTecnicoProblemaNombre, H004V2_A9SatisfaccionTecnicoProblemaId, H004V2_A33SatisfaccionResueltoNombre, H004V2_A8SatisfaccionResueltoId, H004V2_A94UsuarioRequerimiento, H004V2_A90UsuarioFecha, H004V2_A93UsuarioNombre, H004V2_A15UsuarioId, H004V2_A199TicketTecnicoResponsableNombre, H004V2_A198TicketTecnicoResponsableId,
               H004V2_A16TicketResponsableId, H004V2_A14TicketId, H004V2_A32SatisfaccionFecha, H004V2_A7SatisfaccionId
               }
               , new Object[] {
               H004V3_AGRID_nRecordCount
               }
            }
         );
         AV45Pgmname = "PromptSatisfaccion";
         /* GeneXus formulas. */
         AV45Pgmname = "PromptSatisfaccion";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV35OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV39UC_OrderedBy ;
      private short AV10RowsPerPageVariable ;
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
      private short AV9GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int nRC_GXsfl_127 ;
      private int nGXsfl_127_idx=1 ;
      private int subGrid_Rows ;
      private int AV5CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavSatisfaccionresueltonombre_Enabled ;
      private int edtavSatisfacciontecnicoproblemanombre_Enabled ;
      private int edtavSatisfacciontecnicocompetentenombre_Enabled ;
      private int edtavSatisfacciontecnicoprofesionalismonombre_Enabled ;
      private int edtavSatisfacciontiemponombre_Enabled ;
      private int edtavSatisfaccionatencionnombre_Enabled ;
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
      private int AV46GXV1 ;
      private int AV6K2BMaxPages ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long AV17pSatisfaccionId ;
      private long GRID_nFirstRecordOnPage ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_127_idx="0001" ;
      private string AV34K2BToolsGenericSearchField ;
      private string AV45Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV33DeletedTag ;
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
      private string divTable3_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtSatisfaccionFecha_Link ;
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
      private string edtSatisfaccionId_Internalname ;
      private string edtSatisfaccionFecha_Internalname ;
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
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV34K2BToolsGenericSearchField ;
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
      private string sGXsfl_127_fel_idx="0001" ;
      private string ROClassString ;
      private string edtSatisfaccionId_Jsonclick ;
      private string edtSatisfaccionFecha_Jsonclick ;
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
      private DateTime GXt_dtime2 ;
      private DateTime AV19SatisfaccionFecha_From ;
      private DateTime AV22UsuarioFecha_From ;
      private DateTime AV20SatisfaccionFecha_To ;
      private DateTime AV23UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime AV18SatisfaccionFecha ;
      private DateTime AV21UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n34SatisfaccionSugerencia ;
      private bool bGXsfl_127_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private string AV24SatisfaccionResueltoNombre ;
      private string AV25SatisfaccionTecnicoProblemaNombre ;
      private string AV26SatisfaccionTecnicoCompetenteNombre ;
      private string AV27SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV28SatisfaccionTiempoNombre ;
      private string AV29SatisfaccionAtencionNombre ;
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
      private string lV24SatisfaccionResueltoNombre ;
      private string lV25SatisfaccionTecnicoProblemaNombre ;
      private string lV26SatisfaccionTecnicoCompetenteNombre ;
      private string lV27SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV28SatisfaccionTiempoNombre ;
      private string lV29SatisfaccionAtencionNombre ;
      private string AV12GridStateKey ;
      private string imgFiltertoggle_combined_Bitmap ;
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
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H004V2_A34SatisfaccionSugerencia ;
      private bool[] H004V2_n34SatisfaccionSugerencia ;
      private string[] H004V2_A31SatisfaccionAtencionNombre ;
      private short[] H004V2_A13SatisfaccionAtencionId ;
      private string[] H004V2_A38SatisfaccionTiempoNombre ;
      private short[] H004V2_A12SatisfaccionTiempoId ;
      private string[] H004V2_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] H004V2_A11SatisfaccionTecnicoProfesionalismoId ;
      private string[] H004V2_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] H004V2_A10SatisfaccionTecnicoCompetenteId ;
      private string[] H004V2_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] H004V2_A9SatisfaccionTecnicoProblemaId ;
      private string[] H004V2_A33SatisfaccionResueltoNombre ;
      private short[] H004V2_A8SatisfaccionResueltoId ;
      private string[] H004V2_A94UsuarioRequerimiento ;
      private DateTime[] H004V2_A90UsuarioFecha ;
      private string[] H004V2_A93UsuarioNombre ;
      private long[] H004V2_A15UsuarioId ;
      private string[] H004V2_A199TicketTecnicoResponsableNombre ;
      private short[] H004V2_A198TicketTecnicoResponsableId ;
      private long[] H004V2_A16TicketResponsableId ;
      private long[] H004V2_A14TicketId ;
      private DateTime[] H004V2_A32SatisfaccionFecha ;
      private long[] H004V2_A7SatisfaccionId ;
      private long[] H004V3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pSatisfaccionId ;
      private GxSimpleCollection<string> AV15ClassCollection ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV30K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV32FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV37GridOrders ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV41ActivityList ;
      private GXWebForm Form ;
      private SdtK2BGridConfiguration AV7GridConfiguration ;
      private SdtK2BGridState AV13GridState ;
      private SdtK2BGridState_FilterValue AV14GridStateFilterValue ;
      private SdtK2BContext AV16Context ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV31K2BFilterValuesSDTItem ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV38GridOrder ;
      private SdtK2BActivityList_K2BActivityListItem AV42ActivityListItem ;
   }

   public class promptsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004V2( IGxContext context ,
                                             DateTime AV20SatisfaccionFecha_To ,
                                             DateTime AV19SatisfaccionFecha_From ,
                                             DateTime AV23UsuarioFecha_To ,
                                             DateTime AV22UsuarioFecha_From ,
                                             string AV24SatisfaccionResueltoNombre ,
                                             string AV25SatisfaccionTecnicoProblemaNombre ,
                                             string AV26SatisfaccionTecnicoCompetenteNombre ,
                                             string AV27SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV28SatisfaccionTiempoNombre ,
                                             string AV29SatisfaccionAtencionNombre ,
                                             string AV34K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV35OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[19];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SatisfaccionSugerencia], T2.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T7.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T9.[UsuarioRequerimiento], T9.[UsuarioFecha], T9.[UsuarioNombre], T8.[UsuarioId], T11.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T10.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T1.[TicketResponsableId], T1.[TicketId], T1.[SatisfaccionFecha], T1.[SatisfaccionId]";
         sFromString = " FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T8 ON T8.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T9 ON T9.[UsuarioId] = T8.[UsuarioId]) INNER JOIN [TicketResponsable] T10 ON T10.[TicketId] = T1.[TicketId] AND T10.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T11 ON T11.[ResponsableId] = T10.[TicketTecnicoResponsableId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV20SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV20SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV19SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV19SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV23UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] <= @AV23UsuarioFecha_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV22UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] >= @AV22UsuarioFecha_From)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV24SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV25SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV26SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV27SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV28SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV29SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or T11.[ResponsableNombre] like '%' + @lV34K2BToolsGenericSearchField + '%' or T9.[UsuarioNombre] like '%' + @lV34K2BToolsGenericSearchField + '%' or T9.[UsuarioRequerimiento] like '%' + @lV34K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[10] = 1;
            GXv_int4[11] = 1;
            GXv_int4[12] = 1;
            GXv_int4[13] = 1;
            GXv_int4[14] = 1;
            GXv_int4[15] = 1;
         }
         if ( AV35OrderedBy == 0 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV35OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV35OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV35OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[SatisfaccionId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H004V3( IGxContext context ,
                                             DateTime AV20SatisfaccionFecha_To ,
                                             DateTime AV19SatisfaccionFecha_From ,
                                             DateTime AV23UsuarioFecha_To ,
                                             DateTime AV22UsuarioFecha_From ,
                                             string AV24SatisfaccionResueltoNombre ,
                                             string AV25SatisfaccionTecnicoProblemaNombre ,
                                             string AV26SatisfaccionTecnicoCompetenteNombre ,
                                             string AV27SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV28SatisfaccionTiempoNombre ,
                                             string AV29SatisfaccionAtencionNombre ,
                                             string AV34K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV35OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[16];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T11 ON T11.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [EstadoSatisfaccion] T10 ON T10.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T9 ON T9.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T8 ON T8.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [Ticket] T4 ON T4.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T5 ON T5.[UsuarioId] = T4.[UsuarioId]) INNER JOIN [TicketResponsable] T2 ON T2.[TicketId] = T1.[TicketId] AND T2.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T3 ON T3.[ResponsableId] = T2.[TicketTecnicoResponsableId])";
         if ( ! (DateTime.MinValue==AV20SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV20SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV19SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV19SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV23UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioFecha] <= @AV23UsuarioFecha_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV22UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T5.[UsuarioFecha] >= @AV22UsuarioFecha_From)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV24SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV25SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T8.[EstadoSatisfaccionNombre] like @lV26SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T9.[EstadoSatisfaccionNombre] like @lV27SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T10.[EstadoSatisfaccionNombre] like @lV28SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T11.[EstadoSatisfaccionNombre] like @lV29SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV34K2BToolsGenericSearchField + '%' or T3.[ResponsableNombre] like '%' + @lV34K2BToolsGenericSearchField + '%' or T5.[UsuarioNombre] like '%' + @lV34K2BToolsGenericSearchField + '%' or T5.[UsuarioRequerimiento] like '%' + @lV34K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[10] = 1;
            GXv_int6[11] = 1;
            GXv_int6[12] = 1;
            GXv_int6[13] = 1;
            GXv_int6[14] = 1;
            GXv_int6[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV35OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV35OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV35OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV35OrderedBy == 3 )
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
                     return conditional_H004V2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_H004V3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmH004V2;
          prmH004V2 = new Object[] {
          new ParDef("@AV20SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV19SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV23UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV22UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV24SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV25SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV26SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV27SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV28SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV29SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004V3;
          prmH004V3 = new Object[] {
          new ParDef("@AV20SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV19SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV23UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV22UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV24SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV25SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV26SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV27SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV28SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV29SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV34K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004V3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(22);
                ((long[]) buf[23])[0] = rslt.getLong(23);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
