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
   public class wwresponsable : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwresponsable( )
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

      public wwresponsable( IGxContext context )
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
         chkavAtt_responsableid_visible = new GXCheckbox();
         chkavAtt_responsableidentidad_visible = new GXCheckbox();
         chkavAtt_responsablenombre_visible = new GXCheckbox();
         chkavAtt_responsableusuario_visible = new GXCheckbox();
         chkavAtt_responsablecargo_visible = new GXCheckbox();
         chkavAtt_responsableemail_visible = new GXCheckbox();
         chkavAtt_responsableactivo_visible = new GXCheckbox();
         chkavAtt_id_unidad_visible = new GXCheckbox();
         chkavAtt_nombre_unidad_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
         chkResponsableActivo = new GXCheckbox();
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
               AV28K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV27ClassCollection);
               AV29OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               AV50Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV44AutoLinksActivityList);
               AV35ResponsableIdentidad_IsAuthorized = StringUtil.StrToBool( GetPar( "ResponsableIdentidad_IsAuthorized"));
               AV14Att_ResponsableId_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableId_Visible"));
               AV15Att_ResponsableIdentidad_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableIdentidad_Visible"));
               AV16Att_ResponsableNombre_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableNombre_Visible"));
               AV17Att_ResponsableUsuario_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableUsuario_Visible"));
               AV18Att_ResponsableCargo_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableCargo_Visible"));
               AV19Att_ResponsableEmail_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableEmail_Visible"));
               AV20Att_ResponsableActivo_Visible = StringUtil.StrToBool( GetPar( "Att_ResponsableActivo_Visible"));
               AV42Att_id_unidad_Visible = StringUtil.StrToBool( GetPar( "Att_id_unidad_Visible"));
               AV43Att_nombre_unidad_Visible = StringUtil.StrToBool( GetPar( "Att_nombre_unidad_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV47Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
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
            return "responsable_Execute" ;
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
         PA2N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2N2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188152757", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwresponsable.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV28K2BToolsGenericSearchField));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_146", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_146), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV30GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV30GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV50Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV27ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV27ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29OrderedBy), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUTOLINKSACTIVITYLIST", AV44AutoLinksActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUTOLINKSACTIVITYLIST", AV44AutoLinksActivityList);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vRESPONSABLEIDENTIDAD_ISAUTHORIZED", AV35ResponsableIdentidad_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV47Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Uri, "")), context));
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
            WE2N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2N2( ) ;
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
         return formatLink("wwresponsable.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWResponsable" ;
      }

      public override string GetPgmdesc( )
      {
         return "Responsables" ;
      }

      protected void WB2N0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Responsables", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_146_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV28K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV28K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResponsable.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_24_2N2( true) ;
         }
         else
         {
            wb_table1_24_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_2N2e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(65), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableIdentidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Identidad Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableUsuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario Sistema") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableCargo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Cargo:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtResponsableEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Email:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((chkResponsableActivo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Estado:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtid_unidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "id_unidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombre_unidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "nombre_unidad") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A29ResponsableIdentidad);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtResponsableIdentidad_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableIdentidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A30ResponsableNombre);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A96ResponsableUsuario);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableUsuario_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A27ResponsableCargo);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableCargo_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A28ResponsableEmail);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResponsableEmail_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A26ResponsableActivo));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkResponsableActivo.Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtid_unidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A114nombre_unidad);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtnombre_unidad_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombre_unidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV36Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV37Delete));
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
            wb_table2_160_2N2( true) ;
         }
         else
         {
            wb_table2_160_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table2_160_2N2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWResponsable.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV30GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV32UC_OrderedBy);
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

      protected void START2N2( )
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
            Form.Meta.addItem("description", "Responsables", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2N0( ) ;
      }

      protected void WS2N2( )
      {
         START2N2( ) ;
         EVT2N2( ) ;
      }

      protected void EVT2N2( )
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
                              E112N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E122N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E132N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E142N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E152N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E162N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E172N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E182N2 ();
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
                              A6ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ".", ","));
                              A29ResponsableIdentidad = cgiGet( edtResponsableIdentidad_Internalname);
                              A30ResponsableNombre = cgiGet( edtResponsableNombre_Internalname);
                              A96ResponsableUsuario = cgiGet( edtResponsableUsuario_Internalname);
                              A27ResponsableCargo = cgiGet( edtResponsableCargo_Internalname);
                              A28ResponsableEmail = cgiGet( edtResponsableEmail_Internalname);
                              A26ResponsableActivo = StringUtil.StrToBool( cgiGet( chkResponsableActivo_Internalname));
                              A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ","));
                              A114nombre_unidad = cgiGet( edtnombre_unidad_Internalname);
                              n114nombre_unidad = false;
                              AV36Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.convertURL( context.PathToRelativeUrl( AV36Update))), !bGXsfl_146_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV36Update), true);
                              AV37Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete))), !bGXsfl_146_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E192N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E202N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222N2 ();
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

      protected void WE2N2( )
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

      protected void PA2N2( )
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
                                       string AV28K2BToolsGenericSearchField ,
                                       GxSimpleCollection<string> AV27ClassCollection ,
                                       short AV29OrderedBy ,
                                       int AV8CurrentPage ,
                                       string AV50Pgmname ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV44AutoLinksActivityList ,
                                       bool AV35ResponsableIdentidad_IsAuthorized ,
                                       bool AV14Att_ResponsableId_Visible ,
                                       bool AV15Att_ResponsableIdentidad_Visible ,
                                       bool AV16Att_ResponsableNombre_Visible ,
                                       bool AV17Att_ResponsableUsuario_Visible ,
                                       bool AV18Att_ResponsableCargo_Visible ,
                                       bool AV19Att_ResponsableEmail_Visible ,
                                       bool AV20Att_ResponsableActivo_Visible ,
                                       bool AV42Att_id_unidad_Visible ,
                                       bool AV43Att_nombre_unidad_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV47Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E202N2 ();
         GRID_nCurrentRecord = 0;
         RF2N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")));
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
         AV14Att_ResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_ResponsableId_Visible));
         AssignAttri("", false, "AV14Att_ResponsableId_Visible", AV14Att_ResponsableId_Visible);
         AV15Att_ResponsableIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_ResponsableIdentidad_Visible));
         AssignAttri("", false, "AV15Att_ResponsableIdentidad_Visible", AV15Att_ResponsableIdentidad_Visible);
         AV16Att_ResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_ResponsableNombre_Visible));
         AssignAttri("", false, "AV16Att_ResponsableNombre_Visible", AV16Att_ResponsableNombre_Visible);
         AV17Att_ResponsableUsuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_ResponsableUsuario_Visible));
         AssignAttri("", false, "AV17Att_ResponsableUsuario_Visible", AV17Att_ResponsableUsuario_Visible);
         AV18Att_ResponsableCargo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_ResponsableCargo_Visible));
         AssignAttri("", false, "AV18Att_ResponsableCargo_Visible", AV18Att_ResponsableCargo_Visible);
         AV19Att_ResponsableEmail_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_ResponsableEmail_Visible));
         AssignAttri("", false, "AV19Att_ResponsableEmail_Visible", AV19Att_ResponsableEmail_Visible);
         AV20Att_ResponsableActivo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ResponsableActivo_Visible));
         AssignAttri("", false, "AV20Att_ResponsableActivo_Visible", AV20Att_ResponsableActivo_Visible);
         AV42Att_id_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV42Att_id_unidad_Visible));
         AssignAttri("", false, "AV42Att_id_unidad_Visible", AV42Att_id_unidad_Visible);
         AV43Att_nombre_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV43Att_nombre_unidad_Visible));
         AssignAttri("", false, "AV43Att_nombre_unidad_Visible", AV43Att_nombre_unidad_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV21GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E202N2 ();
         RF2N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV50Pgmname = "WWResponsable";
         context.Gx_err = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV29OrderedBy ,
                                              AV28K2BToolsGenericSearchField ,
                                              A6ResponsableId ,
                                              A29ResponsableIdentidad ,
                                              A30ResponsableNombre ,
                                              A96ResponsableUsuario ,
                                              A27ResponsableCargo ,
                                              A28ResponsableEmail ,
                                              A103id_unidad ,
                                              A114nombre_unidad } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H002N2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A103id_unidad = H002N2_A103id_unidad[0];
            A26ResponsableActivo = H002N2_A26ResponsableActivo[0];
            A28ResponsableEmail = H002N2_A28ResponsableEmail[0];
            A27ResponsableCargo = H002N2_A27ResponsableCargo[0];
            A96ResponsableUsuario = H002N2_A96ResponsableUsuario[0];
            A30ResponsableNombre = H002N2_A30ResponsableNombre[0];
            A29ResponsableIdentidad = H002N2_A29ResponsableIdentidad[0];
            A6ResponsableId = H002N2_A6ResponsableId[0];
            /* Using cursor H002N3 */
            pr_datastore1.execute(0, new Object[] {A103id_unidad});
            A114nombre_unidad = H002N3_A114nombre_unidad[0];
            n114nombre_unidad = H002N3_n114nombre_unidad[0];
            pr_datastore1.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A6ResponsableId), 4, 0) , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A29ResponsableIdentidad , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A30ResponsableNombre , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A96ResponsableUsuario , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A27ResponsableCargo , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A28ResponsableEmail , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A103id_unidad), 9, 0) , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A114nombre_unidad , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 200 , "%"),  ' ' ) ) )
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

      protected void RF2N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 146;
         E212N2 ();
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
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV29OrderedBy ,
                                                 AV28K2BToolsGenericSearchField ,
                                                 A6ResponsableId ,
                                                 A29ResponsableIdentidad ,
                                                 A30ResponsableNombre ,
                                                 A96ResponsableUsuario ,
                                                 A27ResponsableCargo ,
                                                 A28ResponsableEmail ,
                                                 A103id_unidad ,
                                                 A114nombre_unidad } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H002N4 */
            pr_default.execute(1);
            nGXsfl_146_idx = 1;
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1462( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A103id_unidad = H002N4_A103id_unidad[0];
               A26ResponsableActivo = H002N4_A26ResponsableActivo[0];
               A28ResponsableEmail = H002N4_A28ResponsableEmail[0];
               A27ResponsableCargo = H002N4_A27ResponsableCargo[0];
               A96ResponsableUsuario = H002N4_A96ResponsableUsuario[0];
               A30ResponsableNombre = H002N4_A30ResponsableNombre[0];
               A29ResponsableIdentidad = H002N4_A29ResponsableIdentidad[0];
               A6ResponsableId = H002N4_A6ResponsableId[0];
               /* Using cursor H002N5 */
               pr_datastore1.execute(1, new Object[] {A103id_unidad});
               A114nombre_unidad = H002N5_A114nombre_unidad[0];
               n114nombre_unidad = H002N5_n114nombre_unidad[0];
               pr_datastore1.close(1);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A6ResponsableId), 4, 0) , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A29ResponsableIdentidad , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A30ResponsableNombre , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A96ResponsableUsuario , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( A27ResponsableCargo , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A28ResponsableEmail , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 102 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A103id_unidad), 9, 0) , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A114nombre_unidad , StringUtil.PadR( "%" + AV28K2BToolsGenericSearchField + "%" , 200 , "%"),  ' ' ) ) )
               {
                  E222N2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            pr_datastore1.close(1);
            wbEnd = 146;
            WB2N0( ) ;
         }
         bGXsfl_146_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV50Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV50Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RESPONSABLEID"+"_"+sGXsfl_146_idx, GetSecureSignedToken( sGXsfl_146_idx, context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV47Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Uri, "")), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV50Pgmname = "WWResponsable";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV30GridOrders);
            /* Read saved values. */
            nRC_GXsfl_146 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_146"), ".", ","));
            AV32UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV29OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            /* Read variables values. */
            AV28K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV28K2BToolsGenericSearchField", AV28K2BToolsGenericSearchField);
            AV14Att_ResponsableId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsableid_visible_Internalname));
            AssignAttri("", false, "AV14Att_ResponsableId_Visible", AV14Att_ResponsableId_Visible);
            AV15Att_ResponsableIdentidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsableidentidad_visible_Internalname));
            AssignAttri("", false, "AV15Att_ResponsableIdentidad_Visible", AV15Att_ResponsableIdentidad_Visible);
            AV16Att_ResponsableNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsablenombre_visible_Internalname));
            AssignAttri("", false, "AV16Att_ResponsableNombre_Visible", AV16Att_ResponsableNombre_Visible);
            AV17Att_ResponsableUsuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsableusuario_visible_Internalname));
            AssignAttri("", false, "AV17Att_ResponsableUsuario_Visible", AV17Att_ResponsableUsuario_Visible);
            AV18Att_ResponsableCargo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsablecargo_visible_Internalname));
            AssignAttri("", false, "AV18Att_ResponsableCargo_Visible", AV18Att_ResponsableCargo_Visible);
            AV19Att_ResponsableEmail_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsableemail_visible_Internalname));
            AssignAttri("", false, "AV19Att_ResponsableEmail_Visible", AV19Att_ResponsableEmail_Visible);
            AV20Att_ResponsableActivo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_responsableactivo_visible_Internalname));
            AssignAttri("", false, "AV20Att_ResponsableActivo_Visible", AV20Att_ResponsableActivo_Visible);
            AV42Att_id_unidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_id_unidad_visible_Internalname));
            AssignAttri("", false, "AV42Att_id_unidad_Visible", AV42Att_id_unidad_Visible);
            AV43Att_nombre_unidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombre_unidad_visible_Internalname));
            AssignAttri("", false, "AV43Att_nombre_unidad_Visible", AV43Att_nombre_unidad_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV21GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV28K2BToolsGenericSearchField) != 0 )
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
         E192N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV50Pgmname,  "Grid", out  AV22RowsPerPageVariable, out  AV23RowsPerPageLoaded) ;
         AssignAttri("", false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
         if ( ! AV23RowsPerPageLoaded )
         {
            AV22RowsPerPageVariable = 20;
            AssignAttri("", false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
         }
         AV21GridSettingsRowsPerPageVariable = AV22RowsPerPageVariable;
         AssignAttri("", false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV22RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Responsables";
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
         AV30GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV31GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV31GridOrder.gxTpr_Ascendingorder = 0;
         AV31GridOrder.gxTpr_Descendingorder = 1;
         AV31GridOrder.gxTpr_Gridcolumnindex = 1;
         AV30GridOrders.Add(AV31GridOrder, 0);
         AV31GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV31GridOrder.gxTpr_Ascendingorder = 2;
         AV31GridOrder.gxTpr_Descendingorder = 3;
         AV31GridOrder.gxTpr_Gridcolumnindex = 2;
         AV30GridOrders.Add(AV31GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E202N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV33Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV33Messages = GXt_objcol_SdtMessages_Message1;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV33Messages.Count )
         {
            AV34Message = ((GeneXus.Utils.SdtMessages_Message)AV33Messages.Item(AV51GXV1));
            GX_msglist.addItem(AV34Message.gxTpr_Description);
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV40ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV50Pgmname;
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV40ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV36Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.convertURL( context.PathToRelativeUrl( AV36Update))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV36Update), true);
         AV52Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.convertURL( context.PathToRelativeUrl( AV36Update))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV36Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_146_Refreshing);
         AV37Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete), true);
         AV53Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_146_Refreshing);
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
         new k2bscjoinstring(context ).execute(  AV27ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV24GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV50Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV29OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
         AV32UC_OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV32UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV32UC_OrderedBy), 4, 0));
         AV54GXV2 = 1;
         while ( AV54GXV2 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV54GXV2));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV28K2BToolsGenericSearchField = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28K2BToolsGenericSearchField", AV28K2BToolsGenericSearchField);
            }
            AV54GXV2 = (int)(AV54GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV25GridState.gxTpr_Currentpage > 0 ) && ( AV25GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV25GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV24GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV50Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV25GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV25GridState.gxTpr_Orderedby = AV29OrderedBy;
         AV25GridState.gxTpr_Filtervalues.Clear();
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV26GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV26GridStateFilterValue.gxTpr_Value = AV28K2BToolsGenericSearchField;
         AV25GridState.gxTpr_Filtervalues.Add(AV26GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV50Pgmname,  AV24GridStateKey,  AV25GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV38TrnContext = new SdtK2BTrnContext(context);
         AV38TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV38TrnContext.gxTpr_Returnmode = "Stack";
         AV38TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV38TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV38TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV38TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV38TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV38TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "Responsable",  AV38TrnContext) ;
      }

      protected void E122N2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Responsable",  "Responsable",  "Insert",  "",  "EntityManagerResponsable") )
         {
            CallWebObject(formatLink("entitymanagerresponsable.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ResponsableId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtResponsableId_Visible = 1;
         AssignProp("", false, edtResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableId_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV14Att_ResponsableId_Visible = true;
         AssignAttri("", false, "AV14Att_ResponsableId_Visible", AV14Att_ResponsableId_Visible);
         edtResponsableIdentidad_Visible = 1;
         AssignProp("", false, edtResponsableIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableIdentidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV15Att_ResponsableIdentidad_Visible = true;
         AssignAttri("", false, "AV15Att_ResponsableIdentidad_Visible", AV15Att_ResponsableIdentidad_Visible);
         edtResponsableNombre_Visible = 1;
         AssignProp("", false, edtResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV16Att_ResponsableNombre_Visible = true;
         AssignAttri("", false, "AV16Att_ResponsableNombre_Visible", AV16Att_ResponsableNombre_Visible);
         edtResponsableUsuario_Visible = 1;
         AssignProp("", false, edtResponsableUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableUsuario_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV17Att_ResponsableUsuario_Visible = true;
         AssignAttri("", false, "AV17Att_ResponsableUsuario_Visible", AV17Att_ResponsableUsuario_Visible);
         edtResponsableCargo_Visible = 1;
         AssignProp("", false, edtResponsableCargo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableCargo_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV18Att_ResponsableCargo_Visible = true;
         AssignAttri("", false, "AV18Att_ResponsableCargo_Visible", AV18Att_ResponsableCargo_Visible);
         edtResponsableEmail_Visible = 1;
         AssignProp("", false, edtResponsableEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableEmail_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV19Att_ResponsableEmail_Visible = true;
         AssignAttri("", false, "AV19Att_ResponsableEmail_Visible", AV19Att_ResponsableEmail_Visible);
         chkResponsableActivo.Visible = 1;
         AssignProp("", false, chkResponsableActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkResponsableActivo.Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV20Att_ResponsableActivo_Visible = true;
         AssignAttri("", false, "AV20Att_ResponsableActivo_Visible", AV20Att_ResponsableActivo_Visible);
         edtid_unidad_Visible = 1;
         AssignProp("", false, edtid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV42Att_id_unidad_Visible = true;
         AssignAttri("", false, "AV42Att_id_unidad_Visible", AV42Att_id_unidad_Visible);
         edtnombre_unidad_Visible = 1;
         AssignProp("", false, edtnombre_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
         AV43Att_nombre_unidad_Visible = true;
         AssignAttri("", false, "AV43Att_nombre_unidad_Visible", AV43Att_nombre_unidad_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV50Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV55GXV3 = 1;
         while ( AV55GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV55GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableId") == 0 )
               {
                  edtResponsableId_Visible = 0;
                  AssignProp("", false, edtResponsableId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableId_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV14Att_ResponsableId_Visible = false;
                  AssignAttri("", false, "AV14Att_ResponsableId_Visible", AV14Att_ResponsableId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableIdentidad") == 0 )
               {
                  edtResponsableIdentidad_Visible = 0;
                  AssignProp("", false, edtResponsableIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableIdentidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV15Att_ResponsableIdentidad_Visible = false;
                  AssignAttri("", false, "AV15Att_ResponsableIdentidad_Visible", AV15Att_ResponsableIdentidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
               {
                  edtResponsableNombre_Visible = 0;
                  AssignProp("", false, edtResponsableNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV16Att_ResponsableNombre_Visible = false;
                  AssignAttri("", false, "AV16Att_ResponsableNombre_Visible", AV16Att_ResponsableNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableUsuario") == 0 )
               {
                  edtResponsableUsuario_Visible = 0;
                  AssignProp("", false, edtResponsableUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableUsuario_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV17Att_ResponsableUsuario_Visible = false;
                  AssignAttri("", false, "AV17Att_ResponsableUsuario_Visible", AV17Att_ResponsableUsuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableCargo") == 0 )
               {
                  edtResponsableCargo_Visible = 0;
                  AssignProp("", false, edtResponsableCargo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableCargo_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV18Att_ResponsableCargo_Visible = false;
                  AssignAttri("", false, "AV18Att_ResponsableCargo_Visible", AV18Att_ResponsableCargo_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableEmail") == 0 )
               {
                  edtResponsableEmail_Visible = 0;
                  AssignProp("", false, edtResponsableEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResponsableEmail_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV19Att_ResponsableEmail_Visible = false;
                  AssignAttri("", false, "AV19Att_ResponsableEmail_Visible", AV19Att_ResponsableEmail_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableActivo") == 0 )
               {
                  chkResponsableActivo.Visible = 0;
                  AssignProp("", false, chkResponsableActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkResponsableActivo.Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV20Att_ResponsableActivo_Visible = false;
                  AssignAttri("", false, "AV20Att_ResponsableActivo_Visible", AV20Att_ResponsableActivo_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
               {
                  edtid_unidad_Visible = 0;
                  AssignProp("", false, edtid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtid_unidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV42Att_id_unidad_Visible = false;
                  AssignAttri("", false, "AV42Att_id_unidad_Visible", AV42Att_id_unidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
               {
                  edtnombre_unidad_Visible = 0;
                  AssignProp("", false, edtnombre_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Visible), 5, 0), !bGXsfl_146_Refreshing);
                  AV43Att_nombre_unidad_Visible = false;
                  AssignAttri("", false, "AV43Att_nombre_unidad_Visible", AV43Att_nombre_unidad_Visible);
               }
            }
            AV55GXV3 = (int)(AV55GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableId";
         AV13GridColumn.gxTpr_Columntitle = "Id Técnico:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableIdentidad";
         AV13GridColumn.gxTpr_Columntitle = "Identidad Técnico:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableNombre";
         AV13GridColumn.gxTpr_Columntitle = "Técnico:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableUsuario";
         AV13GridColumn.gxTpr_Columntitle = "Usuario Sistema";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableCargo";
         AV13GridColumn.gxTpr_Columntitle = "Cargo:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableEmail";
         AV13GridColumn.gxTpr_Columntitle = "Email:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "ResponsableActivo";
         AV13GridColumn.gxTpr_Columntitle = "Estado:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "id_unidad";
         AV13GridColumn.gxTpr_Columntitle = "id_unidad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "nombre_unidad";
         AV13GridColumn.gxTpr_Columntitle = "nombre_unidad";
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
         AV40ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV40ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV40ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerResponsable";
         AV40ActivityList.Add(AV41ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV40ActivityList) ;
         AV35ResponsableIdentidad_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV35ResponsableIdentidad_IsAuthorized", AV35ResponsableIdentidad_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_146_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_146_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV40ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_146_Refreshing);
         }
         else
         {
            edtavDelete_Visible = 1;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_146_Refreshing);
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

      protected void E212N2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV27ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV36Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.convertURL( context.PathToRelativeUrl( AV36Update))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV36Update), true);
         AV52Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.convertURL( context.PathToRelativeUrl( AV36Update))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV36Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_146_Refreshing);
         AV37Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete), true);
         AV53Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete), true);
         edtavDelete_Tooltiptext = "Eliminar";
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_146_Refreshing);
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
         AV44AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "unidades_gis";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "unidades_gis";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV41ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerunidades_gis";
         AV44AutoLinksActivityList.Add(AV41ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV44AutoLinksActivityList) ;
         AV32UC_OrderedBy = AV29OrderedBy;
         AssignAttri("", false, "AV32UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV32UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV27ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44AutoLinksActivityList", AV44AutoLinksActivityList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E222N2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            tblNoresultsfoundtable_Visible = 0;
            AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
            if ( ((SdtK2BActivityList_K2BActivityListItem)AV44AutoLinksActivityList.Item(1)).gxTpr_Isauthorized )
            {
               edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
            }
            if ( AV35ResponsableIdentidad_IsAuthorized )
            {
               edtResponsableIdentidad_Link = formatLink("entitymanagerresponsable.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ResponsableId","TabCode"}) ;
            }
            else
            {
               edtResponsableIdentidad_Link = "";
            }
            edtavUpdate_Enabled = 1;
            edtavUpdate_Link = formatLink("entitymanagerresponsable.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ResponsableId","TabCode"}) ;
            edtavUpdate_Tooltiptext = "Actualizar";
            edtavDelete_Enabled = 1;
            edtavDelete_Link = formatLink("entitymanagerresponsable.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ResponsableId","TabCode"}) ;
            edtavDelete_Tooltiptext = "Eliminar";
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 146;
            }
            sendrow_1462( ) ;
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
         if ( isFullAjaxMode( ) && ! bGXsfl_146_Refreshing )
         {
            context.DoAjaxLoad(146, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112N2( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV29OrderedBy = AV32UC_OrderedBy;
         AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E132N2( )
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
         new k2bloadgridconfiguration(context ).execute(  AV50Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV56GXV4 = 1;
         while ( AV56GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV56GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_ResponsableId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableIdentidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_ResponsableIdentidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV16Att_ResponsableNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableUsuario") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV17Att_ResponsableUsuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableCargo") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV18Att_ResponsableCargo_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableEmail") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV19Att_ResponsableEmail_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "ResponsableActivo") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV20Att_ResponsableActivo_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV42Att_id_unidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV43Att_nombre_unidad_Visible;
            }
            AV56GXV4 = (int)(AV56GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV50Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV32UC_OrderedBy = AV29OrderedBy;
         AssignAttri("", false, "AV32UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV32UC_OrderedBy), 4, 0));
         if ( AV22RowsPerPageVariable != AV21GridSettingsRowsPerPageVariable )
         {
            AV22RowsPerPageVariable = AV21GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV22RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV22RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV22RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV50Pgmname,  "Grid",  AV22RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV28K2BToolsGenericSearchField, AV27ClassCollection, AV29OrderedBy, AV8CurrentPage, AV50Pgmname, AV10GridConfiguration, AV44AutoLinksActivityList, AV35ResponsableIdentidad_IsAuthorized, AV14Att_ResponsableId_Visible, AV15Att_ResponsableIdentidad_Visible, AV16Att_ResponsableNombre_Visible, AV17Att_ResponsableUsuario_Visible, AV18Att_ResponsableCargo_Visible, AV19Att_ResponsableEmail_Visible, AV20Att_ResponsableActivo_Visible, AV42Att_id_unidad_Visible, AV43Att_nombre_unidad_Visible, AV11FreezeColumnTitles, AV47Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
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

      protected void E142N2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E152N2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E162N2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
      }

      protected void E172N2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ClassCollection", AV27ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV50Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV27ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV27ClassCollection) ;
         }
      }

      protected void E182N2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Responsable",  "Responsable",  "List",  "",  "ExportWWResponsable") )
         {
            new exportwwresponsable(context ).execute(  AV28K2BToolsGenericSearchField,  AV29OrderedBy, out  AV45OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV45OutFile, out  AV47Uri) )
            {
               CallWebObject(formatLink(AV47Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV46Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV46Guid.ToString(),  AV45OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV46Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table2_160_2N2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_160_2N2e( true) ;
         }
         else
         {
            wb_table2_160_2N2e( false) ;
         }
      }

      protected void wb_table1_24_2N2( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e232n1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWResponsable.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWResponsable.htm");
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
            GxWebStd.gx_div_start( context, divResponsableid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsableid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsableid_visible_Internalname, "Id Técnico:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsableid_visible_Internalname, StringUtil.BoolToStr( AV14Att_ResponsableId_Visible), "", "Id Técnico:", 1, chkavAtt_responsableid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
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
            GxWebStd.gx_div_start( context, divResponsableidentidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsableidentidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsableidentidad_visible_Internalname, "Identidad Técnico:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsableidentidad_visible_Internalname, StringUtil.BoolToStr( AV15Att_ResponsableIdentidad_Visible), "", "Identidad Técnico:", 1, chkavAtt_responsableidentidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
            GxWebStd.gx_div_start( context, divResponsablenombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsablenombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsablenombre_visible_Internalname, "Técnico:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsablenombre_visible_Internalname, StringUtil.BoolToStr( AV16Att_ResponsableNombre_Visible), "", "Técnico:", 1, chkavAtt_responsablenombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(65, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,65);\"");
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
            GxWebStd.gx_div_start( context, divResponsableusuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsableusuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsableusuario_visible_Internalname, "Usuario Sistema", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsableusuario_visible_Internalname, StringUtil.BoolToStr( AV17Att_ResponsableUsuario_Visible), "", "Usuario Sistema", 1, chkavAtt_responsableusuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(71, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"");
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
            GxWebStd.gx_div_start( context, divResponsablecargo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsablecargo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsablecargo_visible_Internalname, "Cargo:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsablecargo_visible_Internalname, StringUtil.BoolToStr( AV18Att_ResponsableCargo_Visible), "", "Cargo:", 1, chkavAtt_responsablecargo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,77);\"");
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
            GxWebStd.gx_div_start( context, divResponsableemail_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsableemail_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsableemail_visible_Internalname, "Email:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsableemail_visible_Internalname, StringUtil.BoolToStr( AV19Att_ResponsableEmail_Visible), "", "Email:", 1, chkavAtt_responsableemail_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(83, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,83);\"");
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
            GxWebStd.gx_div_start( context, divResponsableactivo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_responsableactivo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_responsableactivo_visible_Internalname, "Estado:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_responsableactivo_visible_Internalname, StringUtil.BoolToStr( AV20Att_ResponsableActivo_Visible), "", "Estado:", 1, chkavAtt_responsableactivo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
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
            GxWebStd.gx_div_start( context, divId_unidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_id_unidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_id_unidad_visible_Internalname, "id_unidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_id_unidad_visible_Internalname, StringUtil.BoolToStr( AV42Att_id_unidad_Visible), "", "id_unidad", 1, chkavAtt_id_unidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,95);\"");
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
            GxWebStd.gx_div_start( context, divNombre_unidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_nombre_unidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombre_unidad_visible_Internalname, "nombre_unidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombre_unidad_visible_Internalname, StringUtil.BoolToStr( AV43Att_nombre_unidad_Visible), "", "nombre_unidad", 1, chkavAtt_nombre_unidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(101, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,101);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_146_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 1, "HLP_WWResponsable.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_146_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV11FreezeColumnTitles), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(113, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,113);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWResponsable.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e242n1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWResponsable.htm");
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
            wb_table3_127_2N2( true) ;
         }
         else
         {
            wb_table3_127_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table3_127_2N2e( bool wbgen )
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
            wb_table4_134_2N2( true) ;
         }
         else
         {
            wb_table4_134_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table4_134_2N2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_24_2N2e( true) ;
         }
         else
         {
            wb_table1_24_2N2e( false) ;
         }
      }

      protected void wb_table4_134_2N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWResponsable.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_134_2N2e( true) ;
         }
         else
         {
            wb_table4_134_2N2e( false) ;
         }
      }

      protected void wb_table3_127_2N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btabledownloadssectioncontainer_Internalname, tblK2btabledownloadssectioncontainer_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e252n1_client"+"'", TempTags, "", 2, "HLP_WWResponsable.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(146), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWResponsable.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_127_2N2e( true) ;
         }
         else
         {
            wb_table3_127_2N2e( false) ;
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
         PA2N2( ) ;
         WS2N2( ) ;
         WE2N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188153324", true, true);
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
         context.AddJavascriptSource("wwresponsable.js", "?2024188153325", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1462( )
      {
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_146_idx;
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD_"+sGXsfl_146_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_146_idx;
         edtResponsableUsuario_Internalname = "RESPONSABLEUSUARIO_"+sGXsfl_146_idx;
         edtResponsableCargo_Internalname = "RESPONSABLECARGO_"+sGXsfl_146_idx;
         edtResponsableEmail_Internalname = "RESPONSABLEEMAIL_"+sGXsfl_146_idx;
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO_"+sGXsfl_146_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_146_idx;
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD_"+sGXsfl_146_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_146_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_146_idx;
      }

      protected void SubsflControlProps_fel_1462( )
      {
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_146_fel_idx;
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD_"+sGXsfl_146_fel_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_146_fel_idx;
         edtResponsableUsuario_Internalname = "RESPONSABLEUSUARIO_"+sGXsfl_146_fel_idx;
         edtResponsableCargo_Internalname = "RESPONSABLECARGO_"+sGXsfl_146_fel_idx;
         edtResponsableEmail_Internalname = "RESPONSABLEEMAIL_"+sGXsfl_146_fel_idx;
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO_"+sGXsfl_146_fel_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_146_fel_idx;
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD_"+sGXsfl_146_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_146_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_146_fel_idx;
      }

      protected void sendrow_1462( )
      {
         SubsflControlProps_1462( ) ;
         WB2N0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtResponsableId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)65,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableIdentidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableIdentidad_Internalname,(string)A29ResponsableIdentidad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResponsableIdentidad_Link,(string)"",(string)"",(string)"",(string)edtResponsableIdentidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtResponsableIdentidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableNombre_Internalname,(string)A30ResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableUsuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableUsuario_Internalname,(string)A96ResponsableUsuario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableUsuario_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableUsuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)146,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableCargo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableCargo_Internalname,(string)A27ResponsableCargo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableCargo_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableCargo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtResponsableEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableEmail_Internalname,(string)A28ResponsableEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A28ResponsableEmail,(string)"",(string)"",(string)"",(string)edtResponsableEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtResponsableEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkResponsableActivo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute_Grid";
            StyleString = "";
            GXCCtl = "RESPONSABLEACTIVO_" + sGXsfl_146_idx;
            chkResponsableActivo.Name = GXCCtl;
            chkResponsableActivo.WebTags = "";
            chkResponsableActivo.Caption = "";
            AssignProp("", false, chkResponsableActivo_Internalname, "TitleCaption", chkResponsableActivo.Caption, !bGXsfl_146_Refreshing);
            chkResponsableActivo.CheckedValue = "false";
            A26ResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A26ResponsableActivo));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkResponsableActivo_Internalname,StringUtil.BoolToStr( A26ResponsableActivo),(string)"",(string)"",chkResponsableActivo.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtid_unidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_unidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtid_unidad_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtnombre_unidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombre_unidad_Internalname,(string)A114nombre_unidad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtnombre_unidad_Link,(string)"",(string)"",(string)"",(string)edtnombre_unidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombre_unidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)146,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV36Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV36Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV52Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV36Update)) ? AV52Update_GXI : context.PathToRelativeUrl( AV36Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV36Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV37Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV53Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete)) ? AV53Delete_GXI : context.PathToRelativeUrl( AV37Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV37Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_146_idx = ((subGrid_Islastpage==1)&&(nGXsfl_146_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_idx+1);
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1462( ) ;
         }
         /* End function sendrow_1462 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_responsableid_visible.Name = "vATT_RESPONSABLEID_VISIBLE";
         chkavAtt_responsableid_visible.WebTags = "";
         chkavAtt_responsableid_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsableid_visible_Internalname, "TitleCaption", chkavAtt_responsableid_visible.Caption, true);
         chkavAtt_responsableid_visible.CheckedValue = "false";
         AV14Att_ResponsableId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_ResponsableId_Visible));
         AssignAttri("", false, "AV14Att_ResponsableId_Visible", AV14Att_ResponsableId_Visible);
         chkavAtt_responsableidentidad_visible.Name = "vATT_RESPONSABLEIDENTIDAD_VISIBLE";
         chkavAtt_responsableidentidad_visible.WebTags = "";
         chkavAtt_responsableidentidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsableidentidad_visible_Internalname, "TitleCaption", chkavAtt_responsableidentidad_visible.Caption, true);
         chkavAtt_responsableidentidad_visible.CheckedValue = "false";
         AV15Att_ResponsableIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_ResponsableIdentidad_Visible));
         AssignAttri("", false, "AV15Att_ResponsableIdentidad_Visible", AV15Att_ResponsableIdentidad_Visible);
         chkavAtt_responsablenombre_visible.Name = "vATT_RESPONSABLENOMBRE_VISIBLE";
         chkavAtt_responsablenombre_visible.WebTags = "";
         chkavAtt_responsablenombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsablenombre_visible_Internalname, "TitleCaption", chkavAtt_responsablenombre_visible.Caption, true);
         chkavAtt_responsablenombre_visible.CheckedValue = "false";
         AV16Att_ResponsableNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV16Att_ResponsableNombre_Visible));
         AssignAttri("", false, "AV16Att_ResponsableNombre_Visible", AV16Att_ResponsableNombre_Visible);
         chkavAtt_responsableusuario_visible.Name = "vATT_RESPONSABLEUSUARIO_VISIBLE";
         chkavAtt_responsableusuario_visible.WebTags = "";
         chkavAtt_responsableusuario_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsableusuario_visible_Internalname, "TitleCaption", chkavAtt_responsableusuario_visible.Caption, true);
         chkavAtt_responsableusuario_visible.CheckedValue = "false";
         AV17Att_ResponsableUsuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_ResponsableUsuario_Visible));
         AssignAttri("", false, "AV17Att_ResponsableUsuario_Visible", AV17Att_ResponsableUsuario_Visible);
         chkavAtt_responsablecargo_visible.Name = "vATT_RESPONSABLECARGO_VISIBLE";
         chkavAtt_responsablecargo_visible.WebTags = "";
         chkavAtt_responsablecargo_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsablecargo_visible_Internalname, "TitleCaption", chkavAtt_responsablecargo_visible.Caption, true);
         chkavAtt_responsablecargo_visible.CheckedValue = "false";
         AV18Att_ResponsableCargo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_ResponsableCargo_Visible));
         AssignAttri("", false, "AV18Att_ResponsableCargo_Visible", AV18Att_ResponsableCargo_Visible);
         chkavAtt_responsableemail_visible.Name = "vATT_RESPONSABLEEMAIL_VISIBLE";
         chkavAtt_responsableemail_visible.WebTags = "";
         chkavAtt_responsableemail_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsableemail_visible_Internalname, "TitleCaption", chkavAtt_responsableemail_visible.Caption, true);
         chkavAtt_responsableemail_visible.CheckedValue = "false";
         AV19Att_ResponsableEmail_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_ResponsableEmail_Visible));
         AssignAttri("", false, "AV19Att_ResponsableEmail_Visible", AV19Att_ResponsableEmail_Visible);
         chkavAtt_responsableactivo_visible.Name = "vATT_RESPONSABLEACTIVO_VISIBLE";
         chkavAtt_responsableactivo_visible.WebTags = "";
         chkavAtt_responsableactivo_visible.Caption = "";
         AssignProp("", false, chkavAtt_responsableactivo_visible_Internalname, "TitleCaption", chkavAtt_responsableactivo_visible.Caption, true);
         chkavAtt_responsableactivo_visible.CheckedValue = "false";
         AV20Att_ResponsableActivo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ResponsableActivo_Visible));
         AssignAttri("", false, "AV20Att_ResponsableActivo_Visible", AV20Att_ResponsableActivo_Visible);
         chkavAtt_id_unidad_visible.Name = "vATT_ID_UNIDAD_VISIBLE";
         chkavAtt_id_unidad_visible.WebTags = "";
         chkavAtt_id_unidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_id_unidad_visible_Internalname, "TitleCaption", chkavAtt_id_unidad_visible.Caption, true);
         chkavAtt_id_unidad_visible.CheckedValue = "false";
         AV42Att_id_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV42Att_id_unidad_Visible));
         AssignAttri("", false, "AV42Att_id_unidad_Visible", AV42Att_id_unidad_Visible);
         chkavAtt_nombre_unidad_visible.Name = "vATT_NOMBRE_UNIDAD_VISIBLE";
         chkavAtt_nombre_unidad_visible.WebTags = "";
         chkavAtt_nombre_unidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombre_unidad_visible_Internalname, "TitleCaption", chkavAtt_nombre_unidad_visible.Caption, true);
         chkavAtt_nombre_unidad_visible.CheckedValue = "false";
         AV43Att_nombre_unidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV43Att_nombre_unidad_Visible));
         AssignAttri("", false, "AV43Att_nombre_unidad_Visible", AV43Att_nombre_unidad_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV21GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV21GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV21GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
         GXCCtl = "RESPONSABLEACTIVO_" + sGXsfl_146_idx;
         chkResponsableActivo.Name = GXCCtl;
         chkResponsableActivo.WebTags = "";
         chkResponsableActivo.Caption = "";
         AssignProp("", false, chkResponsableActivo_Internalname, "TitleCaption", chkResponsableActivo.Caption, !bGXsfl_146_Refreshing);
         chkResponsableActivo.CheckedValue = "false";
         A26ResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A26ResponsableActivo));
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblPgmdescriptortextblock_Internalname = "PGMDESCRIPTORTEXTBLOCK";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_responsableid_visible_Internalname = "vATT_RESPONSABLEID_VISIBLE";
         divResponsableid_gridsettingscontainer_Internalname = "RESPONSABLEID_GRIDSETTINGSCONTAINER";
         chkavAtt_responsableidentidad_visible_Internalname = "vATT_RESPONSABLEIDENTIDAD_VISIBLE";
         divResponsableidentidad_gridsettingscontainer_Internalname = "RESPONSABLEIDENTIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_responsablenombre_visible_Internalname = "vATT_RESPONSABLENOMBRE_VISIBLE";
         divResponsablenombre_gridsettingscontainer_Internalname = "RESPONSABLENOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_responsableusuario_visible_Internalname = "vATT_RESPONSABLEUSUARIO_VISIBLE";
         divResponsableusuario_gridsettingscontainer_Internalname = "RESPONSABLEUSUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_responsablecargo_visible_Internalname = "vATT_RESPONSABLECARGO_VISIBLE";
         divResponsablecargo_gridsettingscontainer_Internalname = "RESPONSABLECARGO_GRIDSETTINGSCONTAINER";
         chkavAtt_responsableemail_visible_Internalname = "vATT_RESPONSABLEEMAIL_VISIBLE";
         divResponsableemail_gridsettingscontainer_Internalname = "RESPONSABLEEMAIL_GRIDSETTINGSCONTAINER";
         chkavAtt_responsableactivo_visible_Internalname = "vATT_RESPONSABLEACTIVO_VISIBLE";
         divResponsableactivo_gridsettingscontainer_Internalname = "RESPONSABLEACTIVO_GRIDSETTINGSCONTAINER";
         chkavAtt_id_unidad_visible_Internalname = "vATT_ID_UNIDAD_VISIBLE";
         divId_unidad_gridsettingscontainer_Internalname = "ID_UNIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_nombre_unidad_visible_Internalname = "vATT_NOMBRE_UNIDAD_VISIBLE";
         divNombre_unidad_gridsettingscontainer_Internalname = "NOMBRE_UNIDAD_GRIDSETTINGSCONTAINER";
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
         edtResponsableId_Internalname = "RESPONSABLEID";
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD";
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE";
         edtResponsableUsuario_Internalname = "RESPONSABLEUSUARIO";
         edtResponsableCargo_Internalname = "RESPONSABLECARGO";
         edtResponsableEmail_Internalname = "RESPONSABLEEMAIL";
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO";
         edtid_unidad_Internalname = "ID_UNIDAD";
         edtnombre_unidad_Internalname = "NOMBRE_UNIDAD";
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
         chkavAtt_nombre_unidad_visible.Caption = "nombre_unidad";
         chkavAtt_id_unidad_visible.Caption = "id_unidad";
         chkavAtt_responsableactivo_visible.Caption = "Estado:";
         chkavAtt_responsableemail_visible.Caption = "Email:";
         chkavAtt_responsablecargo_visible.Caption = "Cargo:";
         chkavAtt_responsableusuario_visible.Caption = "Usuario Sistema";
         chkavAtt_responsablenombre_visible.Caption = "Técnico:";
         chkavAtt_responsableidentidad_visible.Caption = "Identidad Técnico:";
         chkavAtt_responsableid_visible.Caption = "Id Técnico:";
         edtnombre_unidad_Jsonclick = "";
         edtid_unidad_Jsonclick = "";
         chkResponsableActivo.Caption = "";
         edtResponsableEmail_Jsonclick = "";
         edtResponsableCargo_Jsonclick = "";
         edtResponsableUsuario_Jsonclick = "";
         edtResponsableNombre_Jsonclick = "";
         edtResponsableIdentidad_Jsonclick = "";
         edtResponsableId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_nombre_unidad_visible.Enabled = 1;
         chkavAtt_id_unidad_visible.Enabled = 1;
         chkavAtt_responsableactivo_visible.Enabled = 1;
         chkavAtt_responsableemail_visible.Enabled = 1;
         chkavAtt_responsablecargo_visible.Enabled = 1;
         chkavAtt_responsableusuario_visible.Enabled = 1;
         chkavAtt_responsablenombre_visible.Enabled = 1;
         chkavAtt_responsableidentidad_visible.Enabled = 1;
         chkavAtt_responsableid_visible.Enabled = 1;
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
         edtnombre_unidad_Link = "";
         edtResponsableIdentidad_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtnombre_unidad_Visible = -1;
         edtid_unidad_Visible = -1;
         chkResponsableActivo.Visible = -1;
         edtResponsableEmail_Visible = -1;
         edtResponsableCargo_Visible = -1;
         edtResponsableUsuario_Visible = -1;
         edtResponsableNombre_Visible = -1;
         edtResponsableIdentidad_Visible = -1;
         edtResponsableId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Responsables";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E122N2',iparms:[{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E252N1',iparms:[{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E212N2',iparms:[{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV32UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E222N2',iparms:[{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtnombre_unidad_Link',ctrl:'NOMBRE_UNIDAD',prop:'Link'},{av:'edtResponsableIdentidad_Link',ctrl:'RESPONSABLEIDENTIDAD',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E112N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{av:'AV32UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E232N1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E132N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{av:'AV22RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV21GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV22RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E142N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E152N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E162N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E172N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV50Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV44AutoLinksActivityList',fld:'vAUTOLINKSACTIVITYLIST',pic:''},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV36Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV37Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV35ResponsableIdentidad_IsAuthorized',fld:'vRESPONSABLEIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV27ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtResponsableId_Visible',ctrl:'RESPONSABLEID',prop:'Visible'},{av:'edtResponsableIdentidad_Visible',ctrl:'RESPONSABLEIDENTIDAD',prop:'Visible'},{av:'edtResponsableNombre_Visible',ctrl:'RESPONSABLENOMBRE',prop:'Visible'},{av:'edtResponsableUsuario_Visible',ctrl:'RESPONSABLEUSUARIO',prop:'Visible'},{av:'edtResponsableCargo_Visible',ctrl:'RESPONSABLECARGO',prop:'Visible'},{av:'edtResponsableEmail_Visible',ctrl:'RESPONSABLEEMAIL',prop:'Visible'},{av:'chkResponsableActivo.Visible',ctrl:'RESPONSABLEACTIVO',prop:'Visible'},{av:'edtid_unidad_Visible',ctrl:'ID_UNIDAD',prop:'Visible'},{av:'edtnombre_unidad_Visible',ctrl:'NOMBRE_UNIDAD',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E182N2',iparms:[{av:'AV28K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV29OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV47Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E242N1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEIDENTIDAD","{handler:'Valid_Responsableidentidad',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEIDENTIDAD",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLENOMBRE","{handler:'Valid_Responsablenombre',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLENOMBRE",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEUSUARIO","{handler:'Valid_Responsableusuario',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEUSUARIO",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLECARGO","{handler:'Valid_Responsablecargo',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLECARGO",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEEMAIL","{handler:'Valid_Responsableemail',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEEMAIL",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_ID_UNIDAD","{handler:'Valid_Id_unidad',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_ID_UNIDAD",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("VALID_NOMBRE_UNIDAD","{handler:'Valid_Nombre_unidad',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("VALID_NOMBRE_UNIDAD",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_ResponsableId_Visible',fld:'vATT_RESPONSABLEID_VISIBLE',pic:''},{av:'AV15Att_ResponsableIdentidad_Visible',fld:'vATT_RESPONSABLEIDENTIDAD_VISIBLE',pic:''},{av:'AV16Att_ResponsableNombre_Visible',fld:'vATT_RESPONSABLENOMBRE_VISIBLE',pic:''},{av:'AV17Att_ResponsableUsuario_Visible',fld:'vATT_RESPONSABLEUSUARIO_VISIBLE',pic:''},{av:'AV18Att_ResponsableCargo_Visible',fld:'vATT_RESPONSABLECARGO_VISIBLE',pic:''},{av:'AV19Att_ResponsableEmail_Visible',fld:'vATT_RESPONSABLEEMAIL_VISIBLE',pic:''},{av:'AV20Att_ResponsableActivo_Visible',fld:'vATT_RESPONSABLEACTIVO_VISIBLE',pic:''},{av:'AV42Att_id_unidad_Visible',fld:'vATT_ID_UNIDAD_VISIBLE',pic:''},{av:'AV43Att_nombre_unidad_Visible',fld:'vATT_NOMBRE_UNIDAD_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV27ClassCollection = new GxSimpleCollection<string>();
         AV50Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV44AutoLinksActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV47Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV30GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         A29ResponsableIdentidad = "";
         A30ResponsableNombre = "";
         A96ResponsableUsuario = "";
         A27ResponsableCargo = "";
         A28ResponsableEmail = "";
         A114nombre_unidad = "";
         AV36Update = "";
         AV37Delete = "";
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
         AV52Update_GXI = "";
         AV53Delete_GXI = "";
         scmdbuf = "";
         H002N2_A103id_unidad = new int[1] ;
         H002N2_A26ResponsableActivo = new bool[] {false} ;
         H002N2_A28ResponsableEmail = new string[] {""} ;
         H002N2_A27ResponsableCargo = new string[] {""} ;
         H002N2_A96ResponsableUsuario = new string[] {""} ;
         H002N2_A30ResponsableNombre = new string[] {""} ;
         H002N2_A29ResponsableIdentidad = new string[] {""} ;
         H002N2_A6ResponsableId = new short[1] ;
         H002N3_A114nombre_unidad = new string[] {""} ;
         H002N3_n114nombre_unidad = new bool[] {false} ;
         H002N4_A103id_unidad = new int[1] ;
         H002N4_A26ResponsableActivo = new bool[] {false} ;
         H002N4_A28ResponsableEmail = new string[] {""} ;
         H002N4_A27ResponsableCargo = new string[] {""} ;
         H002N4_A96ResponsableUsuario = new string[] {""} ;
         H002N4_A30ResponsableNombre = new string[] {""} ;
         H002N4_A29ResponsableIdentidad = new string[] {""} ;
         H002N4_A6ResponsableId = new short[1] ;
         H002N5_A114nombre_unidad = new string[] {""} ;
         H002N5_n114nombre_unidad = new bool[] {false} ;
         AV5Context = new SdtK2BContext(context);
         AV31GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV33Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV34Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV40ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV41ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV24GridStateKey = "";
         AV25GridState = new SdtK2BGridState(context);
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV38TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV45OutFile = "";
         AV46Guid = (Guid)(Guid.Empty);
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
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwresponsable__default(),
            new Object[][] {
                new Object[] {
               H002N2_A103id_unidad, H002N2_A26ResponsableActivo, H002N2_A28ResponsableEmail, H002N2_A27ResponsableCargo, H002N2_A96ResponsableUsuario, H002N2_A30ResponsableNombre, H002N2_A29ResponsableIdentidad, H002N2_A6ResponsableId
               }
               , new Object[] {
               H002N4_A103id_unidad, H002N4_A26ResponsableActivo, H002N4_A28ResponsableEmail, H002N4_A27ResponsableCargo, H002N4_A96ResponsableUsuario, H002N4_A30ResponsableNombre, H002N4_A29ResponsableIdentidad, H002N4_A6ResponsableId
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwresponsable__datastore1(),
            new Object[][] {
                new Object[] {
               H002N3_A114nombre_unidad, H002N3_n114nombre_unidad
               }
               , new Object[] {
               H002N5_A114nombre_unidad, H002N5_n114nombre_unidad
               }
            }
         );
         AV50Pgmname = "WWResponsable";
         /* GeneXus formulas. */
         AV50Pgmname = "WWResponsable";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV29OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV32UC_OrderedBy ;
      private short AV22RowsPerPageVariable ;
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
      private short AV21GridSettingsRowsPerPageVariable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_146 ;
      private int nGXsfl_146_idx=1 ;
      private int subGrid_Rows ;
      private int AV8CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtResponsableId_Visible ;
      private int edtResponsableIdentidad_Visible ;
      private int edtResponsableNombre_Visible ;
      private int edtResponsableUsuario_Visible ;
      private int edtResponsableCargo_Visible ;
      private int edtResponsableEmail_Visible ;
      private int edtid_unidad_Visible ;
      private int edtnombre_unidad_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int A103id_unidad ;
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
      private int AV51GXV1 ;
      private int AV54GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV55GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV56GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_146_idx="0001" ;
      private string AV28K2BToolsGenericSearchField ;
      private string AV50Pgmname ;
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
      private string edtResponsableIdentidad_Link ;
      private string edtnombre_unidad_Link ;
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
      private string edtResponsableId_Internalname ;
      private string edtResponsableIdentidad_Internalname ;
      private string edtResponsableNombre_Internalname ;
      private string edtResponsableUsuario_Internalname ;
      private string edtResponsableCargo_Internalname ;
      private string edtResponsableEmail_Internalname ;
      private string chkResponsableActivo_Internalname ;
      private string edtid_unidad_Internalname ;
      private string edtnombre_unidad_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string chkavAtt_responsableid_visible_Internalname ;
      private string chkavAtt_responsableidentidad_visible_Internalname ;
      private string chkavAtt_responsablenombre_visible_Internalname ;
      private string chkavAtt_responsableusuario_visible_Internalname ;
      private string chkavAtt_responsablecargo_visible_Internalname ;
      private string chkavAtt_responsableemail_visible_Internalname ;
      private string chkavAtt_responsableactivo_visible_Internalname ;
      private string chkavAtt_id_unidad_visible_Internalname ;
      private string chkavAtt_nombre_unidad_visible_Internalname ;
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
      private string divResponsableid_gridsettingscontainer_Internalname ;
      private string divResponsableidentidad_gridsettingscontainer_Internalname ;
      private string divResponsablenombre_gridsettingscontainer_Internalname ;
      private string divResponsableusuario_gridsettingscontainer_Internalname ;
      private string divResponsablecargo_gridsettingscontainer_Internalname ;
      private string divResponsableemail_gridsettingscontainer_Internalname ;
      private string divResponsableactivo_gridsettingscontainer_Internalname ;
      private string divId_unidad_gridsettingscontainer_Internalname ;
      private string divNombre_unidad_gridsettingscontainer_Internalname ;
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
      private string sGXsfl_146_fel_idx="0001" ;
      private string ROClassString ;
      private string edtResponsableId_Jsonclick ;
      private string edtResponsableIdentidad_Jsonclick ;
      private string edtResponsableNombre_Jsonclick ;
      private string edtResponsableUsuario_Jsonclick ;
      private string edtResponsableCargo_Jsonclick ;
      private string edtResponsableEmail_Jsonclick ;
      private string GXCCtl ;
      private string edtid_unidad_Jsonclick ;
      private string edtnombre_unidad_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV35ResponsableIdentidad_IsAuthorized ;
      private bool AV14Att_ResponsableId_Visible ;
      private bool AV15Att_ResponsableIdentidad_Visible ;
      private bool AV16Att_ResponsableNombre_Visible ;
      private bool AV17Att_ResponsableUsuario_Visible ;
      private bool AV18Att_ResponsableCargo_Visible ;
      private bool AV19Att_ResponsableEmail_Visible ;
      private bool AV20Att_ResponsableActivo_Visible ;
      private bool AV42Att_id_unidad_Visible ;
      private bool AV43Att_nombre_unidad_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool A26ResponsableActivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n114nombre_unidad ;
      private bool bGXsfl_146_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV23RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV36Update_IsBlob ;
      private bool AV37Delete_IsBlob ;
      private string AV47Uri ;
      private string A29ResponsableIdentidad ;
      private string A30ResponsableNombre ;
      private string A96ResponsableUsuario ;
      private string A27ResponsableCargo ;
      private string A28ResponsableEmail ;
      private string A114nombre_unidad ;
      private string AV52Update_GXI ;
      private string AV53Delete_GXI ;
      private string AV24GridStateKey ;
      private string AV45OutFile ;
      private string AV36Update ;
      private string AV37Delete ;
      private Guid AV46Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_responsableid_visible ;
      private GXCheckbox chkavAtt_responsableidentidad_visible ;
      private GXCheckbox chkavAtt_responsablenombre_visible ;
      private GXCheckbox chkavAtt_responsableusuario_visible ;
      private GXCheckbox chkavAtt_responsablecargo_visible ;
      private GXCheckbox chkavAtt_responsableemail_visible ;
      private GXCheckbox chkavAtt_responsableactivo_visible ;
      private GXCheckbox chkavAtt_id_unidad_visible ;
      private GXCheckbox chkavAtt_nombre_unidad_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private GXCheckbox chkResponsableActivo ;
      private IDataStoreProvider pr_default ;
      private int[] H002N2_A103id_unidad ;
      private bool[] H002N2_A26ResponsableActivo ;
      private string[] H002N2_A28ResponsableEmail ;
      private string[] H002N2_A27ResponsableCargo ;
      private string[] H002N2_A96ResponsableUsuario ;
      private string[] H002N2_A30ResponsableNombre ;
      private string[] H002N2_A29ResponsableIdentidad ;
      private short[] H002N2_A6ResponsableId ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] H002N3_A114nombre_unidad ;
      private bool[] H002N3_n114nombre_unidad ;
      private int[] H002N4_A103id_unidad ;
      private bool[] H002N4_A26ResponsableActivo ;
      private string[] H002N4_A28ResponsableEmail ;
      private string[] H002N4_A27ResponsableCargo ;
      private string[] H002N4_A96ResponsableUsuario ;
      private string[] H002N4_A30ResponsableNombre ;
      private string[] H002N4_A29ResponsableIdentidad ;
      private short[] H002N4_A6ResponsableId ;
      private string[] H002N5_A114nombre_unidad ;
      private bool[] H002N5_n114nombre_unidad ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV27ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV30GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV44AutoLinksActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV40ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV25GridState ;
      private SdtK2BGridState_FilterValue AV26GridStateFilterValue ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV31GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV34Message ;
      private SdtK2BTrnContext AV38TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV41ActivityListItem ;
   }

   public class wwresponsable__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002N2( IGxContext context ,
                                             short AV29OrderedBy ,
                                             string AV28K2BToolsGenericSearchField ,
                                             short A6ResponsableId ,
                                             string A29ResponsableIdentidad ,
                                             string A30ResponsableNombre ,
                                             string A96ResponsableUsuario ,
                                             string A27ResponsableCargo ,
                                             string A28ResponsableEmail ,
                                             int A103id_unidad ,
                                             string A114nombre_unidad )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [id_unidad], [ResponsableActivo], [ResponsableEmail], [ResponsableCargo], [ResponsableUsuario], [ResponsableNombre], [ResponsableIdentidad], [ResponsableId] FROM [Responsable]";
         scmdbuf += sWhereString;
         if ( AV29OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [ResponsableId]";
         }
         else if ( AV29OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [ResponsableId] DESC";
         }
         else if ( AV29OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad]";
         }
         else if ( AV29OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H002N4( IGxContext context ,
                                             short AV29OrderedBy ,
                                             string AV28K2BToolsGenericSearchField ,
                                             short A6ResponsableId ,
                                             string A29ResponsableIdentidad ,
                                             string A30ResponsableNombre ,
                                             string A96ResponsableUsuario ,
                                             string A27ResponsableCargo ,
                                             string A28ResponsableEmail ,
                                             int A103id_unidad ,
                                             string A114nombre_unidad )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [id_unidad], [ResponsableActivo], [ResponsableEmail], [ResponsableCargo], [ResponsableUsuario], [ResponsableNombre], [ResponsableIdentidad], [ResponsableId] FROM [Responsable]";
         scmdbuf += sWhereString;
         if ( AV29OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [ResponsableId]";
         }
         else if ( AV29OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [ResponsableId] DESC";
         }
         else if ( AV29OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad]";
         }
         else if ( AV29OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad] DESC";
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
                     return conditional_H002N2(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] );
               case 1 :
                     return conditional_H002N4(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmH002N2;
          prmH002N2 = new Object[] {
          };
          Object[] prmH002N4;
          prmH002N4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N4,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

 public class wwresponsable__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH002N3;
        prmH002N3 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmH002N5;
        prmH002N5 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002N3", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002N5", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N5,1, GxCacheFrequency.OFF ,true,false )
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

}
